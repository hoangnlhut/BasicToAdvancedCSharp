using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        //TestEnvironment();
        //TestCopyFile();
        //TestManipulateFile(args);
        //TestReadFile(args);
        //TestWriteBinaryFile(args);
        //TestReadBinaryFile(args);
        GetInfomationOfFile(args);
    }

    public static void TestEnvironment()
    {
        // các thuộc tính
        Console.WriteLine("**************************");
        Console.WriteLine("Command: {0}", Environment.CommandLine);
        Console.WriteLine("Curr Dir: {0}", Environment.CurrentDirectory);
        Console.WriteLine("Sys Dir: {0}", Environment.SystemDirectory);
        Console.WriteLine("Version: {0}", Environment.Version);
        Console.WriteLine("OS Version: {0}", Environment.OSVersion);
        Console.WriteLine("Machine: {0}", Environment.MachineName);
        Console.WriteLine("Memory: {0}", Environment.WorkingSet);
        // dùng một vài các phương thức
        Console.WriteLine("**************************");
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("Arg {0}: {1}", i, args[i]);
        }
        Console.WriteLine("**************************");
        string[] drivers = Environment.GetLogicalDrives();
        for (int i = 0; i < drivers.Length; i++)
        {
            Console.WriteLine("Drive {0}: {1}", i, drivers[i]);
        }
        Console.WriteLine("**************************");
        Console.WriteLine("Path: {0}",
        Environment.GetEnvironmentVariable("Path"));

        Console.WriteLine("**************************");
        IDictionary environmentVariables = Environment.GetEnvironmentVariables();

        foreach (DictionaryEntry de in environmentVariables)
        {
            Console.WriteLine($"  {de.Key} = {de.Value}");
        }

        Console.WriteLine("**************************");
    }

    public static void TestCopyFile()
    {
        string[] CLA = Environment.GetCommandLineArgs();
        if (CLA.Length < 3)
        {
            Console.WriteLine("Format: {0} orig - file new- file", CLA[0]);
        }
        else
        {
            string origfile = CLA[1];
            string newfile = CLA[2];
            Console.Write("Copy...");
            try
            {
                File.Copy(origfile, newfile);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("\n{0} does not exist!", origfile);
                return;
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("\n{0} already exist!", newfile);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn exception was thrown trying to copy file");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("...Done");
        }
    }
    public static void GetInfomationOfFile(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Phai nhap ten tap tin.");
        }
        else
        {
            try
            {
                FileInfo fiFile = new FileInfo(args[0]);
                if (fiFile.Exists)
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("{0} {1}", fiFile.Name, fiFile.Length);
                    Console.WriteLine("******************************");
                    Console.WriteLine("Last access: {0}", fiFile.LastAccessTime);
                    Console.WriteLine("Last write: {0}", fiFile.LastWriteTime);
                    Console.WriteLine("Creation: {0}", fiFile.CreationTime);
                    Console.WriteLine("******************************");
                }
                else
                {
                    Console.WriteLine("{0} doesn’t exist!", fiFile.Name);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("\n{0} does not exists!", args[1]);
                return;
            }

            catch (Exception e)
            {
                Console.WriteLine("\n An exception was thrown trying to copy file");
                Console.WriteLine();
                return;
            }
        }
    }


    public static void TestWriteFile(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Phai nhap ten tap tin.");
        }
        else
        {
            StreamWriter myFile = File.CreateText(args[0]);
            myFile.WriteLine("Khong co viec gi kho");
            myFile.WriteLine("Chi so long khong ben");
            myFile.WriteLine("Dao nui va lap bien");
            myFile.WriteLine("Quyet chi at lam nen");
            for (int i = 0; i < 10; i++)
            {
                myFile.Write("{0} ", i);
            }
            myFile.Close();
        }
    }

    public static void TestReadFile(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Phai nhap ten tap tin.");
        }
        else
        {
            Console.WriteLine("Starting to read file...");
            try
            {
                StreamReader myFile = File.OpenText(args[0]);
                while (!myFile.EndOfStream)
                {
                    Console.WriteLine(myFile.ReadLine());
                }
                myFile.Close();

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (Exception)
            {
                Console.WriteLine("Error read file");
            }
            Console.WriteLine("Complete to read file...");
        }
    }
    public static void TestWriteBinaryFile(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Phai nhap ten tap tin!");
        }
        else
        {
            FileStream myFile = new FileStream(args[0], FileMode.CreateNew);
            BinaryWriter bwFile = new BinaryWriter(myFile);
            for (int i = 0; i < 100; i++)
            {
                bwFile.Write(i);
            }
            bwFile.Close();
            myFile.Close();
        }
    }

    public static void TestReadBinaryFile(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Phai nhap ten tap tin!");
        }
        else
        {
            FileStream myFile = new FileStream(args[0], FileMode.Open);
            BinaryReader brFile = new BinaryReader(myFile);
            // đọc dữ liệu
            Console.WriteLine("Dang doc tap tin....");
            while (brFile.PeekChar() != -1)
            {
                Console.Write("<{0}>", brFile.ReadInt32());
            }
            Console.WriteLine("....Doc xong");
            brFile.Close();
            myFile.Close();
        }
    }
}

