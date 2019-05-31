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
        private int GetHash(int value, int cellNumbers) => Math.Abs(value) % cellNumbers;

        /// <summary>
        /// Resize hashTable
        /// </summary>
        private void Resize()
        {
            var newMap = new LinkedList[map.Length * 2];
            for (var i = 0; i < newMap.Length; ++i)
            {
                newMap[i] = new LinkedList();
            }

            foreach (var i in map)
            {
                for (var j = 0; j < i.Count; ++j)
                {
                    int key = GetHash(i.GetNthValue(j), newMap.Length);
                    newMap[key].Add(i.GetNthValue(j), 0);
                }
            }
            map = newMap;
        }

        /// <summary>
        /// Check if resize needs
        /// </summary>
        private void MaybeResize()
        {
            int elementsNumber = 0;
            foreach (var i in map)
            {
                elementsNumber += i.Count;
            }

            if (elementsNumber / map.Length >= 2)
            {
                Resize();
            }
        }

        /// <summary>
        /// Add value in hashtable
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Add(int value)
        {
            int key = GetHash(value, map.Length);
            map[key].Add(value, 0);
            MaybeResize();
        }

        /// <summary>
        /// Delete value from hashtable
        /// </summary>
        /// <param name="value">The deleting value</param>
        public void Delete(int value)
        {
            int key = GetHash(value, map.Length);
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
        public bool Exist(int value)
        {
            int key = GetHash(value, map.Length);
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
