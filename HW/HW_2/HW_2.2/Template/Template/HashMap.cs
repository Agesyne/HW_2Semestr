using System;

namespace Structures
{
    /// <summary>
    /// ADS HashMap
    /// </summary>
    public class HashMap
    {
        /// <summary>
        /// The storage of values
        /// </summary>
        private LinkedList[] map;

        /// <summary>
        /// Get hashcode by value
        /// </summary>
        /// <param name="value">The given value</param>
        /// <returns></returns>
        private int GetHash(int value)
        {
            return Math.Abs(value) % map.Length;
        }

        /// <summary>
        /// Add value in hashtable
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Add(int value)
        {
            int key = GetHash(value);
            map[key].Add(value, 0);
        }

        /// <summary>
        /// Delete value from hashtable
        /// </summary>
        /// <param name="value">The deleting value</param>
        public void Delete(int value)
        {
            int key = GetHash(value);
            int cellLength = map[key].Count;
            for (var i = 0; i < cellLength; ++i)
            {
                if (map[key].GetNthValue(i) == value)
                {
                    map[key].Delete(i);
                    return;
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Check if a value exist in hashtable
        /// </summary>
        /// <param name="value">The given value</param>
        /// <returns></returns>
        public bool Exist(int value)
        {
            int key = GetHash(value);
            int cellLength = map[key].Count;
            for (var i = 0; i < cellLength; ++i)
            {
                if (map[key].GetNthValue(i) == value)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Constactor with choice of internal storage length
        /// </summary>
        /// <param name="length">The wanted length</param>
        public HashMap(int length = 8)
        {
            map = new LinkedList[length];
            for (var i = 0; i < length; ++i)
            {
                map[i] = new LinkedList();
            }
        }
    }
}
