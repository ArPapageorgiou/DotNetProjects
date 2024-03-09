using System.Data.SqlClient;
using System.Data;

namespace ADO_DataAdapter_StoredProcedure_NoParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {

                string connectionString = "data source = DESKTOP-3BA0QHV; database= StudentDB; integrated security = SSPI";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetStudents", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    connection.Open(); 

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[1] + " " + reader[2] + " " + reader[3]);
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
