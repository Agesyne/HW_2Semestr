using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForFibonacci
{
    /// <summary>
    /// Test Fibonacci
    /// </summary>
    [TestClass]
    public class TestFibonacci
    {
        /// <summary>
        /// Test Fibonacci method working
        /// </summary>
        [TestMethod]
        public void TestFibonacciMethod()
        {
            int[] source = { 0, 1, 2, 3, 7, 10, 15, -1, -100 };
            int[] answers = { 0, 1, 1, 2, 13, 55, 610 };
            
            for (var i = 0; i < answers.Length; ++i)
            {
                Assert.IsTrue(MathFibonacci.Program.GetNthFibonacciNumber(source[i]) == answers[i]);
            }
            for (var i = answers.Length; i < source.Length; ++i)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathFibonacci.Program.GetNthFibonacciNumber(source[i]));
            }
        }
    }
}
