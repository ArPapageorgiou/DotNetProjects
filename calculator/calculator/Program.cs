using System;

namespace calculator
{
    internal class Program
    {
        static double result;
        static double input1, input2;
        static string operation;

        static void Main(string[] args)
        {
            bool menu = true;

            do
            {
                do
                {
                    getDouble("Please insert a number: ", out input1);
                    getDouble("Please insert a second number: ", out input2);
                    Console.Write("Please select the kind of operation you wish to perform (-, +, *, /): ");
                    operation = Console.ReadLine();

                    if (isValidOperator(operation))
                    {
                        calculateresult();
                        displayResult();
                        Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Invalid operator.Please try again.");
                        Console.ReadLine();
                    }

                }
                while (!isValidOperator(operation));
            } while (menu = true);


        }

        static void getDouble(string prompt, out double value)
        {
            while (true)
            { 
            Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (double.TryParse(userInput, out value))
                {
                    break;
                }
                else 
                { 
                Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static bool isValidOperator(string op) 
        {
            return op == "+" || op == "-" || op == "*" || op == "/";
        }

        static void calculateresult()
        {
            if (operation == "-")
            {
                result = input1 - input2;
               
            }

            else if (operation == "+")
            {
                result = input1 + input2;
            }

            else if (operation == "*")
            {
                result = input1 * input2;
            }

            else if (operation == "/")
            {
                if (input2 != 0)
                {
                    result = input1 / input2;
                }
                else 
                { 
                Console.WriteLine("ERROR: Division by zero in not possible!");
                    result = 0;
                 }
            }

           
            
        }

        static void displayResult()
        { Console.WriteLine(input1 + operation + input2 + "= " + result); }





    }
}
