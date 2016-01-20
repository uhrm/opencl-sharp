using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestFloat3
    {
        [Kernel]
        private static void test_float3_add([Global] float3[] a, [Global] float3[] b, [Global] float3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAdd()
        {
            float3[] a = new float3[] { new float3((float)   7, (float)  14, (float)  21), new float3((float)   5, (float)  10, (float)  15) };
            float3[] b = new float3[] { new float3((float)   5, (float)  10, (float)  15), new float3((float)   7, (float)  14, (float)  21) };
            float3[] r = new float3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],float3[]>)test_float3_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_add");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<float3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_add");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float3>());
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
            Assert.AreEqual(  12.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  24.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  36.00000000, r[1].s2, 1e-7);
        }

        [Kernel]
        private static void test_float3_sub([Global] float3[] a, [Global] float3[] b, [Global] float3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSub()
        {
            float3[] a = new float3[] { new float3((float)   7, (float)  14, (float)  21), new float3((float)   5, (float)  10, (float)  15) };
            float3[] b = new float3[] { new float3((float)   5, (float)  10, (float)  15), new float3((float)   7, (float)  14, (float)  21) };
            float3[] r = new float3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],float3[]>)test_float3_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2.00000000, r[0].s0, 1e-7);
            Assert.AreEqual(   4.00000000, r[0].s1, 1e-7);
            Assert.AreEqual(   6.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_sub");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<float3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_sub");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float3>());
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
            Assert.AreEqual(  -2.00000000, r[1].s0, 1e-7);
            Assert.AreEqual(  -4.00000000, r[1].s1, 1e-7);
            Assert.AreEqual(  -6.00000000, r[1].s2, 1e-7);
        }

        [Kernel]
        private static void test_float3_mul([Global] float3[] a, [Global] float3[] b, [Global] float3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMul()
        {
            float3[] a = new float3[] { new float3((float)   7, (float)  14, (float)  21), new float3((float)   5, (float)  10, (float)  15) };
            float3[] b = new float3[] { new float3((float)   5, (float)  10, (float)  15), new float3((float)   7, (float)  14, (float)  21) };
            float3[] r = new float3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],float3[]>)test_float3_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35.00000000, r[0].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[0].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[0].s2, 1e-7);
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_mul");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<float3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_mul");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float3>());
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
            Assert.AreEqual(  35.00000000, r[1].s0, 1e-7);
            Assert.AreEqual( 140.00000000, r[1].s1, 1e-7);
            Assert.AreEqual( 315.00000000, r[1].s2, 1e-7);
        }

        [Kernel]
        private static void test_float3_div([Global] float3[] a, [Global] float3[] b, [Global] float3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDiv()
        {
            float3[] a = new float3[] { new float3((float)   7, (float)  14, (float)  21), new float3((float)   5, (float)  10, (float)  15) };
            float3[] b = new float3[] { new float3((float)   5, (float)  10, (float)  15), new float3((float)   7, (float)  14, (float)  21) };
            float3[] r = new float3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],float3[]>)test_float3_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1.39999998, r[0].s0, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s1, 1e-7);
            Assert.AreEqual(   1.39999998, r[0].s2, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_div");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<float3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_div");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<float3>());
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
            Assert.AreEqual(   0.71428573, r[1].s0, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s1, 1e-7);
            Assert.AreEqual(   0.71428573, r[1].s2, 1e-7);
        }

        [Kernel]
        private static void test_float3_eq([Global] float3[] a, [Global] float3[] b, [Global] int3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            float3[] a = new float3[] { new float3((float)   4, (float)   3, (float)   2), new float3((float)   0, (float)   1, (float)   2) };
            float3[] b = new float3[] { new float3((float)   0, (float)   1, (float)   2), new float3((float)   4, (float)   3, (float)   2) };
            int3[] r = new int3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],int3[]>)test_float3_eq,
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

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<int3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_eq");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int3>());
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
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_float3_neq([Global] float3[] a, [Global] float3[] b, [Global] int3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            float3[] a = new float3[] { new float3((float)   4, (float)   3, (float)   2), new float3((float)   0, (float)   1, (float)   2) };
            float3[] b = new float3[] { new float3((float)   0, (float)   1, (float)   2), new float3((float)   4, (float)   3, (float)   2) };
            int3[] r = new int3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],int3[]>)test_float3_neq,
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

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<int3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_neq");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int3>());
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
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_float3_lt([Global] float3[] a, [Global] float3[] b, [Global] int3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            float3[] a = new float3[] { new float3((float)   4, (float)   3, (float)   2), new float3((float)   0, (float)   1, (float)   2) };
            float3[] b = new float3[] { new float3((float)   0, (float)   1, (float)   2), new float3((float)   4, (float)   3, (float)   2) };
            int3[] r = new int3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],int3[]>)test_float3_lt,
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

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<int3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_lt");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int3>());
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
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_float3_le([Global] float3[] a, [Global] float3[] b, [Global] int3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            float3[] a = new float3[] { new float3((float)   4, (float)   3, (float)   2), new float3((float)   0, (float)   1, (float)   2) };
            float3[] b = new float3[] { new float3((float)   0, (float)   1, (float)   2), new float3((float)   4, (float)   3, (float)   2) };
            int3[] r = new int3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],int3[]>)test_float3_le,
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

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<int3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_le");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int3>());
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
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_float3_gt([Global] float3[] a, [Global] float3[] b, [Global] int3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            float3[] a = new float3[] { new float3((float)   4, (float)   3, (float)   2), new float3((float)   0, (float)   1, (float)   2) };
            float3[] b = new float3[] { new float3((float)   0, (float)   1, (float)   2), new float3((float)   4, (float)   3, (float)   2) };
            int3[] r = new int3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],int3[]>)test_float3_gt,
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

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<int3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_gt");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int3>());
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
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
        }

        [Kernel]
        private static void test_float3_ge([Global] float3[] a, [Global] float3[] b, [Global] int3[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            float3[] a = new float3[] { new float3((float)   4, (float)   3, (float)   2), new float3((float)   0, (float)   1, (float)   2) };
            float3[] b = new float3[] { new float3((float)   0, (float)   1, (float)   2), new float3((float)   4, (float)   3, (float)   2) };
            int3[] r = new int3[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<float3[],float3[],int3[]>)test_float3_ge,
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

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_float3_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<float3>;
                var mb = null as Mem<float3>;
                var mr = null as Mem<int3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_float3_ge");
                    ma = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<float3>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<int3>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<int3>());
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
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
        }

        [Kernel]
        private static void test_components1([Global] float[] r, [Global] float3[] w)
        {
            float3 ar = new float3((float)1, (float)2, (float)3);
            float aw = (float)1;
            r[0] = ar.x;
            w[0].x = aw;
            r[1] = ar.y;
            w[1].y = aw;
            r[2] = ar.z;
            w[2].z = aw;
        }

        [Test]
        public void TestComponentAccessors1()
        {
            int nr = 3;
            int nw = 3;
            float[] r = new float[nr];
            float3[] w = new float3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<float[],float3[]>)test_components1,
                r, w
            );
            Assert.AreEqual((float)1, r[0]);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)0, w[0].s1);
            Assert.AreEqual((float)0, w[0].s2);
            Assert.AreEqual((float)2, r[1]);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)0, w[1].s0);
            Assert.AreEqual((float)0, w[1].s2);
            Assert.AreEqual((float)3, r[2]);
            Assert.AreEqual((float)1, w[2].s2);
            Assert.AreEqual((float)0, w[2].s0);
            Assert.AreEqual((float)0, w[2].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_components1");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<float>;
                var mw = null as Mem<float3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components1");
                    mr = Mem<float>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<float>());
                    mw = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<float3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, nr);
                    queue.EnqueueReadBuffer(mr, false, r);
                    Array.Clear(w, 0, nw);
                    queue.EnqueueReadBuffer(mw, false, w);
                    queue.Finish();
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mw != null) mw.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual((float)1, r[0]);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)0, w[0].s1);
            Assert.AreEqual((float)0, w[0].s2);
            Assert.AreEqual((float)2, r[1]);
            Assert.AreEqual((float)1, w[1].s1);
            Assert.AreEqual((float)0, w[1].s0);
            Assert.AreEqual((float)0, w[1].s2);
            Assert.AreEqual((float)3, r[2]);
            Assert.AreEqual((float)1, w[2].s2);
            Assert.AreEqual((float)0, w[2].s0);
            Assert.AreEqual((float)0, w[2].s1);
        }
        [Kernel]
        private static void test_components2([Global] float2[] r, [Global] float3[] w)
        {
            float3 ar = new float3((float)1, (float)2, (float)3);
            float2 aw = new float2((float)1, (float)2);
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
        public void TestComponentAccessors2()
        {
            int nr = 9;
            int nw = 6;
            float2[] r = new float2[nr];
            float3[] w = new float3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<float2[],float3[]>)test_components2,
                r, w
            );
            Assert.AreEqual((float)1, r[0].s0);
            Assert.AreEqual((float)1, r[0].s1);
            Assert.AreEqual((float)1, r[1].s0);
            Assert.AreEqual((float)2, r[1].s1);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)2, w[0].s1);
            Assert.AreEqual((float)0, w[0].s2);
            Assert.AreEqual((float)1, r[2].s0);
            Assert.AreEqual((float)3, r[2].s1);
            Assert.AreEqual((float)1, w[1].s0);
            Assert.AreEqual((float)2, w[1].s2);
            Assert.AreEqual((float)0, w[1].s1);
            Assert.AreEqual((float)2, r[3].s0);
            Assert.AreEqual((float)1, r[3].s1);
            Assert.AreEqual((float)1, w[2].s1);
            Assert.AreEqual((float)2, w[2].s0);
            Assert.AreEqual((float)0, w[2].s2);
            Assert.AreEqual((float)2, r[4].s0);
            Assert.AreEqual((float)2, r[4].s1);
            Assert.AreEqual((float)2, r[5].s0);
            Assert.AreEqual((float)3, r[5].s1);
            Assert.AreEqual((float)1, w[3].s1);
            Assert.AreEqual((float)2, w[3].s2);
            Assert.AreEqual((float)0, w[3].s0);
            Assert.AreEqual((float)3, r[6].s0);
            Assert.AreEqual((float)1, r[6].s1);
            Assert.AreEqual((float)1, w[4].s2);
            Assert.AreEqual((float)2, w[4].s0);
            Assert.AreEqual((float)0, w[4].s1);
            Assert.AreEqual((float)3, r[7].s0);
            Assert.AreEqual((float)2, r[7].s1);
            Assert.AreEqual((float)1, w[5].s2);
            Assert.AreEqual((float)2, w[5].s1);
            Assert.AreEqual((float)0, w[5].s0);
            Assert.AreEqual((float)3, r[8].s0);
            Assert.AreEqual((float)3, r[8].s1);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_components2");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<float2>;
                var mw = null as Mem<float3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components2");
                    mr = Mem<float2>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<float2>());
                    mw = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<float3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, nr);
                    queue.EnqueueReadBuffer(mr, false, r);
                    Array.Clear(w, 0, nw);
                    queue.EnqueueReadBuffer(mw, false, w);
                    queue.Finish();
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mw != null) mw.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual((float)1, r[0].s0);
            Assert.AreEqual((float)1, r[0].s1);
            Assert.AreEqual((float)1, r[1].s0);
            Assert.AreEqual((float)2, r[1].s1);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)2, w[0].s1);
            Assert.AreEqual((float)0, w[0].s2);
            Assert.AreEqual((float)1, r[2].s0);
            Assert.AreEqual((float)3, r[2].s1);
            Assert.AreEqual((float)1, w[1].s0);
            Assert.AreEqual((float)2, w[1].s2);
            Assert.AreEqual((float)0, w[1].s1);
            Assert.AreEqual((float)2, r[3].s0);
            Assert.AreEqual((float)1, r[3].s1);
            Assert.AreEqual((float)1, w[2].s1);
            Assert.AreEqual((float)2, w[2].s0);
            Assert.AreEqual((float)0, w[2].s2);
            Assert.AreEqual((float)2, r[4].s0);
            Assert.AreEqual((float)2, r[4].s1);
            Assert.AreEqual((float)2, r[5].s0);
            Assert.AreEqual((float)3, r[5].s1);
            Assert.AreEqual((float)1, w[3].s1);
            Assert.AreEqual((float)2, w[3].s2);
            Assert.AreEqual((float)0, w[3].s0);
            Assert.AreEqual((float)3, r[6].s0);
            Assert.AreEqual((float)1, r[6].s1);
            Assert.AreEqual((float)1, w[4].s2);
            Assert.AreEqual((float)2, w[4].s0);
            Assert.AreEqual((float)0, w[4].s1);
            Assert.AreEqual((float)3, r[7].s0);
            Assert.AreEqual((float)2, r[7].s1);
            Assert.AreEqual((float)1, w[5].s2);
            Assert.AreEqual((float)2, w[5].s1);
            Assert.AreEqual((float)0, w[5].s0);
            Assert.AreEqual((float)3, r[8].s0);
            Assert.AreEqual((float)3, r[8].s1);
        }
        [Kernel]
        private static void test_components3([Global] float3[] r, [Global] float3[] w)
        {
            float3 ar = new float3((float)1, (float)2, (float)3);
            float3 aw = new float3((float)1, (float)2, (float)3);
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
        public void TestComponentAccessors3()
        {
            int nr = 27;
            int nw = 6;
            float3[] r = new float3[nr];
            float3[] w = new float3[nw];

            // test managed
            Array.Clear(r, 0, nr);
            Array.Clear(w, 0, nw);
            Cl.RunKernel(
                new int[] { 1 },
                new int[] { 1 },
                (Action<float3[],float3[]>)test_components3,
                r, w
            );
            Assert.AreEqual((float)1, r[0].s0);
            Assert.AreEqual((float)1, r[0].s1);
            Assert.AreEqual((float)1, r[0].s2);
            Assert.AreEqual((float)1, r[1].s0);
            Assert.AreEqual((float)1, r[1].s1);
            Assert.AreEqual((float)2, r[1].s2);
            Assert.AreEqual((float)1, r[2].s0);
            Assert.AreEqual((float)1, r[2].s1);
            Assert.AreEqual((float)3, r[2].s2);
            Assert.AreEqual((float)1, r[3].s0);
            Assert.AreEqual((float)2, r[3].s1);
            Assert.AreEqual((float)1, r[3].s2);
            Assert.AreEqual((float)1, r[4].s0);
            Assert.AreEqual((float)2, r[4].s1);
            Assert.AreEqual((float)2, r[4].s2);
            Assert.AreEqual((float)1, r[5].s0);
            Assert.AreEqual((float)2, r[5].s1);
            Assert.AreEqual((float)3, r[5].s2);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)2, w[0].s1);
            Assert.AreEqual((float)3, w[0].s2);
            Assert.AreEqual((float)1, r[6].s0);
            Assert.AreEqual((float)3, r[6].s1);
            Assert.AreEqual((float)1, r[6].s2);
            Assert.AreEqual((float)1, r[7].s0);
            Assert.AreEqual((float)3, r[7].s1);
            Assert.AreEqual((float)2, r[7].s2);
            Assert.AreEqual((float)1, w[1].s0);
            Assert.AreEqual((float)2, w[1].s2);
            Assert.AreEqual((float)3, w[1].s1);
            Assert.AreEqual((float)1, r[8].s0);
            Assert.AreEqual((float)3, r[8].s1);
            Assert.AreEqual((float)3, r[8].s2);
            Assert.AreEqual((float)2, r[9].s0);
            Assert.AreEqual((float)1, r[9].s1);
            Assert.AreEqual((float)1, r[9].s2);
            Assert.AreEqual((float)2, r[10].s0);
            Assert.AreEqual((float)1, r[10].s1);
            Assert.AreEqual((float)2, r[10].s2);
            Assert.AreEqual((float)2, r[11].s0);
            Assert.AreEqual((float)1, r[11].s1);
            Assert.AreEqual((float)3, r[11].s2);
            Assert.AreEqual((float)1, w[2].s1);
            Assert.AreEqual((float)2, w[2].s0);
            Assert.AreEqual((float)3, w[2].s2);
            Assert.AreEqual((float)2, r[12].s0);
            Assert.AreEqual((float)2, r[12].s1);
            Assert.AreEqual((float)1, r[12].s2);
            Assert.AreEqual((float)2, r[13].s0);
            Assert.AreEqual((float)2, r[13].s1);
            Assert.AreEqual((float)2, r[13].s2);
            Assert.AreEqual((float)2, r[14].s0);
            Assert.AreEqual((float)2, r[14].s1);
            Assert.AreEqual((float)3, r[14].s2);
            Assert.AreEqual((float)2, r[15].s0);
            Assert.AreEqual((float)3, r[15].s1);
            Assert.AreEqual((float)1, r[15].s2);
            Assert.AreEqual((float)1, w[3].s1);
            Assert.AreEqual((float)2, w[3].s2);
            Assert.AreEqual((float)3, w[3].s0);
            Assert.AreEqual((float)2, r[16].s0);
            Assert.AreEqual((float)3, r[16].s1);
            Assert.AreEqual((float)2, r[16].s2);
            Assert.AreEqual((float)2, r[17].s0);
            Assert.AreEqual((float)3, r[17].s1);
            Assert.AreEqual((float)3, r[17].s2);
            Assert.AreEqual((float)3, r[18].s0);
            Assert.AreEqual((float)1, r[18].s1);
            Assert.AreEqual((float)1, r[18].s2);
            Assert.AreEqual((float)3, r[19].s0);
            Assert.AreEqual((float)1, r[19].s1);
            Assert.AreEqual((float)2, r[19].s2);
            Assert.AreEqual((float)1, w[4].s2);
            Assert.AreEqual((float)2, w[4].s0);
            Assert.AreEqual((float)3, w[4].s1);
            Assert.AreEqual((float)3, r[20].s0);
            Assert.AreEqual((float)1, r[20].s1);
            Assert.AreEqual((float)3, r[20].s2);
            Assert.AreEqual((float)3, r[21].s0);
            Assert.AreEqual((float)2, r[21].s1);
            Assert.AreEqual((float)1, r[21].s2);
            Assert.AreEqual((float)1, w[5].s2);
            Assert.AreEqual((float)2, w[5].s1);
            Assert.AreEqual((float)3, w[5].s0);
            Assert.AreEqual((float)3, r[22].s0);
            Assert.AreEqual((float)2, r[22].s1);
            Assert.AreEqual((float)2, r[22].s2);
            Assert.AreEqual((float)3, r[23].s0);
            Assert.AreEqual((float)2, r[23].s1);
            Assert.AreEqual((float)3, r[23].s2);
            Assert.AreEqual((float)3, r[24].s0);
            Assert.AreEqual((float)3, r[24].s1);
            Assert.AreEqual((float)1, r[24].s2);
            Assert.AreEqual((float)3, r[25].s0);
            Assert.AreEqual((float)3, r[25].s1);
            Assert.AreEqual((float)2, r[25].s2);
            Assert.AreEqual((float)3, r[26].s0);
            Assert.AreEqual((float)3, r[26].s1);
            Assert.AreEqual((float)3, r[26].s2);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.TestFloat3", "test_components3");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var mr = null as Mem<float3>;
                var mw = null as Mem<float3>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_components3");
                    mr = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<float3>());
                    mw = Mem<float3>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<float3>());
                    kernel.SetKernelArg(0, (HandleObject)mr);
                    kernel.SetKernelArg(1, (HandleObject)mw);
                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);
                    queue.Finish();
                    Array.Clear(r, 0, nr);
                    queue.EnqueueReadBuffer(mr, false, r);
                    Array.Clear(w, 0, nw);
                    queue.EnqueueReadBuffer(mw, false, w);
                    queue.Finish();
                }
                finally {
                    if (mr != null) mr.Dispose();
                    if (mw != null) mw.Dispose();
                    if (kernel != null) kernel.Dispose();
                    if (program != null) program.Dispose();
                }
            }
            Assert.AreEqual((float)1, r[0].s0);
            Assert.AreEqual((float)1, r[0].s1);
            Assert.AreEqual((float)1, r[0].s2);
            Assert.AreEqual((float)1, r[1].s0);
            Assert.AreEqual((float)1, r[1].s1);
            Assert.AreEqual((float)2, r[1].s2);
            Assert.AreEqual((float)1, r[2].s0);
            Assert.AreEqual((float)1, r[2].s1);
            Assert.AreEqual((float)3, r[2].s2);
            Assert.AreEqual((float)1, r[3].s0);
            Assert.AreEqual((float)2, r[3].s1);
            Assert.AreEqual((float)1, r[3].s2);
            Assert.AreEqual((float)1, r[4].s0);
            Assert.AreEqual((float)2, r[4].s1);
            Assert.AreEqual((float)2, r[4].s2);
            Assert.AreEqual((float)1, r[5].s0);
            Assert.AreEqual((float)2, r[5].s1);
            Assert.AreEqual((float)3, r[5].s2);
            Assert.AreEqual((float)1, w[0].s0);
            Assert.AreEqual((float)2, w[0].s1);
            Assert.AreEqual((float)3, w[0].s2);
            Assert.AreEqual((float)1, r[6].s0);
            Assert.AreEqual((float)3, r[6].s1);
            Assert.AreEqual((float)1, r[6].s2);
            Assert.AreEqual((float)1, r[7].s0);
            Assert.AreEqual((float)3, r[7].s1);
            Assert.AreEqual((float)2, r[7].s2);
            Assert.AreEqual((float)1, w[1].s0);
            Assert.AreEqual((float)2, w[1].s2);
            Assert.AreEqual((float)3, w[1].s1);
            Assert.AreEqual((float)1, r[8].s0);
            Assert.AreEqual((float)3, r[8].s1);
            Assert.AreEqual((float)3, r[8].s2);
            Assert.AreEqual((float)2, r[9].s0);
            Assert.AreEqual((float)1, r[9].s1);
            Assert.AreEqual((float)1, r[9].s2);
            Assert.AreEqual((float)2, r[10].s0);
            Assert.AreEqual((float)1, r[10].s1);
            Assert.AreEqual((float)2, r[10].s2);
            Assert.AreEqual((float)2, r[11].s0);
            Assert.AreEqual((float)1, r[11].s1);
            Assert.AreEqual((float)3, r[11].s2);
            Assert.AreEqual((float)1, w[2].s1);
            Assert.AreEqual((float)2, w[2].s0);
            Assert.AreEqual((float)3, w[2].s2);
            Assert.AreEqual((float)2, r[12].s0);
            Assert.AreEqual((float)2, r[12].s1);
            Assert.AreEqual((float)1, r[12].s2);
            Assert.AreEqual((float)2, r[13].s0);
            Assert.AreEqual((float)2, r[13].s1);
            Assert.AreEqual((float)2, r[13].s2);
            Assert.AreEqual((float)2, r[14].s0);
            Assert.AreEqual((float)2, r[14].s1);
            Assert.AreEqual((float)3, r[14].s2);
            Assert.AreEqual((float)2, r[15].s0);
            Assert.AreEqual((float)3, r[15].s1);
            Assert.AreEqual((float)1, r[15].s2);
            Assert.AreEqual((float)1, w[3].s1);
            Assert.AreEqual((float)2, w[3].s2);
            Assert.AreEqual((float)3, w[3].s0);
            Assert.AreEqual((float)2, r[16].s0);
            Assert.AreEqual((float)3, r[16].s1);
            Assert.AreEqual((float)2, r[16].s2);
            Assert.AreEqual((float)2, r[17].s0);
            Assert.AreEqual((float)3, r[17].s1);
            Assert.AreEqual((float)3, r[17].s2);
            Assert.AreEqual((float)3, r[18].s0);
            Assert.AreEqual((float)1, r[18].s1);
            Assert.AreEqual((float)1, r[18].s2);
            Assert.AreEqual((float)3, r[19].s0);
            Assert.AreEqual((float)1, r[19].s1);
            Assert.AreEqual((float)2, r[19].s2);
            Assert.AreEqual((float)1, w[4].s2);
            Assert.AreEqual((float)2, w[4].s0);
            Assert.AreEqual((float)3, w[4].s1);
            Assert.AreEqual((float)3, r[20].s0);
            Assert.AreEqual((float)1, r[20].s1);
            Assert.AreEqual((float)3, r[20].s2);
            Assert.AreEqual((float)3, r[21].s0);
            Assert.AreEqual((float)2, r[21].s1);
            Assert.AreEqual((float)1, r[21].s2);
            Assert.AreEqual((float)1, w[5].s2);
            Assert.AreEqual((float)2, w[5].s1);
            Assert.AreEqual((float)3, w[5].s0);
            Assert.AreEqual((float)3, r[22].s0);
            Assert.AreEqual((float)2, r[22].s1);
            Assert.AreEqual((float)2, r[22].s2);
            Assert.AreEqual((float)3, r[23].s0);
            Assert.AreEqual((float)2, r[23].s1);
            Assert.AreEqual((float)3, r[23].s2);
            Assert.AreEqual((float)3, r[24].s0);
            Assert.AreEqual((float)3, r[24].s1);
            Assert.AreEqual((float)1, r[24].s2);
            Assert.AreEqual((float)3, r[25].s0);
            Assert.AreEqual((float)3, r[25].s1);
            Assert.AreEqual((float)2, r[25].s2);
            Assert.AreEqual((float)3, r[26].s0);
            Assert.AreEqual((float)3, r[26].s1);
            Assert.AreEqual((float)3, r[26].s2);
        }
    }
}
