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

        private const int BUILTIN_WIDTH = 32;
        private const int INTPTR_WIDTH = 32;

        private static readonly Dictionary<string,Func<SpirCompiler,TypeOpCode>> PrimitiveTypes = new Dictionary<string,Func<SpirCompiler,TypeOpCode>>()
        {
            { "System.Void",     c => c.OpTypeVoid() },

            { "System.SByte",    c => c.OpTypeInt( 8/*, signed*/) },
            { "System.Int8",     c => c.OpTypeInt( 8/*, signed*/) },
            { "System.Byte",     c => c.OpTypeInt( 8/*, unsigned*/) },
            { "System.UInt8",    c => c.OpTypeInt( 8/*, unsigned*/) },
            { "System.Int16",    c => c.OpTypeInt(16/*, signed*/) },
            { "System.UInt16",   c => c.OpTypeInt(16/*, unsigned*/) },
            { "System.Int32",    c => c.OpTypeInt(32/*, signed*/) },
            { "System.UInt32",   c => c.OpTypeInt(32/*, unsigned*/) },
            { "System.Int64",    c => c.OpTypeInt(64/*, signed*/) },
            { "System.UInt64",   c => c.OpTypeInt(64/*, unsigned*/) },
            { "System.IntPtr",   c => c.OpTypeInt(INTPTR_WIDTH/*, signed*/) },
            { "System.UIntPtr",  c => c.OpTypeInt(INTPTR_WIDTH/*, unsigned*/) },
            { "System.Single",   c => c.OpTypeFloat(32) },
            { "System.Double",   c => c.OpTypeFloat(64) },

            { "OpenCl.sbyte2",   c => c.OpTypeVector( 2, c.OpTypeInt(8/*, signed*/)) },
            { "OpenCl.sbyte3",   c => c.OpTypeVector( 3, c.OpTypeInt( 8/*, signed*/)) },
            { "OpenCl.sbyte4",   c => c.OpTypeVector( 4, c.OpTypeInt( 8/*, signed*/)) },
            { "OpenCl.sbyte8",   c => c.OpTypeVector( 8, c.OpTypeInt( 8/*, signed*/)) },
            { "OpenCl.sbyte16",  c => c.OpTypeVector(16, c.OpTypeInt( 8/*, signed*/)) },
            { "OpenCl.byte2",    c => c.OpTypeVector( 2, c.OpTypeInt( 8/*, unsigned*/)) },
            { "OpenCl.byte3",    c => c.OpTypeVector( 3, c.OpTypeInt( 8/*, unsigned*/)) },
            { "OpenCl.byte4",    c => c.OpTypeVector( 4, c.OpTypeInt( 8/*, unsigned*/)) },
            { "OpenCl.byte8",    c => c.OpTypeVector( 8, c.OpTypeInt( 8/*, unsigned*/)) },
            { "OpenCl.byte16",   c => c.OpTypeVector(16, c.OpTypeInt( 8/*, unsigned*/)) },
            { "OpenCl.short2",   c => c.OpTypeVector( 2, c.OpTypeInt(16/*, signed*/)) },
            { "OpenCl.short3",   c => c.OpTypeVector( 3, c.OpTypeInt(16/*, signed*/)) },
            { "OpenCl.short4",   c => c.OpTypeVector( 4, c.OpTypeInt(16/*, signed*/)) },
            { "OpenCl.short8",   c => c.OpTypeVector( 8, c.OpTypeInt(16/*, signed*/)) },
            { "OpenCl.short16",  c => c.OpTypeVector(16, c.OpTypeInt(16/*, signed*/)) },
            { "OpenCl.ushort2",  c => c.OpTypeVector( 2, c.OpTypeInt(16/*, unsigned*/)) },
            { "OpenCl.ushort3",  c => c.OpTypeVector( 3, c.OpTypeInt(16/*, unsigned*/)) },
            { "OpenCl.ushort4",  c => c.OpTypeVector( 4, c.OpTypeInt(16/*, unsigned*/)) },
            { "OpenCl.ushort8",  c => c.OpTypeVector( 8, c.OpTypeInt(16/*, unsigned*/)) },
            { "OpenCl.ushort16", c => c.OpTypeVector(16, c.OpTypeInt(16/*, unsigned*/)) },
            { "OpenCl.int2",     c => c.OpTypeVector( 2, c.OpTypeInt(32/*, signed*/)) },
            { "OpenCl.int3",     c => c.OpTypeVector( 3, c.OpTypeInt(32/*, signed*/)) },
            { "OpenCl.int4",     c => c.OpTypeVector( 4, c.OpTypeInt(32/*, signed*/)) },
            { "OpenCl.int8",     c => c.OpTypeVector( 8, c.OpTypeInt(32/*, signed*/)) },
            { "OpenCl.int16",    c => c.OpTypeVector(16, c.OpTypeInt(32/*, signed*/)) },
            { "OpenCl.uint2",    c => c.OpTypeVector( 2, c.OpTypeInt(32/*, unsigned*/)) },
            { "OpenCl.uint3",    c => c.OpTypeVector( 3, c.OpTypeInt(32/*, unsigned*/)) },
            { "OpenCl.uint4",    c => c.OpTypeVector( 4, c.OpTypeInt(32/*, unsigned*/)) },
            { "OpenCl.uint8",    c => c.OpTypeVector( 8, c.OpTypeInt(32/*, unsigned*/)) },
            { "OpenCl.uint16",   c => c.OpTypeVector(16, c.OpTypeInt(32/*, unsigned*/)) },
            { "OpenCl.long2",    c => c.OpTypeVector( 2, c.OpTypeInt(64/*, signed*/)) },
            { "OpenCl.long3",    c => c.OpTypeVector( 3, c.OpTypeInt(64/*, signed*/)) },
            { "OpenCl.long4",    c => c.OpTypeVector( 4, c.OpTypeInt(64/*, signed*/)) },
            { "OpenCl.long8",    c => c.OpTypeVector( 8, c.OpTypeInt(64/*, signed*/)) },
            { "OpenCl.long16",   c => c.OpTypeVector(16, c.OpTypeInt(64/*, signed*/)) },
            { "OpenCl.ulong2",   c => c.OpTypeVector( 2, c.OpTypeInt(64/*, unsigned*/)) },
            { "OpenCl.ulong3",   c => c.OpTypeVector( 3, c.OpTypeInt(64/*, unsigned*/)) },
            { "OpenCl.ulong4",   c => c.OpTypeVector( 4, c.OpTypeInt(64/*, unsigned*/)) },
            { "OpenCl.ulong8",   c => c.OpTypeVector( 8, c.OpTypeInt(64/*, unsigned*/)) },
            { "OpenCl.ulong16",  c => c.OpTypeVector(16, c.OpTypeInt(64/*, unsigned*/)) },
            { "OpenCl.float2",   c => c.OpTypeVector( 2, c.OpTypeFloat(32)) },
            { "OpenCl.float3",   c => c.OpTypeVector( 3, c.OpTypeFloat(32)) },
            { "OpenCl.float4",   c => c.OpTypeVector( 4, c.OpTypeFloat(32)) },
            { "OpenCl.float8",   c => c.OpTypeVector( 8, c.OpTypeFloat(32)) },
            { "OpenCl.float16",  c => c.OpTypeVector(16, c.OpTypeFloat(32)) },
            { "OpenCl.double2",  c => c.OpTypeVector( 2, c.OpTypeFloat(64)) },
            { "OpenCl.double3",  c => c.OpTypeVector( 3, c.OpTypeFloat(64)) },
            { "OpenCl.double4",  c => c.OpTypeVector( 4, c.OpTypeFloat(64)) },
            { "OpenCl.double8",  c => c.OpTypeVector( 8, c.OpTypeFloat(64)) },
            { "OpenCl.double16", c => c.OpTypeVector(16, c.OpTypeFloat(64)) },
        };

        // IL source data

        private readonly Queue<MethodDefinition> queue;

        // SPIR-V target data

        private int rcount;

        private List<OpEntryPoint> entryPoints;
        private List<OpDecorate> decorations;
        private Dictionary<TypeOpCode,int> types;
        private Dictionary<string,TypedResultOpCode> imports;
        private Dictionary<ConstOpCode,int> constants;
        private List<List<SpirOpCode>> functions;

        // constructor

        private SpirCompiler(params MethodDefinition[] methods)
        {
            this.queue = new Queue<MethodDefinition>(methods);
            this.rcount = 1;
            this.entryPoints = new List<OpEntryPoint>();
            this.decorations = new List<OpDecorate>();
            this.types = new Dictionary<TypeOpCode,int>();
            this.imports = new Dictionary<String,TypedResultOpCode>();
            this.constants = new Dictionary<ConstOpCode,int>();
            this.functions = new List<List<SpirOpCode>>();
        }

        // type helpers

        // private int SpirTypeIdCallback(TypeOpCode type)
        // {
        //     if (!this.types.TryGetValue(type, out int id)) {
        //         id = this.rcount++;
        //         this.types.Add(type, id);
        //         this.types_list.Add(type);
        //     }
        //     return id;
        // }

        private void RegisterTypeOpCode(TypeOpCode op)
        {
            if (!this.types.ContainsKey(op)) {
                var id = this.rcount++;
                this.types.Add(op, id);
            }
        }

        internal int TypeResultId(TypeOpCode op)
        {
            return this.types[op];
        }

        private TypeOpCode GetTypeOpCode(Type type, StorageClass? storage = null)
        {
            if (PrimitiveTypes.TryGetValue(type.FullName, out var factory)) {
                return factory(this);
            }
            else if (type.IsArray || type.IsPointer) {
                if (!storage.HasValue) {
                    throw new ArgumentNullException("storage");
                }
                return OpTypePointer(storage.GetValueOrDefault(), GetTypeOpCode(type.GetElementType()));
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

        private TypeOpCode GetTypeOpCode(TypeReference tr, StorageClass? storage = null)
        {
            if (PrimitiveTypes.TryGetValue(tr.FullName, out var factory)) {
                return factory(this);
            }
            if (tr.IsArray || tr.IsPointer) {
                if (!storage.HasValue) {
                    throw new ArgumentNullException("storage");
                }
                return OpTypePointer(storage.GetValueOrDefault(), GetTypeOpCode(tr.GetElementType()));
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
                return OpTypePointer(storage, GetTypeOpCode(tr.GetElementType()));
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
            return OpTypeFunction(r, p);
        }

        private static readonly Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,ConversionOpCode>> _convert_ops = new Dictionary<Type,Func<SpirCompiler,TypedResultOpCode,ConversionOpCode>>()
        {
            { typeof(sbyte),  (compiler, value) => compiler.OpSConvert(compiler.GetTypeOpCode<sbyte>(), value) },
            { typeof(short),  (compiler, value) => compiler.OpSConvert(compiler.GetTypeOpCode<short>(), value) },
            { typeof(int),    (compiler, value) => compiler.OpSConvert(compiler.GetTypeOpCode<int>(), value) },
            { typeof(long),   (compiler, value) => compiler.OpSConvert(compiler.GetTypeOpCode<long>(), value) },
            { typeof(IntPtr), (compiler, value) => compiler.OpSConvert(compiler.GetTypeOpCode<IntPtr>(), value) },
            { typeof(float),  (compiler, value) => compiler.OpConvertFToS(compiler.GetTypeOpCode<float>(), value) },
            { typeof(double), (compiler, value) => compiler.OpConvertFToS(compiler.GetTypeOpCode<double>(), value) }
        };

        private ConversionOpCode GetConversionOpCode(TypedResultOpCode src, Type dst)
        {
            if (_convert_ops.TryGetValue(dst, out var factory)) {
                return factory(this, src);
            }
            throw new CompilerException($"Unsupported type conversion: {src.ResultType} -> {dst}.");
        }

        // constant helper

        // private int SpirConstantCallback(ConstOpCode op)
        // {
        //     if (!this.constants.TryGetValue(op, out int id)) {
        //         id = this.rcount++;
        //         this.constants.Add(op, id);
        //     }
        //     return id;
        // }

        private void RegisterConstOpCode(ConstOpCode op)
        {
            if (!this.constants.ContainsKey(op)) {
                var id = this.rcount++;
                this.constants.Add(op, id);
            }
        }

        internal int ConstResultId(ConstOpCode op)
        {
            return this.constants[op];
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
            OpFunction function = OpFunction(functionType);
            if (method.CustomAttributes.SingleOrDefault(ai => ai.AttributeType.FullName == "OpenCl.KernelAttribute") != null) {
                this.entryPoints.Add(new OpEntryPoint(ExecutionModel.Kernel, function, GetMethodName(method)));
            }
            List<SpirOpCode> funcdef = new List<SpirOpCode>();
            funcdef.Add(function);
            var nparams = method.Parameters.Count;
            var param = new OpFunctionParameter[nparams];
            for (var i=0; i<nparams; i++) {
                var pi = method.Parameters[i];
                var ci = OpFunctionParameter(GetTypeOpCode(pi));
                param[i] = ci;
                funcdef.Add(ci);
            }
            funcdef.Add(OpLabel());

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
                        var label = OpLabel();
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
                if (labels.TryGetValue(instr.Offset, out var label)) {
                    if (!(funcdef.Last() is BranchOpCode)) {
                        // note: SPIR-V does not allow fall-through to next control flow block
                        // (see SPIR-V specification §2.2.4 and §2.16.1)
                        funcdef.Add(OpBranch(label));
                    }
                    funcdef.Add(label);
                }
                // main handler for current instruction
                switch (instr.OpCode.Code)
                {
                case Code.Nop:
                    // just for the fun of it...
                    // funcdef.Add(OpNop());
                    break;
                case Code.Dup: {
                    stack.Push(stack.Peek());
                    break;
                }
                case Code.Ldc_I4_0: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 0));
                    break;
                }
                case Code.Ldc_I4_1: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 1));
                    break;
                }
                case Code.Ldc_I4_2: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 2));
                    break;
                }
                case Code.Ldc_I4_3: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 3));
                    break;
                }
                case Code.Ldc_I4_4: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 4));
                    break;
                }
                case Code.Ldc_I4_5: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 5));
                    break;
                }
                case Code.Ldc_I4_6: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 6));
                    break;
                }
                case Code.Ldc_I4_7: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 7));
                    break;
                }
                case Code.Ldc_I4_8: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), 8));
                    break;
                }
                case Code.Ldc_I4_M1: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), -1));
                    break;
                }
                case Code.Ldc_I4: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), (int)instr.Operand));
                    break;
                }
                case Code.Ldc_I4_S: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<int>(), (sbyte)instr.Operand));
                    break;
                }
                case Code.Ldc_I8: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<long>(), (long)instr.Operand));
                    break;
                }
                case Code.Ldc_R4: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<float>(), (float)instr.Operand));
                    break;
                }
                case Code.Ldc_R8: {
                    stack.Push(OpConstant((NumericTypeOpCode)GetTypeOpCode<double>(), (double)instr.Operand));
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
                    var addr = OpPtrAccessChain(arr, idx);
                    var elem = OpLoad(addr);
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
                    var elem = OpLoad(addr);
                    funcdef.Add(elem);
                    stack.Push(elem);
                    break;
                }
                case Code.Ldarga:
                case Code.Ldarga_S: {
                    var arg = instr.Operand as ParameterDefinition;
                    var ptr = OpVariable(OpTypePointer(StorageClass.Function, GetTypeOpCode(arg)));
                    funcdef.Add(ptr);
                    stack.Push(ptr);
                    funcdef.Add(OpStore(ptr, param[arg.Index]));
                    break;
                }
                case Code.Ldloca:
                case Code.Ldloca_S: {
                    var loc = instr.Operand as VariableDefinition;
                    var ptr = OpVariable(OpTypePointer(StorageClass.Function, GetTypeOpCode(loc)));
                    funcdef.Add(ptr);
                    stack.Push(ptr);
                    funcdef.Add(OpStore(ptr, vars[loc.Index]));
                    break;
                }
                case Code.Ldelema: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    var addr = OpPtrAccessChain(arr, idx);
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
                    var ptr = OpPtrAccessChain(arr, idx);
                    funcdef.Add(ptr);
                    funcdef.Add(OpStore(ptr, val));
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
                    funcdef.Add(OpStore(ptr, val));
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpIAdd(l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = OpFConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpFConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpFAdd(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpISub(l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = OpFConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpFConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpFSub(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpIMul(l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = OpFConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpFConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpFMul(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpSDiv(l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                        var tl = l.ResultType as OpTypeFloat;
                        var tr = r.ResultType as OpTypeFloat;
                        if (tl.Width < tr.Width) {
                            l = OpFConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpFConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpFDiv(l, r);
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
                            l = OpUConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpUConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpUDiv(l, r);
                        funcdef.Add(op);
                        stack.Push(op);
                    }
                    // else if (l.ResultType is OpTypeFloat && r.ResultType is OpTypeFloat) {
                    //     var tl = l.ResultType as OpTypeFloat;
                    //     var tr = r.ResultType as OpTypeFloat;
                    //     if (tl.Width < tr.Width) {
                    //         l = OpFConvert(tr, l);
                    //         funcdef.Add(l);
                    //     }
                    //     else if (tr.Width < tl.Width) {
                    //         r = OpFConvert(tl, r);
                    //         funcdef.Add(r);
                    //     }
                    //     var op = OpFDiv(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpBitwiseAnd(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpBitwiseOr(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpBitwiseXor(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpShiftLeftLogical(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpShiftRightArithmetic(l, r);
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
                            l = OpSConvert(tr, l);
                            funcdef.Add(l);
                        }
                        else if (tr.Width < tl.Width) {
                            r = OpSConvert(tl, r);
                            funcdef.Add(r);
                        }
                        var op = OpShiftRightLogical(l, r);
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
                            var t = OpTypePointer(StorageClass.UniformConstant, OpTypeInt(BUILTIN_WIDTH));
                            // import symbol
                            sym = OpVariable(t);
                            this.imports.Add(name, sym);
                            // import decorations
                            this.decorations.Add(OpDecorateBuiltIn(sym, BuiltIn.WorkDim));
                            this.decorations.Add(OpDecorateConstant(sym));
                            this.decorations.Add(OpDecorateLinkageAttributes(sym, LinkageType.Import, BuiltIn.WorkDim));
                        }
                        var ld = OpLoad(sym);
                        var op = OpVectorExtractDynamic(ld, stack.Pop());
                        funcdef.Add(ld);
                        funcdef.Add(op);
                        stack.Push(op);
                        break;
                    }
                    case "OpenCl.Cl.GetGlobalSize": {
                        // __spirv_BuiltInGlobalSize = external addrspace(1) global <3 x i32>
                        if (!this.imports.TryGetValue(name, out TypedResultOpCode sym)) {
                            // type of import symbol
                            var t = OpTypePointer(StorageClass.UniformConstant, OpTypeVector(3, OpTypeInt(BUILTIN_WIDTH)));
                            // import symbol
                            sym = OpVariable(t);
                            this.imports.Add(name, sym);
                            // import decorations
                            this.decorations.Add(OpDecorateBuiltIn(sym, BuiltIn.GlobalSize));
                            this.decorations.Add(OpDecorateConstant(sym));
                            this.decorations.Add(OpDecorateLinkageAttributes(sym, LinkageType.Import, BuiltIn.GlobalSize));
                        }
                        var ld = OpLoad(sym);
                        var op = OpVectorExtractDynamic(ld, stack.Pop());
                        funcdef.Add(ld);
                        funcdef.Add(op);
                        stack.Push(op);
                        break;
                    }
                    case "OpenCl.Cl.GetGlobalId": {
                        // __spirv_BuiltInGlobalInvocationId = external addrspace(1) global <3 x i32>
                        if (!this.imports.TryGetValue(name, out TypedResultOpCode sym)) {
                            // type of import symbol
                            var t = OpTypePointer(StorageClass.UniformConstant, OpTypeVector(3, OpTypeInt(BUILTIN_WIDTH)));
                            // import symbol
                            sym = OpVariable(t);
                            this.imports.Add(name, sym);
                            // import decorations
                            this.decorations.Add(OpDecorateBuiltIn(sym, BuiltIn.GlobalInvocationId));
                            this.decorations.Add(OpDecorateConstant(sym));
                            this.decorations.Add(OpDecorateLinkageAttributes(sym, LinkageType.Import, BuiltIn.GlobalInvocationId));
                        }
                        var ld = OpLoad(sym);
                        var op = OpVectorExtractDynamic(ld, stack.Pop());
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
                            r = OpIAdd(a, b);
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = OpFAdd(a, b);
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
                            r = OpISub(a, b);
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = OpFSub(a, b);
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
                            r = OpIMul(a, b);
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = OpFMul(a, b);
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
                                r = OpUDiv(a, b);
                            }
                            else {
                                r = OpSDiv(a, b);
                            }
                        }
                        else if (a.ResultType is OpTypeFloat || (a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            r = OpFDiv(a, b);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_Division' call.");
                        }
                        funcdef.Add(r);
                        stack.Push(r);
                        break;
                    }
                    case string _ when name.EndsWith("op_Equality"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode cmp;
                        TypedResultOpCode sel;
                        if (a.ResultType is OpTypeInt) {
                            var width = (a.ResultType as OpTypeInt).Width;
                            cmp = OpIEqual(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeInt) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeInt).Width;
                            cmp = OpIEqual(OpTypeVector(size, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else if (a.ResultType is OpTypeFloat) {
                            var width = (a.ResultType as OpTypeFloat).Width;
                            cmp = OpFOrdEqual(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeFloat).Width;
                            cmp = OpFOrdEqual(OpTypeVector(size, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_Equality' call.");
                        }
                        funcdef.Add(cmp);
                        funcdef.Add(sel);
                        stack.Push(sel);
                        break;
                    }
                    case string _ when name.EndsWith("op_Inequality"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode cmp;
                        TypedResultOpCode sel;
                        if (a.ResultType is OpTypeInt) {
                            var width = (a.ResultType as OpTypeInt).Width;
                            cmp = OpINotEqual(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeInt) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeInt).Width;
                            cmp = OpINotEqual(OpTypeVector(size, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else if (a.ResultType is OpTypeFloat) {
                            var width = (a.ResultType as OpTypeFloat).Width;
                            cmp = OpFUnordNotEqual(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeFloat).Width;
                            cmp = OpFUnordNotEqual(OpTypeVector(size, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_Inequality' call.");
                        }
                        funcdef.Add(cmp);
                        funcdef.Add(sel);
                        stack.Push(sel);
                        break;
                    }
                    case string _ when name.EndsWith("op_LessThan"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode cmp;
                        TypedResultOpCode sel;
                        OpTypeInt t;
                        if ((t = a.ResultType as OpTypeInt) != null) {
                            var width = (a.ResultType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp = OpULessThan(OpTypeBool(), a, b);
                            }
                            else {
                                cmp = OpSLessThan(OpTypeBool(), a, b);
                            }
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((t = (a.ResultType as OpTypeVector)?.ComponentType as OpTypeInt) != null) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp =  OpULessThan(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            else {
                                cmp = OpSLessThan(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else if (a.ResultType is OpTypeFloat) {
                            var width = (a.ResultType as OpTypeFloat).Width;
                            cmp = OpFOrdLessThan(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeFloat).Width;
                            cmp = OpFOrdLessThan(OpTypeVector(size, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_LessThan' call.");
                        }
                        funcdef.Add(cmp);
                        funcdef.Add(sel);
                        stack.Push(sel);
                        break;
                    }
                    case string _ when name.EndsWith("op_LessThanOrEqual"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode cmp;
                        TypedResultOpCode sel;
                        OpTypeInt t;
                        if ((t = a.ResultType as OpTypeInt) != null) {
                            var width = (a.ResultType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp = OpULessThanEqual(OpTypeBool(), a, b);
                            }
                            else {
                                cmp = OpSLessThanEqual(OpTypeBool(), a, b);
                            }
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((t = (a.ResultType as OpTypeVector)?.ComponentType as OpTypeInt) != null) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp = OpULessThanEqual(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            else {
                                cmp = OpSLessThanEqual(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else if (a.ResultType is OpTypeFloat) {
                            var width = (a.ResultType as OpTypeFloat).Width;
                            cmp = OpFOrdLessThanEqual(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeFloat).Width;
                            cmp = OpFOrdLessThanEqual(OpTypeVector(size, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_LessThanOrEqual' call.");
                        }
                        funcdef.Add(cmp);
                        funcdef.Add(sel);
                        stack.Push(sel);
                        break;
                    }
                    case string _ when name.EndsWith("op_GreaterThan"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode cmp;
                        TypedResultOpCode sel;
                        OpTypeInt t;
                        if ((t = a.ResultType as OpTypeInt) != null) {
                            var width = (a.ResultType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp = OpUGreaterThan(OpTypeBool(), a, b);
                            }
                            else {
                                cmp = OpSGreaterThan(OpTypeBool(), a, b);
                            }
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((t = (a.ResultType as OpTypeVector)?.ComponentType as OpTypeInt) != null) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp = OpUGreaterThan(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            else {
                                cmp = OpSGreaterThan(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else if (a.ResultType is OpTypeFloat) {
                            var width = (a.ResultType as OpTypeFloat).Width;
                            cmp = OpFOrdGreaterThan(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeFloat).Width;
                            cmp = OpFOrdGreaterThan(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_GreaterThan' call.");
                        }
                        funcdef.Add(cmp);
                        funcdef.Add(sel);
                        stack.Push(sel);
                        break;
                    }
                    case string _ when name.EndsWith("op_GreaterThanOrEqual"): {
                        TypedResultOpCode b = stack.Pop();
                        TypedResultOpCode a = stack.Pop();
                        TypedResultOpCode cmp;
                        TypedResultOpCode sel;
                        OpTypeInt t;
                        if ((t = a.ResultType as OpTypeInt) != null) {
                            var width = (a.ResultType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp = OpUGreaterThanEqual(OpTypeBool(), a, b);
                            }
                            else {
                                cmp = OpSGreaterThanEqual(OpTypeBool(), a, b);
                            }
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((t = (a.ResultType as OpTypeVector)?.ComponentType as OpTypeInt) != null) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeInt).Width;
                            if (t.Signedness == 0) {
                                cmp = OpUGreaterThanEqual(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            else {
                                cmp = OpSGreaterThanEqual(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            }
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else if (a.ResultType is OpTypeFloat) {
                            var width = (a.ResultType as OpTypeFloat).Width;
                            cmp = OpFOrdGreaterThanEqual(OpTypeBool(), a, b);
                            sel = OpSelect(cmp, OpConstant(OpTypeInt(width), -1), OpConstant(OpTypeInt(width), 0));
                        }
                        else if ((a.ResultType as OpTypeVector)?.ComponentType is OpTypeFloat) {
                            var size = (a.ResultType as OpTypeVector).ComponentCount;
                            var width = ((a.ResultType as OpTypeVector).ComponentType as OpTypeFloat).Width;
                            cmp = OpFOrdGreaterThanEqual(OpTypeVector((a.ResultType as OpTypeVector).ComponentCount, OpTypeBool()), a, b);
                            var m = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width), -1), size).ToArray());
                            var z = OpConstantComposite(OpTypeVector(size, OpTypeInt(width)), Enumerable.Repeat<OpConstant>(OpConstant(OpTypeInt(width),  0), size).ToArray());
                            sel = OpSelect(cmp, m, z);
                        }
                        else {
                            throw new CompilerException($"Unsupported type '{a.ResultType}' in 'op_GreaterThanOrEqual' call.");
                        }
                        funcdef.Add(cmp);
                        funcdef.Add(sel);
                        stack.Push(sel);
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
                    var zero = OpConstant(arg.ResultType as NumericTypeOpCode, 0);
                    var cond = OpIEqual(OpTypeBool(), arg, zero);
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Brtrue:
                case Code.Brtrue_S: {
                    var arg = stack.Pop();
                    if (!(arg.ResultType is OpTypeInt)) {
                        throw new CompilerException($"Incompatible operand for 'brtrue' instruction: expected OpTypeInt, found {arg.ResultType.GetType().Name}.");
                    }
                    var zero = OpConstant(arg.ResultType as NumericTypeOpCode, 0);
                    var cond = OpINotEqual(OpTypeBool(), arg, zero);
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Beq:
                case Code.Beq_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpIEqual(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFOrdEqual(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'beq' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Bne_Un:
                case Code.Bne_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpINotEqual(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordNotEqual(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'beq' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Blt:
                case Code.Blt_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpSLessThan(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordLessThan(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'blt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Blt_Un:
                case Code.Blt_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpULessThan(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordLessThan(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'blt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Ble:
                case Code.Ble_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpSLessThanEqual(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordLessThanEqual(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'ble' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Ble_Un:
                case Code.Ble_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpULessThanEqual(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordLessThanEqual(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'ble' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Bgt:
                case Code.Bgt_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpSGreaterThan(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordGreaterThan(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bgt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Bgt_Un:
                case Code.Bgt_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpUGreaterThan(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordGreaterThan(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bgt' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Bge:
                case Code.Bge_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpSGreaterThanEqual(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordGreaterThanEqual(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bge' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Bge_Un:
                case Code.Bge_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    var cond = (TypedResultOpCode)null;
                    if (u.ResultType is OpTypeInt && v.ResultType is OpTypeInt) {
                        cond = OpUGreaterThanEqual(OpTypeBool(), u, v);
                    }
                    else if (u.ResultType is OpTypeFloat && v.ResultType is OpTypeFloat) {
                        cond = OpFUnordGreaterThanEqual(OpTypeBool(), u, v);
                    }
                    else {
                        throw new CompilerException($"Incompatible operands for 'bge' instruction: {u.ResultType.GetType().Name} and {v.ResultType.GetType().Name}.");
                    }
                    var lt = labels[(instr.Operand as Instruction).Offset];
                    var lf = OpLabel();
                    var br = new OpBranchConditional(cond, lt, lf);
                    funcdef.AddRange(new SpirOpCode[] { cond, br, lf });
                    break;
                }
                case Code.Ceq: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = OpIEqual(OpTypeBool(), a, b);
                    var sel = OpSelect(cmp, OpConstant(OpTypeInt(32), 1), OpConstant(OpTypeInt(32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Cgt: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = OpSGreaterThan(OpTypeBool(), a, b);
                    var sel = OpSelect(cmp, OpConstant(OpTypeInt(32), 1), OpConstant(OpTypeInt(32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Cgt_Un: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = OpUGreaterThan(OpTypeBool(), a, b);
                    var sel = OpSelect(cmp, OpConstant(OpTypeInt(32), 1), OpConstant(OpTypeInt(32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Clt: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = OpSLessThan(OpTypeBool(), a, b);
                    var sel = OpSelect(cmp, OpConstant(OpTypeInt(32), 1), OpConstant(OpTypeInt(32), 0));
                    funcdef.Add(cmp);
                    funcdef.Add(sel);
                    stack.Push(sel);
                    break;
                }
                case Code.Clt_Un: {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    var cmp = OpULessThan(OpTypeBool(), a, b);
                    var sel = OpSelect(cmp, OpConstant(OpTypeInt(32), 1), OpConstant(OpTypeInt(32), 0));
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
            OpCapability(Capability.Addresses).Emit(output);
            OpCapability(Capability.Linkage).Emit(output);
            OpCapability(Capability.Kernel).Emit(output);
            OpCapability(Capability.Int16).Emit(output);
            OpCapability(Capability.Int64).Emit(output);
            // import OpenCL extended instruction set
            // see: https://www.khronos.org/registry/spir-v/specs/1.0/OpenCL.ExtendedInstructionSet.100.html
            OpExtInstImport("OpenCL.std").Emit(output);
            // memory model
            OpMemoryModel(AddressingModel.Physical64, MemoryModel.OpenCL).Emit(output);
            // entry points
            foreach (var op in this.entryPoints) {
                op.Emit(output);
            }
            // decorations
            foreach (var op in this.decorations) {
                op.Emit(output);
            }
            // types
            foreach (var op in this.types.OrderBy(kv => kv.Value).Select(kv => kv.Key)) {
                op.Emit(output);
            }
            // imports
            foreach (var op in this.imports) {
                op.Value.Emit(output);
            }
            // exports
            // ...
            // constants
            foreach (var op in this.constants.OrderBy(kv => kv.Value).Select(kv => kv.Key)) {
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
