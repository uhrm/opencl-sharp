using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Reflection;

namespace OpenCl.Compiler
{
    public enum CliTypeCode
    {
        Int32,
        Int64,
        NativeInt,
        Float32,
        Float64,
        ValueType,
        Pointer,
        Object,
    }

    public abstract class CliType : IEquatable<CliType>
    {

        private class CliPrimitiveType : CliType
        {
            private readonly Type systype;

            public CliPrimitiveType(CliTypeCode code, Type systype) : base(code)
            {
                this.systype = systype;
            }

            public override Type SystemType
            {
                get { return this.systype; }
            }
        }

        private class CliValueType : CliType
        {
            private readonly Type sys;

            public CliValueType(TypeReference sys) : this(sys.ToSystemType()) { }

            public CliValueType(Type sys) : base(CliTypeCode.ValueType)
            {
                this.sys = sys;
            }

            public override Type SystemType
            {
                get { return this.sys; }
            }

            public override bool Equals(CliType obj)
            {
                return base.Equals(obj) && this.sys == (obj as CliValueType).sys;
            }
        }

        private readonly CliTypeCode code;

        protected CliType(CliTypeCode code)
        {
            this.code = code;
        }

        public CliTypeCode Code
        {
            get { return this.code; }
        }

        public abstract Type SystemType
        {
            get;
        }

        public virtual bool Equals(CliType obj)
        {
            return obj != null && this.code == obj.code && this.SystemType == obj.SystemType;
        }

        public override bool Equals(object obj)
        {
            return (obj is CliType) && Equals(obj as CliType);
        }

        public override int GetHashCode()
        {
            return this.code.GetHashCode();
        }

