using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.Pluralsight
{
    public class Result<T>
    {
        public T Value { get; set; }
        public string Remarks { get; set; }
    }
}
