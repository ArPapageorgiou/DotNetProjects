using System.Data.SqlClient;
using System.Data;

namespace ADO_DataSet_StoredProcedures_WithParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                string connectionString =
                    "data source=DESKTOP-3BA0QHV; " +
                    "database=StudentDB; " +
                    "integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "spGetStudentById",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter parameter1 = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Value = 102,
                        Direction =ParameterDirection.Input
                    };

                    command.Parameters.Add(parameter1);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        Console.WriteLine(reader["Id"] + ",  " + reader["Name"] + ",  " + reader["Email"] + ",  " + reader["Mobile"]);
                    }

                    
                }


            }
			catch (Exception e)
			{
                Console.WriteLine("Error: " + e.Message);
			}
        }
    }
}
