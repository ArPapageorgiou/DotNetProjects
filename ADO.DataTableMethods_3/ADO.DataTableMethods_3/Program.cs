using System.Data;
using System.Data.SqlClient;

namespace ADO.DataTableMethods_3
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

                    Console.WriteLine("Before Deletion: ");
                    foreach (DataRow row in dataTable1.Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                    }
                    
                    Console.WriteLine();
                    //use Select() method to create an array as a dummy to work on. Otherwise we would 
                    //modify the collection itself during itteration which would throw an exception.
                    foreach (DataRow row in dataTable1.Select()) 
                    {
                        if (Convert.ToInt32(row[0]) == 102) 
                        {
                            dataTable1.Rows.Remove(row);
                            Console.WriteLine("Row with id 102 Deleted");    
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("After Deletion: ");

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
