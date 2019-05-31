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
        public uint GetHash(int value, int cellNumbers)
        {
            return Convert.ToUInt32(Math.Abs(value) % cellNumbers);
        }
    }
}
