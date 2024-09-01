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
        public const string pattern = @"^find(\s+(/[vcnio]?))*(\s+""[^""]*"")(\s+([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([\w*]+\.[\w*]+|\*))?(\s+([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([\w*]+\.[\w*]+|\*))*$";
        public void Find()
        {
            Console.WriteLine("Find String As Window Command");
            string? input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                ProduceResult(input);
                input = Console.ReadLine();
            }
            Console.WriteLine("Display help at the command prompt");
        }


        public void ProduceResult(string input)
        {
            List<FileToFind> files = SplitInputToGetFile(input);
            foreach (FileToFind file in files)
            {
                file.GetContent();
                file.GetContentWithSearchedTextFilterParams();
                file.PrintLastResult();
            }
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
        public List<FileToFind> SplitInputToGetFile(string input)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            var match = regex.Match(input);
            var stringSearch = match?.Groups[3]?.Value.Replace("\"", "");
            var pathFile = match?.Groups[4]?.Value;
            string paramsS = "";
            foreach (var item in match?.Groups[2]?.Captures?.ToList())
            {
                paramsS += item?.Value.Trim() + " ";
            }

            if (string.IsNullOrEmpty(stringSearch) || string.IsNullOrEmpty(pathFile)) { new ArgumentNullException(); }

            List<string> listPathFile = ProcessFilePath(pathFile.Trim());

            List<FileToFind> listFile = new List<FileToFind>();
            foreach (var processedPathFile in listPathFile)
            {
                listFile.Add(new FileToFind() { PathFile = processedPathFile.Trim(), SearchedString = stringSearch.Trim(), ParamsForFind = paramsS.Trim() });
            }

            return listFile;
        }

        private List<string> ProcessFilePath(string pathFile)
        {
            if(pathFile.Contains("*"))
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
