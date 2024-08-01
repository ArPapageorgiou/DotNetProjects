using System.Data.SqlClient;

namespace SqlDataReader_with_index__ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string stringConnection = "data source = DESKTOP-3BA0QHV; database = StudentDB; integrated security = SSPI";

                using (SqlConnection connection = new SqlConnection(stringConnection)) 
                {

                    SqlCommand sqlCommand = new SqlCommand("select Name, Email, Mobile from student", connection);
                    connection.Open();
                    SqlDataReader sdr = sqlCommand.ExecuteReader();

                    while (sdr.Read()) 
                    {
                        Console.WriteLine(sdr[0] + "" + sdr[1] + " " + sdr[2]); //using indexers for Name,Email,Mobile(1,2,3)
                    }
                
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }
        }
    }
}
