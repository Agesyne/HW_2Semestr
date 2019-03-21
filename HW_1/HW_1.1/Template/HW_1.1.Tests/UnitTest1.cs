using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_1._1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test method "isNumberEntered()" that checks if entered string contains number
        /// </summary>
        [TestMethod]
        public void TestNotCorrentInput()
        {
            string[] testArray = { "ehusao", "3.342", "", "79h43dud" };

            foreach (var str in testArray)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => Template.Program.isNumberEntered(str, out var number));
            }
        }

        /// <summary>
        /// Test method "CountFactorial()" that counts n-th factorial number
        /// </summary>
        [TestMethod]
        public void TestFactorial()
        {
            int[,] successCases = { { 1, 2, 5, 7 }, { 1, 2, 120, 5040 } };
            for (int i = 0; i < successCases.Length / 2; ++i)
            {
                Assert.AreEqual(Template.Program.CountFactorial(successCases[0, i]), successCases[1, i]);
            }

            int[] exceptionCases = { 0, -1, -100 };
            foreach (var number in exceptionCases)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => Template.Program.CountFactorial(number));
            }
        }
    }
}
