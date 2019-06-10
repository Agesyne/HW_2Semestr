using System.Collections.Generic;

namespace GenericSet
{
    /// <summary>
    /// Comoparer for integers
    /// </summary>
    public class InteregerComparer : IComparer<int>
    {
        /// <summary>
        /// Compare 2 integers
        /// </summary>
        public int Compare(int x, int y)
        {
            return (x > y) ? 1 : (x == y) ? 0 : -1;
        }
    }
}
