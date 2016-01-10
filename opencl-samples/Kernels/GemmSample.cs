using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using OpenCl.Compiler;

namespace OpenCl.Samples
{
    public static class GemmSample
    {
        // matrix sizes
        private const int M = 64;
        private const int N = 64;
        private const int K = 64;

        // tile sizes
        private const int TM = 4;
        private const int TN = 4;
        private const int TK = 4;

        // group sizes
        // Note: Apple's OpenCL on CPU only accepts work group size = 1 even
        //       when it advertises a max work group size = 1024
        //       https://github.com/kif/pyFAI/issues/11#issuecomment-10644211
        private const int GM = 1; // number of row groups is M/TM/GM
        private const int GN = 1; // number of column groups is N/TN/GN

        private static readonly Random rnd = new Random(0x4f367a01);

        private static double[] CreateZeroMatrix(int m, int n)
        {
            return new double[m*n];
        }

        private static double[] CreateTestMatrix(int m, int n)
        {
            var A = new double[m*n];
            for (var i=0; i<m; i++) {
                for (var j=0; j<n; j++) {
                    A[i+j*m] = (double)Math.Min(i, j);
                }
            }
            return A;
        }

        private static double[] CreateRandomMatrix(int m, int n)
        {
            var A = new double[m*n];
            for (var i=0; i<m; i++) {
                for (var j=0; j<n; j++) {
                    A[i+j*m] = rnd.NextDouble();
                }
            }
            return A;
        }

        // adapted from reference BLAS (netlib.org)
        private static void Gemm(char trans_a, char trans_b, int m, int n, int k, double alpha,
            double[] da, int lda, double[] db, int ldb, double beta, double[] dc, int ldc)
        {
            if (da == null) {
                throw new ArgumentNullException ("da");
            }
            if (db == null) {
                throw new ArgumentNullException("db");
            }
            if (dc == null) { 
                throw new ArgumentNullException("dc");
            }

            bool nota = trans_a == 'N' || trans_a == 'n';
            bool notb = trans_b == 'N' || trans_b == 'n';

            // quick return if possible
            if ((m == 0) || (n == 0) || (((alpha == 0.0) || (k == 0)) && (beta == 1.0))) {
                return;
            }

            // also if alpha == 0.0
            if (alpha == 0.0) {
                if (beta == 0.0) {
                    for (int i=0; i<m; i++) {
                        for (int j=0, ijc=ldc*i; j<n; j++, ijc++) {
                            dc[ijc] = 0.0;
                        }
                    }
                }
                else {
                    for (int i=0; i<m; i++) {
                        for (int j=0, ijc=ldc*i; j<n; j++, ijc++) {
                            dc[ijc] *= beta;
                        }
                    }
                }
                return;
            }

            if (notb) {
                if (nota) {
                    // form C := alpha*A*B + beta*C
                    for (int j=0; j<n; j++) {
                        if (beta == 0.0) {
                            for (int i=0, ijc=ldc*j; i<m; i++, ijc++) {
                                dc[ijc] = 0.0;
                            }
                        }
                        else if (beta != 1.0) {
                            for (int i=0, ijc=ldc*j; i<m; i++, ijc++) {
                                dc[ijc] *= beta;
                            }
                        }
                        for (int l=0, ljb=ldb*j; l<k; l++, ljb++) {
                            double t = alpha*db[ljb];
                            for (int i=0, ila=lda*l, ijc=ldc*j; i<m; i++, ila++, ijc++) {
                                dc[ijc] += t*da[ila];
                            }
                        }
                    }
                }
                else {
                    // form C := alpha*A'*B + beta*C
                    for (int j=0; j<n; j++) {
                        for (int i=0, ijc=ldc*i; j<n; j++, ijc++) {
                            double t = 0.0;
                            for (int l=0, lia=i, ljb=ldb*l; l<k; l++, lia++, ljb++) {
                                t += da[lia]*db[ljb];
                            }
                            if (beta == 0.0) {
                                dc[ijc] = alpha*t;
                            }
                            else {
                                dc[ijc] = alpha*t + beta*dc[ijc];
                            }
                        }
                    }
                }
            }
            else {
                if (nota) {
                    // form C := alpha*A*B' + beta*C
                    for (int j=0; j<n; j++) {
                        if (beta == 0.0) {
                            for (int i=0, ijc=ldc*j; i<m; i++, ijc++) {
                                dc[ijc] = 0.0;
                            }
                        }
                        else if (beta != 1.0) {
                            for (int i=0, ijc=ldc*j; i<m; i++, ijc++) {
                                dc[ijc] *= beta;
                            }
                        }
                        for (int l=0, jlb=j; l<k; l++, jlb+=ldb) {
                            double t = alpha*db[jlb];
                            for (int i=0, ila=lda*l, ijc=ldc*j; i<m; i++, ila++, ijc++) {
                                dc[ijc] += t*da[ila];
                            }
                        }
                    }
                }
                else {
                    // form C := alpha*A'*B' + beta*C
                    for (int j=0; j<n; j++) {
                        for (int i=0, ijc=ldc*j; i<m; i++, ijc++) {
                            double t = 0.0;
                            for (int l=0, lia=i*lda, jlb=j; l<k; l++, lia++, jlb+=ldb) {
                                t += da[lia]*db[jlb];
                            }
                            if (beta == 0.0) {
                                dc[ijc] = alpha*t;
                            }
                            else {
                                dc[ijc] = alpha*t + beta*dc[ijc];
                            }
                        }
                    }
                }
            }
        }

