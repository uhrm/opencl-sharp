
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenCl.Compiler
{
    //
    // SPIR-V opcodes
    //

    abstract class SpirOpCode
    {
        public abstract void Emit(Stream stream);
    }

    abstract class ResultOpCode : SpirOpCode
    {
        public abstract int ResultId { get; }
    }

    abstract class TypedResultOpCode : ResultOpCode
    {
        public abstract TypeOpCode ResultType { get; }
    }

    abstract class DefaultResultOpCode : ResultOpCode
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

    abstract class DefaultTypedResultOpCode : TypedResultOpCode
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

    abstract class GenericOpCode : DefaultTypedResultOpCode
    {
        protected readonly short code;

        public GenericOpCode(int rid, short code) : base(rid)
        {
            this.code = code;
        }
    }

    class OpNop : SpirOpCode
    {
        public override void Emit(Stream stream)
        {
            stream.WriteShortLE(0);
            stream.WriteShortLE(1);
        }
    }

    abstract class OpDecorate : SpirOpCode
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

    class OpDecorateBuiltIn : OpDecorate
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

    class OpDecorateConstant : OpDecorate
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

    class OpDecorateLinkageAttributes : OpDecorate
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

    class OpExtInstImport : DefaultResultOpCode
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

    class OpMemoryModel : SpirOpCode
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

    class OpEntryPoint : SpirOpCode
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

    class OpCapability : SpirOpCode
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

    abstract class TypeOpCode : TypedResultOpCode 
    {
        private readonly SpirCompiler compiler;

        protected TypeOpCode(SpirCompiler compiler)
        {
            this.compiler = compiler;
        }

        public override int ResultId
        {
            get { return this.compiler.TypeResultId(this); }
        }

        public override TypeOpCode ResultType
        {
            get { return this; }
        }

        public abstract override bool Equals(object obj);
        
        public abstract override int GetHashCode();
    }

    class OpTypeVoid : TypeOpCode
    {
        public OpTypeVoid(SpirCompiler compiler) : base(compiler) { }

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

    abstract class ScalarTypeOpCode : TypeOpCode
    {
        protected ScalarTypeOpCode(SpirCompiler compiler) : base(compiler) { }
    }

    class OpTypeBool : ScalarTypeOpCode
    {
        public OpTypeBool(SpirCompiler compiler) : base(compiler) { }

        public override void Emit(Stream stream) {
            stream.WriteShortLE(20);
            stream.WriteShortLE(2);
            stream.WriteIntLE(this.ResultId);
        }

        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType();
        }
        
        public override int GetHashCode()
        {
            return 0x6584c26a;
        }
    }

    abstract class NumericTypeOpCode : ScalarTypeOpCode
    {
        protected NumericTypeOpCode(SpirCompiler compiler) : base(compiler) { }

        public abstract int Width { get; }
    }

    class OpTypeInt : NumericTypeOpCode
    {
        private readonly int width;
        private readonly int signedness;

        public OpTypeInt(SpirCompiler compiler, int width) : this(compiler, width, 0) { }

        public OpTypeInt(SpirCompiler compiler, int width, int signedness) : base(compiler)
        {
            if (signedness != 0) {
                throw new ArgumentException($"Invalid value for argument '{nameof(signedness)}': expected 0, found {signedness}", nameof(signedness));
            }
            this.width = width;
            this.signedness = signedness != 0 ? 1 : 0;
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeInt;
            return this.width == t.width && this.signedness == t.signedness;
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x70dd8170;
                result = 397*result + this.width.GetHashCode();
                result = 397*result + this.signedness.GetHashCode();
                return result;
            }
        }
    }

    class OpTypeFloat : NumericTypeOpCode
    {
        private readonly int width;

        public OpTypeFloat(SpirCompiler compiler, int width) : base(compiler)
        {
            this.width = width;
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeFloat;
            return this.width == t.width;
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x7457a880;
                result = 397*result + this.width.GetHashCode();
                return  result;
            }
        }
    }

    abstract class CompositeTypeOpCode : TypeOpCode
    {
        protected CompositeTypeOpCode(SpirCompiler compiler) : base(compiler) { }

        public abstract TypeOpCode GetResultType(int index);
    }

    class OpTypeVector : CompositeTypeOpCode
    {
        private readonly ScalarTypeOpCode componentType;
        private readonly int componentCount;

        public OpTypeVector(SpirCompiler compiler, int componentCount, ScalarTypeOpCode componentType) : this(compiler, componentType, componentCount) { }

        private OpTypeVector(SpirCompiler compiler, ScalarTypeOpCode componentType, int componentCount) : base(compiler)
        {
            this.componentType = componentType;
            this.componentCount = componentCount;
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
                throw new ArgumentException($"Invalid value of '{nameof(index)}': expected 0 <= i < {this.componentCount}, found i = {index}.", nameof(index));
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeVector;
            return this.componentType.Equals(t.componentType) && this.componentCount == t.componentCount;
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x2b8edf05;
                result = 397*result + this.componentType.GetHashCode();
                result = 397*result + this.componentCount.GetHashCode();
                return  result;
            }
        }
    }

    class OpTypeMatrix : CompositeTypeOpCode
    {
        private readonly OpTypeVector columnType;
        private readonly int columnCount;

        public OpTypeMatrix(SpirCompiler compiler, OpTypeVector columnType, int columnCount) : base(compiler)
        {
            this.columnType = columnType;
            this.columnCount = columnCount;
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
                throw new ArgumentException($"Invalid value of '{nameof(index)}': expected 0 <= i < {this.columnCount}, found i = {index}.", nameof(index));
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeMatrix;
            return this.columnType.Equals(t.columnType) && this.columnCount == t.columnCount;
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x52cc5dfb;
                result = 397*result + this.columnType.GetHashCode();
                result = 397*result + this.columnCount.GetHashCode();
                return result;
            }
        }
    }

    abstract class AggregateTypeOpCode : CompositeTypeOpCode
    {
        protected AggregateTypeOpCode(SpirCompiler compiler) : base(compiler) { }
    }

    class OpTypeArray : AggregateTypeOpCode
    {
        private readonly TypeOpCode elementType;
        private readonly int length;

        public OpTypeArray(SpirCompiler compiler, TypeOpCode elementType, int length) : base(compiler)
        {
            this.elementType = elementType;
            this.length = length;
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
                throw new ArgumentException($"Invalid value of '{nameof(index)}': expected 0 <= i < {this.length}, found {index}.", nameof(index));
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeArray;
            return this.elementType.Equals(t.elementType) && this.length == t.length;
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x23871a4e;
                result = 397*result + this.elementType.GetHashCode();
                result = 397*result + this.length.GetHashCode();
                return result;
            }
        }
    }

    class OpTypeRuntimeArray : TypeOpCode
    {
        private readonly TypeOpCode elementType;

        public OpTypeRuntimeArray(SpirCompiler compiler, TypeOpCode elementType) : base(compiler)
        {
            this.elementType = elementType;
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeRuntimeArray;
            return this.elementType.Equals(t.elementType);
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x2f3e8210;
                result = 397*result + this.elementType.GetHashCode();
                return result;
            }
        }
    }

    class OpTypeStruct : AggregateTypeOpCode
    {
        private readonly TypeOpCode[] members;

        public OpTypeStruct(SpirCompiler compiler, params TypeOpCode[] members) : base(compiler)
        {
            this.members = members;
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
                throw new ArgumentException($"Invalid value of '{nameof(index)}': expected 0 <= i < {this.members.Length}, found {index}.", nameof(index));
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeStruct;
            if (this.members.Length != t.members.Length) {
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
            unchecked {
                var result = 0x38226897;
                result = 397*result + this.members.Length.GetHashCode();
                foreach (var m in this.members) {
                    result = 397*result + m.GetHashCode();
                }
                return result;
            }
        }
    }

    class OpTypeOpaque : TypeOpCode
    {
        private readonly string name;

        public OpTypeOpaque(SpirCompiler compiler, string name) : base(compiler)
        {
            this.name = name;
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeOpaque;
            return this.name.Equals(t.name);
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x37549a9e;
                result = 397*result + this.name.GetHashCode();
                return result;
            }
        }
    }

    class OpTypePointer : TypeOpCode
    {
        private readonly TypeOpCode baseType;
        private readonly StorageClass storage;

        public OpTypePointer(SpirCompiler compiler, StorageClass storage, TypeOpCode baseType) : this(compiler, baseType, storage) { }

        private OpTypePointer(SpirCompiler compiler, TypeOpCode baseType, StorageClass storage) : base(compiler)
        {
            this.baseType = baseType;
            this.storage = storage;
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypePointer;
            return this.baseType.Equals(t.baseType) && this.storage == t.storage;
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x1cdc9de7;
                result = 397*result + this.baseType.GetHashCode();
                result = 397*result + this.storage.GetHashCode();
                return result;
            }
        }

        // public OpTypePointer Derive(TypeOpCode type)
        // {
        //     return new OpTypePointer(this.rfunc, this.storage, type);
        // }
    }

    class OpTypeFunction : TypeOpCode
    {
        private readonly TypeOpCode result;
        private readonly TypeOpCode[] parameters;

        public OpTypeFunction(SpirCompiler compiler, TypeOpCode result, params TypeOpCode[] parameters) : base(compiler)
        {
            this.result = result;
            this.parameters = parameters;
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
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var t = obj as OpTypeFunction;
            if (!this.result.Equals(t.result) || this.parameters.Length != t.parameters.Length) {
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
            unchecked {
                var result = 0x437d165a;
                result = 397*result + this.result.GetHashCode();
                result = 397*result + this.parameters.Length.GetHashCode();
                foreach (var p in this.parameters) {
                    result = 397*result + p.GetHashCode();
                }
                return result;
            }
        }
    }

    abstract class ConstOpCode : TypedResultOpCode
    {
        private readonly SpirCompiler compiler;

        protected ConstOpCode(SpirCompiler compiler)
        {
            this.compiler = compiler;
        }

        public override int ResultId
        {
            get { return this.compiler.ConstResultId(this); }
        }
    }

    sealed class OpConstantTrue : ConstOpCode
    {
        private readonly OpTypeBool type;

        public OpConstantTrue(SpirCompiler compiler, OpTypeBool type)
            : base(compiler)
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

        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType();
        }
        
        public override int GetHashCode()
        {
            return 0x095d36bd;
        }
    }

    sealed class OpConstantFalse : ConstOpCode
    {
        private OpTypeBool type;

        public OpConstantFalse(SpirCompiler compiler, OpTypeBool type)
            : base(compiler)
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

        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType();
        }
        
        public override int GetHashCode()
        {
            return 0x5da86d33;
        }
    }

    sealed class OpConstant : ConstOpCode
    {
        private readonly NumericTypeOpCode type;
        private readonly object value;

        public OpConstant(SpirCompiler compiler, NumericTypeOpCode type, object value)
            : base(compiler)
        {
            this.type = type;
            this.value = value;
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
                    // if ((this.type as OpTypeInt).Signedness == 1) {
                    stream.WriteIntLE(Convert.ToSByte(this.value));
                    // }
                    // else {
                    //     stream.WriteByteLE(Convert.ToByte(this.value));
                    // }
                    break;
                case 16:
                    // if ((this.type as OpTypeInt).Signedness == 1) {
                    stream.WriteIntLE(Convert.ToInt16(this.value));
                    // }
                    // else {
                    //     stream.WriteShortLE(Convert.ToUInt16(this.value));
                    // }
                    break;
                case 32:
                    // if ((this.type as OpTypeInt).Signedness == 1) {
                    stream.WriteIntLE(Convert.ToInt32(this.value));
                    // }
                    // else {
                    //     stream.WriteIntLE(Convert.ToUInt32(this.value));
                    // }
                    break;
                case 64:
                    // if ((this.type as OpTypeInt).Signedness == 1) {
                    stream.WriteLongLE(Convert.ToInt64(this.value));
                    // }
                    // else {
                    //     stream.WriteLongLE(Convert.ToUInt64(this.value));
                    // }
                    break;
                default:
                    throw new CompilerException($"Unsupported integer width: {this.type.Width} (expected width 8, 16, 32, or 64)");
                }
            }
            else if (this.type is OpTypeFloat) {
                switch (this.type.Width) {
                case 32:
                    stream.WriteFloatLE(Convert.ToSingle(this.value));
                    break;
                case 64:
                    stream.WriteDoubleLE(Convert.ToDouble(this.value));
                    break;
                default:
                    throw new CompilerException($"Unsupported floating point width: {this.type.Width} (expected width 32 or 64)");
                }
            }
            else {
                throw new CompilerException($"Unsupported constant type: '{this.type.GetType().Name}'.");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var c = obj as OpConstant;
            return this.type.Equals(c.type) && this.value.Equals(c.value);
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x074147fc;
                result = 397*result + this.type.GetHashCode();
                result = 397*result + this.value.GetHashCode();
                return result;
            }
        }
    }

    sealed class OpConstantComposite : ConstOpCode
    {
        private readonly CompositeTypeOpCode resultType;

        private readonly OpConstant[] members;

        public OpConstantComposite(SpirCompiler compiler, CompositeTypeOpCode resultType, params OpConstant[] members)
            : base(compiler)
        {
            if (resultType is OpTypeVector) {
                int n = (resultType as OpTypeVector).ComponentCount;
                if (members.Length != n) {
                    throw new ArgumentException($"Invalid number of members: expected {n}, found {members.Length}.");
                }
                for (var i=0; i<n; i++) {
                    var t = (resultType as OpTypeVector).GetResultType(i);
                    if (!t.Equals(members[i].ResultType)) {
                    throw new ArgumentException($"Invalid type of member {i}: expected {t}, found {members[i].ResultType}.");
                    }
                }
            }
            else if (resultType is OpTypeMatrix) {
                int n = (resultType as OpTypeMatrix).ColumnCount;
                if (members.Length != n) {
                    throw new ArgumentException($"Invalid number of members: expected {n}, found {members.Length}.");
                }
                for (var i=0; i<n; i++) {
                    var t = (resultType as OpTypeMatrix).GetResultType(i);
                    if (!t.Equals(members[i].ResultType)) {
                    throw new ArgumentException($"Invalid type of member {i}: expected {t}, found {members[i].ResultType}.");
                    }
                }
            }
            else if (resultType is OpTypeArray) {
                int n = (resultType as OpTypeArray).Length;
                if (members.Length != n) {
                    throw new ArgumentException($"Invalid number of members: expected {n}, found {members.Length}.");
                }
                var t = (resultType as OpTypeArray).ElementType;
                for (var i=0; i<n; i++) {
                    if (!t.Equals(members[i].ResultType)) {
                    throw new ArgumentException($"Invalid type of member {i}: expected {t}, found {members[i].ResultType}.");
                    }
                }
            }
            else if (resultType is OpTypeStruct) {
                var m = (resultType as OpTypeStruct).Member;
                if (members.Length != m.Count) {
                    throw new ArgumentException($"Invalid number of members: expected {m.Count}, found {members.Length}.");
                }
                for (var i=0; i<m.Count; i++) {
                    var ti = m[i].ResultType;
                    if (!ti.Equals(members[i].ResultType)) {
                    throw new ArgumentException($"Invalid type of member {i}: expected {ti}, found {members[i].ResultType}.");
                    }
                }
            }
            else {
                throw new ArgumentException($"Result type {resultType.ResultType} is non-composite.");
            }
            this.resultType = resultType;
            this.members = members;
        }

        public override TypeOpCode ResultType
        {
            get { return this.resultType; }
        }

        public IReadOnlyList<OpConstant> Member
        {
            get { return this.members; }
        }

        public override void Emit(Stream stream)
        {
            stream.WriteShortLE(44);
            stream.WriteShortLE((short)(3+this.members.Length));
            stream.WriteIntLE(this.resultType.ResultId);
            stream.WriteIntLE(ResultId);
            foreach (var m in this.members) {
                stream.WriteIntLE(m.ResultId);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var c = obj as OpConstantComposite;
            return this.resultType.Equals(c.resultType) && ((IStructuralEquatable)this.members).Equals(c.members, StructuralComparisons.StructuralEqualityComparer);
        }
        
        public override int GetHashCode()
        {
            unchecked {
                var result = 0x03deaee7;
                result = 397*result + this.resultType.GetHashCode();
                result = 397*result + ((IStructuralEquatable)this.members).GetHashCode(StructuralComparisons.StructuralEqualityComparer);
                return result;
            }
        }
    }

    // function instructions

    class OpFunction : DefaultTypedResultOpCode
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

    class OpFunctionParameter : DefaultTypedResultOpCode
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

    class OpFunctionEnd : SpirOpCode
    {
        public override void Emit(Stream stream)
        {
            stream.WriteShortLE(56);
            stream.WriteShortLE(1);
        }
    }

    class OpFunctionCall : DefaultTypedResultOpCode
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

    class OpVariable : DefaultTypedResultOpCode
    {
        private readonly OpTypePointer resultType;
        // private readonly StorageClass storage;
        private readonly ResultOpCode initializer;

        public OpVariable(int rid, OpTypePointer resultType/*, StorageClass storage*/) : this(rid, resultType/*, storage*/, null) { }

        public OpVariable(int rid, OpTypePointer resultType/*, StorageClass storage*/, TypedResultOpCode initializer) : base(rid)
        {
            if (initializer != null && !initializer.ResultType.Equals(resultType.BaseType)) {
                throw new ArgumentException($"Incmopatible initializer type: expected {initializer.ResultType.GetType().Name}, found {resultType.BaseType.GetType().Name}.", nameof(initializer));
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

    class OpLoad : DefaultTypedResultOpCode
    {
        private readonly TypedResultOpCode pointer;
        private readonly MemoryAccess memoryAccess;
        private readonly int alignment;

        public OpLoad(int rid, TypedResultOpCode pointer) : this(rid, pointer, MemoryAccess.None, 0) { }

        public OpLoad(int rid, TypedResultOpCode pointer, MemoryAccess memoryAccess, int alignment) : base(rid)
        {
            if (!(pointer.ResultType is OpTypePointer)) {
                throw new ArgumentException($"Invalid type of argument '{nameof(pointer)}': expected 'SpirPointerType', found '{pointer.ResultType.GetType().Name}'.", nameof(pointer));
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

    class OpStore : SpirOpCode
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

    class OpAccessChain : DefaultTypedResultOpCode
    {
        private readonly SpirCompiler compiler;
        private readonly TypedResultOpCode basePointer;
        private readonly ResultOpCode[] index;

        public OpAccessChain(SpirCompiler compiler, int rid, TypedResultOpCode basePointer, params ResultOpCode[] index) : base(rid)
        {
            if (!(basePointer.ResultType is OpTypePointer)) {
                throw new ArgumentException($"Invalid type of argument '{nameof(basePointer)}': expected 'OpTypePointer', found '{basePointer.ResultType.GetType().Name}'.", nameof(basePointer));
            }
            this.compiler = compiler;
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
                        throw new CompilerException($"Cannot dereference non-composite type '{result.ResultType.GetType().Name}'.");
                    }
                }
                return this.compiler.OpTypePointer(basePtr.Storage, result);
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

    class OpInBoundsAccessChain : DefaultTypedResultOpCode
    {
        private readonly SpirCompiler compiler;
        private readonly TypedResultOpCode basePointer;
        private readonly ResultOpCode[] index;

        public OpInBoundsAccessChain(SpirCompiler compiler, int rid, TypedResultOpCode basePointer, params ResultOpCode[] index) : base(rid)
        {
            if (!(basePointer.ResultType is OpTypePointer)) {
                throw new ArgumentException($"Invalid type of argument '{nameof(basePointer)}': expected 'SpirPointerType', found '{basePointer.ResultType.GetType().Name}'.", nameof(basePointer));
            }
            this.compiler = compiler;
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
                        throw new CompilerException($"Cannot dereference non-composite type '{result.ResultType.GetType().Name}'.");
                    }
                }
                return this.compiler.OpTypePointer(basePtr.Storage, result);
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

    class OpPtrAccessChain : DefaultTypedResultOpCode
    {
        private readonly SpirCompiler compiler;
        private readonly TypedResultOpCode basePointer;
        private readonly ResultOpCode element;
        private readonly ResultOpCode[] index;

        public OpPtrAccessChain(SpirCompiler compiler, int rid, TypedResultOpCode basePointer, TypedResultOpCode element, params ResultOpCode[] index) : base(rid)
        {
            if (!(basePointer.ResultType is OpTypePointer)) {
                throw new ArgumentException($"Invalid type of argument '{nameof(basePointer)}': expected 'SpirPointerType', found '{basePointer.ResultType.GetType().Name}'.", nameof(basePointer));
            }
            this.compiler = compiler;
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
                        throw new CompilerException($"Cannot dereference non-composite type '{result.ResultType.GetType().Name}'.");
                    }
                }
                return this.compiler.OpTypePointer(basePtr.Storage, result);
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

    class OpInBoundsPtrAccessChain : DefaultTypedResultOpCode
    {
        private readonly SpirCompiler compiler;
        private readonly TypedResultOpCode basePointer;
        private readonly ResultOpCode element;
        private readonly ResultOpCode[] index;

        public OpInBoundsPtrAccessChain(SpirCompiler compiler, int rid, TypedResultOpCode basePointer, TypedResultOpCode element, params ResultOpCode[] index) : base(rid)
        {
            if (!(basePointer.ResultType is OpTypePointer)) {
                throw new ArgumentException($"Invalid type of argument '{nameof(basePointer)}': expected 'SpirPointerType', found '{basePointer.ResultType.GetType().Name}'.", nameof(basePointer));
            }
            this.compiler = compiler;
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
                        throw new CompilerException($"Cannot dereference non-composite type '{result.ResultType.GetType().Name}'.");
                    }
                }
                return this.compiler.OpTypePointer(basePtr.Storage, result);
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

    class OpVectorExtractDynamic : DefaultTypedResultOpCode
    {
        private readonly TypedResultOpCode vector;
        private readonly ResultOpCode index;

        public OpVectorExtractDynamic(int rid, TypedResultOpCode vector, ResultOpCode index) : base(rid)
        {
            if (!(vector.ResultType is OpTypeVector)) {
                throw new ArgumentException($"Invalid type of argument '{nameof(vector)}': expected 'OpTypeVector', found '{vector.ResultType.GetType().Name}'.", nameof(vector));
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

    class OpCompositeExtract : DefaultTypedResultOpCode
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

    abstract class ConversionOpCode : GenericOpCode
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

    class OpConvertFToU : ConversionOpCode
    {
        public OpConvertFToU(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 109, resultType, value) { }
    }

    class OpConvertFToS : ConversionOpCode
    {
        public OpConvertFToS(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 110, resultType, value) { }
    }

    class OpConvertSToF : ConversionOpCode
    {
        public OpConvertSToF(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 111, resultType, value) { }
    }

    class OpConvertUToF : ConversionOpCode
    {
        public OpConvertUToF(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 112, resultType, value) { }
    }

    class OpUConvert : ConversionOpCode
    {
        public OpUConvert(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 113, resultType, value) { }
    }

    class OpSConvert : ConversionOpCode
    {
        public OpSConvert(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 114, resultType, value) { }
    }

    class OpFConvert : ConversionOpCode
    {
        public OpFConvert(int rid, TypeOpCode resultType, TypedResultOpCode value) : base(rid, 115, resultType, value) { }
    }

    // generic unary/binary operations

    abstract class UnaryOpCode : GenericOpCode
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

    abstract class BinaryOpCode : GenericOpCode
    {
        private readonly TypedResultOpCode op1;
        private readonly TypedResultOpCode op2;

        public BinaryOpCode(int rid, short code, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, code)
        {
            if (!op1.ResultType.Equals(op2.ResultType)) {
                throw new ArgumentException($"Incompatible types: '{op1.ResultType.GetType().Name}' and '{op2.ResultType.GetType().Name}'.");
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

    class OpSNegate : UnaryOpCode
    {
        public OpSNegate(int rid, TypedResultOpCode operand) : base(rid, 126, operand) { }
    }

    class OpFNegate : UnaryOpCode
    {
        public OpFNegate(int rid, TypedResultOpCode operand) : base(rid, 127, operand) { }
    }

    class OpIAdd : BinaryOpCode
    {
        public OpIAdd(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 128, op1, op2) { }
    }

    class OpFAdd : BinaryOpCode
    {
        public OpFAdd(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 129, op1, op2) { }
    }

    class OpISub : BinaryOpCode
    {
        public OpISub(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 130, op1, op2) { }
    }

    class OpFSub : BinaryOpCode
    {
        public OpFSub(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 131, op1, op2) { }
    }

    class OpIMul : BinaryOpCode
    {
        public OpIMul(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 132, op1, op2) { }
    }

    class OpFMul : BinaryOpCode
    {
        public OpFMul(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 133, op1, op2) { }
    }

    class OpUDiv : BinaryOpCode
    {
        public OpUDiv(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 134, op1, op2) { }
    }

    class OpSDiv : BinaryOpCode
    {
        public OpSDiv(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 135, op1, op2) { }
    }

    class OpFDiv : BinaryOpCode
    {
        public OpFDiv(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 136, op1, op2) { }
    }

    class OpUMod : BinaryOpCode
    {
        public OpUMod(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 137, op1, op2) { }
    }

    class OpSRem : BinaryOpCode
    {
        public OpSRem(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 138, op1, op2) { }
    }

    class OpSMod : BinaryOpCode
    {
        public OpSMod(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 139, op1, op2) { }
    }

    class OpFRem : BinaryOpCode
    {
        public OpFRem(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 140, op1, op2) { }
    }

    class OpFMod : BinaryOpCode
    {
        public OpFMod(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 141, op1, op2) { }
    }

    // relational and logical instructions

    abstract class LogicalUnaryOpCode : GenericOpCode
    {
        private readonly TypeOpCode resultType;
        private readonly TypedResultOpCode operand;

        public LogicalUnaryOpCode(int rid, TypeOpCode resultType, short code, TypedResultOpCode operand) : base(rid, code)
        {
            if (!((operand.ResultType is ScalarTypeOpCode && resultType is OpTypeBool) || (operand.ResultType is OpTypeVector && (resultType as OpTypeVector)?.ComponentType is OpTypeBool))) {
                throw new ArgumentException($"Incompatible result type '{resultType.GetType().Name}' for operands of type '{operand.ResultType.GetType().Name}'.");
            }
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

    abstract class LogicalBinaryOpCode : GenericOpCode
    {
        private readonly TypeOpCode resultType;
        private readonly TypedResultOpCode op1;
        private readonly TypedResultOpCode op2;

        public LogicalBinaryOpCode(int rid, TypeOpCode resultType, short code, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, code)
        {
            if (!op1.ResultType.Equals(op2.ResultType)) {
                throw new ArgumentException($"Incompatible types: '{op1.ResultType.GetType().Name}' and '{op2.ResultType.GetType().Name}'.");
            }
            if (!((op1.ResultType is ScalarTypeOpCode && resultType is OpTypeBool) || (op1.ResultType is OpTypeVector && (resultType as OpTypeVector)?.ComponentType is OpTypeBool))) {
                throw new ArgumentException($"Incompatible result type '{resultType.GetType().Name}' for operands of type '{op1.ResultType.GetType().Name}'.");
            }
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

    class OpIsNan : LogicalUnaryOpCode
    {
        public OpIsNan(int rid, TypeOpCode resultType, TypedResultOpCode op) : base(rid, resultType, 156, op) { }
    }

    class OpIsInf : LogicalUnaryOpCode
    {
        public OpIsInf(int rid, TypeOpCode resultType, TypedResultOpCode op) : base(rid, resultType, 157, op) { }
    }

    class OpIsFinite : LogicalUnaryOpCode
    {
        public OpIsFinite(int rid, TypeOpCode resultType, TypedResultOpCode op) : base(rid, resultType, 158, op) { }
    }

    class OpIsNormal : LogicalUnaryOpCode
    {
        public OpIsNormal(int rid, TypeOpCode resultType, TypedResultOpCode op) : base(rid, resultType, 159, op) { }
    }

    class OpLessOrGreater : LogicalBinaryOpCode
    {
        public OpLessOrGreater(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 161, op1, op2) { }
    }

    class OpLogicalEqual : LogicalBinaryOpCode
    {
        public OpLogicalEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 164, op1, op2) { }
    }

    class OpLogicalNotEqual : LogicalBinaryOpCode
    {
        public OpLogicalNotEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 165, op1, op2) { }
    }

    class OpLogicalOr : LogicalBinaryOpCode
    {
        public OpLogicalOr(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 166, op1, op2) { }
    }

    class OpLogicalAnd : LogicalBinaryOpCode
    {
        public OpLogicalAnd(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 167, op1, op2) { }
    }

    class OpLogicalNot : LogicalUnaryOpCode
    {
        public OpLogicalNot(int rid, TypeOpCode resultType, TypedResultOpCode op) : base(rid, resultType, 168, op) { }
    }

    class OpSelect : GenericOpCode
    {
        private readonly TypedResultOpCode cond;
        private readonly TypedResultOpCode op1;
        private readonly TypedResultOpCode op2;

        public OpSelect(int rid, TypedResultOpCode cond, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 169)
        {
            if (!(cond.ResultType is OpTypeBool) && !((cond.ResultType as OpTypeVector)?.ComponentType is OpTypeBool)) {
                throw new ArgumentException($"Invalid type of argument '{nameof(cond)}': {cond.ResultType}.");
            }
            if (!op1.ResultType.Equals(op2.ResultType)) {
                throw new ArgumentException($"Incompatible select argument types: '{op1.ResultType.GetType().Name}' and '{op2.ResultType.GetType().Name}'.");
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

    class OpIEqual : LogicalBinaryOpCode
    {
        public OpIEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 170, op1, op2) { }
    }

    class OpINotEqual : LogicalBinaryOpCode
    {
        public OpINotEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 171, op1, op2) { }
    }

    class OpUGreaterThan : LogicalBinaryOpCode
    {
        public OpUGreaterThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 172, op1, op2) { }
    }

    class OpSGreaterThan : LogicalBinaryOpCode
    {
        public OpSGreaterThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 173, op1, op2) { }
    }

    class OpUGreaterThanEqual : LogicalBinaryOpCode
    {
        public OpUGreaterThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 174, op1, op2) { }
    }

    class OpSGreaterThanEqual : LogicalBinaryOpCode
    {
        public OpSGreaterThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 175, op1, op2) { }
    }

    class OpULessThan : LogicalBinaryOpCode
    {
        public OpULessThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 176, op1, op2) { }
    }

    class OpSLessThan : LogicalBinaryOpCode
    {
        public OpSLessThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 177, op1, op2) { }
    }

    class OpULessThanEqual : LogicalBinaryOpCode
    {
        public OpULessThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 178, op1, op2) { }
    }

    class OpSLessThanEqual : LogicalBinaryOpCode
    {
        public OpSLessThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 179, op1, op2) { }
    }

    class OpFOrdEqual : LogicalBinaryOpCode
    {
        public OpFOrdEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 180, op1, op2) { }
    }

    class OpFUnordEqual : LogicalBinaryOpCode
    {
        public OpFUnordEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 181, op1, op2) { }
    }

    class OpFOrdNotEqual : LogicalBinaryOpCode
    {
        public OpFOrdNotEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 182, op1, op2) { }
    }

    class OpFUnordNotEqual : LogicalBinaryOpCode
    {
        public OpFUnordNotEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 183, op1, op2) { }
    }

    class OpFOrdLessThan : LogicalBinaryOpCode
    {
        public OpFOrdLessThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 184, op1, op2) { }
    }

    class OpFUnordLessThan : LogicalBinaryOpCode
    {
        public OpFUnordLessThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 185, op1, op2) { }
    }

    class OpFOrdGreaterThan : LogicalBinaryOpCode
    {
        public OpFOrdGreaterThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 186, op1, op2) { }
    }

    class OpFUnordGreaterThan : LogicalBinaryOpCode
    {
        public OpFUnordGreaterThan(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 187, op1, op2) { }
    }

    class OpFOrdLessThanEqual : LogicalBinaryOpCode
    {
        public OpFOrdLessThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 188, op1, op2) { }
    }

    class OpFUnordLessThanEqual : LogicalBinaryOpCode
    {
        public OpFUnordLessThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 189, op1, op2) { }
    }

    class OpFOrdGreaterThanEqual : LogicalBinaryOpCode
    {
        public OpFOrdGreaterThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 190, op1, op2) { }
    }

    class OpFUnordGreaterThanEqual : LogicalBinaryOpCode
    {
        public OpFUnordGreaterThanEqual(int rid, TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, resultType, 191, op1, op2) { }
    }

    // bitwise operations

    class OpShiftRightLogical : BinaryOpCode
    {
        public OpShiftRightLogical(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 194, op1, op2) { }
    }

    class OpShiftRightArithmetic : BinaryOpCode
    {
        public OpShiftRightArithmetic(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 195, op1, op2) { }
    }

    class OpShiftLeftLogical : BinaryOpCode
    {
        public OpShiftLeftLogical(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 196, op1, op2) { }
    }

    class OpBitwiseOr : BinaryOpCode
    {
        public OpBitwiseOr(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 197, op1, op2) { }
    }

    class OpBitwiseXor : BinaryOpCode
    {
        public OpBitwiseXor(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 198, op1, op2) { }
    }

    class OpBitwiseAnd : BinaryOpCode
    {
        public OpBitwiseAnd(int rid, TypedResultOpCode op1, TypedResultOpCode op2) : base(rid, 199, op1, op2) { }
    }

    class OpNot : UnaryOpCode
    {
        public OpNot(int rid, TypedResultOpCode operand) : base(rid, 200, operand) { }
    }

    // control flow instructions

    class OpLabel : DefaultResultOpCode
    {
        public OpLabel(int rid) : base(rid) { }

        public override void Emit(Stream stream)
        {
            stream.WriteShortLE(248);
            stream.WriteShortLE(2);
            stream.WriteIntLE(ResultId);
        }
    }

    abstract class TerminationOpCode : SpirOpCode
    {
    }

    abstract class BranchOpCode : TerminationOpCode
    {
    }

    class OpBranch : BranchOpCode
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

    class OpBranchConditional : BranchOpCode
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

    // TODO: OpSwitch (251)  [to extend BranchOpCode]

    // TODO: OpKill (252)  [to extend TerminationOpCode]

    class OpReturn : BranchOpCode
    {
        public override void Emit(Stream stream)
        {
            stream.WriteShortLE(253);
            stream.WriteShortLE(1);
        }
    }

    class OpReturnValue : BranchOpCode
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

    // TODO: OpUnreachable (255)  [to extend TerminationOpCode]

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

        public static void WriteByteLE(this Stream stream, byte value)
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

        public static void WriteShortLE(this Stream stream, ushort value)
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

        public static void WriteIntLE(this Stream stream, uint value)
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

        public static void WriteLongLE(this Stream stream, ulong value)
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

    //
    // OpCode factory methods
    //

    public partial class SpirCompiler
    {
        private OpDecorateBuiltIn OpDecorateBuiltIn(ResultOpCode target, BuiltIn builtin)
        {
            return new OpDecorateBuiltIn(target, builtin);
        }

        private OpDecorateConstant OpDecorateConstant(ResultOpCode target)
        {
            return new OpDecorateConstant(target);
        }

        private OpDecorateLinkageAttributes OpDecorateLinkageAttributes(ResultOpCode target, LinkageType linkage, BuiltIn symbol)
        {
            return new OpDecorateLinkageAttributes(target, linkage, symbol);
        }

        private OpExtInstImport OpExtInstImport(string name)
        {
            return new OpExtInstImport(this.rcount++, name);
        }

        private OpMemoryModel OpMemoryModel(AddressingModel addressing, MemoryModel memory)
        {
            return new OpMemoryModel(addressing, memory);
        }

        private OpEntryPoint OpEntryPoint(ExecutionModel execution, OpFunction entryPoint, string name)
        {
            return new OpEntryPoint(execution, entryPoint, name);
        }

        private OpCapability OpCapability(Capability type) {
            return new OpCapability(type);
        }

        private OpTypeVoid OpTypeVoid()
        {
            var op = new OpTypeVoid(this);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeBool OpTypeBool()
        {
            var op = new OpTypeBool(this);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeInt OpTypeInt(int width)
        {
            var op = new OpTypeInt(this, width);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeInt OpTypeInt(int width, int signedness)
        {
            var op = new OpTypeInt(this, width, signedness);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeFloat OpTypeFloat(int width)
        {
            var op = new OpTypeFloat(this, width);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeVector OpTypeVector(int componentCount, ScalarTypeOpCode componentType)
        {
            var op = new OpTypeVector(this, componentCount, componentType);
            RegisterTypeOpCode(op);
            return op;
        }

        // private OpTypeVector OpTypeVector(ScalarTypeOpCode componentType, int componentCount)
        // {
        //     var op = new OpTypeVector(this, componentType, componentCount);
        //     RegisterTypeOpCode(op);
        //     return op;
        // }

        private OpTypeMatrix OpTypeMatrix(OpTypeVector columnType, int columnCount)
        {
            var op = new OpTypeMatrix(this, columnType, columnCount);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeArray OpTypeArray(TypeOpCode elementType, int length)
        {
            var op = new OpTypeArray(this, elementType, length);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeRuntimeArray OpTypeRuntimeArray(TypeOpCode elementType)
        {
            var op = new OpTypeRuntimeArray(this, elementType);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeStruct OpTypeStruct(params TypeOpCode[] members)
        {
            var op = new OpTypeStruct(this, members);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpTypeOpaque OpTypeOpaque(string name)
        {
            var op = new OpTypeOpaque(this, name);
            RegisterTypeOpCode(op);
            return op;
        }

        internal OpTypePointer OpTypePointer(StorageClass storage, TypeOpCode baseType)
        {
            var op = new OpTypePointer(this, storage, baseType);
            RegisterTypeOpCode(op);
            return op;
        }

        // private OpTypePointer OpTypePointer(TypeOpCode baseType, StorageClass storage)
        // {
        //     var op = new OpTypePointer(this, baseType, storage);
        //     RegisterTypeOpCode(op);
        //     return op;
        // }

        // public OpTypePointer Derive(TypeOpCode type)
        // {
        //     return new OpTypePointer(this.rfunc, this.storage, type);
        // }

        private OpTypeFunction OpTypeFunction(TypeOpCode result, params TypeOpCode[] parameters)
        {
            var op = new OpTypeFunction(this, result, parameters);
            RegisterTypeOpCode(op);
            return op;
        }

        private OpConstantTrue OpConstantTrue()
        {
            var result = new OpConstantTrue(this, OpTypeBool());
            RegisterConstOpCode(result);
            return result;
        }

        private OpConstantFalse OpConstantFalse()
        {
            var result = new OpConstantFalse(this, OpTypeBool());
            RegisterConstOpCode(result);
            return result;
        }

        private OpConstant OpConstant(NumericTypeOpCode type, object value)
        {
            var result = new OpConstant(this, type, value);
            RegisterConstOpCode(result);
            return result;
        }

        private OpConstantComposite OpConstantComposite(CompositeTypeOpCode resultType, params OpConstant[] members)
        {
            var result = new OpConstantComposite(this, resultType, members);
            RegisterConstOpCode(result);
            return result;
        }

        private OpFunction OpFunction(OpTypeFunction functionType)
        {
            return new OpFunction(this.rcount++, functionType);
        }

        private OpFunction OpFunction(OpTypeFunction functionType, FunctionControl functionControl)
        {
            return new OpFunction(this.rcount++, functionType, functionControl);
        }

        private OpFunctionParameter OpFunctionParameter(TypeOpCode resultType)
        {
            return new OpFunctionParameter(this.rcount++, resultType);
        }

        private OpFunctionEnd OpFunctionEnd()
        {
            return new OpFunctionEnd();
        }

        private OpFunctionCall OpFunctionCall(OpFunction function, params ResultOpCode[] args)
        {
            return new OpFunctionCall(this.rcount++, function, args);
        }

        private OpVariable OpVariable(OpTypePointer resultType/*, StorageClass storage*/)
        {
            return new OpVariable(this.rcount++, resultType);
        }

        private OpVariable OpVariable(OpTypePointer resultType/*, StorageClass storage*/, TypedResultOpCode initializer)
        {
            return new OpVariable(this.rcount++, resultType, initializer);
        }

        private OpLoad OpLoad(TypedResultOpCode pointer)
        {
            return new OpLoad(this.rcount++, pointer);
        }

        private OpLoad OpLoad(TypedResultOpCode pointer, MemoryAccess memoryAccess, int alignment)
        {
            return new OpLoad(this.rcount++, pointer, memoryAccess, alignment);
        }

        private OpStore OpStore(ResultOpCode pointerType, ResultOpCode objectType)
        {
            return new OpStore(pointerType, objectType);
        }

        private OpStore OpStore(ResultOpCode pointerType, ResultOpCode objectType, MemoryAccess memoryAccess, int alignment)
        {
            return new OpStore(pointerType, objectType, memoryAccess, alignment);
        }

        private OpAccessChain OpAccessChain(TypedResultOpCode basePointer, params ResultOpCode[] index)
        {
            return new OpAccessChain(this, this.rcount++, basePointer, index);
        }

        private OpInBoundsAccessChain OpInBoundsAccessChain(TypedResultOpCode basePointer, params ResultOpCode[] index)
        {
            return new OpInBoundsAccessChain(this, this.rcount++, basePointer, index);
        }

        private OpPtrAccessChain OpPtrAccessChain(TypedResultOpCode basePointer, TypedResultOpCode element, params ResultOpCode[] index)
        {
            return new OpPtrAccessChain(this, this.rcount++, basePointer, element, index);
        }

        private OpInBoundsPtrAccessChain OpInBoundsPtrAccessChain(TypedResultOpCode basePointer, TypedResultOpCode element, params ResultOpCode[] index)
        {
            return new OpInBoundsPtrAccessChain(this, this.rcount++, basePointer, element, index);
        }

        private OpVectorExtractDynamic OpVectorExtractDynamic(TypedResultOpCode vector, ResultOpCode index)
        {
            return new OpVectorExtractDynamic(this.rcount++, vector, index);
        }

        private OpCompositeExtract OpCompositeExtract(CompositeTypeOpCode composite, params int[] index)
        {
            return new OpCompositeExtract(this.rcount++, composite, index);
        }

        private OpConvertFToU OpConvertFToU(TypeOpCode resultType, TypedResultOpCode value)
        {
            return new OpConvertFToU(this.rcount++, resultType, value);
        }

        private OpConvertFToS OpConvertFToS(TypeOpCode resultType, TypedResultOpCode value)
        {
            return new OpConvertFToS(this.rcount++, resultType, value);
        }

        private OpConvertSToF OpConvertSToF(TypeOpCode resultType, TypedResultOpCode value)
        {
            return new OpConvertSToF(this.rcount++, resultType, value);
        }

        private OpConvertUToF OpConvertUToF(TypeOpCode resultType, TypedResultOpCode value)
        {
            return new OpConvertUToF(this.rcount++, resultType, value);
        }

        private OpUConvert OpUConvert(TypeOpCode resultType, TypedResultOpCode value)
        {
            return new OpUConvert(this.rcount++, resultType, value);
        }

        private OpSConvert OpSConvert(TypeOpCode resultType, TypedResultOpCode value)
        {
            return new OpSConvert(this.rcount++, resultType, value);
        }

        private OpFConvert OpFConvert(TypeOpCode resultType, TypedResultOpCode value)
        {
            return new OpFConvert(this.rcount++, resultType, value);
        }

        private OpSNegate OpSNegate(TypedResultOpCode operand)
        {
            return new OpSNegate(this.rcount++, operand);
        }

        private OpFNegate OpFNegate(TypedResultOpCode operand)
        {
            return new OpFNegate(this.rcount++, operand);
        }

        private OpIAdd OpIAdd(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpIAdd(this.rcount++, op1, op2);
        }

        private OpFAdd OpFAdd(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFAdd(this.rcount++, op1, op2);
        }

        private OpISub OpISub(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpISub(this.rcount++, op1, op2);
        }

        private OpFSub OpFSub(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFSub(this.rcount++, op1, op2);
        }

        private OpIMul OpIMul(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpIMul(this.rcount++, op1, op2);
        }

        private OpFMul OpFMul(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFMul(this.rcount++, op1, op2);
        }

        private OpUDiv OpUDiv(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpUDiv(this.rcount++, op1, op2);
        }

        private OpSDiv OpSDiv(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSDiv(this.rcount++, op1, op2);
        }

        private OpFDiv OpFDiv(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFDiv(this.rcount++, op1, op2);
        }

        private OpUMod OpUMod(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpUMod(this.rcount++, op1, op2);
        }

        private OpSRem OpSRem(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSRem(this.rcount++, op1, op2);
        }

        private OpSMod OpSMod(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSMod(this.rcount++, op1, op2);
        }

        private OpFRem OpFRem(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFRem(this.rcount++, op1, op2);
        }

        private OpFMod OpFMod(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFMod(this.rcount++, op1, op2);
        }

        private OpIsNan OpIsNan(TypeOpCode resultType, TypedResultOpCode op)
        {
            return new OpIsNan(this.rcount++, resultType, op);
        }

        private OpIsInf OpIsInf(TypeOpCode resultType, TypedResultOpCode op)
        {
            return new OpIsInf(this.rcount++, resultType, op);
        }

        private OpIsFinite OpIsFinite(TypeOpCode resultType, TypedResultOpCode op)
        {
            return new OpIsFinite(this.rcount++, resultType, op);
        }

        private OpIsNormal OpIsNormal(TypeOpCode resultType, TypedResultOpCode op)
        {
            return new OpIsNormal(this.rcount++, resultType, op);
        }

        private OpLessOrGreater OpLessOrGreater(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpLessOrGreater(this.rcount++, resultType, op1, op2);
        }

        private OpLogicalEqual OpLogicalEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpLogicalEqual(this.rcount++, resultType, op1, op2);
        }

        private OpLogicalNotEqual OpLogicalNotEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpLogicalNotEqual(this.rcount++, resultType, op1, op2);
        }

        private OpLogicalOr OpLogicalOr(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpLogicalOr(this.rcount++, resultType, op1, op2);
        }

        private OpLogicalAnd OpLogicalAnd(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpLogicalAnd(this.rcount++, resultType, op1, op2);
        }

        private OpLogicalNot OpLogicalNot(TypeOpCode resultType, TypedResultOpCode op)
        {
            return new OpLogicalNot(this.rcount++, resultType, op);
        }

        private OpSelect OpSelect(TypedResultOpCode cond, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSelect(this.rcount++, cond, op1, op2);
        }

        private OpIEqual OpIEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpIEqual(this.rcount++, resultType, op1, op2);
        }

        private OpINotEqual OpINotEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpINotEqual(this.rcount++, resultType, op1, op2);
        }

        private OpUGreaterThan OpUGreaterThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpUGreaterThan(this.rcount++, resultType, op1, op2);
        }

        private OpSGreaterThan OpSGreaterThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSGreaterThan(this.rcount++, resultType, op1, op2);
        }

        private OpUGreaterThanEqual OpUGreaterThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpUGreaterThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpSGreaterThanEqual OpSGreaterThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSGreaterThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpULessThan OpULessThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpULessThan(this.rcount++, resultType, op1, op2);
        }

        private OpSLessThan OpSLessThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSLessThan(this.rcount++, resultType, op1, op2);
        }

        private OpULessThanEqual OpULessThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpULessThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpSLessThanEqual OpSLessThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpSLessThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFOrdEqual OpFOrdEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFOrdEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFUnordEqual OpFUnordEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFUnordEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFOrdNotEqual OpFOrdNotEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFOrdNotEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFUnordNotEqual OpFUnordNotEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFUnordNotEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFOrdLessThan OpFOrdLessThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFOrdLessThan(this.rcount++, resultType, op1, op2);
        }

        private OpFUnordLessThan OpFUnordLessThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFUnordLessThan(this.rcount++, resultType, op1, op2);
        }

        private OpFOrdGreaterThan OpFOrdGreaterThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFOrdGreaterThan(this.rcount++, resultType, op1, op2);
        }

        private OpFUnordGreaterThan OpFUnordGreaterThan(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFUnordGreaterThan(this.rcount++, resultType, op1, op2);
        }

        private OpFOrdLessThanEqual OpFOrdLessThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFOrdLessThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFUnordLessThanEqual OpFUnordLessThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFUnordLessThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFOrdGreaterThanEqual OpFOrdGreaterThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFOrdGreaterThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpFUnordGreaterThanEqual OpFUnordGreaterThanEqual(TypeOpCode resultType, TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpFUnordGreaterThanEqual(this.rcount++, resultType, op1, op2);
        }

        private OpShiftRightLogical OpShiftRightLogical(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpShiftRightLogical(this.rcount++, op1, op2);
        }

        private OpShiftRightArithmetic OpShiftRightArithmetic(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpShiftRightArithmetic(this.rcount++, op1, op2);
        }

        private OpShiftLeftLogical OpShiftLeftLogical(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpShiftLeftLogical(this.rcount++, op1, op2);
        }

        private OpBitwiseOr OpBitwiseOr(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpBitwiseOr(this.rcount++, op1, op2);
        }

        private OpBitwiseXor OpBitwiseXor(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpBitwiseXor(this.rcount++, op1, op2);
        }

        private OpBitwiseAnd OpBitwiseAnd(TypedResultOpCode op1, TypedResultOpCode op2)
        {
            return new OpBitwiseAnd(this.rcount++, op1, op2);
        }

        private OpNot OpNot(TypedResultOpCode operand)
        {
            return new OpNot(this.rcount++, operand);
        }

        private OpLabel OpLabel()
        {
            return new OpLabel(this.rcount++);
        }

        private OpBranch OpBranch(OpLabel label)
        {
            return new OpBranch(label);
        }

        private OpBranchConditional OpBranchConditional(TypedResultOpCode condition, OpLabel trueLabel, OpLabel falseLabel)
        {
            return new OpBranchConditional(condition, trueLabel, falseLabel);
        }

        private OpReturn OpReturn()
        {
            return new OpReturn();
        }

        private OpReturnValue OpReturnValue(TypedResultOpCode value)
        {
            return new OpReturnValue(value);
        }
    }
}
