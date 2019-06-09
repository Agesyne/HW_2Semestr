using System;
using System.Collections.Generic;

namespace CalculatingStack
{
    /// <summary>
    /// Stack by list
    /// </summary>
    public class StackByList : IADSStack
    {
        /// <summary>
        /// The stack storage
        /// </summary>
        private List<int> stackList = new List<int>();

        /// <summary>
        /// The property - number of elements in stack
        /// </summary>
        public int Count
        {
            get => stackList.Count;
        }

        /// <summary>
        /// Add element to top of the stack
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Push(int value) => stackList.Insert(0, value);

        /// <summary>
        /// Get top stack element and delete it
        /// </summary>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            int result = stackList[0];
            stackList.RemoveAt(0);
            return result;
        }

        /// <summary>
        /// Get top stack element
        /// </summary>
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return stackList[0];
        }

        /// <summary>
        /// Check if stack is empty
        /// </summary>
        public bool IsEmpty() => stackList.Count == 0;

    }

}
