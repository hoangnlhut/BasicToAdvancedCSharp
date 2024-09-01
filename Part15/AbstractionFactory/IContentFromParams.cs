using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part15.AbstractionFactory
{
    public interface IContentFromParams
    {
        List<string> GetLastContent(FileToFind file);
    }
}
