using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestByte3
    {
        [Kernel]
        private static void test_byte3_add([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            byte3[] a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            byte3[] b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            byte3[] r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_add,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_add");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<byte3>());
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
        private static void test_byte3_sub([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            byte3[] a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            byte3[] b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            byte3[] r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_sub");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<byte3>());
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_mul([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            byte3[] a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            byte3[] b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            byte3[] r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_mul");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<byte3>());
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
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_div([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            byte3[] a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            byte3[] b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            byte3[] r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_div,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_div");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<byte3>());
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
        private static void test_byte3_eq([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            byte3[] a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            byte3[] b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            sbyte3[] r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_eq,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<sbyte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_eq");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte3>());
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
        private static void test_byte3_neq([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            byte3[] a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            byte3[] b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            sbyte3[] r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_neq,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<sbyte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_neq");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte3>());
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
        private static void test_byte3_lt([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            byte3[] a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            byte3[] b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            sbyte3[] r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_lt,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<sbyte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_lt");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte3>());
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
        private static void test_byte3_le([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            byte3[] a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            byte3[] b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            sbyte3[] r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_le,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<sbyte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_le");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte3>());
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
        private static void test_byte3_gt([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            byte3[] a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            byte3[] b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            sbyte3[] r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_gt,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<sbyte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_gt");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte3>());
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
        private static void test_byte3_ge([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            byte3[] a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            byte3[] b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            sbyte3[] r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_ge,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<sbyte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_ge");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte3>());
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
        private static void test_byte3_and([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAnd()
        {
            byte3[] a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            byte3[] b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            byte3[] r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_and,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_and");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_and");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<byte3>());
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
        private static void test_byte3_or([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOr()
        {
            byte3[] a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            byte3[] b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            byte3[] r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_or,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_or");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_or");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<byte3>());
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
        private static void test_byte3_xor([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXor()
        {
            byte3[] a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            byte3[] b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            byte3[] r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_xor,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_byte3_xor");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<byte3>;
                var mb = null as Mem<byte3>;
                var mr = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_byte3_xor");
                    ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<byte3>());
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
        private static void test_components1([Global] byte[] r, [Global] byte3[] w)
        {
            byte3 ar = new byte3((byte)1, (byte)2, (byte)3);
            byte aw = (byte)1;
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
            byte[] r = new byte[nr];
            byte3[] w = new byte3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte[],byte3[]>)test_components1,
                r, w
            );
            Assert.AreEqual((byte)1, r[0]);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)0, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)2, r[1]);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)0, w[1].s0);
            Assert.AreEqual((byte)0, w[1].s2);
            Assert.AreEqual((byte)3, r[2]);
            Assert.AreEqual((byte)1, w[2].s2);
            Assert.AreEqual((byte)0, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_components1");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<byte>;
                var mw = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components1");
                    mr = Mem<byte>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte>());
                    mw = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte3>());
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
            Assert.AreEqual((byte)1, r[0]);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)0, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)2, r[1]);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)0, w[1].s0);
            Assert.AreEqual((byte)0, w[1].s2);
            Assert.AreEqual((byte)3, r[2]);
            Assert.AreEqual((byte)1, w[2].s2);
            Assert.AreEqual((byte)0, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s1);
        }
        [Kernel]
        private static void test_components2([Global] byte2[] r, [Global] byte3[] w)
        {
            byte3 ar = new byte3((byte)1, (byte)2, (byte)3);
            byte2 aw = new byte2((byte)1, (byte)2);
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
            byte2[] r = new byte2[nr];
            byte3[] w = new byte3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte2[],byte3[]>)test_components2,
                r, w
            );
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)2, r[1].s1);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)3, r[2].s1);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)0, w[1].s1);
            Assert.AreEqual((byte)2, r[3].s0);
            Assert.AreEqual((byte)1, r[3].s1);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s2);
            Assert.AreEqual((byte)2, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[5].s0);
            Assert.AreEqual((byte)3, r[5].s1);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)0, w[3].s0);
            Assert.AreEqual((byte)3, r[6].s0);
            Assert.AreEqual((byte)1, r[6].s1);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)0, w[4].s1);
            Assert.AreEqual((byte)3, r[7].s0);
            Assert.AreEqual((byte)2, r[7].s1);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)0, w[5].s0);
            Assert.AreEqual((byte)3, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_components2");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<byte2>;
                var mw = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components2");
                    mr = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte2>());
                    mw = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte3>());
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
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)2, r[1].s1);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)3, r[2].s1);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)0, w[1].s1);
            Assert.AreEqual((byte)2, r[3].s0);
            Assert.AreEqual((byte)1, r[3].s1);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s2);
            Assert.AreEqual((byte)2, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[5].s0);
            Assert.AreEqual((byte)3, r[5].s1);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)0, w[3].s0);
            Assert.AreEqual((byte)3, r[6].s0);
            Assert.AreEqual((byte)1, r[6].s1);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)0, w[4].s1);
            Assert.AreEqual((byte)3, r[7].s0);
            Assert.AreEqual((byte)2, r[7].s1);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)0, w[5].s0);
            Assert.AreEqual((byte)3, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);
        }
        [Kernel]
        private static void test_components3([Global] byte3[] r, [Global] byte3[] w)
        {
            byte3 ar = new byte3((byte)1, (byte)2, (byte)3);
            byte3 aw = new byte3((byte)1, (byte)2, (byte)3);
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
            byte3[] r = new byte3[nr];
            byte3[] w = new byte3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte3[],byte3[]>)test_components3,
                r, w
            );
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[0].s2);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)1, r[1].s1);
            Assert.AreEqual((byte)2, r[1].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)1, r[2].s1);
            Assert.AreEqual((byte)3, r[2].s2);
            Assert.AreEqual((byte)1, r[3].s0);
            Assert.AreEqual((byte)2, r[3].s1);
            Assert.AreEqual((byte)1, r[3].s2);
            Assert.AreEqual((byte)1, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[4].s2);
            Assert.AreEqual((byte)1, r[5].s0);
            Assert.AreEqual((byte)2, r[5].s1);
            Assert.AreEqual((byte)3, r[5].s2);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)3, w[0].s2);
            Assert.AreEqual((byte)1, r[6].s0);
            Assert.AreEqual((byte)3, r[6].s1);
            Assert.AreEqual((byte)1, r[6].s2);
            Assert.AreEqual((byte)1, r[7].s0);
            Assert.AreEqual((byte)3, r[7].s1);
            Assert.AreEqual((byte)2, r[7].s2);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)3, w[1].s1);
            Assert.AreEqual((byte)1, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);
            Assert.AreEqual((byte)3, r[8].s2);
            Assert.AreEqual((byte)2, r[9].s0);
            Assert.AreEqual((byte)1, r[9].s1);
            Assert.AreEqual((byte)1, r[9].s2);
            Assert.AreEqual((byte)2, r[10].s0);
            Assert.AreEqual((byte)1, r[10].s1);
            Assert.AreEqual((byte)2, r[10].s2);
            Assert.AreEqual((byte)2, r[11].s0);
            Assert.AreEqual((byte)1, r[11].s1);
            Assert.AreEqual((byte)3, r[11].s2);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)3, w[2].s2);
            Assert.AreEqual((byte)2, r[12].s0);
            Assert.AreEqual((byte)2, r[12].s1);
            Assert.AreEqual((byte)1, r[12].s2);
            Assert.AreEqual((byte)2, r[13].s0);
            Assert.AreEqual((byte)2, r[13].s1);
            Assert.AreEqual((byte)2, r[13].s2);
            Assert.AreEqual((byte)2, r[14].s0);
            Assert.AreEqual((byte)2, r[14].s1);
            Assert.AreEqual((byte)3, r[14].s2);
            Assert.AreEqual((byte)2, r[15].s0);
            Assert.AreEqual((byte)3, r[15].s1);
            Assert.AreEqual((byte)1, r[15].s2);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)3, w[3].s0);
            Assert.AreEqual((byte)2, r[16].s0);
            Assert.AreEqual((byte)3, r[16].s1);
            Assert.AreEqual((byte)2, r[16].s2);
            Assert.AreEqual((byte)2, r[17].s0);
            Assert.AreEqual((byte)3, r[17].s1);
            Assert.AreEqual((byte)3, r[17].s2);
            Assert.AreEqual((byte)3, r[18].s0);
            Assert.AreEqual((byte)1, r[18].s1);
            Assert.AreEqual((byte)1, r[18].s2);
            Assert.AreEqual((byte)3, r[19].s0);
            Assert.AreEqual((byte)1, r[19].s1);
            Assert.AreEqual((byte)2, r[19].s2);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)3, w[4].s1);
            Assert.AreEqual((byte)3, r[20].s0);
            Assert.AreEqual((byte)1, r[20].s1);
            Assert.AreEqual((byte)3, r[20].s2);
            Assert.AreEqual((byte)3, r[21].s0);
            Assert.AreEqual((byte)2, r[21].s1);
            Assert.AreEqual((byte)1, r[21].s2);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)3, w[5].s0);
            Assert.AreEqual((byte)3, r[22].s0);
            Assert.AreEqual((byte)2, r[22].s1);
            Assert.AreEqual((byte)2, r[22].s2);
            Assert.AreEqual((byte)3, r[23].s0);
            Assert.AreEqual((byte)2, r[23].s1);
            Assert.AreEqual((byte)3, r[23].s2);
            Assert.AreEqual((byte)3, r[24].s0);
            Assert.AreEqual((byte)3, r[24].s1);
            Assert.AreEqual((byte)1, r[24].s2);
            Assert.AreEqual((byte)3, r[25].s0);
            Assert.AreEqual((byte)3, r[25].s1);
            Assert.AreEqual((byte)2, r[25].s2);
            Assert.AreEqual((byte)3, r[26].s0);
            Assert.AreEqual((byte)3, r[26].s1);
            Assert.AreEqual((byte)3, r[26].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestByte3", "test_components3");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<byte3>;
                var mw = null as Mem<byte3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components3");
                    mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte3>());
                    mw = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte3>());
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
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[0].s2);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)1, r[1].s1);
            Assert.AreEqual((byte)2, r[1].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)1, r[2].s1);
            Assert.AreEqual((byte)3, r[2].s2);
            Assert.AreEqual((byte)1, r[3].s0);
            Assert.AreEqual((byte)2, r[3].s1);
            Assert.AreEqual((byte)1, r[3].s2);
            Assert.AreEqual((byte)1, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[4].s2);
            Assert.AreEqual((byte)1, r[5].s0);
            Assert.AreEqual((byte)2, r[5].s1);
            Assert.AreEqual((byte)3, r[5].s2);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)3, w[0].s2);
            Assert.AreEqual((byte)1, r[6].s0);
            Assert.AreEqual((byte)3, r[6].s1);
            Assert.AreEqual((byte)1, r[6].s2);
            Assert.AreEqual((byte)1, r[7].s0);
            Assert.AreEqual((byte)3, r[7].s1);
            Assert.AreEqual((byte)2, r[7].s2);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)3, w[1].s1);
            Assert.AreEqual((byte)1, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);
            Assert.AreEqual((byte)3, r[8].s2);
            Assert.AreEqual((byte)2, r[9].s0);
            Assert.AreEqual((byte)1, r[9].s1);
            Assert.AreEqual((byte)1, r[9].s2);
            Assert.AreEqual((byte)2, r[10].s0);
            Assert.AreEqual((byte)1, r[10].s1);
            Assert.AreEqual((byte)2, r[10].s2);
            Assert.AreEqual((byte)2, r[11].s0);
            Assert.AreEqual((byte)1, r[11].s1);
            Assert.AreEqual((byte)3, r[11].s2);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)3, w[2].s2);
            Assert.AreEqual((byte)2, r[12].s0);
            Assert.AreEqual((byte)2, r[12].s1);
            Assert.AreEqual((byte)1, r[12].s2);
            Assert.AreEqual((byte)2, r[13].s0);
            Assert.AreEqual((byte)2, r[13].s1);
            Assert.AreEqual((byte)2, r[13].s2);
            Assert.AreEqual((byte)2, r[14].s0);
            Assert.AreEqual((byte)2, r[14].s1);
            Assert.AreEqual((byte)3, r[14].s2);
            Assert.AreEqual((byte)2, r[15].s0);
            Assert.AreEqual((byte)3, r[15].s1);
            Assert.AreEqual((byte)1, r[15].s2);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)3, w[3].s0);
            Assert.AreEqual((byte)2, r[16].s0);
            Assert.AreEqual((byte)3, r[16].s1);
            Assert.AreEqual((byte)2, r[16].s2);
            Assert.AreEqual((byte)2, r[17].s0);
            Assert.AreEqual((byte)3, r[17].s1);
            Assert.AreEqual((byte)3, r[17].s2);
            Assert.AreEqual((byte)3, r[18].s0);
            Assert.AreEqual((byte)1, r[18].s1);
            Assert.AreEqual((byte)1, r[18].s2);
            Assert.AreEqual((byte)3, r[19].s0);
            Assert.AreEqual((byte)1, r[19].s1);
            Assert.AreEqual((byte)2, r[19].s2);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)3, w[4].s1);
            Assert.AreEqual((byte)3, r[20].s0);
            Assert.AreEqual((byte)1, r[20].s1);
            Assert.AreEqual((byte)3, r[20].s2);
            Assert.AreEqual((byte)3, r[21].s0);
            Assert.AreEqual((byte)2, r[21].s1);
            Assert.AreEqual((byte)1, r[21].s2);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)3, w[5].s0);
            Assert.AreEqual((byte)3, r[22].s0);
            Assert.AreEqual((byte)2, r[22].s1);
            Assert.AreEqual((byte)2, r[22].s2);
            Assert.AreEqual((byte)3, r[23].s0);
            Assert.AreEqual((byte)2, r[23].s1);
            Assert.AreEqual((byte)3, r[23].s2);
            Assert.AreEqual((byte)3, r[24].s0);
            Assert.AreEqual((byte)3, r[24].s1);
            Assert.AreEqual((byte)1, r[24].s2);
            Assert.AreEqual((byte)3, r[25].s0);
            Assert.AreEqual((byte)3, r[25].s1);
            Assert.AreEqual((byte)2, r[25].s2);
            Assert.AreEqual((byte)3, r[26].s0);
            Assert.AreEqual((byte)3, r[26].s1);
            Assert.AreEqual((byte)3, r[26].s2);
        }
    }
}
