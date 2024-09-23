using Microsoft.Extensions.Configuration;
using Part19ExportDB;
using Part19ExportDB.Input;

namespace ExportDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = builder.Build();

            // nhiều nguồn đầu vào khác nhau
            List<ExportedDBMainObject> exportedDBMainObjects = new List<ExportedDBMainObject>()
            {
                //new ExportedDBSqlServer(configuration.GetConnectionString("HRDB_SQLServer"), "exportRegionsData", "SELECT * FROM regions"),
                //new ExportedDBSqlServer(configuration.GetConnectionString("HRDB_SQLServer"), "exportCountriesData", "SELECT * from countries"),
                //new ExportedDBSqlServer(configuration.GetConnectionString("HRDB_SQLServer"), "exportJobsData", "SELECT * FROM jobs"),
                new ExportedDBSqlServer(configuration.GetConnectionString("HRDB_SQLServer"), "exportDependentsData", "SELECT *", "dependents")
            };

            foreach (var item in exportedDBMainObjects)
            {
                var getTypeSourceToExport = FactoryExportToOutput.CreateExport(item.FormatToExport);
                item.Export(getTypeSourceToExport, item.ExportedFileName, item.ProcessToGetData());
            }
        }
    }
}
