import ctypes
import itertools

vtypes = ['sbyte', 'byte', 'short', 'ushort', 'int', 'uint', 'long', 'ulong', 'float', 'double']
vranks = [2, 3, 4, 8, 16]

velems = {2: 'xy', 3: 'xyz', 4: 'xyzw', 8: None, 16: None}

esizes = {'sbyte': 1, 'byte': 1, 'short': 2, 'ushort': 2, 'int': 4, 'uint': 4, 'long': 8, 'ulong': 8, 'float': 4, 'double': 8}
esigned = {'sbyte': True, 'byte': False, 'short': True, 'ushort': False, 'int': True, 'uint': False, 'long': True, 'ulong': False, 'float': True, 'double': True}
ecmptype = {'sbyte': 'sbyte', 'byte': 'sbyte', 'short': 'short', 'ushort': 'short', 'int': 'int', 'uint': 'int', 'long': 'long', 'ulong': 'long', 'float': 'int', 'double': 'long'}
ezero = {'sbyte': '(sbyte)0', 'byte': '(byte)0', 'short': '(short)0', 'ushort': '(ushort)0', 'int': '0', 'uint': '0U', 'long': '0L', 'ulong': '0UL', 'float': '0f', 'double': '0d'}
eone = {'sbyte': '(sbyte)1', 'byte': '(byte)1', 'short': '(short)1', 'ushort': '(ushort)1', 'int': '1', 'uint': '1U', 'long': '1L', 'ulong': '1UL', 'float': '1f', 'double': '1d'}
emone = {'sbyte': '(sbyte)-1', 'short': '(short)-1', 'int': '-1', 'long': '-1L'}

eptype = {'sbyte': int, 'byte': int, 'short': int, 'ushort': int, 'int': int, 'uint': int, 'long': int, 'ulong': int, 'float': float, 'double': float}
ectype = {'sbyte': ctypes.c_int8, 'byte': ctypes.c_uint8, 'short': ctypes.c_int16, 'ushort': ctypes.c_uint16, 'int': ctypes.c_int32, 'uint': ctypes.c_uint32, 'long': ctypes.c_int64, 'ulong': ctypes.c_uint64, 'float': ctypes.c_float, 'double': ctypes.c_double}

ealias = ['x', 'y', 'z', 'w', None, None, None, None, None, None, 'sA', 'sB', 'sC', 'sD', 'sE', 'sF']

# arithmetic operators
eoparith = [('+', 'add', lambda a, b: a + b), ('-', 'sub', lambda a, b: a - b), ('*', 'mul', lambda a, b: a * b), ('/', 'div', lambda a, b: a / b)]

# relational operators
eoprel = [('==', 'eq', lambda a, b: a == b), ('!=', 'neq', lambda a, b: a != b), ('<', 'lt', lambda a, b: a < b), ('<=', 'le', lambda a, b: a <= b), ('>', 'gt', lambda a, b: a > b), ('>=', 'ge', lambda a, b: a >= b)]

# bitwise operators (for integer types)
eopbit = [('&', 'and', lambda a, b: a & b), ('|', 'or', lambda a, b: a | b), ('^', 'xor', lambda a, b: a ^ b)]

