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
        /// The checking class example
        /// </summary>
        UniqueList list;

        /// <summary>
        /// Set up test environment
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            list = new UniqueList();
        }


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
            list.Add(0);
            list.Add(1);
            list.Add(10);
            list.Add(-8);
            list.Add(7);
            list.Add(-10);
        }

        /// <summary>
        /// Test Delete method
        /// </summary>
        [TestMethod]
        public void TestDeleteMethod()
        {
            AddSomeValues(list);

            list.Delete(0);
            list.Delete(1);
            list.Delete(10);
            list.Delete(-8);
            list.Delete(7);
            list.Delete(-10);
        }

        /// <summary>
        /// Test SetNthValue method
        /// </summary>
        [TestMethod]
        public void TestSetNthValueMethod()
        {
            AddSomeValues(list);

            list.SetNthValue(-100, 0);
            Assert.AreEqual(list.GetNthValue(0), -100);
            list.SetNthValue(100, 5);
            Assert.AreEqual(list.GetNthValue(5), 100);
            list.SetNthValue(200, 2);
            Assert.AreEqual(list.GetNthValue(2), 200);
            list.SetNthValue(1, 4);
            Assert.AreEqual(list.GetNthValue(4), 1);
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(0));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(1));


            AddSomeValues(list);
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(0));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(1));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(10));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(-8));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(7));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.Add(-10));

            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.SetNthValue(-10, 3));
            Assert.ThrowsException<TwiceArgumentAddingException>(() => list.SetNthValue(0, 0));

            list.Delete(0);
            list.Delete(1);
            list.Delete(10);
            list.Delete(-8);
            list.Delete(7);
            list.Delete(-10);
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(0));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(1));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(10));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(-8));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(7));
            Assert.ThrowsException<MissingArgumentRemovingException>(() => list.Delete(-10));
        }

    }

}
