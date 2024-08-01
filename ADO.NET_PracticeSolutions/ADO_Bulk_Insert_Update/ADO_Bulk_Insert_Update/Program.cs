using System.Data.SqlClient;
using System.Data;

namespace ADO_Bulk_Insert_Update
{

    class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    
                    string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";

                    
                    DataTable EmployeeDataTable = new DataTable("Employees");

                   
                    DataColumn Id = new DataColumn("Id");
                    EmployeeDataTable.Columns.Add(Id);

                    DataColumn Name = new DataColumn("Name");
                    EmployeeDataTable.Columns.Add(Name);

                    DataColumn Email = new DataColumn("Email");
                    EmployeeDataTable.Columns.Add(Email);

                    DataColumn Mobile = new DataColumn("Mobile");
                    EmployeeDataTable.Columns.Add(Mobile);

                    
                    EmployeeDataTable.Rows.Add(101, "ABC", "ABC@dotnettutorials.net", "12345");
                    EmployeeDataTable.Rows.Add(102, "PQR", "PQR@dotnettutorials.net", "11223");
                    EmployeeDataTable.Rows.Add(103, "XYZ", "XYZ@dotnettutorials.net", "23432");

                    
                    EmployeeDataTable.Rows.Add(106, "A", "A@dotnettutorials.net", "12345");
                    EmployeeDataTable.Rows.Add(107, "B", "B@dotnettutorials.net", "23456");
                    EmployeeDataTable.Rows.Add(108, "C", "C@dotnettutorials.net", "34567");
                    EmployeeDataTable.Rows.Add(109, "D", "D@dotnettutorials.net", "45678");
                    EmployeeDataTable.Rows.Add(110, "E", "E@dotnettutorials.net", "56789");
                    EmployeeDataTable.Rows.Add(111, "F", "F@dotnettutorials.net", "67890");

                    
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        
                        using (SqlCommand cmd = new SqlCommand("SP_Bulk_Insert_Update_Employees", connection))
                        {
                           
                            cmd.CommandType = CommandType.StoredProcedure;

                            
                            cmd.Parameters.AddWithValue("@Employees", EmployeeDataTable);

                            
                            connection.Open();

                            
                            cmd.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("BULK INSERT UPDATE Successful");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Occurred: {ex.Message}");
                }
                Console.ReadKey();
            }
        }
    }

    
