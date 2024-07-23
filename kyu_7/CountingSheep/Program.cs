using System;

namespace CountingSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Consider an array/list of sheep where some sheep may be missing from their 
            place. We need a function that counts the number of sheep present in the 
            array (true means present).

            For example,

            [true,  true,  true,  false,
            true,  true,  true,  true ,
            true,  false, true,  false,
            true,  false, false, true ,
            true,  true,  true,  true ,
            false, false, true,  true]
            The correct answer would be 17.

            Hint: Don't forget to check for bad values like null/undefined*/

            bool[] flock = { true, false, true, false,};

            Console.WriteLine(CountSheeps(flock));


        }


        public static int CountSheeps(bool[] sheeps)

        {
            int count = 0;

            foreach (bool sheepsItem in sheeps) 
            {
                if (sheepsItem == true)
                {
                    count++;
                }

            }

            return count;


        }

        


    }
}

