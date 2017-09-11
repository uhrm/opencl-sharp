using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using OpenCl.Compiler;

namespace OpenCl.Samples
{
    public static class BitonicSortSample
    {

        private static int[] data =
        {
            111,  83, 142, 245,  62,  41,  79,  33,
            245, 190,  83,  69, 248, 196, 159, 182,
            236,   2,  49,  82,  53, 128,  91,   0,
             41, 143,  74, 186, 242,  34, 124,  54,
            162, 154,  38,  58, 100, 146, 220, 143,
            251, 102, 172,  46,  26, 229, 210, 110,
             24,  49,   9,  16, 164, 219,  48, 191,
             65, 123,  97,  17,   1, 148, 251, 242,
        };

        [Kernel, ClName("bitonic_sort")]
        private static void BitonicSort([Global] int4[] data, int stage, int pass, int dir)
        {
            var i = Cl.GetGlobalId(0);
            int4 srcLeft, srcRight, mask;
            int4 imask10 = new int4(0,  0, -1, -1);
            int4 imask11 = new int4(0, -1,  0, -1);

            if (stage > 0)
            {
                if (pass > 0)    // upper level pass, exchange between two fours
                {
                    var r = 1 << (pass - 1);
                    var lmask = r - 1;
                    var left = ((i>>(pass-1)) << pass) + (i & lmask);
                    var right = left + r;

                    srcLeft = data[left];
                    srcRight = data[right];
                    mask = srcLeft < srcRight;

                    int4 imin = (srcLeft &  mask) | (srcRight & ~mask);
                    int4 imax = (srcLeft & ~mask) | (srcRight &  mask);

                    if ((((i>>(stage-1)) & 1) ^ dir) != 0)
                    {
                        data[left]  = imin;
                        data[right] = imax;
                    }
                    else
                    {
                        data[right] = imin;
                        data[left]  = imax;
                    }
                }
                else    // last pass, sort inside one four
                {
                    srcLeft = data[i];
                    srcRight = srcLeft.zwxy;
                    mask = (srcLeft < srcRight) ^ imask10;

                    if ((((i >> stage) & 1) ^ dir) != 0)
                    {
                        srcLeft = (srcLeft & mask) | (srcRight & ~mask);
                        srcRight = srcLeft.yxwz;
                        mask = (srcLeft < srcRight) ^ imask11;
                        data[i] = (srcLeft & mask) | (srcRight & ~mask);
                    }
                    else
                    {
                        srcLeft = (srcLeft & ~mask) | (srcRight & mask);
                        srcRight = srcLeft.yxwz;
                        mask = (srcLeft < srcRight) ^ imask11;
                        data[i] = (srcLeft & ~mask) | (srcRight & mask);
                    }
                }
            }
            else    // first stage, sort inside one four
            {
                int4 imask0 = new int4(0, -1, -1,  0);
                srcLeft = data[i];
                srcRight = srcLeft.yxwz;
                mask = (srcLeft < srcRight) ^ imask0;
                if (dir != 0)
                    srcLeft = (srcLeft &  mask) | (srcRight & ~mask);
                else
                    srcLeft = (srcLeft & ~mask) | (srcRight &  mask);

                srcRight = srcLeft.zwxy;
                mask = (srcLeft < srcRight) ^ imask10;

                if (((i & 1) ^ dir) != 0)
                {
                    srcLeft = (srcLeft & mask) | (srcRight & ~mask);
                    srcRight = srcLeft.yxwz;
                    mask = (srcLeft < srcRight) ^ imask11;
                    data[i] = (srcLeft & mask) | (srcRight & ~mask);
                }
                else
                {
                    srcLeft = (srcLeft & ~mask) | (srcRight & mask);
                    srcRight = srcLeft.yxwz;
                    mask = (srcLeft < srcRight) ^ imask11;
                    data[i] = (srcLeft & ~mask) | (srcRight & mask);
                }
            }
        }

