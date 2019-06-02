using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structures;

namespace Tests
{
    /// <summary>
    /// Test ParseTree class
    /// </summary>
    [TestClass]
    public class TestParseTree
    {
        /// <summary>
        /// Get stored test values
        /// </summary>
        /// <param name="isCorrectExpressions">Get correct or incorrect exprissions</param>
        /// <returns>Array of expressions</returns>
        private string[] GetExpressions(bool isCorrectExpressions)
        {
            string[] correctExpressions = {
                    "(+ 1 1)",
                    "(- 1 1)",
                    "(* 1 1)",
                    "(/ 10 3)",
                    "(/ 100 (+ (* 2 3) 4))",
                    "(+ (* 5 0) (- 1 0))",
                    "(+ (- (/ (+ 5 3) (/ 9 3)) (* 5 1)) (* (+ 5 0) (- 9 8)))"
                };
            string[] incorrectExpressions = {
                    "+ 1 1)",
                    "(- 1 1",
                    "( 1 1)",
                    "(/ 10 )",
                    "(/ 100)",
                    "(+ (* 5 0)(- 1 0)",
                    "(+ (- (/ (+ 5 3) 0) (* 5 1)) (* (+ 5 0) (- 9 8)))",
                    null
                };

            return (isCorrectExpressions) ? correctExpressions : incorrectExpressions;
        }

        /// <summary>
        /// Get results
        /// </summary>
        /// <returns>Array of results</returns>
        private int[] GetResults()
        {
            int[] correctResults = { 2, 0, 1, 3, 10, 1, 2 };

            return correctResults;
        }

        /// <summary>
        /// Test SetExpression method
        /// </summary>
        [TestMethod]
        public void TestSetExpressionMethod()
        {
            var parseTree = new ParseTree();
            string[] expressions = GetExpressions(true);

            foreach (var i in expressions)
            {
                parseTree.SetExpression(i);
            }
        }

        /// <summary>
        /// Test Count method
        /// </summary>
        [TestMethod]
        public void TestCountMethod()
        {
            var parseTree = new ParseTree();
            string[] expressions = GetExpressions(true);
            int[] results = GetResults();

            for (var i = 0; i < expressions.Length; ++i)
            {
                parseTree.SetExpression(expressions[i]);
                Assert.AreEqual(results[i], parseTree.Count());
            }
        }

        /// <summary>
        /// Test Print method
        /// </summary>
        [TestMethod]
        public void TestPrintMethod()
        {
            var parseTree = new ParseTree();
            string[] expressions = GetExpressions(true);

            for (var i = 0; i < expressions.Length; ++i)
            {
                parseTree.SetExpression(expressions[i]);
                Assert.AreEqual(expressions[i], parseTree.PrintExpression());
            }
        }

        /// <summary>
        /// Test expressions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            var parseTree = new ParseTree();
            string[] expressions = GetExpressions(false);

            var expressionCounter = 0;
            for (; expressionCounter < expressions.Length - 2; ++expressionCounter)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => parseTree.SetExpression(expressions[expressionCounter]));
            }

            parseTree.SetExpression(expressions[expressionCounter]);
            Assert.ThrowsException<DivideByZeroException>(() => parseTree.Count());
            ++expressionCounter;
            
            Assert.ThrowsException<ArgumentNullException>(() => parseTree.SetExpression(expressions[expressionCounter]));
        }

    }

}
