using System;

namespace Regex_validate_PIN_code
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits.

            If the function is passed a valid PIN string, return true, else return false.

            Examples (Input --> Output)

            "1234"   -->  true
            "12345"  -->  false
            "a234"   -->  false*/

            string pinNumber = "123a";

            Console.WriteLine(ValidatePin(pinNumber));
        }
        
        /*public static bool ValidatePin(string pin)
        {

            if (pin == null) return false;

            if (pin.Length == 0) return false;

            char[] pinArray = pin.ToCharArray();

            foreach (char c in pinArray)
            {
                if (!char.IsDigit(c)) return false;
            }

            if(pin.Length == 4 || pin.Length == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        //Another way of solving this using LINQ.

        public static bool ValidatePin(string pin)
        {
            return pin.All(n => char.IsDigit(n)) && (pin.Length == 4 || pin.Length == 6);
        }

    }
}