        private static void RunNative(string source, bool ascending)
        {
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            Context context = Context.CreateContext(platform, devices, null, null);
            var program = Program.CreateProgramWithSource(context, new String[] { source });
            try {
                program.BuildProgram(devices, null, null, null);
            }
            catch (OpenClException ex) {
                Console.WriteLine("*** Error building kernel 'bitonic_sort'");
                if (ex.ErrorCode == ErrorCode.BuildProgramFailure) {
                    Console.WriteLine("*** Build log: {0}", program.BuildInfo.GetLog(devices[0]));
                    Console.WriteLine("*** Source code:");
                    Console.WriteLine(source);
                }
                return;
            }
            var kernel = Kernel.CreateKernel(program, "bitonic_sort");
            var dataBuffer = Mem<int>.CreateBuffer(context, MemFlags.ReadWrite | MemFlags.CopyHostPtr, data);
            if (dataBuffer.Size < Marshal.SizeOf<int>()*data.Length) {
                Console.WriteLine("*** Invalid MemObject size: expected >= {0}, found {1}.", Marshal.SizeOf<int>()*data.Length, dataBuffer.Size);
                return;
            }
            var queue = CommandQueue.CreateCommandQueue(context, devices[0]);

            var numStages = 0;
            for (var i =data.Length; i>2; i>>=1){
                numStages++;
            }

            kernel.SetKernelArg(0, (HandleObject)dataBuffer);
            kernel.SetKernelArg(3, ascending ? 1 : 0);

            for (var stage=0; stage<numStages; stage++) {
                kernel.SetKernelArg(1, stage);
                for (var pass=stage; pass>=0; pass--) {
                    kernel.SetKernelArg(2, pass);
                    // set work-item dimensions
                    var gsz = data.Length/(2*4);
                    var global_work_size = new int[] { pass > 0 ? gsz : gsz << 1 }; // number of quad items in input array
                    // execute kernel
                    queue.EnqueueNDRangeKernel(kernel, null, global_work_size, null, null);
                }
            }

            var result = new int[data.Length];
            queue.EnqueueReadBuffer(dataBuffer, true, result);
            PrintArray(result);
        }

        private static void RunManaged(bool ascending)
        {
            var buffer = new int4[data.Length/4];
            GCHandle gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try {
                Marshal.Copy(data, 0, gch.AddrOfPinnedObject(), data.Length);
            }
            finally {
                gch.Free();
            }
            //PrintArray(buffer);

            var numStages = 0;
            for (var i =data.Length; i>2; i>>=1){
                numStages++;
            }

            for (var stage=0; stage<numStages; stage++) {
                for (var pass=stage; pass>=0; pass--) {
                    // set work-item dimensions
                    var gsz = data.Length/(2*4);
                    var global_work_size = new int[] { pass > 0 ? gsz : gsz << 1 }; // number of quad items in input array
                    // execute kernel
                    Cl.RunKernel(
                        global_work_size,
                        new int[] { 1 },
                        (Action<int4[],int,int,int>)BitonicSort,
                        buffer,
                        stage,
                        pass,
                        1
                    );
                }
            }

            PrintArray(buffer);
        }

        private static void PrintArray(int[] data) {
            var rowsize = 8;
            var nrows = data.Length/rowsize;
            if (nrows*rowsize < data.Length) {
                nrows++;
            }
            for (var i=0; i<nrows; i++) {
                Console.Write("*** ");
                for (var j=0; j<rowsize; j++) {
                    Console.Write("{0,3} ", data[i*rowsize+j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("*** ");
        }

        private static void PrintArray(int4[] data) {
            var rowsize = 8;
            var nrows = 4*data.Length/rowsize;
            if (nrows*rowsize < 4*data.Length) {
                nrows++;
            }
            for (var i=0; i<nrows; i++) {
                Console.Write("*** ");
                for (var j=0; j<rowsize/4; j++) {
                    for (var k=0; k<4; k++) {
                        Console.Write("{0,3} ", data[i*rowsize/4+j][k]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("*** ");
        }

        public static void Run()
        {
            Console.WriteLine("*** Raw data:");
            Console.WriteLine("*** ");
            PrintArray(data);

//            Console.WriteLine("*** manifest resource:");
//            Console.WriteLine("*** ");
//            var assembly = Assembly.GetExecutingAssembly();
//            var resourceName = "OpenCl.Samples.Kernels.bitonicsort.cl";
//            var source = (String)null;
//            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
//            using (StreamReader reader = new StreamReader(stream))
//            {
//                source = reader.ReadToEnd();
//            }
//            RunNative(source, true);

            Console.WriteLine("*** IL translation:");
//            Console.WriteLine("*** ");
//            Console.WriteLine(Compiler.EmitKernel("opencl-samples.exe", "OpenCl.Samples.BitonicSortSample", "BitonicSort"));
            Console.WriteLine("*** ");
            RunNative(ClCompiler.EmitKernel("opencl-samples.exe", "OpenCl.Samples.BitonicSortSample", "BitonicSort"), true);

            Console.WriteLine("*** Cl.RunKernel:");
            Console.WriteLine("*** ");
            RunManaged(true);
        }
    }
}

