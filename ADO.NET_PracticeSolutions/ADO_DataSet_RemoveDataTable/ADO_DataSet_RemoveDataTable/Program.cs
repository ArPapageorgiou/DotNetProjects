using System.Data;
using System.Data.SqlClient;

namespace ADO_DataSet_RemoveDataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                string connectionString = "data source=DESKTOP-3BA0QHV; " +
                    "database=ShoppingCartDB;" +
                    "integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(
                        "SELECT * FROM customers; " +
                        "SELECT * FROM orders",
                        connection);

                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    dataSet.Tables[0].TableName = "Customers";
                    dataSet.Tables[1].TableName = "Orders";

                    Console.WriteLine("Printing Customers Table Data: ");

                    foreach (DataRow row in dataSet.Tables[0].Rows) 
                    {
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Printing Orders Table Data: ");

                    foreach (DataRow row in dataSet.Tables[1].Rows)
                    {
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }

                    Console.WriteLine();

                    if (dataSet.Tables.Contains("Orders") &&
                        dataSet.Tables.CanRemove(dataSet.Tables["Orders"])) 
                    {
                        Console.WriteLine("Deleting Orders Data Table");
                        dataSet.Tables.Remove(dataSet.Tables["Orders"]);

                    }

                    if (dataSet.Tables.Contains("Orders"))
                    {
                        Console.WriteLine("DataTable Orders exists");
                    }
                    else 
                    {
                        Console.WriteLine("DataTable Orders does not exist anymore");
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
