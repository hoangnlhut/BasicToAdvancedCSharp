using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Part15_UnitTest_FindConsoleApp
{
    public static class Constants
    {
        #region Find Text In One File Constants
        public static class FindTextWithVandC
        {
            public const string Input1 = @"find /c /v ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input2 = @"find ""hoang"" /c /v C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt /c /v";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\hoang.txt ""hoang"" /c /v";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\hoang.txt /c /v ""hoang""";
            public const string Input6 = @"find /c /v C:\Users\Hoang\Downloads\test\hoang.txt ""hoang""";

            public static readonly List<string> Output = new List<string>() { "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT: 8" } ;
        }

        public static class FindTextWithC
        {
            public const string Input1 = @"find /c ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input2 = @"find ""hoang"" /c C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt /c";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\hoang.txt ""hoang"" /c";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\hoang.txt /c ""hoang""";
            public const string Input6 = @"find /c C:\Users\Hoang\Downloads\test\hoang.txt ""hoang""";
            public static readonly List<string> Output = new List<string>() { "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT: 2" };
        }

        public static class FindTextWithCAndN
        {
            public const string Input1 = @"find /c /n ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input2 = @"find ""hoang"" /c /n C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt /c /n";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\hoang.txt ""hoang"" /c /n";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\hoang.txt /c /n ""hoang""";
            public const string Input6 = @"find /c /n C:\Users\Hoang\Downloads\test\hoang.txt ""hoang""";
            public static readonly List<string> Output = new List<string>() { "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT: 2" };
        }

        public static class FindTextWithV
        {
            public const string Input1 = @"find /v ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input2 = @"find ""hoang"" /v C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt /v";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\hoang.txt ""hoang"" /v";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\hoang.txt /v ""hoang""";
            public const string Input6 = @"find /v C:\Users\Hoang\Downloads\test\hoang.txt ""hoang""";
            public static readonly List<string> Output = new List<string>() { 
                "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                "abc",
                "123",
                "dfgrth56",
                "HOANG",
                "HOANG456546",
                "HoANg343",
                "z",
                "\"ta la ma\"",
            };
        }
        public static class FindTextWithN
        {
            public const string Input1 = @"find /n ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input2 = @"find ""hoang"" /n C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt /n";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\hoang.txt ""hoang"" /n";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\hoang.txt /n ""hoang""";
            public const string Input6 = @"find /n C:\Users\Hoang\Downloads\test\hoang.txt ""hoang""";
            public static readonly List<string> Output = new List<string>() { "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                @"[2]hoang",
				@"[3]hoang345345"
            };
        }
        public static class FindTextWithI
        {
            public const string Input1 = @"find /i ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input2 = @"find ""hoang"" /i C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt /i";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\hoang.txt ""hoang"" /i";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\hoang.txt /i ""hoang""";
            public const string Input6 = @"find /i C:\Users\Hoang\Downloads\test\hoang.txt ""hoang""";
            public static readonly List<string> Output = new List<string>() { "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                "hoang",
                "hoang345345",
                "HOANG",
                "HOANG456546",
                "HoANg343"
            };
        }

        public static class FindTextWithDefault
        {
            public const string Input1 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\hoang.txt";
            public const string Input2 = @"find C:\Users\Hoang\Downloads\test\hoang.txt ""hoang""";
            public static readonly List<string> Output = new List<string>() { "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                "hoang",
                "hoang345345"
            };
        }
        #endregion

        #region Find Text In Many File Constants
        public static class FindTextWithVandCManyFile
        {
            public const string Input1 = @"find /c /v ""hoang"" C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input2 = @"find ""hoang"" /c /v C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*.txt /c /v";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\*.txt ""hoang"" /c /v";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\*.txt /c /v ""hoang""";
            public const string Input6 = @"find /c /v C:\Users\Hoang\Downloads\test\*.txt ""hoang""";
            public const string Input7 = @"find /c /v ""hoang"" C:\Users\Hoang\Downloads\test\*";
            public const string Input8 = @"find ""hoang"" /c /v C:\Users\Hoang\Downloads\test\*";
            public const string Input9 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\* /c /v";
            public const string Input10 = @"find C:\Users\Hoang\Downloads\test\* ""hoang"" /c /v";
            public const string Input11 = @"find C:\Users\Hoang\Downloads\test\* /c /v ""hoang""";
            public const string Input12 = @"find /c /v C:\Users\Hoang\Downloads\test\* ""hoang""";

            public static readonly List<string> Output = new List<string>() {
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\A.TXT: 4",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\B.TXT: 3",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT: 8",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\TRANG.TXT: 3",
            };
        }

        public static class FindTextWithCandNOrOnlyCManyFiles
        {
            public const string Input1 = @"find /c ""hoang"" C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input2 = @"find ""hoang"" /c C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*.txt /c";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\*.txt ""hoang"" /c";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\*.txt /c ""hoang""";
            public const string Input6 = @"find /c C:\Users\Hoang\Downloads\test\*.txt ""hoang"" ";
            public const string Input7 = @"find /c ""hoang"" C:\Users\Hoang\Downloads\test\*";
            public const string Input8 = @"find ""hoang"" /c C:\Users\Hoang\Downloads\test\*";
            public const string Input9 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\* /c";
            public const string Input10 = @"find C:\Users\Hoang\Downloads\test\* ""hoang"" /c";
            public const string Input11 = @"find C:\Users\Hoang\Downloads\test\* /c ""hoang""";
            public const string Input12 = @"find /c C:\Users\Hoang\Downloads\test\* ""hoang""";
            public const string Input13 = @"find /c /n ""hoang"" C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input14 = @"find ""hoang"" /c /n C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input15 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*.txt /c /n";
            public const string Input16 = @"find C:\Users\Hoang\Downloads\test\*.txt ""hoang"" /c /n";
            public const string Input17 = @"find C:\Users\Hoang\Downloads\test\*.txt /c /n ""hoang""";
            public const string Input18 = @"find /c /n C:\Users\Hoang\Downloads\test\*.txt ""hoang"" ";
            public const string Input19 = @"find /c /n ""hoang"" C:\Users\Hoang\Downloads\test\*";
            public const string Input20 = @"find ""hoang"" /c /n C:\Users\Hoang\Downloads\test\*";
            public const string Input21 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\* /c /n";
            public const string Input22 = @"find C:\Users\Hoang\Downloads\test\* ""hoang"" /c /n";
            public const string Input23 = @"find C:\Users\Hoang\Downloads\test\* /c /n ""hoang""";
            public const string Input24 = @"find /c /n C:\Users\Hoang\Downloads\test\* ""hoang"" ";

            public static readonly List<string> Output = new List<string>() {
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\A.TXT: 0",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\B.TXT: 0",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT: 2",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\TRANG.TXT: 0",
            };
        }

        public static class FindTextWithVManyFiles
        {
            public const string Input1 = @"find /v ""hoang"" C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input2 = @"find ""hoang"" /v C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*.txt /v";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\*.txt ""hoang"" /v";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\*.txt /v ""hoang""";
            public const string Input6 = @"find /v C:\Users\Hoang\Downloads\test\*.txt ""hoang""";
            public const string Input7 = @"find /v ""hoang"" C:\Users\Hoang\Downloads\test\*";
            public const string Input8 = @"find ""hoang"" /v C:\Users\Hoang\Downloads\test\*";
            public const string Input9 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\* /v";
            public const string Input10 = @"find C:\Users\Hoang\Downloads\test\* ""hoang"" /v";
            public const string Input11 = @"find C:\Users\Hoang\Downloads\test\* /v ""hoang""";
            public const string Input12 = @"find /v C:\Users\Hoang\Downloads\test\* ""hoang""";

            public static readonly List<string> Output = new List<string>() {
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\A.TXT",
                 "english",
                 "teacher",
                 "boy",
                 "girl",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\B.TXT",
                 "document",
                 "vehicle",
                 "I want it",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                 "abc",
                 "123",
                 "dfgrth56",
                 "HOANG",
                 "HOANG456546",
                 "HoANg343",
                 "z",
                 "\"ta la ma\"",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\TRANG.TXT",
                 "edf",
                 "trang",
                 "456"
            };
        }

        public static class FindTextWithNManyFiles
        {
            public const string Input1 = @"find /n ""hoang"" C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input2 = @"find ""hoang"" /n C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*.txt /n";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\*.txt ""hoang"" /n";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\*.txt /n ""hoang""";
            public const string Input6 = @"find /n C:\Users\Hoang\Downloads\test\*.txt ""hoang""";
            public const string Input7 = @"find /n ""hoang"" C:\Users\Hoang\Downloads\test\*";
            public const string Input8 = @"find ""hoang"" /n C:\Users\Hoang\Downloads\test\*";
            public const string Input9 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\* /n";
            public const string Input10 = @"find C:\Users\Hoang\Downloads\test\* ""hoang"" /n";
            public const string Input11 = @"find C:\Users\Hoang\Downloads\test\* /n ""hoang""";
            public const string Input12 = @"find /n C:\Users\Hoang\Downloads\test\* ""hoang""";

            public static readonly List<string> Output = new List<string>() {
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\A.TXT",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\B.TXT",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                 @"[2]hoang",
                 @"[3]hoang345345",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\TRANG.TXT",
            };
        }

        public static class FindTextWithIManyFiles
        {
            public const string Input1 = @"find /i ""hoang"" C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input2 = @"find ""hoang"" /i C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*.txt /i";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\*.txt ""hoang"" /i";
            public const string Input5 = @"find C:\Users\Hoang\Downloads\test\*.txt /i ""hoang""";
            public const string Input6 = @"find /i C:\Users\Hoang\Downloads\test\*.txt ""hoang""";
            public const string Input7 = @"find /i ""hoang"" C:\Users\Hoang\Downloads\test\*";
            public const string Input8 = @"find ""hoang"" /i C:\Users\Hoang\Downloads\test\*";
            public const string Input9 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\* /i";
            public const string Input10 = @"find C:\Users\Hoang\Downloads\test\* ""hoang"" /i";
            public const string Input11 = @"find C:\Users\Hoang\Downloads\test\* /i ""hoang""";
            public const string Input12 = @"find /i C:\Users\Hoang\Downloads\test\* ""hoang""";

            public static readonly List<string> Output = new List<string>() {
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\A.TXT",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\B.TXT",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                 "hoang",
                 "hoang345345",
                 "HOANG",
                 "HOANG456546",
                 "HoANg343",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\TRANG.TXT",
            };
        }

        public static class FindTextWithDefaultManyFiles
        {
            public const string Input1 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*.txt";
            public const string Input2 = @"find C:\Users\Hoang\Downloads\test\*.txt ""hoang""";
            public const string Input3 = @"find ""hoang"" C:\Users\Hoang\Downloads\test\*";
            public const string Input4 = @"find C:\Users\Hoang\Downloads\test\* ""hoang""";

            public static readonly List<string> Output = new List<string>() {
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\A.TXT",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\B.TXT",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\HOANG.TXT",
                 "hoang",
                 "hoang345345",
                 "\n" + @"---------- C:\USERS\HOANG\DOWNLOADS\TEST\TRANG.TXT",
            };
        }

        #endregion

        public static class PathFileCharacter
        {
            public const string Wildcard = "*";
            public const string Path = @":\";
            public const string FileText = @".txt";
        }


    }
}
