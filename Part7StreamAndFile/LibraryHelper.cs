using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part7StreamAndFile
{
    public static class LibraryHelper
    {
        public static void DirThroughSystemIo()
        {
            var path = @"C:\";

            //cách này trả về giá trị theo chuối string nên sẽ ko chứa nhiều thông tin nếu muốn thì phải sử dụng các hàm khác
            //var directories = Directory.GetDirectories(path);

            //foreach (var item in directories)
            //{
            //    Console.WriteLine(item);
            //}

            var dir = new DirectoryInfo(path);
            var directories = dir.GetDirectories();

            Console.WriteLine("Get all sub Directories");
            foreach (var item in directories)
            {
                Console.WriteLine($"{item.LastWriteTime:MM/dd/yyyy} {item.LastWriteTime:HH:mm}   <DIR>   {item.Name}");
            }

            Console.WriteLine("***********************************");

            Console.WriteLine("Get all file ");
            var files = dir.GetFiles();
            foreach (var item1 in files)
            {
                Console.WriteLine($"{item1.LastWriteTime:MM/dd/yyyy} {item1.LastWriteTime:HH:mm}            {item1.Length:#,###}   {item1.Name}");
            }
        }

        public static void FolderTree(params string[] args)
        {
            var inputFolder = args[0];
            Console.WriteLine($"Folder tree of {inputFolder}");

            var dir = new DirectoryInfo (inputFolder);
            var addSpaces = new StringBuilder();
            GetAllFileAndFolder(dir, ref addSpaces);
        }

        private static void GetAllFileAndFolder(DirectoryInfo? dir, ref StringBuilder? addSpaces)
        {
            foreach (var file in dir.EnumerateFiles())
            {
                Console.WriteLine($"{addSpaces}|------------- {file.Name}");
            }

            foreach (var direct in dir.EnumerateDirectories())
            {
                Console.WriteLine($"{addSpaces}|------------- {direct.Name}");
                
                var newDir = new DirectoryInfo(direct.FullName);
                if(newDir.EnumerateDirectories().Count() > 0 || newDir.EnumerateFiles().Count() > 0)
                {
                    addSpaces?.Append("\t");
                    GetAllFileAndFolder(newDir, ref addSpaces);
                    addSpaces?.Remove(addSpaces.Length - 1, 1);
                }
            }
            
        }

        public static void CopyFile(params string[] args)
        {
            var inputFilePath = args[0];

            //getting parent directory of path 
            //1. Check có file nào không , nếu có thì lấy file không thì bắn lỗi exception
            var rootDirectoryFilePath = new DirectoryInfo(inputFilePath);
            var rootDirectoryPath = rootDirectoryFilePath.Parent;

            if (!rootDirectoryPath.Exists ) 
            {
                Console.WriteLine("Folder is not existed");
            }

            var downloadDirectory = rootDirectoryPath?.Parent?.FullName;
            var backUpDirectoryPath = Path.Combine(downloadDirectory, "backup");
            Directory.CreateDirectory(backUpDirectoryPath);


            var files = rootDirectoryPath.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine(@"Copying from {0} to{1} with file {2}", rootDirectoryPath?.Parent.FullName, backUpDirectoryPath, file.Name);
                file.CopyTo(Path.Combine(backUpDirectoryPath, file.Name), true);
            }
            //2, Check xem có folder mới để copy đến không , nếu ko có thì tạo folder mới
            // nếu có rồi thì copy sang folder mới thôi



        }
    }
}
