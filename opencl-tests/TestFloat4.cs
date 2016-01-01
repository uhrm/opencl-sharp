using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestFloat4
    {
        [Kernel]
        private static void test_float4_add([Global] float4[] a, [Global] float4[] b, [Global] float4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            float4[] a = new float4[] { new float4((float)   7, (float)  14, (float)  21, (float)  28), new float4((float)   5, (float)  10, (float)  15, (float)  20) };
            float4[] b = new float4[] { new float4((float)   5, (float)  10, (float)  15, (float)  20), new float4((float)   7, (float)  14, (float)  21, (float)  28) };
            float4[] r = new float4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],float4[]>)test_float4_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[1].s3, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<float4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_add");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(  12.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  48.00000000, r[1].s3, 1e-7);
        }

        [Kernel]
        private static void test_float4_sub([Global] float4[] a, [Global] float4[] b, [Global] float4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            float4[] a = new float4[] { new float4((float)   7, (float)  14, (float)  21, (float)  28), new float4((float)   5, (float)  10, (float)  15, (float)  20) };
            float4[] b = new float4[] { new float4((float)   5, (float)  10, (float)  15, (float)  20), new float4((float)   7, (float)  14, (float)  21, (float)  28) };
            float4[] r = new float4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],float4[]>)test_float4_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(   4.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(   6.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(   8.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  -8.00000000, r[1].s3, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<float4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_sub");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(   2.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(   4.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(   6.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(   8.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);
            Assert.AreEqual(  -8.00000000, r[1].s3, 1e-7);
        }

        [Kernel]
        private static void test_float4_mul([Global] float4[] a, [Global] float4[] b, [Global] float4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            float4[] a = new float4[] { new float4((float)   7, (float)  14, (float)  21, (float)  28), new float4((float)   5, (float)  10, (float)  15, (float)  20) };
            float4[] b = new float4[] { new float4((float)   5, (float)  10, (float)  15, (float)  20), new float4((float)   7, (float)  14, (float)  21, (float)  28) };
            float4[] r = new float4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],float4[]>)test_float4_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35.00000000, r[0].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[0].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[0].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[1].s3, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<float4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_mul");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(  35.00000000, r[0].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[0].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[0].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[0].s3, 1e-7);
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);
            Assert.AreEqual( 560.00000000, r[1].s3, 1e-7);
        }

        [Kernel]
        private static void test_float4_div([Global] float4[] a, [Global] float4[] b, [Global] float4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            float4[] a = new float4[] { new float4((float)   7, (float)  14, (float)  21, (float)  28), new float4((float)   5, (float)  10, (float)  15, (float)  20) };
            float4[] b = new float4[] { new float4((float)   5, (float)  10, (float)  15, (float)  20), new float4((float)   7, (float)  14, (float)  21, (float)  28) };
            float4[] r = new float4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],float4[]>)test_float4_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1.39999998, r[0].s0, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s1, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s2, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s3, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s3, 1e-7);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<float4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_div");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(   1.39999998, r[0].s0, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s1, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s2, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s3, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s3, 1e-7);
        }

        [Kernel]
        private static void test_float4_eq([Global] float4[] a, [Global] float4[] b, [Global] int4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            float4[] a = new float4[] { new float4((float)   6, (float)   5, (float)   4, (float)   3), new float4((float)   0, (float)   1, (float)   2, (float)   3) };
            float4[] b = new float4[] { new float4((float)   0, (float)   1, (float)   2, (float)   3), new float4((float)   6, (float)   5, (float)   4, (float)   3) };
            int4[] r = new int4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],int4[]>)test_float4_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<int4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_eq");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
        }

        [Kernel]
        private static void test_float4_neq([Global] float4[] a, [Global] float4[] b, [Global] int4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            float4[] a = new float4[] { new float4((float)   6, (float)   5, (float)   4, (float)   3), new float4((float)   0, (float)   1, (float)   2, (float)   3) };
            float4[] b = new float4[] { new float4((float)   0, (float)   1, (float)   2, (float)   3), new float4((float)   6, (float)   5, (float)   4, (float)   3) };
            int4[] r = new int4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],int4[]>)test_float4_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<int4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_neq");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
        }

        [Kernel]
        private static void test_float4_lt([Global] float4[] a, [Global] float4[] b, [Global] int4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            float4[] a = new float4[] { new float4((float)   6, (float)   5, (float)   4, (float)   3), new float4((float)   0, (float)   1, (float)   2, (float)   3) };
            float4[] b = new float4[] { new float4((float)   0, (float)   1, (float)   2, (float)   3), new float4((float)   6, (float)   5, (float)   4, (float)   3) };
            int4[] r = new int4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],int4[]>)test_float4_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<int4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_lt");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
        }

        [Kernel]
        private static void test_float4_le([Global] float4[] a, [Global] float4[] b, [Global] int4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            float4[] a = new float4[] { new float4((float)   6, (float)   5, (float)   4, (float)   3), new float4((float)   0, (float)   1, (float)   2, (float)   3) };
            float4[] b = new float4[] { new float4((float)   0, (float)   1, (float)   2, (float)   3), new float4((float)   6, (float)   5, (float)   4, (float)   3) };
            int4[] r = new int4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],int4[]>)test_float4_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<int4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_le");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
        }

        [Kernel]
        private static void test_float4_gt([Global] float4[] a, [Global] float4[] b, [Global] int4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            float4[] a = new float4[] { new float4((float)   6, (float)   5, (float)   4, (float)   3), new float4((float)   0, (float)   1, (float)   2, (float)   3) };
            float4[] b = new float4[] { new float4((float)   0, (float)   1, (float)   2, (float)   3), new float4((float)   6, (float)   5, (float)   4, (float)   3) };
            int4[] r = new int4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],int4[]>)test_float4_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<int4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_gt");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
        }

        [Kernel]
        private static void test_float4_ge([Global] float4[] a, [Global] float4[] b, [Global] int4[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            float4[] a = new float4[] { new float4((float)   6, (float)   5, (float)   4, (float)   3), new float4((float)   0, (float)   1, (float)   2, (float)   3) };
            float4[] b = new float4[] { new float4((float)   0, (float)   1, (float)   2, (float)   3), new float4((float)   6, (float)   5, (float)   4, (float)   3) };
            int4[] r = new int4[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float4[],float4[],int4[]>)test_float4_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);

            // compile kernel
            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat4", "test_float4_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float4>;
                var mb = null as Mem<float4>;
                var mr = null as Mem<int4>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float4_ge");
                    ma = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float4>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int4>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int4>());
                    kernel.SetKernelArg(0, (HandleObject)ma);
                    kernel.SetKernelArg(1, (HandleObject)mb);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, 2);
                    queue.EnqueueReadBuffer(mr, true, r);
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mb != null) mb.Dispose();
                    if (ma != null) ma.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
        }

    }
}
