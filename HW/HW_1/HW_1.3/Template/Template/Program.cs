using System;

namespace Sorting
{
    public class Program
    {
        /// <summary>
        /// Locally sway 2 variables
        /// </summary>
        /// <param name="a">First var</param>
        /// <param name="b">Second var</param>
        private static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// Sort given int array
        /// </summary>
        /// <param name="sortingArray">The sorting array</param>
        public static void BubbleSort(int[] sortingArray)
        {
            if (sortingArray == null)
            {
                throw new ArgumentNullException();
            }

            for (var i = 0; i < sortingArray.Length; ++i)
            {
                for (var j = 0; j < sortingArray.Length - 1 - i; ++j)
                {
                    if (sortingArray[j] > sortingArray[j + 1])
                    {
                        Swap(ref sortingArray[j], ref sortingArray[j + 1]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
