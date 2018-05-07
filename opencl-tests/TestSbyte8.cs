
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
    public class TestSbyte8
    {
        [Kernel]
        private static void test_sbyte8_add([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_add,
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
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_add"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_add"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_sub([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_sub,
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
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_sub"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_sub"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_mul([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual(-116, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( -20, r[0].s5);
            Assert.AreEqual( -77, r[0].s6);
            Assert.AreEqual( -64, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_mul"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual(-116, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( -20, r[0].s5);
            Assert.AreEqual( -77, r[0].s6);
            Assert.AreEqual( -64, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_mul"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual(-116, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( -20, r[0].s5);
            Assert.AreEqual( -77, r[0].s6);
            Assert.AreEqual( -64, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);
        }

        [Kernel]
        private static void test_sbyte8_div([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_div,
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
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_div"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_div"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_eq([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_eq,
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_eq"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_eq"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_neq([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_neq,
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_neq"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_neq"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_lt([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_lt,
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_lt"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_lt"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_le([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_le,
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_le"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_le"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_gt([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_gt,
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_gt"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_gt"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_ge([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_ge,
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_ge"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
            var a = new sbyte8[] { new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7), new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7) };
            var b = new sbyte8[] { new sbyte8((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7), new sbyte8((sbyte)  14, (sbyte)  13, (sbyte)  12, (sbyte)  11, (sbyte)  10, (sbyte)   9, (sbyte)   8, (sbyte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_ge"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_and([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_and,
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
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_and"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_or([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_or,
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
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_or"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
        private static void test_sbyte8_xor([Global] sbyte8[] a, [Global] sbyte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte8[],sbyte8[],sbyte8[]>)test_sbyte8_xor,
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
            var a = new sbyte8[] { new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56), new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40) };
            var b = new sbyte8[] { new sbyte8((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40), new sbyte8((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte8", "test_sbyte8_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte8_xor"))
            using (var ma = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte8>()))
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
