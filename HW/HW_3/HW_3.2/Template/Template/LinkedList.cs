using System;

namespace Structures
{
    /// <summary>
    /// ADS LinkedList
    /// </summary>
    public class LinkedList
    {
        /// <summary>
        /// Internal class - element of list
        /// </summary>
        private class ListElement
        {
            public ListElement Next { get; set; }
            public int Value { get; set; }

            public ListElement(int value, ListElement next = null)
            {
                Next = next;
                Value = value;
            }
        }

        /// <summary>
        /// The first element
        /// </summary>
        private ListElement head = null;
        /// <summary>
        /// Number of element in list
        /// </summary>
        public int Count { get; protected set; } = 0;

        /// <summary>
        /// Add new element after given one
        /// </summary>
        /// <param name="value">The value of new element</param>
        /// <param name="prev">The new element will be added after this one</param>
        private void AddElementArterGiven(int value, ListElement prev)
        {
            var newElement = new ListElement(value);
            if (prev == null)
            {
                newElement.Next = head;
                head = newElement;
            }
            else
            {
                newElement.Next = prev.Next;
                prev.Next = newElement;
            }
        }
        /// <summary>
        /// Add new element in list
        /// </summary>
        /// <param name="value">The value of new element</param>
        /// <param name="index">Index of the place element to be added</param>
        public void Add(int value, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentElement = head;
            if (index == 0)
            {
                currentElement = null;
            }
            else
            {
                for (var i = 1; i < index; ++i)
                {
                    currentElement = currentElement.Next;
                }
            }
            AddElementArterGiven(value, currentElement);
            ++Count;
        }

        /// <summary>
        /// Delete element after given one
        /// </summary>
        /// <param name="prev">The element will be deleted after this one</param>
        private void DeleteElementAfterGiven(ListElement prev)
        {
            if (prev == null)
            {
                head = head.Next;
            }
            else
            {
                if (prev.Next == null)
                {
                    throw new DataMisalignedException();
                }
                prev.Next = prev.Next.Next;
            }
        }
        /// <summary>
        /// Delete element in list
        /// </summary>
        /// <param name="index">Index of the place element to be deleted</param>
        public void Delete(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentElement = head;
            if (index == 0)
            {
                currentElement = null;
            }
            else
            {
                for (var i = 1; i < index; ++i)
                {
                    currentElement = currentElement.Next;
                }
            }
            DeleteElementAfterGiven(currentElement);
            --Count;
        }

        /// <summary>
        /// Check if list is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// Get value of n'th list element
        /// </summary>
        /// <param name="index">Index of the element value to be gotten</param>
        /// <returns></returns>
        public int GetNthValue(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentElement = head;
            for (var i = 0; i < index; ++i)
            {
                currentElement = currentElement.Next;
            }

            return currentElement.Value;
        }

        /// <summary>
        /// Set new value for n'th list element
        /// </summary>
        /// <param name="value">The new value</param>
        /// <param name="index">Index of the element value to be setted</param>
        public void SetNthValue(int value, int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentElement = head;
            for (var i = 0; i < index; ++i)
            {
                currentElement = currentElement.Next;
            }

            currentElement.Value = value;
        }

    }
}