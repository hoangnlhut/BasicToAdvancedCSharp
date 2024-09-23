using System.Collections;
using System.Dynamic;
using System.Reflection;
using System.Xml.Linq;
using _100_TestCodeFromAI.ConvertStringNameTableToTableModel;

namespace _100_TestCodeFromAI
{

    // Usage example
    public class Program
    {
        public static void Main()
        {
            dynamic hoang = new { Hoang = "toi la hoang", Id = 1 };

            Console.WriteLine($"Id : {hoang.Id} and Name : {hoang.Hoang}");

            dynamic hoang1 = new {  };
            hoang1.Id = 2;
            hoang1.Hoang = "Nguyen Hoang Viet";

            Console.WriteLine($"Id : {hoang1.Id} and Name : {hoang1.Hoang}");

            #region //how to convert string of name table to table model in c# .net
            //try
            //{
            //    string tableName = "User"; // Example table name
            //    int count = 5; // Number of instances to create

            //    IList modelList = ModelMapper.CreateAndPopulateModelList(tableName, count);

            //    Console.WriteLine($"Created list of type: {modelList.GetType().FullName}");
            //    Console.WriteLine($"Number of items: {modelList.Count}");

            //    // Display some information about the created instances
            //    foreach (var item in modelList)
            //    {
            //        Console.WriteLine($"Instance of type: {item.GetType().Name}");
            //        foreach (PropertyInfo prop in item.GetType().GetProperties())
            //        {
            //            Console.WriteLine($"  {prop.Name}: {prop.GetValue(item)}");
            //        }
            //    }
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}
            #endregion
        }

    }
}
