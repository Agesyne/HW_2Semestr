using System;

namespace Structures
{
    /// <summary>
    /// ADS UniqueList implementation
    /// </summary>
    public class UniqueList : LinkedList
    {
        /// <summary>
        /// Check if given value exist
        /// </summary>
        /// <param name="value">The searching value</param>
        /// <returns>The index of found element</returns>
        private int FindValue(int value)
        {
            if (head == null)
            {
                return -1;
            }

            var indexCounter = 0;
            for (var current = head; current != null; current = current.Next)
            {
                if (current.Value == value)
                {
                    return indexCounter;
                }
                ++indexCounter;
            }
            return -1;
        }

        /// <summary>
        /// Add element
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Add(int value, int index = 0)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (FindValue(value) != -1)
            {
                throw new CustomExceptions.TwiceArgumentAddingException();
            }

            AddElementArterGiven(value, FindElement(index));
            ++Count;
        }

        /// <summary>
        /// Remove existing element
        /// </summary>
        /// <param name="value">The removing value</param>
        public void Delete(int value)
        {
            var deletingElementIndex = FindValue(value);
            if (deletingElementIndex == -1)
            {
                throw new CustomExceptions.MissingArgumentRemovingException();
            }

            DeleteElementAfterGiven(FindElement(deletingElementIndex));
            --Count;
        }

        /// <summary>
        /// Set new value for n'th list element
        /// </summary>
        /// <param name="value">The new value</param>
        /// <param name="index">Index of the element value to be setted</param>
        public void SetNthValue(int value, int index)
        {
            var foundElementIndex = FindValue(value);
            if (foundElementIndex != -1 && foundElementIndex != index)
            {
                throw new CustomExceptions.TwiceArgumentAddingException();
            }

            var currentElement = FindElement(index);
            if (currentElement == null)
            {
                head.Value = value;
            }
            else
            {
                if (currentElement.Next == null)
                {
                    throw new DataMisalignedException();
                }
                currentElement.Next.Value = value;
            }
        }
    }

}
