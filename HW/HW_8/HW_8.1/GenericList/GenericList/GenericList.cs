using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    /// <summary>
    /// ADS LinkedList
    /// </summary>
    public class GenericList<T> : IList<T>
    {
        /// <summary>
        /// Internal class - element of list
        /// </summary>
        private class ListElement
        {
            public ListElement Next { get; set; }
            public T Value { get; set; }

            public ListElement(T value, ListElement next = null)
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
        /// Constructor
        /// </summary>
        public GenericList() { }


        /// <summary>
        /// The collection lets add element after creating
        /// </summary>
        public bool IsReadOnly => false;


        /// <summary>
        /// Access to list elements by index
        /// </summary>
        /// <param name="index">The index of element</param>
        public T this[int index]
        {
            get
            {
                if (index == Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var element = FindElement(index);
                if (element == null)
                {
                    return head.Value;
                }

                if (element.Next == null)
                {
                    throw new DataMisalignedException();
                }
                return element.Next.Value;
            }
            set
            {
                if (index == Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var element = FindElement(index);
                if (element == null)
                {
                    head.Value = value;
                    return;
                }

                if (element.Next == null)
                {
                    throw new DataMisalignedException();
                }
                element.Next.Value = value;
            }
        }

        /// <summary>
        /// Get element of given index
        /// </summary>
        /// <param name="index">The given index</param>
        /// <returns>The element on given index</returns>
        private ListElement FindElement(int index)
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
            return currentElement;
        }

        /// <summary>
        /// Find index of first occurence of given value
        /// </summary>
        /// <param name="item">The value of searching element</param>
        /// <returns>The found index</returns>
        public int IndexOf(T item)
        {
            int index = 0;
            for (var current = head; current != null; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    return index;
                }
                ++index;
            }
            return -1;
        }


        /// <summary>
        /// Add new element after given one
        /// </summary>
        /// <param name="value">The value of new element</param>
        /// <param name="prev">The new element will be added after this one</param>
        private void AddElementArterGiven(T value, ListElement prev)
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
        /// Add element to list
        /// </summary>
        /// <param name="item">Adding value</param>
        public void Add(T item)
        {
            AddElementArterGiven(item, FindElement(Count));
            ++Count;
        }

        /// <summary>
        /// Insert element to given index to list
        /// </summary>
        /// <param name="item">The inserting element</param>
        /// <param name="index">The index element to be inserted</param>
        public void Insert(int index, T item)
        {
            AddElementArterGiven(item, FindElement(index));
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
        /// Remove element by index
        /// </summary>
        /// <param name="index">The index of removing element</param>
        public void RemoveAt(int index)
        {
            if (index == Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            DeleteElementAfterGiven(FindElement(index));
            --Count;
        }

        /// <summary>
        /// Remove first occurence of value
        /// </summary>
        /// <param name="item">The removing item</param>
        /// <returns>True if some element removed</returns>
        public bool Remove(T item)
        {
            ListElement prev = null;
            for (var current = head; current != null; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    DeleteElementAfterGiven(prev);
                    --Count;
                    return true;
                }
                prev = current;
            }
            return false;
        }

        /// <summary>
        /// Remove all element from list
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        
        /// <summary>
        /// Check if list contains given element
        /// </summary>
        /// <param name="item">The checking element</param>
        public bool Contains(T item)
        {
            for (var current = head; current != null; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Write the list to array beggining with given index
        /// </summary>
        /// <param name="array">The array list to be written</param>
        /// <param name="startIndex">The index from which list to be written</param>
        public void CopyTo(T[] array, int startIndex = 0)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Length < startIndex + Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var current = head;
            for (var i = 0; i < Count; ++i)
            {
                if (current == null)
                {
                    throw new DataMisalignedException();
                }
                array[startIndex + i] = current.Value;
                current = current.Next;
            }
        }


        /// <summary>
        /// Enumerator for list
        /// </summary>
        public IEnumerator<T> GetEnumerator() => new GenericListIEnumerator<T>(this);

        /// <summary>
        /// Enumerator for list
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => new GenericListIEnumerator<T>(this);
    }
}