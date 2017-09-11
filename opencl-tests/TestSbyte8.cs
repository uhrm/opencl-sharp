using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestSbyte8
    {
        [Kernel]
        private static void test_sbyte8_add([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual(  60, r[0].s4);
            Assert.AreEqual(  72, r[0].s5);
            Assert.AreEqual(  84, r[0].s6);
            Assert.AreEqual(  96, r[0].s7);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_add");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(  60, r[0].s4);
            Assert.AreEqual(  72, r[0].s5);
            Assert.AreEqual(  84, r[0].s6);
            Assert.AreEqual(  96, r[0].s7);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_sub([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  10, r[0].s4);
            Assert.AreEqual(  12, r[0].s5);
            Assert.AreEqual(  14, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_sub");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(  10, r[0].s4);
            Assert.AreEqual(  12, r[0].s5);
            Assert.AreEqual(  14, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_mul([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual(-116, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( -20, r[0].s5);
            Assert.AreEqual( -77, r[0].s6);
            Assert.AreEqual( -64, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_mul");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(-116, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( -20, r[0].s5);
            Assert.AreEqual( -77, r[0].s6);
            Assert.AreEqual( -64, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_div([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   1, r[0].s3);
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(   1, r[0].s5);
            Assert.AreEqual(   1, r[0].s6);
            Assert.AreEqual(   1, r[0].s7);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_div");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(   1, r[0].s5);
            Assert.AreEqual(   1, r[0].s6);
            Assert.AreEqual(   1, r[0].s7);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_eq([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_eq");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_neq([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_neq");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_lt([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_lt");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_le([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_le");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_gt([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_gt");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_ge([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_ge");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_and([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAnd()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_and,
                a,
                b,
                r
            );
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[0].s2);
            Assert.AreEqual(  20, r[0].s3);
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(  10, r[0].s5);
            Assert.AreEqual(  33, r[0].s6);
            Assert.AreEqual(  40, r[0].s7);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);
            Assert.AreEqual(   1, r[1].s4);
            Assert.AreEqual(  10, r[1].s5);
            Assert.AreEqual(  33, r[1].s6);
            Assert.AreEqual(  40, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_and");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_and");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(  10, r[0].s5);
            Assert.AreEqual(  33, r[0].s6);
            Assert.AreEqual(  40, r[0].s7);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);
            Assert.AreEqual(   1, r[1].s4);
            Assert.AreEqual(  10, r[1].s5);
            Assert.AreEqual(  33, r[1].s6);
            Assert.AreEqual(  40, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_or([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOr()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_or,
                a,
                b,
                r
            );
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(  31, r[0].s2);
            Assert.AreEqual(  28, r[0].s3);
            Assert.AreEqual(  59, r[0].s4);
            Assert.AreEqual(  62, r[0].s5);
            Assert.AreEqual(  51, r[0].s6);
            Assert.AreEqual(  56, r[0].s7);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);
            Assert.AreEqual(  59, r[1].s4);
            Assert.AreEqual(  62, r[1].s5);
            Assert.AreEqual(  51, r[1].s6);
            Assert.AreEqual(  56, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_or");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_or");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(  59, r[0].s4);
            Assert.AreEqual(  62, r[0].s5);
            Assert.AreEqual(  51, r[0].s6);
            Assert.AreEqual(  56, r[0].s7);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);
            Assert.AreEqual(  59, r[1].s4);
            Assert.AreEqual(  62, r[1].s5);
            Assert.AreEqual(  51, r[1].s6);
            Assert.AreEqual(  56, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_xor([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXor()
        {
            sbyte8[] a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            sbyte8[] b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            sbyte8[] r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_xor,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  26, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  58, r[0].s4);
            Assert.AreEqual(  52, r[0].s5);
            Assert.AreEqual(  18, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);
            Assert.AreEqual(  58, r[1].s4);
            Assert.AreEqual(  52, r[1].s5);
            Assert.AreEqual(  18, r[1].s6);
            Assert.AreEqual(  16, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_xor");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<sbyte8>;
                var mb = null as Mem<sbyte8>;
                var mr = null as Mem<sbyte8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_sbyte8_xor");
                    ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<sbyte8>());
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
            Assert.AreEqual(  58, r[0].s4);
            Assert.AreEqual(  52, r[0].s5);
            Assert.AreEqual(  18, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);
            Assert.AreEqual(  58, r[1].s4);
            Assert.AreEqual(  52, r[1].s5);
            Assert.AreEqual(  18, r[1].s6);
            Assert.AreEqual(  16, r[1].s7);
        }

    }
}
