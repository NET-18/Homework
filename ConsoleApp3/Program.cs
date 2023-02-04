using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsoleApp3
{
    internal class Program
    {
        static string connectionString = @"Data Source=DESKTOP-KE0BFAK\SQLEXPRESS;Initial Catalog=TMS_04_01_2023;Integrated Security=True;TrustServerCertificate=true";

        static async Task Main(string[] args)
        {
           using SqlConnection conn = new SqlConnection(connectionString);
            
            var list = new List<SqlParameter>();

            list.Add(new SqlParameter("@anum", "A8"));
            list.Add(new SqlParameter("@anum", "A6"));
            list.Add(new SqlParameter("@anum", "A5"));
            list.Add(new SqlParameter("@anum", "A4"));
            try
            {
                conn.Open();
                
                foreach (var item in list)
                {
                    var sql = $"INSERT INTO Models ([name], manufacturerId) VALUES (@anum, 3);";
                    var command = new SqlCommand(sql, conn);
                    command.Parameters.Add(item);
                  
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            using var adapter = new SqlDataAdapter("SELECT * FROM  [Models]", conn);
            var set = new DataSet();

            adapter.Fill(set);

            var table = set.Tables[0];

            foreach (DataColumn col in table.Columns)
            {
                Console.Write("{0,15}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    Console.Write("{0,15}", cell);
                }
                Console.WriteLine();
            }
        }

    }
}