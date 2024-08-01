namespace Remove_First_and_Last_Character
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Your goal is to create a function that removes the first and last characters of a string. 
             * You're given one parameter, the original string. You don't have to worry about strings with less than two characters.*/

            string wordOrPhrase = "Hello world!";
            Console.WriteLine(Remove_char(wordOrPhrase));

        }

        /*public static string Remove_char(string str)
        {
            str = str.Remove(0,1);
            str = str.Remove(str.Length -1, 1);

            return str;
        }*/

        //Substring(startIndex, length) is another, more concise way of removing the first and last char of the string.
        public static string Remove_char(string str)
        {
            return str.Substring(1, str.Length - 2);
        }

    }
}
