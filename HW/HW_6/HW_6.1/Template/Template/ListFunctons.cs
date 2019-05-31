using System;
using System.Collections.Generic;

namespace StructureFunctions
{
    /// <summary>
    /// Some functions with list
    /// </summary>
    public static class ListFunctions
    {
        /// <summary>
        /// Make function to every element in given list
        /// </summary>
        /// <param name="list">The given list</param>
        /// <param name="transformation">The transforming function</param>
        /// <returns>The transformed list</returns>
        public static List<int> Map(List<int> list, Func<int, int> transformation)
        {
            if (list == null || transformation == null)
            {
                throw new ArgumentNullException();
            }
            var newList = new List<int>();

            for (var i = 0; i < list.Count; ++i)
            {
                newList.Add(transformation(list[i]));
            }
            return newList;
        }

        /// <summary>
        /// Make new list with matching elements elements from given list
        /// </summary>
        /// <param name="list">The given list</param>
        /// <param name="match">The matching function</param>
        /// <returns>The matched list</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> match)
        {
            if (list == null || match == null)
            {
                throw new ArgumentNullException();
            }

            var newList = new List<int>();
            foreach (var i in list)
            {
                if (match(i))
                {
                    newList.Add(i);
                }
            }
            return newList;
        }

        /// <summary>
        /// Accumulate value from all list plus starting value
        /// </summary>
        /// <param name="list">The given list</param>
        /// <param name="summator">The starting value</param>
        /// <param name="accumulating">The accumulating function</param>
        /// <returns>The accumulated value</returns>
        public static int Fold(List<int> list, int summator, Func<int, int, int> accumulating)
        {
            if (list == null || accumulating == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var i in list)
            {
                summator = accumulating(summator, i);
            }
            return summator;
        }

    }
}
