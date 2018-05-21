
//
// GENERATED SOURCE FILE -- DO NOT MODIFY
//

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
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

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
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[0].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[0].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[0].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[0].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[0].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[0].s7, 9.6000000000000007e-14);
            Assert.AreEqual(1.0800000000000000e+02, r[0].s8, 1.0800000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+02, r[0].s9, 1.2000000000000002e-13);
            Assert.AreEqual(1.3200000000000000e+02, r[0].sa, 1.3200000000000002e-13);
            Assert.AreEqual(1.4400000000000000e+02, r[0].sb, 1.4400000000000002e-13);
            Assert.AreEqual(1.5600000000000000e+02, r[0].sc, 1.5600000000000002e-13);
            Assert.AreEqual(1.6800000000000000e+02, r[0].sd, 1.6800000000000002e-13);
            Assert.AreEqual(1.8000000000000000e+02, r[0].se, 1.8000000000000002e-13);
            Assert.AreEqual(1.9200000000000000e+02, r[0].sf, 1.9200000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[1].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[1].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[1].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[1].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[1].s7, 9.6000000000000007e-14);
            Assert.AreEqual(1.0800000000000000e+02, r[1].s8, 1.0800000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+02, r[1].s9, 1.2000000000000002e-13);
            Assert.AreEqual(1.3200000000000000e+02, r[1].sa, 1.3200000000000002e-13);
            Assert.AreEqual(1.4400000000000000e+02, r[1].sb, 1.4400000000000002e-13);
            Assert.AreEqual(1.5600000000000000e+02, r[1].sc, 1.5600000000000002e-13);
            Assert.AreEqual(1.6800000000000000e+02, r[1].sd, 1.6800000000000002e-13);
            Assert.AreEqual(1.8000000000000000e+02, r[1].se, 1.8000000000000002e-13);
            Assert.AreEqual(1.9200000000000000e+02, r[1].sf, 1.9200000000000001e-13);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_add"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[0].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[0].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[0].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[0].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[0].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[0].s7, 9.6000000000000007e-14);
            Assert.AreEqual(1.0800000000000000e+02, r[0].s8, 1.0800000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+02, r[0].s9, 1.2000000000000002e-13);
            Assert.AreEqual(1.3200000000000000e+02, r[0].sa, 1.3200000000000002e-13);
            Assert.AreEqual(1.4400000000000000e+02, r[0].sb, 1.4400000000000002e-13);
            Assert.AreEqual(1.5600000000000000e+02, r[0].sc, 1.5600000000000002e-13);
            Assert.AreEqual(1.6800000000000000e+02, r[0].sd, 1.6800000000000002e-13);
            Assert.AreEqual(1.8000000000000000e+02, r[0].se, 1.8000000000000002e-13);
            Assert.AreEqual(1.9200000000000000e+02, r[0].sf, 1.9200000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[1].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[1].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[1].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[1].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[1].s7, 9.6000000000000007e-14);
            Assert.AreEqual(1.0800000000000000e+02, r[1].s8, 1.0800000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+02, r[1].s9, 1.2000000000000002e-13);
            Assert.AreEqual(1.3200000000000000e+02, r[1].sa, 1.3200000000000002e-13);
            Assert.AreEqual(1.4400000000000000e+02, r[1].sb, 1.4400000000000002e-13);
            Assert.AreEqual(1.5600000000000000e+02, r[1].sc, 1.5600000000000002e-13);
            Assert.AreEqual(1.6800000000000000e+02, r[1].sd, 1.6800000000000002e-13);
            Assert.AreEqual(1.8000000000000000e+02, r[1].se, 1.8000000000000002e-13);
            Assert.AreEqual(1.9200000000000000e+02, r[1].sf, 1.9200000000000001e-13);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_add"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[0].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[0].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[0].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[0].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[0].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[0].s7, 9.6000000000000007e-14);
            Assert.AreEqual(1.0800000000000000e+02, r[0].s8, 1.0800000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+02, r[0].s9, 1.2000000000000002e-13);
            Assert.AreEqual(1.3200000000000000e+02, r[0].sa, 1.3200000000000002e-13);
            Assert.AreEqual(1.4400000000000000e+02, r[0].sb, 1.4400000000000002e-13);
            Assert.AreEqual(1.5600000000000000e+02, r[0].sc, 1.5600000000000002e-13);
            Assert.AreEqual(1.6800000000000000e+02, r[0].sd, 1.6800000000000002e-13);
            Assert.AreEqual(1.8000000000000000e+02, r[0].se, 1.8000000000000002e-13);
            Assert.AreEqual(1.9200000000000000e+02, r[0].sf, 1.9200000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[1].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[1].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[1].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[1].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[1].s7, 9.6000000000000007e-14);
            Assert.AreEqual(1.0800000000000000e+02, r[1].s8, 1.0800000000000001e-13);
            Assert.AreEqual(1.2000000000000000e+02, r[1].s9, 1.2000000000000002e-13);
            Assert.AreEqual(1.3200000000000000e+02, r[1].sa, 1.3200000000000002e-13);
            Assert.AreEqual(1.4400000000000000e+02, r[1].sb, 1.4400000000000002e-13);
            Assert.AreEqual(1.5600000000000000e+02, r[1].sc, 1.5600000000000002e-13);
            Assert.AreEqual(1.6800000000000000e+02, r[1].sd, 1.6800000000000002e-13);
            Assert.AreEqual(1.8000000000000000e+02, r[1].se, 1.8000000000000002e-13);
            Assert.AreEqual(1.9200000000000000e+02, r[1].sf, 1.9200000000000001e-13);
        }

        [Kernel]
        private static void test_double16_sub([Global] double16[] a, [Global] double16[] b, [Global] double16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

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
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(6.0000000000000000e+00, r[0].s2, 6.0000000000000005e-15);
            Assert.AreEqual(8.0000000000000000e+00, r[0].s3, 8.0000000000000006e-15);
            Assert.AreEqual(1.0000000000000000e+01, r[0].s4, 1.0000000000000002e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[0].s5, 1.2000000000000001e-14);
            Assert.AreEqual(1.4000000000000000e+01, r[0].s6, 1.4000000000000000e-14);
            Assert.AreEqual(1.6000000000000000e+01, r[0].s7, 1.6000000000000001e-14);
            Assert.AreEqual(1.8000000000000000e+01, r[0].s8, 1.8000000000000002e-14);
            Assert.AreEqual(2.0000000000000000e+01, r[0].s9, 2.0000000000000003e-14);
            Assert.AreEqual(2.2000000000000000e+01, r[0].sa, 2.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].sb, 2.4000000000000002e-14);
            Assert.AreEqual(2.6000000000000000e+01, r[0].sc, 2.6000000000000003e-14);
            Assert.AreEqual(2.8000000000000000e+01, r[0].sd, 2.8000000000000001e-14);
            Assert.AreEqual(3.0000000000000000e+01, r[0].se, 3.0000000000000005e-14);
            Assert.AreEqual(3.2000000000000000e+01, r[0].sf, 3.2000000000000002e-14);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-8.0000000000000000e+00, r[1].s3, 8.0000000000000006e-15);
            Assert.AreEqual(-1.0000000000000000e+01, r[1].s4, 1.0000000000000002e-14);
            Assert.AreEqual(-1.2000000000000000e+01, r[1].s5, 1.2000000000000001e-14);
            Assert.AreEqual(-1.4000000000000000e+01, r[1].s6, 1.4000000000000000e-14);
            Assert.AreEqual(-1.6000000000000000e+01, r[1].s7, 1.6000000000000001e-14);
            Assert.AreEqual(-1.8000000000000000e+01, r[1].s8, 1.8000000000000002e-14);
            Assert.AreEqual(-2.0000000000000000e+01, r[1].s9, 2.0000000000000003e-14);
            Assert.AreEqual(-2.2000000000000000e+01, r[1].sa, 2.2000000000000001e-14);
            Assert.AreEqual(-2.4000000000000000e+01, r[1].sb, 2.4000000000000002e-14);
            Assert.AreEqual(-2.6000000000000000e+01, r[1].sc, 2.6000000000000003e-14);
            Assert.AreEqual(-2.8000000000000000e+01, r[1].sd, 2.8000000000000001e-14);
            Assert.AreEqual(-3.0000000000000000e+01, r[1].se, 3.0000000000000005e-14);
            Assert.AreEqual(-3.2000000000000000e+01, r[1].sf, 3.2000000000000002e-14);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_sub"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(6.0000000000000000e+00, r[0].s2, 6.0000000000000005e-15);
            Assert.AreEqual(8.0000000000000000e+00, r[0].s3, 8.0000000000000006e-15);
            Assert.AreEqual(1.0000000000000000e+01, r[0].s4, 1.0000000000000002e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[0].s5, 1.2000000000000001e-14);
            Assert.AreEqual(1.4000000000000000e+01, r[0].s6, 1.4000000000000000e-14);
            Assert.AreEqual(1.6000000000000000e+01, r[0].s7, 1.6000000000000001e-14);
            Assert.AreEqual(1.8000000000000000e+01, r[0].s8, 1.8000000000000002e-14);
            Assert.AreEqual(2.0000000000000000e+01, r[0].s9, 2.0000000000000003e-14);
            Assert.AreEqual(2.2000000000000000e+01, r[0].sa, 2.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].sb, 2.4000000000000002e-14);
            Assert.AreEqual(2.6000000000000000e+01, r[0].sc, 2.6000000000000003e-14);
            Assert.AreEqual(2.8000000000000000e+01, r[0].sd, 2.8000000000000001e-14);
            Assert.AreEqual(3.0000000000000000e+01, r[0].se, 3.0000000000000005e-14);
            Assert.AreEqual(3.2000000000000000e+01, r[0].sf, 3.2000000000000002e-14);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-8.0000000000000000e+00, r[1].s3, 8.0000000000000006e-15);
            Assert.AreEqual(-1.0000000000000000e+01, r[1].s4, 1.0000000000000002e-14);
            Assert.AreEqual(-1.2000000000000000e+01, r[1].s5, 1.2000000000000001e-14);
            Assert.AreEqual(-1.4000000000000000e+01, r[1].s6, 1.4000000000000000e-14);
            Assert.AreEqual(-1.6000000000000000e+01, r[1].s7, 1.6000000000000001e-14);
            Assert.AreEqual(-1.8000000000000000e+01, r[1].s8, 1.8000000000000002e-14);
            Assert.AreEqual(-2.0000000000000000e+01, r[1].s9, 2.0000000000000003e-14);
            Assert.AreEqual(-2.2000000000000000e+01, r[1].sa, 2.2000000000000001e-14);
            Assert.AreEqual(-2.4000000000000000e+01, r[1].sb, 2.4000000000000002e-14);
            Assert.AreEqual(-2.6000000000000000e+01, r[1].sc, 2.6000000000000003e-14);
            Assert.AreEqual(-2.8000000000000000e+01, r[1].sd, 2.8000000000000001e-14);
            Assert.AreEqual(-3.0000000000000000e+01, r[1].se, 3.0000000000000005e-14);
            Assert.AreEqual(-3.2000000000000000e+01, r[1].sf, 3.2000000000000002e-14);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_sub"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(6.0000000000000000e+00, r[0].s2, 6.0000000000000005e-15);
            Assert.AreEqual(8.0000000000000000e+00, r[0].s3, 8.0000000000000006e-15);
            Assert.AreEqual(1.0000000000000000e+01, r[0].s4, 1.0000000000000002e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[0].s5, 1.2000000000000001e-14);
            Assert.AreEqual(1.4000000000000000e+01, r[0].s6, 1.4000000000000000e-14);
            Assert.AreEqual(1.6000000000000000e+01, r[0].s7, 1.6000000000000001e-14);
            Assert.AreEqual(1.8000000000000000e+01, r[0].s8, 1.8000000000000002e-14);
            Assert.AreEqual(2.0000000000000000e+01, r[0].s9, 2.0000000000000003e-14);
            Assert.AreEqual(2.2000000000000000e+01, r[0].sa, 2.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].sb, 2.4000000000000002e-14);
            Assert.AreEqual(2.6000000000000000e+01, r[0].sc, 2.6000000000000003e-14);
            Assert.AreEqual(2.8000000000000000e+01, r[0].sd, 2.8000000000000001e-14);
            Assert.AreEqual(3.0000000000000000e+01, r[0].se, 3.0000000000000005e-14);
            Assert.AreEqual(3.2000000000000000e+01, r[0].sf, 3.2000000000000002e-14);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-8.0000000000000000e+00, r[1].s3, 8.0000000000000006e-15);
            Assert.AreEqual(-1.0000000000000000e+01, r[1].s4, 1.0000000000000002e-14);
            Assert.AreEqual(-1.2000000000000000e+01, r[1].s5, 1.2000000000000001e-14);
            Assert.AreEqual(-1.4000000000000000e+01, r[1].s6, 1.4000000000000000e-14);
            Assert.AreEqual(-1.6000000000000000e+01, r[1].s7, 1.6000000000000001e-14);
            Assert.AreEqual(-1.8000000000000000e+01, r[1].s8, 1.8000000000000002e-14);
            Assert.AreEqual(-2.0000000000000000e+01, r[1].s9, 2.0000000000000003e-14);
            Assert.AreEqual(-2.2000000000000000e+01, r[1].sa, 2.2000000000000001e-14);
            Assert.AreEqual(-2.4000000000000000e+01, r[1].sb, 2.4000000000000002e-14);
            Assert.AreEqual(-2.6000000000000000e+01, r[1].sc, 2.6000000000000003e-14);
            Assert.AreEqual(-2.8000000000000000e+01, r[1].sd, 2.8000000000000001e-14);
            Assert.AreEqual(-3.0000000000000000e+01, r[1].se, 3.0000000000000005e-14);
            Assert.AreEqual(-3.2000000000000000e+01, r[1].sf, 3.2000000000000002e-14);
        }

        [Kernel]
        private static void test_double16_mul([Global] double16[] a, [Global] double16[] b, [Global] double16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

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
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[0].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[0].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[0].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[0].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[0].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[0].s7, 2.2400000000000001e-12);
            Assert.AreEqual(2.8350000000000000e+03, r[0].s8, 2.8350000000000003e-12);
            Assert.AreEqual(3.5000000000000000e+03, r[0].s9, 3.5000000000000004e-12);
            Assert.AreEqual(4.2350000000000000e+03, r[0].sa, 4.2350000000000004e-12);
            Assert.AreEqual(5.0400000000000000e+03, r[0].sb, 5.0400000000000003e-12);
            Assert.AreEqual(5.9150000000000000e+03, r[0].sc, 5.9150000000000005e-12);
            Assert.AreEqual(6.8600000000000000e+03, r[0].sd, 6.8600000000000003e-12);
            Assert.AreEqual(7.8750000000000000e+03, r[0].se, 7.8750000000000003e-12);
            Assert.AreEqual(8.9600000000000000e+03, r[0].sf, 8.9600000000000006e-12);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[1].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[1].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[1].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[1].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[1].s7, 2.2400000000000001e-12);
            Assert.AreEqual(2.8350000000000000e+03, r[1].s8, 2.8350000000000003e-12);
            Assert.AreEqual(3.5000000000000000e+03, r[1].s9, 3.5000000000000004e-12);
            Assert.AreEqual(4.2350000000000000e+03, r[1].sa, 4.2350000000000004e-12);
            Assert.AreEqual(5.0400000000000000e+03, r[1].sb, 5.0400000000000003e-12);
            Assert.AreEqual(5.9150000000000000e+03, r[1].sc, 5.9150000000000005e-12);
            Assert.AreEqual(6.8600000000000000e+03, r[1].sd, 6.8600000000000003e-12);
            Assert.AreEqual(7.8750000000000000e+03, r[1].se, 7.8750000000000003e-12);
            Assert.AreEqual(8.9600000000000000e+03, r[1].sf, 8.9600000000000006e-12);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_mul"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[0].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[0].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[0].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[0].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[0].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[0].s7, 2.2400000000000001e-12);
            Assert.AreEqual(2.8350000000000000e+03, r[0].s8, 2.8350000000000003e-12);
            Assert.AreEqual(3.5000000000000000e+03, r[0].s9, 3.5000000000000004e-12);
            Assert.AreEqual(4.2350000000000000e+03, r[0].sa, 4.2350000000000004e-12);
            Assert.AreEqual(5.0400000000000000e+03, r[0].sb, 5.0400000000000003e-12);
            Assert.AreEqual(5.9150000000000000e+03, r[0].sc, 5.9150000000000005e-12);
            Assert.AreEqual(6.8600000000000000e+03, r[0].sd, 6.8600000000000003e-12);
            Assert.AreEqual(7.8750000000000000e+03, r[0].se, 7.8750000000000003e-12);
            Assert.AreEqual(8.9600000000000000e+03, r[0].sf, 8.9600000000000006e-12);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[1].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[1].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[1].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[1].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[1].s7, 2.2400000000000001e-12);
            Assert.AreEqual(2.8350000000000000e+03, r[1].s8, 2.8350000000000003e-12);
            Assert.AreEqual(3.5000000000000000e+03, r[1].s9, 3.5000000000000004e-12);
            Assert.AreEqual(4.2350000000000000e+03, r[1].sa, 4.2350000000000004e-12);
            Assert.AreEqual(5.0400000000000000e+03, r[1].sb, 5.0400000000000003e-12);
            Assert.AreEqual(5.9150000000000000e+03, r[1].sc, 5.9150000000000005e-12);
            Assert.AreEqual(6.8600000000000000e+03, r[1].sd, 6.8600000000000003e-12);
            Assert.AreEqual(7.8750000000000000e+03, r[1].se, 7.8750000000000003e-12);
            Assert.AreEqual(8.9600000000000000e+03, r[1].sf, 8.9600000000000006e-12);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_mul"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[0].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[0].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[0].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[0].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[0].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[0].s7, 2.2400000000000001e-12);
            Assert.AreEqual(2.8350000000000000e+03, r[0].s8, 2.8350000000000003e-12);
            Assert.AreEqual(3.5000000000000000e+03, r[0].s9, 3.5000000000000004e-12);
            Assert.AreEqual(4.2350000000000000e+03, r[0].sa, 4.2350000000000004e-12);
            Assert.AreEqual(5.0400000000000000e+03, r[0].sb, 5.0400000000000003e-12);
            Assert.AreEqual(5.9150000000000000e+03, r[0].sc, 5.9150000000000005e-12);
            Assert.AreEqual(6.8600000000000000e+03, r[0].sd, 6.8600000000000003e-12);
            Assert.AreEqual(7.8750000000000000e+03, r[0].se, 7.8750000000000003e-12);
            Assert.AreEqual(8.9600000000000000e+03, r[0].sf, 8.9600000000000006e-12);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[1].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[1].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[1].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[1].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[1].s7, 2.2400000000000001e-12);
            Assert.AreEqual(2.8350000000000000e+03, r[1].s8, 2.8350000000000003e-12);
            Assert.AreEqual(3.5000000000000000e+03, r[1].s9, 3.5000000000000004e-12);
            Assert.AreEqual(4.2350000000000000e+03, r[1].sa, 4.2350000000000004e-12);
            Assert.AreEqual(5.0400000000000000e+03, r[1].sb, 5.0400000000000003e-12);
            Assert.AreEqual(5.9150000000000000e+03, r[1].sc, 5.9150000000000005e-12);
            Assert.AreEqual(6.8600000000000000e+03, r[1].sd, 6.8600000000000003e-12);
            Assert.AreEqual(7.8750000000000000e+03, r[1].se, 7.8750000000000003e-12);
            Assert.AreEqual(8.9600000000000000e+03, r[1].sf, 8.9600000000000006e-12);
        }

        [Kernel]
        private static void test_double16_div([Global] double16[] a, [Global] double16[] b, [Global] double16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

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
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s2, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s3, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s4, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s5, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s6, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s7, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s8, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s9, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sa, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sb, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sc, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sd, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].se, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sf, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s3, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s4, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s5, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s6, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s7, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s8, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s9, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sa, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sb, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sc, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sd, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].se, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sf, 7.1428571428571436e-16);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestDivCl()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_div"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s2, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s3, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s4, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s5, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s6, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s7, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s8, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s9, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sa, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sb, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sc, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sd, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].se, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sf, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s3, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s4, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s5, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s6, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s7, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s8, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s9, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sa, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sb, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sc, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sd, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].se, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sf, 7.1428571428571436e-16);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestDivSpirV()
        {
            var a = new double16[] { new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112), new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80) };
            var b = new double16[] { new double16((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40, (double)  45, (double)  50, (double)  55, (double)  60, (double)  65, (double)  70, (double)  75, (double)  80), new double16((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56, (double)  63, (double)  70, (double)  77, (double)  84, (double)  91, (double)  98, (double) 105, (double) 112) };
            var r = new double16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_div"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s2, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s3, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s4, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s5, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s6, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s7, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s8, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s9, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sa, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sb, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sc, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sd, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].se, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].sf, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s3, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s4, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s5, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s6, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s7, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s8, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s9, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sa, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sb, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sc, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sd, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].se, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].sf, 7.1428571428571436e-16);
        }

        [Kernel]
        private static void test_double16_eq([Global] double16[] a, [Global] double16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestEqCl()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_eq"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestEqSpirV()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_eq"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestNeqCl()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_neq"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestNeqSpirV()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_neq"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestLtCl()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_lt"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestLtSpirV()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_lt"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestLeCl()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_le"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestLeSpirV()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_le"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestGtCl()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_gt"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestGtSpirV()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_gt"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestGeCl()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_ge"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestGeSpirV()
        {
            var a = new double16[] { new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15), new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15) };
            var b = new double16[] { new double16((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7, (double)   8, (double)   9, (double)  10, (double)  11, (double)  12, (double)  13, (double)  14, (double)  15), new double16((double)  30, (double)  29, (double)  28, (double)  27, (double)  26, (double)  25, (double)  24, (double)  23, (double)  22, (double)  21, (double)  20, (double)  19, (double)  18, (double)  17, (double)  16, (double)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble16", "test_double16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double16_ge"))
            using (var ma = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
