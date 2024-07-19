namespace Kyu_7_BasicMathematicalOperations
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Your task is to create a function that does four basic mathematical operations.

            The function should take three arguments -operation(string / char), value1(number), value2(number).
            The function should return result of numbers after applying the chosen operation.
            Examples(Operator, value1, value2)-- > output

            ('+', 4, 7)-- > 11
            ('-', 15, 18)-- > -3
            ('*', 5, 5)-- > 25
            ('/', 49, 7)-- > 7*/

            double x = 92.00;
            double y = 31.00;
            var result = basicOp('/', x, y);
            Console.WriteLine(result);
        }

        /*public static double basicOp(char operation, double value1, double value2)
        {
            if (value2 == 0 && operation == '/')
            {
                throw new ArgumentException("Cannot divide by 0");
            }
            else
            {
                switch (operation)
                {
                    case ('+'):
                        return value1 + value2;

                    case ('-'):
                        return value1 - value2;

                    case ('*'):
                        return value1 * value2;

                    case ('/'):
                        return value1 / value2;

                    default:
                        throw new ArgumentException("Invalid operation symbol");
                }

            }

        }*/

        
        //I like this syntax though. it's concise and easy to read.

        public static double basicOp(char operation, double value1, double value2)
        {
            if (value2 == 0 && operation == '/')
            {
                throw new ArgumentException("Cannot divide by 0");
            }

            return operation switch
            {
                '+' => value1 + value2,
                '-' => value1 - value2,
                '*' => value1 * value2,
                '/' => value1 / value2,
                _ => throw new ArgumentException("Invalid operation symbol")
            };

        }

    }
}
