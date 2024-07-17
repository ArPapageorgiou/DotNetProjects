using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _7_kyou_Codewars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Given an array of integers as strings and numbers, return the sum of the array values as if all were numbers.

            //Return your answer as a number.
            
            object[] objectArray = {1, "3", 5, 6, "8", "3"};

            Console.WriteLine(SumMix(objectArray));


        }

        public static int SumMix(object[] x)
        {
            int result = 0;

            foreach(object element in x)
            {
                if(element is string)
                {
                    string numberString = element.ToString();
                    int number = int.Parse(numberString);
                    result += number;
                }

                if(element is int)
                {
                    int numberInt = Convert.ToInt32(element);
                    result += numberInt;
                }
            }

                    return result;
        }

    }
}
