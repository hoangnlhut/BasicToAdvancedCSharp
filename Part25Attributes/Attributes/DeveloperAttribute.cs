using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part25Attributes.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class DeveloperAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Level { get; private set; }

        public DeveloperAttribute(string name, string level)
        {
            Name = name;
            Level = level;
        }

       
    }
}