        public static CliType FromOpAdd(CliType l, CliType r) {
            switch (l.Code)
            {
            case CliTypeCode.Pointer:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                case CliTypeCode.Int32:
                    return l;
                }
                break;
            case CliTypeCode.NativeInt:
                switch (r.Code)
                {
                case CliTypeCode.Pointer:
                    return r;
                case CliTypeCode.NativeInt:
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.IntPtr));
                }
                break;
            case CliTypeCode.Int32:
                switch (r.Code)
                {
                case CliTypeCode.Pointer:
                case CliTypeCode.NativeInt:
                    return CliType.FromType(typeof(System.IntPtr));
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.Int32));
                }
                break;
            case CliTypeCode.Int64:
                if (r.Code == CliTypeCode.Int64) {
                    return CliType.FromType(typeof(System.Int64));
                }
                break;
            case CliTypeCode.Float32:
                if (r.Code == CliTypeCode.Float32) {
                    return CliType.FromType(typeof(System.Single));
                }
                break;
            case CliTypeCode.Float64:
                if (r.Code == CliTypeCode.Float64) {
                    return CliType.FromType(typeof(System.Double));
                }
                break;
            }
            throw new ArgumentException(String.Format("Incompatible types for addition: {0} and {1}", l, r));
        }

        public static CliType FromOpSub(CliType l, CliType r) {
            switch (l.Code)
            {
            case CliTypeCode.Pointer:
                switch (r.Code)
                {
                case CliTypeCode.Pointer:
                    return CliType.FromType(typeof(System.IntPtr));
                case CliTypeCode.NativeInt:
                case CliTypeCode.Int32:
                    return l;
                }
                break;
            case CliTypeCode.NativeInt:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.IntPtr));
                }
                break;
            case CliTypeCode.Int32:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                    return CliType.FromType(typeof(System.IntPtr));
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.Int32));
                }
                break;
            case CliTypeCode.Int64:
                if (r.Code == CliTypeCode.Int64) {
                    return CliType.FromType(typeof(System.Int64));
                }
                break;
            case CliTypeCode.Float32:
                if (r.Code == CliTypeCode.Float32) {
                    return CliType.FromType(typeof(System.Single));
                }
                break;
            case CliTypeCode.Float64:
                if (r.Code == CliTypeCode.Float64) {
                    return CliType.FromType(typeof(System.Double));
                }
                break;
            }
            throw new ArgumentException(String.Format("Incompatible types for subtraction: {0} and {1}", l, r));
        }

        public static CliType FromOpMul(CliType l, CliType r) {
            switch (l.Code)
            {
            case CliTypeCode.NativeInt:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.IntPtr));
                }
                break;
            case CliTypeCode.Int32:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                    return CliType.FromType(typeof(System.IntPtr));
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.Int32));
                }
                break;
            case CliTypeCode.Int64:
                if (r.Code == CliTypeCode.Int64) {
                    return CliType.FromType(typeof(System.Int64));
                }
                break;
            case CliTypeCode.Float32:
                if (r.Code == CliTypeCode.Float32) {
                    return CliType.FromType(typeof(System.Single));
                }
                break;
            case CliTypeCode.Float64:
                if (r.Code == CliTypeCode.Float64) {
                    return CliType.FromType(typeof(System.Double));
                }
                break;
            }
            throw new ArgumentException(String.Format("Incompatible types for multiplication: {0} and {1}", l, r));
        }

        public static CliType FromOpDiv(CliType l, CliType r) {
            switch (l.Code)
            {
            case CliTypeCode.NativeInt:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.IntPtr));
                }
                break;
            case CliTypeCode.Int32:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                    return CliType.FromType(typeof(System.IntPtr));
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.Int32));
                }
                break;
            case CliTypeCode.Int64:
                if (r.Code == CliTypeCode.Int64) {
                    return CliType.FromType(typeof(System.Int64));
                }
                break;
            case CliTypeCode.Float32:
                if (r.Code == CliTypeCode.Float32) {
                    return CliType.FromType(typeof(System.Single));
                }
                break;
            case CliTypeCode.Float64:
                if (r.Code == CliTypeCode.Float64) {
                    return CliType.FromType(typeof(System.Double));
                }
                break;
            }
            throw new ArgumentException(String.Format("Incompatible types for division: {0} and {1}", l, r));
        }

        public static CliType FromOpBitwise(CliType l, CliType r) {
            switch (l.Code)
            {
            case CliTypeCode.NativeInt:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.IntPtr));
                }
                break;
            case CliTypeCode.Int32:
                switch (r.Code)
                {
                case CliTypeCode.NativeInt:
                    return CliType.FromType(typeof(System.IntPtr));
                case CliTypeCode.Int32:
                    return CliType.FromType(typeof(System.Int32));
                }
                break;
            case CliTypeCode.Int64:
                if (r.Code == CliTypeCode.Int64) {
                    return CliType.FromType(typeof(System.Int64));
                }
                break;
            }
            throw new ArgumentException(String.Format("Incompatible types for bit-wise operation: {0} and {1}", l, r));
        }

        private static readonly Dictionary<Type,CliType> typeMap = new Dictionary<Type,CliType>() {
            { typeof(System.SByte),   new CliPrimitiveType(CliTypeCode.Int32,     typeof(System.SByte)) },
            { typeof(System.Byte),    new CliPrimitiveType(CliTypeCode.Int32,     typeof(System.Byte)) },
            { typeof(System.Int16),   new CliPrimitiveType(CliTypeCode.Int32,     typeof(System.Int16)) },
            { typeof(System.UInt16),  new CliPrimitiveType(CliTypeCode.Int32,     typeof(System.UInt16)) },
            { typeof(System.Int32),   new CliPrimitiveType(CliTypeCode.Int32,     typeof(System.Int32)) },
            { typeof(System.UInt32),  new CliPrimitiveType(CliTypeCode.Int32,     typeof(System.UInt32)) },
            { typeof(System.Int64),   new CliPrimitiveType(CliTypeCode.Int64,     typeof(System.Int64)) },
            { typeof(System.UInt64),  new CliPrimitiveType(CliTypeCode.Int64,     typeof(System.UInt64)) },
            { typeof(System.IntPtr),  new CliPrimitiveType(CliTypeCode.NativeInt, typeof(System.IntPtr)) },
            { typeof(System.UIntPtr), new CliPrimitiveType(CliTypeCode.NativeInt, typeof(System.UIntPtr)) },
            { typeof(System.Single),  new CliPrimitiveType(CliTypeCode.Float32,   typeof(System.Single)) },
            { typeof(System.Double),  new CliPrimitiveType(CliTypeCode.Float64,   typeof(System.Double)) },
        };

        public static CliType FromType(Type type)
        {
            CliType result;
            if (!typeMap.TryGetValue(type, out result)) {
                if (type.IsValueType) {
                    result = new CliValueType(type);
                }
                else if (type.IsArray || type.IsPointer) {
                    result = new CliPointerType(type);
                }
                else {
                    throw new ArgumentException(String.Format("Unsupported type '{0}'.", type));
                }
            }
            return result;
        }

        public static CliType FromType(TypeReference type)
        {
            return FromType(type.ToSystemType());
        }

//        private static readonly Dictionary<CliTypeCode,Type> sysMap = new Dictionary<CliTypeCode,Type>() {
//            { CliTypeCode.Int32,     typeof(System.Int32) },
//            { CliTypeCode.Int64,     typeof(System.Int64) },
//            { CliTypeCode.NativeInt, typeof(System.IntPtr) },
//            { CliTypeCode.Float32,   typeof(System.Single) },
//            { CliTypeCode.Float64,   typeof(System.Double) },
//        };
//
//        public static Type ToSystemType(CliType t)
//        {
//            return sysMap[t.Code];
//        }
    }

    public class CliPointerType : CliType
    {
        private readonly Type sys;

        public CliPointerType(TypeReference sys) : this(sys.ToSystemType()) { }

        public CliPointerType(Type sys) : base(CliTypeCode.Pointer)
        {
            if (!(sys.IsArray || sys.IsPointer)) {
                throw new ArgumentException(String.Format("Invalid system type: expected array or pointer, found {0}.", sys));
            }
            this.sys = sys;
        }

        public override Type SystemType
        {
            get { return this.sys; }
        }

        public Type Element
        {
            get { return this.sys.GetElementType(); }
        }
    }

    public static class TypeReferenceExtensions
    {
        public static Type ToSystemType(this TypeReference type)
        {
            var def = type.Resolve();
            var name = Assembly.CreateQualifiedName(def.Module.Assembly.FullName, type.FullName);
            var res = Type.GetType(name);
            if (res == null) {
                throw new ArgumentException(String.Format("No system type found for '{0}'.", name));
            }
            return res;
        }
    }
}

