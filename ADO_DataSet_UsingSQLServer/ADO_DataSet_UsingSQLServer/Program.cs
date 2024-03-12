using System.Data;
using System.Data.SqlClient;

namespace ADO_DataSet_UsingSQLServer
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
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Customers", connection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    foreach (DataRow row in dataSet.Tables[0].Rows) 
                    {
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                    }
                }

            } 
            catch (Exception ex) 
            { 
            Console.WriteLine ("Error: " + ex.Message);
            }
        }
    }
}
