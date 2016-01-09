using System;
using Mono.Cecil;
using System.Collections.ObjectModel;

namespace OpenCl.Ast
{
    internal abstract class AstNode
    {
        private TypeReference type;

        protected AstNode(TypeReference type)
        {
            this.type = type;
        }

        public TypeReference Type
        {
            get { return this.type; }
        }

        protected internal abstract void Accept(AstVisitor visitor);
    }

    internal class Const<T> : AstNode
    {
        private readonly T val;

        public Const(TypeReference type, T val) : base(type)
        {
            this.val = val;
        }

        public T Value
        {
            get { return this.val; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    internal class VarRef : AstNode
    {
        private readonly int idx;
        private readonly bool tmp;

        public VarRef(TypeReference type, int idx) : this(type, idx, false) { }

        public VarRef(TypeReference type, int idx, bool tmp) : base(type)
        {
            this.idx = idx;
            this.tmp = tmp;
        }

        public int Index
        {
            get { return this.idx; }
        }

        public bool IsTemp
        {
            get { return this.tmp; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    internal class ParamRef : AstNode
    {
        private readonly string name;

        public ParamRef(TypeReference type, string name) : base(type)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    internal class ElemRef : AstNode
    {
        private readonly AstNode array;
        private readonly AstNode index;

        public ElemRef(TypeReference type, AstNode arr, AstNode idx) : base(type)
        {
            this.array = arr;
            this.index = idx;
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.array.Accept(visitor);
            visitor.ExitArray(this);
            this.index.Accept(visitor);
            visitor.ExitIndex(this);
            visitor.Exit(this);
        }
    }

    internal class FieldRef : AstNode
    {
        private readonly string name;
        private readonly AstNode node;

        public FieldRef(TypeReference type, string name, AstNode node) : base(type)
        {
            this.name = name;
            this.node = node;
        }

        public string Name
        {
            get { return this.name; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.node.Accept(visitor);
            visitor.Exit(this);
        }
    }

    internal class VarAddr : AstNode
    {
        private readonly int idx;

        public VarAddr(TypeReference type, int idx) : base(type)
        {
            this.idx = idx;
        }

        public int Index
        {
            get { return this.idx; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    internal class ElemAddr : AstNode
    {
        private readonly AstNode array;
        private readonly AstNode index;

        public ElemAddr(TypeReference type, AstNode arr, AstNode idx) : base(type)
        {
            this.array = arr;
            this.index = idx;
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.array.Accept(visitor);
            visitor.ExitArray(this);
            this.index.Accept(visitor);
            visitor.ExitIndex(this);
            visitor.Exit(this);
        }
    }

    internal class LoadAddr : AstNode
    {
        private readonly AstNode addr;

        public LoadAddr(AstNode addr) : base((addr.Type as PointerType).ElementType)
        {
            this.addr = addr;
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.addr.Accept(visitor);
            visitor.Exit(this);
        }
    }

    internal class LocAlloc : AstNode
    {
        private readonly AstNode size;

        public LocAlloc(TypeReference type, AstNode size) : base(type)
        {
            this.size = size;
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.size.Accept(visitor);
            visitor.Exit(this);
        }
    }

    internal enum BinaryOpCode
    {
        Add,
        Sub,
        Mul,
        Div,
        And,
        Or,
        Xor,
        Shl,
        Shr,
        Eq,
        Neq,
        Lt,
        Le,
        Gt,
        Ge,
    }

    internal class BinaryOp : AstNode
    {
        private readonly BinaryOpCode code;
        private readonly AstNode left;
        private readonly AstNode rght;

        public BinaryOp(TypeReference type, BinaryOpCode code, AstNode left, AstNode rght) : base(type)
        {
            this.code = code;
            this.left = left;
            this.rght = rght;
        }

        public BinaryOpCode Code
        {
            get { return this.code; }
        }

        public AstNode Left
        {
            get { return this.left; }
        }

        public AstNode Right
        {
            get { return this.rght; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.left.Accept(visitor);
            visitor.ExitLeft(this);
            this.rght.Accept(visitor);
            visitor.ExitRight(this);
            visitor.Exit(this);
        }
    }

    internal enum UnaryOpCode
    {
        Neg,
        Not,
    }

    internal class UnaryOp : AstNode
    {
        private readonly UnaryOpCode code;
        private readonly AstNode node;

        public UnaryOp(UnaryOpCode code, AstNode node) : this(node.Type, code, node) { }

        public UnaryOp(TypeReference type, UnaryOpCode code, AstNode node) : base(type)
        {
            this.code = code;
            this.node = node;
        }

        public UnaryOpCode Code
        {
            get { return this.code; }
        }

        public AstNode Node
        {
            get { return this.node; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.node.Accept(visitor);
            visitor.Exit(this);
        }
    }

    internal class Call : AstNode
    {
//        private readonly MethodReference method;
        private readonly string name;
        private readonly ReadOnlyCollection<AstNode> args;

        public Call(TypeReference type, string name, AstNode[] args) : base(type)
        {
            this.name = name;
            var a = new AstNode[args.Length];
            Array.Copy(args, a, args.Length);
            this.args = Array.AsReadOnly(a);
        }

        public string Name
        {
            get { return this.name; }
        }

        public ReadOnlyCollection<AstNode> Argument
        {
            get { return this.args; }
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            var nargs = this.args.Count;
            for (var i=0; i<nargs; i++) {
                this.args[i].Accept(visitor);
                visitor.ExitArgument(this, i);
            }
            visitor.Exit(this);
        }
    }

    internal abstract class AstVisitor
    {
        public virtual void Visit<T>(Const<T> node)
        {
        }

        public virtual void Visit(VarRef node)
        {
        }

        public virtual void Visit(ParamRef node)
        {
        }

        public virtual void Enter(ElemRef node)
        {
        }

        public virtual void ExitArray(ElemRef node)
        {
        }

        public virtual void ExitIndex(ElemRef node)
        {
        }

        public virtual void Exit(ElemRef node)
        {
        }

        public virtual void Enter(FieldRef node)
        {
        }

        public virtual void Exit(FieldRef node)
        {
        }

        public virtual void Visit(VarAddr node)
        {
        }

        public virtual void Enter(ElemAddr node)
        {
        }

        public virtual void ExitArray(ElemAddr node)
        {
        }

        public virtual void ExitIndex(ElemAddr node)
        {
        }

        public virtual void Exit(ElemAddr node)
        {
        }

        public virtual void Enter(LoadAddr node)
        {
        }

        public virtual void Exit(LoadAddr node)
        {
        }

        public virtual void Enter(LocAlloc node)
        {
        }

        public virtual void Exit(LocAlloc node)
        {
        }

        public virtual void Enter(BinaryOp node)
        {
        }

        public virtual void ExitLeft(BinaryOp node)
        {
        }

        public virtual void ExitRight(BinaryOp node)
        {
        }

        public virtual void Exit(BinaryOp node)
        {
        }

        public virtual void Enter(UnaryOp node)
        {
        }

        public virtual void Exit(UnaryOp node)
        {
        }

        public virtual void Enter(Call node)
        {
        }

        public virtual void ExitArgument(Call node, int idx)
        {
        }

        public virtual void Exit(Call node)
        {
        }
    }

}
