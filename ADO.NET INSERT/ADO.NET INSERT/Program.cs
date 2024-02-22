using System.Data.SqlClient;

namespace ADO.NET_INSERT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().InsertRecord();
            Console.ReadLine(); 
        }

        public void InsertRecord() 
        { 

        SqlConnection conn = null;
            try 
            {
                conn = new SqlConnection("data source= DESKTOP-3BA0QHV; database = Northwind; integrated security = SSPI;");
                SqlCommand cm = new SqlCommand("INSERT INTO Promotions(EmployeeID, Name, email, join_date) values(2, 'Fuller', 'fuller@gmail.com', '02-11-2019')", conn);
                conn.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Record inserted successfully");
            }
            catch (Exception ex) 
            { 
            Console.WriteLine("Oooops something went wrong " + ex.Message);   
            }
            finally 
            { 
                if (conn != null && conn.State == System.Data.ConnectionState.Open) 
                { 
                conn.Close();
                } 
            }

        }
    }
}
