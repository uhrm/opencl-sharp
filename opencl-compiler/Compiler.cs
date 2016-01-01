using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using OpenCl.Ast;

namespace OpenCl
{
    public class Compiler
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
                this.builder.AppendFormat("__V{0}", node.Index);
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
                case BinaryOpCode.Add:
                    op = "+";
                    break;
                case BinaryOpCode.Sub:
                    op = "-";
                    break;
                case BinaryOpCode.Mul:
                    op = "*";
                    break;
                case BinaryOpCode.Div:
                    op = "/";
                    break;
                case BinaryOpCode.And:
                    op = "&";
                    break;
                case BinaryOpCode.Or:
                    op = "|";
                    break;
                case BinaryOpCode.Xor:
                    op = "^";
                    break;
                case BinaryOpCode.Shl:
                    op = "<<";
                    break;
                case BinaryOpCode.Shr:
                    op = ">>";
                    break;
                case BinaryOpCode.Eq:
                    op = "==";
                    break;
                case BinaryOpCode.Neq:
                    op = "!=";
                    break;
                case BinaryOpCode.Lt:
                    op = "<";
                    break;
                case BinaryOpCode.Le:
                    op = "<=";
                    break;
                case BinaryOpCode.Gt:
                    op = ">";
                    break;
                case BinaryOpCode.Ge:
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
                case UnaryOpCode.Neg:
                    op = "-";
                    break;
                case UnaryOpCode.Not:
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

            { "System.Int8",     "char" },
            { "System.UInt8",    "uchar" },
            { "System.Int16",    "short" },
            { "System.UInt16",   "ushort" },
            { "System.Int32",    "int" },
            { "System.UInt32",   "uint" },
            { "System.Int64",    "long" },
            { "System.UInt64",   "ulong" },
            { "System.Single",   "float" },
            { "System.Double",   "double" },

            { "System.String",   "char*" },

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

            { "System.Int8[]",     "char*" },
            { "System.UInt8[]",    "uchar*" },
            { "System.Int16[]",    "short*" },
            { "System.UInt16[]",   "ushort*" },
            { "System.Int32[]",    "int*" },
            { "System.UInt32[]",   "uint*" },
            { "System.Int64[]",    "long*" },
            { "System.UInt64[]",   "ulong*" },
            { "System.Single[]",   "float*" },
            { "System.Double[]",   "double*" },

