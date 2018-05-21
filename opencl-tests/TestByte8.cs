
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
    public class TestByte8
    {
        [Kernel]
        private static void test_byte8_add([Global] byte8[] a, [Global] byte8[] b, [Global] byte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],byte8[]>)test_byte8_add,
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
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_add"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_add"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
        private static void test_byte8_sub([Global] byte8[] a, [Global] byte8[] b, [Global] byte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],byte8[]>)test_byte8_sub,
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
            Assert.AreEqual( 248, r[1].s3);
            Assert.AreEqual( 246, r[1].s4);
            Assert.AreEqual( 244, r[1].s5);
            Assert.AreEqual( 242, r[1].s6);
            Assert.AreEqual( 240, r[1].s7);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_sub"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
            Assert.AreEqual( 248, r[1].s3);
            Assert.AreEqual( 246, r[1].s4);
            Assert.AreEqual( 244, r[1].s5);
            Assert.AreEqual( 242, r[1].s6);
            Assert.AreEqual( 240, r[1].s7);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_sub"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
            Assert.AreEqual( 248, r[1].s3);
            Assert.AreEqual( 246, r[1].s4);
            Assert.AreEqual( 244, r[1].s5);
            Assert.AreEqual( 242, r[1].s6);
            Assert.AreEqual( 240, r[1].s7);
        }

        [Kernel]
        private static void test_byte8_mul([Global] byte8[] a, [Global] byte8[] b, [Global] byte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],byte8[]>)test_byte8_mul,
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( 236, r[1].s5);
            Assert.AreEqual( 179, r[1].s6);
            Assert.AreEqual( 192, r[1].s7);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_mul"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( 236, r[1].s5);
            Assert.AreEqual( 179, r[1].s6);
            Assert.AreEqual( 192, r[1].s7);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_mul"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual( 107, r[1].s4);
            Assert.AreEqual( 236, r[1].s5);
            Assert.AreEqual( 179, r[1].s6);
            Assert.AreEqual( 192, r[1].s7);
        }

        [Kernel]
        private static void test_byte8_div([Global] byte8[] a, [Global] byte8[] b, [Global] byte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],byte8[]>)test_byte8_div,
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
        [Category("Compiled.Cl")]
        public void TestDivCl()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_div"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
        [Category("Compiled.SpirV")]
        public void TestDivSpirV()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_div"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
        private static void test_byte8_eq([Global] byte8[] a, [Global] byte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],sbyte8[]>)test_byte8_eq,
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
        [Category("Compiled.Cl")]
        public void TestEqCl()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_eq"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestEqSpirV()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_eq"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte8_neq([Global] byte8[] a, [Global] byte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],sbyte8[]>)test_byte8_neq,
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
        [Category("Compiled.Cl")]
        public void TestNeqCl()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_neq"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestNeqSpirV()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_neq"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte8_lt([Global] byte8[] a, [Global] byte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],sbyte8[]>)test_byte8_lt,
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
        [Category("Compiled.Cl")]
        public void TestLtCl()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_lt"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLtSpirV()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_lt"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte8_le([Global] byte8[] a, [Global] byte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],sbyte8[]>)test_byte8_le,
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
        [Category("Compiled.Cl")]
        public void TestLeCl()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_le"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLeSpirV()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_le"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte8_gt([Global] byte8[] a, [Global] byte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],sbyte8[]>)test_byte8_gt,
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
        [Category("Compiled.Cl")]
        public void TestGtCl()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_gt"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGtSpirV()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_gt"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte8_ge([Global] byte8[] a, [Global] byte8[] b, [Global] sbyte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],sbyte8[]>)test_byte8_ge,
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
        [Category("Compiled.Cl")]
        public void TestGeCl()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_ge"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGeSpirV()
        {
            var a = new byte8[] { new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7), new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7) };
            var b = new byte8[] { new byte8((byte)   0, (byte)   1, (byte)   2, (byte)   3, (byte)   4, (byte)   5, (byte)   6, (byte)   7), new byte8((byte)  14, (byte)  13, (byte)  12, (byte)  11, (byte)  10, (byte)   9, (byte)   8, (byte)   7) };
            var r = new sbyte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_ge"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte8_and([Global] byte8[] a, [Global] byte8[] b, [Global] byte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAndManaged()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],byte8[]>)test_byte8_and,
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
        [Category("Compiled.Cl")]
        public void TestAndCl()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_and"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAndSpirV()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_and", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_and"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
        private static void test_byte8_or([Global] byte8[] a, [Global] byte8[] b, [Global] byte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestOrManaged()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],byte8[]>)test_byte8_or,
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
        [Category("Compiled.Cl")]
        public void TestOrCl()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_or"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestOrSpirV()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_or", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_or"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
        private static void test_byte8_xor([Global] byte8[] a, [Global] byte8[] b, [Global] byte8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestXorManaged()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte8[],byte8[],byte8[]>)test_byte8_xor,
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
        [Category("Compiled.Cl")]
        public void TestXorCl()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_xor"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestXorSpirV()
        {
            var a = new byte8[] { new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56), new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40) };
            var b = new byte8[] { new byte8((byte)   5, (byte)  10, (byte)  15, (byte)  20, (byte)  25, (byte)  30, (byte)  35, (byte)  40), new byte8((byte)   7, (byte)  14, (byte)  21, (byte)  28, (byte)  35, (byte)  42, (byte)  49, (byte)  56) };
            var r = new byte8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte8", "test_byte8_xor", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte8_xor"))
            using (var ma = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte8>()))
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
