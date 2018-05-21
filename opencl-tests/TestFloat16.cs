
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
    public class TestFloat16
    {
        [Kernel]
        private static void test_float16_add([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

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
            Assert.AreEqual(1.20000000e+01, r[0].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[0].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[0].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[0].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[0].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[0].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[0].s7, 9.60000000e-06);
            Assert.AreEqual(1.08000000e+02, r[0].s8, 1.08000000e-05);
            Assert.AreEqual(1.20000000e+02, r[0].s9, 1.20000000e-05);
            Assert.AreEqual(1.32000000e+02, r[0].sa, 1.32000000e-05);
            Assert.AreEqual(1.44000000e+02, r[0].sb, 1.44000000e-05);
            Assert.AreEqual(1.56000000e+02, r[0].sc, 1.56000000e-05);
            Assert.AreEqual(1.68000000e+02, r[0].sd, 1.68000000e-05);
            Assert.AreEqual(1.80000000e+02, r[0].se, 1.80000000e-05);
            Assert.AreEqual(1.92000000e+02, r[0].sf, 1.92000000e-05);
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[1].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[1].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[1].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[1].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[1].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[1].s7, 9.60000000e-06);
            Assert.AreEqual(1.08000000e+02, r[1].s8, 1.08000000e-05);
            Assert.AreEqual(1.20000000e+02, r[1].s9, 1.20000000e-05);
            Assert.AreEqual(1.32000000e+02, r[1].sa, 1.32000000e-05);
            Assert.AreEqual(1.44000000e+02, r[1].sb, 1.44000000e-05);
            Assert.AreEqual(1.56000000e+02, r[1].sc, 1.56000000e-05);
            Assert.AreEqual(1.68000000e+02, r[1].sd, 1.68000000e-05);
            Assert.AreEqual(1.80000000e+02, r[1].se, 1.80000000e-05);
            Assert.AreEqual(1.92000000e+02, r[1].sf, 1.92000000e-05);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_add"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.20000000e+01, r[0].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[0].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[0].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[0].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[0].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[0].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[0].s7, 9.60000000e-06);
            Assert.AreEqual(1.08000000e+02, r[0].s8, 1.08000000e-05);
            Assert.AreEqual(1.20000000e+02, r[0].s9, 1.20000000e-05);
            Assert.AreEqual(1.32000000e+02, r[0].sa, 1.32000000e-05);
            Assert.AreEqual(1.44000000e+02, r[0].sb, 1.44000000e-05);
            Assert.AreEqual(1.56000000e+02, r[0].sc, 1.56000000e-05);
            Assert.AreEqual(1.68000000e+02, r[0].sd, 1.68000000e-05);
            Assert.AreEqual(1.80000000e+02, r[0].se, 1.80000000e-05);
            Assert.AreEqual(1.92000000e+02, r[0].sf, 1.92000000e-05);
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[1].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[1].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[1].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[1].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[1].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[1].s7, 9.60000000e-06);
            Assert.AreEqual(1.08000000e+02, r[1].s8, 1.08000000e-05);
            Assert.AreEqual(1.20000000e+02, r[1].s9, 1.20000000e-05);
            Assert.AreEqual(1.32000000e+02, r[1].sa, 1.32000000e-05);
            Assert.AreEqual(1.44000000e+02, r[1].sb, 1.44000000e-05);
            Assert.AreEqual(1.56000000e+02, r[1].sc, 1.56000000e-05);
            Assert.AreEqual(1.68000000e+02, r[1].sd, 1.68000000e-05);
            Assert.AreEqual(1.80000000e+02, r[1].se, 1.80000000e-05);
            Assert.AreEqual(1.92000000e+02, r[1].sf, 1.92000000e-05);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_add"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.20000000e+01, r[0].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[0].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[0].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[0].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[0].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[0].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[0].s7, 9.60000000e-06);
            Assert.AreEqual(1.08000000e+02, r[0].s8, 1.08000000e-05);
            Assert.AreEqual(1.20000000e+02, r[0].s9, 1.20000000e-05);
            Assert.AreEqual(1.32000000e+02, r[0].sa, 1.32000000e-05);
            Assert.AreEqual(1.44000000e+02, r[0].sb, 1.44000000e-05);
            Assert.AreEqual(1.56000000e+02, r[0].sc, 1.56000000e-05);
            Assert.AreEqual(1.68000000e+02, r[0].sd, 1.68000000e-05);
            Assert.AreEqual(1.80000000e+02, r[0].se, 1.80000000e-05);
            Assert.AreEqual(1.92000000e+02, r[0].sf, 1.92000000e-05);
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[1].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[1].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[1].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[1].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[1].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[1].s7, 9.60000000e-06);
            Assert.AreEqual(1.08000000e+02, r[1].s8, 1.08000000e-05);
            Assert.AreEqual(1.20000000e+02, r[1].s9, 1.20000000e-05);
            Assert.AreEqual(1.32000000e+02, r[1].sa, 1.32000000e-05);
            Assert.AreEqual(1.44000000e+02, r[1].sb, 1.44000000e-05);
            Assert.AreEqual(1.56000000e+02, r[1].sc, 1.56000000e-05);
            Assert.AreEqual(1.68000000e+02, r[1].sd, 1.68000000e-05);
            Assert.AreEqual(1.80000000e+02, r[1].se, 1.80000000e-05);
            Assert.AreEqual(1.92000000e+02, r[1].sf, 1.92000000e-05);
        }

        [Kernel]
        private static void test_float16_sub([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

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
            Assert.AreEqual(2.00000000e+00, r[0].s0, 2.00000000e-07);
            Assert.AreEqual(4.00000000e+00, r[0].s1, 4.00000000e-07);
            Assert.AreEqual(6.00000000e+00, r[0].s2, 6.00000000e-07);
            Assert.AreEqual(8.00000000e+00, r[0].s3, 8.00000000e-07);
            Assert.AreEqual(1.00000000e+01, r[0].s4, 1.00000000e-06);
            Assert.AreEqual(1.20000000e+01, r[0].s5, 1.20000000e-06);
            Assert.AreEqual(1.40000000e+01, r[0].s6, 1.40000000e-06);
            Assert.AreEqual(1.60000000e+01, r[0].s7, 1.60000000e-06);
            Assert.AreEqual(1.80000000e+01, r[0].s8, 1.80000000e-06);
            Assert.AreEqual(2.00000000e+01, r[0].s9, 2.00000000e-06);
            Assert.AreEqual(2.20000000e+01, r[0].sa, 2.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].sb, 2.40000000e-06);
            Assert.AreEqual(2.60000000e+01, r[0].sc, 2.60000000e-06);
            Assert.AreEqual(2.80000000e+01, r[0].sd, 2.80000000e-06);
            Assert.AreEqual(3.00000000e+01, r[0].se, 3.00000000e-06);
            Assert.AreEqual(3.20000000e+01, r[0].sf, 3.20000000e-06);
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
            Assert.AreEqual(-6.00000000e+00, r[1].s2, 6.00000000e-07);
            Assert.AreEqual(-8.00000000e+00, r[1].s3, 8.00000000e-07);
            Assert.AreEqual(-1.00000000e+01, r[1].s4, 1.00000000e-06);
            Assert.AreEqual(-1.20000000e+01, r[1].s5, 1.20000000e-06);
            Assert.AreEqual(-1.40000000e+01, r[1].s6, 1.40000000e-06);
            Assert.AreEqual(-1.60000000e+01, r[1].s7, 1.60000000e-06);
            Assert.AreEqual(-1.80000000e+01, r[1].s8, 1.80000000e-06);
            Assert.AreEqual(-2.00000000e+01, r[1].s9, 2.00000000e-06);
            Assert.AreEqual(-2.20000000e+01, r[1].sa, 2.20000000e-06);
            Assert.AreEqual(-2.40000000e+01, r[1].sb, 2.40000000e-06);
            Assert.AreEqual(-2.60000000e+01, r[1].sc, 2.60000000e-06);
            Assert.AreEqual(-2.80000000e+01, r[1].sd, 2.80000000e-06);
            Assert.AreEqual(-3.00000000e+01, r[1].se, 3.00000000e-06);
            Assert.AreEqual(-3.20000000e+01, r[1].sf, 3.20000000e-06);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_sub"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.00000000e+00, r[0].s0, 2.00000000e-07);
            Assert.AreEqual(4.00000000e+00, r[0].s1, 4.00000000e-07);
            Assert.AreEqual(6.00000000e+00, r[0].s2, 6.00000000e-07);
            Assert.AreEqual(8.00000000e+00, r[0].s3, 8.00000000e-07);
            Assert.AreEqual(1.00000000e+01, r[0].s4, 1.00000000e-06);
            Assert.AreEqual(1.20000000e+01, r[0].s5, 1.20000000e-06);
            Assert.AreEqual(1.40000000e+01, r[0].s6, 1.40000000e-06);
            Assert.AreEqual(1.60000000e+01, r[0].s7, 1.60000000e-06);
            Assert.AreEqual(1.80000000e+01, r[0].s8, 1.80000000e-06);
            Assert.AreEqual(2.00000000e+01, r[0].s9, 2.00000000e-06);
            Assert.AreEqual(2.20000000e+01, r[0].sa, 2.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].sb, 2.40000000e-06);
            Assert.AreEqual(2.60000000e+01, r[0].sc, 2.60000000e-06);
            Assert.AreEqual(2.80000000e+01, r[0].sd, 2.80000000e-06);
            Assert.AreEqual(3.00000000e+01, r[0].se, 3.00000000e-06);
            Assert.AreEqual(3.20000000e+01, r[0].sf, 3.20000000e-06);
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
            Assert.AreEqual(-6.00000000e+00, r[1].s2, 6.00000000e-07);
            Assert.AreEqual(-8.00000000e+00, r[1].s3, 8.00000000e-07);
            Assert.AreEqual(-1.00000000e+01, r[1].s4, 1.00000000e-06);
            Assert.AreEqual(-1.20000000e+01, r[1].s5, 1.20000000e-06);
            Assert.AreEqual(-1.40000000e+01, r[1].s6, 1.40000000e-06);
            Assert.AreEqual(-1.60000000e+01, r[1].s7, 1.60000000e-06);
            Assert.AreEqual(-1.80000000e+01, r[1].s8, 1.80000000e-06);
            Assert.AreEqual(-2.00000000e+01, r[1].s9, 2.00000000e-06);
            Assert.AreEqual(-2.20000000e+01, r[1].sa, 2.20000000e-06);
            Assert.AreEqual(-2.40000000e+01, r[1].sb, 2.40000000e-06);
            Assert.AreEqual(-2.60000000e+01, r[1].sc, 2.60000000e-06);
            Assert.AreEqual(-2.80000000e+01, r[1].sd, 2.80000000e-06);
            Assert.AreEqual(-3.00000000e+01, r[1].se, 3.00000000e-06);
            Assert.AreEqual(-3.20000000e+01, r[1].sf, 3.20000000e-06);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_sub"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.00000000e+00, r[0].s0, 2.00000000e-07);
            Assert.AreEqual(4.00000000e+00, r[0].s1, 4.00000000e-07);
            Assert.AreEqual(6.00000000e+00, r[0].s2, 6.00000000e-07);
            Assert.AreEqual(8.00000000e+00, r[0].s3, 8.00000000e-07);
            Assert.AreEqual(1.00000000e+01, r[0].s4, 1.00000000e-06);
            Assert.AreEqual(1.20000000e+01, r[0].s5, 1.20000000e-06);
            Assert.AreEqual(1.40000000e+01, r[0].s6, 1.40000000e-06);
            Assert.AreEqual(1.60000000e+01, r[0].s7, 1.60000000e-06);
            Assert.AreEqual(1.80000000e+01, r[0].s8, 1.80000000e-06);
            Assert.AreEqual(2.00000000e+01, r[0].s9, 2.00000000e-06);
            Assert.AreEqual(2.20000000e+01, r[0].sa, 2.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].sb, 2.40000000e-06);
            Assert.AreEqual(2.60000000e+01, r[0].sc, 2.60000000e-06);
            Assert.AreEqual(2.80000000e+01, r[0].sd, 2.80000000e-06);
            Assert.AreEqual(3.00000000e+01, r[0].se, 3.00000000e-06);
            Assert.AreEqual(3.20000000e+01, r[0].sf, 3.20000000e-06);
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
            Assert.AreEqual(-6.00000000e+00, r[1].s2, 6.00000000e-07);
            Assert.AreEqual(-8.00000000e+00, r[1].s3, 8.00000000e-07);
            Assert.AreEqual(-1.00000000e+01, r[1].s4, 1.00000000e-06);
            Assert.AreEqual(-1.20000000e+01, r[1].s5, 1.20000000e-06);
            Assert.AreEqual(-1.40000000e+01, r[1].s6, 1.40000000e-06);
            Assert.AreEqual(-1.60000000e+01, r[1].s7, 1.60000000e-06);
            Assert.AreEqual(-1.80000000e+01, r[1].s8, 1.80000000e-06);
            Assert.AreEqual(-2.00000000e+01, r[1].s9, 2.00000000e-06);
            Assert.AreEqual(-2.20000000e+01, r[1].sa, 2.20000000e-06);
            Assert.AreEqual(-2.40000000e+01, r[1].sb, 2.40000000e-06);
            Assert.AreEqual(-2.60000000e+01, r[1].sc, 2.60000000e-06);
            Assert.AreEqual(-2.80000000e+01, r[1].sd, 2.80000000e-06);
            Assert.AreEqual(-3.00000000e+01, r[1].se, 3.00000000e-06);
            Assert.AreEqual(-3.20000000e+01, r[1].sf, 3.20000000e-06);
        }

        [Kernel]
        private static void test_float16_mul([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

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
            Assert.AreEqual(3.50000000e+01, r[0].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[0].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[0].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[0].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[0].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[0].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[0].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[0].s7, 2.24000000e-04);
            Assert.AreEqual(2.83500000e+03, r[0].s8, 2.83500000e-04);
            Assert.AreEqual(3.50000000e+03, r[0].s9, 3.50000000e-04);
            Assert.AreEqual(4.23500000e+03, r[0].sa, 4.23500000e-04);
            Assert.AreEqual(5.04000000e+03, r[0].sb, 5.04000000e-04);
            Assert.AreEqual(5.91500000e+03, r[0].sc, 5.91500000e-04);
            Assert.AreEqual(6.86000000e+03, r[0].sd, 6.86000000e-04);
            Assert.AreEqual(7.87500000e+03, r[0].se, 7.87500000e-04);
            Assert.AreEqual(8.96000000e+03, r[0].sf, 8.96000000e-04);
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[1].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[1].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[1].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[1].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[1].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[1].s7, 2.24000000e-04);
            Assert.AreEqual(2.83500000e+03, r[1].s8, 2.83500000e-04);
            Assert.AreEqual(3.50000000e+03, r[1].s9, 3.50000000e-04);
            Assert.AreEqual(4.23500000e+03, r[1].sa, 4.23500000e-04);
            Assert.AreEqual(5.04000000e+03, r[1].sb, 5.04000000e-04);
            Assert.AreEqual(5.91500000e+03, r[1].sc, 5.91500000e-04);
            Assert.AreEqual(6.86000000e+03, r[1].sd, 6.86000000e-04);
            Assert.AreEqual(7.87500000e+03, r[1].se, 7.87500000e-04);
            Assert.AreEqual(8.96000000e+03, r[1].sf, 8.96000000e-04);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_mul"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.50000000e+01, r[0].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[0].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[0].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[0].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[0].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[0].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[0].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[0].s7, 2.24000000e-04);
            Assert.AreEqual(2.83500000e+03, r[0].s8, 2.83500000e-04);
            Assert.AreEqual(3.50000000e+03, r[0].s9, 3.50000000e-04);
            Assert.AreEqual(4.23500000e+03, r[0].sa, 4.23500000e-04);
            Assert.AreEqual(5.04000000e+03, r[0].sb, 5.04000000e-04);
            Assert.AreEqual(5.91500000e+03, r[0].sc, 5.91500000e-04);
            Assert.AreEqual(6.86000000e+03, r[0].sd, 6.86000000e-04);
            Assert.AreEqual(7.87500000e+03, r[0].se, 7.87500000e-04);
            Assert.AreEqual(8.96000000e+03, r[0].sf, 8.96000000e-04);
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[1].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[1].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[1].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[1].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[1].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[1].s7, 2.24000000e-04);
            Assert.AreEqual(2.83500000e+03, r[1].s8, 2.83500000e-04);
            Assert.AreEqual(3.50000000e+03, r[1].s9, 3.50000000e-04);
            Assert.AreEqual(4.23500000e+03, r[1].sa, 4.23500000e-04);
            Assert.AreEqual(5.04000000e+03, r[1].sb, 5.04000000e-04);
            Assert.AreEqual(5.91500000e+03, r[1].sc, 5.91500000e-04);
            Assert.AreEqual(6.86000000e+03, r[1].sd, 6.86000000e-04);
            Assert.AreEqual(7.87500000e+03, r[1].se, 7.87500000e-04);
            Assert.AreEqual(8.96000000e+03, r[1].sf, 8.96000000e-04);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_mul"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.50000000e+01, r[0].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[0].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[0].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[0].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[0].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[0].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[0].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[0].s7, 2.24000000e-04);
            Assert.AreEqual(2.83500000e+03, r[0].s8, 2.83500000e-04);
            Assert.AreEqual(3.50000000e+03, r[0].s9, 3.50000000e-04);
            Assert.AreEqual(4.23500000e+03, r[0].sa, 4.23500000e-04);
            Assert.AreEqual(5.04000000e+03, r[0].sb, 5.04000000e-04);
            Assert.AreEqual(5.91500000e+03, r[0].sc, 5.91500000e-04);
            Assert.AreEqual(6.86000000e+03, r[0].sd, 6.86000000e-04);
            Assert.AreEqual(7.87500000e+03, r[0].se, 7.87500000e-04);
            Assert.AreEqual(8.96000000e+03, r[0].sf, 8.96000000e-04);
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[1].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[1].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[1].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[1].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[1].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[1].s7, 2.24000000e-04);
            Assert.AreEqual(2.83500000e+03, r[1].s8, 2.83500000e-04);
            Assert.AreEqual(3.50000000e+03, r[1].s9, 3.50000000e-04);
            Assert.AreEqual(4.23500000e+03, r[1].sa, 4.23500000e-04);
            Assert.AreEqual(5.04000000e+03, r[1].sb, 5.04000000e-04);
            Assert.AreEqual(5.91500000e+03, r[1].sc, 5.91500000e-04);
            Assert.AreEqual(6.86000000e+03, r[1].sd, 6.86000000e-04);
            Assert.AreEqual(7.87500000e+03, r[1].se, 7.87500000e-04);
            Assert.AreEqual(8.96000000e+03, r[1].sf, 8.96000000e-04);
        }

        [Kernel]
        private static void test_float16_div([Global] float16[] a, [Global] float16[] b, [Global] float16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

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
            Assert.AreEqual(1.39999998e+00, r[0].s0, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s1, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s2, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s3, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s4, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s5, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s6, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s7, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s8, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s9, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sa, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sb, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sc, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sd, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].se, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sf, 1.39999998e-07);
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s2, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s3, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s4, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s5, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s6, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s7, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s8, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s9, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sa, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sb, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sc, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sd, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].se, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sf, 7.14285731e-08);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestDivCl()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_div"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.39999998e+00, r[0].s0, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s1, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s2, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s3, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s4, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s5, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s6, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s7, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s8, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s9, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sa, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sb, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sc, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sd, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].se, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sf, 1.39999998e-07);
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s2, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s3, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s4, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s5, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s6, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s7, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s8, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s9, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sa, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sb, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sc, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sd, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].se, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sf, 7.14285731e-08);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestDivSpirV()
        {
            var a = new float16[] { new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112), new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80) };
            var b = new float16[] { new float16((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40, (float)  45, (float)  50, (float)  55, (float)  60, (float)  65, (float)  70, (float)  75, (float)  80), new float16((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56, (float)  63, (float)  70, (float)  77, (float)  84, (float)  91, (float)  98, (float) 105, (float) 112) };
            var r = new float16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_div"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float16>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.39999998e+00, r[0].s0, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s1, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s2, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s3, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s4, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s5, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s6, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s7, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s8, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s9, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sa, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sb, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sc, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sd, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].se, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].sf, 1.39999998e-07);
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s2, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s3, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s4, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s5, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s6, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s7, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s8, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s9, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sa, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sb, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sc, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sd, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].se, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].sf, 7.14285731e-08);
        }

        [Kernel]
        private static void test_float16_eq([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestEqCl()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_eq"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_eq"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_float16_neq([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestNeqCl()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_neq"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_neq"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_float16_lt([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestLtCl()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_lt"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_lt"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_float16_le([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestLeCl()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_le"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_le"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_float16_gt([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestGtCl()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_gt"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_gt"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_float16_ge([Global] float16[] a, [Global] float16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

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
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestGeCl()
        {
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_ge"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new float16[] { new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15), new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15) };
            var b = new float16[] { new float16((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7, (float)   8, (float)   9, (float)  10, (float)  11, (float)  12, (float)  13, (float)  14, (float)  15), new float16((float)  30, (float)  29, (float)  28, (float)  27, (float)  26, (float)  25, (float)  24, (float)  23, (float)  22, (float)  21, (float)  20, (float)  19, (float)  18, (float)  17, (float)  16, (float)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat16", "test_float16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float16_ge"))
            using (var ma = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
