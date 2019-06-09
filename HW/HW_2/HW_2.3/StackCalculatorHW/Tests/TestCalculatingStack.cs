using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatingStack;

namespace Tests
{
    /// <summary>
    /// Test StackCalculator class
    /// </summary>
    [TestClass]
    public class TestStackCalculator
    {
        /// <summary>
        /// Test CalculatePosfixExpression method
        /// </summary>
        [TestMethod]
        public void TestCalculatePostfixExpression()
        {
            string[] expressions = {
                "89+ 2- 2* 6/",
                "11+ 1+ 1+ 1+ 1+ 5- 0+",
                "01- 5- 6+ 5*",
                "33/ 9* 3/ 6* 6/",
                "81+ 9- 5+ 9- 8+ 0-",
                "89+ 2- 2* 6/ 0*"
                                    };

            int[] results = { 5, 1, 0, 3, 4, 0 };

            for (var i = 0; i < expressions.Length; ++i)
            {
                Assert.AreEqual(results[i], StackCalculator.CalculatePostfixExpression(expressions[i], new StackByList()));
                Assert.AreEqual(results[i], StackCalculator.CalculatePostfixExpression(expressions[i], new StackByArray()));
            }
        }

        /// <summary>
        /// Test expressions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            string expression1 = "23+4";
            string expression2 = "23-4+#";
            string expression3 = "25+";
            string expression4 = null;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => StackCalculator.CalculatePostfixExpression(expression1, new StackByList()));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => StackCalculator.CalculatePostfixExpression(expression2, new StackByList()));
            StackByList newStack = null;
            Assert.ThrowsException<ArgumentNullException>(() => StackCalculator.CalculatePostfixExpression(expression3, newStack));
            Assert.ThrowsException<ArgumentNullException>(() => StackCalculator.CalculatePostfixExpression(expression4, new StackByList()));
        }
    }
}
