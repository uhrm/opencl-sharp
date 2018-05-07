import itertools

vtypes = ['sbyte', 'byte', 'short', 'ushort', 'int', 'uint', 'long', 'ulong', 'float', 'double']
vranks = [2, 3, 4, 8, 16]
#vranks = [2, 3, 4]

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

def partitions(n, t):
    """
    Generate all sequences of `n` positive integers that sum to `t`
    (see http://stackoverflow.com/a/13990855/1147926).
    """
    assert(1 <= n <= t)
    for c in itertools.combinations(range(1, t), n - 1):
        def intervals():
            last = 0
            for i in c:
                yield i - last
                last = i
            yield t - last
        yield tuple(intervals())

with open('opencl-sharp/VectorTypes.cs', 'w') as f:
    f.write('\n')
    f.write('//\n')
    f.write('// GENERATED SOURCE FILE -- DO NOT MODIFY\n')
    f.write('//\n')
    f.write('\n')
    f.write('using System;\n')
    f.write('using System.Diagnostics;\n')
    f.write('using System.Runtime.InteropServices;\n')
    f.write('\n')
    f.write('namespace OpenCl\n')
    f.write('{\n')
    for vt in vtypes:
        for vr in vranks:
            f.write('\n')
            if vr != 3:
                f.write('    [StructLayout(LayoutKind.Explicit)]\n')
            else:
                f.write('    [StructLayout(LayoutKind.Explicit, Size=%d)]\n' % (4*esizes[vt]))
            f.write('    [DebuggerDisplay("(%s)")]\n' % str.join(',', ('{s%x}' % i for i in range(vr))))
            f.write('    public struct %s%d : IEquatable<%s%d>\n' % (vt, vr, vt, vr))
            f.write('    {\n')
            for i in range(vr):
                f.write('        [FieldOffset(%d)]\n' % (i*esizes[vt]))
                f.write('        public %s s%x;\n' % (vt, i))
            f.write('\n')
            #
            # scalar constructor
            #
            f.write('        public %s%d(%s v)\n' % (vt, vr, vt))
            f.write('        {\n')
            for i in range(vr):
                f.write('            this.s%x = v;\n' % i)
            f.write('        }\n')
            f.write('\n')
            #
            # vector constructors
            #
            for i in range(1 if vr<=4 else vr, vr+1):
                for p in partitions(i, vr):
                    f.write('        public %s%d(%s)\n' % (vt, vr, str.join(', ', ('%s v%x' % (vt, i) if r==1 else '%s%d v%x' % (vt, r, i) for i,r in enumerate(p)))))
                    f.write('        {\n')
                    k = 0
                    for i, r in enumerate(p):
                        if r == 1:
                            f.write('            this.s%x = v%x;\n' % (k, i))
                            k += 1
                        else:
                            for j in range(r):
                                f.write('            this.s%x = v%x.s%x;\n' % (k, i, j))
                                k += 1
                    f.write('        }\n')
                    f.write('\n')
            #
            # scalar component accessors (x,y,w,z)
            #
            if vr <= 4:
                for i in range(vr):
                    f.write('        public %s %s\n' % (vt, ealias[i]))
                    f.write('        {\n')
                    f.write('            get { return this.s%x; }\n' % i)
                    f.write('            set { this.s%x = value; }\n' % i)
                    f.write('        }\n')
                    f.write('\n')
            #
            # vector component accessors (x,y,w,z)
            #
            if vr <= 4:
                for tr in range(2,vr+1):
                    for c in itertools.product(range(vr), repeat=tr):
                        f.write('        public %s%d %s\n' % (vt, tr, str.join('', (ealias[i] for i in c))))
                        f.write('        {\n')
                        f.write('            get { return new %s%d(%s); }\n' % (vt, tr, str.join(', ', ('this.s%x' % i for i in c))))
                        if len(set(c)) == tr:
                            f.write('            set {\n')
                            for i in range(tr):
                                f.write('                 this.s%x = value.s%x;\n' % (c[i], i))
                            f.write('            }\n')
                        f.write('        }\n')
                        f.write('\n')
            #
            # capitalized component accessors
            #
            if vr == 16:
                for i in range(10,vr):
                    f.write('        public %s %s\n' % (vt, ealias[i]))
                    f.write('        {\n')
                    f.write('            get { return this.s%x; }\n' % i)
                    f.write('            set { this.s%x = value; }\n' % i)
                    f.write('        }\n')
                    f.write('\n')
            #
            # indexer component accessor
            #
            f.write('        public %s this[int index]\n' % vt)
            f.write('        {\n')
            f.write('            get  {\n')
            f.write('                switch (index)\n')
            f.write('                {\n')
            for i in range(vr):
                f.write('                case %d:\n' % i)
                f.write('                    return this.s%x;\n' % i)
            f.write('                default:\n')
            f.write('                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < %d, found index = {0}", index));\n' % vr)
            f.write('                }\n')
            f.write('            }\n')
            f.write('            set {\n')
            f.write('                switch (index)\n')
            f.write('                {\n')
            for i in range(vr):
                f.write('                case %d:\n' % i)
                f.write('                    this.s%x = value;\n' % i)
                f.write('                    break;\n')
            f.write('                default:\n')
            f.write('                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < %d, found index = {0}", index));\n' % vr)
            f.write('                }\n')
            f.write('            }\n')
            f.write('        }\n')
            f.write('\n')
            #
            # IEquatable implementation
            #
            f.write('        // IEquatable\n')
            f.write('\n')
            f.write('        public bool Equals(%s%d obj)\n' % (vt, vr))
            f.write('        {\n')
            f.write('            return %s;\n' % str.join(' && ', ('this.s%x == obj.s%x' % (i, i) for i in range(vr))))
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
            f.write('            return %s;\n' % str.join(' ^ ', ('this.s%x.GetHashCode()' % i for i in range(vr))))
            f.write('        }\n')
            f.write('\n')
            f.write('        public override string ToString()\n')
            f.write('        {\n')
            f.write('            return String.Format("%s", %s);\n' % (str.join(',', ('{%d}' % i for i in range(vr))), str.join(', ', ('this.s%x' % i for i in range(vr)))))
            f.write('        }\n')
            f.write('\n')
            #
            # operators
            #
            f.write('        // Operators\n')
            f.write('\n')
            f.write('        public static implicit operator %s%d((%s) t) => new %s%d(%s);\n' % (vt, vr, str.join(',', itertools.repeat(vt, vr)), vt, vr, str.join(', ', ('t.Item%d' % (i+1,) for i in range(vr)))))
            f.write('\n')
            f.write('        public static implicit operator (%s)(%s%d v) => (%s);\n' % (str.join(',', itertools.repeat(vt, vr)), vt, vr, str.join(', ', ('v.s%x' % (i,) for i in range(vr)))))
            for op in eoparith:
                f.write('\n')
                f.write('        public static %s%d operator %s(%s%d a, %s%d b) => new %s%d(%s);\n' % (vt, vr, op, vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x%sb.s%x)' % (vt, i, op, i) for i in range(vr)))))
            for op in eoprel:
                rt = ecmptype[vt] # element type of result
                f.write('\n')
                f.write('        public static %s%d operator %s(%s%d a, %s%d b) => new %s%d(%s);\n' % (rt, vr, op, vt, vr, vt, vr, rt, vr, str.join(', ', ('a.s%x%sb.s%x ? %s : %s' % (i, op, i, emone[rt], ezero[rt]) for i in range(vr)))))
            if vt not in ('float', 'double'):
                for op in eopbit:
                    f.write('\n')
                    f.write('        public static %s%d operator %s(%s%d a, %s%d b) => new %s%d(%s);\n' % (vt, vr, op, vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x%sb.s%x)' % (vt, i, op, i) for i in range(vr)))))
            f.write('\n')
            f.write('        public static %s%d operator +(%s%d a) => a;\n' % (vt, vr, vt, vr))
            if esigned[vt]:
                f.write('\n')
                f.write('        public static %s%d operator -(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(-a.s%x)' % (vt, i) for i in range(vr)))))
            if vt not in ('float', 'double'):
                f.write('\n')
                f.write('        public static %s%d operator ~(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(~a.s%x)' % (vt, i) for i in range(vr)))))
                f.write('\n')
                f.write('        public static %s%d operator ++(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x+1)' % (vt, i) for i in range(vr)))))
                f.write('\n')
                f.write('        public static %s%d operator --(%s%d a) => new %s%d(%s);\n' % (vt, vr, vt, vr, vt, vr, str.join(', ', ('(%s)(a.s%x-1)' % (vt, i) for i in range(vr)))))
            f.write('\n')
            #
            # object deconstruction
            #
            f.write('        // Object deconstruction\n')
            f.write('\n')
            f.write('        public void Deconstruct(%s)\n' % str.join(', ', ('out %s s%x' % (vt, i) for i in range(vr))))
            f.write('        {\n')
            for i in range(vr):
                f.write('            s%x = this.s%x;\n' % (i, i))
            f.write('        }\n')
            f.write('    }\n')

    f.write('}\n')
