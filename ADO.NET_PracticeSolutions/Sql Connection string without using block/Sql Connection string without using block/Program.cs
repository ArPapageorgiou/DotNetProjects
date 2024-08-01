using System.Data.SqlClient;

namespace Sql_Connection_string_without_using_block
{
    internal class Program
    {
        static void Main(string[] args)
        {
           new Program().SqlConnect();
            Console.WriteLine();
        }

        public void SqlConnect() 
        { 
        
            SqlConnection connection = null;

            try 
            {
                string SqlConnectionString = "data source = DESKTOP-3BA0QHV; database = Northwind; integrated security = SSPI";
                connection = new SqlConnection(SqlConnectionString); 
                connection.Open();
                Console.WriteLine("Connection established successfully!");
            }
            catch (Exception ex) 
            { 
            Console.WriteLine("Ooops...Something went wrong " + ex.Message);
            }

            finally 
            { 
                if (connection != null) 
                { 
                connection.Close();
                } 
            }
        }
    }
}
