
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
    public class TestFloat2
    {
        [Kernel]
        private static void test_float2_add([Global] float2[] a, [Global] float2[] b, [Global] float2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],float2[]>)test_float2_add,
                a,
                b,
                r
            );
            Assert.AreEqual(1.20000000e+01, r[0].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].s1, 2.40000000e-06);
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_add"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.20000000e+01, r[0].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].s1, 2.40000000e-06);
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_add"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.20000000e+01, r[0].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[0].s1, 2.40000000e-06);
            Assert.AreEqual(1.20000000e+01, r[1].s0, 1.20000000e-06);
            Assert.AreEqual(2.40000000e+01, r[1].s1, 2.40000000e-06);
        }

        [Kernel]
        private static void test_float2_sub([Global] float2[] a, [Global] float2[] b, [Global] float2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],float2[]>)test_float2_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(2.00000000e+00, r[0].s0, 2.00000000e-07);
            Assert.AreEqual(4.00000000e+00, r[0].s1, 4.00000000e-07);
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_sub"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.00000000e+00, r[0].s0, 2.00000000e-07);
            Assert.AreEqual(4.00000000e+00, r[0].s1, 4.00000000e-07);
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_sub"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.00000000e+00, r[0].s0, 2.00000000e-07);
            Assert.AreEqual(4.00000000e+00, r[0].s1, 4.00000000e-07);
            Assert.AreEqual(-2.00000000e+00, r[1].s0, 2.00000000e-07);
            Assert.AreEqual(-4.00000000e+00, r[1].s1, 4.00000000e-07);
        }

        [Kernel]
        private static void test_float2_mul([Global] float2[] a, [Global] float2[] b, [Global] float2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],float2[]>)test_float2_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(3.50000000e+01, r[0].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[0].s1, 1.40000000e-05);
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_mul"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.50000000e+01, r[0].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[0].s1, 1.40000000e-05);
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_mul"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.50000000e+01, r[0].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[0].s1, 1.40000000e-05);
            Assert.AreEqual(3.50000000e+01, r[1].s0, 3.50000000e-06);
            Assert.AreEqual(1.40000000e+02, r[1].s1, 1.40000000e-05);
        }

        [Kernel]
        private static void test_float2_div([Global] float2[] a, [Global] float2[] b, [Global] float2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],float2[]>)test_float2_div,
                a,
                b,
                r
            );
            Assert.AreEqual(1.39999998e+00, r[0].s0, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s1, 1.39999998e-07);
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestDivCl()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_div"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.39999998e+00, r[0].s0, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s1, 1.39999998e-07);
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestDivSpirV()
        {
            var a = new float2[] { new float2((float)   7, (float)  14), new float2((float)   5, (float)  10) };
            var b = new float2[] { new float2((float)   5, (float)  10), new float2((float)   7, (float)  14) };
            var r = new float2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_div"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.39999998e+00, r[0].s0, 1.39999998e-07);
            Assert.AreEqual(1.39999998e+00, r[0].s1, 1.39999998e-07);
            Assert.AreEqual(7.14285731e-01, r[1].s0, 7.14285731e-08);
            Assert.AreEqual(7.14285731e-01, r[1].s1, 7.14285731e-08);
        }

        [Kernel]
        private static void test_float2_eq([Global] float2[] a, [Global] float2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],int2[]>)test_float2_eq,
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
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_eq"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestEqSpirV()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_eq"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_float2_neq([Global] float2[] a, [Global] float2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],int2[]>)test_float2_neq,
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
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_neq"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestNeqSpirV()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_neq"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_float2_lt([Global] float2[] a, [Global] float2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],int2[]>)test_float2_lt,
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
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_lt"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLtSpirV()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_lt"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_float2_le([Global] float2[] a, [Global] float2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],int2[]>)test_float2_le,
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
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_le"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestLeSpirV()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_le"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_float2_gt([Global] float2[] a, [Global] float2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],int2[]>)test_float2_gt,
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
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_gt"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGtSpirV()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_gt"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_float2_ge([Global] float2[] a, [Global] float2[] b, [Global] int2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float2[],float2[],int2[]>)test_float2_ge,
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
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_ge"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        [Category("Compiled.SpirV")]
        public void TestGeSpirV()
        {
            var a = new float2[] { new float2((float)   2, (float)   1), new float2((float)   0, (float)   1) };
            var b = new float2[] { new float2((float)   0, (float)   1), new float2((float)   2, (float)   1) };
            var r = new int2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_float2_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_float2_ge"))
            using (var ma = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<float2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
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
        private static void test_components1([Global] float[] r, [Global] float2[] w)
        {
            var ar = new float2((float)1, (float)2);
            var aw = (float)1;
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
            var r = new float[nr];
            var w = new float2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<float[],float2[]>)test_components1,
                r, w
            );
            Assert.AreEqual((float)1, r[0]);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)0, w[0].s1);
            Assert.AreEqual((float)2, r[1]);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)0, w[1].s0);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestComponentAccessors1Cl()
        {
            var nr = 2;
            var nw = 2;
            var r = new float[nr];
            var w = new float2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<float>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<float>()))
            using (var mw = Mem<float2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(float2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((float)1, r[0]);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)0, w[0].s1);
            Assert.AreEqual((float)2, r[1]);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)0, w[1].s0);
        }

        [Test]
        [Category("Compiled.SpirV")]
        [Ignore("Handling component accessors not implemented in SPIR-V compiler.")]
        public void TestComponentAccessors1SpirV()
        {
            var nr = 2;
            var nw = 2;
            var r = new float[nr];
            var w = new float2[nw];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_components1", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<float>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<float>()))
            using (var mw = Mem<float2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(float2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((float)1, r[0]);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)0, w[0].s1);
            Assert.AreEqual((float)2, r[1]);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)0, w[1].s0);
        }
        [Kernel]
        private static void test_components2([Global] float2[] r, [Global] float2[] w)
        {
            var ar = new float2((float)1, (float)2);
            var aw = new float2((float)1, (float)2);
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
            var r = new float2[nr];
            var w = new float2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<float2[],float2[]>)test_components2,
                r, w
            );
            Assert.AreEqual((float)1, r[0].s0);
            Assert.AreEqual((float)1, r[0].s1);
            Assert.AreEqual((float)1, r[1].s0);
            Assert.AreEqual((float)2, r[1].s1);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)2, w[0].s1);
            Assert.AreEqual((float)2, r[2].s0);
            Assert.AreEqual((float)1, r[2].s1);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)2, w[1].s0);
            Assert.AreEqual((float)2, r[3].s0);
            Assert.AreEqual((float)2, r[3].s1);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestComponentAccessors2Cl()
        {
            var nr = 4;
            var nw = 2;
            var r = new float2[nr];
            var w = new float2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<float2>()))
            using (var mw = Mem<float2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(float2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((float)1, r[0].s0);
            Assert.AreEqual((float)1, r[0].s1);
            Assert.AreEqual((float)1, r[1].s0);
            Assert.AreEqual((float)2, r[1].s1);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)2, w[0].s1);
            Assert.AreEqual((float)2, r[2].s0);
            Assert.AreEqual((float)1, r[2].s1);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)2, w[1].s0);
            Assert.AreEqual((float)2, r[3].s0);
            Assert.AreEqual((float)2, r[3].s1);
        }

        [Test]
        [Category("Compiled.SpirV")]
        [Ignore("Handling component accessors not implemented in SPIR-V compiler.")]
        public void TestComponentAccessors2SpirV()
        {
            var nr = 4;
            var nw = 2;
            var r = new float2[nr];
            var w = new float2[nw];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestFloat2", "test_components2", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<float2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<float2>()))
            using (var mw = Mem<float2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<float2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(float2));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((float)1, r[0].s0);
            Assert.AreEqual((float)1, r[0].s1);
            Assert.AreEqual((float)1, r[1].s0);
            Assert.AreEqual((float)2, r[1].s1);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)2, w[0].s1);
            Assert.AreEqual((float)2, r[2].s0);
            Assert.AreEqual((float)1, r[2].s1);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)2, w[1].s0);
            Assert.AreEqual((float)2, r[3].s0);
            Assert.AreEqual((float)2, r[3].s1);
        }
    }
}
