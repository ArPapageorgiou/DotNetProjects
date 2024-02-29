using System.Data;
using System.Data.SqlClient;
namespace ADO.NET_Retrieve_record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().RetrieveRecord();
            Console.WriteLine();
        }
        public void RetrieveRecord()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection("data source = DESKTOP-3BA0QHV; database = Northwind; integrated security = SSPI");
                SqlCommand cm = new SqlCommand("SELECT * FROM Promotions",conn);
                conn.Open();
                SqlDataReader sdr = cm.ExecuteReader();

                while (sdr.Read()) 
                {
                    Console.WriteLine(sdr["EmployeeID"] + " " + sdr["Name"] + " " + sdr["email"] + " " + sdr["join_date"]);
                }

            }
            catch (Exception ex) 
            { 
            Console.WriteLine ("Ooops...Something went wrong" + " " + ex.Message); 
            }
            finally 
            { 
            if (conn != null)
                {
                    conn.Close();
                }
            }
        }

    }
}

    

