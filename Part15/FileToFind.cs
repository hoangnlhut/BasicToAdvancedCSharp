using Part15.AbstractionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part15
{
    public class FileToFind
    {
        public required string PathFile { get; set; }
        public required string SearchedString { get; set; }
        public string ParamsForFind { get; set; } = string.Empty;
        public List<string> ContentOriginal { get; set; } = new List<string>();
        public List<string> ContentResult { get; set; } = new List<string>();

        public void GetContent()
        {
            //check file existed
            if(!File.Exists(PathFile))
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

        public void GetContentWithSearchedTextFilterParams()
        {
            ContentResult = LastContentFactory.GetLastContentFactory(this);
        }

        public void PrintLastResult()
        {
            foreach (var item in ContentResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}
