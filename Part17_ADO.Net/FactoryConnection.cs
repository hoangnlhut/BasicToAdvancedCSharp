using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part17_ADO.Net
{
    public static class FactoryConnection
    {
        public static SqlConnection CreateConnection(IConfiguration configuration)
        {
            return new SqlConnection(configuration.GetConnectionString("HRDB"));
        }
    }
}
