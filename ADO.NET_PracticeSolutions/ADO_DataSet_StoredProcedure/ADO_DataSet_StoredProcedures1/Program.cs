﻿using System.Data.SqlClient;
using System.Data;

namespace ADO_DataSet_StoredProcedures1
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                string connectionString =
                    "data source=DESKTOP-3BA0QHV; " +
                    "database=DBStudents; " +
                    "integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {

                    SqlCommand command = new SqlCommand("spGetStudents", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        Console.WriteLine(reader["Id"] + ",  " + reader["Name"] + ",  " + reader["Email"] + ",  " + reader["Mobile"]);
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
