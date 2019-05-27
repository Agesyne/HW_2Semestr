using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// Test class LinkedList
    /// </summary>
    [TestClass]
    public class TestLinkedListClass
    {
        /// <summary>
        /// Add some values to list
        /// </summary>
        /// <param name="list">The list</param>
        private void AddTestValues(ClassList.LinkedList list)
        {
            list.Add(3, 0);
            list.Add(0, 0);
            list.Add(2, 1);
            list.Add(-1, 0);
            list.Add(4, 4);
            list.Add(-2, 0);
        }

        /// <summary>
        /// Test method Add
        /// </summary>
        [TestMethod]
        public void TestAddMethod()
        {
            var newList = new ClassList.LinkedList();
            int[] resultList = { -2, -1, 0, 2, 3, 4 };
            AddTestValues(newList);

            bool isAddedCorrect = true;
            for (var i = 0; i < newList.Count; ++i)
            {
                if (newList.GetNthValue(i) != resultList[i])
                {
                    isAddedCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(isAddedCorrect);
        }

        /// <summary>
        /// Test method Delete
        /// </summary>
        [TestMethod]
        public void TestDeleteMethod()
        {
            var newList = new ClassList.LinkedList();
            int[] resultList = { -1, 0, 3 };
            AddTestValues(newList);

            newList.Delete(0);
            newList.Delete(4);
            newList.Delete(2);

            bool isDeletedCorrect = true;
            for (var i = 0; i < newList.Count; ++i)
            {
                if (newList.GetNthValue(i) != resultList[i])
                {
                    isDeletedCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(isDeletedCorrect);
        }

        /// <summary>
        /// Test property Count
        /// </summary>
        [TestMethod]
        public void TestCountProperty()
        {
            bool isActualCount = true;
            var newList = new ClassList.LinkedList();

            AddTestValues(newList);
            isActualCount &= newList.Count == 6;
            newList.Delete(0);
            isActualCount &= newList.Count == 5;
            newList.Delete(4);
            isActualCount &= newList.Count == 4;
            newList.Delete(2);
            isActualCount &= newList.Count == 3;
            newList.Add(3, 2);
            isActualCount &= newList.Count == 4;
            newList.Add(0, 1);
            isActualCount &= newList.Count == 5;
            
            Assert.IsTrue(isActualCount);
        }

        /// <summary>
        /// Test method IsEmpty
        /// </summary>
        [TestMethod]
        public void TestIsEmptyMethod()
        {
            bool isReallyEmpty = true;
            var newList = new ClassList.LinkedList();

            isReallyEmpty &= newList.IsEmpty();
            newList.Add(0, 0);
            isReallyEmpty &= !newList.IsEmpty();
            newList.Delete(0);
            isReallyEmpty &= newList.IsEmpty();
            newList.Add(0, 0);
            newList.Add(0, 1);
            newList.Delete(0);
            isReallyEmpty &= !newList.IsEmpty();
            newList.Delete(0);
            isReallyEmpty &= newList.IsEmpty();
            
            Assert.IsTrue(isReallyEmpty);
        }

        /// <summary>
        /// Test method GetNthValue
        /// </summary>
        [TestMethod]
        public void TestGetNthValueMethod()
        {
            bool isCorrentGotten = true;
            var newList = new ClassList.LinkedList();

            AddTestValues(newList);
            isCorrentGotten &= newList.GetNthValue(0) == -2;
            isCorrentGotten &= newList.GetNthValue(1) == -1;
            isCorrentGotten &= newList.GetNthValue(2) == 0;
            isCorrentGotten &= newList.GetNthValue(3) == 2;
            isCorrentGotten &= newList.GetNthValue(4) == 3;
            isCorrentGotten &= newList.GetNthValue(5) == 4;
            
            Assert.IsTrue(isCorrentGotten);
        }

        /// <summary>
        /// Test method SetNthValue
        /// </summary>
        [TestMethod]
        public void TestSetNthValueMethod()
        {
            bool isCorrentGotten = true;
            var newList = new ClassList.LinkedList();

            AddTestValues(newList);
            newList.SetNthValue(-100, 0);
            isCorrentGotten &= newList.GetNthValue(0) == -100;
            newList.SetNthValue(100, 5);
            isCorrentGotten &= newList.GetNthValue(5) == 100;
            newList.SetNthValue(200, 2);
            isCorrentGotten &= newList.GetNthValue(2) == 200;
            
            Assert.IsTrue(isCorrentGotten);
        }

        /// <summary>
        /// Test method's exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            var newList = new ClassList.LinkedList();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.Add(0, -3));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.Add(0, 1));
            newList.Add(3, 0);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.Add(0, 2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.Add(0, 18));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.Delete(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.Delete(1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.GetNthValue(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.GetNthValue(1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.SetNthValue(32, -1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => newList.SetNthValue(23, 1));
        }

    }
}
