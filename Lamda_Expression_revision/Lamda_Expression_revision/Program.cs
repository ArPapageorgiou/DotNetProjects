namespace Lamda_Expression_revision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 4, 6, 7, 9, 12 };
            List<int> squares = list.ConvertAll(num => num * num);

            Console.WriteLine("Squares of numbers:");
            foreach (int square in squares) 
            { 
            Console.WriteLine(square);
            }
        }
    }
}
