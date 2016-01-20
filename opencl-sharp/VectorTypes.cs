using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OpenCl
{
    public interface IVectorType
    {
        int Rank { get; }
        int Size { get; }
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct sbyte2: IVectorType, IEquatable<sbyte2>
    {
        [FieldOffset(0)]
        public sbyte s0;
        [FieldOffset(1)]
        public sbyte s1;

        public sbyte2(sbyte v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public sbyte2(sbyte2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public sbyte2(sbyte v0, sbyte v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public sbyte x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public sbyte y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public sbyte2 xx
        {
            get { return new sbyte2(this.s0, this.s0); }
        }

        public sbyte2 xy
        {
            get { return new sbyte2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public sbyte2 yx
        {
            get { return new sbyte2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public sbyte2 yy
        {
            get { return new sbyte2(this.s1, this.s1); }
        }

        public sbyte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 2; }
        }

        // IEquatable

        public bool Equals(sbyte2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is sbyte2 && Equals((sbyte2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static sbyte2 operator +(sbyte2 a, sbyte2 b) => new sbyte2((sbyte)(a.s0+b.s0), (sbyte)(a.s1+b.s1));

        public static sbyte2 operator -(sbyte2 a, sbyte2 b) => new sbyte2((sbyte)(a.s0-b.s0), (sbyte)(a.s1-b.s1));

        public static sbyte2 operator *(sbyte2 a, sbyte2 b) => new sbyte2((sbyte)(a.s0*b.s0), (sbyte)(a.s1*b.s1));

        public static sbyte2 operator /(sbyte2 a, sbyte2 b) => new sbyte2((sbyte)(a.s0/b.s0), (sbyte)(a.s1/b.s1));

        public static sbyte2 operator ==(sbyte2 a, sbyte2 b) => new sbyte2(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator !=(sbyte2 a, sbyte2 b) => new sbyte2(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator <(sbyte2 a, sbyte2 b) => new sbyte2(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator <=(sbyte2 a, sbyte2 b) => new sbyte2(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator >(sbyte2 a, sbyte2 b) => new sbyte2(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator >=(sbyte2 a, sbyte2 b) => new sbyte2(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator &(sbyte2 a, sbyte2 b) => new sbyte2((sbyte)(a.s0&b.s0), (sbyte)(a.s1&b.s1));

        public static sbyte2 operator |(sbyte2 a, sbyte2 b) => new sbyte2((sbyte)(a.s0|b.s0), (sbyte)(a.s1|b.s1));

        public static sbyte2 operator ^(sbyte2 a, sbyte2 b) => new sbyte2((sbyte)(a.s0^b.s0), (sbyte)(a.s1^b.s1));

        public static sbyte2 operator +(sbyte2 a) => a;

        public static sbyte2 operator -(sbyte2 a) => new sbyte2((sbyte)(-a.s0), (sbyte)(-a.s1));

        public static sbyte2 operator ~(sbyte2 a) => new sbyte2((sbyte)(~a.s0), (sbyte)(~a.s1));

        public static sbyte2 operator ++(sbyte2 a) => new sbyte2((sbyte)(a.s0+1), (sbyte)(a.s1+1));

        public static sbyte2 operator --(sbyte2 a) => new sbyte2((sbyte)(a.s0-1), (sbyte)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=4)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct sbyte3: IVectorType, IEquatable<sbyte3>
    {
        [FieldOffset(0)]
        public sbyte s0;
        [FieldOffset(1)]
        public sbyte s1;
        [FieldOffset(2)]
        public sbyte s2;

        public sbyte3(sbyte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public sbyte3(sbyte3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public sbyte3(sbyte v0, sbyte2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public sbyte3(sbyte2 v0, sbyte v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public sbyte3(sbyte v0, sbyte v1, sbyte v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public sbyte x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public sbyte y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public sbyte z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public sbyte2 xx
        {
            get { return new sbyte2(this.s0, this.s0); }
        }

        public sbyte2 xy
        {
            get { return new sbyte2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public sbyte2 xz
        {
            get { return new sbyte2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public sbyte2 yx
        {
            get { return new sbyte2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public sbyte2 yy
        {
            get { return new sbyte2(this.s1, this.s1); }
        }

        public sbyte2 yz
        {
            get { return new sbyte2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public sbyte2 zx
        {
            get { return new sbyte2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public sbyte2 zy
        {
            get { return new sbyte2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public sbyte2 zz
        {
            get { return new sbyte2(this.s2, this.s2); }
        }

        public sbyte3 xxx
        {
            get { return new sbyte3(this.s0, this.s0, this.s0); }
        }

        public sbyte3 xxy
        {
            get { return new sbyte3(this.s0, this.s0, this.s1); }
        }

        public sbyte3 xxz
        {
            get { return new sbyte3(this.s0, this.s0, this.s2); }
        }

        public sbyte3 xyx
        {
            get { return new sbyte3(this.s0, this.s1, this.s0); }
        }

        public sbyte3 xyy
        {
            get { return new sbyte3(this.s0, this.s1, this.s1); }
        }

        public sbyte3 xyz
        {
            get { return new sbyte3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 xzx
        {
            get { return new sbyte3(this.s0, this.s2, this.s0); }
        }

        public sbyte3 xzy
        {
            get { return new sbyte3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 xzz
        {
            get { return new sbyte3(this.s0, this.s2, this.s2); }
        }

        public sbyte3 yxx
        {
            get { return new sbyte3(this.s1, this.s0, this.s0); }
        }

        public sbyte3 yxy
        {
            get { return new sbyte3(this.s1, this.s0, this.s1); }
        }

        public sbyte3 yxz
        {
            get { return new sbyte3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 yyx
        {
            get { return new sbyte3(this.s1, this.s1, this.s0); }
        }

        public sbyte3 yyy
        {
            get { return new sbyte3(this.s1, this.s1, this.s1); }
        }

        public sbyte3 yyz
        {
            get { return new sbyte3(this.s1, this.s1, this.s2); }
        }

        public sbyte3 yzx
        {
            get { return new sbyte3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 yzy
        {
            get { return new sbyte3(this.s1, this.s2, this.s1); }
        }

        public sbyte3 yzz
        {
            get { return new sbyte3(this.s1, this.s2, this.s2); }
        }

        public sbyte3 zxx
        {
            get { return new sbyte3(this.s2, this.s0, this.s0); }
        }

        public sbyte3 zxy
        {
            get { return new sbyte3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 zxz
        {
            get { return new sbyte3(this.s2, this.s0, this.s2); }
        }

        public sbyte3 zyx
        {
            get { return new sbyte3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 zyy
        {
            get { return new sbyte3(this.s2, this.s1, this.s1); }
        }

        public sbyte3 zyz
        {
            get { return new sbyte3(this.s2, this.s1, this.s2); }
        }

        public sbyte3 zzx
        {
            get { return new sbyte3(this.s2, this.s2, this.s0); }
        }

        public sbyte3 zzy
        {
            get { return new sbyte3(this.s2, this.s2, this.s1); }
        }

        public sbyte3 zzz
        {
            get { return new sbyte3(this.s2, this.s2, this.s2); }
        }

        public sbyte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 3; }
        }

        // IEquatable

        public bool Equals(sbyte3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is sbyte3 && Equals((sbyte3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static sbyte3 operator +(sbyte3 a, sbyte3 b) => new sbyte3((sbyte)(a.s0+b.s0), (sbyte)(a.s1+b.s1), (sbyte)(a.s2+b.s2));

        public static sbyte3 operator -(sbyte3 a, sbyte3 b) => new sbyte3((sbyte)(a.s0-b.s0), (sbyte)(a.s1-b.s1), (sbyte)(a.s2-b.s2));

        public static sbyte3 operator *(sbyte3 a, sbyte3 b) => new sbyte3((sbyte)(a.s0*b.s0), (sbyte)(a.s1*b.s1), (sbyte)(a.s2*b.s2));

        public static sbyte3 operator /(sbyte3 a, sbyte3 b) => new sbyte3((sbyte)(a.s0/b.s0), (sbyte)(a.s1/b.s1), (sbyte)(a.s2/b.s2));

        public static sbyte3 operator ==(sbyte3 a, sbyte3 b) => new sbyte3(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator !=(sbyte3 a, sbyte3 b) => new sbyte3(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator <(sbyte3 a, sbyte3 b) => new sbyte3(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator <=(sbyte3 a, sbyte3 b) => new sbyte3(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator >(sbyte3 a, sbyte3 b) => new sbyte3(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator >=(sbyte3 a, sbyte3 b) => new sbyte3(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator &(sbyte3 a, sbyte3 b) => new sbyte3((sbyte)(a.s0&b.s0), (sbyte)(a.s1&b.s1), (sbyte)(a.s2&b.s2));

        public static sbyte3 operator |(sbyte3 a, sbyte3 b) => new sbyte3((sbyte)(a.s0|b.s0), (sbyte)(a.s1|b.s1), (sbyte)(a.s2|b.s2));

        public static sbyte3 operator ^(sbyte3 a, sbyte3 b) => new sbyte3((sbyte)(a.s0^b.s0), (sbyte)(a.s1^b.s1), (sbyte)(a.s2^b.s2));

        public static sbyte3 operator +(sbyte3 a) => a;

        public static sbyte3 operator -(sbyte3 a) => new sbyte3((sbyte)(-a.s0), (sbyte)(-a.s1), (sbyte)(-a.s2));

        public static sbyte3 operator ~(sbyte3 a) => new sbyte3((sbyte)(~a.s0), (sbyte)(~a.s1), (sbyte)(~a.s2));

        public static sbyte3 operator ++(sbyte3 a) => new sbyte3((sbyte)(a.s0+1), (sbyte)(a.s1+1), (sbyte)(a.s2+1));

        public static sbyte3 operator --(sbyte3 a) => new sbyte3((sbyte)(a.s0-1), (sbyte)(a.s1-1), (sbyte)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct sbyte4: IVectorType, IEquatable<sbyte4>
    {
        [FieldOffset(0)]
        public sbyte s0;
        [FieldOffset(1)]
        public sbyte s1;
        [FieldOffset(2)]
        public sbyte s2;
        [FieldOffset(3)]
        public sbyte s3;

        public sbyte4(sbyte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public sbyte4(sbyte4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public sbyte4(sbyte v0, sbyte3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public sbyte4(sbyte2 v0, sbyte2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public sbyte4(sbyte3 v0, sbyte v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public sbyte4(sbyte v0, sbyte v1, sbyte2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public sbyte4(sbyte v0, sbyte2 v1, sbyte v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public sbyte4(sbyte2 v0, sbyte v1, sbyte v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public sbyte4(sbyte v0, sbyte v1, sbyte v2, sbyte v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public sbyte x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public sbyte y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public sbyte z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public sbyte w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public sbyte2 xx
        {
            get { return new sbyte2(this.s0, this.s0); }
        }

        public sbyte2 xy
        {
            get { return new sbyte2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public sbyte2 xz
        {
            get { return new sbyte2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public sbyte2 xw
        {
            get { return new sbyte2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public sbyte2 yx
        {
            get { return new sbyte2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public sbyte2 yy
        {
            get { return new sbyte2(this.s1, this.s1); }
        }

        public sbyte2 yz
        {
            get { return new sbyte2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public sbyte2 yw
        {
            get { return new sbyte2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public sbyte2 zx
        {
            get { return new sbyte2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public sbyte2 zy
        {
            get { return new sbyte2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public sbyte2 zz
        {
            get { return new sbyte2(this.s2, this.s2); }
        }

        public sbyte2 zw
        {
            get { return new sbyte2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public sbyte2 wx
        {
            get { return new sbyte2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public sbyte2 wy
        {
            get { return new sbyte2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public sbyte2 wz
        {
            get { return new sbyte2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public sbyte2 ww
        {
            get { return new sbyte2(this.s3, this.s3); }
        }

        public sbyte3 xxx
        {
            get { return new sbyte3(this.s0, this.s0, this.s0); }
        }

        public sbyte3 xxy
        {
            get { return new sbyte3(this.s0, this.s0, this.s1); }
        }

        public sbyte3 xxz
        {
            get { return new sbyte3(this.s0, this.s0, this.s2); }
        }

        public sbyte3 xxw
        {
            get { return new sbyte3(this.s0, this.s0, this.s3); }
        }

        public sbyte3 xyx
        {
            get { return new sbyte3(this.s0, this.s1, this.s0); }
        }

        public sbyte3 xyy
        {
            get { return new sbyte3(this.s0, this.s1, this.s1); }
        }

        public sbyte3 xyz
        {
            get { return new sbyte3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 xyw
        {
            get { return new sbyte3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public sbyte3 xzx
        {
            get { return new sbyte3(this.s0, this.s2, this.s0); }
        }

        public sbyte3 xzy
        {
            get { return new sbyte3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 xzz
        {
            get { return new sbyte3(this.s0, this.s2, this.s2); }
        }

        public sbyte3 xzw
        {
            get { return new sbyte3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public sbyte3 xwx
        {
            get { return new sbyte3(this.s0, this.s3, this.s0); }
        }

        public sbyte3 xwy
        {
            get { return new sbyte3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 xwz
        {
            get { return new sbyte3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 xww
        {
            get { return new sbyte3(this.s0, this.s3, this.s3); }
        }

        public sbyte3 yxx
        {
            get { return new sbyte3(this.s1, this.s0, this.s0); }
        }

        public sbyte3 yxy
        {
            get { return new sbyte3(this.s1, this.s0, this.s1); }
        }

        public sbyte3 yxz
        {
            get { return new sbyte3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 yxw
        {
            get { return new sbyte3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public sbyte3 yyx
        {
            get { return new sbyte3(this.s1, this.s1, this.s0); }
        }

        public sbyte3 yyy
        {
            get { return new sbyte3(this.s1, this.s1, this.s1); }
        }

        public sbyte3 yyz
        {
            get { return new sbyte3(this.s1, this.s1, this.s2); }
        }

        public sbyte3 yyw
        {
            get { return new sbyte3(this.s1, this.s1, this.s3); }
        }

        public sbyte3 yzx
        {
            get { return new sbyte3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 yzy
        {
            get { return new sbyte3(this.s1, this.s2, this.s1); }
        }

        public sbyte3 yzz
        {
            get { return new sbyte3(this.s1, this.s2, this.s2); }
        }

        public sbyte3 yzw
        {
            get { return new sbyte3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public sbyte3 ywx
        {
            get { return new sbyte3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 ywy
        {
            get { return new sbyte3(this.s1, this.s3, this.s1); }
        }

        public sbyte3 ywz
        {
            get { return new sbyte3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 yww
        {
            get { return new sbyte3(this.s1, this.s3, this.s3); }
        }

        public sbyte3 zxx
        {
            get { return new sbyte3(this.s2, this.s0, this.s0); }
        }

        public sbyte3 zxy
        {
            get { return new sbyte3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 zxz
        {
            get { return new sbyte3(this.s2, this.s0, this.s2); }
        }

        public sbyte3 zxw
        {
            get { return new sbyte3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public sbyte3 zyx
        {
            get { return new sbyte3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 zyy
        {
            get { return new sbyte3(this.s2, this.s1, this.s1); }
        }

        public sbyte3 zyz
        {
            get { return new sbyte3(this.s2, this.s1, this.s2); }
        }

        public sbyte3 zyw
        {
            get { return new sbyte3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public sbyte3 zzx
        {
            get { return new sbyte3(this.s2, this.s2, this.s0); }
        }

        public sbyte3 zzy
        {
            get { return new sbyte3(this.s2, this.s2, this.s1); }
        }

        public sbyte3 zzz
        {
            get { return new sbyte3(this.s2, this.s2, this.s2); }
        }

        public sbyte3 zzw
        {
            get { return new sbyte3(this.s2, this.s2, this.s3); }
        }

        public sbyte3 zwx
        {
            get { return new sbyte3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 zwy
        {
            get { return new sbyte3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 zwz
        {
            get { return new sbyte3(this.s2, this.s3, this.s2); }
        }

        public sbyte3 zww
        {
            get { return new sbyte3(this.s2, this.s3, this.s3); }
        }

        public sbyte3 wxx
        {
            get { return new sbyte3(this.s3, this.s0, this.s0); }
        }

        public sbyte3 wxy
        {
            get { return new sbyte3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 wxz
        {
            get { return new sbyte3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 wxw
        {
            get { return new sbyte3(this.s3, this.s0, this.s3); }
        }

        public sbyte3 wyx
        {
            get { return new sbyte3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 wyy
        {
            get { return new sbyte3(this.s3, this.s1, this.s1); }
        }

        public sbyte3 wyz
        {
            get { return new sbyte3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public sbyte3 wyw
        {
            get { return new sbyte3(this.s3, this.s1, this.s3); }
        }

        public sbyte3 wzx
        {
            get { return new sbyte3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public sbyte3 wzy
        {
            get { return new sbyte3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public sbyte3 wzz
        {
            get { return new sbyte3(this.s3, this.s2, this.s2); }
        }

        public sbyte3 wzw
        {
            get { return new sbyte3(this.s3, this.s2, this.s3); }
        }

        public sbyte3 wwx
        {
            get { return new sbyte3(this.s3, this.s3, this.s0); }
        }

        public sbyte3 wwy
        {
            get { return new sbyte3(this.s3, this.s3, this.s1); }
        }

        public sbyte3 wwz
        {
            get { return new sbyte3(this.s3, this.s3, this.s2); }
        }

        public sbyte3 www
        {
            get { return new sbyte3(this.s3, this.s3, this.s3); }
        }

        public sbyte4 xxxx
        {
            get { return new sbyte4(this.s0, this.s0, this.s0, this.s0); }
        }

        public sbyte4 xxxy
        {
            get { return new sbyte4(this.s0, this.s0, this.s0, this.s1); }
        }

        public sbyte4 xxxz
        {
            get { return new sbyte4(this.s0, this.s0, this.s0, this.s2); }
        }

        public sbyte4 xxxw
        {
            get { return new sbyte4(this.s0, this.s0, this.s0, this.s3); }
        }

        public sbyte4 xxyx
        {
            get { return new sbyte4(this.s0, this.s0, this.s1, this.s0); }
        }

        public sbyte4 xxyy
        {
            get { return new sbyte4(this.s0, this.s0, this.s1, this.s1); }
        }

        public sbyte4 xxyz
        {
            get { return new sbyte4(this.s0, this.s0, this.s1, this.s2); }
        }

        public sbyte4 xxyw
        {
            get { return new sbyte4(this.s0, this.s0, this.s1, this.s3); }
        }

        public sbyte4 xxzx
        {
            get { return new sbyte4(this.s0, this.s0, this.s2, this.s0); }
        }

        public sbyte4 xxzy
        {
            get { return new sbyte4(this.s0, this.s0, this.s2, this.s1); }
        }

        public sbyte4 xxzz
        {
            get { return new sbyte4(this.s0, this.s0, this.s2, this.s2); }
        }

        public sbyte4 xxzw
        {
            get { return new sbyte4(this.s0, this.s0, this.s2, this.s3); }
        }

        public sbyte4 xxwx
        {
            get { return new sbyte4(this.s0, this.s0, this.s3, this.s0); }
        }

        public sbyte4 xxwy
        {
            get { return new sbyte4(this.s0, this.s0, this.s3, this.s1); }
        }

        public sbyte4 xxwz
        {
            get { return new sbyte4(this.s0, this.s0, this.s3, this.s2); }
        }

        public sbyte4 xxww
        {
            get { return new sbyte4(this.s0, this.s0, this.s3, this.s3); }
        }

        public sbyte4 xyxx
        {
            get { return new sbyte4(this.s0, this.s1, this.s0, this.s0); }
        }

        public sbyte4 xyxy
        {
            get { return new sbyte4(this.s0, this.s1, this.s0, this.s1); }
        }

        public sbyte4 xyxz
        {
            get { return new sbyte4(this.s0, this.s1, this.s0, this.s2); }
        }

        public sbyte4 xyxw
        {
            get { return new sbyte4(this.s0, this.s1, this.s0, this.s3); }
        }

        public sbyte4 xyyx
        {
            get { return new sbyte4(this.s0, this.s1, this.s1, this.s0); }
        }

        public sbyte4 xyyy
        {
            get { return new sbyte4(this.s0, this.s1, this.s1, this.s1); }
        }

        public sbyte4 xyyz
        {
            get { return new sbyte4(this.s0, this.s1, this.s1, this.s2); }
        }

        public sbyte4 xyyw
        {
            get { return new sbyte4(this.s0, this.s1, this.s1, this.s3); }
        }

        public sbyte4 xyzx
        {
            get { return new sbyte4(this.s0, this.s1, this.s2, this.s0); }
        }

        public sbyte4 xyzy
        {
            get { return new sbyte4(this.s0, this.s1, this.s2, this.s1); }
        }

        public sbyte4 xyzz
        {
            get { return new sbyte4(this.s0, this.s1, this.s2, this.s2); }
        }

        public sbyte4 xyzw
        {
            get { return new sbyte4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public sbyte4 xywx
        {
            get { return new sbyte4(this.s0, this.s1, this.s3, this.s0); }
        }

        public sbyte4 xywy
        {
            get { return new sbyte4(this.s0, this.s1, this.s3, this.s1); }
        }

        public sbyte4 xywz
        {
            get { return new sbyte4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public sbyte4 xyww
        {
            get { return new sbyte4(this.s0, this.s1, this.s3, this.s3); }
        }

        public sbyte4 xzxx
        {
            get { return new sbyte4(this.s0, this.s2, this.s0, this.s0); }
        }

        public sbyte4 xzxy
        {
            get { return new sbyte4(this.s0, this.s2, this.s0, this.s1); }
        }

        public sbyte4 xzxz
        {
            get { return new sbyte4(this.s0, this.s2, this.s0, this.s2); }
        }

        public sbyte4 xzxw
        {
            get { return new sbyte4(this.s0, this.s2, this.s0, this.s3); }
        }

        public sbyte4 xzyx
        {
            get { return new sbyte4(this.s0, this.s2, this.s1, this.s0); }
        }

        public sbyte4 xzyy
        {
            get { return new sbyte4(this.s0, this.s2, this.s1, this.s1); }
        }

        public sbyte4 xzyz
        {
            get { return new sbyte4(this.s0, this.s2, this.s1, this.s2); }
        }

        public sbyte4 xzyw
        {
            get { return new sbyte4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public sbyte4 xzzx
        {
            get { return new sbyte4(this.s0, this.s2, this.s2, this.s0); }
        }

        public sbyte4 xzzy
        {
            get { return new sbyte4(this.s0, this.s2, this.s2, this.s1); }
        }

        public sbyte4 xzzz
        {
            get { return new sbyte4(this.s0, this.s2, this.s2, this.s2); }
        }

        public sbyte4 xzzw
        {
            get { return new sbyte4(this.s0, this.s2, this.s2, this.s3); }
        }

        public sbyte4 xzwx
        {
            get { return new sbyte4(this.s0, this.s2, this.s3, this.s0); }
        }

        public sbyte4 xzwy
        {
            get { return new sbyte4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public sbyte4 xzwz
        {
            get { return new sbyte4(this.s0, this.s2, this.s3, this.s2); }
        }

        public sbyte4 xzww
        {
            get { return new sbyte4(this.s0, this.s2, this.s3, this.s3); }
        }

        public sbyte4 xwxx
        {
            get { return new sbyte4(this.s0, this.s3, this.s0, this.s0); }
        }

        public sbyte4 xwxy
        {
            get { return new sbyte4(this.s0, this.s3, this.s0, this.s1); }
        }

        public sbyte4 xwxz
        {
            get { return new sbyte4(this.s0, this.s3, this.s0, this.s2); }
        }

        public sbyte4 xwxw
        {
            get { return new sbyte4(this.s0, this.s3, this.s0, this.s3); }
        }

        public sbyte4 xwyx
        {
            get { return new sbyte4(this.s0, this.s3, this.s1, this.s0); }
        }

        public sbyte4 xwyy
        {
            get { return new sbyte4(this.s0, this.s3, this.s1, this.s1); }
        }

        public sbyte4 xwyz
        {
            get { return new sbyte4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public sbyte4 xwyw
        {
            get { return new sbyte4(this.s0, this.s3, this.s1, this.s3); }
        }

        public sbyte4 xwzx
        {
            get { return new sbyte4(this.s0, this.s3, this.s2, this.s0); }
        }

        public sbyte4 xwzy
        {
            get { return new sbyte4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public sbyte4 xwzz
        {
            get { return new sbyte4(this.s0, this.s3, this.s2, this.s2); }
        }

        public sbyte4 xwzw
        {
            get { return new sbyte4(this.s0, this.s3, this.s2, this.s3); }
        }

        public sbyte4 xwwx
        {
            get { return new sbyte4(this.s0, this.s3, this.s3, this.s0); }
        }

        public sbyte4 xwwy
        {
            get { return new sbyte4(this.s0, this.s3, this.s3, this.s1); }
        }

        public sbyte4 xwwz
        {
            get { return new sbyte4(this.s0, this.s3, this.s3, this.s2); }
        }

        public sbyte4 xwww
        {
            get { return new sbyte4(this.s0, this.s3, this.s3, this.s3); }
        }

        public sbyte4 yxxx
        {
            get { return new sbyte4(this.s1, this.s0, this.s0, this.s0); }
        }

        public sbyte4 yxxy
        {
            get { return new sbyte4(this.s1, this.s0, this.s0, this.s1); }
        }

        public sbyte4 yxxz
        {
            get { return new sbyte4(this.s1, this.s0, this.s0, this.s2); }
        }

        public sbyte4 yxxw
        {
            get { return new sbyte4(this.s1, this.s0, this.s0, this.s3); }
        }

        public sbyte4 yxyx
        {
            get { return new sbyte4(this.s1, this.s0, this.s1, this.s0); }
        }

        public sbyte4 yxyy
        {
            get { return new sbyte4(this.s1, this.s0, this.s1, this.s1); }
        }

        public sbyte4 yxyz
        {
            get { return new sbyte4(this.s1, this.s0, this.s1, this.s2); }
        }

        public sbyte4 yxyw
        {
            get { return new sbyte4(this.s1, this.s0, this.s1, this.s3); }
        }

        public sbyte4 yxzx
        {
            get { return new sbyte4(this.s1, this.s0, this.s2, this.s0); }
        }

        public sbyte4 yxzy
        {
            get { return new sbyte4(this.s1, this.s0, this.s2, this.s1); }
        }

        public sbyte4 yxzz
        {
            get { return new sbyte4(this.s1, this.s0, this.s2, this.s2); }
        }

        public sbyte4 yxzw
        {
            get { return new sbyte4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public sbyte4 yxwx
        {
            get { return new sbyte4(this.s1, this.s0, this.s3, this.s0); }
        }

        public sbyte4 yxwy
        {
            get { return new sbyte4(this.s1, this.s0, this.s3, this.s1); }
        }

        public sbyte4 yxwz
        {
            get { return new sbyte4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public sbyte4 yxww
        {
            get { return new sbyte4(this.s1, this.s0, this.s3, this.s3); }
        }

        public sbyte4 yyxx
        {
            get { return new sbyte4(this.s1, this.s1, this.s0, this.s0); }
        }

        public sbyte4 yyxy
        {
            get { return new sbyte4(this.s1, this.s1, this.s0, this.s1); }
        }

        public sbyte4 yyxz
        {
            get { return new sbyte4(this.s1, this.s1, this.s0, this.s2); }
        }

        public sbyte4 yyxw
        {
            get { return new sbyte4(this.s1, this.s1, this.s0, this.s3); }
        }

        public sbyte4 yyyx
        {
            get { return new sbyte4(this.s1, this.s1, this.s1, this.s0); }
        }

        public sbyte4 yyyy
        {
            get { return new sbyte4(this.s1, this.s1, this.s1, this.s1); }
        }

        public sbyte4 yyyz
        {
            get { return new sbyte4(this.s1, this.s1, this.s1, this.s2); }
        }

        public sbyte4 yyyw
        {
            get { return new sbyte4(this.s1, this.s1, this.s1, this.s3); }
        }

        public sbyte4 yyzx
        {
            get { return new sbyte4(this.s1, this.s1, this.s2, this.s0); }
        }

        public sbyte4 yyzy
        {
            get { return new sbyte4(this.s1, this.s1, this.s2, this.s1); }
        }

        public sbyte4 yyzz
        {
            get { return new sbyte4(this.s1, this.s1, this.s2, this.s2); }
        }

        public sbyte4 yyzw
        {
            get { return new sbyte4(this.s1, this.s1, this.s2, this.s3); }
        }

        public sbyte4 yywx
        {
            get { return new sbyte4(this.s1, this.s1, this.s3, this.s0); }
        }

        public sbyte4 yywy
        {
            get { return new sbyte4(this.s1, this.s1, this.s3, this.s1); }
        }

        public sbyte4 yywz
        {
            get { return new sbyte4(this.s1, this.s1, this.s3, this.s2); }
        }

        public sbyte4 yyww
        {
            get { return new sbyte4(this.s1, this.s1, this.s3, this.s3); }
        }

        public sbyte4 yzxx
        {
            get { return new sbyte4(this.s1, this.s2, this.s0, this.s0); }
        }

        public sbyte4 yzxy
        {
            get { return new sbyte4(this.s1, this.s2, this.s0, this.s1); }
        }

        public sbyte4 yzxz
        {
            get { return new sbyte4(this.s1, this.s2, this.s0, this.s2); }
        }

        public sbyte4 yzxw
        {
            get { return new sbyte4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public sbyte4 yzyx
        {
            get { return new sbyte4(this.s1, this.s2, this.s1, this.s0); }
        }

        public sbyte4 yzyy
        {
            get { return new sbyte4(this.s1, this.s2, this.s1, this.s1); }
        }

        public sbyte4 yzyz
        {
            get { return new sbyte4(this.s1, this.s2, this.s1, this.s2); }
        }

        public sbyte4 yzyw
        {
            get { return new sbyte4(this.s1, this.s2, this.s1, this.s3); }
        }

        public sbyte4 yzzx
        {
            get { return new sbyte4(this.s1, this.s2, this.s2, this.s0); }
        }

        public sbyte4 yzzy
        {
            get { return new sbyte4(this.s1, this.s2, this.s2, this.s1); }
        }

        public sbyte4 yzzz
        {
            get { return new sbyte4(this.s1, this.s2, this.s2, this.s2); }
        }

        public sbyte4 yzzw
        {
            get { return new sbyte4(this.s1, this.s2, this.s2, this.s3); }
        }

        public sbyte4 yzwx
        {
            get { return new sbyte4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public sbyte4 yzwy
        {
            get { return new sbyte4(this.s1, this.s2, this.s3, this.s1); }
        }

        public sbyte4 yzwz
        {
            get { return new sbyte4(this.s1, this.s2, this.s3, this.s2); }
        }

        public sbyte4 yzww
        {
            get { return new sbyte4(this.s1, this.s2, this.s3, this.s3); }
        }

        public sbyte4 ywxx
        {
            get { return new sbyte4(this.s1, this.s3, this.s0, this.s0); }
        }

        public sbyte4 ywxy
        {
            get { return new sbyte4(this.s1, this.s3, this.s0, this.s1); }
        }

        public sbyte4 ywxz
        {
            get { return new sbyte4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public sbyte4 ywxw
        {
            get { return new sbyte4(this.s1, this.s3, this.s0, this.s3); }
        }

        public sbyte4 ywyx
        {
            get { return new sbyte4(this.s1, this.s3, this.s1, this.s0); }
        }

        public sbyte4 ywyy
        {
            get { return new sbyte4(this.s1, this.s3, this.s1, this.s1); }
        }

        public sbyte4 ywyz
        {
            get { return new sbyte4(this.s1, this.s3, this.s1, this.s2); }
        }

        public sbyte4 ywyw
        {
            get { return new sbyte4(this.s1, this.s3, this.s1, this.s3); }
        }

        public sbyte4 ywzx
        {
            get { return new sbyte4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public sbyte4 ywzy
        {
            get { return new sbyte4(this.s1, this.s3, this.s2, this.s1); }
        }

        public sbyte4 ywzz
        {
            get { return new sbyte4(this.s1, this.s3, this.s2, this.s2); }
        }

        public sbyte4 ywzw
        {
            get { return new sbyte4(this.s1, this.s3, this.s2, this.s3); }
        }

        public sbyte4 ywwx
        {
            get { return new sbyte4(this.s1, this.s3, this.s3, this.s0); }
        }

        public sbyte4 ywwy
        {
            get { return new sbyte4(this.s1, this.s3, this.s3, this.s1); }
        }

        public sbyte4 ywwz
        {
            get { return new sbyte4(this.s1, this.s3, this.s3, this.s2); }
        }

        public sbyte4 ywww
        {
            get { return new sbyte4(this.s1, this.s3, this.s3, this.s3); }
        }

        public sbyte4 zxxx
        {
            get { return new sbyte4(this.s2, this.s0, this.s0, this.s0); }
        }

        public sbyte4 zxxy
        {
            get { return new sbyte4(this.s2, this.s0, this.s0, this.s1); }
        }

        public sbyte4 zxxz
        {
            get { return new sbyte4(this.s2, this.s0, this.s0, this.s2); }
        }

        public sbyte4 zxxw
        {
            get { return new sbyte4(this.s2, this.s0, this.s0, this.s3); }
        }

        public sbyte4 zxyx
        {
            get { return new sbyte4(this.s2, this.s0, this.s1, this.s0); }
        }

        public sbyte4 zxyy
        {
            get { return new sbyte4(this.s2, this.s0, this.s1, this.s1); }
        }

        public sbyte4 zxyz
        {
            get { return new sbyte4(this.s2, this.s0, this.s1, this.s2); }
        }

        public sbyte4 zxyw
        {
            get { return new sbyte4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public sbyte4 zxzx
        {
            get { return new sbyte4(this.s2, this.s0, this.s2, this.s0); }
        }

        public sbyte4 zxzy
        {
            get { return new sbyte4(this.s2, this.s0, this.s2, this.s1); }
        }

        public sbyte4 zxzz
        {
            get { return new sbyte4(this.s2, this.s0, this.s2, this.s2); }
        }

        public sbyte4 zxzw
        {
            get { return new sbyte4(this.s2, this.s0, this.s2, this.s3); }
        }

        public sbyte4 zxwx
        {
            get { return new sbyte4(this.s2, this.s0, this.s3, this.s0); }
        }

        public sbyte4 zxwy
        {
            get { return new sbyte4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public sbyte4 zxwz
        {
            get { return new sbyte4(this.s2, this.s0, this.s3, this.s2); }
        }

        public sbyte4 zxww
        {
            get { return new sbyte4(this.s2, this.s0, this.s3, this.s3); }
        }

        public sbyte4 zyxx
        {
            get { return new sbyte4(this.s2, this.s1, this.s0, this.s0); }
        }

        public sbyte4 zyxy
        {
            get { return new sbyte4(this.s2, this.s1, this.s0, this.s1); }
        }

        public sbyte4 zyxz
        {
            get { return new sbyte4(this.s2, this.s1, this.s0, this.s2); }
        }

        public sbyte4 zyxw
        {
            get { return new sbyte4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public sbyte4 zyyx
        {
            get { return new sbyte4(this.s2, this.s1, this.s1, this.s0); }
        }

        public sbyte4 zyyy
        {
            get { return new sbyte4(this.s2, this.s1, this.s1, this.s1); }
        }

        public sbyte4 zyyz
        {
            get { return new sbyte4(this.s2, this.s1, this.s1, this.s2); }
        }

        public sbyte4 zyyw
        {
            get { return new sbyte4(this.s2, this.s1, this.s1, this.s3); }
        }

        public sbyte4 zyzx
        {
            get { return new sbyte4(this.s2, this.s1, this.s2, this.s0); }
        }

        public sbyte4 zyzy
        {
            get { return new sbyte4(this.s2, this.s1, this.s2, this.s1); }
        }

        public sbyte4 zyzz
        {
            get { return new sbyte4(this.s2, this.s1, this.s2, this.s2); }
        }

        public sbyte4 zyzw
        {
            get { return new sbyte4(this.s2, this.s1, this.s2, this.s3); }
        }

        public sbyte4 zywx
        {
            get { return new sbyte4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public sbyte4 zywy
        {
            get { return new sbyte4(this.s2, this.s1, this.s3, this.s1); }
        }

        public sbyte4 zywz
        {
            get { return new sbyte4(this.s2, this.s1, this.s3, this.s2); }
        }

        public sbyte4 zyww
        {
            get { return new sbyte4(this.s2, this.s1, this.s3, this.s3); }
        }

        public sbyte4 zzxx
        {
            get { return new sbyte4(this.s2, this.s2, this.s0, this.s0); }
        }

        public sbyte4 zzxy
        {
            get { return new sbyte4(this.s2, this.s2, this.s0, this.s1); }
        }

        public sbyte4 zzxz
        {
            get { return new sbyte4(this.s2, this.s2, this.s0, this.s2); }
        }

        public sbyte4 zzxw
        {
            get { return new sbyte4(this.s2, this.s2, this.s0, this.s3); }
        }

        public sbyte4 zzyx
        {
            get { return new sbyte4(this.s2, this.s2, this.s1, this.s0); }
        }

        public sbyte4 zzyy
        {
            get { return new sbyte4(this.s2, this.s2, this.s1, this.s1); }
        }

        public sbyte4 zzyz
        {
            get { return new sbyte4(this.s2, this.s2, this.s1, this.s2); }
        }

        public sbyte4 zzyw
        {
            get { return new sbyte4(this.s2, this.s2, this.s1, this.s3); }
        }

        public sbyte4 zzzx
        {
            get { return new sbyte4(this.s2, this.s2, this.s2, this.s0); }
        }

        public sbyte4 zzzy
        {
            get { return new sbyte4(this.s2, this.s2, this.s2, this.s1); }
        }

        public sbyte4 zzzz
        {
            get { return new sbyte4(this.s2, this.s2, this.s2, this.s2); }
        }

        public sbyte4 zzzw
        {
            get { return new sbyte4(this.s2, this.s2, this.s2, this.s3); }
        }

        public sbyte4 zzwx
        {
            get { return new sbyte4(this.s2, this.s2, this.s3, this.s0); }
        }

        public sbyte4 zzwy
        {
            get { return new sbyte4(this.s2, this.s2, this.s3, this.s1); }
        }

        public sbyte4 zzwz
        {
            get { return new sbyte4(this.s2, this.s2, this.s3, this.s2); }
        }

        public sbyte4 zzww
        {
            get { return new sbyte4(this.s2, this.s2, this.s3, this.s3); }
        }

        public sbyte4 zwxx
        {
            get { return new sbyte4(this.s2, this.s3, this.s0, this.s0); }
        }

        public sbyte4 zwxy
        {
            get { return new sbyte4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public sbyte4 zwxz
        {
            get { return new sbyte4(this.s2, this.s3, this.s0, this.s2); }
        }

        public sbyte4 zwxw
        {
            get { return new sbyte4(this.s2, this.s3, this.s0, this.s3); }
        }

        public sbyte4 zwyx
        {
            get { return new sbyte4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public sbyte4 zwyy
        {
            get { return new sbyte4(this.s2, this.s3, this.s1, this.s1); }
        }

        public sbyte4 zwyz
        {
            get { return new sbyte4(this.s2, this.s3, this.s1, this.s2); }
        }

        public sbyte4 zwyw
        {
            get { return new sbyte4(this.s2, this.s3, this.s1, this.s3); }
        }

        public sbyte4 zwzx
        {
            get { return new sbyte4(this.s2, this.s3, this.s2, this.s0); }
        }

        public sbyte4 zwzy
        {
            get { return new sbyte4(this.s2, this.s3, this.s2, this.s1); }
        }

        public sbyte4 zwzz
        {
            get { return new sbyte4(this.s2, this.s3, this.s2, this.s2); }
        }

        public sbyte4 zwzw
        {
            get { return new sbyte4(this.s2, this.s3, this.s2, this.s3); }
        }

        public sbyte4 zwwx
        {
            get { return new sbyte4(this.s2, this.s3, this.s3, this.s0); }
        }

        public sbyte4 zwwy
        {
            get { return new sbyte4(this.s2, this.s3, this.s3, this.s1); }
        }

        public sbyte4 zwwz
        {
            get { return new sbyte4(this.s2, this.s3, this.s3, this.s2); }
        }

        public sbyte4 zwww
        {
            get { return new sbyte4(this.s2, this.s3, this.s3, this.s3); }
        }

        public sbyte4 wxxx
        {
            get { return new sbyte4(this.s3, this.s0, this.s0, this.s0); }
        }

        public sbyte4 wxxy
        {
            get { return new sbyte4(this.s3, this.s0, this.s0, this.s1); }
        }

        public sbyte4 wxxz
        {
            get { return new sbyte4(this.s3, this.s0, this.s0, this.s2); }
        }

        public sbyte4 wxxw
        {
            get { return new sbyte4(this.s3, this.s0, this.s0, this.s3); }
        }

        public sbyte4 wxyx
        {
            get { return new sbyte4(this.s3, this.s0, this.s1, this.s0); }
        }

        public sbyte4 wxyy
        {
            get { return new sbyte4(this.s3, this.s0, this.s1, this.s1); }
        }

        public sbyte4 wxyz
        {
            get { return new sbyte4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public sbyte4 wxyw
        {
            get { return new sbyte4(this.s3, this.s0, this.s1, this.s3); }
        }

        public sbyte4 wxzx
        {
            get { return new sbyte4(this.s3, this.s0, this.s2, this.s0); }
        }

        public sbyte4 wxzy
        {
            get { return new sbyte4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public sbyte4 wxzz
        {
            get { return new sbyte4(this.s3, this.s0, this.s2, this.s2); }
        }

        public sbyte4 wxzw
        {
            get { return new sbyte4(this.s3, this.s0, this.s2, this.s3); }
        }

        public sbyte4 wxwx
        {
            get { return new sbyte4(this.s3, this.s0, this.s3, this.s0); }
        }

        public sbyte4 wxwy
        {
            get { return new sbyte4(this.s3, this.s0, this.s3, this.s1); }
        }

        public sbyte4 wxwz
        {
            get { return new sbyte4(this.s3, this.s0, this.s3, this.s2); }
        }

        public sbyte4 wxww
        {
            get { return new sbyte4(this.s3, this.s0, this.s3, this.s3); }
        }

        public sbyte4 wyxx
        {
            get { return new sbyte4(this.s3, this.s1, this.s0, this.s0); }
        }

        public sbyte4 wyxy
        {
            get { return new sbyte4(this.s3, this.s1, this.s0, this.s1); }
        }

        public sbyte4 wyxz
        {
            get { return new sbyte4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public sbyte4 wyxw
        {
            get { return new sbyte4(this.s3, this.s1, this.s0, this.s3); }
        }

        public sbyte4 wyyx
        {
            get { return new sbyte4(this.s3, this.s1, this.s1, this.s0); }
        }

        public sbyte4 wyyy
        {
            get { return new sbyte4(this.s3, this.s1, this.s1, this.s1); }
        }

        public sbyte4 wyyz
        {
            get { return new sbyte4(this.s3, this.s1, this.s1, this.s2); }
        }

        public sbyte4 wyyw
        {
            get { return new sbyte4(this.s3, this.s1, this.s1, this.s3); }
        }

        public sbyte4 wyzx
        {
            get { return new sbyte4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public sbyte4 wyzy
        {
            get { return new sbyte4(this.s3, this.s1, this.s2, this.s1); }
        }

        public sbyte4 wyzz
        {
            get { return new sbyte4(this.s3, this.s1, this.s2, this.s2); }
        }

        public sbyte4 wyzw
        {
            get { return new sbyte4(this.s3, this.s1, this.s2, this.s3); }
        }

        public sbyte4 wywx
        {
            get { return new sbyte4(this.s3, this.s1, this.s3, this.s0); }
        }

        public sbyte4 wywy
        {
            get { return new sbyte4(this.s3, this.s1, this.s3, this.s1); }
        }

        public sbyte4 wywz
        {
            get { return new sbyte4(this.s3, this.s1, this.s3, this.s2); }
        }

        public sbyte4 wyww
        {
            get { return new sbyte4(this.s3, this.s1, this.s3, this.s3); }
        }

        public sbyte4 wzxx
        {
            get { return new sbyte4(this.s3, this.s2, this.s0, this.s0); }
        }

        public sbyte4 wzxy
        {
            get { return new sbyte4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public sbyte4 wzxz
        {
            get { return new sbyte4(this.s3, this.s2, this.s0, this.s2); }
        }

        public sbyte4 wzxw
        {
            get { return new sbyte4(this.s3, this.s2, this.s0, this.s3); }
        }

        public sbyte4 wzyx
        {
            get { return new sbyte4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public sbyte4 wzyy
        {
            get { return new sbyte4(this.s3, this.s2, this.s1, this.s1); }
        }

        public sbyte4 wzyz
        {
            get { return new sbyte4(this.s3, this.s2, this.s1, this.s2); }
        }

        public sbyte4 wzyw
        {
            get { return new sbyte4(this.s3, this.s2, this.s1, this.s3); }
        }

        public sbyte4 wzzx
        {
            get { return new sbyte4(this.s3, this.s2, this.s2, this.s0); }
        }

        public sbyte4 wzzy
        {
            get { return new sbyte4(this.s3, this.s2, this.s2, this.s1); }
        }

        public sbyte4 wzzz
        {
            get { return new sbyte4(this.s3, this.s2, this.s2, this.s2); }
        }

        public sbyte4 wzzw
        {
            get { return new sbyte4(this.s3, this.s2, this.s2, this.s3); }
        }

        public sbyte4 wzwx
        {
            get { return new sbyte4(this.s3, this.s2, this.s3, this.s0); }
        }

        public sbyte4 wzwy
        {
            get { return new sbyte4(this.s3, this.s2, this.s3, this.s1); }
        }

        public sbyte4 wzwz
        {
            get { return new sbyte4(this.s3, this.s2, this.s3, this.s2); }
        }

        public sbyte4 wzww
        {
            get { return new sbyte4(this.s3, this.s2, this.s3, this.s3); }
        }

        public sbyte4 wwxx
        {
            get { return new sbyte4(this.s3, this.s3, this.s0, this.s0); }
        }

        public sbyte4 wwxy
        {
            get { return new sbyte4(this.s3, this.s3, this.s0, this.s1); }
        }

        public sbyte4 wwxz
        {
            get { return new sbyte4(this.s3, this.s3, this.s0, this.s2); }
        }

        public sbyte4 wwxw
        {
            get { return new sbyte4(this.s3, this.s3, this.s0, this.s3); }
        }

        public sbyte4 wwyx
        {
            get { return new sbyte4(this.s3, this.s3, this.s1, this.s0); }
        }

        public sbyte4 wwyy
        {
            get { return new sbyte4(this.s3, this.s3, this.s1, this.s1); }
        }

        public sbyte4 wwyz
        {
            get { return new sbyte4(this.s3, this.s3, this.s1, this.s2); }
        }

        public sbyte4 wwyw
        {
            get { return new sbyte4(this.s3, this.s3, this.s1, this.s3); }
        }

        public sbyte4 wwzx
        {
            get { return new sbyte4(this.s3, this.s3, this.s2, this.s0); }
        }

        public sbyte4 wwzy
        {
            get { return new sbyte4(this.s3, this.s3, this.s2, this.s1); }
        }

        public sbyte4 wwzz
        {
            get { return new sbyte4(this.s3, this.s3, this.s2, this.s2); }
        }

        public sbyte4 wwzw
        {
            get { return new sbyte4(this.s3, this.s3, this.s2, this.s3); }
        }

        public sbyte4 wwwx
        {
            get { return new sbyte4(this.s3, this.s3, this.s3, this.s0); }
        }

        public sbyte4 wwwy
        {
            get { return new sbyte4(this.s3, this.s3, this.s3, this.s1); }
        }

        public sbyte4 wwwz
        {
            get { return new sbyte4(this.s3, this.s3, this.s3, this.s2); }
        }

        public sbyte4 wwww
        {
            get { return new sbyte4(this.s3, this.s3, this.s3, this.s3); }
        }

        public sbyte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 4; }
        }

        // IEquatable

        public bool Equals(sbyte4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is sbyte4 && Equals((sbyte4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static sbyte4 operator +(sbyte4 a, sbyte4 b) => new sbyte4((sbyte)(a.s0+b.s0), (sbyte)(a.s1+b.s1), (sbyte)(a.s2+b.s2), (sbyte)(a.s3+b.s3));

        public static sbyte4 operator -(sbyte4 a, sbyte4 b) => new sbyte4((sbyte)(a.s0-b.s0), (sbyte)(a.s1-b.s1), (sbyte)(a.s2-b.s2), (sbyte)(a.s3-b.s3));

        public static sbyte4 operator *(sbyte4 a, sbyte4 b) => new sbyte4((sbyte)(a.s0*b.s0), (sbyte)(a.s1*b.s1), (sbyte)(a.s2*b.s2), (sbyte)(a.s3*b.s3));

        public static sbyte4 operator /(sbyte4 a, sbyte4 b) => new sbyte4((sbyte)(a.s0/b.s0), (sbyte)(a.s1/b.s1), (sbyte)(a.s2/b.s2), (sbyte)(a.s3/b.s3));

        public static sbyte4 operator ==(sbyte4 a, sbyte4 b) => new sbyte4(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0, a.s3==b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator !=(sbyte4 a, sbyte4 b) => new sbyte4(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3!=b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator <(sbyte4 a, sbyte4 b) => new sbyte4(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator <=(sbyte4 a, sbyte4 b) => new sbyte4(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<=b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator >(sbyte4 a, sbyte4 b) => new sbyte4(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator >=(sbyte4 a, sbyte4 b) => new sbyte4(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>=b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator &(sbyte4 a, sbyte4 b) => new sbyte4((sbyte)(a.s0&b.s0), (sbyte)(a.s1&b.s1), (sbyte)(a.s2&b.s2), (sbyte)(a.s3&b.s3));

        public static sbyte4 operator |(sbyte4 a, sbyte4 b) => new sbyte4((sbyte)(a.s0|b.s0), (sbyte)(a.s1|b.s1), (sbyte)(a.s2|b.s2), (sbyte)(a.s3|b.s3));

        public static sbyte4 operator ^(sbyte4 a, sbyte4 b) => new sbyte4((sbyte)(a.s0^b.s0), (sbyte)(a.s1^b.s1), (sbyte)(a.s2^b.s2), (sbyte)(a.s3^b.s3));

        public static sbyte4 operator +(sbyte4 a) => a;

        public static sbyte4 operator -(sbyte4 a) => new sbyte4((sbyte)(-a.s0), (sbyte)(-a.s1), (sbyte)(-a.s2), (sbyte)(-a.s3));

        public static sbyte4 operator ~(sbyte4 a) => new sbyte4((sbyte)(~a.s0), (sbyte)(~a.s1), (sbyte)(~a.s2), (sbyte)(~a.s3));

        public static sbyte4 operator ++(sbyte4 a) => new sbyte4((sbyte)(a.s0+1), (sbyte)(a.s1+1), (sbyte)(a.s2+1), (sbyte)(a.s3+1));

        public static sbyte4 operator --(sbyte4 a) => new sbyte4((sbyte)(a.s0-1), (sbyte)(a.s1-1), (sbyte)(a.s2-1), (sbyte)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct sbyte8: IVectorType, IEquatable<sbyte8>
    {
        [FieldOffset(0)]
        public sbyte s0;
        [FieldOffset(1)]
        public sbyte s1;
        [FieldOffset(2)]
        public sbyte s2;
        [FieldOffset(3)]
        public sbyte s3;
        [FieldOffset(4)]
        public sbyte s4;
        [FieldOffset(5)]
        public sbyte s5;
        [FieldOffset(6)]
        public sbyte s6;
        [FieldOffset(7)]
        public sbyte s7;

        public sbyte8(sbyte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public sbyte8(sbyte v0, sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5, sbyte v6, sbyte v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public sbyte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 8; }
        }

        // IEquatable

        public bool Equals(sbyte8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is sbyte8 && Equals((sbyte8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static sbyte8 operator +(sbyte8 a, sbyte8 b) => new sbyte8((sbyte)(a.s0+b.s0), (sbyte)(a.s1+b.s1), (sbyte)(a.s2+b.s2), (sbyte)(a.s3+b.s3), (sbyte)(a.s4+b.s4), (sbyte)(a.s5+b.s5), (sbyte)(a.s6+b.s6), (sbyte)(a.s7+b.s7));

        public static sbyte8 operator -(sbyte8 a, sbyte8 b) => new sbyte8((sbyte)(a.s0-b.s0), (sbyte)(a.s1-b.s1), (sbyte)(a.s2-b.s2), (sbyte)(a.s3-b.s3), (sbyte)(a.s4-b.s4), (sbyte)(a.s5-b.s5), (sbyte)(a.s6-b.s6), (sbyte)(a.s7-b.s7));

        public static sbyte8 operator *(sbyte8 a, sbyte8 b) => new sbyte8((sbyte)(a.s0*b.s0), (sbyte)(a.s1*b.s1), (sbyte)(a.s2*b.s2), (sbyte)(a.s3*b.s3), (sbyte)(a.s4*b.s4), (sbyte)(a.s5*b.s5), (sbyte)(a.s6*b.s6), (sbyte)(a.s7*b.s7));

        public static sbyte8 operator /(sbyte8 a, sbyte8 b) => new sbyte8((sbyte)(a.s0/b.s0), (sbyte)(a.s1/b.s1), (sbyte)(a.s2/b.s2), (sbyte)(a.s3/b.s3), (sbyte)(a.s4/b.s4), (sbyte)(a.s5/b.s5), (sbyte)(a.s6/b.s6), (sbyte)(a.s7/b.s7));

        public static sbyte8 operator ==(sbyte8 a, sbyte8 b) => new sbyte8(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0, a.s3==b.s3 ? (sbyte)-1 : (sbyte)0, a.s4==b.s4 ? (sbyte)-1 : (sbyte)0, a.s5==b.s5 ? (sbyte)-1 : (sbyte)0, a.s6==b.s6 ? (sbyte)-1 : (sbyte)0, a.s7==b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator !=(sbyte8 a, sbyte8 b) => new sbyte8(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3!=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4!=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5!=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6!=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7!=b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator <(sbyte8 a, sbyte8 b) => new sbyte8(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator <=(sbyte8 a, sbyte8 b) => new sbyte8(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<=b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator >(sbyte8 a, sbyte8 b) => new sbyte8(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator >=(sbyte8 a, sbyte8 b) => new sbyte8(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>=b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator &(sbyte8 a, sbyte8 b) => new sbyte8((sbyte)(a.s0&b.s0), (sbyte)(a.s1&b.s1), (sbyte)(a.s2&b.s2), (sbyte)(a.s3&b.s3), (sbyte)(a.s4&b.s4), (sbyte)(a.s5&b.s5), (sbyte)(a.s6&b.s6), (sbyte)(a.s7&b.s7));

        public static sbyte8 operator |(sbyte8 a, sbyte8 b) => new sbyte8((sbyte)(a.s0|b.s0), (sbyte)(a.s1|b.s1), (sbyte)(a.s2|b.s2), (sbyte)(a.s3|b.s3), (sbyte)(a.s4|b.s4), (sbyte)(a.s5|b.s5), (sbyte)(a.s6|b.s6), (sbyte)(a.s7|b.s7));

        public static sbyte8 operator ^(sbyte8 a, sbyte8 b) => new sbyte8((sbyte)(a.s0^b.s0), (sbyte)(a.s1^b.s1), (sbyte)(a.s2^b.s2), (sbyte)(a.s3^b.s3), (sbyte)(a.s4^b.s4), (sbyte)(a.s5^b.s5), (sbyte)(a.s6^b.s6), (sbyte)(a.s7^b.s7));

        public static sbyte8 operator +(sbyte8 a) => a;

        public static sbyte8 operator -(sbyte8 a) => new sbyte8((sbyte)(-a.s0), (sbyte)(-a.s1), (sbyte)(-a.s2), (sbyte)(-a.s3), (sbyte)(-a.s4), (sbyte)(-a.s5), (sbyte)(-a.s6), (sbyte)(-a.s7));

        public static sbyte8 operator ~(sbyte8 a) => new sbyte8((sbyte)(~a.s0), (sbyte)(~a.s1), (sbyte)(~a.s2), (sbyte)(~a.s3), (sbyte)(~a.s4), (sbyte)(~a.s5), (sbyte)(~a.s6), (sbyte)(~a.s7));

        public static sbyte8 operator ++(sbyte8 a) => new sbyte8((sbyte)(a.s0+1), (sbyte)(a.s1+1), (sbyte)(a.s2+1), (sbyte)(a.s3+1), (sbyte)(a.s4+1), (sbyte)(a.s5+1), (sbyte)(a.s6+1), (sbyte)(a.s7+1));

        public static sbyte8 operator --(sbyte8 a) => new sbyte8((sbyte)(a.s0-1), (sbyte)(a.s1-1), (sbyte)(a.s2-1), (sbyte)(a.s3-1), (sbyte)(a.s4-1), (sbyte)(a.s5-1), (sbyte)(a.s6-1), (sbyte)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct sbyte16: IVectorType, IEquatable<sbyte16>
    {
        [FieldOffset(0)]
        public sbyte s0;
        [FieldOffset(1)]
        public sbyte s1;
        [FieldOffset(2)]
        public sbyte s2;
        [FieldOffset(3)]
        public sbyte s3;
        [FieldOffset(4)]
        public sbyte s4;
        [FieldOffset(5)]
        public sbyte s5;
        [FieldOffset(6)]
        public sbyte s6;
        [FieldOffset(7)]
        public sbyte s7;
        [FieldOffset(8)]
        public sbyte s8;
        [FieldOffset(9)]
        public sbyte s9;
        [FieldOffset(10)]
        public sbyte sa;
        [FieldOffset(11)]
        public sbyte sb;
        [FieldOffset(12)]
        public sbyte sc;
        [FieldOffset(13)]
        public sbyte sd;
        [FieldOffset(14)]
        public sbyte se;
        [FieldOffset(15)]
        public sbyte sf;

        public sbyte16(sbyte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public sbyte16(sbyte v0, sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5, sbyte v6, sbyte v7, sbyte v8, sbyte v9, sbyte va, sbyte vb, sbyte vc, sbyte vd, sbyte ve, sbyte vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public sbyte sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public sbyte sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public sbyte sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public sbyte sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public sbyte sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public sbyte sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public sbyte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(sbyte16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is sbyte16 && Equals((sbyte16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static sbyte16 operator +(sbyte16 a, sbyte16 b) => new sbyte16((sbyte)(a.s0+b.s0), (sbyte)(a.s1+b.s1), (sbyte)(a.s2+b.s2), (sbyte)(a.s3+b.s3), (sbyte)(a.s4+b.s4), (sbyte)(a.s5+b.s5), (sbyte)(a.s6+b.s6), (sbyte)(a.s7+b.s7), (sbyte)(a.s8+b.s8), (sbyte)(a.s9+b.s9), (sbyte)(a.sa+b.sa), (sbyte)(a.sb+b.sb), (sbyte)(a.sc+b.sc), (sbyte)(a.sd+b.sd), (sbyte)(a.se+b.se), (sbyte)(a.sf+b.sf));

        public static sbyte16 operator -(sbyte16 a, sbyte16 b) => new sbyte16((sbyte)(a.s0-b.s0), (sbyte)(a.s1-b.s1), (sbyte)(a.s2-b.s2), (sbyte)(a.s3-b.s3), (sbyte)(a.s4-b.s4), (sbyte)(a.s5-b.s5), (sbyte)(a.s6-b.s6), (sbyte)(a.s7-b.s7), (sbyte)(a.s8-b.s8), (sbyte)(a.s9-b.s9), (sbyte)(a.sa-b.sa), (sbyte)(a.sb-b.sb), (sbyte)(a.sc-b.sc), (sbyte)(a.sd-b.sd), (sbyte)(a.se-b.se), (sbyte)(a.sf-b.sf));

        public static sbyte16 operator *(sbyte16 a, sbyte16 b) => new sbyte16((sbyte)(a.s0*b.s0), (sbyte)(a.s1*b.s1), (sbyte)(a.s2*b.s2), (sbyte)(a.s3*b.s3), (sbyte)(a.s4*b.s4), (sbyte)(a.s5*b.s5), (sbyte)(a.s6*b.s6), (sbyte)(a.s7*b.s7), (sbyte)(a.s8*b.s8), (sbyte)(a.s9*b.s9), (sbyte)(a.sa*b.sa), (sbyte)(a.sb*b.sb), (sbyte)(a.sc*b.sc), (sbyte)(a.sd*b.sd), (sbyte)(a.se*b.se), (sbyte)(a.sf*b.sf));

        public static sbyte16 operator /(sbyte16 a, sbyte16 b) => new sbyte16((sbyte)(a.s0/b.s0), (sbyte)(a.s1/b.s1), (sbyte)(a.s2/b.s2), (sbyte)(a.s3/b.s3), (sbyte)(a.s4/b.s4), (sbyte)(a.s5/b.s5), (sbyte)(a.s6/b.s6), (sbyte)(a.s7/b.s7), (sbyte)(a.s8/b.s8), (sbyte)(a.s9/b.s9), (sbyte)(a.sa/b.sa), (sbyte)(a.sb/b.sb), (sbyte)(a.sc/b.sc), (sbyte)(a.sd/b.sd), (sbyte)(a.se/b.se), (sbyte)(a.sf/b.sf));

        public static sbyte16 operator ==(sbyte16 a, sbyte16 b) => new sbyte16(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0, a.s3==b.s3 ? (sbyte)-1 : (sbyte)0, a.s4==b.s4 ? (sbyte)-1 : (sbyte)0, a.s5==b.s5 ? (sbyte)-1 : (sbyte)0, a.s6==b.s6 ? (sbyte)-1 : (sbyte)0, a.s7==b.s7 ? (sbyte)-1 : (sbyte)0, a.s8==b.s8 ? (sbyte)-1 : (sbyte)0, a.s9==b.s9 ? (sbyte)-1 : (sbyte)0, a.sa==b.sa ? (sbyte)-1 : (sbyte)0, a.sb==b.sb ? (sbyte)-1 : (sbyte)0, a.sc==b.sc ? (sbyte)-1 : (sbyte)0, a.sd==b.sd ? (sbyte)-1 : (sbyte)0, a.se==b.se ? (sbyte)-1 : (sbyte)0, a.sf==b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator !=(sbyte16 a, sbyte16 b) => new sbyte16(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3!=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4!=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5!=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6!=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7!=b.s7 ? (sbyte)-1 : (sbyte)0, a.s8!=b.s8 ? (sbyte)-1 : (sbyte)0, a.s9!=b.s9 ? (sbyte)-1 : (sbyte)0, a.sa!=b.sa ? (sbyte)-1 : (sbyte)0, a.sb!=b.sb ? (sbyte)-1 : (sbyte)0, a.sc!=b.sc ? (sbyte)-1 : (sbyte)0, a.sd!=b.sd ? (sbyte)-1 : (sbyte)0, a.se!=b.se ? (sbyte)-1 : (sbyte)0, a.sf!=b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator <(sbyte16 a, sbyte16 b) => new sbyte16(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<b.s7 ? (sbyte)-1 : (sbyte)0, a.s8<b.s8 ? (sbyte)-1 : (sbyte)0, a.s9<b.s9 ? (sbyte)-1 : (sbyte)0, a.sa<b.sa ? (sbyte)-1 : (sbyte)0, a.sb<b.sb ? (sbyte)-1 : (sbyte)0, a.sc<b.sc ? (sbyte)-1 : (sbyte)0, a.sd<b.sd ? (sbyte)-1 : (sbyte)0, a.se<b.se ? (sbyte)-1 : (sbyte)0, a.sf<b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator <=(sbyte16 a, sbyte16 b) => new sbyte16(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<=b.s7 ? (sbyte)-1 : (sbyte)0, a.s8<=b.s8 ? (sbyte)-1 : (sbyte)0, a.s9<=b.s9 ? (sbyte)-1 : (sbyte)0, a.sa<=b.sa ? (sbyte)-1 : (sbyte)0, a.sb<=b.sb ? (sbyte)-1 : (sbyte)0, a.sc<=b.sc ? (sbyte)-1 : (sbyte)0, a.sd<=b.sd ? (sbyte)-1 : (sbyte)0, a.se<=b.se ? (sbyte)-1 : (sbyte)0, a.sf<=b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator >(sbyte16 a, sbyte16 b) => new sbyte16(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>b.s7 ? (sbyte)-1 : (sbyte)0, a.s8>b.s8 ? (sbyte)-1 : (sbyte)0, a.s9>b.s9 ? (sbyte)-1 : (sbyte)0, a.sa>b.sa ? (sbyte)-1 : (sbyte)0, a.sb>b.sb ? (sbyte)-1 : (sbyte)0, a.sc>b.sc ? (sbyte)-1 : (sbyte)0, a.sd>b.sd ? (sbyte)-1 : (sbyte)0, a.se>b.se ? (sbyte)-1 : (sbyte)0, a.sf>b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator >=(sbyte16 a, sbyte16 b) => new sbyte16(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>=b.s7 ? (sbyte)-1 : (sbyte)0, a.s8>=b.s8 ? (sbyte)-1 : (sbyte)0, a.s9>=b.s9 ? (sbyte)-1 : (sbyte)0, a.sa>=b.sa ? (sbyte)-1 : (sbyte)0, a.sb>=b.sb ? (sbyte)-1 : (sbyte)0, a.sc>=b.sc ? (sbyte)-1 : (sbyte)0, a.sd>=b.sd ? (sbyte)-1 : (sbyte)0, a.se>=b.se ? (sbyte)-1 : (sbyte)0, a.sf>=b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator &(sbyte16 a, sbyte16 b) => new sbyte16((sbyte)(a.s0&b.s0), (sbyte)(a.s1&b.s1), (sbyte)(a.s2&b.s2), (sbyte)(a.s3&b.s3), (sbyte)(a.s4&b.s4), (sbyte)(a.s5&b.s5), (sbyte)(a.s6&b.s6), (sbyte)(a.s7&b.s7), (sbyte)(a.s8&b.s8), (sbyte)(a.s9&b.s9), (sbyte)(a.sa&b.sa), (sbyte)(a.sb&b.sb), (sbyte)(a.sc&b.sc), (sbyte)(a.sd&b.sd), (sbyte)(a.se&b.se), (sbyte)(a.sf&b.sf));

        public static sbyte16 operator |(sbyte16 a, sbyte16 b) => new sbyte16((sbyte)(a.s0|b.s0), (sbyte)(a.s1|b.s1), (sbyte)(a.s2|b.s2), (sbyte)(a.s3|b.s3), (sbyte)(a.s4|b.s4), (sbyte)(a.s5|b.s5), (sbyte)(a.s6|b.s6), (sbyte)(a.s7|b.s7), (sbyte)(a.s8|b.s8), (sbyte)(a.s9|b.s9), (sbyte)(a.sa|b.sa), (sbyte)(a.sb|b.sb), (sbyte)(a.sc|b.sc), (sbyte)(a.sd|b.sd), (sbyte)(a.se|b.se), (sbyte)(a.sf|b.sf));

        public static sbyte16 operator ^(sbyte16 a, sbyte16 b) => new sbyte16((sbyte)(a.s0^b.s0), (sbyte)(a.s1^b.s1), (sbyte)(a.s2^b.s2), (sbyte)(a.s3^b.s3), (sbyte)(a.s4^b.s4), (sbyte)(a.s5^b.s5), (sbyte)(a.s6^b.s6), (sbyte)(a.s7^b.s7), (sbyte)(a.s8^b.s8), (sbyte)(a.s9^b.s9), (sbyte)(a.sa^b.sa), (sbyte)(a.sb^b.sb), (sbyte)(a.sc^b.sc), (sbyte)(a.sd^b.sd), (sbyte)(a.se^b.se), (sbyte)(a.sf^b.sf));

        public static sbyte16 operator +(sbyte16 a) => a;

        public static sbyte16 operator -(sbyte16 a) => new sbyte16((sbyte)(-a.s0), (sbyte)(-a.s1), (sbyte)(-a.s2), (sbyte)(-a.s3), (sbyte)(-a.s4), (sbyte)(-a.s5), (sbyte)(-a.s6), (sbyte)(-a.s7), (sbyte)(-a.s8), (sbyte)(-a.s9), (sbyte)(-a.sa), (sbyte)(-a.sb), (sbyte)(-a.sc), (sbyte)(-a.sd), (sbyte)(-a.se), (sbyte)(-a.sf));

        public static sbyte16 operator ~(sbyte16 a) => new sbyte16((sbyte)(~a.s0), (sbyte)(~a.s1), (sbyte)(~a.s2), (sbyte)(~a.s3), (sbyte)(~a.s4), (sbyte)(~a.s5), (sbyte)(~a.s6), (sbyte)(~a.s7), (sbyte)(~a.s8), (sbyte)(~a.s9), (sbyte)(~a.sa), (sbyte)(~a.sb), (sbyte)(~a.sc), (sbyte)(~a.sd), (sbyte)(~a.se), (sbyte)(~a.sf));

        public static sbyte16 operator ++(sbyte16 a) => new sbyte16((sbyte)(a.s0+1), (sbyte)(a.s1+1), (sbyte)(a.s2+1), (sbyte)(a.s3+1), (sbyte)(a.s4+1), (sbyte)(a.s5+1), (sbyte)(a.s6+1), (sbyte)(a.s7+1), (sbyte)(a.s8+1), (sbyte)(a.s9+1), (sbyte)(a.sa+1), (sbyte)(a.sb+1), (sbyte)(a.sc+1), (sbyte)(a.sd+1), (sbyte)(a.se+1), (sbyte)(a.sf+1));

        public static sbyte16 operator --(sbyte16 a) => new sbyte16((sbyte)(a.s0-1), (sbyte)(a.s1-1), (sbyte)(a.s2-1), (sbyte)(a.s3-1), (sbyte)(a.s4-1), (sbyte)(a.s5-1), (sbyte)(a.s6-1), (sbyte)(a.s7-1), (sbyte)(a.s8-1), (sbyte)(a.s9-1), (sbyte)(a.sa-1), (sbyte)(a.sb-1), (sbyte)(a.sc-1), (sbyte)(a.sd-1), (sbyte)(a.se-1), (sbyte)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct byte2: IVectorType, IEquatable<byte2>
    {
        [FieldOffset(0)]
        public byte s0;
        [FieldOffset(1)]
        public byte s1;

        public byte2(byte v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public byte2(byte2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public byte2(byte v0, byte v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public byte x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public byte y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public byte2 xx
        {
            get { return new byte2(this.s0, this.s0); }
        }

        public byte2 xy
        {
            get { return new byte2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public byte2 yx
        {
            get { return new byte2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public byte2 yy
        {
            get { return new byte2(this.s1, this.s1); }
        }

        public byte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 2; }
        }

        // IEquatable

        public bool Equals(byte2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is byte2 && Equals((byte2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static byte2 operator +(byte2 a, byte2 b) => new byte2((byte)(a.s0+b.s0), (byte)(a.s1+b.s1));

        public static byte2 operator -(byte2 a, byte2 b) => new byte2((byte)(a.s0-b.s0), (byte)(a.s1-b.s1));

        public static byte2 operator *(byte2 a, byte2 b) => new byte2((byte)(a.s0*b.s0), (byte)(a.s1*b.s1));

        public static byte2 operator /(byte2 a, byte2 b) => new byte2((byte)(a.s0/b.s0), (byte)(a.s1/b.s1));

        public static sbyte2 operator ==(byte2 a, byte2 b) => new sbyte2(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator !=(byte2 a, byte2 b) => new sbyte2(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator <(byte2 a, byte2 b) => new sbyte2(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator <=(byte2 a, byte2 b) => new sbyte2(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator >(byte2 a, byte2 b) => new sbyte2(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0);

        public static sbyte2 operator >=(byte2 a, byte2 b) => new sbyte2(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0);

        public static byte2 operator &(byte2 a, byte2 b) => new byte2((byte)(a.s0&b.s0), (byte)(a.s1&b.s1));

        public static byte2 operator |(byte2 a, byte2 b) => new byte2((byte)(a.s0|b.s0), (byte)(a.s1|b.s1));

        public static byte2 operator ^(byte2 a, byte2 b) => new byte2((byte)(a.s0^b.s0), (byte)(a.s1^b.s1));

        public static byte2 operator +(byte2 a) => a;

        public static byte2 operator ~(byte2 a) => new byte2((byte)(~a.s0), (byte)(~a.s1));

        public static byte2 operator ++(byte2 a) => new byte2((byte)(a.s0+1), (byte)(a.s1+1));

        public static byte2 operator --(byte2 a) => new byte2((byte)(a.s0-1), (byte)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=4)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct byte3: IVectorType, IEquatable<byte3>
    {
        [FieldOffset(0)]
        public byte s0;
        [FieldOffset(1)]
        public byte s1;
        [FieldOffset(2)]
        public byte s2;

        public byte3(byte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public byte3(byte3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public byte3(byte v0, byte2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public byte3(byte2 v0, byte v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public byte3(byte v0, byte v1, byte v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public byte x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public byte y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public byte z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public byte2 xx
        {
            get { return new byte2(this.s0, this.s0); }
        }

        public byte2 xy
        {
            get { return new byte2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public byte2 xz
        {
            get { return new byte2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public byte2 yx
        {
            get { return new byte2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public byte2 yy
        {
            get { return new byte2(this.s1, this.s1); }
        }

        public byte2 yz
        {
            get { return new byte2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public byte2 zx
        {
            get { return new byte2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public byte2 zy
        {
            get { return new byte2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public byte2 zz
        {
            get { return new byte2(this.s2, this.s2); }
        }

        public byte3 xxx
        {
            get { return new byte3(this.s0, this.s0, this.s0); }
        }

        public byte3 xxy
        {
            get { return new byte3(this.s0, this.s0, this.s1); }
        }

        public byte3 xxz
        {
            get { return new byte3(this.s0, this.s0, this.s2); }
        }

        public byte3 xyx
        {
            get { return new byte3(this.s0, this.s1, this.s0); }
        }

        public byte3 xyy
        {
            get { return new byte3(this.s0, this.s1, this.s1); }
        }

        public byte3 xyz
        {
            get { return new byte3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 xzx
        {
            get { return new byte3(this.s0, this.s2, this.s0); }
        }

        public byte3 xzy
        {
            get { return new byte3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 xzz
        {
            get { return new byte3(this.s0, this.s2, this.s2); }
        }

        public byte3 yxx
        {
            get { return new byte3(this.s1, this.s0, this.s0); }
        }

        public byte3 yxy
        {
            get { return new byte3(this.s1, this.s0, this.s1); }
        }

        public byte3 yxz
        {
            get { return new byte3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 yyx
        {
            get { return new byte3(this.s1, this.s1, this.s0); }
        }

        public byte3 yyy
        {
            get { return new byte3(this.s1, this.s1, this.s1); }
        }

        public byte3 yyz
        {
            get { return new byte3(this.s1, this.s1, this.s2); }
        }

        public byte3 yzx
        {
            get { return new byte3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 yzy
        {
            get { return new byte3(this.s1, this.s2, this.s1); }
        }

        public byte3 yzz
        {
            get { return new byte3(this.s1, this.s2, this.s2); }
        }

        public byte3 zxx
        {
            get { return new byte3(this.s2, this.s0, this.s0); }
        }

        public byte3 zxy
        {
            get { return new byte3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 zxz
        {
            get { return new byte3(this.s2, this.s0, this.s2); }
        }

        public byte3 zyx
        {
            get { return new byte3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 zyy
        {
            get { return new byte3(this.s2, this.s1, this.s1); }
        }

        public byte3 zyz
        {
            get { return new byte3(this.s2, this.s1, this.s2); }
        }

        public byte3 zzx
        {
            get { return new byte3(this.s2, this.s2, this.s0); }
        }

        public byte3 zzy
        {
            get { return new byte3(this.s2, this.s2, this.s1); }
        }

        public byte3 zzz
        {
            get { return new byte3(this.s2, this.s2, this.s2); }
        }

        public byte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 3; }
        }

        // IEquatable

        public bool Equals(byte3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is byte3 && Equals((byte3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static byte3 operator +(byte3 a, byte3 b) => new byte3((byte)(a.s0+b.s0), (byte)(a.s1+b.s1), (byte)(a.s2+b.s2));

        public static byte3 operator -(byte3 a, byte3 b) => new byte3((byte)(a.s0-b.s0), (byte)(a.s1-b.s1), (byte)(a.s2-b.s2));

        public static byte3 operator *(byte3 a, byte3 b) => new byte3((byte)(a.s0*b.s0), (byte)(a.s1*b.s1), (byte)(a.s2*b.s2));

        public static byte3 operator /(byte3 a, byte3 b) => new byte3((byte)(a.s0/b.s0), (byte)(a.s1/b.s1), (byte)(a.s2/b.s2));

        public static sbyte3 operator ==(byte3 a, byte3 b) => new sbyte3(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator !=(byte3 a, byte3 b) => new sbyte3(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator <(byte3 a, byte3 b) => new sbyte3(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator <=(byte3 a, byte3 b) => new sbyte3(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator >(byte3 a, byte3 b) => new sbyte3(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0);

        public static sbyte3 operator >=(byte3 a, byte3 b) => new sbyte3(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0);

        public static byte3 operator &(byte3 a, byte3 b) => new byte3((byte)(a.s0&b.s0), (byte)(a.s1&b.s1), (byte)(a.s2&b.s2));

        public static byte3 operator |(byte3 a, byte3 b) => new byte3((byte)(a.s0|b.s0), (byte)(a.s1|b.s1), (byte)(a.s2|b.s2));

        public static byte3 operator ^(byte3 a, byte3 b) => new byte3((byte)(a.s0^b.s0), (byte)(a.s1^b.s1), (byte)(a.s2^b.s2));

        public static byte3 operator +(byte3 a) => a;

        public static byte3 operator ~(byte3 a) => new byte3((byte)(~a.s0), (byte)(~a.s1), (byte)(~a.s2));

        public static byte3 operator ++(byte3 a) => new byte3((byte)(a.s0+1), (byte)(a.s1+1), (byte)(a.s2+1));

        public static byte3 operator --(byte3 a) => new byte3((byte)(a.s0-1), (byte)(a.s1-1), (byte)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct byte4: IVectorType, IEquatable<byte4>
    {
        [FieldOffset(0)]
        public byte s0;
        [FieldOffset(1)]
        public byte s1;
        [FieldOffset(2)]
        public byte s2;
        [FieldOffset(3)]
        public byte s3;

        public byte4(byte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public byte4(byte4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public byte4(byte v0, byte3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public byte4(byte2 v0, byte2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public byte4(byte3 v0, byte v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public byte4(byte v0, byte v1, byte2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public byte4(byte v0, byte2 v1, byte v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public byte4(byte2 v0, byte v1, byte v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public byte4(byte v0, byte v1, byte v2, byte v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public byte x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public byte y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public byte z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public byte w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public byte2 xx
        {
            get { return new byte2(this.s0, this.s0); }
        }

        public byte2 xy
        {
            get { return new byte2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public byte2 xz
        {
            get { return new byte2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public byte2 xw
        {
            get { return new byte2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public byte2 yx
        {
            get { return new byte2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public byte2 yy
        {
            get { return new byte2(this.s1, this.s1); }
        }

        public byte2 yz
        {
            get { return new byte2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public byte2 yw
        {
            get { return new byte2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public byte2 zx
        {
            get { return new byte2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public byte2 zy
        {
            get { return new byte2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public byte2 zz
        {
            get { return new byte2(this.s2, this.s2); }
        }

        public byte2 zw
        {
            get { return new byte2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public byte2 wx
        {
            get { return new byte2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public byte2 wy
        {
            get { return new byte2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public byte2 wz
        {
            get { return new byte2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public byte2 ww
        {
            get { return new byte2(this.s3, this.s3); }
        }

        public byte3 xxx
        {
            get { return new byte3(this.s0, this.s0, this.s0); }
        }

        public byte3 xxy
        {
            get { return new byte3(this.s0, this.s0, this.s1); }
        }

        public byte3 xxz
        {
            get { return new byte3(this.s0, this.s0, this.s2); }
        }

        public byte3 xxw
        {
            get { return new byte3(this.s0, this.s0, this.s3); }
        }

        public byte3 xyx
        {
            get { return new byte3(this.s0, this.s1, this.s0); }
        }

        public byte3 xyy
        {
            get { return new byte3(this.s0, this.s1, this.s1); }
        }

        public byte3 xyz
        {
            get { return new byte3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 xyw
        {
            get { return new byte3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public byte3 xzx
        {
            get { return new byte3(this.s0, this.s2, this.s0); }
        }

        public byte3 xzy
        {
            get { return new byte3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 xzz
        {
            get { return new byte3(this.s0, this.s2, this.s2); }
        }

        public byte3 xzw
        {
            get { return new byte3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public byte3 xwx
        {
            get { return new byte3(this.s0, this.s3, this.s0); }
        }

        public byte3 xwy
        {
            get { return new byte3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 xwz
        {
            get { return new byte3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 xww
        {
            get { return new byte3(this.s0, this.s3, this.s3); }
        }

        public byte3 yxx
        {
            get { return new byte3(this.s1, this.s0, this.s0); }
        }

        public byte3 yxy
        {
            get { return new byte3(this.s1, this.s0, this.s1); }
        }

        public byte3 yxz
        {
            get { return new byte3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 yxw
        {
            get { return new byte3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public byte3 yyx
        {
            get { return new byte3(this.s1, this.s1, this.s0); }
        }

        public byte3 yyy
        {
            get { return new byte3(this.s1, this.s1, this.s1); }
        }

        public byte3 yyz
        {
            get { return new byte3(this.s1, this.s1, this.s2); }
        }

        public byte3 yyw
        {
            get { return new byte3(this.s1, this.s1, this.s3); }
        }

        public byte3 yzx
        {
            get { return new byte3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 yzy
        {
            get { return new byte3(this.s1, this.s2, this.s1); }
        }

        public byte3 yzz
        {
            get { return new byte3(this.s1, this.s2, this.s2); }
        }

        public byte3 yzw
        {
            get { return new byte3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public byte3 ywx
        {
            get { return new byte3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 ywy
        {
            get { return new byte3(this.s1, this.s3, this.s1); }
        }

        public byte3 ywz
        {
            get { return new byte3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 yww
        {
            get { return new byte3(this.s1, this.s3, this.s3); }
        }

        public byte3 zxx
        {
            get { return new byte3(this.s2, this.s0, this.s0); }
        }

        public byte3 zxy
        {
            get { return new byte3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 zxz
        {
            get { return new byte3(this.s2, this.s0, this.s2); }
        }

        public byte3 zxw
        {
            get { return new byte3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public byte3 zyx
        {
            get { return new byte3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 zyy
        {
            get { return new byte3(this.s2, this.s1, this.s1); }
        }

        public byte3 zyz
        {
            get { return new byte3(this.s2, this.s1, this.s2); }
        }

        public byte3 zyw
        {
            get { return new byte3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public byte3 zzx
        {
            get { return new byte3(this.s2, this.s2, this.s0); }
        }

        public byte3 zzy
        {
            get { return new byte3(this.s2, this.s2, this.s1); }
        }

        public byte3 zzz
        {
            get { return new byte3(this.s2, this.s2, this.s2); }
        }

        public byte3 zzw
        {
            get { return new byte3(this.s2, this.s2, this.s3); }
        }

        public byte3 zwx
        {
            get { return new byte3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 zwy
        {
            get { return new byte3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 zwz
        {
            get { return new byte3(this.s2, this.s3, this.s2); }
        }

        public byte3 zww
        {
            get { return new byte3(this.s2, this.s3, this.s3); }
        }

        public byte3 wxx
        {
            get { return new byte3(this.s3, this.s0, this.s0); }
        }

        public byte3 wxy
        {
            get { return new byte3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 wxz
        {
            get { return new byte3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 wxw
        {
            get { return new byte3(this.s3, this.s0, this.s3); }
        }

        public byte3 wyx
        {
            get { return new byte3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 wyy
        {
            get { return new byte3(this.s3, this.s1, this.s1); }
        }

        public byte3 wyz
        {
            get { return new byte3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public byte3 wyw
        {
            get { return new byte3(this.s3, this.s1, this.s3); }
        }

        public byte3 wzx
        {
            get { return new byte3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public byte3 wzy
        {
            get { return new byte3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public byte3 wzz
        {
            get { return new byte3(this.s3, this.s2, this.s2); }
        }

        public byte3 wzw
        {
            get { return new byte3(this.s3, this.s2, this.s3); }
        }

        public byte3 wwx
        {
            get { return new byte3(this.s3, this.s3, this.s0); }
        }

        public byte3 wwy
        {
            get { return new byte3(this.s3, this.s3, this.s1); }
        }

        public byte3 wwz
        {
            get { return new byte3(this.s3, this.s3, this.s2); }
        }

        public byte3 www
        {
            get { return new byte3(this.s3, this.s3, this.s3); }
        }

        public byte4 xxxx
        {
            get { return new byte4(this.s0, this.s0, this.s0, this.s0); }
        }

        public byte4 xxxy
        {
            get { return new byte4(this.s0, this.s0, this.s0, this.s1); }
        }

        public byte4 xxxz
        {
            get { return new byte4(this.s0, this.s0, this.s0, this.s2); }
        }

        public byte4 xxxw
        {
            get { return new byte4(this.s0, this.s0, this.s0, this.s3); }
        }

        public byte4 xxyx
        {
            get { return new byte4(this.s0, this.s0, this.s1, this.s0); }
        }

        public byte4 xxyy
        {
            get { return new byte4(this.s0, this.s0, this.s1, this.s1); }
        }

        public byte4 xxyz
        {
            get { return new byte4(this.s0, this.s0, this.s1, this.s2); }
        }

        public byte4 xxyw
        {
            get { return new byte4(this.s0, this.s0, this.s1, this.s3); }
        }

        public byte4 xxzx
        {
            get { return new byte4(this.s0, this.s0, this.s2, this.s0); }
        }

        public byte4 xxzy
        {
            get { return new byte4(this.s0, this.s0, this.s2, this.s1); }
        }

        public byte4 xxzz
        {
            get { return new byte4(this.s0, this.s0, this.s2, this.s2); }
        }

        public byte4 xxzw
        {
            get { return new byte4(this.s0, this.s0, this.s2, this.s3); }
        }

        public byte4 xxwx
        {
            get { return new byte4(this.s0, this.s0, this.s3, this.s0); }
        }

        public byte4 xxwy
        {
            get { return new byte4(this.s0, this.s0, this.s3, this.s1); }
        }

        public byte4 xxwz
        {
            get { return new byte4(this.s0, this.s0, this.s3, this.s2); }
        }

        public byte4 xxww
        {
            get { return new byte4(this.s0, this.s0, this.s3, this.s3); }
        }

        public byte4 xyxx
        {
            get { return new byte4(this.s0, this.s1, this.s0, this.s0); }
        }

        public byte4 xyxy
        {
            get { return new byte4(this.s0, this.s1, this.s0, this.s1); }
        }

        public byte4 xyxz
        {
            get { return new byte4(this.s0, this.s1, this.s0, this.s2); }
        }

        public byte4 xyxw
        {
            get { return new byte4(this.s0, this.s1, this.s0, this.s3); }
        }

        public byte4 xyyx
        {
            get { return new byte4(this.s0, this.s1, this.s1, this.s0); }
        }

        public byte4 xyyy
        {
            get { return new byte4(this.s0, this.s1, this.s1, this.s1); }
        }

        public byte4 xyyz
        {
            get { return new byte4(this.s0, this.s1, this.s1, this.s2); }
        }

        public byte4 xyyw
        {
            get { return new byte4(this.s0, this.s1, this.s1, this.s3); }
        }

        public byte4 xyzx
        {
            get { return new byte4(this.s0, this.s1, this.s2, this.s0); }
        }

        public byte4 xyzy
        {
            get { return new byte4(this.s0, this.s1, this.s2, this.s1); }
        }

        public byte4 xyzz
        {
            get { return new byte4(this.s0, this.s1, this.s2, this.s2); }
        }

        public byte4 xyzw
        {
            get { return new byte4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public byte4 xywx
        {
            get { return new byte4(this.s0, this.s1, this.s3, this.s0); }
        }

        public byte4 xywy
        {
            get { return new byte4(this.s0, this.s1, this.s3, this.s1); }
        }

        public byte4 xywz
        {
            get { return new byte4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public byte4 xyww
        {
            get { return new byte4(this.s0, this.s1, this.s3, this.s3); }
        }

        public byte4 xzxx
        {
            get { return new byte4(this.s0, this.s2, this.s0, this.s0); }
        }

        public byte4 xzxy
        {
            get { return new byte4(this.s0, this.s2, this.s0, this.s1); }
        }

        public byte4 xzxz
        {
            get { return new byte4(this.s0, this.s2, this.s0, this.s2); }
        }

        public byte4 xzxw
        {
            get { return new byte4(this.s0, this.s2, this.s0, this.s3); }
        }

        public byte4 xzyx
        {
            get { return new byte4(this.s0, this.s2, this.s1, this.s0); }
        }

        public byte4 xzyy
        {
            get { return new byte4(this.s0, this.s2, this.s1, this.s1); }
        }

        public byte4 xzyz
        {
            get { return new byte4(this.s0, this.s2, this.s1, this.s2); }
        }

        public byte4 xzyw
        {
            get { return new byte4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public byte4 xzzx
        {
            get { return new byte4(this.s0, this.s2, this.s2, this.s0); }
        }

        public byte4 xzzy
        {
            get { return new byte4(this.s0, this.s2, this.s2, this.s1); }
        }

        public byte4 xzzz
        {
            get { return new byte4(this.s0, this.s2, this.s2, this.s2); }
        }

        public byte4 xzzw
        {
            get { return new byte4(this.s0, this.s2, this.s2, this.s3); }
        }

        public byte4 xzwx
        {
            get { return new byte4(this.s0, this.s2, this.s3, this.s0); }
        }

        public byte4 xzwy
        {
            get { return new byte4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public byte4 xzwz
        {
            get { return new byte4(this.s0, this.s2, this.s3, this.s2); }
        }

        public byte4 xzww
        {
            get { return new byte4(this.s0, this.s2, this.s3, this.s3); }
        }

        public byte4 xwxx
        {
            get { return new byte4(this.s0, this.s3, this.s0, this.s0); }
        }

        public byte4 xwxy
        {
            get { return new byte4(this.s0, this.s3, this.s0, this.s1); }
        }

        public byte4 xwxz
        {
            get { return new byte4(this.s0, this.s3, this.s0, this.s2); }
        }

        public byte4 xwxw
        {
            get { return new byte4(this.s0, this.s3, this.s0, this.s3); }
        }

        public byte4 xwyx
        {
            get { return new byte4(this.s0, this.s3, this.s1, this.s0); }
        }

        public byte4 xwyy
        {
            get { return new byte4(this.s0, this.s3, this.s1, this.s1); }
        }

        public byte4 xwyz
        {
            get { return new byte4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public byte4 xwyw
        {
            get { return new byte4(this.s0, this.s3, this.s1, this.s3); }
        }

        public byte4 xwzx
        {
            get { return new byte4(this.s0, this.s3, this.s2, this.s0); }
        }

        public byte4 xwzy
        {
            get { return new byte4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public byte4 xwzz
        {
            get { return new byte4(this.s0, this.s3, this.s2, this.s2); }
        }

        public byte4 xwzw
        {
            get { return new byte4(this.s0, this.s3, this.s2, this.s3); }
        }

        public byte4 xwwx
        {
            get { return new byte4(this.s0, this.s3, this.s3, this.s0); }
        }

        public byte4 xwwy
        {
            get { return new byte4(this.s0, this.s3, this.s3, this.s1); }
        }

        public byte4 xwwz
        {
            get { return new byte4(this.s0, this.s3, this.s3, this.s2); }
        }

        public byte4 xwww
        {
            get { return new byte4(this.s0, this.s3, this.s3, this.s3); }
        }

        public byte4 yxxx
        {
            get { return new byte4(this.s1, this.s0, this.s0, this.s0); }
        }

        public byte4 yxxy
        {
            get { return new byte4(this.s1, this.s0, this.s0, this.s1); }
        }

        public byte4 yxxz
        {
            get { return new byte4(this.s1, this.s0, this.s0, this.s2); }
        }

        public byte4 yxxw
        {
            get { return new byte4(this.s1, this.s0, this.s0, this.s3); }
        }

        public byte4 yxyx
        {
            get { return new byte4(this.s1, this.s0, this.s1, this.s0); }
        }

        public byte4 yxyy
        {
            get { return new byte4(this.s1, this.s0, this.s1, this.s1); }
        }

        public byte4 yxyz
        {
            get { return new byte4(this.s1, this.s0, this.s1, this.s2); }
        }

        public byte4 yxyw
        {
            get { return new byte4(this.s1, this.s0, this.s1, this.s3); }
        }

        public byte4 yxzx
        {
            get { return new byte4(this.s1, this.s0, this.s2, this.s0); }
        }

        public byte4 yxzy
        {
            get { return new byte4(this.s1, this.s0, this.s2, this.s1); }
        }

        public byte4 yxzz
        {
            get { return new byte4(this.s1, this.s0, this.s2, this.s2); }
        }

        public byte4 yxzw
        {
            get { return new byte4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public byte4 yxwx
        {
            get { return new byte4(this.s1, this.s0, this.s3, this.s0); }
        }

        public byte4 yxwy
        {
            get { return new byte4(this.s1, this.s0, this.s3, this.s1); }
        }

        public byte4 yxwz
        {
            get { return new byte4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public byte4 yxww
        {
            get { return new byte4(this.s1, this.s0, this.s3, this.s3); }
        }

        public byte4 yyxx
        {
            get { return new byte4(this.s1, this.s1, this.s0, this.s0); }
        }

        public byte4 yyxy
        {
            get { return new byte4(this.s1, this.s1, this.s0, this.s1); }
        }

        public byte4 yyxz
        {
            get { return new byte4(this.s1, this.s1, this.s0, this.s2); }
        }

        public byte4 yyxw
        {
            get { return new byte4(this.s1, this.s1, this.s0, this.s3); }
        }

        public byte4 yyyx
        {
            get { return new byte4(this.s1, this.s1, this.s1, this.s0); }
        }

        public byte4 yyyy
        {
            get { return new byte4(this.s1, this.s1, this.s1, this.s1); }
        }

        public byte4 yyyz
        {
            get { return new byte4(this.s1, this.s1, this.s1, this.s2); }
        }

        public byte4 yyyw
        {
            get { return new byte4(this.s1, this.s1, this.s1, this.s3); }
        }

        public byte4 yyzx
        {
            get { return new byte4(this.s1, this.s1, this.s2, this.s0); }
        }

        public byte4 yyzy
        {
            get { return new byte4(this.s1, this.s1, this.s2, this.s1); }
        }

        public byte4 yyzz
        {
            get { return new byte4(this.s1, this.s1, this.s2, this.s2); }
        }

        public byte4 yyzw
        {
            get { return new byte4(this.s1, this.s1, this.s2, this.s3); }
        }

        public byte4 yywx
        {
            get { return new byte4(this.s1, this.s1, this.s3, this.s0); }
        }

        public byte4 yywy
        {
            get { return new byte4(this.s1, this.s1, this.s3, this.s1); }
        }

        public byte4 yywz
        {
            get { return new byte4(this.s1, this.s1, this.s3, this.s2); }
        }

        public byte4 yyww
        {
            get { return new byte4(this.s1, this.s1, this.s3, this.s3); }
        }

        public byte4 yzxx
        {
            get { return new byte4(this.s1, this.s2, this.s0, this.s0); }
        }

        public byte4 yzxy
        {
            get { return new byte4(this.s1, this.s2, this.s0, this.s1); }
        }

        public byte4 yzxz
        {
            get { return new byte4(this.s1, this.s2, this.s0, this.s2); }
        }

        public byte4 yzxw
        {
            get { return new byte4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public byte4 yzyx
        {
            get { return new byte4(this.s1, this.s2, this.s1, this.s0); }
        }

        public byte4 yzyy
        {
            get { return new byte4(this.s1, this.s2, this.s1, this.s1); }
        }

        public byte4 yzyz
        {
            get { return new byte4(this.s1, this.s2, this.s1, this.s2); }
        }

        public byte4 yzyw
        {
            get { return new byte4(this.s1, this.s2, this.s1, this.s3); }
        }

        public byte4 yzzx
        {
            get { return new byte4(this.s1, this.s2, this.s2, this.s0); }
        }

        public byte4 yzzy
        {
            get { return new byte4(this.s1, this.s2, this.s2, this.s1); }
        }

        public byte4 yzzz
        {
            get { return new byte4(this.s1, this.s2, this.s2, this.s2); }
        }

        public byte4 yzzw
        {
            get { return new byte4(this.s1, this.s2, this.s2, this.s3); }
        }

        public byte4 yzwx
        {
            get { return new byte4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public byte4 yzwy
        {
            get { return new byte4(this.s1, this.s2, this.s3, this.s1); }
        }

        public byte4 yzwz
        {
            get { return new byte4(this.s1, this.s2, this.s3, this.s2); }
        }

        public byte4 yzww
        {
            get { return new byte4(this.s1, this.s2, this.s3, this.s3); }
        }

        public byte4 ywxx
        {
            get { return new byte4(this.s1, this.s3, this.s0, this.s0); }
        }

        public byte4 ywxy
        {
            get { return new byte4(this.s1, this.s3, this.s0, this.s1); }
        }

        public byte4 ywxz
        {
            get { return new byte4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public byte4 ywxw
        {
            get { return new byte4(this.s1, this.s3, this.s0, this.s3); }
        }

        public byte4 ywyx
        {
            get { return new byte4(this.s1, this.s3, this.s1, this.s0); }
        }

        public byte4 ywyy
        {
            get { return new byte4(this.s1, this.s3, this.s1, this.s1); }
        }

        public byte4 ywyz
        {
            get { return new byte4(this.s1, this.s3, this.s1, this.s2); }
        }

        public byte4 ywyw
        {
            get { return new byte4(this.s1, this.s3, this.s1, this.s3); }
        }

        public byte4 ywzx
        {
            get { return new byte4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public byte4 ywzy
        {
            get { return new byte4(this.s1, this.s3, this.s2, this.s1); }
        }

        public byte4 ywzz
        {
            get { return new byte4(this.s1, this.s3, this.s2, this.s2); }
        }

        public byte4 ywzw
        {
            get { return new byte4(this.s1, this.s3, this.s2, this.s3); }
        }

        public byte4 ywwx
        {
            get { return new byte4(this.s1, this.s3, this.s3, this.s0); }
        }

        public byte4 ywwy
        {
            get { return new byte4(this.s1, this.s3, this.s3, this.s1); }
        }

        public byte4 ywwz
        {
            get { return new byte4(this.s1, this.s3, this.s3, this.s2); }
        }

        public byte4 ywww
        {
            get { return new byte4(this.s1, this.s3, this.s3, this.s3); }
        }

        public byte4 zxxx
        {
            get { return new byte4(this.s2, this.s0, this.s0, this.s0); }
        }

        public byte4 zxxy
        {
            get { return new byte4(this.s2, this.s0, this.s0, this.s1); }
        }

        public byte4 zxxz
        {
            get { return new byte4(this.s2, this.s0, this.s0, this.s2); }
        }

        public byte4 zxxw
        {
            get { return new byte4(this.s2, this.s0, this.s0, this.s3); }
        }

        public byte4 zxyx
        {
            get { return new byte4(this.s2, this.s0, this.s1, this.s0); }
        }

        public byte4 zxyy
        {
            get { return new byte4(this.s2, this.s0, this.s1, this.s1); }
        }

        public byte4 zxyz
        {
            get { return new byte4(this.s2, this.s0, this.s1, this.s2); }
        }

        public byte4 zxyw
        {
            get { return new byte4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public byte4 zxzx
        {
            get { return new byte4(this.s2, this.s0, this.s2, this.s0); }
        }

        public byte4 zxzy
        {
            get { return new byte4(this.s2, this.s0, this.s2, this.s1); }
        }

        public byte4 zxzz
        {
            get { return new byte4(this.s2, this.s0, this.s2, this.s2); }
        }

        public byte4 zxzw
        {
            get { return new byte4(this.s2, this.s0, this.s2, this.s3); }
        }

        public byte4 zxwx
        {
            get { return new byte4(this.s2, this.s0, this.s3, this.s0); }
        }

        public byte4 zxwy
        {
            get { return new byte4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public byte4 zxwz
        {
            get { return new byte4(this.s2, this.s0, this.s3, this.s2); }
        }

        public byte4 zxww
        {
            get { return new byte4(this.s2, this.s0, this.s3, this.s3); }
        }

        public byte4 zyxx
        {
            get { return new byte4(this.s2, this.s1, this.s0, this.s0); }
        }

        public byte4 zyxy
        {
            get { return new byte4(this.s2, this.s1, this.s0, this.s1); }
        }

        public byte4 zyxz
        {
            get { return new byte4(this.s2, this.s1, this.s0, this.s2); }
        }

        public byte4 zyxw
        {
            get { return new byte4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public byte4 zyyx
        {
            get { return new byte4(this.s2, this.s1, this.s1, this.s0); }
        }

        public byte4 zyyy
        {
            get { return new byte4(this.s2, this.s1, this.s1, this.s1); }
        }

        public byte4 zyyz
        {
            get { return new byte4(this.s2, this.s1, this.s1, this.s2); }
        }

        public byte4 zyyw
        {
            get { return new byte4(this.s2, this.s1, this.s1, this.s3); }
        }

        public byte4 zyzx
        {
            get { return new byte4(this.s2, this.s1, this.s2, this.s0); }
        }

        public byte4 zyzy
        {
            get { return new byte4(this.s2, this.s1, this.s2, this.s1); }
        }

        public byte4 zyzz
        {
            get { return new byte4(this.s2, this.s1, this.s2, this.s2); }
        }

        public byte4 zyzw
        {
            get { return new byte4(this.s2, this.s1, this.s2, this.s3); }
        }

        public byte4 zywx
        {
            get { return new byte4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public byte4 zywy
        {
            get { return new byte4(this.s2, this.s1, this.s3, this.s1); }
        }

        public byte4 zywz
        {
            get { return new byte4(this.s2, this.s1, this.s3, this.s2); }
        }

        public byte4 zyww
        {
            get { return new byte4(this.s2, this.s1, this.s3, this.s3); }
        }

        public byte4 zzxx
        {
            get { return new byte4(this.s2, this.s2, this.s0, this.s0); }
        }

        public byte4 zzxy
        {
            get { return new byte4(this.s2, this.s2, this.s0, this.s1); }
        }

        public byte4 zzxz
        {
            get { return new byte4(this.s2, this.s2, this.s0, this.s2); }
        }

        public byte4 zzxw
        {
            get { return new byte4(this.s2, this.s2, this.s0, this.s3); }
        }

        public byte4 zzyx
        {
            get { return new byte4(this.s2, this.s2, this.s1, this.s0); }
        }

        public byte4 zzyy
        {
            get { return new byte4(this.s2, this.s2, this.s1, this.s1); }
        }

        public byte4 zzyz
        {
            get { return new byte4(this.s2, this.s2, this.s1, this.s2); }
        }

        public byte4 zzyw
        {
            get { return new byte4(this.s2, this.s2, this.s1, this.s3); }
        }

        public byte4 zzzx
        {
            get { return new byte4(this.s2, this.s2, this.s2, this.s0); }
        }

        public byte4 zzzy
        {
            get { return new byte4(this.s2, this.s2, this.s2, this.s1); }
        }

        public byte4 zzzz
        {
            get { return new byte4(this.s2, this.s2, this.s2, this.s2); }
        }

        public byte4 zzzw
        {
            get { return new byte4(this.s2, this.s2, this.s2, this.s3); }
        }

        public byte4 zzwx
        {
            get { return new byte4(this.s2, this.s2, this.s3, this.s0); }
        }

        public byte4 zzwy
        {
            get { return new byte4(this.s2, this.s2, this.s3, this.s1); }
        }

        public byte4 zzwz
        {
            get { return new byte4(this.s2, this.s2, this.s3, this.s2); }
        }

        public byte4 zzww
        {
            get { return new byte4(this.s2, this.s2, this.s3, this.s3); }
        }

        public byte4 zwxx
        {
            get { return new byte4(this.s2, this.s3, this.s0, this.s0); }
        }

        public byte4 zwxy
        {
            get { return new byte4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public byte4 zwxz
        {
            get { return new byte4(this.s2, this.s3, this.s0, this.s2); }
        }

        public byte4 zwxw
        {
            get { return new byte4(this.s2, this.s3, this.s0, this.s3); }
        }

        public byte4 zwyx
        {
            get { return new byte4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public byte4 zwyy
        {
            get { return new byte4(this.s2, this.s3, this.s1, this.s1); }
        }

        public byte4 zwyz
        {
            get { return new byte4(this.s2, this.s3, this.s1, this.s2); }
        }

        public byte4 zwyw
        {
            get { return new byte4(this.s2, this.s3, this.s1, this.s3); }
        }

        public byte4 zwzx
        {
            get { return new byte4(this.s2, this.s3, this.s2, this.s0); }
        }

        public byte4 zwzy
        {
            get { return new byte4(this.s2, this.s3, this.s2, this.s1); }
        }

        public byte4 zwzz
        {
            get { return new byte4(this.s2, this.s3, this.s2, this.s2); }
        }

        public byte4 zwzw
        {
            get { return new byte4(this.s2, this.s3, this.s2, this.s3); }
        }

        public byte4 zwwx
        {
            get { return new byte4(this.s2, this.s3, this.s3, this.s0); }
        }

        public byte4 zwwy
        {
            get { return new byte4(this.s2, this.s3, this.s3, this.s1); }
        }

        public byte4 zwwz
        {
            get { return new byte4(this.s2, this.s3, this.s3, this.s2); }
        }

        public byte4 zwww
        {
            get { return new byte4(this.s2, this.s3, this.s3, this.s3); }
        }

        public byte4 wxxx
        {
            get { return new byte4(this.s3, this.s0, this.s0, this.s0); }
        }

        public byte4 wxxy
        {
            get { return new byte4(this.s3, this.s0, this.s0, this.s1); }
        }

        public byte4 wxxz
        {
            get { return new byte4(this.s3, this.s0, this.s0, this.s2); }
        }

        public byte4 wxxw
        {
            get { return new byte4(this.s3, this.s0, this.s0, this.s3); }
        }

        public byte4 wxyx
        {
            get { return new byte4(this.s3, this.s0, this.s1, this.s0); }
        }

        public byte4 wxyy
        {
            get { return new byte4(this.s3, this.s0, this.s1, this.s1); }
        }

        public byte4 wxyz
        {
            get { return new byte4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public byte4 wxyw
        {
            get { return new byte4(this.s3, this.s0, this.s1, this.s3); }
        }

        public byte4 wxzx
        {
            get { return new byte4(this.s3, this.s0, this.s2, this.s0); }
        }

        public byte4 wxzy
        {
            get { return new byte4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public byte4 wxzz
        {
            get { return new byte4(this.s3, this.s0, this.s2, this.s2); }
        }

        public byte4 wxzw
        {
            get { return new byte4(this.s3, this.s0, this.s2, this.s3); }
        }

        public byte4 wxwx
        {
            get { return new byte4(this.s3, this.s0, this.s3, this.s0); }
        }

        public byte4 wxwy
        {
            get { return new byte4(this.s3, this.s0, this.s3, this.s1); }
        }

        public byte4 wxwz
        {
            get { return new byte4(this.s3, this.s0, this.s3, this.s2); }
        }

        public byte4 wxww
        {
            get { return new byte4(this.s3, this.s0, this.s3, this.s3); }
        }

        public byte4 wyxx
        {
            get { return new byte4(this.s3, this.s1, this.s0, this.s0); }
        }

        public byte4 wyxy
        {
            get { return new byte4(this.s3, this.s1, this.s0, this.s1); }
        }

        public byte4 wyxz
        {
            get { return new byte4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public byte4 wyxw
        {
            get { return new byte4(this.s3, this.s1, this.s0, this.s3); }
        }

        public byte4 wyyx
        {
            get { return new byte4(this.s3, this.s1, this.s1, this.s0); }
        }

        public byte4 wyyy
        {
            get { return new byte4(this.s3, this.s1, this.s1, this.s1); }
        }

        public byte4 wyyz
        {
            get { return new byte4(this.s3, this.s1, this.s1, this.s2); }
        }

        public byte4 wyyw
        {
            get { return new byte4(this.s3, this.s1, this.s1, this.s3); }
        }

        public byte4 wyzx
        {
            get { return new byte4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public byte4 wyzy
        {
            get { return new byte4(this.s3, this.s1, this.s2, this.s1); }
        }

        public byte4 wyzz
        {
            get { return new byte4(this.s3, this.s1, this.s2, this.s2); }
        }

        public byte4 wyzw
        {
            get { return new byte4(this.s3, this.s1, this.s2, this.s3); }
        }

        public byte4 wywx
        {
            get { return new byte4(this.s3, this.s1, this.s3, this.s0); }
        }

        public byte4 wywy
        {
            get { return new byte4(this.s3, this.s1, this.s3, this.s1); }
        }

        public byte4 wywz
        {
            get { return new byte4(this.s3, this.s1, this.s3, this.s2); }
        }

        public byte4 wyww
        {
            get { return new byte4(this.s3, this.s1, this.s3, this.s3); }
        }

        public byte4 wzxx
        {
            get { return new byte4(this.s3, this.s2, this.s0, this.s0); }
        }

        public byte4 wzxy
        {
            get { return new byte4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public byte4 wzxz
        {
            get { return new byte4(this.s3, this.s2, this.s0, this.s2); }
        }

        public byte4 wzxw
        {
            get { return new byte4(this.s3, this.s2, this.s0, this.s3); }
        }

        public byte4 wzyx
        {
            get { return new byte4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public byte4 wzyy
        {
            get { return new byte4(this.s3, this.s2, this.s1, this.s1); }
        }

        public byte4 wzyz
        {
            get { return new byte4(this.s3, this.s2, this.s1, this.s2); }
        }

        public byte4 wzyw
        {
            get { return new byte4(this.s3, this.s2, this.s1, this.s3); }
        }

        public byte4 wzzx
        {
            get { return new byte4(this.s3, this.s2, this.s2, this.s0); }
        }

        public byte4 wzzy
        {
            get { return new byte4(this.s3, this.s2, this.s2, this.s1); }
        }

        public byte4 wzzz
        {
            get { return new byte4(this.s3, this.s2, this.s2, this.s2); }
        }

        public byte4 wzzw
        {
            get { return new byte4(this.s3, this.s2, this.s2, this.s3); }
        }

        public byte4 wzwx
        {
            get { return new byte4(this.s3, this.s2, this.s3, this.s0); }
        }

        public byte4 wzwy
        {
            get { return new byte4(this.s3, this.s2, this.s3, this.s1); }
        }

        public byte4 wzwz
        {
            get { return new byte4(this.s3, this.s2, this.s3, this.s2); }
        }

        public byte4 wzww
        {
            get { return new byte4(this.s3, this.s2, this.s3, this.s3); }
        }

        public byte4 wwxx
        {
            get { return new byte4(this.s3, this.s3, this.s0, this.s0); }
        }

        public byte4 wwxy
        {
            get { return new byte4(this.s3, this.s3, this.s0, this.s1); }
        }

        public byte4 wwxz
        {
            get { return new byte4(this.s3, this.s3, this.s0, this.s2); }
        }

        public byte4 wwxw
        {
            get { return new byte4(this.s3, this.s3, this.s0, this.s3); }
        }

        public byte4 wwyx
        {
            get { return new byte4(this.s3, this.s3, this.s1, this.s0); }
        }

        public byte4 wwyy
        {
            get { return new byte4(this.s3, this.s3, this.s1, this.s1); }
        }

        public byte4 wwyz
        {
            get { return new byte4(this.s3, this.s3, this.s1, this.s2); }
        }

        public byte4 wwyw
        {
            get { return new byte4(this.s3, this.s3, this.s1, this.s3); }
        }

        public byte4 wwzx
        {
            get { return new byte4(this.s3, this.s3, this.s2, this.s0); }
        }

        public byte4 wwzy
        {
            get { return new byte4(this.s3, this.s3, this.s2, this.s1); }
        }

        public byte4 wwzz
        {
            get { return new byte4(this.s3, this.s3, this.s2, this.s2); }
        }

        public byte4 wwzw
        {
            get { return new byte4(this.s3, this.s3, this.s2, this.s3); }
        }

        public byte4 wwwx
        {
            get { return new byte4(this.s3, this.s3, this.s3, this.s0); }
        }

        public byte4 wwwy
        {
            get { return new byte4(this.s3, this.s3, this.s3, this.s1); }
        }

        public byte4 wwwz
        {
            get { return new byte4(this.s3, this.s3, this.s3, this.s2); }
        }

        public byte4 wwww
        {
            get { return new byte4(this.s3, this.s3, this.s3, this.s3); }
        }

        public byte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 4; }
        }

        // IEquatable

        public bool Equals(byte4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is byte4 && Equals((byte4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static byte4 operator +(byte4 a, byte4 b) => new byte4((byte)(a.s0+b.s0), (byte)(a.s1+b.s1), (byte)(a.s2+b.s2), (byte)(a.s3+b.s3));

        public static byte4 operator -(byte4 a, byte4 b) => new byte4((byte)(a.s0-b.s0), (byte)(a.s1-b.s1), (byte)(a.s2-b.s2), (byte)(a.s3-b.s3));

        public static byte4 operator *(byte4 a, byte4 b) => new byte4((byte)(a.s0*b.s0), (byte)(a.s1*b.s1), (byte)(a.s2*b.s2), (byte)(a.s3*b.s3));

        public static byte4 operator /(byte4 a, byte4 b) => new byte4((byte)(a.s0/b.s0), (byte)(a.s1/b.s1), (byte)(a.s2/b.s2), (byte)(a.s3/b.s3));

        public static sbyte4 operator ==(byte4 a, byte4 b) => new sbyte4(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0, a.s3==b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator !=(byte4 a, byte4 b) => new sbyte4(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3!=b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator <(byte4 a, byte4 b) => new sbyte4(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator <=(byte4 a, byte4 b) => new sbyte4(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<=b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator >(byte4 a, byte4 b) => new sbyte4(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>b.s3 ? (sbyte)-1 : (sbyte)0);

        public static sbyte4 operator >=(byte4 a, byte4 b) => new sbyte4(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>=b.s3 ? (sbyte)-1 : (sbyte)0);

        public static byte4 operator &(byte4 a, byte4 b) => new byte4((byte)(a.s0&b.s0), (byte)(a.s1&b.s1), (byte)(a.s2&b.s2), (byte)(a.s3&b.s3));

        public static byte4 operator |(byte4 a, byte4 b) => new byte4((byte)(a.s0|b.s0), (byte)(a.s1|b.s1), (byte)(a.s2|b.s2), (byte)(a.s3|b.s3));

        public static byte4 operator ^(byte4 a, byte4 b) => new byte4((byte)(a.s0^b.s0), (byte)(a.s1^b.s1), (byte)(a.s2^b.s2), (byte)(a.s3^b.s3));

        public static byte4 operator +(byte4 a) => a;

        public static byte4 operator ~(byte4 a) => new byte4((byte)(~a.s0), (byte)(~a.s1), (byte)(~a.s2), (byte)(~a.s3));

        public static byte4 operator ++(byte4 a) => new byte4((byte)(a.s0+1), (byte)(a.s1+1), (byte)(a.s2+1), (byte)(a.s3+1));

        public static byte4 operator --(byte4 a) => new byte4((byte)(a.s0-1), (byte)(a.s1-1), (byte)(a.s2-1), (byte)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct byte8: IVectorType, IEquatable<byte8>
    {
        [FieldOffset(0)]
        public byte s0;
        [FieldOffset(1)]
        public byte s1;
        [FieldOffset(2)]
        public byte s2;
        [FieldOffset(3)]
        public byte s3;
        [FieldOffset(4)]
        public byte s4;
        [FieldOffset(5)]
        public byte s5;
        [FieldOffset(6)]
        public byte s6;
        [FieldOffset(7)]
        public byte s7;

        public byte8(byte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public byte8(byte v0, byte v1, byte v2, byte v3, byte v4, byte v5, byte v6, byte v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public byte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 8; }
        }

        // IEquatable

        public bool Equals(byte8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is byte8 && Equals((byte8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static byte8 operator +(byte8 a, byte8 b) => new byte8((byte)(a.s0+b.s0), (byte)(a.s1+b.s1), (byte)(a.s2+b.s2), (byte)(a.s3+b.s3), (byte)(a.s4+b.s4), (byte)(a.s5+b.s5), (byte)(a.s6+b.s6), (byte)(a.s7+b.s7));

        public static byte8 operator -(byte8 a, byte8 b) => new byte8((byte)(a.s0-b.s0), (byte)(a.s1-b.s1), (byte)(a.s2-b.s2), (byte)(a.s3-b.s3), (byte)(a.s4-b.s4), (byte)(a.s5-b.s5), (byte)(a.s6-b.s6), (byte)(a.s7-b.s7));

        public static byte8 operator *(byte8 a, byte8 b) => new byte8((byte)(a.s0*b.s0), (byte)(a.s1*b.s1), (byte)(a.s2*b.s2), (byte)(a.s3*b.s3), (byte)(a.s4*b.s4), (byte)(a.s5*b.s5), (byte)(a.s6*b.s6), (byte)(a.s7*b.s7));

        public static byte8 operator /(byte8 a, byte8 b) => new byte8((byte)(a.s0/b.s0), (byte)(a.s1/b.s1), (byte)(a.s2/b.s2), (byte)(a.s3/b.s3), (byte)(a.s4/b.s4), (byte)(a.s5/b.s5), (byte)(a.s6/b.s6), (byte)(a.s7/b.s7));

        public static sbyte8 operator ==(byte8 a, byte8 b) => new sbyte8(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0, a.s3==b.s3 ? (sbyte)-1 : (sbyte)0, a.s4==b.s4 ? (sbyte)-1 : (sbyte)0, a.s5==b.s5 ? (sbyte)-1 : (sbyte)0, a.s6==b.s6 ? (sbyte)-1 : (sbyte)0, a.s7==b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator !=(byte8 a, byte8 b) => new sbyte8(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3!=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4!=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5!=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6!=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7!=b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator <(byte8 a, byte8 b) => new sbyte8(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator <=(byte8 a, byte8 b) => new sbyte8(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<=b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator >(byte8 a, byte8 b) => new sbyte8(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>b.s7 ? (sbyte)-1 : (sbyte)0);

        public static sbyte8 operator >=(byte8 a, byte8 b) => new sbyte8(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>=b.s7 ? (sbyte)-1 : (sbyte)0);

        public static byte8 operator &(byte8 a, byte8 b) => new byte8((byte)(a.s0&b.s0), (byte)(a.s1&b.s1), (byte)(a.s2&b.s2), (byte)(a.s3&b.s3), (byte)(a.s4&b.s4), (byte)(a.s5&b.s5), (byte)(a.s6&b.s6), (byte)(a.s7&b.s7));

        public static byte8 operator |(byte8 a, byte8 b) => new byte8((byte)(a.s0|b.s0), (byte)(a.s1|b.s1), (byte)(a.s2|b.s2), (byte)(a.s3|b.s3), (byte)(a.s4|b.s4), (byte)(a.s5|b.s5), (byte)(a.s6|b.s6), (byte)(a.s7|b.s7));

        public static byte8 operator ^(byte8 a, byte8 b) => new byte8((byte)(a.s0^b.s0), (byte)(a.s1^b.s1), (byte)(a.s2^b.s2), (byte)(a.s3^b.s3), (byte)(a.s4^b.s4), (byte)(a.s5^b.s5), (byte)(a.s6^b.s6), (byte)(a.s7^b.s7));

        public static byte8 operator +(byte8 a) => a;

        public static byte8 operator ~(byte8 a) => new byte8((byte)(~a.s0), (byte)(~a.s1), (byte)(~a.s2), (byte)(~a.s3), (byte)(~a.s4), (byte)(~a.s5), (byte)(~a.s6), (byte)(~a.s7));

        public static byte8 operator ++(byte8 a) => new byte8((byte)(a.s0+1), (byte)(a.s1+1), (byte)(a.s2+1), (byte)(a.s3+1), (byte)(a.s4+1), (byte)(a.s5+1), (byte)(a.s6+1), (byte)(a.s7+1));

        public static byte8 operator --(byte8 a) => new byte8((byte)(a.s0-1), (byte)(a.s1-1), (byte)(a.s2-1), (byte)(a.s3-1), (byte)(a.s4-1), (byte)(a.s5-1), (byte)(a.s6-1), (byte)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct byte16: IVectorType, IEquatable<byte16>
    {
        [FieldOffset(0)]
        public byte s0;
        [FieldOffset(1)]
        public byte s1;
        [FieldOffset(2)]
        public byte s2;
        [FieldOffset(3)]
        public byte s3;
        [FieldOffset(4)]
        public byte s4;
        [FieldOffset(5)]
        public byte s5;
        [FieldOffset(6)]
        public byte s6;
        [FieldOffset(7)]
        public byte s7;
        [FieldOffset(8)]
        public byte s8;
        [FieldOffset(9)]
        public byte s9;
        [FieldOffset(10)]
        public byte sa;
        [FieldOffset(11)]
        public byte sb;
        [FieldOffset(12)]
        public byte sc;
        [FieldOffset(13)]
        public byte sd;
        [FieldOffset(14)]
        public byte se;
        [FieldOffset(15)]
        public byte sf;

        public byte16(byte v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public byte16(byte v0, byte v1, byte v2, byte v3, byte v4, byte v5, byte v6, byte v7, byte v8, byte v9, byte va, byte vb, byte vc, byte vd, byte ve, byte vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public byte sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public byte sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public byte sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public byte sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public byte sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public byte sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public byte this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(byte16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is byte16 && Equals((byte16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static byte16 operator +(byte16 a, byte16 b) => new byte16((byte)(a.s0+b.s0), (byte)(a.s1+b.s1), (byte)(a.s2+b.s2), (byte)(a.s3+b.s3), (byte)(a.s4+b.s4), (byte)(a.s5+b.s5), (byte)(a.s6+b.s6), (byte)(a.s7+b.s7), (byte)(a.s8+b.s8), (byte)(a.s9+b.s9), (byte)(a.sa+b.sa), (byte)(a.sb+b.sb), (byte)(a.sc+b.sc), (byte)(a.sd+b.sd), (byte)(a.se+b.se), (byte)(a.sf+b.sf));

        public static byte16 operator -(byte16 a, byte16 b) => new byte16((byte)(a.s0-b.s0), (byte)(a.s1-b.s1), (byte)(a.s2-b.s2), (byte)(a.s3-b.s3), (byte)(a.s4-b.s4), (byte)(a.s5-b.s5), (byte)(a.s6-b.s6), (byte)(a.s7-b.s7), (byte)(a.s8-b.s8), (byte)(a.s9-b.s9), (byte)(a.sa-b.sa), (byte)(a.sb-b.sb), (byte)(a.sc-b.sc), (byte)(a.sd-b.sd), (byte)(a.se-b.se), (byte)(a.sf-b.sf));

        public static byte16 operator *(byte16 a, byte16 b) => new byte16((byte)(a.s0*b.s0), (byte)(a.s1*b.s1), (byte)(a.s2*b.s2), (byte)(a.s3*b.s3), (byte)(a.s4*b.s4), (byte)(a.s5*b.s5), (byte)(a.s6*b.s6), (byte)(a.s7*b.s7), (byte)(a.s8*b.s8), (byte)(a.s9*b.s9), (byte)(a.sa*b.sa), (byte)(a.sb*b.sb), (byte)(a.sc*b.sc), (byte)(a.sd*b.sd), (byte)(a.se*b.se), (byte)(a.sf*b.sf));

        public static byte16 operator /(byte16 a, byte16 b) => new byte16((byte)(a.s0/b.s0), (byte)(a.s1/b.s1), (byte)(a.s2/b.s2), (byte)(a.s3/b.s3), (byte)(a.s4/b.s4), (byte)(a.s5/b.s5), (byte)(a.s6/b.s6), (byte)(a.s7/b.s7), (byte)(a.s8/b.s8), (byte)(a.s9/b.s9), (byte)(a.sa/b.sa), (byte)(a.sb/b.sb), (byte)(a.sc/b.sc), (byte)(a.sd/b.sd), (byte)(a.se/b.se), (byte)(a.sf/b.sf));

        public static sbyte16 operator ==(byte16 a, byte16 b) => new sbyte16(a.s0==b.s0 ? (sbyte)-1 : (sbyte)0, a.s1==b.s1 ? (sbyte)-1 : (sbyte)0, a.s2==b.s2 ? (sbyte)-1 : (sbyte)0, a.s3==b.s3 ? (sbyte)-1 : (sbyte)0, a.s4==b.s4 ? (sbyte)-1 : (sbyte)0, a.s5==b.s5 ? (sbyte)-1 : (sbyte)0, a.s6==b.s6 ? (sbyte)-1 : (sbyte)0, a.s7==b.s7 ? (sbyte)-1 : (sbyte)0, a.s8==b.s8 ? (sbyte)-1 : (sbyte)0, a.s9==b.s9 ? (sbyte)-1 : (sbyte)0, a.sa==b.sa ? (sbyte)-1 : (sbyte)0, a.sb==b.sb ? (sbyte)-1 : (sbyte)0, a.sc==b.sc ? (sbyte)-1 : (sbyte)0, a.sd==b.sd ? (sbyte)-1 : (sbyte)0, a.se==b.se ? (sbyte)-1 : (sbyte)0, a.sf==b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator !=(byte16 a, byte16 b) => new sbyte16(a.s0!=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1!=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2!=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3!=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4!=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5!=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6!=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7!=b.s7 ? (sbyte)-1 : (sbyte)0, a.s8!=b.s8 ? (sbyte)-1 : (sbyte)0, a.s9!=b.s9 ? (sbyte)-1 : (sbyte)0, a.sa!=b.sa ? (sbyte)-1 : (sbyte)0, a.sb!=b.sb ? (sbyte)-1 : (sbyte)0, a.sc!=b.sc ? (sbyte)-1 : (sbyte)0, a.sd!=b.sd ? (sbyte)-1 : (sbyte)0, a.se!=b.se ? (sbyte)-1 : (sbyte)0, a.sf!=b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator <(byte16 a, byte16 b) => new sbyte16(a.s0<b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<b.s7 ? (sbyte)-1 : (sbyte)0, a.s8<b.s8 ? (sbyte)-1 : (sbyte)0, a.s9<b.s9 ? (sbyte)-1 : (sbyte)0, a.sa<b.sa ? (sbyte)-1 : (sbyte)0, a.sb<b.sb ? (sbyte)-1 : (sbyte)0, a.sc<b.sc ? (sbyte)-1 : (sbyte)0, a.sd<b.sd ? (sbyte)-1 : (sbyte)0, a.se<b.se ? (sbyte)-1 : (sbyte)0, a.sf<b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator <=(byte16 a, byte16 b) => new sbyte16(a.s0<=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1<=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2<=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3<=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4<=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5<=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6<=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7<=b.s7 ? (sbyte)-1 : (sbyte)0, a.s8<=b.s8 ? (sbyte)-1 : (sbyte)0, a.s9<=b.s9 ? (sbyte)-1 : (sbyte)0, a.sa<=b.sa ? (sbyte)-1 : (sbyte)0, a.sb<=b.sb ? (sbyte)-1 : (sbyte)0, a.sc<=b.sc ? (sbyte)-1 : (sbyte)0, a.sd<=b.sd ? (sbyte)-1 : (sbyte)0, a.se<=b.se ? (sbyte)-1 : (sbyte)0, a.sf<=b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator >(byte16 a, byte16 b) => new sbyte16(a.s0>b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>b.s7 ? (sbyte)-1 : (sbyte)0, a.s8>b.s8 ? (sbyte)-1 : (sbyte)0, a.s9>b.s9 ? (sbyte)-1 : (sbyte)0, a.sa>b.sa ? (sbyte)-1 : (sbyte)0, a.sb>b.sb ? (sbyte)-1 : (sbyte)0, a.sc>b.sc ? (sbyte)-1 : (sbyte)0, a.sd>b.sd ? (sbyte)-1 : (sbyte)0, a.se>b.se ? (sbyte)-1 : (sbyte)0, a.sf>b.sf ? (sbyte)-1 : (sbyte)0);

        public static sbyte16 operator >=(byte16 a, byte16 b) => new sbyte16(a.s0>=b.s0 ? (sbyte)-1 : (sbyte)0, a.s1>=b.s1 ? (sbyte)-1 : (sbyte)0, a.s2>=b.s2 ? (sbyte)-1 : (sbyte)0, a.s3>=b.s3 ? (sbyte)-1 : (sbyte)0, a.s4>=b.s4 ? (sbyte)-1 : (sbyte)0, a.s5>=b.s5 ? (sbyte)-1 : (sbyte)0, a.s6>=b.s6 ? (sbyte)-1 : (sbyte)0, a.s7>=b.s7 ? (sbyte)-1 : (sbyte)0, a.s8>=b.s8 ? (sbyte)-1 : (sbyte)0, a.s9>=b.s9 ? (sbyte)-1 : (sbyte)0, a.sa>=b.sa ? (sbyte)-1 : (sbyte)0, a.sb>=b.sb ? (sbyte)-1 : (sbyte)0, a.sc>=b.sc ? (sbyte)-1 : (sbyte)0, a.sd>=b.sd ? (sbyte)-1 : (sbyte)0, a.se>=b.se ? (sbyte)-1 : (sbyte)0, a.sf>=b.sf ? (sbyte)-1 : (sbyte)0);

        public static byte16 operator &(byte16 a, byte16 b) => new byte16((byte)(a.s0&b.s0), (byte)(a.s1&b.s1), (byte)(a.s2&b.s2), (byte)(a.s3&b.s3), (byte)(a.s4&b.s4), (byte)(a.s5&b.s5), (byte)(a.s6&b.s6), (byte)(a.s7&b.s7), (byte)(a.s8&b.s8), (byte)(a.s9&b.s9), (byte)(a.sa&b.sa), (byte)(a.sb&b.sb), (byte)(a.sc&b.sc), (byte)(a.sd&b.sd), (byte)(a.se&b.se), (byte)(a.sf&b.sf));

        public static byte16 operator |(byte16 a, byte16 b) => new byte16((byte)(a.s0|b.s0), (byte)(a.s1|b.s1), (byte)(a.s2|b.s2), (byte)(a.s3|b.s3), (byte)(a.s4|b.s4), (byte)(a.s5|b.s5), (byte)(a.s6|b.s6), (byte)(a.s7|b.s7), (byte)(a.s8|b.s8), (byte)(a.s9|b.s9), (byte)(a.sa|b.sa), (byte)(a.sb|b.sb), (byte)(a.sc|b.sc), (byte)(a.sd|b.sd), (byte)(a.se|b.se), (byte)(a.sf|b.sf));

        public static byte16 operator ^(byte16 a, byte16 b) => new byte16((byte)(a.s0^b.s0), (byte)(a.s1^b.s1), (byte)(a.s2^b.s2), (byte)(a.s3^b.s3), (byte)(a.s4^b.s4), (byte)(a.s5^b.s5), (byte)(a.s6^b.s6), (byte)(a.s7^b.s7), (byte)(a.s8^b.s8), (byte)(a.s9^b.s9), (byte)(a.sa^b.sa), (byte)(a.sb^b.sb), (byte)(a.sc^b.sc), (byte)(a.sd^b.sd), (byte)(a.se^b.se), (byte)(a.sf^b.sf));

        public static byte16 operator +(byte16 a) => a;

        public static byte16 operator ~(byte16 a) => new byte16((byte)(~a.s0), (byte)(~a.s1), (byte)(~a.s2), (byte)(~a.s3), (byte)(~a.s4), (byte)(~a.s5), (byte)(~a.s6), (byte)(~a.s7), (byte)(~a.s8), (byte)(~a.s9), (byte)(~a.sa), (byte)(~a.sb), (byte)(~a.sc), (byte)(~a.sd), (byte)(~a.se), (byte)(~a.sf));

        public static byte16 operator ++(byte16 a) => new byte16((byte)(a.s0+1), (byte)(a.s1+1), (byte)(a.s2+1), (byte)(a.s3+1), (byte)(a.s4+1), (byte)(a.s5+1), (byte)(a.s6+1), (byte)(a.s7+1), (byte)(a.s8+1), (byte)(a.s9+1), (byte)(a.sa+1), (byte)(a.sb+1), (byte)(a.sc+1), (byte)(a.sd+1), (byte)(a.se+1), (byte)(a.sf+1));

        public static byte16 operator --(byte16 a) => new byte16((byte)(a.s0-1), (byte)(a.s1-1), (byte)(a.s2-1), (byte)(a.s3-1), (byte)(a.s4-1), (byte)(a.s5-1), (byte)(a.s6-1), (byte)(a.s7-1), (byte)(a.s8-1), (byte)(a.s9-1), (byte)(a.sa-1), (byte)(a.sb-1), (byte)(a.sc-1), (byte)(a.sd-1), (byte)(a.se-1), (byte)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct short2: IVectorType, IEquatable<short2>
    {
        [FieldOffset(0)]
        public short s0;
        [FieldOffset(2)]
        public short s1;

        public short2(short v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public short2(short2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public short2(short v0, short v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public short x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public short y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public short2 xx
        {
            get { return new short2(this.s0, this.s0); }
        }

        public short2 xy
        {
            get { return new short2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public short2 yx
        {
            get { return new short2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public short2 yy
        {
            get { return new short2(this.s1, this.s1); }
        }

        public short this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 4; }
        }

        // IEquatable

        public bool Equals(short2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is short2 && Equals((short2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static short2 operator +(short2 a, short2 b) => new short2((short)(a.s0+b.s0), (short)(a.s1+b.s1));

        public static short2 operator -(short2 a, short2 b) => new short2((short)(a.s0-b.s0), (short)(a.s1-b.s1));

        public static short2 operator *(short2 a, short2 b) => new short2((short)(a.s0*b.s0), (short)(a.s1*b.s1));

        public static short2 operator /(short2 a, short2 b) => new short2((short)(a.s0/b.s0), (short)(a.s1/b.s1));

        public static short2 operator ==(short2 a, short2 b) => new short2(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0);

        public static short2 operator !=(short2 a, short2 b) => new short2(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0);

        public static short2 operator <(short2 a, short2 b) => new short2(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0);

        public static short2 operator <=(short2 a, short2 b) => new short2(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0);

        public static short2 operator >(short2 a, short2 b) => new short2(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0);

        public static short2 operator >=(short2 a, short2 b) => new short2(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0);

        public static short2 operator &(short2 a, short2 b) => new short2((short)(a.s0&b.s0), (short)(a.s1&b.s1));

        public static short2 operator |(short2 a, short2 b) => new short2((short)(a.s0|b.s0), (short)(a.s1|b.s1));

        public static short2 operator ^(short2 a, short2 b) => new short2((short)(a.s0^b.s0), (short)(a.s1^b.s1));

        public static short2 operator +(short2 a) => a;

        public static short2 operator -(short2 a) => new short2((short)(-a.s0), (short)(-a.s1));

        public static short2 operator ~(short2 a) => new short2((short)(~a.s0), (short)(~a.s1));

        public static short2 operator ++(short2 a) => new short2((short)(a.s0+1), (short)(a.s1+1));

        public static short2 operator --(short2 a) => new short2((short)(a.s0-1), (short)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=8)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct short3: IVectorType, IEquatable<short3>
    {
        [FieldOffset(0)]
        public short s0;
        [FieldOffset(2)]
        public short s1;
        [FieldOffset(4)]
        public short s2;

        public short3(short v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public short3(short3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public short3(short v0, short2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public short3(short2 v0, short v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public short3(short v0, short v1, short v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public short x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public short y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public short z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public short2 xx
        {
            get { return new short2(this.s0, this.s0); }
        }

        public short2 xy
        {
            get { return new short2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public short2 xz
        {
            get { return new short2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public short2 yx
        {
            get { return new short2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public short2 yy
        {
            get { return new short2(this.s1, this.s1); }
        }

        public short2 yz
        {
            get { return new short2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public short2 zx
        {
            get { return new short2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public short2 zy
        {
            get { return new short2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public short2 zz
        {
            get { return new short2(this.s2, this.s2); }
        }

        public short3 xxx
        {
            get { return new short3(this.s0, this.s0, this.s0); }
        }

        public short3 xxy
        {
            get { return new short3(this.s0, this.s0, this.s1); }
        }

        public short3 xxz
        {
            get { return new short3(this.s0, this.s0, this.s2); }
        }

        public short3 xyx
        {
            get { return new short3(this.s0, this.s1, this.s0); }
        }

        public short3 xyy
        {
            get { return new short3(this.s0, this.s1, this.s1); }
        }

        public short3 xyz
        {
            get { return new short3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 xzx
        {
            get { return new short3(this.s0, this.s2, this.s0); }
        }

        public short3 xzy
        {
            get { return new short3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 xzz
        {
            get { return new short3(this.s0, this.s2, this.s2); }
        }

        public short3 yxx
        {
            get { return new short3(this.s1, this.s0, this.s0); }
        }

        public short3 yxy
        {
            get { return new short3(this.s1, this.s0, this.s1); }
        }

        public short3 yxz
        {
            get { return new short3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 yyx
        {
            get { return new short3(this.s1, this.s1, this.s0); }
        }

        public short3 yyy
        {
            get { return new short3(this.s1, this.s1, this.s1); }
        }

        public short3 yyz
        {
            get { return new short3(this.s1, this.s1, this.s2); }
        }

        public short3 yzx
        {
            get { return new short3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 yzy
        {
            get { return new short3(this.s1, this.s2, this.s1); }
        }

        public short3 yzz
        {
            get { return new short3(this.s1, this.s2, this.s2); }
        }

        public short3 zxx
        {
            get { return new short3(this.s2, this.s0, this.s0); }
        }

        public short3 zxy
        {
            get { return new short3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 zxz
        {
            get { return new short3(this.s2, this.s0, this.s2); }
        }

        public short3 zyx
        {
            get { return new short3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 zyy
        {
            get { return new short3(this.s2, this.s1, this.s1); }
        }

        public short3 zyz
        {
            get { return new short3(this.s2, this.s1, this.s2); }
        }

        public short3 zzx
        {
            get { return new short3(this.s2, this.s2, this.s0); }
        }

        public short3 zzy
        {
            get { return new short3(this.s2, this.s2, this.s1); }
        }

        public short3 zzz
        {
            get { return new short3(this.s2, this.s2, this.s2); }
        }

        public short this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 6; }
        }

        // IEquatable

        public bool Equals(short3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is short3 && Equals((short3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static short3 operator +(short3 a, short3 b) => new short3((short)(a.s0+b.s0), (short)(a.s1+b.s1), (short)(a.s2+b.s2));

        public static short3 operator -(short3 a, short3 b) => new short3((short)(a.s0-b.s0), (short)(a.s1-b.s1), (short)(a.s2-b.s2));

        public static short3 operator *(short3 a, short3 b) => new short3((short)(a.s0*b.s0), (short)(a.s1*b.s1), (short)(a.s2*b.s2));

        public static short3 operator /(short3 a, short3 b) => new short3((short)(a.s0/b.s0), (short)(a.s1/b.s1), (short)(a.s2/b.s2));

        public static short3 operator ==(short3 a, short3 b) => new short3(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0);

        public static short3 operator !=(short3 a, short3 b) => new short3(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0);

        public static short3 operator <(short3 a, short3 b) => new short3(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0);

        public static short3 operator <=(short3 a, short3 b) => new short3(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0);

        public static short3 operator >(short3 a, short3 b) => new short3(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0);

        public static short3 operator >=(short3 a, short3 b) => new short3(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0);

        public static short3 operator &(short3 a, short3 b) => new short3((short)(a.s0&b.s0), (short)(a.s1&b.s1), (short)(a.s2&b.s2));

        public static short3 operator |(short3 a, short3 b) => new short3((short)(a.s0|b.s0), (short)(a.s1|b.s1), (short)(a.s2|b.s2));

        public static short3 operator ^(short3 a, short3 b) => new short3((short)(a.s0^b.s0), (short)(a.s1^b.s1), (short)(a.s2^b.s2));

        public static short3 operator +(short3 a) => a;

        public static short3 operator -(short3 a) => new short3((short)(-a.s0), (short)(-a.s1), (short)(-a.s2));

        public static short3 operator ~(short3 a) => new short3((short)(~a.s0), (short)(~a.s1), (short)(~a.s2));

        public static short3 operator ++(short3 a) => new short3((short)(a.s0+1), (short)(a.s1+1), (short)(a.s2+1));

        public static short3 operator --(short3 a) => new short3((short)(a.s0-1), (short)(a.s1-1), (short)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct short4: IVectorType, IEquatable<short4>
    {
        [FieldOffset(0)]
        public short s0;
        [FieldOffset(2)]
        public short s1;
        [FieldOffset(4)]
        public short s2;
        [FieldOffset(6)]
        public short s3;

        public short4(short v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public short4(short4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public short4(short v0, short3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public short4(short2 v0, short2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public short4(short3 v0, short v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public short4(short v0, short v1, short2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public short4(short v0, short2 v1, short v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public short4(short2 v0, short v1, short v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public short4(short v0, short v1, short v2, short v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public short x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public short y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public short z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public short w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public short2 xx
        {
            get { return new short2(this.s0, this.s0); }
        }

        public short2 xy
        {
            get { return new short2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public short2 xz
        {
            get { return new short2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public short2 xw
        {
            get { return new short2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public short2 yx
        {
            get { return new short2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public short2 yy
        {
            get { return new short2(this.s1, this.s1); }
        }

        public short2 yz
        {
            get { return new short2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public short2 yw
        {
            get { return new short2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public short2 zx
        {
            get { return new short2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public short2 zy
        {
            get { return new short2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public short2 zz
        {
            get { return new short2(this.s2, this.s2); }
        }

        public short2 zw
        {
            get { return new short2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public short2 wx
        {
            get { return new short2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public short2 wy
        {
            get { return new short2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public short2 wz
        {
            get { return new short2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public short2 ww
        {
            get { return new short2(this.s3, this.s3); }
        }

        public short3 xxx
        {
            get { return new short3(this.s0, this.s0, this.s0); }
        }

        public short3 xxy
        {
            get { return new short3(this.s0, this.s0, this.s1); }
        }

        public short3 xxz
        {
            get { return new short3(this.s0, this.s0, this.s2); }
        }

        public short3 xxw
        {
            get { return new short3(this.s0, this.s0, this.s3); }
        }

        public short3 xyx
        {
            get { return new short3(this.s0, this.s1, this.s0); }
        }

        public short3 xyy
        {
            get { return new short3(this.s0, this.s1, this.s1); }
        }

        public short3 xyz
        {
            get { return new short3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 xyw
        {
            get { return new short3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public short3 xzx
        {
            get { return new short3(this.s0, this.s2, this.s0); }
        }

        public short3 xzy
        {
            get { return new short3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 xzz
        {
            get { return new short3(this.s0, this.s2, this.s2); }
        }

        public short3 xzw
        {
            get { return new short3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public short3 xwx
        {
            get { return new short3(this.s0, this.s3, this.s0); }
        }

        public short3 xwy
        {
            get { return new short3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 xwz
        {
            get { return new short3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 xww
        {
            get { return new short3(this.s0, this.s3, this.s3); }
        }

        public short3 yxx
        {
            get { return new short3(this.s1, this.s0, this.s0); }
        }

        public short3 yxy
        {
            get { return new short3(this.s1, this.s0, this.s1); }
        }

        public short3 yxz
        {
            get { return new short3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 yxw
        {
            get { return new short3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public short3 yyx
        {
            get { return new short3(this.s1, this.s1, this.s0); }
        }

        public short3 yyy
        {
            get { return new short3(this.s1, this.s1, this.s1); }
        }

        public short3 yyz
        {
            get { return new short3(this.s1, this.s1, this.s2); }
        }

        public short3 yyw
        {
            get { return new short3(this.s1, this.s1, this.s3); }
        }

        public short3 yzx
        {
            get { return new short3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 yzy
        {
            get { return new short3(this.s1, this.s2, this.s1); }
        }

        public short3 yzz
        {
            get { return new short3(this.s1, this.s2, this.s2); }
        }

        public short3 yzw
        {
            get { return new short3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public short3 ywx
        {
            get { return new short3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 ywy
        {
            get { return new short3(this.s1, this.s3, this.s1); }
        }

        public short3 ywz
        {
            get { return new short3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 yww
        {
            get { return new short3(this.s1, this.s3, this.s3); }
        }

        public short3 zxx
        {
            get { return new short3(this.s2, this.s0, this.s0); }
        }

        public short3 zxy
        {
            get { return new short3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 zxz
        {
            get { return new short3(this.s2, this.s0, this.s2); }
        }

        public short3 zxw
        {
            get { return new short3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public short3 zyx
        {
            get { return new short3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 zyy
        {
            get { return new short3(this.s2, this.s1, this.s1); }
        }

        public short3 zyz
        {
            get { return new short3(this.s2, this.s1, this.s2); }
        }

        public short3 zyw
        {
            get { return new short3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public short3 zzx
        {
            get { return new short3(this.s2, this.s2, this.s0); }
        }

        public short3 zzy
        {
            get { return new short3(this.s2, this.s2, this.s1); }
        }

        public short3 zzz
        {
            get { return new short3(this.s2, this.s2, this.s2); }
        }

        public short3 zzw
        {
            get { return new short3(this.s2, this.s2, this.s3); }
        }

        public short3 zwx
        {
            get { return new short3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 zwy
        {
            get { return new short3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 zwz
        {
            get { return new short3(this.s2, this.s3, this.s2); }
        }

        public short3 zww
        {
            get { return new short3(this.s2, this.s3, this.s3); }
        }

        public short3 wxx
        {
            get { return new short3(this.s3, this.s0, this.s0); }
        }

        public short3 wxy
        {
            get { return new short3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 wxz
        {
            get { return new short3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 wxw
        {
            get { return new short3(this.s3, this.s0, this.s3); }
        }

        public short3 wyx
        {
            get { return new short3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 wyy
        {
            get { return new short3(this.s3, this.s1, this.s1); }
        }

        public short3 wyz
        {
            get { return new short3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public short3 wyw
        {
            get { return new short3(this.s3, this.s1, this.s3); }
        }

        public short3 wzx
        {
            get { return new short3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public short3 wzy
        {
            get { return new short3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public short3 wzz
        {
            get { return new short3(this.s3, this.s2, this.s2); }
        }

        public short3 wzw
        {
            get { return new short3(this.s3, this.s2, this.s3); }
        }

        public short3 wwx
        {
            get { return new short3(this.s3, this.s3, this.s0); }
        }

        public short3 wwy
        {
            get { return new short3(this.s3, this.s3, this.s1); }
        }

        public short3 wwz
        {
            get { return new short3(this.s3, this.s3, this.s2); }
        }

        public short3 www
        {
            get { return new short3(this.s3, this.s3, this.s3); }
        }

        public short4 xxxx
        {
            get { return new short4(this.s0, this.s0, this.s0, this.s0); }
        }

        public short4 xxxy
        {
            get { return new short4(this.s0, this.s0, this.s0, this.s1); }
        }

        public short4 xxxz
        {
            get { return new short4(this.s0, this.s0, this.s0, this.s2); }
        }

        public short4 xxxw
        {
            get { return new short4(this.s0, this.s0, this.s0, this.s3); }
        }

        public short4 xxyx
        {
            get { return new short4(this.s0, this.s0, this.s1, this.s0); }
        }

        public short4 xxyy
        {
            get { return new short4(this.s0, this.s0, this.s1, this.s1); }
        }

        public short4 xxyz
        {
            get { return new short4(this.s0, this.s0, this.s1, this.s2); }
        }

        public short4 xxyw
        {
            get { return new short4(this.s0, this.s0, this.s1, this.s3); }
        }

        public short4 xxzx
        {
            get { return new short4(this.s0, this.s0, this.s2, this.s0); }
        }

        public short4 xxzy
        {
            get { return new short4(this.s0, this.s0, this.s2, this.s1); }
        }

        public short4 xxzz
        {
            get { return new short4(this.s0, this.s0, this.s2, this.s2); }
        }

        public short4 xxzw
        {
            get { return new short4(this.s0, this.s0, this.s2, this.s3); }
        }

        public short4 xxwx
        {
            get { return new short4(this.s0, this.s0, this.s3, this.s0); }
        }

        public short4 xxwy
        {
            get { return new short4(this.s0, this.s0, this.s3, this.s1); }
        }

        public short4 xxwz
        {
            get { return new short4(this.s0, this.s0, this.s3, this.s2); }
        }

        public short4 xxww
        {
            get { return new short4(this.s0, this.s0, this.s3, this.s3); }
        }

        public short4 xyxx
        {
            get { return new short4(this.s0, this.s1, this.s0, this.s0); }
        }

        public short4 xyxy
        {
            get { return new short4(this.s0, this.s1, this.s0, this.s1); }
        }

        public short4 xyxz
        {
            get { return new short4(this.s0, this.s1, this.s0, this.s2); }
        }

        public short4 xyxw
        {
            get { return new short4(this.s0, this.s1, this.s0, this.s3); }
        }

        public short4 xyyx
        {
            get { return new short4(this.s0, this.s1, this.s1, this.s0); }
        }

        public short4 xyyy
        {
            get { return new short4(this.s0, this.s1, this.s1, this.s1); }
        }

        public short4 xyyz
        {
            get { return new short4(this.s0, this.s1, this.s1, this.s2); }
        }

        public short4 xyyw
        {
            get { return new short4(this.s0, this.s1, this.s1, this.s3); }
        }

        public short4 xyzx
        {
            get { return new short4(this.s0, this.s1, this.s2, this.s0); }
        }

        public short4 xyzy
        {
            get { return new short4(this.s0, this.s1, this.s2, this.s1); }
        }

        public short4 xyzz
        {
            get { return new short4(this.s0, this.s1, this.s2, this.s2); }
        }

        public short4 xyzw
        {
            get { return new short4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public short4 xywx
        {
            get { return new short4(this.s0, this.s1, this.s3, this.s0); }
        }

        public short4 xywy
        {
            get { return new short4(this.s0, this.s1, this.s3, this.s1); }
        }

        public short4 xywz
        {
            get { return new short4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public short4 xyww
        {
            get { return new short4(this.s0, this.s1, this.s3, this.s3); }
        }

        public short4 xzxx
        {
            get { return new short4(this.s0, this.s2, this.s0, this.s0); }
        }

        public short4 xzxy
        {
            get { return new short4(this.s0, this.s2, this.s0, this.s1); }
        }

        public short4 xzxz
        {
            get { return new short4(this.s0, this.s2, this.s0, this.s2); }
        }

        public short4 xzxw
        {
            get { return new short4(this.s0, this.s2, this.s0, this.s3); }
        }

        public short4 xzyx
        {
            get { return new short4(this.s0, this.s2, this.s1, this.s0); }
        }

        public short4 xzyy
        {
            get { return new short4(this.s0, this.s2, this.s1, this.s1); }
        }

        public short4 xzyz
        {
            get { return new short4(this.s0, this.s2, this.s1, this.s2); }
        }

        public short4 xzyw
        {
            get { return new short4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public short4 xzzx
        {
            get { return new short4(this.s0, this.s2, this.s2, this.s0); }
        }

        public short4 xzzy
        {
            get { return new short4(this.s0, this.s2, this.s2, this.s1); }
        }

        public short4 xzzz
        {
            get { return new short4(this.s0, this.s2, this.s2, this.s2); }
        }

        public short4 xzzw
        {
            get { return new short4(this.s0, this.s2, this.s2, this.s3); }
        }

        public short4 xzwx
        {
            get { return new short4(this.s0, this.s2, this.s3, this.s0); }
        }

        public short4 xzwy
        {
            get { return new short4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public short4 xzwz
        {
            get { return new short4(this.s0, this.s2, this.s3, this.s2); }
        }

        public short4 xzww
        {
            get { return new short4(this.s0, this.s2, this.s3, this.s3); }
        }

        public short4 xwxx
        {
            get { return new short4(this.s0, this.s3, this.s0, this.s0); }
        }

        public short4 xwxy
        {
            get { return new short4(this.s0, this.s3, this.s0, this.s1); }
        }

        public short4 xwxz
        {
            get { return new short4(this.s0, this.s3, this.s0, this.s2); }
        }

        public short4 xwxw
        {
            get { return new short4(this.s0, this.s3, this.s0, this.s3); }
        }

        public short4 xwyx
        {
            get { return new short4(this.s0, this.s3, this.s1, this.s0); }
        }

        public short4 xwyy
        {
            get { return new short4(this.s0, this.s3, this.s1, this.s1); }
        }

        public short4 xwyz
        {
            get { return new short4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public short4 xwyw
        {
            get { return new short4(this.s0, this.s3, this.s1, this.s3); }
        }

        public short4 xwzx
        {
            get { return new short4(this.s0, this.s3, this.s2, this.s0); }
        }

        public short4 xwzy
        {
            get { return new short4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public short4 xwzz
        {
            get { return new short4(this.s0, this.s3, this.s2, this.s2); }
        }

        public short4 xwzw
        {
            get { return new short4(this.s0, this.s3, this.s2, this.s3); }
        }

        public short4 xwwx
        {
            get { return new short4(this.s0, this.s3, this.s3, this.s0); }
        }

        public short4 xwwy
        {
            get { return new short4(this.s0, this.s3, this.s3, this.s1); }
        }

        public short4 xwwz
        {
            get { return new short4(this.s0, this.s3, this.s3, this.s2); }
        }

        public short4 xwww
        {
            get { return new short4(this.s0, this.s3, this.s3, this.s3); }
        }

        public short4 yxxx
        {
            get { return new short4(this.s1, this.s0, this.s0, this.s0); }
        }

        public short4 yxxy
        {
            get { return new short4(this.s1, this.s0, this.s0, this.s1); }
        }

        public short4 yxxz
        {
            get { return new short4(this.s1, this.s0, this.s0, this.s2); }
        }

        public short4 yxxw
        {
            get { return new short4(this.s1, this.s0, this.s0, this.s3); }
        }

        public short4 yxyx
        {
            get { return new short4(this.s1, this.s0, this.s1, this.s0); }
        }

        public short4 yxyy
        {
            get { return new short4(this.s1, this.s0, this.s1, this.s1); }
        }

        public short4 yxyz
        {
            get { return new short4(this.s1, this.s0, this.s1, this.s2); }
        }

        public short4 yxyw
        {
            get { return new short4(this.s1, this.s0, this.s1, this.s3); }
        }

        public short4 yxzx
        {
            get { return new short4(this.s1, this.s0, this.s2, this.s0); }
        }

        public short4 yxzy
        {
            get { return new short4(this.s1, this.s0, this.s2, this.s1); }
        }

        public short4 yxzz
        {
            get { return new short4(this.s1, this.s0, this.s2, this.s2); }
        }

        public short4 yxzw
        {
            get { return new short4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public short4 yxwx
        {
            get { return new short4(this.s1, this.s0, this.s3, this.s0); }
        }

        public short4 yxwy
        {
            get { return new short4(this.s1, this.s0, this.s3, this.s1); }
        }

        public short4 yxwz
        {
            get { return new short4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public short4 yxww
        {
            get { return new short4(this.s1, this.s0, this.s3, this.s3); }
        }

        public short4 yyxx
        {
            get { return new short4(this.s1, this.s1, this.s0, this.s0); }
        }

        public short4 yyxy
        {
            get { return new short4(this.s1, this.s1, this.s0, this.s1); }
        }

        public short4 yyxz
        {
            get { return new short4(this.s1, this.s1, this.s0, this.s2); }
        }

        public short4 yyxw
        {
            get { return new short4(this.s1, this.s1, this.s0, this.s3); }
        }

        public short4 yyyx
        {
            get { return new short4(this.s1, this.s1, this.s1, this.s0); }
        }

        public short4 yyyy
        {
            get { return new short4(this.s1, this.s1, this.s1, this.s1); }
        }

        public short4 yyyz
        {
            get { return new short4(this.s1, this.s1, this.s1, this.s2); }
        }

        public short4 yyyw
        {
            get { return new short4(this.s1, this.s1, this.s1, this.s3); }
        }

        public short4 yyzx
        {
            get { return new short4(this.s1, this.s1, this.s2, this.s0); }
        }

        public short4 yyzy
        {
            get { return new short4(this.s1, this.s1, this.s2, this.s1); }
        }

        public short4 yyzz
        {
            get { return new short4(this.s1, this.s1, this.s2, this.s2); }
        }

        public short4 yyzw
        {
            get { return new short4(this.s1, this.s1, this.s2, this.s3); }
        }

        public short4 yywx
        {
            get { return new short4(this.s1, this.s1, this.s3, this.s0); }
        }

        public short4 yywy
        {
            get { return new short4(this.s1, this.s1, this.s3, this.s1); }
        }

        public short4 yywz
        {
            get { return new short4(this.s1, this.s1, this.s3, this.s2); }
        }

        public short4 yyww
        {
            get { return new short4(this.s1, this.s1, this.s3, this.s3); }
        }

        public short4 yzxx
        {
            get { return new short4(this.s1, this.s2, this.s0, this.s0); }
        }

        public short4 yzxy
        {
            get { return new short4(this.s1, this.s2, this.s0, this.s1); }
        }

        public short4 yzxz
        {
            get { return new short4(this.s1, this.s2, this.s0, this.s2); }
        }

        public short4 yzxw
        {
            get { return new short4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public short4 yzyx
        {
            get { return new short4(this.s1, this.s2, this.s1, this.s0); }
        }

        public short4 yzyy
        {
            get { return new short4(this.s1, this.s2, this.s1, this.s1); }
        }

        public short4 yzyz
        {
            get { return new short4(this.s1, this.s2, this.s1, this.s2); }
        }

        public short4 yzyw
        {
            get { return new short4(this.s1, this.s2, this.s1, this.s3); }
        }

        public short4 yzzx
        {
            get { return new short4(this.s1, this.s2, this.s2, this.s0); }
        }

        public short4 yzzy
        {
            get { return new short4(this.s1, this.s2, this.s2, this.s1); }
        }

        public short4 yzzz
        {
            get { return new short4(this.s1, this.s2, this.s2, this.s2); }
        }

        public short4 yzzw
        {
            get { return new short4(this.s1, this.s2, this.s2, this.s3); }
        }

        public short4 yzwx
        {
            get { return new short4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public short4 yzwy
        {
            get { return new short4(this.s1, this.s2, this.s3, this.s1); }
        }

        public short4 yzwz
        {
            get { return new short4(this.s1, this.s2, this.s3, this.s2); }
        }

        public short4 yzww
        {
            get { return new short4(this.s1, this.s2, this.s3, this.s3); }
        }

        public short4 ywxx
        {
            get { return new short4(this.s1, this.s3, this.s0, this.s0); }
        }

        public short4 ywxy
        {
            get { return new short4(this.s1, this.s3, this.s0, this.s1); }
        }

        public short4 ywxz
        {
            get { return new short4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public short4 ywxw
        {
            get { return new short4(this.s1, this.s3, this.s0, this.s3); }
        }

        public short4 ywyx
        {
            get { return new short4(this.s1, this.s3, this.s1, this.s0); }
        }

        public short4 ywyy
        {
            get { return new short4(this.s1, this.s3, this.s1, this.s1); }
        }

        public short4 ywyz
        {
            get { return new short4(this.s1, this.s3, this.s1, this.s2); }
        }

        public short4 ywyw
        {
            get { return new short4(this.s1, this.s3, this.s1, this.s3); }
        }

        public short4 ywzx
        {
            get { return new short4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public short4 ywzy
        {
            get { return new short4(this.s1, this.s3, this.s2, this.s1); }
        }

        public short4 ywzz
        {
            get { return new short4(this.s1, this.s3, this.s2, this.s2); }
        }

        public short4 ywzw
        {
            get { return new short4(this.s1, this.s3, this.s2, this.s3); }
        }

        public short4 ywwx
        {
            get { return new short4(this.s1, this.s3, this.s3, this.s0); }
        }

        public short4 ywwy
        {
            get { return new short4(this.s1, this.s3, this.s3, this.s1); }
        }

        public short4 ywwz
        {
            get { return new short4(this.s1, this.s3, this.s3, this.s2); }
        }

        public short4 ywww
        {
            get { return new short4(this.s1, this.s3, this.s3, this.s3); }
        }

        public short4 zxxx
        {
            get { return new short4(this.s2, this.s0, this.s0, this.s0); }
        }

        public short4 zxxy
        {
            get { return new short4(this.s2, this.s0, this.s0, this.s1); }
        }

        public short4 zxxz
        {
            get { return new short4(this.s2, this.s0, this.s0, this.s2); }
        }

        public short4 zxxw
        {
            get { return new short4(this.s2, this.s0, this.s0, this.s3); }
        }

        public short4 zxyx
        {
            get { return new short4(this.s2, this.s0, this.s1, this.s0); }
        }

        public short4 zxyy
        {
            get { return new short4(this.s2, this.s0, this.s1, this.s1); }
        }

        public short4 zxyz
        {
            get { return new short4(this.s2, this.s0, this.s1, this.s2); }
        }

        public short4 zxyw
        {
            get { return new short4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public short4 zxzx
        {
            get { return new short4(this.s2, this.s0, this.s2, this.s0); }
        }

        public short4 zxzy
        {
            get { return new short4(this.s2, this.s0, this.s2, this.s1); }
        }

        public short4 zxzz
        {
            get { return new short4(this.s2, this.s0, this.s2, this.s2); }
        }

        public short4 zxzw
        {
            get { return new short4(this.s2, this.s0, this.s2, this.s3); }
        }

        public short4 zxwx
        {
            get { return new short4(this.s2, this.s0, this.s3, this.s0); }
        }

        public short4 zxwy
        {
            get { return new short4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public short4 zxwz
        {
            get { return new short4(this.s2, this.s0, this.s3, this.s2); }
        }

        public short4 zxww
        {
            get { return new short4(this.s2, this.s0, this.s3, this.s3); }
        }

        public short4 zyxx
        {
            get { return new short4(this.s2, this.s1, this.s0, this.s0); }
        }

        public short4 zyxy
        {
            get { return new short4(this.s2, this.s1, this.s0, this.s1); }
        }

        public short4 zyxz
        {
            get { return new short4(this.s2, this.s1, this.s0, this.s2); }
        }

        public short4 zyxw
        {
            get { return new short4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public short4 zyyx
        {
            get { return new short4(this.s2, this.s1, this.s1, this.s0); }
        }

        public short4 zyyy
        {
            get { return new short4(this.s2, this.s1, this.s1, this.s1); }
        }

        public short4 zyyz
        {
            get { return new short4(this.s2, this.s1, this.s1, this.s2); }
        }

        public short4 zyyw
        {
            get { return new short4(this.s2, this.s1, this.s1, this.s3); }
        }

        public short4 zyzx
        {
            get { return new short4(this.s2, this.s1, this.s2, this.s0); }
        }

        public short4 zyzy
        {
            get { return new short4(this.s2, this.s1, this.s2, this.s1); }
        }

        public short4 zyzz
        {
            get { return new short4(this.s2, this.s1, this.s2, this.s2); }
        }

        public short4 zyzw
        {
            get { return new short4(this.s2, this.s1, this.s2, this.s3); }
        }

        public short4 zywx
        {
            get { return new short4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public short4 zywy
        {
            get { return new short4(this.s2, this.s1, this.s3, this.s1); }
        }

        public short4 zywz
        {
            get { return new short4(this.s2, this.s1, this.s3, this.s2); }
        }

        public short4 zyww
        {
            get { return new short4(this.s2, this.s1, this.s3, this.s3); }
        }

        public short4 zzxx
        {
            get { return new short4(this.s2, this.s2, this.s0, this.s0); }
        }

        public short4 zzxy
        {
            get { return new short4(this.s2, this.s2, this.s0, this.s1); }
        }

        public short4 zzxz
        {
            get { return new short4(this.s2, this.s2, this.s0, this.s2); }
        }

        public short4 zzxw
        {
            get { return new short4(this.s2, this.s2, this.s0, this.s3); }
        }

        public short4 zzyx
        {
            get { return new short4(this.s2, this.s2, this.s1, this.s0); }
        }

        public short4 zzyy
        {
            get { return new short4(this.s2, this.s2, this.s1, this.s1); }
        }

        public short4 zzyz
        {
            get { return new short4(this.s2, this.s2, this.s1, this.s2); }
        }

        public short4 zzyw
        {
            get { return new short4(this.s2, this.s2, this.s1, this.s3); }
        }

        public short4 zzzx
        {
            get { return new short4(this.s2, this.s2, this.s2, this.s0); }
        }

        public short4 zzzy
        {
            get { return new short4(this.s2, this.s2, this.s2, this.s1); }
        }

        public short4 zzzz
        {
            get { return new short4(this.s2, this.s2, this.s2, this.s2); }
        }

        public short4 zzzw
        {
            get { return new short4(this.s2, this.s2, this.s2, this.s3); }
        }

        public short4 zzwx
        {
            get { return new short4(this.s2, this.s2, this.s3, this.s0); }
        }

        public short4 zzwy
        {
            get { return new short4(this.s2, this.s2, this.s3, this.s1); }
        }

        public short4 zzwz
        {
            get { return new short4(this.s2, this.s2, this.s3, this.s2); }
        }

        public short4 zzww
        {
            get { return new short4(this.s2, this.s2, this.s3, this.s3); }
        }

        public short4 zwxx
        {
            get { return new short4(this.s2, this.s3, this.s0, this.s0); }
        }

        public short4 zwxy
        {
            get { return new short4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public short4 zwxz
        {
            get { return new short4(this.s2, this.s3, this.s0, this.s2); }
        }

        public short4 zwxw
        {
            get { return new short4(this.s2, this.s3, this.s0, this.s3); }
        }

        public short4 zwyx
        {
            get { return new short4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public short4 zwyy
        {
            get { return new short4(this.s2, this.s3, this.s1, this.s1); }
        }

        public short4 zwyz
        {
            get { return new short4(this.s2, this.s3, this.s1, this.s2); }
        }

        public short4 zwyw
        {
            get { return new short4(this.s2, this.s3, this.s1, this.s3); }
        }

        public short4 zwzx
        {
            get { return new short4(this.s2, this.s3, this.s2, this.s0); }
        }

        public short4 zwzy
        {
            get { return new short4(this.s2, this.s3, this.s2, this.s1); }
        }

        public short4 zwzz
        {
            get { return new short4(this.s2, this.s3, this.s2, this.s2); }
        }

        public short4 zwzw
        {
            get { return new short4(this.s2, this.s3, this.s2, this.s3); }
        }

        public short4 zwwx
        {
            get { return new short4(this.s2, this.s3, this.s3, this.s0); }
        }

        public short4 zwwy
        {
            get { return new short4(this.s2, this.s3, this.s3, this.s1); }
        }

        public short4 zwwz
        {
            get { return new short4(this.s2, this.s3, this.s3, this.s2); }
        }

        public short4 zwww
        {
            get { return new short4(this.s2, this.s3, this.s3, this.s3); }
        }

        public short4 wxxx
        {
            get { return new short4(this.s3, this.s0, this.s0, this.s0); }
        }

        public short4 wxxy
        {
            get { return new short4(this.s3, this.s0, this.s0, this.s1); }
        }

        public short4 wxxz
        {
            get { return new short4(this.s3, this.s0, this.s0, this.s2); }
        }

        public short4 wxxw
        {
            get { return new short4(this.s3, this.s0, this.s0, this.s3); }
        }

        public short4 wxyx
        {
            get { return new short4(this.s3, this.s0, this.s1, this.s0); }
        }

        public short4 wxyy
        {
            get { return new short4(this.s3, this.s0, this.s1, this.s1); }
        }

        public short4 wxyz
        {
            get { return new short4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public short4 wxyw
        {
            get { return new short4(this.s3, this.s0, this.s1, this.s3); }
        }

        public short4 wxzx
        {
            get { return new short4(this.s3, this.s0, this.s2, this.s0); }
        }

        public short4 wxzy
        {
            get { return new short4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public short4 wxzz
        {
            get { return new short4(this.s3, this.s0, this.s2, this.s2); }
        }

        public short4 wxzw
        {
            get { return new short4(this.s3, this.s0, this.s2, this.s3); }
        }

        public short4 wxwx
        {
            get { return new short4(this.s3, this.s0, this.s3, this.s0); }
        }

        public short4 wxwy
        {
            get { return new short4(this.s3, this.s0, this.s3, this.s1); }
        }

        public short4 wxwz
        {
            get { return new short4(this.s3, this.s0, this.s3, this.s2); }
        }

        public short4 wxww
        {
            get { return new short4(this.s3, this.s0, this.s3, this.s3); }
        }

        public short4 wyxx
        {
            get { return new short4(this.s3, this.s1, this.s0, this.s0); }
        }

        public short4 wyxy
        {
            get { return new short4(this.s3, this.s1, this.s0, this.s1); }
        }

        public short4 wyxz
        {
            get { return new short4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public short4 wyxw
        {
            get { return new short4(this.s3, this.s1, this.s0, this.s3); }
        }

        public short4 wyyx
        {
            get { return new short4(this.s3, this.s1, this.s1, this.s0); }
        }

        public short4 wyyy
        {
            get { return new short4(this.s3, this.s1, this.s1, this.s1); }
        }

        public short4 wyyz
        {
            get { return new short4(this.s3, this.s1, this.s1, this.s2); }
        }

        public short4 wyyw
        {
            get { return new short4(this.s3, this.s1, this.s1, this.s3); }
        }

        public short4 wyzx
        {
            get { return new short4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public short4 wyzy
        {
            get { return new short4(this.s3, this.s1, this.s2, this.s1); }
        }

        public short4 wyzz
        {
            get { return new short4(this.s3, this.s1, this.s2, this.s2); }
        }

        public short4 wyzw
        {
            get { return new short4(this.s3, this.s1, this.s2, this.s3); }
        }

        public short4 wywx
        {
            get { return new short4(this.s3, this.s1, this.s3, this.s0); }
        }

        public short4 wywy
        {
            get { return new short4(this.s3, this.s1, this.s3, this.s1); }
        }

        public short4 wywz
        {
            get { return new short4(this.s3, this.s1, this.s3, this.s2); }
        }

        public short4 wyww
        {
            get { return new short4(this.s3, this.s1, this.s3, this.s3); }
        }

        public short4 wzxx
        {
            get { return new short4(this.s3, this.s2, this.s0, this.s0); }
        }

        public short4 wzxy
        {
            get { return new short4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public short4 wzxz
        {
            get { return new short4(this.s3, this.s2, this.s0, this.s2); }
        }

        public short4 wzxw
        {
            get { return new short4(this.s3, this.s2, this.s0, this.s3); }
        }

        public short4 wzyx
        {
            get { return new short4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public short4 wzyy
        {
            get { return new short4(this.s3, this.s2, this.s1, this.s1); }
        }

        public short4 wzyz
        {
            get { return new short4(this.s3, this.s2, this.s1, this.s2); }
        }

        public short4 wzyw
        {
            get { return new short4(this.s3, this.s2, this.s1, this.s3); }
        }

        public short4 wzzx
        {
            get { return new short4(this.s3, this.s2, this.s2, this.s0); }
        }

        public short4 wzzy
        {
            get { return new short4(this.s3, this.s2, this.s2, this.s1); }
        }

        public short4 wzzz
        {
            get { return new short4(this.s3, this.s2, this.s2, this.s2); }
        }

        public short4 wzzw
        {
            get { return new short4(this.s3, this.s2, this.s2, this.s3); }
        }

        public short4 wzwx
        {
            get { return new short4(this.s3, this.s2, this.s3, this.s0); }
        }

        public short4 wzwy
        {
            get { return new short4(this.s3, this.s2, this.s3, this.s1); }
        }

        public short4 wzwz
        {
            get { return new short4(this.s3, this.s2, this.s3, this.s2); }
        }

        public short4 wzww
        {
            get { return new short4(this.s3, this.s2, this.s3, this.s3); }
        }

        public short4 wwxx
        {
            get { return new short4(this.s3, this.s3, this.s0, this.s0); }
        }

        public short4 wwxy
        {
            get { return new short4(this.s3, this.s3, this.s0, this.s1); }
        }

        public short4 wwxz
        {
            get { return new short4(this.s3, this.s3, this.s0, this.s2); }
        }

        public short4 wwxw
        {
            get { return new short4(this.s3, this.s3, this.s0, this.s3); }
        }

        public short4 wwyx
        {
            get { return new short4(this.s3, this.s3, this.s1, this.s0); }
        }

        public short4 wwyy
        {
            get { return new short4(this.s3, this.s3, this.s1, this.s1); }
        }

        public short4 wwyz
        {
            get { return new short4(this.s3, this.s3, this.s1, this.s2); }
        }

        public short4 wwyw
        {
            get { return new short4(this.s3, this.s3, this.s1, this.s3); }
        }

        public short4 wwzx
        {
            get { return new short4(this.s3, this.s3, this.s2, this.s0); }
        }

        public short4 wwzy
        {
            get { return new short4(this.s3, this.s3, this.s2, this.s1); }
        }

        public short4 wwzz
        {
            get { return new short4(this.s3, this.s3, this.s2, this.s2); }
        }

        public short4 wwzw
        {
            get { return new short4(this.s3, this.s3, this.s2, this.s3); }
        }

        public short4 wwwx
        {
            get { return new short4(this.s3, this.s3, this.s3, this.s0); }
        }

        public short4 wwwy
        {
            get { return new short4(this.s3, this.s3, this.s3, this.s1); }
        }

        public short4 wwwz
        {
            get { return new short4(this.s3, this.s3, this.s3, this.s2); }
        }

        public short4 wwww
        {
            get { return new short4(this.s3, this.s3, this.s3, this.s3); }
        }

        public short this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 8; }
        }

        // IEquatable

        public bool Equals(short4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is short4 && Equals((short4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static short4 operator +(short4 a, short4 b) => new short4((short)(a.s0+b.s0), (short)(a.s1+b.s1), (short)(a.s2+b.s2), (short)(a.s3+b.s3));

        public static short4 operator -(short4 a, short4 b) => new short4((short)(a.s0-b.s0), (short)(a.s1-b.s1), (short)(a.s2-b.s2), (short)(a.s3-b.s3));

        public static short4 operator *(short4 a, short4 b) => new short4((short)(a.s0*b.s0), (short)(a.s1*b.s1), (short)(a.s2*b.s2), (short)(a.s3*b.s3));

        public static short4 operator /(short4 a, short4 b) => new short4((short)(a.s0/b.s0), (short)(a.s1/b.s1), (short)(a.s2/b.s2), (short)(a.s3/b.s3));

        public static short4 operator ==(short4 a, short4 b) => new short4(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0, a.s3==b.s3 ? (short)-1 : (short)0);

        public static short4 operator !=(short4 a, short4 b) => new short4(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0, a.s3!=b.s3 ? (short)-1 : (short)0);

        public static short4 operator <(short4 a, short4 b) => new short4(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0, a.s3<b.s3 ? (short)-1 : (short)0);

        public static short4 operator <=(short4 a, short4 b) => new short4(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0, a.s3<=b.s3 ? (short)-1 : (short)0);

        public static short4 operator >(short4 a, short4 b) => new short4(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0, a.s3>b.s3 ? (short)-1 : (short)0);

        public static short4 operator >=(short4 a, short4 b) => new short4(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0, a.s3>=b.s3 ? (short)-1 : (short)0);

        public static short4 operator &(short4 a, short4 b) => new short4((short)(a.s0&b.s0), (short)(a.s1&b.s1), (short)(a.s2&b.s2), (short)(a.s3&b.s3));

        public static short4 operator |(short4 a, short4 b) => new short4((short)(a.s0|b.s0), (short)(a.s1|b.s1), (short)(a.s2|b.s2), (short)(a.s3|b.s3));

        public static short4 operator ^(short4 a, short4 b) => new short4((short)(a.s0^b.s0), (short)(a.s1^b.s1), (short)(a.s2^b.s2), (short)(a.s3^b.s3));

        public static short4 operator +(short4 a) => a;

        public static short4 operator -(short4 a) => new short4((short)(-a.s0), (short)(-a.s1), (short)(-a.s2), (short)(-a.s3));

        public static short4 operator ~(short4 a) => new short4((short)(~a.s0), (short)(~a.s1), (short)(~a.s2), (short)(~a.s3));

        public static short4 operator ++(short4 a) => new short4((short)(a.s0+1), (short)(a.s1+1), (short)(a.s2+1), (short)(a.s3+1));

        public static short4 operator --(short4 a) => new short4((short)(a.s0-1), (short)(a.s1-1), (short)(a.s2-1), (short)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct short8: IVectorType, IEquatable<short8>
    {
        [FieldOffset(0)]
        public short s0;
        [FieldOffset(2)]
        public short s1;
        [FieldOffset(4)]
        public short s2;
        [FieldOffset(6)]
        public short s3;
        [FieldOffset(8)]
        public short s4;
        [FieldOffset(10)]
        public short s5;
        [FieldOffset(12)]
        public short s6;
        [FieldOffset(14)]
        public short s7;

        public short8(short v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public short8(short v0, short v1, short v2, short v3, short v4, short v5, short v6, short v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public short this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(short8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is short8 && Equals((short8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static short8 operator +(short8 a, short8 b) => new short8((short)(a.s0+b.s0), (short)(a.s1+b.s1), (short)(a.s2+b.s2), (short)(a.s3+b.s3), (short)(a.s4+b.s4), (short)(a.s5+b.s5), (short)(a.s6+b.s6), (short)(a.s7+b.s7));

        public static short8 operator -(short8 a, short8 b) => new short8((short)(a.s0-b.s0), (short)(a.s1-b.s1), (short)(a.s2-b.s2), (short)(a.s3-b.s3), (short)(a.s4-b.s4), (short)(a.s5-b.s5), (short)(a.s6-b.s6), (short)(a.s7-b.s7));

        public static short8 operator *(short8 a, short8 b) => new short8((short)(a.s0*b.s0), (short)(a.s1*b.s1), (short)(a.s2*b.s2), (short)(a.s3*b.s3), (short)(a.s4*b.s4), (short)(a.s5*b.s5), (short)(a.s6*b.s6), (short)(a.s7*b.s7));

        public static short8 operator /(short8 a, short8 b) => new short8((short)(a.s0/b.s0), (short)(a.s1/b.s1), (short)(a.s2/b.s2), (short)(a.s3/b.s3), (short)(a.s4/b.s4), (short)(a.s5/b.s5), (short)(a.s6/b.s6), (short)(a.s7/b.s7));

        public static short8 operator ==(short8 a, short8 b) => new short8(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0, a.s3==b.s3 ? (short)-1 : (short)0, a.s4==b.s4 ? (short)-1 : (short)0, a.s5==b.s5 ? (short)-1 : (short)0, a.s6==b.s6 ? (short)-1 : (short)0, a.s7==b.s7 ? (short)-1 : (short)0);

        public static short8 operator !=(short8 a, short8 b) => new short8(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0, a.s3!=b.s3 ? (short)-1 : (short)0, a.s4!=b.s4 ? (short)-1 : (short)0, a.s5!=b.s5 ? (short)-1 : (short)0, a.s6!=b.s6 ? (short)-1 : (short)0, a.s7!=b.s7 ? (short)-1 : (short)0);

        public static short8 operator <(short8 a, short8 b) => new short8(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0, a.s3<b.s3 ? (short)-1 : (short)0, a.s4<b.s4 ? (short)-1 : (short)0, a.s5<b.s5 ? (short)-1 : (short)0, a.s6<b.s6 ? (short)-1 : (short)0, a.s7<b.s7 ? (short)-1 : (short)0);

        public static short8 operator <=(short8 a, short8 b) => new short8(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0, a.s3<=b.s3 ? (short)-1 : (short)0, a.s4<=b.s4 ? (short)-1 : (short)0, a.s5<=b.s5 ? (short)-1 : (short)0, a.s6<=b.s6 ? (short)-1 : (short)0, a.s7<=b.s7 ? (short)-1 : (short)0);

        public static short8 operator >(short8 a, short8 b) => new short8(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0, a.s3>b.s3 ? (short)-1 : (short)0, a.s4>b.s4 ? (short)-1 : (short)0, a.s5>b.s5 ? (short)-1 : (short)0, a.s6>b.s6 ? (short)-1 : (short)0, a.s7>b.s7 ? (short)-1 : (short)0);

        public static short8 operator >=(short8 a, short8 b) => new short8(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0, a.s3>=b.s3 ? (short)-1 : (short)0, a.s4>=b.s4 ? (short)-1 : (short)0, a.s5>=b.s5 ? (short)-1 : (short)0, a.s6>=b.s6 ? (short)-1 : (short)0, a.s7>=b.s7 ? (short)-1 : (short)0);

        public static short8 operator &(short8 a, short8 b) => new short8((short)(a.s0&b.s0), (short)(a.s1&b.s1), (short)(a.s2&b.s2), (short)(a.s3&b.s3), (short)(a.s4&b.s4), (short)(a.s5&b.s5), (short)(a.s6&b.s6), (short)(a.s7&b.s7));

        public static short8 operator |(short8 a, short8 b) => new short8((short)(a.s0|b.s0), (short)(a.s1|b.s1), (short)(a.s2|b.s2), (short)(a.s3|b.s3), (short)(a.s4|b.s4), (short)(a.s5|b.s5), (short)(a.s6|b.s6), (short)(a.s7|b.s7));

        public static short8 operator ^(short8 a, short8 b) => new short8((short)(a.s0^b.s0), (short)(a.s1^b.s1), (short)(a.s2^b.s2), (short)(a.s3^b.s3), (short)(a.s4^b.s4), (short)(a.s5^b.s5), (short)(a.s6^b.s6), (short)(a.s7^b.s7));

        public static short8 operator +(short8 a) => a;

        public static short8 operator -(short8 a) => new short8((short)(-a.s0), (short)(-a.s1), (short)(-a.s2), (short)(-a.s3), (short)(-a.s4), (short)(-a.s5), (short)(-a.s6), (short)(-a.s7));

        public static short8 operator ~(short8 a) => new short8((short)(~a.s0), (short)(~a.s1), (short)(~a.s2), (short)(~a.s3), (short)(~a.s4), (short)(~a.s5), (short)(~a.s6), (short)(~a.s7));

        public static short8 operator ++(short8 a) => new short8((short)(a.s0+1), (short)(a.s1+1), (short)(a.s2+1), (short)(a.s3+1), (short)(a.s4+1), (short)(a.s5+1), (short)(a.s6+1), (short)(a.s7+1));

        public static short8 operator --(short8 a) => new short8((short)(a.s0-1), (short)(a.s1-1), (short)(a.s2-1), (short)(a.s3-1), (short)(a.s4-1), (short)(a.s5-1), (short)(a.s6-1), (short)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct short16: IVectorType, IEquatable<short16>
    {
        [FieldOffset(0)]
        public short s0;
        [FieldOffset(2)]
        public short s1;
        [FieldOffset(4)]
        public short s2;
        [FieldOffset(6)]
        public short s3;
        [FieldOffset(8)]
        public short s4;
        [FieldOffset(10)]
        public short s5;
        [FieldOffset(12)]
        public short s6;
        [FieldOffset(14)]
        public short s7;
        [FieldOffset(16)]
        public short s8;
        [FieldOffset(18)]
        public short s9;
        [FieldOffset(20)]
        public short sa;
        [FieldOffset(22)]
        public short sb;
        [FieldOffset(24)]
        public short sc;
        [FieldOffset(26)]
        public short sd;
        [FieldOffset(28)]
        public short se;
        [FieldOffset(30)]
        public short sf;

        public short16(short v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public short16(short v0, short v1, short v2, short v3, short v4, short v5, short v6, short v7, short v8, short v9, short va, short vb, short vc, short vd, short ve, short vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public short sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public short sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public short sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public short sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public short sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public short sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public short this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(short16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is short16 && Equals((short16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static short16 operator +(short16 a, short16 b) => new short16((short)(a.s0+b.s0), (short)(a.s1+b.s1), (short)(a.s2+b.s2), (short)(a.s3+b.s3), (short)(a.s4+b.s4), (short)(a.s5+b.s5), (short)(a.s6+b.s6), (short)(a.s7+b.s7), (short)(a.s8+b.s8), (short)(a.s9+b.s9), (short)(a.sa+b.sa), (short)(a.sb+b.sb), (short)(a.sc+b.sc), (short)(a.sd+b.sd), (short)(a.se+b.se), (short)(a.sf+b.sf));

        public static short16 operator -(short16 a, short16 b) => new short16((short)(a.s0-b.s0), (short)(a.s1-b.s1), (short)(a.s2-b.s2), (short)(a.s3-b.s3), (short)(a.s4-b.s4), (short)(a.s5-b.s5), (short)(a.s6-b.s6), (short)(a.s7-b.s7), (short)(a.s8-b.s8), (short)(a.s9-b.s9), (short)(a.sa-b.sa), (short)(a.sb-b.sb), (short)(a.sc-b.sc), (short)(a.sd-b.sd), (short)(a.se-b.se), (short)(a.sf-b.sf));

        public static short16 operator *(short16 a, short16 b) => new short16((short)(a.s0*b.s0), (short)(a.s1*b.s1), (short)(a.s2*b.s2), (short)(a.s3*b.s3), (short)(a.s4*b.s4), (short)(a.s5*b.s5), (short)(a.s6*b.s6), (short)(a.s7*b.s7), (short)(a.s8*b.s8), (short)(a.s9*b.s9), (short)(a.sa*b.sa), (short)(a.sb*b.sb), (short)(a.sc*b.sc), (short)(a.sd*b.sd), (short)(a.se*b.se), (short)(a.sf*b.sf));

        public static short16 operator /(short16 a, short16 b) => new short16((short)(a.s0/b.s0), (short)(a.s1/b.s1), (short)(a.s2/b.s2), (short)(a.s3/b.s3), (short)(a.s4/b.s4), (short)(a.s5/b.s5), (short)(a.s6/b.s6), (short)(a.s7/b.s7), (short)(a.s8/b.s8), (short)(a.s9/b.s9), (short)(a.sa/b.sa), (short)(a.sb/b.sb), (short)(a.sc/b.sc), (short)(a.sd/b.sd), (short)(a.se/b.se), (short)(a.sf/b.sf));

        public static short16 operator ==(short16 a, short16 b) => new short16(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0, a.s3==b.s3 ? (short)-1 : (short)0, a.s4==b.s4 ? (short)-1 : (short)0, a.s5==b.s5 ? (short)-1 : (short)0, a.s6==b.s6 ? (short)-1 : (short)0, a.s7==b.s7 ? (short)-1 : (short)0, a.s8==b.s8 ? (short)-1 : (short)0, a.s9==b.s9 ? (short)-1 : (short)0, a.sa==b.sa ? (short)-1 : (short)0, a.sb==b.sb ? (short)-1 : (short)0, a.sc==b.sc ? (short)-1 : (short)0, a.sd==b.sd ? (short)-1 : (short)0, a.se==b.se ? (short)-1 : (short)0, a.sf==b.sf ? (short)-1 : (short)0);

        public static short16 operator !=(short16 a, short16 b) => new short16(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0, a.s3!=b.s3 ? (short)-1 : (short)0, a.s4!=b.s4 ? (short)-1 : (short)0, a.s5!=b.s5 ? (short)-1 : (short)0, a.s6!=b.s6 ? (short)-1 : (short)0, a.s7!=b.s7 ? (short)-1 : (short)0, a.s8!=b.s8 ? (short)-1 : (short)0, a.s9!=b.s9 ? (short)-1 : (short)0, a.sa!=b.sa ? (short)-1 : (short)0, a.sb!=b.sb ? (short)-1 : (short)0, a.sc!=b.sc ? (short)-1 : (short)0, a.sd!=b.sd ? (short)-1 : (short)0, a.se!=b.se ? (short)-1 : (short)0, a.sf!=b.sf ? (short)-1 : (short)0);

        public static short16 operator <(short16 a, short16 b) => new short16(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0, a.s3<b.s3 ? (short)-1 : (short)0, a.s4<b.s4 ? (short)-1 : (short)0, a.s5<b.s5 ? (short)-1 : (short)0, a.s6<b.s6 ? (short)-1 : (short)0, a.s7<b.s7 ? (short)-1 : (short)0, a.s8<b.s8 ? (short)-1 : (short)0, a.s9<b.s9 ? (short)-1 : (short)0, a.sa<b.sa ? (short)-1 : (short)0, a.sb<b.sb ? (short)-1 : (short)0, a.sc<b.sc ? (short)-1 : (short)0, a.sd<b.sd ? (short)-1 : (short)0, a.se<b.se ? (short)-1 : (short)0, a.sf<b.sf ? (short)-1 : (short)0);

        public static short16 operator <=(short16 a, short16 b) => new short16(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0, a.s3<=b.s3 ? (short)-1 : (short)0, a.s4<=b.s4 ? (short)-1 : (short)0, a.s5<=b.s5 ? (short)-1 : (short)0, a.s6<=b.s6 ? (short)-1 : (short)0, a.s7<=b.s7 ? (short)-1 : (short)0, a.s8<=b.s8 ? (short)-1 : (short)0, a.s9<=b.s9 ? (short)-1 : (short)0, a.sa<=b.sa ? (short)-1 : (short)0, a.sb<=b.sb ? (short)-1 : (short)0, a.sc<=b.sc ? (short)-1 : (short)0, a.sd<=b.sd ? (short)-1 : (short)0, a.se<=b.se ? (short)-1 : (short)0, a.sf<=b.sf ? (short)-1 : (short)0);

        public static short16 operator >(short16 a, short16 b) => new short16(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0, a.s3>b.s3 ? (short)-1 : (short)0, a.s4>b.s4 ? (short)-1 : (short)0, a.s5>b.s5 ? (short)-1 : (short)0, a.s6>b.s6 ? (short)-1 : (short)0, a.s7>b.s7 ? (short)-1 : (short)0, a.s8>b.s8 ? (short)-1 : (short)0, a.s9>b.s9 ? (short)-1 : (short)0, a.sa>b.sa ? (short)-1 : (short)0, a.sb>b.sb ? (short)-1 : (short)0, a.sc>b.sc ? (short)-1 : (short)0, a.sd>b.sd ? (short)-1 : (short)0, a.se>b.se ? (short)-1 : (short)0, a.sf>b.sf ? (short)-1 : (short)0);

        public static short16 operator >=(short16 a, short16 b) => new short16(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0, a.s3>=b.s3 ? (short)-1 : (short)0, a.s4>=b.s4 ? (short)-1 : (short)0, a.s5>=b.s5 ? (short)-1 : (short)0, a.s6>=b.s6 ? (short)-1 : (short)0, a.s7>=b.s7 ? (short)-1 : (short)0, a.s8>=b.s8 ? (short)-1 : (short)0, a.s9>=b.s9 ? (short)-1 : (short)0, a.sa>=b.sa ? (short)-1 : (short)0, a.sb>=b.sb ? (short)-1 : (short)0, a.sc>=b.sc ? (short)-1 : (short)0, a.sd>=b.sd ? (short)-1 : (short)0, a.se>=b.se ? (short)-1 : (short)0, a.sf>=b.sf ? (short)-1 : (short)0);

        public static short16 operator &(short16 a, short16 b) => new short16((short)(a.s0&b.s0), (short)(a.s1&b.s1), (short)(a.s2&b.s2), (short)(a.s3&b.s3), (short)(a.s4&b.s4), (short)(a.s5&b.s5), (short)(a.s6&b.s6), (short)(a.s7&b.s7), (short)(a.s8&b.s8), (short)(a.s9&b.s9), (short)(a.sa&b.sa), (short)(a.sb&b.sb), (short)(a.sc&b.sc), (short)(a.sd&b.sd), (short)(a.se&b.se), (short)(a.sf&b.sf));

        public static short16 operator |(short16 a, short16 b) => new short16((short)(a.s0|b.s0), (short)(a.s1|b.s1), (short)(a.s2|b.s2), (short)(a.s3|b.s3), (short)(a.s4|b.s4), (short)(a.s5|b.s5), (short)(a.s6|b.s6), (short)(a.s7|b.s7), (short)(a.s8|b.s8), (short)(a.s9|b.s9), (short)(a.sa|b.sa), (short)(a.sb|b.sb), (short)(a.sc|b.sc), (short)(a.sd|b.sd), (short)(a.se|b.se), (short)(a.sf|b.sf));

        public static short16 operator ^(short16 a, short16 b) => new short16((short)(a.s0^b.s0), (short)(a.s1^b.s1), (short)(a.s2^b.s2), (short)(a.s3^b.s3), (short)(a.s4^b.s4), (short)(a.s5^b.s5), (short)(a.s6^b.s6), (short)(a.s7^b.s7), (short)(a.s8^b.s8), (short)(a.s9^b.s9), (short)(a.sa^b.sa), (short)(a.sb^b.sb), (short)(a.sc^b.sc), (short)(a.sd^b.sd), (short)(a.se^b.se), (short)(a.sf^b.sf));

        public static short16 operator +(short16 a) => a;

        public static short16 operator -(short16 a) => new short16((short)(-a.s0), (short)(-a.s1), (short)(-a.s2), (short)(-a.s3), (short)(-a.s4), (short)(-a.s5), (short)(-a.s6), (short)(-a.s7), (short)(-a.s8), (short)(-a.s9), (short)(-a.sa), (short)(-a.sb), (short)(-a.sc), (short)(-a.sd), (short)(-a.se), (short)(-a.sf));

        public static short16 operator ~(short16 a) => new short16((short)(~a.s0), (short)(~a.s1), (short)(~a.s2), (short)(~a.s3), (short)(~a.s4), (short)(~a.s5), (short)(~a.s6), (short)(~a.s7), (short)(~a.s8), (short)(~a.s9), (short)(~a.sa), (short)(~a.sb), (short)(~a.sc), (short)(~a.sd), (short)(~a.se), (short)(~a.sf));

        public static short16 operator ++(short16 a) => new short16((short)(a.s0+1), (short)(a.s1+1), (short)(a.s2+1), (short)(a.s3+1), (short)(a.s4+1), (short)(a.s5+1), (short)(a.s6+1), (short)(a.s7+1), (short)(a.s8+1), (short)(a.s9+1), (short)(a.sa+1), (short)(a.sb+1), (short)(a.sc+1), (short)(a.sd+1), (short)(a.se+1), (short)(a.sf+1));

        public static short16 operator --(short16 a) => new short16((short)(a.s0-1), (short)(a.s1-1), (short)(a.s2-1), (short)(a.s3-1), (short)(a.s4-1), (short)(a.s5-1), (short)(a.s6-1), (short)(a.s7-1), (short)(a.s8-1), (short)(a.s9-1), (short)(a.sa-1), (short)(a.sb-1), (short)(a.sc-1), (short)(a.sd-1), (short)(a.se-1), (short)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct ushort2: IVectorType, IEquatable<ushort2>
    {
        [FieldOffset(0)]
        public ushort s0;
        [FieldOffset(2)]
        public ushort s1;

        public ushort2(ushort v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public ushort2(ushort2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public ushort2(ushort v0, ushort v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public ushort x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public ushort y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public ushort2 xx
        {
            get { return new ushort2(this.s0, this.s0); }
        }

        public ushort2 xy
        {
            get { return new ushort2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ushort2 yx
        {
            get { return new ushort2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ushort2 yy
        {
            get { return new ushort2(this.s1, this.s1); }
        }

        public ushort this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 4; }
        }

        // IEquatable

        public bool Equals(ushort2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ushort2 && Equals((ushort2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static ushort2 operator +(ushort2 a, ushort2 b) => new ushort2((ushort)(a.s0+b.s0), (ushort)(a.s1+b.s1));

        public static ushort2 operator -(ushort2 a, ushort2 b) => new ushort2((ushort)(a.s0-b.s0), (ushort)(a.s1-b.s1));

        public static ushort2 operator *(ushort2 a, ushort2 b) => new ushort2((ushort)(a.s0*b.s0), (ushort)(a.s1*b.s1));

        public static ushort2 operator /(ushort2 a, ushort2 b) => new ushort2((ushort)(a.s0/b.s0), (ushort)(a.s1/b.s1));

        public static short2 operator ==(ushort2 a, ushort2 b) => new short2(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0);

        public static short2 operator !=(ushort2 a, ushort2 b) => new short2(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0);

        public static short2 operator <(ushort2 a, ushort2 b) => new short2(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0);

        public static short2 operator <=(ushort2 a, ushort2 b) => new short2(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0);

        public static short2 operator >(ushort2 a, ushort2 b) => new short2(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0);

        public static short2 operator >=(ushort2 a, ushort2 b) => new short2(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0);

        public static ushort2 operator &(ushort2 a, ushort2 b) => new ushort2((ushort)(a.s0&b.s0), (ushort)(a.s1&b.s1));

        public static ushort2 operator |(ushort2 a, ushort2 b) => new ushort2((ushort)(a.s0|b.s0), (ushort)(a.s1|b.s1));

        public static ushort2 operator ^(ushort2 a, ushort2 b) => new ushort2((ushort)(a.s0^b.s0), (ushort)(a.s1^b.s1));

        public static ushort2 operator +(ushort2 a) => a;

        public static ushort2 operator ~(ushort2 a) => new ushort2((ushort)(~a.s0), (ushort)(~a.s1));

        public static ushort2 operator ++(ushort2 a) => new ushort2((ushort)(a.s0+1), (ushort)(a.s1+1));

        public static ushort2 operator --(ushort2 a) => new ushort2((ushort)(a.s0-1), (ushort)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=8)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct ushort3: IVectorType, IEquatable<ushort3>
    {
        [FieldOffset(0)]
        public ushort s0;
        [FieldOffset(2)]
        public ushort s1;
        [FieldOffset(4)]
        public ushort s2;

        public ushort3(ushort v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public ushort3(ushort3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public ushort3(ushort v0, ushort2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public ushort3(ushort2 v0, ushort v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public ushort3(ushort v0, ushort v1, ushort v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public ushort x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public ushort y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public ushort z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public ushort2 xx
        {
            get { return new ushort2(this.s0, this.s0); }
        }

        public ushort2 xy
        {
            get { return new ushort2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ushort2 xz
        {
            get { return new ushort2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ushort2 yx
        {
            get { return new ushort2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ushort2 yy
        {
            get { return new ushort2(this.s1, this.s1); }
        }

        public ushort2 yz
        {
            get { return new ushort2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ushort2 zx
        {
            get { return new ushort2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ushort2 zy
        {
            get { return new ushort2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ushort2 zz
        {
            get { return new ushort2(this.s2, this.s2); }
        }

        public ushort3 xxx
        {
            get { return new ushort3(this.s0, this.s0, this.s0); }
        }

        public ushort3 xxy
        {
            get { return new ushort3(this.s0, this.s0, this.s1); }
        }

        public ushort3 xxz
        {
            get { return new ushort3(this.s0, this.s0, this.s2); }
        }

        public ushort3 xyx
        {
            get { return new ushort3(this.s0, this.s1, this.s0); }
        }

        public ushort3 xyy
        {
            get { return new ushort3(this.s0, this.s1, this.s1); }
        }

        public ushort3 xyz
        {
            get { return new ushort3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 xzx
        {
            get { return new ushort3(this.s0, this.s2, this.s0); }
        }

        public ushort3 xzy
        {
            get { return new ushort3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 xzz
        {
            get { return new ushort3(this.s0, this.s2, this.s2); }
        }

        public ushort3 yxx
        {
            get { return new ushort3(this.s1, this.s0, this.s0); }
        }

        public ushort3 yxy
        {
            get { return new ushort3(this.s1, this.s0, this.s1); }
        }

        public ushort3 yxz
        {
            get { return new ushort3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 yyx
        {
            get { return new ushort3(this.s1, this.s1, this.s0); }
        }

        public ushort3 yyy
        {
            get { return new ushort3(this.s1, this.s1, this.s1); }
        }

        public ushort3 yyz
        {
            get { return new ushort3(this.s1, this.s1, this.s2); }
        }

        public ushort3 yzx
        {
            get { return new ushort3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 yzy
        {
            get { return new ushort3(this.s1, this.s2, this.s1); }
        }

        public ushort3 yzz
        {
            get { return new ushort3(this.s1, this.s2, this.s2); }
        }

        public ushort3 zxx
        {
            get { return new ushort3(this.s2, this.s0, this.s0); }
        }

        public ushort3 zxy
        {
            get { return new ushort3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 zxz
        {
            get { return new ushort3(this.s2, this.s0, this.s2); }
        }

        public ushort3 zyx
        {
            get { return new ushort3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 zyy
        {
            get { return new ushort3(this.s2, this.s1, this.s1); }
        }

        public ushort3 zyz
        {
            get { return new ushort3(this.s2, this.s1, this.s2); }
        }

        public ushort3 zzx
        {
            get { return new ushort3(this.s2, this.s2, this.s0); }
        }

        public ushort3 zzy
        {
            get { return new ushort3(this.s2, this.s2, this.s1); }
        }

        public ushort3 zzz
        {
            get { return new ushort3(this.s2, this.s2, this.s2); }
        }

        public ushort this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 6; }
        }

        // IEquatable

        public bool Equals(ushort3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ushort3 && Equals((ushort3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static ushort3 operator +(ushort3 a, ushort3 b) => new ushort3((ushort)(a.s0+b.s0), (ushort)(a.s1+b.s1), (ushort)(a.s2+b.s2));

        public static ushort3 operator -(ushort3 a, ushort3 b) => new ushort3((ushort)(a.s0-b.s0), (ushort)(a.s1-b.s1), (ushort)(a.s2-b.s2));

        public static ushort3 operator *(ushort3 a, ushort3 b) => new ushort3((ushort)(a.s0*b.s0), (ushort)(a.s1*b.s1), (ushort)(a.s2*b.s2));

        public static ushort3 operator /(ushort3 a, ushort3 b) => new ushort3((ushort)(a.s0/b.s0), (ushort)(a.s1/b.s1), (ushort)(a.s2/b.s2));

        public static short3 operator ==(ushort3 a, ushort3 b) => new short3(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0);

        public static short3 operator !=(ushort3 a, ushort3 b) => new short3(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0);

        public static short3 operator <(ushort3 a, ushort3 b) => new short3(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0);

        public static short3 operator <=(ushort3 a, ushort3 b) => new short3(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0);

        public static short3 operator >(ushort3 a, ushort3 b) => new short3(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0);

        public static short3 operator >=(ushort3 a, ushort3 b) => new short3(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0);

        public static ushort3 operator &(ushort3 a, ushort3 b) => new ushort3((ushort)(a.s0&b.s0), (ushort)(a.s1&b.s1), (ushort)(a.s2&b.s2));

        public static ushort3 operator |(ushort3 a, ushort3 b) => new ushort3((ushort)(a.s0|b.s0), (ushort)(a.s1|b.s1), (ushort)(a.s2|b.s2));

        public static ushort3 operator ^(ushort3 a, ushort3 b) => new ushort3((ushort)(a.s0^b.s0), (ushort)(a.s1^b.s1), (ushort)(a.s2^b.s2));

        public static ushort3 operator +(ushort3 a) => a;

        public static ushort3 operator ~(ushort3 a) => new ushort3((ushort)(~a.s0), (ushort)(~a.s1), (ushort)(~a.s2));

        public static ushort3 operator ++(ushort3 a) => new ushort3((ushort)(a.s0+1), (ushort)(a.s1+1), (ushort)(a.s2+1));

        public static ushort3 operator --(ushort3 a) => new ushort3((ushort)(a.s0-1), (ushort)(a.s1-1), (ushort)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct ushort4: IVectorType, IEquatable<ushort4>
    {
        [FieldOffset(0)]
        public ushort s0;
        [FieldOffset(2)]
        public ushort s1;
        [FieldOffset(4)]
        public ushort s2;
        [FieldOffset(6)]
        public ushort s3;

        public ushort4(ushort v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public ushort4(ushort4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public ushort4(ushort v0, ushort3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public ushort4(ushort2 v0, ushort2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public ushort4(ushort3 v0, ushort v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public ushort4(ushort v0, ushort v1, ushort2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public ushort4(ushort v0, ushort2 v1, ushort v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public ushort4(ushort2 v0, ushort v1, ushort v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public ushort4(ushort v0, ushort v1, ushort v2, ushort v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public ushort x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public ushort y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public ushort z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public ushort w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public ushort2 xx
        {
            get { return new ushort2(this.s0, this.s0); }
        }

        public ushort2 xy
        {
            get { return new ushort2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ushort2 xz
        {
            get { return new ushort2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ushort2 xw
        {
            get { return new ushort2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public ushort2 yx
        {
            get { return new ushort2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ushort2 yy
        {
            get { return new ushort2(this.s1, this.s1); }
        }

        public ushort2 yz
        {
            get { return new ushort2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ushort2 yw
        {
            get { return new ushort2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public ushort2 zx
        {
            get { return new ushort2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ushort2 zy
        {
            get { return new ushort2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ushort2 zz
        {
            get { return new ushort2(this.s2, this.s2); }
        }

        public ushort2 zw
        {
            get { return new ushort2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public ushort2 wx
        {
            get { return new ushort2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ushort2 wy
        {
            get { return new ushort2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ushort2 wz
        {
            get { return new ushort2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ushort2 ww
        {
            get { return new ushort2(this.s3, this.s3); }
        }

        public ushort3 xxx
        {
            get { return new ushort3(this.s0, this.s0, this.s0); }
        }

        public ushort3 xxy
        {
            get { return new ushort3(this.s0, this.s0, this.s1); }
        }

        public ushort3 xxz
        {
            get { return new ushort3(this.s0, this.s0, this.s2); }
        }

        public ushort3 xxw
        {
            get { return new ushort3(this.s0, this.s0, this.s3); }
        }

        public ushort3 xyx
        {
            get { return new ushort3(this.s0, this.s1, this.s0); }
        }

        public ushort3 xyy
        {
            get { return new ushort3(this.s0, this.s1, this.s1); }
        }

        public ushort3 xyz
        {
            get { return new ushort3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 xyw
        {
            get { return new ushort3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ushort3 xzx
        {
            get { return new ushort3(this.s0, this.s2, this.s0); }
        }

        public ushort3 xzy
        {
            get { return new ushort3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 xzz
        {
            get { return new ushort3(this.s0, this.s2, this.s2); }
        }

        public ushort3 xzw
        {
            get { return new ushort3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ushort3 xwx
        {
            get { return new ushort3(this.s0, this.s3, this.s0); }
        }

        public ushort3 xwy
        {
            get { return new ushort3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 xwz
        {
            get { return new ushort3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 xww
        {
            get { return new ushort3(this.s0, this.s3, this.s3); }
        }

        public ushort3 yxx
        {
            get { return new ushort3(this.s1, this.s0, this.s0); }
        }

        public ushort3 yxy
        {
            get { return new ushort3(this.s1, this.s0, this.s1); }
        }

        public ushort3 yxz
        {
            get { return new ushort3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 yxw
        {
            get { return new ushort3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ushort3 yyx
        {
            get { return new ushort3(this.s1, this.s1, this.s0); }
        }

        public ushort3 yyy
        {
            get { return new ushort3(this.s1, this.s1, this.s1); }
        }

        public ushort3 yyz
        {
            get { return new ushort3(this.s1, this.s1, this.s2); }
        }

        public ushort3 yyw
        {
            get { return new ushort3(this.s1, this.s1, this.s3); }
        }

        public ushort3 yzx
        {
            get { return new ushort3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 yzy
        {
            get { return new ushort3(this.s1, this.s2, this.s1); }
        }

        public ushort3 yzz
        {
            get { return new ushort3(this.s1, this.s2, this.s2); }
        }

        public ushort3 yzw
        {
            get { return new ushort3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ushort3 ywx
        {
            get { return new ushort3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 ywy
        {
            get { return new ushort3(this.s1, this.s3, this.s1); }
        }

        public ushort3 ywz
        {
            get { return new ushort3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 yww
        {
            get { return new ushort3(this.s1, this.s3, this.s3); }
        }

        public ushort3 zxx
        {
            get { return new ushort3(this.s2, this.s0, this.s0); }
        }

        public ushort3 zxy
        {
            get { return new ushort3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 zxz
        {
            get { return new ushort3(this.s2, this.s0, this.s2); }
        }

        public ushort3 zxw
        {
            get { return new ushort3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ushort3 zyx
        {
            get { return new ushort3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 zyy
        {
            get { return new ushort3(this.s2, this.s1, this.s1); }
        }

        public ushort3 zyz
        {
            get { return new ushort3(this.s2, this.s1, this.s2); }
        }

        public ushort3 zyw
        {
            get { return new ushort3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ushort3 zzx
        {
            get { return new ushort3(this.s2, this.s2, this.s0); }
        }

        public ushort3 zzy
        {
            get { return new ushort3(this.s2, this.s2, this.s1); }
        }

        public ushort3 zzz
        {
            get { return new ushort3(this.s2, this.s2, this.s2); }
        }

        public ushort3 zzw
        {
            get { return new ushort3(this.s2, this.s2, this.s3); }
        }

        public ushort3 zwx
        {
            get { return new ushort3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 zwy
        {
            get { return new ushort3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 zwz
        {
            get { return new ushort3(this.s2, this.s3, this.s2); }
        }

        public ushort3 zww
        {
            get { return new ushort3(this.s2, this.s3, this.s3); }
        }

        public ushort3 wxx
        {
            get { return new ushort3(this.s3, this.s0, this.s0); }
        }

        public ushort3 wxy
        {
            get { return new ushort3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 wxz
        {
            get { return new ushort3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 wxw
        {
            get { return new ushort3(this.s3, this.s0, this.s3); }
        }

        public ushort3 wyx
        {
            get { return new ushort3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 wyy
        {
            get { return new ushort3(this.s3, this.s1, this.s1); }
        }

        public ushort3 wyz
        {
            get { return new ushort3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ushort3 wyw
        {
            get { return new ushort3(this.s3, this.s1, this.s3); }
        }

        public ushort3 wzx
        {
            get { return new ushort3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ushort3 wzy
        {
            get { return new ushort3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ushort3 wzz
        {
            get { return new ushort3(this.s3, this.s2, this.s2); }
        }

        public ushort3 wzw
        {
            get { return new ushort3(this.s3, this.s2, this.s3); }
        }

        public ushort3 wwx
        {
            get { return new ushort3(this.s3, this.s3, this.s0); }
        }

        public ushort3 wwy
        {
            get { return new ushort3(this.s3, this.s3, this.s1); }
        }

        public ushort3 wwz
        {
            get { return new ushort3(this.s3, this.s3, this.s2); }
        }

        public ushort3 www
        {
            get { return new ushort3(this.s3, this.s3, this.s3); }
        }

        public ushort4 xxxx
        {
            get { return new ushort4(this.s0, this.s0, this.s0, this.s0); }
        }

        public ushort4 xxxy
        {
            get { return new ushort4(this.s0, this.s0, this.s0, this.s1); }
        }

        public ushort4 xxxz
        {
            get { return new ushort4(this.s0, this.s0, this.s0, this.s2); }
        }

        public ushort4 xxxw
        {
            get { return new ushort4(this.s0, this.s0, this.s0, this.s3); }
        }

        public ushort4 xxyx
        {
            get { return new ushort4(this.s0, this.s0, this.s1, this.s0); }
        }

        public ushort4 xxyy
        {
            get { return new ushort4(this.s0, this.s0, this.s1, this.s1); }
        }

        public ushort4 xxyz
        {
            get { return new ushort4(this.s0, this.s0, this.s1, this.s2); }
        }

        public ushort4 xxyw
        {
            get { return new ushort4(this.s0, this.s0, this.s1, this.s3); }
        }

        public ushort4 xxzx
        {
            get { return new ushort4(this.s0, this.s0, this.s2, this.s0); }
        }

        public ushort4 xxzy
        {
            get { return new ushort4(this.s0, this.s0, this.s2, this.s1); }
        }

        public ushort4 xxzz
        {
            get { return new ushort4(this.s0, this.s0, this.s2, this.s2); }
        }

        public ushort4 xxzw
        {
            get { return new ushort4(this.s0, this.s0, this.s2, this.s3); }
        }

        public ushort4 xxwx
        {
            get { return new ushort4(this.s0, this.s0, this.s3, this.s0); }
        }

        public ushort4 xxwy
        {
            get { return new ushort4(this.s0, this.s0, this.s3, this.s1); }
        }

        public ushort4 xxwz
        {
            get { return new ushort4(this.s0, this.s0, this.s3, this.s2); }
        }

        public ushort4 xxww
        {
            get { return new ushort4(this.s0, this.s0, this.s3, this.s3); }
        }

        public ushort4 xyxx
        {
            get { return new ushort4(this.s0, this.s1, this.s0, this.s0); }
        }

        public ushort4 xyxy
        {
            get { return new ushort4(this.s0, this.s1, this.s0, this.s1); }
        }

        public ushort4 xyxz
        {
            get { return new ushort4(this.s0, this.s1, this.s0, this.s2); }
        }

        public ushort4 xyxw
        {
            get { return new ushort4(this.s0, this.s1, this.s0, this.s3); }
        }

        public ushort4 xyyx
        {
            get { return new ushort4(this.s0, this.s1, this.s1, this.s0); }
        }

        public ushort4 xyyy
        {
            get { return new ushort4(this.s0, this.s1, this.s1, this.s1); }
        }

        public ushort4 xyyz
        {
            get { return new ushort4(this.s0, this.s1, this.s1, this.s2); }
        }

        public ushort4 xyyw
        {
            get { return new ushort4(this.s0, this.s1, this.s1, this.s3); }
        }

        public ushort4 xyzx
        {
            get { return new ushort4(this.s0, this.s1, this.s2, this.s0); }
        }

        public ushort4 xyzy
        {
            get { return new ushort4(this.s0, this.s1, this.s2, this.s1); }
        }

        public ushort4 xyzz
        {
            get { return new ushort4(this.s0, this.s1, this.s2, this.s2); }
        }

        public ushort4 xyzw
        {
            get { return new ushort4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ushort4 xywx
        {
            get { return new ushort4(this.s0, this.s1, this.s3, this.s0); }
        }

        public ushort4 xywy
        {
            get { return new ushort4(this.s0, this.s1, this.s3, this.s1); }
        }

        public ushort4 xywz
        {
            get { return new ushort4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ushort4 xyww
        {
            get { return new ushort4(this.s0, this.s1, this.s3, this.s3); }
        }

        public ushort4 xzxx
        {
            get { return new ushort4(this.s0, this.s2, this.s0, this.s0); }
        }

        public ushort4 xzxy
        {
            get { return new ushort4(this.s0, this.s2, this.s0, this.s1); }
        }

        public ushort4 xzxz
        {
            get { return new ushort4(this.s0, this.s2, this.s0, this.s2); }
        }

        public ushort4 xzxw
        {
            get { return new ushort4(this.s0, this.s2, this.s0, this.s3); }
        }

        public ushort4 xzyx
        {
            get { return new ushort4(this.s0, this.s2, this.s1, this.s0); }
        }

        public ushort4 xzyy
        {
            get { return new ushort4(this.s0, this.s2, this.s1, this.s1); }
        }

        public ushort4 xzyz
        {
            get { return new ushort4(this.s0, this.s2, this.s1, this.s2); }
        }

        public ushort4 xzyw
        {
            get { return new ushort4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ushort4 xzzx
        {
            get { return new ushort4(this.s0, this.s2, this.s2, this.s0); }
        }

        public ushort4 xzzy
        {
            get { return new ushort4(this.s0, this.s2, this.s2, this.s1); }
        }

        public ushort4 xzzz
        {
            get { return new ushort4(this.s0, this.s2, this.s2, this.s2); }
        }

        public ushort4 xzzw
        {
            get { return new ushort4(this.s0, this.s2, this.s2, this.s3); }
        }

        public ushort4 xzwx
        {
            get { return new ushort4(this.s0, this.s2, this.s3, this.s0); }
        }

        public ushort4 xzwy
        {
            get { return new ushort4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ushort4 xzwz
        {
            get { return new ushort4(this.s0, this.s2, this.s3, this.s2); }
        }

        public ushort4 xzww
        {
            get { return new ushort4(this.s0, this.s2, this.s3, this.s3); }
        }

        public ushort4 xwxx
        {
            get { return new ushort4(this.s0, this.s3, this.s0, this.s0); }
        }

        public ushort4 xwxy
        {
            get { return new ushort4(this.s0, this.s3, this.s0, this.s1); }
        }

        public ushort4 xwxz
        {
            get { return new ushort4(this.s0, this.s3, this.s0, this.s2); }
        }

        public ushort4 xwxw
        {
            get { return new ushort4(this.s0, this.s3, this.s0, this.s3); }
        }

        public ushort4 xwyx
        {
            get { return new ushort4(this.s0, this.s3, this.s1, this.s0); }
        }

        public ushort4 xwyy
        {
            get { return new ushort4(this.s0, this.s3, this.s1, this.s1); }
        }

        public ushort4 xwyz
        {
            get { return new ushort4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ushort4 xwyw
        {
            get { return new ushort4(this.s0, this.s3, this.s1, this.s3); }
        }

        public ushort4 xwzx
        {
            get { return new ushort4(this.s0, this.s3, this.s2, this.s0); }
        }

        public ushort4 xwzy
        {
            get { return new ushort4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ushort4 xwzz
        {
            get { return new ushort4(this.s0, this.s3, this.s2, this.s2); }
        }

        public ushort4 xwzw
        {
            get { return new ushort4(this.s0, this.s3, this.s2, this.s3); }
        }

        public ushort4 xwwx
        {
            get { return new ushort4(this.s0, this.s3, this.s3, this.s0); }
        }

        public ushort4 xwwy
        {
            get { return new ushort4(this.s0, this.s3, this.s3, this.s1); }
        }

        public ushort4 xwwz
        {
            get { return new ushort4(this.s0, this.s3, this.s3, this.s2); }
        }

        public ushort4 xwww
        {
            get { return new ushort4(this.s0, this.s3, this.s3, this.s3); }
        }

        public ushort4 yxxx
        {
            get { return new ushort4(this.s1, this.s0, this.s0, this.s0); }
        }

        public ushort4 yxxy
        {
            get { return new ushort4(this.s1, this.s0, this.s0, this.s1); }
        }

        public ushort4 yxxz
        {
            get { return new ushort4(this.s1, this.s0, this.s0, this.s2); }
        }

        public ushort4 yxxw
        {
            get { return new ushort4(this.s1, this.s0, this.s0, this.s3); }
        }

        public ushort4 yxyx
        {
            get { return new ushort4(this.s1, this.s0, this.s1, this.s0); }
        }

        public ushort4 yxyy
        {
            get { return new ushort4(this.s1, this.s0, this.s1, this.s1); }
        }

        public ushort4 yxyz
        {
            get { return new ushort4(this.s1, this.s0, this.s1, this.s2); }
        }

        public ushort4 yxyw
        {
            get { return new ushort4(this.s1, this.s0, this.s1, this.s3); }
        }

        public ushort4 yxzx
        {
            get { return new ushort4(this.s1, this.s0, this.s2, this.s0); }
        }

        public ushort4 yxzy
        {
            get { return new ushort4(this.s1, this.s0, this.s2, this.s1); }
        }

        public ushort4 yxzz
        {
            get { return new ushort4(this.s1, this.s0, this.s2, this.s2); }
        }

        public ushort4 yxzw
        {
            get { return new ushort4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ushort4 yxwx
        {
            get { return new ushort4(this.s1, this.s0, this.s3, this.s0); }
        }

        public ushort4 yxwy
        {
            get { return new ushort4(this.s1, this.s0, this.s3, this.s1); }
        }

        public ushort4 yxwz
        {
            get { return new ushort4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ushort4 yxww
        {
            get { return new ushort4(this.s1, this.s0, this.s3, this.s3); }
        }

        public ushort4 yyxx
        {
            get { return new ushort4(this.s1, this.s1, this.s0, this.s0); }
        }

        public ushort4 yyxy
        {
            get { return new ushort4(this.s1, this.s1, this.s0, this.s1); }
        }

        public ushort4 yyxz
        {
            get { return new ushort4(this.s1, this.s1, this.s0, this.s2); }
        }

        public ushort4 yyxw
        {
            get { return new ushort4(this.s1, this.s1, this.s0, this.s3); }
        }

        public ushort4 yyyx
        {
            get { return new ushort4(this.s1, this.s1, this.s1, this.s0); }
        }

        public ushort4 yyyy
        {
            get { return new ushort4(this.s1, this.s1, this.s1, this.s1); }
        }

        public ushort4 yyyz
        {
            get { return new ushort4(this.s1, this.s1, this.s1, this.s2); }
        }

        public ushort4 yyyw
        {
            get { return new ushort4(this.s1, this.s1, this.s1, this.s3); }
        }

        public ushort4 yyzx
        {
            get { return new ushort4(this.s1, this.s1, this.s2, this.s0); }
        }

        public ushort4 yyzy
        {
            get { return new ushort4(this.s1, this.s1, this.s2, this.s1); }
        }

        public ushort4 yyzz
        {
            get { return new ushort4(this.s1, this.s1, this.s2, this.s2); }
        }

        public ushort4 yyzw
        {
            get { return new ushort4(this.s1, this.s1, this.s2, this.s3); }
        }

        public ushort4 yywx
        {
            get { return new ushort4(this.s1, this.s1, this.s3, this.s0); }
        }

        public ushort4 yywy
        {
            get { return new ushort4(this.s1, this.s1, this.s3, this.s1); }
        }

        public ushort4 yywz
        {
            get { return new ushort4(this.s1, this.s1, this.s3, this.s2); }
        }

        public ushort4 yyww
        {
            get { return new ushort4(this.s1, this.s1, this.s3, this.s3); }
        }

        public ushort4 yzxx
        {
            get { return new ushort4(this.s1, this.s2, this.s0, this.s0); }
        }

        public ushort4 yzxy
        {
            get { return new ushort4(this.s1, this.s2, this.s0, this.s1); }
        }

        public ushort4 yzxz
        {
            get { return new ushort4(this.s1, this.s2, this.s0, this.s2); }
        }

        public ushort4 yzxw
        {
            get { return new ushort4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ushort4 yzyx
        {
            get { return new ushort4(this.s1, this.s2, this.s1, this.s0); }
        }

        public ushort4 yzyy
        {
            get { return new ushort4(this.s1, this.s2, this.s1, this.s1); }
        }

        public ushort4 yzyz
        {
            get { return new ushort4(this.s1, this.s2, this.s1, this.s2); }
        }

        public ushort4 yzyw
        {
            get { return new ushort4(this.s1, this.s2, this.s1, this.s3); }
        }

        public ushort4 yzzx
        {
            get { return new ushort4(this.s1, this.s2, this.s2, this.s0); }
        }

        public ushort4 yzzy
        {
            get { return new ushort4(this.s1, this.s2, this.s2, this.s1); }
        }

        public ushort4 yzzz
        {
            get { return new ushort4(this.s1, this.s2, this.s2, this.s2); }
        }

        public ushort4 yzzw
        {
            get { return new ushort4(this.s1, this.s2, this.s2, this.s3); }
        }

        public ushort4 yzwx
        {
            get { return new ushort4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ushort4 yzwy
        {
            get { return new ushort4(this.s1, this.s2, this.s3, this.s1); }
        }

        public ushort4 yzwz
        {
            get { return new ushort4(this.s1, this.s2, this.s3, this.s2); }
        }

        public ushort4 yzww
        {
            get { return new ushort4(this.s1, this.s2, this.s3, this.s3); }
        }

        public ushort4 ywxx
        {
            get { return new ushort4(this.s1, this.s3, this.s0, this.s0); }
        }

        public ushort4 ywxy
        {
            get { return new ushort4(this.s1, this.s3, this.s0, this.s1); }
        }

        public ushort4 ywxz
        {
            get { return new ushort4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ushort4 ywxw
        {
            get { return new ushort4(this.s1, this.s3, this.s0, this.s3); }
        }

        public ushort4 ywyx
        {
            get { return new ushort4(this.s1, this.s3, this.s1, this.s0); }
        }

        public ushort4 ywyy
        {
            get { return new ushort4(this.s1, this.s3, this.s1, this.s1); }
        }

        public ushort4 ywyz
        {
            get { return new ushort4(this.s1, this.s3, this.s1, this.s2); }
        }

        public ushort4 ywyw
        {
            get { return new ushort4(this.s1, this.s3, this.s1, this.s3); }
        }

        public ushort4 ywzx
        {
            get { return new ushort4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ushort4 ywzy
        {
            get { return new ushort4(this.s1, this.s3, this.s2, this.s1); }
        }

        public ushort4 ywzz
        {
            get { return new ushort4(this.s1, this.s3, this.s2, this.s2); }
        }

        public ushort4 ywzw
        {
            get { return new ushort4(this.s1, this.s3, this.s2, this.s3); }
        }

        public ushort4 ywwx
        {
            get { return new ushort4(this.s1, this.s3, this.s3, this.s0); }
        }

        public ushort4 ywwy
        {
            get { return new ushort4(this.s1, this.s3, this.s3, this.s1); }
        }

        public ushort4 ywwz
        {
            get { return new ushort4(this.s1, this.s3, this.s3, this.s2); }
        }

        public ushort4 ywww
        {
            get { return new ushort4(this.s1, this.s3, this.s3, this.s3); }
        }

        public ushort4 zxxx
        {
            get { return new ushort4(this.s2, this.s0, this.s0, this.s0); }
        }

        public ushort4 zxxy
        {
            get { return new ushort4(this.s2, this.s0, this.s0, this.s1); }
        }

        public ushort4 zxxz
        {
            get { return new ushort4(this.s2, this.s0, this.s0, this.s2); }
        }

        public ushort4 zxxw
        {
            get { return new ushort4(this.s2, this.s0, this.s0, this.s3); }
        }

        public ushort4 zxyx
        {
            get { return new ushort4(this.s2, this.s0, this.s1, this.s0); }
        }

        public ushort4 zxyy
        {
            get { return new ushort4(this.s2, this.s0, this.s1, this.s1); }
        }

        public ushort4 zxyz
        {
            get { return new ushort4(this.s2, this.s0, this.s1, this.s2); }
        }

        public ushort4 zxyw
        {
            get { return new ushort4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ushort4 zxzx
        {
            get { return new ushort4(this.s2, this.s0, this.s2, this.s0); }
        }

        public ushort4 zxzy
        {
            get { return new ushort4(this.s2, this.s0, this.s2, this.s1); }
        }

        public ushort4 zxzz
        {
            get { return new ushort4(this.s2, this.s0, this.s2, this.s2); }
        }

        public ushort4 zxzw
        {
            get { return new ushort4(this.s2, this.s0, this.s2, this.s3); }
        }

        public ushort4 zxwx
        {
            get { return new ushort4(this.s2, this.s0, this.s3, this.s0); }
        }

        public ushort4 zxwy
        {
            get { return new ushort4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ushort4 zxwz
        {
            get { return new ushort4(this.s2, this.s0, this.s3, this.s2); }
        }

        public ushort4 zxww
        {
            get { return new ushort4(this.s2, this.s0, this.s3, this.s3); }
        }

        public ushort4 zyxx
        {
            get { return new ushort4(this.s2, this.s1, this.s0, this.s0); }
        }

        public ushort4 zyxy
        {
            get { return new ushort4(this.s2, this.s1, this.s0, this.s1); }
        }

        public ushort4 zyxz
        {
            get { return new ushort4(this.s2, this.s1, this.s0, this.s2); }
        }

        public ushort4 zyxw
        {
            get { return new ushort4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ushort4 zyyx
        {
            get { return new ushort4(this.s2, this.s1, this.s1, this.s0); }
        }

        public ushort4 zyyy
        {
            get { return new ushort4(this.s2, this.s1, this.s1, this.s1); }
        }

        public ushort4 zyyz
        {
            get { return new ushort4(this.s2, this.s1, this.s1, this.s2); }
        }

        public ushort4 zyyw
        {
            get { return new ushort4(this.s2, this.s1, this.s1, this.s3); }
        }

        public ushort4 zyzx
        {
            get { return new ushort4(this.s2, this.s1, this.s2, this.s0); }
        }

        public ushort4 zyzy
        {
            get { return new ushort4(this.s2, this.s1, this.s2, this.s1); }
        }

        public ushort4 zyzz
        {
            get { return new ushort4(this.s2, this.s1, this.s2, this.s2); }
        }

        public ushort4 zyzw
        {
            get { return new ushort4(this.s2, this.s1, this.s2, this.s3); }
        }

        public ushort4 zywx
        {
            get { return new ushort4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ushort4 zywy
        {
            get { return new ushort4(this.s2, this.s1, this.s3, this.s1); }
        }

        public ushort4 zywz
        {
            get { return new ushort4(this.s2, this.s1, this.s3, this.s2); }
        }

        public ushort4 zyww
        {
            get { return new ushort4(this.s2, this.s1, this.s3, this.s3); }
        }

        public ushort4 zzxx
        {
            get { return new ushort4(this.s2, this.s2, this.s0, this.s0); }
        }

        public ushort4 zzxy
        {
            get { return new ushort4(this.s2, this.s2, this.s0, this.s1); }
        }

        public ushort4 zzxz
        {
            get { return new ushort4(this.s2, this.s2, this.s0, this.s2); }
        }

        public ushort4 zzxw
        {
            get { return new ushort4(this.s2, this.s2, this.s0, this.s3); }
        }

        public ushort4 zzyx
        {
            get { return new ushort4(this.s2, this.s2, this.s1, this.s0); }
        }

        public ushort4 zzyy
        {
            get { return new ushort4(this.s2, this.s2, this.s1, this.s1); }
        }

        public ushort4 zzyz
        {
            get { return new ushort4(this.s2, this.s2, this.s1, this.s2); }
        }

        public ushort4 zzyw
        {
            get { return new ushort4(this.s2, this.s2, this.s1, this.s3); }
        }

        public ushort4 zzzx
        {
            get { return new ushort4(this.s2, this.s2, this.s2, this.s0); }
        }

        public ushort4 zzzy
        {
            get { return new ushort4(this.s2, this.s2, this.s2, this.s1); }
        }

        public ushort4 zzzz
        {
            get { return new ushort4(this.s2, this.s2, this.s2, this.s2); }
        }

        public ushort4 zzzw
        {
            get { return new ushort4(this.s2, this.s2, this.s2, this.s3); }
        }

        public ushort4 zzwx
        {
            get { return new ushort4(this.s2, this.s2, this.s3, this.s0); }
        }

        public ushort4 zzwy
        {
            get { return new ushort4(this.s2, this.s2, this.s3, this.s1); }
        }

        public ushort4 zzwz
        {
            get { return new ushort4(this.s2, this.s2, this.s3, this.s2); }
        }

        public ushort4 zzww
        {
            get { return new ushort4(this.s2, this.s2, this.s3, this.s3); }
        }

        public ushort4 zwxx
        {
            get { return new ushort4(this.s2, this.s3, this.s0, this.s0); }
        }

        public ushort4 zwxy
        {
            get { return new ushort4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ushort4 zwxz
        {
            get { return new ushort4(this.s2, this.s3, this.s0, this.s2); }
        }

        public ushort4 zwxw
        {
            get { return new ushort4(this.s2, this.s3, this.s0, this.s3); }
        }

        public ushort4 zwyx
        {
            get { return new ushort4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ushort4 zwyy
        {
            get { return new ushort4(this.s2, this.s3, this.s1, this.s1); }
        }

        public ushort4 zwyz
        {
            get { return new ushort4(this.s2, this.s3, this.s1, this.s2); }
        }

        public ushort4 zwyw
        {
            get { return new ushort4(this.s2, this.s3, this.s1, this.s3); }
        }

        public ushort4 zwzx
        {
            get { return new ushort4(this.s2, this.s3, this.s2, this.s0); }
        }

        public ushort4 zwzy
        {
            get { return new ushort4(this.s2, this.s3, this.s2, this.s1); }
        }

        public ushort4 zwzz
        {
            get { return new ushort4(this.s2, this.s3, this.s2, this.s2); }
        }

        public ushort4 zwzw
        {
            get { return new ushort4(this.s2, this.s3, this.s2, this.s3); }
        }

        public ushort4 zwwx
        {
            get { return new ushort4(this.s2, this.s3, this.s3, this.s0); }
        }

        public ushort4 zwwy
        {
            get { return new ushort4(this.s2, this.s3, this.s3, this.s1); }
        }

        public ushort4 zwwz
        {
            get { return new ushort4(this.s2, this.s3, this.s3, this.s2); }
        }

        public ushort4 zwww
        {
            get { return new ushort4(this.s2, this.s3, this.s3, this.s3); }
        }

        public ushort4 wxxx
        {
            get { return new ushort4(this.s3, this.s0, this.s0, this.s0); }
        }

        public ushort4 wxxy
        {
            get { return new ushort4(this.s3, this.s0, this.s0, this.s1); }
        }

        public ushort4 wxxz
        {
            get { return new ushort4(this.s3, this.s0, this.s0, this.s2); }
        }

        public ushort4 wxxw
        {
            get { return new ushort4(this.s3, this.s0, this.s0, this.s3); }
        }

        public ushort4 wxyx
        {
            get { return new ushort4(this.s3, this.s0, this.s1, this.s0); }
        }

        public ushort4 wxyy
        {
            get { return new ushort4(this.s3, this.s0, this.s1, this.s1); }
        }

        public ushort4 wxyz
        {
            get { return new ushort4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ushort4 wxyw
        {
            get { return new ushort4(this.s3, this.s0, this.s1, this.s3); }
        }

        public ushort4 wxzx
        {
            get { return new ushort4(this.s3, this.s0, this.s2, this.s0); }
        }

        public ushort4 wxzy
        {
            get { return new ushort4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ushort4 wxzz
        {
            get { return new ushort4(this.s3, this.s0, this.s2, this.s2); }
        }

        public ushort4 wxzw
        {
            get { return new ushort4(this.s3, this.s0, this.s2, this.s3); }
        }

        public ushort4 wxwx
        {
            get { return new ushort4(this.s3, this.s0, this.s3, this.s0); }
        }

        public ushort4 wxwy
        {
            get { return new ushort4(this.s3, this.s0, this.s3, this.s1); }
        }

        public ushort4 wxwz
        {
            get { return new ushort4(this.s3, this.s0, this.s3, this.s2); }
        }

        public ushort4 wxww
        {
            get { return new ushort4(this.s3, this.s0, this.s3, this.s3); }
        }

        public ushort4 wyxx
        {
            get { return new ushort4(this.s3, this.s1, this.s0, this.s0); }
        }

        public ushort4 wyxy
        {
            get { return new ushort4(this.s3, this.s1, this.s0, this.s1); }
        }

        public ushort4 wyxz
        {
            get { return new ushort4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ushort4 wyxw
        {
            get { return new ushort4(this.s3, this.s1, this.s0, this.s3); }
        }

        public ushort4 wyyx
        {
            get { return new ushort4(this.s3, this.s1, this.s1, this.s0); }
        }

        public ushort4 wyyy
        {
            get { return new ushort4(this.s3, this.s1, this.s1, this.s1); }
        }

        public ushort4 wyyz
        {
            get { return new ushort4(this.s3, this.s1, this.s1, this.s2); }
        }

        public ushort4 wyyw
        {
            get { return new ushort4(this.s3, this.s1, this.s1, this.s3); }
        }

        public ushort4 wyzx
        {
            get { return new ushort4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ushort4 wyzy
        {
            get { return new ushort4(this.s3, this.s1, this.s2, this.s1); }
        }

        public ushort4 wyzz
        {
            get { return new ushort4(this.s3, this.s1, this.s2, this.s2); }
        }

        public ushort4 wyzw
        {
            get { return new ushort4(this.s3, this.s1, this.s2, this.s3); }
        }

        public ushort4 wywx
        {
            get { return new ushort4(this.s3, this.s1, this.s3, this.s0); }
        }

        public ushort4 wywy
        {
            get { return new ushort4(this.s3, this.s1, this.s3, this.s1); }
        }

        public ushort4 wywz
        {
            get { return new ushort4(this.s3, this.s1, this.s3, this.s2); }
        }

        public ushort4 wyww
        {
            get { return new ushort4(this.s3, this.s1, this.s3, this.s3); }
        }

        public ushort4 wzxx
        {
            get { return new ushort4(this.s3, this.s2, this.s0, this.s0); }
        }

        public ushort4 wzxy
        {
            get { return new ushort4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ushort4 wzxz
        {
            get { return new ushort4(this.s3, this.s2, this.s0, this.s2); }
        }

        public ushort4 wzxw
        {
            get { return new ushort4(this.s3, this.s2, this.s0, this.s3); }
        }

        public ushort4 wzyx
        {
            get { return new ushort4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ushort4 wzyy
        {
            get { return new ushort4(this.s3, this.s2, this.s1, this.s1); }
        }

        public ushort4 wzyz
        {
            get { return new ushort4(this.s3, this.s2, this.s1, this.s2); }
        }

        public ushort4 wzyw
        {
            get { return new ushort4(this.s3, this.s2, this.s1, this.s3); }
        }

        public ushort4 wzzx
        {
            get { return new ushort4(this.s3, this.s2, this.s2, this.s0); }
        }

        public ushort4 wzzy
        {
            get { return new ushort4(this.s3, this.s2, this.s2, this.s1); }
        }

        public ushort4 wzzz
        {
            get { return new ushort4(this.s3, this.s2, this.s2, this.s2); }
        }

        public ushort4 wzzw
        {
            get { return new ushort4(this.s3, this.s2, this.s2, this.s3); }
        }

        public ushort4 wzwx
        {
            get { return new ushort4(this.s3, this.s2, this.s3, this.s0); }
        }

        public ushort4 wzwy
        {
            get { return new ushort4(this.s3, this.s2, this.s3, this.s1); }
        }

        public ushort4 wzwz
        {
            get { return new ushort4(this.s3, this.s2, this.s3, this.s2); }
        }

        public ushort4 wzww
        {
            get { return new ushort4(this.s3, this.s2, this.s3, this.s3); }
        }

        public ushort4 wwxx
        {
            get { return new ushort4(this.s3, this.s3, this.s0, this.s0); }
        }

        public ushort4 wwxy
        {
            get { return new ushort4(this.s3, this.s3, this.s0, this.s1); }
        }

        public ushort4 wwxz
        {
            get { return new ushort4(this.s3, this.s3, this.s0, this.s2); }
        }

        public ushort4 wwxw
        {
            get { return new ushort4(this.s3, this.s3, this.s0, this.s3); }
        }

        public ushort4 wwyx
        {
            get { return new ushort4(this.s3, this.s3, this.s1, this.s0); }
        }

        public ushort4 wwyy
        {
            get { return new ushort4(this.s3, this.s3, this.s1, this.s1); }
        }

        public ushort4 wwyz
        {
            get { return new ushort4(this.s3, this.s3, this.s1, this.s2); }
        }

        public ushort4 wwyw
        {
            get { return new ushort4(this.s3, this.s3, this.s1, this.s3); }
        }

        public ushort4 wwzx
        {
            get { return new ushort4(this.s3, this.s3, this.s2, this.s0); }
        }

        public ushort4 wwzy
        {
            get { return new ushort4(this.s3, this.s3, this.s2, this.s1); }
        }

        public ushort4 wwzz
        {
            get { return new ushort4(this.s3, this.s3, this.s2, this.s2); }
        }

        public ushort4 wwzw
        {
            get { return new ushort4(this.s3, this.s3, this.s2, this.s3); }
        }

        public ushort4 wwwx
        {
            get { return new ushort4(this.s3, this.s3, this.s3, this.s0); }
        }

        public ushort4 wwwy
        {
            get { return new ushort4(this.s3, this.s3, this.s3, this.s1); }
        }

        public ushort4 wwwz
        {
            get { return new ushort4(this.s3, this.s3, this.s3, this.s2); }
        }

        public ushort4 wwww
        {
            get { return new ushort4(this.s3, this.s3, this.s3, this.s3); }
        }

        public ushort this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 8; }
        }

        // IEquatable

        public bool Equals(ushort4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ushort4 && Equals((ushort4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static ushort4 operator +(ushort4 a, ushort4 b) => new ushort4((ushort)(a.s0+b.s0), (ushort)(a.s1+b.s1), (ushort)(a.s2+b.s2), (ushort)(a.s3+b.s3));

        public static ushort4 operator -(ushort4 a, ushort4 b) => new ushort4((ushort)(a.s0-b.s0), (ushort)(a.s1-b.s1), (ushort)(a.s2-b.s2), (ushort)(a.s3-b.s3));

        public static ushort4 operator *(ushort4 a, ushort4 b) => new ushort4((ushort)(a.s0*b.s0), (ushort)(a.s1*b.s1), (ushort)(a.s2*b.s2), (ushort)(a.s3*b.s3));

        public static ushort4 operator /(ushort4 a, ushort4 b) => new ushort4((ushort)(a.s0/b.s0), (ushort)(a.s1/b.s1), (ushort)(a.s2/b.s2), (ushort)(a.s3/b.s3));

        public static short4 operator ==(ushort4 a, ushort4 b) => new short4(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0, a.s3==b.s3 ? (short)-1 : (short)0);

        public static short4 operator !=(ushort4 a, ushort4 b) => new short4(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0, a.s3!=b.s3 ? (short)-1 : (short)0);

        public static short4 operator <(ushort4 a, ushort4 b) => new short4(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0, a.s3<b.s3 ? (short)-1 : (short)0);

        public static short4 operator <=(ushort4 a, ushort4 b) => new short4(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0, a.s3<=b.s3 ? (short)-1 : (short)0);

        public static short4 operator >(ushort4 a, ushort4 b) => new short4(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0, a.s3>b.s3 ? (short)-1 : (short)0);

        public static short4 operator >=(ushort4 a, ushort4 b) => new short4(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0, a.s3>=b.s3 ? (short)-1 : (short)0);

        public static ushort4 operator &(ushort4 a, ushort4 b) => new ushort4((ushort)(a.s0&b.s0), (ushort)(a.s1&b.s1), (ushort)(a.s2&b.s2), (ushort)(a.s3&b.s3));

        public static ushort4 operator |(ushort4 a, ushort4 b) => new ushort4((ushort)(a.s0|b.s0), (ushort)(a.s1|b.s1), (ushort)(a.s2|b.s2), (ushort)(a.s3|b.s3));

        public static ushort4 operator ^(ushort4 a, ushort4 b) => new ushort4((ushort)(a.s0^b.s0), (ushort)(a.s1^b.s1), (ushort)(a.s2^b.s2), (ushort)(a.s3^b.s3));

        public static ushort4 operator +(ushort4 a) => a;

        public static ushort4 operator ~(ushort4 a) => new ushort4((ushort)(~a.s0), (ushort)(~a.s1), (ushort)(~a.s2), (ushort)(~a.s3));

        public static ushort4 operator ++(ushort4 a) => new ushort4((ushort)(a.s0+1), (ushort)(a.s1+1), (ushort)(a.s2+1), (ushort)(a.s3+1));

        public static ushort4 operator --(ushort4 a) => new ushort4((ushort)(a.s0-1), (ushort)(a.s1-1), (ushort)(a.s2-1), (ushort)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct ushort8: IVectorType, IEquatable<ushort8>
    {
        [FieldOffset(0)]
        public ushort s0;
        [FieldOffset(2)]
        public ushort s1;
        [FieldOffset(4)]
        public ushort s2;
        [FieldOffset(6)]
        public ushort s3;
        [FieldOffset(8)]
        public ushort s4;
        [FieldOffset(10)]
        public ushort s5;
        [FieldOffset(12)]
        public ushort s6;
        [FieldOffset(14)]
        public ushort s7;

        public ushort8(ushort v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public ushort8(ushort v0, ushort v1, ushort v2, ushort v3, ushort v4, ushort v5, ushort v6, ushort v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public ushort this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(ushort8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ushort8 && Equals((ushort8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static ushort8 operator +(ushort8 a, ushort8 b) => new ushort8((ushort)(a.s0+b.s0), (ushort)(a.s1+b.s1), (ushort)(a.s2+b.s2), (ushort)(a.s3+b.s3), (ushort)(a.s4+b.s4), (ushort)(a.s5+b.s5), (ushort)(a.s6+b.s6), (ushort)(a.s7+b.s7));

        public static ushort8 operator -(ushort8 a, ushort8 b) => new ushort8((ushort)(a.s0-b.s0), (ushort)(a.s1-b.s1), (ushort)(a.s2-b.s2), (ushort)(a.s3-b.s3), (ushort)(a.s4-b.s4), (ushort)(a.s5-b.s5), (ushort)(a.s6-b.s6), (ushort)(a.s7-b.s7));

        public static ushort8 operator *(ushort8 a, ushort8 b) => new ushort8((ushort)(a.s0*b.s0), (ushort)(a.s1*b.s1), (ushort)(a.s2*b.s2), (ushort)(a.s3*b.s3), (ushort)(a.s4*b.s4), (ushort)(a.s5*b.s5), (ushort)(a.s6*b.s6), (ushort)(a.s7*b.s7));

        public static ushort8 operator /(ushort8 a, ushort8 b) => new ushort8((ushort)(a.s0/b.s0), (ushort)(a.s1/b.s1), (ushort)(a.s2/b.s2), (ushort)(a.s3/b.s3), (ushort)(a.s4/b.s4), (ushort)(a.s5/b.s5), (ushort)(a.s6/b.s6), (ushort)(a.s7/b.s7));

        public static short8 operator ==(ushort8 a, ushort8 b) => new short8(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0, a.s3==b.s3 ? (short)-1 : (short)0, a.s4==b.s4 ? (short)-1 : (short)0, a.s5==b.s5 ? (short)-1 : (short)0, a.s6==b.s6 ? (short)-1 : (short)0, a.s7==b.s7 ? (short)-1 : (short)0);

        public static short8 operator !=(ushort8 a, ushort8 b) => new short8(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0, a.s3!=b.s3 ? (short)-1 : (short)0, a.s4!=b.s4 ? (short)-1 : (short)0, a.s5!=b.s5 ? (short)-1 : (short)0, a.s6!=b.s6 ? (short)-1 : (short)0, a.s7!=b.s7 ? (short)-1 : (short)0);

        public static short8 operator <(ushort8 a, ushort8 b) => new short8(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0, a.s3<b.s3 ? (short)-1 : (short)0, a.s4<b.s4 ? (short)-1 : (short)0, a.s5<b.s5 ? (short)-1 : (short)0, a.s6<b.s6 ? (short)-1 : (short)0, a.s7<b.s7 ? (short)-1 : (short)0);

        public static short8 operator <=(ushort8 a, ushort8 b) => new short8(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0, a.s3<=b.s3 ? (short)-1 : (short)0, a.s4<=b.s4 ? (short)-1 : (short)0, a.s5<=b.s5 ? (short)-1 : (short)0, a.s6<=b.s6 ? (short)-1 : (short)0, a.s7<=b.s7 ? (short)-1 : (short)0);

        public static short8 operator >(ushort8 a, ushort8 b) => new short8(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0, a.s3>b.s3 ? (short)-1 : (short)0, a.s4>b.s4 ? (short)-1 : (short)0, a.s5>b.s5 ? (short)-1 : (short)0, a.s6>b.s6 ? (short)-1 : (short)0, a.s7>b.s7 ? (short)-1 : (short)0);

        public static short8 operator >=(ushort8 a, ushort8 b) => new short8(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0, a.s3>=b.s3 ? (short)-1 : (short)0, a.s4>=b.s4 ? (short)-1 : (short)0, a.s5>=b.s5 ? (short)-1 : (short)0, a.s6>=b.s6 ? (short)-1 : (short)0, a.s7>=b.s7 ? (short)-1 : (short)0);

        public static ushort8 operator &(ushort8 a, ushort8 b) => new ushort8((ushort)(a.s0&b.s0), (ushort)(a.s1&b.s1), (ushort)(a.s2&b.s2), (ushort)(a.s3&b.s3), (ushort)(a.s4&b.s4), (ushort)(a.s5&b.s5), (ushort)(a.s6&b.s6), (ushort)(a.s7&b.s7));

        public static ushort8 operator |(ushort8 a, ushort8 b) => new ushort8((ushort)(a.s0|b.s0), (ushort)(a.s1|b.s1), (ushort)(a.s2|b.s2), (ushort)(a.s3|b.s3), (ushort)(a.s4|b.s4), (ushort)(a.s5|b.s5), (ushort)(a.s6|b.s6), (ushort)(a.s7|b.s7));

        public static ushort8 operator ^(ushort8 a, ushort8 b) => new ushort8((ushort)(a.s0^b.s0), (ushort)(a.s1^b.s1), (ushort)(a.s2^b.s2), (ushort)(a.s3^b.s3), (ushort)(a.s4^b.s4), (ushort)(a.s5^b.s5), (ushort)(a.s6^b.s6), (ushort)(a.s7^b.s7));

        public static ushort8 operator +(ushort8 a) => a;

        public static ushort8 operator ~(ushort8 a) => new ushort8((ushort)(~a.s0), (ushort)(~a.s1), (ushort)(~a.s2), (ushort)(~a.s3), (ushort)(~a.s4), (ushort)(~a.s5), (ushort)(~a.s6), (ushort)(~a.s7));

        public static ushort8 operator ++(ushort8 a) => new ushort8((ushort)(a.s0+1), (ushort)(a.s1+1), (ushort)(a.s2+1), (ushort)(a.s3+1), (ushort)(a.s4+1), (ushort)(a.s5+1), (ushort)(a.s6+1), (ushort)(a.s7+1));

        public static ushort8 operator --(ushort8 a) => new ushort8((ushort)(a.s0-1), (ushort)(a.s1-1), (ushort)(a.s2-1), (ushort)(a.s3-1), (ushort)(a.s4-1), (ushort)(a.s5-1), (ushort)(a.s6-1), (ushort)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct ushort16: IVectorType, IEquatable<ushort16>
    {
        [FieldOffset(0)]
        public ushort s0;
        [FieldOffset(2)]
        public ushort s1;
        [FieldOffset(4)]
        public ushort s2;
        [FieldOffset(6)]
        public ushort s3;
        [FieldOffset(8)]
        public ushort s4;
        [FieldOffset(10)]
        public ushort s5;
        [FieldOffset(12)]
        public ushort s6;
        [FieldOffset(14)]
        public ushort s7;
        [FieldOffset(16)]
        public ushort s8;
        [FieldOffset(18)]
        public ushort s9;
        [FieldOffset(20)]
        public ushort sa;
        [FieldOffset(22)]
        public ushort sb;
        [FieldOffset(24)]
        public ushort sc;
        [FieldOffset(26)]
        public ushort sd;
        [FieldOffset(28)]
        public ushort se;
        [FieldOffset(30)]
        public ushort sf;

        public ushort16(ushort v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public ushort16(ushort v0, ushort v1, ushort v2, ushort v3, ushort v4, ushort v5, ushort v6, ushort v7, ushort v8, ushort v9, ushort va, ushort vb, ushort vc, ushort vd, ushort ve, ushort vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public ushort sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public ushort sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public ushort sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public ushort sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public ushort sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public ushort sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public ushort this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(ushort16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ushort16 && Equals((ushort16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static ushort16 operator +(ushort16 a, ushort16 b) => new ushort16((ushort)(a.s0+b.s0), (ushort)(a.s1+b.s1), (ushort)(a.s2+b.s2), (ushort)(a.s3+b.s3), (ushort)(a.s4+b.s4), (ushort)(a.s5+b.s5), (ushort)(a.s6+b.s6), (ushort)(a.s7+b.s7), (ushort)(a.s8+b.s8), (ushort)(a.s9+b.s9), (ushort)(a.sa+b.sa), (ushort)(a.sb+b.sb), (ushort)(a.sc+b.sc), (ushort)(a.sd+b.sd), (ushort)(a.se+b.se), (ushort)(a.sf+b.sf));

        public static ushort16 operator -(ushort16 a, ushort16 b) => new ushort16((ushort)(a.s0-b.s0), (ushort)(a.s1-b.s1), (ushort)(a.s2-b.s2), (ushort)(a.s3-b.s3), (ushort)(a.s4-b.s4), (ushort)(a.s5-b.s5), (ushort)(a.s6-b.s6), (ushort)(a.s7-b.s7), (ushort)(a.s8-b.s8), (ushort)(a.s9-b.s9), (ushort)(a.sa-b.sa), (ushort)(a.sb-b.sb), (ushort)(a.sc-b.sc), (ushort)(a.sd-b.sd), (ushort)(a.se-b.se), (ushort)(a.sf-b.sf));

        public static ushort16 operator *(ushort16 a, ushort16 b) => new ushort16((ushort)(a.s0*b.s0), (ushort)(a.s1*b.s1), (ushort)(a.s2*b.s2), (ushort)(a.s3*b.s3), (ushort)(a.s4*b.s4), (ushort)(a.s5*b.s5), (ushort)(a.s6*b.s6), (ushort)(a.s7*b.s7), (ushort)(a.s8*b.s8), (ushort)(a.s9*b.s9), (ushort)(a.sa*b.sa), (ushort)(a.sb*b.sb), (ushort)(a.sc*b.sc), (ushort)(a.sd*b.sd), (ushort)(a.se*b.se), (ushort)(a.sf*b.sf));

        public static ushort16 operator /(ushort16 a, ushort16 b) => new ushort16((ushort)(a.s0/b.s0), (ushort)(a.s1/b.s1), (ushort)(a.s2/b.s2), (ushort)(a.s3/b.s3), (ushort)(a.s4/b.s4), (ushort)(a.s5/b.s5), (ushort)(a.s6/b.s6), (ushort)(a.s7/b.s7), (ushort)(a.s8/b.s8), (ushort)(a.s9/b.s9), (ushort)(a.sa/b.sa), (ushort)(a.sb/b.sb), (ushort)(a.sc/b.sc), (ushort)(a.sd/b.sd), (ushort)(a.se/b.se), (ushort)(a.sf/b.sf));

        public static short16 operator ==(ushort16 a, ushort16 b) => new short16(a.s0==b.s0 ? (short)-1 : (short)0, a.s1==b.s1 ? (short)-1 : (short)0, a.s2==b.s2 ? (short)-1 : (short)0, a.s3==b.s3 ? (short)-1 : (short)0, a.s4==b.s4 ? (short)-1 : (short)0, a.s5==b.s5 ? (short)-1 : (short)0, a.s6==b.s6 ? (short)-1 : (short)0, a.s7==b.s7 ? (short)-1 : (short)0, a.s8==b.s8 ? (short)-1 : (short)0, a.s9==b.s9 ? (short)-1 : (short)0, a.sa==b.sa ? (short)-1 : (short)0, a.sb==b.sb ? (short)-1 : (short)0, a.sc==b.sc ? (short)-1 : (short)0, a.sd==b.sd ? (short)-1 : (short)0, a.se==b.se ? (short)-1 : (short)0, a.sf==b.sf ? (short)-1 : (short)0);

        public static short16 operator !=(ushort16 a, ushort16 b) => new short16(a.s0!=b.s0 ? (short)-1 : (short)0, a.s1!=b.s1 ? (short)-1 : (short)0, a.s2!=b.s2 ? (short)-1 : (short)0, a.s3!=b.s3 ? (short)-1 : (short)0, a.s4!=b.s4 ? (short)-1 : (short)0, a.s5!=b.s5 ? (short)-1 : (short)0, a.s6!=b.s6 ? (short)-1 : (short)0, a.s7!=b.s7 ? (short)-1 : (short)0, a.s8!=b.s8 ? (short)-1 : (short)0, a.s9!=b.s9 ? (short)-1 : (short)0, a.sa!=b.sa ? (short)-1 : (short)0, a.sb!=b.sb ? (short)-1 : (short)0, a.sc!=b.sc ? (short)-1 : (short)0, a.sd!=b.sd ? (short)-1 : (short)0, a.se!=b.se ? (short)-1 : (short)0, a.sf!=b.sf ? (short)-1 : (short)0);

        public static short16 operator <(ushort16 a, ushort16 b) => new short16(a.s0<b.s0 ? (short)-1 : (short)0, a.s1<b.s1 ? (short)-1 : (short)0, a.s2<b.s2 ? (short)-1 : (short)0, a.s3<b.s3 ? (short)-1 : (short)0, a.s4<b.s4 ? (short)-1 : (short)0, a.s5<b.s5 ? (short)-1 : (short)0, a.s6<b.s6 ? (short)-1 : (short)0, a.s7<b.s7 ? (short)-1 : (short)0, a.s8<b.s8 ? (short)-1 : (short)0, a.s9<b.s9 ? (short)-1 : (short)0, a.sa<b.sa ? (short)-1 : (short)0, a.sb<b.sb ? (short)-1 : (short)0, a.sc<b.sc ? (short)-1 : (short)0, a.sd<b.sd ? (short)-1 : (short)0, a.se<b.se ? (short)-1 : (short)0, a.sf<b.sf ? (short)-1 : (short)0);

        public static short16 operator <=(ushort16 a, ushort16 b) => new short16(a.s0<=b.s0 ? (short)-1 : (short)0, a.s1<=b.s1 ? (short)-1 : (short)0, a.s2<=b.s2 ? (short)-1 : (short)0, a.s3<=b.s3 ? (short)-1 : (short)0, a.s4<=b.s4 ? (short)-1 : (short)0, a.s5<=b.s5 ? (short)-1 : (short)0, a.s6<=b.s6 ? (short)-1 : (short)0, a.s7<=b.s7 ? (short)-1 : (short)0, a.s8<=b.s8 ? (short)-1 : (short)0, a.s9<=b.s9 ? (short)-1 : (short)0, a.sa<=b.sa ? (short)-1 : (short)0, a.sb<=b.sb ? (short)-1 : (short)0, a.sc<=b.sc ? (short)-1 : (short)0, a.sd<=b.sd ? (short)-1 : (short)0, a.se<=b.se ? (short)-1 : (short)0, a.sf<=b.sf ? (short)-1 : (short)0);

        public static short16 operator >(ushort16 a, ushort16 b) => new short16(a.s0>b.s0 ? (short)-1 : (short)0, a.s1>b.s1 ? (short)-1 : (short)0, a.s2>b.s2 ? (short)-1 : (short)0, a.s3>b.s3 ? (short)-1 : (short)0, a.s4>b.s4 ? (short)-1 : (short)0, a.s5>b.s5 ? (short)-1 : (short)0, a.s6>b.s6 ? (short)-1 : (short)0, a.s7>b.s7 ? (short)-1 : (short)0, a.s8>b.s8 ? (short)-1 : (short)0, a.s9>b.s9 ? (short)-1 : (short)0, a.sa>b.sa ? (short)-1 : (short)0, a.sb>b.sb ? (short)-1 : (short)0, a.sc>b.sc ? (short)-1 : (short)0, a.sd>b.sd ? (short)-1 : (short)0, a.se>b.se ? (short)-1 : (short)0, a.sf>b.sf ? (short)-1 : (short)0);

        public static short16 operator >=(ushort16 a, ushort16 b) => new short16(a.s0>=b.s0 ? (short)-1 : (short)0, a.s1>=b.s1 ? (short)-1 : (short)0, a.s2>=b.s2 ? (short)-1 : (short)0, a.s3>=b.s3 ? (short)-1 : (short)0, a.s4>=b.s4 ? (short)-1 : (short)0, a.s5>=b.s5 ? (short)-1 : (short)0, a.s6>=b.s6 ? (short)-1 : (short)0, a.s7>=b.s7 ? (short)-1 : (short)0, a.s8>=b.s8 ? (short)-1 : (short)0, a.s9>=b.s9 ? (short)-1 : (short)0, a.sa>=b.sa ? (short)-1 : (short)0, a.sb>=b.sb ? (short)-1 : (short)0, a.sc>=b.sc ? (short)-1 : (short)0, a.sd>=b.sd ? (short)-1 : (short)0, a.se>=b.se ? (short)-1 : (short)0, a.sf>=b.sf ? (short)-1 : (short)0);

        public static ushort16 operator &(ushort16 a, ushort16 b) => new ushort16((ushort)(a.s0&b.s0), (ushort)(a.s1&b.s1), (ushort)(a.s2&b.s2), (ushort)(a.s3&b.s3), (ushort)(a.s4&b.s4), (ushort)(a.s5&b.s5), (ushort)(a.s6&b.s6), (ushort)(a.s7&b.s7), (ushort)(a.s8&b.s8), (ushort)(a.s9&b.s9), (ushort)(a.sa&b.sa), (ushort)(a.sb&b.sb), (ushort)(a.sc&b.sc), (ushort)(a.sd&b.sd), (ushort)(a.se&b.se), (ushort)(a.sf&b.sf));

        public static ushort16 operator |(ushort16 a, ushort16 b) => new ushort16((ushort)(a.s0|b.s0), (ushort)(a.s1|b.s1), (ushort)(a.s2|b.s2), (ushort)(a.s3|b.s3), (ushort)(a.s4|b.s4), (ushort)(a.s5|b.s5), (ushort)(a.s6|b.s6), (ushort)(a.s7|b.s7), (ushort)(a.s8|b.s8), (ushort)(a.s9|b.s9), (ushort)(a.sa|b.sa), (ushort)(a.sb|b.sb), (ushort)(a.sc|b.sc), (ushort)(a.sd|b.sd), (ushort)(a.se|b.se), (ushort)(a.sf|b.sf));

        public static ushort16 operator ^(ushort16 a, ushort16 b) => new ushort16((ushort)(a.s0^b.s0), (ushort)(a.s1^b.s1), (ushort)(a.s2^b.s2), (ushort)(a.s3^b.s3), (ushort)(a.s4^b.s4), (ushort)(a.s5^b.s5), (ushort)(a.s6^b.s6), (ushort)(a.s7^b.s7), (ushort)(a.s8^b.s8), (ushort)(a.s9^b.s9), (ushort)(a.sa^b.sa), (ushort)(a.sb^b.sb), (ushort)(a.sc^b.sc), (ushort)(a.sd^b.sd), (ushort)(a.se^b.se), (ushort)(a.sf^b.sf));

        public static ushort16 operator +(ushort16 a) => a;

        public static ushort16 operator ~(ushort16 a) => new ushort16((ushort)(~a.s0), (ushort)(~a.s1), (ushort)(~a.s2), (ushort)(~a.s3), (ushort)(~a.s4), (ushort)(~a.s5), (ushort)(~a.s6), (ushort)(~a.s7), (ushort)(~a.s8), (ushort)(~a.s9), (ushort)(~a.sa), (ushort)(~a.sb), (ushort)(~a.sc), (ushort)(~a.sd), (ushort)(~a.se), (ushort)(~a.sf));

        public static ushort16 operator ++(ushort16 a) => new ushort16((ushort)(a.s0+1), (ushort)(a.s1+1), (ushort)(a.s2+1), (ushort)(a.s3+1), (ushort)(a.s4+1), (ushort)(a.s5+1), (ushort)(a.s6+1), (ushort)(a.s7+1), (ushort)(a.s8+1), (ushort)(a.s9+1), (ushort)(a.sa+1), (ushort)(a.sb+1), (ushort)(a.sc+1), (ushort)(a.sd+1), (ushort)(a.se+1), (ushort)(a.sf+1));

        public static ushort16 operator --(ushort16 a) => new ushort16((ushort)(a.s0-1), (ushort)(a.s1-1), (ushort)(a.s2-1), (ushort)(a.s3-1), (ushort)(a.s4-1), (ushort)(a.s5-1), (ushort)(a.s6-1), (ushort)(a.s7-1), (ushort)(a.s8-1), (ushort)(a.s9-1), (ushort)(a.sa-1), (ushort)(a.sb-1), (ushort)(a.sc-1), (ushort)(a.sd-1), (ushort)(a.se-1), (ushort)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct int2: IVectorType, IEquatable<int2>
    {
        [FieldOffset(0)]
        public int s0;
        [FieldOffset(4)]
        public int s1;

        public int2(int v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public int2(int2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public int2(int v0, int v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public int x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public int y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public int2 xx
        {
            get { return new int2(this.s0, this.s0); }
        }

        public int2 xy
        {
            get { return new int2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public int2 yx
        {
            get { return new int2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public int2 yy
        {
            get { return new int2(this.s1, this.s1); }
        }

        public int this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 8; }
        }

        // IEquatable

        public bool Equals(int2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is int2 && Equals((int2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static int2 operator +(int2 a, int2 b) => new int2((int)(a.s0+b.s0), (int)(a.s1+b.s1));

        public static int2 operator -(int2 a, int2 b) => new int2((int)(a.s0-b.s0), (int)(a.s1-b.s1));

        public static int2 operator *(int2 a, int2 b) => new int2((int)(a.s0*b.s0), (int)(a.s1*b.s1));

        public static int2 operator /(int2 a, int2 b) => new int2((int)(a.s0/b.s0), (int)(a.s1/b.s1));

        public static int2 operator ==(int2 a, int2 b) => new int2(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0);

        public static int2 operator !=(int2 a, int2 b) => new int2(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0);

        public static int2 operator <(int2 a, int2 b) => new int2(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0);

        public static int2 operator <=(int2 a, int2 b) => new int2(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0);

        public static int2 operator >(int2 a, int2 b) => new int2(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0);

        public static int2 operator >=(int2 a, int2 b) => new int2(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0);

        public static int2 operator &(int2 a, int2 b) => new int2((int)(a.s0&b.s0), (int)(a.s1&b.s1));

        public static int2 operator |(int2 a, int2 b) => new int2((int)(a.s0|b.s0), (int)(a.s1|b.s1));

        public static int2 operator ^(int2 a, int2 b) => new int2((int)(a.s0^b.s0), (int)(a.s1^b.s1));

        public static int2 operator +(int2 a) => a;

        public static int2 operator -(int2 a) => new int2((int)(-a.s0), (int)(-a.s1));

        public static int2 operator ~(int2 a) => new int2((int)(~a.s0), (int)(~a.s1));

        public static int2 operator ++(int2 a) => new int2((int)(a.s0+1), (int)(a.s1+1));

        public static int2 operator --(int2 a) => new int2((int)(a.s0-1), (int)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=16)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct int3: IVectorType, IEquatable<int3>
    {
        [FieldOffset(0)]
        public int s0;
        [FieldOffset(4)]
        public int s1;
        [FieldOffset(8)]
        public int s2;

        public int3(int v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public int3(int3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public int3(int v0, int2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public int3(int2 v0, int v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public int3(int v0, int v1, int v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public int x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public int y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public int z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public int2 xx
        {
            get { return new int2(this.s0, this.s0); }
        }

        public int2 xy
        {
            get { return new int2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public int2 xz
        {
            get { return new int2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public int2 yx
        {
            get { return new int2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public int2 yy
        {
            get { return new int2(this.s1, this.s1); }
        }

        public int2 yz
        {
            get { return new int2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public int2 zx
        {
            get { return new int2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public int2 zy
        {
            get { return new int2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public int2 zz
        {
            get { return new int2(this.s2, this.s2); }
        }

        public int3 xxx
        {
            get { return new int3(this.s0, this.s0, this.s0); }
        }

        public int3 xxy
        {
            get { return new int3(this.s0, this.s0, this.s1); }
        }

        public int3 xxz
        {
            get { return new int3(this.s0, this.s0, this.s2); }
        }

        public int3 xyx
        {
            get { return new int3(this.s0, this.s1, this.s0); }
        }

        public int3 xyy
        {
            get { return new int3(this.s0, this.s1, this.s1); }
        }

        public int3 xyz
        {
            get { return new int3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 xzx
        {
            get { return new int3(this.s0, this.s2, this.s0); }
        }

        public int3 xzy
        {
            get { return new int3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 xzz
        {
            get { return new int3(this.s0, this.s2, this.s2); }
        }

        public int3 yxx
        {
            get { return new int3(this.s1, this.s0, this.s0); }
        }

        public int3 yxy
        {
            get { return new int3(this.s1, this.s0, this.s1); }
        }

        public int3 yxz
        {
            get { return new int3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 yyx
        {
            get { return new int3(this.s1, this.s1, this.s0); }
        }

        public int3 yyy
        {
            get { return new int3(this.s1, this.s1, this.s1); }
        }

        public int3 yyz
        {
            get { return new int3(this.s1, this.s1, this.s2); }
        }

        public int3 yzx
        {
            get { return new int3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 yzy
        {
            get { return new int3(this.s1, this.s2, this.s1); }
        }

        public int3 yzz
        {
            get { return new int3(this.s1, this.s2, this.s2); }
        }

        public int3 zxx
        {
            get { return new int3(this.s2, this.s0, this.s0); }
        }

        public int3 zxy
        {
            get { return new int3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 zxz
        {
            get { return new int3(this.s2, this.s0, this.s2); }
        }

        public int3 zyx
        {
            get { return new int3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 zyy
        {
            get { return new int3(this.s2, this.s1, this.s1); }
        }

        public int3 zyz
        {
            get { return new int3(this.s2, this.s1, this.s2); }
        }

        public int3 zzx
        {
            get { return new int3(this.s2, this.s2, this.s0); }
        }

        public int3 zzy
        {
            get { return new int3(this.s2, this.s2, this.s1); }
        }

        public int3 zzz
        {
            get { return new int3(this.s2, this.s2, this.s2); }
        }

        public int this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 12; }
        }

        // IEquatable

        public bool Equals(int3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is int3 && Equals((int3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static int3 operator +(int3 a, int3 b) => new int3((int)(a.s0+b.s0), (int)(a.s1+b.s1), (int)(a.s2+b.s2));

        public static int3 operator -(int3 a, int3 b) => new int3((int)(a.s0-b.s0), (int)(a.s1-b.s1), (int)(a.s2-b.s2));

        public static int3 operator *(int3 a, int3 b) => new int3((int)(a.s0*b.s0), (int)(a.s1*b.s1), (int)(a.s2*b.s2));

        public static int3 operator /(int3 a, int3 b) => new int3((int)(a.s0/b.s0), (int)(a.s1/b.s1), (int)(a.s2/b.s2));

        public static int3 operator ==(int3 a, int3 b) => new int3(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0);

        public static int3 operator !=(int3 a, int3 b) => new int3(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0);

        public static int3 operator <(int3 a, int3 b) => new int3(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0);

        public static int3 operator <=(int3 a, int3 b) => new int3(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0);

        public static int3 operator >(int3 a, int3 b) => new int3(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0);

        public static int3 operator >=(int3 a, int3 b) => new int3(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0);

        public static int3 operator &(int3 a, int3 b) => new int3((int)(a.s0&b.s0), (int)(a.s1&b.s1), (int)(a.s2&b.s2));

        public static int3 operator |(int3 a, int3 b) => new int3((int)(a.s0|b.s0), (int)(a.s1|b.s1), (int)(a.s2|b.s2));

        public static int3 operator ^(int3 a, int3 b) => new int3((int)(a.s0^b.s0), (int)(a.s1^b.s1), (int)(a.s2^b.s2));

        public static int3 operator +(int3 a) => a;

        public static int3 operator -(int3 a) => new int3((int)(-a.s0), (int)(-a.s1), (int)(-a.s2));

        public static int3 operator ~(int3 a) => new int3((int)(~a.s0), (int)(~a.s1), (int)(~a.s2));

        public static int3 operator ++(int3 a) => new int3((int)(a.s0+1), (int)(a.s1+1), (int)(a.s2+1));

        public static int3 operator --(int3 a) => new int3((int)(a.s0-1), (int)(a.s1-1), (int)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct int4: IVectorType, IEquatable<int4>
    {
        [FieldOffset(0)]
        public int s0;
        [FieldOffset(4)]
        public int s1;
        [FieldOffset(8)]
        public int s2;
        [FieldOffset(12)]
        public int s3;

        public int4(int v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public int4(int4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public int4(int v0, int3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public int4(int2 v0, int2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public int4(int3 v0, int v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public int4(int v0, int v1, int2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public int4(int v0, int2 v1, int v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public int4(int2 v0, int v1, int v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public int4(int v0, int v1, int v2, int v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public int x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public int y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public int z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public int w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public int2 xx
        {
            get { return new int2(this.s0, this.s0); }
        }

        public int2 xy
        {
            get { return new int2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public int2 xz
        {
            get { return new int2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public int2 xw
        {
            get { return new int2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public int2 yx
        {
            get { return new int2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public int2 yy
        {
            get { return new int2(this.s1, this.s1); }
        }

        public int2 yz
        {
            get { return new int2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public int2 yw
        {
            get { return new int2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public int2 zx
        {
            get { return new int2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public int2 zy
        {
            get { return new int2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public int2 zz
        {
            get { return new int2(this.s2, this.s2); }
        }

        public int2 zw
        {
            get { return new int2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public int2 wx
        {
            get { return new int2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public int2 wy
        {
            get { return new int2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public int2 wz
        {
            get { return new int2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public int2 ww
        {
            get { return new int2(this.s3, this.s3); }
        }

        public int3 xxx
        {
            get { return new int3(this.s0, this.s0, this.s0); }
        }

        public int3 xxy
        {
            get { return new int3(this.s0, this.s0, this.s1); }
        }

        public int3 xxz
        {
            get { return new int3(this.s0, this.s0, this.s2); }
        }

        public int3 xxw
        {
            get { return new int3(this.s0, this.s0, this.s3); }
        }

        public int3 xyx
        {
            get { return new int3(this.s0, this.s1, this.s0); }
        }

        public int3 xyy
        {
            get { return new int3(this.s0, this.s1, this.s1); }
        }

        public int3 xyz
        {
            get { return new int3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 xyw
        {
            get { return new int3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public int3 xzx
        {
            get { return new int3(this.s0, this.s2, this.s0); }
        }

        public int3 xzy
        {
            get { return new int3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 xzz
        {
            get { return new int3(this.s0, this.s2, this.s2); }
        }

        public int3 xzw
        {
            get { return new int3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public int3 xwx
        {
            get { return new int3(this.s0, this.s3, this.s0); }
        }

        public int3 xwy
        {
            get { return new int3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 xwz
        {
            get { return new int3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 xww
        {
            get { return new int3(this.s0, this.s3, this.s3); }
        }

        public int3 yxx
        {
            get { return new int3(this.s1, this.s0, this.s0); }
        }

        public int3 yxy
        {
            get { return new int3(this.s1, this.s0, this.s1); }
        }

        public int3 yxz
        {
            get { return new int3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 yxw
        {
            get { return new int3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public int3 yyx
        {
            get { return new int3(this.s1, this.s1, this.s0); }
        }

        public int3 yyy
        {
            get { return new int3(this.s1, this.s1, this.s1); }
        }

        public int3 yyz
        {
            get { return new int3(this.s1, this.s1, this.s2); }
        }

        public int3 yyw
        {
            get { return new int3(this.s1, this.s1, this.s3); }
        }

        public int3 yzx
        {
            get { return new int3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 yzy
        {
            get { return new int3(this.s1, this.s2, this.s1); }
        }

        public int3 yzz
        {
            get { return new int3(this.s1, this.s2, this.s2); }
        }

        public int3 yzw
        {
            get { return new int3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public int3 ywx
        {
            get { return new int3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 ywy
        {
            get { return new int3(this.s1, this.s3, this.s1); }
        }

        public int3 ywz
        {
            get { return new int3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 yww
        {
            get { return new int3(this.s1, this.s3, this.s3); }
        }

        public int3 zxx
        {
            get { return new int3(this.s2, this.s0, this.s0); }
        }

        public int3 zxy
        {
            get { return new int3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 zxz
        {
            get { return new int3(this.s2, this.s0, this.s2); }
        }

        public int3 zxw
        {
            get { return new int3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public int3 zyx
        {
            get { return new int3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 zyy
        {
            get { return new int3(this.s2, this.s1, this.s1); }
        }

        public int3 zyz
        {
            get { return new int3(this.s2, this.s1, this.s2); }
        }

        public int3 zyw
        {
            get { return new int3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public int3 zzx
        {
            get { return new int3(this.s2, this.s2, this.s0); }
        }

        public int3 zzy
        {
            get { return new int3(this.s2, this.s2, this.s1); }
        }

        public int3 zzz
        {
            get { return new int3(this.s2, this.s2, this.s2); }
        }

        public int3 zzw
        {
            get { return new int3(this.s2, this.s2, this.s3); }
        }

        public int3 zwx
        {
            get { return new int3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 zwy
        {
            get { return new int3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 zwz
        {
            get { return new int3(this.s2, this.s3, this.s2); }
        }

        public int3 zww
        {
            get { return new int3(this.s2, this.s3, this.s3); }
        }

        public int3 wxx
        {
            get { return new int3(this.s3, this.s0, this.s0); }
        }

        public int3 wxy
        {
            get { return new int3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 wxz
        {
            get { return new int3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 wxw
        {
            get { return new int3(this.s3, this.s0, this.s3); }
        }

        public int3 wyx
        {
            get { return new int3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 wyy
        {
            get { return new int3(this.s3, this.s1, this.s1); }
        }

        public int3 wyz
        {
            get { return new int3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public int3 wyw
        {
            get { return new int3(this.s3, this.s1, this.s3); }
        }

        public int3 wzx
        {
            get { return new int3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public int3 wzy
        {
            get { return new int3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public int3 wzz
        {
            get { return new int3(this.s3, this.s2, this.s2); }
        }

        public int3 wzw
        {
            get { return new int3(this.s3, this.s2, this.s3); }
        }

        public int3 wwx
        {
            get { return new int3(this.s3, this.s3, this.s0); }
        }

        public int3 wwy
        {
            get { return new int3(this.s3, this.s3, this.s1); }
        }

        public int3 wwz
        {
            get { return new int3(this.s3, this.s3, this.s2); }
        }

        public int3 www
        {
            get { return new int3(this.s3, this.s3, this.s3); }
        }

        public int4 xxxx
        {
            get { return new int4(this.s0, this.s0, this.s0, this.s0); }
        }

        public int4 xxxy
        {
            get { return new int4(this.s0, this.s0, this.s0, this.s1); }
        }

        public int4 xxxz
        {
            get { return new int4(this.s0, this.s0, this.s0, this.s2); }
        }

        public int4 xxxw
        {
            get { return new int4(this.s0, this.s0, this.s0, this.s3); }
        }

        public int4 xxyx
        {
            get { return new int4(this.s0, this.s0, this.s1, this.s0); }
        }

        public int4 xxyy
        {
            get { return new int4(this.s0, this.s0, this.s1, this.s1); }
        }

        public int4 xxyz
        {
            get { return new int4(this.s0, this.s0, this.s1, this.s2); }
        }

        public int4 xxyw
        {
            get { return new int4(this.s0, this.s0, this.s1, this.s3); }
        }

        public int4 xxzx
        {
            get { return new int4(this.s0, this.s0, this.s2, this.s0); }
        }

        public int4 xxzy
        {
            get { return new int4(this.s0, this.s0, this.s2, this.s1); }
        }

        public int4 xxzz
        {
            get { return new int4(this.s0, this.s0, this.s2, this.s2); }
        }

        public int4 xxzw
        {
            get { return new int4(this.s0, this.s0, this.s2, this.s3); }
        }

        public int4 xxwx
        {
            get { return new int4(this.s0, this.s0, this.s3, this.s0); }
        }

        public int4 xxwy
        {
            get { return new int4(this.s0, this.s0, this.s3, this.s1); }
        }

        public int4 xxwz
        {
            get { return new int4(this.s0, this.s0, this.s3, this.s2); }
        }

        public int4 xxww
        {
            get { return new int4(this.s0, this.s0, this.s3, this.s3); }
        }

        public int4 xyxx
        {
            get { return new int4(this.s0, this.s1, this.s0, this.s0); }
        }

        public int4 xyxy
        {
            get { return new int4(this.s0, this.s1, this.s0, this.s1); }
        }

        public int4 xyxz
        {
            get { return new int4(this.s0, this.s1, this.s0, this.s2); }
        }

        public int4 xyxw
        {
            get { return new int4(this.s0, this.s1, this.s0, this.s3); }
        }

        public int4 xyyx
        {
            get { return new int4(this.s0, this.s1, this.s1, this.s0); }
        }

        public int4 xyyy
        {
            get { return new int4(this.s0, this.s1, this.s1, this.s1); }
        }

        public int4 xyyz
        {
            get { return new int4(this.s0, this.s1, this.s1, this.s2); }
        }

        public int4 xyyw
        {
            get { return new int4(this.s0, this.s1, this.s1, this.s3); }
        }

        public int4 xyzx
        {
            get { return new int4(this.s0, this.s1, this.s2, this.s0); }
        }

        public int4 xyzy
        {
            get { return new int4(this.s0, this.s1, this.s2, this.s1); }
        }

        public int4 xyzz
        {
            get { return new int4(this.s0, this.s1, this.s2, this.s2); }
        }

        public int4 xyzw
        {
            get { return new int4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public int4 xywx
        {
            get { return new int4(this.s0, this.s1, this.s3, this.s0); }
        }

        public int4 xywy
        {
            get { return new int4(this.s0, this.s1, this.s3, this.s1); }
        }

        public int4 xywz
        {
            get { return new int4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public int4 xyww
        {
            get { return new int4(this.s0, this.s1, this.s3, this.s3); }
        }

        public int4 xzxx
        {
            get { return new int4(this.s0, this.s2, this.s0, this.s0); }
        }

        public int4 xzxy
        {
            get { return new int4(this.s0, this.s2, this.s0, this.s1); }
        }

        public int4 xzxz
        {
            get { return new int4(this.s0, this.s2, this.s0, this.s2); }
        }

        public int4 xzxw
        {
            get { return new int4(this.s0, this.s2, this.s0, this.s3); }
        }

        public int4 xzyx
        {
            get { return new int4(this.s0, this.s2, this.s1, this.s0); }
        }

        public int4 xzyy
        {
            get { return new int4(this.s0, this.s2, this.s1, this.s1); }
        }

        public int4 xzyz
        {
            get { return new int4(this.s0, this.s2, this.s1, this.s2); }
        }

        public int4 xzyw
        {
            get { return new int4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public int4 xzzx
        {
            get { return new int4(this.s0, this.s2, this.s2, this.s0); }
        }

        public int4 xzzy
        {
            get { return new int4(this.s0, this.s2, this.s2, this.s1); }
        }

        public int4 xzzz
        {
            get { return new int4(this.s0, this.s2, this.s2, this.s2); }
        }

        public int4 xzzw
        {
            get { return new int4(this.s0, this.s2, this.s2, this.s3); }
        }

        public int4 xzwx
        {
            get { return new int4(this.s0, this.s2, this.s3, this.s0); }
        }

        public int4 xzwy
        {
            get { return new int4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public int4 xzwz
        {
            get { return new int4(this.s0, this.s2, this.s3, this.s2); }
        }

        public int4 xzww
        {
            get { return new int4(this.s0, this.s2, this.s3, this.s3); }
        }

        public int4 xwxx
        {
            get { return new int4(this.s0, this.s3, this.s0, this.s0); }
        }

        public int4 xwxy
        {
            get { return new int4(this.s0, this.s3, this.s0, this.s1); }
        }

        public int4 xwxz
        {
            get { return new int4(this.s0, this.s3, this.s0, this.s2); }
        }

        public int4 xwxw
        {
            get { return new int4(this.s0, this.s3, this.s0, this.s3); }
        }

        public int4 xwyx
        {
            get { return new int4(this.s0, this.s3, this.s1, this.s0); }
        }

        public int4 xwyy
        {
            get { return new int4(this.s0, this.s3, this.s1, this.s1); }
        }

        public int4 xwyz
        {
            get { return new int4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public int4 xwyw
        {
            get { return new int4(this.s0, this.s3, this.s1, this.s3); }
        }

        public int4 xwzx
        {
            get { return new int4(this.s0, this.s3, this.s2, this.s0); }
        }

        public int4 xwzy
        {
            get { return new int4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public int4 xwzz
        {
            get { return new int4(this.s0, this.s3, this.s2, this.s2); }
        }

        public int4 xwzw
        {
            get { return new int4(this.s0, this.s3, this.s2, this.s3); }
        }

        public int4 xwwx
        {
            get { return new int4(this.s0, this.s3, this.s3, this.s0); }
        }

        public int4 xwwy
        {
            get { return new int4(this.s0, this.s3, this.s3, this.s1); }
        }

        public int4 xwwz
        {
            get { return new int4(this.s0, this.s3, this.s3, this.s2); }
        }

        public int4 xwww
        {
            get { return new int4(this.s0, this.s3, this.s3, this.s3); }
        }

        public int4 yxxx
        {
            get { return new int4(this.s1, this.s0, this.s0, this.s0); }
        }

        public int4 yxxy
        {
            get { return new int4(this.s1, this.s0, this.s0, this.s1); }
        }

        public int4 yxxz
        {
            get { return new int4(this.s1, this.s0, this.s0, this.s2); }
        }

        public int4 yxxw
        {
            get { return new int4(this.s1, this.s0, this.s0, this.s3); }
        }

        public int4 yxyx
        {
            get { return new int4(this.s1, this.s0, this.s1, this.s0); }
        }

        public int4 yxyy
        {
            get { return new int4(this.s1, this.s0, this.s1, this.s1); }
        }

        public int4 yxyz
        {
            get { return new int4(this.s1, this.s0, this.s1, this.s2); }
        }

        public int4 yxyw
        {
            get { return new int4(this.s1, this.s0, this.s1, this.s3); }
        }

        public int4 yxzx
        {
            get { return new int4(this.s1, this.s0, this.s2, this.s0); }
        }

        public int4 yxzy
        {
            get { return new int4(this.s1, this.s0, this.s2, this.s1); }
        }

        public int4 yxzz
        {
            get { return new int4(this.s1, this.s0, this.s2, this.s2); }
        }

        public int4 yxzw
        {
            get { return new int4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public int4 yxwx
        {
            get { return new int4(this.s1, this.s0, this.s3, this.s0); }
        }

        public int4 yxwy
        {
            get { return new int4(this.s1, this.s0, this.s3, this.s1); }
        }

        public int4 yxwz
        {
            get { return new int4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public int4 yxww
        {
            get { return new int4(this.s1, this.s0, this.s3, this.s3); }
        }

        public int4 yyxx
        {
            get { return new int4(this.s1, this.s1, this.s0, this.s0); }
        }

        public int4 yyxy
        {
            get { return new int4(this.s1, this.s1, this.s0, this.s1); }
        }

        public int4 yyxz
        {
            get { return new int4(this.s1, this.s1, this.s0, this.s2); }
        }

        public int4 yyxw
        {
            get { return new int4(this.s1, this.s1, this.s0, this.s3); }
        }

        public int4 yyyx
        {
            get { return new int4(this.s1, this.s1, this.s1, this.s0); }
        }

        public int4 yyyy
        {
            get { return new int4(this.s1, this.s1, this.s1, this.s1); }
        }

        public int4 yyyz
        {
            get { return new int4(this.s1, this.s1, this.s1, this.s2); }
        }

        public int4 yyyw
        {
            get { return new int4(this.s1, this.s1, this.s1, this.s3); }
        }

        public int4 yyzx
        {
            get { return new int4(this.s1, this.s1, this.s2, this.s0); }
        }

        public int4 yyzy
        {
            get { return new int4(this.s1, this.s1, this.s2, this.s1); }
        }

        public int4 yyzz
        {
            get { return new int4(this.s1, this.s1, this.s2, this.s2); }
        }

        public int4 yyzw
        {
            get { return new int4(this.s1, this.s1, this.s2, this.s3); }
        }

        public int4 yywx
        {
            get { return new int4(this.s1, this.s1, this.s3, this.s0); }
        }

        public int4 yywy
        {
            get { return new int4(this.s1, this.s1, this.s3, this.s1); }
        }

        public int4 yywz
        {
            get { return new int4(this.s1, this.s1, this.s3, this.s2); }
        }

        public int4 yyww
        {
            get { return new int4(this.s1, this.s1, this.s3, this.s3); }
        }

        public int4 yzxx
        {
            get { return new int4(this.s1, this.s2, this.s0, this.s0); }
        }

        public int4 yzxy
        {
            get { return new int4(this.s1, this.s2, this.s0, this.s1); }
        }

        public int4 yzxz
        {
            get { return new int4(this.s1, this.s2, this.s0, this.s2); }
        }

        public int4 yzxw
        {
            get { return new int4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public int4 yzyx
        {
            get { return new int4(this.s1, this.s2, this.s1, this.s0); }
        }

        public int4 yzyy
        {
            get { return new int4(this.s1, this.s2, this.s1, this.s1); }
        }

        public int4 yzyz
        {
            get { return new int4(this.s1, this.s2, this.s1, this.s2); }
        }

        public int4 yzyw
        {
            get { return new int4(this.s1, this.s2, this.s1, this.s3); }
        }

        public int4 yzzx
        {
            get { return new int4(this.s1, this.s2, this.s2, this.s0); }
        }

        public int4 yzzy
        {
            get { return new int4(this.s1, this.s2, this.s2, this.s1); }
        }

        public int4 yzzz
        {
            get { return new int4(this.s1, this.s2, this.s2, this.s2); }
        }

        public int4 yzzw
        {
            get { return new int4(this.s1, this.s2, this.s2, this.s3); }
        }

        public int4 yzwx
        {
            get { return new int4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public int4 yzwy
        {
            get { return new int4(this.s1, this.s2, this.s3, this.s1); }
        }

        public int4 yzwz
        {
            get { return new int4(this.s1, this.s2, this.s3, this.s2); }
        }

        public int4 yzww
        {
            get { return new int4(this.s1, this.s2, this.s3, this.s3); }
        }

        public int4 ywxx
        {
            get { return new int4(this.s1, this.s3, this.s0, this.s0); }
        }

        public int4 ywxy
        {
            get { return new int4(this.s1, this.s3, this.s0, this.s1); }
        }

        public int4 ywxz
        {
            get { return new int4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public int4 ywxw
        {
            get { return new int4(this.s1, this.s3, this.s0, this.s3); }
        }

        public int4 ywyx
        {
            get { return new int4(this.s1, this.s3, this.s1, this.s0); }
        }

        public int4 ywyy
        {
            get { return new int4(this.s1, this.s3, this.s1, this.s1); }
        }

        public int4 ywyz
        {
            get { return new int4(this.s1, this.s3, this.s1, this.s2); }
        }

        public int4 ywyw
        {
            get { return new int4(this.s1, this.s3, this.s1, this.s3); }
        }

        public int4 ywzx
        {
            get { return new int4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public int4 ywzy
        {
            get { return new int4(this.s1, this.s3, this.s2, this.s1); }
        }

        public int4 ywzz
        {
            get { return new int4(this.s1, this.s3, this.s2, this.s2); }
        }

        public int4 ywzw
        {
            get { return new int4(this.s1, this.s3, this.s2, this.s3); }
        }

        public int4 ywwx
        {
            get { return new int4(this.s1, this.s3, this.s3, this.s0); }
        }

        public int4 ywwy
        {
            get { return new int4(this.s1, this.s3, this.s3, this.s1); }
        }

        public int4 ywwz
        {
            get { return new int4(this.s1, this.s3, this.s3, this.s2); }
        }

        public int4 ywww
        {
            get { return new int4(this.s1, this.s3, this.s3, this.s3); }
        }

        public int4 zxxx
        {
            get { return new int4(this.s2, this.s0, this.s0, this.s0); }
        }

        public int4 zxxy
        {
            get { return new int4(this.s2, this.s0, this.s0, this.s1); }
        }

        public int4 zxxz
        {
            get { return new int4(this.s2, this.s0, this.s0, this.s2); }
        }

        public int4 zxxw
        {
            get { return new int4(this.s2, this.s0, this.s0, this.s3); }
        }

        public int4 zxyx
        {
            get { return new int4(this.s2, this.s0, this.s1, this.s0); }
        }

        public int4 zxyy
        {
            get { return new int4(this.s2, this.s0, this.s1, this.s1); }
        }

        public int4 zxyz
        {
            get { return new int4(this.s2, this.s0, this.s1, this.s2); }
        }

        public int4 zxyw
        {
            get { return new int4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public int4 zxzx
        {
            get { return new int4(this.s2, this.s0, this.s2, this.s0); }
        }

        public int4 zxzy
        {
            get { return new int4(this.s2, this.s0, this.s2, this.s1); }
        }

        public int4 zxzz
        {
            get { return new int4(this.s2, this.s0, this.s2, this.s2); }
        }

        public int4 zxzw
        {
            get { return new int4(this.s2, this.s0, this.s2, this.s3); }
        }

        public int4 zxwx
        {
            get { return new int4(this.s2, this.s0, this.s3, this.s0); }
        }

        public int4 zxwy
        {
            get { return new int4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public int4 zxwz
        {
            get { return new int4(this.s2, this.s0, this.s3, this.s2); }
        }

        public int4 zxww
        {
            get { return new int4(this.s2, this.s0, this.s3, this.s3); }
        }

        public int4 zyxx
        {
            get { return new int4(this.s2, this.s1, this.s0, this.s0); }
        }

        public int4 zyxy
        {
            get { return new int4(this.s2, this.s1, this.s0, this.s1); }
        }

        public int4 zyxz
        {
            get { return new int4(this.s2, this.s1, this.s0, this.s2); }
        }

        public int4 zyxw
        {
            get { return new int4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public int4 zyyx
        {
            get { return new int4(this.s2, this.s1, this.s1, this.s0); }
        }

        public int4 zyyy
        {
            get { return new int4(this.s2, this.s1, this.s1, this.s1); }
        }

        public int4 zyyz
        {
            get { return new int4(this.s2, this.s1, this.s1, this.s2); }
        }

        public int4 zyyw
        {
            get { return new int4(this.s2, this.s1, this.s1, this.s3); }
        }

        public int4 zyzx
        {
            get { return new int4(this.s2, this.s1, this.s2, this.s0); }
        }

        public int4 zyzy
        {
            get { return new int4(this.s2, this.s1, this.s2, this.s1); }
        }

        public int4 zyzz
        {
            get { return new int4(this.s2, this.s1, this.s2, this.s2); }
        }

        public int4 zyzw
        {
            get { return new int4(this.s2, this.s1, this.s2, this.s3); }
        }

        public int4 zywx
        {
            get { return new int4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public int4 zywy
        {
            get { return new int4(this.s2, this.s1, this.s3, this.s1); }
        }

        public int4 zywz
        {
            get { return new int4(this.s2, this.s1, this.s3, this.s2); }
        }

        public int4 zyww
        {
            get { return new int4(this.s2, this.s1, this.s3, this.s3); }
        }

        public int4 zzxx
        {
            get { return new int4(this.s2, this.s2, this.s0, this.s0); }
        }

        public int4 zzxy
        {
            get { return new int4(this.s2, this.s2, this.s0, this.s1); }
        }

        public int4 zzxz
        {
            get { return new int4(this.s2, this.s2, this.s0, this.s2); }
        }

        public int4 zzxw
        {
            get { return new int4(this.s2, this.s2, this.s0, this.s3); }
        }

        public int4 zzyx
        {
            get { return new int4(this.s2, this.s2, this.s1, this.s0); }
        }

        public int4 zzyy
        {
            get { return new int4(this.s2, this.s2, this.s1, this.s1); }
        }

        public int4 zzyz
        {
            get { return new int4(this.s2, this.s2, this.s1, this.s2); }
        }

        public int4 zzyw
        {
            get { return new int4(this.s2, this.s2, this.s1, this.s3); }
        }

        public int4 zzzx
        {
            get { return new int4(this.s2, this.s2, this.s2, this.s0); }
        }

        public int4 zzzy
        {
            get { return new int4(this.s2, this.s2, this.s2, this.s1); }
        }

        public int4 zzzz
        {
            get { return new int4(this.s2, this.s2, this.s2, this.s2); }
        }

        public int4 zzzw
        {
            get { return new int4(this.s2, this.s2, this.s2, this.s3); }
        }

        public int4 zzwx
        {
            get { return new int4(this.s2, this.s2, this.s3, this.s0); }
        }

        public int4 zzwy
        {
            get { return new int4(this.s2, this.s2, this.s3, this.s1); }
        }

        public int4 zzwz
        {
            get { return new int4(this.s2, this.s2, this.s3, this.s2); }
        }

        public int4 zzww
        {
            get { return new int4(this.s2, this.s2, this.s3, this.s3); }
        }

        public int4 zwxx
        {
            get { return new int4(this.s2, this.s3, this.s0, this.s0); }
        }

        public int4 zwxy
        {
            get { return new int4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public int4 zwxz
        {
            get { return new int4(this.s2, this.s3, this.s0, this.s2); }
        }

        public int4 zwxw
        {
            get { return new int4(this.s2, this.s3, this.s0, this.s3); }
        }

        public int4 zwyx
        {
            get { return new int4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public int4 zwyy
        {
            get { return new int4(this.s2, this.s3, this.s1, this.s1); }
        }

        public int4 zwyz
        {
            get { return new int4(this.s2, this.s3, this.s1, this.s2); }
        }

        public int4 zwyw
        {
            get { return new int4(this.s2, this.s3, this.s1, this.s3); }
        }

        public int4 zwzx
        {
            get { return new int4(this.s2, this.s3, this.s2, this.s0); }
        }

        public int4 zwzy
        {
            get { return new int4(this.s2, this.s3, this.s2, this.s1); }
        }

        public int4 zwzz
        {
            get { return new int4(this.s2, this.s3, this.s2, this.s2); }
        }

        public int4 zwzw
        {
            get { return new int4(this.s2, this.s3, this.s2, this.s3); }
        }

        public int4 zwwx
        {
            get { return new int4(this.s2, this.s3, this.s3, this.s0); }
        }

        public int4 zwwy
        {
            get { return new int4(this.s2, this.s3, this.s3, this.s1); }
        }

        public int4 zwwz
        {
            get { return new int4(this.s2, this.s3, this.s3, this.s2); }
        }

        public int4 zwww
        {
            get { return new int4(this.s2, this.s3, this.s3, this.s3); }
        }

        public int4 wxxx
        {
            get { return new int4(this.s3, this.s0, this.s0, this.s0); }
        }

        public int4 wxxy
        {
            get { return new int4(this.s3, this.s0, this.s0, this.s1); }
        }

        public int4 wxxz
        {
            get { return new int4(this.s3, this.s0, this.s0, this.s2); }
        }

        public int4 wxxw
        {
            get { return new int4(this.s3, this.s0, this.s0, this.s3); }
        }

        public int4 wxyx
        {
            get { return new int4(this.s3, this.s0, this.s1, this.s0); }
        }

        public int4 wxyy
        {
            get { return new int4(this.s3, this.s0, this.s1, this.s1); }
        }

        public int4 wxyz
        {
            get { return new int4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public int4 wxyw
        {
            get { return new int4(this.s3, this.s0, this.s1, this.s3); }
        }

        public int4 wxzx
        {
            get { return new int4(this.s3, this.s0, this.s2, this.s0); }
        }

        public int4 wxzy
        {
            get { return new int4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public int4 wxzz
        {
            get { return new int4(this.s3, this.s0, this.s2, this.s2); }
        }

        public int4 wxzw
        {
            get { return new int4(this.s3, this.s0, this.s2, this.s3); }
        }

        public int4 wxwx
        {
            get { return new int4(this.s3, this.s0, this.s3, this.s0); }
        }

        public int4 wxwy
        {
            get { return new int4(this.s3, this.s0, this.s3, this.s1); }
        }

        public int4 wxwz
        {
            get { return new int4(this.s3, this.s0, this.s3, this.s2); }
        }

        public int4 wxww
        {
            get { return new int4(this.s3, this.s0, this.s3, this.s3); }
        }

        public int4 wyxx
        {
            get { return new int4(this.s3, this.s1, this.s0, this.s0); }
        }

        public int4 wyxy
        {
            get { return new int4(this.s3, this.s1, this.s0, this.s1); }
        }

        public int4 wyxz
        {
            get { return new int4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public int4 wyxw
        {
            get { return new int4(this.s3, this.s1, this.s0, this.s3); }
        }

        public int4 wyyx
        {
            get { return new int4(this.s3, this.s1, this.s1, this.s0); }
        }

        public int4 wyyy
        {
            get { return new int4(this.s3, this.s1, this.s1, this.s1); }
        }

        public int4 wyyz
        {
            get { return new int4(this.s3, this.s1, this.s1, this.s2); }
        }

        public int4 wyyw
        {
            get { return new int4(this.s3, this.s1, this.s1, this.s3); }
        }

        public int4 wyzx
        {
            get { return new int4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public int4 wyzy
        {
            get { return new int4(this.s3, this.s1, this.s2, this.s1); }
        }

        public int4 wyzz
        {
            get { return new int4(this.s3, this.s1, this.s2, this.s2); }
        }

        public int4 wyzw
        {
            get { return new int4(this.s3, this.s1, this.s2, this.s3); }
        }

        public int4 wywx
        {
            get { return new int4(this.s3, this.s1, this.s3, this.s0); }
        }

        public int4 wywy
        {
            get { return new int4(this.s3, this.s1, this.s3, this.s1); }
        }

        public int4 wywz
        {
            get { return new int4(this.s3, this.s1, this.s3, this.s2); }
        }

        public int4 wyww
        {
            get { return new int4(this.s3, this.s1, this.s3, this.s3); }
        }

        public int4 wzxx
        {
            get { return new int4(this.s3, this.s2, this.s0, this.s0); }
        }

        public int4 wzxy
        {
            get { return new int4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public int4 wzxz
        {
            get { return new int4(this.s3, this.s2, this.s0, this.s2); }
        }

        public int4 wzxw
        {
            get { return new int4(this.s3, this.s2, this.s0, this.s3); }
        }

        public int4 wzyx
        {
            get { return new int4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public int4 wzyy
        {
            get { return new int4(this.s3, this.s2, this.s1, this.s1); }
        }

        public int4 wzyz
        {
            get { return new int4(this.s3, this.s2, this.s1, this.s2); }
        }

        public int4 wzyw
        {
            get { return new int4(this.s3, this.s2, this.s1, this.s3); }
        }

        public int4 wzzx
        {
            get { return new int4(this.s3, this.s2, this.s2, this.s0); }
        }

        public int4 wzzy
        {
            get { return new int4(this.s3, this.s2, this.s2, this.s1); }
        }

        public int4 wzzz
        {
            get { return new int4(this.s3, this.s2, this.s2, this.s2); }
        }

        public int4 wzzw
        {
            get { return new int4(this.s3, this.s2, this.s2, this.s3); }
        }

        public int4 wzwx
        {
            get { return new int4(this.s3, this.s2, this.s3, this.s0); }
        }

        public int4 wzwy
        {
            get { return new int4(this.s3, this.s2, this.s3, this.s1); }
        }

        public int4 wzwz
        {
            get { return new int4(this.s3, this.s2, this.s3, this.s2); }
        }

        public int4 wzww
        {
            get { return new int4(this.s3, this.s2, this.s3, this.s3); }
        }

        public int4 wwxx
        {
            get { return new int4(this.s3, this.s3, this.s0, this.s0); }
        }

        public int4 wwxy
        {
            get { return new int4(this.s3, this.s3, this.s0, this.s1); }
        }

        public int4 wwxz
        {
            get { return new int4(this.s3, this.s3, this.s0, this.s2); }
        }

        public int4 wwxw
        {
            get { return new int4(this.s3, this.s3, this.s0, this.s3); }
        }

        public int4 wwyx
        {
            get { return new int4(this.s3, this.s3, this.s1, this.s0); }
        }

        public int4 wwyy
        {
            get { return new int4(this.s3, this.s3, this.s1, this.s1); }
        }

        public int4 wwyz
        {
            get { return new int4(this.s3, this.s3, this.s1, this.s2); }
        }

        public int4 wwyw
        {
            get { return new int4(this.s3, this.s3, this.s1, this.s3); }
        }

        public int4 wwzx
        {
            get { return new int4(this.s3, this.s3, this.s2, this.s0); }
        }

        public int4 wwzy
        {
            get { return new int4(this.s3, this.s3, this.s2, this.s1); }
        }

        public int4 wwzz
        {
            get { return new int4(this.s3, this.s3, this.s2, this.s2); }
        }

        public int4 wwzw
        {
            get { return new int4(this.s3, this.s3, this.s2, this.s3); }
        }

        public int4 wwwx
        {
            get { return new int4(this.s3, this.s3, this.s3, this.s0); }
        }

        public int4 wwwy
        {
            get { return new int4(this.s3, this.s3, this.s3, this.s1); }
        }

        public int4 wwwz
        {
            get { return new int4(this.s3, this.s3, this.s3, this.s2); }
        }

        public int4 wwww
        {
            get { return new int4(this.s3, this.s3, this.s3, this.s3); }
        }

        public int this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(int4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is int4 && Equals((int4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static int4 operator +(int4 a, int4 b) => new int4((int)(a.s0+b.s0), (int)(a.s1+b.s1), (int)(a.s2+b.s2), (int)(a.s3+b.s3));

        public static int4 operator -(int4 a, int4 b) => new int4((int)(a.s0-b.s0), (int)(a.s1-b.s1), (int)(a.s2-b.s2), (int)(a.s3-b.s3));

        public static int4 operator *(int4 a, int4 b) => new int4((int)(a.s0*b.s0), (int)(a.s1*b.s1), (int)(a.s2*b.s2), (int)(a.s3*b.s3));

        public static int4 operator /(int4 a, int4 b) => new int4((int)(a.s0/b.s0), (int)(a.s1/b.s1), (int)(a.s2/b.s2), (int)(a.s3/b.s3));

        public static int4 operator ==(int4 a, int4 b) => new int4(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0);

        public static int4 operator !=(int4 a, int4 b) => new int4(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0);

        public static int4 operator <(int4 a, int4 b) => new int4(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0);

        public static int4 operator <=(int4 a, int4 b) => new int4(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0);

        public static int4 operator >(int4 a, int4 b) => new int4(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0);

        public static int4 operator >=(int4 a, int4 b) => new int4(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0);

        public static int4 operator &(int4 a, int4 b) => new int4((int)(a.s0&b.s0), (int)(a.s1&b.s1), (int)(a.s2&b.s2), (int)(a.s3&b.s3));

        public static int4 operator |(int4 a, int4 b) => new int4((int)(a.s0|b.s0), (int)(a.s1|b.s1), (int)(a.s2|b.s2), (int)(a.s3|b.s3));

        public static int4 operator ^(int4 a, int4 b) => new int4((int)(a.s0^b.s0), (int)(a.s1^b.s1), (int)(a.s2^b.s2), (int)(a.s3^b.s3));

        public static int4 operator +(int4 a) => a;

        public static int4 operator -(int4 a) => new int4((int)(-a.s0), (int)(-a.s1), (int)(-a.s2), (int)(-a.s3));

        public static int4 operator ~(int4 a) => new int4((int)(~a.s0), (int)(~a.s1), (int)(~a.s2), (int)(~a.s3));

        public static int4 operator ++(int4 a) => new int4((int)(a.s0+1), (int)(a.s1+1), (int)(a.s2+1), (int)(a.s3+1));

        public static int4 operator --(int4 a) => new int4((int)(a.s0-1), (int)(a.s1-1), (int)(a.s2-1), (int)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct int8: IVectorType, IEquatable<int8>
    {
        [FieldOffset(0)]
        public int s0;
        [FieldOffset(4)]
        public int s1;
        [FieldOffset(8)]
        public int s2;
        [FieldOffset(12)]
        public int s3;
        [FieldOffset(16)]
        public int s4;
        [FieldOffset(20)]
        public int s5;
        [FieldOffset(24)]
        public int s6;
        [FieldOffset(28)]
        public int s7;

        public int8(int v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public int8(int v0, int v1, int v2, int v3, int v4, int v5, int v6, int v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public int this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(int8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is int8 && Equals((int8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static int8 operator +(int8 a, int8 b) => new int8((int)(a.s0+b.s0), (int)(a.s1+b.s1), (int)(a.s2+b.s2), (int)(a.s3+b.s3), (int)(a.s4+b.s4), (int)(a.s5+b.s5), (int)(a.s6+b.s6), (int)(a.s7+b.s7));

        public static int8 operator -(int8 a, int8 b) => new int8((int)(a.s0-b.s0), (int)(a.s1-b.s1), (int)(a.s2-b.s2), (int)(a.s3-b.s3), (int)(a.s4-b.s4), (int)(a.s5-b.s5), (int)(a.s6-b.s6), (int)(a.s7-b.s7));

        public static int8 operator *(int8 a, int8 b) => new int8((int)(a.s0*b.s0), (int)(a.s1*b.s1), (int)(a.s2*b.s2), (int)(a.s3*b.s3), (int)(a.s4*b.s4), (int)(a.s5*b.s5), (int)(a.s6*b.s6), (int)(a.s7*b.s7));

        public static int8 operator /(int8 a, int8 b) => new int8((int)(a.s0/b.s0), (int)(a.s1/b.s1), (int)(a.s2/b.s2), (int)(a.s3/b.s3), (int)(a.s4/b.s4), (int)(a.s5/b.s5), (int)(a.s6/b.s6), (int)(a.s7/b.s7));

        public static int8 operator ==(int8 a, int8 b) => new int8(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0, a.s4==b.s4 ? -1 : 0, a.s5==b.s5 ? -1 : 0, a.s6==b.s6 ? -1 : 0, a.s7==b.s7 ? -1 : 0);

        public static int8 operator !=(int8 a, int8 b) => new int8(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0, a.s4!=b.s4 ? -1 : 0, a.s5!=b.s5 ? -1 : 0, a.s6!=b.s6 ? -1 : 0, a.s7!=b.s7 ? -1 : 0);

        public static int8 operator <(int8 a, int8 b) => new int8(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0, a.s4<b.s4 ? -1 : 0, a.s5<b.s5 ? -1 : 0, a.s6<b.s6 ? -1 : 0, a.s7<b.s7 ? -1 : 0);

        public static int8 operator <=(int8 a, int8 b) => new int8(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0, a.s4<=b.s4 ? -1 : 0, a.s5<=b.s5 ? -1 : 0, a.s6<=b.s6 ? -1 : 0, a.s7<=b.s7 ? -1 : 0);

        public static int8 operator >(int8 a, int8 b) => new int8(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0, a.s4>b.s4 ? -1 : 0, a.s5>b.s5 ? -1 : 0, a.s6>b.s6 ? -1 : 0, a.s7>b.s7 ? -1 : 0);

        public static int8 operator >=(int8 a, int8 b) => new int8(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0, a.s4>=b.s4 ? -1 : 0, a.s5>=b.s5 ? -1 : 0, a.s6>=b.s6 ? -1 : 0, a.s7>=b.s7 ? -1 : 0);

        public static int8 operator &(int8 a, int8 b) => new int8((int)(a.s0&b.s0), (int)(a.s1&b.s1), (int)(a.s2&b.s2), (int)(a.s3&b.s3), (int)(a.s4&b.s4), (int)(a.s5&b.s5), (int)(a.s6&b.s6), (int)(a.s7&b.s7));

        public static int8 operator |(int8 a, int8 b) => new int8((int)(a.s0|b.s0), (int)(a.s1|b.s1), (int)(a.s2|b.s2), (int)(a.s3|b.s3), (int)(a.s4|b.s4), (int)(a.s5|b.s5), (int)(a.s6|b.s6), (int)(a.s7|b.s7));

        public static int8 operator ^(int8 a, int8 b) => new int8((int)(a.s0^b.s0), (int)(a.s1^b.s1), (int)(a.s2^b.s2), (int)(a.s3^b.s3), (int)(a.s4^b.s4), (int)(a.s5^b.s5), (int)(a.s6^b.s6), (int)(a.s7^b.s7));

        public static int8 operator +(int8 a) => a;

        public static int8 operator -(int8 a) => new int8((int)(-a.s0), (int)(-a.s1), (int)(-a.s2), (int)(-a.s3), (int)(-a.s4), (int)(-a.s5), (int)(-a.s6), (int)(-a.s7));

        public static int8 operator ~(int8 a) => new int8((int)(~a.s0), (int)(~a.s1), (int)(~a.s2), (int)(~a.s3), (int)(~a.s4), (int)(~a.s5), (int)(~a.s6), (int)(~a.s7));

        public static int8 operator ++(int8 a) => new int8((int)(a.s0+1), (int)(a.s1+1), (int)(a.s2+1), (int)(a.s3+1), (int)(a.s4+1), (int)(a.s5+1), (int)(a.s6+1), (int)(a.s7+1));

        public static int8 operator --(int8 a) => new int8((int)(a.s0-1), (int)(a.s1-1), (int)(a.s2-1), (int)(a.s3-1), (int)(a.s4-1), (int)(a.s5-1), (int)(a.s6-1), (int)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct int16: IVectorType, IEquatable<int16>
    {
        [FieldOffset(0)]
        public int s0;
        [FieldOffset(4)]
        public int s1;
        [FieldOffset(8)]
        public int s2;
        [FieldOffset(12)]
        public int s3;
        [FieldOffset(16)]
        public int s4;
        [FieldOffset(20)]
        public int s5;
        [FieldOffset(24)]
        public int s6;
        [FieldOffset(28)]
        public int s7;
        [FieldOffset(32)]
        public int s8;
        [FieldOffset(36)]
        public int s9;
        [FieldOffset(40)]
        public int sa;
        [FieldOffset(44)]
        public int sb;
        [FieldOffset(48)]
        public int sc;
        [FieldOffset(52)]
        public int sd;
        [FieldOffset(56)]
        public int se;
        [FieldOffset(60)]
        public int sf;

        public int16(int v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public int16(int v0, int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int v9, int va, int vb, int vc, int vd, int ve, int vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public int sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public int sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public int sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public int sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public int sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public int sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public int this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 64; }
        }

        // IEquatable

        public bool Equals(int16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is int16 && Equals((int16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static int16 operator +(int16 a, int16 b) => new int16((int)(a.s0+b.s0), (int)(a.s1+b.s1), (int)(a.s2+b.s2), (int)(a.s3+b.s3), (int)(a.s4+b.s4), (int)(a.s5+b.s5), (int)(a.s6+b.s6), (int)(a.s7+b.s7), (int)(a.s8+b.s8), (int)(a.s9+b.s9), (int)(a.sa+b.sa), (int)(a.sb+b.sb), (int)(a.sc+b.sc), (int)(a.sd+b.sd), (int)(a.se+b.se), (int)(a.sf+b.sf));

        public static int16 operator -(int16 a, int16 b) => new int16((int)(a.s0-b.s0), (int)(a.s1-b.s1), (int)(a.s2-b.s2), (int)(a.s3-b.s3), (int)(a.s4-b.s4), (int)(a.s5-b.s5), (int)(a.s6-b.s6), (int)(a.s7-b.s7), (int)(a.s8-b.s8), (int)(a.s9-b.s9), (int)(a.sa-b.sa), (int)(a.sb-b.sb), (int)(a.sc-b.sc), (int)(a.sd-b.sd), (int)(a.se-b.se), (int)(a.sf-b.sf));

        public static int16 operator *(int16 a, int16 b) => new int16((int)(a.s0*b.s0), (int)(a.s1*b.s1), (int)(a.s2*b.s2), (int)(a.s3*b.s3), (int)(a.s4*b.s4), (int)(a.s5*b.s5), (int)(a.s6*b.s6), (int)(a.s7*b.s7), (int)(a.s8*b.s8), (int)(a.s9*b.s9), (int)(a.sa*b.sa), (int)(a.sb*b.sb), (int)(a.sc*b.sc), (int)(a.sd*b.sd), (int)(a.se*b.se), (int)(a.sf*b.sf));

        public static int16 operator /(int16 a, int16 b) => new int16((int)(a.s0/b.s0), (int)(a.s1/b.s1), (int)(a.s2/b.s2), (int)(a.s3/b.s3), (int)(a.s4/b.s4), (int)(a.s5/b.s5), (int)(a.s6/b.s6), (int)(a.s7/b.s7), (int)(a.s8/b.s8), (int)(a.s9/b.s9), (int)(a.sa/b.sa), (int)(a.sb/b.sb), (int)(a.sc/b.sc), (int)(a.sd/b.sd), (int)(a.se/b.se), (int)(a.sf/b.sf));

        public static int16 operator ==(int16 a, int16 b) => new int16(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0, a.s4==b.s4 ? -1 : 0, a.s5==b.s5 ? -1 : 0, a.s6==b.s6 ? -1 : 0, a.s7==b.s7 ? -1 : 0, a.s8==b.s8 ? -1 : 0, a.s9==b.s9 ? -1 : 0, a.sa==b.sa ? -1 : 0, a.sb==b.sb ? -1 : 0, a.sc==b.sc ? -1 : 0, a.sd==b.sd ? -1 : 0, a.se==b.se ? -1 : 0, a.sf==b.sf ? -1 : 0);

        public static int16 operator !=(int16 a, int16 b) => new int16(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0, a.s4!=b.s4 ? -1 : 0, a.s5!=b.s5 ? -1 : 0, a.s6!=b.s6 ? -1 : 0, a.s7!=b.s7 ? -1 : 0, a.s8!=b.s8 ? -1 : 0, a.s9!=b.s9 ? -1 : 0, a.sa!=b.sa ? -1 : 0, a.sb!=b.sb ? -1 : 0, a.sc!=b.sc ? -1 : 0, a.sd!=b.sd ? -1 : 0, a.se!=b.se ? -1 : 0, a.sf!=b.sf ? -1 : 0);

        public static int16 operator <(int16 a, int16 b) => new int16(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0, a.s4<b.s4 ? -1 : 0, a.s5<b.s5 ? -1 : 0, a.s6<b.s6 ? -1 : 0, a.s7<b.s7 ? -1 : 0, a.s8<b.s8 ? -1 : 0, a.s9<b.s9 ? -1 : 0, a.sa<b.sa ? -1 : 0, a.sb<b.sb ? -1 : 0, a.sc<b.sc ? -1 : 0, a.sd<b.sd ? -1 : 0, a.se<b.se ? -1 : 0, a.sf<b.sf ? -1 : 0);

        public static int16 operator <=(int16 a, int16 b) => new int16(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0, a.s4<=b.s4 ? -1 : 0, a.s5<=b.s5 ? -1 : 0, a.s6<=b.s6 ? -1 : 0, a.s7<=b.s7 ? -1 : 0, a.s8<=b.s8 ? -1 : 0, a.s9<=b.s9 ? -1 : 0, a.sa<=b.sa ? -1 : 0, a.sb<=b.sb ? -1 : 0, a.sc<=b.sc ? -1 : 0, a.sd<=b.sd ? -1 : 0, a.se<=b.se ? -1 : 0, a.sf<=b.sf ? -1 : 0);

        public static int16 operator >(int16 a, int16 b) => new int16(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0, a.s4>b.s4 ? -1 : 0, a.s5>b.s5 ? -1 : 0, a.s6>b.s6 ? -1 : 0, a.s7>b.s7 ? -1 : 0, a.s8>b.s8 ? -1 : 0, a.s9>b.s9 ? -1 : 0, a.sa>b.sa ? -1 : 0, a.sb>b.sb ? -1 : 0, a.sc>b.sc ? -1 : 0, a.sd>b.sd ? -1 : 0, a.se>b.se ? -1 : 0, a.sf>b.sf ? -1 : 0);

        public static int16 operator >=(int16 a, int16 b) => new int16(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0, a.s4>=b.s4 ? -1 : 0, a.s5>=b.s5 ? -1 : 0, a.s6>=b.s6 ? -1 : 0, a.s7>=b.s7 ? -1 : 0, a.s8>=b.s8 ? -1 : 0, a.s9>=b.s9 ? -1 : 0, a.sa>=b.sa ? -1 : 0, a.sb>=b.sb ? -1 : 0, a.sc>=b.sc ? -1 : 0, a.sd>=b.sd ? -1 : 0, a.se>=b.se ? -1 : 0, a.sf>=b.sf ? -1 : 0);

        public static int16 operator &(int16 a, int16 b) => new int16((int)(a.s0&b.s0), (int)(a.s1&b.s1), (int)(a.s2&b.s2), (int)(a.s3&b.s3), (int)(a.s4&b.s4), (int)(a.s5&b.s5), (int)(a.s6&b.s6), (int)(a.s7&b.s7), (int)(a.s8&b.s8), (int)(a.s9&b.s9), (int)(a.sa&b.sa), (int)(a.sb&b.sb), (int)(a.sc&b.sc), (int)(a.sd&b.sd), (int)(a.se&b.se), (int)(a.sf&b.sf));

        public static int16 operator |(int16 a, int16 b) => new int16((int)(a.s0|b.s0), (int)(a.s1|b.s1), (int)(a.s2|b.s2), (int)(a.s3|b.s3), (int)(a.s4|b.s4), (int)(a.s5|b.s5), (int)(a.s6|b.s6), (int)(a.s7|b.s7), (int)(a.s8|b.s8), (int)(a.s9|b.s9), (int)(a.sa|b.sa), (int)(a.sb|b.sb), (int)(a.sc|b.sc), (int)(a.sd|b.sd), (int)(a.se|b.se), (int)(a.sf|b.sf));

        public static int16 operator ^(int16 a, int16 b) => new int16((int)(a.s0^b.s0), (int)(a.s1^b.s1), (int)(a.s2^b.s2), (int)(a.s3^b.s3), (int)(a.s4^b.s4), (int)(a.s5^b.s5), (int)(a.s6^b.s6), (int)(a.s7^b.s7), (int)(a.s8^b.s8), (int)(a.s9^b.s9), (int)(a.sa^b.sa), (int)(a.sb^b.sb), (int)(a.sc^b.sc), (int)(a.sd^b.sd), (int)(a.se^b.se), (int)(a.sf^b.sf));

        public static int16 operator +(int16 a) => a;

        public static int16 operator -(int16 a) => new int16((int)(-a.s0), (int)(-a.s1), (int)(-a.s2), (int)(-a.s3), (int)(-a.s4), (int)(-a.s5), (int)(-a.s6), (int)(-a.s7), (int)(-a.s8), (int)(-a.s9), (int)(-a.sa), (int)(-a.sb), (int)(-a.sc), (int)(-a.sd), (int)(-a.se), (int)(-a.sf));

        public static int16 operator ~(int16 a) => new int16((int)(~a.s0), (int)(~a.s1), (int)(~a.s2), (int)(~a.s3), (int)(~a.s4), (int)(~a.s5), (int)(~a.s6), (int)(~a.s7), (int)(~a.s8), (int)(~a.s9), (int)(~a.sa), (int)(~a.sb), (int)(~a.sc), (int)(~a.sd), (int)(~a.se), (int)(~a.sf));

        public static int16 operator ++(int16 a) => new int16((int)(a.s0+1), (int)(a.s1+1), (int)(a.s2+1), (int)(a.s3+1), (int)(a.s4+1), (int)(a.s5+1), (int)(a.s6+1), (int)(a.s7+1), (int)(a.s8+1), (int)(a.s9+1), (int)(a.sa+1), (int)(a.sb+1), (int)(a.sc+1), (int)(a.sd+1), (int)(a.se+1), (int)(a.sf+1));

        public static int16 operator --(int16 a) => new int16((int)(a.s0-1), (int)(a.s1-1), (int)(a.s2-1), (int)(a.s3-1), (int)(a.s4-1), (int)(a.s5-1), (int)(a.s6-1), (int)(a.s7-1), (int)(a.s8-1), (int)(a.s9-1), (int)(a.sa-1), (int)(a.sb-1), (int)(a.sc-1), (int)(a.sd-1), (int)(a.se-1), (int)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct uint2: IVectorType, IEquatable<uint2>
    {
        [FieldOffset(0)]
        public uint s0;
        [FieldOffset(4)]
        public uint s1;

        public uint2(uint v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public uint2(uint2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public uint2(uint v0, uint v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public uint x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public uint y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public uint2 xx
        {
            get { return new uint2(this.s0, this.s0); }
        }

        public uint2 xy
        {
            get { return new uint2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public uint2 yx
        {
            get { return new uint2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public uint2 yy
        {
            get { return new uint2(this.s1, this.s1); }
        }

        public uint this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 8; }
        }

        // IEquatable

        public bool Equals(uint2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is uint2 && Equals((uint2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static uint2 operator +(uint2 a, uint2 b) => new uint2((uint)(a.s0+b.s0), (uint)(a.s1+b.s1));

        public static uint2 operator -(uint2 a, uint2 b) => new uint2((uint)(a.s0-b.s0), (uint)(a.s1-b.s1));

        public static uint2 operator *(uint2 a, uint2 b) => new uint2((uint)(a.s0*b.s0), (uint)(a.s1*b.s1));

        public static uint2 operator /(uint2 a, uint2 b) => new uint2((uint)(a.s0/b.s0), (uint)(a.s1/b.s1));

        public static int2 operator ==(uint2 a, uint2 b) => new int2(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0);

        public static int2 operator !=(uint2 a, uint2 b) => new int2(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0);

        public static int2 operator <(uint2 a, uint2 b) => new int2(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0);

        public static int2 operator <=(uint2 a, uint2 b) => new int2(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0);

        public static int2 operator >(uint2 a, uint2 b) => new int2(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0);

        public static int2 operator >=(uint2 a, uint2 b) => new int2(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0);

        public static uint2 operator &(uint2 a, uint2 b) => new uint2((uint)(a.s0&b.s0), (uint)(a.s1&b.s1));

        public static uint2 operator |(uint2 a, uint2 b) => new uint2((uint)(a.s0|b.s0), (uint)(a.s1|b.s1));

        public static uint2 operator ^(uint2 a, uint2 b) => new uint2((uint)(a.s0^b.s0), (uint)(a.s1^b.s1));

        public static uint2 operator +(uint2 a) => a;

        public static uint2 operator ~(uint2 a) => new uint2((uint)(~a.s0), (uint)(~a.s1));

        public static uint2 operator ++(uint2 a) => new uint2((uint)(a.s0+1), (uint)(a.s1+1));

        public static uint2 operator --(uint2 a) => new uint2((uint)(a.s0-1), (uint)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=16)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct uint3: IVectorType, IEquatable<uint3>
    {
        [FieldOffset(0)]
        public uint s0;
        [FieldOffset(4)]
        public uint s1;
        [FieldOffset(8)]
        public uint s2;

        public uint3(uint v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public uint3(uint3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public uint3(uint v0, uint2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public uint3(uint2 v0, uint v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public uint3(uint v0, uint v1, uint v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public uint x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public uint y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public uint z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public uint2 xx
        {
            get { return new uint2(this.s0, this.s0); }
        }

        public uint2 xy
        {
            get { return new uint2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public uint2 xz
        {
            get { return new uint2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public uint2 yx
        {
            get { return new uint2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public uint2 yy
        {
            get { return new uint2(this.s1, this.s1); }
        }

        public uint2 yz
        {
            get { return new uint2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public uint2 zx
        {
            get { return new uint2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public uint2 zy
        {
            get { return new uint2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public uint2 zz
        {
            get { return new uint2(this.s2, this.s2); }
        }

        public uint3 xxx
        {
            get { return new uint3(this.s0, this.s0, this.s0); }
        }

        public uint3 xxy
        {
            get { return new uint3(this.s0, this.s0, this.s1); }
        }

        public uint3 xxz
        {
            get { return new uint3(this.s0, this.s0, this.s2); }
        }

        public uint3 xyx
        {
            get { return new uint3(this.s0, this.s1, this.s0); }
        }

        public uint3 xyy
        {
            get { return new uint3(this.s0, this.s1, this.s1); }
        }

        public uint3 xyz
        {
            get { return new uint3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 xzx
        {
            get { return new uint3(this.s0, this.s2, this.s0); }
        }

        public uint3 xzy
        {
            get { return new uint3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 xzz
        {
            get { return new uint3(this.s0, this.s2, this.s2); }
        }

        public uint3 yxx
        {
            get { return new uint3(this.s1, this.s0, this.s0); }
        }

        public uint3 yxy
        {
            get { return new uint3(this.s1, this.s0, this.s1); }
        }

        public uint3 yxz
        {
            get { return new uint3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 yyx
        {
            get { return new uint3(this.s1, this.s1, this.s0); }
        }

        public uint3 yyy
        {
            get { return new uint3(this.s1, this.s1, this.s1); }
        }

        public uint3 yyz
        {
            get { return new uint3(this.s1, this.s1, this.s2); }
        }

        public uint3 yzx
        {
            get { return new uint3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 yzy
        {
            get { return new uint3(this.s1, this.s2, this.s1); }
        }

        public uint3 yzz
        {
            get { return new uint3(this.s1, this.s2, this.s2); }
        }

        public uint3 zxx
        {
            get { return new uint3(this.s2, this.s0, this.s0); }
        }

        public uint3 zxy
        {
            get { return new uint3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 zxz
        {
            get { return new uint3(this.s2, this.s0, this.s2); }
        }

        public uint3 zyx
        {
            get { return new uint3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 zyy
        {
            get { return new uint3(this.s2, this.s1, this.s1); }
        }

        public uint3 zyz
        {
            get { return new uint3(this.s2, this.s1, this.s2); }
        }

        public uint3 zzx
        {
            get { return new uint3(this.s2, this.s2, this.s0); }
        }

        public uint3 zzy
        {
            get { return new uint3(this.s2, this.s2, this.s1); }
        }

        public uint3 zzz
        {
            get { return new uint3(this.s2, this.s2, this.s2); }
        }

        public uint this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 12; }
        }

        // IEquatable

        public bool Equals(uint3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is uint3 && Equals((uint3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static uint3 operator +(uint3 a, uint3 b) => new uint3((uint)(a.s0+b.s0), (uint)(a.s1+b.s1), (uint)(a.s2+b.s2));

        public static uint3 operator -(uint3 a, uint3 b) => new uint3((uint)(a.s0-b.s0), (uint)(a.s1-b.s1), (uint)(a.s2-b.s2));

        public static uint3 operator *(uint3 a, uint3 b) => new uint3((uint)(a.s0*b.s0), (uint)(a.s1*b.s1), (uint)(a.s2*b.s2));

        public static uint3 operator /(uint3 a, uint3 b) => new uint3((uint)(a.s0/b.s0), (uint)(a.s1/b.s1), (uint)(a.s2/b.s2));

        public static int3 operator ==(uint3 a, uint3 b) => new int3(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0);

        public static int3 operator !=(uint3 a, uint3 b) => new int3(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0);

        public static int3 operator <(uint3 a, uint3 b) => new int3(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0);

        public static int3 operator <=(uint3 a, uint3 b) => new int3(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0);

        public static int3 operator >(uint3 a, uint3 b) => new int3(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0);

        public static int3 operator >=(uint3 a, uint3 b) => new int3(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0);

        public static uint3 operator &(uint3 a, uint3 b) => new uint3((uint)(a.s0&b.s0), (uint)(a.s1&b.s1), (uint)(a.s2&b.s2));

        public static uint3 operator |(uint3 a, uint3 b) => new uint3((uint)(a.s0|b.s0), (uint)(a.s1|b.s1), (uint)(a.s2|b.s2));

        public static uint3 operator ^(uint3 a, uint3 b) => new uint3((uint)(a.s0^b.s0), (uint)(a.s1^b.s1), (uint)(a.s2^b.s2));

        public static uint3 operator +(uint3 a) => a;

        public static uint3 operator ~(uint3 a) => new uint3((uint)(~a.s0), (uint)(~a.s1), (uint)(~a.s2));

        public static uint3 operator ++(uint3 a) => new uint3((uint)(a.s0+1), (uint)(a.s1+1), (uint)(a.s2+1));

        public static uint3 operator --(uint3 a) => new uint3((uint)(a.s0-1), (uint)(a.s1-1), (uint)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct uint4: IVectorType, IEquatable<uint4>
    {
        [FieldOffset(0)]
        public uint s0;
        [FieldOffset(4)]
        public uint s1;
        [FieldOffset(8)]
        public uint s2;
        [FieldOffset(12)]
        public uint s3;

        public uint4(uint v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public uint4(uint4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public uint4(uint v0, uint3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public uint4(uint2 v0, uint2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public uint4(uint3 v0, uint v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public uint4(uint v0, uint v1, uint2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public uint4(uint v0, uint2 v1, uint v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public uint4(uint2 v0, uint v1, uint v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public uint4(uint v0, uint v1, uint v2, uint v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public uint x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public uint y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public uint z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public uint w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public uint2 xx
        {
            get { return new uint2(this.s0, this.s0); }
        }

        public uint2 xy
        {
            get { return new uint2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public uint2 xz
        {
            get { return new uint2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public uint2 xw
        {
            get { return new uint2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public uint2 yx
        {
            get { return new uint2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public uint2 yy
        {
            get { return new uint2(this.s1, this.s1); }
        }

        public uint2 yz
        {
            get { return new uint2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public uint2 yw
        {
            get { return new uint2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public uint2 zx
        {
            get { return new uint2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public uint2 zy
        {
            get { return new uint2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public uint2 zz
        {
            get { return new uint2(this.s2, this.s2); }
        }

        public uint2 zw
        {
            get { return new uint2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public uint2 wx
        {
            get { return new uint2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public uint2 wy
        {
            get { return new uint2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public uint2 wz
        {
            get { return new uint2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public uint2 ww
        {
            get { return new uint2(this.s3, this.s3); }
        }

        public uint3 xxx
        {
            get { return new uint3(this.s0, this.s0, this.s0); }
        }

        public uint3 xxy
        {
            get { return new uint3(this.s0, this.s0, this.s1); }
        }

        public uint3 xxz
        {
            get { return new uint3(this.s0, this.s0, this.s2); }
        }

        public uint3 xxw
        {
            get { return new uint3(this.s0, this.s0, this.s3); }
        }

        public uint3 xyx
        {
            get { return new uint3(this.s0, this.s1, this.s0); }
        }

        public uint3 xyy
        {
            get { return new uint3(this.s0, this.s1, this.s1); }
        }

        public uint3 xyz
        {
            get { return new uint3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 xyw
        {
            get { return new uint3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public uint3 xzx
        {
            get { return new uint3(this.s0, this.s2, this.s0); }
        }

        public uint3 xzy
        {
            get { return new uint3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 xzz
        {
            get { return new uint3(this.s0, this.s2, this.s2); }
        }

        public uint3 xzw
        {
            get { return new uint3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public uint3 xwx
        {
            get { return new uint3(this.s0, this.s3, this.s0); }
        }

        public uint3 xwy
        {
            get { return new uint3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 xwz
        {
            get { return new uint3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 xww
        {
            get { return new uint3(this.s0, this.s3, this.s3); }
        }

        public uint3 yxx
        {
            get { return new uint3(this.s1, this.s0, this.s0); }
        }

        public uint3 yxy
        {
            get { return new uint3(this.s1, this.s0, this.s1); }
        }

        public uint3 yxz
        {
            get { return new uint3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 yxw
        {
            get { return new uint3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public uint3 yyx
        {
            get { return new uint3(this.s1, this.s1, this.s0); }
        }

        public uint3 yyy
        {
            get { return new uint3(this.s1, this.s1, this.s1); }
        }

        public uint3 yyz
        {
            get { return new uint3(this.s1, this.s1, this.s2); }
        }

        public uint3 yyw
        {
            get { return new uint3(this.s1, this.s1, this.s3); }
        }

        public uint3 yzx
        {
            get { return new uint3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 yzy
        {
            get { return new uint3(this.s1, this.s2, this.s1); }
        }

        public uint3 yzz
        {
            get { return new uint3(this.s1, this.s2, this.s2); }
        }

        public uint3 yzw
        {
            get { return new uint3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public uint3 ywx
        {
            get { return new uint3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 ywy
        {
            get { return new uint3(this.s1, this.s3, this.s1); }
        }

        public uint3 ywz
        {
            get { return new uint3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 yww
        {
            get { return new uint3(this.s1, this.s3, this.s3); }
        }

        public uint3 zxx
        {
            get { return new uint3(this.s2, this.s0, this.s0); }
        }

        public uint3 zxy
        {
            get { return new uint3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 zxz
        {
            get { return new uint3(this.s2, this.s0, this.s2); }
        }

        public uint3 zxw
        {
            get { return new uint3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public uint3 zyx
        {
            get { return new uint3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 zyy
        {
            get { return new uint3(this.s2, this.s1, this.s1); }
        }

        public uint3 zyz
        {
            get { return new uint3(this.s2, this.s1, this.s2); }
        }

        public uint3 zyw
        {
            get { return new uint3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public uint3 zzx
        {
            get { return new uint3(this.s2, this.s2, this.s0); }
        }

        public uint3 zzy
        {
            get { return new uint3(this.s2, this.s2, this.s1); }
        }

        public uint3 zzz
        {
            get { return new uint3(this.s2, this.s2, this.s2); }
        }

        public uint3 zzw
        {
            get { return new uint3(this.s2, this.s2, this.s3); }
        }

        public uint3 zwx
        {
            get { return new uint3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 zwy
        {
            get { return new uint3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 zwz
        {
            get { return new uint3(this.s2, this.s3, this.s2); }
        }

        public uint3 zww
        {
            get { return new uint3(this.s2, this.s3, this.s3); }
        }

        public uint3 wxx
        {
            get { return new uint3(this.s3, this.s0, this.s0); }
        }

        public uint3 wxy
        {
            get { return new uint3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 wxz
        {
            get { return new uint3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 wxw
        {
            get { return new uint3(this.s3, this.s0, this.s3); }
        }

        public uint3 wyx
        {
            get { return new uint3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 wyy
        {
            get { return new uint3(this.s3, this.s1, this.s1); }
        }

        public uint3 wyz
        {
            get { return new uint3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public uint3 wyw
        {
            get { return new uint3(this.s3, this.s1, this.s3); }
        }

        public uint3 wzx
        {
            get { return new uint3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public uint3 wzy
        {
            get { return new uint3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public uint3 wzz
        {
            get { return new uint3(this.s3, this.s2, this.s2); }
        }

        public uint3 wzw
        {
            get { return new uint3(this.s3, this.s2, this.s3); }
        }

        public uint3 wwx
        {
            get { return new uint3(this.s3, this.s3, this.s0); }
        }

        public uint3 wwy
        {
            get { return new uint3(this.s3, this.s3, this.s1); }
        }

        public uint3 wwz
        {
            get { return new uint3(this.s3, this.s3, this.s2); }
        }

        public uint3 www
        {
            get { return new uint3(this.s3, this.s3, this.s3); }
        }

        public uint4 xxxx
        {
            get { return new uint4(this.s0, this.s0, this.s0, this.s0); }
        }

        public uint4 xxxy
        {
            get { return new uint4(this.s0, this.s0, this.s0, this.s1); }
        }

        public uint4 xxxz
        {
            get { return new uint4(this.s0, this.s0, this.s0, this.s2); }
        }

        public uint4 xxxw
        {
            get { return new uint4(this.s0, this.s0, this.s0, this.s3); }
        }

        public uint4 xxyx
        {
            get { return new uint4(this.s0, this.s0, this.s1, this.s0); }
        }

        public uint4 xxyy
        {
            get { return new uint4(this.s0, this.s0, this.s1, this.s1); }
        }

        public uint4 xxyz
        {
            get { return new uint4(this.s0, this.s0, this.s1, this.s2); }
        }

        public uint4 xxyw
        {
            get { return new uint4(this.s0, this.s0, this.s1, this.s3); }
        }

        public uint4 xxzx
        {
            get { return new uint4(this.s0, this.s0, this.s2, this.s0); }
        }

        public uint4 xxzy
        {
            get { return new uint4(this.s0, this.s0, this.s2, this.s1); }
        }

        public uint4 xxzz
        {
            get { return new uint4(this.s0, this.s0, this.s2, this.s2); }
        }

        public uint4 xxzw
        {
            get { return new uint4(this.s0, this.s0, this.s2, this.s3); }
        }

        public uint4 xxwx
        {
            get { return new uint4(this.s0, this.s0, this.s3, this.s0); }
        }

        public uint4 xxwy
        {
            get { return new uint4(this.s0, this.s0, this.s3, this.s1); }
        }

        public uint4 xxwz
        {
            get { return new uint4(this.s0, this.s0, this.s3, this.s2); }
        }

        public uint4 xxww
        {
            get { return new uint4(this.s0, this.s0, this.s3, this.s3); }
        }

        public uint4 xyxx
        {
            get { return new uint4(this.s0, this.s1, this.s0, this.s0); }
        }

        public uint4 xyxy
        {
            get { return new uint4(this.s0, this.s1, this.s0, this.s1); }
        }

        public uint4 xyxz
        {
            get { return new uint4(this.s0, this.s1, this.s0, this.s2); }
        }

        public uint4 xyxw
        {
            get { return new uint4(this.s0, this.s1, this.s0, this.s3); }
        }

        public uint4 xyyx
        {
            get { return new uint4(this.s0, this.s1, this.s1, this.s0); }
        }

        public uint4 xyyy
        {
            get { return new uint4(this.s0, this.s1, this.s1, this.s1); }
        }

        public uint4 xyyz
        {
            get { return new uint4(this.s0, this.s1, this.s1, this.s2); }
        }

        public uint4 xyyw
        {
            get { return new uint4(this.s0, this.s1, this.s1, this.s3); }
        }

        public uint4 xyzx
        {
            get { return new uint4(this.s0, this.s1, this.s2, this.s0); }
        }

        public uint4 xyzy
        {
            get { return new uint4(this.s0, this.s1, this.s2, this.s1); }
        }

        public uint4 xyzz
        {
            get { return new uint4(this.s0, this.s1, this.s2, this.s2); }
        }

        public uint4 xyzw
        {
            get { return new uint4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public uint4 xywx
        {
            get { return new uint4(this.s0, this.s1, this.s3, this.s0); }
        }

        public uint4 xywy
        {
            get { return new uint4(this.s0, this.s1, this.s3, this.s1); }
        }

        public uint4 xywz
        {
            get { return new uint4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public uint4 xyww
        {
            get { return new uint4(this.s0, this.s1, this.s3, this.s3); }
        }

        public uint4 xzxx
        {
            get { return new uint4(this.s0, this.s2, this.s0, this.s0); }
        }

        public uint4 xzxy
        {
            get { return new uint4(this.s0, this.s2, this.s0, this.s1); }
        }

        public uint4 xzxz
        {
            get { return new uint4(this.s0, this.s2, this.s0, this.s2); }
        }

        public uint4 xzxw
        {
            get { return new uint4(this.s0, this.s2, this.s0, this.s3); }
        }

        public uint4 xzyx
        {
            get { return new uint4(this.s0, this.s2, this.s1, this.s0); }
        }

        public uint4 xzyy
        {
            get { return new uint4(this.s0, this.s2, this.s1, this.s1); }
        }

        public uint4 xzyz
        {
            get { return new uint4(this.s0, this.s2, this.s1, this.s2); }
        }

        public uint4 xzyw
        {
            get { return new uint4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public uint4 xzzx
        {
            get { return new uint4(this.s0, this.s2, this.s2, this.s0); }
        }

        public uint4 xzzy
        {
            get { return new uint4(this.s0, this.s2, this.s2, this.s1); }
        }

        public uint4 xzzz
        {
            get { return new uint4(this.s0, this.s2, this.s2, this.s2); }
        }

        public uint4 xzzw
        {
            get { return new uint4(this.s0, this.s2, this.s2, this.s3); }
        }

        public uint4 xzwx
        {
            get { return new uint4(this.s0, this.s2, this.s3, this.s0); }
        }

        public uint4 xzwy
        {
            get { return new uint4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public uint4 xzwz
        {
            get { return new uint4(this.s0, this.s2, this.s3, this.s2); }
        }

        public uint4 xzww
        {
            get { return new uint4(this.s0, this.s2, this.s3, this.s3); }
        }

        public uint4 xwxx
        {
            get { return new uint4(this.s0, this.s3, this.s0, this.s0); }
        }

        public uint4 xwxy
        {
            get { return new uint4(this.s0, this.s3, this.s0, this.s1); }
        }

        public uint4 xwxz
        {
            get { return new uint4(this.s0, this.s3, this.s0, this.s2); }
        }

        public uint4 xwxw
        {
            get { return new uint4(this.s0, this.s3, this.s0, this.s3); }
        }

        public uint4 xwyx
        {
            get { return new uint4(this.s0, this.s3, this.s1, this.s0); }
        }

        public uint4 xwyy
        {
            get { return new uint4(this.s0, this.s3, this.s1, this.s1); }
        }

        public uint4 xwyz
        {
            get { return new uint4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public uint4 xwyw
        {
            get { return new uint4(this.s0, this.s3, this.s1, this.s3); }
        }

        public uint4 xwzx
        {
            get { return new uint4(this.s0, this.s3, this.s2, this.s0); }
        }

        public uint4 xwzy
        {
            get { return new uint4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public uint4 xwzz
        {
            get { return new uint4(this.s0, this.s3, this.s2, this.s2); }
        }

        public uint4 xwzw
        {
            get { return new uint4(this.s0, this.s3, this.s2, this.s3); }
        }

        public uint4 xwwx
        {
            get { return new uint4(this.s0, this.s3, this.s3, this.s0); }
        }

        public uint4 xwwy
        {
            get { return new uint4(this.s0, this.s3, this.s3, this.s1); }
        }

        public uint4 xwwz
        {
            get { return new uint4(this.s0, this.s3, this.s3, this.s2); }
        }

        public uint4 xwww
        {
            get { return new uint4(this.s0, this.s3, this.s3, this.s3); }
        }

        public uint4 yxxx
        {
            get { return new uint4(this.s1, this.s0, this.s0, this.s0); }
        }

        public uint4 yxxy
        {
            get { return new uint4(this.s1, this.s0, this.s0, this.s1); }
        }

        public uint4 yxxz
        {
            get { return new uint4(this.s1, this.s0, this.s0, this.s2); }
        }

        public uint4 yxxw
        {
            get { return new uint4(this.s1, this.s0, this.s0, this.s3); }
        }

        public uint4 yxyx
        {
            get { return new uint4(this.s1, this.s0, this.s1, this.s0); }
        }

        public uint4 yxyy
        {
            get { return new uint4(this.s1, this.s0, this.s1, this.s1); }
        }

        public uint4 yxyz
        {
            get { return new uint4(this.s1, this.s0, this.s1, this.s2); }
        }

        public uint4 yxyw
        {
            get { return new uint4(this.s1, this.s0, this.s1, this.s3); }
        }

        public uint4 yxzx
        {
            get { return new uint4(this.s1, this.s0, this.s2, this.s0); }
        }

        public uint4 yxzy
        {
            get { return new uint4(this.s1, this.s0, this.s2, this.s1); }
        }

        public uint4 yxzz
        {
            get { return new uint4(this.s1, this.s0, this.s2, this.s2); }
        }

        public uint4 yxzw
        {
            get { return new uint4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public uint4 yxwx
        {
            get { return new uint4(this.s1, this.s0, this.s3, this.s0); }
        }

        public uint4 yxwy
        {
            get { return new uint4(this.s1, this.s0, this.s3, this.s1); }
        }

        public uint4 yxwz
        {
            get { return new uint4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public uint4 yxww
        {
            get { return new uint4(this.s1, this.s0, this.s3, this.s3); }
        }

        public uint4 yyxx
        {
            get { return new uint4(this.s1, this.s1, this.s0, this.s0); }
        }

        public uint4 yyxy
        {
            get { return new uint4(this.s1, this.s1, this.s0, this.s1); }
        }

        public uint4 yyxz
        {
            get { return new uint4(this.s1, this.s1, this.s0, this.s2); }
        }

        public uint4 yyxw
        {
            get { return new uint4(this.s1, this.s1, this.s0, this.s3); }
        }

        public uint4 yyyx
        {
            get { return new uint4(this.s1, this.s1, this.s1, this.s0); }
        }

        public uint4 yyyy
        {
            get { return new uint4(this.s1, this.s1, this.s1, this.s1); }
        }

        public uint4 yyyz
        {
            get { return new uint4(this.s1, this.s1, this.s1, this.s2); }
        }

        public uint4 yyyw
        {
            get { return new uint4(this.s1, this.s1, this.s1, this.s3); }
        }

        public uint4 yyzx
        {
            get { return new uint4(this.s1, this.s1, this.s2, this.s0); }
        }

        public uint4 yyzy
        {
            get { return new uint4(this.s1, this.s1, this.s2, this.s1); }
        }

        public uint4 yyzz
        {
            get { return new uint4(this.s1, this.s1, this.s2, this.s2); }
        }

        public uint4 yyzw
        {
            get { return new uint4(this.s1, this.s1, this.s2, this.s3); }
        }

        public uint4 yywx
        {
            get { return new uint4(this.s1, this.s1, this.s3, this.s0); }
        }

        public uint4 yywy
        {
            get { return new uint4(this.s1, this.s1, this.s3, this.s1); }
        }

        public uint4 yywz
        {
            get { return new uint4(this.s1, this.s1, this.s3, this.s2); }
        }

        public uint4 yyww
        {
            get { return new uint4(this.s1, this.s1, this.s3, this.s3); }
        }

        public uint4 yzxx
        {
            get { return new uint4(this.s1, this.s2, this.s0, this.s0); }
        }

        public uint4 yzxy
        {
            get { return new uint4(this.s1, this.s2, this.s0, this.s1); }
        }

        public uint4 yzxz
        {
            get { return new uint4(this.s1, this.s2, this.s0, this.s2); }
        }

        public uint4 yzxw
        {
            get { return new uint4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public uint4 yzyx
        {
            get { return new uint4(this.s1, this.s2, this.s1, this.s0); }
        }

        public uint4 yzyy
        {
            get { return new uint4(this.s1, this.s2, this.s1, this.s1); }
        }

        public uint4 yzyz
        {
            get { return new uint4(this.s1, this.s2, this.s1, this.s2); }
        }

        public uint4 yzyw
        {
            get { return new uint4(this.s1, this.s2, this.s1, this.s3); }
        }

        public uint4 yzzx
        {
            get { return new uint4(this.s1, this.s2, this.s2, this.s0); }
        }

        public uint4 yzzy
        {
            get { return new uint4(this.s1, this.s2, this.s2, this.s1); }
        }

        public uint4 yzzz
        {
            get { return new uint4(this.s1, this.s2, this.s2, this.s2); }
        }

        public uint4 yzzw
        {
            get { return new uint4(this.s1, this.s2, this.s2, this.s3); }
        }

        public uint4 yzwx
        {
            get { return new uint4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public uint4 yzwy
        {
            get { return new uint4(this.s1, this.s2, this.s3, this.s1); }
        }

        public uint4 yzwz
        {
            get { return new uint4(this.s1, this.s2, this.s3, this.s2); }
        }

        public uint4 yzww
        {
            get { return new uint4(this.s1, this.s2, this.s3, this.s3); }
        }

        public uint4 ywxx
        {
            get { return new uint4(this.s1, this.s3, this.s0, this.s0); }
        }

        public uint4 ywxy
        {
            get { return new uint4(this.s1, this.s3, this.s0, this.s1); }
        }

        public uint4 ywxz
        {
            get { return new uint4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public uint4 ywxw
        {
            get { return new uint4(this.s1, this.s3, this.s0, this.s3); }
        }

        public uint4 ywyx
        {
            get { return new uint4(this.s1, this.s3, this.s1, this.s0); }
        }

        public uint4 ywyy
        {
            get { return new uint4(this.s1, this.s3, this.s1, this.s1); }
        }

        public uint4 ywyz
        {
            get { return new uint4(this.s1, this.s3, this.s1, this.s2); }
        }

        public uint4 ywyw
        {
            get { return new uint4(this.s1, this.s3, this.s1, this.s3); }
        }

        public uint4 ywzx
        {
            get { return new uint4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public uint4 ywzy
        {
            get { return new uint4(this.s1, this.s3, this.s2, this.s1); }
        }

        public uint4 ywzz
        {
            get { return new uint4(this.s1, this.s3, this.s2, this.s2); }
        }

        public uint4 ywzw
        {
            get { return new uint4(this.s1, this.s3, this.s2, this.s3); }
        }

        public uint4 ywwx
        {
            get { return new uint4(this.s1, this.s3, this.s3, this.s0); }
        }

        public uint4 ywwy
        {
            get { return new uint4(this.s1, this.s3, this.s3, this.s1); }
        }

        public uint4 ywwz
        {
            get { return new uint4(this.s1, this.s3, this.s3, this.s2); }
        }

        public uint4 ywww
        {
            get { return new uint4(this.s1, this.s3, this.s3, this.s3); }
        }

        public uint4 zxxx
        {
            get { return new uint4(this.s2, this.s0, this.s0, this.s0); }
        }

        public uint4 zxxy
        {
            get { return new uint4(this.s2, this.s0, this.s0, this.s1); }
        }

        public uint4 zxxz
        {
            get { return new uint4(this.s2, this.s0, this.s0, this.s2); }
        }

        public uint4 zxxw
        {
            get { return new uint4(this.s2, this.s0, this.s0, this.s3); }
        }

        public uint4 zxyx
        {
            get { return new uint4(this.s2, this.s0, this.s1, this.s0); }
        }

        public uint4 zxyy
        {
            get { return new uint4(this.s2, this.s0, this.s1, this.s1); }
        }

        public uint4 zxyz
        {
            get { return new uint4(this.s2, this.s0, this.s1, this.s2); }
        }

        public uint4 zxyw
        {
            get { return new uint4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public uint4 zxzx
        {
            get { return new uint4(this.s2, this.s0, this.s2, this.s0); }
        }

        public uint4 zxzy
        {
            get { return new uint4(this.s2, this.s0, this.s2, this.s1); }
        }

        public uint4 zxzz
        {
            get { return new uint4(this.s2, this.s0, this.s2, this.s2); }
        }

        public uint4 zxzw
        {
            get { return new uint4(this.s2, this.s0, this.s2, this.s3); }
        }

        public uint4 zxwx
        {
            get { return new uint4(this.s2, this.s0, this.s3, this.s0); }
        }

        public uint4 zxwy
        {
            get { return new uint4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public uint4 zxwz
        {
            get { return new uint4(this.s2, this.s0, this.s3, this.s2); }
        }

        public uint4 zxww
        {
            get { return new uint4(this.s2, this.s0, this.s3, this.s3); }
        }

        public uint4 zyxx
        {
            get { return new uint4(this.s2, this.s1, this.s0, this.s0); }
        }

        public uint4 zyxy
        {
            get { return new uint4(this.s2, this.s1, this.s0, this.s1); }
        }

        public uint4 zyxz
        {
            get { return new uint4(this.s2, this.s1, this.s0, this.s2); }
        }

        public uint4 zyxw
        {
            get { return new uint4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public uint4 zyyx
        {
            get { return new uint4(this.s2, this.s1, this.s1, this.s0); }
        }

        public uint4 zyyy
        {
            get { return new uint4(this.s2, this.s1, this.s1, this.s1); }
        }

        public uint4 zyyz
        {
            get { return new uint4(this.s2, this.s1, this.s1, this.s2); }
        }

        public uint4 zyyw
        {
            get { return new uint4(this.s2, this.s1, this.s1, this.s3); }
        }

        public uint4 zyzx
        {
            get { return new uint4(this.s2, this.s1, this.s2, this.s0); }
        }

        public uint4 zyzy
        {
            get { return new uint4(this.s2, this.s1, this.s2, this.s1); }
        }

        public uint4 zyzz
        {
            get { return new uint4(this.s2, this.s1, this.s2, this.s2); }
        }

        public uint4 zyzw
        {
            get { return new uint4(this.s2, this.s1, this.s2, this.s3); }
        }

        public uint4 zywx
        {
            get { return new uint4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public uint4 zywy
        {
            get { return new uint4(this.s2, this.s1, this.s3, this.s1); }
        }

        public uint4 zywz
        {
            get { return new uint4(this.s2, this.s1, this.s3, this.s2); }
        }

        public uint4 zyww
        {
            get { return new uint4(this.s2, this.s1, this.s3, this.s3); }
        }

        public uint4 zzxx
        {
            get { return new uint4(this.s2, this.s2, this.s0, this.s0); }
        }

        public uint4 zzxy
        {
            get { return new uint4(this.s2, this.s2, this.s0, this.s1); }
        }

        public uint4 zzxz
        {
            get { return new uint4(this.s2, this.s2, this.s0, this.s2); }
        }

        public uint4 zzxw
        {
            get { return new uint4(this.s2, this.s2, this.s0, this.s3); }
        }

        public uint4 zzyx
        {
            get { return new uint4(this.s2, this.s2, this.s1, this.s0); }
        }

        public uint4 zzyy
        {
            get { return new uint4(this.s2, this.s2, this.s1, this.s1); }
        }

        public uint4 zzyz
        {
            get { return new uint4(this.s2, this.s2, this.s1, this.s2); }
        }

        public uint4 zzyw
        {
            get { return new uint4(this.s2, this.s2, this.s1, this.s3); }
        }

        public uint4 zzzx
        {
            get { return new uint4(this.s2, this.s2, this.s2, this.s0); }
        }

        public uint4 zzzy
        {
            get { return new uint4(this.s2, this.s2, this.s2, this.s1); }
        }

        public uint4 zzzz
        {
            get { return new uint4(this.s2, this.s2, this.s2, this.s2); }
        }

        public uint4 zzzw
        {
            get { return new uint4(this.s2, this.s2, this.s2, this.s3); }
        }

        public uint4 zzwx
        {
            get { return new uint4(this.s2, this.s2, this.s3, this.s0); }
        }

        public uint4 zzwy
        {
            get { return new uint4(this.s2, this.s2, this.s3, this.s1); }
        }

        public uint4 zzwz
        {
            get { return new uint4(this.s2, this.s2, this.s3, this.s2); }
        }

        public uint4 zzww
        {
            get { return new uint4(this.s2, this.s2, this.s3, this.s3); }
        }

        public uint4 zwxx
        {
            get { return new uint4(this.s2, this.s3, this.s0, this.s0); }
        }

        public uint4 zwxy
        {
            get { return new uint4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public uint4 zwxz
        {
            get { return new uint4(this.s2, this.s3, this.s0, this.s2); }
        }

        public uint4 zwxw
        {
            get { return new uint4(this.s2, this.s3, this.s0, this.s3); }
        }

        public uint4 zwyx
        {
            get { return new uint4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public uint4 zwyy
        {
            get { return new uint4(this.s2, this.s3, this.s1, this.s1); }
        }

        public uint4 zwyz
        {
            get { return new uint4(this.s2, this.s3, this.s1, this.s2); }
        }

        public uint4 zwyw
        {
            get { return new uint4(this.s2, this.s3, this.s1, this.s3); }
        }

        public uint4 zwzx
        {
            get { return new uint4(this.s2, this.s3, this.s2, this.s0); }
        }

        public uint4 zwzy
        {
            get { return new uint4(this.s2, this.s3, this.s2, this.s1); }
        }

        public uint4 zwzz
        {
            get { return new uint4(this.s2, this.s3, this.s2, this.s2); }
        }

        public uint4 zwzw
        {
            get { return new uint4(this.s2, this.s3, this.s2, this.s3); }
        }

        public uint4 zwwx
        {
            get { return new uint4(this.s2, this.s3, this.s3, this.s0); }
        }

        public uint4 zwwy
        {
            get { return new uint4(this.s2, this.s3, this.s3, this.s1); }
        }

        public uint4 zwwz
        {
            get { return new uint4(this.s2, this.s3, this.s3, this.s2); }
        }

        public uint4 zwww
        {
            get { return new uint4(this.s2, this.s3, this.s3, this.s3); }
        }

        public uint4 wxxx
        {
            get { return new uint4(this.s3, this.s0, this.s0, this.s0); }
        }

        public uint4 wxxy
        {
            get { return new uint4(this.s3, this.s0, this.s0, this.s1); }
        }

        public uint4 wxxz
        {
            get { return new uint4(this.s3, this.s0, this.s0, this.s2); }
        }

        public uint4 wxxw
        {
            get { return new uint4(this.s3, this.s0, this.s0, this.s3); }
        }

        public uint4 wxyx
        {
            get { return new uint4(this.s3, this.s0, this.s1, this.s0); }
        }

        public uint4 wxyy
        {
            get { return new uint4(this.s3, this.s0, this.s1, this.s1); }
        }

        public uint4 wxyz
        {
            get { return new uint4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public uint4 wxyw
        {
            get { return new uint4(this.s3, this.s0, this.s1, this.s3); }
        }

        public uint4 wxzx
        {
            get { return new uint4(this.s3, this.s0, this.s2, this.s0); }
        }

        public uint4 wxzy
        {
            get { return new uint4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public uint4 wxzz
        {
            get { return new uint4(this.s3, this.s0, this.s2, this.s2); }
        }

        public uint4 wxzw
        {
            get { return new uint4(this.s3, this.s0, this.s2, this.s3); }
        }

        public uint4 wxwx
        {
            get { return new uint4(this.s3, this.s0, this.s3, this.s0); }
        }

        public uint4 wxwy
        {
            get { return new uint4(this.s3, this.s0, this.s3, this.s1); }
        }

        public uint4 wxwz
        {
            get { return new uint4(this.s3, this.s0, this.s3, this.s2); }
        }

        public uint4 wxww
        {
            get { return new uint4(this.s3, this.s0, this.s3, this.s3); }
        }

        public uint4 wyxx
        {
            get { return new uint4(this.s3, this.s1, this.s0, this.s0); }
        }

        public uint4 wyxy
        {
            get { return new uint4(this.s3, this.s1, this.s0, this.s1); }
        }

        public uint4 wyxz
        {
            get { return new uint4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public uint4 wyxw
        {
            get { return new uint4(this.s3, this.s1, this.s0, this.s3); }
        }

        public uint4 wyyx
        {
            get { return new uint4(this.s3, this.s1, this.s1, this.s0); }
        }

        public uint4 wyyy
        {
            get { return new uint4(this.s3, this.s1, this.s1, this.s1); }
        }

        public uint4 wyyz
        {
            get { return new uint4(this.s3, this.s1, this.s1, this.s2); }
        }

        public uint4 wyyw
        {
            get { return new uint4(this.s3, this.s1, this.s1, this.s3); }
        }

        public uint4 wyzx
        {
            get { return new uint4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public uint4 wyzy
        {
            get { return new uint4(this.s3, this.s1, this.s2, this.s1); }
        }

        public uint4 wyzz
        {
            get { return new uint4(this.s3, this.s1, this.s2, this.s2); }
        }

        public uint4 wyzw
        {
            get { return new uint4(this.s3, this.s1, this.s2, this.s3); }
        }

        public uint4 wywx
        {
            get { return new uint4(this.s3, this.s1, this.s3, this.s0); }
        }

        public uint4 wywy
        {
            get { return new uint4(this.s3, this.s1, this.s3, this.s1); }
        }

        public uint4 wywz
        {
            get { return new uint4(this.s3, this.s1, this.s3, this.s2); }
        }

        public uint4 wyww
        {
            get { return new uint4(this.s3, this.s1, this.s3, this.s3); }
        }

        public uint4 wzxx
        {
            get { return new uint4(this.s3, this.s2, this.s0, this.s0); }
        }

        public uint4 wzxy
        {
            get { return new uint4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public uint4 wzxz
        {
            get { return new uint4(this.s3, this.s2, this.s0, this.s2); }
        }

        public uint4 wzxw
        {
            get { return new uint4(this.s3, this.s2, this.s0, this.s3); }
        }

        public uint4 wzyx
        {
            get { return new uint4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public uint4 wzyy
        {
            get { return new uint4(this.s3, this.s2, this.s1, this.s1); }
        }

        public uint4 wzyz
        {
            get { return new uint4(this.s3, this.s2, this.s1, this.s2); }
        }

        public uint4 wzyw
        {
            get { return new uint4(this.s3, this.s2, this.s1, this.s3); }
        }

        public uint4 wzzx
        {
            get { return new uint4(this.s3, this.s2, this.s2, this.s0); }
        }

        public uint4 wzzy
        {
            get { return new uint4(this.s3, this.s2, this.s2, this.s1); }
        }

        public uint4 wzzz
        {
            get { return new uint4(this.s3, this.s2, this.s2, this.s2); }
        }

        public uint4 wzzw
        {
            get { return new uint4(this.s3, this.s2, this.s2, this.s3); }
        }

        public uint4 wzwx
        {
            get { return new uint4(this.s3, this.s2, this.s3, this.s0); }
        }

        public uint4 wzwy
        {
            get { return new uint4(this.s3, this.s2, this.s3, this.s1); }
        }

        public uint4 wzwz
        {
            get { return new uint4(this.s3, this.s2, this.s3, this.s2); }
        }

        public uint4 wzww
        {
            get { return new uint4(this.s3, this.s2, this.s3, this.s3); }
        }

        public uint4 wwxx
        {
            get { return new uint4(this.s3, this.s3, this.s0, this.s0); }
        }

        public uint4 wwxy
        {
            get { return new uint4(this.s3, this.s3, this.s0, this.s1); }
        }

        public uint4 wwxz
        {
            get { return new uint4(this.s3, this.s3, this.s0, this.s2); }
        }

        public uint4 wwxw
        {
            get { return new uint4(this.s3, this.s3, this.s0, this.s3); }
        }

        public uint4 wwyx
        {
            get { return new uint4(this.s3, this.s3, this.s1, this.s0); }
        }

        public uint4 wwyy
        {
            get { return new uint4(this.s3, this.s3, this.s1, this.s1); }
        }

        public uint4 wwyz
        {
            get { return new uint4(this.s3, this.s3, this.s1, this.s2); }
        }

        public uint4 wwyw
        {
            get { return new uint4(this.s3, this.s3, this.s1, this.s3); }
        }

        public uint4 wwzx
        {
            get { return new uint4(this.s3, this.s3, this.s2, this.s0); }
        }

        public uint4 wwzy
        {
            get { return new uint4(this.s3, this.s3, this.s2, this.s1); }
        }

        public uint4 wwzz
        {
            get { return new uint4(this.s3, this.s3, this.s2, this.s2); }
        }

        public uint4 wwzw
        {
            get { return new uint4(this.s3, this.s3, this.s2, this.s3); }
        }

        public uint4 wwwx
        {
            get { return new uint4(this.s3, this.s3, this.s3, this.s0); }
        }

        public uint4 wwwy
        {
            get { return new uint4(this.s3, this.s3, this.s3, this.s1); }
        }

        public uint4 wwwz
        {
            get { return new uint4(this.s3, this.s3, this.s3, this.s2); }
        }

        public uint4 wwww
        {
            get { return new uint4(this.s3, this.s3, this.s3, this.s3); }
        }

        public uint this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(uint4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is uint4 && Equals((uint4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static uint4 operator +(uint4 a, uint4 b) => new uint4((uint)(a.s0+b.s0), (uint)(a.s1+b.s1), (uint)(a.s2+b.s2), (uint)(a.s3+b.s3));

        public static uint4 operator -(uint4 a, uint4 b) => new uint4((uint)(a.s0-b.s0), (uint)(a.s1-b.s1), (uint)(a.s2-b.s2), (uint)(a.s3-b.s3));

        public static uint4 operator *(uint4 a, uint4 b) => new uint4((uint)(a.s0*b.s0), (uint)(a.s1*b.s1), (uint)(a.s2*b.s2), (uint)(a.s3*b.s3));

        public static uint4 operator /(uint4 a, uint4 b) => new uint4((uint)(a.s0/b.s0), (uint)(a.s1/b.s1), (uint)(a.s2/b.s2), (uint)(a.s3/b.s3));

        public static int4 operator ==(uint4 a, uint4 b) => new int4(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0);

        public static int4 operator !=(uint4 a, uint4 b) => new int4(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0);

        public static int4 operator <(uint4 a, uint4 b) => new int4(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0);

        public static int4 operator <=(uint4 a, uint4 b) => new int4(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0);

        public static int4 operator >(uint4 a, uint4 b) => new int4(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0);

        public static int4 operator >=(uint4 a, uint4 b) => new int4(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0);

        public static uint4 operator &(uint4 a, uint4 b) => new uint4((uint)(a.s0&b.s0), (uint)(a.s1&b.s1), (uint)(a.s2&b.s2), (uint)(a.s3&b.s3));

        public static uint4 operator |(uint4 a, uint4 b) => new uint4((uint)(a.s0|b.s0), (uint)(a.s1|b.s1), (uint)(a.s2|b.s2), (uint)(a.s3|b.s3));

        public static uint4 operator ^(uint4 a, uint4 b) => new uint4((uint)(a.s0^b.s0), (uint)(a.s1^b.s1), (uint)(a.s2^b.s2), (uint)(a.s3^b.s3));

        public static uint4 operator +(uint4 a) => a;

        public static uint4 operator ~(uint4 a) => new uint4((uint)(~a.s0), (uint)(~a.s1), (uint)(~a.s2), (uint)(~a.s3));

        public static uint4 operator ++(uint4 a) => new uint4((uint)(a.s0+1), (uint)(a.s1+1), (uint)(a.s2+1), (uint)(a.s3+1));

        public static uint4 operator --(uint4 a) => new uint4((uint)(a.s0-1), (uint)(a.s1-1), (uint)(a.s2-1), (uint)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct uint8: IVectorType, IEquatable<uint8>
    {
        [FieldOffset(0)]
        public uint s0;
        [FieldOffset(4)]
        public uint s1;
        [FieldOffset(8)]
        public uint s2;
        [FieldOffset(12)]
        public uint s3;
        [FieldOffset(16)]
        public uint s4;
        [FieldOffset(20)]
        public uint s5;
        [FieldOffset(24)]
        public uint s6;
        [FieldOffset(28)]
        public uint s7;

        public uint8(uint v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public uint8(uint v0, uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public uint this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(uint8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is uint8 && Equals((uint8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static uint8 operator +(uint8 a, uint8 b) => new uint8((uint)(a.s0+b.s0), (uint)(a.s1+b.s1), (uint)(a.s2+b.s2), (uint)(a.s3+b.s3), (uint)(a.s4+b.s4), (uint)(a.s5+b.s5), (uint)(a.s6+b.s6), (uint)(a.s7+b.s7));

        public static uint8 operator -(uint8 a, uint8 b) => new uint8((uint)(a.s0-b.s0), (uint)(a.s1-b.s1), (uint)(a.s2-b.s2), (uint)(a.s3-b.s3), (uint)(a.s4-b.s4), (uint)(a.s5-b.s5), (uint)(a.s6-b.s6), (uint)(a.s7-b.s7));

        public static uint8 operator *(uint8 a, uint8 b) => new uint8((uint)(a.s0*b.s0), (uint)(a.s1*b.s1), (uint)(a.s2*b.s2), (uint)(a.s3*b.s3), (uint)(a.s4*b.s4), (uint)(a.s5*b.s5), (uint)(a.s6*b.s6), (uint)(a.s7*b.s7));

        public static uint8 operator /(uint8 a, uint8 b) => new uint8((uint)(a.s0/b.s0), (uint)(a.s1/b.s1), (uint)(a.s2/b.s2), (uint)(a.s3/b.s3), (uint)(a.s4/b.s4), (uint)(a.s5/b.s5), (uint)(a.s6/b.s6), (uint)(a.s7/b.s7));

        public static int8 operator ==(uint8 a, uint8 b) => new int8(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0, a.s4==b.s4 ? -1 : 0, a.s5==b.s5 ? -1 : 0, a.s6==b.s6 ? -1 : 0, a.s7==b.s7 ? -1 : 0);

        public static int8 operator !=(uint8 a, uint8 b) => new int8(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0, a.s4!=b.s4 ? -1 : 0, a.s5!=b.s5 ? -1 : 0, a.s6!=b.s6 ? -1 : 0, a.s7!=b.s7 ? -1 : 0);

        public static int8 operator <(uint8 a, uint8 b) => new int8(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0, a.s4<b.s4 ? -1 : 0, a.s5<b.s5 ? -1 : 0, a.s6<b.s6 ? -1 : 0, a.s7<b.s7 ? -1 : 0);

        public static int8 operator <=(uint8 a, uint8 b) => new int8(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0, a.s4<=b.s4 ? -1 : 0, a.s5<=b.s5 ? -1 : 0, a.s6<=b.s6 ? -1 : 0, a.s7<=b.s7 ? -1 : 0);

        public static int8 operator >(uint8 a, uint8 b) => new int8(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0, a.s4>b.s4 ? -1 : 0, a.s5>b.s5 ? -1 : 0, a.s6>b.s6 ? -1 : 0, a.s7>b.s7 ? -1 : 0);

        public static int8 operator >=(uint8 a, uint8 b) => new int8(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0, a.s4>=b.s4 ? -1 : 0, a.s5>=b.s5 ? -1 : 0, a.s6>=b.s6 ? -1 : 0, a.s7>=b.s7 ? -1 : 0);

        public static uint8 operator &(uint8 a, uint8 b) => new uint8((uint)(a.s0&b.s0), (uint)(a.s1&b.s1), (uint)(a.s2&b.s2), (uint)(a.s3&b.s3), (uint)(a.s4&b.s4), (uint)(a.s5&b.s5), (uint)(a.s6&b.s6), (uint)(a.s7&b.s7));

        public static uint8 operator |(uint8 a, uint8 b) => new uint8((uint)(a.s0|b.s0), (uint)(a.s1|b.s1), (uint)(a.s2|b.s2), (uint)(a.s3|b.s3), (uint)(a.s4|b.s4), (uint)(a.s5|b.s5), (uint)(a.s6|b.s6), (uint)(a.s7|b.s7));

        public static uint8 operator ^(uint8 a, uint8 b) => new uint8((uint)(a.s0^b.s0), (uint)(a.s1^b.s1), (uint)(a.s2^b.s2), (uint)(a.s3^b.s3), (uint)(a.s4^b.s4), (uint)(a.s5^b.s5), (uint)(a.s6^b.s6), (uint)(a.s7^b.s7));

        public static uint8 operator +(uint8 a) => a;

        public static uint8 operator ~(uint8 a) => new uint8((uint)(~a.s0), (uint)(~a.s1), (uint)(~a.s2), (uint)(~a.s3), (uint)(~a.s4), (uint)(~a.s5), (uint)(~a.s6), (uint)(~a.s7));

        public static uint8 operator ++(uint8 a) => new uint8((uint)(a.s0+1), (uint)(a.s1+1), (uint)(a.s2+1), (uint)(a.s3+1), (uint)(a.s4+1), (uint)(a.s5+1), (uint)(a.s6+1), (uint)(a.s7+1));

        public static uint8 operator --(uint8 a) => new uint8((uint)(a.s0-1), (uint)(a.s1-1), (uint)(a.s2-1), (uint)(a.s3-1), (uint)(a.s4-1), (uint)(a.s5-1), (uint)(a.s6-1), (uint)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct uint16: IVectorType, IEquatable<uint16>
    {
        [FieldOffset(0)]
        public uint s0;
        [FieldOffset(4)]
        public uint s1;
        [FieldOffset(8)]
        public uint s2;
        [FieldOffset(12)]
        public uint s3;
        [FieldOffset(16)]
        public uint s4;
        [FieldOffset(20)]
        public uint s5;
        [FieldOffset(24)]
        public uint s6;
        [FieldOffset(28)]
        public uint s7;
        [FieldOffset(32)]
        public uint s8;
        [FieldOffset(36)]
        public uint s9;
        [FieldOffset(40)]
        public uint sa;
        [FieldOffset(44)]
        public uint sb;
        [FieldOffset(48)]
        public uint sc;
        [FieldOffset(52)]
        public uint sd;
        [FieldOffset(56)]
        public uint se;
        [FieldOffset(60)]
        public uint sf;

        public uint16(uint v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public uint16(uint v0, uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7, uint v8, uint v9, uint va, uint vb, uint vc, uint vd, uint ve, uint vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public uint sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public uint sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public uint sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public uint sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public uint sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public uint sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public uint this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 64; }
        }

        // IEquatable

        public bool Equals(uint16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is uint16 && Equals((uint16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static uint16 operator +(uint16 a, uint16 b) => new uint16((uint)(a.s0+b.s0), (uint)(a.s1+b.s1), (uint)(a.s2+b.s2), (uint)(a.s3+b.s3), (uint)(a.s4+b.s4), (uint)(a.s5+b.s5), (uint)(a.s6+b.s6), (uint)(a.s7+b.s7), (uint)(a.s8+b.s8), (uint)(a.s9+b.s9), (uint)(a.sa+b.sa), (uint)(a.sb+b.sb), (uint)(a.sc+b.sc), (uint)(a.sd+b.sd), (uint)(a.se+b.se), (uint)(a.sf+b.sf));

        public static uint16 operator -(uint16 a, uint16 b) => new uint16((uint)(a.s0-b.s0), (uint)(a.s1-b.s1), (uint)(a.s2-b.s2), (uint)(a.s3-b.s3), (uint)(a.s4-b.s4), (uint)(a.s5-b.s5), (uint)(a.s6-b.s6), (uint)(a.s7-b.s7), (uint)(a.s8-b.s8), (uint)(a.s9-b.s9), (uint)(a.sa-b.sa), (uint)(a.sb-b.sb), (uint)(a.sc-b.sc), (uint)(a.sd-b.sd), (uint)(a.se-b.se), (uint)(a.sf-b.sf));

        public static uint16 operator *(uint16 a, uint16 b) => new uint16((uint)(a.s0*b.s0), (uint)(a.s1*b.s1), (uint)(a.s2*b.s2), (uint)(a.s3*b.s3), (uint)(a.s4*b.s4), (uint)(a.s5*b.s5), (uint)(a.s6*b.s6), (uint)(a.s7*b.s7), (uint)(a.s8*b.s8), (uint)(a.s9*b.s9), (uint)(a.sa*b.sa), (uint)(a.sb*b.sb), (uint)(a.sc*b.sc), (uint)(a.sd*b.sd), (uint)(a.se*b.se), (uint)(a.sf*b.sf));

        public static uint16 operator /(uint16 a, uint16 b) => new uint16((uint)(a.s0/b.s0), (uint)(a.s1/b.s1), (uint)(a.s2/b.s2), (uint)(a.s3/b.s3), (uint)(a.s4/b.s4), (uint)(a.s5/b.s5), (uint)(a.s6/b.s6), (uint)(a.s7/b.s7), (uint)(a.s8/b.s8), (uint)(a.s9/b.s9), (uint)(a.sa/b.sa), (uint)(a.sb/b.sb), (uint)(a.sc/b.sc), (uint)(a.sd/b.sd), (uint)(a.se/b.se), (uint)(a.sf/b.sf));

        public static int16 operator ==(uint16 a, uint16 b) => new int16(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0, a.s4==b.s4 ? -1 : 0, a.s5==b.s5 ? -1 : 0, a.s6==b.s6 ? -1 : 0, a.s7==b.s7 ? -1 : 0, a.s8==b.s8 ? -1 : 0, a.s9==b.s9 ? -1 : 0, a.sa==b.sa ? -1 : 0, a.sb==b.sb ? -1 : 0, a.sc==b.sc ? -1 : 0, a.sd==b.sd ? -1 : 0, a.se==b.se ? -1 : 0, a.sf==b.sf ? -1 : 0);

        public static int16 operator !=(uint16 a, uint16 b) => new int16(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0, a.s4!=b.s4 ? -1 : 0, a.s5!=b.s5 ? -1 : 0, a.s6!=b.s6 ? -1 : 0, a.s7!=b.s7 ? -1 : 0, a.s8!=b.s8 ? -1 : 0, a.s9!=b.s9 ? -1 : 0, a.sa!=b.sa ? -1 : 0, a.sb!=b.sb ? -1 : 0, a.sc!=b.sc ? -1 : 0, a.sd!=b.sd ? -1 : 0, a.se!=b.se ? -1 : 0, a.sf!=b.sf ? -1 : 0);

        public static int16 operator <(uint16 a, uint16 b) => new int16(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0, a.s4<b.s4 ? -1 : 0, a.s5<b.s5 ? -1 : 0, a.s6<b.s6 ? -1 : 0, a.s7<b.s7 ? -1 : 0, a.s8<b.s8 ? -1 : 0, a.s9<b.s9 ? -1 : 0, a.sa<b.sa ? -1 : 0, a.sb<b.sb ? -1 : 0, a.sc<b.sc ? -1 : 0, a.sd<b.sd ? -1 : 0, a.se<b.se ? -1 : 0, a.sf<b.sf ? -1 : 0);

        public static int16 operator <=(uint16 a, uint16 b) => new int16(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0, a.s4<=b.s4 ? -1 : 0, a.s5<=b.s5 ? -1 : 0, a.s6<=b.s6 ? -1 : 0, a.s7<=b.s7 ? -1 : 0, a.s8<=b.s8 ? -1 : 0, a.s9<=b.s9 ? -1 : 0, a.sa<=b.sa ? -1 : 0, a.sb<=b.sb ? -1 : 0, a.sc<=b.sc ? -1 : 0, a.sd<=b.sd ? -1 : 0, a.se<=b.se ? -1 : 0, a.sf<=b.sf ? -1 : 0);

        public static int16 operator >(uint16 a, uint16 b) => new int16(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0, a.s4>b.s4 ? -1 : 0, a.s5>b.s5 ? -1 : 0, a.s6>b.s6 ? -1 : 0, a.s7>b.s7 ? -1 : 0, a.s8>b.s8 ? -1 : 0, a.s9>b.s9 ? -1 : 0, a.sa>b.sa ? -1 : 0, a.sb>b.sb ? -1 : 0, a.sc>b.sc ? -1 : 0, a.sd>b.sd ? -1 : 0, a.se>b.se ? -1 : 0, a.sf>b.sf ? -1 : 0);

        public static int16 operator >=(uint16 a, uint16 b) => new int16(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0, a.s4>=b.s4 ? -1 : 0, a.s5>=b.s5 ? -1 : 0, a.s6>=b.s6 ? -1 : 0, a.s7>=b.s7 ? -1 : 0, a.s8>=b.s8 ? -1 : 0, a.s9>=b.s9 ? -1 : 0, a.sa>=b.sa ? -1 : 0, a.sb>=b.sb ? -1 : 0, a.sc>=b.sc ? -1 : 0, a.sd>=b.sd ? -1 : 0, a.se>=b.se ? -1 : 0, a.sf>=b.sf ? -1 : 0);

        public static uint16 operator &(uint16 a, uint16 b) => new uint16((uint)(a.s0&b.s0), (uint)(a.s1&b.s1), (uint)(a.s2&b.s2), (uint)(a.s3&b.s3), (uint)(a.s4&b.s4), (uint)(a.s5&b.s5), (uint)(a.s6&b.s6), (uint)(a.s7&b.s7), (uint)(a.s8&b.s8), (uint)(a.s9&b.s9), (uint)(a.sa&b.sa), (uint)(a.sb&b.sb), (uint)(a.sc&b.sc), (uint)(a.sd&b.sd), (uint)(a.se&b.se), (uint)(a.sf&b.sf));

        public static uint16 operator |(uint16 a, uint16 b) => new uint16((uint)(a.s0|b.s0), (uint)(a.s1|b.s1), (uint)(a.s2|b.s2), (uint)(a.s3|b.s3), (uint)(a.s4|b.s4), (uint)(a.s5|b.s5), (uint)(a.s6|b.s6), (uint)(a.s7|b.s7), (uint)(a.s8|b.s8), (uint)(a.s9|b.s9), (uint)(a.sa|b.sa), (uint)(a.sb|b.sb), (uint)(a.sc|b.sc), (uint)(a.sd|b.sd), (uint)(a.se|b.se), (uint)(a.sf|b.sf));

        public static uint16 operator ^(uint16 a, uint16 b) => new uint16((uint)(a.s0^b.s0), (uint)(a.s1^b.s1), (uint)(a.s2^b.s2), (uint)(a.s3^b.s3), (uint)(a.s4^b.s4), (uint)(a.s5^b.s5), (uint)(a.s6^b.s6), (uint)(a.s7^b.s7), (uint)(a.s8^b.s8), (uint)(a.s9^b.s9), (uint)(a.sa^b.sa), (uint)(a.sb^b.sb), (uint)(a.sc^b.sc), (uint)(a.sd^b.sd), (uint)(a.se^b.se), (uint)(a.sf^b.sf));

        public static uint16 operator +(uint16 a) => a;

        public static uint16 operator ~(uint16 a) => new uint16((uint)(~a.s0), (uint)(~a.s1), (uint)(~a.s2), (uint)(~a.s3), (uint)(~a.s4), (uint)(~a.s5), (uint)(~a.s6), (uint)(~a.s7), (uint)(~a.s8), (uint)(~a.s9), (uint)(~a.sa), (uint)(~a.sb), (uint)(~a.sc), (uint)(~a.sd), (uint)(~a.se), (uint)(~a.sf));

        public static uint16 operator ++(uint16 a) => new uint16((uint)(a.s0+1), (uint)(a.s1+1), (uint)(a.s2+1), (uint)(a.s3+1), (uint)(a.s4+1), (uint)(a.s5+1), (uint)(a.s6+1), (uint)(a.s7+1), (uint)(a.s8+1), (uint)(a.s9+1), (uint)(a.sa+1), (uint)(a.sb+1), (uint)(a.sc+1), (uint)(a.sd+1), (uint)(a.se+1), (uint)(a.sf+1));

        public static uint16 operator --(uint16 a) => new uint16((uint)(a.s0-1), (uint)(a.s1-1), (uint)(a.s2-1), (uint)(a.s3-1), (uint)(a.s4-1), (uint)(a.s5-1), (uint)(a.s6-1), (uint)(a.s7-1), (uint)(a.s8-1), (uint)(a.s9-1), (uint)(a.sa-1), (uint)(a.sb-1), (uint)(a.sc-1), (uint)(a.sd-1), (uint)(a.se-1), (uint)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct long2: IVectorType, IEquatable<long2>
    {
        [FieldOffset(0)]
        public long s0;
        [FieldOffset(8)]
        public long s1;

        public long2(long v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public long2(long2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public long2(long v0, long v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public long x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public long y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public long2 xx
        {
            get { return new long2(this.s0, this.s0); }
        }

        public long2 xy
        {
            get { return new long2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public long2 yx
        {
            get { return new long2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public long2 yy
        {
            get { return new long2(this.s1, this.s1); }
        }

        public long this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(long2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is long2 && Equals((long2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static long2 operator +(long2 a, long2 b) => new long2((long)(a.s0+b.s0), (long)(a.s1+b.s1));

        public static long2 operator -(long2 a, long2 b) => new long2((long)(a.s0-b.s0), (long)(a.s1-b.s1));

        public static long2 operator *(long2 a, long2 b) => new long2((long)(a.s0*b.s0), (long)(a.s1*b.s1));

        public static long2 operator /(long2 a, long2 b) => new long2((long)(a.s0/b.s0), (long)(a.s1/b.s1));

        public static long2 operator ==(long2 a, long2 b) => new long2(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L);

        public static long2 operator !=(long2 a, long2 b) => new long2(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L);

        public static long2 operator <(long2 a, long2 b) => new long2(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L);

        public static long2 operator <=(long2 a, long2 b) => new long2(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L);

        public static long2 operator >(long2 a, long2 b) => new long2(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L);

        public static long2 operator >=(long2 a, long2 b) => new long2(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L);

        public static long2 operator &(long2 a, long2 b) => new long2((long)(a.s0&b.s0), (long)(a.s1&b.s1));

        public static long2 operator |(long2 a, long2 b) => new long2((long)(a.s0|b.s0), (long)(a.s1|b.s1));

        public static long2 operator ^(long2 a, long2 b) => new long2((long)(a.s0^b.s0), (long)(a.s1^b.s1));

        public static long2 operator +(long2 a) => a;

        public static long2 operator -(long2 a) => new long2((long)(-a.s0), (long)(-a.s1));

        public static long2 operator ~(long2 a) => new long2((long)(~a.s0), (long)(~a.s1));

        public static long2 operator ++(long2 a) => new long2((long)(a.s0+1), (long)(a.s1+1));

        public static long2 operator --(long2 a) => new long2((long)(a.s0-1), (long)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=32)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct long3: IVectorType, IEquatable<long3>
    {
        [FieldOffset(0)]
        public long s0;
        [FieldOffset(8)]
        public long s1;
        [FieldOffset(16)]
        public long s2;

        public long3(long v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public long3(long3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public long3(long v0, long2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public long3(long2 v0, long v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public long3(long v0, long v1, long v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public long x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public long y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public long z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public long2 xx
        {
            get { return new long2(this.s0, this.s0); }
        }

        public long2 xy
        {
            get { return new long2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public long2 xz
        {
            get { return new long2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public long2 yx
        {
            get { return new long2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public long2 yy
        {
            get { return new long2(this.s1, this.s1); }
        }

        public long2 yz
        {
            get { return new long2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public long2 zx
        {
            get { return new long2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public long2 zy
        {
            get { return new long2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public long2 zz
        {
            get { return new long2(this.s2, this.s2); }
        }

        public long3 xxx
        {
            get { return new long3(this.s0, this.s0, this.s0); }
        }

        public long3 xxy
        {
            get { return new long3(this.s0, this.s0, this.s1); }
        }

        public long3 xxz
        {
            get { return new long3(this.s0, this.s0, this.s2); }
        }

        public long3 xyx
        {
            get { return new long3(this.s0, this.s1, this.s0); }
        }

        public long3 xyy
        {
            get { return new long3(this.s0, this.s1, this.s1); }
        }

        public long3 xyz
        {
            get { return new long3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 xzx
        {
            get { return new long3(this.s0, this.s2, this.s0); }
        }

        public long3 xzy
        {
            get { return new long3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 xzz
        {
            get { return new long3(this.s0, this.s2, this.s2); }
        }

        public long3 yxx
        {
            get { return new long3(this.s1, this.s0, this.s0); }
        }

        public long3 yxy
        {
            get { return new long3(this.s1, this.s0, this.s1); }
        }

        public long3 yxz
        {
            get { return new long3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 yyx
        {
            get { return new long3(this.s1, this.s1, this.s0); }
        }

        public long3 yyy
        {
            get { return new long3(this.s1, this.s1, this.s1); }
        }

        public long3 yyz
        {
            get { return new long3(this.s1, this.s1, this.s2); }
        }

        public long3 yzx
        {
            get { return new long3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 yzy
        {
            get { return new long3(this.s1, this.s2, this.s1); }
        }

        public long3 yzz
        {
            get { return new long3(this.s1, this.s2, this.s2); }
        }

        public long3 zxx
        {
            get { return new long3(this.s2, this.s0, this.s0); }
        }

        public long3 zxy
        {
            get { return new long3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 zxz
        {
            get { return new long3(this.s2, this.s0, this.s2); }
        }

        public long3 zyx
        {
            get { return new long3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 zyy
        {
            get { return new long3(this.s2, this.s1, this.s1); }
        }

        public long3 zyz
        {
            get { return new long3(this.s2, this.s1, this.s2); }
        }

        public long3 zzx
        {
            get { return new long3(this.s2, this.s2, this.s0); }
        }

        public long3 zzy
        {
            get { return new long3(this.s2, this.s2, this.s1); }
        }

        public long3 zzz
        {
            get { return new long3(this.s2, this.s2, this.s2); }
        }

        public long this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 24; }
        }

        // IEquatable

        public bool Equals(long3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is long3 && Equals((long3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static long3 operator +(long3 a, long3 b) => new long3((long)(a.s0+b.s0), (long)(a.s1+b.s1), (long)(a.s2+b.s2));

        public static long3 operator -(long3 a, long3 b) => new long3((long)(a.s0-b.s0), (long)(a.s1-b.s1), (long)(a.s2-b.s2));

        public static long3 operator *(long3 a, long3 b) => new long3((long)(a.s0*b.s0), (long)(a.s1*b.s1), (long)(a.s2*b.s2));

        public static long3 operator /(long3 a, long3 b) => new long3((long)(a.s0/b.s0), (long)(a.s1/b.s1), (long)(a.s2/b.s2));

        public static long3 operator ==(long3 a, long3 b) => new long3(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L);

        public static long3 operator !=(long3 a, long3 b) => new long3(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L);

        public static long3 operator <(long3 a, long3 b) => new long3(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L);

        public static long3 operator <=(long3 a, long3 b) => new long3(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L);

        public static long3 operator >(long3 a, long3 b) => new long3(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L);

        public static long3 operator >=(long3 a, long3 b) => new long3(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L);

        public static long3 operator &(long3 a, long3 b) => new long3((long)(a.s0&b.s0), (long)(a.s1&b.s1), (long)(a.s2&b.s2));

        public static long3 operator |(long3 a, long3 b) => new long3((long)(a.s0|b.s0), (long)(a.s1|b.s1), (long)(a.s2|b.s2));

        public static long3 operator ^(long3 a, long3 b) => new long3((long)(a.s0^b.s0), (long)(a.s1^b.s1), (long)(a.s2^b.s2));

        public static long3 operator +(long3 a) => a;

        public static long3 operator -(long3 a) => new long3((long)(-a.s0), (long)(-a.s1), (long)(-a.s2));

        public static long3 operator ~(long3 a) => new long3((long)(~a.s0), (long)(~a.s1), (long)(~a.s2));

        public static long3 operator ++(long3 a) => new long3((long)(a.s0+1), (long)(a.s1+1), (long)(a.s2+1));

        public static long3 operator --(long3 a) => new long3((long)(a.s0-1), (long)(a.s1-1), (long)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct long4: IVectorType, IEquatable<long4>
    {
        [FieldOffset(0)]
        public long s0;
        [FieldOffset(8)]
        public long s1;
        [FieldOffset(16)]
        public long s2;
        [FieldOffset(24)]
        public long s3;

        public long4(long v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public long4(long4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public long4(long v0, long3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public long4(long2 v0, long2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public long4(long3 v0, long v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public long4(long v0, long v1, long2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public long4(long v0, long2 v1, long v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public long4(long2 v0, long v1, long v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public long4(long v0, long v1, long v2, long v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public long x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public long y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public long z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public long w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public long2 xx
        {
            get { return new long2(this.s0, this.s0); }
        }

        public long2 xy
        {
            get { return new long2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public long2 xz
        {
            get { return new long2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public long2 xw
        {
            get { return new long2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public long2 yx
        {
            get { return new long2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public long2 yy
        {
            get { return new long2(this.s1, this.s1); }
        }

        public long2 yz
        {
            get { return new long2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public long2 yw
        {
            get { return new long2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public long2 zx
        {
            get { return new long2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public long2 zy
        {
            get { return new long2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public long2 zz
        {
            get { return new long2(this.s2, this.s2); }
        }

        public long2 zw
        {
            get { return new long2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public long2 wx
        {
            get { return new long2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public long2 wy
        {
            get { return new long2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public long2 wz
        {
            get { return new long2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public long2 ww
        {
            get { return new long2(this.s3, this.s3); }
        }

        public long3 xxx
        {
            get { return new long3(this.s0, this.s0, this.s0); }
        }

        public long3 xxy
        {
            get { return new long3(this.s0, this.s0, this.s1); }
        }

        public long3 xxz
        {
            get { return new long3(this.s0, this.s0, this.s2); }
        }

        public long3 xxw
        {
            get { return new long3(this.s0, this.s0, this.s3); }
        }

        public long3 xyx
        {
            get { return new long3(this.s0, this.s1, this.s0); }
        }

        public long3 xyy
        {
            get { return new long3(this.s0, this.s1, this.s1); }
        }

        public long3 xyz
        {
            get { return new long3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 xyw
        {
            get { return new long3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public long3 xzx
        {
            get { return new long3(this.s0, this.s2, this.s0); }
        }

        public long3 xzy
        {
            get { return new long3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 xzz
        {
            get { return new long3(this.s0, this.s2, this.s2); }
        }

        public long3 xzw
        {
            get { return new long3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public long3 xwx
        {
            get { return new long3(this.s0, this.s3, this.s0); }
        }

        public long3 xwy
        {
            get { return new long3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 xwz
        {
            get { return new long3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 xww
        {
            get { return new long3(this.s0, this.s3, this.s3); }
        }

        public long3 yxx
        {
            get { return new long3(this.s1, this.s0, this.s0); }
        }

        public long3 yxy
        {
            get { return new long3(this.s1, this.s0, this.s1); }
        }

        public long3 yxz
        {
            get { return new long3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 yxw
        {
            get { return new long3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public long3 yyx
        {
            get { return new long3(this.s1, this.s1, this.s0); }
        }

        public long3 yyy
        {
            get { return new long3(this.s1, this.s1, this.s1); }
        }

        public long3 yyz
        {
            get { return new long3(this.s1, this.s1, this.s2); }
        }

        public long3 yyw
        {
            get { return new long3(this.s1, this.s1, this.s3); }
        }

        public long3 yzx
        {
            get { return new long3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 yzy
        {
            get { return new long3(this.s1, this.s2, this.s1); }
        }

        public long3 yzz
        {
            get { return new long3(this.s1, this.s2, this.s2); }
        }

        public long3 yzw
        {
            get { return new long3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public long3 ywx
        {
            get { return new long3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 ywy
        {
            get { return new long3(this.s1, this.s3, this.s1); }
        }

        public long3 ywz
        {
            get { return new long3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 yww
        {
            get { return new long3(this.s1, this.s3, this.s3); }
        }

        public long3 zxx
        {
            get { return new long3(this.s2, this.s0, this.s0); }
        }

        public long3 zxy
        {
            get { return new long3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 zxz
        {
            get { return new long3(this.s2, this.s0, this.s2); }
        }

        public long3 zxw
        {
            get { return new long3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public long3 zyx
        {
            get { return new long3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 zyy
        {
            get { return new long3(this.s2, this.s1, this.s1); }
        }

        public long3 zyz
        {
            get { return new long3(this.s2, this.s1, this.s2); }
        }

        public long3 zyw
        {
            get { return new long3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public long3 zzx
        {
            get { return new long3(this.s2, this.s2, this.s0); }
        }

        public long3 zzy
        {
            get { return new long3(this.s2, this.s2, this.s1); }
        }

        public long3 zzz
        {
            get { return new long3(this.s2, this.s2, this.s2); }
        }

        public long3 zzw
        {
            get { return new long3(this.s2, this.s2, this.s3); }
        }

        public long3 zwx
        {
            get { return new long3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 zwy
        {
            get { return new long3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 zwz
        {
            get { return new long3(this.s2, this.s3, this.s2); }
        }

        public long3 zww
        {
            get { return new long3(this.s2, this.s3, this.s3); }
        }

        public long3 wxx
        {
            get { return new long3(this.s3, this.s0, this.s0); }
        }

        public long3 wxy
        {
            get { return new long3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 wxz
        {
            get { return new long3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 wxw
        {
            get { return new long3(this.s3, this.s0, this.s3); }
        }

        public long3 wyx
        {
            get { return new long3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 wyy
        {
            get { return new long3(this.s3, this.s1, this.s1); }
        }

        public long3 wyz
        {
            get { return new long3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public long3 wyw
        {
            get { return new long3(this.s3, this.s1, this.s3); }
        }

        public long3 wzx
        {
            get { return new long3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public long3 wzy
        {
            get { return new long3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public long3 wzz
        {
            get { return new long3(this.s3, this.s2, this.s2); }
        }

        public long3 wzw
        {
            get { return new long3(this.s3, this.s2, this.s3); }
        }

        public long3 wwx
        {
            get { return new long3(this.s3, this.s3, this.s0); }
        }

        public long3 wwy
        {
            get { return new long3(this.s3, this.s3, this.s1); }
        }

        public long3 wwz
        {
            get { return new long3(this.s3, this.s3, this.s2); }
        }

        public long3 www
        {
            get { return new long3(this.s3, this.s3, this.s3); }
        }

        public long4 xxxx
        {
            get { return new long4(this.s0, this.s0, this.s0, this.s0); }
        }

        public long4 xxxy
        {
            get { return new long4(this.s0, this.s0, this.s0, this.s1); }
        }

        public long4 xxxz
        {
            get { return new long4(this.s0, this.s0, this.s0, this.s2); }
        }

        public long4 xxxw
        {
            get { return new long4(this.s0, this.s0, this.s0, this.s3); }
        }

        public long4 xxyx
        {
            get { return new long4(this.s0, this.s0, this.s1, this.s0); }
        }

        public long4 xxyy
        {
            get { return new long4(this.s0, this.s0, this.s1, this.s1); }
        }

        public long4 xxyz
        {
            get { return new long4(this.s0, this.s0, this.s1, this.s2); }
        }

        public long4 xxyw
        {
            get { return new long4(this.s0, this.s0, this.s1, this.s3); }
        }

        public long4 xxzx
        {
            get { return new long4(this.s0, this.s0, this.s2, this.s0); }
        }

        public long4 xxzy
        {
            get { return new long4(this.s0, this.s0, this.s2, this.s1); }
        }

        public long4 xxzz
        {
            get { return new long4(this.s0, this.s0, this.s2, this.s2); }
        }

        public long4 xxzw
        {
            get { return new long4(this.s0, this.s0, this.s2, this.s3); }
        }

        public long4 xxwx
        {
            get { return new long4(this.s0, this.s0, this.s3, this.s0); }
        }

        public long4 xxwy
        {
            get { return new long4(this.s0, this.s0, this.s3, this.s1); }
        }

        public long4 xxwz
        {
            get { return new long4(this.s0, this.s0, this.s3, this.s2); }
        }

        public long4 xxww
        {
            get { return new long4(this.s0, this.s0, this.s3, this.s3); }
        }

        public long4 xyxx
        {
            get { return new long4(this.s0, this.s1, this.s0, this.s0); }
        }

        public long4 xyxy
        {
            get { return new long4(this.s0, this.s1, this.s0, this.s1); }
        }

        public long4 xyxz
        {
            get { return new long4(this.s0, this.s1, this.s0, this.s2); }
        }

        public long4 xyxw
        {
            get { return new long4(this.s0, this.s1, this.s0, this.s3); }
        }

        public long4 xyyx
        {
            get { return new long4(this.s0, this.s1, this.s1, this.s0); }
        }

        public long4 xyyy
        {
            get { return new long4(this.s0, this.s1, this.s1, this.s1); }
        }

        public long4 xyyz
        {
            get { return new long4(this.s0, this.s1, this.s1, this.s2); }
        }

        public long4 xyyw
        {
            get { return new long4(this.s0, this.s1, this.s1, this.s3); }
        }

        public long4 xyzx
        {
            get { return new long4(this.s0, this.s1, this.s2, this.s0); }
        }

        public long4 xyzy
        {
            get { return new long4(this.s0, this.s1, this.s2, this.s1); }
        }

        public long4 xyzz
        {
            get { return new long4(this.s0, this.s1, this.s2, this.s2); }
        }

        public long4 xyzw
        {
            get { return new long4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public long4 xywx
        {
            get { return new long4(this.s0, this.s1, this.s3, this.s0); }
        }

        public long4 xywy
        {
            get { return new long4(this.s0, this.s1, this.s3, this.s1); }
        }

        public long4 xywz
        {
            get { return new long4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public long4 xyww
        {
            get { return new long4(this.s0, this.s1, this.s3, this.s3); }
        }

        public long4 xzxx
        {
            get { return new long4(this.s0, this.s2, this.s0, this.s0); }
        }

        public long4 xzxy
        {
            get { return new long4(this.s0, this.s2, this.s0, this.s1); }
        }

        public long4 xzxz
        {
            get { return new long4(this.s0, this.s2, this.s0, this.s2); }
        }

        public long4 xzxw
        {
            get { return new long4(this.s0, this.s2, this.s0, this.s3); }
        }

        public long4 xzyx
        {
            get { return new long4(this.s0, this.s2, this.s1, this.s0); }
        }

        public long4 xzyy
        {
            get { return new long4(this.s0, this.s2, this.s1, this.s1); }
        }

        public long4 xzyz
        {
            get { return new long4(this.s0, this.s2, this.s1, this.s2); }
        }

        public long4 xzyw
        {
            get { return new long4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public long4 xzzx
        {
            get { return new long4(this.s0, this.s2, this.s2, this.s0); }
        }

        public long4 xzzy
        {
            get { return new long4(this.s0, this.s2, this.s2, this.s1); }
        }

        public long4 xzzz
        {
            get { return new long4(this.s0, this.s2, this.s2, this.s2); }
        }

        public long4 xzzw
        {
            get { return new long4(this.s0, this.s2, this.s2, this.s3); }
        }

        public long4 xzwx
        {
            get { return new long4(this.s0, this.s2, this.s3, this.s0); }
        }

        public long4 xzwy
        {
            get { return new long4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public long4 xzwz
        {
            get { return new long4(this.s0, this.s2, this.s3, this.s2); }
        }

        public long4 xzww
        {
            get { return new long4(this.s0, this.s2, this.s3, this.s3); }
        }

        public long4 xwxx
        {
            get { return new long4(this.s0, this.s3, this.s0, this.s0); }
        }

        public long4 xwxy
        {
            get { return new long4(this.s0, this.s3, this.s0, this.s1); }
        }

        public long4 xwxz
        {
            get { return new long4(this.s0, this.s3, this.s0, this.s2); }
        }

        public long4 xwxw
        {
            get { return new long4(this.s0, this.s3, this.s0, this.s3); }
        }

        public long4 xwyx
        {
            get { return new long4(this.s0, this.s3, this.s1, this.s0); }
        }

        public long4 xwyy
        {
            get { return new long4(this.s0, this.s3, this.s1, this.s1); }
        }

        public long4 xwyz
        {
            get { return new long4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public long4 xwyw
        {
            get { return new long4(this.s0, this.s3, this.s1, this.s3); }
        }

        public long4 xwzx
        {
            get { return new long4(this.s0, this.s3, this.s2, this.s0); }
        }

        public long4 xwzy
        {
            get { return new long4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public long4 xwzz
        {
            get { return new long4(this.s0, this.s3, this.s2, this.s2); }
        }

        public long4 xwzw
        {
            get { return new long4(this.s0, this.s3, this.s2, this.s3); }
        }

        public long4 xwwx
        {
            get { return new long4(this.s0, this.s3, this.s3, this.s0); }
        }

        public long4 xwwy
        {
            get { return new long4(this.s0, this.s3, this.s3, this.s1); }
        }

        public long4 xwwz
        {
            get { return new long4(this.s0, this.s3, this.s3, this.s2); }
        }

        public long4 xwww
        {
            get { return new long4(this.s0, this.s3, this.s3, this.s3); }
        }

        public long4 yxxx
        {
            get { return new long4(this.s1, this.s0, this.s0, this.s0); }
        }

        public long4 yxxy
        {
            get { return new long4(this.s1, this.s0, this.s0, this.s1); }
        }

        public long4 yxxz
        {
            get { return new long4(this.s1, this.s0, this.s0, this.s2); }
        }

        public long4 yxxw
        {
            get { return new long4(this.s1, this.s0, this.s0, this.s3); }
        }

        public long4 yxyx
        {
            get { return new long4(this.s1, this.s0, this.s1, this.s0); }
        }

        public long4 yxyy
        {
            get { return new long4(this.s1, this.s0, this.s1, this.s1); }
        }

        public long4 yxyz
        {
            get { return new long4(this.s1, this.s0, this.s1, this.s2); }
        }

        public long4 yxyw
        {
            get { return new long4(this.s1, this.s0, this.s1, this.s3); }
        }

        public long4 yxzx
        {
            get { return new long4(this.s1, this.s0, this.s2, this.s0); }
        }

        public long4 yxzy
        {
            get { return new long4(this.s1, this.s0, this.s2, this.s1); }
        }

        public long4 yxzz
        {
            get { return new long4(this.s1, this.s0, this.s2, this.s2); }
        }

        public long4 yxzw
        {
            get { return new long4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public long4 yxwx
        {
            get { return new long4(this.s1, this.s0, this.s3, this.s0); }
        }

        public long4 yxwy
        {
            get { return new long4(this.s1, this.s0, this.s3, this.s1); }
        }

        public long4 yxwz
        {
            get { return new long4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public long4 yxww
        {
            get { return new long4(this.s1, this.s0, this.s3, this.s3); }
        }

        public long4 yyxx
        {
            get { return new long4(this.s1, this.s1, this.s0, this.s0); }
        }

        public long4 yyxy
        {
            get { return new long4(this.s1, this.s1, this.s0, this.s1); }
        }

        public long4 yyxz
        {
            get { return new long4(this.s1, this.s1, this.s0, this.s2); }
        }

        public long4 yyxw
        {
            get { return new long4(this.s1, this.s1, this.s0, this.s3); }
        }

        public long4 yyyx
        {
            get { return new long4(this.s1, this.s1, this.s1, this.s0); }
        }

        public long4 yyyy
        {
            get { return new long4(this.s1, this.s1, this.s1, this.s1); }
        }

        public long4 yyyz
        {
            get { return new long4(this.s1, this.s1, this.s1, this.s2); }
        }

        public long4 yyyw
        {
            get { return new long4(this.s1, this.s1, this.s1, this.s3); }
        }

        public long4 yyzx
        {
            get { return new long4(this.s1, this.s1, this.s2, this.s0); }
        }

        public long4 yyzy
        {
            get { return new long4(this.s1, this.s1, this.s2, this.s1); }
        }

        public long4 yyzz
        {
            get { return new long4(this.s1, this.s1, this.s2, this.s2); }
        }

        public long4 yyzw
        {
            get { return new long4(this.s1, this.s1, this.s2, this.s3); }
        }

        public long4 yywx
        {
            get { return new long4(this.s1, this.s1, this.s3, this.s0); }
        }

        public long4 yywy
        {
            get { return new long4(this.s1, this.s1, this.s3, this.s1); }
        }

        public long4 yywz
        {
            get { return new long4(this.s1, this.s1, this.s3, this.s2); }
        }

        public long4 yyww
        {
            get { return new long4(this.s1, this.s1, this.s3, this.s3); }
        }

        public long4 yzxx
        {
            get { return new long4(this.s1, this.s2, this.s0, this.s0); }
        }

        public long4 yzxy
        {
            get { return new long4(this.s1, this.s2, this.s0, this.s1); }
        }

        public long4 yzxz
        {
            get { return new long4(this.s1, this.s2, this.s0, this.s2); }
        }

        public long4 yzxw
        {
            get { return new long4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public long4 yzyx
        {
            get { return new long4(this.s1, this.s2, this.s1, this.s0); }
        }

        public long4 yzyy
        {
            get { return new long4(this.s1, this.s2, this.s1, this.s1); }
        }

        public long4 yzyz
        {
            get { return new long4(this.s1, this.s2, this.s1, this.s2); }
        }

        public long4 yzyw
        {
            get { return new long4(this.s1, this.s2, this.s1, this.s3); }
        }

        public long4 yzzx
        {
            get { return new long4(this.s1, this.s2, this.s2, this.s0); }
        }

        public long4 yzzy
        {
            get { return new long4(this.s1, this.s2, this.s2, this.s1); }
        }

        public long4 yzzz
        {
            get { return new long4(this.s1, this.s2, this.s2, this.s2); }
        }

        public long4 yzzw
        {
            get { return new long4(this.s1, this.s2, this.s2, this.s3); }
        }

        public long4 yzwx
        {
            get { return new long4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public long4 yzwy
        {
            get { return new long4(this.s1, this.s2, this.s3, this.s1); }
        }

        public long4 yzwz
        {
            get { return new long4(this.s1, this.s2, this.s3, this.s2); }
        }

        public long4 yzww
        {
            get { return new long4(this.s1, this.s2, this.s3, this.s3); }
        }

        public long4 ywxx
        {
            get { return new long4(this.s1, this.s3, this.s0, this.s0); }
        }

        public long4 ywxy
        {
            get { return new long4(this.s1, this.s3, this.s0, this.s1); }
        }

        public long4 ywxz
        {
            get { return new long4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public long4 ywxw
        {
            get { return new long4(this.s1, this.s3, this.s0, this.s3); }
        }

        public long4 ywyx
        {
            get { return new long4(this.s1, this.s3, this.s1, this.s0); }
        }

        public long4 ywyy
        {
            get { return new long4(this.s1, this.s3, this.s1, this.s1); }
        }

        public long4 ywyz
        {
            get { return new long4(this.s1, this.s3, this.s1, this.s2); }
        }

        public long4 ywyw
        {
            get { return new long4(this.s1, this.s3, this.s1, this.s3); }
        }

        public long4 ywzx
        {
            get { return new long4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public long4 ywzy
        {
            get { return new long4(this.s1, this.s3, this.s2, this.s1); }
        }

        public long4 ywzz
        {
            get { return new long4(this.s1, this.s3, this.s2, this.s2); }
        }

        public long4 ywzw
        {
            get { return new long4(this.s1, this.s3, this.s2, this.s3); }
        }

        public long4 ywwx
        {
            get { return new long4(this.s1, this.s3, this.s3, this.s0); }
        }

        public long4 ywwy
        {
            get { return new long4(this.s1, this.s3, this.s3, this.s1); }
        }

        public long4 ywwz
        {
            get { return new long4(this.s1, this.s3, this.s3, this.s2); }
        }

        public long4 ywww
        {
            get { return new long4(this.s1, this.s3, this.s3, this.s3); }
        }

        public long4 zxxx
        {
            get { return new long4(this.s2, this.s0, this.s0, this.s0); }
        }

        public long4 zxxy
        {
            get { return new long4(this.s2, this.s0, this.s0, this.s1); }
        }

        public long4 zxxz
        {
            get { return new long4(this.s2, this.s0, this.s0, this.s2); }
        }

        public long4 zxxw
        {
            get { return new long4(this.s2, this.s0, this.s0, this.s3); }
        }

        public long4 zxyx
        {
            get { return new long4(this.s2, this.s0, this.s1, this.s0); }
        }

        public long4 zxyy
        {
            get { return new long4(this.s2, this.s0, this.s1, this.s1); }
        }

        public long4 zxyz
        {
            get { return new long4(this.s2, this.s0, this.s1, this.s2); }
        }

        public long4 zxyw
        {
            get { return new long4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public long4 zxzx
        {
            get { return new long4(this.s2, this.s0, this.s2, this.s0); }
        }

        public long4 zxzy
        {
            get { return new long4(this.s2, this.s0, this.s2, this.s1); }
        }

        public long4 zxzz
        {
            get { return new long4(this.s2, this.s0, this.s2, this.s2); }
        }

        public long4 zxzw
        {
            get { return new long4(this.s2, this.s0, this.s2, this.s3); }
        }

        public long4 zxwx
        {
            get { return new long4(this.s2, this.s0, this.s3, this.s0); }
        }

        public long4 zxwy
        {
            get { return new long4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public long4 zxwz
        {
            get { return new long4(this.s2, this.s0, this.s3, this.s2); }
        }

        public long4 zxww
        {
            get { return new long4(this.s2, this.s0, this.s3, this.s3); }
        }

        public long4 zyxx
        {
            get { return new long4(this.s2, this.s1, this.s0, this.s0); }
        }

        public long4 zyxy
        {
            get { return new long4(this.s2, this.s1, this.s0, this.s1); }
        }

        public long4 zyxz
        {
            get { return new long4(this.s2, this.s1, this.s0, this.s2); }
        }

        public long4 zyxw
        {
            get { return new long4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public long4 zyyx
        {
            get { return new long4(this.s2, this.s1, this.s1, this.s0); }
        }

        public long4 zyyy
        {
            get { return new long4(this.s2, this.s1, this.s1, this.s1); }
        }

        public long4 zyyz
        {
            get { return new long4(this.s2, this.s1, this.s1, this.s2); }
        }

        public long4 zyyw
        {
            get { return new long4(this.s2, this.s1, this.s1, this.s3); }
        }

        public long4 zyzx
        {
            get { return new long4(this.s2, this.s1, this.s2, this.s0); }
        }

        public long4 zyzy
        {
            get { return new long4(this.s2, this.s1, this.s2, this.s1); }
        }

        public long4 zyzz
        {
            get { return new long4(this.s2, this.s1, this.s2, this.s2); }
        }

        public long4 zyzw
        {
            get { return new long4(this.s2, this.s1, this.s2, this.s3); }
        }

        public long4 zywx
        {
            get { return new long4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public long4 zywy
        {
            get { return new long4(this.s2, this.s1, this.s3, this.s1); }
        }

        public long4 zywz
        {
            get { return new long4(this.s2, this.s1, this.s3, this.s2); }
        }

        public long4 zyww
        {
            get { return new long4(this.s2, this.s1, this.s3, this.s3); }
        }

        public long4 zzxx
        {
            get { return new long4(this.s2, this.s2, this.s0, this.s0); }
        }

        public long4 zzxy
        {
            get { return new long4(this.s2, this.s2, this.s0, this.s1); }
        }

        public long4 zzxz
        {
            get { return new long4(this.s2, this.s2, this.s0, this.s2); }
        }

        public long4 zzxw
        {
            get { return new long4(this.s2, this.s2, this.s0, this.s3); }
        }

        public long4 zzyx
        {
            get { return new long4(this.s2, this.s2, this.s1, this.s0); }
        }

        public long4 zzyy
        {
            get { return new long4(this.s2, this.s2, this.s1, this.s1); }
        }

        public long4 zzyz
        {
            get { return new long4(this.s2, this.s2, this.s1, this.s2); }
        }

        public long4 zzyw
        {
            get { return new long4(this.s2, this.s2, this.s1, this.s3); }
        }

        public long4 zzzx
        {
            get { return new long4(this.s2, this.s2, this.s2, this.s0); }
        }

        public long4 zzzy
        {
            get { return new long4(this.s2, this.s2, this.s2, this.s1); }
        }

        public long4 zzzz
        {
            get { return new long4(this.s2, this.s2, this.s2, this.s2); }
        }

        public long4 zzzw
        {
            get { return new long4(this.s2, this.s2, this.s2, this.s3); }
        }

        public long4 zzwx
        {
            get { return new long4(this.s2, this.s2, this.s3, this.s0); }
        }

        public long4 zzwy
        {
            get { return new long4(this.s2, this.s2, this.s3, this.s1); }
        }

        public long4 zzwz
        {
            get { return new long4(this.s2, this.s2, this.s3, this.s2); }
        }

        public long4 zzww
        {
            get { return new long4(this.s2, this.s2, this.s3, this.s3); }
        }

        public long4 zwxx
        {
            get { return new long4(this.s2, this.s3, this.s0, this.s0); }
        }

        public long4 zwxy
        {
            get { return new long4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public long4 zwxz
        {
            get { return new long4(this.s2, this.s3, this.s0, this.s2); }
        }

        public long4 zwxw
        {
            get { return new long4(this.s2, this.s3, this.s0, this.s3); }
        }

        public long4 zwyx
        {
            get { return new long4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public long4 zwyy
        {
            get { return new long4(this.s2, this.s3, this.s1, this.s1); }
        }

        public long4 zwyz
        {
            get { return new long4(this.s2, this.s3, this.s1, this.s2); }
        }

        public long4 zwyw
        {
            get { return new long4(this.s2, this.s3, this.s1, this.s3); }
        }

        public long4 zwzx
        {
            get { return new long4(this.s2, this.s3, this.s2, this.s0); }
        }

        public long4 zwzy
        {
            get { return new long4(this.s2, this.s3, this.s2, this.s1); }
        }

        public long4 zwzz
        {
            get { return new long4(this.s2, this.s3, this.s2, this.s2); }
        }

        public long4 zwzw
        {
            get { return new long4(this.s2, this.s3, this.s2, this.s3); }
        }

        public long4 zwwx
        {
            get { return new long4(this.s2, this.s3, this.s3, this.s0); }
        }

        public long4 zwwy
        {
            get { return new long4(this.s2, this.s3, this.s3, this.s1); }
        }

        public long4 zwwz
        {
            get { return new long4(this.s2, this.s3, this.s3, this.s2); }
        }

        public long4 zwww
        {
            get { return new long4(this.s2, this.s3, this.s3, this.s3); }
        }

        public long4 wxxx
        {
            get { return new long4(this.s3, this.s0, this.s0, this.s0); }
        }

        public long4 wxxy
        {
            get { return new long4(this.s3, this.s0, this.s0, this.s1); }
        }

        public long4 wxxz
        {
            get { return new long4(this.s3, this.s0, this.s0, this.s2); }
        }

        public long4 wxxw
        {
            get { return new long4(this.s3, this.s0, this.s0, this.s3); }
        }

        public long4 wxyx
        {
            get { return new long4(this.s3, this.s0, this.s1, this.s0); }
        }

        public long4 wxyy
        {
            get { return new long4(this.s3, this.s0, this.s1, this.s1); }
        }

        public long4 wxyz
        {
            get { return new long4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public long4 wxyw
        {
            get { return new long4(this.s3, this.s0, this.s1, this.s3); }
        }

        public long4 wxzx
        {
            get { return new long4(this.s3, this.s0, this.s2, this.s0); }
        }

        public long4 wxzy
        {
            get { return new long4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public long4 wxzz
        {
            get { return new long4(this.s3, this.s0, this.s2, this.s2); }
        }

        public long4 wxzw
        {
            get { return new long4(this.s3, this.s0, this.s2, this.s3); }
        }

        public long4 wxwx
        {
            get { return new long4(this.s3, this.s0, this.s3, this.s0); }
        }

        public long4 wxwy
        {
            get { return new long4(this.s3, this.s0, this.s3, this.s1); }
        }

        public long4 wxwz
        {
            get { return new long4(this.s3, this.s0, this.s3, this.s2); }
        }

        public long4 wxww
        {
            get { return new long4(this.s3, this.s0, this.s3, this.s3); }
        }

        public long4 wyxx
        {
            get { return new long4(this.s3, this.s1, this.s0, this.s0); }
        }

        public long4 wyxy
        {
            get { return new long4(this.s3, this.s1, this.s0, this.s1); }
        }

        public long4 wyxz
        {
            get { return new long4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public long4 wyxw
        {
            get { return new long4(this.s3, this.s1, this.s0, this.s3); }
        }

        public long4 wyyx
        {
            get { return new long4(this.s3, this.s1, this.s1, this.s0); }
        }

        public long4 wyyy
        {
            get { return new long4(this.s3, this.s1, this.s1, this.s1); }
        }

        public long4 wyyz
        {
            get { return new long4(this.s3, this.s1, this.s1, this.s2); }
        }

        public long4 wyyw
        {
            get { return new long4(this.s3, this.s1, this.s1, this.s3); }
        }

        public long4 wyzx
        {
            get { return new long4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public long4 wyzy
        {
            get { return new long4(this.s3, this.s1, this.s2, this.s1); }
        }

        public long4 wyzz
        {
            get { return new long4(this.s3, this.s1, this.s2, this.s2); }
        }

        public long4 wyzw
        {
            get { return new long4(this.s3, this.s1, this.s2, this.s3); }
        }

        public long4 wywx
        {
            get { return new long4(this.s3, this.s1, this.s3, this.s0); }
        }

        public long4 wywy
        {
            get { return new long4(this.s3, this.s1, this.s3, this.s1); }
        }

        public long4 wywz
        {
            get { return new long4(this.s3, this.s1, this.s3, this.s2); }
        }

        public long4 wyww
        {
            get { return new long4(this.s3, this.s1, this.s3, this.s3); }
        }

        public long4 wzxx
        {
            get { return new long4(this.s3, this.s2, this.s0, this.s0); }
        }

        public long4 wzxy
        {
            get { return new long4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public long4 wzxz
        {
            get { return new long4(this.s3, this.s2, this.s0, this.s2); }
        }

        public long4 wzxw
        {
            get { return new long4(this.s3, this.s2, this.s0, this.s3); }
        }

        public long4 wzyx
        {
            get { return new long4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public long4 wzyy
        {
            get { return new long4(this.s3, this.s2, this.s1, this.s1); }
        }

        public long4 wzyz
        {
            get { return new long4(this.s3, this.s2, this.s1, this.s2); }
        }

        public long4 wzyw
        {
            get { return new long4(this.s3, this.s2, this.s1, this.s3); }
        }

        public long4 wzzx
        {
            get { return new long4(this.s3, this.s2, this.s2, this.s0); }
        }

        public long4 wzzy
        {
            get { return new long4(this.s3, this.s2, this.s2, this.s1); }
        }

        public long4 wzzz
        {
            get { return new long4(this.s3, this.s2, this.s2, this.s2); }
        }

        public long4 wzzw
        {
            get { return new long4(this.s3, this.s2, this.s2, this.s3); }
        }

        public long4 wzwx
        {
            get { return new long4(this.s3, this.s2, this.s3, this.s0); }
        }

        public long4 wzwy
        {
            get { return new long4(this.s3, this.s2, this.s3, this.s1); }
        }

        public long4 wzwz
        {
            get { return new long4(this.s3, this.s2, this.s3, this.s2); }
        }

        public long4 wzww
        {
            get { return new long4(this.s3, this.s2, this.s3, this.s3); }
        }

        public long4 wwxx
        {
            get { return new long4(this.s3, this.s3, this.s0, this.s0); }
        }

        public long4 wwxy
        {
            get { return new long4(this.s3, this.s3, this.s0, this.s1); }
        }

        public long4 wwxz
        {
            get { return new long4(this.s3, this.s3, this.s0, this.s2); }
        }

        public long4 wwxw
        {
            get { return new long4(this.s3, this.s3, this.s0, this.s3); }
        }

        public long4 wwyx
        {
            get { return new long4(this.s3, this.s3, this.s1, this.s0); }
        }

        public long4 wwyy
        {
            get { return new long4(this.s3, this.s3, this.s1, this.s1); }
        }

        public long4 wwyz
        {
            get { return new long4(this.s3, this.s3, this.s1, this.s2); }
        }

        public long4 wwyw
        {
            get { return new long4(this.s3, this.s3, this.s1, this.s3); }
        }

        public long4 wwzx
        {
            get { return new long4(this.s3, this.s3, this.s2, this.s0); }
        }

        public long4 wwzy
        {
            get { return new long4(this.s3, this.s3, this.s2, this.s1); }
        }

        public long4 wwzz
        {
            get { return new long4(this.s3, this.s3, this.s2, this.s2); }
        }

        public long4 wwzw
        {
            get { return new long4(this.s3, this.s3, this.s2, this.s3); }
        }

        public long4 wwwx
        {
            get { return new long4(this.s3, this.s3, this.s3, this.s0); }
        }

        public long4 wwwy
        {
            get { return new long4(this.s3, this.s3, this.s3, this.s1); }
        }

        public long4 wwwz
        {
            get { return new long4(this.s3, this.s3, this.s3, this.s2); }
        }

        public long4 wwww
        {
            get { return new long4(this.s3, this.s3, this.s3, this.s3); }
        }

        public long this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(long4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is long4 && Equals((long4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static long4 operator +(long4 a, long4 b) => new long4((long)(a.s0+b.s0), (long)(a.s1+b.s1), (long)(a.s2+b.s2), (long)(a.s3+b.s3));

        public static long4 operator -(long4 a, long4 b) => new long4((long)(a.s0-b.s0), (long)(a.s1-b.s1), (long)(a.s2-b.s2), (long)(a.s3-b.s3));

        public static long4 operator *(long4 a, long4 b) => new long4((long)(a.s0*b.s0), (long)(a.s1*b.s1), (long)(a.s2*b.s2), (long)(a.s3*b.s3));

        public static long4 operator /(long4 a, long4 b) => new long4((long)(a.s0/b.s0), (long)(a.s1/b.s1), (long)(a.s2/b.s2), (long)(a.s3/b.s3));

        public static long4 operator ==(long4 a, long4 b) => new long4(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L);

        public static long4 operator !=(long4 a, long4 b) => new long4(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L);

        public static long4 operator <(long4 a, long4 b) => new long4(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L);

        public static long4 operator <=(long4 a, long4 b) => new long4(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L);

        public static long4 operator >(long4 a, long4 b) => new long4(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L);

        public static long4 operator >=(long4 a, long4 b) => new long4(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L);

        public static long4 operator &(long4 a, long4 b) => new long4((long)(a.s0&b.s0), (long)(a.s1&b.s1), (long)(a.s2&b.s2), (long)(a.s3&b.s3));

        public static long4 operator |(long4 a, long4 b) => new long4((long)(a.s0|b.s0), (long)(a.s1|b.s1), (long)(a.s2|b.s2), (long)(a.s3|b.s3));

        public static long4 operator ^(long4 a, long4 b) => new long4((long)(a.s0^b.s0), (long)(a.s1^b.s1), (long)(a.s2^b.s2), (long)(a.s3^b.s3));

        public static long4 operator +(long4 a) => a;

        public static long4 operator -(long4 a) => new long4((long)(-a.s0), (long)(-a.s1), (long)(-a.s2), (long)(-a.s3));

        public static long4 operator ~(long4 a) => new long4((long)(~a.s0), (long)(~a.s1), (long)(~a.s2), (long)(~a.s3));

        public static long4 operator ++(long4 a) => new long4((long)(a.s0+1), (long)(a.s1+1), (long)(a.s2+1), (long)(a.s3+1));

        public static long4 operator --(long4 a) => new long4((long)(a.s0-1), (long)(a.s1-1), (long)(a.s2-1), (long)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct long8: IVectorType, IEquatable<long8>
    {
        [FieldOffset(0)]
        public long s0;
        [FieldOffset(8)]
        public long s1;
        [FieldOffset(16)]
        public long s2;
        [FieldOffset(24)]
        public long s3;
        [FieldOffset(32)]
        public long s4;
        [FieldOffset(40)]
        public long s5;
        [FieldOffset(48)]
        public long s6;
        [FieldOffset(56)]
        public long s7;

        public long8(long v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public long8(long v0, long v1, long v2, long v3, long v4, long v5, long v6, long v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public long this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 64; }
        }

        // IEquatable

        public bool Equals(long8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is long8 && Equals((long8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static long8 operator +(long8 a, long8 b) => new long8((long)(a.s0+b.s0), (long)(a.s1+b.s1), (long)(a.s2+b.s2), (long)(a.s3+b.s3), (long)(a.s4+b.s4), (long)(a.s5+b.s5), (long)(a.s6+b.s6), (long)(a.s7+b.s7));

        public static long8 operator -(long8 a, long8 b) => new long8((long)(a.s0-b.s0), (long)(a.s1-b.s1), (long)(a.s2-b.s2), (long)(a.s3-b.s3), (long)(a.s4-b.s4), (long)(a.s5-b.s5), (long)(a.s6-b.s6), (long)(a.s7-b.s7));

        public static long8 operator *(long8 a, long8 b) => new long8((long)(a.s0*b.s0), (long)(a.s1*b.s1), (long)(a.s2*b.s2), (long)(a.s3*b.s3), (long)(a.s4*b.s4), (long)(a.s5*b.s5), (long)(a.s6*b.s6), (long)(a.s7*b.s7));

        public static long8 operator /(long8 a, long8 b) => new long8((long)(a.s0/b.s0), (long)(a.s1/b.s1), (long)(a.s2/b.s2), (long)(a.s3/b.s3), (long)(a.s4/b.s4), (long)(a.s5/b.s5), (long)(a.s6/b.s6), (long)(a.s7/b.s7));

        public static long8 operator ==(long8 a, long8 b) => new long8(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L, a.s4==b.s4 ? -1L : 0L, a.s5==b.s5 ? -1L : 0L, a.s6==b.s6 ? -1L : 0L, a.s7==b.s7 ? -1L : 0L);

        public static long8 operator !=(long8 a, long8 b) => new long8(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L, a.s4!=b.s4 ? -1L : 0L, a.s5!=b.s5 ? -1L : 0L, a.s6!=b.s6 ? -1L : 0L, a.s7!=b.s7 ? -1L : 0L);

        public static long8 operator <(long8 a, long8 b) => new long8(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L, a.s4<b.s4 ? -1L : 0L, a.s5<b.s5 ? -1L : 0L, a.s6<b.s6 ? -1L : 0L, a.s7<b.s7 ? -1L : 0L);

        public static long8 operator <=(long8 a, long8 b) => new long8(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L, a.s4<=b.s4 ? -1L : 0L, a.s5<=b.s5 ? -1L : 0L, a.s6<=b.s6 ? -1L : 0L, a.s7<=b.s7 ? -1L : 0L);

        public static long8 operator >(long8 a, long8 b) => new long8(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L, a.s4>b.s4 ? -1L : 0L, a.s5>b.s5 ? -1L : 0L, a.s6>b.s6 ? -1L : 0L, a.s7>b.s7 ? -1L : 0L);

        public static long8 operator >=(long8 a, long8 b) => new long8(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L, a.s4>=b.s4 ? -1L : 0L, a.s5>=b.s5 ? -1L : 0L, a.s6>=b.s6 ? -1L : 0L, a.s7>=b.s7 ? -1L : 0L);

        public static long8 operator &(long8 a, long8 b) => new long8((long)(a.s0&b.s0), (long)(a.s1&b.s1), (long)(a.s2&b.s2), (long)(a.s3&b.s3), (long)(a.s4&b.s4), (long)(a.s5&b.s5), (long)(a.s6&b.s6), (long)(a.s7&b.s7));

        public static long8 operator |(long8 a, long8 b) => new long8((long)(a.s0|b.s0), (long)(a.s1|b.s1), (long)(a.s2|b.s2), (long)(a.s3|b.s3), (long)(a.s4|b.s4), (long)(a.s5|b.s5), (long)(a.s6|b.s6), (long)(a.s7|b.s7));

        public static long8 operator ^(long8 a, long8 b) => new long8((long)(a.s0^b.s0), (long)(a.s1^b.s1), (long)(a.s2^b.s2), (long)(a.s3^b.s3), (long)(a.s4^b.s4), (long)(a.s5^b.s5), (long)(a.s6^b.s6), (long)(a.s7^b.s7));

        public static long8 operator +(long8 a) => a;

        public static long8 operator -(long8 a) => new long8((long)(-a.s0), (long)(-a.s1), (long)(-a.s2), (long)(-a.s3), (long)(-a.s4), (long)(-a.s5), (long)(-a.s6), (long)(-a.s7));

        public static long8 operator ~(long8 a) => new long8((long)(~a.s0), (long)(~a.s1), (long)(~a.s2), (long)(~a.s3), (long)(~a.s4), (long)(~a.s5), (long)(~a.s6), (long)(~a.s7));

        public static long8 operator ++(long8 a) => new long8((long)(a.s0+1), (long)(a.s1+1), (long)(a.s2+1), (long)(a.s3+1), (long)(a.s4+1), (long)(a.s5+1), (long)(a.s6+1), (long)(a.s7+1));

        public static long8 operator --(long8 a) => new long8((long)(a.s0-1), (long)(a.s1-1), (long)(a.s2-1), (long)(a.s3-1), (long)(a.s4-1), (long)(a.s5-1), (long)(a.s6-1), (long)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct long16: IVectorType, IEquatable<long16>
    {
        [FieldOffset(0)]
        public long s0;
        [FieldOffset(8)]
        public long s1;
        [FieldOffset(16)]
        public long s2;
        [FieldOffset(24)]
        public long s3;
        [FieldOffset(32)]
        public long s4;
        [FieldOffset(40)]
        public long s5;
        [FieldOffset(48)]
        public long s6;
        [FieldOffset(56)]
        public long s7;
        [FieldOffset(64)]
        public long s8;
        [FieldOffset(72)]
        public long s9;
        [FieldOffset(80)]
        public long sa;
        [FieldOffset(88)]
        public long sb;
        [FieldOffset(96)]
        public long sc;
        [FieldOffset(104)]
        public long sd;
        [FieldOffset(112)]
        public long se;
        [FieldOffset(120)]
        public long sf;

        public long16(long v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public long16(long v0, long v1, long v2, long v3, long v4, long v5, long v6, long v7, long v8, long v9, long va, long vb, long vc, long vd, long ve, long vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public long sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public long sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public long sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public long sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public long sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public long sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public long this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 128; }
        }

        // IEquatable

        public bool Equals(long16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is long16 && Equals((long16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static long16 operator +(long16 a, long16 b) => new long16((long)(a.s0+b.s0), (long)(a.s1+b.s1), (long)(a.s2+b.s2), (long)(a.s3+b.s3), (long)(a.s4+b.s4), (long)(a.s5+b.s5), (long)(a.s6+b.s6), (long)(a.s7+b.s7), (long)(a.s8+b.s8), (long)(a.s9+b.s9), (long)(a.sa+b.sa), (long)(a.sb+b.sb), (long)(a.sc+b.sc), (long)(a.sd+b.sd), (long)(a.se+b.se), (long)(a.sf+b.sf));

        public static long16 operator -(long16 a, long16 b) => new long16((long)(a.s0-b.s0), (long)(a.s1-b.s1), (long)(a.s2-b.s2), (long)(a.s3-b.s3), (long)(a.s4-b.s4), (long)(a.s5-b.s5), (long)(a.s6-b.s6), (long)(a.s7-b.s7), (long)(a.s8-b.s8), (long)(a.s9-b.s9), (long)(a.sa-b.sa), (long)(a.sb-b.sb), (long)(a.sc-b.sc), (long)(a.sd-b.sd), (long)(a.se-b.se), (long)(a.sf-b.sf));

        public static long16 operator *(long16 a, long16 b) => new long16((long)(a.s0*b.s0), (long)(a.s1*b.s1), (long)(a.s2*b.s2), (long)(a.s3*b.s3), (long)(a.s4*b.s4), (long)(a.s5*b.s5), (long)(a.s6*b.s6), (long)(a.s7*b.s7), (long)(a.s8*b.s8), (long)(a.s9*b.s9), (long)(a.sa*b.sa), (long)(a.sb*b.sb), (long)(a.sc*b.sc), (long)(a.sd*b.sd), (long)(a.se*b.se), (long)(a.sf*b.sf));

        public static long16 operator /(long16 a, long16 b) => new long16((long)(a.s0/b.s0), (long)(a.s1/b.s1), (long)(a.s2/b.s2), (long)(a.s3/b.s3), (long)(a.s4/b.s4), (long)(a.s5/b.s5), (long)(a.s6/b.s6), (long)(a.s7/b.s7), (long)(a.s8/b.s8), (long)(a.s9/b.s9), (long)(a.sa/b.sa), (long)(a.sb/b.sb), (long)(a.sc/b.sc), (long)(a.sd/b.sd), (long)(a.se/b.se), (long)(a.sf/b.sf));

        public static long16 operator ==(long16 a, long16 b) => new long16(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L, a.s4==b.s4 ? -1L : 0L, a.s5==b.s5 ? -1L : 0L, a.s6==b.s6 ? -1L : 0L, a.s7==b.s7 ? -1L : 0L, a.s8==b.s8 ? -1L : 0L, a.s9==b.s9 ? -1L : 0L, a.sa==b.sa ? -1L : 0L, a.sb==b.sb ? -1L : 0L, a.sc==b.sc ? -1L : 0L, a.sd==b.sd ? -1L : 0L, a.se==b.se ? -1L : 0L, a.sf==b.sf ? -1L : 0L);

        public static long16 operator !=(long16 a, long16 b) => new long16(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L, a.s4!=b.s4 ? -1L : 0L, a.s5!=b.s5 ? -1L : 0L, a.s6!=b.s6 ? -1L : 0L, a.s7!=b.s7 ? -1L : 0L, a.s8!=b.s8 ? -1L : 0L, a.s9!=b.s9 ? -1L : 0L, a.sa!=b.sa ? -1L : 0L, a.sb!=b.sb ? -1L : 0L, a.sc!=b.sc ? -1L : 0L, a.sd!=b.sd ? -1L : 0L, a.se!=b.se ? -1L : 0L, a.sf!=b.sf ? -1L : 0L);

        public static long16 operator <(long16 a, long16 b) => new long16(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L, a.s4<b.s4 ? -1L : 0L, a.s5<b.s5 ? -1L : 0L, a.s6<b.s6 ? -1L : 0L, a.s7<b.s7 ? -1L : 0L, a.s8<b.s8 ? -1L : 0L, a.s9<b.s9 ? -1L : 0L, a.sa<b.sa ? -1L : 0L, a.sb<b.sb ? -1L : 0L, a.sc<b.sc ? -1L : 0L, a.sd<b.sd ? -1L : 0L, a.se<b.se ? -1L : 0L, a.sf<b.sf ? -1L : 0L);

        public static long16 operator <=(long16 a, long16 b) => new long16(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L, a.s4<=b.s4 ? -1L : 0L, a.s5<=b.s5 ? -1L : 0L, a.s6<=b.s6 ? -1L : 0L, a.s7<=b.s7 ? -1L : 0L, a.s8<=b.s8 ? -1L : 0L, a.s9<=b.s9 ? -1L : 0L, a.sa<=b.sa ? -1L : 0L, a.sb<=b.sb ? -1L : 0L, a.sc<=b.sc ? -1L : 0L, a.sd<=b.sd ? -1L : 0L, a.se<=b.se ? -1L : 0L, a.sf<=b.sf ? -1L : 0L);

        public static long16 operator >(long16 a, long16 b) => new long16(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L, a.s4>b.s4 ? -1L : 0L, a.s5>b.s5 ? -1L : 0L, a.s6>b.s6 ? -1L : 0L, a.s7>b.s7 ? -1L : 0L, a.s8>b.s8 ? -1L : 0L, a.s9>b.s9 ? -1L : 0L, a.sa>b.sa ? -1L : 0L, a.sb>b.sb ? -1L : 0L, a.sc>b.sc ? -1L : 0L, a.sd>b.sd ? -1L : 0L, a.se>b.se ? -1L : 0L, a.sf>b.sf ? -1L : 0L);

        public static long16 operator >=(long16 a, long16 b) => new long16(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L, a.s4>=b.s4 ? -1L : 0L, a.s5>=b.s5 ? -1L : 0L, a.s6>=b.s6 ? -1L : 0L, a.s7>=b.s7 ? -1L : 0L, a.s8>=b.s8 ? -1L : 0L, a.s9>=b.s9 ? -1L : 0L, a.sa>=b.sa ? -1L : 0L, a.sb>=b.sb ? -1L : 0L, a.sc>=b.sc ? -1L : 0L, a.sd>=b.sd ? -1L : 0L, a.se>=b.se ? -1L : 0L, a.sf>=b.sf ? -1L : 0L);

        public static long16 operator &(long16 a, long16 b) => new long16((long)(a.s0&b.s0), (long)(a.s1&b.s1), (long)(a.s2&b.s2), (long)(a.s3&b.s3), (long)(a.s4&b.s4), (long)(a.s5&b.s5), (long)(a.s6&b.s6), (long)(a.s7&b.s7), (long)(a.s8&b.s8), (long)(a.s9&b.s9), (long)(a.sa&b.sa), (long)(a.sb&b.sb), (long)(a.sc&b.sc), (long)(a.sd&b.sd), (long)(a.se&b.se), (long)(a.sf&b.sf));

        public static long16 operator |(long16 a, long16 b) => new long16((long)(a.s0|b.s0), (long)(a.s1|b.s1), (long)(a.s2|b.s2), (long)(a.s3|b.s3), (long)(a.s4|b.s4), (long)(a.s5|b.s5), (long)(a.s6|b.s6), (long)(a.s7|b.s7), (long)(a.s8|b.s8), (long)(a.s9|b.s9), (long)(a.sa|b.sa), (long)(a.sb|b.sb), (long)(a.sc|b.sc), (long)(a.sd|b.sd), (long)(a.se|b.se), (long)(a.sf|b.sf));

        public static long16 operator ^(long16 a, long16 b) => new long16((long)(a.s0^b.s0), (long)(a.s1^b.s1), (long)(a.s2^b.s2), (long)(a.s3^b.s3), (long)(a.s4^b.s4), (long)(a.s5^b.s5), (long)(a.s6^b.s6), (long)(a.s7^b.s7), (long)(a.s8^b.s8), (long)(a.s9^b.s9), (long)(a.sa^b.sa), (long)(a.sb^b.sb), (long)(a.sc^b.sc), (long)(a.sd^b.sd), (long)(a.se^b.se), (long)(a.sf^b.sf));

        public static long16 operator +(long16 a) => a;

        public static long16 operator -(long16 a) => new long16((long)(-a.s0), (long)(-a.s1), (long)(-a.s2), (long)(-a.s3), (long)(-a.s4), (long)(-a.s5), (long)(-a.s6), (long)(-a.s7), (long)(-a.s8), (long)(-a.s9), (long)(-a.sa), (long)(-a.sb), (long)(-a.sc), (long)(-a.sd), (long)(-a.se), (long)(-a.sf));

        public static long16 operator ~(long16 a) => new long16((long)(~a.s0), (long)(~a.s1), (long)(~a.s2), (long)(~a.s3), (long)(~a.s4), (long)(~a.s5), (long)(~a.s6), (long)(~a.s7), (long)(~a.s8), (long)(~a.s9), (long)(~a.sa), (long)(~a.sb), (long)(~a.sc), (long)(~a.sd), (long)(~a.se), (long)(~a.sf));

        public static long16 operator ++(long16 a) => new long16((long)(a.s0+1), (long)(a.s1+1), (long)(a.s2+1), (long)(a.s3+1), (long)(a.s4+1), (long)(a.s5+1), (long)(a.s6+1), (long)(a.s7+1), (long)(a.s8+1), (long)(a.s9+1), (long)(a.sa+1), (long)(a.sb+1), (long)(a.sc+1), (long)(a.sd+1), (long)(a.se+1), (long)(a.sf+1));

        public static long16 operator --(long16 a) => new long16((long)(a.s0-1), (long)(a.s1-1), (long)(a.s2-1), (long)(a.s3-1), (long)(a.s4-1), (long)(a.s5-1), (long)(a.s6-1), (long)(a.s7-1), (long)(a.s8-1), (long)(a.s9-1), (long)(a.sa-1), (long)(a.sb-1), (long)(a.sc-1), (long)(a.sd-1), (long)(a.se-1), (long)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct ulong2: IVectorType, IEquatable<ulong2>
    {
        [FieldOffset(0)]
        public ulong s0;
        [FieldOffset(8)]
        public ulong s1;

        public ulong2(ulong v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public ulong2(ulong2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public ulong2(ulong v0, ulong v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public ulong x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public ulong y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public ulong2 xx
        {
            get { return new ulong2(this.s0, this.s0); }
        }

        public ulong2 xy
        {
            get { return new ulong2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ulong2 yx
        {
            get { return new ulong2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ulong2 yy
        {
            get { return new ulong2(this.s1, this.s1); }
        }

        public ulong this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(ulong2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ulong2 && Equals((ulong2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static ulong2 operator +(ulong2 a, ulong2 b) => new ulong2((ulong)(a.s0+b.s0), (ulong)(a.s1+b.s1));

        public static ulong2 operator -(ulong2 a, ulong2 b) => new ulong2((ulong)(a.s0-b.s0), (ulong)(a.s1-b.s1));

        public static ulong2 operator *(ulong2 a, ulong2 b) => new ulong2((ulong)(a.s0*b.s0), (ulong)(a.s1*b.s1));

        public static ulong2 operator /(ulong2 a, ulong2 b) => new ulong2((ulong)(a.s0/b.s0), (ulong)(a.s1/b.s1));

        public static long2 operator ==(ulong2 a, ulong2 b) => new long2(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L);

        public static long2 operator !=(ulong2 a, ulong2 b) => new long2(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L);

        public static long2 operator <(ulong2 a, ulong2 b) => new long2(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L);

        public static long2 operator <=(ulong2 a, ulong2 b) => new long2(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L);

        public static long2 operator >(ulong2 a, ulong2 b) => new long2(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L);

        public static long2 operator >=(ulong2 a, ulong2 b) => new long2(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L);

        public static ulong2 operator &(ulong2 a, ulong2 b) => new ulong2((ulong)(a.s0&b.s0), (ulong)(a.s1&b.s1));

        public static ulong2 operator |(ulong2 a, ulong2 b) => new ulong2((ulong)(a.s0|b.s0), (ulong)(a.s1|b.s1));

        public static ulong2 operator ^(ulong2 a, ulong2 b) => new ulong2((ulong)(a.s0^b.s0), (ulong)(a.s1^b.s1));

        public static ulong2 operator +(ulong2 a) => a;

        public static ulong2 operator ~(ulong2 a) => new ulong2((ulong)(~a.s0), (ulong)(~a.s1));

        public static ulong2 operator ++(ulong2 a) => new ulong2((ulong)(a.s0+1), (ulong)(a.s1+1));

        public static ulong2 operator --(ulong2 a) => new ulong2((ulong)(a.s0-1), (ulong)(a.s1-1));
    }

    [StructLayout(LayoutKind.Explicit, Size=32)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct ulong3: IVectorType, IEquatable<ulong3>
    {
        [FieldOffset(0)]
        public ulong s0;
        [FieldOffset(8)]
        public ulong s1;
        [FieldOffset(16)]
        public ulong s2;

        public ulong3(ulong v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public ulong3(ulong3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public ulong3(ulong v0, ulong2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public ulong3(ulong2 v0, ulong v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public ulong3(ulong v0, ulong v1, ulong v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public ulong x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public ulong y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public ulong z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public ulong2 xx
        {
            get { return new ulong2(this.s0, this.s0); }
        }

        public ulong2 xy
        {
            get { return new ulong2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ulong2 xz
        {
            get { return new ulong2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ulong2 yx
        {
            get { return new ulong2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ulong2 yy
        {
            get { return new ulong2(this.s1, this.s1); }
        }

        public ulong2 yz
        {
            get { return new ulong2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ulong2 zx
        {
            get { return new ulong2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ulong2 zy
        {
            get { return new ulong2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ulong2 zz
        {
            get { return new ulong2(this.s2, this.s2); }
        }

        public ulong3 xxx
        {
            get { return new ulong3(this.s0, this.s0, this.s0); }
        }

        public ulong3 xxy
        {
            get { return new ulong3(this.s0, this.s0, this.s1); }
        }

        public ulong3 xxz
        {
            get { return new ulong3(this.s0, this.s0, this.s2); }
        }

        public ulong3 xyx
        {
            get { return new ulong3(this.s0, this.s1, this.s0); }
        }

        public ulong3 xyy
        {
            get { return new ulong3(this.s0, this.s1, this.s1); }
        }

        public ulong3 xyz
        {
            get { return new ulong3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 xzx
        {
            get { return new ulong3(this.s0, this.s2, this.s0); }
        }

        public ulong3 xzy
        {
            get { return new ulong3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 xzz
        {
            get { return new ulong3(this.s0, this.s2, this.s2); }
        }

        public ulong3 yxx
        {
            get { return new ulong3(this.s1, this.s0, this.s0); }
        }

        public ulong3 yxy
        {
            get { return new ulong3(this.s1, this.s0, this.s1); }
        }

        public ulong3 yxz
        {
            get { return new ulong3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 yyx
        {
            get { return new ulong3(this.s1, this.s1, this.s0); }
        }

        public ulong3 yyy
        {
            get { return new ulong3(this.s1, this.s1, this.s1); }
        }

        public ulong3 yyz
        {
            get { return new ulong3(this.s1, this.s1, this.s2); }
        }

        public ulong3 yzx
        {
            get { return new ulong3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 yzy
        {
            get { return new ulong3(this.s1, this.s2, this.s1); }
        }

        public ulong3 yzz
        {
            get { return new ulong3(this.s1, this.s2, this.s2); }
        }

        public ulong3 zxx
        {
            get { return new ulong3(this.s2, this.s0, this.s0); }
        }

        public ulong3 zxy
        {
            get { return new ulong3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 zxz
        {
            get { return new ulong3(this.s2, this.s0, this.s2); }
        }

        public ulong3 zyx
        {
            get { return new ulong3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 zyy
        {
            get { return new ulong3(this.s2, this.s1, this.s1); }
        }

        public ulong3 zyz
        {
            get { return new ulong3(this.s2, this.s1, this.s2); }
        }

        public ulong3 zzx
        {
            get { return new ulong3(this.s2, this.s2, this.s0); }
        }

        public ulong3 zzy
        {
            get { return new ulong3(this.s2, this.s2, this.s1); }
        }

        public ulong3 zzz
        {
            get { return new ulong3(this.s2, this.s2, this.s2); }
        }

        public ulong this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 24; }
        }

        // IEquatable

        public bool Equals(ulong3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ulong3 && Equals((ulong3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static ulong3 operator +(ulong3 a, ulong3 b) => new ulong3((ulong)(a.s0+b.s0), (ulong)(a.s1+b.s1), (ulong)(a.s2+b.s2));

        public static ulong3 operator -(ulong3 a, ulong3 b) => new ulong3((ulong)(a.s0-b.s0), (ulong)(a.s1-b.s1), (ulong)(a.s2-b.s2));

        public static ulong3 operator *(ulong3 a, ulong3 b) => new ulong3((ulong)(a.s0*b.s0), (ulong)(a.s1*b.s1), (ulong)(a.s2*b.s2));

        public static ulong3 operator /(ulong3 a, ulong3 b) => new ulong3((ulong)(a.s0/b.s0), (ulong)(a.s1/b.s1), (ulong)(a.s2/b.s2));

        public static long3 operator ==(ulong3 a, ulong3 b) => new long3(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L);

        public static long3 operator !=(ulong3 a, ulong3 b) => new long3(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L);

        public static long3 operator <(ulong3 a, ulong3 b) => new long3(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L);

        public static long3 operator <=(ulong3 a, ulong3 b) => new long3(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L);

        public static long3 operator >(ulong3 a, ulong3 b) => new long3(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L);

        public static long3 operator >=(ulong3 a, ulong3 b) => new long3(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L);

        public static ulong3 operator &(ulong3 a, ulong3 b) => new ulong3((ulong)(a.s0&b.s0), (ulong)(a.s1&b.s1), (ulong)(a.s2&b.s2));

        public static ulong3 operator |(ulong3 a, ulong3 b) => new ulong3((ulong)(a.s0|b.s0), (ulong)(a.s1|b.s1), (ulong)(a.s2|b.s2));

        public static ulong3 operator ^(ulong3 a, ulong3 b) => new ulong3((ulong)(a.s0^b.s0), (ulong)(a.s1^b.s1), (ulong)(a.s2^b.s2));

        public static ulong3 operator +(ulong3 a) => a;

        public static ulong3 operator ~(ulong3 a) => new ulong3((ulong)(~a.s0), (ulong)(~a.s1), (ulong)(~a.s2));

        public static ulong3 operator ++(ulong3 a) => new ulong3((ulong)(a.s0+1), (ulong)(a.s1+1), (ulong)(a.s2+1));

        public static ulong3 operator --(ulong3 a) => new ulong3((ulong)(a.s0-1), (ulong)(a.s1-1), (ulong)(a.s2-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct ulong4: IVectorType, IEquatable<ulong4>
    {
        [FieldOffset(0)]
        public ulong s0;
        [FieldOffset(8)]
        public ulong s1;
        [FieldOffset(16)]
        public ulong s2;
        [FieldOffset(24)]
        public ulong s3;

        public ulong4(ulong v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public ulong4(ulong4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public ulong4(ulong v0, ulong3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public ulong4(ulong2 v0, ulong2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public ulong4(ulong3 v0, ulong v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public ulong4(ulong v0, ulong v1, ulong2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public ulong4(ulong v0, ulong2 v1, ulong v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public ulong4(ulong2 v0, ulong v1, ulong v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public ulong4(ulong v0, ulong v1, ulong v2, ulong v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public ulong x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public ulong y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public ulong z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public ulong w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public ulong2 xx
        {
            get { return new ulong2(this.s0, this.s0); }
        }

        public ulong2 xy
        {
            get { return new ulong2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ulong2 xz
        {
            get { return new ulong2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ulong2 xw
        {
            get { return new ulong2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public ulong2 yx
        {
            get { return new ulong2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ulong2 yy
        {
            get { return new ulong2(this.s1, this.s1); }
        }

        public ulong2 yz
        {
            get { return new ulong2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ulong2 yw
        {
            get { return new ulong2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public ulong2 zx
        {
            get { return new ulong2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ulong2 zy
        {
            get { return new ulong2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ulong2 zz
        {
            get { return new ulong2(this.s2, this.s2); }
        }

        public ulong2 zw
        {
            get { return new ulong2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public ulong2 wx
        {
            get { return new ulong2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public ulong2 wy
        {
            get { return new ulong2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public ulong2 wz
        {
            get { return new ulong2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public ulong2 ww
        {
            get { return new ulong2(this.s3, this.s3); }
        }

        public ulong3 xxx
        {
            get { return new ulong3(this.s0, this.s0, this.s0); }
        }

        public ulong3 xxy
        {
            get { return new ulong3(this.s0, this.s0, this.s1); }
        }

        public ulong3 xxz
        {
            get { return new ulong3(this.s0, this.s0, this.s2); }
        }

        public ulong3 xxw
        {
            get { return new ulong3(this.s0, this.s0, this.s3); }
        }

        public ulong3 xyx
        {
            get { return new ulong3(this.s0, this.s1, this.s0); }
        }

        public ulong3 xyy
        {
            get { return new ulong3(this.s0, this.s1, this.s1); }
        }

        public ulong3 xyz
        {
            get { return new ulong3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 xyw
        {
            get { return new ulong3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ulong3 xzx
        {
            get { return new ulong3(this.s0, this.s2, this.s0); }
        }

        public ulong3 xzy
        {
            get { return new ulong3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 xzz
        {
            get { return new ulong3(this.s0, this.s2, this.s2); }
        }

        public ulong3 xzw
        {
            get { return new ulong3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ulong3 xwx
        {
            get { return new ulong3(this.s0, this.s3, this.s0); }
        }

        public ulong3 xwy
        {
            get { return new ulong3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 xwz
        {
            get { return new ulong3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 xww
        {
            get { return new ulong3(this.s0, this.s3, this.s3); }
        }

        public ulong3 yxx
        {
            get { return new ulong3(this.s1, this.s0, this.s0); }
        }

        public ulong3 yxy
        {
            get { return new ulong3(this.s1, this.s0, this.s1); }
        }

        public ulong3 yxz
        {
            get { return new ulong3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 yxw
        {
            get { return new ulong3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ulong3 yyx
        {
            get { return new ulong3(this.s1, this.s1, this.s0); }
        }

        public ulong3 yyy
        {
            get { return new ulong3(this.s1, this.s1, this.s1); }
        }

        public ulong3 yyz
        {
            get { return new ulong3(this.s1, this.s1, this.s2); }
        }

        public ulong3 yyw
        {
            get { return new ulong3(this.s1, this.s1, this.s3); }
        }

        public ulong3 yzx
        {
            get { return new ulong3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 yzy
        {
            get { return new ulong3(this.s1, this.s2, this.s1); }
        }

        public ulong3 yzz
        {
            get { return new ulong3(this.s1, this.s2, this.s2); }
        }

        public ulong3 yzw
        {
            get { return new ulong3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ulong3 ywx
        {
            get { return new ulong3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 ywy
        {
            get { return new ulong3(this.s1, this.s3, this.s1); }
        }

        public ulong3 ywz
        {
            get { return new ulong3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 yww
        {
            get { return new ulong3(this.s1, this.s3, this.s3); }
        }

        public ulong3 zxx
        {
            get { return new ulong3(this.s2, this.s0, this.s0); }
        }

        public ulong3 zxy
        {
            get { return new ulong3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 zxz
        {
            get { return new ulong3(this.s2, this.s0, this.s2); }
        }

        public ulong3 zxw
        {
            get { return new ulong3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ulong3 zyx
        {
            get { return new ulong3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 zyy
        {
            get { return new ulong3(this.s2, this.s1, this.s1); }
        }

        public ulong3 zyz
        {
            get { return new ulong3(this.s2, this.s1, this.s2); }
        }

        public ulong3 zyw
        {
            get { return new ulong3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public ulong3 zzx
        {
            get { return new ulong3(this.s2, this.s2, this.s0); }
        }

        public ulong3 zzy
        {
            get { return new ulong3(this.s2, this.s2, this.s1); }
        }

        public ulong3 zzz
        {
            get { return new ulong3(this.s2, this.s2, this.s2); }
        }

        public ulong3 zzw
        {
            get { return new ulong3(this.s2, this.s2, this.s3); }
        }

        public ulong3 zwx
        {
            get { return new ulong3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 zwy
        {
            get { return new ulong3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 zwz
        {
            get { return new ulong3(this.s2, this.s3, this.s2); }
        }

        public ulong3 zww
        {
            get { return new ulong3(this.s2, this.s3, this.s3); }
        }

        public ulong3 wxx
        {
            get { return new ulong3(this.s3, this.s0, this.s0); }
        }

        public ulong3 wxy
        {
            get { return new ulong3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 wxz
        {
            get { return new ulong3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 wxw
        {
            get { return new ulong3(this.s3, this.s0, this.s3); }
        }

        public ulong3 wyx
        {
            get { return new ulong3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 wyy
        {
            get { return new ulong3(this.s3, this.s1, this.s1); }
        }

        public ulong3 wyz
        {
            get { return new ulong3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public ulong3 wyw
        {
            get { return new ulong3(this.s3, this.s1, this.s3); }
        }

        public ulong3 wzx
        {
            get { return new ulong3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public ulong3 wzy
        {
            get { return new ulong3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public ulong3 wzz
        {
            get { return new ulong3(this.s3, this.s2, this.s2); }
        }

        public ulong3 wzw
        {
            get { return new ulong3(this.s3, this.s2, this.s3); }
        }

        public ulong3 wwx
        {
            get { return new ulong3(this.s3, this.s3, this.s0); }
        }

        public ulong3 wwy
        {
            get { return new ulong3(this.s3, this.s3, this.s1); }
        }

        public ulong3 wwz
        {
            get { return new ulong3(this.s3, this.s3, this.s2); }
        }

        public ulong3 www
        {
            get { return new ulong3(this.s3, this.s3, this.s3); }
        }

        public ulong4 xxxx
        {
            get { return new ulong4(this.s0, this.s0, this.s0, this.s0); }
        }

        public ulong4 xxxy
        {
            get { return new ulong4(this.s0, this.s0, this.s0, this.s1); }
        }

        public ulong4 xxxz
        {
            get { return new ulong4(this.s0, this.s0, this.s0, this.s2); }
        }

        public ulong4 xxxw
        {
            get { return new ulong4(this.s0, this.s0, this.s0, this.s3); }
        }

        public ulong4 xxyx
        {
            get { return new ulong4(this.s0, this.s0, this.s1, this.s0); }
        }

        public ulong4 xxyy
        {
            get { return new ulong4(this.s0, this.s0, this.s1, this.s1); }
        }

        public ulong4 xxyz
        {
            get { return new ulong4(this.s0, this.s0, this.s1, this.s2); }
        }

        public ulong4 xxyw
        {
            get { return new ulong4(this.s0, this.s0, this.s1, this.s3); }
        }

        public ulong4 xxzx
        {
            get { return new ulong4(this.s0, this.s0, this.s2, this.s0); }
        }

        public ulong4 xxzy
        {
            get { return new ulong4(this.s0, this.s0, this.s2, this.s1); }
        }

        public ulong4 xxzz
        {
            get { return new ulong4(this.s0, this.s0, this.s2, this.s2); }
        }

        public ulong4 xxzw
        {
            get { return new ulong4(this.s0, this.s0, this.s2, this.s3); }
        }

        public ulong4 xxwx
        {
            get { return new ulong4(this.s0, this.s0, this.s3, this.s0); }
        }

        public ulong4 xxwy
        {
            get { return new ulong4(this.s0, this.s0, this.s3, this.s1); }
        }

        public ulong4 xxwz
        {
            get { return new ulong4(this.s0, this.s0, this.s3, this.s2); }
        }

        public ulong4 xxww
        {
            get { return new ulong4(this.s0, this.s0, this.s3, this.s3); }
        }

        public ulong4 xyxx
        {
            get { return new ulong4(this.s0, this.s1, this.s0, this.s0); }
        }

        public ulong4 xyxy
        {
            get { return new ulong4(this.s0, this.s1, this.s0, this.s1); }
        }

        public ulong4 xyxz
        {
            get { return new ulong4(this.s0, this.s1, this.s0, this.s2); }
        }

        public ulong4 xyxw
        {
            get { return new ulong4(this.s0, this.s1, this.s0, this.s3); }
        }

        public ulong4 xyyx
        {
            get { return new ulong4(this.s0, this.s1, this.s1, this.s0); }
        }

        public ulong4 xyyy
        {
            get { return new ulong4(this.s0, this.s1, this.s1, this.s1); }
        }

        public ulong4 xyyz
        {
            get { return new ulong4(this.s0, this.s1, this.s1, this.s2); }
        }

        public ulong4 xyyw
        {
            get { return new ulong4(this.s0, this.s1, this.s1, this.s3); }
        }

        public ulong4 xyzx
        {
            get { return new ulong4(this.s0, this.s1, this.s2, this.s0); }
        }

        public ulong4 xyzy
        {
            get { return new ulong4(this.s0, this.s1, this.s2, this.s1); }
        }

        public ulong4 xyzz
        {
            get { return new ulong4(this.s0, this.s1, this.s2, this.s2); }
        }

        public ulong4 xyzw
        {
            get { return new ulong4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ulong4 xywx
        {
            get { return new ulong4(this.s0, this.s1, this.s3, this.s0); }
        }

        public ulong4 xywy
        {
            get { return new ulong4(this.s0, this.s1, this.s3, this.s1); }
        }

        public ulong4 xywz
        {
            get { return new ulong4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ulong4 xyww
        {
            get { return new ulong4(this.s0, this.s1, this.s3, this.s3); }
        }

        public ulong4 xzxx
        {
            get { return new ulong4(this.s0, this.s2, this.s0, this.s0); }
        }

        public ulong4 xzxy
        {
            get { return new ulong4(this.s0, this.s2, this.s0, this.s1); }
        }

        public ulong4 xzxz
        {
            get { return new ulong4(this.s0, this.s2, this.s0, this.s2); }
        }

        public ulong4 xzxw
        {
            get { return new ulong4(this.s0, this.s2, this.s0, this.s3); }
        }

        public ulong4 xzyx
        {
            get { return new ulong4(this.s0, this.s2, this.s1, this.s0); }
        }

        public ulong4 xzyy
        {
            get { return new ulong4(this.s0, this.s2, this.s1, this.s1); }
        }

        public ulong4 xzyz
        {
            get { return new ulong4(this.s0, this.s2, this.s1, this.s2); }
        }

        public ulong4 xzyw
        {
            get { return new ulong4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ulong4 xzzx
        {
            get { return new ulong4(this.s0, this.s2, this.s2, this.s0); }
        }

        public ulong4 xzzy
        {
            get { return new ulong4(this.s0, this.s2, this.s2, this.s1); }
        }

        public ulong4 xzzz
        {
            get { return new ulong4(this.s0, this.s2, this.s2, this.s2); }
        }

        public ulong4 xzzw
        {
            get { return new ulong4(this.s0, this.s2, this.s2, this.s3); }
        }

        public ulong4 xzwx
        {
            get { return new ulong4(this.s0, this.s2, this.s3, this.s0); }
        }

        public ulong4 xzwy
        {
            get { return new ulong4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ulong4 xzwz
        {
            get { return new ulong4(this.s0, this.s2, this.s3, this.s2); }
        }

        public ulong4 xzww
        {
            get { return new ulong4(this.s0, this.s2, this.s3, this.s3); }
        }

        public ulong4 xwxx
        {
            get { return new ulong4(this.s0, this.s3, this.s0, this.s0); }
        }

        public ulong4 xwxy
        {
            get { return new ulong4(this.s0, this.s3, this.s0, this.s1); }
        }

        public ulong4 xwxz
        {
            get { return new ulong4(this.s0, this.s3, this.s0, this.s2); }
        }

        public ulong4 xwxw
        {
            get { return new ulong4(this.s0, this.s3, this.s0, this.s3); }
        }

        public ulong4 xwyx
        {
            get { return new ulong4(this.s0, this.s3, this.s1, this.s0); }
        }

        public ulong4 xwyy
        {
            get { return new ulong4(this.s0, this.s3, this.s1, this.s1); }
        }

        public ulong4 xwyz
        {
            get { return new ulong4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ulong4 xwyw
        {
            get { return new ulong4(this.s0, this.s3, this.s1, this.s3); }
        }

        public ulong4 xwzx
        {
            get { return new ulong4(this.s0, this.s3, this.s2, this.s0); }
        }

        public ulong4 xwzy
        {
            get { return new ulong4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ulong4 xwzz
        {
            get { return new ulong4(this.s0, this.s3, this.s2, this.s2); }
        }

        public ulong4 xwzw
        {
            get { return new ulong4(this.s0, this.s3, this.s2, this.s3); }
        }

        public ulong4 xwwx
        {
            get { return new ulong4(this.s0, this.s3, this.s3, this.s0); }
        }

        public ulong4 xwwy
        {
            get { return new ulong4(this.s0, this.s3, this.s3, this.s1); }
        }

        public ulong4 xwwz
        {
            get { return new ulong4(this.s0, this.s3, this.s3, this.s2); }
        }

        public ulong4 xwww
        {
            get { return new ulong4(this.s0, this.s3, this.s3, this.s3); }
        }

        public ulong4 yxxx
        {
            get { return new ulong4(this.s1, this.s0, this.s0, this.s0); }
        }

        public ulong4 yxxy
        {
            get { return new ulong4(this.s1, this.s0, this.s0, this.s1); }
        }

        public ulong4 yxxz
        {
            get { return new ulong4(this.s1, this.s0, this.s0, this.s2); }
        }

        public ulong4 yxxw
        {
            get { return new ulong4(this.s1, this.s0, this.s0, this.s3); }
        }

        public ulong4 yxyx
        {
            get { return new ulong4(this.s1, this.s0, this.s1, this.s0); }
        }

        public ulong4 yxyy
        {
            get { return new ulong4(this.s1, this.s0, this.s1, this.s1); }
        }

        public ulong4 yxyz
        {
            get { return new ulong4(this.s1, this.s0, this.s1, this.s2); }
        }

        public ulong4 yxyw
        {
            get { return new ulong4(this.s1, this.s0, this.s1, this.s3); }
        }

        public ulong4 yxzx
        {
            get { return new ulong4(this.s1, this.s0, this.s2, this.s0); }
        }

        public ulong4 yxzy
        {
            get { return new ulong4(this.s1, this.s0, this.s2, this.s1); }
        }

        public ulong4 yxzz
        {
            get { return new ulong4(this.s1, this.s0, this.s2, this.s2); }
        }

        public ulong4 yxzw
        {
            get { return new ulong4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ulong4 yxwx
        {
            get { return new ulong4(this.s1, this.s0, this.s3, this.s0); }
        }

        public ulong4 yxwy
        {
            get { return new ulong4(this.s1, this.s0, this.s3, this.s1); }
        }

        public ulong4 yxwz
        {
            get { return new ulong4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ulong4 yxww
        {
            get { return new ulong4(this.s1, this.s0, this.s3, this.s3); }
        }

        public ulong4 yyxx
        {
            get { return new ulong4(this.s1, this.s1, this.s0, this.s0); }
        }

        public ulong4 yyxy
        {
            get { return new ulong4(this.s1, this.s1, this.s0, this.s1); }
        }

        public ulong4 yyxz
        {
            get { return new ulong4(this.s1, this.s1, this.s0, this.s2); }
        }

        public ulong4 yyxw
        {
            get { return new ulong4(this.s1, this.s1, this.s0, this.s3); }
        }

        public ulong4 yyyx
        {
            get { return new ulong4(this.s1, this.s1, this.s1, this.s0); }
        }

        public ulong4 yyyy
        {
            get { return new ulong4(this.s1, this.s1, this.s1, this.s1); }
        }

        public ulong4 yyyz
        {
            get { return new ulong4(this.s1, this.s1, this.s1, this.s2); }
        }

        public ulong4 yyyw
        {
            get { return new ulong4(this.s1, this.s1, this.s1, this.s3); }
        }

        public ulong4 yyzx
        {
            get { return new ulong4(this.s1, this.s1, this.s2, this.s0); }
        }

        public ulong4 yyzy
        {
            get { return new ulong4(this.s1, this.s1, this.s2, this.s1); }
        }

        public ulong4 yyzz
        {
            get { return new ulong4(this.s1, this.s1, this.s2, this.s2); }
        }

        public ulong4 yyzw
        {
            get { return new ulong4(this.s1, this.s1, this.s2, this.s3); }
        }

        public ulong4 yywx
        {
            get { return new ulong4(this.s1, this.s1, this.s3, this.s0); }
        }

        public ulong4 yywy
        {
            get { return new ulong4(this.s1, this.s1, this.s3, this.s1); }
        }

        public ulong4 yywz
        {
            get { return new ulong4(this.s1, this.s1, this.s3, this.s2); }
        }

        public ulong4 yyww
        {
            get { return new ulong4(this.s1, this.s1, this.s3, this.s3); }
        }

        public ulong4 yzxx
        {
            get { return new ulong4(this.s1, this.s2, this.s0, this.s0); }
        }

        public ulong4 yzxy
        {
            get { return new ulong4(this.s1, this.s2, this.s0, this.s1); }
        }

        public ulong4 yzxz
        {
            get { return new ulong4(this.s1, this.s2, this.s0, this.s2); }
        }

        public ulong4 yzxw
        {
            get { return new ulong4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ulong4 yzyx
        {
            get { return new ulong4(this.s1, this.s2, this.s1, this.s0); }
        }

        public ulong4 yzyy
        {
            get { return new ulong4(this.s1, this.s2, this.s1, this.s1); }
        }

        public ulong4 yzyz
        {
            get { return new ulong4(this.s1, this.s2, this.s1, this.s2); }
        }

        public ulong4 yzyw
        {
            get { return new ulong4(this.s1, this.s2, this.s1, this.s3); }
        }

        public ulong4 yzzx
        {
            get { return new ulong4(this.s1, this.s2, this.s2, this.s0); }
        }

        public ulong4 yzzy
        {
            get { return new ulong4(this.s1, this.s2, this.s2, this.s1); }
        }

        public ulong4 yzzz
        {
            get { return new ulong4(this.s1, this.s2, this.s2, this.s2); }
        }

        public ulong4 yzzw
        {
            get { return new ulong4(this.s1, this.s2, this.s2, this.s3); }
        }

        public ulong4 yzwx
        {
            get { return new ulong4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ulong4 yzwy
        {
            get { return new ulong4(this.s1, this.s2, this.s3, this.s1); }
        }

        public ulong4 yzwz
        {
            get { return new ulong4(this.s1, this.s2, this.s3, this.s2); }
        }

        public ulong4 yzww
        {
            get { return new ulong4(this.s1, this.s2, this.s3, this.s3); }
        }

        public ulong4 ywxx
        {
            get { return new ulong4(this.s1, this.s3, this.s0, this.s0); }
        }

        public ulong4 ywxy
        {
            get { return new ulong4(this.s1, this.s3, this.s0, this.s1); }
        }

        public ulong4 ywxz
        {
            get { return new ulong4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ulong4 ywxw
        {
            get { return new ulong4(this.s1, this.s3, this.s0, this.s3); }
        }

        public ulong4 ywyx
        {
            get { return new ulong4(this.s1, this.s3, this.s1, this.s0); }
        }

        public ulong4 ywyy
        {
            get { return new ulong4(this.s1, this.s3, this.s1, this.s1); }
        }

        public ulong4 ywyz
        {
            get { return new ulong4(this.s1, this.s3, this.s1, this.s2); }
        }

        public ulong4 ywyw
        {
            get { return new ulong4(this.s1, this.s3, this.s1, this.s3); }
        }

        public ulong4 ywzx
        {
            get { return new ulong4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ulong4 ywzy
        {
            get { return new ulong4(this.s1, this.s3, this.s2, this.s1); }
        }

        public ulong4 ywzz
        {
            get { return new ulong4(this.s1, this.s3, this.s2, this.s2); }
        }

        public ulong4 ywzw
        {
            get { return new ulong4(this.s1, this.s3, this.s2, this.s3); }
        }

        public ulong4 ywwx
        {
            get { return new ulong4(this.s1, this.s3, this.s3, this.s0); }
        }

        public ulong4 ywwy
        {
            get { return new ulong4(this.s1, this.s3, this.s3, this.s1); }
        }

        public ulong4 ywwz
        {
            get { return new ulong4(this.s1, this.s3, this.s3, this.s2); }
        }

        public ulong4 ywww
        {
            get { return new ulong4(this.s1, this.s3, this.s3, this.s3); }
        }

        public ulong4 zxxx
        {
            get { return new ulong4(this.s2, this.s0, this.s0, this.s0); }
        }

        public ulong4 zxxy
        {
            get { return new ulong4(this.s2, this.s0, this.s0, this.s1); }
        }

        public ulong4 zxxz
        {
            get { return new ulong4(this.s2, this.s0, this.s0, this.s2); }
        }

        public ulong4 zxxw
        {
            get { return new ulong4(this.s2, this.s0, this.s0, this.s3); }
        }

        public ulong4 zxyx
        {
            get { return new ulong4(this.s2, this.s0, this.s1, this.s0); }
        }

        public ulong4 zxyy
        {
            get { return new ulong4(this.s2, this.s0, this.s1, this.s1); }
        }

        public ulong4 zxyz
        {
            get { return new ulong4(this.s2, this.s0, this.s1, this.s2); }
        }

        public ulong4 zxyw
        {
            get { return new ulong4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ulong4 zxzx
        {
            get { return new ulong4(this.s2, this.s0, this.s2, this.s0); }
        }

        public ulong4 zxzy
        {
            get { return new ulong4(this.s2, this.s0, this.s2, this.s1); }
        }

        public ulong4 zxzz
        {
            get { return new ulong4(this.s2, this.s0, this.s2, this.s2); }
        }

        public ulong4 zxzw
        {
            get { return new ulong4(this.s2, this.s0, this.s2, this.s3); }
        }

        public ulong4 zxwx
        {
            get { return new ulong4(this.s2, this.s0, this.s3, this.s0); }
        }

        public ulong4 zxwy
        {
            get { return new ulong4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ulong4 zxwz
        {
            get { return new ulong4(this.s2, this.s0, this.s3, this.s2); }
        }

        public ulong4 zxww
        {
            get { return new ulong4(this.s2, this.s0, this.s3, this.s3); }
        }

        public ulong4 zyxx
        {
            get { return new ulong4(this.s2, this.s1, this.s0, this.s0); }
        }

        public ulong4 zyxy
        {
            get { return new ulong4(this.s2, this.s1, this.s0, this.s1); }
        }

        public ulong4 zyxz
        {
            get { return new ulong4(this.s2, this.s1, this.s0, this.s2); }
        }

        public ulong4 zyxw
        {
            get { return new ulong4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public ulong4 zyyx
        {
            get { return new ulong4(this.s2, this.s1, this.s1, this.s0); }
        }

        public ulong4 zyyy
        {
            get { return new ulong4(this.s2, this.s1, this.s1, this.s1); }
        }

        public ulong4 zyyz
        {
            get { return new ulong4(this.s2, this.s1, this.s1, this.s2); }
        }

        public ulong4 zyyw
        {
            get { return new ulong4(this.s2, this.s1, this.s1, this.s3); }
        }

        public ulong4 zyzx
        {
            get { return new ulong4(this.s2, this.s1, this.s2, this.s0); }
        }

        public ulong4 zyzy
        {
            get { return new ulong4(this.s2, this.s1, this.s2, this.s1); }
        }

        public ulong4 zyzz
        {
            get { return new ulong4(this.s2, this.s1, this.s2, this.s2); }
        }

        public ulong4 zyzw
        {
            get { return new ulong4(this.s2, this.s1, this.s2, this.s3); }
        }

        public ulong4 zywx
        {
            get { return new ulong4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ulong4 zywy
        {
            get { return new ulong4(this.s2, this.s1, this.s3, this.s1); }
        }

        public ulong4 zywz
        {
            get { return new ulong4(this.s2, this.s1, this.s3, this.s2); }
        }

        public ulong4 zyww
        {
            get { return new ulong4(this.s2, this.s1, this.s3, this.s3); }
        }

        public ulong4 zzxx
        {
            get { return new ulong4(this.s2, this.s2, this.s0, this.s0); }
        }

        public ulong4 zzxy
        {
            get { return new ulong4(this.s2, this.s2, this.s0, this.s1); }
        }

        public ulong4 zzxz
        {
            get { return new ulong4(this.s2, this.s2, this.s0, this.s2); }
        }

        public ulong4 zzxw
        {
            get { return new ulong4(this.s2, this.s2, this.s0, this.s3); }
        }

        public ulong4 zzyx
        {
            get { return new ulong4(this.s2, this.s2, this.s1, this.s0); }
        }

        public ulong4 zzyy
        {
            get { return new ulong4(this.s2, this.s2, this.s1, this.s1); }
        }

        public ulong4 zzyz
        {
            get { return new ulong4(this.s2, this.s2, this.s1, this.s2); }
        }

        public ulong4 zzyw
        {
            get { return new ulong4(this.s2, this.s2, this.s1, this.s3); }
        }

        public ulong4 zzzx
        {
            get { return new ulong4(this.s2, this.s2, this.s2, this.s0); }
        }

        public ulong4 zzzy
        {
            get { return new ulong4(this.s2, this.s2, this.s2, this.s1); }
        }

        public ulong4 zzzz
        {
            get { return new ulong4(this.s2, this.s2, this.s2, this.s2); }
        }

        public ulong4 zzzw
        {
            get { return new ulong4(this.s2, this.s2, this.s2, this.s3); }
        }

        public ulong4 zzwx
        {
            get { return new ulong4(this.s2, this.s2, this.s3, this.s0); }
        }

        public ulong4 zzwy
        {
            get { return new ulong4(this.s2, this.s2, this.s3, this.s1); }
        }

        public ulong4 zzwz
        {
            get { return new ulong4(this.s2, this.s2, this.s3, this.s2); }
        }

        public ulong4 zzww
        {
            get { return new ulong4(this.s2, this.s2, this.s3, this.s3); }
        }

        public ulong4 zwxx
        {
            get { return new ulong4(this.s2, this.s3, this.s0, this.s0); }
        }

        public ulong4 zwxy
        {
            get { return new ulong4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ulong4 zwxz
        {
            get { return new ulong4(this.s2, this.s3, this.s0, this.s2); }
        }

        public ulong4 zwxw
        {
            get { return new ulong4(this.s2, this.s3, this.s0, this.s3); }
        }

        public ulong4 zwyx
        {
            get { return new ulong4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ulong4 zwyy
        {
            get { return new ulong4(this.s2, this.s3, this.s1, this.s1); }
        }

        public ulong4 zwyz
        {
            get { return new ulong4(this.s2, this.s3, this.s1, this.s2); }
        }

        public ulong4 zwyw
        {
            get { return new ulong4(this.s2, this.s3, this.s1, this.s3); }
        }

        public ulong4 zwzx
        {
            get { return new ulong4(this.s2, this.s3, this.s2, this.s0); }
        }

        public ulong4 zwzy
        {
            get { return new ulong4(this.s2, this.s3, this.s2, this.s1); }
        }

        public ulong4 zwzz
        {
            get { return new ulong4(this.s2, this.s3, this.s2, this.s2); }
        }

        public ulong4 zwzw
        {
            get { return new ulong4(this.s2, this.s3, this.s2, this.s3); }
        }

        public ulong4 zwwx
        {
            get { return new ulong4(this.s2, this.s3, this.s3, this.s0); }
        }

        public ulong4 zwwy
        {
            get { return new ulong4(this.s2, this.s3, this.s3, this.s1); }
        }

        public ulong4 zwwz
        {
            get { return new ulong4(this.s2, this.s3, this.s3, this.s2); }
        }

        public ulong4 zwww
        {
            get { return new ulong4(this.s2, this.s3, this.s3, this.s3); }
        }

        public ulong4 wxxx
        {
            get { return new ulong4(this.s3, this.s0, this.s0, this.s0); }
        }

        public ulong4 wxxy
        {
            get { return new ulong4(this.s3, this.s0, this.s0, this.s1); }
        }

        public ulong4 wxxz
        {
            get { return new ulong4(this.s3, this.s0, this.s0, this.s2); }
        }

        public ulong4 wxxw
        {
            get { return new ulong4(this.s3, this.s0, this.s0, this.s3); }
        }

        public ulong4 wxyx
        {
            get { return new ulong4(this.s3, this.s0, this.s1, this.s0); }
        }

        public ulong4 wxyy
        {
            get { return new ulong4(this.s3, this.s0, this.s1, this.s1); }
        }

        public ulong4 wxyz
        {
            get { return new ulong4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ulong4 wxyw
        {
            get { return new ulong4(this.s3, this.s0, this.s1, this.s3); }
        }

        public ulong4 wxzx
        {
            get { return new ulong4(this.s3, this.s0, this.s2, this.s0); }
        }

        public ulong4 wxzy
        {
            get { return new ulong4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ulong4 wxzz
        {
            get { return new ulong4(this.s3, this.s0, this.s2, this.s2); }
        }

        public ulong4 wxzw
        {
            get { return new ulong4(this.s3, this.s0, this.s2, this.s3); }
        }

        public ulong4 wxwx
        {
            get { return new ulong4(this.s3, this.s0, this.s3, this.s0); }
        }

        public ulong4 wxwy
        {
            get { return new ulong4(this.s3, this.s0, this.s3, this.s1); }
        }

        public ulong4 wxwz
        {
            get { return new ulong4(this.s3, this.s0, this.s3, this.s2); }
        }

        public ulong4 wxww
        {
            get { return new ulong4(this.s3, this.s0, this.s3, this.s3); }
        }

        public ulong4 wyxx
        {
            get { return new ulong4(this.s3, this.s1, this.s0, this.s0); }
        }

        public ulong4 wyxy
        {
            get { return new ulong4(this.s3, this.s1, this.s0, this.s1); }
        }

        public ulong4 wyxz
        {
            get { return new ulong4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public ulong4 wyxw
        {
            get { return new ulong4(this.s3, this.s1, this.s0, this.s3); }
        }

        public ulong4 wyyx
        {
            get { return new ulong4(this.s3, this.s1, this.s1, this.s0); }
        }

        public ulong4 wyyy
        {
            get { return new ulong4(this.s3, this.s1, this.s1, this.s1); }
        }

        public ulong4 wyyz
        {
            get { return new ulong4(this.s3, this.s1, this.s1, this.s2); }
        }

        public ulong4 wyyw
        {
            get { return new ulong4(this.s3, this.s1, this.s1, this.s3); }
        }

        public ulong4 wyzx
        {
            get { return new ulong4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ulong4 wyzy
        {
            get { return new ulong4(this.s3, this.s1, this.s2, this.s1); }
        }

        public ulong4 wyzz
        {
            get { return new ulong4(this.s3, this.s1, this.s2, this.s2); }
        }

        public ulong4 wyzw
        {
            get { return new ulong4(this.s3, this.s1, this.s2, this.s3); }
        }

        public ulong4 wywx
        {
            get { return new ulong4(this.s3, this.s1, this.s3, this.s0); }
        }

        public ulong4 wywy
        {
            get { return new ulong4(this.s3, this.s1, this.s3, this.s1); }
        }

        public ulong4 wywz
        {
            get { return new ulong4(this.s3, this.s1, this.s3, this.s2); }
        }

        public ulong4 wyww
        {
            get { return new ulong4(this.s3, this.s1, this.s3, this.s3); }
        }

        public ulong4 wzxx
        {
            get { return new ulong4(this.s3, this.s2, this.s0, this.s0); }
        }

        public ulong4 wzxy
        {
            get { return new ulong4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public ulong4 wzxz
        {
            get { return new ulong4(this.s3, this.s2, this.s0, this.s2); }
        }

        public ulong4 wzxw
        {
            get { return new ulong4(this.s3, this.s2, this.s0, this.s3); }
        }

        public ulong4 wzyx
        {
            get { return new ulong4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public ulong4 wzyy
        {
            get { return new ulong4(this.s3, this.s2, this.s1, this.s1); }
        }

        public ulong4 wzyz
        {
            get { return new ulong4(this.s3, this.s2, this.s1, this.s2); }
        }

        public ulong4 wzyw
        {
            get { return new ulong4(this.s3, this.s2, this.s1, this.s3); }
        }

        public ulong4 wzzx
        {
            get { return new ulong4(this.s3, this.s2, this.s2, this.s0); }
        }

        public ulong4 wzzy
        {
            get { return new ulong4(this.s3, this.s2, this.s2, this.s1); }
        }

        public ulong4 wzzz
        {
            get { return new ulong4(this.s3, this.s2, this.s2, this.s2); }
        }

        public ulong4 wzzw
        {
            get { return new ulong4(this.s3, this.s2, this.s2, this.s3); }
        }

        public ulong4 wzwx
        {
            get { return new ulong4(this.s3, this.s2, this.s3, this.s0); }
        }

        public ulong4 wzwy
        {
            get { return new ulong4(this.s3, this.s2, this.s3, this.s1); }
        }

        public ulong4 wzwz
        {
            get { return new ulong4(this.s3, this.s2, this.s3, this.s2); }
        }

        public ulong4 wzww
        {
            get { return new ulong4(this.s3, this.s2, this.s3, this.s3); }
        }

        public ulong4 wwxx
        {
            get { return new ulong4(this.s3, this.s3, this.s0, this.s0); }
        }

        public ulong4 wwxy
        {
            get { return new ulong4(this.s3, this.s3, this.s0, this.s1); }
        }

        public ulong4 wwxz
        {
            get { return new ulong4(this.s3, this.s3, this.s0, this.s2); }
        }

        public ulong4 wwxw
        {
            get { return new ulong4(this.s3, this.s3, this.s0, this.s3); }
        }

        public ulong4 wwyx
        {
            get { return new ulong4(this.s3, this.s3, this.s1, this.s0); }
        }

        public ulong4 wwyy
        {
            get { return new ulong4(this.s3, this.s3, this.s1, this.s1); }
        }

        public ulong4 wwyz
        {
            get { return new ulong4(this.s3, this.s3, this.s1, this.s2); }
        }

        public ulong4 wwyw
        {
            get { return new ulong4(this.s3, this.s3, this.s1, this.s3); }
        }

        public ulong4 wwzx
        {
            get { return new ulong4(this.s3, this.s3, this.s2, this.s0); }
        }

        public ulong4 wwzy
        {
            get { return new ulong4(this.s3, this.s3, this.s2, this.s1); }
        }

        public ulong4 wwzz
        {
            get { return new ulong4(this.s3, this.s3, this.s2, this.s2); }
        }

        public ulong4 wwzw
        {
            get { return new ulong4(this.s3, this.s3, this.s2, this.s3); }
        }

        public ulong4 wwwx
        {
            get { return new ulong4(this.s3, this.s3, this.s3, this.s0); }
        }

        public ulong4 wwwy
        {
            get { return new ulong4(this.s3, this.s3, this.s3, this.s1); }
        }

        public ulong4 wwwz
        {
            get { return new ulong4(this.s3, this.s3, this.s3, this.s2); }
        }

        public ulong4 wwww
        {
            get { return new ulong4(this.s3, this.s3, this.s3, this.s3); }
        }

        public ulong this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(ulong4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ulong4 && Equals((ulong4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static ulong4 operator +(ulong4 a, ulong4 b) => new ulong4((ulong)(a.s0+b.s0), (ulong)(a.s1+b.s1), (ulong)(a.s2+b.s2), (ulong)(a.s3+b.s3));

        public static ulong4 operator -(ulong4 a, ulong4 b) => new ulong4((ulong)(a.s0-b.s0), (ulong)(a.s1-b.s1), (ulong)(a.s2-b.s2), (ulong)(a.s3-b.s3));

        public static ulong4 operator *(ulong4 a, ulong4 b) => new ulong4((ulong)(a.s0*b.s0), (ulong)(a.s1*b.s1), (ulong)(a.s2*b.s2), (ulong)(a.s3*b.s3));

        public static ulong4 operator /(ulong4 a, ulong4 b) => new ulong4((ulong)(a.s0/b.s0), (ulong)(a.s1/b.s1), (ulong)(a.s2/b.s2), (ulong)(a.s3/b.s3));

        public static long4 operator ==(ulong4 a, ulong4 b) => new long4(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L);

        public static long4 operator !=(ulong4 a, ulong4 b) => new long4(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L);

        public static long4 operator <(ulong4 a, ulong4 b) => new long4(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L);

        public static long4 operator <=(ulong4 a, ulong4 b) => new long4(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L);

        public static long4 operator >(ulong4 a, ulong4 b) => new long4(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L);

        public static long4 operator >=(ulong4 a, ulong4 b) => new long4(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L);

        public static ulong4 operator &(ulong4 a, ulong4 b) => new ulong4((ulong)(a.s0&b.s0), (ulong)(a.s1&b.s1), (ulong)(a.s2&b.s2), (ulong)(a.s3&b.s3));

        public static ulong4 operator |(ulong4 a, ulong4 b) => new ulong4((ulong)(a.s0|b.s0), (ulong)(a.s1|b.s1), (ulong)(a.s2|b.s2), (ulong)(a.s3|b.s3));

        public static ulong4 operator ^(ulong4 a, ulong4 b) => new ulong4((ulong)(a.s0^b.s0), (ulong)(a.s1^b.s1), (ulong)(a.s2^b.s2), (ulong)(a.s3^b.s3));

        public static ulong4 operator +(ulong4 a) => a;

        public static ulong4 operator ~(ulong4 a) => new ulong4((ulong)(~a.s0), (ulong)(~a.s1), (ulong)(~a.s2), (ulong)(~a.s3));

        public static ulong4 operator ++(ulong4 a) => new ulong4((ulong)(a.s0+1), (ulong)(a.s1+1), (ulong)(a.s2+1), (ulong)(a.s3+1));

        public static ulong4 operator --(ulong4 a) => new ulong4((ulong)(a.s0-1), (ulong)(a.s1-1), (ulong)(a.s2-1), (ulong)(a.s3-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct ulong8: IVectorType, IEquatable<ulong8>
    {
        [FieldOffset(0)]
        public ulong s0;
        [FieldOffset(8)]
        public ulong s1;
        [FieldOffset(16)]
        public ulong s2;
        [FieldOffset(24)]
        public ulong s3;
        [FieldOffset(32)]
        public ulong s4;
        [FieldOffset(40)]
        public ulong s5;
        [FieldOffset(48)]
        public ulong s6;
        [FieldOffset(56)]
        public ulong s7;

        public ulong8(ulong v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public ulong8(ulong v0, ulong v1, ulong v2, ulong v3, ulong v4, ulong v5, ulong v6, ulong v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public ulong this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 64; }
        }

        // IEquatable

        public bool Equals(ulong8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ulong8 && Equals((ulong8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static ulong8 operator +(ulong8 a, ulong8 b) => new ulong8((ulong)(a.s0+b.s0), (ulong)(a.s1+b.s1), (ulong)(a.s2+b.s2), (ulong)(a.s3+b.s3), (ulong)(a.s4+b.s4), (ulong)(a.s5+b.s5), (ulong)(a.s6+b.s6), (ulong)(a.s7+b.s7));

        public static ulong8 operator -(ulong8 a, ulong8 b) => new ulong8((ulong)(a.s0-b.s0), (ulong)(a.s1-b.s1), (ulong)(a.s2-b.s2), (ulong)(a.s3-b.s3), (ulong)(a.s4-b.s4), (ulong)(a.s5-b.s5), (ulong)(a.s6-b.s6), (ulong)(a.s7-b.s7));

        public static ulong8 operator *(ulong8 a, ulong8 b) => new ulong8((ulong)(a.s0*b.s0), (ulong)(a.s1*b.s1), (ulong)(a.s2*b.s2), (ulong)(a.s3*b.s3), (ulong)(a.s4*b.s4), (ulong)(a.s5*b.s5), (ulong)(a.s6*b.s6), (ulong)(a.s7*b.s7));

        public static ulong8 operator /(ulong8 a, ulong8 b) => new ulong8((ulong)(a.s0/b.s0), (ulong)(a.s1/b.s1), (ulong)(a.s2/b.s2), (ulong)(a.s3/b.s3), (ulong)(a.s4/b.s4), (ulong)(a.s5/b.s5), (ulong)(a.s6/b.s6), (ulong)(a.s7/b.s7));

        public static long8 operator ==(ulong8 a, ulong8 b) => new long8(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L, a.s4==b.s4 ? -1L : 0L, a.s5==b.s5 ? -1L : 0L, a.s6==b.s6 ? -1L : 0L, a.s7==b.s7 ? -1L : 0L);

        public static long8 operator !=(ulong8 a, ulong8 b) => new long8(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L, a.s4!=b.s4 ? -1L : 0L, a.s5!=b.s5 ? -1L : 0L, a.s6!=b.s6 ? -1L : 0L, a.s7!=b.s7 ? -1L : 0L);

        public static long8 operator <(ulong8 a, ulong8 b) => new long8(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L, a.s4<b.s4 ? -1L : 0L, a.s5<b.s5 ? -1L : 0L, a.s6<b.s6 ? -1L : 0L, a.s7<b.s7 ? -1L : 0L);

        public static long8 operator <=(ulong8 a, ulong8 b) => new long8(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L, a.s4<=b.s4 ? -1L : 0L, a.s5<=b.s5 ? -1L : 0L, a.s6<=b.s6 ? -1L : 0L, a.s7<=b.s7 ? -1L : 0L);

        public static long8 operator >(ulong8 a, ulong8 b) => new long8(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L, a.s4>b.s4 ? -1L : 0L, a.s5>b.s5 ? -1L : 0L, a.s6>b.s6 ? -1L : 0L, a.s7>b.s7 ? -1L : 0L);

        public static long8 operator >=(ulong8 a, ulong8 b) => new long8(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L, a.s4>=b.s4 ? -1L : 0L, a.s5>=b.s5 ? -1L : 0L, a.s6>=b.s6 ? -1L : 0L, a.s7>=b.s7 ? -1L : 0L);

        public static ulong8 operator &(ulong8 a, ulong8 b) => new ulong8((ulong)(a.s0&b.s0), (ulong)(a.s1&b.s1), (ulong)(a.s2&b.s2), (ulong)(a.s3&b.s3), (ulong)(a.s4&b.s4), (ulong)(a.s5&b.s5), (ulong)(a.s6&b.s6), (ulong)(a.s7&b.s7));

        public static ulong8 operator |(ulong8 a, ulong8 b) => new ulong8((ulong)(a.s0|b.s0), (ulong)(a.s1|b.s1), (ulong)(a.s2|b.s2), (ulong)(a.s3|b.s3), (ulong)(a.s4|b.s4), (ulong)(a.s5|b.s5), (ulong)(a.s6|b.s6), (ulong)(a.s7|b.s7));

        public static ulong8 operator ^(ulong8 a, ulong8 b) => new ulong8((ulong)(a.s0^b.s0), (ulong)(a.s1^b.s1), (ulong)(a.s2^b.s2), (ulong)(a.s3^b.s3), (ulong)(a.s4^b.s4), (ulong)(a.s5^b.s5), (ulong)(a.s6^b.s6), (ulong)(a.s7^b.s7));

        public static ulong8 operator +(ulong8 a) => a;

        public static ulong8 operator ~(ulong8 a) => new ulong8((ulong)(~a.s0), (ulong)(~a.s1), (ulong)(~a.s2), (ulong)(~a.s3), (ulong)(~a.s4), (ulong)(~a.s5), (ulong)(~a.s6), (ulong)(~a.s7));

        public static ulong8 operator ++(ulong8 a) => new ulong8((ulong)(a.s0+1), (ulong)(a.s1+1), (ulong)(a.s2+1), (ulong)(a.s3+1), (ulong)(a.s4+1), (ulong)(a.s5+1), (ulong)(a.s6+1), (ulong)(a.s7+1));

        public static ulong8 operator --(ulong8 a) => new ulong8((ulong)(a.s0-1), (ulong)(a.s1-1), (ulong)(a.s2-1), (ulong)(a.s3-1), (ulong)(a.s4-1), (ulong)(a.s5-1), (ulong)(a.s6-1), (ulong)(a.s7-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct ulong16: IVectorType, IEquatable<ulong16>
    {
        [FieldOffset(0)]
        public ulong s0;
        [FieldOffset(8)]
        public ulong s1;
        [FieldOffset(16)]
        public ulong s2;
        [FieldOffset(24)]
        public ulong s3;
        [FieldOffset(32)]
        public ulong s4;
        [FieldOffset(40)]
        public ulong s5;
        [FieldOffset(48)]
        public ulong s6;
        [FieldOffset(56)]
        public ulong s7;
        [FieldOffset(64)]
        public ulong s8;
        [FieldOffset(72)]
        public ulong s9;
        [FieldOffset(80)]
        public ulong sa;
        [FieldOffset(88)]
        public ulong sb;
        [FieldOffset(96)]
        public ulong sc;
        [FieldOffset(104)]
        public ulong sd;
        [FieldOffset(112)]
        public ulong se;
        [FieldOffset(120)]
        public ulong sf;

        public ulong16(ulong v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public ulong16(ulong v0, ulong v1, ulong v2, ulong v3, ulong v4, ulong v5, ulong v6, ulong v7, ulong v8, ulong v9, ulong va, ulong vb, ulong vc, ulong vd, ulong ve, ulong vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public ulong sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public ulong sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public ulong sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public ulong sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public ulong sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public ulong sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public ulong this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 128; }
        }

        // IEquatable

        public bool Equals(ulong16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is ulong16 && Equals((ulong16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static ulong16 operator +(ulong16 a, ulong16 b) => new ulong16((ulong)(a.s0+b.s0), (ulong)(a.s1+b.s1), (ulong)(a.s2+b.s2), (ulong)(a.s3+b.s3), (ulong)(a.s4+b.s4), (ulong)(a.s5+b.s5), (ulong)(a.s6+b.s6), (ulong)(a.s7+b.s7), (ulong)(a.s8+b.s8), (ulong)(a.s9+b.s9), (ulong)(a.sa+b.sa), (ulong)(a.sb+b.sb), (ulong)(a.sc+b.sc), (ulong)(a.sd+b.sd), (ulong)(a.se+b.se), (ulong)(a.sf+b.sf));

        public static ulong16 operator -(ulong16 a, ulong16 b) => new ulong16((ulong)(a.s0-b.s0), (ulong)(a.s1-b.s1), (ulong)(a.s2-b.s2), (ulong)(a.s3-b.s3), (ulong)(a.s4-b.s4), (ulong)(a.s5-b.s5), (ulong)(a.s6-b.s6), (ulong)(a.s7-b.s7), (ulong)(a.s8-b.s8), (ulong)(a.s9-b.s9), (ulong)(a.sa-b.sa), (ulong)(a.sb-b.sb), (ulong)(a.sc-b.sc), (ulong)(a.sd-b.sd), (ulong)(a.se-b.se), (ulong)(a.sf-b.sf));

        public static ulong16 operator *(ulong16 a, ulong16 b) => new ulong16((ulong)(a.s0*b.s0), (ulong)(a.s1*b.s1), (ulong)(a.s2*b.s2), (ulong)(a.s3*b.s3), (ulong)(a.s4*b.s4), (ulong)(a.s5*b.s5), (ulong)(a.s6*b.s6), (ulong)(a.s7*b.s7), (ulong)(a.s8*b.s8), (ulong)(a.s9*b.s9), (ulong)(a.sa*b.sa), (ulong)(a.sb*b.sb), (ulong)(a.sc*b.sc), (ulong)(a.sd*b.sd), (ulong)(a.se*b.se), (ulong)(a.sf*b.sf));

        public static ulong16 operator /(ulong16 a, ulong16 b) => new ulong16((ulong)(a.s0/b.s0), (ulong)(a.s1/b.s1), (ulong)(a.s2/b.s2), (ulong)(a.s3/b.s3), (ulong)(a.s4/b.s4), (ulong)(a.s5/b.s5), (ulong)(a.s6/b.s6), (ulong)(a.s7/b.s7), (ulong)(a.s8/b.s8), (ulong)(a.s9/b.s9), (ulong)(a.sa/b.sa), (ulong)(a.sb/b.sb), (ulong)(a.sc/b.sc), (ulong)(a.sd/b.sd), (ulong)(a.se/b.se), (ulong)(a.sf/b.sf));

        public static long16 operator ==(ulong16 a, ulong16 b) => new long16(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L, a.s4==b.s4 ? -1L : 0L, a.s5==b.s5 ? -1L : 0L, a.s6==b.s6 ? -1L : 0L, a.s7==b.s7 ? -1L : 0L, a.s8==b.s8 ? -1L : 0L, a.s9==b.s9 ? -1L : 0L, a.sa==b.sa ? -1L : 0L, a.sb==b.sb ? -1L : 0L, a.sc==b.sc ? -1L : 0L, a.sd==b.sd ? -1L : 0L, a.se==b.se ? -1L : 0L, a.sf==b.sf ? -1L : 0L);

        public static long16 operator !=(ulong16 a, ulong16 b) => new long16(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L, a.s4!=b.s4 ? -1L : 0L, a.s5!=b.s5 ? -1L : 0L, a.s6!=b.s6 ? -1L : 0L, a.s7!=b.s7 ? -1L : 0L, a.s8!=b.s8 ? -1L : 0L, a.s9!=b.s9 ? -1L : 0L, a.sa!=b.sa ? -1L : 0L, a.sb!=b.sb ? -1L : 0L, a.sc!=b.sc ? -1L : 0L, a.sd!=b.sd ? -1L : 0L, a.se!=b.se ? -1L : 0L, a.sf!=b.sf ? -1L : 0L);

        public static long16 operator <(ulong16 a, ulong16 b) => new long16(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L, a.s4<b.s4 ? -1L : 0L, a.s5<b.s5 ? -1L : 0L, a.s6<b.s6 ? -1L : 0L, a.s7<b.s7 ? -1L : 0L, a.s8<b.s8 ? -1L : 0L, a.s9<b.s9 ? -1L : 0L, a.sa<b.sa ? -1L : 0L, a.sb<b.sb ? -1L : 0L, a.sc<b.sc ? -1L : 0L, a.sd<b.sd ? -1L : 0L, a.se<b.se ? -1L : 0L, a.sf<b.sf ? -1L : 0L);

        public static long16 operator <=(ulong16 a, ulong16 b) => new long16(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L, a.s4<=b.s4 ? -1L : 0L, a.s5<=b.s5 ? -1L : 0L, a.s6<=b.s6 ? -1L : 0L, a.s7<=b.s7 ? -1L : 0L, a.s8<=b.s8 ? -1L : 0L, a.s9<=b.s9 ? -1L : 0L, a.sa<=b.sa ? -1L : 0L, a.sb<=b.sb ? -1L : 0L, a.sc<=b.sc ? -1L : 0L, a.sd<=b.sd ? -1L : 0L, a.se<=b.se ? -1L : 0L, a.sf<=b.sf ? -1L : 0L);

        public static long16 operator >(ulong16 a, ulong16 b) => new long16(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L, a.s4>b.s4 ? -1L : 0L, a.s5>b.s5 ? -1L : 0L, a.s6>b.s6 ? -1L : 0L, a.s7>b.s7 ? -1L : 0L, a.s8>b.s8 ? -1L : 0L, a.s9>b.s9 ? -1L : 0L, a.sa>b.sa ? -1L : 0L, a.sb>b.sb ? -1L : 0L, a.sc>b.sc ? -1L : 0L, a.sd>b.sd ? -1L : 0L, a.se>b.se ? -1L : 0L, a.sf>b.sf ? -1L : 0L);

        public static long16 operator >=(ulong16 a, ulong16 b) => new long16(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L, a.s4>=b.s4 ? -1L : 0L, a.s5>=b.s5 ? -1L : 0L, a.s6>=b.s6 ? -1L : 0L, a.s7>=b.s7 ? -1L : 0L, a.s8>=b.s8 ? -1L : 0L, a.s9>=b.s9 ? -1L : 0L, a.sa>=b.sa ? -1L : 0L, a.sb>=b.sb ? -1L : 0L, a.sc>=b.sc ? -1L : 0L, a.sd>=b.sd ? -1L : 0L, a.se>=b.se ? -1L : 0L, a.sf>=b.sf ? -1L : 0L);

        public static ulong16 operator &(ulong16 a, ulong16 b) => new ulong16((ulong)(a.s0&b.s0), (ulong)(a.s1&b.s1), (ulong)(a.s2&b.s2), (ulong)(a.s3&b.s3), (ulong)(a.s4&b.s4), (ulong)(a.s5&b.s5), (ulong)(a.s6&b.s6), (ulong)(a.s7&b.s7), (ulong)(a.s8&b.s8), (ulong)(a.s9&b.s9), (ulong)(a.sa&b.sa), (ulong)(a.sb&b.sb), (ulong)(a.sc&b.sc), (ulong)(a.sd&b.sd), (ulong)(a.se&b.se), (ulong)(a.sf&b.sf));

        public static ulong16 operator |(ulong16 a, ulong16 b) => new ulong16((ulong)(a.s0|b.s0), (ulong)(a.s1|b.s1), (ulong)(a.s2|b.s2), (ulong)(a.s3|b.s3), (ulong)(a.s4|b.s4), (ulong)(a.s5|b.s5), (ulong)(a.s6|b.s6), (ulong)(a.s7|b.s7), (ulong)(a.s8|b.s8), (ulong)(a.s9|b.s9), (ulong)(a.sa|b.sa), (ulong)(a.sb|b.sb), (ulong)(a.sc|b.sc), (ulong)(a.sd|b.sd), (ulong)(a.se|b.se), (ulong)(a.sf|b.sf));

        public static ulong16 operator ^(ulong16 a, ulong16 b) => new ulong16((ulong)(a.s0^b.s0), (ulong)(a.s1^b.s1), (ulong)(a.s2^b.s2), (ulong)(a.s3^b.s3), (ulong)(a.s4^b.s4), (ulong)(a.s5^b.s5), (ulong)(a.s6^b.s6), (ulong)(a.s7^b.s7), (ulong)(a.s8^b.s8), (ulong)(a.s9^b.s9), (ulong)(a.sa^b.sa), (ulong)(a.sb^b.sb), (ulong)(a.sc^b.sc), (ulong)(a.sd^b.sd), (ulong)(a.se^b.se), (ulong)(a.sf^b.sf));

        public static ulong16 operator +(ulong16 a) => a;

        public static ulong16 operator ~(ulong16 a) => new ulong16((ulong)(~a.s0), (ulong)(~a.s1), (ulong)(~a.s2), (ulong)(~a.s3), (ulong)(~a.s4), (ulong)(~a.s5), (ulong)(~a.s6), (ulong)(~a.s7), (ulong)(~a.s8), (ulong)(~a.s9), (ulong)(~a.sa), (ulong)(~a.sb), (ulong)(~a.sc), (ulong)(~a.sd), (ulong)(~a.se), (ulong)(~a.sf));

        public static ulong16 operator ++(ulong16 a) => new ulong16((ulong)(a.s0+1), (ulong)(a.s1+1), (ulong)(a.s2+1), (ulong)(a.s3+1), (ulong)(a.s4+1), (ulong)(a.s5+1), (ulong)(a.s6+1), (ulong)(a.s7+1), (ulong)(a.s8+1), (ulong)(a.s9+1), (ulong)(a.sa+1), (ulong)(a.sb+1), (ulong)(a.sc+1), (ulong)(a.sd+1), (ulong)(a.se+1), (ulong)(a.sf+1));

        public static ulong16 operator --(ulong16 a) => new ulong16((ulong)(a.s0-1), (ulong)(a.s1-1), (ulong)(a.s2-1), (ulong)(a.s3-1), (ulong)(a.s4-1), (ulong)(a.s5-1), (ulong)(a.s6-1), (ulong)(a.s7-1), (ulong)(a.s8-1), (ulong)(a.s9-1), (ulong)(a.sa-1), (ulong)(a.sb-1), (ulong)(a.sc-1), (ulong)(a.sd-1), (ulong)(a.se-1), (ulong)(a.sf-1));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct float2: IVectorType, IEquatable<float2>
    {
        [FieldOffset(0)]
        public float s0;
        [FieldOffset(4)]
        public float s1;

        public float2(float v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public float2(float2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public float2(float v0, float v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public float x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public float y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public float2 xx
        {
            get { return new float2(this.s0, this.s0); }
        }

        public float2 xy
        {
            get { return new float2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public float2 yx
        {
            get { return new float2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public float2 yy
        {
            get { return new float2(this.s1, this.s1); }
        }

        public float this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 8; }
        }

        // IEquatable

        public bool Equals(float2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is float2 && Equals((float2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static float2 operator +(float2 a, float2 b) => new float2((float)(a.s0+b.s0), (float)(a.s1+b.s1));

        public static float2 operator -(float2 a, float2 b) => new float2((float)(a.s0-b.s0), (float)(a.s1-b.s1));

        public static float2 operator *(float2 a, float2 b) => new float2((float)(a.s0*b.s0), (float)(a.s1*b.s1));

        public static float2 operator /(float2 a, float2 b) => new float2((float)(a.s0/b.s0), (float)(a.s1/b.s1));

        public static int2 operator ==(float2 a, float2 b) => new int2(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0);

        public static int2 operator !=(float2 a, float2 b) => new int2(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0);

        public static int2 operator <(float2 a, float2 b) => new int2(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0);

        public static int2 operator <=(float2 a, float2 b) => new int2(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0);

        public static int2 operator >(float2 a, float2 b) => new int2(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0);

        public static int2 operator >=(float2 a, float2 b) => new int2(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0);

        public static float2 operator +(float2 a) => a;

        public static float2 operator -(float2 a) => new float2((float)(-a.s0), (float)(-a.s1));
    }

    [StructLayout(LayoutKind.Explicit, Size=16)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct float3: IVectorType, IEquatable<float3>
    {
        [FieldOffset(0)]
        public float s0;
        [FieldOffset(4)]
        public float s1;
        [FieldOffset(8)]
        public float s2;

        public float3(float v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public float3(float3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public float3(float v0, float2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public float3(float2 v0, float v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public float3(float v0, float v1, float v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public float x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public float y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public float z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public float2 xx
        {
            get { return new float2(this.s0, this.s0); }
        }

        public float2 xy
        {
            get { return new float2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public float2 xz
        {
            get { return new float2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public float2 yx
        {
            get { return new float2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public float2 yy
        {
            get { return new float2(this.s1, this.s1); }
        }

        public float2 yz
        {
            get { return new float2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public float2 zx
        {
            get { return new float2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public float2 zy
        {
            get { return new float2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public float2 zz
        {
            get { return new float2(this.s2, this.s2); }
        }

        public float3 xxx
        {
            get { return new float3(this.s0, this.s0, this.s0); }
        }

        public float3 xxy
        {
            get { return new float3(this.s0, this.s0, this.s1); }
        }

        public float3 xxz
        {
            get { return new float3(this.s0, this.s0, this.s2); }
        }

        public float3 xyx
        {
            get { return new float3(this.s0, this.s1, this.s0); }
        }

        public float3 xyy
        {
            get { return new float3(this.s0, this.s1, this.s1); }
        }

        public float3 xyz
        {
            get { return new float3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 xzx
        {
            get { return new float3(this.s0, this.s2, this.s0); }
        }

        public float3 xzy
        {
            get { return new float3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 xzz
        {
            get { return new float3(this.s0, this.s2, this.s2); }
        }

        public float3 yxx
        {
            get { return new float3(this.s1, this.s0, this.s0); }
        }

        public float3 yxy
        {
            get { return new float3(this.s1, this.s0, this.s1); }
        }

        public float3 yxz
        {
            get { return new float3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 yyx
        {
            get { return new float3(this.s1, this.s1, this.s0); }
        }

        public float3 yyy
        {
            get { return new float3(this.s1, this.s1, this.s1); }
        }

        public float3 yyz
        {
            get { return new float3(this.s1, this.s1, this.s2); }
        }

        public float3 yzx
        {
            get { return new float3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 yzy
        {
            get { return new float3(this.s1, this.s2, this.s1); }
        }

        public float3 yzz
        {
            get { return new float3(this.s1, this.s2, this.s2); }
        }

        public float3 zxx
        {
            get { return new float3(this.s2, this.s0, this.s0); }
        }

        public float3 zxy
        {
            get { return new float3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 zxz
        {
            get { return new float3(this.s2, this.s0, this.s2); }
        }

        public float3 zyx
        {
            get { return new float3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 zyy
        {
            get { return new float3(this.s2, this.s1, this.s1); }
        }

        public float3 zyz
        {
            get { return new float3(this.s2, this.s1, this.s2); }
        }

        public float3 zzx
        {
            get { return new float3(this.s2, this.s2, this.s0); }
        }

        public float3 zzy
        {
            get { return new float3(this.s2, this.s2, this.s1); }
        }

        public float3 zzz
        {
            get { return new float3(this.s2, this.s2, this.s2); }
        }

        public float this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 12; }
        }

        // IEquatable

        public bool Equals(float3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is float3 && Equals((float3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static float3 operator +(float3 a, float3 b) => new float3((float)(a.s0+b.s0), (float)(a.s1+b.s1), (float)(a.s2+b.s2));

        public static float3 operator -(float3 a, float3 b) => new float3((float)(a.s0-b.s0), (float)(a.s1-b.s1), (float)(a.s2-b.s2));

        public static float3 operator *(float3 a, float3 b) => new float3((float)(a.s0*b.s0), (float)(a.s1*b.s1), (float)(a.s2*b.s2));

        public static float3 operator /(float3 a, float3 b) => new float3((float)(a.s0/b.s0), (float)(a.s1/b.s1), (float)(a.s2/b.s2));

        public static int3 operator ==(float3 a, float3 b) => new int3(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0);

        public static int3 operator !=(float3 a, float3 b) => new int3(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0);

        public static int3 operator <(float3 a, float3 b) => new int3(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0);

        public static int3 operator <=(float3 a, float3 b) => new int3(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0);

        public static int3 operator >(float3 a, float3 b) => new int3(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0);

        public static int3 operator >=(float3 a, float3 b) => new int3(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0);

        public static float3 operator +(float3 a) => a;

        public static float3 operator -(float3 a) => new float3((float)(-a.s0), (float)(-a.s1), (float)(-a.s2));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct float4: IVectorType, IEquatable<float4>
    {
        [FieldOffset(0)]
        public float s0;
        [FieldOffset(4)]
        public float s1;
        [FieldOffset(8)]
        public float s2;
        [FieldOffset(12)]
        public float s3;

        public float4(float v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public float4(float4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public float4(float v0, float3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public float4(float2 v0, float2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public float4(float3 v0, float v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public float4(float v0, float v1, float2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public float4(float v0, float2 v1, float v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public float4(float2 v0, float v1, float v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public float4(float v0, float v1, float v2, float v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public float x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public float y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public float z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public float w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public float2 xx
        {
            get { return new float2(this.s0, this.s0); }
        }

        public float2 xy
        {
            get { return new float2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public float2 xz
        {
            get { return new float2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public float2 xw
        {
            get { return new float2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public float2 yx
        {
            get { return new float2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public float2 yy
        {
            get { return new float2(this.s1, this.s1); }
        }

        public float2 yz
        {
            get { return new float2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public float2 yw
        {
            get { return new float2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public float2 zx
        {
            get { return new float2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public float2 zy
        {
            get { return new float2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public float2 zz
        {
            get { return new float2(this.s2, this.s2); }
        }

        public float2 zw
        {
            get { return new float2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public float2 wx
        {
            get { return new float2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public float2 wy
        {
            get { return new float2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public float2 wz
        {
            get { return new float2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public float2 ww
        {
            get { return new float2(this.s3, this.s3); }
        }

        public float3 xxx
        {
            get { return new float3(this.s0, this.s0, this.s0); }
        }

        public float3 xxy
        {
            get { return new float3(this.s0, this.s0, this.s1); }
        }

        public float3 xxz
        {
            get { return new float3(this.s0, this.s0, this.s2); }
        }

        public float3 xxw
        {
            get { return new float3(this.s0, this.s0, this.s3); }
        }

        public float3 xyx
        {
            get { return new float3(this.s0, this.s1, this.s0); }
        }

        public float3 xyy
        {
            get { return new float3(this.s0, this.s1, this.s1); }
        }

        public float3 xyz
        {
            get { return new float3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 xyw
        {
            get { return new float3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public float3 xzx
        {
            get { return new float3(this.s0, this.s2, this.s0); }
        }

        public float3 xzy
        {
            get { return new float3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 xzz
        {
            get { return new float3(this.s0, this.s2, this.s2); }
        }

        public float3 xzw
        {
            get { return new float3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public float3 xwx
        {
            get { return new float3(this.s0, this.s3, this.s0); }
        }

        public float3 xwy
        {
            get { return new float3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 xwz
        {
            get { return new float3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 xww
        {
            get { return new float3(this.s0, this.s3, this.s3); }
        }

        public float3 yxx
        {
            get { return new float3(this.s1, this.s0, this.s0); }
        }

        public float3 yxy
        {
            get { return new float3(this.s1, this.s0, this.s1); }
        }

        public float3 yxz
        {
            get { return new float3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 yxw
        {
            get { return new float3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public float3 yyx
        {
            get { return new float3(this.s1, this.s1, this.s0); }
        }

        public float3 yyy
        {
            get { return new float3(this.s1, this.s1, this.s1); }
        }

        public float3 yyz
        {
            get { return new float3(this.s1, this.s1, this.s2); }
        }

        public float3 yyw
        {
            get { return new float3(this.s1, this.s1, this.s3); }
        }

        public float3 yzx
        {
            get { return new float3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 yzy
        {
            get { return new float3(this.s1, this.s2, this.s1); }
        }

        public float3 yzz
        {
            get { return new float3(this.s1, this.s2, this.s2); }
        }

        public float3 yzw
        {
            get { return new float3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public float3 ywx
        {
            get { return new float3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 ywy
        {
            get { return new float3(this.s1, this.s3, this.s1); }
        }

        public float3 ywz
        {
            get { return new float3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 yww
        {
            get { return new float3(this.s1, this.s3, this.s3); }
        }

        public float3 zxx
        {
            get { return new float3(this.s2, this.s0, this.s0); }
        }

        public float3 zxy
        {
            get { return new float3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 zxz
        {
            get { return new float3(this.s2, this.s0, this.s2); }
        }

        public float3 zxw
        {
            get { return new float3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public float3 zyx
        {
            get { return new float3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 zyy
        {
            get { return new float3(this.s2, this.s1, this.s1); }
        }

        public float3 zyz
        {
            get { return new float3(this.s2, this.s1, this.s2); }
        }

        public float3 zyw
        {
            get { return new float3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public float3 zzx
        {
            get { return new float3(this.s2, this.s2, this.s0); }
        }

        public float3 zzy
        {
            get { return new float3(this.s2, this.s2, this.s1); }
        }

        public float3 zzz
        {
            get { return new float3(this.s2, this.s2, this.s2); }
        }

        public float3 zzw
        {
            get { return new float3(this.s2, this.s2, this.s3); }
        }

        public float3 zwx
        {
            get { return new float3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 zwy
        {
            get { return new float3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 zwz
        {
            get { return new float3(this.s2, this.s3, this.s2); }
        }

        public float3 zww
        {
            get { return new float3(this.s2, this.s3, this.s3); }
        }

        public float3 wxx
        {
            get { return new float3(this.s3, this.s0, this.s0); }
        }

        public float3 wxy
        {
            get { return new float3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 wxz
        {
            get { return new float3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 wxw
        {
            get { return new float3(this.s3, this.s0, this.s3); }
        }

        public float3 wyx
        {
            get { return new float3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 wyy
        {
            get { return new float3(this.s3, this.s1, this.s1); }
        }

        public float3 wyz
        {
            get { return new float3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public float3 wyw
        {
            get { return new float3(this.s3, this.s1, this.s3); }
        }

        public float3 wzx
        {
            get { return new float3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public float3 wzy
        {
            get { return new float3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public float3 wzz
        {
            get { return new float3(this.s3, this.s2, this.s2); }
        }

        public float3 wzw
        {
            get { return new float3(this.s3, this.s2, this.s3); }
        }

        public float3 wwx
        {
            get { return new float3(this.s3, this.s3, this.s0); }
        }

        public float3 wwy
        {
            get { return new float3(this.s3, this.s3, this.s1); }
        }

        public float3 wwz
        {
            get { return new float3(this.s3, this.s3, this.s2); }
        }

        public float3 www
        {
            get { return new float3(this.s3, this.s3, this.s3); }
        }

        public float4 xxxx
        {
            get { return new float4(this.s0, this.s0, this.s0, this.s0); }
        }

        public float4 xxxy
        {
            get { return new float4(this.s0, this.s0, this.s0, this.s1); }
        }

        public float4 xxxz
        {
            get { return new float4(this.s0, this.s0, this.s0, this.s2); }
        }

        public float4 xxxw
        {
            get { return new float4(this.s0, this.s0, this.s0, this.s3); }
        }

        public float4 xxyx
        {
            get { return new float4(this.s0, this.s0, this.s1, this.s0); }
        }

        public float4 xxyy
        {
            get { return new float4(this.s0, this.s0, this.s1, this.s1); }
        }

        public float4 xxyz
        {
            get { return new float4(this.s0, this.s0, this.s1, this.s2); }
        }

        public float4 xxyw
        {
            get { return new float4(this.s0, this.s0, this.s1, this.s3); }
        }

        public float4 xxzx
        {
            get { return new float4(this.s0, this.s0, this.s2, this.s0); }
        }

        public float4 xxzy
        {
            get { return new float4(this.s0, this.s0, this.s2, this.s1); }
        }

        public float4 xxzz
        {
            get { return new float4(this.s0, this.s0, this.s2, this.s2); }
        }

        public float4 xxzw
        {
            get { return new float4(this.s0, this.s0, this.s2, this.s3); }
        }

        public float4 xxwx
        {
            get { return new float4(this.s0, this.s0, this.s3, this.s0); }
        }

        public float4 xxwy
        {
            get { return new float4(this.s0, this.s0, this.s3, this.s1); }
        }

        public float4 xxwz
        {
            get { return new float4(this.s0, this.s0, this.s3, this.s2); }
        }

        public float4 xxww
        {
            get { return new float4(this.s0, this.s0, this.s3, this.s3); }
        }

        public float4 xyxx
        {
            get { return new float4(this.s0, this.s1, this.s0, this.s0); }
        }

        public float4 xyxy
        {
            get { return new float4(this.s0, this.s1, this.s0, this.s1); }
        }

        public float4 xyxz
        {
            get { return new float4(this.s0, this.s1, this.s0, this.s2); }
        }

        public float4 xyxw
        {
            get { return new float4(this.s0, this.s1, this.s0, this.s3); }
        }

        public float4 xyyx
        {
            get { return new float4(this.s0, this.s1, this.s1, this.s0); }
        }

        public float4 xyyy
        {
            get { return new float4(this.s0, this.s1, this.s1, this.s1); }
        }

        public float4 xyyz
        {
            get { return new float4(this.s0, this.s1, this.s1, this.s2); }
        }

        public float4 xyyw
        {
            get { return new float4(this.s0, this.s1, this.s1, this.s3); }
        }

        public float4 xyzx
        {
            get { return new float4(this.s0, this.s1, this.s2, this.s0); }
        }

        public float4 xyzy
        {
            get { return new float4(this.s0, this.s1, this.s2, this.s1); }
        }

        public float4 xyzz
        {
            get { return new float4(this.s0, this.s1, this.s2, this.s2); }
        }

        public float4 xyzw
        {
            get { return new float4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public float4 xywx
        {
            get { return new float4(this.s0, this.s1, this.s3, this.s0); }
        }

        public float4 xywy
        {
            get { return new float4(this.s0, this.s1, this.s3, this.s1); }
        }

        public float4 xywz
        {
            get { return new float4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public float4 xyww
        {
            get { return new float4(this.s0, this.s1, this.s3, this.s3); }
        }

        public float4 xzxx
        {
            get { return new float4(this.s0, this.s2, this.s0, this.s0); }
        }

        public float4 xzxy
        {
            get { return new float4(this.s0, this.s2, this.s0, this.s1); }
        }

        public float4 xzxz
        {
            get { return new float4(this.s0, this.s2, this.s0, this.s2); }
        }

        public float4 xzxw
        {
            get { return new float4(this.s0, this.s2, this.s0, this.s3); }
        }

        public float4 xzyx
        {
            get { return new float4(this.s0, this.s2, this.s1, this.s0); }
        }

        public float4 xzyy
        {
            get { return new float4(this.s0, this.s2, this.s1, this.s1); }
        }

        public float4 xzyz
        {
            get { return new float4(this.s0, this.s2, this.s1, this.s2); }
        }

        public float4 xzyw
        {
            get { return new float4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public float4 xzzx
        {
            get { return new float4(this.s0, this.s2, this.s2, this.s0); }
        }

        public float4 xzzy
        {
            get { return new float4(this.s0, this.s2, this.s2, this.s1); }
        }

        public float4 xzzz
        {
            get { return new float4(this.s0, this.s2, this.s2, this.s2); }
        }

        public float4 xzzw
        {
            get { return new float4(this.s0, this.s2, this.s2, this.s3); }
        }

        public float4 xzwx
        {
            get { return new float4(this.s0, this.s2, this.s3, this.s0); }
        }

        public float4 xzwy
        {
            get { return new float4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public float4 xzwz
        {
            get { return new float4(this.s0, this.s2, this.s3, this.s2); }
        }

        public float4 xzww
        {
            get { return new float4(this.s0, this.s2, this.s3, this.s3); }
        }

        public float4 xwxx
        {
            get { return new float4(this.s0, this.s3, this.s0, this.s0); }
        }

        public float4 xwxy
        {
            get { return new float4(this.s0, this.s3, this.s0, this.s1); }
        }

        public float4 xwxz
        {
            get { return new float4(this.s0, this.s3, this.s0, this.s2); }
        }

        public float4 xwxw
        {
            get { return new float4(this.s0, this.s3, this.s0, this.s3); }
        }

        public float4 xwyx
        {
            get { return new float4(this.s0, this.s3, this.s1, this.s0); }
        }

        public float4 xwyy
        {
            get { return new float4(this.s0, this.s3, this.s1, this.s1); }
        }

        public float4 xwyz
        {
            get { return new float4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public float4 xwyw
        {
            get { return new float4(this.s0, this.s3, this.s1, this.s3); }
        }

        public float4 xwzx
        {
            get { return new float4(this.s0, this.s3, this.s2, this.s0); }
        }

        public float4 xwzy
        {
            get { return new float4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public float4 xwzz
        {
            get { return new float4(this.s0, this.s3, this.s2, this.s2); }
        }

        public float4 xwzw
        {
            get { return new float4(this.s0, this.s3, this.s2, this.s3); }
        }

        public float4 xwwx
        {
            get { return new float4(this.s0, this.s3, this.s3, this.s0); }
        }

        public float4 xwwy
        {
            get { return new float4(this.s0, this.s3, this.s3, this.s1); }
        }

        public float4 xwwz
        {
            get { return new float4(this.s0, this.s3, this.s3, this.s2); }
        }

        public float4 xwww
        {
            get { return new float4(this.s0, this.s3, this.s3, this.s3); }
        }

        public float4 yxxx
        {
            get { return new float4(this.s1, this.s0, this.s0, this.s0); }
        }

        public float4 yxxy
        {
            get { return new float4(this.s1, this.s0, this.s0, this.s1); }
        }

        public float4 yxxz
        {
            get { return new float4(this.s1, this.s0, this.s0, this.s2); }
        }

        public float4 yxxw
        {
            get { return new float4(this.s1, this.s0, this.s0, this.s3); }
        }

        public float4 yxyx
        {
            get { return new float4(this.s1, this.s0, this.s1, this.s0); }
        }

        public float4 yxyy
        {
            get { return new float4(this.s1, this.s0, this.s1, this.s1); }
        }

        public float4 yxyz
        {
            get { return new float4(this.s1, this.s0, this.s1, this.s2); }
        }

        public float4 yxyw
        {
            get { return new float4(this.s1, this.s0, this.s1, this.s3); }
        }

        public float4 yxzx
        {
            get { return new float4(this.s1, this.s0, this.s2, this.s0); }
        }

        public float4 yxzy
        {
            get { return new float4(this.s1, this.s0, this.s2, this.s1); }
        }

        public float4 yxzz
        {
            get { return new float4(this.s1, this.s0, this.s2, this.s2); }
        }

        public float4 yxzw
        {
            get { return new float4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public float4 yxwx
        {
            get { return new float4(this.s1, this.s0, this.s3, this.s0); }
        }

        public float4 yxwy
        {
            get { return new float4(this.s1, this.s0, this.s3, this.s1); }
        }

        public float4 yxwz
        {
            get { return new float4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public float4 yxww
        {
            get { return new float4(this.s1, this.s0, this.s3, this.s3); }
        }

        public float4 yyxx
        {
            get { return new float4(this.s1, this.s1, this.s0, this.s0); }
        }

        public float4 yyxy
        {
            get { return new float4(this.s1, this.s1, this.s0, this.s1); }
        }

        public float4 yyxz
        {
            get { return new float4(this.s1, this.s1, this.s0, this.s2); }
        }

        public float4 yyxw
        {
            get { return new float4(this.s1, this.s1, this.s0, this.s3); }
        }

        public float4 yyyx
        {
            get { return new float4(this.s1, this.s1, this.s1, this.s0); }
        }

        public float4 yyyy
        {
            get { return new float4(this.s1, this.s1, this.s1, this.s1); }
        }

        public float4 yyyz
        {
            get { return new float4(this.s1, this.s1, this.s1, this.s2); }
        }

        public float4 yyyw
        {
            get { return new float4(this.s1, this.s1, this.s1, this.s3); }
        }

        public float4 yyzx
        {
            get { return new float4(this.s1, this.s1, this.s2, this.s0); }
        }

        public float4 yyzy
        {
            get { return new float4(this.s1, this.s1, this.s2, this.s1); }
        }

        public float4 yyzz
        {
            get { return new float4(this.s1, this.s1, this.s2, this.s2); }
        }

        public float4 yyzw
        {
            get { return new float4(this.s1, this.s1, this.s2, this.s3); }
        }

        public float4 yywx
        {
            get { return new float4(this.s1, this.s1, this.s3, this.s0); }
        }

        public float4 yywy
        {
            get { return new float4(this.s1, this.s1, this.s3, this.s1); }
        }

        public float4 yywz
        {
            get { return new float4(this.s1, this.s1, this.s3, this.s2); }
        }

        public float4 yyww
        {
            get { return new float4(this.s1, this.s1, this.s3, this.s3); }
        }

        public float4 yzxx
        {
            get { return new float4(this.s1, this.s2, this.s0, this.s0); }
        }

        public float4 yzxy
        {
            get { return new float4(this.s1, this.s2, this.s0, this.s1); }
        }

        public float4 yzxz
        {
            get { return new float4(this.s1, this.s2, this.s0, this.s2); }
        }

        public float4 yzxw
        {
            get { return new float4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public float4 yzyx
        {
            get { return new float4(this.s1, this.s2, this.s1, this.s0); }
        }

        public float4 yzyy
        {
            get { return new float4(this.s1, this.s2, this.s1, this.s1); }
        }

        public float4 yzyz
        {
            get { return new float4(this.s1, this.s2, this.s1, this.s2); }
        }

        public float4 yzyw
        {
            get { return new float4(this.s1, this.s2, this.s1, this.s3); }
        }

        public float4 yzzx
        {
            get { return new float4(this.s1, this.s2, this.s2, this.s0); }
        }

        public float4 yzzy
        {
            get { return new float4(this.s1, this.s2, this.s2, this.s1); }
        }

        public float4 yzzz
        {
            get { return new float4(this.s1, this.s2, this.s2, this.s2); }
        }

        public float4 yzzw
        {
            get { return new float4(this.s1, this.s2, this.s2, this.s3); }
        }

        public float4 yzwx
        {
            get { return new float4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public float4 yzwy
        {
            get { return new float4(this.s1, this.s2, this.s3, this.s1); }
        }

        public float4 yzwz
        {
            get { return new float4(this.s1, this.s2, this.s3, this.s2); }
        }

        public float4 yzww
        {
            get { return new float4(this.s1, this.s2, this.s3, this.s3); }
        }

        public float4 ywxx
        {
            get { return new float4(this.s1, this.s3, this.s0, this.s0); }
        }

        public float4 ywxy
        {
            get { return new float4(this.s1, this.s3, this.s0, this.s1); }
        }

        public float4 ywxz
        {
            get { return new float4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public float4 ywxw
        {
            get { return new float4(this.s1, this.s3, this.s0, this.s3); }
        }

        public float4 ywyx
        {
            get { return new float4(this.s1, this.s3, this.s1, this.s0); }
        }

        public float4 ywyy
        {
            get { return new float4(this.s1, this.s3, this.s1, this.s1); }
        }

        public float4 ywyz
        {
            get { return new float4(this.s1, this.s3, this.s1, this.s2); }
        }

        public float4 ywyw
        {
            get { return new float4(this.s1, this.s3, this.s1, this.s3); }
        }

        public float4 ywzx
        {
            get { return new float4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public float4 ywzy
        {
            get { return new float4(this.s1, this.s3, this.s2, this.s1); }
        }

        public float4 ywzz
        {
            get { return new float4(this.s1, this.s3, this.s2, this.s2); }
        }

        public float4 ywzw
        {
            get { return new float4(this.s1, this.s3, this.s2, this.s3); }
        }

        public float4 ywwx
        {
            get { return new float4(this.s1, this.s3, this.s3, this.s0); }
        }

        public float4 ywwy
        {
            get { return new float4(this.s1, this.s3, this.s3, this.s1); }
        }

        public float4 ywwz
        {
            get { return new float4(this.s1, this.s3, this.s3, this.s2); }
        }

        public float4 ywww
        {
            get { return new float4(this.s1, this.s3, this.s3, this.s3); }
        }

        public float4 zxxx
        {
            get { return new float4(this.s2, this.s0, this.s0, this.s0); }
        }

        public float4 zxxy
        {
            get { return new float4(this.s2, this.s0, this.s0, this.s1); }
        }

        public float4 zxxz
        {
            get { return new float4(this.s2, this.s0, this.s0, this.s2); }
        }

        public float4 zxxw
        {
            get { return new float4(this.s2, this.s0, this.s0, this.s3); }
        }

        public float4 zxyx
        {
            get { return new float4(this.s2, this.s0, this.s1, this.s0); }
        }

        public float4 zxyy
        {
            get { return new float4(this.s2, this.s0, this.s1, this.s1); }
        }

        public float4 zxyz
        {
            get { return new float4(this.s2, this.s0, this.s1, this.s2); }
        }

        public float4 zxyw
        {
            get { return new float4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public float4 zxzx
        {
            get { return new float4(this.s2, this.s0, this.s2, this.s0); }
        }

        public float4 zxzy
        {
            get { return new float4(this.s2, this.s0, this.s2, this.s1); }
        }

        public float4 zxzz
        {
            get { return new float4(this.s2, this.s0, this.s2, this.s2); }
        }

        public float4 zxzw
        {
            get { return new float4(this.s2, this.s0, this.s2, this.s3); }
        }

        public float4 zxwx
        {
            get { return new float4(this.s2, this.s0, this.s3, this.s0); }
        }

        public float4 zxwy
        {
            get { return new float4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public float4 zxwz
        {
            get { return new float4(this.s2, this.s0, this.s3, this.s2); }
        }

        public float4 zxww
        {
            get { return new float4(this.s2, this.s0, this.s3, this.s3); }
        }

        public float4 zyxx
        {
            get { return new float4(this.s2, this.s1, this.s0, this.s0); }
        }

        public float4 zyxy
        {
            get { return new float4(this.s2, this.s1, this.s0, this.s1); }
        }

        public float4 zyxz
        {
            get { return new float4(this.s2, this.s1, this.s0, this.s2); }
        }

        public float4 zyxw
        {
            get { return new float4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public float4 zyyx
        {
            get { return new float4(this.s2, this.s1, this.s1, this.s0); }
        }

        public float4 zyyy
        {
            get { return new float4(this.s2, this.s1, this.s1, this.s1); }
        }

        public float4 zyyz
        {
            get { return new float4(this.s2, this.s1, this.s1, this.s2); }
        }

        public float4 zyyw
        {
            get { return new float4(this.s2, this.s1, this.s1, this.s3); }
        }

        public float4 zyzx
        {
            get { return new float4(this.s2, this.s1, this.s2, this.s0); }
        }

        public float4 zyzy
        {
            get { return new float4(this.s2, this.s1, this.s2, this.s1); }
        }

        public float4 zyzz
        {
            get { return new float4(this.s2, this.s1, this.s2, this.s2); }
        }

        public float4 zyzw
        {
            get { return new float4(this.s2, this.s1, this.s2, this.s3); }
        }

        public float4 zywx
        {
            get { return new float4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public float4 zywy
        {
            get { return new float4(this.s2, this.s1, this.s3, this.s1); }
        }

        public float4 zywz
        {
            get { return new float4(this.s2, this.s1, this.s3, this.s2); }
        }

        public float4 zyww
        {
            get { return new float4(this.s2, this.s1, this.s3, this.s3); }
        }

        public float4 zzxx
        {
            get { return new float4(this.s2, this.s2, this.s0, this.s0); }
        }

        public float4 zzxy
        {
            get { return new float4(this.s2, this.s2, this.s0, this.s1); }
        }

        public float4 zzxz
        {
            get { return new float4(this.s2, this.s2, this.s0, this.s2); }
        }

        public float4 zzxw
        {
            get { return new float4(this.s2, this.s2, this.s0, this.s3); }
        }

        public float4 zzyx
        {
            get { return new float4(this.s2, this.s2, this.s1, this.s0); }
        }

        public float4 zzyy
        {
            get { return new float4(this.s2, this.s2, this.s1, this.s1); }
        }

        public float4 zzyz
        {
            get { return new float4(this.s2, this.s2, this.s1, this.s2); }
        }

        public float4 zzyw
        {
            get { return new float4(this.s2, this.s2, this.s1, this.s3); }
        }

        public float4 zzzx
        {
            get { return new float4(this.s2, this.s2, this.s2, this.s0); }
        }

        public float4 zzzy
        {
            get { return new float4(this.s2, this.s2, this.s2, this.s1); }
        }

        public float4 zzzz
        {
            get { return new float4(this.s2, this.s2, this.s2, this.s2); }
        }

        public float4 zzzw
        {
            get { return new float4(this.s2, this.s2, this.s2, this.s3); }
        }

        public float4 zzwx
        {
            get { return new float4(this.s2, this.s2, this.s3, this.s0); }
        }

        public float4 zzwy
        {
            get { return new float4(this.s2, this.s2, this.s3, this.s1); }
        }

        public float4 zzwz
        {
            get { return new float4(this.s2, this.s2, this.s3, this.s2); }
        }

        public float4 zzww
        {
            get { return new float4(this.s2, this.s2, this.s3, this.s3); }
        }

        public float4 zwxx
        {
            get { return new float4(this.s2, this.s3, this.s0, this.s0); }
        }

        public float4 zwxy
        {
            get { return new float4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public float4 zwxz
        {
            get { return new float4(this.s2, this.s3, this.s0, this.s2); }
        }

        public float4 zwxw
        {
            get { return new float4(this.s2, this.s3, this.s0, this.s3); }
        }

        public float4 zwyx
        {
            get { return new float4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public float4 zwyy
        {
            get { return new float4(this.s2, this.s3, this.s1, this.s1); }
        }

        public float4 zwyz
        {
            get { return new float4(this.s2, this.s3, this.s1, this.s2); }
        }

        public float4 zwyw
        {
            get { return new float4(this.s2, this.s3, this.s1, this.s3); }
        }

        public float4 zwzx
        {
            get { return new float4(this.s2, this.s3, this.s2, this.s0); }
        }

        public float4 zwzy
        {
            get { return new float4(this.s2, this.s3, this.s2, this.s1); }
        }

        public float4 zwzz
        {
            get { return new float4(this.s2, this.s3, this.s2, this.s2); }
        }

        public float4 zwzw
        {
            get { return new float4(this.s2, this.s3, this.s2, this.s3); }
        }

        public float4 zwwx
        {
            get { return new float4(this.s2, this.s3, this.s3, this.s0); }
        }

        public float4 zwwy
        {
            get { return new float4(this.s2, this.s3, this.s3, this.s1); }
        }

        public float4 zwwz
        {
            get { return new float4(this.s2, this.s3, this.s3, this.s2); }
        }

        public float4 zwww
        {
            get { return new float4(this.s2, this.s3, this.s3, this.s3); }
        }

        public float4 wxxx
        {
            get { return new float4(this.s3, this.s0, this.s0, this.s0); }
        }

        public float4 wxxy
        {
            get { return new float4(this.s3, this.s0, this.s0, this.s1); }
        }

        public float4 wxxz
        {
            get { return new float4(this.s3, this.s0, this.s0, this.s2); }
        }

        public float4 wxxw
        {
            get { return new float4(this.s3, this.s0, this.s0, this.s3); }
        }

        public float4 wxyx
        {
            get { return new float4(this.s3, this.s0, this.s1, this.s0); }
        }

        public float4 wxyy
        {
            get { return new float4(this.s3, this.s0, this.s1, this.s1); }
        }

        public float4 wxyz
        {
            get { return new float4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public float4 wxyw
        {
            get { return new float4(this.s3, this.s0, this.s1, this.s3); }
        }

        public float4 wxzx
        {
            get { return new float4(this.s3, this.s0, this.s2, this.s0); }
        }

        public float4 wxzy
        {
            get { return new float4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public float4 wxzz
        {
            get { return new float4(this.s3, this.s0, this.s2, this.s2); }
        }

        public float4 wxzw
        {
            get { return new float4(this.s3, this.s0, this.s2, this.s3); }
        }

        public float4 wxwx
        {
            get { return new float4(this.s3, this.s0, this.s3, this.s0); }
        }

        public float4 wxwy
        {
            get { return new float4(this.s3, this.s0, this.s3, this.s1); }
        }

        public float4 wxwz
        {
            get { return new float4(this.s3, this.s0, this.s3, this.s2); }
        }

        public float4 wxww
        {
            get { return new float4(this.s3, this.s0, this.s3, this.s3); }
        }

        public float4 wyxx
        {
            get { return new float4(this.s3, this.s1, this.s0, this.s0); }
        }

        public float4 wyxy
        {
            get { return new float4(this.s3, this.s1, this.s0, this.s1); }
        }

        public float4 wyxz
        {
            get { return new float4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public float4 wyxw
        {
            get { return new float4(this.s3, this.s1, this.s0, this.s3); }
        }

        public float4 wyyx
        {
            get { return new float4(this.s3, this.s1, this.s1, this.s0); }
        }

        public float4 wyyy
        {
            get { return new float4(this.s3, this.s1, this.s1, this.s1); }
        }

        public float4 wyyz
        {
            get { return new float4(this.s3, this.s1, this.s1, this.s2); }
        }

        public float4 wyyw
        {
            get { return new float4(this.s3, this.s1, this.s1, this.s3); }
        }

        public float4 wyzx
        {
            get { return new float4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public float4 wyzy
        {
            get { return new float4(this.s3, this.s1, this.s2, this.s1); }
        }

        public float4 wyzz
        {
            get { return new float4(this.s3, this.s1, this.s2, this.s2); }
        }

        public float4 wyzw
        {
            get { return new float4(this.s3, this.s1, this.s2, this.s3); }
        }

        public float4 wywx
        {
            get { return new float4(this.s3, this.s1, this.s3, this.s0); }
        }

        public float4 wywy
        {
            get { return new float4(this.s3, this.s1, this.s3, this.s1); }
        }

        public float4 wywz
        {
            get { return new float4(this.s3, this.s1, this.s3, this.s2); }
        }

        public float4 wyww
        {
            get { return new float4(this.s3, this.s1, this.s3, this.s3); }
        }

        public float4 wzxx
        {
            get { return new float4(this.s3, this.s2, this.s0, this.s0); }
        }

        public float4 wzxy
        {
            get { return new float4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public float4 wzxz
        {
            get { return new float4(this.s3, this.s2, this.s0, this.s2); }
        }

        public float4 wzxw
        {
            get { return new float4(this.s3, this.s2, this.s0, this.s3); }
        }

        public float4 wzyx
        {
            get { return new float4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public float4 wzyy
        {
            get { return new float4(this.s3, this.s2, this.s1, this.s1); }
        }

        public float4 wzyz
        {
            get { return new float4(this.s3, this.s2, this.s1, this.s2); }
        }

        public float4 wzyw
        {
            get { return new float4(this.s3, this.s2, this.s1, this.s3); }
        }

        public float4 wzzx
        {
            get { return new float4(this.s3, this.s2, this.s2, this.s0); }
        }

        public float4 wzzy
        {
            get { return new float4(this.s3, this.s2, this.s2, this.s1); }
        }

        public float4 wzzz
        {
            get { return new float4(this.s3, this.s2, this.s2, this.s2); }
        }

        public float4 wzzw
        {
            get { return new float4(this.s3, this.s2, this.s2, this.s3); }
        }

        public float4 wzwx
        {
            get { return new float4(this.s3, this.s2, this.s3, this.s0); }
        }

        public float4 wzwy
        {
            get { return new float4(this.s3, this.s2, this.s3, this.s1); }
        }

        public float4 wzwz
        {
            get { return new float4(this.s3, this.s2, this.s3, this.s2); }
        }

        public float4 wzww
        {
            get { return new float4(this.s3, this.s2, this.s3, this.s3); }
        }

        public float4 wwxx
        {
            get { return new float4(this.s3, this.s3, this.s0, this.s0); }
        }

        public float4 wwxy
        {
            get { return new float4(this.s3, this.s3, this.s0, this.s1); }
        }

        public float4 wwxz
        {
            get { return new float4(this.s3, this.s3, this.s0, this.s2); }
        }

        public float4 wwxw
        {
            get { return new float4(this.s3, this.s3, this.s0, this.s3); }
        }

        public float4 wwyx
        {
            get { return new float4(this.s3, this.s3, this.s1, this.s0); }
        }

        public float4 wwyy
        {
            get { return new float4(this.s3, this.s3, this.s1, this.s1); }
        }

        public float4 wwyz
        {
            get { return new float4(this.s3, this.s3, this.s1, this.s2); }
        }

        public float4 wwyw
        {
            get { return new float4(this.s3, this.s3, this.s1, this.s3); }
        }

        public float4 wwzx
        {
            get { return new float4(this.s3, this.s3, this.s2, this.s0); }
        }

        public float4 wwzy
        {
            get { return new float4(this.s3, this.s3, this.s2, this.s1); }
        }

        public float4 wwzz
        {
            get { return new float4(this.s3, this.s3, this.s2, this.s2); }
        }

        public float4 wwzw
        {
            get { return new float4(this.s3, this.s3, this.s2, this.s3); }
        }

        public float4 wwwx
        {
            get { return new float4(this.s3, this.s3, this.s3, this.s0); }
        }

        public float4 wwwy
        {
            get { return new float4(this.s3, this.s3, this.s3, this.s1); }
        }

        public float4 wwwz
        {
            get { return new float4(this.s3, this.s3, this.s3, this.s2); }
        }

        public float4 wwww
        {
            get { return new float4(this.s3, this.s3, this.s3, this.s3); }
        }

        public float this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(float4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is float4 && Equals((float4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static float4 operator +(float4 a, float4 b) => new float4((float)(a.s0+b.s0), (float)(a.s1+b.s1), (float)(a.s2+b.s2), (float)(a.s3+b.s3));

        public static float4 operator -(float4 a, float4 b) => new float4((float)(a.s0-b.s0), (float)(a.s1-b.s1), (float)(a.s2-b.s2), (float)(a.s3-b.s3));

        public static float4 operator *(float4 a, float4 b) => new float4((float)(a.s0*b.s0), (float)(a.s1*b.s1), (float)(a.s2*b.s2), (float)(a.s3*b.s3));

        public static float4 operator /(float4 a, float4 b) => new float4((float)(a.s0/b.s0), (float)(a.s1/b.s1), (float)(a.s2/b.s2), (float)(a.s3/b.s3));

        public static int4 operator ==(float4 a, float4 b) => new int4(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0);

        public static int4 operator !=(float4 a, float4 b) => new int4(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0);

        public static int4 operator <(float4 a, float4 b) => new int4(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0);

        public static int4 operator <=(float4 a, float4 b) => new int4(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0);

        public static int4 operator >(float4 a, float4 b) => new int4(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0);

        public static int4 operator >=(float4 a, float4 b) => new int4(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0);

        public static float4 operator +(float4 a) => a;

        public static float4 operator -(float4 a) => new float4((float)(-a.s0), (float)(-a.s1), (float)(-a.s2), (float)(-a.s3));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct float8: IVectorType, IEquatable<float8>
    {
        [FieldOffset(0)]
        public float s0;
        [FieldOffset(4)]
        public float s1;
        [FieldOffset(8)]
        public float s2;
        [FieldOffset(12)]
        public float s3;
        [FieldOffset(16)]
        public float s4;
        [FieldOffset(20)]
        public float s5;
        [FieldOffset(24)]
        public float s6;
        [FieldOffset(28)]
        public float s7;

        public float8(float v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public float8(float v0, float v1, float v2, float v3, float v4, float v5, float v6, float v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public float this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(float8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is float8 && Equals((float8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static float8 operator +(float8 a, float8 b) => new float8((float)(a.s0+b.s0), (float)(a.s1+b.s1), (float)(a.s2+b.s2), (float)(a.s3+b.s3), (float)(a.s4+b.s4), (float)(a.s5+b.s5), (float)(a.s6+b.s6), (float)(a.s7+b.s7));

        public static float8 operator -(float8 a, float8 b) => new float8((float)(a.s0-b.s0), (float)(a.s1-b.s1), (float)(a.s2-b.s2), (float)(a.s3-b.s3), (float)(a.s4-b.s4), (float)(a.s5-b.s5), (float)(a.s6-b.s6), (float)(a.s7-b.s7));

        public static float8 operator *(float8 a, float8 b) => new float8((float)(a.s0*b.s0), (float)(a.s1*b.s1), (float)(a.s2*b.s2), (float)(a.s3*b.s3), (float)(a.s4*b.s4), (float)(a.s5*b.s5), (float)(a.s6*b.s6), (float)(a.s7*b.s7));

        public static float8 operator /(float8 a, float8 b) => new float8((float)(a.s0/b.s0), (float)(a.s1/b.s1), (float)(a.s2/b.s2), (float)(a.s3/b.s3), (float)(a.s4/b.s4), (float)(a.s5/b.s5), (float)(a.s6/b.s6), (float)(a.s7/b.s7));

        public static int8 operator ==(float8 a, float8 b) => new int8(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0, a.s4==b.s4 ? -1 : 0, a.s5==b.s5 ? -1 : 0, a.s6==b.s6 ? -1 : 0, a.s7==b.s7 ? -1 : 0);

        public static int8 operator !=(float8 a, float8 b) => new int8(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0, a.s4!=b.s4 ? -1 : 0, a.s5!=b.s5 ? -1 : 0, a.s6!=b.s6 ? -1 : 0, a.s7!=b.s7 ? -1 : 0);

        public static int8 operator <(float8 a, float8 b) => new int8(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0, a.s4<b.s4 ? -1 : 0, a.s5<b.s5 ? -1 : 0, a.s6<b.s6 ? -1 : 0, a.s7<b.s7 ? -1 : 0);

        public static int8 operator <=(float8 a, float8 b) => new int8(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0, a.s4<=b.s4 ? -1 : 0, a.s5<=b.s5 ? -1 : 0, a.s6<=b.s6 ? -1 : 0, a.s7<=b.s7 ? -1 : 0);

        public static int8 operator >(float8 a, float8 b) => new int8(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0, a.s4>b.s4 ? -1 : 0, a.s5>b.s5 ? -1 : 0, a.s6>b.s6 ? -1 : 0, a.s7>b.s7 ? -1 : 0);

        public static int8 operator >=(float8 a, float8 b) => new int8(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0, a.s4>=b.s4 ? -1 : 0, a.s5>=b.s5 ? -1 : 0, a.s6>=b.s6 ? -1 : 0, a.s7>=b.s7 ? -1 : 0);

        public static float8 operator +(float8 a) => a;

        public static float8 operator -(float8 a) => new float8((float)(-a.s0), (float)(-a.s1), (float)(-a.s2), (float)(-a.s3), (float)(-a.s4), (float)(-a.s5), (float)(-a.s6), (float)(-a.s7));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct float16: IVectorType, IEquatable<float16>
    {
        [FieldOffset(0)]
        public float s0;
        [FieldOffset(4)]
        public float s1;
        [FieldOffset(8)]
        public float s2;
        [FieldOffset(12)]
        public float s3;
        [FieldOffset(16)]
        public float s4;
        [FieldOffset(20)]
        public float s5;
        [FieldOffset(24)]
        public float s6;
        [FieldOffset(28)]
        public float s7;
        [FieldOffset(32)]
        public float s8;
        [FieldOffset(36)]
        public float s9;
        [FieldOffset(40)]
        public float sa;
        [FieldOffset(44)]
        public float sb;
        [FieldOffset(48)]
        public float sc;
        [FieldOffset(52)]
        public float sd;
        [FieldOffset(56)]
        public float se;
        [FieldOffset(60)]
        public float sf;

        public float16(float v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public float16(float v0, float v1, float v2, float v3, float v4, float v5, float v6, float v7, float v8, float v9, float va, float vb, float vc, float vd, float ve, float vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public float sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public float sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public float sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public float sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public float sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public float sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public float this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 64; }
        }

        // IEquatable

        public bool Equals(float16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is float16 && Equals((float16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static float16 operator +(float16 a, float16 b) => new float16((float)(a.s0+b.s0), (float)(a.s1+b.s1), (float)(a.s2+b.s2), (float)(a.s3+b.s3), (float)(a.s4+b.s4), (float)(a.s5+b.s5), (float)(a.s6+b.s6), (float)(a.s7+b.s7), (float)(a.s8+b.s8), (float)(a.s9+b.s9), (float)(a.sa+b.sa), (float)(a.sb+b.sb), (float)(a.sc+b.sc), (float)(a.sd+b.sd), (float)(a.se+b.se), (float)(a.sf+b.sf));

        public static float16 operator -(float16 a, float16 b) => new float16((float)(a.s0-b.s0), (float)(a.s1-b.s1), (float)(a.s2-b.s2), (float)(a.s3-b.s3), (float)(a.s4-b.s4), (float)(a.s5-b.s5), (float)(a.s6-b.s6), (float)(a.s7-b.s7), (float)(a.s8-b.s8), (float)(a.s9-b.s9), (float)(a.sa-b.sa), (float)(a.sb-b.sb), (float)(a.sc-b.sc), (float)(a.sd-b.sd), (float)(a.se-b.se), (float)(a.sf-b.sf));

        public static float16 operator *(float16 a, float16 b) => new float16((float)(a.s0*b.s0), (float)(a.s1*b.s1), (float)(a.s2*b.s2), (float)(a.s3*b.s3), (float)(a.s4*b.s4), (float)(a.s5*b.s5), (float)(a.s6*b.s6), (float)(a.s7*b.s7), (float)(a.s8*b.s8), (float)(a.s9*b.s9), (float)(a.sa*b.sa), (float)(a.sb*b.sb), (float)(a.sc*b.sc), (float)(a.sd*b.sd), (float)(a.se*b.se), (float)(a.sf*b.sf));

        public static float16 operator /(float16 a, float16 b) => new float16((float)(a.s0/b.s0), (float)(a.s1/b.s1), (float)(a.s2/b.s2), (float)(a.s3/b.s3), (float)(a.s4/b.s4), (float)(a.s5/b.s5), (float)(a.s6/b.s6), (float)(a.s7/b.s7), (float)(a.s8/b.s8), (float)(a.s9/b.s9), (float)(a.sa/b.sa), (float)(a.sb/b.sb), (float)(a.sc/b.sc), (float)(a.sd/b.sd), (float)(a.se/b.se), (float)(a.sf/b.sf));

        public static int16 operator ==(float16 a, float16 b) => new int16(a.s0==b.s0 ? -1 : 0, a.s1==b.s1 ? -1 : 0, a.s2==b.s2 ? -1 : 0, a.s3==b.s3 ? -1 : 0, a.s4==b.s4 ? -1 : 0, a.s5==b.s5 ? -1 : 0, a.s6==b.s6 ? -1 : 0, a.s7==b.s7 ? -1 : 0, a.s8==b.s8 ? -1 : 0, a.s9==b.s9 ? -1 : 0, a.sa==b.sa ? -1 : 0, a.sb==b.sb ? -1 : 0, a.sc==b.sc ? -1 : 0, a.sd==b.sd ? -1 : 0, a.se==b.se ? -1 : 0, a.sf==b.sf ? -1 : 0);

        public static int16 operator !=(float16 a, float16 b) => new int16(a.s0!=b.s0 ? -1 : 0, a.s1!=b.s1 ? -1 : 0, a.s2!=b.s2 ? -1 : 0, a.s3!=b.s3 ? -1 : 0, a.s4!=b.s4 ? -1 : 0, a.s5!=b.s5 ? -1 : 0, a.s6!=b.s6 ? -1 : 0, a.s7!=b.s7 ? -1 : 0, a.s8!=b.s8 ? -1 : 0, a.s9!=b.s9 ? -1 : 0, a.sa!=b.sa ? -1 : 0, a.sb!=b.sb ? -1 : 0, a.sc!=b.sc ? -1 : 0, a.sd!=b.sd ? -1 : 0, a.se!=b.se ? -1 : 0, a.sf!=b.sf ? -1 : 0);

        public static int16 operator <(float16 a, float16 b) => new int16(a.s0<b.s0 ? -1 : 0, a.s1<b.s1 ? -1 : 0, a.s2<b.s2 ? -1 : 0, a.s3<b.s3 ? -1 : 0, a.s4<b.s4 ? -1 : 0, a.s5<b.s5 ? -1 : 0, a.s6<b.s6 ? -1 : 0, a.s7<b.s7 ? -1 : 0, a.s8<b.s8 ? -1 : 0, a.s9<b.s9 ? -1 : 0, a.sa<b.sa ? -1 : 0, a.sb<b.sb ? -1 : 0, a.sc<b.sc ? -1 : 0, a.sd<b.sd ? -1 : 0, a.se<b.se ? -1 : 0, a.sf<b.sf ? -1 : 0);

        public static int16 operator <=(float16 a, float16 b) => new int16(a.s0<=b.s0 ? -1 : 0, a.s1<=b.s1 ? -1 : 0, a.s2<=b.s2 ? -1 : 0, a.s3<=b.s3 ? -1 : 0, a.s4<=b.s4 ? -1 : 0, a.s5<=b.s5 ? -1 : 0, a.s6<=b.s6 ? -1 : 0, a.s7<=b.s7 ? -1 : 0, a.s8<=b.s8 ? -1 : 0, a.s9<=b.s9 ? -1 : 0, a.sa<=b.sa ? -1 : 0, a.sb<=b.sb ? -1 : 0, a.sc<=b.sc ? -1 : 0, a.sd<=b.sd ? -1 : 0, a.se<=b.se ? -1 : 0, a.sf<=b.sf ? -1 : 0);

        public static int16 operator >(float16 a, float16 b) => new int16(a.s0>b.s0 ? -1 : 0, a.s1>b.s1 ? -1 : 0, a.s2>b.s2 ? -1 : 0, a.s3>b.s3 ? -1 : 0, a.s4>b.s4 ? -1 : 0, a.s5>b.s5 ? -1 : 0, a.s6>b.s6 ? -1 : 0, a.s7>b.s7 ? -1 : 0, a.s8>b.s8 ? -1 : 0, a.s9>b.s9 ? -1 : 0, a.sa>b.sa ? -1 : 0, a.sb>b.sb ? -1 : 0, a.sc>b.sc ? -1 : 0, a.sd>b.sd ? -1 : 0, a.se>b.se ? -1 : 0, a.sf>b.sf ? -1 : 0);

        public static int16 operator >=(float16 a, float16 b) => new int16(a.s0>=b.s0 ? -1 : 0, a.s1>=b.s1 ? -1 : 0, a.s2>=b.s2 ? -1 : 0, a.s3>=b.s3 ? -1 : 0, a.s4>=b.s4 ? -1 : 0, a.s5>=b.s5 ? -1 : 0, a.s6>=b.s6 ? -1 : 0, a.s7>=b.s7 ? -1 : 0, a.s8>=b.s8 ? -1 : 0, a.s9>=b.s9 ? -1 : 0, a.sa>=b.sa ? -1 : 0, a.sb>=b.sb ? -1 : 0, a.sc>=b.sc ? -1 : 0, a.sd>=b.sd ? -1 : 0, a.se>=b.se ? -1 : 0, a.sf>=b.sf ? -1 : 0);

        public static float16 operator +(float16 a) => a;

        public static float16 operator -(float16 a) => new float16((float)(-a.s0), (float)(-a.s1), (float)(-a.s2), (float)(-a.s3), (float)(-a.s4), (float)(-a.s5), (float)(-a.s6), (float)(-a.s7), (float)(-a.s8), (float)(-a.s9), (float)(-a.sa), (float)(-a.sb), (float)(-a.sc), (float)(-a.sd), (float)(-a.se), (float)(-a.sf));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1})")]
    public struct double2: IVectorType, IEquatable<double2>
    {
        [FieldOffset(0)]
        public double s0;
        [FieldOffset(8)]
        public double s1;

        public double2(double v)
        {
            this.s0 = v;
            this.s1 = v;
        }

        public double2(double2 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
        }

        public double2(double v0, double v1)
        {
            this.s0 = v0;
            this.s1 = v1;
        }

        public double x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public double y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public double2 xx
        {
            get { return new double2(this.s0, this.s0); }
        }

        public double2 xy
        {
            get { return new double2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public double2 yx
        {
            get { return new double2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public double2 yy
        {
            get { return new double2(this.s1, this.s1); }
        }

        public double this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 2, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 2; }
        }

        public int Size
        {
            get { return 16; }
        }

        // IEquatable

        public bool Equals(double2 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is double2 && Equals((double2)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.s0, this.s1);
        }

        // Operators

        public static double2 operator +(double2 a, double2 b) => new double2((double)(a.s0+b.s0), (double)(a.s1+b.s1));

        public static double2 operator -(double2 a, double2 b) => new double2((double)(a.s0-b.s0), (double)(a.s1-b.s1));

        public static double2 operator *(double2 a, double2 b) => new double2((double)(a.s0*b.s0), (double)(a.s1*b.s1));

        public static double2 operator /(double2 a, double2 b) => new double2((double)(a.s0/b.s0), (double)(a.s1/b.s1));

        public static long2 operator ==(double2 a, double2 b) => new long2(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L);

        public static long2 operator !=(double2 a, double2 b) => new long2(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L);

        public static long2 operator <(double2 a, double2 b) => new long2(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L);

        public static long2 operator <=(double2 a, double2 b) => new long2(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L);

        public static long2 operator >(double2 a, double2 b) => new long2(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L);

        public static long2 operator >=(double2 a, double2 b) => new long2(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L);

        public static double2 operator +(double2 a) => a;

        public static double2 operator -(double2 a) => new double2((double)(-a.s0), (double)(-a.s1));
    }

    [StructLayout(LayoutKind.Explicit, Size=32)]
    [DebuggerDisplay("({s0},{s1},{s2})")]
    public struct double3: IVectorType, IEquatable<double3>
    {
        [FieldOffset(0)]
        public double s0;
        [FieldOffset(8)]
        public double s1;
        [FieldOffset(16)]
        public double s2;

        public double3(double v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
        }

        public double3(double3 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
        }

        public double3(double v0, double2 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
        }

        public double3(double2 v0, double v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
        }

        public double3(double v0, double v1, double v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
        }

        public double x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public double y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public double z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public double2 xx
        {
            get { return new double2(this.s0, this.s0); }
        }

        public double2 xy
        {
            get { return new double2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public double2 xz
        {
            get { return new double2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public double2 yx
        {
            get { return new double2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public double2 yy
        {
            get { return new double2(this.s1, this.s1); }
        }

        public double2 yz
        {
            get { return new double2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public double2 zx
        {
            get { return new double2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public double2 zy
        {
            get { return new double2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public double2 zz
        {
            get { return new double2(this.s2, this.s2); }
        }

        public double3 xxx
        {
            get { return new double3(this.s0, this.s0, this.s0); }
        }

        public double3 xxy
        {
            get { return new double3(this.s0, this.s0, this.s1); }
        }

        public double3 xxz
        {
            get { return new double3(this.s0, this.s0, this.s2); }
        }

        public double3 xyx
        {
            get { return new double3(this.s0, this.s1, this.s0); }
        }

        public double3 xyy
        {
            get { return new double3(this.s0, this.s1, this.s1); }
        }

        public double3 xyz
        {
            get { return new double3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 xzx
        {
            get { return new double3(this.s0, this.s2, this.s0); }
        }

        public double3 xzy
        {
            get { return new double3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 xzz
        {
            get { return new double3(this.s0, this.s2, this.s2); }
        }

        public double3 yxx
        {
            get { return new double3(this.s1, this.s0, this.s0); }
        }

        public double3 yxy
        {
            get { return new double3(this.s1, this.s0, this.s1); }
        }

        public double3 yxz
        {
            get { return new double3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 yyx
        {
            get { return new double3(this.s1, this.s1, this.s0); }
        }

        public double3 yyy
        {
            get { return new double3(this.s1, this.s1, this.s1); }
        }

        public double3 yyz
        {
            get { return new double3(this.s1, this.s1, this.s2); }
        }

        public double3 yzx
        {
            get { return new double3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 yzy
        {
            get { return new double3(this.s1, this.s2, this.s1); }
        }

        public double3 yzz
        {
            get { return new double3(this.s1, this.s2, this.s2); }
        }

        public double3 zxx
        {
            get { return new double3(this.s2, this.s0, this.s0); }
        }

        public double3 zxy
        {
            get { return new double3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 zxz
        {
            get { return new double3(this.s2, this.s0, this.s2); }
        }

        public double3 zyx
        {
            get { return new double3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 zyy
        {
            get { return new double3(this.s2, this.s1, this.s1); }
        }

        public double3 zyz
        {
            get { return new double3(this.s2, this.s1, this.s2); }
        }

        public double3 zzx
        {
            get { return new double3(this.s2, this.s2, this.s0); }
        }

        public double3 zzy
        {
            get { return new double3(this.s2, this.s2, this.s1); }
        }

        public double3 zzz
        {
            get { return new double3(this.s2, this.s2, this.s2); }
        }

        public double this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 3, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 3; }
        }

        public int Size
        {
            get { return 24; }
        }

        // IEquatable

        public bool Equals(double3 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is double3 && Equals((double3)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2}", this.s0, this.s1, this.s2);
        }

        // Operators

        public static double3 operator +(double3 a, double3 b) => new double3((double)(a.s0+b.s0), (double)(a.s1+b.s1), (double)(a.s2+b.s2));

        public static double3 operator -(double3 a, double3 b) => new double3((double)(a.s0-b.s0), (double)(a.s1-b.s1), (double)(a.s2-b.s2));

        public static double3 operator *(double3 a, double3 b) => new double3((double)(a.s0*b.s0), (double)(a.s1*b.s1), (double)(a.s2*b.s2));

        public static double3 operator /(double3 a, double3 b) => new double3((double)(a.s0/b.s0), (double)(a.s1/b.s1), (double)(a.s2/b.s2));

        public static long3 operator ==(double3 a, double3 b) => new long3(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L);

        public static long3 operator !=(double3 a, double3 b) => new long3(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L);

        public static long3 operator <(double3 a, double3 b) => new long3(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L);

        public static long3 operator <=(double3 a, double3 b) => new long3(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L);

        public static long3 operator >(double3 a, double3 b) => new long3(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L);

        public static long3 operator >=(double3 a, double3 b) => new long3(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L);

        public static double3 operator +(double3 a) => a;

        public static double3 operator -(double3 a) => new double3((double)(-a.s0), (double)(-a.s1), (double)(-a.s2));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3})")]
    public struct double4: IVectorType, IEquatable<double4>
    {
        [FieldOffset(0)]
        public double s0;
        [FieldOffset(8)]
        public double s1;
        [FieldOffset(16)]
        public double s2;
        [FieldOffset(24)]
        public double s3;

        public double4(double v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
        }

        public double4(double4 v0)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v0.s3;
        }

        public double4(double v0, double3 v1)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v1.s2;
        }

        public double4(double2 v0, double2 v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1.s0;
            this.s3 = v1.s1;
        }

        public double4(double3 v0, double v1)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v0.s2;
            this.s3 = v1;
        }

        public double4(double v0, double v1, double2 v2)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2.s0;
            this.s3 = v2.s1;
        }

        public double4(double v0, double2 v1, double v2)
        {
            this.s0 = v0;
            this.s1 = v1.s0;
            this.s2 = v1.s1;
            this.s3 = v2;
        }

        public double4(double2 v0, double v1, double v2)
        {
            this.s0 = v0.s0;
            this.s1 = v0.s1;
            this.s2 = v1;
            this.s3 = v2;
        }

        public double4(double v0, double v1, double v2, double v3)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
        }

        public double x
        {
            get { return this.s0; }
            set { this.s0 = value; }
        }

        public double y
        {
            get { return this.s1; }
            set { this.s1 = value; }
        }

        public double z
        {
            get { return this.s2; }
            set { this.s2 = value; }
        }

        public double w
        {
            get { return this.s3; }
            set { this.s3 = value; }
        }

        public double2 xx
        {
            get { return new double2(this.s0, this.s0); }
        }

        public double2 xy
        {
            get { return new double2(this.s0, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public double2 xz
        {
            get { return new double2(this.s0, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public double2 xw
        {
            get { return new double2(this.s0, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public double2 yx
        {
            get { return new double2(this.s1, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public double2 yy
        {
            get { return new double2(this.s1, this.s1); }
        }

        public double2 yz
        {
            get { return new double2(this.s1, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public double2 yw
        {
            get { return new double2(this.s1, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public double2 zx
        {
            get { return new double2(this.s2, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public double2 zy
        {
            get { return new double2(this.s2, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public double2 zz
        {
            get { return new double2(this.s2, this.s2); }
        }

        public double2 zw
        {
            get { return new double2(this.s2, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
            }
        }

        public double2 wx
        {
            get { return new double2(this.s3, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
            }
        }

        public double2 wy
        {
            get { return new double2(this.s3, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
            }
        }

        public double2 wz
        {
            get { return new double2(this.s3, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
            }
        }

        public double2 ww
        {
            get { return new double2(this.s3, this.s3); }
        }

        public double3 xxx
        {
            get { return new double3(this.s0, this.s0, this.s0); }
        }

        public double3 xxy
        {
            get { return new double3(this.s0, this.s0, this.s1); }
        }

        public double3 xxz
        {
            get { return new double3(this.s0, this.s0, this.s2); }
        }

        public double3 xxw
        {
            get { return new double3(this.s0, this.s0, this.s3); }
        }

        public double3 xyx
        {
            get { return new double3(this.s0, this.s1, this.s0); }
        }

        public double3 xyy
        {
            get { return new double3(this.s0, this.s1, this.s1); }
        }

        public double3 xyz
        {
            get { return new double3(this.s0, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 xyw
        {
            get { return new double3(this.s0, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public double3 xzx
        {
            get { return new double3(this.s0, this.s2, this.s0); }
        }

        public double3 xzy
        {
            get { return new double3(this.s0, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 xzz
        {
            get { return new double3(this.s0, this.s2, this.s2); }
        }

        public double3 xzw
        {
            get { return new double3(this.s0, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public double3 xwx
        {
            get { return new double3(this.s0, this.s3, this.s0); }
        }

        public double3 xwy
        {
            get { return new double3(this.s0, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 xwz
        {
            get { return new double3(this.s0, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 xww
        {
            get { return new double3(this.s0, this.s3, this.s3); }
        }

        public double3 yxx
        {
            get { return new double3(this.s1, this.s0, this.s0); }
        }

        public double3 yxy
        {
            get { return new double3(this.s1, this.s0, this.s1); }
        }

        public double3 yxz
        {
            get { return new double3(this.s1, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 yxw
        {
            get { return new double3(this.s1, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public double3 yyx
        {
            get { return new double3(this.s1, this.s1, this.s0); }
        }

        public double3 yyy
        {
            get { return new double3(this.s1, this.s1, this.s1); }
        }

        public double3 yyz
        {
            get { return new double3(this.s1, this.s1, this.s2); }
        }

        public double3 yyw
        {
            get { return new double3(this.s1, this.s1, this.s3); }
        }

        public double3 yzx
        {
            get { return new double3(this.s1, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 yzy
        {
            get { return new double3(this.s1, this.s2, this.s1); }
        }

        public double3 yzz
        {
            get { return new double3(this.s1, this.s2, this.s2); }
        }

        public double3 yzw
        {
            get { return new double3(this.s1, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public double3 ywx
        {
            get { return new double3(this.s1, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 ywy
        {
            get { return new double3(this.s1, this.s3, this.s1); }
        }

        public double3 ywz
        {
            get { return new double3(this.s1, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 yww
        {
            get { return new double3(this.s1, this.s3, this.s3); }
        }

        public double3 zxx
        {
            get { return new double3(this.s2, this.s0, this.s0); }
        }

        public double3 zxy
        {
            get { return new double3(this.s2, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 zxz
        {
            get { return new double3(this.s2, this.s0, this.s2); }
        }

        public double3 zxw
        {
            get { return new double3(this.s2, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public double3 zyx
        {
            get { return new double3(this.s2, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 zyy
        {
            get { return new double3(this.s2, this.s1, this.s1); }
        }

        public double3 zyz
        {
            get { return new double3(this.s2, this.s1, this.s2); }
        }

        public double3 zyw
        {
            get { return new double3(this.s2, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
            }
        }

        public double3 zzx
        {
            get { return new double3(this.s2, this.s2, this.s0); }
        }

        public double3 zzy
        {
            get { return new double3(this.s2, this.s2, this.s1); }
        }

        public double3 zzz
        {
            get { return new double3(this.s2, this.s2, this.s2); }
        }

        public double3 zzw
        {
            get { return new double3(this.s2, this.s2, this.s3); }
        }

        public double3 zwx
        {
            get { return new double3(this.s2, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 zwy
        {
            get { return new double3(this.s2, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 zwz
        {
            get { return new double3(this.s2, this.s3, this.s2); }
        }

        public double3 zww
        {
            get { return new double3(this.s2, this.s3, this.s3); }
        }

        public double3 wxx
        {
            get { return new double3(this.s3, this.s0, this.s0); }
        }

        public double3 wxy
        {
            get { return new double3(this.s3, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 wxz
        {
            get { return new double3(this.s3, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 wxw
        {
            get { return new double3(this.s3, this.s0, this.s3); }
        }

        public double3 wyx
        {
            get { return new double3(this.s3, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 wyy
        {
            get { return new double3(this.s3, this.s1, this.s1); }
        }

        public double3 wyz
        {
            get { return new double3(this.s3, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
            }
        }

        public double3 wyw
        {
            get { return new double3(this.s3, this.s1, this.s3); }
        }

        public double3 wzx
        {
            get { return new double3(this.s3, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
            }
        }

        public double3 wzy
        {
            get { return new double3(this.s3, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
            }
        }

        public double3 wzz
        {
            get { return new double3(this.s3, this.s2, this.s2); }
        }

        public double3 wzw
        {
            get { return new double3(this.s3, this.s2, this.s3); }
        }

        public double3 wwx
        {
            get { return new double3(this.s3, this.s3, this.s0); }
        }

        public double3 wwy
        {
            get { return new double3(this.s3, this.s3, this.s1); }
        }

        public double3 wwz
        {
            get { return new double3(this.s3, this.s3, this.s2); }
        }

        public double3 www
        {
            get { return new double3(this.s3, this.s3, this.s3); }
        }

        public double4 xxxx
        {
            get { return new double4(this.s0, this.s0, this.s0, this.s0); }
        }

        public double4 xxxy
        {
            get { return new double4(this.s0, this.s0, this.s0, this.s1); }
        }

        public double4 xxxz
        {
            get { return new double4(this.s0, this.s0, this.s0, this.s2); }
        }

        public double4 xxxw
        {
            get { return new double4(this.s0, this.s0, this.s0, this.s3); }
        }

        public double4 xxyx
        {
            get { return new double4(this.s0, this.s0, this.s1, this.s0); }
        }

        public double4 xxyy
        {
            get { return new double4(this.s0, this.s0, this.s1, this.s1); }
        }

        public double4 xxyz
        {
            get { return new double4(this.s0, this.s0, this.s1, this.s2); }
        }

        public double4 xxyw
        {
            get { return new double4(this.s0, this.s0, this.s1, this.s3); }
        }

        public double4 xxzx
        {
            get { return new double4(this.s0, this.s0, this.s2, this.s0); }
        }

        public double4 xxzy
        {
            get { return new double4(this.s0, this.s0, this.s2, this.s1); }
        }

        public double4 xxzz
        {
            get { return new double4(this.s0, this.s0, this.s2, this.s2); }
        }

        public double4 xxzw
        {
            get { return new double4(this.s0, this.s0, this.s2, this.s3); }
        }

        public double4 xxwx
        {
            get { return new double4(this.s0, this.s0, this.s3, this.s0); }
        }

        public double4 xxwy
        {
            get { return new double4(this.s0, this.s0, this.s3, this.s1); }
        }

        public double4 xxwz
        {
            get { return new double4(this.s0, this.s0, this.s3, this.s2); }
        }

        public double4 xxww
        {
            get { return new double4(this.s0, this.s0, this.s3, this.s3); }
        }

        public double4 xyxx
        {
            get { return new double4(this.s0, this.s1, this.s0, this.s0); }
        }

        public double4 xyxy
        {
            get { return new double4(this.s0, this.s1, this.s0, this.s1); }
        }

        public double4 xyxz
        {
            get { return new double4(this.s0, this.s1, this.s0, this.s2); }
        }

        public double4 xyxw
        {
            get { return new double4(this.s0, this.s1, this.s0, this.s3); }
        }

        public double4 xyyx
        {
            get { return new double4(this.s0, this.s1, this.s1, this.s0); }
        }

        public double4 xyyy
        {
            get { return new double4(this.s0, this.s1, this.s1, this.s1); }
        }

        public double4 xyyz
        {
            get { return new double4(this.s0, this.s1, this.s1, this.s2); }
        }

        public double4 xyyw
        {
            get { return new double4(this.s0, this.s1, this.s1, this.s3); }
        }

        public double4 xyzx
        {
            get { return new double4(this.s0, this.s1, this.s2, this.s0); }
        }

        public double4 xyzy
        {
            get { return new double4(this.s0, this.s1, this.s2, this.s1); }
        }

        public double4 xyzz
        {
            get { return new double4(this.s0, this.s1, this.s2, this.s2); }
        }

        public double4 xyzw
        {
            get { return new double4(this.s0, this.s1, this.s2, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public double4 xywx
        {
            get { return new double4(this.s0, this.s1, this.s3, this.s0); }
        }

        public double4 xywy
        {
            get { return new double4(this.s0, this.s1, this.s3, this.s1); }
        }

        public double4 xywz
        {
            get { return new double4(this.s0, this.s1, this.s3, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public double4 xyww
        {
            get { return new double4(this.s0, this.s1, this.s3, this.s3); }
        }

        public double4 xzxx
        {
            get { return new double4(this.s0, this.s2, this.s0, this.s0); }
        }

        public double4 xzxy
        {
            get { return new double4(this.s0, this.s2, this.s0, this.s1); }
        }

        public double4 xzxz
        {
            get { return new double4(this.s0, this.s2, this.s0, this.s2); }
        }

        public double4 xzxw
        {
            get { return new double4(this.s0, this.s2, this.s0, this.s3); }
        }

        public double4 xzyx
        {
            get { return new double4(this.s0, this.s2, this.s1, this.s0); }
        }

        public double4 xzyy
        {
            get { return new double4(this.s0, this.s2, this.s1, this.s1); }
        }

        public double4 xzyz
        {
            get { return new double4(this.s0, this.s2, this.s1, this.s2); }
        }

        public double4 xzyw
        {
            get { return new double4(this.s0, this.s2, this.s1, this.s3); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public double4 xzzx
        {
            get { return new double4(this.s0, this.s2, this.s2, this.s0); }
        }

        public double4 xzzy
        {
            get { return new double4(this.s0, this.s2, this.s2, this.s1); }
        }

        public double4 xzzz
        {
            get { return new double4(this.s0, this.s2, this.s2, this.s2); }
        }

        public double4 xzzw
        {
            get { return new double4(this.s0, this.s2, this.s2, this.s3); }
        }

        public double4 xzwx
        {
            get { return new double4(this.s0, this.s2, this.s3, this.s0); }
        }

        public double4 xzwy
        {
            get { return new double4(this.s0, this.s2, this.s3, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public double4 xzwz
        {
            get { return new double4(this.s0, this.s2, this.s3, this.s2); }
        }

        public double4 xzww
        {
            get { return new double4(this.s0, this.s2, this.s3, this.s3); }
        }

        public double4 xwxx
        {
            get { return new double4(this.s0, this.s3, this.s0, this.s0); }
        }

        public double4 xwxy
        {
            get { return new double4(this.s0, this.s3, this.s0, this.s1); }
        }

        public double4 xwxz
        {
            get { return new double4(this.s0, this.s3, this.s0, this.s2); }
        }

        public double4 xwxw
        {
            get { return new double4(this.s0, this.s3, this.s0, this.s3); }
        }

        public double4 xwyx
        {
            get { return new double4(this.s0, this.s3, this.s1, this.s0); }
        }

        public double4 xwyy
        {
            get { return new double4(this.s0, this.s3, this.s1, this.s1); }
        }

        public double4 xwyz
        {
            get { return new double4(this.s0, this.s3, this.s1, this.s2); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public double4 xwyw
        {
            get { return new double4(this.s0, this.s3, this.s1, this.s3); }
        }

        public double4 xwzx
        {
            get { return new double4(this.s0, this.s3, this.s2, this.s0); }
        }

        public double4 xwzy
        {
            get { return new double4(this.s0, this.s3, this.s2, this.s1); }
            set {
                 this.s0 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public double4 xwzz
        {
            get { return new double4(this.s0, this.s3, this.s2, this.s2); }
        }

        public double4 xwzw
        {
            get { return new double4(this.s0, this.s3, this.s2, this.s3); }
        }

        public double4 xwwx
        {
            get { return new double4(this.s0, this.s3, this.s3, this.s0); }
        }

        public double4 xwwy
        {
            get { return new double4(this.s0, this.s3, this.s3, this.s1); }
        }

        public double4 xwwz
        {
            get { return new double4(this.s0, this.s3, this.s3, this.s2); }
        }

        public double4 xwww
        {
            get { return new double4(this.s0, this.s3, this.s3, this.s3); }
        }

        public double4 yxxx
        {
            get { return new double4(this.s1, this.s0, this.s0, this.s0); }
        }

        public double4 yxxy
        {
            get { return new double4(this.s1, this.s0, this.s0, this.s1); }
        }

        public double4 yxxz
        {
            get { return new double4(this.s1, this.s0, this.s0, this.s2); }
        }

        public double4 yxxw
        {
            get { return new double4(this.s1, this.s0, this.s0, this.s3); }
        }

        public double4 yxyx
        {
            get { return new double4(this.s1, this.s0, this.s1, this.s0); }
        }

        public double4 yxyy
        {
            get { return new double4(this.s1, this.s0, this.s1, this.s1); }
        }

        public double4 yxyz
        {
            get { return new double4(this.s1, this.s0, this.s1, this.s2); }
        }

        public double4 yxyw
        {
            get { return new double4(this.s1, this.s0, this.s1, this.s3); }
        }

        public double4 yxzx
        {
            get { return new double4(this.s1, this.s0, this.s2, this.s0); }
        }

        public double4 yxzy
        {
            get { return new double4(this.s1, this.s0, this.s2, this.s1); }
        }

        public double4 yxzz
        {
            get { return new double4(this.s1, this.s0, this.s2, this.s2); }
        }

        public double4 yxzw
        {
            get { return new double4(this.s1, this.s0, this.s2, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public double4 yxwx
        {
            get { return new double4(this.s1, this.s0, this.s3, this.s0); }
        }

        public double4 yxwy
        {
            get { return new double4(this.s1, this.s0, this.s3, this.s1); }
        }

        public double4 yxwz
        {
            get { return new double4(this.s1, this.s0, this.s3, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public double4 yxww
        {
            get { return new double4(this.s1, this.s0, this.s3, this.s3); }
        }

        public double4 yyxx
        {
            get { return new double4(this.s1, this.s1, this.s0, this.s0); }
        }

        public double4 yyxy
        {
            get { return new double4(this.s1, this.s1, this.s0, this.s1); }
        }

        public double4 yyxz
        {
            get { return new double4(this.s1, this.s1, this.s0, this.s2); }
        }

        public double4 yyxw
        {
            get { return new double4(this.s1, this.s1, this.s0, this.s3); }
        }

        public double4 yyyx
        {
            get { return new double4(this.s1, this.s1, this.s1, this.s0); }
        }

        public double4 yyyy
        {
            get { return new double4(this.s1, this.s1, this.s1, this.s1); }
        }

        public double4 yyyz
        {
            get { return new double4(this.s1, this.s1, this.s1, this.s2); }
        }

        public double4 yyyw
        {
            get { return new double4(this.s1, this.s1, this.s1, this.s3); }
        }

        public double4 yyzx
        {
            get { return new double4(this.s1, this.s1, this.s2, this.s0); }
        }

        public double4 yyzy
        {
            get { return new double4(this.s1, this.s1, this.s2, this.s1); }
        }

        public double4 yyzz
        {
            get { return new double4(this.s1, this.s1, this.s2, this.s2); }
        }

        public double4 yyzw
        {
            get { return new double4(this.s1, this.s1, this.s2, this.s3); }
        }

        public double4 yywx
        {
            get { return new double4(this.s1, this.s1, this.s3, this.s0); }
        }

        public double4 yywy
        {
            get { return new double4(this.s1, this.s1, this.s3, this.s1); }
        }

        public double4 yywz
        {
            get { return new double4(this.s1, this.s1, this.s3, this.s2); }
        }

        public double4 yyww
        {
            get { return new double4(this.s1, this.s1, this.s3, this.s3); }
        }

        public double4 yzxx
        {
            get { return new double4(this.s1, this.s2, this.s0, this.s0); }
        }

        public double4 yzxy
        {
            get { return new double4(this.s1, this.s2, this.s0, this.s1); }
        }

        public double4 yzxz
        {
            get { return new double4(this.s1, this.s2, this.s0, this.s2); }
        }

        public double4 yzxw
        {
            get { return new double4(this.s1, this.s2, this.s0, this.s3); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public double4 yzyx
        {
            get { return new double4(this.s1, this.s2, this.s1, this.s0); }
        }

        public double4 yzyy
        {
            get { return new double4(this.s1, this.s2, this.s1, this.s1); }
        }

        public double4 yzyz
        {
            get { return new double4(this.s1, this.s2, this.s1, this.s2); }
        }

        public double4 yzyw
        {
            get { return new double4(this.s1, this.s2, this.s1, this.s3); }
        }

        public double4 yzzx
        {
            get { return new double4(this.s1, this.s2, this.s2, this.s0); }
        }

        public double4 yzzy
        {
            get { return new double4(this.s1, this.s2, this.s2, this.s1); }
        }

        public double4 yzzz
        {
            get { return new double4(this.s1, this.s2, this.s2, this.s2); }
        }

        public double4 yzzw
        {
            get { return new double4(this.s1, this.s2, this.s2, this.s3); }
        }

        public double4 yzwx
        {
            get { return new double4(this.s1, this.s2, this.s3, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s2 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public double4 yzwy
        {
            get { return new double4(this.s1, this.s2, this.s3, this.s1); }
        }

        public double4 yzwz
        {
            get { return new double4(this.s1, this.s2, this.s3, this.s2); }
        }

        public double4 yzww
        {
            get { return new double4(this.s1, this.s2, this.s3, this.s3); }
        }

        public double4 ywxx
        {
            get { return new double4(this.s1, this.s3, this.s0, this.s0); }
        }

        public double4 ywxy
        {
            get { return new double4(this.s1, this.s3, this.s0, this.s1); }
        }

        public double4 ywxz
        {
            get { return new double4(this.s1, this.s3, this.s0, this.s2); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public double4 ywxw
        {
            get { return new double4(this.s1, this.s3, this.s0, this.s3); }
        }

        public double4 ywyx
        {
            get { return new double4(this.s1, this.s3, this.s1, this.s0); }
        }

        public double4 ywyy
        {
            get { return new double4(this.s1, this.s3, this.s1, this.s1); }
        }

        public double4 ywyz
        {
            get { return new double4(this.s1, this.s3, this.s1, this.s2); }
        }

        public double4 ywyw
        {
            get { return new double4(this.s1, this.s3, this.s1, this.s3); }
        }

        public double4 ywzx
        {
            get { return new double4(this.s1, this.s3, this.s2, this.s0); }
            set {
                 this.s1 = value.s0;
                 this.s3 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public double4 ywzy
        {
            get { return new double4(this.s1, this.s3, this.s2, this.s1); }
        }

        public double4 ywzz
        {
            get { return new double4(this.s1, this.s3, this.s2, this.s2); }
        }

        public double4 ywzw
        {
            get { return new double4(this.s1, this.s3, this.s2, this.s3); }
        }

        public double4 ywwx
        {
            get { return new double4(this.s1, this.s3, this.s3, this.s0); }
        }

        public double4 ywwy
        {
            get { return new double4(this.s1, this.s3, this.s3, this.s1); }
        }

        public double4 ywwz
        {
            get { return new double4(this.s1, this.s3, this.s3, this.s2); }
        }

        public double4 ywww
        {
            get { return new double4(this.s1, this.s3, this.s3, this.s3); }
        }

        public double4 zxxx
        {
            get { return new double4(this.s2, this.s0, this.s0, this.s0); }
        }

        public double4 zxxy
        {
            get { return new double4(this.s2, this.s0, this.s0, this.s1); }
        }

        public double4 zxxz
        {
            get { return new double4(this.s2, this.s0, this.s0, this.s2); }
        }

        public double4 zxxw
        {
            get { return new double4(this.s2, this.s0, this.s0, this.s3); }
        }

        public double4 zxyx
        {
            get { return new double4(this.s2, this.s0, this.s1, this.s0); }
        }

        public double4 zxyy
        {
            get { return new double4(this.s2, this.s0, this.s1, this.s1); }
        }

        public double4 zxyz
        {
            get { return new double4(this.s2, this.s0, this.s1, this.s2); }
        }

        public double4 zxyw
        {
            get { return new double4(this.s2, this.s0, this.s1, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public double4 zxzx
        {
            get { return new double4(this.s2, this.s0, this.s2, this.s0); }
        }

        public double4 zxzy
        {
            get { return new double4(this.s2, this.s0, this.s2, this.s1); }
        }

        public double4 zxzz
        {
            get { return new double4(this.s2, this.s0, this.s2, this.s2); }
        }

        public double4 zxzw
        {
            get { return new double4(this.s2, this.s0, this.s2, this.s3); }
        }

        public double4 zxwx
        {
            get { return new double4(this.s2, this.s0, this.s3, this.s0); }
        }

        public double4 zxwy
        {
            get { return new double4(this.s2, this.s0, this.s3, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s0 = value.s1;
                 this.s3 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public double4 zxwz
        {
            get { return new double4(this.s2, this.s0, this.s3, this.s2); }
        }

        public double4 zxww
        {
            get { return new double4(this.s2, this.s0, this.s3, this.s3); }
        }

        public double4 zyxx
        {
            get { return new double4(this.s2, this.s1, this.s0, this.s0); }
        }

        public double4 zyxy
        {
            get { return new double4(this.s2, this.s1, this.s0, this.s1); }
        }

        public double4 zyxz
        {
            get { return new double4(this.s2, this.s1, this.s0, this.s2); }
        }

        public double4 zyxw
        {
            get { return new double4(this.s2, this.s1, this.s0, this.s3); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s3 = value.s3;
            }
        }

        public double4 zyyx
        {
            get { return new double4(this.s2, this.s1, this.s1, this.s0); }
        }

        public double4 zyyy
        {
            get { return new double4(this.s2, this.s1, this.s1, this.s1); }
        }

        public double4 zyyz
        {
            get { return new double4(this.s2, this.s1, this.s1, this.s2); }
        }

        public double4 zyyw
        {
            get { return new double4(this.s2, this.s1, this.s1, this.s3); }
        }

        public double4 zyzx
        {
            get { return new double4(this.s2, this.s1, this.s2, this.s0); }
        }

        public double4 zyzy
        {
            get { return new double4(this.s2, this.s1, this.s2, this.s1); }
        }

        public double4 zyzz
        {
            get { return new double4(this.s2, this.s1, this.s2, this.s2); }
        }

        public double4 zyzw
        {
            get { return new double4(this.s2, this.s1, this.s2, this.s3); }
        }

        public double4 zywx
        {
            get { return new double4(this.s2, this.s1, this.s3, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s1 = value.s1;
                 this.s3 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public double4 zywy
        {
            get { return new double4(this.s2, this.s1, this.s3, this.s1); }
        }

        public double4 zywz
        {
            get { return new double4(this.s2, this.s1, this.s3, this.s2); }
        }

        public double4 zyww
        {
            get { return new double4(this.s2, this.s1, this.s3, this.s3); }
        }

        public double4 zzxx
        {
            get { return new double4(this.s2, this.s2, this.s0, this.s0); }
        }

        public double4 zzxy
        {
            get { return new double4(this.s2, this.s2, this.s0, this.s1); }
        }

        public double4 zzxz
        {
            get { return new double4(this.s2, this.s2, this.s0, this.s2); }
        }

        public double4 zzxw
        {
            get { return new double4(this.s2, this.s2, this.s0, this.s3); }
        }

        public double4 zzyx
        {
            get { return new double4(this.s2, this.s2, this.s1, this.s0); }
        }

        public double4 zzyy
        {
            get { return new double4(this.s2, this.s2, this.s1, this.s1); }
        }

        public double4 zzyz
        {
            get { return new double4(this.s2, this.s2, this.s1, this.s2); }
        }

        public double4 zzyw
        {
            get { return new double4(this.s2, this.s2, this.s1, this.s3); }
        }

        public double4 zzzx
        {
            get { return new double4(this.s2, this.s2, this.s2, this.s0); }
        }

        public double4 zzzy
        {
            get { return new double4(this.s2, this.s2, this.s2, this.s1); }
        }

        public double4 zzzz
        {
            get { return new double4(this.s2, this.s2, this.s2, this.s2); }
        }

        public double4 zzzw
        {
            get { return new double4(this.s2, this.s2, this.s2, this.s3); }
        }

        public double4 zzwx
        {
            get { return new double4(this.s2, this.s2, this.s3, this.s0); }
        }

        public double4 zzwy
        {
            get { return new double4(this.s2, this.s2, this.s3, this.s1); }
        }

        public double4 zzwz
        {
            get { return new double4(this.s2, this.s2, this.s3, this.s2); }
        }

        public double4 zzww
        {
            get { return new double4(this.s2, this.s2, this.s3, this.s3); }
        }

        public double4 zwxx
        {
            get { return new double4(this.s2, this.s3, this.s0, this.s0); }
        }

        public double4 zwxy
        {
            get { return new double4(this.s2, this.s3, this.s0, this.s1); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public double4 zwxz
        {
            get { return new double4(this.s2, this.s3, this.s0, this.s2); }
        }

        public double4 zwxw
        {
            get { return new double4(this.s2, this.s3, this.s0, this.s3); }
        }

        public double4 zwyx
        {
            get { return new double4(this.s2, this.s3, this.s1, this.s0); }
            set {
                 this.s2 = value.s0;
                 this.s3 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public double4 zwyy
        {
            get { return new double4(this.s2, this.s3, this.s1, this.s1); }
        }

        public double4 zwyz
        {
            get { return new double4(this.s2, this.s3, this.s1, this.s2); }
        }

        public double4 zwyw
        {
            get { return new double4(this.s2, this.s3, this.s1, this.s3); }
        }

        public double4 zwzx
        {
            get { return new double4(this.s2, this.s3, this.s2, this.s0); }
        }

        public double4 zwzy
        {
            get { return new double4(this.s2, this.s3, this.s2, this.s1); }
        }

        public double4 zwzz
        {
            get { return new double4(this.s2, this.s3, this.s2, this.s2); }
        }

        public double4 zwzw
        {
            get { return new double4(this.s2, this.s3, this.s2, this.s3); }
        }

        public double4 zwwx
        {
            get { return new double4(this.s2, this.s3, this.s3, this.s0); }
        }

        public double4 zwwy
        {
            get { return new double4(this.s2, this.s3, this.s3, this.s1); }
        }

        public double4 zwwz
        {
            get { return new double4(this.s2, this.s3, this.s3, this.s2); }
        }

        public double4 zwww
        {
            get { return new double4(this.s2, this.s3, this.s3, this.s3); }
        }

        public double4 wxxx
        {
            get { return new double4(this.s3, this.s0, this.s0, this.s0); }
        }

        public double4 wxxy
        {
            get { return new double4(this.s3, this.s0, this.s0, this.s1); }
        }

        public double4 wxxz
        {
            get { return new double4(this.s3, this.s0, this.s0, this.s2); }
        }

        public double4 wxxw
        {
            get { return new double4(this.s3, this.s0, this.s0, this.s3); }
        }

        public double4 wxyx
        {
            get { return new double4(this.s3, this.s0, this.s1, this.s0); }
        }

        public double4 wxyy
        {
            get { return new double4(this.s3, this.s0, this.s1, this.s1); }
        }

        public double4 wxyz
        {
            get { return new double4(this.s3, this.s0, this.s1, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s1 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public double4 wxyw
        {
            get { return new double4(this.s3, this.s0, this.s1, this.s3); }
        }

        public double4 wxzx
        {
            get { return new double4(this.s3, this.s0, this.s2, this.s0); }
        }

        public double4 wxzy
        {
            get { return new double4(this.s3, this.s0, this.s2, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s0 = value.s1;
                 this.s2 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public double4 wxzz
        {
            get { return new double4(this.s3, this.s0, this.s2, this.s2); }
        }

        public double4 wxzw
        {
            get { return new double4(this.s3, this.s0, this.s2, this.s3); }
        }

        public double4 wxwx
        {
            get { return new double4(this.s3, this.s0, this.s3, this.s0); }
        }

        public double4 wxwy
        {
            get { return new double4(this.s3, this.s0, this.s3, this.s1); }
        }

        public double4 wxwz
        {
            get { return new double4(this.s3, this.s0, this.s3, this.s2); }
        }

        public double4 wxww
        {
            get { return new double4(this.s3, this.s0, this.s3, this.s3); }
        }

        public double4 wyxx
        {
            get { return new double4(this.s3, this.s1, this.s0, this.s0); }
        }

        public double4 wyxy
        {
            get { return new double4(this.s3, this.s1, this.s0, this.s1); }
        }

        public double4 wyxz
        {
            get { return new double4(this.s3, this.s1, this.s0, this.s2); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s0 = value.s2;
                 this.s2 = value.s3;
            }
        }

        public double4 wyxw
        {
            get { return new double4(this.s3, this.s1, this.s0, this.s3); }
        }

        public double4 wyyx
        {
            get { return new double4(this.s3, this.s1, this.s1, this.s0); }
        }

        public double4 wyyy
        {
            get { return new double4(this.s3, this.s1, this.s1, this.s1); }
        }

        public double4 wyyz
        {
            get { return new double4(this.s3, this.s1, this.s1, this.s2); }
        }

        public double4 wyyw
        {
            get { return new double4(this.s3, this.s1, this.s1, this.s3); }
        }

        public double4 wyzx
        {
            get { return new double4(this.s3, this.s1, this.s2, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s1 = value.s1;
                 this.s2 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public double4 wyzy
        {
            get { return new double4(this.s3, this.s1, this.s2, this.s1); }
        }

        public double4 wyzz
        {
            get { return new double4(this.s3, this.s1, this.s2, this.s2); }
        }

        public double4 wyzw
        {
            get { return new double4(this.s3, this.s1, this.s2, this.s3); }
        }

        public double4 wywx
        {
            get { return new double4(this.s3, this.s1, this.s3, this.s0); }
        }

        public double4 wywy
        {
            get { return new double4(this.s3, this.s1, this.s3, this.s1); }
        }

        public double4 wywz
        {
            get { return new double4(this.s3, this.s1, this.s3, this.s2); }
        }

        public double4 wyww
        {
            get { return new double4(this.s3, this.s1, this.s3, this.s3); }
        }

        public double4 wzxx
        {
            get { return new double4(this.s3, this.s2, this.s0, this.s0); }
        }

        public double4 wzxy
        {
            get { return new double4(this.s3, this.s2, this.s0, this.s1); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s0 = value.s2;
                 this.s1 = value.s3;
            }
        }

        public double4 wzxz
        {
            get { return new double4(this.s3, this.s2, this.s0, this.s2); }
        }

        public double4 wzxw
        {
            get { return new double4(this.s3, this.s2, this.s0, this.s3); }
        }

        public double4 wzyx
        {
            get { return new double4(this.s3, this.s2, this.s1, this.s0); }
            set {
                 this.s3 = value.s0;
                 this.s2 = value.s1;
                 this.s1 = value.s2;
                 this.s0 = value.s3;
            }
        }

        public double4 wzyy
        {
            get { return new double4(this.s3, this.s2, this.s1, this.s1); }
        }

        public double4 wzyz
        {
            get { return new double4(this.s3, this.s2, this.s1, this.s2); }
        }

        public double4 wzyw
        {
            get { return new double4(this.s3, this.s2, this.s1, this.s3); }
        }

        public double4 wzzx
        {
            get { return new double4(this.s3, this.s2, this.s2, this.s0); }
        }

        public double4 wzzy
        {
            get { return new double4(this.s3, this.s2, this.s2, this.s1); }
        }

        public double4 wzzz
        {
            get { return new double4(this.s3, this.s2, this.s2, this.s2); }
        }

        public double4 wzzw
        {
            get { return new double4(this.s3, this.s2, this.s2, this.s3); }
        }

        public double4 wzwx
        {
            get { return new double4(this.s3, this.s2, this.s3, this.s0); }
        }

        public double4 wzwy
        {
            get { return new double4(this.s3, this.s2, this.s3, this.s1); }
        }

        public double4 wzwz
        {
            get { return new double4(this.s3, this.s2, this.s3, this.s2); }
        }

        public double4 wzww
        {
            get { return new double4(this.s3, this.s2, this.s3, this.s3); }
        }

        public double4 wwxx
        {
            get { return new double4(this.s3, this.s3, this.s0, this.s0); }
        }

        public double4 wwxy
        {
            get { return new double4(this.s3, this.s3, this.s0, this.s1); }
        }

        public double4 wwxz
        {
            get { return new double4(this.s3, this.s3, this.s0, this.s2); }
        }

        public double4 wwxw
        {
            get { return new double4(this.s3, this.s3, this.s0, this.s3); }
        }

        public double4 wwyx
        {
            get { return new double4(this.s3, this.s3, this.s1, this.s0); }
        }

        public double4 wwyy
        {
            get { return new double4(this.s3, this.s3, this.s1, this.s1); }
        }

        public double4 wwyz
        {
            get { return new double4(this.s3, this.s3, this.s1, this.s2); }
        }

        public double4 wwyw
        {
            get { return new double4(this.s3, this.s3, this.s1, this.s3); }
        }

        public double4 wwzx
        {
            get { return new double4(this.s3, this.s3, this.s2, this.s0); }
        }

        public double4 wwzy
        {
            get { return new double4(this.s3, this.s3, this.s2, this.s1); }
        }

        public double4 wwzz
        {
            get { return new double4(this.s3, this.s3, this.s2, this.s2); }
        }

        public double4 wwzw
        {
            get { return new double4(this.s3, this.s3, this.s2, this.s3); }
        }

        public double4 wwwx
        {
            get { return new double4(this.s3, this.s3, this.s3, this.s0); }
        }

        public double4 wwwy
        {
            get { return new double4(this.s3, this.s3, this.s3, this.s1); }
        }

        public double4 wwwz
        {
            get { return new double4(this.s3, this.s3, this.s3, this.s2); }
        }

        public double4 wwww
        {
            get { return new double4(this.s3, this.s3, this.s3, this.s3); }
        }

        public double this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 4, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 4; }
        }

        public int Size
        {
            get { return 32; }
        }

        // IEquatable

        public bool Equals(double4 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is double4 && Equals((double4)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}", this.s0, this.s1, this.s2, this.s3);
        }

        // Operators

        public static double4 operator +(double4 a, double4 b) => new double4((double)(a.s0+b.s0), (double)(a.s1+b.s1), (double)(a.s2+b.s2), (double)(a.s3+b.s3));

        public static double4 operator -(double4 a, double4 b) => new double4((double)(a.s0-b.s0), (double)(a.s1-b.s1), (double)(a.s2-b.s2), (double)(a.s3-b.s3));

        public static double4 operator *(double4 a, double4 b) => new double4((double)(a.s0*b.s0), (double)(a.s1*b.s1), (double)(a.s2*b.s2), (double)(a.s3*b.s3));

        public static double4 operator /(double4 a, double4 b) => new double4((double)(a.s0/b.s0), (double)(a.s1/b.s1), (double)(a.s2/b.s2), (double)(a.s3/b.s3));

        public static long4 operator ==(double4 a, double4 b) => new long4(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L);

        public static long4 operator !=(double4 a, double4 b) => new long4(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L);

        public static long4 operator <(double4 a, double4 b) => new long4(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L);

        public static long4 operator <=(double4 a, double4 b) => new long4(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L);

        public static long4 operator >(double4 a, double4 b) => new long4(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L);

        public static long4 operator >=(double4 a, double4 b) => new long4(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L);

        public static double4 operator +(double4 a) => a;

        public static double4 operator -(double4 a) => new double4((double)(-a.s0), (double)(-a.s1), (double)(-a.s2), (double)(-a.s3));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7})")]
    public struct double8: IVectorType, IEquatable<double8>
    {
        [FieldOffset(0)]
        public double s0;
        [FieldOffset(8)]
        public double s1;
        [FieldOffset(16)]
        public double s2;
        [FieldOffset(24)]
        public double s3;
        [FieldOffset(32)]
        public double s4;
        [FieldOffset(40)]
        public double s5;
        [FieldOffset(48)]
        public double s6;
        [FieldOffset(56)]
        public double s7;

        public double8(double v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
        }

        public double8(double v0, double v1, double v2, double v3, double v4, double v5, double v6, double v7)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
        }

        public double this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 8, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 8; }
        }

        public int Size
        {
            get { return 64; }
        }

        // IEquatable

        public bool Equals(double8 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is double8 && Equals((double8)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7);
        }

        // Operators

        public static double8 operator +(double8 a, double8 b) => new double8((double)(a.s0+b.s0), (double)(a.s1+b.s1), (double)(a.s2+b.s2), (double)(a.s3+b.s3), (double)(a.s4+b.s4), (double)(a.s5+b.s5), (double)(a.s6+b.s6), (double)(a.s7+b.s7));

        public static double8 operator -(double8 a, double8 b) => new double8((double)(a.s0-b.s0), (double)(a.s1-b.s1), (double)(a.s2-b.s2), (double)(a.s3-b.s3), (double)(a.s4-b.s4), (double)(a.s5-b.s5), (double)(a.s6-b.s6), (double)(a.s7-b.s7));

        public static double8 operator *(double8 a, double8 b) => new double8((double)(a.s0*b.s0), (double)(a.s1*b.s1), (double)(a.s2*b.s2), (double)(a.s3*b.s3), (double)(a.s4*b.s4), (double)(a.s5*b.s5), (double)(a.s6*b.s6), (double)(a.s7*b.s7));

        public static double8 operator /(double8 a, double8 b) => new double8((double)(a.s0/b.s0), (double)(a.s1/b.s1), (double)(a.s2/b.s2), (double)(a.s3/b.s3), (double)(a.s4/b.s4), (double)(a.s5/b.s5), (double)(a.s6/b.s6), (double)(a.s7/b.s7));

        public static long8 operator ==(double8 a, double8 b) => new long8(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L, a.s4==b.s4 ? -1L : 0L, a.s5==b.s5 ? -1L : 0L, a.s6==b.s6 ? -1L : 0L, a.s7==b.s7 ? -1L : 0L);

        public static long8 operator !=(double8 a, double8 b) => new long8(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L, a.s4!=b.s4 ? -1L : 0L, a.s5!=b.s5 ? -1L : 0L, a.s6!=b.s6 ? -1L : 0L, a.s7!=b.s7 ? -1L : 0L);

        public static long8 operator <(double8 a, double8 b) => new long8(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L, a.s4<b.s4 ? -1L : 0L, a.s5<b.s5 ? -1L : 0L, a.s6<b.s6 ? -1L : 0L, a.s7<b.s7 ? -1L : 0L);

        public static long8 operator <=(double8 a, double8 b) => new long8(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L, a.s4<=b.s4 ? -1L : 0L, a.s5<=b.s5 ? -1L : 0L, a.s6<=b.s6 ? -1L : 0L, a.s7<=b.s7 ? -1L : 0L);

        public static long8 operator >(double8 a, double8 b) => new long8(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L, a.s4>b.s4 ? -1L : 0L, a.s5>b.s5 ? -1L : 0L, a.s6>b.s6 ? -1L : 0L, a.s7>b.s7 ? -1L : 0L);

        public static long8 operator >=(double8 a, double8 b) => new long8(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L, a.s4>=b.s4 ? -1L : 0L, a.s5>=b.s5 ? -1L : 0L, a.s6>=b.s6 ? -1L : 0L, a.s7>=b.s7 ? -1L : 0L);

        public static double8 operator +(double8 a) => a;

        public static double8 operator -(double8 a) => new double8((double)(-a.s0), (double)(-a.s1), (double)(-a.s2), (double)(-a.s3), (double)(-a.s4), (double)(-a.s5), (double)(-a.s6), (double)(-a.s7));
    }

    [StructLayout(LayoutKind.Explicit)]
    [DebuggerDisplay("({s0},{s1},{s2},{s3},{s4},{s5},{s6},{s7},{s8},{s9},{sa},{sb},{sc},{sd},{se},{sf})")]
    public struct double16: IVectorType, IEquatable<double16>
    {
        [FieldOffset(0)]
        public double s0;
        [FieldOffset(8)]
        public double s1;
        [FieldOffset(16)]
        public double s2;
        [FieldOffset(24)]
        public double s3;
        [FieldOffset(32)]
        public double s4;
        [FieldOffset(40)]
        public double s5;
        [FieldOffset(48)]
        public double s6;
        [FieldOffset(56)]
        public double s7;
        [FieldOffset(64)]
        public double s8;
        [FieldOffset(72)]
        public double s9;
        [FieldOffset(80)]
        public double sa;
        [FieldOffset(88)]
        public double sb;
        [FieldOffset(96)]
        public double sc;
        [FieldOffset(104)]
        public double sd;
        [FieldOffset(112)]
        public double se;
        [FieldOffset(120)]
        public double sf;

        public double16(double v)
        {
            this.s0 = v;
            this.s1 = v;
            this.s2 = v;
            this.s3 = v;
            this.s4 = v;
            this.s5 = v;
            this.s6 = v;
            this.s7 = v;
            this.s8 = v;
            this.s9 = v;
            this.sa = v;
            this.sb = v;
            this.sc = v;
            this.sd = v;
            this.se = v;
            this.sf = v;
        }

        public double16(double v0, double v1, double v2, double v3, double v4, double v5, double v6, double v7, double v8, double v9, double va, double vb, double vc, double vd, double ve, double vf)
        {
            this.s0 = v0;
            this.s1 = v1;
            this.s2 = v2;
            this.s3 = v3;
            this.s4 = v4;
            this.s5 = v5;
            this.s6 = v6;
            this.s7 = v7;
            this.s8 = v8;
            this.s9 = v9;
            this.sa = va;
            this.sb = vb;
            this.sc = vc;
            this.sd = vd;
            this.se = ve;
            this.sf = vf;
        }

        public double sA
        {
            get { return this.sa; }
            set { this.sa = value; }
        }

        public double sB
        {
            get { return this.sb; }
            set { this.sb = value; }
        }

        public double sC
        {
            get { return this.sc; }
            set { this.sc = value; }
        }

        public double sD
        {
            get { return this.sd; }
            set { this.sd = value; }
        }

        public double sE
        {
            get { return this.se; }
            set { this.se = value; }
        }

        public double sF
        {
            get { return this.sf; }
            set { this.sf = value; }
        }

        public double this[int index]
        {
            get  {
                switch (index)
                {
                case 0:
                    return this.s0;
                case 1:
                    return this.s1;
                case 2:
                    return this.s2;
                case 3:
                    return this.s3;
                case 4:
                    return this.s4;
                case 5:
                    return this.s5;
                case 6:
                    return this.s6;
                case 7:
                    return this.s7;
                case 8:
                    return this.s8;
                case 9:
                    return this.s9;
                case 10:
                    return this.sa;
                case 11:
                    return this.sb;
                case 12:
                    return this.sc;
                case 13:
                    return this.sd;
                case 14:
                    return this.se;
                case 15:
                    return this.sf;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
            set {
                switch (index)
                {
                case 0:
                    this.s0 = value;
                    break;
                case 1:
                    this.s1 = value;
                    break;
                case 2:
                    this.s2 = value;
                    break;
                case 3:
                    this.s3 = value;
                    break;
                case 4:
                    this.s4 = value;
                    break;
                case 5:
                    this.s5 = value;
                    break;
                case 6:
                    this.s6 = value;
                    break;
                case 7:
                    this.s7 = value;
                    break;
                case 8:
                    this.s8 = value;
                    break;
                case 9:
                    this.s9 = value;
                    break;
                case 10:
                    this.sa = value;
                    break;
                case 11:
                    this.sb = value;
                    break;
                case 12:
                    this.sc = value;
                    break;
                case 13:
                    this.sd = value;
                    break;
                case 14:
                    this.se = value;
                    break;
                case 15:
                    this.sf = value;
                    break;
                default:
                    throw new IndexOutOfRangeException(String.Format("Invalid index: expected 0 <= index < 16, found index = {0}", index));
                }
            }
        }

        // IVectorType

        public int Rank
        {
            get { return 16; }
        }

        public int Size
        {
            get { return 128; }
        }

        // IEquatable

        public bool Equals(double16 obj)
        {
            return this.s0 == obj.s0 && this.s1 == obj.s1 && this.s2 == obj.s2 && this.s3 == obj.s3 && this.s4 == obj.s4 && this.s5 == obj.s5 && this.s6 == obj.s6 && this.s7 == obj.s7 && this.s8 == obj.s8 && this.s9 == obj.s9 && this.sa == obj.sa && this.sb == obj.sb && this.sc == obj.sc && this.sd == obj.sd && this.se == obj.se && this.sf == obj.sf;
        }

        // Object

        public override bool Equals(object obj)
        {
            return obj is double16 && Equals((double16)obj);
        }

        public override int GetHashCode()
        {
            return this.s0.GetHashCode() ^ this.s1.GetHashCode() ^ this.s2.GetHashCode() ^ this.s3.GetHashCode() ^ this.s4.GetHashCode() ^ this.s5.GetHashCode() ^ this.s6.GetHashCode() ^ this.s7.GetHashCode() ^ this.s8.GetHashCode() ^ this.s9.GetHashCode() ^ this.sa.GetHashCode() ^ this.sb.GetHashCode() ^ this.sc.GetHashCode() ^ this.sd.GetHashCode() ^ this.se.GetHashCode() ^ this.sf.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", this.s0, this.s1, this.s2, this.s3, this.s4, this.s5, this.s6, this.s7, this.s8, this.s9, this.sa, this.sb, this.sc, this.sd, this.se, this.sf);
        }

        // Operators

        public static double16 operator +(double16 a, double16 b) => new double16((double)(a.s0+b.s0), (double)(a.s1+b.s1), (double)(a.s2+b.s2), (double)(a.s3+b.s3), (double)(a.s4+b.s4), (double)(a.s5+b.s5), (double)(a.s6+b.s6), (double)(a.s7+b.s7), (double)(a.s8+b.s8), (double)(a.s9+b.s9), (double)(a.sa+b.sa), (double)(a.sb+b.sb), (double)(a.sc+b.sc), (double)(a.sd+b.sd), (double)(a.se+b.se), (double)(a.sf+b.sf));

        public static double16 operator -(double16 a, double16 b) => new double16((double)(a.s0-b.s0), (double)(a.s1-b.s1), (double)(a.s2-b.s2), (double)(a.s3-b.s3), (double)(a.s4-b.s4), (double)(a.s5-b.s5), (double)(a.s6-b.s6), (double)(a.s7-b.s7), (double)(a.s8-b.s8), (double)(a.s9-b.s9), (double)(a.sa-b.sa), (double)(a.sb-b.sb), (double)(a.sc-b.sc), (double)(a.sd-b.sd), (double)(a.se-b.se), (double)(a.sf-b.sf));

        public static double16 operator *(double16 a, double16 b) => new double16((double)(a.s0*b.s0), (double)(a.s1*b.s1), (double)(a.s2*b.s2), (double)(a.s3*b.s3), (double)(a.s4*b.s4), (double)(a.s5*b.s5), (double)(a.s6*b.s6), (double)(a.s7*b.s7), (double)(a.s8*b.s8), (double)(a.s9*b.s9), (double)(a.sa*b.sa), (double)(a.sb*b.sb), (double)(a.sc*b.sc), (double)(a.sd*b.sd), (double)(a.se*b.se), (double)(a.sf*b.sf));

        public static double16 operator /(double16 a, double16 b) => new double16((double)(a.s0/b.s0), (double)(a.s1/b.s1), (double)(a.s2/b.s2), (double)(a.s3/b.s3), (double)(a.s4/b.s4), (double)(a.s5/b.s5), (double)(a.s6/b.s6), (double)(a.s7/b.s7), (double)(a.s8/b.s8), (double)(a.s9/b.s9), (double)(a.sa/b.sa), (double)(a.sb/b.sb), (double)(a.sc/b.sc), (double)(a.sd/b.sd), (double)(a.se/b.se), (double)(a.sf/b.sf));

        public static long16 operator ==(double16 a, double16 b) => new long16(a.s0==b.s0 ? -1L : 0L, a.s1==b.s1 ? -1L : 0L, a.s2==b.s2 ? -1L : 0L, a.s3==b.s3 ? -1L : 0L, a.s4==b.s4 ? -1L : 0L, a.s5==b.s5 ? -1L : 0L, a.s6==b.s6 ? -1L : 0L, a.s7==b.s7 ? -1L : 0L, a.s8==b.s8 ? -1L : 0L, a.s9==b.s9 ? -1L : 0L, a.sa==b.sa ? -1L : 0L, a.sb==b.sb ? -1L : 0L, a.sc==b.sc ? -1L : 0L, a.sd==b.sd ? -1L : 0L, a.se==b.se ? -1L : 0L, a.sf==b.sf ? -1L : 0L);

        public static long16 operator !=(double16 a, double16 b) => new long16(a.s0!=b.s0 ? -1L : 0L, a.s1!=b.s1 ? -1L : 0L, a.s2!=b.s2 ? -1L : 0L, a.s3!=b.s3 ? -1L : 0L, a.s4!=b.s4 ? -1L : 0L, a.s5!=b.s5 ? -1L : 0L, a.s6!=b.s6 ? -1L : 0L, a.s7!=b.s7 ? -1L : 0L, a.s8!=b.s8 ? -1L : 0L, a.s9!=b.s9 ? -1L : 0L, a.sa!=b.sa ? -1L : 0L, a.sb!=b.sb ? -1L : 0L, a.sc!=b.sc ? -1L : 0L, a.sd!=b.sd ? -1L : 0L, a.se!=b.se ? -1L : 0L, a.sf!=b.sf ? -1L : 0L);

        public static long16 operator <(double16 a, double16 b) => new long16(a.s0<b.s0 ? -1L : 0L, a.s1<b.s1 ? -1L : 0L, a.s2<b.s2 ? -1L : 0L, a.s3<b.s3 ? -1L : 0L, a.s4<b.s4 ? -1L : 0L, a.s5<b.s5 ? -1L : 0L, a.s6<b.s6 ? -1L : 0L, a.s7<b.s7 ? -1L : 0L, a.s8<b.s8 ? -1L : 0L, a.s9<b.s9 ? -1L : 0L, a.sa<b.sa ? -1L : 0L, a.sb<b.sb ? -1L : 0L, a.sc<b.sc ? -1L : 0L, a.sd<b.sd ? -1L : 0L, a.se<b.se ? -1L : 0L, a.sf<b.sf ? -1L : 0L);

        public static long16 operator <=(double16 a, double16 b) => new long16(a.s0<=b.s0 ? -1L : 0L, a.s1<=b.s1 ? -1L : 0L, a.s2<=b.s2 ? -1L : 0L, a.s3<=b.s3 ? -1L : 0L, a.s4<=b.s4 ? -1L : 0L, a.s5<=b.s5 ? -1L : 0L, a.s6<=b.s6 ? -1L : 0L, a.s7<=b.s7 ? -1L : 0L, a.s8<=b.s8 ? -1L : 0L, a.s9<=b.s9 ? -1L : 0L, a.sa<=b.sa ? -1L : 0L, a.sb<=b.sb ? -1L : 0L, a.sc<=b.sc ? -1L : 0L, a.sd<=b.sd ? -1L : 0L, a.se<=b.se ? -1L : 0L, a.sf<=b.sf ? -1L : 0L);

        public static long16 operator >(double16 a, double16 b) => new long16(a.s0>b.s0 ? -1L : 0L, a.s1>b.s1 ? -1L : 0L, a.s2>b.s2 ? -1L : 0L, a.s3>b.s3 ? -1L : 0L, a.s4>b.s4 ? -1L : 0L, a.s5>b.s5 ? -1L : 0L, a.s6>b.s6 ? -1L : 0L, a.s7>b.s7 ? -1L : 0L, a.s8>b.s8 ? -1L : 0L, a.s9>b.s9 ? -1L : 0L, a.sa>b.sa ? -1L : 0L, a.sb>b.sb ? -1L : 0L, a.sc>b.sc ? -1L : 0L, a.sd>b.sd ? -1L : 0L, a.se>b.se ? -1L : 0L, a.sf>b.sf ? -1L : 0L);

        public static long16 operator >=(double16 a, double16 b) => new long16(a.s0>=b.s0 ? -1L : 0L, a.s1>=b.s1 ? -1L : 0L, a.s2>=b.s2 ? -1L : 0L, a.s3>=b.s3 ? -1L : 0L, a.s4>=b.s4 ? -1L : 0L, a.s5>=b.s5 ? -1L : 0L, a.s6>=b.s6 ? -1L : 0L, a.s7>=b.s7 ? -1L : 0L, a.s8>=b.s8 ? -1L : 0L, a.s9>=b.s9 ? -1L : 0L, a.sa>=b.sa ? -1L : 0L, a.sb>=b.sb ? -1L : 0L, a.sc>=b.sc ? -1L : 0L, a.sd>=b.sd ? -1L : 0L, a.se>=b.se ? -1L : 0L, a.sf>=b.sf ? -1L : 0L);

        public static double16 operator +(double16 a) => a;

        public static double16 operator -(double16 a) => new double16((double)(-a.s0), (double)(-a.s1), (double)(-a.s2), (double)(-a.s3), (double)(-a.s4), (double)(-a.s5), (double)(-a.s6), (double)(-a.s7), (double)(-a.s8), (double)(-a.s9), (double)(-a.sa), (double)(-a.sb), (double)(-a.sc), (double)(-a.sd), (double)(-a.se), (double)(-a.sf));
    }
}
