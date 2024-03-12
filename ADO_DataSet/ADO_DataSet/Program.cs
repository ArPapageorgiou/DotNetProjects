using System.Data;

namespace ADO_DataSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            { 
            DataTable Customer = new DataTable();

                DataColumn CustomerId = new DataColumn("Id", typeof(Int32));
                Customer.Columns.Add(CustomerId);

                DataColumn CustomerName = new DataColumn("Name", typeof(string));
                Customer.Columns.Add(CustomerName);

                DataColumn CustomerMobile = new DataColumn("Mobile", typeof(string));
                Customer.Columns.Add(CustomerMobile);

                DataRow C_Row1 = Customer.NewRow();
                C_Row1["Id"] = 101;
                C_Row1["Name"] = "Anurag";
                C_Row1["Mobile"] = "1234567890";
                Customer.Rows.Add(C_Row1);    

                DataRow C_Row2 = Customer.NewRow();
                C_Row2["Id"] = 102;
                C_Row2["Name"] = "Manoj";
                C_Row2["Mobile"] = "1234567891";
                Customer.Rows.Add(C_Row2);

                DataTable Orders = new DataTable();

                DataColumn OrdersId = new DataColumn("Id", typeof (Int32));
                Orders.Columns.Add(OrdersId);

                DataColumn CustomerIdKey = new DataColumn("CustomerId", typeof (Int32));
                Orders.Columns.Add(CustomerIdKey);

                DataColumn OrderAmount = new DataColumn("Amount", typeof(Int32));
                Orders.Columns.Add(OrderAmount);

                DataRow O_Row1 = Orders.NewRow();
                O_Row1["Id"] = 201;
                O_Row1["CustomerId"] = 101;
                O_Row1["Amount"] = 56;
                Orders.Rows.Add(O_Row1);

                DataRow O_Row2 = Orders.NewRow();
                O_Row2["Id"] = 202;
                O_Row2["CustomerId"] = 102;
                O_Row2["Amount"] = 77;
                Orders.Rows.Add(O_Row2);

                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(Customer);
                dataSet.Tables.Add(Orders);

                Console.WriteLine("Customer Table Data: ");

                foreach (DataRow row in dataSet.Tables[0].Rows) 
                {
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                }

                Console.WriteLine();

                Console.WriteLine("Orders Table Data: ");

                foreach (DataRow row in dataSet.Tables[1].Rows) 
                {
                    Console.WriteLine(row["Id"] + ",  " + row["CustomerId"] + ",  " + row["Amount"]);
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
