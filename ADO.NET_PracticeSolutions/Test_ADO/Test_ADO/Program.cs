using System.Data.SqlClient;
using System.Data;

namespace Test_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                DataTable dataTable = new DataTable("Student");

                DataColumn Id = new DataColumn("ID");
                Id.DataType = typeof(int);
                Id.Unique = true;
                Id.AllowDBNull = false;
                Id.Caption = "Student ID";
                Id.AutoIncrement = true;
                Id.AutoIncrementSeed = 101;
                Id.AutoIncrementStep = 1;
                dataTable.Columns.Add(Id);

                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                dataTable.Columns.Add(Name);

                DataColumn Email = new DataColumn("Email");
                dataTable.Columns.Add(Email);

                dataTable.PrimaryKey = new DataColumn[] { Id };

                DataRow row1 = dataTable.NewRow();
                row1["Name"] = "Anurag";
                row1["Email"] = "Anurag@dotnettutorials.net";
                dataTable.Rows.Add(row1);

                dataTable.Rows.Add(null, "Mohanty", "Mohanty@dotnettutorials.net");

                dataTable.Rows.Add(null, "Argiris", "Argiris@dotnettutorials.net");

                foreach (DataRow row in dataTable.Rows) 
                {
                    Console.WriteLine(row[0] + ", " + row[1] + ", " + row[2]);
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
