using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenCl.Compiler;

namespace OpenCl.Tests
{
    [TestFixture]
    public class TestUshort8
    {
        [Kernel]
        private static void test_ushort8_add([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] + b[i];
        }

        [Test]
        public void TestAddManaged()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_add,
                a,
                b,
                r
            );
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual(  60, r[0].s4);
            Assert.AreEqual(  72, r[0].s5);
            Assert.AreEqual(  84, r[0].s6);
            Assert.AreEqual(  96, r[0].s7);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);
        }

        [Test]
        public void TestAddCl()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_add");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_add");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual(  60, r[0].s4);
            Assert.AreEqual(  72, r[0].s5);
            Assert.AreEqual(  84, r[0].s6);
            Assert.AreEqual(  96, r[0].s7);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);
        }

        [Test]
        public void TestAddSpir()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_add", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_ushort8_add");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(  12, r[0].s0);
            Assert.AreEqual(  24, r[0].s1);
            Assert.AreEqual(  36, r[0].s2);
            Assert.AreEqual(  48, r[0].s3);
            Assert.AreEqual(  60, r[0].s4);
            Assert.AreEqual(  72, r[0].s5);
            Assert.AreEqual(  84, r[0].s6);
            Assert.AreEqual(  96, r[0].s7);
            Assert.AreEqual(  12, r[1].s0);
            Assert.AreEqual(  24, r[1].s1);
            Assert.AreEqual(  36, r[1].s2);
            Assert.AreEqual(  48, r[1].s3);
            Assert.AreEqual(  60, r[1].s4);
            Assert.AreEqual(  72, r[1].s5);
            Assert.AreEqual(  84, r[1].s6);
            Assert.AreEqual(  96, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_sub([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] - b[i];
        }

        [Test]
        public void TestSubManaged()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_sub,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  10, r[0].s4);
            Assert.AreEqual(  12, r[0].s5);
            Assert.AreEqual(  14, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(65534, r[1].s0);
            Assert.AreEqual(65532, r[1].s1);
            Assert.AreEqual(65530, r[1].s2);
            Assert.AreEqual(65528, r[1].s3);
            Assert.AreEqual(65526, r[1].s4);
            Assert.AreEqual(65524, r[1].s5);
            Assert.AreEqual(65522, r[1].s6);
            Assert.AreEqual(65520, r[1].s7);
        }

        [Test]
        public void TestSubCl()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_sub");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_sub");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  10, r[0].s4);
            Assert.AreEqual(  12, r[0].s5);
            Assert.AreEqual(  14, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(65534, r[1].s0);
            Assert.AreEqual(65532, r[1].s1);
            Assert.AreEqual(65530, r[1].s2);
            Assert.AreEqual(65528, r[1].s3);
            Assert.AreEqual(65526, r[1].s4);
            Assert.AreEqual(65524, r[1].s5);
            Assert.AreEqual(65522, r[1].s6);
            Assert.AreEqual(65520, r[1].s7);
        }

        [Test]
        public void TestSubSpir()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_sub", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_ushort8_sub");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(   6, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  10, r[0].s4);
            Assert.AreEqual(  12, r[0].s5);
            Assert.AreEqual(  14, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(65534, r[1].s0);
            Assert.AreEqual(65532, r[1].s1);
            Assert.AreEqual(65530, r[1].s2);
            Assert.AreEqual(65528, r[1].s3);
            Assert.AreEqual(65526, r[1].s4);
            Assert.AreEqual(65524, r[1].s5);
            Assert.AreEqual(65522, r[1].s6);
            Assert.AreEqual(65520, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_mul([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] * b[i];
        }

        [Test]
        public void TestMulManaged()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_mul,
                a,
                b,
                r
            );
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual( 875, r[0].s4);
            Assert.AreEqual(1260, r[0].s5);
            Assert.AreEqual(1715, r[0].s6);
            Assert.AreEqual(2240, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
        }

        [Test]
        public void TestMulCl()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_mul");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_mul");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual( 875, r[0].s4);
            Assert.AreEqual(1260, r[0].s5);
            Assert.AreEqual(1715, r[0].s6);
            Assert.AreEqual(2240, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
        }

        [Test]
        public void TestMulSpir()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_mul", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_ushort8_mul");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(  35, r[0].s0);
            Assert.AreEqual( 140, r[0].s1);
            Assert.AreEqual( 315, r[0].s2);
            Assert.AreEqual( 560, r[0].s3);
            Assert.AreEqual( 875, r[0].s4);
            Assert.AreEqual(1260, r[0].s5);
            Assert.AreEqual(1715, r[0].s6);
            Assert.AreEqual(2240, r[0].s7);
            Assert.AreEqual(  35, r[1].s0);
            Assert.AreEqual( 140, r[1].s1);
            Assert.AreEqual( 315, r[1].s2);
            Assert.AreEqual( 560, r[1].s3);
            Assert.AreEqual( 875, r[1].s4);
            Assert.AreEqual(1260, r[1].s5);
            Assert.AreEqual(1715, r[1].s6);
            Assert.AreEqual(2240, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_div([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] / b[i];
        }

        [Test]
        public void TestDivManaged()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_div,
                a,
                b,
                r
            );
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   1, r[0].s3);
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(   1, r[0].s5);
            Assert.AreEqual(   1, r[0].s6);
            Assert.AreEqual(   1, r[0].s7);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);
        }

        [Test]
        public void TestDivCl()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_div");

            // test Cl kernel
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_div");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   1, r[0].s3);
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(   1, r[0].s5);
            Assert.AreEqual(   1, r[0].s6);
            Assert.AreEqual(   1, r[0].s7);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);
        }

        [Test]
        public void TestDivSpir()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_div", module);

            // test SPIR-V kernel
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithIL(context, module.ToArray());
                    program.BuildProgram(device);
                    kernel = Kernel.CreateKernel(program, "test_ushort8_div");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(   1, r[0].s0);
            Assert.AreEqual(   1, r[0].s1);
            Assert.AreEqual(   1, r[0].s2);
            Assert.AreEqual(   1, r[0].s3);
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(   1, r[0].s5);
            Assert.AreEqual(   1, r[0].s6);
            Assert.AreEqual(   1, r[0].s7);
            Assert.AreEqual(   0, r[1].s0);
            Assert.AreEqual(   0, r[1].s1);
            Assert.AreEqual(   0, r[1].s2);
            Assert.AreEqual(   0, r[1].s3);
            Assert.AreEqual(   0, r[1].s4);
            Assert.AreEqual(   0, r[1].s5);
            Assert.AreEqual(   0, r[1].s6);
            Assert.AreEqual(   0, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_eq([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] == b[i];
        }

        [Test]
        public void TestEq()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            short8[] r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_eq,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_eq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<short8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_eq");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short8>());
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
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_neq([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] != b[i];
        }

        [Test]
        public void TestNeq()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            short8[] r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_neq,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_neq");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<short8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_neq");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short8>());
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
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_lt([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] < b[i];
        }

        [Test]
        public void TestLt()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            short8[] r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_lt,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_lt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<short8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_lt");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short8>());
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
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_le([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] <= b[i];
        }

        [Test]
        public void TestLe()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            short8[] r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_le,
                a,
                b,
                r
            );
            Assert.AreEqual( 0, r[0].s0);
            Assert.AreEqual( 0, r[0].s1);
            Assert.AreEqual( 0, r[0].s2);
            Assert.AreEqual( 0, r[0].s3);
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_le");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<short8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_le");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short8>());
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
            Assert.AreEqual( 0, r[0].s4);
            Assert.AreEqual( 0, r[0].s5);
            Assert.AreEqual( 0, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual(-1, r[1].s0);
            Assert.AreEqual(-1, r[1].s1);
            Assert.AreEqual(-1, r[1].s2);
            Assert.AreEqual(-1, r[1].s3);
            Assert.AreEqual(-1, r[1].s4);
            Assert.AreEqual(-1, r[1].s5);
            Assert.AreEqual(-1, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_gt([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] > b[i];
        }

        [Test]
        public void TestGt()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            short8[] r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_gt,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_gt");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<short8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_gt");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short8>());
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
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual( 0, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual( 0, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_ge([Global] ushort8[] a, [Global] ushort8[] b, [Global] short8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] >= b[i];
        }

        [Test]
        public void TestGe()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7), new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   0, (ushort)   1, (ushort)   2, (ushort)   3, (ushort)   4, (ushort)   5, (ushort)   6, (ushort)   7), new ushort8((ushort)  14, (ushort)  13, (ushort)  12, (ushort)  11, (ushort)  10, (ushort)   9, (ushort)   8, (ushort)   7) };
            short8[] r = new short8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],short8[]>)test_ushort8_ge,
                a,
                b,
                r
            );
            Assert.AreEqual(-1, r[0].s0);
            Assert.AreEqual(-1, r[0].s1);
            Assert.AreEqual(-1, r[0].s2);
            Assert.AreEqual(-1, r[0].s3);
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_ge");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<short8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_ge");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<short8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<short8>());
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
            Assert.AreEqual(-1, r[0].s4);
            Assert.AreEqual(-1, r[0].s5);
            Assert.AreEqual(-1, r[0].s6);
            Assert.AreEqual(-1, r[0].s7);
            Assert.AreEqual( 0, r[1].s0);
            Assert.AreEqual( 0, r[1].s1);
            Assert.AreEqual( 0, r[1].s2);
            Assert.AreEqual( 0, r[1].s3);
            Assert.AreEqual( 0, r[1].s4);
            Assert.AreEqual( 0, r[1].s5);
            Assert.AreEqual( 0, r[1].s6);
            Assert.AreEqual(-1, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_and([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] & b[i];
        }

        [Test]
        public void TestAnd()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_and,
                a,
                b,
                r
            );
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[0].s2);
            Assert.AreEqual(  20, r[0].s3);
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(  10, r[0].s5);
            Assert.AreEqual(  33, r[0].s6);
            Assert.AreEqual(  40, r[0].s7);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);
            Assert.AreEqual(   1, r[1].s4);
            Assert.AreEqual(  10, r[1].s5);
            Assert.AreEqual(  33, r[1].s6);
            Assert.AreEqual(  40, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_and");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_and");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(   5, r[0].s0);
            Assert.AreEqual(  10, r[0].s1);
            Assert.AreEqual(   5, r[0].s2);
            Assert.AreEqual(  20, r[0].s3);
            Assert.AreEqual(   1, r[0].s4);
            Assert.AreEqual(  10, r[0].s5);
            Assert.AreEqual(  33, r[0].s6);
            Assert.AreEqual(  40, r[0].s7);
            Assert.AreEqual(   5, r[1].s0);
            Assert.AreEqual(  10, r[1].s1);
            Assert.AreEqual(   5, r[1].s2);
            Assert.AreEqual(  20, r[1].s3);
            Assert.AreEqual(   1, r[1].s4);
            Assert.AreEqual(  10, r[1].s5);
            Assert.AreEqual(  33, r[1].s6);
            Assert.AreEqual(  40, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_or([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] | b[i];
        }

        [Test]
        public void TestOr()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_or,
                a,
                b,
                r
            );
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(  31, r[0].s2);
            Assert.AreEqual(  28, r[0].s3);
            Assert.AreEqual(  59, r[0].s4);
            Assert.AreEqual(  62, r[0].s5);
            Assert.AreEqual(  51, r[0].s6);
            Assert.AreEqual(  56, r[0].s7);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);
            Assert.AreEqual(  59, r[1].s4);
            Assert.AreEqual(  62, r[1].s5);
            Assert.AreEqual(  51, r[1].s6);
            Assert.AreEqual(  56, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_or");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_or");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(   7, r[0].s0);
            Assert.AreEqual(  14, r[0].s1);
            Assert.AreEqual(  31, r[0].s2);
            Assert.AreEqual(  28, r[0].s3);
            Assert.AreEqual(  59, r[0].s4);
            Assert.AreEqual(  62, r[0].s5);
            Assert.AreEqual(  51, r[0].s6);
            Assert.AreEqual(  56, r[0].s7);
            Assert.AreEqual(   7, r[1].s0);
            Assert.AreEqual(  14, r[1].s1);
            Assert.AreEqual(  31, r[1].s2);
            Assert.AreEqual(  28, r[1].s3);
            Assert.AreEqual(  59, r[1].s4);
            Assert.AreEqual(  62, r[1].s5);
            Assert.AreEqual(  51, r[1].s6);
            Assert.AreEqual(  56, r[1].s7);
        }

        [Kernel]
        private static void test_ushort8_xor([Global] ushort8[] a, [Global] ushort8[] b, [Global] ushort8[] r)
        {
            int i = Cl.GetGlobalId(0);
            r[i] = a[i] ^ b[i];
        }

        [Test]
        public void TestXor()
        {
            ushort8[] a = new ushort8[] { new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56), new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40) };
            ushort8[] b = new ushort8[] { new ushort8((ushort)   5, (ushort)  10, (ushort)  15, (ushort)  20, (ushort)  25, (ushort)  30, (ushort)  35, (ushort)  40), new ushort8((ushort)   7, (ushort)  14, (ushort)  21, (ushort)  28, (ushort)  35, (ushort)  42, (ushort)  49, (ushort)  56) };
            ushort8[] r = new ushort8[2];

            // test managed
            Array.Clear(r, 0, 2);
            Cl.RunKernel(
                new int[] { 2 },
                new int[] { 1 },
                (Action<ushort8[],ushort8[],ushort8[]>)test_ushort8_xor,
                a,
                b,
                r
            );
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  26, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  58, r[0].s4);
            Assert.AreEqual(  52, r[0].s5);
            Assert.AreEqual(  18, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);
            Assert.AreEqual(  58, r[1].s4);
            Assert.AreEqual(  52, r[1].s5);
            Assert.AreEqual(  18, r[1].s6);
            Assert.AreEqual(  16, r[1].s7);

            // compile kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestUshort8", "test_ushort8_xor");

            // test native
            Platform platform = Platform.GetPlatformIDs()[0];
            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
            using (var context = Context.CreateContext(platform, devices, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))
            {
                var program = null as Program;
                var kernel = null as Kernel;
                var ma = null as Mem<ushort8>;
                var mb = null as Mem<ushort8>;
                var mr = null as Mem<ushort8>;
                try {
                    program = Program.CreateProgramWithSource(context, new String[] { source });
                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }
                    kernel = Kernel.CreateKernel(program, "test_ushort8_xor");
                    ma = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);
                    mb = Mem<ushort8>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);
                    mr = Mem<ushort8>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<ushort8>());
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
            Assert.AreEqual(   2, r[0].s0);
            Assert.AreEqual(   4, r[0].s1);
            Assert.AreEqual(  26, r[0].s2);
            Assert.AreEqual(   8, r[0].s3);
            Assert.AreEqual(  58, r[0].s4);
            Assert.AreEqual(  52, r[0].s5);
            Assert.AreEqual(  18, r[0].s6);
            Assert.AreEqual(  16, r[0].s7);
            Assert.AreEqual(   2, r[1].s0);
            Assert.AreEqual(   4, r[1].s1);
            Assert.AreEqual(  26, r[1].s2);
            Assert.AreEqual(   8, r[1].s3);
            Assert.AreEqual(  58, r[1].s4);
            Assert.AreEqual(  52, r[1].s5);
            Assert.AreEqual(  18, r[1].s6);
            Assert.AreEqual(  16, r[1].s7);
        }

    }
}
