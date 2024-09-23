using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part19ExportDB.Output;

namespace Part19ExportDB.Input
{
    public abstract class ExportedDBMainObject
    {
        //database configuration
        public abstract  string ConnectionString { get; set; }
        public abstract  string ExportedFileName { get; set; }
        public abstract  string CommandText { get; set; }
        public abstract string TableName { get; set; } 

        // export configuration
        public virtual string FormatToExport { get; set; } = "csv";
        public virtual bool IsZipped { get; set; } = false;
        public virtual bool AddDateToFileName { get; set; } = false;

        public abstract void Export(IExportDB exportDb, string fileName, IEnumerable<dynamic> datas);
        public abstract IEnumerable<dynamic> ProcessToGetData();
    }

}
