using System.Collections;
using System.Reflection;

namespace _100_TestCodeFromAI.ConvertStringNameTableToTableModel
{
    //how to convert string of name table to table model in c# .net
    public static class ModelMapper
    {
        public static Type GetModelTypeFromTableName(string tableName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string modelName = tableName + "Model"; // Adjust if your naming convention is different

            Type modelType = assembly.GetTypes()
                .FirstOrDefault(t => string.Equals(t.Name, modelName, StringComparison.OrdinalIgnoreCase));

            if (modelType == null)
            {
                throw new ArgumentException($"No model found for table name: {tableName}");
            }

            return modelType;
        }

        public static object CreateModelInstance(string tableName)
        {
            Type modelType = GetModelTypeFromTableName(tableName);
            return Activator.CreateInstance(modelType);
        }

        public static IList CreateModelList(string tableName)
        {
            Type modelType = GetModelTypeFromTableName(tableName);
            Type listType = typeof(List<>).MakeGenericType(modelType);
            return (IList)Activator.CreateInstance(listType);
        }

        public static IList CreateAndPopulateModelList(string tableName, int count)
        {
            IList list = CreateModelList(tableName);
            Type modelType = GetModelTypeFromTableName(tableName);

            for (int i = 0; i < count; i++)
            {
                object instance = Activator.CreateInstance(modelType);
                // Here you would typically populate the instance with data
                // For demonstration, we'll just set an Id property if it exists
                PropertyInfo idProperty = modelType.GetProperty("Id");
                if (idProperty != null && idProperty.PropertyType == typeof(int))
                {
                    idProperty.SetValue(instance, i + 1);
                }
                list.Add(instance);
            }

            return list;
        }
    }
}
