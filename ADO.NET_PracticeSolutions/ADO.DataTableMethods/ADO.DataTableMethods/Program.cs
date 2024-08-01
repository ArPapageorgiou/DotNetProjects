using System.Data.SqlClient;
using System.Data;

namespace ADO.DataTableMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string connectionString = "data source=DESKTOP-3BA0QHV; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Student", connection);
                    DataTable dataTable1 = new DataTable();
                    dataAdapter.Fill(dataTable1);

                    foreach (DataRow row in dataTable1.Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
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
