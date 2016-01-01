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

ealias = ['x', 'y', 'z', 'w', None, None, None, None, None, None, 'sA', 'sB', 'sC', 'sD', 'sE', 'sF']
eoparith = ['+', '-', '*', '/']             # arithmetic operators
eoprel = ['==', '!=', '<', '<=', '>', '>='] # relational operators (for integer types)
eopbit = ['&', '|', '^']                    # bitwise operators

with open('opencl-sharp/VectorTypes.cs', 'w') as f:
    f.write('using System;\n')
    f.write('using System.Diagnostics;\n')
    f.write('using System.Runtime.InteropServices;\n')
    f.write('\n')
    f.write('namespace OpenCl\n')
    f.write('{\n')
    f.write('    public interface IVectorType\n')
    f.write('    {\n')
    f.write('        int Rank { get; }\n')
    f.write('        int Size { get; }\n')
    f.write('    }\n')
    for vt in vtypes:
        for vr in vranks:
            f.write('\n')
            if vr != 3:
                f.write('    [StructLayout(LayoutKind.Explicit)]\n')
            else:
                f.write('    [StructLayout(LayoutKind.Explicit, Size=%d)]\n' % (4*esizes[vt]))
            f.write('    [DebuggerDisplay("(%s)")]\n' % str.join(',', ('{s%x}' % i for i in xrange(vr))))
            f.write('    public struct %s%d: IVectorType, IEquatable<%s%d>\n' % (vt, vr, vt, vr))
            f.write('    {\n')
            for i in xrange(vr):
                f.write('        [FieldOffset(%d)]\n' % (i*esizes[vt]))
                f.write('        public %s s%x;\n' % (vt, i))
            f.write('\n')
            f.write('        public %s%d(%s v)\n' % (vt, vr, vt))
            f.write('        {\n')
            for i in xrange(vr):
                f.write('            this.s%x = v;\n' % i)
            f.write('        }\n')
            f.write('\n')
            f.write('        public %s%d(%s)\n' % (vt, vr, str.join(', ', ('%s s%x' % (vt, i) for i in xrange(vr)))))
            f.write('        {\n')
            for i in xrange(vr):
                f.write('            this.s%x = s%x;\n' % (i, i))
            f.write('        }\n')
            f.write('\n')
            if vr <= 4:
                for i in xrange(vr):
                    f.write('        public %s %s\n' % (vt, ealias[i]))
                    f.write('        {\n')
                    f.write('            get { return this.s%x; }\n' % i)
                    f.write('            set { this.s%x = value; }\n' % i)
                    f.write('        }\n')
                    f.write('\n')
            if vr <= 4:
                for c in itertools.product(xrange(vr), repeat=vr):
                    f.write('        public %s%d %s\n' % (vt, vr, str.join('', (ealias[i] for i in c))))
                    f.write('        {\n')
                    f.write('            get { return new %s%d(%s); }\n' % (vt, vr, str.join(', ', ('this.s%x' % i for i in c))))
                    f.write('        }\n')
                    f.write('\n')
            if vr == 16:
                for i in xrange(10,vr):
                    f.write('        public %s %s\n' % (vt, ealias[i]))
                    f.write('        {\n')
                    f.write('            get { return this.s%x; }\n' % i)
                    f.write('            set { this.s%x = value; }\n' % i)
                    f.write('        }\n')
                    f.write('\n')
            f.write('        public %s this[int index]\n' % vt)
            f.write('        {\n')
            f.write('            get  {\n')
            f.write('                switch (index)\n')
            f.write('                {\n')
            for i in xrange(vr):
                f.write('                case %d:\n' % i)
                f.write('                    return this.s%x;\n' % i)
            f.write('                default:\n')
            f.write('                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < %d, found index = {0}", index));\n' % vr)
            f.write('                }\n')
            f.write('            }\n')
            f.write('            set {\n')
            f.write('                switch (index)\n')
            f.write('                {\n')
            for i in xrange(vr):
                f.write('                case %d:\n' % i)
                f.write('                    this.s%x = value;\n' % i)
                f.write('                    break;\n')
            f.write('                default:\n')
            f.write('                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < %d, found index = {0}", index));\n' % vr)
            f.write('                }\n')
            f.write('            }\n')
            f.write('        }\n')
            f.write('\n')
            f.write('        // IVectorType\n')
            f.write('\n')
            f.write('        public int Rank\n')
            f.write('        {\n')
            f.write('            get { return %d; }\n' % vr)
            f.write('        }\n')
            f.write('\n')
            f.write('        public int Size\n')
            f.write('        {\n')
            f.write('            get { return %d; }\n' % (vr*esizes[vt]))
            f.write('        }\n')
            f.write('\n')
            f.write('        // IEquatable\n')
            f.write('\n')
            f.write('        public bool Equals(%s%d obj)\n' % (vt, vr))
            f.write('        {\n')
            f.write('            return %s;\n' % str.join(' && ', ('this.s%x == obj.s%x' % (i, i) for i in xrange(vr))))
            f.write('        }\n')
            f.write('\n')
            f.write('        // Object\n')
            f.write('\n')
            f.write('        public override bool Equals(object obj)\n')
            f.write('        {\n')
            f.write('            return obj is %s%d && Equals((%s%d)obj);\n' % (vt, vr, vt, vr))
            f.write('        }\n')
            f.write('\n')
            f.write('        public override int GetHashCode()\n')
            f.write('        {\n')
            f.write('            return %s;\n' % str.join(' ^ ', ('this.s%x.GetHashCode()' % i for i in xrange(vr))))
            f.write('        }\n')
            f.write('\n')
            f.write('        public override string ToString()\n')
            f.write('        {\n')
            f.write('            return String.Format("%s", %s);\n' % (str.join(',', ('{%d}' % i for i in xrange(vr))), str.join(', ', ('this.s%x' % i for i in xrange(vr)))))
            f.write('        }\n')
            f.write('\n')
            f.write('        // Operators\n')
            for op in eoparith:
                f.write('\n')
                f.write('        public static %s%d operator %s(%s%d a, %s%d b) => new %s%d(%s);\n' % (vt, vr, op, vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x%sb.s%x)' % (vt, i, op, i) for i in xrange(vr)))))
            for op in eoprel:
                rt = ecmptype[vt] # element type of result
                f.write('\n')
                f.write('        public static %s%d operator %s(%s%d a, %s%d b) => new %s%d(%s);\n' % (rt, vr, op, vt, vr, vt, vr, rt, vr, str.join(', ', ('a.s%x%sb.s%x ? %s : %s' % (i, op, i, emone[rt], ezero[rt]) for i in xrange(vr)))))
            if vt not in ('float', 'double'):
                for op in eopbit:
                    f.write('\n')
                    f.write('        public static %s%d operator %s(%s%d a, %s%d b) => new %s%d(%s);\n' % (vt, vr, op, vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x%sb.s%x)' % (vt, i, op, i) for i in xrange(vr)))))
            f.write('\n')
            f.write('        public static %s%d operator +(%s%d a) => a;\n' % (vt, vr, vt, vr))
            if esigned[vt]:
                f.write('\n')
                f.write('        public static %s%d operator -(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(-a.s%x)' % (vt, i) for i in xrange(vr)))))
            if vt not in ('float', 'double'):
                f.write('\n')
                f.write('        public static %s%d operator ~(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(~a.s%x)' % (vt, i) for i in xrange(vr)))))
                f.write('\n')
                f.write('        public static %s%d operator ++(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x+1)' % (vt, i) for i in xrange(vr)))))
                f.write('\n')
                f.write('        public static %s%d operator --(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x-1)' % (vt, i) for i in xrange(vr)))))
            f.write('    }\n')

    f.write('}\n')
