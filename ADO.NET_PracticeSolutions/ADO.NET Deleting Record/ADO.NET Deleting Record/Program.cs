using System.Data.SqlClient;

namespace ADO.NET_Deleting_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().DeletingRecord();
            Console.WriteLine();
        }

        public void DeletingRecord() 
        { 
        
        SqlConnection conn = null;
            try
            {

                conn = new SqlConnection("data source = DESKTOP-3BA0QHV; database = Northwind; integrated security = SSPI ");
                SqlCommand cm = new SqlCommand("DELETE FROM Promotions WHERE EmployeeID = '2'", conn);
                conn.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Command executed successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            finally
            {
                if (conn != null)

                {
                    conn.Close();
                }
            }
            
        
        }
    }
}
