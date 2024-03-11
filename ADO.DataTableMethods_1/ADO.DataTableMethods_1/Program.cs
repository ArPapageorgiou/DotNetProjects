using System.Data.SqlClient;
using System.Data;

namespace ADO.DataTableMethods_1
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
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from student", connection);
                    DataTable originalDataTable = new DataTable();
                    dataAdapter.Fill(originalDataTable);
                    
                    Console.WriteLine("Original Data Table: OriginalDataTable");
                    foreach (DataRow row in originalDataTable.Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                    }
                   
                    Console.WriteLine();
                   
                    Console.WriteLine("Copy Data Table: copyDataTable");
                    DataTable copyDataTable= originalDataTable.Copy();

                    if (copyDataTable != null)
                    {
                        foreach (DataRow row in copyDataTable.Rows)
                        {
                            Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                        }
                    }
                   
                    Console.WriteLine();
                    
                    Console.WriteLine("Clone Data Table: cloneDataTable");
                    DataTable cloneDataTable = originalDataTable.Clone();

                    if (cloneDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in cloneDataTable.Rows)
                        {
                            Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                        }

                    }
                    else 
                    { 
                    Console.WriteLine("cloneDataTable is Empty");
                        Console.WriteLine("Adding Data to cloneDataTable");
                        cloneDataTable.Rows.Add(101, "Test1", "test1@dotmail.com", "12353214674");
                        cloneDataTable.Rows.Add(102, "Test2", "test2@dotmail.com", "83746589885");

                        foreach (DataRow row in cloneDataTable.Rows) 
                        {
                            Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                        }
                    }

                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Ooops, Something went wrong: " + e.Message);
            }
        }
    }
}
