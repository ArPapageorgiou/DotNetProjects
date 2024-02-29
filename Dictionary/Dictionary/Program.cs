namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer()
            {

                ID = 101,
                Name = "Mark",
                Salary = 5000

            };

            Customer customer2 = new Customer()
            {

                ID = 110,
                Name = "Pam",
                Salary = 6500

            };

            Customer customer3 = new Customer()
            {

                ID = 119,
                Name = "John",
                Salary = 3500

            };

            Dictionary<int, Customer> customerDictionary = new Dictionary<int, Customer>();
            customerDictionary.Add(customer1.ID, customer1);
            customerDictionary.Add(customer2.ID, customer2);
            customerDictionary.Add(customer3.ID, customer3);
            
            if (!customerDictionary.ContainsKey(customer1.ID)) 
            { 
            customerDictionary.Add(customer1.ID, customer3);
            }

            if (customerDictionary.ContainsKey(135)) 
            {
                Customer cust = customerDictionary[135];
            }

            Customer C1 =  customerDictionary[119];
            Console.WriteLine("ID = {0}, Name = {1}, Salary = {2}", C1.ID, C1.Name, C1.Salary);

            Console.WriteLine();

            foreach (KeyValuePair<int, Customer> customerKeyValuePair in customerDictionary) 
            {
                Console.WriteLine("Key = {0}", customerKeyValuePair.Key);
                Customer custValue = customerKeyValuePair.Value;
                Console.WriteLine("ID = {0}, Name = {1}, Salary = {2}",custValue.ID,custValue.Name,custValue.Salary);
                Console.WriteLine();
            }
        }
    }

    public class Customer 
    { 
        public int ID { get; set; }
        public string Name { get; set; } 
        public int Salary { get; set; }
    }
}
