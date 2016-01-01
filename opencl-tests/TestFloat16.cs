using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestFloat16
    {
        [Kernel]
        private static void test_float16_add([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            float16[] a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            float16[] b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            float16[] r = new float16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],float16[]>)test_float16_add,
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
            Assert.AreEqual( 108.00000000, r[0].s8, 1e-7);
            Assert.AreEqual( 120.00000000, r[0].s9, 1e-7);
            Assert.AreEqual( 132.00000000, r[0].sa, 1e-7);
            Assert.AreEqual( 144.00000000, r[0].sb, 1e-7);
            Assert.AreEqual( 156.00000000, r[0].sc, 1e-7);
            Assert.AreEqual( 168.00000000, r[0].sd, 1e-7);
            Assert.AreEqual( 180.00000000, r[0].se, 1e-7);
            Assert.AreEqual( 192.00000000, r[0].sf, 1e-7);
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[1].s3, 1e-7);
            Assert.AreEqual(  60.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(  72.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(  84.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(  96.00000000, r[1].s7, 1e-7);
            Assert.AreEqual( 108.00000000, r[1].s8, 1e-7);
            Assert.AreEqual( 120.00000000, r[1].s9, 1e-7);
            Assert.AreEqual( 132.00000000, r[1].sa, 1e-7);
            Assert.AreEqual( 144.00000000, r[1].sb, 1e-7);
            Assert.AreEqual( 156.00000000, r[1].sc, 1e-7);
            Assert.AreEqual( 168.00000000, r[1].sd, 1e-7);
            Assert.AreEqual( 180.00000000, r[1].se, 1e-7);
            Assert.AreEqual( 192.00000000, r[1].sf, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<float16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_add");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float16>());
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
            Assert.AreEqual( 108.00000000, r[0].s8, 1e-7);
            Assert.AreEqual( 120.00000000, r[0].s9, 1e-7);
            Assert.AreEqual( 132.00000000, r[0].sa, 1e-7);
            Assert.AreEqual( 144.00000000, r[0].sb, 1e-7);
            Assert.AreEqual( 156.00000000, r[0].sc, 1e-7);
            Assert.AreEqual( 168.00000000, r[0].sd, 1e-7);
            Assert.AreEqual( 180.00000000, r[0].se, 1e-7);
            Assert.AreEqual( 192.00000000, r[0].sf, 1e-7);
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[1].s3, 1e-7);
            Assert.AreEqual(  60.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(  72.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(  84.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(  96.00000000, r[1].s7, 1e-7);
            Assert.AreEqual( 108.00000000, r[1].s8, 1e-7);
            Assert.AreEqual( 120.00000000, r[1].s9, 1e-7);
            Assert.AreEqual( 132.00000000, r[1].sa, 1e-7);
            Assert.AreEqual( 144.00000000, r[1].sb, 1e-7);
            Assert.AreEqual( 156.00000000, r[1].sc, 1e-7);
            Assert.AreEqual( 168.00000000, r[1].sd, 1e-7);
            Assert.AreEqual( 180.00000000, r[1].se, 1e-7);
            Assert.AreEqual( 192.00000000, r[1].sf, 1e-7);
        }

        [Kernel]
        private static void test_float16_sub([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            float16[] a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            float16[] b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            float16[] r = new float16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],float16[]>)test_float16_sub,
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
            Assert.AreEqual(  18.00000000, r[0].s8, 1e-7);
            Assert.AreEqual(  20.00000000, r[0].s9, 1e-7);
            Assert.AreEqual(  22.00000000, r[0].sa, 1e-7);
            Assert.AreEqual(  24.00000000, r[0].sb, 1e-7);
            Assert.AreEqual(  26.00000000, r[0].sc, 1e-7);
            Assert.AreEqual(  28.00000000, r[0].sd, 1e-7);
            Assert.AreEqual(  30.00000000, r[0].se, 1e-7);
            Assert.AreEqual(  32.00000000, r[0].sf, 1e-7);
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  -8.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( -10.00000000, r[1].s4, 1e-7);
            Assert.AreEqual( -12.00000000, r[1].s5, 1e-7);
            Assert.AreEqual( -14.00000000, r[1].s6, 1e-7);
            Assert.AreEqual( -16.00000000, r[1].s7, 1e-7);
            Assert.AreEqual( -18.00000000, r[1].s8, 1e-7);
            Assert.AreEqual( -20.00000000, r[1].s9, 1e-7);
            Assert.AreEqual( -22.00000000, r[1].sa, 1e-7);
            Assert.AreEqual( -24.00000000, r[1].sb, 1e-7);
            Assert.AreEqual( -26.00000000, r[1].sc, 1e-7);
            Assert.AreEqual( -28.00000000, r[1].sd, 1e-7);
            Assert.AreEqual( -30.00000000, r[1].se, 1e-7);
            Assert.AreEqual( -32.00000000, r[1].sf, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<float16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_sub");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float16>());
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
            Assert.AreEqual(  18.00000000, r[0].s8, 1e-7);
            Assert.AreEqual(  20.00000000, r[0].s9, 1e-7);
            Assert.AreEqual(  22.00000000, r[0].sa, 1e-7);
            Assert.AreEqual(  24.00000000, r[0].sb, 1e-7);
            Assert.AreEqual(  26.00000000, r[0].sc, 1e-7);
            Assert.AreEqual(  28.00000000, r[0].sd, 1e-7);
            Assert.AreEqual(  30.00000000, r[0].se, 1e-7);
            Assert.AreEqual(  32.00000000, r[0].sf, 1e-7);
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  -8.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( -10.00000000, r[1].s4, 1e-7);
            Assert.AreEqual( -12.00000000, r[1].s5, 1e-7);
            Assert.AreEqual( -14.00000000, r[1].s6, 1e-7);
            Assert.AreEqual( -16.00000000, r[1].s7, 1e-7);
            Assert.AreEqual( -18.00000000, r[1].s8, 1e-7);
            Assert.AreEqual( -20.00000000, r[1].s9, 1e-7);
            Assert.AreEqual( -22.00000000, r[1].sa, 1e-7);
            Assert.AreEqual( -24.00000000, r[1].sb, 1e-7);
            Assert.AreEqual( -26.00000000, r[1].sc, 1e-7);
            Assert.AreEqual( -28.00000000, r[1].sd, 1e-7);
            Assert.AreEqual( -30.00000000, r[1].se, 1e-7);
            Assert.AreEqual( -32.00000000, r[1].sf, 1e-7);
        }

        [Kernel]
        private static void test_float16_mul([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            float16[] a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            float16[] b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            float16[] r = new float16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],float16[]>)test_float16_mul,
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
            Assert.AreEqual(2835.00000000, r[0].s8, 1e-7);
            Assert.AreEqual(3500.00000000, r[0].s9, 1e-7);
            Assert.AreEqual(4235.00000000, r[0].sa, 1e-7);
            Assert.AreEqual(5040.00000000, r[0].sb, 1e-7);
            Assert.AreEqual(5915.00000000, r[0].sc, 1e-7);
            Assert.AreEqual(6860.00000000, r[0].sd, 1e-7);
            Assert.AreEqual(7875.00000000, r[0].se, 1e-7);
            Assert.AreEqual(8960.00000000, r[0].sf, 1e-7);
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( 875.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(1260.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(1715.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(2240.00000000, r[1].s7, 1e-7);
            Assert.AreEqual(2835.00000000, r[1].s8, 1e-7);
            Assert.AreEqual(3500.00000000, r[1].s9, 1e-7);
            Assert.AreEqual(4235.00000000, r[1].sa, 1e-7);
            Assert.AreEqual(5040.00000000, r[1].sb, 1e-7);
            Assert.AreEqual(5915.00000000, r[1].sc, 1e-7);
            Assert.AreEqual(6860.00000000, r[1].sd, 1e-7);
            Assert.AreEqual(7875.00000000, r[1].se, 1e-7);
            Assert.AreEqual(8960.00000000, r[1].sf, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<float16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_mul");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float16>());
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
            Assert.AreEqual(2835.00000000, r[0].s8, 1e-7);
            Assert.AreEqual(3500.00000000, r[0].s9, 1e-7);
            Assert.AreEqual(4235.00000000, r[0].sa, 1e-7);
            Assert.AreEqual(5040.00000000, r[0].sb, 1e-7);
            Assert.AreEqual(5915.00000000, r[0].sc, 1e-7);
            Assert.AreEqual(6860.00000000, r[0].sd, 1e-7);
            Assert.AreEqual(7875.00000000, r[0].se, 1e-7);
            Assert.AreEqual(8960.00000000, r[0].sf, 1e-7);
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[1].s3, 1e-7);
            Assert.AreEqual( 875.00000000, r[1].s4, 1e-7);
            Assert.AreEqual(1260.00000000, r[1].s5, 1e-7);
            Assert.AreEqual(1715.00000000, r[1].s6, 1e-7);
            Assert.AreEqual(2240.00000000, r[1].s7, 1e-7);
            Assert.AreEqual(2835.00000000, r[1].s8, 1e-7);
            Assert.AreEqual(3500.00000000, r[1].s9, 1e-7);
            Assert.AreEqual(4235.00000000, r[1].sa, 1e-7);
            Assert.AreEqual(5040.00000000, r[1].sb, 1e-7);
            Assert.AreEqual(5915.00000000, r[1].sc, 1e-7);
            Assert.AreEqual(6860.00000000, r[1].sd, 1e-7);
            Assert.AreEqual(7875.00000000, r[1].se, 1e-7);
            Assert.AreEqual(8960.00000000, r[1].sf, 1e-7);
        }

        [Kernel]
        private static void test_float16_div([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            float16[] a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            float16[] b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            float16[] r = new float16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],float16[]>)test_float16_div,
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
            Assert.AreEqual(   1.39999998, r[0].s8, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s9, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sa, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sb, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sc, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sd, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].se, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sf, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s3, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s4, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s5, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s6, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s7, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s8, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s9, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sa, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sb, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sc, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sd, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].se, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sf, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<float16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_div");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float16>());
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
            Assert.AreEqual(   1.39999998, r[0].s8, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s9, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sa, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sb, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sc, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sd, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].se, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].sf, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s3, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s4, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s5, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s6, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s7, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s8, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s9, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sa, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sb, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sc, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sd, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].se, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].sf, 1e-7);
        }

        [Kernel]
        private static void test_float16_eq([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            float16[] a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            float16[] b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            int16[] r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],int16[]>)test_float16_eq,
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
            Assert.AreEqual( 0, r[0].s8);
            Assert.AreEqual( 0, r[0].s9);
            Assert.AreEqual( 0, r[0].sa);
            Assert.AreEqual( 0, r[0].sb);
            Assert.AreEqual( 0, r[0].sc);
            Assert.AreEqual( 0, r[0].sd);
            Assert.AreEqual( 0, r[0].se);
            Assert.AreEqual(-1, r[0].sf);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
            Assert.AreEqual( 0, r[1].s8);
            Assert.AreEqual( 0, r[1].s9);
            Assert.AreEqual( 0, r[1].sa);
            Assert.AreEqual( 0, r[1].sb);
            Assert.AreEqual( 0, r[1].sc);
            Assert.AreEqual( 0, r[1].sd);
            Assert.AreEqual( 0, r[1].se);
            Assert.AreEqual(-1, r[1].sf);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<int16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_eq");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int16>());
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
            Assert.AreEqual( 0, r[0].s8);
            Assert.AreEqual( 0, r[0].s9);
            Assert.AreEqual( 0, r[0].sa);
            Assert.AreEqual( 0, r[0].sb);
            Assert.AreEqual( 0, r[0].sc);
            Assert.AreEqual( 0, r[0].sd);
            Assert.AreEqual( 0, r[0].se);
            Assert.AreEqual(-1, r[0].sf);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
            Assert.AreEqual( 0, r[1].s8);
            Assert.AreEqual( 0, r[1].s9);
            Assert.AreEqual( 0, r[1].sa);
            Assert.AreEqual( 0, r[1].sb);
            Assert.AreEqual( 0, r[1].sc);
            Assert.AreEqual( 0, r[1].sd);
            Assert.AreEqual( 0, r[1].se);
            Assert.AreEqual(-1, r[1].sf);
        }

        [Kernel]
        private static void test_float16_neq([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            float16[] a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            float16[] b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            int16[] r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],int16[]>)test_float16_neq,
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
            Assert.AreEqual(-1, r[0].s8);
            Assert.AreEqual(-1, r[0].s9);
            Assert.AreEqual(-1, r[0].sa);
            Assert.AreEqual(-1, r[0].sb);
            Assert.AreEqual(-1, r[0].sc);
            Assert.AreEqual(-1, r[0].sd);
            Assert.AreEqual(-1, r[0].se);
            Assert.AreEqual( 0, r[0].sf);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
            Assert.AreEqual(-1, r[1].s8);
            Assert.AreEqual(-1, r[1].s9);
            Assert.AreEqual(-1, r[1].sa);
            Assert.AreEqual(-1, r[1].sb);
            Assert.AreEqual(-1, r[1].sc);
            Assert.AreEqual(-1, r[1].sd);
            Assert.AreEqual(-1, r[1].se);
            Assert.AreEqual( 0, r[1].sf);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<int16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_neq");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int16>());
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
            Assert.AreEqual(-1, r[0].s8);
            Assert.AreEqual(-1, r[0].s9);
            Assert.AreEqual(-1, r[0].sa);
            Assert.AreEqual(-1, r[0].sb);
            Assert.AreEqual(-1, r[0].sc);
            Assert.AreEqual(-1, r[0].sd);
            Assert.AreEqual(-1, r[0].se);
            Assert.AreEqual( 0, r[0].sf);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
            Assert.AreEqual(-1, r[1].s8);
            Assert.AreEqual(-1, r[1].s9);
            Assert.AreEqual(-1, r[1].sa);
            Assert.AreEqual(-1, r[1].sb);
            Assert.AreEqual(-1, r[1].sc);
            Assert.AreEqual(-1, r[1].sd);
            Assert.AreEqual(-1, r[1].se);
            Assert.AreEqual( 0, r[1].sf);
        }

        [Kernel]
        private static void test_float16_lt([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            float16[] a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            float16[] b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            int16[] r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],int16[]>)test_float16_lt,
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
            Assert.AreEqual( 0, r[0].s8);
            Assert.AreEqual( 0, r[0].s9);
            Assert.AreEqual( 0, r[0].sa);
            Assert.AreEqual( 0, r[0].sb);
            Assert.AreEqual( 0, r[0].sc);
            Assert.AreEqual( 0, r[0].sd);
            Assert.AreEqual( 0, r[0].se);
            Assert.AreEqual( 0, r[0].sf);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
            Assert.AreEqual(-1, r[1].s8);
            Assert.AreEqual(-1, r[1].s9);
            Assert.AreEqual(-1, r[1].sa);
            Assert.AreEqual(-1, r[1].sb);
            Assert.AreEqual(-1, r[1].sc);
            Assert.AreEqual(-1, r[1].sd);
            Assert.AreEqual(-1, r[1].se);
            Assert.AreEqual( 0, r[1].sf);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<int16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_lt");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int16>());
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
            Assert.AreEqual( 0, r[0].s8);
            Assert.AreEqual( 0, r[0].s9);
            Assert.AreEqual( 0, r[0].sa);
            Assert.AreEqual( 0, r[0].sb);
            Assert.AreEqual( 0, r[0].sc);
            Assert.AreEqual( 0, r[0].sd);
            Assert.AreEqual( 0, r[0].se);
            Assert.AreEqual( 0, r[0].sf);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
            Assert.AreEqual(-1, r[1].s8);
            Assert.AreEqual(-1, r[1].s9);
            Assert.AreEqual(-1, r[1].sa);
            Assert.AreEqual(-1, r[1].sb);
            Assert.AreEqual(-1, r[1].sc);
            Assert.AreEqual(-1, r[1].sd);
            Assert.AreEqual(-1, r[1].se);
            Assert.AreEqual( 0, r[1].sf);
        }

        [Kernel]
        private static void test_float16_le([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            float16[] a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            float16[] b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            int16[] r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],int16[]>)test_float16_le,
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
            Assert.AreEqual( 0, r[0].s8);
            Assert.AreEqual( 0, r[0].s9);
            Assert.AreEqual( 0, r[0].sa);
            Assert.AreEqual( 0, r[0].sb);
            Assert.AreEqual( 0, r[0].sc);
            Assert.AreEqual( 0, r[0].sd);
            Assert.AreEqual( 0, r[0].se);
            Assert.AreEqual(-1, r[0].sf);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
            Assert.AreEqual(-1, r[1].s8);
            Assert.AreEqual(-1, r[1].s9);
            Assert.AreEqual(-1, r[1].sa);
            Assert.AreEqual(-1, r[1].sb);
            Assert.AreEqual(-1, r[1].sc);
            Assert.AreEqual(-1, r[1].sd);
            Assert.AreEqual(-1, r[1].se);
            Assert.AreEqual(-1, r[1].sf);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<int16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_le");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int16>());
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
            Assert.AreEqual( 0, r[0].s8);
            Assert.AreEqual( 0, r[0].s9);
            Assert.AreEqual( 0, r[0].sa);
            Assert.AreEqual( 0, r[0].sb);
            Assert.AreEqual( 0, r[0].sc);
            Assert.AreEqual( 0, r[0].sd);
            Assert.AreEqual( 0, r[0].se);
            Assert.AreEqual(-1, r[0].sf);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
            Assert.AreEqual(-1, r[1].s8);
            Assert.AreEqual(-1, r[1].s9);
            Assert.AreEqual(-1, r[1].sa);
            Assert.AreEqual(-1, r[1].sb);
            Assert.AreEqual(-1, r[1].sc);
            Assert.AreEqual(-1, r[1].sd);
            Assert.AreEqual(-1, r[1].se);
            Assert.AreEqual(-1, r[1].sf);
        }

        [Kernel]
        private static void test_float16_gt([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            float16[] a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            float16[] b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            int16[] r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],int16[]>)test_float16_gt,
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
            Assert.AreEqual(-1, r[0].s8);
            Assert.AreEqual(-1, r[0].s9);
            Assert.AreEqual(-1, r[0].sa);
            Assert.AreEqual(-1, r[0].sb);
            Assert.AreEqual(-1, r[0].sc);
            Assert.AreEqual(-1, r[0].sd);
            Assert.AreEqual(-1, r[0].se);
            Assert.AreEqual( 0, r[0].sf);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
            Assert.AreEqual( 0, r[1].s8);
            Assert.AreEqual( 0, r[1].s9);
            Assert.AreEqual( 0, r[1].sa);
            Assert.AreEqual( 0, r[1].sb);
            Assert.AreEqual( 0, r[1].sc);
            Assert.AreEqual( 0, r[1].sd);
            Assert.AreEqual( 0, r[1].se);
            Assert.AreEqual( 0, r[1].sf);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<int16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_gt");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int16>());
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
            Assert.AreEqual(-1, r[0].s8);
            Assert.AreEqual(-1, r[0].s9);
            Assert.AreEqual(-1, r[0].sa);
            Assert.AreEqual(-1, r[0].sb);
            Assert.AreEqual(-1, r[0].sc);
            Assert.AreEqual(-1, r[0].sd);
            Assert.AreEqual(-1, r[0].se);
            Assert.AreEqual( 0, r[0].sf);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
            Assert.AreEqual( 0, r[1].s8);
            Assert.AreEqual( 0, r[1].s9);
            Assert.AreEqual( 0, r[1].sa);
            Assert.AreEqual( 0, r[1].sb);
            Assert.AreEqual( 0, r[1].sc);
            Assert.AreEqual( 0, r[1].sd);
            Assert.AreEqual( 0, r[1].se);
            Assert.AreEqual( 0, r[1].sf);
        }

        [Kernel]
        private static void test_float16_ge([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            float16[] a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            float16[] b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            int16[] r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float16[],float16[],int16[]>)test_float16_ge,
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
            Assert.AreEqual(-1, r[0].s8);
            Assert.AreEqual(-1, r[0].s9);
            Assert.AreEqual(-1, r[0].sa);
            Assert.AreEqual(-1, r[0].sb);
            Assert.AreEqual(-1, r[0].sc);
            Assert.AreEqual(-1, r[0].sd);
            Assert.AreEqual(-1, r[0].se);
            Assert.AreEqual(-1, r[0].sf);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
            Assert.AreEqual( 0, r[1].s8);
            Assert.AreEqual( 0, r[1].s9);
            Assert.AreEqual( 0, r[1].sa);
            Assert.AreEqual( 0, r[1].sb);
            Assert.AreEqual( 0, r[1].sc);
            Assert.AreEqual( 0, r[1].sd);
            Assert.AreEqual( 0, r[1].se);
            Assert.AreEqual(-1, r[1].sf);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat16", "test_float16_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float16>;
                var mb = null as Mem<float16>;
                var mr = null as Mem<int16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float16_ge");
                    ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int16>());
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
            Assert.AreEqual(-1, r[0].s8);
            Assert.AreEqual(-1, r[0].s9);
            Assert.AreEqual(-1, r[0].sa);
            Assert.AreEqual(-1, r[0].sb);
            Assert.AreEqual(-1, r[0].sc);
            Assert.AreEqual(-1, r[0].sd);
            Assert.AreEqual(-1, r[0].se);
            Assert.AreEqual(-1, r[0].sf);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
            Assert.AreEqual( 0, r[1].s8);
            Assert.AreEqual( 0, r[1].s9);
            Assert.AreEqual( 0, r[1].sa);
            Assert.AreEqual( 0, r[1].sb);
            Assert.AreEqual( 0, r[1].sc);
            Assert.AreEqual( 0, r[1].sd);
            Assert.AreEqual( 0, r[1].se);
            Assert.AreEqual(-1, r[1].sf);
        }

    }
}
