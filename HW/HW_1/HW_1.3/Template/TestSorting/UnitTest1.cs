using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSorting
{
    /// <summary>
    /// Test Sorting
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Check if int array is sorted
        /// </summary>
        /// <param name="checkingArray"></param>
        /// <returns></returns>
        private bool isArraySorted(int[] checkingArray)
        {
            for (var i = 0; i < checkingArray.Length - 1; ++i)
            {
                if (checkingArray[i] > checkingArray[i + 1])
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Test BubbleSort
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            int[] a = { -2, 32, 64, -86, 28, -8, 85, 76, -43, -34 };
            int[] b = { -4, 31, -11, 93, -1, -94, -63, -43, 99, -1 };
            int[] c = { 29, -30, 13, -40, -41, 47, -36, 60, 65, -43 };
            int[] d = { -94, 40, 78, 51, -96, -22, 2, -7, -83, 0 };
            int[] e = null;

            Sorting.Program.BubbleSort(a);
            Sorting.Program.BubbleSort(b);
            Sorting.Program.BubbleSort(c);
            Sorting.Program.BubbleSort(d);
            bool isAllSorted = isArraySorted(a) && isArraySorted(b) && isArraySorted(c) && isArraySorted(d);
            Assert.IsTrue(isAllSorted);
            Assert.ThrowsException<ArgumentNullException>(() => Sorting.Program.BubbleSort(e));
        }
    }
}
