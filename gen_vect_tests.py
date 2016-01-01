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
            f.write('using System.Runtime.InteropServices;\n')
            f.write('using NUnit.Framework;\n')
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
                f.write('            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.Test%s%d", "test_%s%d_%s");\n' % (vt.title(), vr, vt, vr, optxt))
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
                f.write('            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.Test%s%d", "test_%s%d_%s");\n' % (vt.title(), vr, vt, vr, optxt))
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
                    f.write('            var source = Compiler.EmitKernel("opencl-tests.dll", "OpenCl.Tests.Test%s%d", "test_%s%d_%s");\n' % (vt.title(), vr, vt, vr, optxt))
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

            f.write('    }\n')
            f.write('}\n')
