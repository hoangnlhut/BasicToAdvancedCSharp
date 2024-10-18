using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.Basics
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CustomAttribute : Attribute
    {
        public string Description { get; }
        public CustomAttribute(string description)
        {
            Description = description;
        }
    }
}
