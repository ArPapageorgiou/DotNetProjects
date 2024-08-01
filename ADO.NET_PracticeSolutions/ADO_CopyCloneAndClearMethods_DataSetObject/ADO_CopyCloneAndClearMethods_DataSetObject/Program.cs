using System.Data;
using System.Data.SqlClient;

namespace ADO_CopyCloneAndClearMethods_DataSetObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "data source=DESKTOP-3BA0QHV; database=StudentDB; integrated security=SSPI";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Student", connection);
                    DataSet originalDataSet = new DataSet();
                    dataAdapter.Fill(originalDataSet);

                    Console.WriteLine("Original DataSet: ");

                    foreach (DataRow row in originalDataSet.Tables[0].Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Copy DataSet: ");

                    DataSet copyDataSet = originalDataSet.Copy();

                    if (copyDataSet.Tables != null)
                    {
                        foreach (DataRow row in copyDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    Console.WriteLine();

                    DataSet cloneDataSet = originalDataSet.Clone();

                    if (cloneDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in cloneDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Clone DataSet is Empty");
                        Console.WriteLine("Adding Data to cloneDataSet");

                        cloneDataSet.Tables[0].Rows.Add(101, "test1", "test1@adonet.com", "12353547");
                        cloneDataSet.Tables[0].Rows.Add(102, "test2", "test2@adonet.com", "09878752");

                        foreach (DataRow row in cloneDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }

                    Console.WriteLine();

                    //removes all data from all tables of the dataset
                    copyDataSet.Clear();
                    if (copyDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in copyDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("After clear no data is found");
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
