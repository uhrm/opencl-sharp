
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
    public class TestByte16
    {
        [Kernel]
        private static void test_byte16_add([Global] byte16[] a, [Global] byte16[] b, [Global] byte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],byte16[]>)test_byte16_add,
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
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_add"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_add"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
        private static void test_byte16_sub([Global] byte16[] a, [Global] byte16[] b, [Global] byte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],byte16[]>)test_byte16_sub,
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
            Assert.AreEqual( 248, r[1].s3);
            Assert.AreEqual( 246, r[1].s4);
            Assert.AreEqual( 244, r[1].s5);
            Assert.AreEqual( 242, r[1].s6);
            Assert.AreEqual( 240, r[1].s7);
            Assert.AreEqual( 238, r[1].s8);
            Assert.AreEqual( 236, r[1].s9);
            Assert.AreEqual( 234, r[1].sa);
            Assert.AreEqual( 232, r[1].sb);
            Assert.AreEqual( 230, r[1].sc);
            Assert.AreEqual( 228, r[1].sd);
            Assert.AreEqual( 226, r[1].se);
            Assert.AreEqual( 224, r[1].sf);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_sub"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
            Assert.AreEqual( 248, r[1].s3);
            Assert.AreEqual( 246, r[1].s4);
            Assert.AreEqual( 244, r[1].s5);
            Assert.AreEqual( 242, r[1].s6);
            Assert.AreEqual( 240, r[1].s7);
            Assert.AreEqual( 238, r[1].s8);
            Assert.AreEqual( 236, r[1].s9);
            Assert.AreEqual( 234, r[1].sa);
            Assert.AreEqual( 232, r[1].sb);
            Assert.AreEqual( 230, r[1].sc);
            Assert.AreEqual( 228, r[1].sd);
            Assert.AreEqual( 226, r[1].se);
            Assert.AreEqual( 224, r[1].sf);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_sub"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
            Assert.AreEqual( 248, r[1].s3);
            Assert.AreEqual( 246, r[1].s4);
            Assert.AreEqual( 244, r[1].s5);
            Assert.AreEqual( 242, r[1].s6);
            Assert.AreEqual( 240, r[1].s7);
            Assert.AreEqual( 238, r[1].s8);
            Assert.AreEqual( 236, r[1].s9);
            Assert.AreEqual( 234, r[1].sa);
            Assert.AreEqual( 232, r[1].sb);
            Assert.AreEqual( 230, r[1].sc);
            Assert.AreEqual( 228, r[1].sd);
            Assert.AreEqual( 226, r[1].se);
            Assert.AreEqual( 224, r[1].sf);
        }

        [Kernel]
        private static void test_byte16_mul([Global] byte16[] a, [Global] byte16[] b, [Global] byte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],byte16[]>)test_byte16_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( 236, r[0].s5);
            Assert.AreEqual( 179, r[0].s6);
            Assert.AreEqual( 192, r[0].s7);
            Assert.AreEqual(  19, r[0].s8);
            Assert.AreEqual( 172, r[0].s9);
            Assert.AreEqual( 139, r[0].sa);
            Assert.AreEqual( 176, r[0].sb);
            Assert.AreEqual(  27, r[0].sc);
            Assert.AreEqual( 204, r[0].sd);
            Assert.AreEqual( 195, r[0].se);
            Assert.AreEqual(   0, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( 236, r[1].s5);
            Assert.AreEqual( 179, r[1].s6);
            Assert.AreEqual( 192, r[1].s7);
            Assert.AreEqual(  19, r[1].s8);
            Assert.AreEqual( 172, r[1].s9);
            Assert.AreEqual( 139, r[1].sa);
            Assert.AreEqual( 176, r[1].sb);
            Assert.AreEqual(  27, r[1].sc);
            Assert.AreEqual( 204, r[1].sd);
            Assert.AreEqual( 195, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_mul"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( 236, r[0].s5);
            Assert.AreEqual( 179, r[0].s6);
            Assert.AreEqual( 192, r[0].s7);
            Assert.AreEqual(  19, r[0].s8);
            Assert.AreEqual( 172, r[0].s9);
            Assert.AreEqual( 139, r[0].sa);
            Assert.AreEqual( 176, r[0].sb);
            Assert.AreEqual(  27, r[0].sc);
            Assert.AreEqual( 204, r[0].sd);
            Assert.AreEqual( 195, r[0].se);
            Assert.AreEqual(   0, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( 236, r[1].s5);
            Assert.AreEqual( 179, r[1].s6);
            Assert.AreEqual( 192, r[1].s7);
            Assert.AreEqual(  19, r[1].s8);
            Assert.AreEqual( 172, r[1].s9);
            Assert.AreEqual( 139, r[1].sa);
            Assert.AreEqual( 176, r[1].sb);
            Assert.AreEqual(  27, r[1].sc);
            Assert.AreEqual( 204, r[1].sd);
            Assert.AreEqual( 195, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_mul"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual( 107, r[0].s4);
            Assert.AreEqual( 236, r[0].s5);
            Assert.AreEqual( 179, r[0].s6);
            Assert.AreEqual( 192, r[0].s7);
            Assert.AreEqual(  19, r[0].s8);
            Assert.AreEqual( 172, r[0].s9);
            Assert.AreEqual( 139, r[0].sa);
            Assert.AreEqual( 176, r[0].sb);
            Assert.AreEqual(  27, r[0].sc);
            Assert.AreEqual( 204, r[0].sd);
            Assert.AreEqual( 195, r[0].se);
            Assert.AreEqual(   0, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( 236, r[1].s5);
            Assert.AreEqual( 179, r[1].s6);
            Assert.AreEqual( 192, r[1].s7);
            Assert.AreEqual(  19, r[1].s8);
            Assert.AreEqual( 172, r[1].s9);
            Assert.AreEqual( 139, r[1].sa);
            Assert.AreEqual( 176, r[1].sb);
            Assert.AreEqual(  27, r[1].sc);
            Assert.AreEqual( 204, r[1].sd);
            Assert.AreEqual( 195, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Kernel]
        private static void test_byte16_div([Global] byte16[] a, [Global] byte16[] b, [Global] byte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],byte16[]>)test_byte16_div,
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
        [Category("Compiled.Cl")]
        public void TestDivCl()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_div"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
        [Category("Compiled.SpirV")]
        public void TestDivSpirV()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_div"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
        private static void test_byte16_eq([Global] byte16[] a, [Global] byte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],sbyte16[]>)test_byte16_eq,
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_eq"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_eq"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_byte16_neq([Global] byte16[] a, [Global] byte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],sbyte16[]>)test_byte16_neq,
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_neq"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_neq"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_byte16_lt([Global] byte16[] a, [Global] byte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],sbyte16[]>)test_byte16_lt,
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_lt"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_lt"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_byte16_le([Global] byte16[] a, [Global] byte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],sbyte16[]>)test_byte16_le,
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_le"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_le"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_byte16_gt([Global] byte16[] a, [Global] byte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],sbyte16[]>)test_byte16_gt,
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_gt"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_gt"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_byte16_ge([Global] byte16[] a, [Global] byte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],sbyte16[]>)test_byte16_ge,
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_ge"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new byte16[] { new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15), new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15) };
            var b = new byte16[] { new byte16((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7, (byte)   8, (byte)   9, (byte)  10, (byte)  11, (byte)  12, (byte)  13, (byte)  14, (byte)  15), new byte16((byte)  30, (byte)  29, (byte)  28, (byte)  27, (byte)  26, (byte)  25, (byte)  24, (byte)  23, (byte)  22, (byte)  21, (byte)  20, (byte)  19, (byte)  18, (byte)  17, (byte)  16, (byte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_ge"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_byte16_and([Global] byte16[] a, [Global] byte16[] b, [Global] byte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAndManaged()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],byte16[]>)test_byte16_and,
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
        [Category("Compiled.Cl")]
        public void TestAndCl()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_and"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAndSpirV()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_and", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_and"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
        private static void test_byte16_or([Global] byte16[] a, [Global] byte16[] b, [Global] byte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestOrManaged()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],byte16[]>)test_byte16_or,
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
        [Category("Compiled.Cl")]
        public void TestOrCl()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_or"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestOrSpirV()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_or", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_or"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
        private static void test_byte16_xor([Global] byte16[] a, [Global] byte16[] b, [Global] byte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestXorManaged()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte16[],byte16[],byte16[]>)test_byte16_xor,
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
        [Category("Compiled.Cl")]
        public void TestXorCl()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_xor"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestXorSpirV()
        {
            var a = new byte16[] { new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112), new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80) };
            var b = new byte16[] { new byte16((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40, (byte)  45, (byte)  50, (byte)  55, (byte)  60, (byte)  65, (byte)  70, (byte)  75, (byte)  80), new byte16((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56, (byte)  63, (byte)  70, (byte)  77, (byte)  84, (byte)  91, (byte)  98, (byte) 105, (byte) 112) };
            var r = new byte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte16", "test_byte16_xor", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte16_xor"))
            using (var ma = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte16>()))
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
