using System.Data;
using System.Data.SqlClient;

namespace ADO_CallingStoredProcedureWithInputAndOutputParameters
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
                    command.CommandText = "spCreateStudent";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("@Name", "Argiris");
                    SqlParameter parameter2 = new SqlParameter("@Email", "argiris@adonet.com");
                    SqlParameter parameter3 = new SqlParameter("@Mobile", "0987687645");

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2); 
                    command.Parameters.Add(parameter3); 

                    SqlParameter outParameter = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outParameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                    Console.WriteLine("Newly generated StudentId: " + outParameter.Value.ToString());
                }

                
 }
			catch (Exception e)
			{
                Console.WriteLine("Error: " + e.Message);
			}
        }
    }
}
