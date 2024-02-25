using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace DataReader_ADO.NET__Access_Multiple_Result_Sets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {

                string connectionString = "data source = DESKTOP-3BA0QHV; database = ShoppingCartDB; integrated security = SSPI";

                using(SqlConnection connection = new SqlConnection(connectionString)) 
                {

                    SqlCommand sqlcommand = new SqlCommand("select * from Customers; select * from Orders", connection);
                    connection.Open();

                    SqlDataReader sdr = sqlcommand.ExecuteReader();

                    Console.WriteLine("First result set is: ");
                    Console.WriteLine("------------------------------------");
                    while (sdr.Read()) 
                    {

                        Console.WriteLine(sdr[0] + " " + sdr[1] + " " + sdr[2]);
                    
                    }


                    while (sdr.NextResult()) 
                    {
                        Console.WriteLine();
                        Console.WriteLine("Next result set is: ");
                        Console.WriteLine("------------------------------------");

                        while (sdr.Read()) 
                        {

                            Console.WriteLine(sdr[0] + " " + sdr[1] + " " + sdr[2]);
                        
                        }
                    
                    }
                
                }

            }   
            catch (Exception ex) 
            {
                Console.WriteLine("Ooops...An error has occured: " + ex.Message);
            }
        }
    }
}
