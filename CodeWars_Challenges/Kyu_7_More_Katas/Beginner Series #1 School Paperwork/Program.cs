namespace Beginner_Series__1_School_Paperwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Your classmates asked you to copy some paperwork for them.You know that there are 'n' classmates and the paperwork has 'm' pages.



            //Your task is to calculate how many blank pages do you need. If n < 0 or m< 0 return 0.
            //Example:

            //n = 5, m = 5: 25
            //n = -5, m = 5:  0

            Console.WriteLine(Paperwork(0, 0));
            Console.WriteLine(Paperwork(-2, 0));
            Console.WriteLine(Paperwork(0, -4));
            Console.WriteLine(Paperwork(2, 0));
            Console.WriteLine(Paperwork(0, 3));
            Console.WriteLine(Paperwork(5, 5));

        }

        //public static int Paperwork(int n, int m)
        //{
        //    int result; ;

        //    if (n == 0 || m ==0)
        //    {
        //        result = 0 ;
        //        return result;
        //    }
        //    else if (n < 0 || m < 0)
        //    {
        //        result = 0;
        //        return result;
        //    }
        //    else
        //    {
        //        return n * m;
        //    }
            
        //}

        //Or just use a ternary operator like this
        public static int Paperwork(int n, int m) => (n > 0 && m > 0) ? n * m : 0;
    }
}
