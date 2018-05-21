
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
    public class TestUint16
    {
        [Kernel]
        private static void test_uint16_add([Global] uint16[] a, [Global] uint16[] b, [Global] uint16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],uint16[]>)test_uint16_add,
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_add"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_add"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
        private static void test_uint16_sub([Global] uint16[] a, [Global] uint16[] b, [Global] uint16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],uint16[]>)test_uint16_sub,
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
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
            Assert.AreEqual(4294967290, r[1].s2);
            Assert.AreEqual(4294967288, r[1].s3);
            Assert.AreEqual(4294967286, r[1].s4);
            Assert.AreEqual(4294967284, r[1].s5);
            Assert.AreEqual(4294967282, r[1].s6);
            Assert.AreEqual(4294967280, r[1].s7);
            Assert.AreEqual(4294967278, r[1].s8);
            Assert.AreEqual(4294967276, r[1].s9);
            Assert.AreEqual(4294967274, r[1].sa);
            Assert.AreEqual(4294967272, r[1].sb);
            Assert.AreEqual(4294967270, r[1].sc);
            Assert.AreEqual(4294967268, r[1].sd);
            Assert.AreEqual(4294967266, r[1].se);
            Assert.AreEqual(4294967264, r[1].sf);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_sub"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
            Assert.AreEqual(4294967290, r[1].s2);
            Assert.AreEqual(4294967288, r[1].s3);
            Assert.AreEqual(4294967286, r[1].s4);
            Assert.AreEqual(4294967284, r[1].s5);
            Assert.AreEqual(4294967282, r[1].s6);
            Assert.AreEqual(4294967280, r[1].s7);
            Assert.AreEqual(4294967278, r[1].s8);
            Assert.AreEqual(4294967276, r[1].s9);
            Assert.AreEqual(4294967274, r[1].sa);
            Assert.AreEqual(4294967272, r[1].sb);
            Assert.AreEqual(4294967270, r[1].sc);
            Assert.AreEqual(4294967268, r[1].sd);
            Assert.AreEqual(4294967266, r[1].se);
            Assert.AreEqual(4294967264, r[1].sf);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_sub"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
            Assert.AreEqual(4294967290, r[1].s2);
            Assert.AreEqual(4294967288, r[1].s3);
            Assert.AreEqual(4294967286, r[1].s4);
            Assert.AreEqual(4294967284, r[1].s5);
            Assert.AreEqual(4294967282, r[1].s6);
            Assert.AreEqual(4294967280, r[1].s7);
            Assert.AreEqual(4294967278, r[1].s8);
            Assert.AreEqual(4294967276, r[1].s9);
            Assert.AreEqual(4294967274, r[1].sa);
            Assert.AreEqual(4294967272, r[1].sb);
            Assert.AreEqual(4294967270, r[1].sc);
            Assert.AreEqual(4294967268, r[1].sd);
            Assert.AreEqual(4294967266, r[1].se);
            Assert.AreEqual(4294967264, r[1].sf);
        }

        [Kernel]
        private static void test_uint16_mul([Global] uint16[] a, [Global] uint16[] b, [Global] uint16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],uint16[]>)test_uint16_mul,
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
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_mul"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_mul"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
        private static void test_uint16_div([Global] uint16[] a, [Global] uint16[] b, [Global] uint16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],uint16[]>)test_uint16_div,
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_div"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_div"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
        private static void test_uint16_eq([Global] uint16[] a, [Global] uint16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],int16[]>)test_uint16_eq,
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_eq"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_eq"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint16_neq([Global] uint16[] a, [Global] uint16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],int16[]>)test_uint16_neq,
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_neq"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_neq"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint16_lt([Global] uint16[] a, [Global] uint16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],int16[]>)test_uint16_lt,
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_lt"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_lt"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint16_le([Global] uint16[] a, [Global] uint16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],int16[]>)test_uint16_le,
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_le"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_le"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint16_gt([Global] uint16[] a, [Global] uint16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],int16[]>)test_uint16_gt,
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_gt"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_gt"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint16_ge([Global] uint16[] a, [Global] uint16[] b, [Global] int16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],int16[]>)test_uint16_ge,
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_ge"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new uint16[] { new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15), new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15) };
            var b = new uint16[] { new uint16((uint)   0, (uint)   1, (uint)   2, (uint)   3, (uint)   4, (uint)   5, (uint)   6, (uint)   7, (uint)   8, (uint)   9, (uint)  10, (uint)  11, (uint)  12, (uint)  13, (uint)  14, (uint)  15), new uint16((uint)  30, (uint)  29, (uint)  28, (uint)  27, (uint)  26, (uint)  25, (uint)  24, (uint)  23, (uint)  22, (uint)  21, (uint)  20, (uint)  19, (uint)  18, (uint)  17, (uint)  16, (uint)  15) };
            var r = new int16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_ge"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_uint16_and([Global] uint16[] a, [Global] uint16[] b, [Global] uint16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAndManaged()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],uint16[]>)test_uint16_and,
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_and"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_and", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_and"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
        private static void test_uint16_or([Global] uint16[] a, [Global] uint16[] b, [Global] uint16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestOrManaged()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],uint16[]>)test_uint16_or,
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_or"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_or", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_or"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
        private static void test_uint16_xor([Global] uint16[] a, [Global] uint16[] b, [Global] uint16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestXorManaged()
        {
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint16[],uint16[],uint16[]>)test_uint16_xor,
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_xor"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
            var a = new uint16[] { new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112), new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80) };
            var b = new uint16[] { new uint16((uint)   5, (uint)  10, (uint)  15, (uint)  20, (uint)  25, (uint)  30, (uint)  35, (uint)  40, (uint)  45, (uint)  50, (uint)  55, (uint)  60, (uint)  65, (uint)  70, (uint)  75, (uint)  80), new uint16((uint)   7, (uint)  14, (uint)  21, (uint)  28, (uint)  35, (uint)  42, (uint)  49, (uint)  56, (uint)  63, (uint)  70, (uint)  77, (uint)  84, (uint)  91, (uint)  98, (uint) 105, (uint) 112) };
            var r = new uint16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint16", "test_uint16_xor", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint16_xor"))
            using (var ma = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint16>()))
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
