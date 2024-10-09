using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part27DependencyInjection
{
    public class Class1(IMessageWriter messageWriter)
    {
        public void PrintMessageWriter()
        {
            messageWriter.Write("Print message by message writer");
        }
    }
}
