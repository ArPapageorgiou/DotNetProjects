using System.Data;
using System.Data.SqlClient;

namespace ADO_DataSet_StoredProcedure_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{

                string connectionString =
                    "data source=DESKTOP-3BA0QHV; " +
                    "database=EmployeeDB; " +
                    "integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = "spGetEmployeesByAgeDept";

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Age", 25);
                    command.Parameters.AddWithValue("@Dept", "IT");

                    DataSet dataSet = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    
                    adapter.Fill(dataSet);

                    foreach (DataRow row in dataSet.Tables[0].Rows) 
                    {
                        Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3] + " " + row[4] + " " + row[5]);
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