            { "System.String[]",   "char**" },

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
        };

        private readonly MethodDefinition method;
        private readonly StringBuilder builder;

        private readonly ClExprVisitor printer;

        private readonly Dictionary<int,BranchType> labels;

        private Compiler(MethodDefinition method)
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
            MethodBody body = this.method.Body;
            var vars = body.Variables;
            foreach (var v in vars) {
                this.builder.AppendFormat("{0} __V{1};\n", typeMap[v.VariableType.FullName], v.Index);
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
                case Code.Ldc_I4_0:
                    stack.Push(new Const<int>(0));
                    break;
                case Code.Ldc_I4_1:
                    stack.Push(new Const<int>(1));
                    break;
                case Code.Ldc_I4_2:
                    stack.Push(new Const<int>(2));
                    break;
                case Code.Ldc_I4_3:
                    stack.Push(new Const<int>(3));
                    break;
                case Code.Ldc_I4_4:
                    stack.Push(new Const<int>(4));
                    break;
                case Code.Ldc_I4_5:
                    stack.Push(new Const<int>(5));
                    break;
                case Code.Ldc_I4_6:
                    stack.Push(new Const<int>(6));
                    break;
                case Code.Ldc_I4_7:
                    stack.Push(new Const<int>(7));
                    break;
                case Code.Ldc_I4_8:
                    stack.Push(new Const<int>(8));
                    break;
                case Code.Ldc_I4_M1:
                    stack.Push(new Const<int>(-1));
                    break;
                case Code.Ldc_I4:
                    stack.Push(new Const<int>((int)instr.Operand));
                    break;
                case Code.Ldc_I4_S:
                    stack.Push(new Const<int>((sbyte)instr.Operand));
                    break;
                case Code.Ldarg_0:
                    stack.Push(new ParamRef(this.method.Parameters[0].Name));
                    break;
                case Code.Ldarg_1:
                    stack.Push(new ParamRef(this.method.Parameters[1].Name));
                    break;
                case Code.Ldarg_2:
                    stack.Push(new ParamRef(this.method.Parameters[2].Name));
                    break;
                case Code.Ldarg_3:
                    stack.Push(new ParamRef(this.method.Parameters[3].Name));
                    break;
                case Code.Ldarg:
                    stack.Push(new ParamRef((instr.Operand as ParameterDefinition).Name));
                    break;
                case Code.Ldarg_S:
                    stack.Push(new ParamRef((instr.Operand as ParameterDefinition).Name));
                    break;
                case Code.Ldloc_0:
                    stack.Push(new VarRef(0));
                    break;
                case Code.Ldloc_1:
                    stack.Push(new VarRef(1));
                    break;
                case Code.Ldloc_2:
                    stack.Push(new VarRef(2));
                    break;
                case Code.Ldloc_3:
                    stack.Push(new VarRef(3));
                    break;
                case Code.Ldloc:
                case Code.Ldloc_S:
                    stack.Push(new VarRef((instr.Operand as VariableDefinition).Index));
                    break;
                case Code.Ldelem_Any:
                case Code.Ldelem_I:
                case Code.Ldelem_I1:
                case Code.Ldelem_I2:
                case Code.Ldelem_I4:
                case Code.Ldelem_I8:
                case Code.Ldelem_U1:
                case Code.Ldelem_U2:
                case Code.Ldelem_U4:
                case Code.Ldelem_R4:
                case Code.Ldelem_R8: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemRef(arr, idx));
                    break;
                }
                case Code.Ldobj: {
                    var ptr = stack.Pop();
                    stack.Push(new LoadAddr(ptr));
                    break;
                }
                case Code.Ldloca:
                case Code.Ldloca_S:
                    stack.Push(new VarAddr((instr.Operand as VariableDefinition).Index));
                    break;
                case Code.Ldelema: {
                    var idx = stack.Pop();
                    var arr = stack.Pop();
                    stack.Push(new ElemAddr(arr, idx));
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
                case Code.Add:
                /*case Code.Add_Ovf:
                case Code.Add_Ovf_Un:*/ {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Add, l, r));
                    break;
                }
                case Code.Sub:
                /*case Code.Sub_Ovf:
                case Code.Sub_Ovf_Un:*/ {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Sub, l, r));
                    break;
                }
                case Code.Mul:
                /*case Code.Mul_Ovf:
                case Code.Mul_Ovf_Un:*/ {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Mul, l, r));
                    break;
                }
                case Code.Div:
                case Code.Div_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Div, l, r));
                    break;
                }
                case Code.And: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.And, l, r));
                    break;
                }
                case Code.Or: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Or, l, r));
                    break;
                }
                case Code.Xor: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Xor, l, r));
                    break;
                }
                case Code.Shl: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Shl, l, r));
                    break;
                }
                case Code.Shr:
                case Code.Shr_Un: {
                    var r = stack.Pop();
                    var l = stack.Pop();
                    stack.Push(new BinaryOp(BinaryOpCode.Shr, l, r));
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
                                this.builder.AppendFormat(") = ({0}){{ ", tdef.Name);
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
                            switch (name)
                            {
                            case "op_Addition":
                                stack.Push(new BinaryOp(BinaryOpCode.Add, args[0], args[1]));
                                break;
                            case "op_Subtraction":
                                stack.Push(new BinaryOp(BinaryOpCode.Sub, args[0], args[1]));
                                break;
                            case "op_Multiply":
                                stack.Push(new BinaryOp(BinaryOpCode.Mul, args[0], args[1]));
                                break;
                            case "op_Division":
                                stack.Push(new BinaryOp(BinaryOpCode.Div, args[0], args[1]));
                                break;
                            case "op_Equality":
                                stack.Push(new BinaryOp(BinaryOpCode.Eq, args[0], args[1]));
                                break;
                            case "op_Inequality":
                                stack.Push(new BinaryOp(BinaryOpCode.Neq, args[0], args[1]));
                                break;
                            case "op_LessThan":
                                stack.Push(new BinaryOp(BinaryOpCode.Lt, args[0], args[1]));
                                break;
                            case "op_LessThanOrEqual":
                                stack.Push(new BinaryOp(BinaryOpCode.Le, args[0], args[1]));
                                break;
                            case "op_GreaterThan":
                                stack.Push(new BinaryOp(BinaryOpCode.Gt, args[0], args[1]));
                                break;
                            case "op_GreaterThanOrEqual":
                                stack.Push(new BinaryOp(BinaryOpCode.Ge, args[0], args[1]));
                                break;
                            case "op_BitwiseAnd":
                                stack.Push(new BinaryOp(BinaryOpCode.And, args[0], args[1]));
                                break;
                            case "op_BitwiseOr":
                                stack.Push(new BinaryOp(BinaryOpCode.Or, args[0], args[1]));
                                break;
                            case "op_ExclusiveOr":
                                stack.Push(new BinaryOp(BinaryOpCode.Xor, args[0], args[1]));
                                break;
                            case "op_OnesComplement":
                                stack.Push(new UnaryOp(UnaryOpCode.Not, args[0]));
                                break;
                            default:
                                if (mdef.HasThis && name.StartsWith("get_")) {
                                    // Note: this assumes that the property getter is a valid
                                    // C-style field reference.
                                    stack.Push(new FieldRef(name.Substring(4), args[0]));
                                }
                                else {
                                    stack.Push(new Call(name, args));
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
                    throw new ApplicationException(String.Format("Unsupported opcode: {0}.", instr.OpCode));
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

        public static string EmitKernel(string module, string type, string method)
        {
            ModuleDefinition _module = ModuleDefinition.ReadModule(module);
            TypeDefinition _type = _module.Types.Single(ti => ti.FullName == type);
            MethodDefinition _method = _type.Methods.Single(mi => mi.Name == method);
            return EmitKernel(_method);
        }

        public static string EmitKernel(MethodDefinition method)
        {
            Compiler compiler = new Compiler(method);
            compiler.Run();
            return compiler.builder.ToString();
        }
    }
}
