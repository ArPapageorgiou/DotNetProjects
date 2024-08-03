using System.Text;

namespace Square_Every_Digit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Welcome. In this kata, you are asked to square every digit of a number and concatenate them.

            For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1. (81-1-1-81)*/

            int n = 9119;

            Console.WriteLine(SquareEveryDigit(n));

        }

        public static int SquareEveryDigit(int n)
        {
            var sb = new StringBuilder();

            foreach (char c in n.ToString())
            {
                int digit = int.Parse(c.ToString());
                sb.Append(digit * digit);
            }

            return int.Parse(sb.ToString());
        }

    }
}
