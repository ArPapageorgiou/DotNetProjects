using System.Data;
using System.Data.SqlClient;

namespace ADO_DataSet_MultipleDBTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string connectionString = 
                    "data source=DESKTOP-3BA0QHV; " +
                    "database=ShoppingCartDB; " +
                    "integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Customers; SELECT * FROM Orders", connection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    Console.WriteLine("Table 1 Data: ");

                    foreach (DataRow row in dataSet.Tables[0].Rows) 
                    {
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Table 2 Data: ");

                    foreach (DataRow row in dataSet.Tables[1].Rows) 
                    {
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
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
