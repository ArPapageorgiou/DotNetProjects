using System.Data.SqlClient;
using System.Data;

namespace ADO_DataSet_StoredProcedure
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

                    SqlCommand command = new SqlCommand("spGetStudents", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        Console.WriteLine(reader[0]+" " + reader[1] + " " + reader[2] + " " + reader[3]);
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
