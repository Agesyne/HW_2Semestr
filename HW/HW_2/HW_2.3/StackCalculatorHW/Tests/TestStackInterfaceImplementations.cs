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
        private IADSStack stack1 = null;

        /// <summary>
        /// Variable for StackByArray
        /// </summary>
        private IADSStack stack2 = null;


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
            int[] values = { 1, 2, 3, 5 };
            foreach (var i in values)
            {
                stack1.Push(i);
                stack2.Push(i);
            }
        }

        /// <summary>
        /// Test Pop method
        /// </summary>
        [TestMethod]
        public void TestPopMethod()
        {
            PushSomeValues(stack1);
            PushSomeValues(stack2);
            Assert.AreEqual(stack1.Count, stack2.Count);

            int[] results = { 5, 3, 2, 1 };
            for (var i = 0; i < stack1.Count; ++i)
            {
                Assert.AreEqual(results[i], stack1.Pop());
                Assert.AreEqual(results[i], stack2.Pop());
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
            Assert.AreEqual(stack1.Count, stack2.Count);

            int[] results = { 5, 3, 2, 1 };
            for (var i = 0; i < stack1.Count; ++i)
            {
                Assert.AreEqual(results[i], stack1.Peek());
                stack1.Pop();
                Assert.AreEqual(results[i], stack2.Peek());
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
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
            ++resultCounter;

            stack1.Pop();
            stack2.Pop();
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
            ++resultCounter;

            stack1.Push(4);
            stack2.Push(4);
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
            ++resultCounter;

            stack1.Pop();
            stack2.Pop();
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
            ++resultCounter;

            stack1.Pop();
            stack1.Pop();
            stack2.Pop();
            stack2.Pop();
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
            ++resultCounter;

            stack1.Pop();
            stack2.Pop();
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
            ++resultCounter;

            stack1.Push(1);
            stack2.Push(1);
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
            ++resultCounter;

            stack1.Push(2);
            stack2.Push(2);
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count); ;
            ++resultCounter;

            stack1.Pop();
            stack1.Pop();
            stack2.Pop();
            stack2.Pop();
            Assert.AreEqual(results[resultCounter], stack1.Count);
            Assert.AreEqual(results[resultCounter], stack2.Count);
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
