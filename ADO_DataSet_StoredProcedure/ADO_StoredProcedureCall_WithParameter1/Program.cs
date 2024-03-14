using System.Data.SqlClient;
using System.Data;

namespace ADO_DataSet_StoredProcedureCall
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{

                string connectionString = "data source=DESKTOP-3BA0QHV; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    SqlCommand command = new SqlCommand("spGetEmployeesByAgeDept", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DataSet dataSet = new DataSet();

                    SqlParameter paramsAge = new SqlParameter
                    {
                        ParameterName = "@Age",
                        SqlDbType = SqlDbType.Int,
                        Value = 25,
                        Direction = ParameterDirection.Input,
                    };

                    command.Parameters.Add(paramsAge);

                    command.Parameters.AddWithValue("@Dept", "IT");

                    SqlDataAdapter dataAdapter = new SqlDataAdapter
                    {
                        SelectCommand = command
                    };

                    dataAdapter.Fill(dataSet);

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
