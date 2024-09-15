using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part15.Decoration
{
    public class BaseDecorator : IProcessorFindComponent
    {
        private readonly IProcessorFindComponent _processorFindComponent;
        public BaseDecorator(IProcessorFindComponent processorFindComponent)
        {
            _processorFindComponent = processorFindComponent;
        }
        public IEnumerable<string> Save(List<string> content)
        {
            return _processorFindComponent.Save(content);
        }
    }
}
