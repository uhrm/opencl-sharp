using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestShort4
    {
        [Kernel]
        private static void test_short4_add([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            short4[] a = new short4[] { new short4((short)   7, (short)  14, (short)  21, (short)  28), new short4((short)   5, (short)  10, (short)  15, (short)  20) };
            short4[] b = new short4[] { new short4((short)   5, (short)  10, (short)  15, (short)  20), new short4((short)   7, (short)  14, (short)  21, (short)  28) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_add");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
        }

        [Kernel]
        private static void test_short4_sub([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            short4[] a = new short4[] { new short4((short)   7, (short)  14, (short)  21, (short)  28), new short4((short)   5, (short)  10, (short)  15, (short)  20) };
            short4[] b = new short4[] { new short4((short)   5, (short)  10, (short)  15, (short)  20), new short4((short)   7, (short)  14, (short)  21, (short)  28) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_sub");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
        }

        [Kernel]
        private static void test_short4_mul([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            short4[] a = new short4[] { new short4((short)   7, (short)  14, (short)  21, (short)  28), new short4((short)   5, (short)  10, (short)  15, (short)  20) };
            short4[] b = new short4[] { new short4((short)   5, (short)  10, (short)  15, (short)  20), new short4((short)   7, (short)  14, (short)  21, (short)  28) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_mul");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
        }

        [Kernel]
        private static void test_short4_div([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            short4[] a = new short4[] { new short4((short)   7, (short)  14, (short)  21, (short)  28), new short4((short)   5, (short)  10, (short)  15, (short)  20) };
            short4[] b = new short4[] { new short4((short)   5, (short)  10, (short)  15, (short)  20), new short4((short)   7, (short)  14, (short)  21, (short)  28) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   1, r[0].s3);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_div");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(   1, r[0].s3);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
        }

        [Kernel]
        private static void test_short4_eq([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            short4[] a = new short4[] { new short4((short)   6, (short)   5, (short)   4, (short)   3), new short4((short)   0, (short)   1, (short)   2, (short)   3) };
            short4[] b = new short4[] { new short4((short)   0, (short)   1, (short)   2, (short)   3), new short4((short)   6, (short)   5, (short)   4, (short)   3) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_eq");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
        }

        [Kernel]
        private static void test_short4_neq([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            short4[] a = new short4[] { new short4((short)   6, (short)   5, (short)   4, (short)   3), new short4((short)   0, (short)   1, (short)   2, (short)   3) };
            short4[] b = new short4[] { new short4((short)   0, (short)   1, (short)   2, (short)   3), new short4((short)   6, (short)   5, (short)   4, (short)   3) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_neq");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
        }

        [Kernel]
        private static void test_short4_lt([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            short4[] a = new short4[] { new short4((short)   6, (short)   5, (short)   4, (short)   3), new short4((short)   0, (short)   1, (short)   2, (short)   3) };
            short4[] b = new short4[] { new short4((short)   0, (short)   1, (short)   2, (short)   3), new short4((short)   6, (short)   5, (short)   4, (short)   3) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_lt");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
        }

        [Kernel]
        private static void test_short4_le([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            short4[] a = new short4[] { new short4((short)   6, (short)   5, (short)   4, (short)   3), new short4((short)   0, (short)   1, (short)   2, (short)   3) };
            short4[] b = new short4[] { new short4((short)   0, (short)   1, (short)   2, (short)   3), new short4((short)   6, (short)   5, (short)   4, (short)   3) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_le");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
        }

        [Kernel]
        private static void test_short4_gt([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            short4[] a = new short4[] { new short4((short)   6, (short)   5, (short)   4, (short)   3), new short4((short)   0, (short)   1, (short)   2, (short)   3) };
            short4[] b = new short4[] { new short4((short)   0, (short)   1, (short)   2, (short)   3), new short4((short)   6, (short)   5, (short)   4, (short)   3) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_gt");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
        }

        [Kernel]
        private static void test_short4_ge([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            short4[] a = new short4[] { new short4((short)   6, (short)   5, (short)   4, (short)   3), new short4((short)   0, (short)   1, (short)   2, (short)   3) };
            short4[] b = new short4[] { new short4((short)   0, (short)   1, (short)   2, (short)   3), new short4((short)   6, (short)   5, (short)   4, (short)   3) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_ge");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
        }

        [Kernel]
        private static void test_short4_and([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAnd()
        {
            short4[] a = new short4[] { new short4((short)   7, (short)  14, (short)  21, (short)  28), new short4((short)   5, (short)  10, (short)  15, (short)  20) };
            short4[] b = new short4[] { new short4((short)   5, (short)  10, (short)  15, (short)  20), new short4((short)   7, (short)  14, (short)  21, (short)  28) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_and,
                a,
                b,
                r
            );
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[0].s2);
            Assert.AreEqual(  20, r[0].s3);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_and");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_and");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(  20, r[0].s3);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);
        }

        [Kernel]
        private static void test_short4_or([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOr()
        {
            short4[] a = new short4[] { new short4((short)   7, (short)  14, (short)  21, (short)  28), new short4((short)   5, (short)  10, (short)  15, (short)  20) };
            short4[] b = new short4[] { new short4((short)   5, (short)  10, (short)  15, (short)  20), new short4((short)   7, (short)  14, (short)  21, (short)  28) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_or,
                a,
                b,
                r
            );
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(  31, r[0].s2);
            Assert.AreEqual(  28, r[0].s3);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_or");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_or");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(  28, r[0].s3);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);
        }

        [Kernel]
        private static void test_short4_xor([Global] short4[] a, [Global] short4[] b, [Global] short4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXor()
        {
            short4[] a = new short4[] { new short4((short)   7, (short)  14, (short)  21, (short)  28), new short4((short)   5, (short)  10, (short)  15, (short)  20) };
            short4[] b = new short4[] { new short4((short)   5, (short)  10, (short)  15, (short)  20), new short4((short)   7, (short)  14, (short)  21, (short)  28) };
            short4[] r = new short4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short4[],short4[],short4[]>)test_short4_xor,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  26, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_short4_xor");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<short4>;
                var mb = null as Mem<short4>;
                var mr = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_short4_xor");
                    ma = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<short4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short4>());
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
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);
        }

        [Kernel]
        private static void test_components1([Global] short[] r, [Global] short4[] w)
        {
            short4 ar = new short4((short)1, (short)2, (short)3, (short)4);
            short aw = (short)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
            r[2] = ar.z;
            w[2].z = aw;
            r[3] = ar.w;
            w[3].w = aw;
        }

        [Test]
        public void TestComponentAccessors1()
        {
            int nr = 4;
            int nw = 4;
            short[] r = new short[nr];
            short4[] w = new short4[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<short[],short4[]>)test_components1,
                r, w
            );
            Assert.AreEqual((short)1, r[0]);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)0, w[0].s1);
            Assert.AreEqual((short)0, w[0].s2);
            Assert.AreEqual((short)0, w[0].s3);
            Assert.AreEqual((short)2, r[1]);
            Assert.AreEqual((short)1, w[1].s1);
            Assert.AreEqual((short)0, w[1].s0);
            Assert.AreEqual((short)0, w[1].s2);
            Assert.AreEqual((short)0, w[1].s3);
            Assert.AreEqual((short)3, r[2]);
            Assert.AreEqual((short)1, w[2].s2);
            Assert.AreEqual((short)0, w[2].s0);
            Assert.AreEqual((short)0, w[2].s1);
            Assert.AreEqual((short)0, w[2].s3);
            Assert.AreEqual((short)4, r[3]);
            Assert.AreEqual((short)1, w[3].s3);
            Assert.AreEqual((short)0, w[3].s0);
            Assert.AreEqual((short)0, w[3].s1);
            Assert.AreEqual((short)0, w[3].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_components1");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<short>;
                var mw = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components1");
                    mr = Mem<short>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<short>());
                    mw = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<short4>());
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
            Assert.AreEqual((short)1, r[0]);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)0, w[0].s1);
            Assert.AreEqual((short)0, w[0].s2);
            Assert.AreEqual((short)0, w[0].s3);
            Assert.AreEqual((short)2, r[1]);
            Assert.AreEqual((short)1, w[1].s1);
            Assert.AreEqual((short)0, w[1].s0);
            Assert.AreEqual((short)0, w[1].s2);
            Assert.AreEqual((short)0, w[1].s3);
            Assert.AreEqual((short)3, r[2]);
            Assert.AreEqual((short)1, w[2].s2);
            Assert.AreEqual((short)0, w[2].s0);
            Assert.AreEqual((short)0, w[2].s1);
            Assert.AreEqual((short)0, w[2].s3);
            Assert.AreEqual((short)4, r[3]);
            Assert.AreEqual((short)1, w[3].s3);
            Assert.AreEqual((short)0, w[3].s0);
            Assert.AreEqual((short)0, w[3].s1);
            Assert.AreEqual((short)0, w[3].s2);
        }
        [Kernel]
        private static void test_components2([Global] short2[] r, [Global] short4[] w)
        {
            short4 ar = new short4((short)1, (short)2, (short)3, (short)4);
            short2 aw = new short2((short)1, (short)2);
            r[0] = ar.xx;
            r[1] = ar.xy;
            w[0].xy = aw;
            r[2] = ar.xz;
            w[1].xz = aw;
            r[3] = ar.xw;
            w[2].xw = aw;
            r[4] = ar.yx;
            w[3].yx = aw;
            r[5] = ar.yy;
            r[6] = ar.yz;
            w[4].yz = aw;
            r[7] = ar.yw;
            w[5].yw = aw;
            r[8] = ar.zx;
            w[6].zx = aw;
            r[9] = ar.zy;
            w[7].zy = aw;
            r[10] = ar.zz;
            r[11] = ar.zw;
            w[8].zw = aw;
            r[12] = ar.wx;
            w[9].wx = aw;
            r[13] = ar.wy;
            w[10].wy = aw;
            r[14] = ar.wz;
            w[11].wz = aw;
            r[15] = ar.ww;
        }

        [Test]
        public void TestComponentAccessors2()
        {
            int nr = 16;
            int nw = 12;
            short2[] r = new short2[nr];
            short4[] w = new short4[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<short2[],short4[]>)test_components2,
                r, w
            );
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)2, r[1].s1);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)0, w[0].s2);
            Assert.AreEqual((short)0, w[0].s3);
            Assert.AreEqual((short)1, r[2].s0);
            Assert.AreEqual((short)3, r[2].s1);
            Assert.AreEqual((short)1, w[1].s0);
            Assert.AreEqual((short)2, w[1].s2);
            Assert.AreEqual((short)0, w[1].s1);
            Assert.AreEqual((short)0, w[1].s3);
            Assert.AreEqual((short)1, r[3].s0);
            Assert.AreEqual((short)4, r[3].s1);
            Assert.AreEqual((short)1, w[2].s0);
            Assert.AreEqual((short)2, w[2].s3);
            Assert.AreEqual((short)0, w[2].s1);
            Assert.AreEqual((short)0, w[2].s2);
            Assert.AreEqual((short)2, r[4].s0);
            Assert.AreEqual((short)1, r[4].s1);
            Assert.AreEqual((short)1, w[3].s1);
            Assert.AreEqual((short)2, w[3].s0);
            Assert.AreEqual((short)0, w[3].s2);
            Assert.AreEqual((short)0, w[3].s3);
            Assert.AreEqual((short)2, r[5].s0);
            Assert.AreEqual((short)2, r[5].s1);
            Assert.AreEqual((short)2, r[6].s0);
            Assert.AreEqual((short)3, r[6].s1);
            Assert.AreEqual((short)1, w[4].s1);
            Assert.AreEqual((short)2, w[4].s2);
            Assert.AreEqual((short)0, w[4].s0);
            Assert.AreEqual((short)0, w[4].s3);
            Assert.AreEqual((short)2, r[7].s0);
            Assert.AreEqual((short)4, r[7].s1);
            Assert.AreEqual((short)1, w[5].s1);
            Assert.AreEqual((short)2, w[5].s3);
            Assert.AreEqual((short)0, w[5].s0);
            Assert.AreEqual((short)0, w[5].s2);
            Assert.AreEqual((short)3, r[8].s0);
            Assert.AreEqual((short)1, r[8].s1);
            Assert.AreEqual((short)1, w[6].s2);
            Assert.AreEqual((short)2, w[6].s0);
            Assert.AreEqual((short)0, w[6].s1);
            Assert.AreEqual((short)0, w[6].s3);
            Assert.AreEqual((short)3, r[9].s0);
            Assert.AreEqual((short)2, r[9].s1);
            Assert.AreEqual((short)1, w[7].s2);
            Assert.AreEqual((short)2, w[7].s1);
            Assert.AreEqual((short)0, w[7].s0);
            Assert.AreEqual((short)0, w[7].s3);
            Assert.AreEqual((short)3, r[10].s0);
            Assert.AreEqual((short)3, r[10].s1);
            Assert.AreEqual((short)3, r[11].s0);
            Assert.AreEqual((short)4, r[11].s1);
            Assert.AreEqual((short)1, w[8].s2);
            Assert.AreEqual((short)2, w[8].s3);
            Assert.AreEqual((short)0, w[8].s0);
            Assert.AreEqual((short)0, w[8].s1);
            Assert.AreEqual((short)4, r[12].s0);
            Assert.AreEqual((short)1, r[12].s1);
            Assert.AreEqual((short)1, w[9].s3);
            Assert.AreEqual((short)2, w[9].s0);
            Assert.AreEqual((short)0, w[9].s1);
            Assert.AreEqual((short)0, w[9].s2);
            Assert.AreEqual((short)4, r[13].s0);
            Assert.AreEqual((short)2, r[13].s1);
            Assert.AreEqual((short)1, w[10].s3);
            Assert.AreEqual((short)2, w[10].s1);
            Assert.AreEqual((short)0, w[10].s0);
            Assert.AreEqual((short)0, w[10].s2);
            Assert.AreEqual((short)4, r[14].s0);
            Assert.AreEqual((short)3, r[14].s1);
            Assert.AreEqual((short)1, w[11].s3);
            Assert.AreEqual((short)2, w[11].s2);
            Assert.AreEqual((short)0, w[11].s0);
            Assert.AreEqual((short)0, w[11].s1);
            Assert.AreEqual((short)4, r[15].s0);
            Assert.AreEqual((short)4, r[15].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_components2");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<short2>;
                var mw = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components2");
                    mr = Mem<short2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<short2>());
                    mw = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<short4>());
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
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)2, r[1].s1);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)0, w[0].s2);
            Assert.AreEqual((short)0, w[0].s3);
            Assert.AreEqual((short)1, r[2].s0);
            Assert.AreEqual((short)3, r[2].s1);
            Assert.AreEqual((short)1, w[1].s0);
            Assert.AreEqual((short)2, w[1].s2);
            Assert.AreEqual((short)0, w[1].s1);
            Assert.AreEqual((short)0, w[1].s3);
            Assert.AreEqual((short)1, r[3].s0);
            Assert.AreEqual((short)4, r[3].s1);
            Assert.AreEqual((short)1, w[2].s0);
            Assert.AreEqual((short)2, w[2].s3);
            Assert.AreEqual((short)0, w[2].s1);
            Assert.AreEqual((short)0, w[2].s2);
            Assert.AreEqual((short)2, r[4].s0);
            Assert.AreEqual((short)1, r[4].s1);
            Assert.AreEqual((short)1, w[3].s1);
            Assert.AreEqual((short)2, w[3].s0);
            Assert.AreEqual((short)0, w[3].s2);
            Assert.AreEqual((short)0, w[3].s3);
            Assert.AreEqual((short)2, r[5].s0);
            Assert.AreEqual((short)2, r[5].s1);
            Assert.AreEqual((short)2, r[6].s0);
            Assert.AreEqual((short)3, r[6].s1);
            Assert.AreEqual((short)1, w[4].s1);
            Assert.AreEqual((short)2, w[4].s2);
            Assert.AreEqual((short)0, w[4].s0);
            Assert.AreEqual((short)0, w[4].s3);
            Assert.AreEqual((short)2, r[7].s0);
            Assert.AreEqual((short)4, r[7].s1);
            Assert.AreEqual((short)1, w[5].s1);
            Assert.AreEqual((short)2, w[5].s3);
            Assert.AreEqual((short)0, w[5].s0);
            Assert.AreEqual((short)0, w[5].s2);
            Assert.AreEqual((short)3, r[8].s0);
            Assert.AreEqual((short)1, r[8].s1);
            Assert.AreEqual((short)1, w[6].s2);
            Assert.AreEqual((short)2, w[6].s0);
            Assert.AreEqual((short)0, w[6].s1);
            Assert.AreEqual((short)0, w[6].s3);
            Assert.AreEqual((short)3, r[9].s0);
            Assert.AreEqual((short)2, r[9].s1);
            Assert.AreEqual((short)1, w[7].s2);
            Assert.AreEqual((short)2, w[7].s1);
            Assert.AreEqual((short)0, w[7].s0);
            Assert.AreEqual((short)0, w[7].s3);
            Assert.AreEqual((short)3, r[10].s0);
            Assert.AreEqual((short)3, r[10].s1);
            Assert.AreEqual((short)3, r[11].s0);
            Assert.AreEqual((short)4, r[11].s1);
            Assert.AreEqual((short)1, w[8].s2);
            Assert.AreEqual((short)2, w[8].s3);
            Assert.AreEqual((short)0, w[8].s0);
            Assert.AreEqual((short)0, w[8].s1);
            Assert.AreEqual((short)4, r[12].s0);
            Assert.AreEqual((short)1, r[12].s1);
            Assert.AreEqual((short)1, w[9].s3);
            Assert.AreEqual((short)2, w[9].s0);
            Assert.AreEqual((short)0, w[9].s1);
            Assert.AreEqual((short)0, w[9].s2);
            Assert.AreEqual((short)4, r[13].s0);
            Assert.AreEqual((short)2, r[13].s1);
            Assert.AreEqual((short)1, w[10].s3);
            Assert.AreEqual((short)2, w[10].s1);
            Assert.AreEqual((short)0, w[10].s0);
            Assert.AreEqual((short)0, w[10].s2);
            Assert.AreEqual((short)4, r[14].s0);
            Assert.AreEqual((short)3, r[14].s1);
            Assert.AreEqual((short)1, w[11].s3);
            Assert.AreEqual((short)2, w[11].s2);
            Assert.AreEqual((short)0, w[11].s0);
            Assert.AreEqual((short)0, w[11].s1);
            Assert.AreEqual((short)4, r[15].s0);
            Assert.AreEqual((short)4, r[15].s1);
        }
        [Kernel]
        private static void test_components3([Global] short3[] r, [Global] short4[] w)
        {
            short4 ar = new short4((short)1, (short)2, (short)3, (short)4);
            short3 aw = new short3((short)1, (short)2, (short)3);
            r[0] = ar.xxx;
            r[1] = ar.xxy;
            r[2] = ar.xxz;
            r[3] = ar.xxw;
            r[4] = ar.xyx;
            r[5] = ar.xyy;
            r[6] = ar.xyz;
            w[0].xyz = aw;
            r[7] = ar.xyw;
            w[1].xyw = aw;
            r[8] = ar.xzx;
            r[9] = ar.xzy;
            w[2].xzy = aw;
            r[10] = ar.xzz;
            r[11] = ar.xzw;
            w[3].xzw = aw;
            r[12] = ar.xwx;
            r[13] = ar.xwy;
            w[4].xwy = aw;
            r[14] = ar.xwz;
            w[5].xwz = aw;
            r[15] = ar.xww;
            r[16] = ar.yxx;
            r[17] = ar.yxy;
            r[18] = ar.yxz;
            w[6].yxz = aw;
            r[19] = ar.yxw;
            w[7].yxw = aw;
            r[20] = ar.yyx;
            r[21] = ar.yyy;
            r[22] = ar.yyz;
            r[23] = ar.yyw;
            r[24] = ar.yzx;
            w[8].yzx = aw;
            r[25] = ar.yzy;
            r[26] = ar.yzz;
            r[27] = ar.yzw;
            w[9].yzw = aw;
            r[28] = ar.ywx;
            w[10].ywx = aw;
            r[29] = ar.ywy;
            r[30] = ar.ywz;
            w[11].ywz = aw;
            r[31] = ar.yww;
            r[32] = ar.zxx;
            r[33] = ar.zxy;
            w[12].zxy = aw;
            r[34] = ar.zxz;
            r[35] = ar.zxw;
            w[13].zxw = aw;
            r[36] = ar.zyx;
            w[14].zyx = aw;
            r[37] = ar.zyy;
            r[38] = ar.zyz;
            r[39] = ar.zyw;
            w[15].zyw = aw;
            r[40] = ar.zzx;
            r[41] = ar.zzy;
            r[42] = ar.zzz;
            r[43] = ar.zzw;
            r[44] = ar.zwx;
            w[16].zwx = aw;
            r[45] = ar.zwy;
            w[17].zwy = aw;
            r[46] = ar.zwz;
            r[47] = ar.zww;
            r[48] = ar.wxx;
            r[49] = ar.wxy;
            w[18].wxy = aw;
            r[50] = ar.wxz;
            w[19].wxz = aw;
            r[51] = ar.wxw;
            r[52] = ar.wyx;
            w[20].wyx = aw;
            r[53] = ar.wyy;
            r[54] = ar.wyz;
            w[21].wyz = aw;
            r[55] = ar.wyw;
            r[56] = ar.wzx;
            w[22].wzx = aw;
            r[57] = ar.wzy;
            w[23].wzy = aw;
            r[58] = ar.wzz;
            r[59] = ar.wzw;
            r[60] = ar.wwx;
            r[61] = ar.wwy;
            r[62] = ar.wwz;
            r[63] = ar.www;
        }

        [Test]
        public void TestComponentAccessors3()
        {
            int nr = 64;
            int nw = 24;
            short3[] r = new short3[nr];
            short4[] w = new short4[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<short3[],short4[]>)test_components3,
                r, w
            );
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[0].s2);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)1, r[1].s1);
            Assert.AreEqual((short)2, r[1].s2);
            Assert.AreEqual((short)1, r[2].s0);
            Assert.AreEqual((short)1, r[2].s1);
            Assert.AreEqual((short)3, r[2].s2);
            Assert.AreEqual((short)1, r[3].s0);
            Assert.AreEqual((short)1, r[3].s1);
            Assert.AreEqual((short)4, r[3].s2);
            Assert.AreEqual((short)1, r[4].s0);
            Assert.AreEqual((short)2, r[4].s1);
            Assert.AreEqual((short)1, r[4].s2);
            Assert.AreEqual((short)1, r[5].s0);
            Assert.AreEqual((short)2, r[5].s1);
            Assert.AreEqual((short)2, r[5].s2);
            Assert.AreEqual((short)1, r[6].s0);
            Assert.AreEqual((short)2, r[6].s1);
            Assert.AreEqual((short)3, r[6].s2);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)3, w[0].s2);
            Assert.AreEqual((short)0, w[0].s3);
            Assert.AreEqual((short)1, r[7].s0);
            Assert.AreEqual((short)2, r[7].s1);
            Assert.AreEqual((short)4, r[7].s2);
            Assert.AreEqual((short)1, w[1].s0);
            Assert.AreEqual((short)2, w[1].s1);
            Assert.AreEqual((short)3, w[1].s3);
            Assert.AreEqual((short)0, w[1].s2);
            Assert.AreEqual((short)1, r[8].s0);
            Assert.AreEqual((short)3, r[8].s1);
            Assert.AreEqual((short)1, r[8].s2);
            Assert.AreEqual((short)1, r[9].s0);
            Assert.AreEqual((short)3, r[9].s1);
            Assert.AreEqual((short)2, r[9].s2);
            Assert.AreEqual((short)1, w[2].s0);
            Assert.AreEqual((short)2, w[2].s2);
            Assert.AreEqual((short)3, w[2].s1);
            Assert.AreEqual((short)0, w[2].s3);
            Assert.AreEqual((short)1, r[10].s0);
            Assert.AreEqual((short)3, r[10].s1);
            Assert.AreEqual((short)3, r[10].s2);
            Assert.AreEqual((short)1, r[11].s0);
            Assert.AreEqual((short)3, r[11].s1);
            Assert.AreEqual((short)4, r[11].s2);
            Assert.AreEqual((short)1, w[3].s0);
            Assert.AreEqual((short)2, w[3].s2);
            Assert.AreEqual((short)3, w[3].s3);
            Assert.AreEqual((short)0, w[3].s1);
            Assert.AreEqual((short)1, r[12].s0);
            Assert.AreEqual((short)4, r[12].s1);
            Assert.AreEqual((short)1, r[12].s2);
            Assert.AreEqual((short)1, r[13].s0);
            Assert.AreEqual((short)4, r[13].s1);
            Assert.AreEqual((short)2, r[13].s2);
            Assert.AreEqual((short)1, w[4].s0);
            Assert.AreEqual((short)2, w[4].s3);
            Assert.AreEqual((short)3, w[4].s1);
            Assert.AreEqual((short)0, w[4].s2);
            Assert.AreEqual((short)1, r[14].s0);
            Assert.AreEqual((short)4, r[14].s1);
            Assert.AreEqual((short)3, r[14].s2);
            Assert.AreEqual((short)1, w[5].s0);
            Assert.AreEqual((short)2, w[5].s3);
            Assert.AreEqual((short)3, w[5].s2);
            Assert.AreEqual((short)0, w[5].s1);
            Assert.AreEqual((short)1, r[15].s0);
            Assert.AreEqual((short)4, r[15].s1);
            Assert.AreEqual((short)4, r[15].s2);
            Assert.AreEqual((short)2, r[16].s0);
            Assert.AreEqual((short)1, r[16].s1);
            Assert.AreEqual((short)1, r[16].s2);
            Assert.AreEqual((short)2, r[17].s0);
            Assert.AreEqual((short)1, r[17].s1);
            Assert.AreEqual((short)2, r[17].s2);
            Assert.AreEqual((short)2, r[18].s0);
            Assert.AreEqual((short)1, r[18].s1);
            Assert.AreEqual((short)3, r[18].s2);
            Assert.AreEqual((short)1, w[6].s1);
            Assert.AreEqual((short)2, w[6].s0);
            Assert.AreEqual((short)3, w[6].s2);
            Assert.AreEqual((short)0, w[6].s3);
            Assert.AreEqual((short)2, r[19].s0);
            Assert.AreEqual((short)1, r[19].s1);
            Assert.AreEqual((short)4, r[19].s2);
            Assert.AreEqual((short)1, w[7].s1);
            Assert.AreEqual((short)2, w[7].s0);
            Assert.AreEqual((short)3, w[7].s3);
            Assert.AreEqual((short)0, w[7].s2);
            Assert.AreEqual((short)2, r[20].s0);
            Assert.AreEqual((short)2, r[20].s1);
            Assert.AreEqual((short)1, r[20].s2);
            Assert.AreEqual((short)2, r[21].s0);
            Assert.AreEqual((short)2, r[21].s1);
            Assert.AreEqual((short)2, r[21].s2);
            Assert.AreEqual((short)2, r[22].s0);
            Assert.AreEqual((short)2, r[22].s1);
            Assert.AreEqual((short)3, r[22].s2);
            Assert.AreEqual((short)2, r[23].s0);
            Assert.AreEqual((short)2, r[23].s1);
            Assert.AreEqual((short)4, r[23].s2);
            Assert.AreEqual((short)2, r[24].s0);
            Assert.AreEqual((short)3, r[24].s1);
            Assert.AreEqual((short)1, r[24].s2);
            Assert.AreEqual((short)1, w[8].s1);
            Assert.AreEqual((short)2, w[8].s2);
            Assert.AreEqual((short)3, w[8].s0);
            Assert.AreEqual((short)0, w[8].s3);
            Assert.AreEqual((short)2, r[25].s0);
            Assert.AreEqual((short)3, r[25].s1);
            Assert.AreEqual((short)2, r[25].s2);
            Assert.AreEqual((short)2, r[26].s0);
            Assert.AreEqual((short)3, r[26].s1);
            Assert.AreEqual((short)3, r[26].s2);
            Assert.AreEqual((short)2, r[27].s0);
            Assert.AreEqual((short)3, r[27].s1);
            Assert.AreEqual((short)4, r[27].s2);
            Assert.AreEqual((short)1, w[9].s1);
            Assert.AreEqual((short)2, w[9].s2);
            Assert.AreEqual((short)3, w[9].s3);
            Assert.AreEqual((short)0, w[9].s0);
            Assert.AreEqual((short)2, r[28].s0);
            Assert.AreEqual((short)4, r[28].s1);
            Assert.AreEqual((short)1, r[28].s2);
            Assert.AreEqual((short)1, w[10].s1);
            Assert.AreEqual((short)2, w[10].s3);
            Assert.AreEqual((short)3, w[10].s0);
            Assert.AreEqual((short)0, w[10].s2);
            Assert.AreEqual((short)2, r[29].s0);
            Assert.AreEqual((short)4, r[29].s1);
            Assert.AreEqual((short)2, r[29].s2);
            Assert.AreEqual((short)2, r[30].s0);
            Assert.AreEqual((short)4, r[30].s1);
            Assert.AreEqual((short)3, r[30].s2);
            Assert.AreEqual((short)1, w[11].s1);
            Assert.AreEqual((short)2, w[11].s3);
            Assert.AreEqual((short)3, w[11].s2);
            Assert.AreEqual((short)0, w[11].s0);
            Assert.AreEqual((short)2, r[31].s0);
            Assert.AreEqual((short)4, r[31].s1);
            Assert.AreEqual((short)4, r[31].s2);
            Assert.AreEqual((short)3, r[32].s0);
            Assert.AreEqual((short)1, r[32].s1);
            Assert.AreEqual((short)1, r[32].s2);
            Assert.AreEqual((short)3, r[33].s0);
            Assert.AreEqual((short)1, r[33].s1);
            Assert.AreEqual((short)2, r[33].s2);
            Assert.AreEqual((short)1, w[12].s2);
            Assert.AreEqual((short)2, w[12].s0);
            Assert.AreEqual((short)3, w[12].s1);
            Assert.AreEqual((short)0, w[12].s3);
            Assert.AreEqual((short)3, r[34].s0);
            Assert.AreEqual((short)1, r[34].s1);
            Assert.AreEqual((short)3, r[34].s2);
            Assert.AreEqual((short)3, r[35].s0);
            Assert.AreEqual((short)1, r[35].s1);
            Assert.AreEqual((short)4, r[35].s2);
            Assert.AreEqual((short)1, w[13].s2);
            Assert.AreEqual((short)2, w[13].s0);
            Assert.AreEqual((short)3, w[13].s3);
            Assert.AreEqual((short)0, w[13].s1);
            Assert.AreEqual((short)3, r[36].s0);
            Assert.AreEqual((short)2, r[36].s1);
            Assert.AreEqual((short)1, r[36].s2);
            Assert.AreEqual((short)1, w[14].s2);
            Assert.AreEqual((short)2, w[14].s1);
            Assert.AreEqual((short)3, w[14].s0);
            Assert.AreEqual((short)0, w[14].s3);
            Assert.AreEqual((short)3, r[37].s0);
            Assert.AreEqual((short)2, r[37].s1);
            Assert.AreEqual((short)2, r[37].s2);
            Assert.AreEqual((short)3, r[38].s0);
            Assert.AreEqual((short)2, r[38].s1);
            Assert.AreEqual((short)3, r[38].s2);
            Assert.AreEqual((short)3, r[39].s0);
            Assert.AreEqual((short)2, r[39].s1);
            Assert.AreEqual((short)4, r[39].s2);
            Assert.AreEqual((short)1, w[15].s2);
            Assert.AreEqual((short)2, w[15].s1);
            Assert.AreEqual((short)3, w[15].s3);
            Assert.AreEqual((short)0, w[15].s0);
            Assert.AreEqual((short)3, r[40].s0);
            Assert.AreEqual((short)3, r[40].s1);
            Assert.AreEqual((short)1, r[40].s2);
            Assert.AreEqual((short)3, r[41].s0);
            Assert.AreEqual((short)3, r[41].s1);
            Assert.AreEqual((short)2, r[41].s2);
            Assert.AreEqual((short)3, r[42].s0);
            Assert.AreEqual((short)3, r[42].s1);
            Assert.AreEqual((short)3, r[42].s2);
            Assert.AreEqual((short)3, r[43].s0);
            Assert.AreEqual((short)3, r[43].s1);
            Assert.AreEqual((short)4, r[43].s2);
            Assert.AreEqual((short)3, r[44].s0);
            Assert.AreEqual((short)4, r[44].s1);
            Assert.AreEqual((short)1, r[44].s2);
            Assert.AreEqual((short)1, w[16].s2);
            Assert.AreEqual((short)2, w[16].s3);
            Assert.AreEqual((short)3, w[16].s0);
            Assert.AreEqual((short)0, w[16].s1);
            Assert.AreEqual((short)3, r[45].s0);
            Assert.AreEqual((short)4, r[45].s1);
            Assert.AreEqual((short)2, r[45].s2);
            Assert.AreEqual((short)1, w[17].s2);
            Assert.AreEqual((short)2, w[17].s3);
            Assert.AreEqual((short)3, w[17].s1);
            Assert.AreEqual((short)0, w[17].s0);
            Assert.AreEqual((short)3, r[46].s0);
            Assert.AreEqual((short)4, r[46].s1);
            Assert.AreEqual((short)3, r[46].s2);
            Assert.AreEqual((short)3, r[47].s0);
            Assert.AreEqual((short)4, r[47].s1);
            Assert.AreEqual((short)4, r[47].s2);
            Assert.AreEqual((short)4, r[48].s0);
            Assert.AreEqual((short)1, r[48].s1);
            Assert.AreEqual((short)1, r[48].s2);
            Assert.AreEqual((short)4, r[49].s0);
            Assert.AreEqual((short)1, r[49].s1);
            Assert.AreEqual((short)2, r[49].s2);
            Assert.AreEqual((short)1, w[18].s3);
            Assert.AreEqual((short)2, w[18].s0);
            Assert.AreEqual((short)3, w[18].s1);
            Assert.AreEqual((short)0, w[18].s2);
            Assert.AreEqual((short)4, r[50].s0);
            Assert.AreEqual((short)1, r[50].s1);
            Assert.AreEqual((short)3, r[50].s2);
            Assert.AreEqual((short)1, w[19].s3);
            Assert.AreEqual((short)2, w[19].s0);
            Assert.AreEqual((short)3, w[19].s2);
            Assert.AreEqual((short)0, w[19].s1);
            Assert.AreEqual((short)4, r[51].s0);
            Assert.AreEqual((short)1, r[51].s1);
            Assert.AreEqual((short)4, r[51].s2);
            Assert.AreEqual((short)4, r[52].s0);
            Assert.AreEqual((short)2, r[52].s1);
            Assert.AreEqual((short)1, r[52].s2);
            Assert.AreEqual((short)1, w[20].s3);
            Assert.AreEqual((short)2, w[20].s1);
            Assert.AreEqual((short)3, w[20].s0);
            Assert.AreEqual((short)0, w[20].s2);
            Assert.AreEqual((short)4, r[53].s0);
            Assert.AreEqual((short)2, r[53].s1);
            Assert.AreEqual((short)2, r[53].s2);
            Assert.AreEqual((short)4, r[54].s0);
            Assert.AreEqual((short)2, r[54].s1);
            Assert.AreEqual((short)3, r[54].s2);
            Assert.AreEqual((short)1, w[21].s3);
            Assert.AreEqual((short)2, w[21].s1);
            Assert.AreEqual((short)3, w[21].s2);
            Assert.AreEqual((short)0, w[21].s0);
            Assert.AreEqual((short)4, r[55].s0);
            Assert.AreEqual((short)2, r[55].s1);
            Assert.AreEqual((short)4, r[55].s2);
            Assert.AreEqual((short)4, r[56].s0);
            Assert.AreEqual((short)3, r[56].s1);
            Assert.AreEqual((short)1, r[56].s2);
            Assert.AreEqual((short)1, w[22].s3);
            Assert.AreEqual((short)2, w[22].s2);
            Assert.AreEqual((short)3, w[22].s0);
            Assert.AreEqual((short)0, w[22].s1);
            Assert.AreEqual((short)4, r[57].s0);
            Assert.AreEqual((short)3, r[57].s1);
            Assert.AreEqual((short)2, r[57].s2);
            Assert.AreEqual((short)1, w[23].s3);
            Assert.AreEqual((short)2, w[23].s2);
            Assert.AreEqual((short)3, w[23].s1);
            Assert.AreEqual((short)0, w[23].s0);
            Assert.AreEqual((short)4, r[58].s0);
            Assert.AreEqual((short)3, r[58].s1);
            Assert.AreEqual((short)3, r[58].s2);
            Assert.AreEqual((short)4, r[59].s0);
            Assert.AreEqual((short)3, r[59].s1);
            Assert.AreEqual((short)4, r[59].s2);
            Assert.AreEqual((short)4, r[60].s0);
            Assert.AreEqual((short)4, r[60].s1);
            Assert.AreEqual((short)1, r[60].s2);
            Assert.AreEqual((short)4, r[61].s0);
            Assert.AreEqual((short)4, r[61].s1);
            Assert.AreEqual((short)2, r[61].s2);
            Assert.AreEqual((short)4, r[62].s0);
            Assert.AreEqual((short)4, r[62].s1);
            Assert.AreEqual((short)3, r[62].s2);
            Assert.AreEqual((short)4, r[63].s0);
            Assert.AreEqual((short)4, r[63].s1);
            Assert.AreEqual((short)4, r[63].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_components3");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<short3>;
                var mw = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components3");
                    mr = Mem<short3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<short3>());
                    mw = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<short4>());
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
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[0].s2);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)1, r[1].s1);
            Assert.AreEqual((short)2, r[1].s2);
            Assert.AreEqual((short)1, r[2].s0);
            Assert.AreEqual((short)1, r[2].s1);
            Assert.AreEqual((short)3, r[2].s2);
            Assert.AreEqual((short)1, r[3].s0);
            Assert.AreEqual((short)1, r[3].s1);
            Assert.AreEqual((short)4, r[3].s2);
            Assert.AreEqual((short)1, r[4].s0);
            Assert.AreEqual((short)2, r[4].s1);
            Assert.AreEqual((short)1, r[4].s2);
            Assert.AreEqual((short)1, r[5].s0);
            Assert.AreEqual((short)2, r[5].s1);
            Assert.AreEqual((short)2, r[5].s2);
            Assert.AreEqual((short)1, r[6].s0);
            Assert.AreEqual((short)2, r[6].s1);
            Assert.AreEqual((short)3, r[6].s2);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)3, w[0].s2);
            Assert.AreEqual((short)0, w[0].s3);
            Assert.AreEqual((short)1, r[7].s0);
            Assert.AreEqual((short)2, r[7].s1);
            Assert.AreEqual((short)4, r[7].s2);
            Assert.AreEqual((short)1, w[1].s0);
            Assert.AreEqual((short)2, w[1].s1);
            Assert.AreEqual((short)3, w[1].s3);
            Assert.AreEqual((short)0, w[1].s2);
            Assert.AreEqual((short)1, r[8].s0);
            Assert.AreEqual((short)3, r[8].s1);
            Assert.AreEqual((short)1, r[8].s2);
            Assert.AreEqual((short)1, r[9].s0);
            Assert.AreEqual((short)3, r[9].s1);
            Assert.AreEqual((short)2, r[9].s2);
            Assert.AreEqual((short)1, w[2].s0);
            Assert.AreEqual((short)2, w[2].s2);
            Assert.AreEqual((short)3, w[2].s1);
            Assert.AreEqual((short)0, w[2].s3);
            Assert.AreEqual((short)1, r[10].s0);
            Assert.AreEqual((short)3, r[10].s1);
            Assert.AreEqual((short)3, r[10].s2);
            Assert.AreEqual((short)1, r[11].s0);
            Assert.AreEqual((short)3, r[11].s1);
            Assert.AreEqual((short)4, r[11].s2);
            Assert.AreEqual((short)1, w[3].s0);
            Assert.AreEqual((short)2, w[3].s2);
            Assert.AreEqual((short)3, w[3].s3);
            Assert.AreEqual((short)0, w[3].s1);
            Assert.AreEqual((short)1, r[12].s0);
            Assert.AreEqual((short)4, r[12].s1);
            Assert.AreEqual((short)1, r[12].s2);
            Assert.AreEqual((short)1, r[13].s0);
            Assert.AreEqual((short)4, r[13].s1);
            Assert.AreEqual((short)2, r[13].s2);
            Assert.AreEqual((short)1, w[4].s0);
            Assert.AreEqual((short)2, w[4].s3);
            Assert.AreEqual((short)3, w[4].s1);
            Assert.AreEqual((short)0, w[4].s2);
            Assert.AreEqual((short)1, r[14].s0);
            Assert.AreEqual((short)4, r[14].s1);
            Assert.AreEqual((short)3, r[14].s2);
            Assert.AreEqual((short)1, w[5].s0);
            Assert.AreEqual((short)2, w[5].s3);
            Assert.AreEqual((short)3, w[5].s2);
            Assert.AreEqual((short)0, w[5].s1);
            Assert.AreEqual((short)1, r[15].s0);
            Assert.AreEqual((short)4, r[15].s1);
            Assert.AreEqual((short)4, r[15].s2);
            Assert.AreEqual((short)2, r[16].s0);
            Assert.AreEqual((short)1, r[16].s1);
            Assert.AreEqual((short)1, r[16].s2);
            Assert.AreEqual((short)2, r[17].s0);
            Assert.AreEqual((short)1, r[17].s1);
            Assert.AreEqual((short)2, r[17].s2);
            Assert.AreEqual((short)2, r[18].s0);
            Assert.AreEqual((short)1, r[18].s1);
            Assert.AreEqual((short)3, r[18].s2);
            Assert.AreEqual((short)1, w[6].s1);
            Assert.AreEqual((short)2, w[6].s0);
            Assert.AreEqual((short)3, w[6].s2);
            Assert.AreEqual((short)0, w[6].s3);
            Assert.AreEqual((short)2, r[19].s0);
            Assert.AreEqual((short)1, r[19].s1);
            Assert.AreEqual((short)4, r[19].s2);
            Assert.AreEqual((short)1, w[7].s1);
            Assert.AreEqual((short)2, w[7].s0);
            Assert.AreEqual((short)3, w[7].s3);
            Assert.AreEqual((short)0, w[7].s2);
            Assert.AreEqual((short)2, r[20].s0);
            Assert.AreEqual((short)2, r[20].s1);
            Assert.AreEqual((short)1, r[20].s2);
            Assert.AreEqual((short)2, r[21].s0);
            Assert.AreEqual((short)2, r[21].s1);
            Assert.AreEqual((short)2, r[21].s2);
            Assert.AreEqual((short)2, r[22].s0);
            Assert.AreEqual((short)2, r[22].s1);
            Assert.AreEqual((short)3, r[22].s2);
            Assert.AreEqual((short)2, r[23].s0);
            Assert.AreEqual((short)2, r[23].s1);
            Assert.AreEqual((short)4, r[23].s2);
            Assert.AreEqual((short)2, r[24].s0);
            Assert.AreEqual((short)3, r[24].s1);
            Assert.AreEqual((short)1, r[24].s2);
            Assert.AreEqual((short)1, w[8].s1);
            Assert.AreEqual((short)2, w[8].s2);
            Assert.AreEqual((short)3, w[8].s0);
            Assert.AreEqual((short)0, w[8].s3);
            Assert.AreEqual((short)2, r[25].s0);
            Assert.AreEqual((short)3, r[25].s1);
            Assert.AreEqual((short)2, r[25].s2);
            Assert.AreEqual((short)2, r[26].s0);
            Assert.AreEqual((short)3, r[26].s1);
            Assert.AreEqual((short)3, r[26].s2);
            Assert.AreEqual((short)2, r[27].s0);
            Assert.AreEqual((short)3, r[27].s1);
            Assert.AreEqual((short)4, r[27].s2);
            Assert.AreEqual((short)1, w[9].s1);
            Assert.AreEqual((short)2, w[9].s2);
            Assert.AreEqual((short)3, w[9].s3);
            Assert.AreEqual((short)0, w[9].s0);
            Assert.AreEqual((short)2, r[28].s0);
            Assert.AreEqual((short)4, r[28].s1);
            Assert.AreEqual((short)1, r[28].s2);
            Assert.AreEqual((short)1, w[10].s1);
            Assert.AreEqual((short)2, w[10].s3);
            Assert.AreEqual((short)3, w[10].s0);
            Assert.AreEqual((short)0, w[10].s2);
            Assert.AreEqual((short)2, r[29].s0);
            Assert.AreEqual((short)4, r[29].s1);
            Assert.AreEqual((short)2, r[29].s2);
            Assert.AreEqual((short)2, r[30].s0);
            Assert.AreEqual((short)4, r[30].s1);
            Assert.AreEqual((short)3, r[30].s2);
            Assert.AreEqual((short)1, w[11].s1);
            Assert.AreEqual((short)2, w[11].s3);
            Assert.AreEqual((short)3, w[11].s2);
            Assert.AreEqual((short)0, w[11].s0);
            Assert.AreEqual((short)2, r[31].s0);
            Assert.AreEqual((short)4, r[31].s1);
            Assert.AreEqual((short)4, r[31].s2);
            Assert.AreEqual((short)3, r[32].s0);
            Assert.AreEqual((short)1, r[32].s1);
            Assert.AreEqual((short)1, r[32].s2);
            Assert.AreEqual((short)3, r[33].s0);
            Assert.AreEqual((short)1, r[33].s1);
            Assert.AreEqual((short)2, r[33].s2);
            Assert.AreEqual((short)1, w[12].s2);
            Assert.AreEqual((short)2, w[12].s0);
            Assert.AreEqual((short)3, w[12].s1);
            Assert.AreEqual((short)0, w[12].s3);
            Assert.AreEqual((short)3, r[34].s0);
            Assert.AreEqual((short)1, r[34].s1);
            Assert.AreEqual((short)3, r[34].s2);
            Assert.AreEqual((short)3, r[35].s0);
            Assert.AreEqual((short)1, r[35].s1);
            Assert.AreEqual((short)4, r[35].s2);
            Assert.AreEqual((short)1, w[13].s2);
            Assert.AreEqual((short)2, w[13].s0);
            Assert.AreEqual((short)3, w[13].s3);
            Assert.AreEqual((short)0, w[13].s1);
            Assert.AreEqual((short)3, r[36].s0);
            Assert.AreEqual((short)2, r[36].s1);
            Assert.AreEqual((short)1, r[36].s2);
            Assert.AreEqual((short)1, w[14].s2);
            Assert.AreEqual((short)2, w[14].s1);
            Assert.AreEqual((short)3, w[14].s0);
            Assert.AreEqual((short)0, w[14].s3);
            Assert.AreEqual((short)3, r[37].s0);
            Assert.AreEqual((short)2, r[37].s1);
            Assert.AreEqual((short)2, r[37].s2);
            Assert.AreEqual((short)3, r[38].s0);
            Assert.AreEqual((short)2, r[38].s1);
            Assert.AreEqual((short)3, r[38].s2);
            Assert.AreEqual((short)3, r[39].s0);
            Assert.AreEqual((short)2, r[39].s1);
            Assert.AreEqual((short)4, r[39].s2);
            Assert.AreEqual((short)1, w[15].s2);
            Assert.AreEqual((short)2, w[15].s1);
            Assert.AreEqual((short)3, w[15].s3);
            Assert.AreEqual((short)0, w[15].s0);
            Assert.AreEqual((short)3, r[40].s0);
            Assert.AreEqual((short)3, r[40].s1);
            Assert.AreEqual((short)1, r[40].s2);
            Assert.AreEqual((short)3, r[41].s0);
            Assert.AreEqual((short)3, r[41].s1);
            Assert.AreEqual((short)2, r[41].s2);
            Assert.AreEqual((short)3, r[42].s0);
            Assert.AreEqual((short)3, r[42].s1);
            Assert.AreEqual((short)3, r[42].s2);
            Assert.AreEqual((short)3, r[43].s0);
            Assert.AreEqual((short)3, r[43].s1);
            Assert.AreEqual((short)4, r[43].s2);
            Assert.AreEqual((short)3, r[44].s0);
            Assert.AreEqual((short)4, r[44].s1);
            Assert.AreEqual((short)1, r[44].s2);
            Assert.AreEqual((short)1, w[16].s2);
            Assert.AreEqual((short)2, w[16].s3);
            Assert.AreEqual((short)3, w[16].s0);
            Assert.AreEqual((short)0, w[16].s1);
            Assert.AreEqual((short)3, r[45].s0);
            Assert.AreEqual((short)4, r[45].s1);
            Assert.AreEqual((short)2, r[45].s2);
            Assert.AreEqual((short)1, w[17].s2);
            Assert.AreEqual((short)2, w[17].s3);
            Assert.AreEqual((short)3, w[17].s1);
            Assert.AreEqual((short)0, w[17].s0);
            Assert.AreEqual((short)3, r[46].s0);
            Assert.AreEqual((short)4, r[46].s1);
            Assert.AreEqual((short)3, r[46].s2);
            Assert.AreEqual((short)3, r[47].s0);
            Assert.AreEqual((short)4, r[47].s1);
            Assert.AreEqual((short)4, r[47].s2);
            Assert.AreEqual((short)4, r[48].s0);
            Assert.AreEqual((short)1, r[48].s1);
            Assert.AreEqual((short)1, r[48].s2);
            Assert.AreEqual((short)4, r[49].s0);
            Assert.AreEqual((short)1, r[49].s1);
            Assert.AreEqual((short)2, r[49].s2);
            Assert.AreEqual((short)1, w[18].s3);
            Assert.AreEqual((short)2, w[18].s0);
            Assert.AreEqual((short)3, w[18].s1);
            Assert.AreEqual((short)0, w[18].s2);
            Assert.AreEqual((short)4, r[50].s0);
            Assert.AreEqual((short)1, r[50].s1);
            Assert.AreEqual((short)3, r[50].s2);
            Assert.AreEqual((short)1, w[19].s3);
            Assert.AreEqual((short)2, w[19].s0);
            Assert.AreEqual((short)3, w[19].s2);
            Assert.AreEqual((short)0, w[19].s1);
            Assert.AreEqual((short)4, r[51].s0);
            Assert.AreEqual((short)1, r[51].s1);
            Assert.AreEqual((short)4, r[51].s2);
            Assert.AreEqual((short)4, r[52].s0);
            Assert.AreEqual((short)2, r[52].s1);
            Assert.AreEqual((short)1, r[52].s2);
            Assert.AreEqual((short)1, w[20].s3);
            Assert.AreEqual((short)2, w[20].s1);
            Assert.AreEqual((short)3, w[20].s0);
            Assert.AreEqual((short)0, w[20].s2);
            Assert.AreEqual((short)4, r[53].s0);
            Assert.AreEqual((short)2, r[53].s1);
            Assert.AreEqual((short)2, r[53].s2);
            Assert.AreEqual((short)4, r[54].s0);
            Assert.AreEqual((short)2, r[54].s1);
            Assert.AreEqual((short)3, r[54].s2);
            Assert.AreEqual((short)1, w[21].s3);
            Assert.AreEqual((short)2, w[21].s1);
            Assert.AreEqual((short)3, w[21].s2);
            Assert.AreEqual((short)0, w[21].s0);
            Assert.AreEqual((short)4, r[55].s0);
            Assert.AreEqual((short)2, r[55].s1);
            Assert.AreEqual((short)4, r[55].s2);
            Assert.AreEqual((short)4, r[56].s0);
            Assert.AreEqual((short)3, r[56].s1);
            Assert.AreEqual((short)1, r[56].s2);
            Assert.AreEqual((short)1, w[22].s3);
            Assert.AreEqual((short)2, w[22].s2);
            Assert.AreEqual((short)3, w[22].s0);
            Assert.AreEqual((short)0, w[22].s1);
            Assert.AreEqual((short)4, r[57].s0);
            Assert.AreEqual((short)3, r[57].s1);
            Assert.AreEqual((short)2, r[57].s2);
            Assert.AreEqual((short)1, w[23].s3);
            Assert.AreEqual((short)2, w[23].s2);
            Assert.AreEqual((short)3, w[23].s1);
            Assert.AreEqual((short)0, w[23].s0);
            Assert.AreEqual((short)4, r[58].s0);
            Assert.AreEqual((short)3, r[58].s1);
            Assert.AreEqual((short)3, r[58].s2);
            Assert.AreEqual((short)4, r[59].s0);
            Assert.AreEqual((short)3, r[59].s1);
            Assert.AreEqual((short)4, r[59].s2);
            Assert.AreEqual((short)4, r[60].s0);
            Assert.AreEqual((short)4, r[60].s1);
            Assert.AreEqual((short)1, r[60].s2);
            Assert.AreEqual((short)4, r[61].s0);
            Assert.AreEqual((short)4, r[61].s1);
            Assert.AreEqual((short)2, r[61].s2);
            Assert.AreEqual((short)4, r[62].s0);
            Assert.AreEqual((short)4, r[62].s1);
            Assert.AreEqual((short)3, r[62].s2);
            Assert.AreEqual((short)4, r[63].s0);
            Assert.AreEqual((short)4, r[63].s1);
            Assert.AreEqual((short)4, r[63].s2);
        }
        [Kernel]
        private static void test_components4([Global] short4[] r, [Global] short4[] w)
        {
            short4 ar = new short4((short)1, (short)2, (short)3, (short)4);
            short4 aw = new short4((short)1, (short)2, (short)3, (short)4);
            r[0] = ar.xxxx;
            r[1] = ar.xxxy;
            r[2] = ar.xxxz;
            r[3] = ar.xxxw;
            r[4] = ar.xxyx;
            r[5] = ar.xxyy;
            r[6] = ar.xxyz;
            r[7] = ar.xxyw;
            r[8] = ar.xxzx;
            r[9] = ar.xxzy;
            r[10] = ar.xxzz;
            r[11] = ar.xxzw;
            r[12] = ar.xxwx;
            r[13] = ar.xxwy;
            r[14] = ar.xxwz;
            r[15] = ar.xxww;
            r[16] = ar.xyxx;
            r[17] = ar.xyxy;
            r[18] = ar.xyxz;
            r[19] = ar.xyxw;
            r[20] = ar.xyyx;
            r[21] = ar.xyyy;
            r[22] = ar.xyyz;
            r[23] = ar.xyyw;
            r[24] = ar.xyzx;
            r[25] = ar.xyzy;
            r[26] = ar.xyzz;
            r[27] = ar.xyzw;
            w[0].xyzw = aw;
            r[28] = ar.xywx;
            r[29] = ar.xywy;
            r[30] = ar.xywz;
            w[1].xywz = aw;
            r[31] = ar.xyww;
            r[32] = ar.xzxx;
            r[33] = ar.xzxy;
            r[34] = ar.xzxz;
            r[35] = ar.xzxw;
            r[36] = ar.xzyx;
            r[37] = ar.xzyy;
            r[38] = ar.xzyz;
            r[39] = ar.xzyw;
            w[2].xzyw = aw;
            r[40] = ar.xzzx;
            r[41] = ar.xzzy;
            r[42] = ar.xzzz;
            r[43] = ar.xzzw;
            r[44] = ar.xzwx;
            r[45] = ar.xzwy;
            w[3].xzwy = aw;
            r[46] = ar.xzwz;
            r[47] = ar.xzww;
            r[48] = ar.xwxx;
            r[49] = ar.xwxy;
            r[50] = ar.xwxz;
            r[51] = ar.xwxw;
            r[52] = ar.xwyx;
            r[53] = ar.xwyy;
            r[54] = ar.xwyz;
            w[4].xwyz = aw;
            r[55] = ar.xwyw;
            r[56] = ar.xwzx;
            r[57] = ar.xwzy;
            w[5].xwzy = aw;
            r[58] = ar.xwzz;
            r[59] = ar.xwzw;
            r[60] = ar.xwwx;
            r[61] = ar.xwwy;
            r[62] = ar.xwwz;
            r[63] = ar.xwww;
            r[64] = ar.yxxx;
            r[65] = ar.yxxy;
            r[66] = ar.yxxz;
            r[67] = ar.yxxw;
            r[68] = ar.yxyx;
            r[69] = ar.yxyy;
            r[70] = ar.yxyz;
            r[71] = ar.yxyw;
            r[72] = ar.yxzx;
            r[73] = ar.yxzy;
            r[74] = ar.yxzz;
            r[75] = ar.yxzw;
            w[6].yxzw = aw;
            r[76] = ar.yxwx;
            r[77] = ar.yxwy;
            r[78] = ar.yxwz;
            w[7].yxwz = aw;
            r[79] = ar.yxww;
            r[80] = ar.yyxx;
            r[81] = ar.yyxy;
            r[82] = ar.yyxz;
            r[83] = ar.yyxw;
            r[84] = ar.yyyx;
            r[85] = ar.yyyy;
            r[86] = ar.yyyz;
            r[87] = ar.yyyw;
            r[88] = ar.yyzx;
            r[89] = ar.yyzy;
            r[90] = ar.yyzz;
            r[91] = ar.yyzw;
            r[92] = ar.yywx;
            r[93] = ar.yywy;
            r[94] = ar.yywz;
            r[95] = ar.yyww;
            r[96] = ar.yzxx;
            r[97] = ar.yzxy;
            r[98] = ar.yzxz;
            r[99] = ar.yzxw;
            w[8].yzxw = aw;
            r[100] = ar.yzyx;
            r[101] = ar.yzyy;
            r[102] = ar.yzyz;
            r[103] = ar.yzyw;
            r[104] = ar.yzzx;
            r[105] = ar.yzzy;
            r[106] = ar.yzzz;
            r[107] = ar.yzzw;
            r[108] = ar.yzwx;
            w[9].yzwx = aw;
            r[109] = ar.yzwy;
            r[110] = ar.yzwz;
            r[111] = ar.yzww;
            r[112] = ar.ywxx;
            r[113] = ar.ywxy;
            r[114] = ar.ywxz;
            w[10].ywxz = aw;
            r[115] = ar.ywxw;
            r[116] = ar.ywyx;
            r[117] = ar.ywyy;
            r[118] = ar.ywyz;
            r[119] = ar.ywyw;
            r[120] = ar.ywzx;
            w[11].ywzx = aw;
            r[121] = ar.ywzy;
            r[122] = ar.ywzz;
            r[123] = ar.ywzw;
            r[124] = ar.ywwx;
            r[125] = ar.ywwy;
            r[126] = ar.ywwz;
            r[127] = ar.ywww;
            r[128] = ar.zxxx;
            r[129] = ar.zxxy;
            r[130] = ar.zxxz;
            r[131] = ar.zxxw;
            r[132] = ar.zxyx;
            r[133] = ar.zxyy;
            r[134] = ar.zxyz;
            r[135] = ar.zxyw;
            w[12].zxyw = aw;
            r[136] = ar.zxzx;
            r[137] = ar.zxzy;
            r[138] = ar.zxzz;
            r[139] = ar.zxzw;
            r[140] = ar.zxwx;
            r[141] = ar.zxwy;
            w[13].zxwy = aw;
            r[142] = ar.zxwz;
            r[143] = ar.zxww;
            r[144] = ar.zyxx;
            r[145] = ar.zyxy;
            r[146] = ar.zyxz;
            r[147] = ar.zyxw;
            w[14].zyxw = aw;
            r[148] = ar.zyyx;
            r[149] = ar.zyyy;
            r[150] = ar.zyyz;
            r[151] = ar.zyyw;
            r[152] = ar.zyzx;
            r[153] = ar.zyzy;
            r[154] = ar.zyzz;
            r[155] = ar.zyzw;
            r[156] = ar.zywx;
            w[15].zywx = aw;
            r[157] = ar.zywy;
            r[158] = ar.zywz;
            r[159] = ar.zyww;
            r[160] = ar.zzxx;
            r[161] = ar.zzxy;
            r[162] = ar.zzxz;
            r[163] = ar.zzxw;
            r[164] = ar.zzyx;
            r[165] = ar.zzyy;
            r[166] = ar.zzyz;
            r[167] = ar.zzyw;
            r[168] = ar.zzzx;
            r[169] = ar.zzzy;
            r[170] = ar.zzzz;
            r[171] = ar.zzzw;
            r[172] = ar.zzwx;
            r[173] = ar.zzwy;
            r[174] = ar.zzwz;
            r[175] = ar.zzww;
            r[176] = ar.zwxx;
            r[177] = ar.zwxy;
            w[16].zwxy = aw;
            r[178] = ar.zwxz;
            r[179] = ar.zwxw;
            r[180] = ar.zwyx;
            w[17].zwyx = aw;
            r[181] = ar.zwyy;
            r[182] = ar.zwyz;
            r[183] = ar.zwyw;
            r[184] = ar.zwzx;
            r[185] = ar.zwzy;
            r[186] = ar.zwzz;
            r[187] = ar.zwzw;
            r[188] = ar.zwwx;
            r[189] = ar.zwwy;
            r[190] = ar.zwwz;
            r[191] = ar.zwww;
            r[192] = ar.wxxx;
            r[193] = ar.wxxy;
            r[194] = ar.wxxz;
            r[195] = ar.wxxw;
            r[196] = ar.wxyx;
            r[197] = ar.wxyy;
            r[198] = ar.wxyz;
            w[18].wxyz = aw;
            r[199] = ar.wxyw;
            r[200] = ar.wxzx;
            r[201] = ar.wxzy;
            w[19].wxzy = aw;
            r[202] = ar.wxzz;
            r[203] = ar.wxzw;
            r[204] = ar.wxwx;
            r[205] = ar.wxwy;
            r[206] = ar.wxwz;
            r[207] = ar.wxww;
            r[208] = ar.wyxx;
            r[209] = ar.wyxy;
            r[210] = ar.wyxz;
            w[20].wyxz = aw;
            r[211] = ar.wyxw;
            r[212] = ar.wyyx;
            r[213] = ar.wyyy;
            r[214] = ar.wyyz;
            r[215] = ar.wyyw;
            r[216] = ar.wyzx;
            w[21].wyzx = aw;
            r[217] = ar.wyzy;
            r[218] = ar.wyzz;
            r[219] = ar.wyzw;
            r[220] = ar.wywx;
            r[221] = ar.wywy;
            r[222] = ar.wywz;
            r[223] = ar.wyww;
            r[224] = ar.wzxx;
            r[225] = ar.wzxy;
            w[22].wzxy = aw;
            r[226] = ar.wzxz;
            r[227] = ar.wzxw;
            r[228] = ar.wzyx;
            w[23].wzyx = aw;
            r[229] = ar.wzyy;
            r[230] = ar.wzyz;
            r[231] = ar.wzyw;
            r[232] = ar.wzzx;
            r[233] = ar.wzzy;
            r[234] = ar.wzzz;
            r[235] = ar.wzzw;
            r[236] = ar.wzwx;
            r[237] = ar.wzwy;
            r[238] = ar.wzwz;
            r[239] = ar.wzww;
            r[240] = ar.wwxx;
            r[241] = ar.wwxy;
            r[242] = ar.wwxz;
            r[243] = ar.wwxw;
            r[244] = ar.wwyx;
            r[245] = ar.wwyy;
            r[246] = ar.wwyz;
            r[247] = ar.wwyw;
            r[248] = ar.wwzx;
            r[249] = ar.wwzy;
            r[250] = ar.wwzz;
            r[251] = ar.wwzw;
            r[252] = ar.wwwx;
            r[253] = ar.wwwy;
            r[254] = ar.wwwz;
            r[255] = ar.wwww;
        }

        [Test]
        public void TestComponentAccessors4()
        {
            int nr = 256;
            int nw = 24;
            short4[] r = new short4[nr];
            short4[] w = new short4[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<short4[],short4[]>)test_components4,
                r, w
            );
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[0].s2);
            Assert.AreEqual((short)1, r[0].s3);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)1, r[1].s1);
            Assert.AreEqual((short)1, r[1].s2);
            Assert.AreEqual((short)2, r[1].s3);
            Assert.AreEqual((short)1, r[2].s0);
            Assert.AreEqual((short)1, r[2].s1);
            Assert.AreEqual((short)1, r[2].s2);
            Assert.AreEqual((short)3, r[2].s3);
            Assert.AreEqual((short)1, r[3].s0);
            Assert.AreEqual((short)1, r[3].s1);
            Assert.AreEqual((short)1, r[3].s2);
            Assert.AreEqual((short)4, r[3].s3);
            Assert.AreEqual((short)1, r[4].s0);
            Assert.AreEqual((short)1, r[4].s1);
            Assert.AreEqual((short)2, r[4].s2);
            Assert.AreEqual((short)1, r[4].s3);
            Assert.AreEqual((short)1, r[5].s0);
            Assert.AreEqual((short)1, r[5].s1);
            Assert.AreEqual((short)2, r[5].s2);
            Assert.AreEqual((short)2, r[5].s3);
            Assert.AreEqual((short)1, r[6].s0);
            Assert.AreEqual((short)1, r[6].s1);
            Assert.AreEqual((short)2, r[6].s2);
            Assert.AreEqual((short)3, r[6].s3);
            Assert.AreEqual((short)1, r[7].s0);
            Assert.AreEqual((short)1, r[7].s1);
            Assert.AreEqual((short)2, r[7].s2);
            Assert.AreEqual((short)4, r[7].s3);
            Assert.AreEqual((short)1, r[8].s0);
            Assert.AreEqual((short)1, r[8].s1);
            Assert.AreEqual((short)3, r[8].s2);
            Assert.AreEqual((short)1, r[8].s3);
            Assert.AreEqual((short)1, r[9].s0);
            Assert.AreEqual((short)1, r[9].s1);
            Assert.AreEqual((short)3, r[9].s2);
            Assert.AreEqual((short)2, r[9].s3);
            Assert.AreEqual((short)1, r[10].s0);
            Assert.AreEqual((short)1, r[10].s1);
            Assert.AreEqual((short)3, r[10].s2);
            Assert.AreEqual((short)3, r[10].s3);
            Assert.AreEqual((short)1, r[11].s0);
            Assert.AreEqual((short)1, r[11].s1);
            Assert.AreEqual((short)3, r[11].s2);
            Assert.AreEqual((short)4, r[11].s3);
            Assert.AreEqual((short)1, r[12].s0);
            Assert.AreEqual((short)1, r[12].s1);
            Assert.AreEqual((short)4, r[12].s2);
            Assert.AreEqual((short)1, r[12].s3);
            Assert.AreEqual((short)1, r[13].s0);
            Assert.AreEqual((short)1, r[13].s1);
            Assert.AreEqual((short)4, r[13].s2);
            Assert.AreEqual((short)2, r[13].s3);
            Assert.AreEqual((short)1, r[14].s0);
            Assert.AreEqual((short)1, r[14].s1);
            Assert.AreEqual((short)4, r[14].s2);
            Assert.AreEqual((short)3, r[14].s3);
            Assert.AreEqual((short)1, r[15].s0);
            Assert.AreEqual((short)1, r[15].s1);
            Assert.AreEqual((short)4, r[15].s2);
            Assert.AreEqual((short)4, r[15].s3);
            Assert.AreEqual((short)1, r[16].s0);
            Assert.AreEqual((short)2, r[16].s1);
            Assert.AreEqual((short)1, r[16].s2);
            Assert.AreEqual((short)1, r[16].s3);
            Assert.AreEqual((short)1, r[17].s0);
            Assert.AreEqual((short)2, r[17].s1);
            Assert.AreEqual((short)1, r[17].s2);
            Assert.AreEqual((short)2, r[17].s3);
            Assert.AreEqual((short)1, r[18].s0);
            Assert.AreEqual((short)2, r[18].s1);
            Assert.AreEqual((short)1, r[18].s2);
            Assert.AreEqual((short)3, r[18].s3);
            Assert.AreEqual((short)1, r[19].s0);
            Assert.AreEqual((short)2, r[19].s1);
            Assert.AreEqual((short)1, r[19].s2);
            Assert.AreEqual((short)4, r[19].s3);
            Assert.AreEqual((short)1, r[20].s0);
            Assert.AreEqual((short)2, r[20].s1);
            Assert.AreEqual((short)2, r[20].s2);
            Assert.AreEqual((short)1, r[20].s3);
            Assert.AreEqual((short)1, r[21].s0);
            Assert.AreEqual((short)2, r[21].s1);
            Assert.AreEqual((short)2, r[21].s2);
            Assert.AreEqual((short)2, r[21].s3);
            Assert.AreEqual((short)1, r[22].s0);
            Assert.AreEqual((short)2, r[22].s1);
            Assert.AreEqual((short)2, r[22].s2);
            Assert.AreEqual((short)3, r[22].s3);
            Assert.AreEqual((short)1, r[23].s0);
            Assert.AreEqual((short)2, r[23].s1);
            Assert.AreEqual((short)2, r[23].s2);
            Assert.AreEqual((short)4, r[23].s3);
            Assert.AreEqual((short)1, r[24].s0);
            Assert.AreEqual((short)2, r[24].s1);
            Assert.AreEqual((short)3, r[24].s2);
            Assert.AreEqual((short)1, r[24].s3);
            Assert.AreEqual((short)1, r[25].s0);
            Assert.AreEqual((short)2, r[25].s1);
            Assert.AreEqual((short)3, r[25].s2);
            Assert.AreEqual((short)2, r[25].s3);
            Assert.AreEqual((short)1, r[26].s0);
            Assert.AreEqual((short)2, r[26].s1);
            Assert.AreEqual((short)3, r[26].s2);
            Assert.AreEqual((short)3, r[26].s3);
            Assert.AreEqual((short)1, r[27].s0);
            Assert.AreEqual((short)2, r[27].s1);
            Assert.AreEqual((short)3, r[27].s2);
            Assert.AreEqual((short)4, r[27].s3);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)3, w[0].s2);
            Assert.AreEqual((short)4, w[0].s3);
            Assert.AreEqual((short)1, r[28].s0);
            Assert.AreEqual((short)2, r[28].s1);
            Assert.AreEqual((short)4, r[28].s2);
            Assert.AreEqual((short)1, r[28].s3);
            Assert.AreEqual((short)1, r[29].s0);
            Assert.AreEqual((short)2, r[29].s1);
            Assert.AreEqual((short)4, r[29].s2);
            Assert.AreEqual((short)2, r[29].s3);
            Assert.AreEqual((short)1, r[30].s0);
            Assert.AreEqual((short)2, r[30].s1);
            Assert.AreEqual((short)4, r[30].s2);
            Assert.AreEqual((short)3, r[30].s3);
            Assert.AreEqual((short)1, w[1].s0);
            Assert.AreEqual((short)2, w[1].s1);
            Assert.AreEqual((short)3, w[1].s3);
            Assert.AreEqual((short)4, w[1].s2);
            Assert.AreEqual((short)1, r[31].s0);
            Assert.AreEqual((short)2, r[31].s1);
            Assert.AreEqual((short)4, r[31].s2);
            Assert.AreEqual((short)4, r[31].s3);
            Assert.AreEqual((short)1, r[32].s0);
            Assert.AreEqual((short)3, r[32].s1);
            Assert.AreEqual((short)1, r[32].s2);
            Assert.AreEqual((short)1, r[32].s3);
            Assert.AreEqual((short)1, r[33].s0);
            Assert.AreEqual((short)3, r[33].s1);
            Assert.AreEqual((short)1, r[33].s2);
            Assert.AreEqual((short)2, r[33].s3);
            Assert.AreEqual((short)1, r[34].s0);
            Assert.AreEqual((short)3, r[34].s1);
            Assert.AreEqual((short)1, r[34].s2);
            Assert.AreEqual((short)3, r[34].s3);
            Assert.AreEqual((short)1, r[35].s0);
            Assert.AreEqual((short)3, r[35].s1);
            Assert.AreEqual((short)1, r[35].s2);
            Assert.AreEqual((short)4, r[35].s3);
            Assert.AreEqual((short)1, r[36].s0);
            Assert.AreEqual((short)3, r[36].s1);
            Assert.AreEqual((short)2, r[36].s2);
            Assert.AreEqual((short)1, r[36].s3);
            Assert.AreEqual((short)1, r[37].s0);
            Assert.AreEqual((short)3, r[37].s1);
            Assert.AreEqual((short)2, r[37].s2);
            Assert.AreEqual((short)2, r[37].s3);
            Assert.AreEqual((short)1, r[38].s0);
            Assert.AreEqual((short)3, r[38].s1);
            Assert.AreEqual((short)2, r[38].s2);
            Assert.AreEqual((short)3, r[38].s3);
            Assert.AreEqual((short)1, r[39].s0);
            Assert.AreEqual((short)3, r[39].s1);
            Assert.AreEqual((short)2, r[39].s2);
            Assert.AreEqual((short)4, r[39].s3);
            Assert.AreEqual((short)1, w[2].s0);
            Assert.AreEqual((short)2, w[2].s2);
            Assert.AreEqual((short)3, w[2].s1);
            Assert.AreEqual((short)4, w[2].s3);
            Assert.AreEqual((short)1, r[40].s0);
            Assert.AreEqual((short)3, r[40].s1);
            Assert.AreEqual((short)3, r[40].s2);
            Assert.AreEqual((short)1, r[40].s3);
            Assert.AreEqual((short)1, r[41].s0);
            Assert.AreEqual((short)3, r[41].s1);
            Assert.AreEqual((short)3, r[41].s2);
            Assert.AreEqual((short)2, r[41].s3);
            Assert.AreEqual((short)1, r[42].s0);
            Assert.AreEqual((short)3, r[42].s1);
            Assert.AreEqual((short)3, r[42].s2);
            Assert.AreEqual((short)3, r[42].s3);
            Assert.AreEqual((short)1, r[43].s0);
            Assert.AreEqual((short)3, r[43].s1);
            Assert.AreEqual((short)3, r[43].s2);
            Assert.AreEqual((short)4, r[43].s3);
            Assert.AreEqual((short)1, r[44].s0);
            Assert.AreEqual((short)3, r[44].s1);
            Assert.AreEqual((short)4, r[44].s2);
            Assert.AreEqual((short)1, r[44].s3);
            Assert.AreEqual((short)1, r[45].s0);
            Assert.AreEqual((short)3, r[45].s1);
            Assert.AreEqual((short)4, r[45].s2);
            Assert.AreEqual((short)2, r[45].s3);
            Assert.AreEqual((short)1, w[3].s0);
            Assert.AreEqual((short)2, w[3].s2);
            Assert.AreEqual((short)3, w[3].s3);
            Assert.AreEqual((short)4, w[3].s1);
            Assert.AreEqual((short)1, r[46].s0);
            Assert.AreEqual((short)3, r[46].s1);
            Assert.AreEqual((short)4, r[46].s2);
            Assert.AreEqual((short)3, r[46].s3);
            Assert.AreEqual((short)1, r[47].s0);
            Assert.AreEqual((short)3, r[47].s1);
            Assert.AreEqual((short)4, r[47].s2);
            Assert.AreEqual((short)4, r[47].s3);
            Assert.AreEqual((short)1, r[48].s0);
            Assert.AreEqual((short)4, r[48].s1);
            Assert.AreEqual((short)1, r[48].s2);
            Assert.AreEqual((short)1, r[48].s3);
            Assert.AreEqual((short)1, r[49].s0);
            Assert.AreEqual((short)4, r[49].s1);
            Assert.AreEqual((short)1, r[49].s2);
            Assert.AreEqual((short)2, r[49].s3);
            Assert.AreEqual((short)1, r[50].s0);
            Assert.AreEqual((short)4, r[50].s1);
            Assert.AreEqual((short)1, r[50].s2);
            Assert.AreEqual((short)3, r[50].s3);
            Assert.AreEqual((short)1, r[51].s0);
            Assert.AreEqual((short)4, r[51].s1);
            Assert.AreEqual((short)1, r[51].s2);
            Assert.AreEqual((short)4, r[51].s3);
            Assert.AreEqual((short)1, r[52].s0);
            Assert.AreEqual((short)4, r[52].s1);
            Assert.AreEqual((short)2, r[52].s2);
            Assert.AreEqual((short)1, r[52].s3);
            Assert.AreEqual((short)1, r[53].s0);
            Assert.AreEqual((short)4, r[53].s1);
            Assert.AreEqual((short)2, r[53].s2);
            Assert.AreEqual((short)2, r[53].s3);
            Assert.AreEqual((short)1, r[54].s0);
            Assert.AreEqual((short)4, r[54].s1);
            Assert.AreEqual((short)2, r[54].s2);
            Assert.AreEqual((short)3, r[54].s3);
            Assert.AreEqual((short)1, w[4].s0);
            Assert.AreEqual((short)2, w[4].s3);
            Assert.AreEqual((short)3, w[4].s1);
            Assert.AreEqual((short)4, w[4].s2);
            Assert.AreEqual((short)1, r[55].s0);
            Assert.AreEqual((short)4, r[55].s1);
            Assert.AreEqual((short)2, r[55].s2);
            Assert.AreEqual((short)4, r[55].s3);
            Assert.AreEqual((short)1, r[56].s0);
            Assert.AreEqual((short)4, r[56].s1);
            Assert.AreEqual((short)3, r[56].s2);
            Assert.AreEqual((short)1, r[56].s3);
            Assert.AreEqual((short)1, r[57].s0);
            Assert.AreEqual((short)4, r[57].s1);
            Assert.AreEqual((short)3, r[57].s2);
            Assert.AreEqual((short)2, r[57].s3);
            Assert.AreEqual((short)1, w[5].s0);
            Assert.AreEqual((short)2, w[5].s3);
            Assert.AreEqual((short)3, w[5].s2);
            Assert.AreEqual((short)4, w[5].s1);
            Assert.AreEqual((short)1, r[58].s0);
            Assert.AreEqual((short)4, r[58].s1);
            Assert.AreEqual((short)3, r[58].s2);
            Assert.AreEqual((short)3, r[58].s3);
            Assert.AreEqual((short)1, r[59].s0);
            Assert.AreEqual((short)4, r[59].s1);
            Assert.AreEqual((short)3, r[59].s2);
            Assert.AreEqual((short)4, r[59].s3);
            Assert.AreEqual((short)1, r[60].s0);
            Assert.AreEqual((short)4, r[60].s1);
            Assert.AreEqual((short)4, r[60].s2);
            Assert.AreEqual((short)1, r[60].s3);
            Assert.AreEqual((short)1, r[61].s0);
            Assert.AreEqual((short)4, r[61].s1);
            Assert.AreEqual((short)4, r[61].s2);
            Assert.AreEqual((short)2, r[61].s3);
            Assert.AreEqual((short)1, r[62].s0);
            Assert.AreEqual((short)4, r[62].s1);
            Assert.AreEqual((short)4, r[62].s2);
            Assert.AreEqual((short)3, r[62].s3);
            Assert.AreEqual((short)1, r[63].s0);
            Assert.AreEqual((short)4, r[63].s1);
            Assert.AreEqual((short)4, r[63].s2);
            Assert.AreEqual((short)4, r[63].s3);
            Assert.AreEqual((short)2, r[64].s0);
            Assert.AreEqual((short)1, r[64].s1);
            Assert.AreEqual((short)1, r[64].s2);
            Assert.AreEqual((short)1, r[64].s3);
            Assert.AreEqual((short)2, r[65].s0);
            Assert.AreEqual((short)1, r[65].s1);
            Assert.AreEqual((short)1, r[65].s2);
            Assert.AreEqual((short)2, r[65].s3);
            Assert.AreEqual((short)2, r[66].s0);
            Assert.AreEqual((short)1, r[66].s1);
            Assert.AreEqual((short)1, r[66].s2);
            Assert.AreEqual((short)3, r[66].s3);
            Assert.AreEqual((short)2, r[67].s0);
            Assert.AreEqual((short)1, r[67].s1);
            Assert.AreEqual((short)1, r[67].s2);
            Assert.AreEqual((short)4, r[67].s3);
            Assert.AreEqual((short)2, r[68].s0);
            Assert.AreEqual((short)1, r[68].s1);
            Assert.AreEqual((short)2, r[68].s2);
            Assert.AreEqual((short)1, r[68].s3);
            Assert.AreEqual((short)2, r[69].s0);
            Assert.AreEqual((short)1, r[69].s1);
            Assert.AreEqual((short)2, r[69].s2);
            Assert.AreEqual((short)2, r[69].s3);
            Assert.AreEqual((short)2, r[70].s0);
            Assert.AreEqual((short)1, r[70].s1);
            Assert.AreEqual((short)2, r[70].s2);
            Assert.AreEqual((short)3, r[70].s3);
            Assert.AreEqual((short)2, r[71].s0);
            Assert.AreEqual((short)1, r[71].s1);
            Assert.AreEqual((short)2, r[71].s2);
            Assert.AreEqual((short)4, r[71].s3);
            Assert.AreEqual((short)2, r[72].s0);
            Assert.AreEqual((short)1, r[72].s1);
            Assert.AreEqual((short)3, r[72].s2);
            Assert.AreEqual((short)1, r[72].s3);
            Assert.AreEqual((short)2, r[73].s0);
            Assert.AreEqual((short)1, r[73].s1);
            Assert.AreEqual((short)3, r[73].s2);
            Assert.AreEqual((short)2, r[73].s3);
            Assert.AreEqual((short)2, r[74].s0);
            Assert.AreEqual((short)1, r[74].s1);
            Assert.AreEqual((short)3, r[74].s2);
            Assert.AreEqual((short)3, r[74].s3);
            Assert.AreEqual((short)2, r[75].s0);
            Assert.AreEqual((short)1, r[75].s1);
            Assert.AreEqual((short)3, r[75].s2);
            Assert.AreEqual((short)4, r[75].s3);
            Assert.AreEqual((short)1, w[6].s1);
            Assert.AreEqual((short)2, w[6].s0);
            Assert.AreEqual((short)3, w[6].s2);
            Assert.AreEqual((short)4, w[6].s3);
            Assert.AreEqual((short)2, r[76].s0);
            Assert.AreEqual((short)1, r[76].s1);
            Assert.AreEqual((short)4, r[76].s2);
            Assert.AreEqual((short)1, r[76].s3);
            Assert.AreEqual((short)2, r[77].s0);
            Assert.AreEqual((short)1, r[77].s1);
            Assert.AreEqual((short)4, r[77].s2);
            Assert.AreEqual((short)2, r[77].s3);
            Assert.AreEqual((short)2, r[78].s0);
            Assert.AreEqual((short)1, r[78].s1);
            Assert.AreEqual((short)4, r[78].s2);
            Assert.AreEqual((short)3, r[78].s3);
            Assert.AreEqual((short)1, w[7].s1);
            Assert.AreEqual((short)2, w[7].s0);
            Assert.AreEqual((short)3, w[7].s3);
            Assert.AreEqual((short)4, w[7].s2);
            Assert.AreEqual((short)2, r[79].s0);
            Assert.AreEqual((short)1, r[79].s1);
            Assert.AreEqual((short)4, r[79].s2);
            Assert.AreEqual((short)4, r[79].s3);
            Assert.AreEqual((short)2, r[80].s0);
            Assert.AreEqual((short)2, r[80].s1);
            Assert.AreEqual((short)1, r[80].s2);
            Assert.AreEqual((short)1, r[80].s3);
            Assert.AreEqual((short)2, r[81].s0);
            Assert.AreEqual((short)2, r[81].s1);
            Assert.AreEqual((short)1, r[81].s2);
            Assert.AreEqual((short)2, r[81].s3);
            Assert.AreEqual((short)2, r[82].s0);
            Assert.AreEqual((short)2, r[82].s1);
            Assert.AreEqual((short)1, r[82].s2);
            Assert.AreEqual((short)3, r[82].s3);
            Assert.AreEqual((short)2, r[83].s0);
            Assert.AreEqual((short)2, r[83].s1);
            Assert.AreEqual((short)1, r[83].s2);
            Assert.AreEqual((short)4, r[83].s3);
            Assert.AreEqual((short)2, r[84].s0);
            Assert.AreEqual((short)2, r[84].s1);
            Assert.AreEqual((short)2, r[84].s2);
            Assert.AreEqual((short)1, r[84].s3);
            Assert.AreEqual((short)2, r[85].s0);
            Assert.AreEqual((short)2, r[85].s1);
            Assert.AreEqual((short)2, r[85].s2);
            Assert.AreEqual((short)2, r[85].s3);
            Assert.AreEqual((short)2, r[86].s0);
            Assert.AreEqual((short)2, r[86].s1);
            Assert.AreEqual((short)2, r[86].s2);
            Assert.AreEqual((short)3, r[86].s3);
            Assert.AreEqual((short)2, r[87].s0);
            Assert.AreEqual((short)2, r[87].s1);
            Assert.AreEqual((short)2, r[87].s2);
            Assert.AreEqual((short)4, r[87].s3);
            Assert.AreEqual((short)2, r[88].s0);
            Assert.AreEqual((short)2, r[88].s1);
            Assert.AreEqual((short)3, r[88].s2);
            Assert.AreEqual((short)1, r[88].s3);
            Assert.AreEqual((short)2, r[89].s0);
            Assert.AreEqual((short)2, r[89].s1);
            Assert.AreEqual((short)3, r[89].s2);
            Assert.AreEqual((short)2, r[89].s3);
            Assert.AreEqual((short)2, r[90].s0);
            Assert.AreEqual((short)2, r[90].s1);
            Assert.AreEqual((short)3, r[90].s2);
            Assert.AreEqual((short)3, r[90].s3);
            Assert.AreEqual((short)2, r[91].s0);
            Assert.AreEqual((short)2, r[91].s1);
            Assert.AreEqual((short)3, r[91].s2);
            Assert.AreEqual((short)4, r[91].s3);
            Assert.AreEqual((short)2, r[92].s0);
            Assert.AreEqual((short)2, r[92].s1);
            Assert.AreEqual((short)4, r[92].s2);
            Assert.AreEqual((short)1, r[92].s3);
            Assert.AreEqual((short)2, r[93].s0);
            Assert.AreEqual((short)2, r[93].s1);
            Assert.AreEqual((short)4, r[93].s2);
            Assert.AreEqual((short)2, r[93].s3);
            Assert.AreEqual((short)2, r[94].s0);
            Assert.AreEqual((short)2, r[94].s1);
            Assert.AreEqual((short)4, r[94].s2);
            Assert.AreEqual((short)3, r[94].s3);
            Assert.AreEqual((short)2, r[95].s0);
            Assert.AreEqual((short)2, r[95].s1);
            Assert.AreEqual((short)4, r[95].s2);
            Assert.AreEqual((short)4, r[95].s3);
            Assert.AreEqual((short)2, r[96].s0);
            Assert.AreEqual((short)3, r[96].s1);
            Assert.AreEqual((short)1, r[96].s2);
            Assert.AreEqual((short)1, r[96].s3);
            Assert.AreEqual((short)2, r[97].s0);
            Assert.AreEqual((short)3, r[97].s1);
            Assert.AreEqual((short)1, r[97].s2);
            Assert.AreEqual((short)2, r[97].s3);
            Assert.AreEqual((short)2, r[98].s0);
            Assert.AreEqual((short)3, r[98].s1);
            Assert.AreEqual((short)1, r[98].s2);
            Assert.AreEqual((short)3, r[98].s3);
            Assert.AreEqual((short)2, r[99].s0);
            Assert.AreEqual((short)3, r[99].s1);
            Assert.AreEqual((short)1, r[99].s2);
            Assert.AreEqual((short)4, r[99].s3);
            Assert.AreEqual((short)1, w[8].s1);
            Assert.AreEqual((short)2, w[8].s2);
            Assert.AreEqual((short)3, w[8].s0);
            Assert.AreEqual((short)4, w[8].s3);
            Assert.AreEqual((short)2, r[100].s0);
            Assert.AreEqual((short)3, r[100].s1);
            Assert.AreEqual((short)2, r[100].s2);
            Assert.AreEqual((short)1, r[100].s3);
            Assert.AreEqual((short)2, r[101].s0);
            Assert.AreEqual((short)3, r[101].s1);
            Assert.AreEqual((short)2, r[101].s2);
            Assert.AreEqual((short)2, r[101].s3);
            Assert.AreEqual((short)2, r[102].s0);
            Assert.AreEqual((short)3, r[102].s1);
            Assert.AreEqual((short)2, r[102].s2);
            Assert.AreEqual((short)3, r[102].s3);
            Assert.AreEqual((short)2, r[103].s0);
            Assert.AreEqual((short)3, r[103].s1);
            Assert.AreEqual((short)2, r[103].s2);
            Assert.AreEqual((short)4, r[103].s3);
            Assert.AreEqual((short)2, r[104].s0);
            Assert.AreEqual((short)3, r[104].s1);
            Assert.AreEqual((short)3, r[104].s2);
            Assert.AreEqual((short)1, r[104].s3);
            Assert.AreEqual((short)2, r[105].s0);
            Assert.AreEqual((short)3, r[105].s1);
            Assert.AreEqual((short)3, r[105].s2);
            Assert.AreEqual((short)2, r[105].s3);
            Assert.AreEqual((short)2, r[106].s0);
            Assert.AreEqual((short)3, r[106].s1);
            Assert.AreEqual((short)3, r[106].s2);
            Assert.AreEqual((short)3, r[106].s3);
            Assert.AreEqual((short)2, r[107].s0);
            Assert.AreEqual((short)3, r[107].s1);
            Assert.AreEqual((short)3, r[107].s2);
            Assert.AreEqual((short)4, r[107].s3);
            Assert.AreEqual((short)2, r[108].s0);
            Assert.AreEqual((short)3, r[108].s1);
            Assert.AreEqual((short)4, r[108].s2);
            Assert.AreEqual((short)1, r[108].s3);
            Assert.AreEqual((short)1, w[9].s1);
            Assert.AreEqual((short)2, w[9].s2);
            Assert.AreEqual((short)3, w[9].s3);
            Assert.AreEqual((short)4, w[9].s0);
            Assert.AreEqual((short)2, r[109].s0);
            Assert.AreEqual((short)3, r[109].s1);
            Assert.AreEqual((short)4, r[109].s2);
            Assert.AreEqual((short)2, r[109].s3);
            Assert.AreEqual((short)2, r[110].s0);
            Assert.AreEqual((short)3, r[110].s1);
            Assert.AreEqual((short)4, r[110].s2);
            Assert.AreEqual((short)3, r[110].s3);
            Assert.AreEqual((short)2, r[111].s0);
            Assert.AreEqual((short)3, r[111].s1);
            Assert.AreEqual((short)4, r[111].s2);
            Assert.AreEqual((short)4, r[111].s3);
            Assert.AreEqual((short)2, r[112].s0);
            Assert.AreEqual((short)4, r[112].s1);
            Assert.AreEqual((short)1, r[112].s2);
            Assert.AreEqual((short)1, r[112].s3);
            Assert.AreEqual((short)2, r[113].s0);
            Assert.AreEqual((short)4, r[113].s1);
            Assert.AreEqual((short)1, r[113].s2);
            Assert.AreEqual((short)2, r[113].s3);
            Assert.AreEqual((short)2, r[114].s0);
            Assert.AreEqual((short)4, r[114].s1);
            Assert.AreEqual((short)1, r[114].s2);
            Assert.AreEqual((short)3, r[114].s3);
            Assert.AreEqual((short)1, w[10].s1);
            Assert.AreEqual((short)2, w[10].s3);
            Assert.AreEqual((short)3, w[10].s0);
            Assert.AreEqual((short)4, w[10].s2);
            Assert.AreEqual((short)2, r[115].s0);
            Assert.AreEqual((short)4, r[115].s1);
            Assert.AreEqual((short)1, r[115].s2);
            Assert.AreEqual((short)4, r[115].s3);
            Assert.AreEqual((short)2, r[116].s0);
            Assert.AreEqual((short)4, r[116].s1);
            Assert.AreEqual((short)2, r[116].s2);
            Assert.AreEqual((short)1, r[116].s3);
            Assert.AreEqual((short)2, r[117].s0);
            Assert.AreEqual((short)4, r[117].s1);
            Assert.AreEqual((short)2, r[117].s2);
            Assert.AreEqual((short)2, r[117].s3);
            Assert.AreEqual((short)2, r[118].s0);
            Assert.AreEqual((short)4, r[118].s1);
            Assert.AreEqual((short)2, r[118].s2);
            Assert.AreEqual((short)3, r[118].s3);
            Assert.AreEqual((short)2, r[119].s0);
            Assert.AreEqual((short)4, r[119].s1);
            Assert.AreEqual((short)2, r[119].s2);
            Assert.AreEqual((short)4, r[119].s3);
            Assert.AreEqual((short)2, r[120].s0);
            Assert.AreEqual((short)4, r[120].s1);
            Assert.AreEqual((short)3, r[120].s2);
            Assert.AreEqual((short)1, r[120].s3);
            Assert.AreEqual((short)1, w[11].s1);
            Assert.AreEqual((short)2, w[11].s3);
            Assert.AreEqual((short)3, w[11].s2);
            Assert.AreEqual((short)4, w[11].s0);
            Assert.AreEqual((short)2, r[121].s0);
            Assert.AreEqual((short)4, r[121].s1);
            Assert.AreEqual((short)3, r[121].s2);
            Assert.AreEqual((short)2, r[121].s3);
            Assert.AreEqual((short)2, r[122].s0);
            Assert.AreEqual((short)4, r[122].s1);
            Assert.AreEqual((short)3, r[122].s2);
            Assert.AreEqual((short)3, r[122].s3);
            Assert.AreEqual((short)2, r[123].s0);
            Assert.AreEqual((short)4, r[123].s1);
            Assert.AreEqual((short)3, r[123].s2);
            Assert.AreEqual((short)4, r[123].s3);
            Assert.AreEqual((short)2, r[124].s0);
            Assert.AreEqual((short)4, r[124].s1);
            Assert.AreEqual((short)4, r[124].s2);
            Assert.AreEqual((short)1, r[124].s3);
            Assert.AreEqual((short)2, r[125].s0);
            Assert.AreEqual((short)4, r[125].s1);
            Assert.AreEqual((short)4, r[125].s2);
            Assert.AreEqual((short)2, r[125].s3);
            Assert.AreEqual((short)2, r[126].s0);
            Assert.AreEqual((short)4, r[126].s1);
            Assert.AreEqual((short)4, r[126].s2);
            Assert.AreEqual((short)3, r[126].s3);
            Assert.AreEqual((short)2, r[127].s0);
            Assert.AreEqual((short)4, r[127].s1);
            Assert.AreEqual((short)4, r[127].s2);
            Assert.AreEqual((short)4, r[127].s3);
            Assert.AreEqual((short)3, r[128].s0);
            Assert.AreEqual((short)1, r[128].s1);
            Assert.AreEqual((short)1, r[128].s2);
            Assert.AreEqual((short)1, r[128].s3);
            Assert.AreEqual((short)3, r[129].s0);
            Assert.AreEqual((short)1, r[129].s1);
            Assert.AreEqual((short)1, r[129].s2);
            Assert.AreEqual((short)2, r[129].s3);
            Assert.AreEqual((short)3, r[130].s0);
            Assert.AreEqual((short)1, r[130].s1);
            Assert.AreEqual((short)1, r[130].s2);
            Assert.AreEqual((short)3, r[130].s3);
            Assert.AreEqual((short)3, r[131].s0);
            Assert.AreEqual((short)1, r[131].s1);
            Assert.AreEqual((short)1, r[131].s2);
            Assert.AreEqual((short)4, r[131].s3);
            Assert.AreEqual((short)3, r[132].s0);
            Assert.AreEqual((short)1, r[132].s1);
            Assert.AreEqual((short)2, r[132].s2);
            Assert.AreEqual((short)1, r[132].s3);
            Assert.AreEqual((short)3, r[133].s0);
            Assert.AreEqual((short)1, r[133].s1);
            Assert.AreEqual((short)2, r[133].s2);
            Assert.AreEqual((short)2, r[133].s3);
            Assert.AreEqual((short)3, r[134].s0);
            Assert.AreEqual((short)1, r[134].s1);
            Assert.AreEqual((short)2, r[134].s2);
            Assert.AreEqual((short)3, r[134].s3);
            Assert.AreEqual((short)3, r[135].s0);
            Assert.AreEqual((short)1, r[135].s1);
            Assert.AreEqual((short)2, r[135].s2);
            Assert.AreEqual((short)4, r[135].s3);
            Assert.AreEqual((short)1, w[12].s2);
            Assert.AreEqual((short)2, w[12].s0);
            Assert.AreEqual((short)3, w[12].s1);
            Assert.AreEqual((short)4, w[12].s3);
            Assert.AreEqual((short)3, r[136].s0);
            Assert.AreEqual((short)1, r[136].s1);
            Assert.AreEqual((short)3, r[136].s2);
            Assert.AreEqual((short)1, r[136].s3);
            Assert.AreEqual((short)3, r[137].s0);
            Assert.AreEqual((short)1, r[137].s1);
            Assert.AreEqual((short)3, r[137].s2);
            Assert.AreEqual((short)2, r[137].s3);
            Assert.AreEqual((short)3, r[138].s0);
            Assert.AreEqual((short)1, r[138].s1);
            Assert.AreEqual((short)3, r[138].s2);
            Assert.AreEqual((short)3, r[138].s3);
            Assert.AreEqual((short)3, r[139].s0);
            Assert.AreEqual((short)1, r[139].s1);
            Assert.AreEqual((short)3, r[139].s2);
            Assert.AreEqual((short)4, r[139].s3);
            Assert.AreEqual((short)3, r[140].s0);
            Assert.AreEqual((short)1, r[140].s1);
            Assert.AreEqual((short)4, r[140].s2);
            Assert.AreEqual((short)1, r[140].s3);
            Assert.AreEqual((short)3, r[141].s0);
            Assert.AreEqual((short)1, r[141].s1);
            Assert.AreEqual((short)4, r[141].s2);
            Assert.AreEqual((short)2, r[141].s3);
            Assert.AreEqual((short)1, w[13].s2);
            Assert.AreEqual((short)2, w[13].s0);
            Assert.AreEqual((short)3, w[13].s3);
            Assert.AreEqual((short)4, w[13].s1);
            Assert.AreEqual((short)3, r[142].s0);
            Assert.AreEqual((short)1, r[142].s1);
            Assert.AreEqual((short)4, r[142].s2);
            Assert.AreEqual((short)3, r[142].s3);
            Assert.AreEqual((short)3, r[143].s0);
            Assert.AreEqual((short)1, r[143].s1);
            Assert.AreEqual((short)4, r[143].s2);
            Assert.AreEqual((short)4, r[143].s3);
            Assert.AreEqual((short)3, r[144].s0);
            Assert.AreEqual((short)2, r[144].s1);
            Assert.AreEqual((short)1, r[144].s2);
            Assert.AreEqual((short)1, r[144].s3);
            Assert.AreEqual((short)3, r[145].s0);
            Assert.AreEqual((short)2, r[145].s1);
            Assert.AreEqual((short)1, r[145].s2);
            Assert.AreEqual((short)2, r[145].s3);
            Assert.AreEqual((short)3, r[146].s0);
            Assert.AreEqual((short)2, r[146].s1);
            Assert.AreEqual((short)1, r[146].s2);
            Assert.AreEqual((short)3, r[146].s3);
            Assert.AreEqual((short)3, r[147].s0);
            Assert.AreEqual((short)2, r[147].s1);
            Assert.AreEqual((short)1, r[147].s2);
            Assert.AreEqual((short)4, r[147].s3);
            Assert.AreEqual((short)1, w[14].s2);
            Assert.AreEqual((short)2, w[14].s1);
            Assert.AreEqual((short)3, w[14].s0);
            Assert.AreEqual((short)4, w[14].s3);
            Assert.AreEqual((short)3, r[148].s0);
            Assert.AreEqual((short)2, r[148].s1);
            Assert.AreEqual((short)2, r[148].s2);
            Assert.AreEqual((short)1, r[148].s3);
            Assert.AreEqual((short)3, r[149].s0);
            Assert.AreEqual((short)2, r[149].s1);
            Assert.AreEqual((short)2, r[149].s2);
            Assert.AreEqual((short)2, r[149].s3);
            Assert.AreEqual((short)3, r[150].s0);
            Assert.AreEqual((short)2, r[150].s1);
            Assert.AreEqual((short)2, r[150].s2);
            Assert.AreEqual((short)3, r[150].s3);
            Assert.AreEqual((short)3, r[151].s0);
            Assert.AreEqual((short)2, r[151].s1);
            Assert.AreEqual((short)2, r[151].s2);
            Assert.AreEqual((short)4, r[151].s3);
            Assert.AreEqual((short)3, r[152].s0);
            Assert.AreEqual((short)2, r[152].s1);
            Assert.AreEqual((short)3, r[152].s2);
            Assert.AreEqual((short)1, r[152].s3);
            Assert.AreEqual((short)3, r[153].s0);
            Assert.AreEqual((short)2, r[153].s1);
            Assert.AreEqual((short)3, r[153].s2);
            Assert.AreEqual((short)2, r[153].s3);
            Assert.AreEqual((short)3, r[154].s0);
            Assert.AreEqual((short)2, r[154].s1);
            Assert.AreEqual((short)3, r[154].s2);
            Assert.AreEqual((short)3, r[154].s3);
            Assert.AreEqual((short)3, r[155].s0);
            Assert.AreEqual((short)2, r[155].s1);
            Assert.AreEqual((short)3, r[155].s2);
            Assert.AreEqual((short)4, r[155].s3);
            Assert.AreEqual((short)3, r[156].s0);
            Assert.AreEqual((short)2, r[156].s1);
            Assert.AreEqual((short)4, r[156].s2);
            Assert.AreEqual((short)1, r[156].s3);
            Assert.AreEqual((short)1, w[15].s2);
            Assert.AreEqual((short)2, w[15].s1);
            Assert.AreEqual((short)3, w[15].s3);
            Assert.AreEqual((short)4, w[15].s0);
            Assert.AreEqual((short)3, r[157].s0);
            Assert.AreEqual((short)2, r[157].s1);
            Assert.AreEqual((short)4, r[157].s2);
            Assert.AreEqual((short)2, r[157].s3);
            Assert.AreEqual((short)3, r[158].s0);
            Assert.AreEqual((short)2, r[158].s1);
            Assert.AreEqual((short)4, r[158].s2);
            Assert.AreEqual((short)3, r[158].s3);
            Assert.AreEqual((short)3, r[159].s0);
            Assert.AreEqual((short)2, r[159].s1);
            Assert.AreEqual((short)4, r[159].s2);
            Assert.AreEqual((short)4, r[159].s3);
            Assert.AreEqual((short)3, r[160].s0);
            Assert.AreEqual((short)3, r[160].s1);
            Assert.AreEqual((short)1, r[160].s2);
            Assert.AreEqual((short)1, r[160].s3);
            Assert.AreEqual((short)3, r[161].s0);
            Assert.AreEqual((short)3, r[161].s1);
            Assert.AreEqual((short)1, r[161].s2);
            Assert.AreEqual((short)2, r[161].s3);
            Assert.AreEqual((short)3, r[162].s0);
            Assert.AreEqual((short)3, r[162].s1);
            Assert.AreEqual((short)1, r[162].s2);
            Assert.AreEqual((short)3, r[162].s3);
            Assert.AreEqual((short)3, r[163].s0);
            Assert.AreEqual((short)3, r[163].s1);
            Assert.AreEqual((short)1, r[163].s2);
            Assert.AreEqual((short)4, r[163].s3);
            Assert.AreEqual((short)3, r[164].s0);
            Assert.AreEqual((short)3, r[164].s1);
            Assert.AreEqual((short)2, r[164].s2);
            Assert.AreEqual((short)1, r[164].s3);
            Assert.AreEqual((short)3, r[165].s0);
            Assert.AreEqual((short)3, r[165].s1);
            Assert.AreEqual((short)2, r[165].s2);
            Assert.AreEqual((short)2, r[165].s3);
            Assert.AreEqual((short)3, r[166].s0);
            Assert.AreEqual((short)3, r[166].s1);
            Assert.AreEqual((short)2, r[166].s2);
            Assert.AreEqual((short)3, r[166].s3);
            Assert.AreEqual((short)3, r[167].s0);
            Assert.AreEqual((short)3, r[167].s1);
            Assert.AreEqual((short)2, r[167].s2);
            Assert.AreEqual((short)4, r[167].s3);
            Assert.AreEqual((short)3, r[168].s0);
            Assert.AreEqual((short)3, r[168].s1);
            Assert.AreEqual((short)3, r[168].s2);
            Assert.AreEqual((short)1, r[168].s3);
            Assert.AreEqual((short)3, r[169].s0);
            Assert.AreEqual((short)3, r[169].s1);
            Assert.AreEqual((short)3, r[169].s2);
            Assert.AreEqual((short)2, r[169].s3);
            Assert.AreEqual((short)3, r[170].s0);
            Assert.AreEqual((short)3, r[170].s1);
            Assert.AreEqual((short)3, r[170].s2);
            Assert.AreEqual((short)3, r[170].s3);
            Assert.AreEqual((short)3, r[171].s0);
            Assert.AreEqual((short)3, r[171].s1);
            Assert.AreEqual((short)3, r[171].s2);
            Assert.AreEqual((short)4, r[171].s3);
            Assert.AreEqual((short)3, r[172].s0);
            Assert.AreEqual((short)3, r[172].s1);
            Assert.AreEqual((short)4, r[172].s2);
            Assert.AreEqual((short)1, r[172].s3);
            Assert.AreEqual((short)3, r[173].s0);
            Assert.AreEqual((short)3, r[173].s1);
            Assert.AreEqual((short)4, r[173].s2);
            Assert.AreEqual((short)2, r[173].s3);
            Assert.AreEqual((short)3, r[174].s0);
            Assert.AreEqual((short)3, r[174].s1);
            Assert.AreEqual((short)4, r[174].s2);
            Assert.AreEqual((short)3, r[174].s3);
            Assert.AreEqual((short)3, r[175].s0);
            Assert.AreEqual((short)3, r[175].s1);
            Assert.AreEqual((short)4, r[175].s2);
            Assert.AreEqual((short)4, r[175].s3);
            Assert.AreEqual((short)3, r[176].s0);
            Assert.AreEqual((short)4, r[176].s1);
            Assert.AreEqual((short)1, r[176].s2);
            Assert.AreEqual((short)1, r[176].s3);
            Assert.AreEqual((short)3, r[177].s0);
            Assert.AreEqual((short)4, r[177].s1);
            Assert.AreEqual((short)1, r[177].s2);
            Assert.AreEqual((short)2, r[177].s3);
            Assert.AreEqual((short)1, w[16].s2);
            Assert.AreEqual((short)2, w[16].s3);
            Assert.AreEqual((short)3, w[16].s0);
            Assert.AreEqual((short)4, w[16].s1);
            Assert.AreEqual((short)3, r[178].s0);
            Assert.AreEqual((short)4, r[178].s1);
            Assert.AreEqual((short)1, r[178].s2);
            Assert.AreEqual((short)3, r[178].s3);
            Assert.AreEqual((short)3, r[179].s0);
            Assert.AreEqual((short)4, r[179].s1);
            Assert.AreEqual((short)1, r[179].s2);
            Assert.AreEqual((short)4, r[179].s3);
            Assert.AreEqual((short)3, r[180].s0);
            Assert.AreEqual((short)4, r[180].s1);
            Assert.AreEqual((short)2, r[180].s2);
            Assert.AreEqual((short)1, r[180].s3);
            Assert.AreEqual((short)1, w[17].s2);
            Assert.AreEqual((short)2, w[17].s3);
            Assert.AreEqual((short)3, w[17].s1);
            Assert.AreEqual((short)4, w[17].s0);
            Assert.AreEqual((short)3, r[181].s0);
            Assert.AreEqual((short)4, r[181].s1);
            Assert.AreEqual((short)2, r[181].s2);
            Assert.AreEqual((short)2, r[181].s3);
            Assert.AreEqual((short)3, r[182].s0);
            Assert.AreEqual((short)4, r[182].s1);
            Assert.AreEqual((short)2, r[182].s2);
            Assert.AreEqual((short)3, r[182].s3);
            Assert.AreEqual((short)3, r[183].s0);
            Assert.AreEqual((short)4, r[183].s1);
            Assert.AreEqual((short)2, r[183].s2);
            Assert.AreEqual((short)4, r[183].s3);
            Assert.AreEqual((short)3, r[184].s0);
            Assert.AreEqual((short)4, r[184].s1);
            Assert.AreEqual((short)3, r[184].s2);
            Assert.AreEqual((short)1, r[184].s3);
            Assert.AreEqual((short)3, r[185].s0);
            Assert.AreEqual((short)4, r[185].s1);
            Assert.AreEqual((short)3, r[185].s2);
            Assert.AreEqual((short)2, r[185].s3);
            Assert.AreEqual((short)3, r[186].s0);
            Assert.AreEqual((short)4, r[186].s1);
            Assert.AreEqual((short)3, r[186].s2);
            Assert.AreEqual((short)3, r[186].s3);
            Assert.AreEqual((short)3, r[187].s0);
            Assert.AreEqual((short)4, r[187].s1);
            Assert.AreEqual((short)3, r[187].s2);
            Assert.AreEqual((short)4, r[187].s3);
            Assert.AreEqual((short)3, r[188].s0);
            Assert.AreEqual((short)4, r[188].s1);
            Assert.AreEqual((short)4, r[188].s2);
            Assert.AreEqual((short)1, r[188].s3);
            Assert.AreEqual((short)3, r[189].s0);
            Assert.AreEqual((short)4, r[189].s1);
            Assert.AreEqual((short)4, r[189].s2);
            Assert.AreEqual((short)2, r[189].s3);
            Assert.AreEqual((short)3, r[190].s0);
            Assert.AreEqual((short)4, r[190].s1);
            Assert.AreEqual((short)4, r[190].s2);
            Assert.AreEqual((short)3, r[190].s3);
            Assert.AreEqual((short)3, r[191].s0);
            Assert.AreEqual((short)4, r[191].s1);
            Assert.AreEqual((short)4, r[191].s2);
            Assert.AreEqual((short)4, r[191].s3);
            Assert.AreEqual((short)4, r[192].s0);
            Assert.AreEqual((short)1, r[192].s1);
            Assert.AreEqual((short)1, r[192].s2);
            Assert.AreEqual((short)1, r[192].s3);
            Assert.AreEqual((short)4, r[193].s0);
            Assert.AreEqual((short)1, r[193].s1);
            Assert.AreEqual((short)1, r[193].s2);
            Assert.AreEqual((short)2, r[193].s3);
            Assert.AreEqual((short)4, r[194].s0);
            Assert.AreEqual((short)1, r[194].s1);
            Assert.AreEqual((short)1, r[194].s2);
            Assert.AreEqual((short)3, r[194].s3);
            Assert.AreEqual((short)4, r[195].s0);
            Assert.AreEqual((short)1, r[195].s1);
            Assert.AreEqual((short)1, r[195].s2);
            Assert.AreEqual((short)4, r[195].s3);
            Assert.AreEqual((short)4, r[196].s0);
            Assert.AreEqual((short)1, r[196].s1);
            Assert.AreEqual((short)2, r[196].s2);
            Assert.AreEqual((short)1, r[196].s3);
            Assert.AreEqual((short)4, r[197].s0);
            Assert.AreEqual((short)1, r[197].s1);
            Assert.AreEqual((short)2, r[197].s2);
            Assert.AreEqual((short)2, r[197].s3);
            Assert.AreEqual((short)4, r[198].s0);
            Assert.AreEqual((short)1, r[198].s1);
            Assert.AreEqual((short)2, r[198].s2);
            Assert.AreEqual((short)3, r[198].s3);
            Assert.AreEqual((short)1, w[18].s3);
            Assert.AreEqual((short)2, w[18].s0);
            Assert.AreEqual((short)3, w[18].s1);
            Assert.AreEqual((short)4, w[18].s2);
            Assert.AreEqual((short)4, r[199].s0);
            Assert.AreEqual((short)1, r[199].s1);
            Assert.AreEqual((short)2, r[199].s2);
            Assert.AreEqual((short)4, r[199].s3);
            Assert.AreEqual((short)4, r[200].s0);
            Assert.AreEqual((short)1, r[200].s1);
            Assert.AreEqual((short)3, r[200].s2);
            Assert.AreEqual((short)1, r[200].s3);
            Assert.AreEqual((short)4, r[201].s0);
            Assert.AreEqual((short)1, r[201].s1);
            Assert.AreEqual((short)3, r[201].s2);
            Assert.AreEqual((short)2, r[201].s3);
            Assert.AreEqual((short)1, w[19].s3);
            Assert.AreEqual((short)2, w[19].s0);
            Assert.AreEqual((short)3, w[19].s2);
            Assert.AreEqual((short)4, w[19].s1);
            Assert.AreEqual((short)4, r[202].s0);
            Assert.AreEqual((short)1, r[202].s1);
            Assert.AreEqual((short)3, r[202].s2);
            Assert.AreEqual((short)3, r[202].s3);
            Assert.AreEqual((short)4, r[203].s0);
            Assert.AreEqual((short)1, r[203].s1);
            Assert.AreEqual((short)3, r[203].s2);
            Assert.AreEqual((short)4, r[203].s3);
            Assert.AreEqual((short)4, r[204].s0);
            Assert.AreEqual((short)1, r[204].s1);
            Assert.AreEqual((short)4, r[204].s2);
            Assert.AreEqual((short)1, r[204].s3);
            Assert.AreEqual((short)4, r[205].s0);
            Assert.AreEqual((short)1, r[205].s1);
            Assert.AreEqual((short)4, r[205].s2);
            Assert.AreEqual((short)2, r[205].s3);
            Assert.AreEqual((short)4, r[206].s0);
            Assert.AreEqual((short)1, r[206].s1);
            Assert.AreEqual((short)4, r[206].s2);
            Assert.AreEqual((short)3, r[206].s3);
            Assert.AreEqual((short)4, r[207].s0);
            Assert.AreEqual((short)1, r[207].s1);
            Assert.AreEqual((short)4, r[207].s2);
            Assert.AreEqual((short)4, r[207].s3);
            Assert.AreEqual((short)4, r[208].s0);
            Assert.AreEqual((short)2, r[208].s1);
            Assert.AreEqual((short)1, r[208].s2);
            Assert.AreEqual((short)1, r[208].s3);
            Assert.AreEqual((short)4, r[209].s0);
            Assert.AreEqual((short)2, r[209].s1);
            Assert.AreEqual((short)1, r[209].s2);
            Assert.AreEqual((short)2, r[209].s3);
            Assert.AreEqual((short)4, r[210].s0);
            Assert.AreEqual((short)2, r[210].s1);
            Assert.AreEqual((short)1, r[210].s2);
            Assert.AreEqual((short)3, r[210].s3);
            Assert.AreEqual((short)1, w[20].s3);
            Assert.AreEqual((short)2, w[20].s1);
            Assert.AreEqual((short)3, w[20].s0);
            Assert.AreEqual((short)4, w[20].s2);
            Assert.AreEqual((short)4, r[211].s0);
            Assert.AreEqual((short)2, r[211].s1);
            Assert.AreEqual((short)1, r[211].s2);
            Assert.AreEqual((short)4, r[211].s3);
            Assert.AreEqual((short)4, r[212].s0);
            Assert.AreEqual((short)2, r[212].s1);
            Assert.AreEqual((short)2, r[212].s2);
            Assert.AreEqual((short)1, r[212].s3);
            Assert.AreEqual((short)4, r[213].s0);
            Assert.AreEqual((short)2, r[213].s1);
            Assert.AreEqual((short)2, r[213].s2);
            Assert.AreEqual((short)2, r[213].s3);
            Assert.AreEqual((short)4, r[214].s0);
            Assert.AreEqual((short)2, r[214].s1);
            Assert.AreEqual((short)2, r[214].s2);
            Assert.AreEqual((short)3, r[214].s3);
            Assert.AreEqual((short)4, r[215].s0);
            Assert.AreEqual((short)2, r[215].s1);
            Assert.AreEqual((short)2, r[215].s2);
            Assert.AreEqual((short)4, r[215].s3);
            Assert.AreEqual((short)4, r[216].s0);
            Assert.AreEqual((short)2, r[216].s1);
            Assert.AreEqual((short)3, r[216].s2);
            Assert.AreEqual((short)1, r[216].s3);
            Assert.AreEqual((short)1, w[21].s3);
            Assert.AreEqual((short)2, w[21].s1);
            Assert.AreEqual((short)3, w[21].s2);
            Assert.AreEqual((short)4, w[21].s0);
            Assert.AreEqual((short)4, r[217].s0);
            Assert.AreEqual((short)2, r[217].s1);
            Assert.AreEqual((short)3, r[217].s2);
            Assert.AreEqual((short)2, r[217].s3);
            Assert.AreEqual((short)4, r[218].s0);
            Assert.AreEqual((short)2, r[218].s1);
            Assert.AreEqual((short)3, r[218].s2);
            Assert.AreEqual((short)3, r[218].s3);
            Assert.AreEqual((short)4, r[219].s0);
            Assert.AreEqual((short)2, r[219].s1);
            Assert.AreEqual((short)3, r[219].s2);
            Assert.AreEqual((short)4, r[219].s3);
            Assert.AreEqual((short)4, r[220].s0);
            Assert.AreEqual((short)2, r[220].s1);
            Assert.AreEqual((short)4, r[220].s2);
            Assert.AreEqual((short)1, r[220].s3);
            Assert.AreEqual((short)4, r[221].s0);
            Assert.AreEqual((short)2, r[221].s1);
            Assert.AreEqual((short)4, r[221].s2);
            Assert.AreEqual((short)2, r[221].s3);
            Assert.AreEqual((short)4, r[222].s0);
            Assert.AreEqual((short)2, r[222].s1);
            Assert.AreEqual((short)4, r[222].s2);
            Assert.AreEqual((short)3, r[222].s3);
            Assert.AreEqual((short)4, r[223].s0);
            Assert.AreEqual((short)2, r[223].s1);
            Assert.AreEqual((short)4, r[223].s2);
            Assert.AreEqual((short)4, r[223].s3);
            Assert.AreEqual((short)4, r[224].s0);
            Assert.AreEqual((short)3, r[224].s1);
            Assert.AreEqual((short)1, r[224].s2);
            Assert.AreEqual((short)1, r[224].s3);
            Assert.AreEqual((short)4, r[225].s0);
            Assert.AreEqual((short)3, r[225].s1);
            Assert.AreEqual((short)1, r[225].s2);
            Assert.AreEqual((short)2, r[225].s3);
            Assert.AreEqual((short)1, w[22].s3);
            Assert.AreEqual((short)2, w[22].s2);
            Assert.AreEqual((short)3, w[22].s0);
            Assert.AreEqual((short)4, w[22].s1);
            Assert.AreEqual((short)4, r[226].s0);
            Assert.AreEqual((short)3, r[226].s1);
            Assert.AreEqual((short)1, r[226].s2);
            Assert.AreEqual((short)3, r[226].s3);
            Assert.AreEqual((short)4, r[227].s0);
            Assert.AreEqual((short)3, r[227].s1);
            Assert.AreEqual((short)1, r[227].s2);
            Assert.AreEqual((short)4, r[227].s3);
            Assert.AreEqual((short)4, r[228].s0);
            Assert.AreEqual((short)3, r[228].s1);
            Assert.AreEqual((short)2, r[228].s2);
            Assert.AreEqual((short)1, r[228].s3);
            Assert.AreEqual((short)1, w[23].s3);
            Assert.AreEqual((short)2, w[23].s2);
            Assert.AreEqual((short)3, w[23].s1);
            Assert.AreEqual((short)4, w[23].s0);
            Assert.AreEqual((short)4, r[229].s0);
            Assert.AreEqual((short)3, r[229].s1);
            Assert.AreEqual((short)2, r[229].s2);
            Assert.AreEqual((short)2, r[229].s3);
            Assert.AreEqual((short)4, r[230].s0);
            Assert.AreEqual((short)3, r[230].s1);
            Assert.AreEqual((short)2, r[230].s2);
            Assert.AreEqual((short)3, r[230].s3);
            Assert.AreEqual((short)4, r[231].s0);
            Assert.AreEqual((short)3, r[231].s1);
            Assert.AreEqual((short)2, r[231].s2);
            Assert.AreEqual((short)4, r[231].s3);
            Assert.AreEqual((short)4, r[232].s0);
            Assert.AreEqual((short)3, r[232].s1);
            Assert.AreEqual((short)3, r[232].s2);
            Assert.AreEqual((short)1, r[232].s3);
            Assert.AreEqual((short)4, r[233].s0);
            Assert.AreEqual((short)3, r[233].s1);
            Assert.AreEqual((short)3, r[233].s2);
            Assert.AreEqual((short)2, r[233].s3);
            Assert.AreEqual((short)4, r[234].s0);
            Assert.AreEqual((short)3, r[234].s1);
            Assert.AreEqual((short)3, r[234].s2);
            Assert.AreEqual((short)3, r[234].s3);
            Assert.AreEqual((short)4, r[235].s0);
            Assert.AreEqual((short)3, r[235].s1);
            Assert.AreEqual((short)3, r[235].s2);
            Assert.AreEqual((short)4, r[235].s3);
            Assert.AreEqual((short)4, r[236].s0);
            Assert.AreEqual((short)3, r[236].s1);
            Assert.AreEqual((short)4, r[236].s2);
            Assert.AreEqual((short)1, r[236].s3);
            Assert.AreEqual((short)4, r[237].s0);
            Assert.AreEqual((short)3, r[237].s1);
            Assert.AreEqual((short)4, r[237].s2);
            Assert.AreEqual((short)2, r[237].s3);
            Assert.AreEqual((short)4, r[238].s0);
            Assert.AreEqual((short)3, r[238].s1);
            Assert.AreEqual((short)4, r[238].s2);
            Assert.AreEqual((short)3, r[238].s3);
            Assert.AreEqual((short)4, r[239].s0);
            Assert.AreEqual((short)3, r[239].s1);
            Assert.AreEqual((short)4, r[239].s2);
            Assert.AreEqual((short)4, r[239].s3);
            Assert.AreEqual((short)4, r[240].s0);
            Assert.AreEqual((short)4, r[240].s1);
            Assert.AreEqual((short)1, r[240].s2);
            Assert.AreEqual((short)1, r[240].s3);
            Assert.AreEqual((short)4, r[241].s0);
            Assert.AreEqual((short)4, r[241].s1);
            Assert.AreEqual((short)1, r[241].s2);
            Assert.AreEqual((short)2, r[241].s3);
            Assert.AreEqual((short)4, r[242].s0);
            Assert.AreEqual((short)4, r[242].s1);
            Assert.AreEqual((short)1, r[242].s2);
            Assert.AreEqual((short)3, r[242].s3);
            Assert.AreEqual((short)4, r[243].s0);
            Assert.AreEqual((short)4, r[243].s1);
            Assert.AreEqual((short)1, r[243].s2);
            Assert.AreEqual((short)4, r[243].s3);
            Assert.AreEqual((short)4, r[244].s0);
            Assert.AreEqual((short)4, r[244].s1);
            Assert.AreEqual((short)2, r[244].s2);
            Assert.AreEqual((short)1, r[244].s3);
            Assert.AreEqual((short)4, r[245].s0);
            Assert.AreEqual((short)4, r[245].s1);
            Assert.AreEqual((short)2, r[245].s2);
            Assert.AreEqual((short)2, r[245].s3);
            Assert.AreEqual((short)4, r[246].s0);
            Assert.AreEqual((short)4, r[246].s1);
            Assert.AreEqual((short)2, r[246].s2);
            Assert.AreEqual((short)3, r[246].s3);
            Assert.AreEqual((short)4, r[247].s0);
            Assert.AreEqual((short)4, r[247].s1);
            Assert.AreEqual((short)2, r[247].s2);
            Assert.AreEqual((short)4, r[247].s3);
            Assert.AreEqual((short)4, r[248].s0);
            Assert.AreEqual((short)4, r[248].s1);
            Assert.AreEqual((short)3, r[248].s2);
            Assert.AreEqual((short)1, r[248].s3);
            Assert.AreEqual((short)4, r[249].s0);
            Assert.AreEqual((short)4, r[249].s1);
            Assert.AreEqual((short)3, r[249].s2);
            Assert.AreEqual((short)2, r[249].s3);
            Assert.AreEqual((short)4, r[250].s0);
            Assert.AreEqual((short)4, r[250].s1);
            Assert.AreEqual((short)3, r[250].s2);
            Assert.AreEqual((short)3, r[250].s3);
            Assert.AreEqual((short)4, r[251].s0);
            Assert.AreEqual((short)4, r[251].s1);
            Assert.AreEqual((short)3, r[251].s2);
            Assert.AreEqual((short)4, r[251].s3);
            Assert.AreEqual((short)4, r[252].s0);
            Assert.AreEqual((short)4, r[252].s1);
            Assert.AreEqual((short)4, r[252].s2);
            Assert.AreEqual((short)1, r[252].s3);
            Assert.AreEqual((short)4, r[253].s0);
            Assert.AreEqual((short)4, r[253].s1);
            Assert.AreEqual((short)4, r[253].s2);
            Assert.AreEqual((short)2, r[253].s3);
            Assert.AreEqual((short)4, r[254].s0);
            Assert.AreEqual((short)4, r[254].s1);
            Assert.AreEqual((short)4, r[254].s2);
            Assert.AreEqual((short)3, r[254].s3);
            Assert.AreEqual((short)4, r[255].s0);
            Assert.AreEqual((short)4, r[255].s1);
            Assert.AreEqual((short)4, r[255].s2);
            Assert.AreEqual((short)4, r[255].s3);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestShort4", "test_components4");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<short4>;
                var mw = null as Mem<short4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components4");
                    mr = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<short4>());
                    mw = Mem<short4>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<short4>());
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
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[0].s2);
            Assert.AreEqual((short)1, r[0].s3);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)1, r[1].s1);
            Assert.AreEqual((short)1, r[1].s2);
            Assert.AreEqual((short)2, r[1].s3);
            Assert.AreEqual((short)1, r[2].s0);
            Assert.AreEqual((short)1, r[2].s1);
            Assert.AreEqual((short)1, r[2].s2);
            Assert.AreEqual((short)3, r[2].s3);
            Assert.AreEqual((short)1, r[3].s0);
            Assert.AreEqual((short)1, r[3].s1);
            Assert.AreEqual((short)1, r[3].s2);
            Assert.AreEqual((short)4, r[3].s3);
            Assert.AreEqual((short)1, r[4].s0);
            Assert.AreEqual((short)1, r[4].s1);
            Assert.AreEqual((short)2, r[4].s2);
            Assert.AreEqual((short)1, r[4].s3);
            Assert.AreEqual((short)1, r[5].s0);
            Assert.AreEqual((short)1, r[5].s1);
            Assert.AreEqual((short)2, r[5].s2);
            Assert.AreEqual((short)2, r[5].s3);
            Assert.AreEqual((short)1, r[6].s0);
            Assert.AreEqual((short)1, r[6].s1);
            Assert.AreEqual((short)2, r[6].s2);
            Assert.AreEqual((short)3, r[6].s3);
            Assert.AreEqual((short)1, r[7].s0);
            Assert.AreEqual((short)1, r[7].s1);
            Assert.AreEqual((short)2, r[7].s2);
            Assert.AreEqual((short)4, r[7].s3);
            Assert.AreEqual((short)1, r[8].s0);
            Assert.AreEqual((short)1, r[8].s1);
            Assert.AreEqual((short)3, r[8].s2);
            Assert.AreEqual((short)1, r[8].s3);
            Assert.AreEqual((short)1, r[9].s0);
            Assert.AreEqual((short)1, r[9].s1);
            Assert.AreEqual((short)3, r[9].s2);
            Assert.AreEqual((short)2, r[9].s3);
            Assert.AreEqual((short)1, r[10].s0);
            Assert.AreEqual((short)1, r[10].s1);
            Assert.AreEqual((short)3, r[10].s2);
            Assert.AreEqual((short)3, r[10].s3);
            Assert.AreEqual((short)1, r[11].s0);
            Assert.AreEqual((short)1, r[11].s1);
            Assert.AreEqual((short)3, r[11].s2);
            Assert.AreEqual((short)4, r[11].s3);
            Assert.AreEqual((short)1, r[12].s0);
            Assert.AreEqual((short)1, r[12].s1);
            Assert.AreEqual((short)4, r[12].s2);
            Assert.AreEqual((short)1, r[12].s3);
            Assert.AreEqual((short)1, r[13].s0);
            Assert.AreEqual((short)1, r[13].s1);
            Assert.AreEqual((short)4, r[13].s2);
            Assert.AreEqual((short)2, r[13].s3);
            Assert.AreEqual((short)1, r[14].s0);
            Assert.AreEqual((short)1, r[14].s1);
            Assert.AreEqual((short)4, r[14].s2);
            Assert.AreEqual((short)3, r[14].s3);
            Assert.AreEqual((short)1, r[15].s0);
            Assert.AreEqual((short)1, r[15].s1);
            Assert.AreEqual((short)4, r[15].s2);
            Assert.AreEqual((short)4, r[15].s3);
            Assert.AreEqual((short)1, r[16].s0);
            Assert.AreEqual((short)2, r[16].s1);
            Assert.AreEqual((short)1, r[16].s2);
            Assert.AreEqual((short)1, r[16].s3);
            Assert.AreEqual((short)1, r[17].s0);
            Assert.AreEqual((short)2, r[17].s1);
            Assert.AreEqual((short)1, r[17].s2);
            Assert.AreEqual((short)2, r[17].s3);
            Assert.AreEqual((short)1, r[18].s0);
            Assert.AreEqual((short)2, r[18].s1);
            Assert.AreEqual((short)1, r[18].s2);
            Assert.AreEqual((short)3, r[18].s3);
            Assert.AreEqual((short)1, r[19].s0);
            Assert.AreEqual((short)2, r[19].s1);
            Assert.AreEqual((short)1, r[19].s2);
            Assert.AreEqual((short)4, r[19].s3);
            Assert.AreEqual((short)1, r[20].s0);
            Assert.AreEqual((short)2, r[20].s1);
            Assert.AreEqual((short)2, r[20].s2);
            Assert.AreEqual((short)1, r[20].s3);
            Assert.AreEqual((short)1, r[21].s0);
            Assert.AreEqual((short)2, r[21].s1);
            Assert.AreEqual((short)2, r[21].s2);
            Assert.AreEqual((short)2, r[21].s3);
            Assert.AreEqual((short)1, r[22].s0);
            Assert.AreEqual((short)2, r[22].s1);
            Assert.AreEqual((short)2, r[22].s2);
            Assert.AreEqual((short)3, r[22].s3);
            Assert.AreEqual((short)1, r[23].s0);
            Assert.AreEqual((short)2, r[23].s1);
            Assert.AreEqual((short)2, r[23].s2);
            Assert.AreEqual((short)4, r[23].s3);
            Assert.AreEqual((short)1, r[24].s0);
            Assert.AreEqual((short)2, r[24].s1);
            Assert.AreEqual((short)3, r[24].s2);
            Assert.AreEqual((short)1, r[24].s3);
            Assert.AreEqual((short)1, r[25].s0);
            Assert.AreEqual((short)2, r[25].s1);
            Assert.AreEqual((short)3, r[25].s2);
            Assert.AreEqual((short)2, r[25].s3);
            Assert.AreEqual((short)1, r[26].s0);
            Assert.AreEqual((short)2, r[26].s1);
            Assert.AreEqual((short)3, r[26].s2);
            Assert.AreEqual((short)3, r[26].s3);
            Assert.AreEqual((short)1, r[27].s0);
            Assert.AreEqual((short)2, r[27].s1);
            Assert.AreEqual((short)3, r[27].s2);
            Assert.AreEqual((short)4, r[27].s3);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)3, w[0].s2);
            Assert.AreEqual((short)4, w[0].s3);
            Assert.AreEqual((short)1, r[28].s0);
            Assert.AreEqual((short)2, r[28].s1);
            Assert.AreEqual((short)4, r[28].s2);
            Assert.AreEqual((short)1, r[28].s3);
            Assert.AreEqual((short)1, r[29].s0);
            Assert.AreEqual((short)2, r[29].s1);
            Assert.AreEqual((short)4, r[29].s2);
            Assert.AreEqual((short)2, r[29].s3);
            Assert.AreEqual((short)1, r[30].s0);
            Assert.AreEqual((short)2, r[30].s1);
            Assert.AreEqual((short)4, r[30].s2);
            Assert.AreEqual((short)3, r[30].s3);
            Assert.AreEqual((short)1, w[1].s0);
            Assert.AreEqual((short)2, w[1].s1);
            Assert.AreEqual((short)3, w[1].s3);
            Assert.AreEqual((short)4, w[1].s2);
            Assert.AreEqual((short)1, r[31].s0);
            Assert.AreEqual((short)2, r[31].s1);
            Assert.AreEqual((short)4, r[31].s2);
            Assert.AreEqual((short)4, r[31].s3);
            Assert.AreEqual((short)1, r[32].s0);
            Assert.AreEqual((short)3, r[32].s1);
            Assert.AreEqual((short)1, r[32].s2);
            Assert.AreEqual((short)1, r[32].s3);
            Assert.AreEqual((short)1, r[33].s0);
            Assert.AreEqual((short)3, r[33].s1);
            Assert.AreEqual((short)1, r[33].s2);
            Assert.AreEqual((short)2, r[33].s3);
            Assert.AreEqual((short)1, r[34].s0);
            Assert.AreEqual((short)3, r[34].s1);
            Assert.AreEqual((short)1, r[34].s2);
            Assert.AreEqual((short)3, r[34].s3);
            Assert.AreEqual((short)1, r[35].s0);
            Assert.AreEqual((short)3, r[35].s1);
            Assert.AreEqual((short)1, r[35].s2);
            Assert.AreEqual((short)4, r[35].s3);
            Assert.AreEqual((short)1, r[36].s0);
            Assert.AreEqual((short)3, r[36].s1);
            Assert.AreEqual((short)2, r[36].s2);
            Assert.AreEqual((short)1, r[36].s3);
            Assert.AreEqual((short)1, r[37].s0);
            Assert.AreEqual((short)3, r[37].s1);
            Assert.AreEqual((short)2, r[37].s2);
            Assert.AreEqual((short)2, r[37].s3);
            Assert.AreEqual((short)1, r[38].s0);
            Assert.AreEqual((short)3, r[38].s1);
            Assert.AreEqual((short)2, r[38].s2);
            Assert.AreEqual((short)3, r[38].s3);
            Assert.AreEqual((short)1, r[39].s0);
            Assert.AreEqual((short)3, r[39].s1);
            Assert.AreEqual((short)2, r[39].s2);
            Assert.AreEqual((short)4, r[39].s3);
            Assert.AreEqual((short)1, w[2].s0);
            Assert.AreEqual((short)2, w[2].s2);
            Assert.AreEqual((short)3, w[2].s1);
            Assert.AreEqual((short)4, w[2].s3);
            Assert.AreEqual((short)1, r[40].s0);
            Assert.AreEqual((short)3, r[40].s1);
            Assert.AreEqual((short)3, r[40].s2);
            Assert.AreEqual((short)1, r[40].s3);
            Assert.AreEqual((short)1, r[41].s0);
            Assert.AreEqual((short)3, r[41].s1);
            Assert.AreEqual((short)3, r[41].s2);
            Assert.AreEqual((short)2, r[41].s3);
            Assert.AreEqual((short)1, r[42].s0);
            Assert.AreEqual((short)3, r[42].s1);
            Assert.AreEqual((short)3, r[42].s2);
            Assert.AreEqual((short)3, r[42].s3);
            Assert.AreEqual((short)1, r[43].s0);
            Assert.AreEqual((short)3, r[43].s1);
            Assert.AreEqual((short)3, r[43].s2);
            Assert.AreEqual((short)4, r[43].s3);
            Assert.AreEqual((short)1, r[44].s0);
            Assert.AreEqual((short)3, r[44].s1);
            Assert.AreEqual((short)4, r[44].s2);
            Assert.AreEqual((short)1, r[44].s3);
            Assert.AreEqual((short)1, r[45].s0);
            Assert.AreEqual((short)3, r[45].s1);
            Assert.AreEqual((short)4, r[45].s2);
            Assert.AreEqual((short)2, r[45].s3);
            Assert.AreEqual((short)1, w[3].s0);
            Assert.AreEqual((short)2, w[3].s2);
            Assert.AreEqual((short)3, w[3].s3);
            Assert.AreEqual((short)4, w[3].s1);
            Assert.AreEqual((short)1, r[46].s0);
            Assert.AreEqual((short)3, r[46].s1);
            Assert.AreEqual((short)4, r[46].s2);
            Assert.AreEqual((short)3, r[46].s3);
            Assert.AreEqual((short)1, r[47].s0);
            Assert.AreEqual((short)3, r[47].s1);
            Assert.AreEqual((short)4, r[47].s2);
            Assert.AreEqual((short)4, r[47].s3);
            Assert.AreEqual((short)1, r[48].s0);
            Assert.AreEqual((short)4, r[48].s1);
            Assert.AreEqual((short)1, r[48].s2);
            Assert.AreEqual((short)1, r[48].s3);
            Assert.AreEqual((short)1, r[49].s0);
            Assert.AreEqual((short)4, r[49].s1);
            Assert.AreEqual((short)1, r[49].s2);
            Assert.AreEqual((short)2, r[49].s3);
            Assert.AreEqual((short)1, r[50].s0);
            Assert.AreEqual((short)4, r[50].s1);
            Assert.AreEqual((short)1, r[50].s2);
            Assert.AreEqual((short)3, r[50].s3);
            Assert.AreEqual((short)1, r[51].s0);
            Assert.AreEqual((short)4, r[51].s1);
            Assert.AreEqual((short)1, r[51].s2);
            Assert.AreEqual((short)4, r[51].s3);
            Assert.AreEqual((short)1, r[52].s0);
            Assert.AreEqual((short)4, r[52].s1);
            Assert.AreEqual((short)2, r[52].s2);
            Assert.AreEqual((short)1, r[52].s3);
            Assert.AreEqual((short)1, r[53].s0);
            Assert.AreEqual((short)4, r[53].s1);
            Assert.AreEqual((short)2, r[53].s2);
            Assert.AreEqual((short)2, r[53].s3);
            Assert.AreEqual((short)1, r[54].s0);
            Assert.AreEqual((short)4, r[54].s1);
            Assert.AreEqual((short)2, r[54].s2);
            Assert.AreEqual((short)3, r[54].s3);
            Assert.AreEqual((short)1, w[4].s0);
            Assert.AreEqual((short)2, w[4].s3);
            Assert.AreEqual((short)3, w[4].s1);
            Assert.AreEqual((short)4, w[4].s2);
            Assert.AreEqual((short)1, r[55].s0);
            Assert.AreEqual((short)4, r[55].s1);
            Assert.AreEqual((short)2, r[55].s2);
            Assert.AreEqual((short)4, r[55].s3);
            Assert.AreEqual((short)1, r[56].s0);
            Assert.AreEqual((short)4, r[56].s1);
            Assert.AreEqual((short)3, r[56].s2);
            Assert.AreEqual((short)1, r[56].s3);
            Assert.AreEqual((short)1, r[57].s0);
            Assert.AreEqual((short)4, r[57].s1);
            Assert.AreEqual((short)3, r[57].s2);
            Assert.AreEqual((short)2, r[57].s3);
            Assert.AreEqual((short)1, w[5].s0);
            Assert.AreEqual((short)2, w[5].s3);
            Assert.AreEqual((short)3, w[5].s2);
            Assert.AreEqual((short)4, w[5].s1);
            Assert.AreEqual((short)1, r[58].s0);
            Assert.AreEqual((short)4, r[58].s1);
            Assert.AreEqual((short)3, r[58].s2);
            Assert.AreEqual((short)3, r[58].s3);
            Assert.AreEqual((short)1, r[59].s0);
            Assert.AreEqual((short)4, r[59].s1);
            Assert.AreEqual((short)3, r[59].s2);
            Assert.AreEqual((short)4, r[59].s3);
            Assert.AreEqual((short)1, r[60].s0);
            Assert.AreEqual((short)4, r[60].s1);
            Assert.AreEqual((short)4, r[60].s2);
            Assert.AreEqual((short)1, r[60].s3);
            Assert.AreEqual((short)1, r[61].s0);
            Assert.AreEqual((short)4, r[61].s1);
            Assert.AreEqual((short)4, r[61].s2);
            Assert.AreEqual((short)2, r[61].s3);
            Assert.AreEqual((short)1, r[62].s0);
            Assert.AreEqual((short)4, r[62].s1);
            Assert.AreEqual((short)4, r[62].s2);
            Assert.AreEqual((short)3, r[62].s3);
            Assert.AreEqual((short)1, r[63].s0);
            Assert.AreEqual((short)4, r[63].s1);
            Assert.AreEqual((short)4, r[63].s2);
            Assert.AreEqual((short)4, r[63].s3);
            Assert.AreEqual((short)2, r[64].s0);
            Assert.AreEqual((short)1, r[64].s1);
            Assert.AreEqual((short)1, r[64].s2);
            Assert.AreEqual((short)1, r[64].s3);
            Assert.AreEqual((short)2, r[65].s0);
            Assert.AreEqual((short)1, r[65].s1);
            Assert.AreEqual((short)1, r[65].s2);
            Assert.AreEqual((short)2, r[65].s3);
            Assert.AreEqual((short)2, r[66].s0);
            Assert.AreEqual((short)1, r[66].s1);
            Assert.AreEqual((short)1, r[66].s2);
            Assert.AreEqual((short)3, r[66].s3);
            Assert.AreEqual((short)2, r[67].s0);
            Assert.AreEqual((short)1, r[67].s1);
            Assert.AreEqual((short)1, r[67].s2);
            Assert.AreEqual((short)4, r[67].s3);
            Assert.AreEqual((short)2, r[68].s0);
            Assert.AreEqual((short)1, r[68].s1);
            Assert.AreEqual((short)2, r[68].s2);
            Assert.AreEqual((short)1, r[68].s3);
            Assert.AreEqual((short)2, r[69].s0);
            Assert.AreEqual((short)1, r[69].s1);
            Assert.AreEqual((short)2, r[69].s2);
            Assert.AreEqual((short)2, r[69].s3);
            Assert.AreEqual((short)2, r[70].s0);
            Assert.AreEqual((short)1, r[70].s1);
            Assert.AreEqual((short)2, r[70].s2);
            Assert.AreEqual((short)3, r[70].s3);
            Assert.AreEqual((short)2, r[71].s0);
            Assert.AreEqual((short)1, r[71].s1);
            Assert.AreEqual((short)2, r[71].s2);
            Assert.AreEqual((short)4, r[71].s3);
            Assert.AreEqual((short)2, r[72].s0);
            Assert.AreEqual((short)1, r[72].s1);
            Assert.AreEqual((short)3, r[72].s2);
            Assert.AreEqual((short)1, r[72].s3);
            Assert.AreEqual((short)2, r[73].s0);
            Assert.AreEqual((short)1, r[73].s1);
            Assert.AreEqual((short)3, r[73].s2);
            Assert.AreEqual((short)2, r[73].s3);
            Assert.AreEqual((short)2, r[74].s0);
            Assert.AreEqual((short)1, r[74].s1);
            Assert.AreEqual((short)3, r[74].s2);
            Assert.AreEqual((short)3, r[74].s3);
            Assert.AreEqual((short)2, r[75].s0);
            Assert.AreEqual((short)1, r[75].s1);
            Assert.AreEqual((short)3, r[75].s2);
            Assert.AreEqual((short)4, r[75].s3);
            Assert.AreEqual((short)1, w[6].s1);
            Assert.AreEqual((short)2, w[6].s0);
            Assert.AreEqual((short)3, w[6].s2);
            Assert.AreEqual((short)4, w[6].s3);
            Assert.AreEqual((short)2, r[76].s0);
            Assert.AreEqual((short)1, r[76].s1);
            Assert.AreEqual((short)4, r[76].s2);
            Assert.AreEqual((short)1, r[76].s3);
            Assert.AreEqual((short)2, r[77].s0);
            Assert.AreEqual((short)1, r[77].s1);
            Assert.AreEqual((short)4, r[77].s2);
            Assert.AreEqual((short)2, r[77].s3);
            Assert.AreEqual((short)2, r[78].s0);
            Assert.AreEqual((short)1, r[78].s1);
            Assert.AreEqual((short)4, r[78].s2);
            Assert.AreEqual((short)3, r[78].s3);
            Assert.AreEqual((short)1, w[7].s1);
            Assert.AreEqual((short)2, w[7].s0);
            Assert.AreEqual((short)3, w[7].s3);
            Assert.AreEqual((short)4, w[7].s2);
            Assert.AreEqual((short)2, r[79].s0);
            Assert.AreEqual((short)1, r[79].s1);
            Assert.AreEqual((short)4, r[79].s2);
            Assert.AreEqual((short)4, r[79].s3);
            Assert.AreEqual((short)2, r[80].s0);
            Assert.AreEqual((short)2, r[80].s1);
            Assert.AreEqual((short)1, r[80].s2);
            Assert.AreEqual((short)1, r[80].s3);
            Assert.AreEqual((short)2, r[81].s0);
            Assert.AreEqual((short)2, r[81].s1);
            Assert.AreEqual((short)1, r[81].s2);
            Assert.AreEqual((short)2, r[81].s3);
            Assert.AreEqual((short)2, r[82].s0);
            Assert.AreEqual((short)2, r[82].s1);
            Assert.AreEqual((short)1, r[82].s2);
            Assert.AreEqual((short)3, r[82].s3);
            Assert.AreEqual((short)2, r[83].s0);
            Assert.AreEqual((short)2, r[83].s1);
            Assert.AreEqual((short)1, r[83].s2);
            Assert.AreEqual((short)4, r[83].s3);
            Assert.AreEqual((short)2, r[84].s0);
            Assert.AreEqual((short)2, r[84].s1);
            Assert.AreEqual((short)2, r[84].s2);
            Assert.AreEqual((short)1, r[84].s3);
            Assert.AreEqual((short)2, r[85].s0);
            Assert.AreEqual((short)2, r[85].s1);
            Assert.AreEqual((short)2, r[85].s2);
            Assert.AreEqual((short)2, r[85].s3);
            Assert.AreEqual((short)2, r[86].s0);
            Assert.AreEqual((short)2, r[86].s1);
            Assert.AreEqual((short)2, r[86].s2);
            Assert.AreEqual((short)3, r[86].s3);
            Assert.AreEqual((short)2, r[87].s0);
            Assert.AreEqual((short)2, r[87].s1);
            Assert.AreEqual((short)2, r[87].s2);
            Assert.AreEqual((short)4, r[87].s3);
            Assert.AreEqual((short)2, r[88].s0);
            Assert.AreEqual((short)2, r[88].s1);
            Assert.AreEqual((short)3, r[88].s2);
            Assert.AreEqual((short)1, r[88].s3);
            Assert.AreEqual((short)2, r[89].s0);
            Assert.AreEqual((short)2, r[89].s1);
            Assert.AreEqual((short)3, r[89].s2);
            Assert.AreEqual((short)2, r[89].s3);
            Assert.AreEqual((short)2, r[90].s0);
            Assert.AreEqual((short)2, r[90].s1);
            Assert.AreEqual((short)3, r[90].s2);
            Assert.AreEqual((short)3, r[90].s3);
            Assert.AreEqual((short)2, r[91].s0);
            Assert.AreEqual((short)2, r[91].s1);
            Assert.AreEqual((short)3, r[91].s2);
            Assert.AreEqual((short)4, r[91].s3);
            Assert.AreEqual((short)2, r[92].s0);
            Assert.AreEqual((short)2, r[92].s1);
            Assert.AreEqual((short)4, r[92].s2);
            Assert.AreEqual((short)1, r[92].s3);
            Assert.AreEqual((short)2, r[93].s0);
            Assert.AreEqual((short)2, r[93].s1);
            Assert.AreEqual((short)4, r[93].s2);
            Assert.AreEqual((short)2, r[93].s3);
            Assert.AreEqual((short)2, r[94].s0);
            Assert.AreEqual((short)2, r[94].s1);
            Assert.AreEqual((short)4, r[94].s2);
            Assert.AreEqual((short)3, r[94].s3);
            Assert.AreEqual((short)2, r[95].s0);
            Assert.AreEqual((short)2, r[95].s1);
            Assert.AreEqual((short)4, r[95].s2);
            Assert.AreEqual((short)4, r[95].s3);
            Assert.AreEqual((short)2, r[96].s0);
            Assert.AreEqual((short)3, r[96].s1);
            Assert.AreEqual((short)1, r[96].s2);
            Assert.AreEqual((short)1, r[96].s3);
            Assert.AreEqual((short)2, r[97].s0);
            Assert.AreEqual((short)3, r[97].s1);
            Assert.AreEqual((short)1, r[97].s2);
            Assert.AreEqual((short)2, r[97].s3);
            Assert.AreEqual((short)2, r[98].s0);
            Assert.AreEqual((short)3, r[98].s1);
            Assert.AreEqual((short)1, r[98].s2);
            Assert.AreEqual((short)3, r[98].s3);
            Assert.AreEqual((short)2, r[99].s0);
            Assert.AreEqual((short)3, r[99].s1);
            Assert.AreEqual((short)1, r[99].s2);
            Assert.AreEqual((short)4, r[99].s3);
            Assert.AreEqual((short)1, w[8].s1);
            Assert.AreEqual((short)2, w[8].s2);
            Assert.AreEqual((short)3, w[8].s0);
            Assert.AreEqual((short)4, w[8].s3);
            Assert.AreEqual((short)2, r[100].s0);
            Assert.AreEqual((short)3, r[100].s1);
            Assert.AreEqual((short)2, r[100].s2);
            Assert.AreEqual((short)1, r[100].s3);
            Assert.AreEqual((short)2, r[101].s0);
            Assert.AreEqual((short)3, r[101].s1);
            Assert.AreEqual((short)2, r[101].s2);
            Assert.AreEqual((short)2, r[101].s3);
            Assert.AreEqual((short)2, r[102].s0);
            Assert.AreEqual((short)3, r[102].s1);
            Assert.AreEqual((short)2, r[102].s2);
            Assert.AreEqual((short)3, r[102].s3);
            Assert.AreEqual((short)2, r[103].s0);
            Assert.AreEqual((short)3, r[103].s1);
            Assert.AreEqual((short)2, r[103].s2);
            Assert.AreEqual((short)4, r[103].s3);
            Assert.AreEqual((short)2, r[104].s0);
            Assert.AreEqual((short)3, r[104].s1);
            Assert.AreEqual((short)3, r[104].s2);
            Assert.AreEqual((short)1, r[104].s3);
            Assert.AreEqual((short)2, r[105].s0);
            Assert.AreEqual((short)3, r[105].s1);
            Assert.AreEqual((short)3, r[105].s2);
            Assert.AreEqual((short)2, r[105].s3);
            Assert.AreEqual((short)2, r[106].s0);
            Assert.AreEqual((short)3, r[106].s1);
            Assert.AreEqual((short)3, r[106].s2);
            Assert.AreEqual((short)3, r[106].s3);
            Assert.AreEqual((short)2, r[107].s0);
            Assert.AreEqual((short)3, r[107].s1);
            Assert.AreEqual((short)3, r[107].s2);
            Assert.AreEqual((short)4, r[107].s3);
            Assert.AreEqual((short)2, r[108].s0);
            Assert.AreEqual((short)3, r[108].s1);
            Assert.AreEqual((short)4, r[108].s2);
            Assert.AreEqual((short)1, r[108].s3);
            Assert.AreEqual((short)1, w[9].s1);
            Assert.AreEqual((short)2, w[9].s2);
            Assert.AreEqual((short)3, w[9].s3);
            Assert.AreEqual((short)4, w[9].s0);
            Assert.AreEqual((short)2, r[109].s0);
            Assert.AreEqual((short)3, r[109].s1);
            Assert.AreEqual((short)4, r[109].s2);
            Assert.AreEqual((short)2, r[109].s3);
            Assert.AreEqual((short)2, r[110].s0);
            Assert.AreEqual((short)3, r[110].s1);
            Assert.AreEqual((short)4, r[110].s2);
            Assert.AreEqual((short)3, r[110].s3);
            Assert.AreEqual((short)2, r[111].s0);
            Assert.AreEqual((short)3, r[111].s1);
            Assert.AreEqual((short)4, r[111].s2);
            Assert.AreEqual((short)4, r[111].s3);
            Assert.AreEqual((short)2, r[112].s0);
            Assert.AreEqual((short)4, r[112].s1);
            Assert.AreEqual((short)1, r[112].s2);
            Assert.AreEqual((short)1, r[112].s3);
            Assert.AreEqual((short)2, r[113].s0);
            Assert.AreEqual((short)4, r[113].s1);
            Assert.AreEqual((short)1, r[113].s2);
            Assert.AreEqual((short)2, r[113].s3);
            Assert.AreEqual((short)2, r[114].s0);
            Assert.AreEqual((short)4, r[114].s1);
            Assert.AreEqual((short)1, r[114].s2);
            Assert.AreEqual((short)3, r[114].s3);
            Assert.AreEqual((short)1, w[10].s1);
            Assert.AreEqual((short)2, w[10].s3);
            Assert.AreEqual((short)3, w[10].s0);
            Assert.AreEqual((short)4, w[10].s2);
            Assert.AreEqual((short)2, r[115].s0);
            Assert.AreEqual((short)4, r[115].s1);
            Assert.AreEqual((short)1, r[115].s2);
            Assert.AreEqual((short)4, r[115].s3);
            Assert.AreEqual((short)2, r[116].s0);
            Assert.AreEqual((short)4, r[116].s1);
            Assert.AreEqual((short)2, r[116].s2);
            Assert.AreEqual((short)1, r[116].s3);
            Assert.AreEqual((short)2, r[117].s0);
            Assert.AreEqual((short)4, r[117].s1);
            Assert.AreEqual((short)2, r[117].s2);
            Assert.AreEqual((short)2, r[117].s3);
            Assert.AreEqual((short)2, r[118].s0);
            Assert.AreEqual((short)4, r[118].s1);
            Assert.AreEqual((short)2, r[118].s2);
            Assert.AreEqual((short)3, r[118].s3);
            Assert.AreEqual((short)2, r[119].s0);
            Assert.AreEqual((short)4, r[119].s1);
            Assert.AreEqual((short)2, r[119].s2);
            Assert.AreEqual((short)4, r[119].s3);
            Assert.AreEqual((short)2, r[120].s0);
            Assert.AreEqual((short)4, r[120].s1);
            Assert.AreEqual((short)3, r[120].s2);
            Assert.AreEqual((short)1, r[120].s3);
            Assert.AreEqual((short)1, w[11].s1);
            Assert.AreEqual((short)2, w[11].s3);
            Assert.AreEqual((short)3, w[11].s2);
            Assert.AreEqual((short)4, w[11].s0);
            Assert.AreEqual((short)2, r[121].s0);
            Assert.AreEqual((short)4, r[121].s1);
            Assert.AreEqual((short)3, r[121].s2);
            Assert.AreEqual((short)2, r[121].s3);
            Assert.AreEqual((short)2, r[122].s0);
            Assert.AreEqual((short)4, r[122].s1);
            Assert.AreEqual((short)3, r[122].s2);
            Assert.AreEqual((short)3, r[122].s3);
            Assert.AreEqual((short)2, r[123].s0);
            Assert.AreEqual((short)4, r[123].s1);
            Assert.AreEqual((short)3, r[123].s2);
            Assert.AreEqual((short)4, r[123].s3);
            Assert.AreEqual((short)2, r[124].s0);
            Assert.AreEqual((short)4, r[124].s1);
            Assert.AreEqual((short)4, r[124].s2);
            Assert.AreEqual((short)1, r[124].s3);
            Assert.AreEqual((short)2, r[125].s0);
            Assert.AreEqual((short)4, r[125].s1);
            Assert.AreEqual((short)4, r[125].s2);
            Assert.AreEqual((short)2, r[125].s3);
            Assert.AreEqual((short)2, r[126].s0);
            Assert.AreEqual((short)4, r[126].s1);
            Assert.AreEqual((short)4, r[126].s2);
            Assert.AreEqual((short)3, r[126].s3);
            Assert.AreEqual((short)2, r[127].s0);
            Assert.AreEqual((short)4, r[127].s1);
            Assert.AreEqual((short)4, r[127].s2);
            Assert.AreEqual((short)4, r[127].s3);
            Assert.AreEqual((short)3, r[128].s0);
            Assert.AreEqual((short)1, r[128].s1);
            Assert.AreEqual((short)1, r[128].s2);
            Assert.AreEqual((short)1, r[128].s3);
            Assert.AreEqual((short)3, r[129].s0);
            Assert.AreEqual((short)1, r[129].s1);
            Assert.AreEqual((short)1, r[129].s2);
            Assert.AreEqual((short)2, r[129].s3);
            Assert.AreEqual((short)3, r[130].s0);
            Assert.AreEqual((short)1, r[130].s1);
            Assert.AreEqual((short)1, r[130].s2);
            Assert.AreEqual((short)3, r[130].s3);
            Assert.AreEqual((short)3, r[131].s0);
            Assert.AreEqual((short)1, r[131].s1);
            Assert.AreEqual((short)1, r[131].s2);
            Assert.AreEqual((short)4, r[131].s3);
            Assert.AreEqual((short)3, r[132].s0);
            Assert.AreEqual((short)1, r[132].s1);
            Assert.AreEqual((short)2, r[132].s2);
            Assert.AreEqual((short)1, r[132].s3);
            Assert.AreEqual((short)3, r[133].s0);
            Assert.AreEqual((short)1, r[133].s1);
            Assert.AreEqual((short)2, r[133].s2);
            Assert.AreEqual((short)2, r[133].s3);
            Assert.AreEqual((short)3, r[134].s0);
            Assert.AreEqual((short)1, r[134].s1);
            Assert.AreEqual((short)2, r[134].s2);
            Assert.AreEqual((short)3, r[134].s3);
            Assert.AreEqual((short)3, r[135].s0);
            Assert.AreEqual((short)1, r[135].s1);
            Assert.AreEqual((short)2, r[135].s2);
            Assert.AreEqual((short)4, r[135].s3);
            Assert.AreEqual((short)1, w[12].s2);
            Assert.AreEqual((short)2, w[12].s0);
            Assert.AreEqual((short)3, w[12].s1);
            Assert.AreEqual((short)4, w[12].s3);
            Assert.AreEqual((short)3, r[136].s0);
            Assert.AreEqual((short)1, r[136].s1);
            Assert.AreEqual((short)3, r[136].s2);
            Assert.AreEqual((short)1, r[136].s3);
            Assert.AreEqual((short)3, r[137].s0);
            Assert.AreEqual((short)1, r[137].s1);
            Assert.AreEqual((short)3, r[137].s2);
            Assert.AreEqual((short)2, r[137].s3);
            Assert.AreEqual((short)3, r[138].s0);
            Assert.AreEqual((short)1, r[138].s1);
            Assert.AreEqual((short)3, r[138].s2);
            Assert.AreEqual((short)3, r[138].s3);
            Assert.AreEqual((short)3, r[139].s0);
            Assert.AreEqual((short)1, r[139].s1);
            Assert.AreEqual((short)3, r[139].s2);
            Assert.AreEqual((short)4, r[139].s3);
            Assert.AreEqual((short)3, r[140].s0);
            Assert.AreEqual((short)1, r[140].s1);
            Assert.AreEqual((short)4, r[140].s2);
            Assert.AreEqual((short)1, r[140].s3);
            Assert.AreEqual((short)3, r[141].s0);
            Assert.AreEqual((short)1, r[141].s1);
            Assert.AreEqual((short)4, r[141].s2);
            Assert.AreEqual((short)2, r[141].s3);
            Assert.AreEqual((short)1, w[13].s2);
            Assert.AreEqual((short)2, w[13].s0);
            Assert.AreEqual((short)3, w[13].s3);
            Assert.AreEqual((short)4, w[13].s1);
            Assert.AreEqual((short)3, r[142].s0);
            Assert.AreEqual((short)1, r[142].s1);
            Assert.AreEqual((short)4, r[142].s2);
            Assert.AreEqual((short)3, r[142].s3);
            Assert.AreEqual((short)3, r[143].s0);
            Assert.AreEqual((short)1, r[143].s1);
            Assert.AreEqual((short)4, r[143].s2);
            Assert.AreEqual((short)4, r[143].s3);
            Assert.AreEqual((short)3, r[144].s0);
            Assert.AreEqual((short)2, r[144].s1);
            Assert.AreEqual((short)1, r[144].s2);
            Assert.AreEqual((short)1, r[144].s3);
            Assert.AreEqual((short)3, r[145].s0);
            Assert.AreEqual((short)2, r[145].s1);
            Assert.AreEqual((short)1, r[145].s2);
            Assert.AreEqual((short)2, r[145].s3);
            Assert.AreEqual((short)3, r[146].s0);
            Assert.AreEqual((short)2, r[146].s1);
            Assert.AreEqual((short)1, r[146].s2);
            Assert.AreEqual((short)3, r[146].s3);
            Assert.AreEqual((short)3, r[147].s0);
            Assert.AreEqual((short)2, r[147].s1);
            Assert.AreEqual((short)1, r[147].s2);
            Assert.AreEqual((short)4, r[147].s3);
            Assert.AreEqual((short)1, w[14].s2);
            Assert.AreEqual((short)2, w[14].s1);
            Assert.AreEqual((short)3, w[14].s0);
            Assert.AreEqual((short)4, w[14].s3);
            Assert.AreEqual((short)3, r[148].s0);
            Assert.AreEqual((short)2, r[148].s1);
            Assert.AreEqual((short)2, r[148].s2);
            Assert.AreEqual((short)1, r[148].s3);
            Assert.AreEqual((short)3, r[149].s0);
            Assert.AreEqual((short)2, r[149].s1);
            Assert.AreEqual((short)2, r[149].s2);
            Assert.AreEqual((short)2, r[149].s3);
            Assert.AreEqual((short)3, r[150].s0);
            Assert.AreEqual((short)2, r[150].s1);
            Assert.AreEqual((short)2, r[150].s2);
            Assert.AreEqual((short)3, r[150].s3);
            Assert.AreEqual((short)3, r[151].s0);
            Assert.AreEqual((short)2, r[151].s1);
            Assert.AreEqual((short)2, r[151].s2);
            Assert.AreEqual((short)4, r[151].s3);
            Assert.AreEqual((short)3, r[152].s0);
            Assert.AreEqual((short)2, r[152].s1);
            Assert.AreEqual((short)3, r[152].s2);
            Assert.AreEqual((short)1, r[152].s3);
            Assert.AreEqual((short)3, r[153].s0);
            Assert.AreEqual((short)2, r[153].s1);
            Assert.AreEqual((short)3, r[153].s2);
            Assert.AreEqual((short)2, r[153].s3);
            Assert.AreEqual((short)3, r[154].s0);
            Assert.AreEqual((short)2, r[154].s1);
            Assert.AreEqual((short)3, r[154].s2);
            Assert.AreEqual((short)3, r[154].s3);
            Assert.AreEqual((short)3, r[155].s0);
            Assert.AreEqual((short)2, r[155].s1);
            Assert.AreEqual((short)3, r[155].s2);
            Assert.AreEqual((short)4, r[155].s3);
            Assert.AreEqual((short)3, r[156].s0);
            Assert.AreEqual((short)2, r[156].s1);
            Assert.AreEqual((short)4, r[156].s2);
            Assert.AreEqual((short)1, r[156].s3);
            Assert.AreEqual((short)1, w[15].s2);
            Assert.AreEqual((short)2, w[15].s1);
            Assert.AreEqual((short)3, w[15].s3);
            Assert.AreEqual((short)4, w[15].s0);
            Assert.AreEqual((short)3, r[157].s0);
            Assert.AreEqual((short)2, r[157].s1);
            Assert.AreEqual((short)4, r[157].s2);
            Assert.AreEqual((short)2, r[157].s3);
            Assert.AreEqual((short)3, r[158].s0);
            Assert.AreEqual((short)2, r[158].s1);
            Assert.AreEqual((short)4, r[158].s2);
            Assert.AreEqual((short)3, r[158].s3);
            Assert.AreEqual((short)3, r[159].s0);
            Assert.AreEqual((short)2, r[159].s1);
            Assert.AreEqual((short)4, r[159].s2);
            Assert.AreEqual((short)4, r[159].s3);
            Assert.AreEqual((short)3, r[160].s0);
            Assert.AreEqual((short)3, r[160].s1);
            Assert.AreEqual((short)1, r[160].s2);
            Assert.AreEqual((short)1, r[160].s3);
            Assert.AreEqual((short)3, r[161].s0);
            Assert.AreEqual((short)3, r[161].s1);
            Assert.AreEqual((short)1, r[161].s2);
            Assert.AreEqual((short)2, r[161].s3);
            Assert.AreEqual((short)3, r[162].s0);
            Assert.AreEqual((short)3, r[162].s1);
            Assert.AreEqual((short)1, r[162].s2);
            Assert.AreEqual((short)3, r[162].s3);
            Assert.AreEqual((short)3, r[163].s0);
            Assert.AreEqual((short)3, r[163].s1);
            Assert.AreEqual((short)1, r[163].s2);
            Assert.AreEqual((short)4, r[163].s3);
            Assert.AreEqual((short)3, r[164].s0);
            Assert.AreEqual((short)3, r[164].s1);
            Assert.AreEqual((short)2, r[164].s2);
            Assert.AreEqual((short)1, r[164].s3);
            Assert.AreEqual((short)3, r[165].s0);
            Assert.AreEqual((short)3, r[165].s1);
            Assert.AreEqual((short)2, r[165].s2);
            Assert.AreEqual((short)2, r[165].s3);
            Assert.AreEqual((short)3, r[166].s0);
            Assert.AreEqual((short)3, r[166].s1);
            Assert.AreEqual((short)2, r[166].s2);
            Assert.AreEqual((short)3, r[166].s3);
            Assert.AreEqual((short)3, r[167].s0);
            Assert.AreEqual((short)3, r[167].s1);
            Assert.AreEqual((short)2, r[167].s2);
            Assert.AreEqual((short)4, r[167].s3);
            Assert.AreEqual((short)3, r[168].s0);
            Assert.AreEqual((short)3, r[168].s1);
            Assert.AreEqual((short)3, r[168].s2);
            Assert.AreEqual((short)1, r[168].s3);
            Assert.AreEqual((short)3, r[169].s0);
            Assert.AreEqual((short)3, r[169].s1);
            Assert.AreEqual((short)3, r[169].s2);
            Assert.AreEqual((short)2, r[169].s3);
            Assert.AreEqual((short)3, r[170].s0);
            Assert.AreEqual((short)3, r[170].s1);
            Assert.AreEqual((short)3, r[170].s2);
            Assert.AreEqual((short)3, r[170].s3);
            Assert.AreEqual((short)3, r[171].s0);
            Assert.AreEqual((short)3, r[171].s1);
            Assert.AreEqual((short)3, r[171].s2);
            Assert.AreEqual((short)4, r[171].s3);
            Assert.AreEqual((short)3, r[172].s0);
            Assert.AreEqual((short)3, r[172].s1);
            Assert.AreEqual((short)4, r[172].s2);
            Assert.AreEqual((short)1, r[172].s3);
            Assert.AreEqual((short)3, r[173].s0);
            Assert.AreEqual((short)3, r[173].s1);
            Assert.AreEqual((short)4, r[173].s2);
            Assert.AreEqual((short)2, r[173].s3);
            Assert.AreEqual((short)3, r[174].s0);
            Assert.AreEqual((short)3, r[174].s1);
            Assert.AreEqual((short)4, r[174].s2);
            Assert.AreEqual((short)3, r[174].s3);
            Assert.AreEqual((short)3, r[175].s0);
            Assert.AreEqual((short)3, r[175].s1);
            Assert.AreEqual((short)4, r[175].s2);
            Assert.AreEqual((short)4, r[175].s3);
            Assert.AreEqual((short)3, r[176].s0);
            Assert.AreEqual((short)4, r[176].s1);
            Assert.AreEqual((short)1, r[176].s2);
            Assert.AreEqual((short)1, r[176].s3);
            Assert.AreEqual((short)3, r[177].s0);
            Assert.AreEqual((short)4, r[177].s1);
            Assert.AreEqual((short)1, r[177].s2);
            Assert.AreEqual((short)2, r[177].s3);
            Assert.AreEqual((short)1, w[16].s2);
            Assert.AreEqual((short)2, w[16].s3);
            Assert.AreEqual((short)3, w[16].s0);
            Assert.AreEqual((short)4, w[16].s1);
            Assert.AreEqual((short)3, r[178].s0);
            Assert.AreEqual((short)4, r[178].s1);
            Assert.AreEqual((short)1, r[178].s2);
            Assert.AreEqual((short)3, r[178].s3);
            Assert.AreEqual((short)3, r[179].s0);
            Assert.AreEqual((short)4, r[179].s1);
            Assert.AreEqual((short)1, r[179].s2);
            Assert.AreEqual((short)4, r[179].s3);
            Assert.AreEqual((short)3, r[180].s0);
            Assert.AreEqual((short)4, r[180].s1);
            Assert.AreEqual((short)2, r[180].s2);
            Assert.AreEqual((short)1, r[180].s3);
            Assert.AreEqual((short)1, w[17].s2);
            Assert.AreEqual((short)2, w[17].s3);
            Assert.AreEqual((short)3, w[17].s1);
            Assert.AreEqual((short)4, w[17].s0);
            Assert.AreEqual((short)3, r[181].s0);
            Assert.AreEqual((short)4, r[181].s1);
            Assert.AreEqual((short)2, r[181].s2);
            Assert.AreEqual((short)2, r[181].s3);
            Assert.AreEqual((short)3, r[182].s0);
            Assert.AreEqual((short)4, r[182].s1);
            Assert.AreEqual((short)2, r[182].s2);
            Assert.AreEqual((short)3, r[182].s3);
            Assert.AreEqual((short)3, r[183].s0);
            Assert.AreEqual((short)4, r[183].s1);
            Assert.AreEqual((short)2, r[183].s2);
            Assert.AreEqual((short)4, r[183].s3);
            Assert.AreEqual((short)3, r[184].s0);
            Assert.AreEqual((short)4, r[184].s1);
            Assert.AreEqual((short)3, r[184].s2);
            Assert.AreEqual((short)1, r[184].s3);
            Assert.AreEqual((short)3, r[185].s0);
            Assert.AreEqual((short)4, r[185].s1);
            Assert.AreEqual((short)3, r[185].s2);
            Assert.AreEqual((short)2, r[185].s3);
            Assert.AreEqual((short)3, r[186].s0);
            Assert.AreEqual((short)4, r[186].s1);
            Assert.AreEqual((short)3, r[186].s2);
            Assert.AreEqual((short)3, r[186].s3);
            Assert.AreEqual((short)3, r[187].s0);
            Assert.AreEqual((short)4, r[187].s1);
            Assert.AreEqual((short)3, r[187].s2);
            Assert.AreEqual((short)4, r[187].s3);
            Assert.AreEqual((short)3, r[188].s0);
            Assert.AreEqual((short)4, r[188].s1);
            Assert.AreEqual((short)4, r[188].s2);
            Assert.AreEqual((short)1, r[188].s3);
            Assert.AreEqual((short)3, r[189].s0);
            Assert.AreEqual((short)4, r[189].s1);
            Assert.AreEqual((short)4, r[189].s2);
            Assert.AreEqual((short)2, r[189].s3);
            Assert.AreEqual((short)3, r[190].s0);
            Assert.AreEqual((short)4, r[190].s1);
            Assert.AreEqual((short)4, r[190].s2);
            Assert.AreEqual((short)3, r[190].s3);
            Assert.AreEqual((short)3, r[191].s0);
            Assert.AreEqual((short)4, r[191].s1);
            Assert.AreEqual((short)4, r[191].s2);
            Assert.AreEqual((short)4, r[191].s3);
            Assert.AreEqual((short)4, r[192].s0);
            Assert.AreEqual((short)1, r[192].s1);
            Assert.AreEqual((short)1, r[192].s2);
            Assert.AreEqual((short)1, r[192].s3);
            Assert.AreEqual((short)4, r[193].s0);
            Assert.AreEqual((short)1, r[193].s1);
            Assert.AreEqual((short)1, r[193].s2);
            Assert.AreEqual((short)2, r[193].s3);
            Assert.AreEqual((short)4, r[194].s0);
            Assert.AreEqual((short)1, r[194].s1);
            Assert.AreEqual((short)1, r[194].s2);
            Assert.AreEqual((short)3, r[194].s3);
            Assert.AreEqual((short)4, r[195].s0);
            Assert.AreEqual((short)1, r[195].s1);
            Assert.AreEqual((short)1, r[195].s2);
            Assert.AreEqual((short)4, r[195].s3);
            Assert.AreEqual((short)4, r[196].s0);
            Assert.AreEqual((short)1, r[196].s1);
            Assert.AreEqual((short)2, r[196].s2);
            Assert.AreEqual((short)1, r[196].s3);
            Assert.AreEqual((short)4, r[197].s0);
            Assert.AreEqual((short)1, r[197].s1);
            Assert.AreEqual((short)2, r[197].s2);
            Assert.AreEqual((short)2, r[197].s3);
            Assert.AreEqual((short)4, r[198].s0);
            Assert.AreEqual((short)1, r[198].s1);
            Assert.AreEqual((short)2, r[198].s2);
            Assert.AreEqual((short)3, r[198].s3);
            Assert.AreEqual((short)1, w[18].s3);
            Assert.AreEqual((short)2, w[18].s0);
            Assert.AreEqual((short)3, w[18].s1);
            Assert.AreEqual((short)4, w[18].s2);
            Assert.AreEqual((short)4, r[199].s0);
            Assert.AreEqual((short)1, r[199].s1);
            Assert.AreEqual((short)2, r[199].s2);
            Assert.AreEqual((short)4, r[199].s3);
            Assert.AreEqual((short)4, r[200].s0);
            Assert.AreEqual((short)1, r[200].s1);
            Assert.AreEqual((short)3, r[200].s2);
            Assert.AreEqual((short)1, r[200].s3);
            Assert.AreEqual((short)4, r[201].s0);
            Assert.AreEqual((short)1, r[201].s1);
            Assert.AreEqual((short)3, r[201].s2);
            Assert.AreEqual((short)2, r[201].s3);
            Assert.AreEqual((short)1, w[19].s3);
            Assert.AreEqual((short)2, w[19].s0);
            Assert.AreEqual((short)3, w[19].s2);
            Assert.AreEqual((short)4, w[19].s1);
            Assert.AreEqual((short)4, r[202].s0);
            Assert.AreEqual((short)1, r[202].s1);
            Assert.AreEqual((short)3, r[202].s2);
            Assert.AreEqual((short)3, r[202].s3);
            Assert.AreEqual((short)4, r[203].s0);
            Assert.AreEqual((short)1, r[203].s1);
            Assert.AreEqual((short)3, r[203].s2);
            Assert.AreEqual((short)4, r[203].s3);
            Assert.AreEqual((short)4, r[204].s0);
            Assert.AreEqual((short)1, r[204].s1);
            Assert.AreEqual((short)4, r[204].s2);
            Assert.AreEqual((short)1, r[204].s3);
            Assert.AreEqual((short)4, r[205].s0);
            Assert.AreEqual((short)1, r[205].s1);
            Assert.AreEqual((short)4, r[205].s2);
            Assert.AreEqual((short)2, r[205].s3);
            Assert.AreEqual((short)4, r[206].s0);
            Assert.AreEqual((short)1, r[206].s1);
            Assert.AreEqual((short)4, r[206].s2);
            Assert.AreEqual((short)3, r[206].s3);
            Assert.AreEqual((short)4, r[207].s0);
            Assert.AreEqual((short)1, r[207].s1);
            Assert.AreEqual((short)4, r[207].s2);
            Assert.AreEqual((short)4, r[207].s3);
            Assert.AreEqual((short)4, r[208].s0);
            Assert.AreEqual((short)2, r[208].s1);
            Assert.AreEqual((short)1, r[208].s2);
            Assert.AreEqual((short)1, r[208].s3);
            Assert.AreEqual((short)4, r[209].s0);
            Assert.AreEqual((short)2, r[209].s1);
            Assert.AreEqual((short)1, r[209].s2);
            Assert.AreEqual((short)2, r[209].s3);
            Assert.AreEqual((short)4, r[210].s0);
            Assert.AreEqual((short)2, r[210].s1);
            Assert.AreEqual((short)1, r[210].s2);
            Assert.AreEqual((short)3, r[210].s3);
            Assert.AreEqual((short)1, w[20].s3);
            Assert.AreEqual((short)2, w[20].s1);
            Assert.AreEqual((short)3, w[20].s0);
            Assert.AreEqual((short)4, w[20].s2);
            Assert.AreEqual((short)4, r[211].s0);
            Assert.AreEqual((short)2, r[211].s1);
            Assert.AreEqual((short)1, r[211].s2);
            Assert.AreEqual((short)4, r[211].s3);
            Assert.AreEqual((short)4, r[212].s0);
            Assert.AreEqual((short)2, r[212].s1);
            Assert.AreEqual((short)2, r[212].s2);
            Assert.AreEqual((short)1, r[212].s3);
            Assert.AreEqual((short)4, r[213].s0);
            Assert.AreEqual((short)2, r[213].s1);
            Assert.AreEqual((short)2, r[213].s2);
            Assert.AreEqual((short)2, r[213].s3);
            Assert.AreEqual((short)4, r[214].s0);
            Assert.AreEqual((short)2, r[214].s1);
            Assert.AreEqual((short)2, r[214].s2);
            Assert.AreEqual((short)3, r[214].s3);
            Assert.AreEqual((short)4, r[215].s0);
            Assert.AreEqual((short)2, r[215].s1);
            Assert.AreEqual((short)2, r[215].s2);
            Assert.AreEqual((short)4, r[215].s3);
            Assert.AreEqual((short)4, r[216].s0);
            Assert.AreEqual((short)2, r[216].s1);
            Assert.AreEqual((short)3, r[216].s2);
            Assert.AreEqual((short)1, r[216].s3);
            Assert.AreEqual((short)1, w[21].s3);
            Assert.AreEqual((short)2, w[21].s1);
            Assert.AreEqual((short)3, w[21].s2);
            Assert.AreEqual((short)4, w[21].s0);
            Assert.AreEqual((short)4, r[217].s0);
            Assert.AreEqual((short)2, r[217].s1);
            Assert.AreEqual((short)3, r[217].s2);
            Assert.AreEqual((short)2, r[217].s3);
            Assert.AreEqual((short)4, r[218].s0);
            Assert.AreEqual((short)2, r[218].s1);
            Assert.AreEqual((short)3, r[218].s2);
            Assert.AreEqual((short)3, r[218].s3);
            Assert.AreEqual((short)4, r[219].s0);
            Assert.AreEqual((short)2, r[219].s1);
            Assert.AreEqual((short)3, r[219].s2);
            Assert.AreEqual((short)4, r[219].s3);
            Assert.AreEqual((short)4, r[220].s0);
            Assert.AreEqual((short)2, r[220].s1);
            Assert.AreEqual((short)4, r[220].s2);
            Assert.AreEqual((short)1, r[220].s3);
            Assert.AreEqual((short)4, r[221].s0);
            Assert.AreEqual((short)2, r[221].s1);
            Assert.AreEqual((short)4, r[221].s2);
            Assert.AreEqual((short)2, r[221].s3);
            Assert.AreEqual((short)4, r[222].s0);
            Assert.AreEqual((short)2, r[222].s1);
            Assert.AreEqual((short)4, r[222].s2);
            Assert.AreEqual((short)3, r[222].s3);
            Assert.AreEqual((short)4, r[223].s0);
            Assert.AreEqual((short)2, r[223].s1);
            Assert.AreEqual((short)4, r[223].s2);
            Assert.AreEqual((short)4, r[223].s3);
            Assert.AreEqual((short)4, r[224].s0);
            Assert.AreEqual((short)3, r[224].s1);
            Assert.AreEqual((short)1, r[224].s2);
            Assert.AreEqual((short)1, r[224].s3);
            Assert.AreEqual((short)4, r[225].s0);
            Assert.AreEqual((short)3, r[225].s1);
            Assert.AreEqual((short)1, r[225].s2);
            Assert.AreEqual((short)2, r[225].s3);
            Assert.AreEqual((short)1, w[22].s3);
            Assert.AreEqual((short)2, w[22].s2);
            Assert.AreEqual((short)3, w[22].s0);
            Assert.AreEqual((short)4, w[22].s1);
            Assert.AreEqual((short)4, r[226].s0);
            Assert.AreEqual((short)3, r[226].s1);
            Assert.AreEqual((short)1, r[226].s2);
            Assert.AreEqual((short)3, r[226].s3);
            Assert.AreEqual((short)4, r[227].s0);
            Assert.AreEqual((short)3, r[227].s1);
            Assert.AreEqual((short)1, r[227].s2);
            Assert.AreEqual((short)4, r[227].s3);
            Assert.AreEqual((short)4, r[228].s0);
            Assert.AreEqual((short)3, r[228].s1);
            Assert.AreEqual((short)2, r[228].s2);
            Assert.AreEqual((short)1, r[228].s3);
            Assert.AreEqual((short)1, w[23].s3);
            Assert.AreEqual((short)2, w[23].s2);
            Assert.AreEqual((short)3, w[23].s1);
            Assert.AreEqual((short)4, w[23].s0);
            Assert.AreEqual((short)4, r[229].s0);
            Assert.AreEqual((short)3, r[229].s1);
            Assert.AreEqual((short)2, r[229].s2);
            Assert.AreEqual((short)2, r[229].s3);
            Assert.AreEqual((short)4, r[230].s0);
            Assert.AreEqual((short)3, r[230].s1);
            Assert.AreEqual((short)2, r[230].s2);
            Assert.AreEqual((short)3, r[230].s3);
            Assert.AreEqual((short)4, r[231].s0);
            Assert.AreEqual((short)3, r[231].s1);
            Assert.AreEqual((short)2, r[231].s2);
            Assert.AreEqual((short)4, r[231].s3);
            Assert.AreEqual((short)4, r[232].s0);
            Assert.AreEqual((short)3, r[232].s1);
            Assert.AreEqual((short)3, r[232].s2);
            Assert.AreEqual((short)1, r[232].s3);
            Assert.AreEqual((short)4, r[233].s0);
            Assert.AreEqual((short)3, r[233].s1);
            Assert.AreEqual((short)3, r[233].s2);
            Assert.AreEqual((short)2, r[233].s3);
            Assert.AreEqual((short)4, r[234].s0);
            Assert.AreEqual((short)3, r[234].s1);
            Assert.AreEqual((short)3, r[234].s2);
            Assert.AreEqual((short)3, r[234].s3);
            Assert.AreEqual((short)4, r[235].s0);
            Assert.AreEqual((short)3, r[235].s1);
            Assert.AreEqual((short)3, r[235].s2);
            Assert.AreEqual((short)4, r[235].s3);
            Assert.AreEqual((short)4, r[236].s0);
            Assert.AreEqual((short)3, r[236].s1);
            Assert.AreEqual((short)4, r[236].s2);
            Assert.AreEqual((short)1, r[236].s3);
            Assert.AreEqual((short)4, r[237].s0);
            Assert.AreEqual((short)3, r[237].s1);
            Assert.AreEqual((short)4, r[237].s2);
            Assert.AreEqual((short)2, r[237].s3);
            Assert.AreEqual((short)4, r[238].s0);
            Assert.AreEqual((short)3, r[238].s1);
            Assert.AreEqual((short)4, r[238].s2);
            Assert.AreEqual((short)3, r[238].s3);
            Assert.AreEqual((short)4, r[239].s0);
            Assert.AreEqual((short)3, r[239].s1);
            Assert.AreEqual((short)4, r[239].s2);
            Assert.AreEqual((short)4, r[239].s3);
            Assert.AreEqual((short)4, r[240].s0);
            Assert.AreEqual((short)4, r[240].s1);
            Assert.AreEqual((short)1, r[240].s2);
            Assert.AreEqual((short)1, r[240].s3);
            Assert.AreEqual((short)4, r[241].s0);
            Assert.AreEqual((short)4, r[241].s1);
            Assert.AreEqual((short)1, r[241].s2);
            Assert.AreEqual((short)2, r[241].s3);
            Assert.AreEqual((short)4, r[242].s0);
            Assert.AreEqual((short)4, r[242].s1);
            Assert.AreEqual((short)1, r[242].s2);
            Assert.AreEqual((short)3, r[242].s3);
            Assert.AreEqual((short)4, r[243].s0);
            Assert.AreEqual((short)4, r[243].s1);
            Assert.AreEqual((short)1, r[243].s2);
            Assert.AreEqual((short)4, r[243].s3);
            Assert.AreEqual((short)4, r[244].s0);
            Assert.AreEqual((short)4, r[244].s1);
            Assert.AreEqual((short)2, r[244].s2);
            Assert.AreEqual((short)1, r[244].s3);
            Assert.AreEqual((short)4, r[245].s0);
            Assert.AreEqual((short)4, r[245].s1);
            Assert.AreEqual((short)2, r[245].s2);
            Assert.AreEqual((short)2, r[245].s3);
            Assert.AreEqual((short)4, r[246].s0);
            Assert.AreEqual((short)4, r[246].s1);
            Assert.AreEqual((short)2, r[246].s2);
            Assert.AreEqual((short)3, r[246].s3);
            Assert.AreEqual((short)4, r[247].s0);
            Assert.AreEqual((short)4, r[247].s1);
            Assert.AreEqual((short)2, r[247].s2);
            Assert.AreEqual((short)4, r[247].s3);
            Assert.AreEqual((short)4, r[248].s0);
            Assert.AreEqual((short)4, r[248].s1);
            Assert.AreEqual((short)3, r[248].s2);
            Assert.AreEqual((short)1, r[248].s3);
            Assert.AreEqual((short)4, r[249].s0);
            Assert.AreEqual((short)4, r[249].s1);
            Assert.AreEqual((short)3, r[249].s2);
            Assert.AreEqual((short)2, r[249].s3);
            Assert.AreEqual((short)4, r[250].s0);
            Assert.AreEqual((short)4, r[250].s1);
            Assert.AreEqual((short)3, r[250].s2);
            Assert.AreEqual((short)3, r[250].s3);
            Assert.AreEqual((short)4, r[251].s0);
            Assert.AreEqual((short)4, r[251].s1);
            Assert.AreEqual((short)3, r[251].s2);
            Assert.AreEqual((short)4, r[251].s3);
            Assert.AreEqual((short)4, r[252].s0);
            Assert.AreEqual((short)4, r[252].s1);
            Assert.AreEqual((short)4, r[252].s2);
            Assert.AreEqual((short)1, r[252].s3);
            Assert.AreEqual((short)4, r[253].s0);
            Assert.AreEqual((short)4, r[253].s1);
            Assert.AreEqual((short)4, r[253].s2);
            Assert.AreEqual((short)2, r[253].s3);
            Assert.AreEqual((short)4, r[254].s0);
            Assert.AreEqual((short)4, r[254].s1);
            Assert.AreEqual((short)4, r[254].s2);
            Assert.AreEqual((short)3, r[254].s3);
            Assert.AreEqual((short)4, r[255].s0);
            Assert.AreEqual((short)4, r[255].s1);
            Assert.AreEqual((short)4, r[255].s2);
            Assert.AreEqual((short)4, r[255].s3);
        }
    }
}