        [Kernel, ClName("gemm_nn_f64")]
        private static unsafe void GemmNN([Global] double[] A, int lda, [Global] double[] B, int ldb, [Global] double[] C, int ldc, int k, double alpha, double beta)
        {
            // computes C := alpha*A*B + beta*C

            int Aind = Cl.GetGroupId(0)*GM*TM + Cl.GetLocalId(0);
            int Bind = Cl.GetGroupId(1)*GN*TN + Cl.GetLocalId(1);
            int Cind = Aind + Bind*ldc;

            Bind *= ldb;

            double* c = stackalloc double[TM*TN];
            for (var i=0; i<TM*TN; i++) {
                c[i] = 0.0;
            }

            for (int lb = 0; lb < k; lb += TK) {
                for (int i = 0; i < TM; ++i) {
                    for (int j = 0; j < TN; ++j) {
                        for (int l = 0; l < TK; ++l) {
                            c[i*TN + j] += A[Aind + l*lda + i*GM] * B[Bind + l + j*ldb*GN];
                        }
                    }
                }
                Aind += lda*TK;
                Bind += TK;
            }

            // store accumulated results from c to C with alpha and beta multiplication
            for (int i = 0; i < TM; ++i) {
                for (int j = 0; j < TN; ++j) {
                    int Ccur = Cind + i*GM + j*GN*ldc;
                    C[Ccur] = alpha*c[i*TN + j] + beta*C[Ccur];
                }
            }
        }

        private static void RunNative(string source)
        {
            var A = CreateRandomMatrix(M, K);
            var B = CreateRandomMatrix(K, N);
            var C = CreateRandomMatrix(M, N);
            var Z = CreateZeroMatrix(M, N);
            Array.Copy(C, Z, M*N);

            var error = ErrorCode.Success;
            var platform = Platform.GetPlatformIDs()[0];
            var devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var Abuf = null as Mem<double>;
                var Bbuf = null as Mem<double>;
                var Cbuf = null as Mem<double>;

                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    program.BuildProgram(devices, null, null, null);
                    kernel = Kernel.CreateKernel(program, "gemm_nn_f64");
                    Abuf = Mem<double>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, A);
                    Bbuf = Mem<double>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, B);
                    Cbuf = Mem<double>.CreateBuffer(context, MemFlags.ReadWrite | MemFlags.CopyHostPtr, C);

