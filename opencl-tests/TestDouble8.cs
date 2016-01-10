using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestDouble8
    {
        [Kernel]
        private static void test_double8_add([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            double8[] a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            double8[] b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            double8[] r = new double8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],double8[]>)test_double8_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(  48.0000000000000000, r[0].s3, 1e-15);
            Assert.AreEqual(  60.0000000000000000, r[0].s4, 1e-15);
            Assert.AreEqual(  72.0000000000000000, r[0].s5, 1e-15);
            Assert.AreEqual(  84.0000000000000000, r[0].s6, 1e-15);
            Assert.AreEqual(  96.0000000000000000, r[0].s7, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  48.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual(  60.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(  72.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(  84.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(  96.0000000000000000, r[1].s7, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<double8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_add");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double8>());
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
            Assert.AreEqual(  48.0000000000000000, r[0].s3, 1e-15);
            Assert.AreEqual(  60.0000000000000000, r[0].s4, 1e-15);
            Assert.AreEqual(  72.0000000000000000, r[0].s5, 1e-15);
            Assert.AreEqual(  84.0000000000000000, r[0].s6, 1e-15);
            Assert.AreEqual(  96.0000000000000000, r[0].s7, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  48.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual(  60.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(  72.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(  84.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(  96.0000000000000000, r[1].s7, 1e-15);
        }

        [Kernel]
        private static void test_double8_sub([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            double8[] a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            double8[] b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            double8[] r = new double8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],double8[]>)test_double8_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual(   4.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual(   6.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual(   8.0000000000000000, r[0].s3, 1e-15);
            Assert.AreEqual(  10.0000000000000000, r[0].s4, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[0].s5, 1e-15);
            Assert.AreEqual(  14.0000000000000000, r[0].s6, 1e-15);
            Assert.AreEqual(  16.0000000000000000, r[0].s7, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  -8.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( -10.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual( -12.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual( -14.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual( -16.0000000000000000, r[1].s7, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<double8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_sub");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double8>());
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
            Assert.AreEqual(   8.0000000000000000, r[0].s3, 1e-15);
            Assert.AreEqual(  10.0000000000000000, r[0].s4, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[0].s5, 1e-15);
            Assert.AreEqual(  14.0000000000000000, r[0].s6, 1e-15);
            Assert.AreEqual(  16.0000000000000000, r[0].s7, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  -8.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( -10.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual( -12.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual( -14.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual( -16.0000000000000000, r[1].s7, 1e-15);
        }

        [Kernel]
        private static void test_double8_mul([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            double8[] a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            double8[] b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            double8[] r = new double8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],double8[]>)test_double8_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35.0000000000000000, r[0].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[0].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[0].s2, 1e-15);
            Assert.AreEqual( 560.0000000000000000, r[0].s3, 1e-15);
            Assert.AreEqual( 875.0000000000000000, r[0].s4, 1e-15);
            Assert.AreEqual(1260.0000000000000000, r[0].s5, 1e-15);
            Assert.AreEqual(1715.0000000000000000, r[0].s6, 1e-15);
            Assert.AreEqual(2240.0000000000000000, r[0].s7, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual( 560.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( 875.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(1260.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(1715.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(2240.0000000000000000, r[1].s7, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<double8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_mul");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double8>());
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
            Assert.AreEqual( 560.0000000000000000, r[0].s3, 1e-15);
            Assert.AreEqual( 875.0000000000000000, r[0].s4, 1e-15);
            Assert.AreEqual(1260.0000000000000000, r[0].s5, 1e-15);
            Assert.AreEqual(1715.0000000000000000, r[0].s6, 1e-15);
            Assert.AreEqual(2240.0000000000000000, r[0].s7, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual( 560.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( 875.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(1260.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(1715.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(2240.0000000000000000, r[1].s7, 1e-15);
        }

        [Kernel]
        private static void test_double8_div([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            double8[] a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            double8[] b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            double8[] r = new double8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],double8[]>)test_double8_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1.3999999999999999, r[0].s0, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s1, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s2, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s3, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s4, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s5, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s6, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s7, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s3, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s4, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s5, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s6, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s7, 1e-15);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<double8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_div");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double8>());
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
            Assert.AreEqual(   1.3999999999999999, r[0].s3, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s4, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s5, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s6, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s7, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s3, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s4, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s5, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s6, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s7, 1e-15);
        }

        [Kernel]
        private static void test_double8_eq([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            double8[] a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            double8[] b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            long8[] r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],long8[]>)test_double8_eq,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<long8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_eq");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long8>());
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
        private static void test_double8_neq([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            double8[] a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            double8[] b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            long8[] r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],long8[]>)test_double8_neq,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<long8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_neq");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long8>());
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
        private static void test_double8_lt([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            double8[] a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            double8[] b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            long8[] r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],long8[]>)test_double8_lt,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<long8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_lt");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long8>());
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
        private static void test_double8_le([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            double8[] a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            double8[] b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            long8[] r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],long8[]>)test_double8_le,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<long8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_le");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long8>());
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
        private static void test_double8_gt([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            double8[] a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            double8[] b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            long8[] r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],long8[]>)test_double8_gt,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<long8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_gt");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long8>());
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
        private static void test_double8_ge([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            double8[] a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            double8[] b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            long8[] r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double8[],double8[],long8[]>)test_double8_ge,
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
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestDouble8", "test_double8_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double8>;
                var mb = null as Mem<double8>;
                var mr = null as Mem<long8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double8_ge");
                    ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long8>());
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
