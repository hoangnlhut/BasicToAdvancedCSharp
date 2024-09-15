using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part15.Decoration
{
    public interface IProcessorFindComponent
    {
        IEnumerable<string> Save(List<string> content);
    }
}
