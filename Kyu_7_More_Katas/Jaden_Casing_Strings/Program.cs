using System.Text;

namespace Jaden_Casing_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Jaden Smith, the son of Will Smith, is the star of films such as The Karate Kid (2010) and After Earth (2013). Jaden is also known for some of his philosophy that he delivers via Twitter. When writing on Twitter, he is known for almost always capitalizing every word. For simplicity, you'll have to capitalize each word, check out how contractions are expected to be in the example below.

            Your task is to convert strings to how they would be written by Jaden Smith. The strings are actual quotes from Jaden Smith, but they are not capitalized in the same way he originally typed them.

            Example:

            Not Jaden-Cased: "How can mirrors be real if our eyes aren't real"
            Jaden-Cased:     "How Can Mirrors Be Real If Our Eyes Aren't Real"
            */

            string someString = "How can mirrors be real if our eyes aren't real";
            Console.WriteLine(JadenCasing(someString));

        }

        /*public static string JadenCasing(string str)
        {
            string[] strArray = str.Split(' ');

            string result = "";
            
            foreach(string word in strArray)
            {
                char[] charArray = word.ToCharArray();
                charArray[0] = Char.ToUpper(charArray[0]);
                result += ($" {new string(charArray)}");
            }

            return result.TrimStart();

        }*/


        //A more efficient implementation that avoids repeated string concatenation by using StringBuilder.
        //By using StringBuilder we can access and manipulate characters in a string directly instead of creating a character array for each word.
        //StringBuilder provides a mutable buffer where characters can be efficiently added without creating new string objects at each step.
        public static string JadenCasing(string str)
        {
            string[] strArray = str.Split(' ');

            var builder = new StringBuilder();

            foreach(string word in strArray)
            {
                StringBuilder sb = new StringBuilder(word);
                sb[0] = char.ToUpper(sb[0]);
                builder.Append(sb);
                builder.Append(' ');
            }

            return builder.ToString();

        }

    }
}
