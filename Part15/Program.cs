using System.Text.RegularExpressions;

namespace Part15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindWindow findWindow = new FindWindow();
            findWindow.Find();
            //TryToTestRegex();
        }

        private static void TryToTestRegex()
        {
            //string pattern = @"^find(\s+(/[vcnio]?))*(\s+""[^""]*"")(\s+([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([\w*]+\.[\w*]+|\*))?(\s+([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([\w*]+\.[\w*]+|\*))*$"; 
            string pattern = @"^find(\s+(/[vcnio]?|\s*""[^""]*""|\s*([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([\w*]+\.[\w*]+|\*)))+";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            string[] testCommands = {
                @"find C:\folder\*.txt ""example"" /v /n",
                @"find /v /n C:\folder\* ""example""",
                @"find ""example"" /v /n C:\folder\hoang.txt"
            };

            foreach (string command in testCommands)
            {
                var match = regex.Match(command);
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


                if (regex.IsMatch(command))
                {
                    Console.WriteLine($"Valid: {command}");
                    Console.WriteLine($"Search string: {stringSearch}, Path File: {pathFile}, params : {paramsS.Trim()}");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Invalid: {command}");
                }
            }
        }
    }
}
