namespace _7_Kyou_Growth_of_a_Population
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //p0, percent, aug(inhabitants coming or leaving each year), p(population to equal or surpass)

            //the function nb_year should return n number of entire years needed to get a population greater or equal to p.

            //aug is an integer, percent a positive or null floating number, p0 and p are positive integers(> 0)

            Console.WriteLine(NbYear(1000, 10, 100, 2500));
        }

        public static int NbYear(int p0, double percent, int aug, int p)
        {

            int yearCount = 0;
            double percentageAsDecimal = percent / 100;


            while (p0 < p)
            {
                double populationGrowth = p0 * percentageAsDecimal;
                p0 = p0 + (int)populationGrowth + aug;
                yearCount++;
            }


            return yearCount;

        }

    }
}
