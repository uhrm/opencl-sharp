
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
    public class TestInt16
    {
        [Kernel]
        private static void test_int16_add([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_add,
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_add"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_add"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_int16_sub([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_sub,
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_sub"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_sub"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_int16_mul([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_mul,
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_mul"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_mul"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_int16_div([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_div,
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_div"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_div"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_int16_eq([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_eq,
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
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_eq"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestEqSpirV()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_eq"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_int16_neq([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_neq,
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
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_neq"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestNeqSpirV()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_neq"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_int16_lt([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_lt,
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
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_lt"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestLtSpirV()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_lt"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_int16_le([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_le,
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
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_le"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestLeSpirV()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_le"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_int16_gt([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_gt,
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
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_gt"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestGtSpirV()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_gt"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_int16_ge([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_ge,
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
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_ge"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        public void TestGeSpirV()
        {
            var a = new int16[] { new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15), new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15) };
            var b = new int16[] { new int16((int)   0, (int)   1, (int)   2, (int)   3, (int)   4, (int)   5, (int)   6, (int)   7, (int)   8, (int)   9, (int)  10, (int)  11, (int)  12, (int)  13, (int)  14, (int)  15), new int16((int)  30, (int)  29, (int)  28, (int)  27, (int)  26, (int)  25, (int)  24, (int)  23, (int)  22, (int)  21, (int)  20, (int)  19, (int)  18, (int)  17, (int)  16, (int)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_ge"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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

        [Kernel]
        private static void test_int16_and([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_and,
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_and"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_int16_or([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_or,
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_or"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
        private static void test_int16_xor([Global] int16[] a, [Global] int16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<int16[],int16[],int16[]>)test_int16_xor,
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
            var a = new int16[] { new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112), new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80) };
            var b = new int16[] { new int16((int)   5, (int)  10, (int)  15, (int)  20, (int)  25, (int)  30, (int)  35, (int)  40, (int)  45, (int)  50, (int)  55, (int)  60, (int)  65, (int)  70, (int)  75, (int)  80), new int16((int)   7, (int)  14, (int)  21, (int)  28, (int)  35, (int)  42, (int)  49, (int)  56, (int)  63, (int)  70, (int)  77, (int)  84, (int)  91, (int)  98, (int) 105, (int) 112) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestInt16", "test_int16_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_int16_xor"))
            using (var ma = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int16>()))
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
