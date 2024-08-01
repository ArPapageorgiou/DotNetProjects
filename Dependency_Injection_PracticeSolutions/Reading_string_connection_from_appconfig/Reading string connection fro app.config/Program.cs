using System.Configuration;
using System.Data.SqlClient;

namespace Reading_string_connection_fro_app.config
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    Console.WriteLine("Yes it's open!");
                }
            }
            catch (Exception ex) 
            { 
            Console.WriteLine("Ooops...It's not open " + ex.Message);
            }
            
        }
    }
}
