using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

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
        public void TestAdd()
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

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_add");

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

        [Kernel]
        private static void test_double3_sub([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
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

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_sub");

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

        [Kernel]
        private static void test_double3_mul([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
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

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_mul");

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

        [Kernel]
        private static void test_double3_div([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
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

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_div");

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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_eq");

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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_neq");

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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_lt");

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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_le");

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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_gt");

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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble3", "test_double3_ge");

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

    }
}
