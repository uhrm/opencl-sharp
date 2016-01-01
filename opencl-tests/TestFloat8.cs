using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestFloat8
    {
        [Kernel]
        private static void test_float8_add([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            float8[] a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            float8[] b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            float8[] r = new float8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],float8[]>)test_float8_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  60.00000000, r[0].s4, 1e-7);
            Assert.AreEqual(  72.00000000, r[0].s5, 1e-7);
            Assert.AreEqual(  84.00000000, r[0].s6, 1e-7);
            Assert.AreEqual(  96.00000000, r[0].s7, 1e-7);
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[1].s3, 1e-7);
            Assert.AreEqual(  60.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(  72.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(  84.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(  96.00000000, r[1].s7, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<float8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_add");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float8>());
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
            Assert.AreEqual(  12.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  60.00000000, r[0].s4, 1e-7);
            Assert.AreEqual(  72.00000000, r[0].s5, 1e-7);
            Assert.AreEqual(  84.00000000, r[0].s6, 1e-7);
            Assert.AreEqual(  96.00000000, r[0].s7, 1e-7);
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[1].s3, 1e-7);
            Assert.AreEqual(  60.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(  72.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(  84.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(  96.00000000, r[1].s7, 1e-7);
        }

        [Kernel]
        private static void test_float8_sub([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            float8[] a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            float8[] b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            float8[] r = new float8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],float8[]>)test_float8_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(   4.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(   6.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(   8.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  10.00000000, r[0].s4, 1e-7);
            Assert.AreEqual(  12.00000000, r[0].s5, 1e-7);
            Assert.AreEqual(  14.00000000, r[0].s6, 1e-7);
            Assert.AreEqual(  16.00000000, r[0].s7, 1e-7);
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  -8.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( -10.00000000, r[1].s4, 1e-7);
            Assert.AreEqual( -12.00000000, r[1].s5, 1e-7);
            Assert.AreEqual( -14.00000000, r[1].s6, 1e-7);
            Assert.AreEqual( -16.00000000, r[1].s7, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<float8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_sub");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float8>());
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
            Assert.AreEqual(   2.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(   4.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(   6.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(   8.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  10.00000000, r[0].s4, 1e-7);
            Assert.AreEqual(  12.00000000, r[0].s5, 1e-7);
            Assert.AreEqual(  14.00000000, r[0].s6, 1e-7);
            Assert.AreEqual(  16.00000000, r[0].s7, 1e-7);
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  -8.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( -10.00000000, r[1].s4, 1e-7);
            Assert.AreEqual( -12.00000000, r[1].s5, 1e-7);
            Assert.AreEqual( -14.00000000, r[1].s6, 1e-7);
            Assert.AreEqual( -16.00000000, r[1].s7, 1e-7);
        }

        [Kernel]
        private static void test_float8_mul([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            float8[] a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            float8[] b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            float8[] r = new float8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],float8[]>)test_float8_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35.00000000, r[0].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[0].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[0].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[0].s3, 1e-7);
            Assert.AreEqual( 875.00000000, r[0].s4, 1e-7);
            Assert.AreEqual(1260.00000000, r[0].s5, 1e-7);
            Assert.AreEqual(1715.00000000, r[0].s6, 1e-7);
            Assert.AreEqual(2240.00000000, r[0].s7, 1e-7);
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( 875.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(1260.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(1715.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(2240.00000000, r[1].s7, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<float8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_mul");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float8>());
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
            Assert.AreEqual(  35.00000000, r[0].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[0].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[0].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[0].s3, 1e-7);
            Assert.AreEqual( 875.00000000, r[0].s4, 1e-7);
            Assert.AreEqual(1260.00000000, r[0].s5, 1e-7);
            Assert.AreEqual(1715.00000000, r[0].s6, 1e-7);
            Assert.AreEqual(2240.00000000, r[0].s7, 1e-7);
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( 875.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(1260.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(1715.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(2240.00000000, r[1].s7, 1e-7);
        }

        [Kernel]
        private static void test_float8_div([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            float8[] a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            float8[] b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            float8[] r = new float8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],float8[]>)test_float8_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1.39999998, r[0].s0, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s1, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s2, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s3, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s4, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s5, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s6, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s7, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s3, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s4, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s5, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s6, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s7, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<float8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_div");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float8>());
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
            Assert.AreEqual(   1.39999998, r[0].s0, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s1, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s2, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s3, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s4, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s5, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s6, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s7, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s3, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s4, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s5, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s6, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s7, 1e-7);
        }

        [Kernel]
        private static void test_float8_eq([Global] float8[] a, [Global] float8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            float8[] a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            float8[] b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            int8[] r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],int8[]>)test_float8_eq,
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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<int8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_eq");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int8>());
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
        private static void test_float8_neq([Global] float8[] a, [Global] float8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            float8[] a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            float8[] b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            int8[] r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],int8[]>)test_float8_neq,
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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<int8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_neq");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int8>());
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
        private static void test_float8_lt([Global] float8[] a, [Global] float8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            float8[] a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            float8[] b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            int8[] r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],int8[]>)test_float8_lt,
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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<int8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_lt");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int8>());
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
        private static void test_float8_le([Global] float8[] a, [Global] float8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            float8[] a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            float8[] b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            int8[] r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],int8[]>)test_float8_le,
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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<int8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_le");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int8>());
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
        private static void test_float8_gt([Global] float8[] a, [Global] float8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            float8[] a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            float8[] b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            int8[] r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],int8[]>)test_float8_gt,
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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<int8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_gt");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int8>());
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
        private static void test_float8_ge([Global] float8[] a, [Global] float8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            float8[] a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            float8[] b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            int8[] r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float8[],float8[],int8[]>)test_float8_ge,
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
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat8", "test_float8_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float8>;
                var mb = null as Mem<float8>;
                var mr = null as Mem<int8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float8_ge");
                    ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int8>());
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

    }
}