for vt in vtypes:
    for vr in vranks:
        with open('opencl-tests/Test%s%d.cs' % (vt.title(), vr), 'w') as f:
            f.write('using System;\n')
            f.write('using System.IO;\n')
            f.write('using System.Linq;\n')
            f.write('using System.Runtime.InteropServices;\n')
            f.write('using NUnit.Framework;\n')
            f.write('using OpenCl.Compiler;\n')
            f.write('\n')
            f.write('namespace OpenCl.Tests\n')
            f.write('{\n')
            f.write('    [TestFixture]\n')
            f.write('    public class Test%s%d\n' % (vt.title(), vr))
            f.write('    {\n')
            for opsym, optxt, oplbd in eoparith:
                f.write('        [Kernel]\n')
                f.write('        private static void test_%s%d_%s([Global] %s%d[] a, [Global] %s%d[] b, [Global] %s%d[] r)\n' % (vt, vr, optxt, vt, vr, vt, vr, vt, vr))
                f.write('        {\n')
                f.write('            int i = Cl.GetGlobalId(0);\n')
                f.write('            r[i] = a[i] %s b[i];\n' % opsym)
                f.write('        }\n')
                f.write('\n')
                f.write('        [Test]\n')
                f.write('        public void Test%sManaged()\n' % (optxt.title()))
                f.write('        {\n')
                f.write('            %s%d[] a = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr)))))
                f.write('            %s%d[] b = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr)))))
                f.write('            %s%d[] r = new %s%d[2];\n' % (vt, vr, vt, vr))
                f.write('\n')
                f.write('            // test managed\n')
                f.write('            Array.Clear(r, 0, 2);\n')
                f.write('            Cl.RunKernel(\n')
                f.write('                new int[] { 2 },\n')
                f.write('                new int[] { 1 },\n')
                f.write('                (Action<%s%d[],%s%d[],%s%d[]>)test_%s%d_%s,\n' % (vt, vr, vt, vr, vt, vr, vt, vr, optxt))
                f.write('                a,\n')
                f.write('                b,\n')
                f.write('                r\n')
                f.write('            );\n')
                #f.write('            test_%s%d_%s(a, b, r, 2);\n' % (vt, vr, optxt))
                for i in xrange(2):
                    for j in xrange(vr):
                        r = oplbd(eptype[vt]((7-2*i)*(j+1)), eptype[vt]((5+2*i)*(j+1)))
                        if vt not in ('float', 'double'):
                            f.write('            Assert.AreEqual(%4d, r[%d].s%x);\n' % (ectype[vt](r).value, i, j))
                        elif vt == 'float':
                            f.write('            Assert.AreEqual(%13.8f, r[%d].s%x, 1e-7);\n' % (ectype[vt](r).value, i, j))
                        else:
                            f.write('            Assert.AreEqual(%21.16f, r[%d].s%x, 1e-15);\n' % (ectype[vt](r).value, i, j))
                f.write('        }\n')
                f.write('\n')
                f.write('        [Test]\n')
                f.write('        public void Test%sCl()\n' % (optxt.title()))
                f.write('        {\n')
                f.write('            %s%d[] a = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr)))))
                f.write('            %s%d[] b = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr)))))
                f.write('            %s%d[] r = new %s%d[2];\n' % (vt, vr, vt, vr))
                f.write('\n')
                f.write('            // compile Cl kernel\n')
                f.write('            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.Test%s%d", "test_%s%d_%s");\n' % (vt.title(), vr, vt, vr, optxt))
                f.write('\n')
                f.write('            // test Cl kernel\n')
                f.write('            Platform platform = Platform.GetPlatformIDs()[0];\n')
                f.write('            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);\n')
                f.write('            using (var context = Context.CreateContext(platform, devices, null, null))\n')
                f.write('            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))\n')
                f.write('            {\n')
                f.write('                var program = null as Program;\n')
                f.write('                var kernel = null as Kernel;\n')
                f.write('                var ma = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                var mb = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                var mr = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                try {\n')
                f.write('                    program = Program.CreateProgramWithSource(context, new String[] { source });\n')
#                f.write('                    program.BuildProgram(devices, null, null, null);\n')
                f.write('                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }\n')
                f.write('                    kernel = Kernel.CreateKernel(program, "test_%s%d_%s");\n' % (vt, vr, optxt))
                f.write('                    ma = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);\n' % (vt, vr))
                f.write('                    mb = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);\n' % (vt, vr))
                f.write('                    mr = Mem<%s%d>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<%s%d>());\n' % (vt, vr, vt, vr))
                f.write('                    kernel.SetKernelArg(0, (HandleObject)ma);\n')
                f.write('                    kernel.SetKernelArg(1, (HandleObject)mb);\n')
                f.write('                    kernel.SetKernelArg(2, (HandleObject)mr);\n')
                f.write('                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);\n')
                f.write('                    queue.Finish();\n')
                f.write('                    queue.EnqueueReadBuffer(mr, true, r);\n')
                f.write('                }\n')
                f.write('                finally {\n')
                f.write('                    if (mr != null) mr.Dispose();\n')
                f.write('                    if (mb != null) mb.Dispose();\n')
                f.write('                    if (ma != null) ma.Dispose();\n')
                f.write('                    if (kernel != null) kernel.Dispose();\n')
                f.write('                    if (program != null) program.Dispose();\n')
                f.write('                }\n')
                f.write('            }\n')
                for i in xrange(2):
                    for j in xrange(vr):
                        r = oplbd(eptype[vt]((7-2*i)*(j+1)), eptype[vt]((5+2*i)*(j+1)))
                        if vt not in ('float', 'double'):
                            f.write('            Assert.AreEqual(%4d, r[%d].s%x);\n' % (ectype[vt](r).value, i, j))
                        elif vt == 'float':
                            f.write('            Assert.AreEqual(%13.8f, r[%d].s%x, 1e-7);\n' % (ectype[vt](r).value, i, j))
                        else:
                            f.write('            Assert.AreEqual(%21.16f, r[%d].s%x, 1e-15);\n' % (ectype[vt](r).value, i, j))
                f.write('        }\n')
                f.write('\n')
                f.write('        [Test]\n')
                f.write('        public void Test%sSpir()\n' % (optxt.title()))
                f.write('        {\n')
                f.write('            %s%d[] a = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr)))))
                f.write('            %s%d[] b = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr)))))
                f.write('            %s%d[] r = new %s%d[2];\n' % (vt, vr, vt, vr))
                f.write('\n')
                f.write('            // compile SPIR-V kernel\n')
                f.write('            var module = new MemoryStream();\n')
                f.write('            SpirCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.Test%s%d", "test_%s%d_%s", module);\n' % (vt.title(), vr, vt, vr, optxt))
                f.write('\n')
                f.write('            // test SPIR-V kernel\n')
                f.write('            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();\n')
                f.write('            using (var context = Context.CreateContext(null, device, null, null))\n')
                f.write('            using (var queue = CommandQueue.CreateCommandQueue(context, device))\n')
                f.write('            {\n')
                f.write('                var program = null as Program;\n')
                f.write('                var kernel = null as Kernel;\n')
                f.write('                var ma = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                var mb = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                var mr = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                try {\n')
                f.write('                    program = Program.CreateProgramWithIL(context, module.ToArray());\n')
                f.write('                    program.BuildProgram(device);\n')
#                f.write('                    try { program.BuildProgram(device); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }\n')
                f.write('                    kernel = Kernel.CreateKernel(program, "test_%s%d_%s");\n' % (vt, vr, optxt))
                f.write('                    ma = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);\n' % (vt, vr))
                f.write('                    mb = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);\n' % (vt, vr))
                f.write('                    mr = Mem<%s%d>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<%s%d>());\n' % (vt, vr, vt, vr))
                f.write('                    kernel.SetKernelArg(0, (HandleObject)ma);\n')
                f.write('                    kernel.SetKernelArg(1, (HandleObject)mb);\n')
                f.write('                    kernel.SetKernelArg(2, (HandleObject)mr);\n')
                f.write('                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);\n')
                f.write('                    queue.Finish();\n')
                f.write('                    queue.EnqueueReadBuffer(mr, true, r);\n')
                f.write('                }\n')
                f.write('                finally {\n')
                f.write('                    if (mr != null) mr.Dispose();\n')
                f.write('                    if (mb != null) mb.Dispose();\n')
                f.write('                    if (ma != null) ma.Dispose();\n')
                f.write('                    if (kernel != null) kernel.Dispose();\n')
                f.write('                    if (program != null) program.Dispose();\n')
                f.write('                }\n')
                f.write('            }\n')
                for i in xrange(2):
                    for j in xrange(vr):
                        r = oplbd(eptype[vt]((7-2*i)*(j+1)), eptype[vt]((5+2*i)*(j+1)))
                        if vt not in ('float', 'double'):
                            f.write('            Assert.AreEqual(%4d, r[%d].s%x);\n' % (ectype[vt](r).value, i, j))
                        elif vt == 'float':
                            f.write('            Assert.AreEqual(%13.8f, r[%d].s%x, 1e-7);\n' % (ectype[vt](r).value, i, j))
                        else:
                            f.write('            Assert.AreEqual(%21.16f, r[%d].s%x, 1e-15);\n' % (ectype[vt](r).value, i, j))
                f.write('        }\n')
                f.write('\n')
            for opsym, optxt, oplbd in eoprel:
                rt = ecmptype[vt]
                f.write('        [Kernel]\n')
                f.write('        private static void test_%s%d_%s([Global] %s%d[] a, [Global] %s%d[] b, [Global] %s%d[] r)\n' % (vt, vr, optxt, vt, vr, vt, vr, rt, vr))
                f.write('        {\n')
                f.write('            int i = Cl.GetGlobalId(0);\n')
                f.write('            r[i] = a[i] %s b[i];\n' % opsym)
                f.write('        }\n')
                f.write('\n')
                f.write('        [Test]\n')
                f.write('        public void Test%s()\n' % (optxt.title()))
                f.write('        {\n')
                f.write('            %s%d[] a = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 2*(vr-1)-i) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt,          i) for i in xrange(vr)))))
                f.write('            %s%d[] b = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt,          i) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 2*(vr-1)-i) for i in xrange(vr)))))
                f.write('            %s%d[] r = new %s%d[2];\n' % (rt, vr, rt, vr))
                f.write('\n')
                f.write('            // test managed\n')
                f.write('            Array.Clear(r, 0, 2);\n')
                f.write('            Cl.RunKernel(\n')
                f.write('                new int[] { 2 },\n')
                f.write('                new int[] { 1 },\n')
                f.write('                (Action<%s%d[],%s%d[],%s%d[]>)test_%s%d_%s,\n' % (vt, vr, vt, vr, rt, vr, vt, vr, optxt))
                f.write('                a,\n')
                f.write('                b,\n')
                f.write('                r\n')
                f.write('            );\n')
                #f.write('            test_%s%d_%s(a, b, r, 2);\n' % (vt, vr, optxt))
                for i in xrange(2):
                    for j in xrange(vr):
                        r = oplbd(2*(vr-1)*(1-i)+(2*i-1)*j, 2*(vr-1)*i+(1-2*i)*j)
                        f.write('            Assert.AreEqual(%2d, r[%d].s%x);\n' % (-1 if r else 0, i, j))
                f.write('\n')
                f.write('            // compile kernel\n')
                f.write('            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.Test%s%d", "test_%s%d_%s");\n' % (vt.title(), vr, vt, vr, optxt))
                f.write('\n')
                f.write('            // test native\n')
                f.write('            Platform platform = Platform.GetPlatformIDs()[0];\n')
                f.write('            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);\n')
                f.write('            using (var context = Context.CreateContext(platform, devices, null, null))\n')
                f.write('            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))\n')
                f.write('            {\n')
                f.write('                var program = null as Program;\n')
                f.write('                var kernel = null as Kernel;\n')
                f.write('                var ma = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                var mb = null as Mem<%s%d>;\n' % (vt, vr))
                f.write('                var mr = null as Mem<%s%d>;\n' % (rt, vr))
                f.write('                try {\n')
                f.write('                    program = Program.CreateProgramWithSource(context, new String[] { source });\n')
#                f.write('                    program.BuildProgram(devices, null, null, null);\n')
                f.write('                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }\n')
                f.write('                    kernel = Kernel.CreateKernel(program, "test_%s%d_%s");\n' % (vt, vr, optxt))
                f.write('                    ma = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);\n' % (vt, vr))
                f.write('                    mb = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);\n' % (vt, vr))
                f.write('                    mr = Mem<%s%d>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<%s%d>());\n' % (rt, vr, rt, vr))
                f.write('                    kernel.SetKernelArg(0, (HandleObject)ma);\n')
                f.write('                    kernel.SetKernelArg(1, (HandleObject)mb);\n')
                f.write('                    kernel.SetKernelArg(2, (HandleObject)mr);\n')
                f.write('                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);\n')
                f.write('                    queue.Finish();\n')
                f.write('                    Array.Clear(r, 0, 2);\n')
                f.write('                    queue.EnqueueReadBuffer(mr, true, r);\n')
                f.write('                }\n')
                f.write('                finally {\n')
                f.write('                    if (mr != null) mr.Dispose();\n')
                f.write('                    if (mb != null) mb.Dispose();\n')
                f.write('                    if (ma != null) ma.Dispose();\n')
                f.write('                    if (kernel != null) kernel.Dispose();\n')
                f.write('                    if (program != null) program.Dispose();\n')
                f.write('                }\n')
                f.write('            }\n')
                for i in xrange(2):
                    for j in xrange(vr):
                        r = oplbd(2*(vr-1)*(1-i)+(2*i-1)*j, 2*(vr-1)*i+(1-2*i)*j)
                        f.write('            Assert.AreEqual(%2d, r[%d].s%x);\n' % (-1 if r else 0, i, j))
                f.write('        }\n')
                f.write('\n')
            if vt not in ('float', 'double'):
                for opsym, optxt, oplbd in eopbit:
                    f.write('        [Kernel]\n')
                    f.write('        private static void test_%s%d_%s([Global] %s%d[] a, [Global] %s%d[] b, [Global] %s%d[] r)\n' % (vt, vr, optxt, vt, vr, vt, vr, vt, vr))
                    f.write('        {\n')
                    f.write('            int i = Cl.GetGlobalId(0);\n')
                    f.write('            r[i] = a[i] %s b[i];\n' % opsym)
                    f.write('        }\n')
                    f.write('\n')
                    f.write('        [Test]\n')
                    f.write('        public void Test%s()\n' % (optxt.title()))
                    f.write('        {\n')
                    f.write('            %s%d[] a = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr)))))
                    f.write('            %s%d[] b = new %s%d[] { new %s%d(%s), new %s%d(%s) };\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)%4d' % (vt, 5*(i+1)) for i in xrange(vr))), vt, vr, str.join(', ', ('(%s)%4d' % (vt, 7*(i+1)) for i in xrange(vr)))))
                    f.write('            %s%d[] r = new %s%d[2];\n' % (vt, vr, vt, vr))
                    f.write('\n')
                    f.write('            // test managed\n')
                    f.write('            Array.Clear(r, 0, 2);\n')
                    f.write('            Cl.RunKernel(\n')
                    f.write('                new int[] { 2 },\n')
                    f.write('                new int[] { 1 },\n')
                    f.write('                (Action<%s%d[],%s%d[],%s%d[]>)test_%s%d_%s,\n' % (vt, vr, vt, vr, vt, vr, vt, vr, optxt))
                    f.write('                a,\n')
                    f.write('                b,\n')
                    f.write('                r\n')
                    f.write('            );\n')
                    #f.write('            test_%s%d_%s(a, b, r, 2);\n' % (vt, vr, optxt))
                    for i in xrange(2):
                        for j in xrange(vr):
                            r = oplbd(eptype[vt]((7-2*i)*(j+1)), eptype[vt]((5+2*i)*(j+1)))
                            if vt not in ('float', 'double'):
                                f.write('            Assert.AreEqual(%4d, r[%d].s%x);\n' % (ectype[vt](r).value, i, j))
                            elif vt == 'float':
                                f.write('            Assert.AreEqual(%13.8f, r[%d].s%x, 1e-7);\n' % (ectype[vt](r).value, i, j))
                            else:
                                f.write('            Assert.AreEqual(%21.16f, r[%d].s%x, 1e-15);\n' % (ectype[vt](r).value, i, j))
                    f.write('\n')
                    f.write('            // compile kernel\n')
                    f.write('            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.Test%s%d", "test_%s%d_%s");\n' % (vt.title(), vr, vt, vr, optxt))
                    f.write('\n')
                    f.write('            // test native\n')
                    f.write('            Platform platform = Platform.GetPlatformIDs()[0];\n')
                    f.write('            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);\n')
                    f.write('            using (var context = Context.CreateContext(platform, devices, null, null))\n')
                    f.write('            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))\n')
                    f.write('            {\n')
                    f.write('                var program = null as Program;\n')
                    f.write('                var kernel = null as Kernel;\n')
                    f.write('                var ma = null as Mem<%s%d>;\n' % (vt, vr))
                    f.write('                var mb = null as Mem<%s%d>;\n' % (vt, vr))
                    f.write('                var mr = null as Mem<%s%d>;\n' % (vt, vr))
                    f.write('                try {\n')
                    f.write('                    program = Program.CreateProgramWithSource(context, new String[] { source });\n')
#                    f.write('                    program.BuildProgram(devices, null, null, null);\n')
                    f.write('                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }\n')
                    f.write('                    kernel = Kernel.CreateKernel(program, "test_%s%d_%s");\n' % (vt, vr, optxt))
                    f.write('                    ma = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, a);\n' % (vt, vr))
                    f.write('                    mb = Mem<%s%d>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, b);\n' % (vt, vr))
                    f.write('                    mr = Mem<%s%d>.CreateBuffer(context, MemFlags.WriteOnly, 2*Marshal.SizeOf<%s%d>());\n' % (vt, vr, vt, vr))
                    f.write('                    kernel.SetKernelArg(0, (HandleObject)ma);\n')
                    f.write('                    kernel.SetKernelArg(1, (HandleObject)mb);\n')
                    f.write('                    kernel.SetKernelArg(2, (HandleObject)mr);\n')
                    f.write('                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 2 }, null, null);\n')
                    f.write('                    queue.Finish();\n')
                    f.write('                    Array.Clear(r, 0, 2);\n')
                    f.write('                    queue.EnqueueReadBuffer(mr, true, r);\n')
                    f.write('                }\n')
                    f.write('                finally {\n')
                    f.write('                    if (mr != null) mr.Dispose();\n')
                    f.write('                    if (mb != null) mb.Dispose();\n')
                    f.write('                    if (ma != null) ma.Dispose();\n')
                    f.write('                    if (kernel != null) kernel.Dispose();\n')
                    f.write('                    if (program != null) program.Dispose();\n')
                    f.write('                }\n')
                    f.write('            }\n')
                    for i in xrange(2):
                        for j in xrange(vr):
                            r = oplbd(eptype[vt]((7-2*i)*(j+1)), eptype[vt]((5+2*i)*(j+1)))
                            if vt not in ('float', 'double'):
                                f.write('            Assert.AreEqual(%4d, r[%d].s%x);\n' % (ectype[vt](r).value, i, j))
                            elif vt == 'float':
                                f.write('            Assert.AreEqual(%13.8f, r[%d].s%x, 1e-7);\n' % (ectype[vt](r).value, i, j))
                            else:
                                f.write('            Assert.AreEqual(%21.16f, r[%d].s%x, 1e-15);\n' % (ectype[vt](r).value, i, j))
                    f.write('        }\n')
                    f.write('\n')

            if vr <= 4:
                for tr in xrange(1,vr+1):
                    tt = "%s%d" % (vt, tr) if tr > 1 else vt
                    f.write('        [Kernel]\n')
                    f.write('        private static void test_components%d([Global] %s[] r, [Global] %s%d[] w)\n' % (tr, tt, vt, vr))
                    f.write('        {\n')
                    f.write('            %s%d ar = new %s%d(%s);\n' % (vt, vr, vt, vr, str.join(', ', ("(%s)%d" % (vt, i+1) for i in xrange(vr)))))
                    if tr > 1:
                        f.write('            %s aw = new %s(%s);\n' % (tt, tt, str.join(', ', ("(%s)%d" % (vt, i+1) for i in xrange(tr)))))
                    else:
                        f.write('            %s aw = %s;\n' % (tt, str.join(', ', ("(%s)%d" % (vt, i+1) for i in xrange(tr)))))
                    rcnt = 0
                    wcnt = 0
                    for c in itertools.product(xrange(vr), repeat=tr):
                        f.write('            r[%d] = ar.%s;\n' % (rcnt, str.join('', (ealias[i] for i in c))))
                        rcnt = rcnt+1
                        if len(set(c)) == tr:
                            f.write('            w[%d].%s = aw;\n' % (wcnt, str.join('', (ealias[i] for i in c))))
                            wcnt = wcnt+1
                    f.write('        }\n')
                    f.write('\n')
                    f.write('        [Test]\n')
                    f.write('        public void TestComponentAccessors%d()\n' % tr)
                    f.write('        {\n')
                    f.write('            int nr = %d;\n' % rcnt)
                    f.write('            int nw = %d;\n' % wcnt)
                    f.write('            %s[] r = new %s[nr];\n' % (tt, tt))
                    f.write('            %s%d[] w = new %s%d[nw];\n' % (vt, vr, vt, vr))
                    f.write('\n')
                    f.write('            // test managed\n')
                    f.write('            Array.Clear(r, 0, nr);\n')
                    f.write('            Array.Clear(w, 0, nw);\n')
                    f.write('            Cl.RunKernel(\n')
                    f.write('                new int[] { 1 },\n')
                    f.write('                new int[] { 1 },\n')
                    f.write('                (Action<%s[],%s%d[]>)test_components%d,\n' % (tt, vt, vr, tr))
                    f.write('                r, w\n')
                    f.write('            );\n')
                    rcnt = 0
                    wcnt = 0
                    for c in itertools.product(xrange(vr), repeat=tr):
                        for k, x in enumerate(c):
                            if tr > 1:
                                f.write('            Assert.AreEqual((%s)%d, r[%d].s%x);\n' % (vt, x+1, rcnt, k))
                            else:
                                f.write('            Assert.AreEqual((%s)%d, r[%d]);\n' % (vt, x+1, rcnt))
                        rcnt = rcnt+1
                        cs = set(c)
                        if len(set(c)) == tr:
                            for k, x in enumerate(c):
                                f.write('            Assert.AreEqual((%s)%d, w[%d].s%x);\n' % (vt, k+1, wcnt, x))
                            for x in (set(xrange(vr))-set(c)):
                                f.write('            Assert.AreEqual((%s)0, w[%d].s%x);\n' % (vt, wcnt, x))
                            wcnt = wcnt+1
                    f.write('\n')
                    f.write('            // compile kernel\n')
                    f.write('            var source = ClCompiler.EmitKernel("opencl-tests", "OpenCl.Tests.Test%s%d", "test_components%d");\n' % (vt.title(), vr, tr))
                    f.write('\n')
                    f.write('            // test native\n')
                    f.write('            Platform platform = Platform.GetPlatformIDs()[0];\n')
                    f.write('            Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);\n')
                    f.write('            using (var context = Context.CreateContext(platform, devices, null, null))\n')
                    f.write('            using (var queue = CommandQueue.CreateCommandQueue(context, devices[0]))\n')
                    f.write('            {\n')
                    f.write('                var program = null as Program;\n')
                    f.write('                var kernel = null as Kernel;\n')
                    f.write('                var mr = null as Mem<%s>;\n' % tt)
                    f.write('                var mw = null as Mem<%s%d>;\n' % (vt, vr))
                    f.write('                try {\n')
                    f.write('                    program = Program.CreateProgramWithSource(context, new String[] { source });\n')
                    f.write('                    try { program.BuildProgram(devices, null, null, null); } catch (OpenClException ex) { Console.WriteLine(source); throw ex; }\n')
                    f.write('                    kernel = Kernel.CreateKernel(program, "test_components%d");\n' % tr)
                    f.write('                    mr = Mem<%s>.CreateBuffer(context, MemFlags.WriteOnly, nr*Marshal.SizeOf<%s>());\n' % (tt, tt))
                    f.write('                    mw = Mem<%s%d>.CreateBuffer(context, MemFlags.WriteOnly, nw*Marshal.SizeOf<%s%d>());\n' % (vt, vr, vt, vr))
                    f.write('                    kernel.SetKernelArg(0, (HandleObject)mr);\n')
                    f.write('                    kernel.SetKernelArg(1, (HandleObject)mw);\n')
                    f.write('                    queue.EnqueueFillBuffer(mw, default(%s%d));\n' % (vt, vr))
                    f.write('                    queue.Finish();\n')
                    f.write('                    queue.EnqueueNDRangeKernel(kernel, null, new int[] { 1 }, null, null);\n')
                    f.write('                    queue.Finish();\n')
                    # f.write('                    Array.Clear(r, 0, nr);\n')
                    f.write('                    queue.EnqueueReadBuffer(mr, false, r);\n')
                    # f.write('                    Array.Clear(w, 0, nw);\n')
                    f.write('                    queue.EnqueueReadBuffer(mw, false, w);\n')
                    f.write('                    queue.Finish();\n')
                    f.write('                }\n')
                    f.write('                finally {\n')
                    f.write('                    if (mr != null) mr.Dispose();\n')
                    f.write('                    if (mw != null) mw.Dispose();\n')
                    f.write('                    if (kernel != null) kernel.Dispose();\n')
                    f.write('                    if (program != null) program.Dispose();\n')
                    f.write('                }\n')
                    f.write('            }\n')
                    rcnt = 0
                    wcnt = 0
                    for c in itertools.product(xrange(vr), repeat=tr):
                        for k, x in enumerate(c):
                            if tr > 1:
                                f.write('            Assert.AreEqual((%s)%d, r[%d].s%x);\n' % (vt, x+1, rcnt, k))
                            else:
                                f.write('            Assert.AreEqual((%s)%d, r[%d]);\n' % (vt, x+1, rcnt))
                        rcnt = rcnt+1
                        cs = set(c)
                        if len(set(c)) == tr:
                            for k, x in enumerate(c):
                                f.write('            Assert.AreEqual((%s)%d, w[%d].s%x);\n' % (vt, k+1, wcnt, x))
                            for x in (set(xrange(vr))-set(c)):
                                f.write('            Assert.AreEqual((%s)0, w[%d].s%x);\n' % (vt, wcnt, x))
                            wcnt = wcnt+1
                    f.write('        }\n')

            f.write('    }\n')
            f.write('}\n')
