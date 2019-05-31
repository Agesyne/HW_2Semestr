using System;
using System.Collections.Generic;

namespace Structures
{
    public class DataSqueezer
    {
        /// <summary>
        /// Local pair structure for storing value and its amount
        /// </summary>
        private class BytePair
        {
            /// <summary>
            /// The storing value
            /// </summary>
            public byte Value { get; set; }

            /// <summary>
            /// The amount of repeating
            /// </summary>
            public byte Amount { get; set; }


            /// <summary>
            /// The constructor
            /// </summary>
            /// <param name="value">The storing value</param>
            /// <param name="amount">The amount of repeating</param>
            public BytePair(byte value, byte amount)
            {
                Value = value;
                Amount = amount;
            }
        }

        /// <summary>
        /// Squeeze array of bytes
        /// </summary>
        /// <param name="data">The given array of bytes</param>
        /// <returns>Squeezed array of bytes</returns>
        public static byte[] Box(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            if (data.Length == 0)
            {
                return new byte[] { };
            }

            var newDataList = new List<BytePair>();
            foreach (var i in data)
            {
                if (newDataList.Count != 0 && newDataList[newDataList.Count - 1].Value == i && newDataList[newDataList.Count - 1].Amount < 255)
                {
                    ++newDataList[newDataList.Count - 1].Amount;
                }
                else
                {
                    newDataList.Add(new BytePair(i, 1));
                }
            }

            byte[] newData = new byte[newDataList.Count * 2];
            for (var i = 0; i < newDataList.Count; ++i)
            {
                newData[i * 2] = newDataList[i].Amount;
                newData[i * 2 + 1] = newDataList[i].Value;
            }
            return newData;
        }

        /// <summary>
        /// Desqueeze array of bytes
        /// </summary>
        /// <param name="data">The given array of bytes</param>
        /// <returns>The desqueezed array of bytes</returns>
        public static byte[] Unbox(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            if (data.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (data.Length == 0)
            {
                return new byte[] { };
            }

            var newDataList = new List<BytePair>();
            int totalAmount = 0;
            for (var i = 0; i < data.Length / 2; ++i)
            {
                var newBytePair = new BytePair(data[i * 2 + 1], data[i * 2]);
                totalAmount += newBytePair.Amount;
                newDataList.Add(newBytePair);
            }

            byte[] newData = new byte[totalAmount];
            int arrayCounter = 0;
            for (var i = 0; i < newDataList.Count; ++i)
            {
                for (var j = 0; j < newDataList[i].Amount; ++j)
                {
                    newData[arrayCounter] = newDataList[i].Value;
                    ++arrayCounter;
                    if (arrayCounter > totalAmount)
                    {
                        throw new DataMisalignedException();
                    }
                }
            }
            return newData;
        }
        
    }
}
