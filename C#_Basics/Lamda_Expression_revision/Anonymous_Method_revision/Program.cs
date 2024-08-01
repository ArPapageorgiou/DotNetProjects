namespace Anonymous_Method_revision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = SumEvenNumbers(numbers);

            Console.WriteLine("Sum of even numbers: " + sum); 



        }

        static int SumEvenNumbers(List<int> numbers) 
        { 
            int sum = 0;
            numbers.ForEach(delegate (int num)
            {
                if (num % 2 == 0) 
                {
                    sum += num;
                }
            });
            return sum;

        }
    }
}
