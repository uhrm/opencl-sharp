
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
    public class TestDouble2
    {
        [Kernel]
        private static void test_double2_add([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_add,
                a,
                b,
                r
            );
            Assert.AreEqual(1.2000000000000000e+01, r[0].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[0].s1, 2.4000000000000002e-14);
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
        }

        [Test]
        public void TestAddCl()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_add");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_add"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
        }

        [Test]
        public void TestAddSpirV()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_add", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_add"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(1.2000000000000000e+01, r[1].s0, 1.2000000000000001e-14);
            Assert.AreEqual(2.4000000000000000e+01, r[1].s1, 2.4000000000000002e-14);
        }

        [Kernel]
        private static void test_double2_sub([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(2.0000000000000000e+00, r[0].s0, 2.0000000000000002e-15);
            Assert.AreEqual(4.0000000000000000e+00, r[0].s1, 4.0000000000000003e-15);
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
        }

        [Test]
        public void TestSubCl()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_sub");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_sub"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
        }

        [Test]
        public void TestSubSpirV()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_sub", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_sub"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(-2.0000000000000000e+00, r[1].s0, 2.0000000000000002e-15);
            Assert.AreEqual(-4.0000000000000000e+00, r[1].s1, 4.0000000000000003e-15);
        }

        [Kernel]
        private static void test_double2_mul([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(3.5000000000000000e+01, r[0].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[0].s1, 1.4000000000000001e-13);
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
        }

        [Test]
        public void TestMulCl()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_mul");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_mul"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
        }

        [Test]
        public void TestMulSpirV()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_mul", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_mul"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(3.5000000000000000e+01, r[1].s0, 3.5000000000000002e-14);
            Assert.AreEqual(1.4000000000000000e+02, r[1].s1, 1.4000000000000001e-13);
        }

        [Kernel]
        private static void test_double2_div([Global] double2[] a, [Global] double2[] b, [Global] double2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],double2[]>)test_double2_div,
                a,
                b,
                r
            );
            Assert.AreEqual(1.3999999999999999e+00, r[0].s0, 1.4000000000000001e-15);
            Assert.AreEqual(1.3999999999999999e+00, r[0].s1, 1.4000000000000001e-15);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
        }

        [Test]
        public void TestDivCl()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_div");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_div"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
        }

        [Test]
        public void TestDivSpirV()
        {
            var a = new double2[] { new double2((double)   7, (double)  14), new double2((double)   5, (double)  10) };
            var b = new double2[] { new double2((double)   5, (double)  10), new double2((double)   7, (double)  14) };
            var r = new double2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_div", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_div"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<double2>()))
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
            Assert.AreEqual(7.1428571428571430e-01, r[1].s0, 7.1428571428571436e-16);
            Assert.AreEqual(7.1428571428571430e-01, r[1].s1, 7.1428571428571436e-16);
        }

        [Kernel]
        private static void test_double2_eq([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEqManaged()
        {
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_eq,
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_eq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_eq"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_eq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_eq"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
        private static void test_double2_neq([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeqManaged()
        {
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_neq,
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_neq");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_neq"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_neq", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_neq"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
        private static void test_double2_lt([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLtManaged()
        {
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_lt,
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_lt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_lt"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_lt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_lt"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
        private static void test_double2_le([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLeManaged()
        {
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_le,
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_le");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_le"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_le", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_le"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
        private static void test_double2_gt([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGtManaged()
        {
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_gt,
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_gt");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_gt"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_gt", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_gt"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
        private static void test_double2_ge([Global] double2[] a, [Global] double2[] b, [Global] long2[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGeManaged()
        {
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<double2[],double2[],long2[]>)test_double2_ge,
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_ge");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_ge"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
            var a = new double2[] { new double2((double)   2, (double)   1), new double2((double)   0, (double)   1) };
            var b = new double2[] { new double2((double)   0, (double)   1), new double2((double)   2, (double)   1) };
            var r = new long2[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_double2_ge", module);

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_double2_ge"))
            using (var ma = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<double2>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<long2>.CreateBuffer(context, MemFlags.ReadWrite, 2*Marshal.SizeOf<long2>()))
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
        private static void test_components1([Global] double[] r, [Global] double2[] w)
        {
            var ar = new double2((double)1, (double)2);
            var aw = (double)1;
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
            var r = new double[nr];
            var w = new double2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double[],double2[]>)test_components1,
                r, w
            );
            Assert.AreEqual((double)1, r[0]);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)0, w[0].s1);
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
        }

        [Test]
        public void TestComponentAccessors1Cl()
        {
            var nr = 2;
            var nw = 2;
            var r = new double[nr];
            var w = new double2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_components1");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components1"))
            using (var mr = Mem<double>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double>()))
            using (var mw = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double2));
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
            Assert.AreEqual((double)2, r[1]);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)0, w[1].s0);
        }
        [Kernel]
        private static void test_components2([Global] double2[] r, [Global] double2[] w)
        {
            var ar = new double2((double)1, (double)2);
            var aw = new double2((double)1, (double)2);
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
            var r = new double2[nr];
            var w = new double2[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<double2[],double2[]>)test_components2,
                r, w
            );
            Assert.AreEqual((double)1, r[0].s0);
            Assert.AreEqual((double)1, r[0].s1);
            Assert.AreEqual((double)1, r[1].s0);
            Assert.AreEqual((double)2, r[1].s1);
            Assert.AreEqual((double)1, w[0].s0);
            Assert.AreEqual((double)2, w[0].s1);
            Assert.AreEqual((double)2, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)2, w[1].s0);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
        }

        [Test]
        public void TestComponentAccessors2Cl()
        {
            var nr = 4;
            var nw = 2;
            var r = new double2[nr];
            var w = new double2[nw];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestDouble2", "test_components2");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_components2"))
            using (var mr = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<double2>()))
            using (var mw = Mem<double2>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<double2>()))
            {
                kernel.SetKernelArg(0, (HandleObject)mr);
                kernel.SetKernelArg(1, (HandleObject)mw);
                queue.EnqueueFillBuffer(mw, default(double2));
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
            Assert.AreEqual((double)2, r[2].s0);
            Assert.AreEqual((double)1, r[2].s1);
            Assert.AreEqual((double)1, w[1].s1);
            Assert.AreEqual((double)2, w[1].s0);
            Assert.AreEqual((double)2, r[3].s0);
            Assert.AreEqual((double)2, r[3].s1);
        }
    }
}
