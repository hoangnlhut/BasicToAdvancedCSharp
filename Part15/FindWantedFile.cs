using Part15.AbstractionFactory;
using Part15.Decoration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part15
{
    public class FindWantedFile : BaseDecorator
    {
        public FindWantedFile(IProcessorFindComponent processorFindComponent) : base(processorFindComponent)
        {
        }

        public required string PathFile { get; set; }
        public List<string> ContentOriginal { get; set; } = new List<string>();
        public List<string> ContentResult { get; set; } = new List<string>();

        public required string SearchedString { get; set; }
        public string ParamsForFind { get; set; } = string.Empty;

        private void GetContent()
        {
            //check file existed

            // chưa bao phủ cây nếu không tìm thấy path thì là tìm kiếm nhập trên màn hình
            if (!File.Exists(PathFile))
            {
                Console.WriteLine($"ERROR: file {PathFile} does not exist");
            }

            // read file
            using StreamReader inputStreamReader = File.OpenText(PathFile);
            var originalContent = new List<string>();

            while(!inputStreamReader.EndOfStream)
            {
                var eachLine = inputStreamReader.ReadLine();
                originalContent.Add(eachLine);
            }
            
            ContentOriginal = originalContent;
        }

        private void GetContentWithSearchedTextFilterParams()
        {
            var iContent = LastContentFactory.GetLastContentFactory(this.ParamsForFind);
            ContentResult = iContent.GetLastContent(this);
        }

        public IEnumerable<string> Save(List<string> content)
        {
            return base.Save(content);
        }

        public IEnumerable<string> Process()
        {
            GetContent();
            GetContentWithSearchedTextFilterParams();
            return Save(this.ContentResult);
        }
    }
}
