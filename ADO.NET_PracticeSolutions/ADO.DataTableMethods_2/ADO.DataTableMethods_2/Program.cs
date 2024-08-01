using System.Data;
using System.Data.SqlClient;
namespace ADO.DataTableMethods_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string connectionString = "data source =DESKTOP-3BA0QHV; database=StudentDB; integrated security=SSPI";

                using(SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from student", connection);
                    DataTable dataTable1= new DataTable();
                    dataAdapter.Fill(dataTable1);
                    Console.WriteLine("dataTable before deletion: ");
                    foreach (DataRow row in dataTable1.Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                    }
                    Console.WriteLine();
                    foreach (DataRow row in dataTable1.Rows) 
                    {
                        if (Convert.ToInt32(row["Id"]) == 101) 
                        { 
                        row.Delete();
                            Console.WriteLine("Row with id 101 Deleted");
                        }
                    }
                    dataTable1.AcceptChanges();

                    Console.WriteLine();
                    Console.WriteLine("After deletion: ");

                    foreach (DataRow row in dataTable1.Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
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
