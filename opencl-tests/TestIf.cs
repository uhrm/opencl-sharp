
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
    public class TestIf
    {
        [Kernel]
        private static void test_if([Global] int[] a, [Global] int[] b, [Global] int[] r)
        {
            int i = Cl.GetGlobalId(0);
            if (a[i] > b[i]) {
                r[i] = a[i] - b[i];
            }
            else {
                r[i] = b[i] - a[i];
            }
        }

        [Test]
        [Category("Managed")]
        public void TestIfManaged()
        {
            var a = new int[] { 7, 14, 6, 10 };
            var b = new int[] { 5, 10, 6, 14 };
            var r = new int[4];

            // test managed
            Array.Clear(r, 0, 4);
            Cl.RunKernel(
                new int[] { 4 },
                new int[] { 1 },
                (Action<int[],int[],int[]>)test_if,
                a,
                b,
                r
            );
            Assert.AreEqual(2, r[0]);
            Assert.AreEqual(4, r[1]);
            Assert.AreEqual(0, r[2]);
            Assert.AreEqual(4, r[3]);
        }

        [Test]
        [Category("Compiled.Cl")]
        [Ignore("Handling Booleans not implemented in CL compiler.")]
        public void TestIfCl()
        {
            var a = new int[] { 7, 14, 6, 10 };
            var b = new int[] { 5, 10, 6, 14 };
            var r = new int[4];

            // compile Cl kernel
            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestIf", "test_if");

            // test Cl kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(platform, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithSource(context, device, source))
            using (var kernel = Kernel.CreateKernel(program, "test_if"))
            using (var ma = Mem<int>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int>.CreateBuffer(context, MemFlags.ReadWrite, 4*Marshal.SizeOf<int>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 4 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2, r[0]);
            Assert.AreEqual(4, r[1]);
            Assert.AreEqual(0, r[2]);
            Assert.AreEqual(4, r[3]);
        }

        [Test]
        [Category("Compiled.SpirV")]
        public void TestIfSpirV()
        {
            var a = new int[] { 7, 14, 6, 10 };
            var b = new int[] { 5, 10, 6, 14 };
            var r = new int[4];

            // compile SPIR-V kernel
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.TestIf", "test_if", module);
            // ***DEBUG***
            using (var stream = new FileStream("test_if.spv", FileMode.Create))
            {
                var buf = module.ToArray();
                stream.Write(buf, 0, buf.Length);
            }
            // ***ENDEBUG***

            // test SPIR-V kernel
            var platform = Platform.GetPlatformIDs().First();
            var device = Device.GetDeviceIDs(platform, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, device, module.ToArray()))
            using (var kernel = Kernel.CreateKernel(program, "test_if"))
            using (var ma = Mem<int>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a))
            using (var mb = Mem<int>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b))
            using (var mr = Mem<int>.CreateBuffer(context, MemFlags.ReadWrite, 4*Marshal.SizeOf<int>()))
            {
                kernel.SetKernelArg(0, (HandleObject)ma);
                kernel.SetKernelArg(1, (HandleObject)mb);
                kernel.SetKernelArg(2, (HandleObject)mr);
                queue.EnqueueNDRangeKernel(kernel, null, new int[] { 4 }, null, null);
                queue.Finish();
                queue.EnqueueReadBuffer(mr, true, r);
            }
            Assert.AreEqual(2, r[0]);
            Assert.AreEqual(4, r[1]);
            Assert.AreEqual(0, r[2]);
            Assert.AreEqual(4, r[3]);
        }
    }
}
