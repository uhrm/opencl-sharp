
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
    public class TestLong16
    {
        [Kernel]
        private static void test_long16_add([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_add,
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
            Assert.AreEqual( 108, r[0].s8);
            Assert.AreEqual( 120, r[0].s9);
            Assert.AreEqual( 132, r[0].sa);
            Assert.AreEqual( 144, r[0].sb);
            Assert.AreEqual( 156, r[0].sc);
            Assert.AreEqual( 168, r[0].sd);
            Assert.AreEqual( 180, r[0].se);
            Assert.AreEqual( 192, r[0].sf);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);
            Assert.AreEqual( 108, r[1].s8);
            Assert.AreEqual( 120, r[1].s9);
            Assert.AreEqual( 132, r[1].sa);
            Assert.AreEqual( 144, r[1].sb);
            Assert.AreEqual( 156, r[1].sc);
            Assert.AreEqual( 168, r[1].sd);
            Assert.AreEqual( 180, r[1].se);
            Assert.AreEqual( 192, r[1].sf);
        }

        [Test]
        public void TestAddCl()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_add"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual( 108, r[0].s8);
            Assert.AreEqual( 120, r[0].s9);
            Assert.AreEqual( 132, r[0].sa);
            Assert.AreEqual( 144, r[0].sb);
            Assert.AreEqual( 156, r[0].sc);
            Assert.AreEqual( 168, r[0].sd);
            Assert.AreEqual( 180, r[0].se);
            Assert.AreEqual( 192, r[0].sf);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);
            Assert.AreEqual( 108, r[1].s8);
            Assert.AreEqual( 120, r[1].s9);
            Assert.AreEqual( 132, r[1].sa);
            Assert.AreEqual( 144, r[1].sb);
            Assert.AreEqual( 156, r[1].sc);
            Assert.AreEqual( 168, r[1].sd);
            Assert.AreEqual( 180, r[1].se);
            Assert.AreEqual( 192, r[1].sf);
        }

        [Test]
        public void TestAddSpirV()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_add"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual( 108, r[0].s8);
            Assert.AreEqual( 120, r[0].s9);
            Assert.AreEqual( 132, r[0].sa);
            Assert.AreEqual( 144, r[0].sb);
            Assert.AreEqual( 156, r[0].sc);
            Assert.AreEqual( 168, r[0].sd);
            Assert.AreEqual( 180, r[0].se);
            Assert.AreEqual( 192, r[0].sf);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);
            Assert.AreEqual( 108, r[1].s8);
            Assert.AreEqual( 120, r[1].s9);
            Assert.AreEqual( 132, r[1].sa);
            Assert.AreEqual( 144, r[1].sb);
            Assert.AreEqual( 156, r[1].sc);
            Assert.AreEqual( 168, r[1].sd);
            Assert.AreEqual( 180, r[1].se);
            Assert.AreEqual( 192, r[1].sf);
        }

        [Kernel]
        private static void test_long16_sub([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_sub,
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
            Assert.AreEqual(  18, r[0].s8);
            Assert.AreEqual(  20, r[0].s9);
            Assert.AreEqual(  22, r[0].sa);
            Assert.AreEqual(  24, r[0].sb);
            Assert.AreEqual(  26, r[0].sc);
            Assert.AreEqual(  28, r[0].sd);
            Assert.AreEqual(  30, r[0].se);
            Assert.AreEqual(  32, r[0].sf);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);
            Assert.AreEqual( -18, r[1].s8);
            Assert.AreEqual( -20, r[1].s9);
            Assert.AreEqual( -22, r[1].sa);
            Assert.AreEqual( -24, r[1].sb);
            Assert.AreEqual( -26, r[1].sc);
            Assert.AreEqual( -28, r[1].sd);
            Assert.AreEqual( -30, r[1].se);
            Assert.AreEqual( -32, r[1].sf);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_sub"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(  18, r[0].s8);
            Assert.AreEqual(  20, r[0].s9);
            Assert.AreEqual(  22, r[0].sa);
            Assert.AreEqual(  24, r[0].sb);
            Assert.AreEqual(  26, r[0].sc);
            Assert.AreEqual(  28, r[0].sd);
            Assert.AreEqual(  30, r[0].se);
            Assert.AreEqual(  32, r[0].sf);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);
            Assert.AreEqual( -18, r[1].s8);
            Assert.AreEqual( -20, r[1].s9);
            Assert.AreEqual( -22, r[1].sa);
            Assert.AreEqual( -24, r[1].sb);
            Assert.AreEqual( -26, r[1].sc);
            Assert.AreEqual( -28, r[1].sd);
            Assert.AreEqual( -30, r[1].se);
            Assert.AreEqual( -32, r[1].sf);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_sub"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(  18, r[0].s8);
            Assert.AreEqual(  20, r[0].s9);
            Assert.AreEqual(  22, r[0].sa);
            Assert.AreEqual(  24, r[0].sb);
            Assert.AreEqual(  26, r[0].sc);
            Assert.AreEqual(  28, r[0].sd);
            Assert.AreEqual(  30, r[0].se);
            Assert.AreEqual(  32, r[0].sf);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
            Assert.AreEqual(  -6, r[1].s2);
            Assert.AreEqual(  -8, r[1].s3);
            Assert.AreEqual( -10, r[1].s4);
            Assert.AreEqual( -12, r[1].s5);
            Assert.AreEqual( -14, r[1].s6);
            Assert.AreEqual( -16, r[1].s7);
            Assert.AreEqual( -18, r[1].s8);
            Assert.AreEqual( -20, r[1].s9);
            Assert.AreEqual( -22, r[1].sa);
            Assert.AreEqual( -24, r[1].sb);
            Assert.AreEqual( -26, r[1].sc);
            Assert.AreEqual( -28, r[1].sd);
            Assert.AreEqual( -30, r[1].se);
            Assert.AreEqual( -32, r[1].sf);
        }

        [Kernel]
        private static void test_long16_mul([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_mul,
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
            Assert.AreEqual(2835, r[0].s8);
            Assert.AreEqual(3500, r[0].s9);
            Assert.AreEqual(4235, r[0].sa);
            Assert.AreEqual(5040, r[0].sb);
            Assert.AreEqual(5915, r[0].sc);
            Assert.AreEqual(6860, r[0].sd);
            Assert.AreEqual(7875, r[0].se);
            Assert.AreEqual(8960, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
            Assert.AreEqual(2835, r[1].s8);
            Assert.AreEqual(3500, r[1].s9);
            Assert.AreEqual(4235, r[1].sa);
            Assert.AreEqual(5040, r[1].sb);
            Assert.AreEqual(5915, r[1].sc);
            Assert.AreEqual(6860, r[1].sd);
            Assert.AreEqual(7875, r[1].se);
            Assert.AreEqual(8960, r[1].sf);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_mul"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(2835, r[0].s8);
            Assert.AreEqual(3500, r[0].s9);
            Assert.AreEqual(4235, r[0].sa);
            Assert.AreEqual(5040, r[0].sb);
            Assert.AreEqual(5915, r[0].sc);
            Assert.AreEqual(6860, r[0].sd);
            Assert.AreEqual(7875, r[0].se);
            Assert.AreEqual(8960, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
            Assert.AreEqual(2835, r[1].s8);
            Assert.AreEqual(3500, r[1].s9);
            Assert.AreEqual(4235, r[1].sa);
            Assert.AreEqual(5040, r[1].sb);
            Assert.AreEqual(5915, r[1].sc);
            Assert.AreEqual(6860, r[1].sd);
            Assert.AreEqual(7875, r[1].se);
            Assert.AreEqual(8960, r[1].sf);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_mul"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(2835, r[0].s8);
            Assert.AreEqual(3500, r[0].s9);
            Assert.AreEqual(4235, r[0].sa);
            Assert.AreEqual(5040, r[0].sb);
            Assert.AreEqual(5915, r[0].sc);
            Assert.AreEqual(6860, r[0].sd);
            Assert.AreEqual(7875, r[0].se);
            Assert.AreEqual(8960, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
            Assert.AreEqual(2835, r[1].s8);
            Assert.AreEqual(3500, r[1].s9);
            Assert.AreEqual(4235, r[1].sa);
            Assert.AreEqual(5040, r[1].sb);
            Assert.AreEqual(5915, r[1].sc);
            Assert.AreEqual(6860, r[1].sd);
            Assert.AreEqual(7875, r[1].se);
            Assert.AreEqual(8960, r[1].sf);
        }

        [Kernel]
        private static void test_long16_div([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_div,
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
            Assert.AreEqual(   1, r[0].s8);
            Assert.AreEqual(   1, r[0].s9);
            Assert.AreEqual(   1, r[0].sa);
            Assert.AreEqual(   1, r[0].sb);
            Assert.AreEqual(   1, r[0].sc);
            Assert.AreEqual(   1, r[0].sd);
            Assert.AreEqual(   1, r[0].se);
            Assert.AreEqual(   1, r[0].sf);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);
            Assert.AreEqual(   0, r[1].s8);
            Assert.AreEqual(   0, r[1].s9);
            Assert.AreEqual(   0, r[1].sa);
            Assert.AreEqual(   0, r[1].sb);
            Assert.AreEqual(   0, r[1].sc);
            Assert.AreEqual(   0, r[1].sd);
            Assert.AreEqual(   0, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Test]
        public void TestDivCl()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_div"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(   1, r[0].s8);
            Assert.AreEqual(   1, r[0].s9);
            Assert.AreEqual(   1, r[0].sa);
            Assert.AreEqual(   1, r[0].sb);
            Assert.AreEqual(   1, r[0].sc);
            Assert.AreEqual(   1, r[0].sd);
            Assert.AreEqual(   1, r[0].se);
            Assert.AreEqual(   1, r[0].sf);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);
            Assert.AreEqual(   0, r[1].s8);
            Assert.AreEqual(   0, r[1].s9);
            Assert.AreEqual(   0, r[1].sa);
            Assert.AreEqual(   0, r[1].sb);
            Assert.AreEqual(   0, r[1].sc);
            Assert.AreEqual(   0, r[1].sd);
            Assert.AreEqual(   0, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Test]
        public void TestDivSpirV()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_div"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(   1, r[0].s8);
            Assert.AreEqual(   1, r[0].s9);
            Assert.AreEqual(   1, r[0].sa);
            Assert.AreEqual(   1, r[0].sb);
            Assert.AreEqual(   1, r[0].sc);
            Assert.AreEqual(   1, r[0].sd);
            Assert.AreEqual(   1, r[0].se);
            Assert.AreEqual(   1, r[0].sf);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);
            Assert.AreEqual(   0, r[1].s8);
            Assert.AreEqual(   0, r[1].s9);
            Assert.AreEqual(   0, r[1].sa);
            Assert.AreEqual(   0, r[1].sb);
            Assert.AreEqual(   0, r[1].sc);
            Assert.AreEqual(   0, r[1].sd);
            Assert.AreEqual(   0, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Kernel]
        private static void test_long16_eq([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_eq,
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
        public void TestEqCl()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_eq"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestEqSpirV()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_eq"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_long16_neq([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_neq,
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
        public void TestNeqCl()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_neq"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestNeqSpirV()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_neq"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_long16_lt([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_lt,
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
        public void TestLtCl()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_lt"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestLtSpirV()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_lt"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_long16_le([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_le,
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
        public void TestLeCl()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_le"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestLeSpirV()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_le"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_long16_gt([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_gt,
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
        public void TestGtCl()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_gt"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestGtSpirV()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_gt"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_long16_ge([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_ge,
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
        public void TestGeCl()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_ge"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestGeSpirV()
        {
            var a = new long16[] { new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15), new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15) };
            var b = new long16[] { new long16((long)   0, (long)   1, (long)   2, (long)   3, (long)   4, (long)   5, (long)   6, (long)   7, (long)   8, (long)   9, (long)  10, (long)  11, (long)  12, (long)  13, (long)  14, (long)  15), new long16((long)  30, (long)  29, (long)  28, (long)  27, (long)  26, (long)  25, (long)  24, (long)  23, (long)  22, (long)  21, (long)  20, (long)  19, (long)  18, (long)  17, (long)  16, (long)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_ge"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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

        [Kernel]
        private static void test_long16_and([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_and,
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
            Assert.AreEqual(  45, r[0].s8);
            Assert.AreEqual(   2, r[0].s9);
            Assert.AreEqual(   5, r[0].sa);
            Assert.AreEqual(  20, r[0].sb);
            Assert.AreEqual(  65, r[0].sc);
            Assert.AreEqual(  66, r[0].sd);
            Assert.AreEqual(  73, r[0].se);
            Assert.AreEqual(  80, r[0].sf);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);
            Assert.AreEqual(   1, r[1].s4);
            Assert.AreEqual(  10, r[1].s5);
            Assert.AreEqual(  33, r[1].s6);
            Assert.AreEqual(  40, r[1].s7);
            Assert.AreEqual(  45, r[1].s8);
            Assert.AreEqual(   2, r[1].s9);
            Assert.AreEqual(   5, r[1].sa);
            Assert.AreEqual(  20, r[1].sb);
            Assert.AreEqual(  65, r[1].sc);
            Assert.AreEqual(  66, r[1].sd);
            Assert.AreEqual(  73, r[1].se);
            Assert.AreEqual(  80, r[1].sf);
        }

        [Test]
        public void TestAndCl()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_and"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(  45, r[0].s8);
            Assert.AreEqual(   2, r[0].s9);
            Assert.AreEqual(   5, r[0].sa);
            Assert.AreEqual(  20, r[0].sb);
            Assert.AreEqual(  65, r[0].sc);
            Assert.AreEqual(  66, r[0].sd);
            Assert.AreEqual(  73, r[0].se);
            Assert.AreEqual(  80, r[0].sf);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);
            Assert.AreEqual(   1, r[1].s4);
            Assert.AreEqual(  10, r[1].s5);
            Assert.AreEqual(  33, r[1].s6);
            Assert.AreEqual(  40, r[1].s7);
            Assert.AreEqual(  45, r[1].s8);
            Assert.AreEqual(   2, r[1].s9);
            Assert.AreEqual(   5, r[1].sa);
            Assert.AreEqual(  20, r[1].sb);
            Assert.AreEqual(  65, r[1].sc);
            Assert.AreEqual(  66, r[1].sd);
            Assert.AreEqual(  73, r[1].se);
            Assert.AreEqual(  80, r[1].sf);
        }

        [Kernel]
        private static void test_long16_or([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_or,
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
            Assert.AreEqual(  63, r[0].s8);
            Assert.AreEqual( 118, r[0].s9);
            Assert.AreEqual( 127, r[0].sa);
            Assert.AreEqual( 124, r[0].sb);
            Assert.AreEqual(  91, r[0].sc);
            Assert.AreEqual( 102, r[0].sd);
            Assert.AreEqual( 107, r[0].se);
            Assert.AreEqual( 112, r[0].sf);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);
            Assert.AreEqual(  59, r[1].s4);
            Assert.AreEqual(  62, r[1].s5);
            Assert.AreEqual(  51, r[1].s6);
            Assert.AreEqual(  56, r[1].s7);
            Assert.AreEqual(  63, r[1].s8);
            Assert.AreEqual( 118, r[1].s9);
            Assert.AreEqual( 127, r[1].sa);
            Assert.AreEqual( 124, r[1].sb);
            Assert.AreEqual(  91, r[1].sc);
            Assert.AreEqual( 102, r[1].sd);
            Assert.AreEqual( 107, r[1].se);
            Assert.AreEqual( 112, r[1].sf);
        }

        [Test]
        public void TestOrCl()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_or"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(  63, r[0].s8);
            Assert.AreEqual( 118, r[0].s9);
            Assert.AreEqual( 127, r[0].sa);
            Assert.AreEqual( 124, r[0].sb);
            Assert.AreEqual(  91, r[0].sc);
            Assert.AreEqual( 102, r[0].sd);
            Assert.AreEqual( 107, r[0].se);
            Assert.AreEqual( 112, r[0].sf);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);
            Assert.AreEqual(  59, r[1].s4);
            Assert.AreEqual(  62, r[1].s5);
            Assert.AreEqual(  51, r[1].s6);
            Assert.AreEqual(  56, r[1].s7);
            Assert.AreEqual(  63, r[1].s8);
            Assert.AreEqual( 118, r[1].s9);
            Assert.AreEqual( 127, r[1].sa);
            Assert.AreEqual( 124, r[1].sb);
            Assert.AreEqual(  91, r[1].sc);
            Assert.AreEqual( 102, r[1].sd);
            Assert.AreEqual( 107, r[1].se);
            Assert.AreEqual( 112, r[1].sf);
        }

        [Kernel]
        private static void test_long16_xor([Global] long16[] a, [Global] long16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<long16[],long16[],long16[]>)test_long16_xor,
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
            Assert.AreEqual(  18, r[0].s8);
            Assert.AreEqual( 116, r[0].s9);
            Assert.AreEqual( 122, r[0].sa);
            Assert.AreEqual( 104, r[0].sb);
            Assert.AreEqual(  26, r[0].sc);
            Assert.AreEqual(  36, r[0].sd);
            Assert.AreEqual(  34, r[0].se);
            Assert.AreEqual(  32, r[0].sf);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);
            Assert.AreEqual(  58, r[1].s4);
            Assert.AreEqual(  52, r[1].s5);
            Assert.AreEqual(  18, r[1].s6);
            Assert.AreEqual(  16, r[1].s7);
            Assert.AreEqual(  18, r[1].s8);
            Assert.AreEqual( 116, r[1].s9);
            Assert.AreEqual( 122, r[1].sa);
            Assert.AreEqual( 104, r[1].sb);
            Assert.AreEqual(  26, r[1].sc);
            Assert.AreEqual(  36, r[1].sd);
            Assert.AreEqual(  34, r[1].se);
            Assert.AreEqual(  32, r[1].sf);
        }

        [Test]
        public void TestXorCl()
        {
            var a = new long16[] { new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112), new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80) };
            var b = new long16[] { new long16((long)   5, (long)  10, (long)  15, (long)  20, (long)  25, (long)  30, (long)  35, (long)  40, (long)  45, (long)  50, (long)  55, (long)  60, (long)  65, (long)  70, (long)  75, (long)  80), new long16((long)   7, (long)  14, (long)  21, (long)  28, (long)  35, (long)  42, (long)  49, (long)  56, (long)  63, (long)  70, (long)  77, (long)  84, (long)  91, (long)  98, (long) 105, (long) 112) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestLong16", "test_long16_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_long16_xor"))
            using (var ma = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<long16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long16>()))
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
            Assert.AreEqual(  18, r[0].s8);
            Assert.AreEqual( 116, r[0].s9);
            Assert.AreEqual( 122, r[0].sa);
            Assert.AreEqual( 104, r[0].sb);
            Assert.AreEqual(  26, r[0].sc);
            Assert.AreEqual(  36, r[0].sd);
            Assert.AreEqual(  34, r[0].se);
            Assert.AreEqual(  32, r[0].sf);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);
            Assert.AreEqual(  58, r[1].s4);
            Assert.AreEqual(  52, r[1].s5);
            Assert.AreEqual(  18, r[1].s6);
            Assert.AreEqual(  16, r[1].s7);
            Assert.AreEqual(  18, r[1].s8);
            Assert.AreEqual( 116, r[1].s9);
            Assert.AreEqual( 122, r[1].sa);
            Assert.AreEqual( 104, r[1].sb);
            Assert.AreEqual(  26, r[1].sc);
            Assert.AreEqual(  36, r[1].sd);
            Assert.AreEqual(  34, r[1].se);
            Assert.AreEqual(  32, r[1].sf);
        }

    }
}
