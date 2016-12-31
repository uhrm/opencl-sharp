using System;

namespace OpenCl.Compiler
{
    public class CompilerException : System.Exception
    {
        public CompilerException(string message) : base(message) { }
        public CompilerException(string message, Exception inner) : base(message, inner) { }
    }
}
