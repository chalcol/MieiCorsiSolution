using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MieiCorsi.Models.Services.Infrastructure
{
    public class SqlDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string query)
        {
           
            var conn = new SqlConnection("Data Source=Data/MieiCorsiDB.db");
            conn.Open();

            var cmd = new SqlCommand(query, conn);

           var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                var title = (String) reader["Title"];
            }
            conn.Dispose();
            throw new NotImplementedException();
        }
    }
}
