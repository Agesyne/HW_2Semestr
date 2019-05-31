using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structures;

namespace Tests
{
    /// <summary>
    /// Test HashTable class
    /// </summary>
    [TestClass]
    public class TestHashTable
    {
        private HashMap map = null;

        [TestInitialize()]
        public void Setup()
        {
            map = new HashMap();
        }

        /// <summary>
        /// Add some predefined values
        /// </summary>
        /// <param name="map">The map values to be added</param>
        private void AddSomeValues(HashMap map)
        {
            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);
        }

        /// <summary>
        /// Test Add method
        /// </summary>
        [TestMethod]
        public void TestAddMethod()
        {
            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);

            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);
            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);
            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);
            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);
            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);
        }

        /// <summary>
        /// Test Delete method
        /// </summary>
        [TestMethod]
        public void TestDeleteMethod()
        {
            AddSomeValues(map);

            map.Delete(4);
            map.Delete(1);
            map.Delete(0);

            int[] values = { 2, 3 };
            foreach (var i in values)
            {
                Assert.IsTrue(map.Exist(i));
            }
            Assert.IsFalse(map.Exist(0));
            Assert.IsFalse(map.Exist(1));
            Assert.IsFalse(map.Exist(4));
        }

        /// <summary>
        /// Test Exist method
        /// </summary>
        [TestMethod]
        public void TestExistMethod()
        {
            AddSomeValues(map);

            int[] valuesIn = { 0, 1, 2, 3, 4 };
            int[] valuesOff = { -1, 5, -100, 50 };
            foreach (var i in valuesIn)
            {
                Assert.IsTrue(map.Exist(i));
            }
            foreach (var i in valuesOff)
            {
                Assert.IsFalse(map.Exist(i));
            }
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            AddSomeValues(map);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.Delete(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.Delete(-10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.Delete(5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.Delete(10));
        }

    }
}
