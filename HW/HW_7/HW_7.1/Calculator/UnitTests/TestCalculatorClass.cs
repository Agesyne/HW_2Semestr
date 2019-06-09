using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// Test Calculator class
    /// </summary>
    [TestClass]
    public class TestCalculatorClass
    {
        /// <summary>
        /// Test Count method
        /// </summary>
        [TestMethod]
        [DataRow("9+9", 18)]
        [DataRow("9", 9)]
        [DataRow("10/3", 3)]
        [DataRow("((9+2)*2-10)%5+8", 10)]
        [DataRow("((9+8))", 17)]
        [DataRow("(7+2) / 5 - 5", -4)]
        [DataRow("1*8+(0-8)*5", -32)]
        public void TestCountMethod(string expression, int result)
        {
            Assert.AreEqual(result, Calculator.Background.Calculator.Count(expression));
        }

        /// <summary>
        /// Test ArgumentOutOfRange expression
        /// </summary>
        [TestMethod]
        [DataRow("(")]
        [DataRow(")")]
        [DataRow("()")]
        [DataRow("+")]
        [DataRow("34+")]
        [DataRow("-55")]
        [DataRow("(87+3)-5)")]
        [DataRow("6@8")]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestArgumentOutOfRangeExpression(string expression)
        {
            Calculator.Background.Calculator.Count(expression);
        }
        
        /// <summary>
        /// Test DivideByZero expression
        /// </summary>
        [TestMethod]
        [DataRow("7/0")]
        [DataRow("7/(6+2-4*2)")]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestDivideByZeroExpression(string expression)
        {
            Calculator.Background.Calculator.Count(expression);
        }
        
    }

}
