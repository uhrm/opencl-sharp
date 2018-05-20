using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace OpenCl.Compiler
{
    public class ClCompiler
    {
        private enum BranchType
        {
            Goto,
            If,
            While,
        }

        private class ClExprVisitor : AstVisitor
        {
            private readonly StringBuilder builder;

            public ClExprVisitor(StringBuilder sb)
            {
                this.builder = sb;
            }

            // Const

            public override void Visit<T>(Const<T> node)
            {
                this.builder.Append(node.Value.ToString());
            }

            // ParamRef

            public override void Visit(ParamRef node)
            {
                this.builder.Append(node.Name);
            }

            // VarRef

            public override void Visit(VarRef node)
            {
                this.builder.AppendFormat("__{0}{1}", node.IsTemp ? "T" : "V", node.Index);
            }

            // ElemRef

            public override void ExitArray(ElemRef node)
            {
                this.builder.Append("[");
            }

            public override void ExitIndex(ElemRef node)
            {
                this.builder.Append("]");
            }

            // FieldRef

            public override void Enter(FieldRef node)
            {
                this.builder.Append("(*(");
            }

            public override void Exit(FieldRef node)
            {
                this.builder.AppendFormat(")).{0}", node.Name);
            }

            // ParamAddr

            public override void Visit(ParamAddr node)
            {
                this.builder.AppendFormat("&{0}", node.Name);
            }

            // VarAddr

            public override void Visit(VarAddr node)
            {
                this.builder.AppendFormat("&__V{0}", node.Index);
            }

            // ElemAddr

            public override void Enter(ElemAddr node)
            {
                this.builder.Append("(");
            }

            public override void ExitArray(ElemAddr node)
            {
                this.builder.Append("+");
            }

            public override void Exit(ElemAddr node)
            {
                this.builder.Append(")");
            }

            // LoadAddr

            public override void Enter(LoadAddr node)
            {
                this.builder.Append("(*(");
            }

            public override void Exit(LoadAddr node)
            {
                this.builder.Append("))");
            }

            // LocAlloc

            public override void Enter(LocAlloc node)
            {
                this.builder.Append("alloca(");
            }

            public override void Exit(LocAlloc node)
            {
                this.builder.Append(")");
            }

            // Conv

            public override void Enter(Conv node)
            {
                this.builder.AppendFormat("(({0})(", typeMap[node.CliType.SystemType.FullName]);
            }

            public override void Exit(Conv node)
            {
                this.builder.Append("))");
            }

            // Call

            public override void Enter(Call node)
            {
                this.builder.AppendFormat("{0}(", node.Name);
            }

            public override void ExitArgument(Call node, int idx)
            {
                if (idx < node.Argument.Count-1) {
                    this.builder.Append(", ");
                }
            }

            public override void Exit(Call node)
            {
                this.builder.Append(")");
            }

            // BinaryOp

            public override void Enter(BinaryOp node)
            {
                this.builder.Append("(");
            }

            public override void ExitLeft(BinaryOp node)
            {
                var op = String.Empty;
                switch (node.Code)
                {
                case BinaryOp.OpCode.Add:
                    op = "+";
                    break;
                case BinaryOp.OpCode.Sub:
                    op = "-";
                    break;
                case BinaryOp.OpCode.Mul:
                    op = "*";
                    break;
                case BinaryOp.OpCode.Div:
                    op = "/";
                    break;
                case BinaryOp.OpCode.And:
                    op = "&";
                    break;
                case BinaryOp.OpCode.Or:
                    op = "|";
                    break;
                case BinaryOp.OpCode.Xor:
                    op = "^";
                    break;
                case BinaryOp.OpCode.Shl:
                    op = "<<";
                    break;
                case BinaryOp.OpCode.Shr:
                    op = ">>";
                    break;
                case BinaryOp.OpCode.Eq:
                    op = "==";
                    break;
                case BinaryOp.OpCode.Neq:
                    op = "!=";
                    break;
                case BinaryOp.OpCode.Lt:
                    op = "<";
                    break;
                case BinaryOp.OpCode.Le:
                    op = "<=";
                    break;
                case BinaryOp.OpCode.Gt:
                    op = ">";
                    break;
                case BinaryOp.OpCode.Ge:
                    op = ">=";
                    break;
                }
                this.builder.Append(op);
            }

            public override void Exit(BinaryOp node)
            {
                this.builder.Append(")");
            }

            // UnaryOp

            public override void Enter(UnaryOp node)
            {
                var op = String.Empty;
                switch (node.Code)
                {
                case UnaryOp.OpCode.Neg:
                    op = "-";
                    break;
                case UnaryOp.OpCode.Not:
                    op = "~";
                    break;
                }
                this.builder.AppendFormat("({0}(", op);
            }

            public override void Exit(UnaryOp node)
            {
                this.builder.Append("))");
            }
        }

        private static readonly Dictionary<string,string> typeMap = new Dictionary<string,string>()
        {
            { "System.Void",     "void" },

            { "System.SByte",    "char" },
            { "System.Int8",     "char" },
            { "System.Byte",     "uchar" },
            { "System.UInt8",    "uchar" },
            { "System.Int16",    "short" },
            { "System.UInt16",   "ushort" },
            { "System.Int32",    "int" },
            { "System.UInt32",   "uint" },
            { "System.Int64",    "long" },
            { "System.UInt64",   "ulong" },
            { "System.Single",   "float" },
            { "System.Double",   "double" },

            { "OpenCl.sbyte2",   "char2" },
            { "OpenCl.sbyte3",   "char3" },
            { "OpenCl.sbyte4",   "char4" },
            { "OpenCl.sbyte8",   "char8" },
            { "OpenCl.sbyte16",  "char16" },
            { "OpenCl.byte2",    "uchar2" },
            { "OpenCl.byte3",    "uchar3" },
            { "OpenCl.byte4",    "uchar4" },
            { "OpenCl.byte8",    "uchar8" },
            { "OpenCl.byte16",   "uchar16" },
            { "OpenCl.short2",   "short2" },
            { "OpenCl.short3",   "short3" },
            { "OpenCl.short4",   "short4" },
            { "OpenCl.short8",   "short8" },
            { "OpenCl.short16",  "short16" },
            { "OpenCl.ushort2",  "ushort2" },
            { "OpenCl.ushort3",  "ushort3" },
            { "OpenCl.ushort4",  "ushort4" },
            { "OpenCl.ushort8",  "ushort8" },
            { "OpenCl.ushort16", "ushort16" },
            { "OpenCl.int2",     "int2" },
            { "OpenCl.int3",     "int3" },
            { "OpenCl.int4",     "int4" },
            { "OpenCl.int8",     "int8" },
            { "OpenCl.int16",    "int16" },
            { "OpenCl.uint2",    "uint2" },
            { "OpenCl.uint3",    "uint3" },
            { "OpenCl.uint4",    "uint4" },
            { "OpenCl.uint8",    "uint8" },
            { "OpenCl.uint16",   "uint16" },
            { "OpenCl.long2",    "long2" },
            { "OpenCl.long3",    "long3" },
            { "OpenCl.long4",    "long4" },
            { "OpenCl.long8",    "long8" },
            { "OpenCl.long16",   "long16" },
            { "OpenCl.ulong2",   "ulong2" },
            { "OpenCl.ulong3",   "ulong3" },
            { "OpenCl.ulong4",   "ulong4" },
            { "OpenCl.ulong8",   "ulong8" },
            { "OpenCl.ulong16",  "ulong16" },
            { "OpenCl.float2",   "float2" },
            { "OpenCl.float3",   "float3" },
            { "OpenCl.float4",   "float4" },
            { "OpenCl.float8",   "float8" },
            { "OpenCl.float16",  "float16" },
            { "OpenCl.double2",  "double2" },
            { "OpenCl.double3",  "double3" },
            { "OpenCl.double4",  "double4" },
            { "OpenCl.double8",  "double8" },
            { "OpenCl.double16", "double16" },

            { "System.SByte[]",    "char*" },
            { "System.Int8[]",     "char*" },
            { "System.Byte[]",     "uchar*" },
            { "System.UInt8[]",    "uchar*" },
            { "System.Int16[]",    "short*" },
            { "System.UInt16[]",   "ushort*" },
            { "System.Int32[]",    "int*" },
            { "System.UInt32[]",   "uint*" },
            { "System.Int64[]",    "long*" },
            { "System.UInt64[]",   "ulong*" },
            { "System.Single[]",   "float*" },
            { "System.Double[]",   "double*" },

            { "OpenCl.sbyte2[]",   "char2*" },
            { "OpenCl.sbyte3[]",   "char3*" },
            { "OpenCl.sbyte4[]",   "char4*" },
            { "OpenCl.sbyte8[]",   "char8*" },
            { "OpenCl.sbyte16[]",  "char16*" },
            { "OpenCl.byte2[]",    "uchar2*" },
            { "OpenCl.byte3[]",    "uchar3*" },
            { "OpenCl.byte4[]",    "uchar4*" },
            { "OpenCl.byte8[]",    "uchar8*" },
            { "OpenCl.byte16[]",   "uchar16*" },
            { "OpenCl.short2[]",   "short2*" },
            { "OpenCl.short3[]",   "short3*" },
            { "OpenCl.short4[]",   "short4*" },
            { "OpenCl.short8[]",   "short8*" },
            { "OpenCl.short16[]",  "short16*" },
            { "OpenCl.ushort2[]",  "ushort2*" },
            { "OpenCl.ushort3[]",  "ushort3*" },
            { "OpenCl.ushort4[]",  "ushort4*" },
            { "OpenCl.ushort8[]",  "ushort8*" },
            { "OpenCl.ushort16[]", "ushort16*" },
            { "OpenCl.int2[]",     "int2*" },
            { "OpenCl.int3[]",     "int3*" },
            { "OpenCl.int4[]",     "int4*" },
            { "OpenCl.int8[]",     "int8*" },
            { "OpenCl.int16[]",    "int16*" },
            { "OpenCl.uint2[]",    "uint2*" },
            { "OpenCl.uint3[]",    "uint3*" },
            { "OpenCl.uint4[]",    "uint4*" },
            { "OpenCl.uint8[]",    "uint8*" },
            { "OpenCl.uint16[]",   "uint16*" },
            { "OpenCl.long2[]",    "long2*" },
            { "OpenCl.long3[]",    "long3*" },
            { "OpenCl.long4[]",    "long4*" },
            { "OpenCl.long8[]",    "long8*" },
            { "OpenCl.long16[]",   "long16*" },
            { "OpenCl.ulong2[]",   "ulong2*" },
            { "OpenCl.ulong3[]",   "ulong3*" },
            { "OpenCl.ulong4[]",   "ulong4*" },
            { "OpenCl.ulong8[]",   "ulong8*" },
            { "OpenCl.ulong16[]",  "ulong16*" },
            { "OpenCl.float2[]",   "float2*" },
            { "OpenCl.float3[]",   "float3*" },
            { "OpenCl.float4[]",   "float4*" },
            { "OpenCl.float8[]",   "float8*" },
            { "OpenCl.float16[]",  "float16*" },
            { "OpenCl.double2[]",  "double2*" },
            { "OpenCl.double3[]",  "double3*" },
            { "OpenCl.double4[]",  "double4*" },
            { "OpenCl.double8[]",  "double8*" },
            { "OpenCl.double16[]", "double16*" },

            { "System.SByte*",    "char*" },
            { "System.Int8*",     "char*" },
            { "System.Byte*",     "uchar*" },
            { "System.UInt8*",    "uchar*" },
            { "System.Int16*",    "short*" },
            { "System.UInt16*",   "ushort*" },
            { "System.Int32*",    "int*" },
            { "System.UInt32*",   "uint*" },
            { "System.Int64*",    "long*" },
            { "System.UInt64*",   "ulong*" },
            { "System.Single*",   "float*" },
            { "System.Double*",   "double*" },

            { "OpenCl.sbyte2*",   "char2*" },
            { "OpenCl.sbyte3*",   "char3*" },
            { "OpenCl.sbyte4*",   "char4*" },
            { "OpenCl.sbyte8*",   "char8*" },
            { "OpenCl.sbyte16*",  "char16*" },
            { "OpenCl.byte2*",    "uchar2*" },
            { "OpenCl.byte3*",    "uchar3*" },
            { "OpenCl.byte4*",    "uchar4*" },
            { "OpenCl.byte8*",    "uchar8*" },
            { "OpenCl.byte16*",   "uchar16*" },
            { "OpenCl.short2*",   "short2*" },
            { "OpenCl.short3*",   "short3*" },
            { "OpenCl.short4*",   "short4*" },
            { "OpenCl.short8*",   "short8*" },
            { "OpenCl.short16*",  "short16*" },
            { "OpenCl.ushort2*",  "ushort2*" },
            { "OpenCl.ushort3*",  "ushort3*" },
            { "OpenCl.ushort4*",  "ushort4*" },
            { "OpenCl.ushort8*",  "ushort8*" },
            { "OpenCl.ushort16*", "ushort16*" },
            { "OpenCl.int2*",     "int2*" },
            { "OpenCl.int3*",     "int3*" },
            { "OpenCl.int4*",     "int4*" },
            { "OpenCl.int8*",     "int8*" },
            { "OpenCl.int16*",    "int16*" },
            { "OpenCl.uint2*",    "uint2*" },
            { "OpenCl.uint3*",    "uint3*" },
            { "OpenCl.uint4*",    "uint4*" },
            { "OpenCl.uint8*",    "uint8*" },
            { "OpenCl.uint16*",   "uint16*" },
            { "OpenCl.long2*",    "long2*" },
            { "OpenCl.long3*",    "long3*" },
            { "OpenCl.long4*",    "long4*" },
            { "OpenCl.long8*",    "long8*" },
            { "OpenCl.long16*",   "long16*" },
            { "OpenCl.ulong2*",   "ulong2*" },
            { "OpenCl.ulong3*",   "ulong3*" },
            { "OpenCl.ulong4*",   "ulong4*" },
            { "OpenCl.ulong8*",   "ulong8*" },
            { "OpenCl.ulong16*",  "ulong16*" },
            { "OpenCl.float2*",   "float2*" },
            { "OpenCl.float3*",   "float3*" },
            { "OpenCl.float4*",   "float4*" },
            { "OpenCl.float8*",   "float8*" },
            { "OpenCl.float16*",  "float16*" },
            { "OpenCl.double2*",  "double2*" },
            { "OpenCl.double3*",  "double3*" },
            { "OpenCl.double4*",  "double4*" },
            { "OpenCl.double8*",  "double8*" },
            { "OpenCl.double16*", "double16*" },
        };

        private readonly MethodDefinition method;

        private readonly StringBuilder builder;

        private readonly ClExprVisitor printer;

        private readonly Dictionary<int,BranchType> labels;

        private ClCompiler(MethodDefinition method)
        {
            this.method = method;
            this.builder = new StringBuilder();
            this.printer = new ClExprVisitor(this.builder);
            this.labels = new Dictionary<int,BranchType>();
        }

        private string GetMethodName(MethodDefinition mdef)
        {
            var name =
                mdef.CustomAttributes
                .Where(ai => ai.AttributeType.FullName == "OpenCl.ClNameAttribute")
                .Select((attr, idx) => attr.ConstructorArguments[0].Value as string)
                .FirstOrDefault();
            return name != null ? name : mdef.Name;
        }

        private void EmitType(TypeReference type)
        {
            string name = null;
            if (!typeMap.TryGetValue(type.FullName, out name)) {
                throw new ArgumentException(String.Format("Unsupported type: {0}.", type.FullName));
            }
            this.builder.Append(name);
            this.builder.Append(" ");
        }

        private void EmitUnaryBranch(Instruction instr, AstNode b)
        {
            switch (labels[(instr.Operand as Instruction).Offset])
            {
            case BranchType.If:
                this.builder.Append("if (");
                if (instr.OpCode.Code == Code.Brtrue || instr.OpCode.Code == Code.Brtrue_S) {
                    this.builder.Append("!(");
                }
                b.Accept(this.printer);
                if (instr.OpCode.Code == Code.Brtrue || instr.OpCode.Code == Code.Brtrue_S) {
                    this.builder.Append(")");
                }
                this.builder.AppendLine(") {");
                break;
            case BranchType.While:
                this.builder.Append("} while (");
                if (instr.OpCode.Code == Code.Brfalse || instr.OpCode.Code == Code.Brfalse_S) {
                    this.builder.Append("!(");
                }
                b.Accept(this.printer);
                if (instr.OpCode.Code == Code.Brfalse || instr.OpCode.Code == Code.Brfalse_S) {
                    this.builder.Append(")");
                }
                this.builder.AppendLine(");");
                break;
            default:
                this.builder.Append("if (");
                if (instr.OpCode.Code == Code.Brfalse || instr.OpCode.Code == Code.Brfalse_S) {
                    this.builder.Append("!(");
                }
                b.Accept(this.printer);
                if (instr.OpCode.Code == Code.Brfalse || instr.OpCode.Code == Code.Brfalse_S) {
                    this.builder.Append(")");
                }
                this.builder.AppendFormat(") goto __L{0:x4};\n", (instr.Operand as Instruction).Offset);
                break;
            }
        }

        private void EmitBinaryBranch(Instruction instr, string op, AstNode u, AstNode v)
        {
            switch (labels[(instr.Operand as Instruction).Offset])
            {
            case BranchType.If:
                this.builder.Append("if (!(");
                u.Accept(this.printer);
                this.builder.Append(op);
                v.Accept(this.printer);
                this.builder.AppendLine(")) {");
                break;
            case BranchType.While:
                this.builder.Append("} while (");
                u.Accept(this.printer);
                this.builder.Append(op);
                v.Accept(this.printer);
                this.builder.AppendLine(");");
                break;
            default:
                this.builder.Append("if (");
                u.Accept(this.printer);
                this.builder.Append(op);
                v.Accept(this.printer);
                this.builder.AppendFormat(") goto __L{0:x4};\n", (instr.Operand as Instruction).Offset);
                break;
            }
        }

        private void EmitHeader()
        {
            if (this.method.CustomAttributes.SingleOrDefault(ai => ai.AttributeType.FullName == "OpenCl.KernelAttribute") != null) {
                this.builder.Append("__kernel ");
            }
            EmitType(this.method.ReturnType);
            this.builder.Append(GetMethodName(this.method));
            this.builder.Append("(");
            var parameters = this.method.Parameters;
            for (var i=0; i<parameters.Count; i++) {
                if (i > 0) {
                    this.builder.Append(", ");
                }
                if (parameters[i].CustomAttributes.SingleOrDefault(ai => ai.AttributeType.FullName == "OpenCl.GlobalAttribute") != null) {
                    this.builder.Append("__global ");
                }
                EmitType(parameters[i].ParameterType);
                this.builder.Append(parameters[i].Name);
            }
            this.builder.AppendLine(")");
        }

        private void EmitBody()
        {
            this.builder.AppendLine("{");
            var body = this.method.Body;
            var vars = body.Variables;
            foreach (var v in vars) {
                string name = null;
                if (!typeMap.TryGetValue(v.VariableType.FullName, out name)) {
                    throw new ArgumentException(String.Format("Unsupported type: {0}.", v.VariableType.FullName));
                }
                this.builder.AppendFormat("{0} __V{1};\n", name, v.Index);
            }
            var code = body.Instructions;
            foreach (var instr in code) {
                switch (instr.OpCode.OperandType)
                {
                case OperandType.ShortInlineBrTarget:
                case OperandType.InlineBrTarget: {
                    var sofs = instr.Offset;
                    var tofs = (instr.Operand as Instruction).Offset;
                    BranchType type;
                    if (instr.OpCode.Code == Code.Br || instr.OpCode.Code == Code.Br_S) {
                        type = BranchType.Goto;
                    }
                    else if (sofs < tofs) {
                        type = BranchType.If;
                    }
                    else {
                        type = BranchType.While;
                    }
                    this.labels.Add(tofs, type);
                    break;
                }
                default:
                    break;
                }
            }
            var stack = new Stack<AstNode>();
            var ndups = 0;
            foreach (var instr in code) {
                if (this.labels.ContainsKey(instr.Offset)) {
                    switch (this.labels[instr.Offset])
                    {
                    case BranchType.Goto:
                        this.builder.AppendFormat("__L{0:x4}: {{ }}\n", instr.Offset);
                        break;
                    case BranchType.If:
                        this.builder.AppendLine("}");
                        break;
                    case BranchType.While:
                        this.builder.AppendLine("do {");
                        break;
                    }
                }
                // ***DEBUG***
//                this.builder.AppendLine(instr.ToString());
                // ***ENDEBUG***
                switch (instr.OpCode.Code)
                {
                case Code.Nop:
                    // nothing to do...
                    break;
                case Code.Dup: {
                    var node = stack.Pop();
                        string name = null;
                        if (!typeMap.TryGetValue(node.CliType.SystemType.FullName, out name)) {
                            throw new ArgumentException(String.Format("Unsupported type: {0}.", node.CliType));
                        }
                        this.builder.AppendFormat("{0} __T{1} = ", name, ndups);
                        node.Accept(printer);
                        this.builder.AppendLine(";");
                        stack.Push(new VarRef(node.CliType, ndups, true));
                        stack.Push(new VarRef(node.CliType, ndups, true));
                        ndups++;
                    break;
                }
                case Code.Ldc_I4_0:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 0));
                    break;
                case Code.Ldc_I4_1:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 1));
                    break;
                case Code.Ldc_I4_2:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 2));
                    break;
                case Code.Ldc_I4_3:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 3));
                    break;
                case Code.Ldc_I4_4:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 4));
                    break;
                case Code.Ldc_I4_5:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 5));
                    break;
                case Code.Ldc_I4_6:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 6));
                    break;
                case Code.Ldc_I4_7:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 7));
                    break;
                case Code.Ldc_I4_8:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), 8));
                    break;
                case Code.Ldc_I4_M1:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), -1));
                    break;
                case Code.Ldc_I4:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), (int)instr.Operand));
                    break;
                case Code.Ldc_I4_S:
                    stack.Push(new Const<int>(CliType.FromType(typeof(System.Int32)), (sbyte)instr.Operand));
                    break;
                case Code.Ldc_I8:
                    stack.Push(new Const<long>(CliType.FromType(typeof(System.Int64)), (long)instr.Operand));
                    break;
                case Code.Ldc_R4:
                    stack.Push(new Const<float>(CliType.FromType(typeof(System.Single)), (float)instr.Operand));
                    break;
                case Code.Ldc_R8:
                    stack.Push(new Const<double>(CliType.FromType(typeof(System.Double)), (double)instr.Operand));
                    break;
                case Code.Ldarg_0: {
                    var arg = this.method.Parameters[0];
                    stack.Push(new ParamRef(CliType.FromType(arg.ParameterType), arg.Name));
                    break;
                }
                case Code.Ldarg_1: {
                    var arg = this.method.Parameters[1];
                    stack.Push(new ParamRef(CliType.FromType(arg.ParameterType), arg.Name));
                    break;
                }
                case Code.Ldarg_2: {
                    var arg = this.method.Parameters[2];
                    stack.Push(new ParamRef(CliType.FromType(arg.ParameterType), arg.Name));
                    break;
                }
                case Code.Ldarg_3: {
                    var arg = this.method.Parameters[3];
                    stack.Push(new ParamRef(CliType.FromType(arg.ParameterType), arg.Name));
                    break;
                }
                case Code.Ldarg:
                case Code.Ldarg_S: {
                    var arg = instr.Operand as ParameterDefinition;
                    stack.Push(new ParamRef(CliType.FromType(arg.ParameterType), arg.Name));
                    break;
                }
                case Code.Ldloc_0:
                    stack.Push(new VarRef(CliType.FromType(vars[0].VariableType), 0));
                    break;
                case Code.Ldloc_1:
                    stack.Push(new VarRef(CliType.FromType(vars[1].VariableType), 1));
                    break;
                case Code.Ldloc_2:
                    stack.Push(new VarRef(CliType.FromType(vars[2].VariableType), 2));
                    break;
                case Code.Ldloc_3:
                    stack.Push(new VarRef(CliType.FromType(vars[3].VariableType), 3));
                    break;
                case Code.Ldloc:
                case Code.Ldloc_S: {
                    var loc = instr.Operand as VariableDefinition;
                    stack.Push(new VarRef(CliType.FromType(loc.VariableType), loc.Index));
                    break;
                }
                case Code.Ldelem_Any: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(instr.Operand as TypeReference), arr, idx));
                    break;
                }
                case Code.Ldelem_I: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.IntPtr)), arr, idx));
                    break;
                }
                case Code.Ldelem_I1: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.SByte)), arr, idx));
                    break;
                }
                case Code.Ldelem_I2: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.Int16)), arr, idx));
                    break;
                }
                case Code.Ldelem_I4: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.Int32)), arr, idx));
                    break;
                }
                case Code.Ldelem_U1: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.Byte)), arr, idx));
                    break;
                }
                case Code.Ldelem_U2: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.UInt16)), arr, idx));
                    break;
                }
                case Code.Ldelem_U4: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.UInt32)), arr, idx));
                    break;
                }
                case Code.Ldelem_I8: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.Int64)), arr, idx));
                    break;
                }
                case Code.Ldelem_R4: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.Single)), arr, idx));
                    break;
                }
                case Code.Ldelem_R8: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(CliType.FromType(typeof(System.Double)), arr, idx));
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
                    var ptr = stack.Pop();
                    stack.Push(new LoadAddr(ptr));
                    break;
                }
                case Code.Ldarga:
                case Code.Ldarga_S: {
                    var arg = instr.Operand as ParameterDefinition;
                    var type = new PointerType(arg.ParameterType);
                    stack.Push(new ParamAddr(new CliPointerType(type), arg.Name));
                    break;
                }
                case Code.Ldloca:
                case Code.Ldloca_S: {
                    var loc = instr.Operand as VariableDefinition;
                    var type = new PointerType(loc.VariableType);
                    stack.Push(new VarAddr(new CliPointerType(type), loc.Index));
                    break;
                }
                case Code.Ldelema: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                        stack.Push(new ElemAddr(arr.CliType, arr, idx));
                    break;
                }
                case Code.Localloc: {
                    var size = stack.Pop();
                    stack.Push(new LocAlloc(size));
                    break;
                }
                case Code.Stloc_0: {
                    this.builder.Append("__V0 = ");
                    stack.Pop().Accept(this.printer);
                    this.builder.AppendLine(";");
                    break;
                }
                case Code.Stloc_1: {
                    this.builder.Append("__V1 = ");
                    stack.Pop().Accept(this.printer);
                    this.builder.AppendLine(";");
                    break;
                }
                case Code.Stloc_2: {
                    this.builder.Append("__V2 = ");
                    stack.Pop().Accept(this.printer);
                    this.builder.AppendLine(";");
                    break;
                }
                case Code.Stloc_3: {
                    this.builder.Append("__V3 = ");
                    stack.Pop().Accept(this.printer);
                    this.builder.AppendLine(";");
                    break;
                }
                case Code.Stloc:
                case Code.Stloc_S: {
                    this.builder.AppendFormat("__V{0} = ", (instr.Operand as VariableDefinition).Index);
                    stack.Pop().Accept(this.printer);
                    this.builder.AppendLine(";");
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
                    arr.Accept(this.printer);
                    this.builder.Append("[");
                    idx.Accept(this.printer);
                    this.builder.Append("] = ");
                    val.Accept(this.printer);
                    this.builder.AppendLine(";");
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
                    this.builder.Append("*(");
                    ptr.Accept(this.printer);
                    this.builder.Append(") = ");
                    val.Accept(this.printer);
                    this.builder.AppendLine(";");
                    break;
                }
                case Code.Conv_I:
                case Code.Conv_Ovf_I:
                case Code.Conv_Ovf_I_Un:
                    stack.Push(new Conv(typeof(IntPtr), stack.Pop()));
                    break;
                case Code.Conv_I1:
                case Code.Conv_Ovf_I1:
                case Code.Conv_Ovf_I1_Un:
                    stack.Push(new Conv(typeof(SByte), stack.Pop()));
                    break;
                case Code.Conv_I2:
                case Code.Conv_Ovf_I2:
                case Code.Conv_Ovf_I2_Un:
                    stack.Push(new Conv(typeof(Int16), stack.Pop()));
                    break;
                case Code.Conv_I4:
                case Code.Conv_Ovf_I4:
                case Code.Conv_Ovf_I4_Un:
                    stack.Push(new Conv(typeof(Int32), stack.Pop()));
                    break;
                case Code.Conv_I8:
                case Code.Conv_Ovf_I8:
                case Code.Conv_Ovf_I8_Un:
                    stack.Push(new Conv(typeof(Int64), stack.Pop()));
                    break;
                case Code.Conv_U:
                case Code.Conv_Ovf_U:
                case Code.Conv_Ovf_U_Un:
                    stack.Push(new Conv(typeof(UIntPtr), stack.Pop()));
                    break;
                case Code.Conv_U1:
                case Code.Conv_Ovf_U1:
                case Code.Conv_Ovf_U1_Un:
                    stack.Push(new Conv(typeof(Byte), stack.Pop()));
                    break;
                case Code.Conv_U2:
                case Code.Conv_Ovf_U2:
                case Code.Conv_Ovf_U2_Un:
                    stack.Push(new Conv(typeof(UInt16), stack.Pop()));
                    break;
                case Code.Conv_U4:
                case Code.Conv_Ovf_U4:
                case Code.Conv_Ovf_U4_Un:
                    stack.Push(new Conv(typeof(UInt32), stack.Pop()));
                    break;
                case Code.Conv_U8:
                case Code.Conv_Ovf_U8:
                case Code.Conv_Ovf_U8_Un:
                    stack.Push(new Conv(typeof(UInt64), stack.Pop()));
                    break;
                case Code.Conv_R4:
                    stack.Push(new Conv(typeof(Single), stack.Pop()));
                    break;
                case Code.Conv_R8:
                    stack.Push(new Conv(typeof(Double), stack.Pop()));
                    break;
                case Code.Add:
                case Code.Add_Ovf:
                case Code.Add_Ovf_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpAdd(l.CliType, r.CliType);
                    if (l.CliType is CliPointerType) {
                        var e = (l.CliType as CliPointerType).Element;
                        var s = Marshal.SizeOf(e);
                        r = new BinaryOp(r.CliType, BinaryOp.OpCode.Div, r, new Const<int> (r.CliType, s));
                    }
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Add, l, r));
                    break;
                }
                case Code.Sub:
                case Code.Sub_Ovf:
                case Code.Sub_Ovf_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpSub(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Sub, l, r));
                    break;
                }
                case Code.Mul:
                case Code.Mul_Ovf:
                case Code.Mul_Ovf_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpMul(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Mul, l, r));
                    break;
                }
                case Code.Div:
                case Code.Div_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpDiv(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Div, l, r));
                    break;
                }
                case Code.And: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpBitwise(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.And, l, r));
                    break;
                }
                case Code.Or: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpBitwise(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Or, l, r));
                    break;
                }
                case Code.Xor: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpBitwise(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Xor, l, r));
                    break;
                }
                case Code.Shl: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpBitwise(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Shl, l, r));
                    break;
                }
                case Code.Shr:
                case Code.Shr_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    var t = CliType.FromOpBitwise(l.CliType, r.CliType);
                    stack.Push(new BinaryOp(t, BinaryOp.OpCode.Shr, l, r));
                    break;
                }
                case Code.Call: {
                    var mref = instr.Operand as MethodReference;
                    var mdef = mref.Resolve();
                    var name = GetMethodName(mdef);
                    var nargs = mref.Parameters.Count;
                    if (mdef.HasThis && !mdef.ExplicitThis) {
                        nargs++;
                    }
                    var args = new AstNode[nargs];
                    for (var i=nargs-1; i>=0; i--) {
                        args[i] = stack.Pop();
                    }
                    if (mdef.IsConstructor) {
                        var tdef = mdef.DeclaringType;
                        if (tdef.IsValueType) {
                            // Note: this assumes that the struct constructor
                            // is compatible with C-style compound literals.
                            this.builder.Append("*(");
                            args[0].Accept(this.printer);
                            this.builder.AppendFormat(") = ({0}){{ ", typeMap[tdef.FullName]);
                            for (int i=1; i<nargs; i++) {
                                if (i > 1) {
                                    this.builder.Append(", ");
                                }
                                args[i].Accept(this.printer);
                            }
                            this.builder.AppendLine(" };");
                        }
                    }
                    else {
                        var rtype = CliType.FromType(mdef.ReturnType);
                        switch (name)
                        {
                        case "op_Addition":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Add, args[0], args[1]));
                            break;
                        case "op_Subtraction":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Sub, args[0], args[1]));
                            break;
                        case "op_Multiply":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Mul, args[0], args[1]));
                            break;
                        case "op_Division":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Div, args[0], args[1]));
                            break;
                        case "op_Equality":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Eq, args[0], args[1]));
                            break;
                        case "op_Inequality":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Neq, args[0], args[1]));
                            break;
                        case "op_LessThan":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Lt, args[0], args[1]));
                            break;
                        case "op_LessThanOrEqual":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Le, args[0], args[1]));
                            break;
                        case "op_GreaterThan":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Gt, args[0], args[1]));
                            break;
                        case "op_GreaterThanOrEqual":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Ge, args[0], args[1]));
                            break;
                        case "op_BitwiseAnd":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.And, args[0], args[1]));
                            break;
                        case "op_BitwiseOr":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Or, args[0], args[1]));
                            break;
                        case "op_ExclusiveOr":
                            stack.Push(new BinaryOp(rtype, BinaryOp.OpCode.Xor, args[0], args[1]));
                            break;
                        case "op_OnesComplement":
                            stack.Push(new UnaryOp(UnaryOp.OpCode.Not, args[0]));
                            break;
                        default:
                            if (mdef.HasThis && name.StartsWith("get_")) {
                                // Note: this assumes that the property getter is a valid
                                // C-style field reference.
                                stack.Push(new FieldRef(rtype, name.Substring(4), args[0]));
                            }
                            else if (mdef.HasThis && name.StartsWith("set_")) {
                                // Note: this assumes that the property setter is a valid
                                // C-style field reference.
                                this.builder.Append("(*");
                                args[0].Accept(this.printer);
                                this.builder.AppendFormat(").{0} = ", name.Substring(4));
                                args[1].Accept(this.printer);
                                this.builder.AppendLine(";");
                            }
                            else {
                                stack.Push(new Call(rtype, name, args));
                            }
                            break;
                        }
                    }
                    break;
                }
                case Code.Br:
                case Code.Br_S:
                    this.builder.AppendFormat("goto __L{0:x4};\n", (instr.Operand as Instruction).Offset);
                    break;
                case Code.Brfalse:
                case Code.Brfalse_S:
                case Code.Brtrue:
                case Code.Brtrue_S: {
                    var b = stack.Pop();
                    EmitUnaryBranch(instr, b);
                    break;
                }
                case Code.Beq:
                case Code.Beq_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    EmitBinaryBranch(instr, " == ", u, v);
                    break;
                }
                case Code.Bne_Un:
                case Code.Bne_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    EmitBinaryBranch(instr, " != ", u, v);
                    break;
                }
                case Code.Blt:
                case Code.Blt_S:
                case Code.Blt_Un:
                case Code.Blt_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    EmitBinaryBranch(instr, " < ", u, v);
                    break;
                }
                case Code.Ble:
                case Code.Ble_S:
                case Code.Ble_Un:
                case Code.Ble_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    EmitBinaryBranch(instr, " <= ", u, v);
                    break;
                }
                case Code.Bgt:
                case Code.Bgt_S:
                case Code.Bgt_Un:
                case Code.Bgt_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    EmitBinaryBranch(instr, " > ", u, v);
                    break;
                }
                case Code.Bge:
                case Code.Bge_S:
                case Code.Bge_Un:
                case Code.Bge_Un_S: {
                    var v = stack.Pop();
                    var u = stack.Pop();
                    EmitBinaryBranch(instr, " >= ", u, v);
                    break;
                }
                case Code.Ret:
                    this.builder.Append("return");
                    if (this.method.ReturnType.FullName != "System.Void") {
                        this.builder.Append(" ");
                        stack.Pop().Accept(this.printer);
                    }
                    this.builder.AppendLine(";");
                    break;
                default:
                    throw new CompilerException(String.Format("Unsupported opcode: {0}.", instr.OpCode));
//                    break;
                }
            }
            this.builder.AppendLine("}");
        }

        private void Run()
        {
            EmitHeader();
            EmitBody();
        }

        public static string EmitKernel(string assembly, string type, string method)
        {
            var resolver = new DotNetCoreAssemblyResolver();
            using (var _assembly = resolver.Resolve(assembly))
            using (var _module = _assembly.MainModule) {
                // ModuleDefinition _module = ModuleDefinition.ReadModule(module, new ReaderParameters { AssemblyResolver = new DotNetCoreAssemblyResolver() });
                TypeDefinition _type = _module.Types.Single(ti => ti.FullName == type);
                MethodDefinition _method = _type.Methods.Single(mi => mi.Name == method);
                return EmitKernel(/*_module, _type,*/ _method);
            }
        }

        public static string EmitKernel(MethodDefinition method)
        {
            ClCompiler compiler = new ClCompiler(method);
            compiler.Run();
            return compiler.builder.ToString();
        }
    }
}
