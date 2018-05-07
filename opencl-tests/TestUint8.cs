
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
    public class TestUint8
    {
        [Kernel]
        private static void test_uint8_add([Global] uint8[] a, [Global] uint8[] b, [Global] uint8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],uint8[]>)test_uint8_add,
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
        }

        [Test]
        public void TestAddCl()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_add"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        public void TestAddSpirV()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_add"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        private static void test_uint8_sub([Global] uint8[] a, [Global] uint8[] b, [Global] uint8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],uint8[]>)test_uint8_sub,
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
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
            Assert.AreEqual(4294967290, r[1].s2);
            Assert.AreEqual(4294967288, r[1].s3);
            Assert.AreEqual(4294967286, r[1].s4);
            Assert.AreEqual(4294967284, r[1].s5);
            Assert.AreEqual(4294967282, r[1].s6);
            Assert.AreEqual(4294967280, r[1].s7);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_sub"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  10, r[0].s4);
            Assert.AreEqual(  12, r[0].s5);
            Assert.AreEqual(  14, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
            Assert.AreEqual(4294967290, r[1].s2);
            Assert.AreEqual(4294967288, r[1].s3);
            Assert.AreEqual(4294967286, r[1].s4);
            Assert.AreEqual(4294967284, r[1].s5);
            Assert.AreEqual(4294967282, r[1].s6);
            Assert.AreEqual(4294967280, r[1].s7);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_sub"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  10, r[0].s4);
            Assert.AreEqual(  12, r[0].s5);
            Assert.AreEqual(  14, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
            Assert.AreEqual(4294967290, r[1].s2);
            Assert.AreEqual(4294967288, r[1].s3);
            Assert.AreEqual(4294967286, r[1].s4);
            Assert.AreEqual(4294967284, r[1].s5);
            Assert.AreEqual(4294967282, r[1].s6);
            Assert.AreEqual(4294967280, r[1].s7);
        }

        [Kernel]
        private static void test_uint8_mul([Global] uint8[] a, [Global] uint8[] b, [Global] uint8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],uint8[]>)test_uint8_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual( 875, r[0].s4);
            Assert.AreEqual(1260, r[0].s5);
            Assert.AreEqual(1715, r[0].s6);
            Assert.AreEqual(2240, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_mul"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual( 875, r[0].s4);
            Assert.AreEqual(1260, r[0].s5);
            Assert.AreEqual(1715, r[0].s6);
            Assert.AreEqual(2240, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_mul"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual( 875, r[0].s4);
            Assert.AreEqual(1260, r[0].s5);
            Assert.AreEqual(1715, r[0].s6);
            Assert.AreEqual(2240, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
        }

        [Kernel]
        private static void test_uint8_div([Global] uint8[] a, [Global] uint8[] b, [Global] uint8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],uint8[]>)test_uint8_div,
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
        }

        [Test]
        public void TestDivCl()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_div"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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

        [Test]
        public void TestDivSpirV()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_div"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        private static void test_uint8_eq([Global] uint8[] a, [Global] uint8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],int8[]>)test_uint8_eq,
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_eq"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_eq"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint8_neq([Global] uint8[] a, [Global] uint8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],int8[]>)test_uint8_neq,
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_neq"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_neq"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint8_lt([Global] uint8[] a, [Global] uint8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],int8[]>)test_uint8_lt,
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_lt"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_lt"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint8_le([Global] uint8[] a, [Global] uint8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],int8[]>)test_uint8_le,
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_le"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_le"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint8_gt([Global] uint8[] a, [Global] uint8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],int8[]>)test_uint8_gt,
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_gt"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_gt"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint8_ge([Global] uint8[] a, [Global] uint8[] b, [Global] int8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],int8[]>)test_uint8_ge,
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_ge"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint8[] { new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7), new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7) };
            var b = new uint8[] { new uint8((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7), new uint8((uint)  14, (uint)  13, (uint)  12, (uint)  11, (uint)  10, (uint)   9, (uint)   8, (uint)   7) };
            var r = new int8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_ge"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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

        [Kernel]
        private static void test_uint8_and([Global] uint8[] a, [Global] uint8[] b, [Global] uint8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],uint8[]>)test_uint8_and,
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
        }

        [Test]
        public void TestAndCl()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_and"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        private static void test_uint8_or([Global] uint8[] a, [Global] uint8[] b, [Global] uint8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],uint8[]>)test_uint8_or,
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
        }

        [Test]
        public void TestOrCl()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_or"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
        private static void test_uint8_xor([Global] uint8[] a, [Global] uint8[] b, [Global] uint8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint8[],uint8[],uint8[]>)test_uint8_xor,
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
        }

        [Test]
        public void TestXorCl()
        {
            var a = new uint8[] { new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56), new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40) };
            var b = new uint8[] { new uint8((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40), new uint8((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56) };
            var r = new uint8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint8", "test_uint8_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint8_xor"))
            using (var ma = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
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
