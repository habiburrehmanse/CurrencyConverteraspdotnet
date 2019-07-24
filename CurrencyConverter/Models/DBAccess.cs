using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class DBAccess
    {
        public static string ConnectionString { get; set; }

        public DBAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
