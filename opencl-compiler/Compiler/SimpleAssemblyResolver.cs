
using System;
using System.Collections.Generic;

namespace Mono.Cecil
{
    class SimpleAssemblyResolver : IAssemblyResolver
    {
        Dictionary<string,AssemblyDefinition> libraries;

        public SimpleAssemblyResolver()
        {
             this.libraries = new Dictionary<string,AssemblyDefinition>();
        }

        public virtual AssemblyDefinition Resolve(string fullName)
        {
            return Resolve(fullName, new ReaderParameters());
        }

        public virtual AssemblyDefinition Resolve(string fullName, ReaderParameters parameters)
        {
            if (fullName == null)
                throw new ArgumentNullException("fullName");

            return Resolve(AssemblyNameReference.Parse(fullName), parameters);
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            return Resolve(name, new ReaderParameters());
        }

        public AssemblyDefinition Resolve(AssemblyNameReference nameRef, ReaderParameters parameters)
        {
            if (nameRef == null) {
                throw new ArgumentNullException("nameRef");
            }

            AssemblyDefinition asm;
            if (!this.libraries.TryGetValue(nameRef.Name, out asm)) {
                asm = AssemblyDefinition.ReadAssembly(nameRef.Name+".dll", new ReaderParameters() { AssemblyResolver = this });
                this.libraries.Add(nameRef.Name, asm);

            }
            return asm;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) {
                return;
            }
            foreach (var asm in this.libraries.Values) {
                asm.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}