using System.Data.SqlClient;
using System.Data;

namespace ADO_Return_DataSet_From_Stored_Procedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string connectionString = "data source=DESKTOP-3BA0QHV; database=EmployeeDB; integrated security=SSPI";

                SqlParameter[] parameterList = new SqlParameter[]
                {
                new SqlParameter("@Age", 25),
                new SqlParameter("@Dept", "IT")
                };

                DataSet mainDataSet = ExecuteStoredProcedureReturnDataSet(connectionString, "spGetEmployeesByAgeDept", parameterList);

                Console.WriteLine("spGetEmployeesByAgeDept Result:");
                foreach (DataRow row in mainDataSet.Tables[0].Rows)
                {
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"] + ",  " + row["Age"] + ",  " + row["Department"]);
                }

                Console.WriteLine();

                DataSet mainDataSet2 = ExecuteStoredProcedureReturnDataSet(connectionString, "spGetEmployees");

                Console.WriteLine("spGetEmployees Result:");
                foreach (DataRow row in mainDataSet2.Tables[0].Rows) 
                {
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"] + ",  " + row["Age"] + ",  " + row["Department"]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        public static DataSet ExecuteStoredProcedureReturnDataSet(string connectionString, string procedureName, params SqlParameter[] parameterList)
        {

            DataSet dataset = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = procedureName;

                        if (parameterList != null)
                        {

                            command.Parameters.AddRange(parameterList);

                        }

                        dataAdapter.Fill(dataset);

                    }

                }
            }

            return dataset;

        }
    }
}
