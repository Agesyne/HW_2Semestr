using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatingStack;

namespace Tests
{
    /// <summary>
    /// Test IADSStack
    /// </summary>
    [TestClass]
    public class TestStackInterfaceImplementations
    {
        /// <summary>
        /// Push some values to stack
        /// </summary>
        /// <param name="stack">The given stack</param>
        private void PushSomeValues(IADSStack stack)
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
        }

        /// <summary>
        /// Test Push method
        /// </summary>
        [TestMethod]
        public void TestPushMethod()
        {
            IADSStack stack1 = new StackByList();
            IADSStack stack2 = new StackByArray();

            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(5);

            stack2.Push(1);
            stack2.Push(2);
            stack2.Push(3);
            stack2.Push(5);
        }

        /// <summary>
        /// Test Pop method
        /// </summary>
        [TestMethod]
        public void TestPopMethod()
        {
            bool isAllCorrent = true;
            IADSStack stack1 = new StackByList();
            IADSStack stack2 = new StackByArray();

            PushSomeValues(stack1);
            PushSomeValues(stack2);

            int[] results = { 5, 3, 2, 1 };
            for (var i = 0; i < stack1.Count; ++i)
            {
                if (stack1.Pop() != results[i])
                {
                    isAllCorrent = false;
                    break;
                }
            }
            Assert.IsTrue(isAllCorrent);
            for (var i = 0; i < stack1.Count; ++i)
            {
                if (stack2.Pop() != results[i])
                {
                    isAllCorrent = false;
                    break;
                }
            }
            Assert.IsTrue(isAllCorrent);
        }

        /// <summary>
        /// Test Peek method
        /// </summary>
        [TestMethod]
        public void TestPeekMethod()
        {
            bool isAllCorrent = true;
            IADSStack stack1 = new StackByList();
            IADSStack stack2 = new StackByArray();

            PushSomeValues(stack1);
            PushSomeValues(stack2);

            int[] results = { 5, 3, 2, 1 };
            for (var i = 0; i < stack1.Count; ++i)
            {
                if (stack1.Peek() != results[i])
                {
                    isAllCorrent = false;
                    break;
                }
                stack1.Pop();
            }
            Assert.IsTrue(isAllCorrent);
            for (var i = 0; i < stack2.Count; ++i)
            {
                if (stack2.Peek() != results[i])
                {
                    isAllCorrent = false;
                    break;
                }
                stack2.Pop();
            }
            Assert.IsTrue(isAllCorrent);
        }

        /// <summary>
        /// Test IsEmpty method
        /// </summary>
        [TestMethod]
        public void TestIsEmptyMethod()
        {
            bool isAllCorrent = true;
            IADSStack stack1 = new StackByList();
            IADSStack stack2 = new StackByArray();

            isAllCorrent &= stack1.IsEmpty();
            stack1.Push(1);
            isAllCorrent &= !stack1.IsEmpty();
            stack1.Pop();
            isAllCorrent &= stack1.IsEmpty();
            stack1.Push(2);
            stack1.Push(3);
            stack1.Pop();
            isAllCorrent &= !stack1.IsEmpty();
            stack1.Pop();
            isAllCorrent &= stack1.IsEmpty();
            Assert.IsTrue(isAllCorrent);

            isAllCorrent &= stack2.IsEmpty();
            stack2.Push(1);
            isAllCorrent &= !stack2.IsEmpty();
            stack2.Pop();
            isAllCorrent &= stack2.IsEmpty();
            stack2.Push(2);
            stack2.Push(3);
            stack2.Pop();
            isAllCorrent &= !stack2.IsEmpty();
            stack2.Pop();
            isAllCorrent &= stack2.IsEmpty();
            Assert.IsTrue(isAllCorrent);
        }

        /// <summary>
        /// Test Count property
        /// </summary>
        [TestMethod]
        public void TestCountProperty()
        {
            bool isAllCorrent = true;
            IADSStack stack1 = new StackByList();
            IADSStack stack2 = new StackByArray();

            int[] results = { 4, 3, 4, 3, 1, 0, 1, 2, 0 };
            int resultCounter = 0;

            PushSomeValues(stack1);
            PushSomeValues(stack2);
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);

            stack1.Pop();
            stack2.Pop();
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);

            stack1.Push(4);
            stack2.Push(4);
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);
            
            stack1.Pop();
            stack2.Pop();
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);

            stack1.Pop();
            stack1.Pop();
            stack2.Pop();
            stack2.Pop();
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);
            
            stack1.Pop();
            stack2.Pop();
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);

            stack1.Push(1);
            stack2.Push(1);
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);

            stack1.Push(2);
            stack2.Push(2);
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);

            stack1.Pop();
            stack1.Pop();
            stack2.Pop();
            stack2.Pop();
            isAllCorrent &= stack1.Count == results[resultCounter];
            isAllCorrent &= stack2.Count == results[resultCounter];
            ++resultCounter;
            Assert.IsTrue(isAllCorrent);
        }
        
        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            IADSStack stack1 = new StackByList();
            IADSStack stack2 = new StackByArray();

            Assert.ThrowsException<InvalidOperationException>(() => stack1.Pop());
            Assert.ThrowsException<InvalidOperationException>(() => stack1.Peek());

            Assert.ThrowsException<InvalidOperationException>(() => stack2.Pop());
            Assert.ThrowsException<InvalidOperationException>(() => stack2.Peek());
        }
    }

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
            bool isAllCorrect = true;
            string expression1 = "89+ 2- 2* 6/";
            string expression2 = "11+ 1+ 1+ 1+ 1+ 5- 0+";
            string expression3 = "01- 5- 6+ 5*";
            string expression4 = "33/ 9* 3/ 6* 6/";
            string expression5 = "81+ 9- 5+ 9- 8+ 0-";
            string expression6 = "89+ 2- 2* 6/ 0*";

            int[] results = { 5, 1, 0, 3, 4, 0 };
            int resultCounter = 0;

            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression1, new StackByList());
            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression1, new StackByArray());
            ++resultCounter;
            Assert.IsTrue(isAllCorrect);

            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression2, new StackByList());
            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression2, new StackByArray());
            ++resultCounter;
            Assert.IsTrue(isAllCorrect);

            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression3, new StackByList());
            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression3, new StackByArray());
            ++resultCounter;
            Assert.IsTrue(isAllCorrect);

            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression4, new StackByList());
            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression4, new StackByArray());
            ++resultCounter;
            Assert.IsTrue(isAllCorrect);

            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression5, new StackByList());
            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression5, new StackByArray());
            ++resultCounter;
            Assert.IsTrue(isAllCorrect);

            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression6, new StackByList());
            isAllCorrect &= results[resultCounter] == StackCalculator.CalculatePostfixExpression(expression6, new StackByArray());
            ++resultCounter;
            Assert.IsTrue(isAllCorrect);
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
