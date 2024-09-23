using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part19ExportDB
{
    public static class DynamicDataReaderMapper
    {
        public static dynamic MapToDynamicObject(IDataReader reader)
        {
            dynamic obj = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)obj;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                object value = reader.GetValue(i);

                // Handle DBNull values
                if (value == DBNull.Value)
                {
                    value = null;
                }

                dictionary[columnName] = value;
            }

            return obj;
        }

        public static IEnumerable<dynamic> MapToDynamicList(IDataReader reader)
        {
            var list = new List<dynamic>();

            while (reader.Read())
            {
                list.Add(MapToDynamicObject(reader));
            }

            return list;
        }
    }

}
