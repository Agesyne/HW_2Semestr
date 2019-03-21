using System;

namespace Template
{
    public class Program
    {
        /// <summary>
        /// The method prevents closing console when everething is done
        /// </summary>
        static void HoldConsoleOn()
        {
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }

        /// <summary>
        /// The method counts factorial number
        /// </summary>
        /// <param name="number"> N-th factorial number</param>
        /// <returns></returns>
        public static int CountFactorial(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int result = 1;

            for (int i = 1; i <= number; ++i)
            {
                result *= i;
            }

            return result;
        }

        /// <summary>
        /// Check if number entered wrong
        /// </summary>
        /// <param name="enteredString"> User input</param>
        /// <param name="number"> Read number from the string</param>
        /// <returns></returns>
        public static int isNumberEntered(string enteredString, out int number)
        {
            bool isNumberic = Int32.TryParse(enteredString, out number);
            if (!isNumberic)
            {
                throw new ArgumentOutOfRangeException("String is not a number");
            }
            return number;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The program counts Factorial");
            Console.Write("Enter number: ");
            string enteredString = Console.ReadLine();

            
            try
            {
                isNumberEntered(enteredString, out int number);
                Console.WriteLine($"{number}-th number is {CountFactorial(number)}");
            }
            catch (ArgumentOutOfRangeException e) when (e.ParamName == "String is not a number")
            {
                Console.WriteLine($"\"{enteredString}\" is not a number");
            }
            catch (ArgumentOutOfRangeException e) when (e.ParamName == "Number <=0")
            {
                Console.WriteLine("Number can't be <= 0");
            }

            HoldConsoleOn();
        }
    }
}
