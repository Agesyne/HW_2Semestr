namespace CalculatingStack
{
    /// <summary>
    /// Interface of Abstract Data Structure Stack
    /// </summary>
    public interface IADSStack
    {
        /// <summary>
        /// Number of elements in stack
        /// </summary>
        int Count { get; }


        /// <summary>
        /// Add element in stack
        /// </summary>
        /// <param name="value">The adding value</param>
        void Push(int value);

        /// <summary>
        /// Delete last value in stack and return it
        /// </summary>
        /// <returns>The last value in stack</returns>
        int Pop();

        /// <summary>
        /// Get last value in stack
        /// </summary>
        int Peek();

        /// <summary>
        /// Check if stack is empty
        /// </summary>
        bool IsEmpty();
    }
}
