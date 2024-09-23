using Part19ExportDB.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Part19ExportDB
{
    public static class Helper
    {
        public static void CheckCommandTextAndTable(ref string commandText,ref string tablename)
        {
            if (string.IsNullOrEmpty(commandText)) throw new ArgumentNullException();

            //nếu có tên bảng thì biến string thành một model
            if (!string.IsNullOrEmpty(tablename))
            {
                if (!commandText.Contains("from", StringComparison.OrdinalIgnoreCase) )
                {
                    commandText = commandText + " from " + tablename;
                }
            }
            // nếu không có tên bảng thì phải cắt chuỗi ra để lấy bảng
            else
            {
               var indexFrom = commandText.LastIndexOf("from", StringComparison.OrdinalIgnoreCase);
               var subStringAfterFrom = commandText.Substring(indexFrom).Split(" ");
               if (subStringAfterFrom.Count() <= 0) throw new NullReferenceException();
               tablename = subStringAfterFrom[1];
            }
        }


        //public static Type GetModelTypeFromTableName(string tableName)
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    //string modelName = tableName + "Model"; // Adjust if your naming convention is different
        //    string modelName = MappingNameToTableModel(tableName) ; // Adjust if your naming convention is different

        //    Type modelType = assembly.GetTypes()
        //        .FirstOrDefault(t => string.Equals(t.Name, modelName, StringComparison.OrdinalIgnoreCase));

        //    if (modelType == null)
        //    {
        //        throw new ArgumentException($"No model found for table name: {tableName}");
        //    }

        //    return modelType;
        //}

        //private static string MappingNameToTableModel(string tableName) => tableName switch
        //{
        //    "regions" => "Region",
        //    _ => throw new ArgumentNullException()
        //};

        //public static object CreateModelInstance(string tableName)
        //{
        //    Type modelType = GetModelTypeFromTableName(tableName);
        //    return Activator.CreateInstance(modelType);
        //}

        //public static IList CreateModelList(string tableName)
        //{
        //    Type modelType = GetModelTypeFromTableName(tableName);
        //    Type listType = typeof(List<>).MakeGenericType(modelType);
        //    return (IList)Activator.CreateInstance(listType);
        //}
    }
}
