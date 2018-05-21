
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
    public class TestUlong8
    {
        [Kernel]
        private static void test_ulong8_add([Global] ulong8[] a, [Global] ulong8[] b, [Global] ulong8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],ulong8[]>)test_ulong8_add,
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_add"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_add"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
        private static void test_ulong8_sub([Global] ulong8[] a, [Global] ulong8[] b, [Global] ulong8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],ulong8[]>)test_ulong8_sub,
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
            Assert.AreEqual(18446744073709551614, r[1].s0);
            Assert.AreEqual(18446744073709551612, r[1].s1);
            Assert.AreEqual(18446744073709551610, r[1].s2);
            Assert.AreEqual(18446744073709551608, r[1].s3);
            Assert.AreEqual(18446744073709551606, r[1].s4);
            Assert.AreEqual(18446744073709551604, r[1].s5);
            Assert.AreEqual(18446744073709551602, r[1].s6);
            Assert.AreEqual(18446744073709551600, r[1].s7);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_sub"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
            Assert.AreEqual(18446744073709551614, r[1].s0);
            Assert.AreEqual(18446744073709551612, r[1].s1);
            Assert.AreEqual(18446744073709551610, r[1].s2);
            Assert.AreEqual(18446744073709551608, r[1].s3);
            Assert.AreEqual(18446744073709551606, r[1].s4);
            Assert.AreEqual(18446744073709551604, r[1].s5);
            Assert.AreEqual(18446744073709551602, r[1].s6);
            Assert.AreEqual(18446744073709551600, r[1].s7);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_sub"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
            Assert.AreEqual(18446744073709551614, r[1].s0);
            Assert.AreEqual(18446744073709551612, r[1].s1);
            Assert.AreEqual(18446744073709551610, r[1].s2);
            Assert.AreEqual(18446744073709551608, r[1].s3);
            Assert.AreEqual(18446744073709551606, r[1].s4);
            Assert.AreEqual(18446744073709551604, r[1].s5);
            Assert.AreEqual(18446744073709551602, r[1].s6);
            Assert.AreEqual(18446744073709551600, r[1].s7);
        }

        [Kernel]
        private static void test_ulong8_mul([Global] ulong8[] a, [Global] ulong8[] b, [Global] ulong8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],ulong8[]>)test_ulong8_mul,
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
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_mul"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_mul"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
        private static void test_ulong8_div([Global] ulong8[] a, [Global] ulong8[] b, [Global] ulong8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],ulong8[]>)test_ulong8_div,
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_div"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_div"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
        private static void test_ulong8_eq([Global] ulong8[] a, [Global] ulong8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],long8[]>)test_ulong8_eq,
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_eq"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_eq"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_ulong8_neq([Global] ulong8[] a, [Global] ulong8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],long8[]>)test_ulong8_neq,
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_neq"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_neq"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_ulong8_lt([Global] ulong8[] a, [Global] ulong8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],long8[]>)test_ulong8_lt,
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_lt"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_lt"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_ulong8_le([Global] ulong8[] a, [Global] ulong8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],long8[]>)test_ulong8_le,
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_le"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_le"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_ulong8_gt([Global] ulong8[] a, [Global] ulong8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],long8[]>)test_ulong8_gt,
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_gt"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_gt"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_ulong8_ge([Global] ulong8[] a, [Global] ulong8[] b, [Global] long8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],long8[]>)test_ulong8_ge,
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_ge"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
            var a = new ulong8[] { new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7), new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7) };
            var b = new ulong8[] { new ulong8((ulong)   0, (ulong)   1, (ulong)   2, (ulong)   3, (ulong)   4, (ulong)   5, (ulong)   6, (ulong)   7), new ulong8((ulong)  14, (ulong)  13, (ulong)  12, (ulong)  11, (ulong)  10, (ulong)   9, (ulong)   8, (ulong)   7) };
            var r = new long8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_ge"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long8>()))
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
        private static void test_ulong8_and([Global] ulong8[] a, [Global] ulong8[] b, [Global] ulong8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAndManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],ulong8[]>)test_ulong8_and,
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_and"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_and", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_and"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
        private static void test_ulong8_or([Global] ulong8[] a, [Global] ulong8[] b, [Global] ulong8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestOrManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],ulong8[]>)test_ulong8_or,
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_or"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_or", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_or"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
        private static void test_ulong8_xor([Global] ulong8[] a, [Global] ulong8[] b, [Global] ulong8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestXorManaged()
        {
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ulong8[],ulong8[],ulong8[]>)test_ulong8_xor,
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_xor"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
            var a = new ulong8[] { new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56), new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40) };
            var b = new ulong8[] { new ulong8((ulong)   5, (ulong)  10, (ulong)  15, (ulong)  20, (ulong)  25, (ulong)  30, (ulong)  35, (ulong)  40), new ulong8((ulong)   7, (ulong)  14, (ulong)  21, (ulong)  28, (ulong)  35, (ulong)  42, (ulong)  49, (ulong)  56) };
            var r = new ulong8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUlong8", "test_ulong8_xor", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_ulong8_xor"))
            using (var ma = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<ulong8>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<ulong8>()))
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
