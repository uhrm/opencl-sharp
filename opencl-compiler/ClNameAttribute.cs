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
}
