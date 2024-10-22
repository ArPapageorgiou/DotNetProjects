using System.Text;

namespace Complementary_DNA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". 
             * Your function receives one side of the DNA (string, except for Haskell); 
             * you need to return the other complementary side. 
             * DNA strand is never empty or there is no DNA at all (again, except for Haskell).

            Example: (input --> output)

            "ATTGC" --> "TAACG"
            "GTAT" --> "CATA"*/

            Console.WriteLine(DnaStrings("ATGC"));

        }

        public static string DnaStrings(string dnaHalf)
        {
            StringBuilder otherHalf = new StringBuilder();
            
            foreach (char c in dnaHalf)
            {
                switch (c)
                {
                    case 'A':
                        otherHalf.Append('T');
                        break;

                    case 'T':
                        otherHalf.Append('A');
                        break;

                    case 'G':
                        otherHalf.Append('C');
                        break;

                    case 'C':
                        otherHalf.Append('G');
                        break;
                }
            }

            return otherHalf.ToString().ToUpper();
        }
    }
}
