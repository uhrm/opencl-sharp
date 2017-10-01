
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenCl.Compiler
{
    public partial class SpirCompiler
    {
        //
        // SPIR-V opcodes
        //

        private abstract class SpirOpCode
        {
            public abstract void Emit(Stream stream);
        }

        private abstract class ResultOpCode : SpirOpCode
        {
            public abstract int ResultId { get; }
        }

        private abstract class TypedResultOpCode : ResultOpCode
        {
            public abstract TypeOpCode ResultType { get; }
        }

        private abstract class DefaultResultOpCode : ResultOpCode
        {
            private readonly int rid;

            public DefaultResultOpCode(int rid) {
                this.rid = rid;
            }

            public override int ResultId
            {
                get { return this.rid; }
            }
        }

        private abstract class DefaultTypedResultOpCode : TypedResultOpCode
        {
            private readonly int rid;

            public DefaultTypedResultOpCode(int rid) {
                this.rid = rid;
            }

            public override int ResultId
            {
                get { return this.rid; }
            }
        }

        private abstract class GenericOpCode : DefaultTypedResultOpCode
        {
            protected readonly short code;

            public GenericOpCode(int rid, short code) : base(rid)
            {
                this.code = code;
            }
        }

        private class OpNop : SpirOpCode
        {
            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(0);
                stream.WriteShortLE(1);
            }
        }

        private abstract class OpDecorate : SpirOpCode
        {
            public readonly ResultOpCode target;
            public readonly Decoration decoration;

            protected OpDecorate(ResultOpCode target, Decoration decoration) {
                this.target = target;
                this.decoration = decoration;
            }

            protected abstract int ArgSize { get; }

            protected abstract void EmitArgs(Stream stream);

            public override void Emit(Stream stream) {
                stream.WriteShortLE(71);
                stream.WriteShortLE((short)(3+ArgSize));
                stream.WriteIntLE(this.target.ResultId);
                stream.WriteIntLE((int)this.decoration);
                EmitArgs(stream);
            }
        }

        private class OpDecorateBuiltIn : OpDecorate
        {
            public readonly BuiltIn builtin;

            public OpDecorateBuiltIn(ResultOpCode target, BuiltIn builtin) : base(target, Decoration.BuiltIn)
            {
                this.builtin = builtin;
            }

            protected override int ArgSize
            {
                get { return 1; }
            }

            protected override void EmitArgs(Stream stream)
            {
                stream.WriteIntLE((int)this.builtin);
            }
        }

        private class OpDecorateConstant : OpDecorate
        {
            public OpDecorateConstant(ResultOpCode target) : base(target, Decoration.Constant) { }

            protected override int ArgSize
            {
                get { return 0; }
            }

            protected override void EmitArgs(Stream stream)
            {
            }
        }

        private class OpDecorateLinkageAttributes : OpDecorate
        {
            // name mangling for LLVM-based implementations
            // see: https://github.com/KhronosGroup/SPIRV-LLVM/blob/khronos/spirv-3.6.1/docs/SPIRVRepresentationInLLVM.rst#id16
            private static Dictionary<BuiltIn,string> symbols = new Dictionary<BuiltIn,string>() {
                { BuiltIn.WorkDim, "__spirv_BuiltInWorkDim" },
                { BuiltIn.GlobalSize, "__spirv_BuiltInGlobalSize" },
                { BuiltIn.GlobalInvocationId, "__spirv_BuiltInGlobalInvocationId" },
                { BuiltIn.WorkgroupSize, "__spirv_BuiltInWorkgroupSize" },
                { BuiltIn.EnqueuedWorkgroupSize, "__spirv_BuiltInEnqueuedWorkgroupSize" },
                { BuiltIn.LocalInvocationId, "__spirv_BuiltInLocalInvocationId" },
                { BuiltIn.NumWorkgroups, "__spirv_BuiltInNumWorkgroups" },
                { BuiltIn.WorkgroupId, "__spirv_BuiltInWorkgroupId" },
                { BuiltIn.GlobalOffset, "__spirv_BuiltInGlobalOffset" },
                { BuiltIn.GlobalLinearId, "__spirv_BuiltInGlobalLinearId" },
                { BuiltIn.LocalInvocationIndex, "__spirv_BuiltInLocalInvocationIndex" },
                { BuiltIn.SubgroupSize, "__spirv_BuiltInSubgroupSize" },
                { BuiltIn.SubgroupMaxSize, "__spirv_BuiltInSubgroupMaxSize" },
                { BuiltIn.NumSubgroups, "__spirv_BuiltInNumSubgroups" },
                { BuiltIn.NumEnqueuedSubgroups, "__spirv_BuiltInNumEnqueuedSubgroups" },
                { BuiltIn.SubgroupId, "__spirv_BuiltInSubgroupId" },
                { BuiltIn.SubgroupLocalInvocationId, "__spirv_BuiltInSubgroupLocalInvocationId" }
            };

            public readonly LinkageType linkage;
            public readonly BuiltIn symbol;

            public OpDecorateLinkageAttributes(ResultOpCode target, LinkageType linkage, BuiltIn symbol) : base(target, Decoration.LinkageAttributes)
            {
                this.linkage = linkage;
                this.symbol = symbol;
             }

            protected override int ArgSize
            {
                get { return StreamExtensions.GetPaddedLength(symbols[this.symbol])/4 + 1; }
            }

            protected override void EmitArgs(Stream stream)
            {
                stream.WriteString(symbols[this.symbol]);
                stream.WriteIntLE((int)this.linkage);
            }
        }

        private class OpExtInstImport : DefaultResultOpCode
        {
            public readonly string name;

            public OpExtInstImport(int rid, string name) : base(rid) {
                this.name = name;
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(11);
                stream.WriteShortLE((short)(2+StreamExtensions.GetPaddedLength(this.name)/4));
                stream.WriteIntLE(this.ResultId);
                stream.WriteString(this.name);
            }
        }

        private class OpMemoryModel : SpirOpCode
        {
            public readonly AddressingModel addressing;
            public readonly MemoryModel memory;

            public OpMemoryModel(AddressingModel addressing, MemoryModel memory) {
                this.addressing = addressing;
                this.memory = memory;
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(14);
                stream.WriteShortLE(3);
                stream.WriteIntLE((int)this.addressing);
                stream.WriteIntLE((int)this.memory);
            }
        }

        private class OpEntryPoint : SpirOpCode
        {
            public readonly ExecutionModel execution;
            public readonly OpFunction entryPoint;
            public readonly string name;

            public OpEntryPoint(ExecutionModel execution, OpFunction entryPoint, string name) {
                this.execution = execution;
                this.entryPoint = entryPoint;
                this.name = name;
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(15);
                stream.WriteShortLE((short)(3+StreamExtensions.GetPaddedLength(this.name)/4));
                stream.WriteIntLE((int)this.execution);
                stream.WriteIntLE(this.entryPoint.ResultId);
                stream.WriteString(this.name);
            }
        }

        private class OpCapability : SpirOpCode
        {
            public readonly Capability type;

            public OpCapability(Capability type) {
                this.type = type;
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(17);
                stream.WriteShortLE(2);
                stream.WriteIntLE((int)this.type);
            }
        }

        // type instructions

        private abstract class TypeOpCode : TypedResultOpCode 
        {
            protected readonly Func<TypeOpCode,int> rfunc;

            protected TypeOpCode(Func<TypeOpCode,int> rfunc)
            {
                this.rfunc = rfunc;
            }

            public override int ResultId
            {
                get { return this.rfunc(this); }
            }

            public override TypeOpCode ResultType
            {
                get { return this; }
            }

            public abstract override bool Equals(object obj);
            
            public abstract override int GetHashCode();
        }

        private class OpTypeVoid : TypeOpCode
        {
            public OpTypeVoid(Func<TypeOpCode,int> rfunc) : base(rfunc) { rfunc(this); }

            public new OpTypeVoid ResultType
            {
                get { return this; }
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(19);
                stream.WriteShortLE(2);
                stream.WriteIntLE(this.ResultId);
            }

            public override bool Equals(object obj)
            {
                return obj != null && GetType() == obj.GetType();
            }
            
            public override int GetHashCode()
            {
                return 0x5c36e;
            }
        }

        private abstract class ScalarTypeOpCode : TypeOpCode
        {
            protected ScalarTypeOpCode(Func<TypeOpCode,int> rfunc) : base(rfunc) { }
        }

        private class OpTypeBool : ScalarTypeOpCode
        {
            public OpTypeBool(Func<TypeOpCode,int> rfunc) : base(rfunc) { rfunc(this); }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(20);
                stream.WriteShortLE(2);
                stream.WriteIntLE(this.ResultId);
            }

            public override bool Equals(object obj)
            {
                return obj as OpTypeBool != null;
            }
            
            public override int GetHashCode()
            {
                return 0x6584c26a;
            }
        }

        private abstract class NumericTypeOpCode : ScalarTypeOpCode
        {
            protected NumericTypeOpCode(Func<TypeOpCode,int> rfunc) : base(rfunc) { }

            public abstract int Width { get; }
        }

        private class OpTypeInt : NumericTypeOpCode
        {
            private readonly int width;
            private readonly int signedness;

            public OpTypeInt(Func<TypeOpCode,int> rfunc, int width) : this(rfunc, width, 0) { }

            public OpTypeInt(Func<TypeOpCode,int> rfunc, int width, int signedness) : base(rfunc)
            {
                this.width = width;
                this.signedness = signedness;
                rfunc(this);
            }

            public override int Width
            {
                get { return this.width; }
            }

            public int Signedness
            {
                get { return this.signedness; }
            }

            public new OpTypeInt ResultType
            {
                get { return this; }
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(21);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE(this.Width);
                stream.WriteIntLE(this.Signedness);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeInt;
                return t != null && this.width == t.width && this.signedness == t.signedness;
            }
            
            public override int GetHashCode()
            {
                return 0x70dd8170 ^ 0x39863788*this.width ^ 0x61f93cd8*this.signedness;
            }
        }

        private class OpTypeFloat : NumericTypeOpCode
        {
            private readonly int width;

            public OpTypeFloat(Func<TypeOpCode,int> rfunc, int width) : base(rfunc)
            {
                this.width = width;
                rfunc(this);
            }

            public override int Width
            {
                get { return this.width; }
            }

            public new OpTypeFloat ResultType
            {
                get { return this; }
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(22);
                stream.WriteShortLE(3);
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE(this.Width);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeFloat;
                return t != null && this.width == t.width;
            }
            
            public override int GetHashCode()
            {
                return 0x7457a880 ^ 0x6fc82f48*this.width;
            }
        }

        private abstract class CompositeTypeOpCode : TypeOpCode
        {
            protected CompositeTypeOpCode(Func<TypeOpCode,int> rfunc) : base(rfunc) { }

            public abstract TypeOpCode GetResultType(int index);
        }

        private class OpTypeVector : CompositeTypeOpCode
        {
            private readonly ScalarTypeOpCode componentType;
            private readonly int componentCount;

            public OpTypeVector(Func<TypeOpCode,int> rfunc, int componentCount, ScalarTypeOpCode componentType) : this(rfunc, componentType, componentCount) { }

            private OpTypeVector(Func<TypeOpCode,int> rfunc, ScalarTypeOpCode componentType, int componentCount) : base(rfunc)
            {
                this.componentType = componentType;
                this.componentCount = componentCount;
                rfunc(this);
            }

            public ScalarTypeOpCode ComponentType
            {
                get { return this.componentType; }
            }

            public int ComponentCount
            {
                get { return this.componentCount; }
            }

            public new OpTypeVector ResultType
            {
                get { return this; }
            }

            public override TypeOpCode GetResultType(int index)
            {
                if (index < 0 || index >= this.componentCount) {
                    throw new ArgumentException(String.Format("Invalid component index: epected 0 <= i < {0}, found {1}.", this.componentCount, index));
                }
                return this.componentType;
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(23);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE(this.componentType.ResultId);
                stream.WriteIntLE(this.componentCount);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeVector;
                return t != null && this.componentType.Equals(t.componentType) && this.componentCount == t.componentCount;
            }
            
            public override int GetHashCode()
            {
                return 0x2b8edf05 ^ 0x2224e190*this.componentType.GetHashCode() ^ 0x5177a29b*this.componentCount;
            }
        }

        private class OpTypeMatrix : CompositeTypeOpCode
        {
            private readonly OpTypeVector columnType;
            private readonly int columnCount;

            public OpTypeMatrix(Func<TypeOpCode,int> rfunc, OpTypeVector columnType, int columnCount) : base(rfunc)
            {
                this.columnType = columnType;
                this.columnCount = columnCount;
                rfunc(this);
            }

            public OpTypeVector ColumnType
            {
                get { return this.columnType; }
            }

            public int ColumnCount
            {
                get { return this.columnCount; }
            }

            public new OpTypeMatrix ResultType
            {
                get { return this; }
            }

            public override TypeOpCode GetResultType(int index)
            {
                if (index < 0 || index >= this.columnCount) {
                    throw new ArgumentException(String.Format("Invalid component index: epected 0 <= i < {0}, found {1}.", this.columnCount, index));
                }
                return this.columnType;
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(24);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE(this.columnType.ResultId);
                stream.WriteIntLE(this.columnCount);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeMatrix;
                return t != null && this.columnType.Equals(t.columnType) && this.columnCount == t.columnCount;
            }
            
            public override int GetHashCode()
            {
                return 0x52cc5dfb ^ 0x73622e8c*this.columnType.GetHashCode() ^ 0x64d25d50*this.columnCount;
            }
        }

        private abstract class AggregateTypeOpCode : CompositeTypeOpCode
        {
            protected AggregateTypeOpCode(Func<TypeOpCode,int> rfunc) : base(rfunc) { }
        }

        private class OpTypeArray : AggregateTypeOpCode
        {
            private readonly TypeOpCode elementType;
            private readonly int length;

            public OpTypeArray(Func<TypeOpCode,int> rfunc, TypeOpCode elementType, int length) : base(rfunc)
            {
                this.elementType = elementType;
                this.length = length;
                rfunc(this);
            }

            public TypeOpCode ElementType
            {
                get { return this.elementType; }
            }

            public int Length
            {
                get { return this.length; }
            }

            public new OpTypeArray ResultType
            {
                get { return this; }
            }

            public override TypeOpCode GetResultType(int index)
            {
                if (index < 0 || index >= this.length) {
                    throw new ArgumentException(String.Format("Invalid array index: epected 0 <= i < {0}, found {1}.", this.length, index));
                }
                return this.elementType;
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(28);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE(this.elementType.ResultId);
                stream.WriteIntLE(this.length);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeArray;
                return t != null && this.elementType.Equals(t.elementType) && this.length == t.length;
            }
            
            public override int GetHashCode()
            {
                return 0x23871a4e ^ 0x0e0ac0d6*this.elementType.GetHashCode() ^ 0x62f0dfe7*this.length;
            }
        }

        private class OpTypeRuntimeArray : TypeOpCode
        {
            private readonly TypeOpCode elementType;

            public OpTypeRuntimeArray(Func<TypeOpCode,int> rfunc, TypeOpCode elementType) : base(rfunc)
            {
                this.elementType = elementType;
                rfunc(this);
            }

            public TypeOpCode ElementType
            {
                get { return this.elementType; }
            }

            public new OpTypeRuntimeArray ResultType
            {
                get { return this; }
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(29);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE(this.elementType.ResultId);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeRuntimeArray;
                return t != null && this.elementType.Equals(t.elementType);
            }
            
            public override int GetHashCode()
            {
                return 0x2f3e8210 ^ 0x24f4559f*this.elementType.GetHashCode();
            }
        }

        private class OpTypeStruct : AggregateTypeOpCode
        {
            private readonly TypeOpCode[] members;

            public OpTypeStruct(Func<TypeOpCode,int> rfunc, params TypeOpCode[] members) : base(rfunc)
            {
                this.members = members;
                rfunc(this);
            }

            public IReadOnlyList<TypeOpCode> Member
            {
                get { return this.members; }
            }

            public new OpTypeStruct ResultType
            {
                get { return this; }
            }

            public override TypeOpCode GetResultType(int index)
            {
                if (index < 0 || index >= this.members.Length) {
                    throw new ArgumentException(String.Format("Invalid array index: epected 0 <= i < {0}, found {1}.", this.members.Length, index));
                }
                return this.members[index];
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(30);
                stream.WriteShortLE((short)(2+this.members.Length));
                stream.WriteIntLE(this.ResultId);
                foreach (var m in this.members) {
                    stream.WriteIntLE(m.ResultId);
                }
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeStruct;
                if (t == null || this.members.Length != t.members.Length) {
                    return false;
                }
                for (var i=0; i<this.members.Length; i++) {
                    if (!this.members[i].Equals(t.members[i])) {
                        return false;
                    }
                }
                return true;
            }
            
            public override int GetHashCode()
            {
                var result = 0x38226897 ^ 0x359ae909*this.members.Length;
                for (var i=0; i<this.members.Length; i++) {
                    switch (i) {
                    case 0:
                        result ^= 0x331de368*this.members[i].GetHashCode();
                        break;
                    case 1:
                        result ^= 0x36354355*this.members[i].GetHashCode();
                        break;
                    case 2:
                        result ^= 0x430cf1aa*this.members[i].GetHashCode();
                        break;
                    case 3:
                        result ^= 0x6e87be7e*this.members[i].GetHashCode();
                        break;
                    case 4:
                        result ^= 0x731ecda9*this.members[i].GetHashCode();
                        break;
                    case 5:
                        result ^= 0x080cab25*this.members[i].GetHashCode();
                        break;
                    case 6:
                        result ^= 0x30522232*this.members[i].GetHashCode();
                        break;
                    case 7:
                        result ^= 0x4719bbca*this.members[i].GetHashCode();
                        break;
                    default:
                        result ^= 0x244c9dd6*this.members[i].GetHashCode();
                        break;
                    }
                }
                return result;
            }
        }

        private class OpTypeOpaque : TypeOpCode
        {
            private readonly string name;

            public OpTypeOpaque(Func<TypeOpCode,int> rfunc, string name) : base(rfunc)
            {
                this.name = name;
                rfunc(this);
            }

            public string Name
            {
                get { return this.name; }
            }

            public new OpTypeOpaque ResultType
            {
                get { return this; }
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(31);
                stream.WriteShortLE((short)(2+StreamExtensions.GetPaddedLength(this.name)));
                stream.WriteIntLE(this.ResultId);
                stream.WriteString(this.name);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeOpaque;
                return t != null && this.name.Equals(t.name);
            }
            
            public override int GetHashCode()
            {
                return 0x37549a9e ^ 0x673c2b10*this.name.GetHashCode();
            }
        }

        private class OpTypePointer : TypeOpCode
        {
            private readonly TypeOpCode baseType;
            private readonly StorageClass storage;

            public OpTypePointer(Func<TypeOpCode,int> rfunc, StorageClass storage, TypeOpCode baseType) : this(rfunc, baseType, storage) { }

            private OpTypePointer(Func<TypeOpCode,int> rfunc, TypeOpCode baseType, StorageClass storage) : base(rfunc)
            {
                this.baseType = baseType;
                this.storage = storage;
                rfunc(this);
            }

            public TypeOpCode BaseType
            {
                get { return this.baseType; }
            }

            public StorageClass Storage
            {
                get { return this.storage; }
            }

            public new OpTypePointer ResultType
            {
                get { return this; }
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(32);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE((int)this.storage);
                stream.WriteIntLE(this.baseType.ResultId);
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypePointer;
                return t != null && this.baseType.Equals(t.baseType) && this.storage == t.storage;
            }
            
            public override int GetHashCode()
            {
                return 0x1cdc9de7 ^ 0x66ee5213*this.baseType.GetHashCode() ^ 0x771ca164*(int)this.storage;
            }

            public OpTypePointer Derive(TypeOpCode type)
            {
                return new OpTypePointer(this.rfunc, this.storage, type);
            }
        }

        private class OpTypeFunction : TypeOpCode
        {
            private readonly TypeOpCode result;
            private readonly TypeOpCode[] parameters;

            public OpTypeFunction(Func<TypeOpCode,int> rfunc, TypeOpCode result, params TypeOpCode[] parameters) : base(rfunc)
            {
                this.result = result;
                this.parameters = parameters;
                rfunc(this);
            }

            public TypeOpCode ReturnType
            {
                get { return this.result; }
            }

            public IReadOnlyList<TypeOpCode> Parameter
            {
                get { return this.parameters; }
            }

            public new OpTypeFunction ResultType
            {
                get { return this; }
            }

            public override void Emit(Stream stream) {
                stream.WriteShortLE(33);
                stream.WriteShortLE((short)(3+this.parameters.Length));
                stream.WriteIntLE(this.ResultId);
                stream.WriteIntLE(this.result.ResultId);
                foreach (var p in this.parameters) {
                    stream.WriteIntLE(p.ResultId);
                }
            }

            public override bool Equals(object obj)
            {
                var t = obj as OpTypeFunction;
                if (t == null || !this.result.Equals(t.result) || this.parameters.Length != t.parameters.Length) {
                    return false;
                }
                for (var i=0; i<this.parameters.Length; i++) {
                    if (!this.parameters[i].Equals(t.parameters[i])) {
                        return false;
                    }
                }
                return true;
            }
            
            public override int GetHashCode()
            {
                var result = 0x437d165a ^ 0x348145d1*this.result.GetHashCode() ^ 0x04609426*this.parameters.Length;
                for (var i=0; i<this.parameters.Length; i++) {
                    switch (i) {
                    case 0:
                        result ^= 0x5bb1f74d*this.parameters[i].GetHashCode();
                        break;
                    case 1:
                        result ^= 0x3fcdf667*this.parameters[i].GetHashCode();
                        break;
                    case 2:
                        result ^= 0x12521d55*this.parameters[i].GetHashCode();
                        break;
                    case 3:
                        result ^= 0x7d11d31f*this.parameters[i].GetHashCode();
                        break;
                    case 4:
                        result ^= 0x2d097381*this.parameters[i].GetHashCode();
                        break;
                    case 5:
                        result ^= 0x30917df9*this.parameters[i].GetHashCode();
                        break;
                    case 6:
                        result ^= 0x64ca61c4*this.parameters[i].GetHashCode();
                        break;
                    case 7:
                        result ^= 0x6dfc5ff0*this.parameters[i].GetHashCode();
                        break;
                    default:
                        result ^= 0x3ca8ebfc*this.parameters[i].GetHashCode();
                        break;
                    }
                }
                return result;
            }
        }

        private class OpConstantTrue : DefaultTypedResultOpCode
        {
            private OpTypeBool type;

            public OpConstantTrue(int rid, OpTypeBool type) : base(rid)
            {
                this.type = type;
            }

            public override TypeOpCode ResultType
            {
                get { return this.type; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(41);
                stream.WriteShortLE(3);
                stream.WriteIntLE(this.type.ResultId);
                stream.WriteIntLE(ResultId);
            }
        }

        private class OpConstantFalse : DefaultTypedResultOpCode
        {
            private OpTypeBool type;

            public OpConstantFalse(int rid, OpTypeBool type) : base(rid)
            {
                this.type = type;
            }

            public override TypeOpCode ResultType
            {
                get { return this.type; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(42);
                stream.WriteShortLE(3);
                stream.WriteIntLE(this.type.ResultId);
                stream.WriteIntLE(ResultId);
            }
        }

        private class OpConstant : TypedResultOpCode
        {
            private readonly int rid;
            private readonly NumericTypeOpCode type;
            private readonly object value;

            public OpConstant(Func<OpConstant,int> rfunc, NumericTypeOpCode type, object value)
            {
                this.type = type;
                this.value = value;
                this.rid = rfunc(this);
            }

            public override int ResultId
            {
                get { return this.rid; }
            }

            public override TypeOpCode ResultType
            {
                get { return this.type; }
            }

            public object Value
            {
                get { return this.value; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(43);
                stream.WriteShortLE((short)(3+Math.Max((this.type.Width+31 & ~31)/32, 1)));
                stream.WriteIntLE(this.type.ResultId);
                stream.WriteIntLE(ResultId);
                if (this.type is OpTypeInt) {
                    switch (this.type.Width) {
                    case 8:
                        stream.WriteByteLE((sbyte)this.value);
                        break;
                    case 16:
                        stream.WriteShortLE((short)this.value);
                        break;
                    case 32:
                        stream.WriteIntLE((int)this.value);
                        break;
                    case 64:
                        stream.WriteLongLE((long)this.value);
                        break;
                    default:
                        throw new CompilerException(String.Format("Unsupported integer width: {0} (expected width 8, 16, 32, or 64)", this.type.Width));
                    }
                }
                else {
                    switch (this.type.Width) {
                    case 32:
                        stream.WriteFloatLE((float)this.value);
                        break;
                    case 64:
                        stream.WriteDoubleLE((double)this.value);
                        break;
                    default:
                        throw new CompilerException(String.Format("Unsupported floating point width: {0} (expected width 32 or 64)", this.type.Width));
                    }
                }
            }

            public override bool Equals(object obj)
            {
                var c = obj as OpConstant;
                return c != null && this.type.Equals(c.type) && this.value.Equals(c.value);
            }
            
            public override int GetHashCode()
            {
                return 0x074147fc ^ 0x54cb7d94*this.type.GetHashCode() ^ 0x46339fcb*this.value.GetHashCode();
            }
        }

        // function instructions

        private class OpFunction : DefaultTypedResultOpCode
        {
            private readonly OpTypeFunction functionType;
            private readonly FunctionControl functionControl;

            public OpFunction(int rid, OpTypeFunction functionType) : this(rid, functionType, FunctionControl.None) { }

            public OpFunction(int rid, OpTypeFunction functionType, FunctionControl functionControl) : base(rid)
            {
                this.functionType = functionType;
                this.functionControl = functionControl;
            }

            public override TypeOpCode ResultType
            {
                get { return this.functionType; }
            }

            public TypeOpCode ReturnType
            {
                get { return this.functionType.ReturnType; }
            }

            public IReadOnlyList<TypeOpCode> ParameterType
            {
                get { return this.functionType.Parameter; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(54);
                stream.WriteShortLE(5);
                stream.WriteIntLE(this.functionType.ReturnType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE((int)this.functionControl);
                stream.WriteIntLE(this.functionType.ResultId);
            }
        }

        private class OpFunctionParameter : DefaultTypedResultOpCode
        {
            private readonly TypeOpCode resultType;

            public OpFunctionParameter(int rid, TypeOpCode resultType) : base(rid)
            {
                this.resultType = resultType;
            }

            public override TypeOpCode ResultType
            {
                get { return this.resultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(55);
                stream.WriteShortLE(3);
                stream.WriteIntLE(this.resultType.ResultId);
                stream.WriteIntLE(ResultId);
            }
        }

        private class OpFunctionEnd : SpirOpCode
        {
            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(56);
                stream.WriteShortLE(1);
            }
        }

        private class OpFunctionCall : DefaultTypedResultOpCode
        {
            private readonly OpFunction function;
            private readonly ResultOpCode[] args;

            public OpFunctionCall(int rid, OpFunction function, params ResultOpCode[] args) : base(rid)
            {
                this.function = function;
                this.args = args;
            }

            public override TypeOpCode ResultType
            {
                get { return this.function.ReturnType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(57);
                stream.WriteShortLE((short)(4+this.function.ParameterType.Count));
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.function.ResultId);
                foreach (var pi in this.function.ParameterType) {
                    stream.WriteIntLE(pi.ResultId);
                }
            }
        }

        // ...

        private class OpVariable : DefaultTypedResultOpCode
        {
            private readonly OpTypePointer resultType;
            // private readonly StorageClass storage;
            private readonly ResultOpCode initializer;

            public OpVariable(int rid, OpTypePointer resultType/*, StorageClass storage*/) : this(rid, resultType/*, storage*/, null) { }

            public OpVariable(int rid, OpTypePointer resultType/*, StorageClass storage*/, TypedResultOpCode initializer) : base(rid)
            {
                if (initializer != null && !initializer.ResultType.Equals(resultType.BaseType)) {
                    throw new ArgumentException(String.Format("Incmopatible initializer type: expected {0}, found {1}.", initializer.ResultType.GetType().Name, resultType.BaseType.GetType().Name));
                }
                this.resultType = resultType;
                // this.storage = storage;
                this.initializer = initializer;
            }

            public override TypeOpCode ResultType
            {
                get { return this.resultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(59);
                stream.WriteShortLE((short)(this.initializer != null ? 5 : 4));
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE((int)this.resultType.Storage);
                if (this.initializer != null) {
                    stream.WriteIntLE(this.initializer.ResultId);
                }
            }
        }

        private class OpLoad : DefaultTypedResultOpCode
        {
            private readonly TypedResultOpCode pointer;
            private readonly MemoryAccess memoryAccess;
            private readonly int alignment;

            public OpLoad(int rid, TypedResultOpCode pointer) : this(rid, pointer, MemoryAccess.None, 0) { }

            public OpLoad(int rid, TypedResultOpCode pointer, MemoryAccess memoryAccess, int alignment) : base(rid)
            {
                if (!(pointer.ResultType is OpTypePointer)) {
                    throw new ArgumentException(String.Format("Invalid type of pointer argument: expecte SpirPointerType, found {0}.", pointer.ResultType.GetType().Name));
                }
                this.pointer = pointer;
                this.memoryAccess = memoryAccess;
                this.alignment = alignment;
            }

            public override TypeOpCode ResultType
            {
                get { return (this.pointer.ResultType as OpTypePointer).BaseType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(61);
                var len = 4;
                if (this.memoryAccess != MemoryAccess.None) {
                    len++;
                }
                if ((this.memoryAccess & MemoryAccess.Aligned) != 0) {
                    len++;
                }
                stream.WriteShortLE((short)len);
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.pointer.ResultId);
                if (this.memoryAccess != MemoryAccess.None) {
                    stream.WriteIntLE((int)this.memoryAccess);
                }
                if ((this.memoryAccess & MemoryAccess.Aligned) != 0) {
                    stream.WriteIntLE(this.alignment);
                }
            }
        }

        private class OpStore : SpirOpCode
        {
            private readonly ResultOpCode pointerType;
            private readonly ResultOpCode objectType;
            private readonly MemoryAccess memoryAccess;
            private readonly int alignment;

            public OpStore(ResultOpCode pointerType, ResultOpCode objectType) : this(pointerType, objectType, MemoryAccess.None, 0) { }

            public OpStore(ResultOpCode pointerType, ResultOpCode objectType, MemoryAccess memoryAccess, int alignment)
            {
                this.pointerType = pointerType;
                this.objectType = objectType;
                this.memoryAccess = memoryAccess;
                this.alignment = alignment;
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(62);
                var len = 3;
                if (this.memoryAccess != MemoryAccess.None) {
                    len++;
                }
                if ((this.memoryAccess & MemoryAccess.Aligned) != 0) {
                    len++;
                }
                stream.WriteShortLE((short)len);
                stream.WriteIntLE(this.pointerType.ResultId);
                stream.WriteIntLE(this.objectType.ResultId);
                if (this.memoryAccess != MemoryAccess.None) {
                    stream.WriteIntLE((int)this.memoryAccess);
                }
                if ((this.memoryAccess & MemoryAccess.Aligned) != 0) {
                    stream.WriteIntLE(this.alignment);
                }
            }
        }

        private class OpAccessChain : DefaultTypedResultOpCode
        {
            private readonly TypedResultOpCode basePointer;
            private readonly ResultOpCode[] index;

            public OpAccessChain(int rid, TypedResultOpCode basePointer, params ResultOpCode[] index) : base(rid)
            {
                if (!(basePointer.ResultType is OpTypePointer)) {
                    throw new ArgumentException($"Invalid type of pointer argument: expected SpirPointerType, found {basePointer.ResultType.GetType().Name}.");
                }
                this.basePointer = basePointer;
                this.index = index;
            }

            public override TypeOpCode ResultType
            {
                get {
                    OpTypePointer basePtr = this.basePointer.ResultType as OpTypePointer;
                    TypeOpCode result = basePtr.BaseType;
                    foreach (var i in this.index) {
                        if (result is OpTypeVector) {
                            result = (result as OpTypeVector).ComponentType;
                        }
                        else if (result is OpTypeMatrix) {
                            result = (result as OpTypeMatrix).ColumnType;
                        }
                        else if (result is OpTypeArray) {
                            result = (result as OpTypeArray).ElementType;
                        }
                        else if (result is OpTypeStruct) {
                            var c = i as OpConstant;
                            result = (result as OpTypeStruct).GetResultType((int)c.Value);
                        }
                        else {
                            throw new CompilerException($"Cannot dereference non-composite type {result.ResultType.GetType().Name}.");
                        }
                    }
                    return basePtr.Derive(result);
                }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(65);
                stream.WriteShortLE((short)(4+this.index.Length));
                stream.WriteIntLE(this.basePointer.ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.basePointer.ResultId);
                foreach (var idx in this.index) {
                    stream.WriteIntLE(idx.ResultId);
                }
            }
        }

        private class OpInBoundsAccessChain : DefaultTypedResultOpCode
        {
            private readonly TypedResultOpCode basePointer;
            private readonly ResultOpCode[] index;

            public OpInBoundsAccessChain(int rid, TypedResultOpCode basePointer, params ResultOpCode[] index) : base(rid)
            {
                if (!(basePointer.ResultType is OpTypePointer)) {
                    throw new ArgumentException($"Invalid type of pointer argument: expected SpirPointerType, found {basePointer.ResultType.GetType().Name}.");
                }
                this.basePointer = basePointer;
                this.index = index;
            }

            public override TypeOpCode ResultType
            {
                get {
                    OpTypePointer basePtr = this.basePointer.ResultType as OpTypePointer;
                    TypeOpCode result = basePtr.BaseType;
                    foreach (var i in this.index) {
                        if (result is OpTypeVector) {
                            result = (result as OpTypeVector).ComponentType;
                        }
                        else if (result is OpTypeMatrix) {
                            result = (result as OpTypeMatrix).ColumnType;
                        }
                        else if (result is OpTypeArray) {
                            result = (result as OpTypeArray).ElementType;
                        }
                        else if (result is OpTypeStruct) {
                            var c = i as OpConstant;
                            result = (result as OpTypeStruct).GetResultType((int)c.Value);
                        }
                        else {
                            throw new CompilerException($"Cannot dereference non-composite type {result.ResultType.GetType().Name}.");
                        }
                    }
                    return basePtr.Derive(result);
                }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(66);
                stream.WriteShortLE((short)(4+this.index.Length));
                stream.WriteIntLE(this.basePointer.ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.basePointer.ResultId);
                foreach (var idx in this.index) {
                    stream.WriteIntLE(idx.ResultId);
                }
            }
        }

        private class OpPtrAccessChain : DefaultTypedResultOpCode
        {
            private readonly TypedResultOpCode basePointer;
            private readonly ResultOpCode element;
            private readonly ResultOpCode[] index;

            public OpPtrAccessChain(int rid, TypedResultOpCode basePointer, TypedResultOpCode element, params ResultOpCode[] index) : base(rid)
            {
                if (!(basePointer.ResultType is OpTypePointer)) {
                    throw new ArgumentException($"Invalid type of pointer argument: expected SpirPointerType, found {basePointer.ResultType.GetType().Name}.");
                }
                this.basePointer = basePointer;
                this.element = element;
                this.index = index;
            }

            public override TypeOpCode ResultType
            {
                get {
                    OpTypePointer basePtr = this.basePointer.ResultType as OpTypePointer;
                    TypeOpCode result = basePtr.BaseType;
                    foreach (var i in this.index) {
                        if (result is OpTypeVector) {
                            result = (result as OpTypeVector).ComponentType;
                        }
                        else if (result is OpTypeMatrix) {
                            result = (result as OpTypeMatrix).ColumnType;
                        }
                        else if (result is OpTypeArray) {
                            result = (result as OpTypeArray).ElementType;
                        }
                        else if (result is OpTypeStruct) {
                            var c = i as OpConstant;
                            result = (result as OpTypeStruct).GetResultType((int)c.Value);
                        }
                        else {
                            throw new CompilerException($"Cannot dereference non-composite type {result.ResultType.GetType().Name}.");
                        }
                    }
                    return basePtr.Derive(result);
                }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(67);
                stream.WriteShortLE((short)(5+this.index.Length));
                stream.WriteIntLE(this.basePointer.ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.basePointer.ResultId);
                stream.WriteIntLE(this.element.ResultId);
                foreach (var idx in this.index) {
                    stream.WriteIntLE(idx.ResultId);
                }
            }
        }

        private class OpInBoundsPtrAccessChain : DefaultTypedResultOpCode
        {
            private readonly TypedResultOpCode basePointer;
            private readonly ResultOpCode element;
            private readonly ResultOpCode[] index;

            public OpInBoundsPtrAccessChain(int rid, TypedResultOpCode basePointer, TypedResultOpCode element, params ResultOpCode[] index) : base(rid)
            {
                if (!(basePointer.ResultType is OpTypePointer)) {
                    throw new ArgumentException($"Invalid type of pointer argument: expected SpirPointerType, found {basePointer.ResultType.GetType().Name}.");
                }
                this.basePointer = basePointer;
                this.element = element;
                this.index = index;
            }

            public override TypeOpCode ResultType
            {
                get {
                    OpTypePointer basePtr = this.basePointer.ResultType as OpTypePointer;
                    TypeOpCode result = basePtr.BaseType;
                    foreach (var i in this.index) {
                        if (result is OpTypeVector) {
                            result = (result as OpTypeVector).ComponentType;
                        }
                        else if (result is OpTypeMatrix) {
                            result = (result as OpTypeMatrix).ColumnType;
                        }
                        else if (result is OpTypeArray) {
                            result = (result as OpTypeArray).ElementType;
                        }
                        else if (result is OpTypeStruct) {
                            var c = i as OpConstant;
                            result = (result as OpTypeStruct).GetResultType((int)c.Value);
                        }
                        else {
                            throw new CompilerException($"Cannot dereference non-composite type {result.ResultType.GetType().Name}.");
                        }
                    }
                    return basePtr.Derive(result);
                }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(70);
                stream.WriteShortLE((short)(5+this.index.Length));
                stream.WriteIntLE(this.basePointer.ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.basePointer.ResultId);
                stream.WriteIntLE(this.element.ResultId);
                foreach (var idx in this.index) {
                    stream.WriteIntLE(idx.ResultId);
                }
            }
        }

        // composite instructions

        private class OpVectorExtractDynamic : DefaultTypedResultOpCode
        {
            private readonly TypedResultOpCode vector;
            private readonly ResultOpCode index;

            public OpVectorExtractDynamic(int rid, TypedResultOpCode vector, ResultOpCode index) : base(rid)
            {
                if (!(vector.ResultType is OpTypeVector)) {
                    throw new ArgumentException(String.Format("Invalid vector argument type: expected OpTypeVector, found {0}.", vector.ResultType.GetType().Name));
                }
                this.vector = vector;
                this.index = index;
            }

            public override TypeOpCode ResultType
            {
                get { return (this.vector.ResultType as OpTypeVector).ComponentType.ResultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(77);
                stream.WriteShortLE(5);
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.vector.ResultId);
                stream.WriteIntLE(this.index.ResultId);
            }
        }

        private class OpCompositeExtract : DefaultTypedResultOpCode
        {
            private readonly CompositeTypeOpCode composite;
            private readonly int[] index;

            public OpCompositeExtract(int rid, CompositeTypeOpCode composite, params int[] index) : base(rid)
            {
                this.composite = composite;
                this.index = index;
            }

            public override TypeOpCode ResultType
            {
                get {
                    TypeOpCode result = this.composite;
                    foreach (var i in this.index) {
                        result = (result as CompositeTypeOpCode).GetResultType(i);
                    }
                    return result;
                }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(81);
                stream.WriteShortLE((short)(4+this.index.Length));
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.composite.ResultId);
                foreach (var idx in this.index) {
                    stream.WriteIntLE(idx);
                }
            }
        }

        // type conversion operations

        private abstract class ConversionOpCode : GenericOpCode
        {
            private readonly TypeOpCode resultType;
            private readonly TypedResultOpCode value;

            public ConversionOpCode(int rid, short code, TypeOpCode resultType, TypedResultOpCode value) : base(rid, code)
            {
                this.resultType = resultType;
                this.value = value;
            }

            public override TypeOpCode ResultType
            {
                get { return this.resultType; }
            }

            public TypedResultOpCode Value
            {
                get { return this.value; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(this.code);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.resultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.value.ResultId);
            }
        }

        private class OpConvertFToU : ConversionOpCode
        {
            public OpConvertFToU(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 109, resultType, value) { }
        }

        private class OpConvertFToS : ConversionOpCode
        {
            public OpConvertFToS(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 110, resultType, value) { }
        }

        private class OpConvertSToF : ConversionOpCode
        {
            public OpConvertSToF(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 111, resultType, value) { }
        }

        private class OpConvertUToF : ConversionOpCode
        {
            public OpConvertUToF(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 112, resultType, value) { }
        }

        private class OpUConvert : ConversionOpCode
        {
            public OpUConvert(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 113, resultType, value) { }
        }

        private class OpSConvert : ConversionOpCode
        {
            public OpSConvert(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 114, resultType, value) { }
        }

        private class OpFConvert : ConversionOpCode
        {
            public OpFConvert(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 115, resultType, value) { }
        }

        // generic unary/binary operations

        private abstract class UnaryOpCode : GenericOpCode
        {
            private readonly TypedResultOpCode operand;

            public UnaryOpCode(int rid, short code, TypedResultOpCode operand) : base(rid, code)
            {
                this.operand = operand;
            }

            public override TypeOpCode ResultType
            {
                get { return this.operand.ResultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(this.code);
                stream.WriteShortLE(4);
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.operand.ResultId);
            }
        }

        private abstract class BinaryOpCode : GenericOpCode
        {
            private readonly TypedResultOpCode op1;
            private readonly TypedResultOpCode op2;

            public BinaryOpCode(int rid, short code, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, code)
            {
                if (!op1.ResultType.Equals(op2.ResultType)) {
                    throw new ArgumentException(String.Format("Incompatible types: {0} and {1}", op1.ResultType.GetType().Name, op2.ResultType.GetType().Name));
                }
                this.op1 = op1;
                this.op2 = op2;
            }

            public override TypeOpCode ResultType
            {
                get { return this.op1.ResultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(this.code);
                stream.WriteShortLE(5);
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.op1.ResultId);
                stream.WriteIntLE(this.op2.ResultId);
            }
        }

        // arithmetic operations

        private class OpSNegate : UnaryOpCode
        {
            public OpSNegate(int rid, TypedResultOpCode operand) : base(rid, 126, operand) { }
        }

        private class OpFNegate : UnaryOpCode
        {
            public OpFNegate(int rid, TypedResultOpCode operand) : base(rid, 127, operand) { }
        }

        private class OpIAdd : BinaryOpCode
        {
            public OpIAdd(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 128, op1, op2) { }
        }

        private class OpFAdd : BinaryOpCode
        {
            public OpFAdd(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 129, op1, op2) { }
        }

        private class OpISub : BinaryOpCode
        {
            public OpISub(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 130, op1, op2) { }
        }

        private class OpFSub : BinaryOpCode
        {
            public OpFSub(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 131, op1, op2) { }
        }

        private class OpIMul : BinaryOpCode
        {
            public OpIMul(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 132, op1, op2) { }
        }

        private class OpFMul : BinaryOpCode
        {
            public OpFMul(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 133, op1, op2) { }
        }

        private class OpUDiv : BinaryOpCode
        {
            public OpUDiv(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 134, op1, op2) { }
        }

        private class OpSDiv : BinaryOpCode
        {
            public OpSDiv(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 135, op1, op2) { }
        }

        private class OpFDiv : BinaryOpCode
        {
            public OpFDiv(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 136, op1, op2) { }
        }

        private class OpUMod : BinaryOpCode
        {
            public OpUMod(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 137, op1, op2) { }
        }

        private class OpSRem : BinaryOpCode
        {
            public OpSRem(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 138, op1, op2) { }
        }

        private class OpSMod : BinaryOpCode
        {
            public OpSMod(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 139, op1, op2) { }
        }

        private class OpFRem : BinaryOpCode
        {
            public OpFRem(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 140, op1, op2) { }
        }

        private class OpFMod : BinaryOpCode
        {
            public OpFMod(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 141, op1, op2) { }
        }

        // relational and logical instructions

        private abstract class LogicalUnaryOpCode : GenericOpCode
        {
            private readonly OpTypeBool resultType;
            private readonly TypedResultOpCode operand;

            public LogicalUnaryOpCode(int rid, OpTypeBool resultType, short code, TypedResultOpCode operand) : base(rid, code)
            {
                this.resultType = resultType;
                this.operand = operand;
            }

            public override TypeOpCode ResultType
            {
                get { return this.resultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(this.code);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.resultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.operand.ResultId);
            }
        }

        private abstract class LogicalBinaryOpCode : GenericOpCode
        {
            private readonly OpTypeBool resultType;
            private readonly TypedResultOpCode op1;
            private readonly TypedResultOpCode op2;

            public LogicalBinaryOpCode(int rid, OpTypeBool resultType, short code, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, code)
            {
                this.resultType = resultType;
                this.op1 = op1;
                this.op2 = op2;
            }

            public override TypeOpCode ResultType
            {
                get { return this.resultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(this.code);
                stream.WriteShortLE(5);
                stream.WriteIntLE(this.resultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.op1.ResultId);
                stream.WriteIntLE(this.op2.ResultId);
            }
        }

        private class OpIsNan : LogicalUnaryOpCode
        {
            public OpIsNan(int rid, OpTypeBool resultType, TypedResultOpCode op) : base(rid, resultType, 156, op) { }
        }

        private class OpIsInf : LogicalUnaryOpCode
        {
            public OpIsInf(int rid, OpTypeBool resultType, TypedResultOpCode op) : base(rid, resultType, 157, op) { }
        }

        private class OpIsFinite : LogicalUnaryOpCode
        {
            public OpIsFinite(int rid, OpTypeBool resultType, TypedResultOpCode op) : base(rid, resultType, 158, op) { }
        }

        private class OpIsNormal : LogicalUnaryOpCode
        {
            public OpIsNormal(int rid, OpTypeBool resultType, TypedResultOpCode op) : base(rid, resultType, 159, op) { }
        }

        private class OpLessOrGreater : LogicalBinaryOpCode
        {
            public OpLessOrGreater(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 161, op1, op2) { }
        }

        private class OpLogicalEqual : LogicalBinaryOpCode
        {
            public OpLogicalEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 164, op1, op2) { }
        }

        private class OpLogicalNotEqual : LogicalBinaryOpCode
        {
            public OpLogicalNotEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 165, op1, op2) { }
        }

        private class OpLogicalOr : LogicalBinaryOpCode
        {
            public OpLogicalOr(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 166, op1, op2) { }
        }

        private class OpLogicalAnd : LogicalBinaryOpCode
        {
            public OpLogicalAnd(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 167, op1, op2) { }
        }

        private class OpLogicalNot : LogicalUnaryOpCode
        {
            public OpLogicalNot(int rid, OpTypeBool resultType, TypedResultOpCode op) : base(rid, resultType, 168, op) { }
        }

        private class OpSelect : GenericOpCode
        {
            private readonly TypedResultOpCode cond;
            private readonly TypedResultOpCode op1;
            private readonly TypedResultOpCode op2;

            public OpSelect(int rid, TypedResultOpCode cond, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 169)
            {
                if (!(cond.ResultType is OpTypeBool)) {
                    throw new ArgumentException($"Invalid type of 'cond' argument: expected OpTypeBool, found {cond.ResultType.GetType().Name}.");
                }
                if (!op1.ResultType.Equals(op2.ResultType)) {
                    throw new ArgumentException($"Incmopatible select argument types: {op1.ResultType.GetType().Name}, found {op2.ResultType.GetType().Name}.");
                }
                this.cond = cond;
                this.op1 = op1;
                this.op2 = op2;
            }

            public override TypeOpCode ResultType
            {
                get { return this.op1.ResultType; }
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(this.code);
                stream.WriteShortLE(6);
                stream.WriteIntLE(ResultType.ResultId);
                stream.WriteIntLE(ResultId);
                stream.WriteIntLE(this.cond.ResultId);
                stream.WriteIntLE(this.op1.ResultId);
                stream.WriteIntLE(this.op2.ResultId);
            }
        }

        private class OpIEqual : LogicalBinaryOpCode
        {
            public OpIEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 170, op1, op2) { }
        }

        private class OpINotEqual : LogicalBinaryOpCode
        {
            public OpINotEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 171, op1, op2) { }
        }

        private class OpUGreaterThan : LogicalBinaryOpCode
        {
            public OpUGreaterThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 172, op1, op2) { }
        }

        private class OpSGreaterThan : LogicalBinaryOpCode
        {
            public OpSGreaterThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 173, op1, op2) { }
        }

        private class OpUGreaterThanEqual : LogicalBinaryOpCode
        {
            public OpUGreaterThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 174, op1, op2) { }
        }

        private class OpSGreaterThanEqual : LogicalBinaryOpCode
        {
            public OpSGreaterThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 175, op1, op2) { }
        }

        private class OpULessThan : LogicalBinaryOpCode
        {
            public OpULessThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 176, op1, op2) { }
        }

        private class OpSLessThan : LogicalBinaryOpCode
        {
            public OpSLessThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 177, op1, op2) { }
        }

        private class OpULessThanEqual : LogicalBinaryOpCode
        {
            public OpULessThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 178, op1, op2) { }
        }

        private class OpSLessThanEqual : LogicalBinaryOpCode
        {
            public OpSLessThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 179, op1, op2) { }
        }

        private class OpFOrdEqual : LogicalBinaryOpCode
        {
            public OpFOrdEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 180, op1, op2) { }
        }

        private class OpFUnordEqual : LogicalBinaryOpCode
        {
            public OpFUnordEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 181, op1, op2) { }
        }

        private class OpFOrdNotEqual : LogicalBinaryOpCode
        {
            public OpFOrdNotEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 182, op1, op2) { }
        }

        private class OpFUnordNotEqual : LogicalBinaryOpCode
        {
            public OpFUnordNotEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 183, op1, op2) { }
        }

        private class OpFOrdLessThan : LogicalBinaryOpCode
        {
            public OpFOrdLessThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 184, op1, op2) { }
        }

        private class OpFUnordLessThan : LogicalBinaryOpCode
        {
            public OpFUnordLessThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 185, op1, op2) { }
        }

        private class OpFOrdGreaterThan : LogicalBinaryOpCode
        {
            public OpFOrdGreaterThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 186, op1, op2) { }
        }

        private class OpFUnordGreaterThan : LogicalBinaryOpCode
        {
            public OpFUnordGreaterThan(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 187, op1, op2) { }
        }

        private class OpFOrdLessThanEqual : LogicalBinaryOpCode
        {
            public OpFOrdLessThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 188, op1, op2) { }
        }

        private class OpFUnordLessThanEqual : LogicalBinaryOpCode
        {
            public OpFUnordLessThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 189, op1, op2) { }
        }

        private class OpFOrdGreaterThanEqual : LogicalBinaryOpCode
        {
            public OpFOrdGreaterThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 190, op1, op2) { }
        }

        private class OpFUnordGreaterThanEqual : LogicalBinaryOpCode
        {
            public OpFUnordGreaterThanEqual(int rid, OpTypeBool resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 191, op1, op2) { }
        }

        // bitwise operations

        private class OpShiftRightLogical : BinaryOpCode
        {
            public OpShiftRightLogical(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 194, op1, op2) { }
        }

        private class OpShiftRightArithmetic : BinaryOpCode
        {
            public OpShiftRightArithmetic(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 195, op1, op2) { }
        }

        private class OpShiftLeftLogical : BinaryOpCode
        {
            public OpShiftLeftLogical(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 196, op1, op2) { }
        }

        private class OpBitwiseOr : BinaryOpCode
        {
            public OpBitwiseOr(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 197, op1, op2) { }
        }

        private class OpBitwiseXor : BinaryOpCode
        {
            public OpBitwiseXor(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 198, op1, op2) { }
        }

        private class OpBitwiseAnd : BinaryOpCode
        {
            public OpBitwiseAnd(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 199, op1, op2) { }
        }

        private class OpNot : UnaryOpCode
        {
            public OpNot(int rid, TypedResultOpCode operand) : base(rid, 200, operand) { }
        }

        // control flow instructions

        private class OpLabel : DefaultResultOpCode
        {
            public OpLabel(int rid) : base(rid) { }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(248);
                stream.WriteShortLE(2);
                stream.WriteIntLE(ResultId);
            }
        }

        private class OpBranch : SpirOpCode
        {
            private readonly OpLabel label;

            public OpBranch(OpLabel label)
            {
                this.label = label;
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(249);
                stream.WriteShortLE(2);
                stream.WriteIntLE(this.label.ResultId);
            }
        }

        private class OpBranchConditional : SpirOpCode
        {
            private readonly TypedResultOpCode condition;
            private readonly OpLabel trueLabel;
            private readonly OpLabel falseLabel;

            public OpBranchConditional(TypedResultOpCode condition, OpLabel trueLabel, OpLabel falseLabel)
            {
                this.condition = condition;
                this.trueLabel = trueLabel;
                this.falseLabel = falseLabel;
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(250);
                stream.WriteShortLE(4);
                stream.WriteIntLE(this.condition.ResultId);
                stream.WriteIntLE(this.trueLabel.ResultId);
                stream.WriteIntLE(this.falseLabel.ResultId);
            }
        }

        private class OpReturn : SpirOpCode
        {
            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(253);
                stream.WriteShortLE(1);
            }
        }

        private class OpReturnValue : SpirOpCode
        {
            private readonly TypedResultOpCode value;

            public OpReturnValue(TypedResultOpCode value)
            {
                this.value = value;
            }

            public override void Emit(Stream stream)
            {
                stream.WriteShortLE(254);
                stream.WriteShortLE(2);
                stream.WriteIntLE(this.value.ResultId);
            }
        }
    }

    static class StreamExtensions
    {
        public static void WriteByteLE(this Stream stream, sbyte value)
        {
            var buf = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) {
                Array.Reverse(buf);
            }
            stream.Write(buf, 0, buf.Length);
        }

        public static void WriteShortLE(this Stream stream, short value)
        {
            var buf = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) {
                Array.Reverse(buf);
            }
            stream.Write(buf, 0, buf.Length);
        }

        public static void WriteIntLE(this Stream stream, int value)
        {
            var buf = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) {
                Array.Reverse(buf);
            }
            stream.Write(buf, 0, buf.Length);
        }

        public static void WriteLongLE(this Stream stream, long value)
        {
            var buf = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) {
                Array.Reverse(buf);
            }
            stream.Write(buf, 0, buf.Length);
        }

        public static void WriteFloatLE(this Stream stream, float value)
        {
            var buf = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) {
                Array.Reverse(buf);
            }
            stream.Write(buf, 0, buf.Length);
        }

        public static void WriteDoubleLE(this Stream stream, double value)
        {
            var buf = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) {
                Array.Reverse(buf);
            }
            stream.Write(buf, 0, buf.Length);
        }

        public static int GetPaddedLength(string value) {
            // var bytes = Encoding.ASCII.GetBytes(value);
            // var len = bytes.Length;
            var len = value.Length;
            return (len+4) & ~3;
        }

        public static void WriteString(this Stream stream, string value) {
            var bytes = Encoding.ASCII.GetBytes(value);
            var len = bytes.Length;
            stream.Write(bytes, 0, len);
            var npad = ((len+4) & ~3) - len;
            for (var i=0; i<npad; i++) {
                stream.WriteByte(0x00);
            }
        }
    }
}
