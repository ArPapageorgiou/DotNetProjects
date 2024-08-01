using System.Data.SqlClient;

namespace SqlDataReader_ADO.NET
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

                    SqlCommand sqlCommand = new SqlCommand("select Name, Email, Mobile from student", connection);
                    connection.Open();
                    SqlDataReader sdr = sqlCommand.ExecuteReader();

                    while (sdr.Read()) 
                    {
                        Console.WriteLine(sdr["Name"] + " " + sdr["Email"] + " " + sdr["Mobile"]);
                    }

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Ooops...Something went wrong: " + ex.Message);
            }
        }
    }
}
