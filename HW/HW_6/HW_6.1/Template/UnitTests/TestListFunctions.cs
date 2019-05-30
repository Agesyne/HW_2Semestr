using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StructureFunctions;

namespace UnitTests
{
    /// <summary>
    /// Test ListFuntions class
    /// </summary>
    [TestClass]
    public class TestListFunctions
    {
        /// <summary>
        /// Compare if lists are same
        /// </summary>
        /// <param name="a">The 1st list</param>
        /// <param name="b">The 2nd list</param>
        private static bool IsSameList(List<int> a, List<int> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            for (var i = 0; i < a.Count; ++i)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Test Map method
        /// </summary>
        [TestMethod]
        public void TestMapMethod()
        {
            var list1 = new List<int>() { 1, 2, 3, 4, 5 };
            var list2 = new List<int>() { -1, -2, -3, -4, -5 };
            var list3 = new List<int>() { -10, 20, -30, 40, -50 };

            var resultList1 = new List<int>() { 2, 4, 6, 8, 10 };
            var resultList2 = new List<int>() { -6, -7, -8, -9, -10 };
            var resultList3 = new List<int>() { -2, 4, -6, 8, -10 };

            Assert.IsTrue(IsSameList(resultList1, ListFunctions.Map(list1, x => x * 2)));
            Assert.IsTrue(IsSameList(resultList2, ListFunctions.Map(list2, x => x - 5)));
            Assert.IsTrue(IsSameList(resultList3, ListFunctions.Map(list3, x => x / 5)));
        }

        /// <summary>
        /// Test Filter method
        /// </summary>
        [TestMethod]
        public void TestFilterMethod()
        {
            var list1 = new List<int>() { 1, 2, 3, 4, 5 };
            var list2 = new List<int>() { -1, -2, -3, -4, -5 };
            var list3 = new List<int>() { -10, 20, -30, 40, -50 };

            var resultList1 = new List<int>() { 1, 3, 5 };
            var resultList2 = new List<int>() { -3, -4, -5 };
            var resultList3 = new List<int>() { 20, 40 };

            Assert.IsTrue(IsSameList(resultList1, ListFunctions.Filter(list1, x => x % 2 == 1)));
            Assert.IsTrue(IsSameList(resultList2, ListFunctions.Filter(list2, x => x < -2)));
            Assert.IsTrue(IsSameList(resultList3, ListFunctions.Filter(list3, x => x >= 10)));
        }

        /// <summary>
        /// Test Fold method
        /// </summary>
        [TestMethod]
        public void TestFoldMethod()
        {
            var list1 = new List<int>() { 1, 2, 3, 4, 5 };
            var list2 = new List<int>() { -1, -2, -3, -4, -5 };
            var list3 = new List<int>() { -10, 20, -30, 40, -50 };

            var resultList1 = 15;
            var resultList2 = -120;
            var resultList3 = -20;

            Assert.AreEqual(resultList1, ListFunctions.Fold(list1, 0, (acc, elem) => acc + elem));
            Assert.AreEqual(resultList2, ListFunctions.Fold(list2, 1, (acc, elem) => acc * elem));
            Assert.AreEqual(resultList3, ListFunctions.Fold(list3, 10, (acc, elem) => acc + elem));
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> nullList = null;

            Assert.ThrowsException<ArgumentNullException>(() => ListFunctions.Map(nullList, elem => 2 * elem));
            Assert.ThrowsException<ArgumentNullException>(() => ListFunctions.Map(list, null));

            Assert.ThrowsException<ArgumentNullException>(() => ListFunctions.Filter(nullList, elem => elem < 5));
            Assert.ThrowsException<ArgumentNullException>(() => ListFunctions.Filter(list, null));

            Assert.ThrowsException<ArgumentNullException>(() => ListFunctions.Fold(nullList, 0, (acc, elem) => acc + elem));
            Assert.ThrowsException<ArgumentNullException>(() => ListFunctions.Fold(list, 0, null));
        }

    }
}
