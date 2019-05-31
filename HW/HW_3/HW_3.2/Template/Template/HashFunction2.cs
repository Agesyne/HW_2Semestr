using System;

namespace Structures
{
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
        public uint GetHash(int value, int cellNumbers)
        {
            int result = 0;
            while (value > 0)
            {
                result += value * 10 % cellNumbers;
                value /= 10;
            }
            return Convert.ToUInt32(result % cellNumbers);
        }
    }
}
