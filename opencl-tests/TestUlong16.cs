
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
    public class TestUlong16
    {
        [Kernel]
        private static void test_ulong16_add([Global] ulong16[] a, [Global] ulong16[] b, [Global] ulong16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],ulong16[]>)test_ulong16_add,
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_add"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_add"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
        private static void test_ulong16_sub([Global] ulong16[] a, [Global] ulong16[] b, [Global] ulong16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],ulong16[]>)test_ulong16_sub,
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
            Assert.AreEqual(18446744073709551614, r[1].s0);
            Assert.AreEqual(18446744073709551612, r[1].s1);
            Assert.AreEqual(18446744073709551610, r[1].s2);
            Assert.AreEqual(18446744073709551608, r[1].s3);
            Assert.AreEqual(18446744073709551606, r[1].s4);
            Assert.AreEqual(18446744073709551604, r[1].s5);
            Assert.AreEqual(18446744073709551602, r[1].s6);
            Assert.AreEqual(18446744073709551600, r[1].s7);
            Assert.AreEqual(18446744073709551598, r[1].s8);
            Assert.AreEqual(18446744073709551596, r[1].s9);
            Assert.AreEqual(18446744073709551594, r[1].sa);
            Assert.AreEqual(18446744073709551592, r[1].sb);
            Assert.AreEqual(18446744073709551590, r[1].sc);
            Assert.AreEqual(18446744073709551588, r[1].sd);
            Assert.AreEqual(18446744073709551586, r[1].se);
            Assert.AreEqual(18446744073709551584, r[1].sf);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_sub"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            Assert.AreEqual(18446744073709551614, r[1].s0);
            Assert.AreEqual(18446744073709551612, r[1].s1);
            Assert.AreEqual(18446744073709551610, r[1].s2);
            Assert.AreEqual(18446744073709551608, r[1].s3);
            Assert.AreEqual(18446744073709551606, r[1].s4);
            Assert.AreEqual(18446744073709551604, r[1].s5);
            Assert.AreEqual(18446744073709551602, r[1].s6);
            Assert.AreEqual(18446744073709551600, r[1].s7);
            Assert.AreEqual(18446744073709551598, r[1].s8);
            Assert.AreEqual(18446744073709551596, r[1].s9);
            Assert.AreEqual(18446744073709551594, r[1].sa);
            Assert.AreEqual(18446744073709551592, r[1].sb);
            Assert.AreEqual(18446744073709551590, r[1].sc);
            Assert.AreEqual(18446744073709551588, r[1].sd);
            Assert.AreEqual(18446744073709551586, r[1].se);
            Assert.AreEqual(18446744073709551584, r[1].sf);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_sub"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            Assert.AreEqual(18446744073709551614, r[1].s0);
            Assert.AreEqual(18446744073709551612, r[1].s1);
            Assert.AreEqual(18446744073709551610, r[1].s2);
            Assert.AreEqual(18446744073709551608, r[1].s3);
            Assert.AreEqual(18446744073709551606, r[1].s4);
            Assert.AreEqual(18446744073709551604, r[1].s5);
            Assert.AreEqual(18446744073709551602, r[1].s6);
            Assert.AreEqual(18446744073709551600, r[1].s7);
            Assert.AreEqual(18446744073709551598, r[1].s8);
            Assert.AreEqual(18446744073709551596, r[1].s9);
            Assert.AreEqual(18446744073709551594, r[1].sa);
            Assert.AreEqual(18446744073709551592, r[1].sb);
            Assert.AreEqual(18446744073709551590, r[1].sc);
            Assert.AreEqual(18446744073709551588, r[1].sd);
            Assert.AreEqual(18446744073709551586, r[1].se);
            Assert.AreEqual(18446744073709551584, r[1].sf);
        }

        [Kernel]
        private static void test_ulong16_mul([Global] ulong16[] a, [Global] ulong16[] b, [Global] ulong16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],ulong16[]>)test_ulong16_mul,
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_mul"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_mul"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
        private static void test_ulong16_div([Global] ulong16[] a, [Global] ulong16[] b, [Global] ulong16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],ulong16[]>)test_ulong16_div,
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_div"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_div"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
        private static void test_ulong16_eq([Global] ulong16[] a, [Global] ulong16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],long16[]>)test_ulong16_eq,
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
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_eq"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestEqSpirV()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_eq"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_ulong16_neq([Global] ulong16[] a, [Global] ulong16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],long16[]>)test_ulong16_neq,
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
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_neq"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestNeqSpirV()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_neq"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_ulong16_lt([Global] ulong16[] a, [Global] ulong16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],long16[]>)test_ulong16_lt,
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
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_lt"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLtSpirV()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_lt"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_ulong16_le([Global] ulong16[] a, [Global] ulong16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],long16[]>)test_ulong16_le,
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
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_le"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLeSpirV()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_le"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_ulong16_gt([Global] ulong16[] a, [Global] ulong16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],long16[]>)test_ulong16_gt,
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
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_gt"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGtSpirV()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_gt"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_ulong16_ge([Global] ulong16[] a, [Global] ulong16[] b, [Global] long16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],long16[]>)test_ulong16_ge,
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
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_ge"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGeSpirV()
        {
            var a = new ulong16[] { new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15), new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15) };
            var b = new ulong16[] { new ulong16((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7, (ulong)   8, (ulong)   9, (ulong)  10, (ulong)  11, (ulong)  12, (ulong)  13, (ulong)  14, (ulong)  15), new ulong16((ulong)  30, (ulong)  29, (ulong)  28, (ulong)  27, (ulong)  26, (ulong)  25, (ulong)  24, (ulong)  23, (ulong)  22, (ulong)  21, (ulong)  20, (ulong)  19, (ulong)  18, (ulong)  17, (ulong)  16, (ulong)  15) };
            var r = new long16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_ge"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_ulong16_and([Global] ulong16[] a, [Global] ulong16[] b, [Global] ulong16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAndManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],ulong16[]>)test_ulong16_and,
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_and"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_and", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_and"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
        private static void test_ulong16_or([Global] ulong16[] a, [Global] ulong16[] b, [Global] ulong16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestOrManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],ulong16[]>)test_ulong16_or,
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_or"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_or", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_or"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
        private static void test_ulong16_xor([Global] ulong16[] a, [Global] ulong16[] b, [Global] ulong16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestXorManaged()
        {
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong16[],ulong16[],ulong16[]>)test_ulong16_xor,
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_xor"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
            var a = new ulong16[] { new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112), new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80) };
            var b = new ulong16[] { new ulong16((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40, (ulong)  45, (ulong)  50, (ulong)  55, (ulong)  60, (ulong)  65, (ulong)  70, (ulong)  75, (ulong)  80), new ulong16((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56, (ulong)  63, (ulong)  70, (ulong)  77, (ulong)  84, (ulong)  91, (ulong)  98, (ulong) 105, (ulong) 112) };
            var r = new ulong16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong16", "test_ulong16_xor", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong16_xor"))
            using (var ma = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong16>()))
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
