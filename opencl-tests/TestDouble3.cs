
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
    public class TestDouble3
    {
        [Kernel]
        private static void test_double3_add([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestAddManaged()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_add,
                a,
                b,
                r
            );
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[0].s2, 3.6000000000000004e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestAddCl()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_add"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[0].s2, 3.6000000000000004e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestAddSpirV()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_add"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[0].s2, 3.6000000000000004e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
            Assert.AreEqual(3.6000000000000000e+01, r[1].s2, 3.6000000000000004e-14);
        }

        [Kernel]
        private static void test_double3_sub([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestSubManaged()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(6.0000000000000000e+00, r[0].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestSubCl()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_sub"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(6.0000000000000000e+00, r[0].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestSubSpirV()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_sub"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(6.0000000000000000e+00, r[0].s2, 6.0000000000000005e-15);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-6.0000000000000000e+00, r[1].s2, 6.0000000000000005e-15);
        }

        [Kernel]
        private static void test_double3_mul([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestMulManaged()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[0].s2, 3.1500000000000002e-13);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestMulCl()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_mul"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[0].s2, 3.1500000000000002e-13);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestMulSpirV()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_mul"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[0].s2, 3.1500000000000002e-13);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.1500000000000000e+02, r[1].s2, 3.1500000000000002e-13);
        }

        [Kernel]
        private static void test_double3_div([Global] double3[] a, [Global] double3[] b, [Global] double3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestDivManaged()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],double3[]>)test_double3_div,
                a,
                b,
                r
            );
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s2, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestDivCl()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_div"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s2, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestDivSpirV()
        {
            var a = new double3[] { new double3((double)   7, (double)  14, (double)  21), new double3((double)   5, (double)  10, (double)  15) };
            var b = new double3[] { new double3((double)   5, (double)  10, (double)  15), new double3((double)   7, (double)  14, (double)  21) };
            var r = new double3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_div"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s2, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s2, 7.1428571428571436e-16);
        }

        [Kernel]
        private static void test_double3_eq([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestEqManaged()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_eq,
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
        [Category("Compiled.Cl")]
        public void TestEqCl()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_eq"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        [Category("Compiled.SpirV")]
        public void TestEqSpirV()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_eq"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        private static void test_double3_neq([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestNeqManaged()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_neq,
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
        [Category("Compiled.Cl")]
        public void TestNeqCl()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_neq"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        [Category("Compiled.SpirV")]
        public void TestNeqSpirV()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_neq"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        private static void test_double3_lt([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLtManaged()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_lt,
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
        [Category("Compiled.Cl")]
        public void TestLtCl()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_lt"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        [Category("Compiled.SpirV")]
        public void TestLtSpirV()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_lt"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        private static void test_double3_le([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestLeManaged()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_le,
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
        [Category("Compiled.Cl")]
        public void TestLeCl()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_le"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        [Category("Compiled.SpirV")]
        public void TestLeSpirV()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_le"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        private static void test_double3_gt([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGtManaged()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_gt,
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
        [Category("Compiled.Cl")]
        public void TestGtCl()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_gt"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        [Category("Compiled.SpirV")]
        public void TestGtSpirV()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_gt"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        private static void test_double3_ge([Global] double3[] a, [Global] double3[] b, [Global] long3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        [Category("Managed")]
        public void TestGeManaged()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double3[],double3[],long3[]>)test_double3_ge,
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
        [Category("Compiled.Cl")]
        public void TestGeCl()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_ge"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        [Category("Compiled.SpirV")]
        public void TestGeSpirV()
        {
            var a = new double3[] { new double3((double)   4, (double)   3, (double)   2), new double3((double)   0, (double)   1, (double)   2) };
            var b = new double3[] { new double3((double)   0, (double)   1, (double)   2), new double3((double)   4, (double)   3, (double)   2) };
            var r = new long3[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_double3_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double3_ge"))
            using (var ma = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long3>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long3>()))
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
        private static void test_components1([Global] double[] r, [Global] double3[] w)
        {
            var ar = new double3((double)1, (double)2, (double)3);
            var aw = (double)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
            r[2] = ar.z;
            w[2].z = aw;
        }

        [Test]
        [Category("Managed")]
        public void TestComponentAccessors1Managed()
        {
            var nr = 3;
            var nw = 3;
            var r = new double[nr];
            var w = new double3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double[],double3[]>)test_components1,
                r, w
            );
            Assert.AreEqual((double)1, r[0]);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)0, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
            Assert.AreEqual((double)0, w[1].s2);
            Assert.AreEqual((double)3, r[2]);
            Assert.AreEqual((double)1, w[2].s2);
            Assert.AreEqual((double)0, w[2].s0);
            Assert.AreEqual((double)0, w[2].s1);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestComponentAccessors1Cl()
        {
            var nr = 3;
            var nw = 3;
            var r = new double[nr];
            var w = new double3[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<double>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double>()))
            using (var mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((double)1, r[0]);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)0, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
            Assert.AreEqual((double)0, w[1].s2);
            Assert.AreEqual((double)3, r[2]);
            Assert.AreEqual((double)1, w[2].s2);
            Assert.AreEqual((double)0, w[2].s0);
            Assert.AreEqual((double)0, w[2].s1);
        }

        [Test]
        [Category("Compiled.SpirV")]
        [Ignore("Handling component accessors not implemented in SPIR-V compiler.")]
        public void TestComponentAccessors1SpirV()
        {
            var nr = 3;
            var nw = 3;
            var r = new double[nr];
            var w = new double3[nw];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components1", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<double>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double>()))
            using (var mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((double)1, r[0]);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)0, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
            Assert.AreEqual((double)0, w[1].s2);
            Assert.AreEqual((double)3, r[2]);
            Assert.AreEqual((double)1, w[2].s2);
            Assert.AreEqual((double)0, w[2].s0);
            Assert.AreEqual((double)0, w[2].s1);
        }
        [Kernel]
        private static void test_components2([Global] double2[] r, [Global] double3[] w)
        {
            var ar = new double3((double)1, (double)2, (double)3);
            var aw = new double2((double)1, (double)2);
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
        [Category("Managed")]
        public void TestComponentAccessors2Managed()
        {
            var nr = 9;
            var nw = 6;
            var r = new double2[nr];
            var w = new double3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double2[],double3[]>)test_components2,
                r, w
            );
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)2, r[1].s1);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)3, r[2].s1);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)0, w[1].s1);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)1, r[3].s1);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)0, w[2].s2);
            Assert.AreEqual((double)2, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[5].s0);
            Assert.AreEqual((double)3, r[5].s1);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)0, w[3].s0);
            Assert.AreEqual((double)3, r[6].s0);
            Assert.AreEqual((double)1, r[6].s1);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)0, w[4].s1);
            Assert.AreEqual((double)3, r[7].s0);
            Assert.AreEqual((double)2, r[7].s1);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)0, w[5].s0);
            Assert.AreEqual((double)3, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestComponentAccessors2Cl()
        {
            var nr = 9;
            var nw = 6;
            var r = new double2[nr];
            var w = new double3[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double2>()))
            using (var mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)2, r[1].s1);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)3, r[2].s1);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)0, w[1].s1);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)1, r[3].s1);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)0, w[2].s2);
            Assert.AreEqual((double)2, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[5].s0);
            Assert.AreEqual((double)3, r[5].s1);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)0, w[3].s0);
            Assert.AreEqual((double)3, r[6].s0);
            Assert.AreEqual((double)1, r[6].s1);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)0, w[4].s1);
            Assert.AreEqual((double)3, r[7].s0);
            Assert.AreEqual((double)2, r[7].s1);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)0, w[5].s0);
            Assert.AreEqual((double)3, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
        }

        [Test]
        [Category("Compiled.SpirV")]
        [Ignore("Handling component accessors not implemented in SPIR-V compiler.")]
        public void TestComponentAccessors2SpirV()
        {
            var nr = 9;
            var nw = 6;
            var r = new double2[nr];
            var w = new double3[nw];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components2", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double2>()))
            using (var mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)2, r[1].s1);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)0, w[0].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)3, r[2].s1);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)0, w[1].s1);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)1, r[3].s1);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)0, w[2].s2);
            Assert.AreEqual((double)2, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[5].s0);
            Assert.AreEqual((double)3, r[5].s1);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)0, w[3].s0);
            Assert.AreEqual((double)3, r[6].s0);
            Assert.AreEqual((double)1, r[6].s1);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)0, w[4].s1);
            Assert.AreEqual((double)3, r[7].s0);
            Assert.AreEqual((double)2, r[7].s1);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)0, w[5].s0);
            Assert.AreEqual((double)3, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
        }
        [Kernel]
        private static void test_components3([Global] double3[] r, [Global] double3[] w)
        {
            var ar = new double3((double)1, (double)2, (double)3);
            var aw = new double3((double)1, (double)2, (double)3);
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
        [Category("Managed")]
        public void TestComponentAccessors3Managed()
        {
            var nr = 27;
            var nw = 6;
            var r = new double3[nr];
            var w = new double3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double3[],double3[]>)test_components3,
                r, w
            );
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[0].s2);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)1, r[1].s1);
            Assert.AreEqual((double)2, r[1].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)3, r[2].s2);
            Assert.AreEqual((double)1, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
            Assert.AreEqual((double)1, r[3].s2);
            Assert.AreEqual((double)1, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[4].s2);
            Assert.AreEqual((double)1, r[5].s0);
            Assert.AreEqual((double)2, r[5].s1);
            Assert.AreEqual((double)3, r[5].s2);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)3, w[0].s2);
            Assert.AreEqual((double)1, r[6].s0);
            Assert.AreEqual((double)3, r[6].s1);
            Assert.AreEqual((double)1, r[6].s2);
            Assert.AreEqual((double)1, r[7].s0);
            Assert.AreEqual((double)3, r[7].s1);
            Assert.AreEqual((double)2, r[7].s2);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)3, w[1].s1);
            Assert.AreEqual((double)1, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
            Assert.AreEqual((double)3, r[8].s2);
            Assert.AreEqual((double)2, r[9].s0);
            Assert.AreEqual((double)1, r[9].s1);
            Assert.AreEqual((double)1, r[9].s2);
            Assert.AreEqual((double)2, r[10].s0);
            Assert.AreEqual((double)1, r[10].s1);
            Assert.AreEqual((double)2, r[10].s2);
            Assert.AreEqual((double)2, r[11].s0);
            Assert.AreEqual((double)1, r[11].s1);
            Assert.AreEqual((double)3, r[11].s2);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)3, w[2].s2);
            Assert.AreEqual((double)2, r[12].s0);
            Assert.AreEqual((double)2, r[12].s1);
            Assert.AreEqual((double)1, r[12].s2);
            Assert.AreEqual((double)2, r[13].s0);
            Assert.AreEqual((double)2, r[13].s1);
            Assert.AreEqual((double)2, r[13].s2);
            Assert.AreEqual((double)2, r[14].s0);
            Assert.AreEqual((double)2, r[14].s1);
            Assert.AreEqual((double)3, r[14].s2);
            Assert.AreEqual((double)2, r[15].s0);
            Assert.AreEqual((double)3, r[15].s1);
            Assert.AreEqual((double)1, r[15].s2);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)3, w[3].s0);
            Assert.AreEqual((double)2, r[16].s0);
            Assert.AreEqual((double)3, r[16].s1);
            Assert.AreEqual((double)2, r[16].s2);
            Assert.AreEqual((double)2, r[17].s0);
            Assert.AreEqual((double)3, r[17].s1);
            Assert.AreEqual((double)3, r[17].s2);
            Assert.AreEqual((double)3, r[18].s0);
            Assert.AreEqual((double)1, r[18].s1);
            Assert.AreEqual((double)1, r[18].s2);
            Assert.AreEqual((double)3, r[19].s0);
            Assert.AreEqual((double)1, r[19].s1);
            Assert.AreEqual((double)2, r[19].s2);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)3, w[4].s1);
            Assert.AreEqual((double)3, r[20].s0);
            Assert.AreEqual((double)1, r[20].s1);
            Assert.AreEqual((double)3, r[20].s2);
            Assert.AreEqual((double)3, r[21].s0);
            Assert.AreEqual((double)2, r[21].s1);
            Assert.AreEqual((double)1, r[21].s2);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)3, w[5].s0);
            Assert.AreEqual((double)3, r[22].s0);
            Assert.AreEqual((double)2, r[22].s1);
            Assert.AreEqual((double)2, r[22].s2);
            Assert.AreEqual((double)3, r[23].s0);
            Assert.AreEqual((double)2, r[23].s1);
            Assert.AreEqual((double)3, r[23].s2);
            Assert.AreEqual((double)3, r[24].s0);
            Assert.AreEqual((double)3, r[24].s1);
            Assert.AreEqual((double)1, r[24].s2);
            Assert.AreEqual((double)3, r[25].s0);
            Assert.AreEqual((double)3, r[25].s1);
            Assert.AreEqual((double)2, r[25].s2);
            Assert.AreEqual((double)3, r[26].s0);
            Assert.AreEqual((double)3, r[26].s1);
            Assert.AreEqual((double)3, r[26].s2);
        }

        [Test]
        [Category("Compiled.Cl")]
        public void TestComponentAccessors3Cl()
        {
            var nr = 27;
            var nw = 6;
            var r = new double3[nr];
            var w = new double3[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components3");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components3"))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double3>()))
            using (var mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[0].s2);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)1, r[1].s1);
            Assert.AreEqual((double)2, r[1].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)3, r[2].s2);
            Assert.AreEqual((double)1, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
            Assert.AreEqual((double)1, r[3].s2);
            Assert.AreEqual((double)1, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[4].s2);
            Assert.AreEqual((double)1, r[5].s0);
            Assert.AreEqual((double)2, r[5].s1);
            Assert.AreEqual((double)3, r[5].s2);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)3, w[0].s2);
            Assert.AreEqual((double)1, r[6].s0);
            Assert.AreEqual((double)3, r[6].s1);
            Assert.AreEqual((double)1, r[6].s2);
            Assert.AreEqual((double)1, r[7].s0);
            Assert.AreEqual((double)3, r[7].s1);
            Assert.AreEqual((double)2, r[7].s2);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)3, w[1].s1);
            Assert.AreEqual((double)1, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
            Assert.AreEqual((double)3, r[8].s2);
            Assert.AreEqual((double)2, r[9].s0);
            Assert.AreEqual((double)1, r[9].s1);
            Assert.AreEqual((double)1, r[9].s2);
            Assert.AreEqual((double)2, r[10].s0);
            Assert.AreEqual((double)1, r[10].s1);
            Assert.AreEqual((double)2, r[10].s2);
            Assert.AreEqual((double)2, r[11].s0);
            Assert.AreEqual((double)1, r[11].s1);
            Assert.AreEqual((double)3, r[11].s2);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)3, w[2].s2);
            Assert.AreEqual((double)2, r[12].s0);
            Assert.AreEqual((double)2, r[12].s1);
            Assert.AreEqual((double)1, r[12].s2);
            Assert.AreEqual((double)2, r[13].s0);
            Assert.AreEqual((double)2, r[13].s1);
            Assert.AreEqual((double)2, r[13].s2);
            Assert.AreEqual((double)2, r[14].s0);
            Assert.AreEqual((double)2, r[14].s1);
            Assert.AreEqual((double)3, r[14].s2);
            Assert.AreEqual((double)2, r[15].s0);
            Assert.AreEqual((double)3, r[15].s1);
            Assert.AreEqual((double)1, r[15].s2);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)3, w[3].s0);
            Assert.AreEqual((double)2, r[16].s0);
            Assert.AreEqual((double)3, r[16].s1);
            Assert.AreEqual((double)2, r[16].s2);
            Assert.AreEqual((double)2, r[17].s0);
            Assert.AreEqual((double)3, r[17].s1);
            Assert.AreEqual((double)3, r[17].s2);
            Assert.AreEqual((double)3, r[18].s0);
            Assert.AreEqual((double)1, r[18].s1);
            Assert.AreEqual((double)1, r[18].s2);
            Assert.AreEqual((double)3, r[19].s0);
            Assert.AreEqual((double)1, r[19].s1);
            Assert.AreEqual((double)2, r[19].s2);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)3, w[4].s1);
            Assert.AreEqual((double)3, r[20].s0);
            Assert.AreEqual((double)1, r[20].s1);
            Assert.AreEqual((double)3, r[20].s2);
            Assert.AreEqual((double)3, r[21].s0);
            Assert.AreEqual((double)2, r[21].s1);
            Assert.AreEqual((double)1, r[21].s2);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)3, w[5].s0);
            Assert.AreEqual((double)3, r[22].s0);
            Assert.AreEqual((double)2, r[22].s1);
            Assert.AreEqual((double)2, r[22].s2);
            Assert.AreEqual((double)3, r[23].s0);
            Assert.AreEqual((double)2, r[23].s1);
            Assert.AreEqual((double)3, r[23].s2);
            Assert.AreEqual((double)3, r[24].s0);
            Assert.AreEqual((double)3, r[24].s1);
            Assert.AreEqual((double)1, r[24].s2);
            Assert.AreEqual((double)3, r[25].s0);
            Assert.AreEqual((double)3, r[25].s1);
            Assert.AreEqual((double)2, r[25].s2);
            Assert.AreEqual((double)3, r[26].s0);
            Assert.AreEqual((double)3, r[26].s1);
            Assert.AreEqual((double)3, r[26].s2);
        }

        [Test]
        [Category("Compiled.SpirV")]
        [Ignore("Handling component accessors not implemented in SPIR-V compiler.")]
        public void TestComponentAccessors3SpirV()
        {
            var nr = 27;
            var nw = 6;
            var r = new double3[nr];
            var w = new double3[nw];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble3", "test_components3", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_components3"))
            using (var mr = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double3>()))
            using (var mw = Mem<double3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double3>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double3));
                queue.Finish();
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, false, r);
                queue.EnqueueReadBuffer(mw, false, w);
                queue.Finish();
            }
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[0].s2);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)1, r[1].s1);
            Assert.AreEqual((double)2, r[1].s2);
            Assert.AreEqual((double)1, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)3, r[2].s2);
            Assert.AreEqual((double)1, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
            Assert.AreEqual((double)1, r[3].s2);
            Assert.AreEqual((double)1, r[4].s0);
            Assert.AreEqual((double)2, r[4].s1);
            Assert.AreEqual((double)2, r[4].s2);
            Assert.AreEqual((double)1, r[5].s0);
            Assert.AreEqual((double)2, r[5].s1);
            Assert.AreEqual((double)3, r[5].s2);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)3, w[0].s2);
            Assert.AreEqual((double)1, r[6].s0);
            Assert.AreEqual((double)3, r[6].s1);
            Assert.AreEqual((double)1, r[6].s2);
            Assert.AreEqual((double)1, r[7].s0);
            Assert.AreEqual((double)3, r[7].s1);
            Assert.AreEqual((double)2, r[7].s2);
            Assert.AreEqual((double)1, w[1].s0);
            Assert.AreEqual((double)2, w[1].s2);
            Assert.AreEqual((double)3, w[1].s1);
            Assert.AreEqual((double)1, r[8].s0);
            Assert.AreEqual((double)3, r[8].s1);
            Assert.AreEqual((double)3, r[8].s2);
            Assert.AreEqual((double)2, r[9].s0);
            Assert.AreEqual((double)1, r[9].s1);
            Assert.AreEqual((double)1, r[9].s2);
            Assert.AreEqual((double)2, r[10].s0);
            Assert.AreEqual((double)1, r[10].s1);
            Assert.AreEqual((double)2, r[10].s2);
            Assert.AreEqual((double)2, r[11].s0);
            Assert.AreEqual((double)1, r[11].s1);
            Assert.AreEqual((double)3, r[11].s2);
            Assert.AreEqual((double)1, w[2].s1);
            Assert.AreEqual((double)2, w[2].s0);
            Assert.AreEqual((double)3, w[2].s2);
            Assert.AreEqual((double)2, r[12].s0);
            Assert.AreEqual((double)2, r[12].s1);
            Assert.AreEqual((double)1, r[12].s2);
            Assert.AreEqual((double)2, r[13].s0);
            Assert.AreEqual((double)2, r[13].s1);
            Assert.AreEqual((double)2, r[13].s2);
            Assert.AreEqual((double)2, r[14].s0);
            Assert.AreEqual((double)2, r[14].s1);
            Assert.AreEqual((double)3, r[14].s2);
            Assert.AreEqual((double)2, r[15].s0);
            Assert.AreEqual((double)3, r[15].s1);
            Assert.AreEqual((double)1, r[15].s2);
            Assert.AreEqual((double)1, w[3].s1);
            Assert.AreEqual((double)2, w[3].s2);
            Assert.AreEqual((double)3, w[3].s0);
            Assert.AreEqual((double)2, r[16].s0);
            Assert.AreEqual((double)3, r[16].s1);
            Assert.AreEqual((double)2, r[16].s2);
            Assert.AreEqual((double)2, r[17].s0);
            Assert.AreEqual((double)3, r[17].s1);
            Assert.AreEqual((double)3, r[17].s2);
            Assert.AreEqual((double)3, r[18].s0);
            Assert.AreEqual((double)1, r[18].s1);
            Assert.AreEqual((double)1, r[18].s2);
            Assert.AreEqual((double)3, r[19].s0);
            Assert.AreEqual((double)1, r[19].s1);
            Assert.AreEqual((double)2, r[19].s2);
            Assert.AreEqual((double)1, w[4].s2);
            Assert.AreEqual((double)2, w[4].s0);
            Assert.AreEqual((double)3, w[4].s1);
            Assert.AreEqual((double)3, r[20].s0);
            Assert.AreEqual((double)1, r[20].s1);
            Assert.AreEqual((double)3, r[20].s2);
            Assert.AreEqual((double)3, r[21].s0);
            Assert.AreEqual((double)2, r[21].s1);
            Assert.AreEqual((double)1, r[21].s2);
            Assert.AreEqual((double)1, w[5].s2);
            Assert.AreEqual((double)2, w[5].s1);
            Assert.AreEqual((double)3, w[5].s0);
            Assert.AreEqual((double)3, r[22].s0);
            Assert.AreEqual((double)2, r[22].s1);
            Assert.AreEqual((double)2, r[22].s2);
            Assert.AreEqual((double)3, r[23].s0);
            Assert.AreEqual((double)2, r[23].s1);
            Assert.AreEqual((double)3, r[23].s2);
            Assert.AreEqual((double)3, r[24].s0);
            Assert.AreEqual((double)3, r[24].s1);
            Assert.AreEqual((double)1, r[24].s2);
            Assert.AreEqual((double)3, r[25].s0);
            Assert.AreEqual((double)3, r[25].s1);
            Assert.AreEqual((double)2, r[25].s2);
            Assert.AreEqual((double)3, r[26].s0);
            Assert.AreEqual((double)3, r[26].s1);
            Assert.AreEqual((double)3, r[26].s2);
        }
    }
}
