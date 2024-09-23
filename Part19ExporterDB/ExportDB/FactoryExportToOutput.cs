using Part19ExportDB.Output;
using System.Reflection.Metadata.Ecma335;

namespace Part19ExportDB
{
    public static class FactoryExportToOutput
    {
        public static IExportDB CreateExport(string format) => format switch
        {
            "csv" => new ExportDBToCsv(),
            "sql" => new ExportDBToSql(),
            _ => throw new ArgumentOutOfRangeException(nameof(format), $"Not expected format value: {format}"),
        };

    }
}
