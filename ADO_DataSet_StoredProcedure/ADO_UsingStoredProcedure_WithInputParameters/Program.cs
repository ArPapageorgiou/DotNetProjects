using System.Data;
using System.Data.SqlClient;

namespace ADO_UsingStoredProcedure_WithInputParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try 
			{

                string connectionString = "data source=DESKTOP-3BA0QHV; database=DBStudents; integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                { 
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "spGetStudentById";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = new SqlParameter 
                    { 
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        SqlValue = 113,
                        Direction = ParameterDirection.Input,
                    
                    };
                    command.Parameters.Add(parameter);

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
                Console.WriteLine ("Error: " + e.Message);
			}
        }
    }
}
