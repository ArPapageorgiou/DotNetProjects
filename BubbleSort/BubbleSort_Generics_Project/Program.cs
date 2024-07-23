namespace Generics_BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize arrays to be sorted
                int[] numbersToSort = { 5, 4, 2, 1, 3 };
                char[] charactersTosort = { 'a', 'd', 'c', 'b', 'e' };

                // Create Bubble sort objects for integers and characters
                Bubble<int> numbers = new Bubble<int>(numbersToSort);
                Bubble<char> characters = new Bubble<char>(charactersTosort);

                // Perform sorting on the integer array
                numbers.Print();
                numbers.BubbleSortAscending();
                numbers.Print();
                numbers.BubbleSortDescending();
                numbers.Print();

                // Perform sorting on the character array
                characters.Print();
                characters.BubbleSortAscending();
                characters.Print();
                characters.BubbleSortDescending();
                characters.Print();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred. {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
