using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestLong3
    {
        [Kernel]
        private static void test_long3_add([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            long3[] a = new long3[] { new long3((long)   7, (long)  14, (long)  21), new long3((long)   5, (long)  10, (long)  15) };
            long3[] b = new long3[] { new long3((long)   5, (long)  10, (long)  15), new long3((long)   7, (long)  14, (long)  21) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_add");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
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
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
        }

        [Kernel]
        private static void test_long3_sub([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            long3[] a = new long3[] { new long3((long)   7, (long)  14, (long)  21), new long3((long)   5, (long)  10, (long)  15) };
            long3[] b = new long3[] { new long3((long)   5, (long)  10, (long)  15), new long3((long)   7, (long)  14, (long)  21) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_sub");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
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
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
        }

        [Kernel]
        private static void test_long3_mul([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            long3[] a = new long3[] { new long3((long)   7, (long)  14, (long)  21), new long3((long)   5, (long)  10, (long)  15) };
            long3[] b = new long3[] { new long3((long)   5, (long)  10, (long)  15), new long3((long)   7, (long)  14, (long)  21) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_mul");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
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
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
        }

        [Kernel]
        private static void test_long3_div([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            long3[] a = new long3[] { new long3((long)   7, (long)  14, (long)  21), new long3((long)   5, (long)  10, (long)  15) };
            long3[] b = new long3[] { new long3((long)   5, (long)  10, (long)  15), new long3((long)   7, (long)  14, (long)  21) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_div");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long3>());
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
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
        }

        [Kernel]
        private static void test_long3_eq([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            long3[] a = new long3[] { new long3((long)   4, (long)   3, (long)   2), new long3((long)   0, (long)   1, (long)   2) };
            long3[] b = new long3[] { new long3((long)   0, (long)   1, (long)   2), new long3((long)   4, (long)   3, (long)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_eq,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_eq");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
        private static void test_long3_neq([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            long3[] a = new long3[] { new long3((long)   4, (long)   3, (long)   2), new long3((long)   0, (long)   1, (long)   2) };
            long3[] b = new long3[] { new long3((long)   0, (long)   1, (long)   2), new long3((long)   4, (long)   3, (long)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_neq,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_neq");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
        private static void test_long3_lt([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            long3[] a = new long3[] { new long3((long)   4, (long)   3, (long)   2), new long3((long)   0, (long)   1, (long)   2) };
            long3[] b = new long3[] { new long3((long)   0, (long)   1, (long)   2), new long3((long)   4, (long)   3, (long)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_lt,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_lt");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
        private static void test_long3_le([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            long3[] a = new long3[] { new long3((long)   4, (long)   3, (long)   2), new long3((long)   0, (long)   1, (long)   2) };
            long3[] b = new long3[] { new long3((long)   0, (long)   1, (long)   2), new long3((long)   4, (long)   3, (long)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_le,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_le");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
        private static void test_long3_gt([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            long3[] a = new long3[] { new long3((long)   4, (long)   3, (long)   2), new long3((long)   0, (long)   1, (long)   2) };
            long3[] b = new long3[] { new long3((long)   0, (long)   1, (long)   2), new long3((long)   4, (long)   3, (long)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_gt,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_gt");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
        private static void test_long3_ge([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            long3[] a = new long3[] { new long3((long)   4, (long)   3, (long)   2), new long3((long)   0, (long)   1, (long)   2) };
            long3[] b = new long3[] { new long3((long)   0, (long)   1, (long)   2), new long3((long)   4, (long)   3, (long)   2) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_ge,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_ge");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
        private static void test_long3_and([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAnd()
        {
            long3[] a = new long3[] { new long3((long)   7, (long)  14, (long)  21), new long3((long)   5, (long)  10, (long)  15) };
            long3[] b = new long3[] { new long3((long)   5, (long)  10, (long)  15), new long3((long)   7, (long)  14, (long)  21) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_and,
                a,
                b,
                r
            );
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[0].s2);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_and");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_and");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[0].s2);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
        }

        [Kernel]
        private static void test_long3_or([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOr()
        {
            long3[] a = new long3[] { new long3((long)   7, (long)  14, (long)  21), new long3((long)   5, (long)  10, (long)  15) };
            long3[] b = new long3[] { new long3((long)   5, (long)  10, (long)  15), new long3((long)   7, (long)  14, (long)  21) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_or,
                a,
                b,
                r
            );
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(  31, r[0].s2);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_or");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_or");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(  31, r[0].s2);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
        }

        [Kernel]
        private static void test_long3_xor([Global] long3[] a, [Global] long3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXor()
        {
            long3[] a = new long3[] { new long3((long)   7, (long)  14, (long)  21), new long3((long)   5, (long)  10, (long)  15) };
            long3[] b = new long3[] { new long3((long)   5, (long)  10, (long)  15), new long3((long)   7, (long)  14, (long)  21) };
            long3[] r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long3[],long3[],long3[]>)test_long3_xor,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  26, r[0].s2);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_long3_xor");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<long3>;
                var mb = null as Mem<long3>;
                var mr = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_long3_xor");
                    ma = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<long3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
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
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  26, r[0].s2);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
        }

        [Kernel]
        private static void test_components1([Global] long[] r, [Global] long3[] w)
        {
            long3 ar = new long3((long)1, (long)2, (long)3);
            long aw = (long)1;
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
            long[] r = new long[nr];
            long3[] w = new long3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<long[],long3[]>)test_components1,
                r, w
            );
            Assert.AreEqual((long)1, r[0]);
            Assert.AreEqual((long)1, w[0].s0);
            Assert.AreEqual((long)0, w[0].s1);
            Assert.AreEqual((long)0, w[0].s2);
            Assert.AreEqual((long)2, r[1]);
            Assert.AreEqual((long)1, w[1].s1);
            Assert.AreEqual((long)0, w[1].s0);
            Assert.AreEqual((long)0, w[1].s2);
            Assert.AreEqual((long)3, r[2]);
            Assert.AreEqual((long)1, w[2].s2);
            Assert.AreEqual((long)0, w[2].s0);
            Assert.AreEqual((long)0, w[2].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_components1");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<long>;
                var mw = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components1");
                    mr = Mem<long>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<long>());
                    mw = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, nr);
                    queue.EnqueueReadBuffer(mr, false, r);
                    Array.Clear(w, 0, nw);
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
            Assert.AreEqual((long)1, r[0]);
            Assert.AreEqual((long)1, w[0].s0);
            Assert.AreEqual((long)0, w[0].s1);
            Assert.AreEqual((long)0, w[0].s2);
            Assert.AreEqual((long)2, r[1]);
            Assert.AreEqual((long)1, w[1].s1);
            Assert.AreEqual((long)0, w[1].s0);
            Assert.AreEqual((long)0, w[1].s2);
            Assert.AreEqual((long)3, r[2]);
            Assert.AreEqual((long)1, w[2].s2);
            Assert.AreEqual((long)0, w[2].s0);
            Assert.AreEqual((long)0, w[2].s1);
        }
        [Kernel]
        private static void test_components2([Global] long2[] r, [Global] long3[] w)
        {
            long3 ar = new long3((long)1, (long)2, (long)3);
            long2 aw = new long2((long)1, (long)2);
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
            long2[] r = new long2[nr];
            long3[] w = new long3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<long2[],long3[]>)test_components2,
                r, w
            );
            Assert.AreEqual((long)1, r[0].s0);
            Assert.AreEqual((long)1, r[0].s1);
            Assert.AreEqual((long)1, r[1].s0);
            Assert.AreEqual((long)2, r[1].s1);
            Assert.AreEqual((long)1, w[0].s0);
            Assert.AreEqual((long)2, w[0].s1);
            Assert.AreEqual((long)0, w[0].s2);
            Assert.AreEqual((long)1, r[2].s0);
            Assert.AreEqual((long)3, r[2].s1);
            Assert.AreEqual((long)1, w[1].s0);
            Assert.AreEqual((long)2, w[1].s2);
            Assert.AreEqual((long)0, w[1].s1);
            Assert.AreEqual((long)2, r[3].s0);
            Assert.AreEqual((long)1, r[3].s1);
            Assert.AreEqual((long)1, w[2].s1);
            Assert.AreEqual((long)2, w[2].s0);
            Assert.AreEqual((long)0, w[2].s2);
            Assert.AreEqual((long)2, r[4].s0);
            Assert.AreEqual((long)2, r[4].s1);
            Assert.AreEqual((long)2, r[5].s0);
            Assert.AreEqual((long)3, r[5].s1);
            Assert.AreEqual((long)1, w[3].s1);
            Assert.AreEqual((long)2, w[3].s2);
            Assert.AreEqual((long)0, w[3].s0);
            Assert.AreEqual((long)3, r[6].s0);
            Assert.AreEqual((long)1, r[6].s1);
            Assert.AreEqual((long)1, w[4].s2);
            Assert.AreEqual((long)2, w[4].s0);
            Assert.AreEqual((long)0, w[4].s1);
            Assert.AreEqual((long)3, r[7].s0);
            Assert.AreEqual((long)2, r[7].s1);
            Assert.AreEqual((long)1, w[5].s2);
            Assert.AreEqual((long)2, w[5].s1);
            Assert.AreEqual((long)0, w[5].s0);
            Assert.AreEqual((long)3, r[8].s0);
            Assert.AreEqual((long)3, r[8].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_components2");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<long2>;
                var mw = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components2");
                    mr = Mem<long2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<long2>());
                    mw = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, nr);
                    queue.EnqueueReadBuffer(mr, false, r);
                    Array.Clear(w, 0, nw);
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
            Assert.AreEqual((long)1, r[0].s0);
            Assert.AreEqual((long)1, r[0].s1);
            Assert.AreEqual((long)1, r[1].s0);
            Assert.AreEqual((long)2, r[1].s1);
            Assert.AreEqual((long)1, w[0].s0);
            Assert.AreEqual((long)2, w[0].s1);
            Assert.AreEqual((long)0, w[0].s2);
            Assert.AreEqual((long)1, r[2].s0);
            Assert.AreEqual((long)3, r[2].s1);
            Assert.AreEqual((long)1, w[1].s0);
            Assert.AreEqual((long)2, w[1].s2);
            Assert.AreEqual((long)0, w[1].s1);
            Assert.AreEqual((long)2, r[3].s0);
            Assert.AreEqual((long)1, r[3].s1);
            Assert.AreEqual((long)1, w[2].s1);
            Assert.AreEqual((long)2, w[2].s0);
            Assert.AreEqual((long)0, w[2].s2);
            Assert.AreEqual((long)2, r[4].s0);
            Assert.AreEqual((long)2, r[4].s1);
            Assert.AreEqual((long)2, r[5].s0);
            Assert.AreEqual((long)3, r[5].s1);
            Assert.AreEqual((long)1, w[3].s1);
            Assert.AreEqual((long)2, w[3].s2);
            Assert.AreEqual((long)0, w[3].s0);
            Assert.AreEqual((long)3, r[6].s0);
            Assert.AreEqual((long)1, r[6].s1);
            Assert.AreEqual((long)1, w[4].s2);
            Assert.AreEqual((long)2, w[4].s0);
            Assert.AreEqual((long)0, w[4].s1);
            Assert.AreEqual((long)3, r[7].s0);
            Assert.AreEqual((long)2, r[7].s1);
            Assert.AreEqual((long)1, w[5].s2);
            Assert.AreEqual((long)2, w[5].s1);
            Assert.AreEqual((long)0, w[5].s0);
            Assert.AreEqual((long)3, r[8].s0);
            Assert.AreEqual((long)3, r[8].s1);
        }
        [Kernel]
        private static void test_components3([Global] long3[] r, [Global] long3[] w)
        {
            long3 ar = new long3((long)1, (long)2, (long)3);
            long3 aw = new long3((long)1, (long)2, (long)3);
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
            long3[] r = new long3[nr];
            long3[] w = new long3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<long3[],long3[]>)test_components3,
                r, w
            );
            Assert.AreEqual((long)1, r[0].s0);
            Assert.AreEqual((long)1, r[0].s1);
            Assert.AreEqual((long)1, r[0].s2);
            Assert.AreEqual((long)1, r[1].s0);
            Assert.AreEqual((long)1, r[1].s1);
            Assert.AreEqual((long)2, r[1].s2);
            Assert.AreEqual((long)1, r[2].s0);
            Assert.AreEqual((long)1, r[2].s1);
            Assert.AreEqual((long)3, r[2].s2);
            Assert.AreEqual((long)1, r[3].s0);
            Assert.AreEqual((long)2, r[3].s1);
            Assert.AreEqual((long)1, r[3].s2);
            Assert.AreEqual((long)1, r[4].s0);
            Assert.AreEqual((long)2, r[4].s1);
            Assert.AreEqual((long)2, r[4].s2);
            Assert.AreEqual((long)1, r[5].s0);
            Assert.AreEqual((long)2, r[5].s1);
            Assert.AreEqual((long)3, r[5].s2);
            Assert.AreEqual((long)1, w[0].s0);
            Assert.AreEqual((long)2, w[0].s1);
            Assert.AreEqual((long)3, w[0].s2);
            Assert.AreEqual((long)1, r[6].s0);
            Assert.AreEqual((long)3, r[6].s1);
            Assert.AreEqual((long)1, r[6].s2);
            Assert.AreEqual((long)1, r[7].s0);
            Assert.AreEqual((long)3, r[7].s1);
            Assert.AreEqual((long)2, r[7].s2);
            Assert.AreEqual((long)1, w[1].s0);
            Assert.AreEqual((long)2, w[1].s2);
            Assert.AreEqual((long)3, w[1].s1);
            Assert.AreEqual((long)1, r[8].s0);
            Assert.AreEqual((long)3, r[8].s1);
            Assert.AreEqual((long)3, r[8].s2);
            Assert.AreEqual((long)2, r[9].s0);
            Assert.AreEqual((long)1, r[9].s1);
            Assert.AreEqual((long)1, r[9].s2);
            Assert.AreEqual((long)2, r[10].s0);
            Assert.AreEqual((long)1, r[10].s1);
            Assert.AreEqual((long)2, r[10].s2);
            Assert.AreEqual((long)2, r[11].s0);
            Assert.AreEqual((long)1, r[11].s1);
            Assert.AreEqual((long)3, r[11].s2);
            Assert.AreEqual((long)1, w[2].s1);
            Assert.AreEqual((long)2, w[2].s0);
            Assert.AreEqual((long)3, w[2].s2);
            Assert.AreEqual((long)2, r[12].s0);
            Assert.AreEqual((long)2, r[12].s1);
            Assert.AreEqual((long)1, r[12].s2);
            Assert.AreEqual((long)2, r[13].s0);
            Assert.AreEqual((long)2, r[13].s1);
            Assert.AreEqual((long)2, r[13].s2);
            Assert.AreEqual((long)2, r[14].s0);
            Assert.AreEqual((long)2, r[14].s1);
            Assert.AreEqual((long)3, r[14].s2);
            Assert.AreEqual((long)2, r[15].s0);
            Assert.AreEqual((long)3, r[15].s1);
            Assert.AreEqual((long)1, r[15].s2);
            Assert.AreEqual((long)1, w[3].s1);
            Assert.AreEqual((long)2, w[3].s2);
            Assert.AreEqual((long)3, w[3].s0);
            Assert.AreEqual((long)2, r[16].s0);
            Assert.AreEqual((long)3, r[16].s1);
            Assert.AreEqual((long)2, r[16].s2);
            Assert.AreEqual((long)2, r[17].s0);
            Assert.AreEqual((long)3, r[17].s1);
            Assert.AreEqual((long)3, r[17].s2);
            Assert.AreEqual((long)3, r[18].s0);
            Assert.AreEqual((long)1, r[18].s1);
            Assert.AreEqual((long)1, r[18].s2);
            Assert.AreEqual((long)3, r[19].s0);
            Assert.AreEqual((long)1, r[19].s1);
            Assert.AreEqual((long)2, r[19].s2);
            Assert.AreEqual((long)1, w[4].s2);
            Assert.AreEqual((long)2, w[4].s0);
            Assert.AreEqual((long)3, w[4].s1);
            Assert.AreEqual((long)3, r[20].s0);
            Assert.AreEqual((long)1, r[20].s1);
            Assert.AreEqual((long)3, r[20].s2);
            Assert.AreEqual((long)3, r[21].s0);
            Assert.AreEqual((long)2, r[21].s1);
            Assert.AreEqual((long)1, r[21].s2);
            Assert.AreEqual((long)1, w[5].s2);
            Assert.AreEqual((long)2, w[5].s1);
            Assert.AreEqual((long)3, w[5].s0);
            Assert.AreEqual((long)3, r[22].s0);
            Assert.AreEqual((long)2, r[22].s1);
            Assert.AreEqual((long)2, r[22].s2);
            Assert.AreEqual((long)3, r[23].s0);
            Assert.AreEqual((long)2, r[23].s1);
            Assert.AreEqual((long)3, r[23].s2);
            Assert.AreEqual((long)3, r[24].s0);
            Assert.AreEqual((long)3, r[24].s1);
            Assert.AreEqual((long)1, r[24].s2);
            Assert.AreEqual((long)3, r[25].s0);
            Assert.AreEqual((long)3, r[25].s1);
            Assert.AreEqual((long)2, r[25].s2);
            Assert.AreEqual((long)3, r[26].s0);
            Assert.AreEqual((long)3, r[26].s1);
            Assert.AreEqual((long)3, r[26].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestLong3", "test_components3");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<long3>;
                var mw = null as Mem<long3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components3");
                    mr = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<long3>());
                    mw = Mem<long3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<long3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, nr);
                    queue.EnqueueReadBuffer(mr, false, r);
                    Array.Clear(w, 0, nw);
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
            Assert.AreEqual((long)1, r[0].s0);
            Assert.AreEqual((long)1, r[0].s1);
            Assert.AreEqual((long)1, r[0].s2);
            Assert.AreEqual((long)1, r[1].s0);
            Assert.AreEqual((long)1, r[1].s1);
            Assert.AreEqual((long)2, r[1].s2);
            Assert.AreEqual((long)1, r[2].s0);
            Assert.AreEqual((long)1, r[2].s1);
            Assert.AreEqual((long)3, r[2].s2);
            Assert.AreEqual((long)1, r[3].s0);
            Assert.AreEqual((long)2, r[3].s1);
            Assert.AreEqual((long)1, r[3].s2);
            Assert.AreEqual((long)1, r[4].s0);
            Assert.AreEqual((long)2, r[4].s1);
            Assert.AreEqual((long)2, r[4].s2);
            Assert.AreEqual((long)1, r[5].s0);
            Assert.AreEqual((long)2, r[5].s1);
            Assert.AreEqual((long)3, r[5].s2);
            Assert.AreEqual((long)1, w[0].s0);
            Assert.AreEqual((long)2, w[0].s1);
            Assert.AreEqual((long)3, w[0].s2);
            Assert.AreEqual((long)1, r[6].s0);
            Assert.AreEqual((long)3, r[6].s1);
            Assert.AreEqual((long)1, r[6].s2);
            Assert.AreEqual((long)1, r[7].s0);
            Assert.AreEqual((long)3, r[7].s1);
            Assert.AreEqual((long)2, r[7].s2);
            Assert.AreEqual((long)1, w[1].s0);
            Assert.AreEqual((long)2, w[1].s2);
            Assert.AreEqual((long)3, w[1].s1);
            Assert.AreEqual((long)1, r[8].s0);
            Assert.AreEqual((long)3, r[8].s1);
            Assert.AreEqual((long)3, r[8].s2);
            Assert.AreEqual((long)2, r[9].s0);
            Assert.AreEqual((long)1, r[9].s1);
            Assert.AreEqual((long)1, r[9].s2);
            Assert.AreEqual((long)2, r[10].s0);
            Assert.AreEqual((long)1, r[10].s1);
            Assert.AreEqual((long)2, r[10].s2);
            Assert.AreEqual((long)2, r[11].s0);
            Assert.AreEqual((long)1, r[11].s1);
            Assert.AreEqual((long)3, r[11].s2);
            Assert.AreEqual((long)1, w[2].s1);
            Assert.AreEqual((long)2, w[2].s0);
            Assert.AreEqual((long)3, w[2].s2);
            Assert.AreEqual((long)2, r[12].s0);
            Assert.AreEqual((long)2, r[12].s1);
            Assert.AreEqual((long)1, r[12].s2);
            Assert.AreEqual((long)2, r[13].s0);
            Assert.AreEqual((long)2, r[13].s1);
            Assert.AreEqual((long)2, r[13].s2);
            Assert.AreEqual((long)2, r[14].s0);
            Assert.AreEqual((long)2, r[14].s1);
            Assert.AreEqual((long)3, r[14].s2);
            Assert.AreEqual((long)2, r[15].s0);
            Assert.AreEqual((long)3, r[15].s1);
            Assert.AreEqual((long)1, r[15].s2);
            Assert.AreEqual((long)1, w[3].s1);
            Assert.AreEqual((long)2, w[3].s2);
            Assert.AreEqual((long)3, w[3].s0);
            Assert.AreEqual((long)2, r[16].s0);
            Assert.AreEqual((long)3, r[16].s1);
            Assert.AreEqual((long)2, r[16].s2);
            Assert.AreEqual((long)2, r[17].s0);
            Assert.AreEqual((long)3, r[17].s1);
            Assert.AreEqual((long)3, r[17].s2);
            Assert.AreEqual((long)3, r[18].s0);
            Assert.AreEqual((long)1, r[18].s1);
            Assert.AreEqual((long)1, r[18].s2);
            Assert.AreEqual((long)3, r[19].s0);
            Assert.AreEqual((long)1, r[19].s1);
            Assert.AreEqual((long)2, r[19].s2);
            Assert.AreEqual((long)1, w[4].s2);
            Assert.AreEqual((long)2, w[4].s0);
            Assert.AreEqual((long)3, w[4].s1);
            Assert.AreEqual((long)3, r[20].s0);
            Assert.AreEqual((long)1, r[20].s1);
            Assert.AreEqual((long)3, r[20].s2);
            Assert.AreEqual((long)3, r[21].s0);
            Assert.AreEqual((long)2, r[21].s1);
            Assert.AreEqual((long)1, r[21].s2);
            Assert.AreEqual((long)1, w[5].s2);
            Assert.AreEqual((long)2, w[5].s1);
            Assert.AreEqual((long)3, w[5].s0);
            Assert.AreEqual((long)3, r[22].s0);
            Assert.AreEqual((long)2, r[22].s1);
            Assert.AreEqual((long)2, r[22].s2);
            Assert.AreEqual((long)3, r[23].s0);
            Assert.AreEqual((long)2, r[23].s1);
            Assert.AreEqual((long)3, r[23].s2);
            Assert.AreEqual((long)3, r[24].s0);
            Assert.AreEqual((long)3, r[24].s1);
            Assert.AreEqual((long)1, r[24].s2);
            Assert.AreEqual((long)3, r[25].s0);
            Assert.AreEqual((long)3, r[25].s1);
            Assert.AreEqual((long)2, r[25].s2);
            Assert.AreEqual((long)3, r[26].s0);
            Assert.AreEqual((long)3, r[26].s1);
            Assert.AreEqual((long)3, r[26].s2);
        }
    }
}
