namespace Delegates_revision
{
    internal class Program
    {
        delegate double AverageCalculator(List<int> numbers);
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {1,2,3,4,5};
            AverageCalculator calculator = CalculateAverage;

            double average = calculator(numbers);
            Console.WriteLine("Average: " + average);
        }

        static double CalculateAverage(List<int> numbers) 
        { 
            int sum = 0;
            foreach (int num in numbers) 
            { 
            sum += num;
            }

            double average = sum/numbers.Count;

            return average;
        }
    }
}
