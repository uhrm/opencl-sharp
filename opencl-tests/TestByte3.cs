
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
    public class TestByte3
    {
        [Kernel]
        private static void test_byte3_add([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
        }

        [Test]
        public void TestAddCl()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_add"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
        }

        [Test]
        public void TestAddSpirV()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_add"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_sub([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_sub"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_sub"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
            Assert.AreEqual( 250, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_mul([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual(  59, r[0].s2);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_mul"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_mul"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual(  59, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_div([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
        }

        [Test]
        public void TestDivCl()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_div"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
        }

        [Test]
        public void TestDivSpirV()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_div"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_eq([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Test]
        public void TestEqCl()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_eq"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Test]
        public void TestEqSpirV()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_eq"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_neq([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Test]
        public void TestNeqCl()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_neq"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Test]
        public void TestNeqSpirV()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_neq"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_lt([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Test]
        public void TestLtCl()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_lt"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Test]
        public void TestLtSpirV()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_lt"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_le([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Test]
        public void TestLeCl()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_le"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Test]
        public void TestLeSpirV()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_le"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_gt([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Test]
        public void TestGtCl()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_gt"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Test]
        public void TestGtSpirV()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_gt"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_ge([Global] byte3[] a, [Global] byte3[] b, [Global] sbyte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],sbyte3[]>)test_byte3_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Test]
        public void TestGeCl()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_ge"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Test]
        public void TestGeSpirV()
        {
            var a = new byte3[] { new byte3((byte)   4, (byte)   3, (byte)   2), new byte3((byte)   0, (byte)   1, (byte)   2) };
            var b = new byte3[] { new byte3((byte)   0, (byte)   1, (byte)   2), new byte3((byte)   4, (byte)   3, (byte)   2) };
            var r = new sbyte3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_ge"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte3>()))
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
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_and([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_and,
                a,
                b,
                r
            );
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[0].s2);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
        }

        [Test]
        public void TestAndCl()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_and"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_or([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_or,
                a,
                b,
                r
            );
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(  31, r[0].s2);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
        }

        [Test]
        public void TestOrCl()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_or"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
        }

        [Kernel]
        private static void test_byte3_xor([Global] byte3[] a, [Global] byte3[] b, [Global] byte3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte3[],byte3[],byte3[]>)test_byte3_xor,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  26, r[0].s2);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
        }

        [Test]
        public void TestXorCl()
        {
            var a = new byte3[] { new byte3((byte)   7, (byte)  14, (byte)  21), new byte3((byte)   5, (byte)  10, (byte)  15) };
            var b = new byte3[] { new byte3((byte)   5, (byte)  10, (byte)  15), new byte3((byte)   7, (byte)  14, (byte)  21) };
            var r = new byte3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_byte3_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte3_xor"))
            using (var ma = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte3>()))
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
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
        }

        [Kernel]
        private static void test_components1([Global] byte[] r, [Global] byte3[] w)
        {
            var ar = new byte3((byte)1, (byte)2, (byte)3);
            var aw = (byte)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
            r[2] = ar.z;
            w[2].z = aw;
        }

        [Test]
        public void TestComponentAccessors1Managed()
        {
            var nr = 3;
            var nw = 3;
            var r = new byte[nr];
            var w = new byte3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte[],byte3[]>)test_components1,
                r, w
            );
            Assert.AreEqual((byte)1, r[0]);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)0, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)2, r[1]);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)0, w[1].s0);
            Assert.AreEqual((byte)0, w[1].s2);
            Assert.AreEqual((byte)3, r[2]);
            Assert.AreEqual((byte)1, w[2].s2);
            Assert.AreEqual((byte)0, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s1);
        }

        [Test]
        public void TestComponentAccessors1Cl()
        {
            var nr = 3;
            var nw = 3;
            var r = new byte[nr];
            var w = new byte3[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<byte>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte>()))
            using (var mw = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(byte3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((byte)1, r[0]);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)0, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)2, r[1]);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)0, w[1].s0);
            Assert.AreEqual((byte)0, w[1].s2);
            Assert.AreEqual((byte)3, r[2]);
            Assert.AreEqual((byte)1, w[2].s2);
            Assert.AreEqual((byte)0, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s1);
        }
        [Kernel]
        private static void test_components2([Global] byte2[] r, [Global] byte3[] w)
        {
            var ar = new byte3((byte)1, (byte)2, (byte)3);
            var aw = new byte2((byte)1, (byte)2);
            r[0] = ar.xx;
            r[1] = ar.xy;
            w[0].xy = aw;
            r[2] = ar.xz;
            w[1].xz = aw;
            r[3] = ar.yx;
            w[2].yx = aw;
            r[4] = ar.yy;
            r[5] = ar.yz;
            w[3].yz = aw;
            r[6] = ar.zx;
            w[4].zx = aw;
            r[7] = ar.zy;
            w[5].zy = aw;
            r[8] = ar.zz;
        }

        [Test]
        public void TestComponentAccessors2Managed()
        {
            var nr = 9;
            var nw = 6;
            var r = new byte2[nr];
            var w = new byte3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte2[],byte3[]>)test_components2,
                r, w
            );
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)2, r[1].s1);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)3, r[2].s1);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)0, w[1].s1);
            Assert.AreEqual((byte)2, r[3].s0);
            Assert.AreEqual((byte)1, r[3].s1);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s2);
            Assert.AreEqual((byte)2, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[5].s0);
            Assert.AreEqual((byte)3, r[5].s1);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)0, w[3].s0);
            Assert.AreEqual((byte)3, r[6].s0);
            Assert.AreEqual((byte)1, r[6].s1);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)0, w[4].s1);
            Assert.AreEqual((byte)3, r[7].s0);
            Assert.AreEqual((byte)2, r[7].s1);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)0, w[5].s0);
            Assert.AreEqual((byte)3, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);
        }

        [Test]
        public void TestComponentAccessors2Cl()
        {
            var nr = 9;
            var nw = 6;
            var r = new byte2[nr];
            var w = new byte3[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte2>()))
            using (var mw = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(byte3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)2, r[1].s1);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)0, w[0].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)3, r[2].s1);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)0, w[1].s1);
            Assert.AreEqual((byte)2, r[3].s0);
            Assert.AreEqual((byte)1, r[3].s1);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)0, w[2].s2);
            Assert.AreEqual((byte)2, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[5].s0);
            Assert.AreEqual((byte)3, r[5].s1);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)0, w[3].s0);
            Assert.AreEqual((byte)3, r[6].s0);
            Assert.AreEqual((byte)1, r[6].s1);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)0, w[4].s1);
            Assert.AreEqual((byte)3, r[7].s0);
            Assert.AreEqual((byte)2, r[7].s1);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)0, w[5].s0);
            Assert.AreEqual((byte)3, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);
        }
        [Kernel]
        private static void test_components3([Global] byte3[] r, [Global] byte3[] w)
        {
            var ar = new byte3((byte)1, (byte)2, (byte)3);
            var aw = new byte3((byte)1, (byte)2, (byte)3);
            r[0] = ar.xxx;
            r[1] = ar.xxy;
            r[2] = ar.xxz;
            r[3] = ar.xyx;
            r[4] = ar.xyy;
            r[5] = ar.xyz;
            w[0].xyz = aw;
            r[6] = ar.xzx;
            r[7] = ar.xzy;
            w[1].xzy = aw;
            r[8] = ar.xzz;
            r[9] = ar.yxx;
            r[10] = ar.yxy;
            r[11] = ar.yxz;
            w[2].yxz = aw;
            r[12] = ar.yyx;
            r[13] = ar.yyy;
            r[14] = ar.yyz;
            r[15] = ar.yzx;
            w[3].yzx = aw;
            r[16] = ar.yzy;
            r[17] = ar.yzz;
            r[18] = ar.zxx;
            r[19] = ar.zxy;
            w[4].zxy = aw;
            r[20] = ar.zxz;
            r[21] = ar.zyx;
            w[5].zyx = aw;
            r[22] = ar.zyy;
            r[23] = ar.zyz;
            r[24] = ar.zzx;
            r[25] = ar.zzy;
            r[26] = ar.zzz;
        }

        [Test]
        public void TestComponentAccessors3Managed()
        {
            var nr = 27;
            var nw = 6;
            var r = new byte3[nr];
            var w = new byte3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte3[],byte3[]>)test_components3,
                r, w
            );
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[0].s2);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)1, r[1].s1);
            Assert.AreEqual((byte)2, r[1].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)1, r[2].s1);
            Assert.AreEqual((byte)3, r[2].s2);
            Assert.AreEqual((byte)1, r[3].s0);
            Assert.AreEqual((byte)2, r[3].s1);
            Assert.AreEqual((byte)1, r[3].s2);
            Assert.AreEqual((byte)1, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[4].s2);
            Assert.AreEqual((byte)1, r[5].s0);
            Assert.AreEqual((byte)2, r[5].s1);
            Assert.AreEqual((byte)3, r[5].s2);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)3, w[0].s2);
            Assert.AreEqual((byte)1, r[6].s0);
            Assert.AreEqual((byte)3, r[6].s1);
            Assert.AreEqual((byte)1, r[6].s2);
            Assert.AreEqual((byte)1, r[7].s0);
            Assert.AreEqual((byte)3, r[7].s1);
            Assert.AreEqual((byte)2, r[7].s2);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)3, w[1].s1);
            Assert.AreEqual((byte)1, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);
            Assert.AreEqual((byte)3, r[8].s2);
            Assert.AreEqual((byte)2, r[9].s0);
            Assert.AreEqual((byte)1, r[9].s1);
            Assert.AreEqual((byte)1, r[9].s2);
            Assert.AreEqual((byte)2, r[10].s0);
            Assert.AreEqual((byte)1, r[10].s1);
            Assert.AreEqual((byte)2, r[10].s2);
            Assert.AreEqual((byte)2, r[11].s0);
            Assert.AreEqual((byte)1, r[11].s1);
            Assert.AreEqual((byte)3, r[11].s2);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)3, w[2].s2);
            Assert.AreEqual((byte)2, r[12].s0);
            Assert.AreEqual((byte)2, r[12].s1);
            Assert.AreEqual((byte)1, r[12].s2);
            Assert.AreEqual((byte)2, r[13].s0);
            Assert.AreEqual((byte)2, r[13].s1);
            Assert.AreEqual((byte)2, r[13].s2);
            Assert.AreEqual((byte)2, r[14].s0);
            Assert.AreEqual((byte)2, r[14].s1);
            Assert.AreEqual((byte)3, r[14].s2);
            Assert.AreEqual((byte)2, r[15].s0);
            Assert.AreEqual((byte)3, r[15].s1);
            Assert.AreEqual((byte)1, r[15].s2);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)3, w[3].s0);
            Assert.AreEqual((byte)2, r[16].s0);
            Assert.AreEqual((byte)3, r[16].s1);
            Assert.AreEqual((byte)2, r[16].s2);
            Assert.AreEqual((byte)2, r[17].s0);
            Assert.AreEqual((byte)3, r[17].s1);
            Assert.AreEqual((byte)3, r[17].s2);
            Assert.AreEqual((byte)3, r[18].s0);
            Assert.AreEqual((byte)1, r[18].s1);
            Assert.AreEqual((byte)1, r[18].s2);
            Assert.AreEqual((byte)3, r[19].s0);
            Assert.AreEqual((byte)1, r[19].s1);
            Assert.AreEqual((byte)2, r[19].s2);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)3, w[4].s1);
            Assert.AreEqual((byte)3, r[20].s0);
            Assert.AreEqual((byte)1, r[20].s1);
            Assert.AreEqual((byte)3, r[20].s2);
            Assert.AreEqual((byte)3, r[21].s0);
            Assert.AreEqual((byte)2, r[21].s1);
            Assert.AreEqual((byte)1, r[21].s2);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)3, w[5].s0);
            Assert.AreEqual((byte)3, r[22].s0);
            Assert.AreEqual((byte)2, r[22].s1);
            Assert.AreEqual((byte)2, r[22].s2);
            Assert.AreEqual((byte)3, r[23].s0);
            Assert.AreEqual((byte)2, r[23].s1);
            Assert.AreEqual((byte)3, r[23].s2);
            Assert.AreEqual((byte)3, r[24].s0);
            Assert.AreEqual((byte)3, r[24].s1);
            Assert.AreEqual((byte)1, r[24].s2);
            Assert.AreEqual((byte)3, r[25].s0);
            Assert.AreEqual((byte)3, r[25].s1);
            Assert.AreEqual((byte)2, r[25].s2);
            Assert.AreEqual((byte)3, r[26].s0);
            Assert.AreEqual((byte)3, r[26].s1);
            Assert.AreEqual((byte)3, r[26].s2);
        }

        [Test]
        public void TestComponentAccessors3Cl()
        {
            var nr = 27;
            var nw = 6;
            var r = new byte3[nr];
            var w = new byte3[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte3", "test_components3");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components3"))
            using (var mr = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte3>()))
            using (var mw = Mem<byte3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(byte3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[0].s2);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)1, r[1].s1);
            Assert.AreEqual((byte)2, r[1].s2);
            Assert.AreEqual((byte)1, r[2].s0);
            Assert.AreEqual((byte)1, r[2].s1);
            Assert.AreEqual((byte)3, r[2].s2);
            Assert.AreEqual((byte)1, r[3].s0);
            Assert.AreEqual((byte)2, r[3].s1);
            Assert.AreEqual((byte)1, r[3].s2);
            Assert.AreEqual((byte)1, r[4].s0);
            Assert.AreEqual((byte)2, r[4].s1);
            Assert.AreEqual((byte)2, r[4].s2);
            Assert.AreEqual((byte)1, r[5].s0);
            Assert.AreEqual((byte)2, r[5].s1);
            Assert.AreEqual((byte)3, r[5].s2);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)3, w[0].s2);
            Assert.AreEqual((byte)1, r[6].s0);
            Assert.AreEqual((byte)3, r[6].s1);
            Assert.AreEqual((byte)1, r[6].s2);
            Assert.AreEqual((byte)1, r[7].s0);
            Assert.AreEqual((byte)3, r[7].s1);
            Assert.AreEqual((byte)2, r[7].s2);
            Assert.AreEqual((byte)1, w[1].s0);
            Assert.AreEqual((byte)2, w[1].s2);
            Assert.AreEqual((byte)3, w[1].s1);
            Assert.AreEqual((byte)1, r[8].s0);
            Assert.AreEqual((byte)3, r[8].s1);
            Assert.AreEqual((byte)3, r[8].s2);
            Assert.AreEqual((byte)2, r[9].s0);
            Assert.AreEqual((byte)1, r[9].s1);
            Assert.AreEqual((byte)1, r[9].s2);
            Assert.AreEqual((byte)2, r[10].s0);
            Assert.AreEqual((byte)1, r[10].s1);
            Assert.AreEqual((byte)2, r[10].s2);
            Assert.AreEqual((byte)2, r[11].s0);
            Assert.AreEqual((byte)1, r[11].s1);
            Assert.AreEqual((byte)3, r[11].s2);
            Assert.AreEqual((byte)1, w[2].s1);
            Assert.AreEqual((byte)2, w[2].s0);
            Assert.AreEqual((byte)3, w[2].s2);
            Assert.AreEqual((byte)2, r[12].s0);
            Assert.AreEqual((byte)2, r[12].s1);
            Assert.AreEqual((byte)1, r[12].s2);
            Assert.AreEqual((byte)2, r[13].s0);
            Assert.AreEqual((byte)2, r[13].s1);
            Assert.AreEqual((byte)2, r[13].s2);
            Assert.AreEqual((byte)2, r[14].s0);
            Assert.AreEqual((byte)2, r[14].s1);
            Assert.AreEqual((byte)3, r[14].s2);
            Assert.AreEqual((byte)2, r[15].s0);
            Assert.AreEqual((byte)3, r[15].s1);
            Assert.AreEqual((byte)1, r[15].s2);
            Assert.AreEqual((byte)1, w[3].s1);
            Assert.AreEqual((byte)2, w[3].s2);
            Assert.AreEqual((byte)3, w[3].s0);
            Assert.AreEqual((byte)2, r[16].s0);
            Assert.AreEqual((byte)3, r[16].s1);
            Assert.AreEqual((byte)2, r[16].s2);
            Assert.AreEqual((byte)2, r[17].s0);
            Assert.AreEqual((byte)3, r[17].s1);
            Assert.AreEqual((byte)3, r[17].s2);
            Assert.AreEqual((byte)3, r[18].s0);
            Assert.AreEqual((byte)1, r[18].s1);
            Assert.AreEqual((byte)1, r[18].s2);
            Assert.AreEqual((byte)3, r[19].s0);
            Assert.AreEqual((byte)1, r[19].s1);
            Assert.AreEqual((byte)2, r[19].s2);
            Assert.AreEqual((byte)1, w[4].s2);
            Assert.AreEqual((byte)2, w[4].s0);
            Assert.AreEqual((byte)3, w[4].s1);
            Assert.AreEqual((byte)3, r[20].s0);
            Assert.AreEqual((byte)1, r[20].s1);
            Assert.AreEqual((byte)3, r[20].s2);
            Assert.AreEqual((byte)3, r[21].s0);
            Assert.AreEqual((byte)2, r[21].s1);
            Assert.AreEqual((byte)1, r[21].s2);
            Assert.AreEqual((byte)1, w[5].s2);
            Assert.AreEqual((byte)2, w[5].s1);
            Assert.AreEqual((byte)3, w[5].s0);
            Assert.AreEqual((byte)3, r[22].s0);
            Assert.AreEqual((byte)2, r[22].s1);
            Assert.AreEqual((byte)2, r[22].s2);
            Assert.AreEqual((byte)3, r[23].s0);
            Assert.AreEqual((byte)2, r[23].s1);
            Assert.AreEqual((byte)3, r[23].s2);
            Assert.AreEqual((byte)3, r[24].s0);
            Assert.AreEqual((byte)3, r[24].s1);
            Assert.AreEqual((byte)1, r[24].s2);
            Assert.AreEqual((byte)3, r[25].s0);
            Assert.AreEqual((byte)3, r[25].s1);
            Assert.AreEqual((byte)2, r[25].s2);
            Assert.AreEqual((byte)3, r[26].s0);
            Assert.AreEqual((byte)3, r[26].s1);
            Assert.AreEqual((byte)3, r[26].s2);
        }
    }
}