                    kernel.SetKernelArg(0, (HandleObject)Abuf);
                    kernel.SetKernelArg(1, K);
                    kernel.SetKernelArg(2, (HandleObject)Bbuf);
                    kernel.SetKernelArg(3, N);
                    kernel.SetKernelArg(4, (HandleObject)Cbuf);
                    kernel.SetKernelArg(5, N);
                    kernel.SetKernelArg(6, K);
                    kernel.SetKernelArg(7, 0.5);
                    kernel.SetKernelArg(8, 0.5);

//                    Console.WriteLine("*** Enqueueing kernel.");
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { M/TM, N/TN }, new int[] { GM, GN }, null);
//                    Console.WriteLine("*** Enqueueing read buffer.");
                    queue.EnqueueReadBuffer(Cbuf, true, C);
//                    Console.WriteLine("*** Waiting for queue to finish.");
                    queue.Finish();
                }
                catch (OpenClException ex) {
                    error = ex.ErrorCode;
                    switch (error)
                    {
                    case ErrorCode.BuildProgramFailure:
                        Console.WriteLine("*** Error building kernel 'gemm_nn_f64'");
                        Console.WriteLine("*** Build log: {0}", program.BuildInfo.GetLog(devices[0]));
                        Console.WriteLine("*** Source code:");
                        Console.WriteLine(source);
                        break;
                    case ErrorCode.InvalidWorkGroupSize:
                        Console.WriteLine("*** Invalid workgroup size (max. workgroup size: {0}; max. work item sizes: {1},{2},{3}).",
                            devices[0].MaxWorkGroupSize,
                            devices[0].MaxWorkItemSizes[0],
                            devices[0].MaxWorkItemSizes[1],
                            devices[0].MaxWorkItemSizes[2]);
                        break;
                    default:
                        Console.WriteLine("*** OpenCL error {0}: {1}", (int)error, error);
                        break;
                    }
                    Console.WriteLine("*** ");
                }
                finally {
                    if (Cbuf != null) Cbuf.Dispose();
                    if (Bbuf != null) Bbuf.Dispose();
                    if (Abuf != null) Abuf.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }

                if (error != ErrorCode.Success) {
                    return;
                }

                Gemm('N', 'N', M, N, K, 0.5, A, K, B, N, 0.5, Z, N);

                for (var i=0; i<M; i++) {
                    for (var j=0; j<N; j++) {
                        if (Math.Abs(C[i*N+j]-Z[i*N+j]) > 1e-10) {
                            Console.WriteLine("*** Error in elemen ({0},{1}): expected {2}, found {3}.", i, j, Z[i*N+j], C[i*N+j]);
                        }
                    }
                }
            }
        }

        private static void RunManaged()
        {
            var A = CreateRandomMatrix(M, K);
            var B = CreateTestMatrix(K, N);
            var C = CreateRandomMatrix(M, N);
            var Z = CreateZeroMatrix(M, N);
            Array.Copy(C, Z, M*N);

            Cl.RunKernel(
                new int[] { M/TM, N/TN },
                new int[] { GM, GN },
                (Action<double[],int,double[],int,double[],int,int,double,double>)GemmNN,
                A, K, B, N, C, N, K, 0.5, 0.5
            );

            Gemm('N', 'N', M, N, K, 0.5, A, K, B, N, 0.5, Z, N);

            for (var i=0; i<M; i++) {
                for (var j=0; j<N; j++) {
                    if (Math.Abs(C[i+j*M]-Z[i+j*M]) > 1e-10) {
                        Console.WriteLine("*** Error in elemen ({0},{1}): expected {2}, found {3}.", i, j, Z[i+j*M], C[i+j*M]);
                    }
                }
            }
        }

        public static void Run()
        {
            Console.WriteLine("*** IL translation:");
//            Console.WriteLine("*** ");
//            Console.WriteLine(Compiler.EmitKernel("opencl-samples.exe", "OpenCl.Samples.GemmSample", "GemmNN"));
            Console.WriteLine("*** ");
            RunNative(ClCompiler.EmitKernel("opencl-samples.exe", "OpenCl.Samples.GemmSample", "GemmNN"));

            Console.WriteLine("*** Cl.RunKernel:");
            Console.WriteLine("*** ");
            RunManaged();
        }
    }
}
