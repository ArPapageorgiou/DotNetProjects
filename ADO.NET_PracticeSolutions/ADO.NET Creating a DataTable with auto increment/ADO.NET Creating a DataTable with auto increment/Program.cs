using System.Data;

namespace ADO.NET_Creating_a_DataTable_with_auto_increment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                DataTable dataTable = new DataTable("student");

                DataColumn id = new DataColumn("ID");
                id.DataType = typeof(int);  
                id.AutoIncrement = true;
                id.AutoIncrementSeed = 1000;
                id.AutoIncrementStep = 10;
                dataTable.Columns.Add(id);

                DataColumn name = new DataColumn("Name");
                name.DataType = typeof(string);
                name.AllowDBNull = false;
                name.MaxLength = 100;
                dataTable.Columns.Add(name);

                DataColumn email = new DataColumn("Email");
                dataTable.Columns.Add(email);

                //Add New DataRow by creating the DataRow object
                DataRow row1 = dataTable.NewRow();
                row1["Name"] = "Anurag";
                row1["Email"] = "Anurag@dotnettutorials.net";
                dataTable.Rows.Add(row1);

                //Adding new DataRow by simply adding the values
                //Supply null for auto increment column
                dataTable.Rows.Add(null, "Mohanty", "Mohanty@dotnettutorials.net");

                foreach (DataRow row in dataTable.Rows) 
                {
                    Console.WriteLine(row[0] + " " + row[1] + " " + row[2]);
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Ooops... " + ex.Message);
            }
        }
    }
}
