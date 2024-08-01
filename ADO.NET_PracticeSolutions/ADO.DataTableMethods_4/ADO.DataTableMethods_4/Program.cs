using System.Data;
using System.Data.SqlClient;

namespace ADO.DataTableMethods_4
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
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from student", connection);
                    DataTable dataTable1 = new DataTable();
                    dataAdapter.Fill(dataTable1);

                    Console.WriteLine("Before deletion");
                    foreach (DataRow row in dataTable1.Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                    }
                    
                    Console.WriteLine();

                    foreach (DataRow row in dataTable1.Rows) 
                    {
                        if (Convert.ToInt32(row[0]) == 101) 
                        {
                            row.Delete();
                            Console.WriteLine("Row with Id 101 Deleted");
                        }
                    }

                    Console.WriteLine();
                    
                    Console.WriteLine("After Deletion: ");
                    foreach (DataRow row in dataTable1.Select())
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                    }

                    dataTable1.RejectChanges();
                    Console.WriteLine() ;
                    Console.WriteLine("Rollbacking all the changes") ;
                    
                    Console.WriteLine();

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
