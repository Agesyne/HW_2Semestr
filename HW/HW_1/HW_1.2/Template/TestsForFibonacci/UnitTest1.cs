using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForFibonacci
{
    /// <summary>
    /// Test Fibonacci
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test Fibonacci method working
        /// </summary>
        [TestMethod]
        public void TestFibonacci()
        {
            int[] sourse = { 0, 1, 2, 3, 7, 10, 15, -1, -100 };
            int[] answers = { 0, 1, 1, 2, 13, 55, 610 };

            bool isAllRight = true;
            for (var i = 0; i < answers.Length; ++i)
            {
                if (MathFibonacci.Program.GetNthFibonacciNumber(sourse[i]) != answers[i])
                {
                    isAllRight = false;
                    break;
                }
            }
            Assert.IsTrue(isAllRight);
            for (var i = answers.Length; i < sourse.Length; ++i)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathFibonacci.Program.GetNthFibonacciNumber(sourse[i]));
            }
        }
    }
}
