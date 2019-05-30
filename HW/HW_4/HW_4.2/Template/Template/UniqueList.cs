using System.Collections.Generic;

namespace Structures
{
    /// <summary>
    /// ADS UniqueList implementation
    /// </summary>
    public class UniqueList : List<int>
    {
        /// <summary>
        /// Base internal storage
        /// </summary>
        private List<int> list = new List<int>();

        /// <summary>
        /// Add element
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Add(int value)
        {
            foreach (var i in list)
            {
                if (value == i)
                {
                    throw new CustomExceptions.TwiceArgumentAddingException();
                }
            }
            list.Add(value);
        }

        /// <summary>
        /// Remove existing element
        /// </summary>
        /// <param name="value">The removing value</param>
        public void Remove(int value)
        {
            foreach (var i in list)
            {
                if (value == i)
                {
                    list.Remove(value);
                    return;
                }
            }
            throw new CustomExceptions.MissingArgumentRemovingException();
        }

    }

}
