using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    class SortedSet : IComparer<string>
    {
        SortedSetElement head = null;

        /// <summary>
        /// Implimentation of comparing interface
        /// </summary>
        /// <param name="a">First param</param>
        /// <param name="b">Second param</param>
        /// <returns>True if a > b</returns>
        public bool IsGreater(List<string> a, List<string> b)
        {
            return a.Count > b.Count;
        }

        /// <summary>
        /// Implimentation of comparing interface
        /// </summary>
        /// <param name="a">First param</param>
        /// <param name="b">Second param</param>
        /// <returns>True if a = b</returns>
        public bool IsEqual(List<string> a, List<string> b)
        {
            return a.Count == b.Count;
        }

        /// <summary>
        /// An item of the ADS
        /// </summary>
        class SortedSetElement
        {
            public List<string> value;
            public SortedSetElement next;

            public SortedSetElement(List<string> value, SortedSetElement next = null)
            {
                this.value = value;
                this.next = next;
            }

        }

        /// <summary>
        /// Insert new elements right in order
        /// </summary>
        /// <param name="insertingList">Inserting element</param>
        public void Insert(List<string> insertingList)
        {
            SortedSetElement newElement = new SortedSetElement(insertingList);

            if (head == null)
            {
                head = newElement;
                return;
            }
            else if (!IsGreater(insertingList, head.value))
            {
                if (insertingList == head.value)
                {
                    return;
                }
                newElement.next = head;
                head = newElement;
                return;
            }

            SortedSetElement prev = null;
            SortedSetElement current = head;
            while (IsGreater(insertingList, current.value))
            {
                if (current.next == null)
                {
                    break;
                }
                prev = current;
                current = current.next;
            }

            SortedSetElement checkingCurrent = current;
            while (checkingCurrent != null && IsEqual(insertingList, checkingCurrent.value))
            {
                if (insertingList == checkingCurrent.value)
                {
                    return;
                }
            }
            newElement.next = prev.next;
            prev.next = newElement;
        }

        /// <summary>
        /// Print value of SortedSet Element
        /// </summary>
        void PrintSortedSetElement(SortedSetElement a)
        {
            foreach(var i in a.value)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print all stored lists
        /// </summary>
        public void PrintAll()
        {
            SortedSetElement current = head;
            while (current != null)
            {
                PrintSortedSetElement(current);
                current = current.next;
            }
        }
    }
}
