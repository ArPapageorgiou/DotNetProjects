using System.Data;
using System.Data.SqlClient;

namespace ADO_AccesingTableByDefaultName
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
                    SqlDataAdapter dataAdapter = 
                        new SqlDataAdapter("SELECT * FROM Customers; " +
                        "SELECT * FROM Orders", 
                        connection);

                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    Console.WriteLine("Table 1 Data: ");

                    foreach (DataRow row in dataSet.Tables["Table"].Rows) 
                    {
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Table 2 Data: ");

                    foreach (DataRow row in dataSet.Tables["Table1"].Rows)
                    {
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }

                    Console.WriteLine();

                    //Explicitly setting table name
                    dataSet.Tables[0].TableName = "Customers";
                    dataSet.Tables[1].TableName = "Orders";

                    Console.WriteLine("Table 1 Data: ");

                    foreach (DataRow row in dataSet.Tables["Customers"].Rows)
                    {
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Table 2 Data: ");

                    foreach (DataRow row in dataSet.Tables["Orders"].Rows)
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
