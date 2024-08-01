using System.Data;
using System.Data.SqlClient;



namespace ADO_StoredProcedureCall_WithParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{

                string connectionString = "data source=DESKTOP-3BA0QHV; database=DBStudents; integrated security=SSPI";
                
                int[] isToDelete = { 110, 111, 112 };

                 
                foreach (int i in isToDelete) 
                {
                    
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        SqlCommand command = new SqlCommand("spDeleteStudentRowsByIdStudent", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        command.Parameters.Add(new SqlParameter("@Id", i));

                        connection.Open();

                        command.ExecuteNonQuery();

                        Console.WriteLine($"Deleted row with Id: {i}");
                    
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
