using System.Data;
using System.Data.SqlClient;

namespace ADO_Using_Stored_Procedures_Revision
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{

                string connectionString = "data source=DESKTOP-3BA0QHV; database=DBStudents; integrated security=SSPI";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        CommandText = "spGetStudents",
                        CommandType = CommandType.StoredProcedure,
                        Connection = sqlConnection
                    };

                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    Console.WriteLine("Student List acquired:");

                    while (reader.Read()) 
                    {
                        Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
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
