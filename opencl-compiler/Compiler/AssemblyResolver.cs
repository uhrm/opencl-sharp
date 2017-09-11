using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Mono.Cecil;

namespace OpenCl.Compiler
{
    class DotNetCoreAssemblyResolver : IAssemblyResolver
    {
        private static readonly string BaseDirectory = System.AppContext.BaseDirectory;
        private static readonly string RuntimeDirectory = Path.GetDirectoryName(typeof(object).Assembly.Location);

        private readonly Dictionary<string,AssemblyDefinition> libraries;

        public DotNetCoreAssemblyResolver()
        {
             this.libraries = new Dictionary<string,AssemblyDefinition>();
        }

        public virtual AssemblyDefinition Resolve(string fullName)
        {
            return Resolve(fullName, new ReaderParameters() { AssemblyResolver = this });
        }

        public virtual AssemblyDefinition Resolve(string fullName, ReaderParameters parameters)
        {
            if (fullName == null) {
                throw new ArgumentNullException("fullName");
            }
            return Resolve(AssemblyNameReference.Parse(fullName), parameters);
        }

        // IAssemblyResolver API

        public AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            return Resolve(name, new ReaderParameters() { AssemblyResolver = this });
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
        {
            if (name == null) {
                throw new ArgumentNullException("name");
            }
            AssemblyDefinition def;
            if (!this.libraries.TryGetValue(name.Name, out def)) {
                var path = Path.Combine(BaseDirectory, $"{name.Name}.dll");
                if (File.Exists(path)) {
                    def = AssemblyDefinition.ReadAssembly(path, parameters);
                    this.libraries.Add(name.Name, def);
                }
                else {
                    path = Path.Combine(RuntimeDirectory, $"{name.Name}.dll");
                    if (File.Exists(path)) {
                        def = AssemblyDefinition.ReadAssembly(path, parameters);
                        this.libraries.Add(name.Name, def);
                    }
                    else {
                        path = $"{name.Name}.dll";
                        if (File.Exists(path)) {
                            def = AssemblyDefinition.ReadAssembly(path, parameters);
                            this.libraries.Add(name.Name, def);
                        }
                    }
                }
            }
            return def;
        }

        // IDisposable API

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) {
                return;
            }
            foreach (var def in this.libraries.Values) {
                def.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}