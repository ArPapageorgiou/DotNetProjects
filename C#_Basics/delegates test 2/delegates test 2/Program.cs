using System.Data.SqlTypes;

namespace delegates_test_2
{
    delegate bool eligibleForDiscount(Product anyProduct);
    internal class Program
    {
        static void Main(string[] args)
        {
          List<Product> ProductsList = new List<Product>();
            ProductsList.Add(new Product() { name = "bread", price = 2 });
            ProductsList.Add(new Product() { name = "milk", price = 2 });
            ProductsList.Add(new Product() { name = "soda", price = 1 });
            ProductsList.Add(new Product() { name = "detergent", price = 8 });
            ProductsList.Add(new Product() { name = "juice", price = 3 });
            ProductsList.Add(new Product() { name = "wine", price = 7 });

            eligibleForDiscount delegateOfDiscount = new eligibleForDiscount(discountDelegateMethod);
            Product.discountMethod(ProductsList, delegateOfDiscount);
        }

        public static bool discountDelegateMethod(Product product) 
        {
            if (product.price >= 5)
            {
                return true;
            }
            else 
            { 
            return false;
            }
        }


    }

    
}
