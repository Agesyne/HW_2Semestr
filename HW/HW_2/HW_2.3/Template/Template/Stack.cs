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
            get
            {
                return stackList.Count;
            }
        }

        /// <summary>
        /// Add element to top of the stack
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Push(int value)
        {
            stackList.Insert(0, value);
        }

        /// <summary>
        /// Get top stack element and delete it
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
        public bool IsEmpty()
        {
            return stackList.Count == 0;
        }
    }

    /// <summary>
    /// Stack by array
    /// </summary>
    public class StackByArray : IADSStack
    {
        /// <summary>
        /// The stack storage
        /// </summary>
        private int[] stackArray = new int[16];

        /// <summary>
        /// The property - number of elements in stack
        /// </summary>
        public int Count { get; protected set; } = 0;

        /// <summary>
        /// Increase array length 2 times
        /// </summary>
        private void ExpandStack()
        {
            int[] newStackArray = new int[stackArray.Length * 2];
            for (var i = 0; i < stackArray.Length; ++i)
            {
                newStackArray[i] = stackArray[i];
            }
            stackArray = newStackArray;
        }
        /// <summary>
        /// Add element to top of the stack
        /// </summary>
        /// <param name="value">The adding value</param>
        public void Push(int value)
        {
            if (Count >= stackArray.Length)
            {
                ExpandStack();
            }
            stackArray[Count] = value;
            ++Count;
        }

        /// <summary>
        /// Get top stack element and delete it
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            Count -= 1;
            return stackArray[Count];
        }

        /// <summary>
        /// Get top stack element
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return stackArray[Count - 1];
        }

        /// <summary>
        /// Check if stack is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
