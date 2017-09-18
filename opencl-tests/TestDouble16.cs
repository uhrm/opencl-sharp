using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestDouble16
    {
        [Kernel]
        private static void test_double16_add([Global] double16[] a, [Global] double16[] b, [Global] double16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],double16[]>)test_double16_add,
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
            Assert.AreEqual( 108.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual( 120.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual( 132.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual( 144.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual( 156.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual( 168.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual( 180.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual( 192.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  48.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual(  60.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(  72.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(  84.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(  96.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual( 108.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual( 120.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual( 132.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual( 144.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual( 156.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual( 168.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual( 180.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual( 192.0000000000000000, r[1].sf, 1e-15);
        }

        [Test]
        public void TestAddCl()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_add");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_add");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual( 108.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual( 120.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual( 132.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual( 144.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual( 156.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual( 168.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual( 180.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual( 192.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  48.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual(  60.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(  72.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(  84.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(  96.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual( 108.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual( 120.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual( 132.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual( 144.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual( 156.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual( 168.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual( 180.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual( 192.0000000000000000, r[1].sf, 1e-15);
        }

        [Test]
        public void TestAddSpir()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_add", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double16_add");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual( 108.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual( 120.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual( 132.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual( 144.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual( 156.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual( 168.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual( 180.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual( 192.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  12.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  36.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  48.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual(  60.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(  72.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(  84.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(  96.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual( 108.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual( 120.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual( 132.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual( 144.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual( 156.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual( 168.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual( 180.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual( 192.0000000000000000, r[1].sf, 1e-15);
        }

        [Kernel]
        private static void test_double16_sub([Global] double16[] a, [Global] double16[] b, [Global] double16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],double16[]>)test_double16_sub,
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
            Assert.AreEqual(  18.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual(  20.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual(  22.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual(  26.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual(  28.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual(  30.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual(  32.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  -8.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( -10.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual( -12.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual( -14.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual( -16.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual( -18.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual( -20.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual( -22.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual( -24.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual( -26.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual( -28.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual( -30.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual( -32.0000000000000000, r[1].sf, 1e-15);
        }

        [Test]
        public void TestSubCl()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_sub");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_sub");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual(  18.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual(  20.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual(  22.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual(  26.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual(  28.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual(  30.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual(  32.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  -8.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( -10.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual( -12.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual( -14.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual( -16.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual( -18.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual( -20.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual( -22.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual( -24.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual( -26.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual( -28.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual( -30.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual( -32.0000000000000000, r[1].sf, 1e-15);
        }

        [Test]
        public void TestSubSpir()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_sub", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double16_sub");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual(  18.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual(  20.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual(  22.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual(  24.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual(  26.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual(  28.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual(  30.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual(  32.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  -2.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual(  -4.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual(  -6.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual(  -8.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( -10.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual( -12.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual( -14.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual( -16.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual( -18.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual( -20.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual( -22.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual( -24.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual( -26.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual( -28.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual( -30.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual( -32.0000000000000000, r[1].sf, 1e-15);
        }

        [Kernel]
        private static void test_double16_mul([Global] double16[] a, [Global] double16[] b, [Global] double16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],double16[]>)test_double16_mul,
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
            Assert.AreEqual(2835.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual(3500.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual(4235.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual(5040.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual(5915.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual(6860.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual(7875.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual(8960.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual( 560.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( 875.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(1260.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(1715.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(2240.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual(2835.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual(3500.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual(4235.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual(5040.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual(5915.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual(6860.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual(7875.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual(8960.0000000000000000, r[1].sf, 1e-15);
        }

        [Test]
        public void TestMulCl()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_mul");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_mul");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual(2835.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual(3500.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual(4235.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual(5040.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual(5915.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual(6860.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual(7875.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual(8960.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual( 560.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( 875.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(1260.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(1715.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(2240.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual(2835.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual(3500.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual(4235.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual(5040.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual(5915.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual(6860.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual(7875.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual(8960.0000000000000000, r[1].sf, 1e-15);
        }

        [Test]
        public void TestMulSpir()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_mul", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double16_mul");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual(2835.0000000000000000, r[0].s8, 1e-15);
            Assert.AreEqual(3500.0000000000000000, r[0].s9, 1e-15);
            Assert.AreEqual(4235.0000000000000000, r[0].sa, 1e-15);
            Assert.AreEqual(5040.0000000000000000, r[0].sb, 1e-15);
            Assert.AreEqual(5915.0000000000000000, r[0].sc, 1e-15);
            Assert.AreEqual(6860.0000000000000000, r[0].sd, 1e-15);
            Assert.AreEqual(7875.0000000000000000, r[0].se, 1e-15);
            Assert.AreEqual(8960.0000000000000000, r[0].sf, 1e-15);
            Assert.AreEqual(  35.0000000000000000, r[1].s0, 1e-15);
            Assert.AreEqual( 140.0000000000000000, r[1].s1, 1e-15);
            Assert.AreEqual( 315.0000000000000000, r[1].s2, 1e-15);
            Assert.AreEqual( 560.0000000000000000, r[1].s3, 1e-15);
            Assert.AreEqual( 875.0000000000000000, r[1].s4, 1e-15);
            Assert.AreEqual(1260.0000000000000000, r[1].s5, 1e-15);
            Assert.AreEqual(1715.0000000000000000, r[1].s6, 1e-15);
            Assert.AreEqual(2240.0000000000000000, r[1].s7, 1e-15);
            Assert.AreEqual(2835.0000000000000000, r[1].s8, 1e-15);
            Assert.AreEqual(3500.0000000000000000, r[1].s9, 1e-15);
            Assert.AreEqual(4235.0000000000000000, r[1].sa, 1e-15);
            Assert.AreEqual(5040.0000000000000000, r[1].sb, 1e-15);
            Assert.AreEqual(5915.0000000000000000, r[1].sc, 1e-15);
            Assert.AreEqual(6860.0000000000000000, r[1].sd, 1e-15);
            Assert.AreEqual(7875.0000000000000000, r[1].se, 1e-15);
            Assert.AreEqual(8960.0000000000000000, r[1].sf, 1e-15);
        }

        [Kernel]
        private static void test_double16_div([Global] double16[] a, [Global] double16[] b, [Global] double16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],double16[]>)test_double16_div,
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
            Assert.AreEqual(   1.3999999999999999, r[0].s8, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s9, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sa, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sb, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sc, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sd, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].se, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sf, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s3, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s4, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s5, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s6, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s7, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s8, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s9, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sa, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sb, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sc, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sd, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].se, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sf, 1e-15);
        }

        [Test]
        public void TestDivCl()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_div");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_div");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual(   1.3999999999999999, r[0].s8, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s9, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sa, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sb, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sc, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sd, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].se, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sf, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s3, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s4, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s5, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s6, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s7, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s8, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s9, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sa, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sb, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sc, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sd, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].se, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sf, 1e-15);
        }

        [Test]
        public void TestDivSpir()
        {
            double16[] a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            double16[] b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            double16[] r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_div", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<double16>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_double16_div");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<double16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<double16>());
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
            Assert.AreEqual(   1.3999999999999999, r[0].s8, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].s9, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sa, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sb, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sc, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sd, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].se, 1e-15);
            Assert.AreEqual(   1.3999999999999999, r[0].sf, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s0, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s1, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s2, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s3, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s4, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s5, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s6, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s7, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s8, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].s9, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sa, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sb, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sc, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sd, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].se, 1e-15);
            Assert.AreEqual(   0.7142857142857143, r[1].sf, 1e-15);
        }

        [Kernel]
        private static void test_double16_eq([Global] double16[] a, [Global] double16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            double16[] a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            double16[] b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            long16[] r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],long16[]>)test_double16_eq,
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
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<long16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_eq");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long16>());
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
        private static void test_double16_neq([Global] double16[] a, [Global] double16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            double16[] a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            double16[] b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            long16[] r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],long16[]>)test_double16_neq,
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
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<long16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_neq");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long16>());
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
        private static void test_double16_lt([Global] double16[] a, [Global] double16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            double16[] a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            double16[] b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            long16[] r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],long16[]>)test_double16_lt,
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
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<long16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_lt");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long16>());
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
        private static void test_double16_le([Global] double16[] a, [Global] double16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            double16[] a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            double16[] b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            long16[] r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],long16[]>)test_double16_le,
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
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<long16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_le");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long16>());
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
        private static void test_double16_gt([Global] double16[] a, [Global] double16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            double16[] a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            double16[] b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            long16[] r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],long16[]>)test_double16_gt,
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
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<long16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_gt");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long16>());
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
        private static void test_double16_ge([Global] double16[] a, [Global] double16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            double16[] a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            double16[] b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            long16[] r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double16[],double16[],long16[]>)test_double16_ge,
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
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<double16>;
                var mb = null as Mem<double16>;
                var mr = null as Mem<long16>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_double16_ge");
                    ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<long16>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<long16>());
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
