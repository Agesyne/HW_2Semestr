using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    /// <summary>
    /// Enumerator for GerericList
    /// </summary>
    public class GenericListIEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// The list class
        /// </summary>
        GenericList<T> list = null;

        /// <summary>
        /// The current position
        /// </summary>
        private int position = -1;


        /// <summary>
        /// Constructor: fill list
        /// </summary>
        public GenericListIEnumerator(GenericList<T> list)
        {
            this.list = list;
        }

        /// <summary>
        /// Current element
        /// </summary>
        public T Current
        {
            get
            {
                if (position == -1 || position >= list.Count)
                {
                    throw new InvalidOperationException();
                }
                return list[position];
            }
            set
            {
                if (position == -1 || position >= list.Count)
                {
                    throw new InvalidOperationException();
                }
                list[position] = value;
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
            if (position < list.Count - 1)
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
