using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structures;
using CustomExceptions;

namespace UnitTests
{
    /// <summary>
    /// Test UniqueList class
    /// </summary>
    [TestClass]
    public class TestUniqueList
    {
        /// <summary>
        /// Add some predefined values
        /// </summary>
        /// <param name="list">The list values to be added</param>
        private void AddSomeValues(UniqueList list)
        {
            list.Add(0);
            list.Add(1);
            list.Add(10);
            list.Add(-8);
            list.Add(7);
            list.Add(-10);
        }

        /// <summary>
        /// Test Add method
        /// </summary>
        [TestMethod]
        public void TestAddMethod()
        {
            var list = new UniqueList();

            list.Add(0);
            list.Add(1);
            list.Add(10);
            list.Add(-8);
            list.Add(7);
            list.Add(-10);
        }

        /// <summary>
        /// Test Remove method
        /// </summary>
        [TestMethod]
        public void TestRemoveMethod()
        {
            var list = new UniqueList();
            AddSomeValues(list);

            list.Remove(0);
            list.Remove(1);
            list.Remove(10);
            list.Remove(-8);
            list.Remove(7);
            list.Remove(-10);
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            var list = new UniqueList();
            
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(0));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(1));


            AddSomeValues(list);
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(0));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(1));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(10));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(-8));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(7));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(-10));


            list.Remove(0);
            list.Remove(1);
            list.Remove(10);
            list.Remove(-8);
            list.Remove(7);
            list.Remove(-10);
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(0));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(1));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(10));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(-8));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(7));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Remove(-10));
        }

    }

}
