using System.Collections;

namespace Part19ExportDB.Output
{
    public interface IExportDB 
    {
        void Export(string nameFile, IEnumerable<dynamic> datas, bool isZipped = false);
    }
}