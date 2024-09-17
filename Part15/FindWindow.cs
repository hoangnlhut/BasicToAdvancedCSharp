using Part15.Decoration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part15
{
    public class FindWindow
    {
        public const string pattern = @"^find(\s+(/[vcnio]?|\s*""[^""]*""|\s*([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([\w*]+\.[\w*]+|\*)))+";
        public void Find()
        {
            Console.WriteLine("Find String As Window Command");
            // không mở rộng được: đang fix cứng chỉ từ việc đọc từ màn hình
            // --> triển khai abstraction / interface: có thể đọc từ nhiều nguồn: đọc từ màn hình, đọc từ file,.....
            string? input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                ProduceResult(input, new ConsoleFindComponent()); 
                input = Console.ReadLine();
            }
            Console.WriteLine("Display help at the command prompt");
        }


        public List<string> ProduceResult(string input, IProcessorFindComponent component)
        {
            List<string> totalResult = new List<string>();

            List<FindWantedFile> files = SplitInputToGetFile(input, component);

            foreach (FindWantedFile file in files)
            {
                totalResult.AddRange(file.Process());
            }

            return totalResult;
        }

        /// <summary>
        /// get 3 part of string:
        /// result[0]: params
        /// result[1]: string to find in text
        /// result[2]: text file / files
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FindWantedFile> SplitInputToGetFile(string input, IProcessorFindComponent component)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = regex.Match(input);
            var group = match?.Groups[2].Captures;
            string stringSearch = string.Empty;
            string pathFile = string.Empty;
            string paramsS = string.Empty;
            foreach (Capture groupItem in group)
            {
                if (
                    groupItem.Value.Contains(Constants.PathFileCharacter.Wildcard)
                    || groupItem.Value.Contains(Constants.PathFileCharacter.Path)
                    || groupItem.Value.Contains(Constants.PathFileCharacter.FileText)
                    )
                {
                    pathFile = groupItem.Value;
                }
                else if (
                    groupItem.Value.Contains(Constants.ParamsList.V)
                    || groupItem.Value.Contains(Constants.ParamsList.C)
                    || groupItem.Value.Contains(Constants.ParamsList.N)
                    || groupItem.Value.Contains(Constants.ParamsList.I)
                    )
                {
                    paramsS += groupItem?.Value + " ";
                }
                else
                {
                    stringSearch = groupItem?.Value?.Replace("\"", "").Trim();
                }
            }

            if (string.IsNullOrEmpty(stringSearch) || string.IsNullOrEmpty(pathFile)) { new ArgumentNullException(); }

            List<string> listPathFile = ProcessFilePath(pathFile.Trim());

            List<FindWantedFile> listFile = new List<FindWantedFile>();
            foreach (var processedPathFile in listPathFile)
            {
                listFile.Add(new FindWantedFile(component) { PathFile = processedPathFile.Trim(), SearchedString = stringSearch.Trim(), ParamsForFind = paramsS.Trim() });
            }

            return listFile;
        }

        private List<string> ProcessFilePath(string pathFile)
        {
            if (pathFile.Contains("*"))
            {
                var dirParentPathName = new DirectoryInfo(pathFile)?.Parent?.FullName;
                if(string.IsNullOrEmpty(dirParentPathName)) { throw new ArgumentNullException(); }

                var dir = new DirectoryInfo(dirParentPathName);
                var filesInDirectory = dir.GetFiles();
                var listFile = new List<string>();
                foreach (var file in filesInDirectory) 
                {
                    listFile.Add($"{dir.FullName}\\{file.Name}");
                }
                return listFile;
            }   
            
            return new List<string> { pathFile };
        }
    }
}
