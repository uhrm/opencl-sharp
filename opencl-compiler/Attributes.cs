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
}
