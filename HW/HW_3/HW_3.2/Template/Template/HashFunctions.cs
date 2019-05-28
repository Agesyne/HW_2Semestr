using System;

namespace Structures
{
    /// <summary>
    /// Some hash method
    /// </summary>
    public class HashFunctionByRestDividing : HashFunction
    {
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
        public int GetHash(int value, int cellNumbers)
        {
            int result = 0;
            while (value > 0)
            {
                result += value * 10 % cellNumbers;
                value %= 10;
            }
            return result % cellNumbers;
        }
    }
}
