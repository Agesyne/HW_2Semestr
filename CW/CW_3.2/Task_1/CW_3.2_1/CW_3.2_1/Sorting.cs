using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BubbleSort<T>
    {
        /// <summary>
        /// Check if list is sorted
        /// </summary>
        /// <param name="input">The checking list</param>
        /// <returns></returns>
        public static bool IsSorted(List<T> input, IComparer<T> comparer)
        {
            for (var i = 0; i < input.Count - 1; ++i)
            {
                if (comparer.Compare(input[i], input[i + 1]) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sort list of objects in given order
        /// </summary>
        /// <param name="input">The sorting list of objects</param>
        /// <param name="comparer">Order determiner</param>
        /// <returns></returns>
        public static List<T> Sort(List<T> input, IComparer<T> comparer)
        {
            if (input == null)
            {
                throw new NullReferenceException();
            }
            if (comparer == null)
            {
                throw new NullReferenceException();
            }

            for (var i = 0; i < input.Count; ++i)
            {
                for (var j = 0; j < input.Count - i - 1; ++j)
                {
                    if (comparer.Compare(input[j], input[j + 1]) == 1)
                    {
                        var tmp = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = tmp;
                    }
                }
            }
            PrintList(input);
            return input;
        }

        /// <summary>
        /// Print given list
        /// </summary>
        /// <param name="input">The printing list</param>
        static void PrintList(List<T> input)
        {
            foreach (var i in input)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
