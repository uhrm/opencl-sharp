using System;

namespace OpenCl
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class ClNameAttribute : System.Attribute
    {
        private string name;

        public ClNameAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Parameter)]
    public class GlobalAttribute : System.Attribute
    {
    }

    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class KernelAttribute : System.Attribute
    {
    }

    // [System.AttributeUsage(System.AttributeTargets.Method)]
    // public class BuiltInAttribute : System.Attribute
    // {
    //     public enum Symbol
    //     {
    //         NumWorkgroups = 24,
    //         WorkgroupSize = 25,
    //         WorkgroupId = 26,
    //         LocalInvocationId = 27,
    //         GlobalInvocationId = 28,
    //         LocalInvocationIndex = 29,
    //         WorkDim = 30,
    //         GlobalSize = 31,
    //         EnqueuedWorkgroupSize = 32,
    //         GlobalOffset = 33,
    //         GlobalLinearId = 34,
    //         SubgroupSize = 35,
    //         SubgroupMaxSize = 36,
    //         NumSubgroups = 37,
    //         NumEnqueuedSubgroups = 38,
    //         SubgroupId = 39,
    //         SubgroupLocalInvocationId = 40,
    //     }

    //     private Symbol symbol;

    //     public BuiltInAttribute(Symbol symbol)
    //     {
    //         this.symbol = symbol;
    //     }

    //     public Symbol Sym
    //     {
    //         get { return this.symbol; }
    //     }
    // }
}
