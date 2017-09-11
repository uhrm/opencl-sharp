using System;
using System.Collections.Generic;

namespace OpenCl.Compiler
{
    internal abstract class AstNode
    {
        private CliType type;

        protected AstNode(CliType type)
        {
            if (type == null) {
                throw new ArgumentNullException("type");
            }
            this.type = type;
        }

        public CliType CliType
        {
            get { return this.type; }
        }

        protected internal abstract void Accept(AstVisitor visitor);
    }

    internal class Const<T> : AstNode
    {
        private readonly T val;

        public Const(CliType type, T val) : base(type)
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
    
    internal class ParamRef : AstNode
    {
        private readonly string name;
        
        public ParamRef(CliType type, string name) : base(type)
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

    internal class VarRef : AstNode
    {
        private readonly int idx;
        private readonly bool tmp;

        public VarRef(CliType type, int idx) : this(type, idx, false) { }

        public VarRef(CliType type, int idx, bool tmp) : base(type)
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

    internal class ElemRef : AstNode
    {
        private readonly AstNode array;
        private readonly AstNode index;

        public ElemRef(CliType type, AstNode arr, AstNode idx) : base(type)
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

        public FieldRef(CliType type, string name, AstNode node) : base(type)
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

    internal class ParamAddr : AstNode
    {
        private readonly string name;

        public ParamAddr(CliPointerType type, string name) : base(type)
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

    internal class VarAddr : AstNode
    {
        private readonly int idx;

        public VarAddr(CliPointerType type, int idx) : base(type)
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

        public ElemAddr(CliType type, AstNode arr, AstNode idx) : base(type)
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

        private static Type DerefPointer(CliType type)
        {
            var ptr = type as CliPointerType;
            if (ptr == null) {
                throw new ArgumentException(String.Format("Unsupported type: expected CliPointerType but found {0} ({1}).", type.Code, type.SystemType));
            }
            return ptr.Element;
        }

        public LoadAddr(AstNode addr) : base(CliType.FromType(DerefPointer(addr.CliType)))
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

        public LocAlloc(AstNode size) : base(new CliPointerType(typeof(IntPtr*)))
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

    internal class Conv : AstNode
    {
        private readonly AstNode val;

        public Conv(Type type, AstNode val) : base(CliType.FromType(type))
        {
            this.val = val;
        }

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.Enter(this);
            this.val.Accept(visitor);
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

        public BinaryOp(CliType type, BinaryOpCode code, AstNode left, AstNode rght) : base(type)
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

        public UnaryOp(UnaryOpCode code, AstNode node) : base(node.CliType)
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
        private readonly IReadOnlyList<AstNode> args;

        public Call(CliType type, string name, AstNode[] args) : base(type)
        {
            this.name = name;
            var a = new AstNode[args.Length];
            Array.Copy(args, a, args.Length);
            this.args = a;
        }

        public string Name
        {
            get { return this.name; }
        }

        public IReadOnlyList<AstNode> Argument
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
        
        public virtual void Visit(ParamRef node)
        {
        }

        public virtual void Visit(VarRef node)
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

        public virtual void Visit(ParamAddr node)
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

        public virtual void Enter(Conv node)
        {
        }

        public virtual void Exit(Conv node)
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
