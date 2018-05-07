
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
    public class TestUint2
    {
        [Kernel]
        private static void test_uint2_add([Global] uint2[] a, [Global] uint2[] b, [Global] uint2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],uint2[]>)test_uint2_add,
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_add"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_add"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
        private static void test_uint2_sub([Global] uint2[] a, [Global] uint2[] b, [Global] uint2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],uint2[]>)test_uint2_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_sub"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_sub"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
            Assert.AreEqual(4294967294, r[1].s0);
            Assert.AreEqual(4294967292, r[1].s1);
        }

        [Kernel]
        private static void test_uint2_mul([Global] uint2[] a, [Global] uint2[] b, [Global] uint2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],uint2[]>)test_uint2_mul,
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_mul"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_mul"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
        private static void test_uint2_div([Global] uint2[] a, [Global] uint2[] b, [Global] uint2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],uint2[]>)test_uint2_div,
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_div"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_div"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
        private static void test_uint2_eq([Global] uint2[] a, [Global] uint2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],int2[]>)test_uint2_eq,
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_eq"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_eq"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
        private static void test_uint2_neq([Global] uint2[] a, [Global] uint2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],int2[]>)test_uint2_neq,
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_neq"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_neq"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
        private static void test_uint2_lt([Global] uint2[] a, [Global] uint2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],int2[]>)test_uint2_lt,
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_lt"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_lt"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
        private static void test_uint2_le([Global] uint2[] a, [Global] uint2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],int2[]>)test_uint2_le,
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_le"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_le"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
        private static void test_uint2_gt([Global] uint2[] a, [Global] uint2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],int2[]>)test_uint2_gt,
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_gt"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_gt"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
        private static void test_uint2_ge([Global] uint2[] a, [Global] uint2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],int2[]>)test_uint2_ge,
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_ge"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
            var a = new uint2[] { new uint2((uint)   2, (uint)   1), new uint2((uint)   0, (uint)   1) };
            var b = new uint2[] { new uint2((uint)   0, (uint)   1), new uint2((uint)   2, (uint)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_ge"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<int2>()))
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
        private static void test_uint2_and([Global] uint2[] a, [Global] uint2[] b, [Global] uint2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],uint2[]>)test_uint2_and,
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_and"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
        private static void test_uint2_or([Global] uint2[] a, [Global] uint2[] b, [Global] uint2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],uint2[]>)test_uint2_or,
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_or"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
        private static void test_uint2_xor([Global] uint2[] a, [Global] uint2[] b, [Global] uint2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<uint2[],uint2[],uint2[]>)test_uint2_xor,
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
            var a = new uint2[] { new uint2((uint)   7, (uint)  14), new uint2((uint)   5, (uint)  10) };
            var b = new uint2[] { new uint2((uint)   5, (uint)  10), new uint2((uint)   7, (uint)  14) };
            var r = new uint2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_uint2_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_uint2_xor"))
            using (var ma = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<uint2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<uint2>()))
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
        private static void test_components1([Global] uint[] r, [Global] uint2[] w)
        {
            var ar = new uint2((uint)1, (uint)2);
            var aw = (uint)1;
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
            var r = new uint[nr];
            var w = new uint2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<uint[],uint2[]>)test_components1,
                r, w
            );
            Assert.AreEqual((uint)1, r[0]);
            Assert.AreEqual((uint)1, w[0].s0);
            Assert.AreEqual((uint)0, w[0].s1);
            Assert.AreEqual((uint)2, r[1]);
            Assert.AreEqual((uint)1, w[1].s1);
            Assert.AreEqual((uint)0, w[1].s0);
        }

        [Test]
        public void TestComponentAccessors1Cl()
        {
            var nr = 2;
            var nw = 2;
            var r = new uint[nr];
            var w = new uint2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<uint>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<uint>()))
            using (var mw = Mem<uint2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<uint2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(uint2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((uint)1, r[0]);
            Assert.AreEqual((uint)1, w[0].s0);
            Assert.AreEqual((uint)0, w[0].s1);
            Assert.AreEqual((uint)2, r[1]);
            Assert.AreEqual((uint)1, w[1].s1);
            Assert.AreEqual((uint)0, w[1].s0);
        }
        [Kernel]
        private static void test_components2([Global] uint2[] r, [Global] uint2[] w)
        {
            var ar = new uint2((uint)1, (uint)2);
            var aw = new uint2((uint)1, (uint)2);
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
            var r = new uint2[nr];
            var w = new uint2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<uint2[],uint2[]>)test_components2,
                r, w
            );
            Assert.AreEqual((uint)1, r[0].s0);
            Assert.AreEqual((uint)1, r[0].s1);
            Assert.AreEqual((uint)1, r[1].s0);
            Assert.AreEqual((uint)2, r[1].s1);
            Assert.AreEqual((uint)1, w[0].s0);
            Assert.AreEqual((uint)2, w[0].s1);
            Assert.AreEqual((uint)2, r[2].s0);
            Assert.AreEqual((uint)1, r[2].s1);
            Assert.AreEqual((uint)1, w[1].s1);
            Assert.AreEqual((uint)2, w[1].s0);
            Assert.AreEqual((uint)2, r[3].s0);
            Assert.AreEqual((uint)2, r[3].s1);
        }

        [Test]
        public void TestComponentAccessors2Cl()
        {
            var nr = 4;
            var nw = 2;
            var r = new uint2[nr];
            var w = new uint2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUint2", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<uint2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<uint2>()))
            using (var mw = Mem<uint2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<uint2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(uint2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((uint)1, r[0].s0);
            Assert.AreEqual((uint)1, r[0].s1);
            Assert.AreEqual((uint)1, r[1].s0);
            Assert.AreEqual((uint)2, r[1].s1);
            Assert.AreEqual((uint)1, w[0].s0);
            Assert.AreEqual((uint)2, w[0].s1);
            Assert.AreEqual((uint)2, r[2].s0);
            Assert.AreEqual((uint)1, r[2].s1);
            Assert.AreEqual((uint)1, w[1].s1);
            Assert.AreEqual((uint)2, w[1].s0);
            Assert.AreEqual((uint)2, r[3].s0);
            Assert.AreEqual((uint)2, r[3].s1);
        }
    }
}
