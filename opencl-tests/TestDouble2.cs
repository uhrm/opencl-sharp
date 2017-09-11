using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestDouble2
    {
        [Kernel]
        private static void test_double2_add([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            double2[] a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            double2[] b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            double2[] r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<double2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_add");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double2>());
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
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
        }

        [Kernel]
        private static void test_double2_sub([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            double2[] a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            double2[] b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            double2[] r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(   4.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<double2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_sub");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double2>());
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
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
        }

        [Kernel]
        private static void test_double2_mul([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            double2[] a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            double2[] b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            double2[] r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<double2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_mul");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double2>());
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
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
        }

        [Kernel]
        private static void test_double2_div([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            double2[] a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            double2[] b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            double2[] r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1.3999999999999999, r[0].s0, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<double2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_div");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double2>());
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
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
        }

        [Kernel]
        private static void test_double2_eq([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            double2[] a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            double2[] b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            long2[] r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<long2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_eq");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long2>());
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
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Kernel]
        private static void test_double2_neq([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            double2[] a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            double2[] b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            long2[] r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<long2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_neq");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long2>());
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
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Kernel]
        private static void test_double2_lt([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            double2[] a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            double2[] b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            long2[] r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<long2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_lt");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long2>());
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
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Kernel]
        private static void test_double2_le([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            double2[] a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            double2[] b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            long2[] r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<long2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_le");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long2>());
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
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Kernel]
        private static void test_double2_gt([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            double2[] a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            double2[] b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            long2[] r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<long2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_gt");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long2>());
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
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Kernel]
        private static void test_double2_ge([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            double2[] a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            double2[] b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            long2[] r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double2>;
                var mb = null as Mem<double2>;
                var mr = null as Mem<long2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double2_ge");
                    ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long2>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long2>());
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
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Kernel]
        private static void test_components1([Global] double[] r, [Global] double2[] w)
        {
            double2 ar = new double2((double)1, (double)2);
            double aw = (double)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
        }

        [Test]
        public void TestComponentAccessors1()
        {
            int nr = 2;
            int nw = 2;
            double[] r = new double[nr];
            double2[] w = new double2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double[],double2[]>)test_components1,
                r, w
            );
            Assert.AreEqual((double)1, r[0]);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)0, w[0].s1);
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_components1");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<double>;
                var mw = null as Mem<double2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components1");
                    mr = Mem<double>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double>());
                    mw = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double2>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueFillBuffer(mw, default(double2));
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
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
        }
        [Kernel]
        private static void test_components2([Global] double2[] r, [Global] double2[] w)
        {
            double2 ar = new double2((double)1, (double)2);
            double2 aw = new double2((double)1, (double)2);
            r[0] = ar.xx;
            r[1] = ar.xy;
            w[0].xy = aw;
            r[2] = ar.yx;
            w[1].yx = aw;
            r[3] = ar.yy;
        }

        [Test]
        public void TestComponentAccessors2()
        {
            int nr = 4;
            int nw = 2;
            double2[] r = new double2[nr];
            double2[] w = new double2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double2[],double2[]>)test_components2,
                r, w
            );
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)2, r[1].s1);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)2, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)2, w[1].s0);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_components2");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<double2>;
                var mw = null as Mem<double2>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components2");
                    mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double2>());
                    mw = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double2>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueFillBuffer(mw, default(double2));
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
            Assert.AreEqual((double)2, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)2, w[1].s0);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
        }
    }
}
