using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Template
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExceptions()
        {
            PriorityQueue myQueue = new PriorityQueue();
            Assert.ThrowsException<StructIsEmptyException>(() => myQueue.Dequeue());

            myQueue.Enqueue("1", 0);
            myQueue.Dequeue();
            Assert.ThrowsException<StructIsEmptyException>(() => myQueue.Dequeue());

            myQueue.Enqueue("1", 0);
            myQueue.Enqueue("2", 0);
            myQueue.Enqueue("3", -4);
            myQueue.Enqueue("4", 9);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            Assert.ThrowsException<StructIsEmptyException>(() => myQueue.Dequeue());
        }

        [TestMethod]
        public void TestWork()
        {
            PriorityQueue myQueue = new PriorityQueue();

            myQueue.Enqueue("1", 0);
            myQueue.Enqueue("2", 0);
            myQueue.Enqueue("3", -5);
            myQueue.Enqueue("4", 10);

            Assert.Equals(4, myQueue.Dequeue());
            Assert.Equals(1, myQueue.Dequeue());
            Assert.Equals(2, myQueue.Dequeue());
            Assert.Equals(3, myQueue.Dequeue());
        }
    }
}
