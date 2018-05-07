
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
    public class TestSbyte2
    {
        [Kernel]
        private static void test_sbyte2_add([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_add,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_add"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_add"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_sub([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_sub,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_sub"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_sub"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_mul([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual(-116, r[0].s1);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_mul"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_mul"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual(-116, r[1].s1);
        }

        [Kernel]
        private static void test_sbyte2_div([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_div,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_div"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_div"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_eq([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_eq,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_eq"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_eq"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_neq([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_neq,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_neq"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_neq"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_lt([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_lt,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_lt"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_lt"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_le([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_le,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_le"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_le"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_gt([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_gt,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_gt"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_gt"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_ge([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_ge,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_ge"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
            var a = new sbyte2[] { new sbyte2((sbyte)   2, (sbyte)   1), new sbyte2((sbyte)   0, (sbyte)   1) };
            var b = new sbyte2[] { new sbyte2((sbyte)   0, (sbyte)   1), new sbyte2((sbyte)   2, (sbyte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_ge"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_and([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAndManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_and,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_and"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_or([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOrManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_or,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_or"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_sbyte2_xor([Global] sbyte2[] a, [Global] sbyte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXorManaged()
        {
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[],sbyte2[]>)test_sbyte2_xor,
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
            var a = new sbyte2[] { new sbyte2((sbyte)   7, (sbyte)  14), new sbyte2((sbyte)   5, (sbyte)  10) };
            var b = new sbyte2[] { new sbyte2((sbyte)   5, (sbyte)  10), new sbyte2((sbyte)   7, (sbyte)  14) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_sbyte2_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_sbyte2_xor"))
            using (var ma = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<sbyte2>()))
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
        private static void test_components1([Global] sbyte[] r, [Global] sbyte2[] w)
        {
            var ar = new sbyte2((sbyte)1, (sbyte)2);
            var aw = (sbyte)1;
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
            var r = new sbyte[nr];
            var w = new sbyte2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<sbyte[],sbyte2[]>)test_components1,
                r, w
            );
            Assert.AreEqual((sbyte)1, r[0]);
            Assert.AreEqual((sbyte)1, w[0].s0);
            Assert.AreEqual((sbyte)0, w[0].s1);
            Assert.AreEqual((sbyte)2, r[1]);
            Assert.AreEqual((sbyte)1, w[1].s1);
            Assert.AreEqual((sbyte)0, w[1].s0);
        }

        [Test]
        public void TestComponentAccessors1Cl()
        {
            var nr = 2;
            var nw = 2;
            var r = new sbyte[nr];
            var w = new sbyte2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<sbyte>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<sbyte>()))
            using (var mw = Mem<sbyte2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<sbyte2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(sbyte2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((sbyte)1, r[0]);
            Assert.AreEqual((sbyte)1, w[0].s0);
            Assert.AreEqual((sbyte)0, w[0].s1);
            Assert.AreEqual((sbyte)2, r[1]);
            Assert.AreEqual((sbyte)1, w[1].s1);
            Assert.AreEqual((sbyte)0, w[1].s0);
        }
        [Kernel]
        private static void test_components2([Global] sbyte2[] r, [Global] sbyte2[] w)
        {
            var ar = new sbyte2((sbyte)1, (sbyte)2);
            var aw = new sbyte2((sbyte)1, (sbyte)2);
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
            var r = new sbyte2[nr];
            var w = new sbyte2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<sbyte2[],sbyte2[]>)test_components2,
                r, w
            );
            Assert.AreEqual((sbyte)1, r[0].s0);
            Assert.AreEqual((sbyte)1, r[0].s1);
            Assert.AreEqual((sbyte)1, r[1].s0);
            Assert.AreEqual((sbyte)2, r[1].s1);
            Assert.AreEqual((sbyte)1, w[0].s0);
            Assert.AreEqual((sbyte)2, w[0].s1);
            Assert.AreEqual((sbyte)2, r[2].s0);
            Assert.AreEqual((sbyte)1, r[2].s1);
            Assert.AreEqual((sbyte)1, w[1].s1);
            Assert.AreEqual((sbyte)2, w[1].s0);
            Assert.AreEqual((sbyte)2, r[3].s0);
            Assert.AreEqual((sbyte)2, r[3].s1);
        }

        [Test]
        public void TestComponentAccessors2Cl()
        {
            var nr = 4;
            var nw = 2;
            var r = new sbyte2[nr];
            var w = new sbyte2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestSbyte2", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<sbyte2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<sbyte2>()))
            using (var mw = Mem<sbyte2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<sbyte2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(sbyte2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((sbyte)1, r[0].s0);
            Assert.AreEqual((sbyte)1, r[0].s1);
            Assert.AreEqual((sbyte)1, r[1].s0);
            Assert.AreEqual((sbyte)2, r[1].s1);
            Assert.AreEqual((sbyte)1, w[0].s0);
            Assert.AreEqual((sbyte)2, w[0].s1);
            Assert.AreEqual((sbyte)2, r[2].s0);
            Assert.AreEqual((sbyte)1, r[2].s1);
            Assert.AreEqual((sbyte)1, w[1].s1);
            Assert.AreEqual((sbyte)2, w[1].s0);
            Assert.AreEqual((sbyte)2, r[3].s0);
            Assert.AreEqual((sbyte)2, r[3].s1);
        }
    }
}
