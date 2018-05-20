using System;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using OpenCl.Compiler;

namespace OpenCl.Samples
{
    public static class TestKernelSample
    {
        private static short4[] a =
        {
            new short4(7, 14, 21, 28), new short4(5, 15, 21, 20)
        };

        private static short4[] b =
        {
            new short4(5, 15, 21, 20), new short4(7, 14, 21, 28)
        };

        [Kernel, ClName("test_kernel")]
        private static void TestKernel([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            long i = Cl.GetGlobalId(0);
            // r[i] = a[i] < b[i];
            // r[i] = a[i] <= b[i];
            // r[i] = a[i] > b[i];
            // r[i] = a[i] >= b[i];
            // r[i] = a[i] == b[i];
            r[i] = a[i] != b[i];
        }

        private static void RunManaged()
        {
            var abuf = new short4[2];
            Array.Copy(a, abuf, 2);
            var bbuf = new short4[2];
            Array.Copy(b, bbuf, 2);
            var rbuf = new short4[2];

            // set work-item dimensions
            var global_work_size = new int[] { 2 };
            // execute kernel
            Cl.RunKernel(
                global_work_size,
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)TestKernel,
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
                Console.WriteLine("*** Error creating kernel 'test_kernel'");
                return;
            }
            var kernel = Kernel.CreateKernel(program, "test_kernel");
            var abuf = Mem<short4>.CreateBuffer(context, MemFlags.ReadWrite | MemFlags.CopyHostPtr, a);
            var bbuf = Mem<short4>.CreateBuffer(context, MemFlags.ReadWrite | MemFlags.CopyHostPtr, b);
            var rbuf = Mem<short4>.CreateBuffer(context, MemFlags.ReadWrite, Marshal.SizeOf<short4>()*2);
            var queue = CommandQueue.CreateCommandQueue(context, device);

            kernel.SetKernelArg(0, (HandleObject)abuf);
            kernel.SetKernelArg(1, (HandleObject)bbuf);
            kernel.SetKernelArg(2, (HandleObject)rbuf);

            // set work-item dimensions
            var global_work_size = new int[] { 2 };
            // execute kernel
            queue.EnqueueNDRangeKernel(kernel, null, global_work_size, null, null);

            var result = new short4[2];
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

        private static void PrintArray(short4[] data) {
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
            SpirCompiler.EmitKernel("opencl-samples", "OpenCl.Samples.TestKernelSample", "TestKernel", module);

            var buf = module.ToArray();

            using (var stream = new FileStream("test_kernel.spv", FileMode.Create))
            {
                stream.Write(buf, 0, buf.Length);
            }
            RunNative(buf);
        }
    }
}
