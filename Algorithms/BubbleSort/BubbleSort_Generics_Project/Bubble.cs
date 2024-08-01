namespace Generics_BubbleSort
{
    // Class to perform bubble sort on an array of generic type T
    public class Bubble<T> where T : IComparable<T> 
    {
        // Property to store the array
        public T[] Array { get; private set; }
        
        // Constructor to initialize the array
        public Bubble(T[] array)
        {
            if (array == null)
            {
                throw new NullArrayException("Array cannot be null.");
            }

            Array = array;
        }

        // Method to print the array elements
        public void Print() 
        {
            if (Array == null || Array.Length == 0)
            {
                Console.WriteLine("Array is empty. Nothing to print.");
                return;
            }

            Console.WriteLine(String.Join(", ", Array));
        }

        // Private method to swap elements at specified indices
        private void Swap(int index1, int index2)
        {
            // Ensure indices are within bounds
            if (index1 < 0 || index1 >= Array.Length || index2 < 0 || index2 >= Array.Length)
            {
                Console.WriteLine("Swap operation failed: Index out of range.");
                return;
            }

            // Perform the swap
            T temp = Array[index1];
            Array[index1] = Array[index2];
            Array[index2] = temp;
        }

        // Method to perform bubble sort in ascending order
        public void BubbleSortAscending() 
        {
            try
            {
                if (Array == null || Array.Length == 0)
                {
                    Console.WriteLine("Array is empty. Cannot perform sort (ascending).");
                    return;
                }

                for (int i = 0; i < Array.Length - 1; i++)
                {
                    for (int j = 0; j < Array.Length - i - 1; j++)
                    {
                        if (Array[j].CompareTo(Array[j + 1]) > 0)
                        {
                            Swap(j, j + 1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during bubble sort (ascending).");
            }
        }

        // Method to perform bubble sort in descending order
        public void BubbleSortDescending()
        {
            try
            {
                if (Array == null || Array.Length == 0)
                {
                    Console.WriteLine("Array is empty. Cannot perform sort (descending).");
                    return;
                }

                for (int i = 0; i < Array.Length - 1; i++)
                {
                    for (int j = 0; j < Array.Length - i - 1; j++)
                    {
                        if (Array[j].CompareTo(Array[j + 1]) < 0)
                        {
                            Swap(j, j + 1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred during bubble sort (descending).");
            }
        }
    }
}