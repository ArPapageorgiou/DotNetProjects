using System.Collections.Generic;

namespace Delegates_Revision
{
    internal class Program
    {
        delegate bool ComparisonHandler<T>(T x, T y);

        static void Sort<T>(List<T> list, ComparisonHandler<T> comparison) 
        {
            for (int i = 0; i < list.Count - 1; i++) 
            {
                for (int j = i + 1; j < list.Count; j++) 
                {
                    if (comparison(list[j], list[i])) 
                    {
                        T temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {5,2,7,1,9};

            Sort(numbers, (x, y) => x < y);

            Console.WriteLine("Sorted in ascending order:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Sort(numbers, (x, y) => x > y);

            Console.WriteLine("Sorted in descending order:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
