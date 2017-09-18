using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestDouble3
    {
        [Kernel]
        private static void test_double3_add([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
        }

        [Test]
        public void TestAddCl()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_add");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_add");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(  12.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
        }

        [Test]
        public void TestAddSpir()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_add", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double3_add");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(  12.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
        }

        [Kernel]
        private static void test_double3_sub([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(   4.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(   6.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
        }

        [Test]
        public void TestSubCl()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_sub");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_sub");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(   2.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(   4.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(   6.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
        }

        [Test]
        public void TestSubSpir()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_sub", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double3_sub");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(   2.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(   4.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(   6.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
        }

        [Kernel]
        private static void test_double3_mul([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
        }

        [Test]
        public void TestMulCl()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_mul");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_mul");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(  35.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
        }

        [Test]
        public void TestMulSpir()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_mul", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double3_mul");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(  35.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
        }

        [Kernel]
        private static void test_double3_div([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1.3999999999999999, r[0].s0, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s1, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
        }

        [Test]
        public void TestDivCl()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_div");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_div");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(   1.3999999999999999, r[0].s0, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s1, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
        }

        [Test]
        public void TestDivSpir()
        {
            double3[] a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            double3[] b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            double3[] r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_div", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double3_div");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(   1.3999999999999999, r[0].s0, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s1, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
        }

        [Kernel]
        private static void test_double3_eq([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            double3[] a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            double3[] b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_eq");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_double3_neq([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            double3[] a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            double3[] b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_neq");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_double3_lt([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            double3[] a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            double3[] b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_lt");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_double3_le([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            double3[] a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            double3[] b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_le");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_double3_gt([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            double3[] a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            double3[] b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_gt");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_double3_ge([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            double3[] a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            double3[] b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double3>;
                var mb = null as Mem<double3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double3_ge");
                    ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_components1([Global] double[] r, [Global] double3[] w)
        {
            double3 ar = new double3((double)1, (double)2, (double)3);
            double aw = (double)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
            r[2] = ar.z;
            w[2].z = aw;
        }

        [Test]
        public void TestComponentAccessors1()
        {
            int nr = 3;
            int nw = 3;
            double[] r = new double[nr];
            double3[] w = new double3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double[],double3[]>)test_components1,
                r, w
            );
            Assert.AreEqual((double)1, r[0]);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)0, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
            Assert.AreEqual((double)0, w[1].s2);
            Assert.AreEqual((double)3, r[2]);
            Assert.AreEqual((double)1, w[2].s2);
            Assert.AreEqual((double)0, w[2].s0);
            Assert.AreEqual((double)0, w[2].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components1");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<double>;
                var mw = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components1");
                    mr = Mem<double>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double>());
                    mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueFillBuffer(mw, default(double3));
                    queue.Finish();
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, false, r);
                    queue.EnqueueReadBuffer(mw, false, w);
                    queue.Finish();
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mw != null) mw.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual((double)1, r[0]);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)0, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
            Assert.AreEqual((double)0, w[1].s2);
            Assert.AreEqual((double)3, r[2]);
            Assert.AreEqual((double)1, w[2].s2);
            Assert.AreEqual((double)0, w[2].s0);
            Assert.AreEqual((double)0, w[2].s1);
        }
        [Kernel]
        private static void test_components2([Global] double2[] r, [Global] double3[] w)
        {
            double3 ar = new double3((double)1, (double)2, (double)3);
            double2 aw = new double2((double)1, (double)2);
            r[0] = ar.xx;
            r[1] = ar.xy;
            w[0].xy = aw;
            r[2] = ar.xz;
            w[1].xz = aw;
            r[3] = ar.yx;
            w[2].yx = aw;
            r[4] = ar.yy;
            r[5] = ar.yz;
            w[3].yz = aw;
            r[6] = ar.zx;
            w[4].zx = aw;
            r[7] = ar.zy;
            w[5].zy = aw;
            r[8] = ar.zz;
        }

        [Test]
        public void TestComponentAccessors2()
        {
            int nr = 9;
            int nw = 6;
            double2[] r = new double2[nr];
            double3[] w = new double3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double2[],double3[]>)test_components2,
                r, w
            );
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)2, r[1].s1);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)3, r[2].s1);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)0, w[1].s1);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)1, r[3].s1);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)0, w[2].s2);
            Assert.AreEqual((double)2, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[5].s0);
            Assert.AreEqual((double)3, r[5].s1);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)0, w[3].s0);
            Assert.AreEqual((double)3, r[6].s0);
            Assert.AreEqual((double)1, r[6].s1);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)0, w[4].s1);
            Assert.AreEqual((double)3, r[7].s0);
            Assert.AreEqual((double)2, r[7].s1);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)0, w[5].s0);
            Assert.AreEqual((double)3, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components2");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<double2>;
                var mw = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components2");
                    mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double2>());
                    mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueFillBuffer(mw, default(double3));
                    queue.Finish();
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, false, r);
                    queue.EnqueueReadBuffer(mw, false, w);
                    queue.Finish();
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mw != null) mw.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)2, r[1].s1);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)3, r[2].s1);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)0, w[1].s1);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)1, r[3].s1);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)0, w[2].s2);
            Assert.AreEqual((double)2, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[5].s0);
            Assert.AreEqual((double)3, r[5].s1);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)0, w[3].s0);
            Assert.AreEqual((double)3, r[6].s0);
            Assert.AreEqual((double)1, r[6].s1);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)0, w[4].s1);
            Assert.AreEqual((double)3, r[7].s0);
            Assert.AreEqual((double)2, r[7].s1);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)0, w[5].s0);
            Assert.AreEqual((double)3, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
        }
        [Kernel]
        private static void test_components3([Global] double3[] r, [Global] double3[] w)
        {
            double3 ar = new double3((double)1, (double)2, (double)3);
            double3 aw = new double3((double)1, (double)2, (double)3);
            r[0] = ar.xxx;
            r[1] = ar.xxy;
            r[2] = ar.xxz;
            r[3] = ar.xyx;
            r[4] = ar.xyy;
            r[5] = ar.xyz;
            w[0].xyz = aw;
            r[6] = ar.xzx;
            r[7] = ar.xzy;
            w[1].xzy = aw;
            r[8] = ar.xzz;
            r[9] = ar.yxx;
            r[10] = ar.yxy;
            r[11] = ar.yxz;
            w[2].yxz = aw;
            r[12] = ar.yyx;
            r[13] = ar.yyy;
            r[14] = ar.yyz;
            r[15] = ar.yzx;
            w[3].yzx = aw;
            r[16] = ar.yzy;
            r[17] = ar.yzz;
            r[18] = ar.zxx;
            r[19] = ar.zxy;
            w[4].zxy = aw;
            r[20] = ar.zxz;
            r[21] = ar.zyx;
            w[5].zyx = aw;
            r[22] = ar.zyy;
            r[23] = ar.zyz;
            r[24] = ar.zzx;
            r[25] = ar.zzy;
            r[26] = ar.zzz;
        }

        [Test]
        public void TestComponentAccessors3()
        {
            int nr = 27;
            int nw = 6;
            double3[] r = new double3[nr];
            double3[] w = new double3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double3[],double3[]>)test_components3,
                r, w
            );
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[0].s2);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)1, r[1].s1);
            Assert.AreEqual((double)2, r[1].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)3, r[2].s2);
            Assert.AreEqual((double)1, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
            Assert.AreEqual((double)1, r[3].s2);
            Assert.AreEqual((double)1, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[4].s2);
            Assert.AreEqual((double)1, r[5].s0);
            Assert.AreEqual((double)2, r[5].s1);
            Assert.AreEqual((double)3, r[5].s2);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)3, w[0].s2);
            Assert.AreEqual((double)1, r[6].s0);
            Assert.AreEqual((double)3, r[6].s1);
            Assert.AreEqual((double)1, r[6].s2);
            Assert.AreEqual((double)1, r[7].s0);
            Assert.AreEqual((double)3, r[7].s1);
            Assert.AreEqual((double)2, r[7].s2);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)3, w[1].s1);
            Assert.AreEqual((double)1, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
            Assert.AreEqual((double)3, r[8].s2);
            Assert.AreEqual((double)2, r[9].s0);
            Assert.AreEqual((double)1, r[9].s1);
            Assert.AreEqual((double)1, r[9].s2);
            Assert.AreEqual((double)2, r[10].s0);
            Assert.AreEqual((double)1, r[10].s1);
            Assert.AreEqual((double)2, r[10].s2);
            Assert.AreEqual((double)2, r[11].s0);
            Assert.AreEqual((double)1, r[11].s1);
            Assert.AreEqual((double)3, r[11].s2);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)3, w[2].s2);
            Assert.AreEqual((double)2, r[12].s0);
            Assert.AreEqual((double)2, r[12].s1);
            Assert.AreEqual((double)1, r[12].s2);
            Assert.AreEqual((double)2, r[13].s0);
            Assert.AreEqual((double)2, r[13].s1);
            Assert.AreEqual((double)2, r[13].s2);
            Assert.AreEqual((double)2, r[14].s0);
            Assert.AreEqual((double)2, r[14].s1);
            Assert.AreEqual((double)3, r[14].s2);
            Assert.AreEqual((double)2, r[15].s0);
            Assert.AreEqual((double)3, r[15].s1);
            Assert.AreEqual((double)1, r[15].s2);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)3, w[3].s0);
            Assert.AreEqual((double)2, r[16].s0);
            Assert.AreEqual((double)3, r[16].s1);
            Assert.AreEqual((double)2, r[16].s2);
            Assert.AreEqual((double)2, r[17].s0);
            Assert.AreEqual((double)3, r[17].s1);
            Assert.AreEqual((double)3, r[17].s2);
            Assert.AreEqual((double)3, r[18].s0);
            Assert.AreEqual((double)1, r[18].s1);
            Assert.AreEqual((double)1, r[18].s2);
            Assert.AreEqual((double)3, r[19].s0);
            Assert.AreEqual((double)1, r[19].s1);
            Assert.AreEqual((double)2, r[19].s2);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)3, w[4].s1);
            Assert.AreEqual((double)3, r[20].s0);
            Assert.AreEqual((double)1, r[20].s1);
            Assert.AreEqual((double)3, r[20].s2);
            Assert.AreEqual((double)3, r[21].s0);
            Assert.AreEqual((double)2, r[21].s1);
            Assert.AreEqual((double)1, r[21].s2);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)3, w[5].s0);
            Assert.AreEqual((double)3, r[22].s0);
            Assert.AreEqual((double)2, r[22].s1);
            Assert.AreEqual((double)2, r[22].s2);
            Assert.AreEqual((double)3, r[23].s0);
            Assert.AreEqual((double)2, r[23].s1);
            Assert.AreEqual((double)3, r[23].s2);
            Assert.AreEqual((double)3, r[24].s0);
            Assert.AreEqual((double)3, r[24].s1);
            Assert.AreEqual((double)1, r[24].s2);
            Assert.AreEqual((double)3, r[25].s0);
            Assert.AreEqual((double)3, r[25].s1);
            Assert.AreEqual((double)2, r[25].s2);
            Assert.AreEqual((double)3, r[26].s0);
            Assert.AreEqual((double)3, r[26].s1);
            Assert.AreEqual((double)3, r[26].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components3");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<double3>;
                var mw = null as Mem<double3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components3");
                    mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double3>());
                    mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueFillBuffer(mw, default(double3));
                    queue.Finish();
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, false, r);
                    queue.EnqueueReadBuffer(mw, false, w);
                    queue.Finish();
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mw != null) mw.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[0].s2);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)1, r[1].s1);
            Assert.AreEqual((double)2, r[1].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)3, r[2].s2);
            Assert.AreEqual((double)1, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
            Assert.AreEqual((double)1, r[3].s2);
            Assert.AreEqual((double)1, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[4].s2);
            Assert.AreEqual((double)1, r[5].s0);
            Assert.AreEqual((double)2, r[5].s1);
            Assert.AreEqual((double)3, r[5].s2);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)3, w[0].s2);
            Assert.AreEqual((double)1, r[6].s0);
            Assert.AreEqual((double)3, r[6].s1);
            Assert.AreEqual((double)1, r[6].s2);
            Assert.AreEqual((double)1, r[7].s0);
            Assert.AreEqual((double)3, r[7].s1);
            Assert.AreEqual((double)2, r[7].s2);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)3, w[1].s1);
            Assert.AreEqual((double)1, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
            Assert.AreEqual((double)3, r[8].s2);
            Assert.AreEqual((double)2, r[9].s0);
            Assert.AreEqual((double)1, r[9].s1);
            Assert.AreEqual((double)1, r[9].s2);
            Assert.AreEqual((double)2, r[10].s0);
            Assert.AreEqual((double)1, r[10].s1);
            Assert.AreEqual((double)2, r[10].s2);
            Assert.AreEqual((double)2, r[11].s0);
            Assert.AreEqual((double)1, r[11].s1);
            Assert.AreEqual((double)3, r[11].s2);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)3, w[2].s2);
            Assert.AreEqual((double)2, r[12].s0);
            Assert.AreEqual((double)2, r[12].s1);
            Assert.AreEqual((double)1, r[12].s2);
            Assert.AreEqual((double)2, r[13].s0);
            Assert.AreEqual((double)2, r[13].s1);
            Assert.AreEqual((double)2, r[13].s2);
            Assert.AreEqual((double)2, r[14].s0);
            Assert.AreEqual((double)2, r[14].s1);
            Assert.AreEqual((double)3, r[14].s2);
            Assert.AreEqual((double)2, r[15].s0);
            Assert.AreEqual((double)3, r[15].s1);
            Assert.AreEqual((double)1, r[15].s2);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)3, w[3].s0);
            Assert.AreEqual((double)2, r[16].s0);
            Assert.AreEqual((double)3, r[16].s1);
            Assert.AreEqual((double)2, r[16].s2);
            Assert.AreEqual((double)2, r[17].s0);
            Assert.AreEqual((double)3, r[17].s1);
            Assert.AreEqual((double)3, r[17].s2);
            Assert.AreEqual((double)3, r[18].s0);
            Assert.AreEqual((double)1, r[18].s1);
            Assert.AreEqual((double)1, r[18].s2);
            Assert.AreEqual((double)3, r[19].s0);
            Assert.AreEqual((double)1, r[19].s1);
            Assert.AreEqual((double)2, r[19].s2);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)3, w[4].s1);
            Assert.AreEqual((double)3, r[20].s0);
            Assert.AreEqual((double)1, r[20].s1);
            Assert.AreEqual((double)3, r[20].s2);
            Assert.AreEqual((double)3, r[21].s0);
            Assert.AreEqual((double)2, r[21].s1);
            Assert.AreEqual((double)1, r[21].s2);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)3, w[5].s0);
            Assert.AreEqual((double)3, r[22].s0);
            Assert.AreEqual((double)2, r[22].s1);
            Assert.AreEqual((double)2, r[22].s2);
            Assert.AreEqual((double)3, r[23].s0);
            Assert.AreEqual((double)2, r[23].s1);
            Assert.AreEqual((double)3, r[23].s2);
            Assert.AreEqual((double)3, r[24].s0);
            Assert.AreEqual((double)3, r[24].s1);
            Assert.AreEqual((double)1, r[24].s2);
            Assert.AreEqual((double)3, r[25].s0);
            Assert.AreEqual((double)3, r[25].s1);
            Assert.AreEqual((double)2, r[25].s2);
            Assert.AreEqual((double)3, r[26].s0);
            Assert.AreEqual((double)3, r[26].s1);
            Assert.AreEqual((double)3, r[26].s2);
        }
    }
}
