using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Part19ExportDB.Model;
using Part19ExportDB.Output;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Part19ExportDB.Input
{
    public class ExportedDBSqlServer : ExportedDBMainObject
    {
        public override string ConnectionString { get; set; }
        public override string ExportedFileName { get; set; }
        public override string CommandText { get; set; }
        public override string TableName { get; set; }

        public ExportedDBSqlServer(string connectionString, string exportedFileName, string commandText, string tableName = null)
        {
            ConnectionString = connectionString ?? throw new NullReferenceException();
            ExportedFileName = exportedFileName ?? throw new NullReferenceException();
            CommandText = commandText ?? throw new NullReferenceException();
            TableName = tableName;
        }

        public override IEnumerable<dynamic> ProcessToGetData()
        {
            var newCommandText = CommandText;
            var tableName = TableName;
            Helper.CheckCommandTextAndTable(ref newCommandText, ref tableName);

            CommandText = newCommandText;
            TableName = tableName;

            var datas = new List<dynamic>();

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            using SqlCommand command = new SqlCommand(CommandText, sqlConnection);

            sqlConnection.Open();

            using var reader = command.ExecuteReader();
            {
                if (!reader.HasRows) { return datas; }
                datas = DynamicDataReaderMapper.MapToDynamicList(reader).ToList();
                #region how to see key and value of dictionary
                //foreach (var item in datas)
                //{
                //    Console.WriteLine("New Row:");
                //    foreach (var property in (IDictionary<string, object>)item)
                //    {
                //        Console.WriteLine($"  {property.Key}: {property.Value}");
                //    }
                //}
                #endregion
            }
            sqlConnection.Close();
            return datas.ToList();
        }


        public override void Export(IExportDB exportDb, string fileName, IEnumerable<dynamic> datas)
        {

            fileName = AddDateToFileName ? fileName + DateTime.Now.ToString("yyyyMMdd_HHmmss") : fileName;
            exportDb.Export(fileName, datas, IsZipped);
        }
    }
}
