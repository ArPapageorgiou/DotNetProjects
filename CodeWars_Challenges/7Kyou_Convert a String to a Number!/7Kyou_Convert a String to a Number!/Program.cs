namespace _7Kyou_Convert_a_String_to_a_Number_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //We need a function that can transform a string into a number. What ways of achieving this do you know?

            //Note: Don't worry, all inputs will be strings, and every string is a perfectly valid representation of an integral number.
            string someString = "143";
            int stringToInt = ManualStringToNumber(someString);
            Console.WriteLine(stringToInt);

        }

        public static int ConvertStringToNumber(String str)
        {
            int result = Convert.ToInt32(str);
            return result;
        }

        public static int ParseStringToNumber(String str)
        {
            int result = int.Parse(str);
            return result;
        }

        public static int ManualStringToNumber(String str)
        {
            //check for null and throw exception if true
            if(str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            
            int result = 0;
            bool isNegative = false;
            int startIndex = 0;

            if (str[0] == '-')//chack if number is a negative
            {
                isNegative = true;//used to assign the minus symbol to the result at the end
                startIndex = 1;//start from second index in case number is a negative
            }

            for (int i = startIndex; i < str.Length; i++)
            {
                int digit = str[i] - '0';//convert each char to int
                result = result * 10 + digit;
            }

            return isNegative ? -result : result;//attach minus symbol to the int in case isNegative is true 
        }
    }
}
