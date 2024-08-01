using System.Data.SqlClient;
using System.Data;

namespace ADO_CallStoredProcedures_WithInputParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                string connectionString =
                    "data source=DESKTOP-3BA0QHV; " +
                    "database=StudentDB;" +
                    "integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetStudentById", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "Id",
                        SqlDbType = SqlDbType.Int,
                        Value = 101,
                        Direction = ParameterDirection.Input,
                    };

                    sqlCommand.Parameters.Add(param1);

                    connection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read()) 
                    {
                        Console.WriteLine(reader["Id"] + ",  " + reader["Name"] + ",  " + reader["Email"] + ",  " + reader["Mobile"]);
                    }
                }

            }
			catch (Exception e)
			{
                Console.WriteLine($"Exception Occured: {e.Message}");
			}
        }
    }
}
