using System.Linq;

namespace List_Filtering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*In this kata you will create a function that takes a list of non-negative integers and strings and returns a new list with the strings filtered out.
            Example

            ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b"}) => {1, 2}
            ListFilterer.GetIntegersFromList(new List<object>(){1, "a", "b", 0, 15}) => {1, 0, 15}
            ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", "aasf", "1", "123", 123}) => {1, 2, 231}*/

            List<object> list = new List<object> { 1, "d", 5, "hello", 2, 9, "5"};

            foreach (var item in FilterList(list)) 
            { 
                Console.WriteLine(item);
            }

        }

        public static IEnumerable<int> FilterList(IEnumerable<object> listOfItems)
        {
            //return listOfItems?.Where(item => item is int).Cast<int>() ?? Enumerable.Empty<int>();


            //OfType() method automatically handles the filtering and casting, making it more concise and efficient
            return listOfItems?.OfType<int>() ?? Enumerable.Empty<int>();
        }

    }
}
