using System.Data;
using System.Data.SqlClient;

namespace ADO_DataSet_CopyCloneClearMethods1
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                string connectionString =
                    "data source=DESKTOP-3BA0QHV; " +
                    "database=ShoppingCartDB;" +
                    "integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Customers", connection);
                    DataSet originalDataSet = new DataSet();
                    dataAdapter.Fill(originalDataSet);

                    Console.WriteLine("Printing originalDataSet Data: ");

                    foreach (DataRow row in originalDataSet.Tables[0].Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                    }

                    Console.WriteLine();

                    DataSet copyDataSet = originalDataSet.Copy();

                    Console.WriteLine("Printing copyDataSet Data: ");

                    if (copyDataSet != null) 
                    {
                        foreach (DataRow row in copyDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                        }
                    }

                    Console.WriteLine();

                    DataSet cloneDataSet = originalDataSet.Clone();

                    Console.WriteLine("Printing cloneDataSet Data: ");

                    if (copyDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in cloneDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                        }
                    }
                    else 
                    { 
                    Console.WriteLine("cloneDataSet Table is empty");
                    }

                    Console.WriteLine();

                    Console.WriteLine("Adding new Data to the cloneDataSet Table");

                    cloneDataSet.Tables[0].Rows.Add(101, "Argiris", "12325765478");
                    cloneDataSet.Tables[0].Rows.Add(102, "Giorgos", "09867865654");

                    foreach (DataRow row in cloneDataSet.Tables[0].Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                    }

                    Console.WriteLine();

                    copyDataSet.Clear();

                    if (copyDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in copyDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                        }
                    }
                    else 
                    {
                        Console.WriteLine("After clear copyDataSet Table is Empty");
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
