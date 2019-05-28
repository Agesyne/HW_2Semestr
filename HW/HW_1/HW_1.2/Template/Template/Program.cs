using System;

namespace MathFibonacci
{
    public class Program
    {
        /// <summary>
        /// Get n'th Fibonacci number
        /// </summary>
        /// <param name="number">The Fibonacci number u wanna get</param>
        /// <returns></returns>
        public static int GetNthFibonacciNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (number == 0)
            {
                return 0;
            }
            
            int prev = 0;
            int cur = 0;
            int next = 1;

            for (var i = 1; i < number; ++i)
            {
                prev = cur;
                cur = next;
                next = prev + cur;
            }

            return next;
        }

        static void Main(string[] args)
        {
        }
    }
}
