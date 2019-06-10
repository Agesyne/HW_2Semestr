using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericSet
{
    /// <summary>
    /// Enumerator for GerericSet
    /// </summary>
    public class GenericSetIEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// The set class
        /// </summary>
        GenericSet<T> set = null;

        /// <summary>
        /// The current position
        /// </summary>
        private int position = -1;


        /// <summary>
        /// Constructor: fill set
        /// </summary>
        public GenericSetIEnumerator(GenericSet<T> set)
        {
            this.set = set;
        }

        /// <summary>
        /// Current element
        /// </summary>
        public T Current
        {
            get
            {
                if (position == -1 || position >= set.Count)
                {
                    throw new InvalidOperationException();
                }
                return set[position];
            }
        }

        /// <summary>
        /// ...Something just to be
        /// </summary>
        object IEnumerator.Current => throw new NotImplementedException();

        /// <summary>
        /// Make step to next element
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (position < set.Count - 1)
            {
                ++position;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Stop walking throw
        /// </summary>
        public void Reset() => position = -1;

        /// <summary>
        /// ...Something just to be
        /// </summary>
        public void Dispose() { }
    }

}
