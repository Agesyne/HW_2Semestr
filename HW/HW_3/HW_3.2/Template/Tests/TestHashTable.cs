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
            var map1 = new HashMap();
            var map2 = new HashMap(new HashFunctionByMultiplyes());

            map1.Add(0);
            map1.Add(4);
            map1.Add(3);
            map1.Add(1);
            map1.Add(2);

            map2.Add(0);
            map2.Add(4);
            map2.Add(3);
            map2.Add(1);
            map2.Add(2);
        }

        /// <summary>
        /// Test Delete method
        /// </summary>
        [TestMethod]
        public void TestDeleteMethod()
        {
            var map1 = new HashMap();
            var map2 = new HashMap(new HashFunctionByMultiplyes());
            AddSomeValues(map1);
            AddSomeValues(map2);

            map1.Delete(4);
            map1.Delete(1);
            map1.Delete(0);

            map2.Delete(4);
            map2.Delete(1);
            map2.Delete(0);

            int[] values = { 2, 3 };
            foreach (var i in values)
            {
                Assert.IsTrue(map1.Exist(i));
                Assert.IsTrue(map2.Exist(i));
            }
            Assert.IsFalse(map1.Exist(0));
            Assert.IsFalse(map1.Exist(1));
            Assert.IsFalse(map1.Exist(4));

            Assert.IsFalse(map2.Exist(0));
            Assert.IsFalse(map2.Exist(1));
            Assert.IsFalse(map2.Exist(4));
        }

        /// <summary>
        /// Test Exist method
        /// </summary>
        [TestMethod]
        public void TestExistMethod()
        {
            var map1 = new HashMap();
            var map2 = new HashMap(new HashFunctionByMultiplyes());
            AddSomeValues(map1);
            AddSomeValues(map2);

            int[] valuesIn = { 0, 1, 2, 3, 4 };
            int[] valuesOff = { -1, 5, -100, 50 };
            foreach (var i in valuesIn)
            {
                Assert.IsTrue(map1.Exist(i));
                Assert.IsTrue(map2.Exist(i));
            }
            foreach (var i in valuesOff)
            {
                Assert.IsFalse(map1.Exist(i));
                Assert.IsFalse(map2.Exist(i));
            }
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            var map1 = new HashMap();
            var map2 = new HashMap(new HashFunctionByMultiplyes());
            AddSomeValues(map1);
            AddSomeValues(map2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map1.Delete(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map1.Delete(-10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map1.Delete(5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map1.Delete(10));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map2.Delete(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map2.Delete(-10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map2.Delete(5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => map2.Delete(10));
        }

    }
}
