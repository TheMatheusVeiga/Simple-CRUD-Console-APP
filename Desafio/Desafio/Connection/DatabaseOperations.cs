using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Connection
{
    public class DatabaseOperations
    {
        public static string MainConnectionString()
        {
            return "Server=localhost\\SQLEXPRESS;Database=desafio;Trusted_Connection=True;";
        }

        public static DataSet DatabaseSelect(string query, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(Desafio.Connection.DatabaseOperations.MainConnectionString()))
            {
                try
                {
                    SqlCommand sql = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql);
                    connection.Open();
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, tableName);

                    return dataset;
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        public static int DatabaseInserUpdateDelete(string query)
        {
            using (SqlConnection connection = new SqlConnection(Desafio.Connection.DatabaseOperations.MainConnectionString()))
            {
                try
                {
                    SqlCommand sql = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql);
                    connection.Open();
                    adapter.InsertCommand = sql;
                    int result = adapter.InsertCommand.ExecuteNonQuery();
                    if (result <= 0)
                        throw new Exception();

                    return result;
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }
    }
}
