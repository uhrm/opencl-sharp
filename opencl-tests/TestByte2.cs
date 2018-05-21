
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
    public class TestByte2
    {
        [Kernel]
        private static void test_byte2_add([Global] byte2[] a, [Global] byte2[] b, [Global] byte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],byte2[]>)test_byte2_add,
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
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_add"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_add"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        private static void test_byte2_sub([Global] byte2[] a, [Global] byte2[] b, [Global] byte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],byte2[]>)test_byte2_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_sub"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_sub"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
            Assert.AreEqual( 254, r[1].s0);
            Assert.AreEqual( 252, r[1].s1);
        }

        [Kernel]
        private static void test_byte2_mul([Global] byte2[] a, [Global] byte2[] b, [Global] byte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],byte2[]>)test_byte2_mul,
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
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_mul"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_mul"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        private static void test_byte2_div([Global] byte2[] a, [Global] byte2[] b, [Global] byte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],byte2[]>)test_byte2_div,
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
        [Category("Compiled.Cl")]
        public void TestDivCl()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_div"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        [Category("Compiled.SpirV")]
        public void TestDivSpirV()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_div"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        private static void test_byte2_eq([Global] byte2[] a, [Global] byte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],sbyte2[]>)test_byte2_eq,
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
        [Category("Compiled.Cl")]
        public void TestEqCl()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_eq"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestEqSpirV()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_eq"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte2_neq([Global] byte2[] a, [Global] byte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],sbyte2[]>)test_byte2_neq,
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
        [Category("Compiled.Cl")]
        public void TestNeqCl()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_neq"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestNeqSpirV()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_neq"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte2_lt([Global] byte2[] a, [Global] byte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],sbyte2[]>)test_byte2_lt,
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
        [Category("Compiled.Cl")]
        public void TestLtCl()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_lt"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLtSpirV()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_lt"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte2_le([Global] byte2[] a, [Global] byte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],sbyte2[]>)test_byte2_le,
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
        [Category("Compiled.Cl")]
        public void TestLeCl()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_le"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLeSpirV()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_le"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte2_gt([Global] byte2[] a, [Global] byte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],sbyte2[]>)test_byte2_gt,
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
        [Category("Compiled.Cl")]
        public void TestGtCl()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_gt"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGtSpirV()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_gt"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte2_ge([Global] byte2[] a, [Global] byte2[] b, [Global] sbyte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],sbyte2[]>)test_byte2_ge,
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
        [Category("Compiled.Cl")]
        public void TestGeCl()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_ge"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGeSpirV()
        {
            var a = new byte2[] { new byte2((byte)   2, (byte)   1), new byte2((byte)   0, (byte)   1) };
            var b = new byte2[] { new byte2((byte)   0, (byte)   1), new byte2((byte)   2, (byte)   1) };
            var r = new sbyte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_ge"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_byte2_and([Global] byte2[] a, [Global] byte2[] b, [Global] byte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAndManaged()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],byte2[]>)test_byte2_and,
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
        [Category("Compiled.Cl")]
        public void TestAndCl()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_and");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_and"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAndSpirV()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_and", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_and"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        private static void test_byte2_or([Global] byte2[] a, [Global] byte2[] b, [Global] byte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestOrManaged()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],byte2[]>)test_byte2_or,
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
        [Category("Compiled.Cl")]
        public void TestOrCl()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_or");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_or"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestOrSpirV()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_or", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_or"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        private static void test_byte2_xor([Global] byte2[] a, [Global] byte2[] b, [Global] byte2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestXorManaged()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<byte2[],byte2[],byte2[]>)test_byte2_xor,
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
        [Category("Compiled.Cl")]
        public void TestXorCl()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_xor");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_xor"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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

        [Test]
        [Category("Compiled.SpirV")]
        public void TestXorSpirV()
        {
            var a = new byte2[] { new byte2((byte)   7, (byte)  14), new byte2((byte)   5, (byte)  10) };
            var b = new byte2[] { new byte2((byte)   5, (byte)  10), new byte2((byte)   7, (byte)  14) };
            var r = new byte2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_byte2_xor", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_byte2_xor"))
            using (var ma = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<byte2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<byte2>()))
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
        private static void test_components1([Global] byte[] r, [Global] byte2[] w)
        {
            var ar = new byte2((byte)1, (byte)2);
            var aw = (byte)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
        }

        [Test]
        [Category("Managed")]
        public void TestComponentAccessors1Managed()
        {
            var nr = 2;
            var nw = 2;
            var r = new byte[nr];
            var w = new byte2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte[],byte2[]>)test_components1,
                r, w
            );
            Assert.AreEqual((byte)1, r[0]);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)0, w[0].s1);
            Assert.AreEqual((byte)2, r[1]);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)0, w[1].s0);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestComponentAccessors1Cl()
        {
            var nr = 2;
            var nw = 2;
            var r = new byte[nr];
            var w = new byte2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<byte>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte>()))
            using (var mw = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(byte2));
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
            Assert.AreEqual((byte)2, r[1]);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)0, w[1].s0);
        }

        [Test]
        [Category("Compiled.SpirV")]
        [Ignore("Handling component accessors not implemented in SPIR-V compiler.")]
        public void TestComponentAccessors1SpirV()
        {
            var nr = 2;
            var nw = 2;
            var r = new byte[nr];
            var w = new byte2[nw];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_components1", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<byte>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte>()))
            using (var mw = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(byte2));
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
            Assert.AreEqual((byte)2, r[1]);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)0, w[1].s0);
        }
        [Kernel]
        private static void test_components2([Global] byte2[] r, [Global] byte2[] w)
        {
            var ar = new byte2((byte)1, (byte)2);
            var aw = new byte2((byte)1, (byte)2);
            r[0] = ar.xx;
            r[1] = ar.xy;
            w[0].xy = aw;
            r[2] = ar.yx;
            w[1].yx = aw;
            r[3] = ar.yy;
        }

        [Test]
        [Category("Managed")]
        public void TestComponentAccessors2Managed()
        {
            var nr = 4;
            var nw = 2;
            var r = new byte2[nr];
            var w = new byte2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<byte2[],byte2[]>)test_components2,
                r, w
            );
            Assert.AreEqual((byte)1, r[0].s0);
            Assert.AreEqual((byte)1, r[0].s1);
            Assert.AreEqual((byte)1, r[1].s0);
            Assert.AreEqual((byte)2, r[1].s1);
            Assert.AreEqual((byte)1, w[0].s0);
            Assert.AreEqual((byte)2, w[0].s1);
            Assert.AreEqual((byte)2, r[2].s0);
            Assert.AreEqual((byte)1, r[2].s1);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)2, w[1].s0);
            Assert.AreEqual((byte)2, r[3].s0);
            Assert.AreEqual((byte)2, r[3].s1);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestComponentAccessors2Cl()
        {
            var nr = 4;
            var nw = 2;
            var r = new byte2[nr];
            var w = new byte2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte2>()))
            using (var mw = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(byte2));
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
            Assert.AreEqual((byte)2, r[2].s0);
            Assert.AreEqual((byte)1, r[2].s1);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)2, w[1].s0);
            Assert.AreEqual((byte)2, r[3].s0);
            Assert.AreEqual((byte)2, r[3].s1);
        }

        [Test]
        [Category("Compiled.SpirV")]
        [Ignore("Handling component accessors not implemented in SPIR-V compiler.")]
        public void TestComponentAccessors2SpirV()
        {
            var nr = 4;
            var nw = 2;
            var r = new byte2[nr];
            var w = new byte2[nw];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestByte2", "test_components2", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<byte2>()))
            using (var mw = Mem<byte2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<byte2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(byte2));
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
            Assert.AreEqual((byte)2, r[2].s0);
            Assert.AreEqual((byte)1, r[2].s1);
            Assert.AreEqual((byte)1, w[1].s1);
            Assert.AreEqual((byte)2, w[1].s0);
            Assert.AreEqual((byte)2, r[3].s0);
            Assert.AreEqual((byte)2, r[3].s1);
        }
    }
}
