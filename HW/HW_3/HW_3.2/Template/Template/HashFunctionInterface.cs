namespace Structures
{
    /// <summary>
    /// Interface of hashFunction
    /// </summary>
    public interface HashFunction
    {
        /// <summary>
        /// Get hashCode by value and max value
        /// </summary>
        /// <param name="value">The given value</param>
        /// <param name="cellNumbers">The maximum output</param>
        int GetHash(int value, int cellNumbers);
    }
}
