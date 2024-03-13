using System.Data.SqlClient;
using System.Data;

namespace ADO_DataSet_StoredProcedures_WithParameters1
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

                    SqlCommand command = new SqlCommand("spCreateStudent", connection) 
                    { 
                    CommandType = System.Data.CommandType.StoredProcedure
                    };

                    SqlParameter parameter1 = new SqlParameter
                    {
                        ParameterName = "@Name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = "Test",
                        Direction = ParameterDirection.Input
                    };

                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter()
                    { 
                    ParameterName = "@Email",
                    SqlDbType=SqlDbType.NVarChar,
                    Value = "Test@adonet.net",
                    Direction = ParameterDirection.Input
                    };

                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter()
                    { 
                    ParameterName = "@Mobile",
                    SqlDbType=SqlDbType.NVarChar,
                    Value = "1234567890",
                    Direction = ParameterDirection.Input
                    };

                    command.Parameters.Add(parameter3);

                    SqlParameter outParameter = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outParameter);

                    connection.Open();

                    command.ExecuteNonQuery();

                    Console.WriteLine("Newly Generated Student ID: " + outParameter.Value.ToString());

                    

                }


            }
			catch (Exception e)
			{
                Console.WriteLine("Error: " + e.Message);
			}
        }
    }
}
