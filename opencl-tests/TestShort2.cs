
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
    public class TestShort2
    {
        [Kernel]
        private static void test_short2_add([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
        }

        [Test]
        public void TestAddCl()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_add"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
        }

        [Test]
        public void TestAddSpirV()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_add"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
        }

        [Kernel]
        private static void test_short2_sub([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_sub"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_sub"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(  -2, r[1].s0);
            Assert.AreEqual(  -4, r[1].s1);
        }

        [Kernel]
        private static void test_short2_mul([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_mul"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_mul"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
        }

        [Kernel]
        private static void test_short2_div([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
        }

        [Test]
        public void TestDivCl()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_div"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
        }

        [Test]
        public void TestDivSpirV()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_div"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
        }

        [Kernel]
        private static void test_short2_eq([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Test]
        public void TestEqCl()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_eq"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Test]
        public void TestEqSpirV()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_eq"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Kernel]
        private static void test_short2_neq([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Test]
        public void TestNeqCl()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_neq"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Test]
        public void TestNeqSpirV()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_neq"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Kernel]
        private static void test_short2_lt([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Test]
        public void TestLtCl()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_lt"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Test]
        public void TestLtSpirV()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_lt"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Kernel]
        private static void test_short2_le([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Test]
        public void TestLeCl()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_le"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Test]
        public void TestLeSpirV()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_le"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Kernel]
        private static void test_short2_gt([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Test]
        public void TestGtCl()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_gt"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Test]
        public void TestGtSpirV()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_gt"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
        }

        [Kernel]
        private static void test_short2_ge([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Test]
        public void TestGeCl()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_ge"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Test]
        public void TestGeSpirV()
        {
            var a = new short2[] { new short2((short)   2, (short)   1), new short2((short)   0, (short)   1) };
            var b = new short2[] { new short2((short)   0, (short)   1), new short2((short)   2, (short)   1) };
            var r = new short2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_ge"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
        }

        [Kernel]
        private static void test_short2_and([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_and,
                a,
                b,
                r
            );
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
        }

        [Test]
        public void TestAndCl()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_and"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
        }

        [Kernel]
        private static void test_short2_or([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_or,
                a,
                b,
                r
            );
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
        }

        [Test]
        public void TestOrCl()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_or"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
        }

        [Kernel]
        private static void test_short2_xor([Global] short2[] a, [Global] short2[] b, [Global] short2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<short2[],short2[],short2[]>)test_short2_xor,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
        }

        [Test]
        public void TestXorCl()
        {
            var a = new short2[] { new short2((short)   7, (short)  14), new short2((short)   5, (short)  10) };
            var b = new short2[] { new short2((short)   5, (short)  10), new short2((short)   7, (short)  14) };
            var r = new short2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_short2_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_short2_xor"))
            using (var ma = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<short2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<short2>()))
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
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
        }

        [Kernel]
        private static void test_components1([Global] short[] r, [Global] short2[] w)
        {
            var ar = new short2((short)1, (short)2);
            var aw = (short)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
        }

        [Test]
        public void TestComponentAccessors1Managed()
        {
            var nr = 2;
            var nw = 2;
            var r = new short[nr];
            var w = new short2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<short[],short2[]>)test_components1,
                r, w
            );
            Assert.AreEqual((short)1, r[0]);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)0, w[0].s1);
            Assert.AreEqual((short)2, r[1]);
            Assert.AreEqual((short)1, w[1].s1);
            Assert.AreEqual((short)0, w[1].s0);
        }

        [Test]
        public void TestComponentAccessors1Cl()
        {
            var nr = 2;
            var nw = 2;
            var r = new short[nr];
            var w = new short2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<short>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<short>()))
            using (var mw = Mem<short2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(short2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((short)1, r[0]);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)0, w[0].s1);
            Assert.AreEqual((short)2, r[1]);
            Assert.AreEqual((short)1, w[1].s1);
            Assert.AreEqual((short)0, w[1].s0);
        }
        [Kernel]
        private static void test_components2([Global] short2[] r, [Global] short2[] w)
        {
            var ar = new short2((short)1, (short)2);
            var aw = new short2((short)1, (short)2);
            r[0] = ar.xx;
            r[1] = ar.xy;
            w[0].xy = aw;
            r[2] = ar.yx;
            w[1].yx = aw;
            r[3] = ar.yy;
        }

        [Test]
        public void TestComponentAccessors2Managed()
        {
            var nr = 4;
            var nw = 2;
            var r = new short2[nr];
            var w = new short2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<short2[],short2[]>)test_components2,
                r, w
            );
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)2, r[1].s1);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)2, r[2].s0);
            Assert.AreEqual((short)1, r[2].s1);
            Assert.AreEqual((short)1, w[1].s1);
            Assert.AreEqual((short)2, w[1].s0);
            Assert.AreEqual((short)2, r[3].s0);
            Assert.AreEqual((short)2, r[3].s1);
        }

        [Test]
        public void TestComponentAccessors2Cl()
        {
            var nr = 4;
            var nw = 2;
            var r = new short2[nr];
            var w = new short2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestShort2", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<short2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<short2>()))
            using (var mw = Mem<short2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<short2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(short2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((short)1, r[0].s0);
            Assert.AreEqual((short)1, r[0].s1);
            Assert.AreEqual((short)1, r[1].s0);
            Assert.AreEqual((short)2, r[1].s1);
            Assert.AreEqual((short)1, w[0].s0);
            Assert.AreEqual((short)2, w[0].s1);
            Assert.AreEqual((short)2, r[2].s0);
            Assert.AreEqual((short)1, r[2].s1);
            Assert.AreEqual((short)1, w[1].s1);
            Assert.AreEqual((short)2, w[1].s0);
            Assert.AreEqual((short)2, r[3].s0);
            Assert.AreEqual((short)2, r[3].s1);
        }
    }
}
