
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
    public class TestFloat8
    {
        [Kernel]
        private static void test_float8_add([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

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
            Assert.AreEqual(1.20000000e+01, r[0].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[0].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[0].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[0].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[0].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[0].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[0].s7, 9.60000000e-06);
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[1].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[1].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[1].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[1].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[1].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[1].s7, 9.60000000e-06);
        }

        [Test]
        public void TestAddCl()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_add"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[1].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[1].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[1].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[1].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[1].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[1].s7, 9.60000000e-06);
        }

        [Test]
        public void TestAddSpirV()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_add"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
            Assert.AreEqual(3.60000000e+01, r[1].s2, 3.60000000e-06);
            Assert.AreEqual(4.80000000e+01, r[1].s3, 4.80000000e-06);
            Assert.AreEqual(6.00000000e+01, r[1].s4, 6.00000000e-06);
            Assert.AreEqual(7.20000000e+01, r[1].s5, 7.20000000e-06);
            Assert.AreEqual(8.40000000e+01, r[1].s6, 8.40000000e-06);
            Assert.AreEqual(9.60000000e+01, r[1].s7, 9.60000000e-06);
        }

        [Kernel]
        private static void test_float8_sub([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

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
            Assert.AreEqual(2.00000000e+00, r[0].s0, 2.00000000e-07);
            Assert.AreEqual(4.00000000e+00, r[0].s1, 4.00000000e-07);
            Assert.AreEqual(6.00000000e+00, r[0].s2, 6.00000000e-07);
            Assert.AreEqual(8.00000000e+00, r[0].s3, 8.00000000e-07);
            Assert.AreEqual(1.00000000e+01, r[0].s4, 1.00000000e-06);
            Assert.AreEqual(1.20000000e+01, r[0].s5, 1.20000000e-06);
            Assert.AreEqual(1.40000000e+01, r[0].s6, 1.40000000e-06);
            Assert.AreEqual(1.60000000e+01, r[0].s7, 1.60000000e-06);
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
            Assert.AreEqual(-6.00000000e+00, r[1].s2, 6.00000000e-07);
            Assert.AreEqual(-8.00000000e+00, r[1].s3, 8.00000000e-07);
            Assert.AreEqual(-1.00000000e+01, r[1].s4, 1.00000000e-06);
            Assert.AreEqual(-1.20000000e+01, r[1].s5, 1.20000000e-06);
            Assert.AreEqual(-1.40000000e+01, r[1].s6, 1.40000000e-06);
            Assert.AreEqual(-1.60000000e+01, r[1].s7, 1.60000000e-06);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_sub"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
            Assert.AreEqual(-6.00000000e+00, r[1].s2, 6.00000000e-07);
            Assert.AreEqual(-8.00000000e+00, r[1].s3, 8.00000000e-07);
            Assert.AreEqual(-1.00000000e+01, r[1].s4, 1.00000000e-06);
            Assert.AreEqual(-1.20000000e+01, r[1].s5, 1.20000000e-06);
            Assert.AreEqual(-1.40000000e+01, r[1].s6, 1.40000000e-06);
            Assert.AreEqual(-1.60000000e+01, r[1].s7, 1.60000000e-06);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_sub"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
            Assert.AreEqual(-6.00000000e+00, r[1].s2, 6.00000000e-07);
            Assert.AreEqual(-8.00000000e+00, r[1].s3, 8.00000000e-07);
            Assert.AreEqual(-1.00000000e+01, r[1].s4, 1.00000000e-06);
            Assert.AreEqual(-1.20000000e+01, r[1].s5, 1.20000000e-06);
            Assert.AreEqual(-1.40000000e+01, r[1].s6, 1.40000000e-06);
            Assert.AreEqual(-1.60000000e+01, r[1].s7, 1.60000000e-06);
        }

        [Kernel]
        private static void test_float8_mul([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

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
            Assert.AreEqual(3.50000000e+01, r[0].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[0].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[0].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[0].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[0].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[0].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[0].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[0].s7, 2.24000000e-04);
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[1].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[1].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[1].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[1].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[1].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[1].s7, 2.24000000e-04);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_mul"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[1].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[1].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[1].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[1].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[1].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[1].s7, 2.24000000e-04);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_mul"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
            Assert.AreEqual(3.15000000e+02, r[1].s2, 3.15000000e-05);
            Assert.AreEqual(5.60000000e+02, r[1].s3, 5.60000000e-05);
            Assert.AreEqual(8.75000000e+02, r[1].s4, 8.75000000e-05);
            Assert.AreEqual(1.26000000e+03, r[1].s5, 1.26000000e-04);
            Assert.AreEqual(1.71500000e+03, r[1].s6, 1.71500000e-04);
            Assert.AreEqual(2.24000000e+03, r[1].s7, 2.24000000e-04);
        }

        [Kernel]
        private static void test_float8_div([Global] float8[] a, [Global] float8[] b, [Global] float8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

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
            Assert.AreEqual(1.39999998e+00, r[0].s0, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s1, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s2, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s3, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s4, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s5, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s6, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s7, 1.39999998e-07);
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s2, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s3, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s4, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s5, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s6, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s7, 7.14285731e-08);
        }

        [Test]
        public void TestDivCl()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_div"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s2, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s3, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s4, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s5, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s6, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s7, 7.14285731e-08);
        }

        [Test]
        public void TestDivSpirV()
        {
            var a = new float8[] { new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56), new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40) };
            var b = new float8[] { new float8((float)   5, (float)  10, (float)  15, (float)  20, (float)  25, (float)  30, (float)  35, (float)  40), new float8((float)   7, (float)  14, (float)  21, (float)  28, (float)  35, (float)  42, (float)  49, (float)  56) };
            var r = new float8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_div"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float8>()))
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
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s2, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s3, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s4, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s5, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s6, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s7, 7.14285731e-08);
        }

        [Kernel]
        private static void test_float8_eq([Global] float8[] a, [Global] float8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

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
        }

        [Test]
        public void TestEqCl()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_eq"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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

        [Test]
        public void TestEqSpirV()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_eq"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
        public void TestNeqManaged()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

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
        }

        [Test]
        public void TestNeqCl()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_neq"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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

        [Test]
        public void TestNeqSpirV()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_neq"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
        public void TestLtManaged()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

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
        }

        [Test]
        public void TestLtCl()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_lt"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
        }

        [Test]
        public void TestLtSpirV()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_lt"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
        public void TestLeManaged()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

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
        }

        [Test]
        public void TestLeCl()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_le"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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

        [Test]
        public void TestLeSpirV()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_le"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
        public void TestGtManaged()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

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
        }

        [Test]
        public void TestGtCl()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_gt"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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

        [Test]
        public void TestGtSpirV()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_gt"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
        public void TestGeManaged()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

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
        }

        [Test]
        public void TestGeCl()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_ge"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
        }

        [Test]
        public void TestGeSpirV()
        {
            var a = new float8[] { new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7), new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7) };
            var b = new float8[] { new float8((float)   0, (float)   1, (float)   2, (float)   3, (float)   4, (float)   5, (float)   6, (float)   7), new float8((float)  14, (float)  13, (float)  12, (float)  11, (float)  10, (float)   9, (float)   8, (float)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat8", "test_float8_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float8_ge"))
            using (var ma = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int8>()))
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
