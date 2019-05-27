using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    /// <summary>
    /// Store element - pair of value and priority.
    /// Let extract element with max priority
    /// </summary>
    public class PriorityQueue
    {
        QueueElement head { get; set; }
        public int size { get; set; }

        /// <summary>
        /// Insert element into the struct
        /// </summary>
        /// <param name="val">Element's value</param>
        /// <param name="priority">Value's priority</param>
        public void Enqueue(string val, int priority)
        {
            QueueElement newElement = new QueueElement(val, priority);

            if (head == null)
            {
                head = newElement;
                ++size;
                return;
            }

            QueueElement current = head;
            while (current.next != null)
            {
                if (current.next.priority < newElement.priority)
                {
                    newElement.next = current.next;
                    current.next = newElement;
                    ++size;
                    return;
                }
            }
            current.next = newElement;
            ++size;
        }

        /// <summary>
        /// Extract value of element with max priority
        /// </summary>
        /// <returns>Extracting value - string</returns>
        public string Dequeue()
        {
            if (isEmpty())
            {
                throw new StructIsEmptyException();
            }

            string result = head.value;
            head = head.next;
            --size;
            return result;
        }

        /// <summary>
        /// Check if struct is empty
        /// </summary>
        /// <returns>Bool: true if empty</returns>
        bool isEmpty()
        {
            return size == 0;
        }
    }
}
