using System;
using System.Collections.Generic;
using System.IO;

using Mono.Cecil;

namespace OpenCl.Compiler
{
    class DotNetCoreAssemblyResolver : IAssemblyResolver
    {
        private static readonly IReadOnlyList<string> Paths = new string[] {
            System.AppContext.BaseDirectory,
            Path.GetDirectoryName(typeof(object).Assembly.Location),
            Directory.GetCurrentDirectory()
        };

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
            if (this.libraries.TryGetValue(name.Name, out AssemblyDefinition def)) {
                return def;
            }
            string module = $"{name.Name}.dll";
            foreach (var path in Paths) {
                var filename = Path.Combine(path, module);
                if (File.Exists(filename)) {
                    def = AssemblyDefinition.ReadAssembly(filename, parameters);
                    this.libraries.Add(name.Name, def);
                    return def;
                }
            }
            throw new AssemblyResolutionException(name);
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