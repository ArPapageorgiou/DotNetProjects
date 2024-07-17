namespace Kyou_7_Convert_a_Boolean_to_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Implement a function which convert the given boolean value into its string representation.

            //Note: Only valid inputs will be given.

            bool someBoolean = true;
            string boolToString = BooleanToStringShortVersion(someBoolean);
            Console.WriteLine(boolToString);


        }

        public static string BooleanToString(bool b)
        {
            string result = "";

            if (b == true)
            {
                result = b.ToString();
            }
            else
            {
                result = b.ToString();
            }

            return result;
        }

        public static string BooleanToStringShortVersion(bool b)
        {
            return b ? "True" : "False";
        }

    }
}
