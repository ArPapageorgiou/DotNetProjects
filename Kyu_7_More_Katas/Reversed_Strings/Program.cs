namespace Reversed_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Complete the solution so that it reverses the string passed into it.

            'world'  =>  'dlrow'
            'word'   =>  'drow'*/

            string someString = "Hello world";
            Console.WriteLine(ReverseString(someString));

        }

        /*public static string ReverseString(string str)
        {
            str = str.Trim();

            char[] strArray = str.ToCharArray();

            string result = "";

            foreach (char c in strArray)
            {
                result = c + result;
            }

            return result;
        }*/


        //A much more concise way of doing this.
        public static string ReverseString(string str)
        {
            char[] strArray = str.ToCharArray();
            Array.Reverse(strArray);

            return new string(strArray);
        }

    }
}
