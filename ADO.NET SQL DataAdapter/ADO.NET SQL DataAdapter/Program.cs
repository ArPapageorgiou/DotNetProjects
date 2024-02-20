using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_SQL_DataAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {

                string stringConnection = "data source = DESKTOP-3BA0QHV; database = StudentDB; integrated security = SSPI";
                using (SqlConnection connection = new SqlConnection(stringConnection)) 
                {

                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Console.WriteLine("Using Data Table: ");

                    foreach (DataRow row in dt.Rows) 
                    {
                        Console.WriteLine(row[0] + ", " + row[1] + ", " + row[2]);
                    }

                    Console.WriteLine("-------------------------------------");

                    DataSet ds = new DataSet();
                    da.Fill(ds, "student");

                    Console.WriteLine("Using DataSet: ");

                    foreach (DataRow row in ds.Tables["student"].Rows) 
                    {
                        Console.WriteLine(row[0] + ", " + row[1] + ", " + row[2]);
                    }

                }

            }catch (Exception ex) 
            {
                Console.WriteLine("Ooops... " + ex.Message);
            }
        }
    }
}
