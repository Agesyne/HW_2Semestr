using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace UnitTests
{
    /// <summary>
    /// Test GerericList class
    /// </summary>
    [TestClass]
    public class TestGenericList
    {
        /// <summary>
        /// The GenericList object
        /// </summary>
        private GenericList<int> list = null;

        /// <summary>
        /// Array of adding values
        /// </summary>
        private int[] values = null;

        /// <summary>
        /// Initialize testing object
        /// </summary>
        [TestInitialize()]
        public void SetUp()
        {
            list = new GenericList<int>();
            values = new int[] { 1, 8, 0, -5, 0, 0, 1, 4 };
        }

        /// <summary>
        /// Add given values to list
        /// </summary>
        private void AddValues(GenericList<int> list, params int[] values)
        {
            foreach (var i in values)
            {
                list.Add(i);
            }
        }


        /// <summary>
        /// Test Add method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestAddMethod()
        {
            foreach (var i in values)
            {
                list.Add(i);
            }

            for (var i = 0; i < values.Length; ++i)
            {
                Assert.AreEqual(values[i], list[i]);
            }
        }

        /// <summary>
        /// Test Insert method
        /// </summary>
        /// <param name="values">Inserting values</param>
        [TestMethod]
        public void TestInsertMethod()
        {
            foreach (var i in values)
            {
                list.Insert(0, i);
            }

            for (var i = 0; i < values.Length; ++i)
            {
                Assert.AreEqual(values[values.Length - 1 - i], list[i]);
            }
        }


        /// <summary>
        /// Test Remove method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestRemoveMethod()
        {
            AddValues(list, values);

            for (var i = 0; i < values.Length; i += 2)
            {
                Assert.IsTrue(list.Remove(values[i]));
            }

            for (var i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(values[i * 2 + 1], list[i]);
            }
        }
        
        /// <summary>
        /// Test RemoveAt method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestRemoveAtMethod()
        {
            AddValues(list, values);

            for (var i = 0; i < list.Count; ++i)
            {
                list.RemoveAt(i);
            }

            for (var i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(values[i * 2 + 1], list[i]);
            }
        }
        
        /// <summary>
        /// Test Clear method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestClearMethod()
        {
            AddValues(list, values);

            list.Clear();

            Assert.AreEqual(0, list.Count);
        }


        /// <summary>
        /// Test Contains method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestContainsMethod()
        {
            AddValues(list, values);

            foreach (var i in values)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }


        /// <summary>
        /// Test IndexOf method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestIndexOfMethod()
        {
            AddValues(list, values);

            foreach (var i in values)
            {
                Assert.AreEqual(Array.IndexOf(values, i), list.IndexOf(i));
            }
        }


        /// <summary>
        /// Test CopyTo method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestCopyToMethod()
        {
            AddValues(list, values);

            int[] copiedArray = new int[list.Count];
            list.CopyTo(copiedArray);


            Assert.AreEqual(values.Length, copiedArray.Length);
            for (var i = 0; i < copiedArray.Length; ++i)
            {
                Assert.AreEqual(values[i], copiedArray[i]);
            }
        }


        /// <summary>
        /// Test [] (Slice) method
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestSliceMethod()
        {
            AddValues(list, values);
            
            for (var i = 0; i < values.Length; ++i)
            {
                Assert.AreEqual(values[i], list[i]);
            }
        }


        /// <summary>
        /// Test Count property
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestCountProperty()
        {
            AddValues(list, values);

            int currentCount = values.Length;
            Assert.AreEqual(currentCount, list.Count);
            --currentCount;

            while (currentCount != -1)
            {
                list.RemoveAt(0);
                Assert.AreEqual(currentCount, list.Count);
                --currentCount;
            }
        }


        /// <summary>
        /// Test Enumerator
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestEnumerator()
        {
            AddValues(list, values);

            var index = 0;
            foreach (var i in values)
            {
                Assert.AreEqual(values[index], i);
                ++index;
            }
        }


        /// <summary>
        /// Test exceptions
        /// </summary>
        /// <param name="values">Adding values</param>
        [TestMethod]
        public void TestExceptions()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(-1, 8));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(1, 8));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list[0]);
            AddValues(list, values);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list[-1]);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list[values.Length]);
            Assert.ThrowsException<ArgumentNullException>(() => list.CopyTo(null));
            var array = new int[values.Length];
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.CopyTo(array, 1));
        }

    }
}
