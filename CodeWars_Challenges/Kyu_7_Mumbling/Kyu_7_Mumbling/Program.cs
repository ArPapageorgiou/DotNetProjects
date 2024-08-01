namespace Kyu_7_Mumbling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*This time no story, no theory.The examples below show you how to write function accum:
            Examples:

            accum("abcd")-> "A-Bb-Ccc-Dddd"
            accum("RqaEzty")-> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
            accum("cwAt")-> "C-Ww-Aaa-Tttt"*/
            string str = "abfd";
            var stringResult = Accum(str);
            Console.WriteLine(stringResult);

        }

        static bool IsAllLetters(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Input must be a valid string. It cannot be null or empty.");
            }

            foreach(char c in str)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }

        /*static string Accum(string str)
        {
            List<string> stringList = new List<string>();

            if (!IsAllLetters(str))
            {
                return string.Empty;
            }
                var stringArray = str.ToCharArray();
               
                int count = 0;
                
                foreach(char c in stringArray)
                {
                    count++;
                    string stringLetter = c.ToString().ToUpper();

                    for (int i = 1; i < count; i++)
                    {
                        stringLetter += c.ToString().ToLower();
                    }

                    stringList.Add(stringLetter);
                }

            

            string result = string.Join("-", stringList);
            return result;
        }*/


        //I can avoid excessive boxing and unboxing with this revised version.
        
        //In the previous version I Constructed stringLetter using repeated
        //concatenation within the loop.
        //Each concatenation operation(stringLetter += ...) creates a new string object,
        //which can be inefficient because strings are immutable in C#.
        
        //Original: Repeats the lowercase character using a for loop and string concatenation.
        //Revised: Uses new string (char.ToLower(c), i) to handle repetition.
        //The use of new string(char.ToLower(c), i) and direct iteration reduces
        //the overall time complexity.
        public static string Accum(string str)
        {
            if (!IsAllLetters(str))
            {
                return string.Empty;
            }

            List<string> stringList= new List<string>();

            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                string part = char.ToUpper(c).ToString() + new string(char.ToLower(c), i);
                stringList.Add(part);
            }

            var result = string.Join("-", stringList);
            return result;
            
        }

    }
}
