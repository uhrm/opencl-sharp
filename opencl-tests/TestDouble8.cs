
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
    public class TestDouble8
    {
        [Kernel]
        private static void test_double8_add([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

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
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[0].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[0].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[0].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[0].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[0].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[0].s7, 9.6000000000000007e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[1].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[1].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[1].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[1].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[1].s7, 9.6000000000000007e-14);
        }

        [Test]
        public void TestAddCl()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_add"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[1].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[1].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[1].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[1].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[1].s7, 9.6000000000000007e-14);
        }

        [Test]
        public void TestAddSpirV()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_add"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
            Assert.AreEqual(4.8000000000000000e+01, r[1].s3, 4.8000000000000004e-14);
            Assert.AreEqual(6.0000000000000000e+01, r[1].s4, 6.0000000000000009e-14);
            Assert.AreEqual(7.2000000000000000e+01, r[1].s5, 7.2000000000000009e-14);
            Assert.AreEqual(8.4000000000000000e+01, r[1].s6, 8.4000000000000008e-14);
            Assert.AreEqual(9.6000000000000000e+01, r[1].s7, 9.6000000000000007e-14);
        }

        [Kernel]
        private static void test_double8_sub([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

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
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(6.0000000000000000e+00, r[0].s2, 6.0000000000000005e-15);
            Assert.AreEqual(8.0000000000000000e+00, r[0].s3, 8.0000000000000006e-15);
            Assert.AreEqual(1.0000000000000000e+01, r[0].s4, 1.0000000000000002e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[0].s5, 1.2000000000000001e-14);
            Assert.AreEqual(1.4000000000000000e+01, r[0].s6, 1.4000000000000000e-14);
            Assert.AreEqual(1.6000000000000000e+01, r[0].s7, 1.6000000000000001e-14);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-8.0000000000000000e+00, r[1].s3, 8.0000000000000006e-15);
            Assert.AreEqual(-1.0000000000000000e+01, r[1].s4, 1.0000000000000002e-14);
            Assert.AreEqual(-1.2000000000000000e+01, r[1].s5, 1.2000000000000001e-14);
            Assert.AreEqual(-1.4000000000000000e+01, r[1].s6, 1.4000000000000000e-14);
            Assert.AreEqual(-1.6000000000000000e+01, r[1].s7, 1.6000000000000001e-14);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_sub"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-8.0000000000000000e+00, r[1].s3, 8.0000000000000006e-15);
            Assert.AreEqual(-1.0000000000000000e+01, r[1].s4, 1.0000000000000002e-14);
            Assert.AreEqual(-1.2000000000000000e+01, r[1].s5, 1.2000000000000001e-14);
            Assert.AreEqual(-1.4000000000000000e+01, r[1].s6, 1.4000000000000000e-14);
            Assert.AreEqual(-1.6000000000000000e+01, r[1].s7, 1.6000000000000001e-14);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_sub"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-8.0000000000000000e+00, r[1].s3, 8.0000000000000006e-15);
            Assert.AreEqual(-1.0000000000000000e+01, r[1].s4, 1.0000000000000002e-14);
            Assert.AreEqual(-1.2000000000000000e+01, r[1].s5, 1.2000000000000001e-14);
            Assert.AreEqual(-1.4000000000000000e+01, r[1].s6, 1.4000000000000000e-14);
            Assert.AreEqual(-1.6000000000000000e+01, r[1].s7, 1.6000000000000001e-14);
        }

        [Kernel]
        private static void test_double8_mul([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

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
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[0].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[0].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[0].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[0].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[0].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[0].s7, 2.2400000000000001e-12);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[1].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[1].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[1].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[1].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[1].s7, 2.2400000000000001e-12);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_mul"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[1].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[1].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[1].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[1].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[1].s7, 2.2400000000000001e-12);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_mul"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
            Assert.AreEqual(5.6000000000000000e+02, r[1].s3, 5.6000000000000004e-13);
            Assert.AreEqual(8.7500000000000000e+02, r[1].s4, 8.7500000000000011e-13);
            Assert.AreEqual(1.2600000000000000e+03, r[1].s5, 1.2600000000000001e-12);
            Assert.AreEqual(1.7150000000000000e+03, r[1].s6, 1.7150000000000001e-12);
            Assert.AreEqual(2.2400000000000000e+03, r[1].s7, 2.2400000000000001e-12);
        }

        [Kernel]
        private static void test_double8_div([Global] double8[] a, [Global] double8[] b, [Global] double8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

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
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s2, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s3, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s4, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s5, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s6, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s7, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s3, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s4, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s5, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s6, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s7, 7.1428571428571436e-16);
        }

        [Test]
        public void TestDivCl()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_div"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s3, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s4, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s5, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s6, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s7, 7.1428571428571436e-16);
        }

        [Test]
        public void TestDivSpirV()
        {
            var a = new double8[] { new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56), new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40) };
            var b = new double8[] { new double8((double)   5, (double)  10, (double)  15, (double)  20, (double)  25, (double)  30, (double)  35, (double)  40), new double8((double)   7, (double)  14, (double)  21, (double)  28, (double)  35, (double)  42, (double)  49, (double)  56) };
            var r = new double8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_div"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double8>()))
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
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s3, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s4, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s5, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s6, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s7, 7.1428571428571436e-16);
        }

        [Kernel]
        private static void test_double8_eq([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

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
        }

        [Test]
        public void TestEqCl()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_eq"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_eq"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_double8_neq([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

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
        }

        [Test]
        public void TestNeqCl()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_neq"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_neq"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_double8_lt([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

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
        }

        [Test]
        public void TestLtCl()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_lt"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_lt"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_double8_le([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

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
        }

        [Test]
        public void TestLeCl()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_le"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_le"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_double8_gt([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

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
        }

        [Test]
        public void TestGtCl()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_gt"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_gt"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_double8_ge([Global] double8[] a, [Global] double8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

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
        }

        [Test]
        public void TestGeCl()
        {
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_ge"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new double8[] { new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7), new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7) };
            var b = new double8[] { new double8((double)   0, (double)   1, (double)   2, (double)   3, (double)   4, (double)   5, (double)   6, (double)   7), new double8((double)  14, (double)  13, (double)  12, (double)  11, (double)  10, (double)   9, (double)   8, (double)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble8", "test_double8_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double8_ge"))
            using (var ma = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
