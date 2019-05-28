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
        /// Interface determined GetHash method
        /// </summary>
        private HashFunction HashCode = new HashFunctionByRestDividing();

        /// <summary>
        /// Add value in hashtable
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Add(int value)
        {
            int key = HashCode.GetHash(value, map.Length);
            map[key].Add(value, 0);
        }

        /// <summary>
        /// Delete value from hashtable
        /// </summary>
        /// <param name="value">The deleting value</param>
        public void Delete(int value)
        {
            int key = HashCode.GetHash(value, map.Length);
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
            int key = HashCode.GetHash(value, map.Length);
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
        /// Constructor with choice of internal storage length and hash function
        /// </summary>
        /// <param name="length">The wanted length</param>
        /// <param name="hash">The wanted hash function</param>
        public HashMap(HashFunction hash = null, int length = 8)
        {
            if (hash != null)
            {
                HashCode = hash;
            }

            map = new LinkedList[length];
            for (var i = 0; i < length; ++i)
            {
                map[i] = new LinkedList();
            }
        }
    }
}
