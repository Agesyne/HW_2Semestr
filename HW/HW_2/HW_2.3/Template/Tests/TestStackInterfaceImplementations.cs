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
        /// Variable for StackByList
        /// </summary>
        IADSStack stack1 = null;

        /// <summary>
        /// Variable for StackByArray
        /// </summary>
        IADSStack stack2 = null;


        /// <summary>
        /// Set up data before every test
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            stack1 = new StackByList();
            stack2 = new StackByArray();
        }


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
            PushSomeValues(stack1);
            PushSomeValues(stack2);

            int[] results = { 5, 3, 2, 1 };
            for (var i = 0; i < stack1.Count; ++i)
            {
                Assert.AreEqual(stack1.Pop(), results[i]);
            }
            for (var i = 0; i < stack2.Count; ++i)
            {
                Assert.AreEqual(stack2.Pop(), results[i]);
            }
        }

        /// <summary>
        /// Test Peek method
        /// </summary>
        [TestMethod]
        public void TestPeekMethod()
        {
            PushSomeValues(stack1);
            PushSomeValues(stack2);

            int[] results = { 5, 3, 2, 1 };
            for (var i = 0; i < stack1.Count; ++i)
            {
                Assert.AreEqual(stack1.Peek(), results[i]);
                stack1.Pop();
            }
            for (var i = 0; i < stack2.Count; ++i)
            {
                Assert.AreEqual(stack2.Peek(), results[i]);
                stack2.Pop();
            }
        }

        /// <summary>
        /// Test IsEmpty method
        /// </summary>
        [TestMethod]
        public void TestIsEmptyMethod()
        {
            Assert.IsTrue(stack1.IsEmpty());
            stack1.Push(1);
            Assert.IsFalse(stack1.IsEmpty());
            stack1.Pop();
            Assert.IsTrue(stack1.IsEmpty());
            stack1.Push(2);
            stack1.Push(3);
            stack1.Pop();
            Assert.IsFalse(stack1.IsEmpty());
            stack1.Pop();
            Assert.IsTrue(stack1.IsEmpty());

            Assert.IsTrue(stack2.IsEmpty());
            stack2.Push(1);
            Assert.IsFalse(stack2.IsEmpty());
            stack2.Pop();
            Assert.IsTrue(stack2.IsEmpty());
            stack2.Push(2);
            stack2.Push(3);
            stack2.Pop();
            Assert.IsFalse(stack2.IsEmpty());
            stack2.Pop();
            Assert.IsTrue(stack2.IsEmpty());
        }

        /// <summary>
        /// Test Count property
        /// </summary>
        [TestMethod]
        public void TestCountProperty()
        {
            int[] results = { 4, 3, 4, 3, 1, 0, 1, 2, 0 };
            int resultCounter = 0;

            PushSomeValues(stack1);
            PushSomeValues(stack2);
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Pop();
            stack2.Pop();
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Push(4);
            stack2.Push(4);
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Pop();
            stack2.Pop();
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Pop();
            stack1.Pop();
            stack2.Pop();
            stack2.Pop();
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Pop();
            stack2.Pop();
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Push(1);
            stack2.Push(1);
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Push(2);
            stack2.Push(2);
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
            ++resultCounter;

            stack1.Pop();
            stack1.Pop();
            stack2.Pop();
            stack2.Pop();
            Assert.AreEqual(stack1.Count, results[resultCounter]);
            Assert.AreEqual(stack2.Count, results[resultCounter]);
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            Assert.ThrowsException<InvalidOperationException>(() => stack1.Pop());
            Assert.ThrowsException<InvalidOperationException>(() => stack1.Peek());

            Assert.ThrowsException<InvalidOperationException>(() => stack2.Pop());
            Assert.ThrowsException<InvalidOperationException>(() => stack2.Peek());
        }
    }
}
