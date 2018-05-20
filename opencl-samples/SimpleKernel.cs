using System;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using OpenCl.Compiler;

namespace OpenCl.Samples
{
    public static class SimpleKernelSample
    {
        private static readonly int len = 64;

        private static int[] a =
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

        private static int[] b =
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

        [Kernel, ClName("simple_kernel")]
        private static void SimpleKernel([Global] int4[] a, [Global] int4[] b, [Global] int4[] r)
        {
            long i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        private static void RunManaged()
        {
            GCHandle gch;
            var abuf = new int4[(len+3)/4];
            gch = GCHandle.Alloc(abuf, GCHandleType.Pinned);
            try {
                Marshal.Copy(a, 0, gch.AddrOfPinnedObject(), a.Length);
            }
            finally {
                gch.Free();
            }
            var bbuf = new int4[(len+3)/4];
            gch = GCHandle.Alloc(bbuf, GCHandleType.Pinned);
            try {
                Marshal.Copy(b, 0, gch.AddrOfPinnedObject(), b.Length);
            }
            finally {
                gch.Free();
            }
            var rbuf = new int4[(len+3)/4];

            // set work-item dimensions
            var global_work_size = new int[] { (len+3)/4 }; // number of quad items in input arrays
            // execute kernel
            Cl.RunKernel(
                global_work_size,
                new int[] { 1 },
                (Action<int4[],int4[],int4[]>)SimpleKernel,
                abuf,
                bbuf,
                rbuf
            );

            PrintArray(rbuf);
        }

        private static void RunNative(byte[] module)
        {
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            var context = Context.CreateContext(platform, device, null, null);
            var program = Program.CreateProgramWithIL(context, module);
            try {
                program.BuildProgram(device);
            }
            catch (OpenClException) {
                Console.WriteLine("*** Error creating kernel 'simple_kernel'");
                return;
            }
            var kernel = Kernel.CreateKernel(program, "simple_kernel");
            var abuf = Mem<int>.CreateBuffer(context, MemFlags.ReadWrite | MemFlags.CopyHostPtr, a);
            if (abuf.Size < Marshal.SizeOf<int>()*a.Length) {
                Console.WriteLine("*** Invalid 'abuf' MemObject size: expected >= {0}, found {1}.", Marshal.SizeOf<int>()*a.Length, abuf.Size);
                return;
            }
            var bbuf = Mem<int>.CreateBuffer(context, MemFlags.ReadWrite | MemFlags.CopyHostPtr, b);
            if (bbuf.Size < Marshal.SizeOf<int>()*b.Length) {
                Console.WriteLine("*** Invalid 'bbuf' MemObject size: expected >= {0}, found {1}.", Marshal.SizeOf<int>()*b.Length, bbuf.Size);
                return;
            }
            var rbuf = Mem<int>.CreateBuffer(context, MemFlags.ReadWrite, Marshal.SizeOf<int>()*((len+3) & ~3));
            if (rbuf.Size < Marshal.SizeOf<int>()*len) {
                Console.WriteLine("*** Invalid 'rbuf' MemObject size: expected >= {0}, found {1}.", Marshal.SizeOf<int>()*len, rbuf.Size);
                return;
            }
            var queue = CommandQueue.CreateCommandQueue(context, device);

            kernel.SetKernelArg(0, (HandleObject)abuf);
            kernel.SetKernelArg(1, (HandleObject)bbuf);
            kernel.SetKernelArg(2, (HandleObject)rbuf);

            // set work-item dimensions
            var global_work_size = new int[] { (len+3)/4 }; // number of quad items in input arrays
            // execute kernel
            queue.EnqueueNDRangeKernel(kernel, null, global_work_size, null, null);

            var result = new int[len];
            queue.EnqueueReadBuffer(rbuf, true, result);

            PrintArray(result);
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
            Console.WriteLine("*** Managed:");
            Console.WriteLine("*** ");
            RunManaged();

            Console.WriteLine("*** Native SPIR-V:");
            Console.WriteLine("*** ");
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-samples", "OpenCl.Samples.SimpleKernelSample", "SimpleKernel", module);

            var buf = module.ToArray();

            using (var stream = new FileStream("simple_kernel.spv", FileMode.Create))
            {
                stream.Write(buf, 0, buf.Length);
            }
            RunNative(buf);
        }
    }
}
