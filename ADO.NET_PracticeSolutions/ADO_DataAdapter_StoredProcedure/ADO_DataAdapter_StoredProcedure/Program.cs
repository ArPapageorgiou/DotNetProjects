using System.Data;
using System.Data.SqlClient;

namespace ADO_DataAdapter_StoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {

                string connectionString = "data source = DESKTOP-3BA0QHV; database = StudentDB; integrated security = SSPI";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("spGetStudents", connection);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    foreach (DataRow row in table.Rows) 
                    {
                        Console.WriteLine(row[1] + " " + row[2] + " " + row[3]);  
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
