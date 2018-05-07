
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
    public class TestUshort8
    {
        [Kernel]
        private static void test_ushort8_add([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_add,
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_add"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_add"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
        private static void test_ushort8_sub([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_sub,
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
            Assert.AreEqual(65534, r[1].s0);
            Assert.AreEqual(65532, r[1].s1);
            Assert.AreEqual(65530, r[1].s2);
            Assert.AreEqual(65528, r[1].s3);
            Assert.AreEqual(65526, r[1].s4);
            Assert.AreEqual(65524, r[1].s5);
            Assert.AreEqual(65522, r[1].s6);
            Assert.AreEqual(65520, r[1].s7);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_sub"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
            Assert.AreEqual(65534, r[1].s0);
            Assert.AreEqual(65532, r[1].s1);
            Assert.AreEqual(65530, r[1].s2);
            Assert.AreEqual(65528, r[1].s3);
            Assert.AreEqual(65526, r[1].s4);
            Assert.AreEqual(65524, r[1].s5);
            Assert.AreEqual(65522, r[1].s6);
            Assert.AreEqual(65520, r[1].s7);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_sub"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
            Assert.AreEqual(65534, r[1].s0);
            Assert.AreEqual(65532, r[1].s1);
            Assert.AreEqual(65530, r[1].s2);
            Assert.AreEqual(65528, r[1].s3);
            Assert.AreEqual(65526, r[1].s4);
            Assert.AreEqual(65524, r[1].s5);
            Assert.AreEqual(65522, r[1].s6);
            Assert.AreEqual(65520, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_mul([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_mul,
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_mul"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_mul"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
        private static void test_ushort8_div([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_div,
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_div"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_div"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
        private static void test_ushort8_eq([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_eq,
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_eq"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_eq"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
        private static void test_ushort8_neq([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_neq,
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_neq"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_neq"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
        private static void test_ushort8_lt([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_lt,
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_lt"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_lt"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
        private static void test_ushort8_le([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_le,
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_le"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_le"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
        private static void test_ushort8_gt([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_gt,
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_gt"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_gt"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
        private static void test_ushort8_ge([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_ge,
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_ge"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
            var a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            var b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            var r = new short8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_ge"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short8>()))
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
        private static void test_ushort8_and([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_and,
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_and"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
        private static void test_ushort8_or([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_or,
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_or"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
        private static void test_ushort8_xor([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_xor,
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
            var a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            var b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            var r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ushort8_xor"))
            using (var ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ushort8>()))
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
