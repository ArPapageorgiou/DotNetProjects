using System;
using System.Data;
using System.Data.SqlClient;
namespace BulkInsertUsingSqlBulkCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                string ConnectionString = @"data source=DESKTOP-3BA0QHV; database=EmployeeDB; integrated security=SSPI";

                DataTable EmployeeDataTable = new DataTable("Employees");

                DataColumn Id = new DataColumn("Id");
                EmployeeDataTable.Columns.Add(Id);

                DataColumn Name = new DataColumn("Name");
                EmployeeDataTable.Columns.Add(Name);

                DataColumn Email = new DataColumn("Email");
                EmployeeDataTable.Columns.Add(Email);

                DataColumn Mobile = new DataColumn("Mobile");
                EmployeeDataTable.Columns.Add(Mobile);

                EmployeeDataTable.Rows.Add(105, "Santosh", "Santosh@dotnettutorials.net", "12345");
                EmployeeDataTable.Rows.Add(106, "Saroj", "Saroj@dotnettutorials.net", "23456");
                EmployeeDataTable.Rows.Add(107, "Sameer", "Sameer@dotnettutorials.net", "34567");

                
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                   
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection))
                    {
                        
                        sqlBulkCopy.DestinationTableName = "dbo.Employee";

                        
                        sqlBulkCopy.ColumnMappings.Add("Id", "Id");
                        sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        sqlBulkCopy.ColumnMappings.Add("Email", "Email");
                        sqlBulkCopy.ColumnMappings.Add("Mobile", "Mobile");

                        
                        connection.Open();


                        sqlBulkCopy.WriteToServer(EmployeeDataTable);
                    }
                }

                Console.WriteLine("BULK INSERT Successful using SqlBulkCopy");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}