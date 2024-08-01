using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates_test_2
{
    class Product
    {
        public string name { get; set; }
        public int price { get; set; }

        public static void discountMethod(List<Product> Plist, eligibleForDiscount discountDelegate)
        {
            foreach (Product p in Plist)
            {
                if (discountDelegate(p))
                {
                    Console.WriteLine(p.name + " is eligible for discount");
                }

            }
        }


    }
}
