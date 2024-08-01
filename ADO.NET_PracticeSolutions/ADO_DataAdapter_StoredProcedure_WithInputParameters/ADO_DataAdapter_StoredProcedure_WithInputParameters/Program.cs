using System.Data.SqlClient;
using System.Data;

namespace ADO_DataAdapter_StoredProcedure_WithInputParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string connectionString = "data source = DESKTOP-3BA0QHV; database = StudentDB; integrated security = SSPI";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        CommandText = "spGetStudentById",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter parameter1 = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Value = 102,
                    Direction = ParameterDirection.Input
                    };

                    sqlCommand.Parameters.Add(parameter1);

                    connection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read()) 
                    {
                        Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3]);
                    }
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message); 
            }
        }
    }
}
