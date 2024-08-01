using System.Xml;

namespace ConverNumberToString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x = 123;
            Console.WriteLine(NumberToString(x));
        }

        //public static string NumberToString(int num)
        //{
        //    return num.ToString();
        //}

        //public static string NumberToString(int num)
        //{
        //    string result = $"{num}";
        //    return result;
        //}

        //public static string NumberToString(int num)
        //{
        //    return num + "";
        //}

        //public static string NumberToString(int num)
        //{
        //    return string.Format("{0}", num);
        //}


        //The manual version
        public static string NumberToString(int num)
        {
            if(num == 0)
            {
                return "0";
            }

            bool isNegative = num < 0;

            if(isNegative) 
            {
                num = - num; // Make the number positive for processing
            }

            string result = "";

            while (num > 0)
            {
                int digit = num % 10; // Get the last digit by getting the remainder. eg. 123 % 10 = 3
                
                result = (char)(digit + '0') + result; // Convert digit to char and prepend.
                                                       // Prepending ensures that the digits are added in the correct order

                num = num / 10; // Remove the last digit and go through the process again
            }

            if (isNegative)
            {
                result = "-" + result; // Add the negative sign if necessary
            }

            return result;
        }
    }
}
