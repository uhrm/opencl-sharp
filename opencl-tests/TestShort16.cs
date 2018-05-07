
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
    public class TestShort16
    {
        [Kernel]
        private static void test_short16_add([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_add,
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_add"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_add"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_sub([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_sub,
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_sub"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_sub"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_mul([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_mul,
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_mul"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_mul"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_div([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_div,
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_div"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_div"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_eq([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_eq,
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_eq"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_eq"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_neq([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_neq,
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_neq"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_neq"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_lt([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_lt,
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_lt"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_lt"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_le([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_le,
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_le"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_le"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_gt([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_gt,
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_gt"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_gt"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_ge([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_ge,
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_ge"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
            var a = new short16[] { new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15), new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15) };
            var b = new short16[] { new short16((short)   0, (short)   1, (short)   2, (short)   3, (short)   4, (short)   5, (short)   6, (short)   7, (short)   8, (short)   9, (short)  10, (short)  11, (short)  12, (short)  13, (short)  14, (short)  15), new short16((short)  30, (short)  29, (short)  28, (short)  27, (short)  26, (short)  25, (short)  24, (short)  23, (short)  22, (short)  21, (short)  20, (short)  19, (short)  18, (short)  17, (short)  16, (short)  15) };
            var r = new short16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_ge"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_and([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_and,
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_and"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_or([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_or,
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_or"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
        private static void test_short16_xor([Global] short16[] a, [Global] short16[] b, [Global] short16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short16[],short16[],short16[]>)test_short16_xor,
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
            var a = new short16[] { new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112), new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80) };
            var b = new short16[] { new short16((short)   5, (short)  10, (short)  15, (short)  20, (short)  25, (short)  30, (short)  35, (short)  40, (short)  45, (short)  50, (short)  55, (short)  60, (short)  65, (short)  70, (short)  75, (short)  80), new short16((short)   7, (short)  14, (short)  21, (short)  28, (short)  35, (short)  42, (short)  49, (short)  56, (short)  63, (short)  70, (short)  77, (short)  84, (short)  91, (short)  98, (short) 105, (short) 112) };
            var r = new short16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort16", "test_short16_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short16_xor"))
            using (var ma = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short16>()))
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
