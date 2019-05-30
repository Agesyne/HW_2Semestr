using System;

namespace Structures
{
    /// <summary>
    /// Some hash method
    /// </summary>
    public class HashFunctionByRestDividing : HashFunction
    {
        /// <summary>
        /// Get hashCode by dividing with rest
        /// </summary>
        /// <param name="value">The given value</param>
        /// <param name="cellNumbers">Maximum output number</param>
        public int GetHash(int value, int cellNumbers)
        {
            return Math.Abs(value) % cellNumbers;
        }
    }

    /// <summary>
    /// Some hash method
    /// </summary>
    public class HashFunctionByMultiplyes : HashFunction
    {
        /// <summary>
        /// Get hashCode by multiplying each digit in number
        /// </summary>
        /// <param name="value">The given value</param>
        /// <param name="cellNumbers">Maximum output number</param>
        public int GetHash(int value, int cellNumbers)
        {
            int result = 0;
            while (value > 0)
            {
                result += value * 10 % cellNumbers;
                value /= 10;
            }
            return result % cellNumbers;
        }
    }
}
