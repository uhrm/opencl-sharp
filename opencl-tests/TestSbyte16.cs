
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
    public class TestSbyte16
    {
        [Kernel]
        private static void test_sbyte16_add([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_add,
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
            Assert.AreEqual(-124, r[0].sa);
            Assert.AreEqual(-112, r[0].sb);
            Assert.AreEqual(-100, r[0].sc);
            Assert.AreEqual( -88, r[0].sd);
            Assert.AreEqual( -76, r[0].se);
            Assert.AreEqual( -64, r[0].sf);
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
            Assert.AreEqual(-124, r[1].sa);
            Assert.AreEqual(-112, r[1].sb);
            Assert.AreEqual(-100, r[1].sc);
            Assert.AreEqual( -88, r[1].sd);
            Assert.AreEqual( -76, r[1].se);
            Assert.AreEqual( -64, r[1].sf);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_add"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            Assert.AreEqual(-124, r[0].sa);
            Assert.AreEqual(-112, r[0].sb);
            Assert.AreEqual(-100, r[0].sc);
            Assert.AreEqual( -88, r[0].sd);
            Assert.AreEqual( -76, r[0].se);
            Assert.AreEqual( -64, r[0].sf);
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
            Assert.AreEqual(-124, r[1].sa);
            Assert.AreEqual(-112, r[1].sb);
            Assert.AreEqual(-100, r[1].sc);
            Assert.AreEqual( -88, r[1].sd);
            Assert.AreEqual( -76, r[1].se);
            Assert.AreEqual( -64, r[1].sf);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_add"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            Assert.AreEqual(-124, r[0].sa);
            Assert.AreEqual(-112, r[0].sb);
            Assert.AreEqual(-100, r[0].sc);
            Assert.AreEqual( -88, r[0].sd);
            Assert.AreEqual( -76, r[0].se);
            Assert.AreEqual( -64, r[0].sf);
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
            Assert.AreEqual(-124, r[1].sa);
            Assert.AreEqual(-112, r[1].sb);
            Assert.AreEqual(-100, r[1].sc);
            Assert.AreEqual( -88, r[1].sd);
            Assert.AreEqual( -76, r[1].se);
            Assert.AreEqual( -64, r[1].sf);
        }

        [Kernel]
        private static void test_sbyte16_sub([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_sub,
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
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_sub"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_sub"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_sbyte16_mul([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_mul,
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
            Assert.AreEqual(  19, r[0].s8);
            Assert.AreEqual( -84, r[0].s9);
            Assert.AreEqual(-117, r[0].sa);
            Assert.AreEqual( -80, r[0].sb);
            Assert.AreEqual(  27, r[0].sc);
            Assert.AreEqual( -52, r[0].sd);
            Assert.AreEqual( -61, r[0].se);
            Assert.AreEqual(   0, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);
            Assert.AreEqual(  19, r[1].s8);
            Assert.AreEqual( -84, r[1].s9);
            Assert.AreEqual(-117, r[1].sa);
            Assert.AreEqual( -80, r[1].sb);
            Assert.AreEqual(  27, r[1].sc);
            Assert.AreEqual( -52, r[1].sd);
            Assert.AreEqual( -61, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_mul"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            Assert.AreEqual(  19, r[0].s8);
            Assert.AreEqual( -84, r[0].s9);
            Assert.AreEqual(-117, r[0].sa);
            Assert.AreEqual( -80, r[0].sb);
            Assert.AreEqual(  27, r[0].sc);
            Assert.AreEqual( -52, r[0].sd);
            Assert.AreEqual( -61, r[0].se);
            Assert.AreEqual(   0, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);
            Assert.AreEqual(  19, r[1].s8);
            Assert.AreEqual( -84, r[1].s9);
            Assert.AreEqual(-117, r[1].sa);
            Assert.AreEqual( -80, r[1].sb);
            Assert.AreEqual(  27, r[1].sc);
            Assert.AreEqual( -52, r[1].sd);
            Assert.AreEqual( -61, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_mul"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            Assert.AreEqual(  19, r[0].s8);
            Assert.AreEqual( -84, r[0].s9);
            Assert.AreEqual(-117, r[0].sa);
            Assert.AreEqual( -80, r[0].sb);
            Assert.AreEqual(  27, r[0].sc);
            Assert.AreEqual( -52, r[0].sd);
            Assert.AreEqual( -61, r[0].se);
            Assert.AreEqual(   0, r[0].sf);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( -20, r[1].s5);
            Assert.AreEqual( -77, r[1].s6);
            Assert.AreEqual( -64, r[1].s7);
            Assert.AreEqual(  19, r[1].s8);
            Assert.AreEqual( -84, r[1].s9);
            Assert.AreEqual(-117, r[1].sa);
            Assert.AreEqual( -80, r[1].sb);
            Assert.AreEqual(  27, r[1].sc);
            Assert.AreEqual( -52, r[1].sd);
            Assert.AreEqual( -61, r[1].se);
            Assert.AreEqual(   0, r[1].sf);
        }

        [Kernel]
        private static void test_sbyte16_div([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_div,
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_div"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_div"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_sbyte16_eq([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_eq,
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_eq"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_eq"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_sbyte16_neq([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_neq,
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_neq"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_neq"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_sbyte16_lt([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_lt,
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_lt"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_lt"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_sbyte16_le([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_le,
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_le"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_le"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_sbyte16_gt([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_gt,
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_gt"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_gt"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_sbyte16_ge([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_ge,
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_ge"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
            var a = new sbyte16[] { new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15), new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15) };
            var b = new sbyte16[] { new sbyte16((sbyte)   0, (sbyte)   1, (sbyte)   2, (sbyte)   3, (sbyte)   4, (sbyte)   5, (sbyte)   6, (sbyte)   7, (sbyte)   8, (sbyte)   9, (sbyte)  10, (sbyte)  11, (sbyte)  12, (sbyte)  13, (sbyte)  14, (sbyte)  15), new sbyte16((sbyte)  30, (sbyte)  29, (sbyte)  28, (sbyte)  27, (sbyte)  26, (sbyte)  25, (sbyte)  24, (sbyte)  23, (sbyte)  22, (sbyte)  21, (sbyte)  20, (sbyte)  19, (sbyte)  18, (sbyte)  17, (sbyte)  16, (sbyte)  15) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_ge"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_sbyte16_and([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAndManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_and,
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_and"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_and", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_and"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_sbyte16_or([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestOrManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_or,
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_or"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_or", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_or"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
        private static void test_sbyte16_xor([Global] sbyte16[] a, [Global] sbyte16[] b, [Global] sbyte16[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestXorManaged()
        {
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte16[],sbyte16[],sbyte16[]>)test_sbyte16_xor,
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_xor"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
            var a = new sbyte16[] { new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112), new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80) };
            var b = new sbyte16[] { new sbyte16((sbyte)   5, (sbyte)  10, (sbyte)  15, (sbyte)  20, (sbyte)  25, (sbyte)  30, (sbyte)  35, (sbyte)  40, (sbyte)  45, (sbyte)  50, (sbyte)  55, (sbyte)  60, (sbyte)  65, (sbyte)  70, (sbyte)  75, (sbyte)  80), new sbyte16((sbyte)   7, (sbyte)  14, (sbyte)  21, (sbyte)  28, (sbyte)  35, (sbyte)  42, (sbyte)  49, (sbyte)  56, (sbyte)  63, (sbyte)  70, (sbyte)  77, (sbyte)  84, (sbyte)  91, (sbyte)  98, (sbyte) 105, (sbyte) 112) };
            var r = new sbyte16[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte16", "test_sbyte16_xor", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte16_xor"))
            using (var ma = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte16>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte16>()))
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
