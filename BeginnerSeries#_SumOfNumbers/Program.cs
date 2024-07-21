using System;

namespace BeginnerSeries3_SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Given two integers a and b, which can be positive or negative, find the sum 
            of all the integers between and including them and return it. If the two numbers 
            are equal return a or b.

            Note: a and b are not ordered!

            Examples (a, b) --> output (explanation)

            (1, 0) --> 1 (1 + 0 = 1)
            (1, 2) --> 3 (1 + 2 = 3)
            (0, 1) --> 1 (0 + 1 = 1)
            (1, 1) --> 1 (1 since both are same)
            (-1, 0) --> -1 (-1 + 0 = -1)
            (-1, 2) --> 2 (-1 + 0 + 1 + 2 = 2)*/

            int a = -7;
            int b = 2;

            Console.WriteLine(GetSum(a,b));

        }
        
        public static int GetSum(int a, int b)
     {
       
       int sum = 0;
       
       if(a < b)
       {
        
         while(a<=b)
         {
           sum += a;
           a++;
         }
         
         return sum;
         
       }
       
       else if(b<a)
       {
         
         while(b<=a)
         {
           sum += b;
           b++;
         }
         
         return sum;
         
       }
       
       else
       {
         return a;
       }
     }

    }
}