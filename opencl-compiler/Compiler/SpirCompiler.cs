using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace OpenCl.Compiler
{
    public partial class SpirCompiler
    {
        // compiles into SPIR-V Format
        // see: https://www.khronos.org/registry/spir-v/specs/1.1/SPIRV.html

        private static readonly Dictionary<string,Func<Func<TypeOpCode,int>,TypeOpCode>> PrimitiveTypes = new Dictionary<string,Func<Func<TypeOpCode,int>,TypeOpCode>>()
        {
            { "System.Void",     f => new OpTypeVoid(f) },

            { "System.SByte",    f => new OpTypeInt(f,  8/*, signed*/) },
            { "System.Int8",     f => new OpTypeInt(f,  8/*, signed*/) },
            { "System.Byte",     f => new OpTypeInt(f,  8/*, unsigned*/) },
            { "System.UInt8",    f => new OpTypeInt(f,  8/*, unsigned*/) },
            { "System.Int16",    f => new OpTypeInt(f, 16/*, signed*/) },
            { "System.UInt16",   f => new OpTypeInt(f, 16/*, unsigned*/) },
            { "System.Int32",    f => new OpTypeInt(f, 32/*, signed*/) },
            { "System.UInt32",   f => new OpTypeInt(f, 32/*, unsigned*/) },
            { "System.Int64",    f => new OpTypeInt(f, 64/*, signed*/) },
            { "System.UInt64",   f => new OpTypeInt(f, 64/*, unsigned*/) },
            { "System.IntPtr",   f => new OpTypeInt(f, 8*Marshal.SizeOf<IntPtr>()/*, signed*/) },
            { "System.UIntPtr",  f => new OpTypeInt(f, 8*Marshal.SizeOf<UIntPtr>()/*, unsigned*/) },
            { "System.Single",   f => new OpTypeFloat(f, 32) },
            { "System.Double",   f => new OpTypeFloat(f, 64) },

            { "OpenCl.sbyte2",   f => new OpTypeVector(f,  2, new OpTypeInt(f,  8/*, signed*/)) },
            { "OpenCl.sbyte3",   f => new OpTypeVector(f,  3, new OpTypeInt(f,  8/*, signed*/)) },
            { "OpenCl.sbyte4",   f => new OpTypeVector(f,  4, new OpTypeInt(f,  8/*, signed*/)) },
            { "OpenCl.sbyte8",   f => new OpTypeVector(f,  8, new OpTypeInt(f,  8/*, signed*/)) },
            { "OpenCl.sbyte16",  f => new OpTypeVector(f, 16, new OpTypeInt(f,  8/*, signed*/)) },
            { "OpenCl.byte2",    f => new OpTypeVector(f,  2, new OpTypeInt(f,  8/*, unsigned*/)) },
            { "OpenCl.byte3",    f => new OpTypeVector(f,  3, new OpTypeInt(f,  8/*, unsigned*/)) },
            { "OpenCl.byte4",    f => new OpTypeVector(f,  4, new OpTypeInt(f,  8/*, unsigned*/)) },
            { "OpenCl.byte8",    f => new OpTypeVector(f,  8, new OpTypeInt(f,  8/*, unsigned*/)) },
            { "OpenCl.byte16",   f => new OpTypeVector(f, 16, new OpTypeInt(f,  8/*, unsigned*/)) },
            { "OpenCl.short2",   f => new OpTypeVector(f,  2, new OpTypeInt(f, 16/*, signed*/)) },
            { "OpenCl.short3",   f => new OpTypeVector(f,  3, new OpTypeInt(f, 16/*, signed*/)) },
            { "OpenCl.short4",   f => new OpTypeVector(f,  4, new OpTypeInt(f, 16/*, signed*/)) },
            { "OpenCl.short8",   f => new OpTypeVector(f,  8, new OpTypeInt(f, 16/*, signed*/)) },
            { "OpenCl.short16",  f => new OpTypeVector(f, 16, new OpTypeInt(f, 16/*, signed*/)) },
            { "OpenCl.ushort2",  f => new OpTypeVector(f,  2, new OpTypeInt(f, 16/*, unsigned*/)) },
            { "OpenCl.ushort3",  f => new OpTypeVector(f,  3, new OpTypeInt(f, 16/*, unsigned*/)) },
            { "OpenCl.ushort4",  f => new OpTypeVector(f,  4, new OpTypeInt(f, 16/*, unsigned*/)) },
            { "OpenCl.ushort8",  f => new OpTypeVector(f,  8, new OpTypeInt(f, 16/*, unsigned*/)) },
            { "OpenCl.ushort16", f => new OpTypeVector(f, 16, new OpTypeInt(f, 16/*, unsigned*/)) },
            { "OpenCl.int2",     f => new OpTypeVector(f,  2, new OpTypeInt(f, 32/*, signed*/)) },
            { "OpenCl.int3",     f => new OpTypeVector(f,  3, new OpTypeInt(f, 32/*, signed*/)) },
            { "OpenCl.int4",     f => new OpTypeVector(f,  4, new OpTypeInt(f, 32/*, signed*/)) },
            { "OpenCl.int8",     f => new OpTypeVector(f,  8, new OpTypeInt(f, 32/*, signed*/)) },
            { "OpenCl.int16",    f => new OpTypeVector(f, 16, new OpTypeInt(f, 32/*, signed*/)) },
            { "OpenCl.uint2",    f => new OpTypeVector(f,  2, new OpTypeInt(f, 32/*, unsigned*/)) },
            { "OpenCl.uint3",    f => new OpTypeVector(f,  3, new OpTypeInt(f, 32/*, unsigned*/)) },
            { "OpenCl.uint4",    f => new OpTypeVector(f,  4, new OpTypeInt(f, 32/*, unsigned*/)) },
            { "OpenCl.uint8",    f => new OpTypeVector(f,  8, new OpTypeInt(f, 32/*, unsigned*/)) },
            { "OpenCl.uint16",   f => new OpTypeVector(f, 16, new OpTypeInt(f, 32/*, unsigned*/)) },
            { "OpenCl.long2",    f => new OpTypeVector(f,  2, new OpTypeInt(f, 64/*, signed*/)) },
            { "OpenCl.long3",    f => new OpTypeVector(f,  3, new OpTypeInt(f, 64/*, signed*/)) },
            { "OpenCl.long4",    f => new OpTypeVector(f,  4, new OpTypeInt(f, 64/*, signed*/)) },
            { "OpenCl.long8",    f => new OpTypeVector(f,  8, new OpTypeInt(f, 64/*, signed*/)) },
            { "OpenCl.long16",   f => new OpTypeVector(f, 16, new OpTypeInt(f, 64/*, signed*/)) },
            { "OpenCl.ulong2",   f => new OpTypeVector(f,  2, new OpTypeInt(f, 64/*, unsigned*/)) },
            { "OpenCl.ulong3",   f => new OpTypeVector(f,  3, new OpTypeInt(f, 64/*, unsigned*/)) },
            { "OpenCl.ulong4",   f => new OpTypeVector(f,  4, new OpTypeInt(f, 64/*, unsigned*/)) },
            { "OpenCl.ulong8",   f => new OpTypeVector(f,  8, new OpTypeInt(f, 64/*, unsigned*/)) },
            { "OpenCl.ulong16",  f => new OpTypeVector(f, 16, new OpTypeInt(f, 64/*, unsigned*/)) },
            { "OpenCl.float2",   f => new OpTypeVector(f,  2, new OpTypeFloat(f, 32)) },
            { "OpenCl.float3",   f => new OpTypeVector(f,  3, new OpTypeFloat(f, 32)) },
            { "OpenCl.float4",   f => new OpTypeVector(f,  4, new OpTypeFloat(f, 32)) },
            { "OpenCl.float8",   f => new OpTypeVector(f,  8, new OpTypeFloat(f, 32)) },
            { "OpenCl.float16",  f => new OpTypeVector(f, 16, new OpTypeFloat(f, 32)) },
            { "OpenCl.double2",  f => new OpTypeVector(f,  2, new OpTypeFloat(f, 64)) },
            { "OpenCl.double3",  f => new OpTypeVector(f,  3, new OpTypeFloat(f, 64)) },
            { "OpenCl.double4",  f => new OpTypeVector(f,  4, new OpTypeFloat(f, 64)) },
            { "OpenCl.double8",  f => new OpTypeVector(f,  8, new OpTypeFloat(f, 64)) },
            { "OpenCl.double16", f => new OpTypeVector(f, 16, new OpTypeFloat(f, 64)) },
        };

        // IL source data

        private readonly Queue<MethodDefinition> queue;

        // SPIR-V target data

        private int rcount;

        private List<OpEntryPoint> entryPoints;
        private List<OpDecorate> decorations;
        private Dictionary<TypeOpCode,int> types;
        private List<TypeOpCode> types_list;
        private Dictionary<string,TypedResultOpCode> imports;
        private Dictionary<OpConstant,int> constants;
        private List<List<SpirOpCode>> functions;

        // constructor

        private SpirCompiler(params MethodDefinition[] methods)
        {
            this.queue = new Queue<MethodDefinition>(methods);
            this.rcount = 1;
            this.entryPoints = new List<OpEntryPoint>();
            this.decorations = new List<OpDecorate>();
            this.types = new Dictionary<TypeOpCode,int>();
            this.types_list = new List<TypeOpCode>();
            this.imports = new Dictionary<String,TypedResultOpCode>();
            this.constants = new Dictionary<OpConstant,int>();
            this.functions = new List<List<SpirOpCode>>();
        }

        // type helpers

        private int SpirTypeIdCallback(TypeOpCode type)
        {
            if (!this.types.TryGetValue(type, out int id)) {
                id = this.rcount++;
                this.types.Add(type, id);
                this.types_list.Add(type);
            }
            return id;
        }

        private TypeOpCode GetTypeOpCode(Type type)
        {
            return GetTypeOpCode(type, (StorageClass)0);
        }

        private TypeOpCode GetTypeOpCode(Type type, StorageClass storage)
        {
            if (PrimitiveTypes.TryGetValue(type.FullName, out var/*Func<Func<TypeOpCode,int>,TypeOpCode>*/ factory)) {
                return factory(SpirTypeIdCallback);
            }
            else if (type.IsArray || type.IsPointer) {
                return new OpTypePointer(SpirTypeIdCallback, storage, GetTypeOpCode(type.GetElementType(), storage));
            }
            else if (type.IsValueType) {
                throw new CompilerException($"Struct types are not yet supported: {type.FullName}.");
            }
            else {
                throw new CompilerException($"Unsupported type: {type.FullName}.");
            }
        }

        private TypeOpCode GetTypeOpCode<T>()
        {
            return GetTypeOpCode(typeof(T));
        }

        private TypeOpCode GetTypeOpCode<T>(StorageClass storage)
        {
            return GetTypeOpCode(typeof(T), storage);
        }

        private TypeOpCode GetTypeOpCode(TypeReference tr)
        {
            return GetTypeOpCode(tr, StorageClass.Function);
        }

        private TypeOpCode GetTypeOpCode(TypeReference tr, StorageClass storage)
        {
            if (PrimitiveTypes.TryGetValue(tr.FullName, out var factory)) {
                return factory(SpirTypeIdCallback);
            }
            if (tr.IsArray || tr.IsPointer) {
                return new OpTypePointer(SpirTypeIdCallback, storage, GetTypeOpCode(tr.GetElementType()));
            }
            else if (tr.IsValueType) {
                throw new CompilerException($"Struct types are not yet supported: {tr.FullName}.");
            }
            else {
                throw new CompilerException($"Unsupported type: {tr.FullName}.");
            }
        }

        private TypeOpCode GetTypeOpCode(ParameterReference pr)
        {
            TypeReference tr = pr.ParameterType;
            if (tr.IsArray || tr.IsPointer) {
                var global = pr.Resolve().CustomAttributes.Any(ai => ai.AttributeType.FullName == "OpenCl.GlobalAttribute");
                var storage = global ? StorageClass.CrossWorkgroup : StorageClass.UniformConstant;
                return new OpTypePointer(SpirTypeIdCallback, storage, GetTypeOpCode(tr.GetElementType()));
            }
            else {
                return GetTypeOpCode(pr.ParameterType);
            }
        }

        private TypeOpCode GetTypeOpCode(VariableReference vr)
        {
            return GetTypeOpCode(vr.VariableType);
        }

        private OpTypeFunction GetTypeOpCode(MethodReference mr)
        {
            var r = GetTypeOpCode(mr.ReturnType);
            var p = mr.Parameters
                    .Select(pi => GetTypeOpCode(pi))
                    .ToArray();
            return new OpTypeFunction(SpirTypeIdCallback, r, p);
        }

        // private static readonly Dictionary<TypeOpCode,Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>> _convert_ops = new Dictionary<TypeOpCode,Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>>()
        // {
        //     { new OpTypeInt(t => -1, 8), new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>() {
        //         { typeof(sbyte),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) },
        //         { typeof(short),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) },
        //         { typeof(int),    (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) },
        //         { typeof(long),   (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) },
        //         { typeof(IntPtr), (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) },
        //         { typeof(float),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) },
        //         { typeof(double), (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) }
        //     }},
        //     { new OpTypeInt(t => -1, 16), new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>() {
        //         { typeof(sbyte),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) },
        //         { typeof(short),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) },
        //         { typeof(int),    (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) },
        //         { typeof(long),   (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) },
        //         { typeof(IntPtr), (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) },
        //         { typeof(float),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) },
        //         { typeof(double), (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) }
        //     }},
        //     { new OpTypeInt(t => -1, 32), new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>() {
        //         { typeof(sbyte),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) },
        //         { typeof(short),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) },
        //         { typeof(int),    (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) },
        //         { typeof(long),   (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) },
        //         { typeof(IntPtr), (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) },
        //         { typeof(float),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) },
        //         { typeof(double), (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) }
        //     }},
        //     { new OpTypeInt(t => -1, 64), new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>() {
        //         { typeof(sbyte),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) },
        //         { typeof(short),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) },
        //         { typeof(int),    (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) },
        //         { typeof(long),   (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) },
        //         { typeof(IntPtr), (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) },
        //         { typeof(float),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) },
        //         { typeof(double), (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) }
        //     }},
        //     { new OpTypeFloat(t => -1, 32), new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>() {
        //         { typeof(sbyte),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) },
        //         { typeof(short),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) },
        //         { typeof(int),    (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) },
        //         { typeof(long),   (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) },
        //         { typeof(IntPtr), (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) },
        //         { typeof(float),  (compiler, value) => new OpFConvert(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) },
        //         { typeof(double), (compiler, value) => new OpFConvert(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) }
        //     }},
        //     { new OpTypeFloat(t => -1, 64), new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>>() {
        //         { typeof(sbyte),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) },
        //         { typeof(short),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) },
        //         { typeof(int),    (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) },
        //         { typeof(long),   (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) },
        //         { typeof(IntPtr), (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) },
        //         { typeof(float),  (compiler, value) => new OpFConvert(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) },
        //         { typeof(double), (compiler, value) => new OpFConvert(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) }
        //     }}
        // };

        // private TypedResultOpCode GetConversionOpCode(TypedResultOpCode src, Type dst)
        // {
        //     Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode>> map = null;
        //     if (!_convert_ops.TryGetValue(src.ResultType, out map)) {
        //         throw new CompilerException(String.Format("Unsupported source type in type conversion: {0} -> {1}.", src.ResultType, dst));
        //     }
        //     Func<SpirCompiler,TypedResultOpCode,TypedResultOpCode> factory = null;
        //     if (!map.TryGetValue(dst, out factory)) {
        //         throw new CompilerException(String.Format("Unsupported target type in type conversion: {0} -> {1}.", src.ResultType, dst));
        //     }
        //     return factory(this, src);
        // }

        private static readonly Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,ConversionOpCode>> _convert_ops = new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,ConversionOpCode>>()
        {
            { typeof(sbyte),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<sbyte>(), value) },
            { typeof(short),  (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<short>(), value) },
            { typeof(int),    (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<int>(), value) },
            { typeof(long),   (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<long>(), value) },
            { typeof(IntPtr), (compiler, value) => new OpSConvert(compiler.rcount++, compiler.GetTypeOpCode<IntPtr>(), value) },
            { typeof(float),  (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<float>(), value) },
            { typeof(double), (compiler, value) => new OpConvertFToS(compiler.rcount++, compiler.GetTypeOpCode<double>(), value) }
        };

        private ConversionOpCode GetConversionOpCode(TypedResultOpCode src, Type dst)
        {
            if (_convert_ops.TryGetValue(dst, out var /*Func<SpirCompiler,TypedResultOpCode,ConversionOpCode>*/ factory)) {
                return factory(this, src);
            }
            throw new CompilerException($"Unsupported type conversion: {src.ResultType} -> {dst}.");
        }

        // constant helper

        private int SpirConstantCallback(OpConstant op)
        {
            if (!this.constants.TryGetValue(op, out int id)) {
                id = this.rcount++;
                this.constants.Add(op, id);
            }
            return id;
        }

        private string GetMethodName(MethodDefinition mdef)
        {
            return mdef.CustomAttributes
                .Where(ai => ai.AttributeType.FullName == "OpenCl.ClNameAttribute")
                .Select((attr, idx) => attr.ConstructorArguments[0].Value as string)
                .DefaultIfEmpty(mdef.Name)
                .First();
        }

        private void Parse(MethodDefinition method)
        {
            var functionType = GetTypeOpCode(method);
            OpFunction function = new OpFunction(this.rcount++, functionType);
            if (method.CustomAttributes.SingleOrDefault(ai => ai.AttributeType.FullName == "OpenCl.KernelAttribute") != null) {
                this.entryPoints.Add(new OpEntryPoint(ExecutionModel.Kernel, function, GetMethodName(method)));
            }
            List<SpirOpCode> funcdef = new List<SpirOpCode>();
            funcdef.Add(function);
            var nparams = method.Parameters.Count;
            var param = new OpFunctionParameter[nparams];
            for (var i=0; i<nparams; i++) {
                var pi = method.Parameters[i];
                var ci = new OpFunctionParameter(this.rcount++, GetTypeOpCode(pi));
                param[i] = ci;
                funcdef.Add(ci);
            }
            funcdef.Add(new OpLabel(this.rcount++));

            var body = method.Body;
            var vars = new TypedResultOpCode[body.Variables.Count];
            // foreach (var v in vars) {
            //     string name = null;
            //     if (!typeMap.TryGetValue(v.VariableType.FullName, out name)) {
            //         throw new ArgumentException(String.Format("Unsupported type: {0}.", v.VariableType.FullName));
            //     }
            //     this.builder.AppendFormat("{0} __V{1};\n", name, v.Index);
            // }
            var code = body.Instructions;

            // gather all branching targets
            var labels = new Dictionary<int,OpLabel>();
            foreach (var instr in code) {
                switch (instr.OpCode.OperandType) {
                    case OperandType.ShortInlineBrTarget:
                    case OperandType.InlineBrTarget: {
                        var target = (instr.Operand as Instruction).Offset;
                        var label = new OpLabel(this.rcount++);
                        labels.Add(target, label);
                        break;
                    }
                    default:
                        break;
                }
            }

            // convert IL op-codes to SPIR-V op-codes
            var stack = new Stack<TypedResultOpCode>();
            foreach (var instr in code) {
                // emit label if current instruction is a branching target
                if (labels.ContainsKey(instr.Offset)) {
                    funcdef.Add(labels[instr.Offset]);
                }
                // main handler for current instruction
                switch (instr.OpCode.Code)
                {
                case Code.Nop:
                    // just for the fun of it...
                    // funcdef.Add(new OpNop());
                    break;
                case Code.Dup: {
                    stack.Push(stack.Peek());
                    break;
                }
                case Code.Ldc_I4_0: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 0));
                    break;
                }
                case Code.Ldc_I4_1: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 1));
                    break;
                }
                case Code.Ldc_I4_2: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 2));
                    break;
                }
                case Code.Ldc_I4_3: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 3));
                    break;
                }
                case Code.Ldc_I4_4: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 4));
                    break;
                }
                case Code.Ldc_I4_5: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 5));
                    break;
                }
                case Code.Ldc_I4_6: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 6));
                    break;
                }
                case Code.Ldc_I4_7: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 7));
                    break;
                }
                case Code.Ldc_I4_8: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), 8));
                    break;
                }
                case Code.Ldc_I4_M1: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), -1));
                    break;
                }
                case Code.Ldc_I4: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), (int)instr.Operand));
                    break;
                }
                case Code.Ldc_I4_S: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<int>(), (sbyte)instr.Operand));
                    break;
                }
                case Code.Ldc_I8: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<long>(), (long)instr.Operand));
                    break;
                }
                case Code.Ldc_R4: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<float>(), (float)instr.Operand));
                    break;
                }
                case Code.Ldc_R8: {
                    stack.Push(new OpConstant(SpirConstantCallback, (NumericTypeOpCode)GetTypeOpCode<double>(), (double)instr.Operand));
                    break;
                }
                case Code.Ldarg_0: {
                    stack.Push(param[0]);
                    break;
                }
                case Code.Ldarg_1: {
                    stack.Push(param[1]);
                    break;
                }
                case Code.Ldarg_2: {
                    stack.Push(param[2]);
                    break;
                }
                case Code.Ldarg_3: {
                    stack.Push(param[3]);
                    break;
                }
                case Code.Ldarg:
                case Code.Ldarg_S: {
                    var arg = instr.Operand as ParameterDefinition;
                    stack.Push(param[arg.Index]);
                    break;
                }
                case Code.Ldloc_0: {
                    stack.Push(vars[0]);
                    break;
                }
                case Code.Ldloc_1: {
                    stack.Push(vars[1]);
                    break;
                }
                case Code.Ldloc_2: {
                    stack.Push(vars[2]);
                    break;
                }
                case Code.Ldloc_3: {
                    stack.Push(vars[3]);
                    break;
                }
                case Code.Ldloc:
                case Code.Ldloc_S: {
                    var loc = instr.Operand as VariableDefinition;
                    stack.Push(vars[loc.Index]);
                    break;
                }
                case Code.Ldelem_Any:
                case Code.Ldelem_I:
                case Code.Ldelem_I1:
                case Code.Ldelem_I2:
                case Code.Ldelem_I4:
                case Code.Ldelem_U1:
                case Code.Ldelem_U2:
                case Code.Ldelem_U4:
                case Code.Ldelem_I8:
                case Code.Ldelem_R4:
                case Code.Ldelem_R8: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    var addr = new OpPtrAccessChain(this.rcount++, arr, idx);
                    var elem = new OpLoad(this.rcount++, addr);
                    funcdef.Add(addr);
                    funcdef.Add(elem);
                    stack.Push(elem);
                    break;
                }
                case Code.Ldind_I:
                case Code.Ldind_I1:
                case Code.Ldind_I2:
                case Code.Ldind_I4:
                case Code.Ldind_I8:
                case Code.Ldind_R4:
                case Code.Ldind_R8:
                case Code.Ldobj: {
                    var addr = stack.Pop();
                    var elem = new OpLoad(this.rcount++, addr);
                    funcdef.Add(elem);
                    stack.Push(elem);
                    break;
                }
                case Code.Ldarga:
                case Code.Ldarga_S: {
                    var arg = instr.Operand as ParameterDefinition;
                    var ptr = new OpVariable(this.rcount++, new OpTypePointer(SpirTypeIdCallback, StorageClass.Function, GetTypeOpCode(arg)));
                    funcdef.Add(ptr);
                    stack.Push(ptr);
                    funcdef.Add(new OpStore(ptr, param[arg.Index]));
                    break;
                }
                case Code.Ldloca:
                case Code.Ldloca_S: {
                    var loc = instr.Operand as VariableDefinition;
                    var ptr = new OpVariable(this.rcount++, new OpTypePointer(SpirTypeIdCallback, StorageClass.Function, GetTypeOpCode(loc)));
                    funcdef.Add(ptr);
                    stack.Push(ptr);
                    funcdef.Add(new OpStore(ptr, vars[loc.Index]));
                    break;
                }
                case Code.Ldelema: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    var addr = new OpPtrAccessChain(this.rcount++, arr, idx);
                    funcdef.Add(addr);
                    stack.Push(addr);
                    break;
                }
                case Code.Localloc: {
                    throw new NotSupportedException();
                }
                case Code.Stloc_0: {
                    vars[0] = stack.Pop();
                    break;
                }
                case Code.Stloc_1: {
                    vars[1] = stack.Pop();
                    break;
                }
                case Code.Stloc_2: {
                    vars[2] = stack.Pop();
                    break;
                }
                case Code.Stloc_3: {
                    vars[3] = stack.Pop();
                    break;
                }
                case Code.Stloc:
                case Code.Stloc_S: {
                    var loc = instr.Operand as VariableDefinition;
                    vars[loc.Index] = stack.Pop();
                    break;
                }
                case Code.Stelem_Any:
                case Code.Stelem_I:
                case Code.Stelem_I1:
                case Code.Stelem_I2:
                case Code.Stelem_I4:
                case Code.Stelem_I8:
                case Code.Stelem_R4:
                case Code.Stelem_R8: {
                    var val = stack.Pop();
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    var ptr = new OpPtrAccessChain(this.rcount++, arr, idx);
                    funcdef.Add(ptr);
                    funcdef.Add(new OpStore(ptr, val));
                    break;
                }
                case Code.Stind_I:
                case Code.Stind_I1:
                case Code.Stind_I2:
                case Code.Stind_I4:
                case Code.Stind_I8:
                case Code.Stind_R4:
                case Code.Stind_R8:
                case Code.Stobj: {
                    var val = stack.Pop();
                    var ptr = stack.Pop();
                    funcdef.Add(new OpStore(ptr, val));
                    break;
                }
                case Code.Conv_I:
                case Code.Conv_Ovf_I:
                case Code.Conv_Ovf_I_Un: {
                    var arg = stack.Pop();
                    var op = GetConversionOpCode(arg, typeof(IntPtr)) as TypedResultOpCode;
                    if ((op.ResultType as OpTypeInt)?.Width == (arg.ResultType as OpTypeInt)?.Width) {
                        op = arg;
                    }
                    else {
                    funcdef.Add(op);
                    }
                    stack.Push(op);
                    break;
                }
                case Code.Conv_I1:
                case Code.Conv_Ovf_I1:
                case Code.Conv_Ovf_I1_Un: {
                    var arg = stack.Pop();
                    var op = GetConversionOpCode(arg, typeof(SByte));
                    funcdef.Add(op);
                    stack.Push(op);
                    break;
                }
                case Code.Conv_I2:
                case Code.Conv_Ovf_I2:
                case Code.Conv_Ovf_I2_Un: {
                    var arg = stack.Pop();
                    var op = GetConversionOpCode(arg, typeof(Int16));
                    funcdef.Add(op);
                    stack.Push(op);
                    break;
                }
                case Code.Conv_I4:
                case Code.Conv_Ovf_I4:
                case Code.Conv_Ovf_I4_Un: {
                    var arg = stack.Pop();
                    var op = GetConversionOpCode(arg, typeof(Int32));
                    funcdef.Add(op);
                    stack.Push(op);
                    break;
                }
                case Code.Conv_I8:
                case Code.Conv_Ovf_I8:
                case Code.Conv_Ovf_I8_Un: {
                    var arg = stack.Pop();
                    var op = GetConversionOpCode(arg, typeof(Int64));
                    funcdef.Add(op);
                    stack.Push(op);
                    break;
                }
                case Code.Conv_U:
                case Code.Conv_Ovf_U:
                case Code.Conv_Ovf_U_Un:
                    throw new NotSupportedException();
                    // stack.Push(new Conv(typeof(UIntPtr), stack.Pop()));
                    // break;
                case Code.Conv_U1:
                case Code.Conv_Ovf_U1:
                case Code.Conv_Ovf_U1_Un:
                    throw new NotSupportedException();
                    // stack.Push(new Conv(typeof(Byte), stack.Pop()));
                    // break;
                case Code.Conv_U2:
                case Code.Conv_Ovf_U2:
                case Code.Conv_Ovf_U2_Un:
                    throw new NotSupportedException();
                    // stack.Push(new Conv(typeof(UInt16), stack.Pop()));
                    // break;
                case Code.Conv_U4:
                case Code.Conv_Ovf_U4:
                case Code.Conv_Ovf_U4_Un:
                    throw new NotSupportedException();
                    // stack.Push(new Conv(typeof(UInt32), stack.Pop()));
                    // break;
                case Code.Conv_U8:
                case Code.Conv_Ovf_U8:
                case Code.Conv_Ovf_U8_Un:
                    throw new NotSupportedException();
                    // stack.Push(new Conv(typeof(UInt64), stack.Pop()));
                    // break;
                case Code.Conv_R4: {
                    var arg = stack.Pop();
                    var op = GetConversionOpCode(arg, typeof(Single));
                    funcdef.Add(op);
                    stack.Push(op);
                    break;
                }
                case Code.Conv_R8: {
                    var arg = stack.Pop();
                    var op = GetConversionOpCode(arg, typeof(Double));
                    funcdef.Add(op);
                    stack.Push(op);
                    break;
                }
                case Code.Add:
                case Code.Add_Ovf:
                case Code.Add_Ovf_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpIAdd(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = new OpFConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpFConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpFAdd(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'add' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Sub:
                case Code.Sub_Ovf:
                case Code.Sub_Ovf_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpISub(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = new OpFConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpFConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpFSub(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'sub' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Mul:
                case Code.Mul_Ovf:
                case Code.Mul_Ovf_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpIMul(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = new OpFConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpFConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpFMul(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'mul' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Div: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpSDiv(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = new OpFConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpFConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpFDiv(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'div' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Div_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpUConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpUConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpUDiv(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    // else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                    //     var tl = l.ResultType as OpTypeFloat;
                    //     var tr = r.ResultType as OpTypeFloat;
                    //     if (tl.Width < tr.Width) {
                    //         l = new OpFConvert(this.rcount++, tr, l);
                    //         funcdef.Add(l);
                    //     }
                    //     else if (tr.Width < tl.Width) {
                    //         r = new OpFConvert(this.rcount++, tl, r);
                    //         funcdef.Add(r);
                    //     }
                    //     var op = new OpFDiv(this.rcount++, l, r);
                    //     funcdef.Add(op);
                    //     stack.Push(op);
                    // }
                    else {
                        throw new CompilerException($"Incompatible types for 'div' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.And: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpBitwiseAnd(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'and' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Or: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpBitwiseOr(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'or' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Xor: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpBitwiseXor(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'xor' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Shl: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpShiftLeftLogical(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'shl' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Shr: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpShiftRightArithmetic(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'shr' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Shr_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    if (l.ResultType is OpTypeInt && r.ResultType is OpTypeInt) {
                        var tl = l.ResultType as OpTypeInt;
                        var tr = r.ResultType as OpTypeInt;
                        if (tl.Width < tr.Width) {
                            l = new OpSConvert(this.rcount++, tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = new OpSConvert(this.rcount++, tl, r);
                            funcdef.Add(r);
                        }
                        var op = new OpShiftRightLogical(this.rcount++, l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else {
                        throw new CompilerException($"Incompatible types for 'shr' operation: {l.ResultType.GetType().Name} and {r.ResultType.GetType().Name}.");
                    }
                    break;
                }
                case Code.Call: {
                    var mref = instr.Operand as MethodReference;
                    var mdef = mref.Resolve();
                    var tdef = mdef.DeclaringType;
                    var name = tdef.FullName + "." + mdef.Name;
                    var nargs = mref.Parameters.Count;
                    if (mdef.HasThis && !mdef.ExplicitThis) {
                        nargs++;
                    }
                    switch (name)
                    {
                    // builtin variables (https://github.com/KhronosGroup/SPIRV-LLVM/blob/khronos/spirv-3.6.1/test/SPIRV/builtin_vars-decorate.ll)
                    case "OpenCl.Cl.GetWorkDim": {
                        // __spirv_BuiltInWorkDim = external addrspace(1) global i32
                        if (!this.imports.TryGetValue(name, out TypedResultOpCode sym)) {
                            // type of import symbol
                            var t = new OpTypePointer(SpirTypeIdCallback, StorageClass.UniformConstant,
                                        new OpTypeInt(SpirTypeIdCallback, 64));
                            // import symbol
                            sym = new OpVariable(this.rcount++, t);
                            this.imports.Add(name, sym);
                            // import decorations
                            this.decorations.Add(new OpDecorateBuiltIn(sym, BuiltIn.WorkDim));
                            this.decorations.Add(new OpDecorateConstant(sym));
                            this.decorations.Add(new OpDecorateLinkageAttributes(sym, LinkageType.Import, BuiltIn.WorkDim));
                        }
                        var ld = new OpLoad(this.rcount++, sym);
                        var op = new OpVectorExtractDynamic(this.rcount++, ld, stack.Pop());
                        funcdef.Add(ld);
                        funcdef.Add(op);
                        stack.Push(op);
                        break;
                    }
                    case "OpenCl.Cl.GetGlobalSize": {
                        // __spirv_BuiltInGlobalSize = external addrspace(1) global <3 x i32>
                        if (!this.imports.TryGetValue(name, out TypedResultOpCode sym)) {
                            // type of import symbol
                            var t = new OpTypePointer(SpirTypeIdCallback, StorageClass.UniformConstant,
                                        new OpTypeVector(SpirTypeIdCallback, 3,
                                            new OpTypeInt(SpirTypeIdCallback, 64)));
                            // import symbol
                            sym = new OpVariable(this.rcount++, t);
                            this.imports.Add(name, sym);
                            // import decorations
                            this.decorations.Add(new OpDecorateBuiltIn(sym, BuiltIn.GlobalSize));
                            this.decorations.Add(new OpDecorateConstant(sym));
                            this.decorations.Add(new OpDecorateLinkageAttributes(sym, LinkageType.Import, BuiltIn.GlobalSize));
                        }
                        var ld = new OpLoad(this.rcount++, sym);
                        var op = new OpVectorExtractDynamic(this.rcount++, ld, stack.Pop());
                        funcdef.Add(ld);
                        funcdef.Add(op);
                        stack.Push(op);
                        break;
                    }
                    case "OpenCl.Cl.GetGlobalId": {
                        // __spirv_BuiltInGlobalInvocationId = external addrspace(1) global <3 x i32>
                        if (!this.imports.TryGetValue(name, out TypedResultOpCode sym)) {
                            // type of import symbol
                            var t = new OpTypePointer(SpirTypeIdCallback, StorageClass.UniformConstant,
                                        new OpTypeVector(SpirTypeIdCallback, 3,
                                            new OpTypeInt(SpirTypeIdCallback, 64)));
                            // import symbol
                            sym = new OpVariable(this.rcount++, t);
                            this.imports.Add(name, sym);
                            // import decorations
                            this.decorations.Add(new OpDecorateBuiltIn(sym, BuiltIn.GlobalInvocationId));
                            this.decorations.Add(new OpDecorateConstant(sym));
                            this.decorations.Add(new OpDecorateLinkageAttributes(sym, LinkageType.Import, BuiltIn.GlobalInvocationId));
                        }
                        var ld = new OpLoad(this.rcount++, sym);
                        var op = new OpVectorExtractDynamic(this.rcount++, ld, stack.Pop());
                        funcdef.Add(ld);
                        funcdef.Add(op);
                        stack.Push(op);
                        break;
                    }
// @__spirv_BuiltInWorkgroupSize = external addrspace(1) global <3 x i32>
// @__spirv_BuiltInEnqueuedWorkgroupSize = external addrspace(1) global <3 x i32>
// @__spirv_BuiltInLocalInvocationId = external addrspace(1) global <3 x i32>
// @__spirv_BuiltInNumWorkgroups = external addrspace(1) global <3 x i32>
// @__spirv_BuiltInWorkgroupId = external addrspace(1) global <3 x i32>
// @__spirv_BuiltInGlobalOffset = external addrspace(1) global <3 x i32>
// @__spirv_BuiltInGlobalLinearId = external addrspace(1) global i32
// @__spirv_BuiltInLocalInvocationIndex = external addrspace(1) global i32
// @__spirv_BuiltInSubgroupSize = external addrspace(1) global i32
// @__spirv_BuiltInSubgroupMaxSize = external addrspace(1) global i32
// @__spirv_BuiltInNumSubgroups = external addrspace(1) global i32
// @__spirv_BuiltInNumEnqueuedSubgroups = external addrspace(1) global i32
// @__spirv_BuiltInSubgroupId = external addrspace(1) global i32
// @__spirv_BuiltInSubgroupLocalInvocationId = external addrspace(1) global i32
                    case string _ when name.EndsWith("op_Addition"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode r;
                        if (a.ResultType is OpTypeInt || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeInt) {
                            r = new OpIAdd(this.rcount++, a, b);
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = new OpFAdd(this.rcount++, a, b);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_Addition' call.");
                        }
                        funcdef.Add(r);
                        stack.Push(r);
                        break;
                    }
                    case string _ when name.EndsWith("op_Subtraction"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode r;
                        if (a.ResultType is OpTypeInt || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeInt) {
                            r = new OpISub(this.rcount++, a, b);
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = new OpFSub(this.rcount++, a, b);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_Subtraction' call.");
                        }
                        funcdef.Add(r);
                        stack.Push(r);
                        break;
                    }
                    case string _ when name.EndsWith("op_Multiply"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode r;
                        if (a.ResultType is OpTypeInt || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeInt) {
                            r = new OpIMul(this.rcount++, a, b);
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = new OpFMul(this.rcount++, a, b);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_Multiply' call.");
                        }
                        funcdef.Add(r);
                        stack.Push(r);
                        break;
                    }
                    case string _ when name.EndsWith("op_Division"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode r;
                        OpTypeInt t;
                        if ((t = a.ResultType as OpTypeInt ?? (a.ResultType as OpTypeVector)?.ComponentType as OpTypeInt) != null) {
                            if (t.Signedness == 0) {
                                r = new OpUDiv(this.rcount++, a, b);
                            }
                            else {
                                r = new OpSDiv(this.rcount++, a, b);
                            }
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = new OpFDiv(this.rcount++, a, b);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_Division' call.");
                        }
                        funcdef.Add(r);
                        stack.Push(r);
                        break;
                    }
                    default:
                        throw new CompilerException($"Unsupported call to '{name}'.");
                    }
                //     var args = new AstNode[nargs];
                //     for (var i=nargs-1; i>=0; i--) {
                //         args[i] = stack.Pop();
                //     }
                //     if (mdef.IsConstructor) {
                //         var tdef = mdef.DeclaringType;
                //         if (tdef.IsValueType) {
                //             // Note: this assumes that the struct constructor
                //             // is compatible with C-style compound literals.
                //             this.builder.Append("*(");
                //             args[0].Accept(this.printer);
                //             this.builder.AppendFormat(") = ({0}){{ ", typeMap[tdef.FullName]);
                //             for (int i=1; i<nargs; i++) {
                //                 if (i > 1) {
                //                     this.builder.Append(", ");
                //                 }
                //                 args[i].Accept(this.printer);
                //             }
                //             this.builder.AppendLine(" };");
                //         }
                //     }
                //     else {
                //         var rtype = CliType.FromType(mdef.ReturnType);
                //         switch (name)
                //         {
                //         case "op_Addition":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Add, args[0], args[1]));
                //             break;
                //         case "op_Subtraction":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Sub, args[0], args[1]));
                //             break;
                //         case "op_Multiply":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Mul, args[0], args[1]));
                //             break;
                //         case "op_Division":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Div, args[0], args[1]));
                //             break;
                //         case "op_Equality":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Eq, args[0], args[1]));
                //             break;
                //         case "op_Inequality":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Neq, args[0], args[1]));
                //             break;
                //         case "op_LessThan":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Lt, args[0], args[1]));
                //             break;
                //         case "op_LessThanOrEqual":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Le, args[0], args[1]));
                //             break;
                //         case "op_GreaterThan":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Gt, args[0], args[1]));
                //             break;
                //         case "op_GreaterThanOrEqual":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Ge, args[0], args[1]));
                //             break;
                //         case "op_BitwiseAnd":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.And, args[0], args[1]));
                //             break;
                //         case "op_BitwiseOr":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Or, args[0], args[1]));
                //             break;
                //         case "op_ExclusiveOr":
                //             stack.Push(new BinaryOp(rtype, BinaryOpCode.Xor, args[0], args[1]));
                //             break;
                //         case "op_OnesComplement":
                //             stack.Push(new UnaryOp(UnaryOpCode.Not, args[0]));
                //             break;
                //         default:
                //             if (mdef.HasThis && name.StartsWith("get_")) {
                //                 // Note: this assumes that the property getter is a valid
                //                 // C-style field reference.
                //                 stack.Push(new FieldRef(rtype, name.Substring(4), args[0]));
                //             }
                //             else if (mdef.HasThis && name.StartsWith("set_")) {
                //                 // Note: this assumes that the property setter is a valid
                //                 // C-style field reference.
                //                 this.builder.Append("(*");
                //                 args[0].Accept(this.printer);
                //                 this.builder.AppendFormat(").{0} = ", name.Substring(4));
                //                 args[1].Accept(this.printer);
                //                 this.builder.AppendLine(";");
                //             }
                //             else {
                //                 stack.Push(new Call(rtype, name, args));
                //             }
                //             break;
                //         }
                //     }
                    break;
                }
                case Code.Br:
                case Code.Br_S: {
                    var target = (instr.Operand as Instruction).Offset;
                    funcdef.Add(new OpBranch(labels[target]));
                    break;
                }
                case Code.Brfalse:
                case Code.Brfalse_S: {
                    var arg = stack.Pop();
                    if (!(arg.ResultType is OpTypeInt)) {
                        throw new CompilerException($"Incompatible operand for 'brtrue' instruction: expected OpTypeInt, found {arg.ResultType.GetType().Name}.");
                    }
                    var zero = new OpConstant(SpirConstantCallback, arg.ResultType as NumericTypeOpCode, 0);
                    var cond = new OpIEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), arg, zero);
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Brtrue:
                case Code.Brtrue_S: {
                    var arg = stack.Pop();
                    if (!(arg.ResultType is OpTypeInt)) {
                        throw new CompilerException($"Incompatible operand for 'brtrue' instruction: expected OpTypeInt, found {arg.ResultType.GetType().Name}.");
                    }
                    var zero = new OpConstant(SpirConstantCallback, arg.ResultType as NumericTypeOpCode, 0);
                    var cond = new OpINotEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), arg, zero);
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Beq:
                case Code.Beq_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpIEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFOrdEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'beq' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Bne_Un:
                case Code.Bne_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpINotEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordNotEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'beq' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Blt:
                case Code.Blt_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpSLessThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordLessThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'blt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Blt_Un:
                case Code.Blt_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpULessThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordLessThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'blt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Ble:
                case Code.Ble_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpSLessThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordLessThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'ble' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Ble_Un:
                case Code.Ble_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpULessThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordLessThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'ble' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Bgt:
                case Code.Bgt_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpSGreaterThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordGreaterThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bgt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Bgt_Un:
                case Code.Bgt_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpUGreaterThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordGreaterThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bgt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Bge:
                case Code.Bge_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpSGreaterThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordGreaterThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bge' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Bge_Un:
                case Code.Bge_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = new OpUGreaterThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = new OpFUnordGreaterThanEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bge' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = new OpLabel(this.rcount++);
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf});
                    break;
                }
                case Code.Ceq: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = new OpIEqual(this.rcount++, new OpTypeBool(SpirTypeIdCallback), a, b);
                    var sel = new OpSelect(this.rcount++, cmp, new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 1), new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Cgt: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = new OpSGreaterThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), a, b);
                    var sel = new OpSelect(this.rcount++, cmp, new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 1), new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Cgt_Un: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = new OpUGreaterThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), a, b);
                    var sel = new OpSelect(this.rcount++, cmp, new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 1), new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Clt: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = new OpSLessThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), a, b);
                    var sel = new OpSelect(this.rcount++, cmp, new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 1), new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Clt_Un: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = new OpULessThan(this.rcount++, new OpTypeBool(SpirTypeIdCallback), a, b);
                    var sel = new OpSelect(this.rcount++, cmp, new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 1), new OpConstant(SpirConstantCallback, new OpTypeInt(SpirTypeIdCallback, 32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Ret:
                    if (method.ReturnType.FullName != "System.Void") {
                        funcdef.Add(new OpReturnValue(stack.Pop()));
                    }
                    else {
                        funcdef.Add(new OpReturn());
                    }
                    break;
                default:
                    throw new CompilerException($"Unsupported opcode: {instr.OpCode}.");
                }
            }
            funcdef.Add(new OpFunctionEnd());
            this.functions.Add(funcdef);
        }

        private void Emit(Stream output)
        {
            var bound = this.rcount+1;
            // SPIR-V magic number
            output.WriteByte(0x03);
            output.WriteByte(0x02);
            output.WriteByte(0x23);
            output.WriteByte(0x07);
            // SPIR-V version number
            output.WriteByte(0x00);
            output.WriteByte(0x00);
            output.WriteByte(0x01);
            output.WriteByte(0x00);
            // SPIR-V generator number
            output.WriteByte(0x00);
            output.WriteByte(0x00);
            output.WriteByte(0x00);
            output.WriteByte(0x00);
            // SPIR-V max ID
            output.WriteIntLE(bound);
            // reserved (must be zero)
            output.WriteIntLE(0x00);
            // capabilities
            new OpCapability(Capability.Addresses).Emit(output);
            new OpCapability(Capability.Linkage).Emit(output);
            new OpCapability(Capability.Kernel).Emit(output);
            new OpCapability(Capability.Int64).Emit(output);
            // import OpenCL extended instruction set
            // see: https://www.khronos.org/registry/spir-v/specs/1.0/OpenCL.ExtendedInstructionSet.100.html
            new OpExtInstImport(this.rcount++, "OpenCL.std").Emit(output);
            // memory model
            new OpMemoryModel(AddressingModel.Physical64, MemoryModel.OpenCL).Emit(output);
            // entry points
            foreach (var op in this.entryPoints) {
                op.Emit(output);
            }
            // decorations
            foreach (var op in this.decorations) {
                op.Emit(output);
            }
            // types
            foreach (var op in this.types_list) {
                op.Emit(output);
            }
            // imports
            foreach (var op in this.imports) {
                op.Value.Emit(output);
            }
            // exports
            // ...
            // constants
            foreach (var op in this.constants.Keys) {
                op.Emit(output);
            }
            // functions
            foreach (var func in this.functions) {
                foreach (var op in func) {
                    op.Emit(output);
                }
            }
            // sanity check
            if (bound != this.rcount) {
                throw new Exception(String.Format("Invalid result ID bound: expected {0}, found {1}", bound, this.rcount));
            }
        }

        private void Run(Stream output)
        {
            while (this.queue.Count > 0) {
                Parse(this.queue.Dequeue());
            }
            Emit(output);
        }

        public static void EmitKernel(string assembly, string type, string method, Stream output)
        {
            var resolver = new DotNetCoreAssemblyResolver();
            using (var _assembly = resolver.Resolve(assembly))
            using (var _module = _assembly.MainModule) {
                TypeDefinition _type = _module.Types.Single(ti => ti.FullName == type);
                if (_type == null) {
                    Console.WriteLine("*** Error: could not find type '{0}'.", type);
                    return;
                }
                MethodDefinition _method = _type.Methods.Single(mi => mi.Name == method);
                if (_method == null) {
                    Console.WriteLine("*** Error: could not find method '{0}'.", method);
                    return;
                }
                EmitKernel(_method, output);
            }
        }

        public static void EmitKernel(MethodDefinition method, Stream output)
        {
            SpirCompiler compiler = new SpirCompiler(method);
            compiler.Run(output);
        }
    }
}
