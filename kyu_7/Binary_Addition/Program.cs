using System;
using System.Linq;

namespace Ninary_Addition
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Implement a function that adds two numbers together and returns 
            their sum in binary. The conversion can be done before, or after 
            the addition.

            The binary number returned should be a string.

            Examples:(Input1, Input2 --> Output (explanation)))

            1, 1 --> "10" (1 + 1 = 2 in decimal or 10 in binary)
            5, 9 --> "1110" (5 + 9 = 14 in decimal or 1110 in binary)*/
            
            int a = 5;
            int b = 9;

            Console.WriteLine(AddBinary(a,b));

        }
        
        /*public static string AddBinary(int a, int b)
        {
            int sum = a + b;
            string binarySum = "";

            if(sum == 0) return "0";

            while(sum > 0)
            {
                int remainder = sum % 2;
                binarySum  = remainder.ToString() + binarySum;
                sum /= 2; 
            }

            return binarySum;

        }*/

        //This is a much shorter way to do this. Quite handy.
        static static string AddBinary(int a, int b)
        {
            Convert.ToString(a+b, 2);
        }

    }
}