using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DatabaseManager
    {
        private string _connectionString = @"Data Source=DESKTOP-KE0BFAK\SQLEXPRESS;Initial Catalog=MyOrmDatabase;Trusted_Connection=True;TrustServerCertificate=True";

        
        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : new()
        {
            var table = Misc.GetTableName<T>();
            var set = new DataSet();

            using var connection = new SqlConnection(_connectionString);
            using var adapter = new SqlDataAdapter($"SELECT * From {table} ", connection);

            adapter.FillSchema(set, SchemaType.Source, table);
            adapter.Fill(set, table);

            var rows = set.Tables[table].Rows;
            var res = new List<T>();

            foreach(DataRow row in rows)
            {
                res.Add(Misc.Initialize<T>(row));
            }
            return res; 
        }
    }
}
