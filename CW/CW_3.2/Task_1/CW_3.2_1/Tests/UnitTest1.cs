using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestIntSorting()
        {
            List<int> checkingList = new List<int>();
            int[] checkingArray = new int[] { 3, 8, 19, -5, 23, 100, 23, -5, 0, -7, 3 };
            foreach (var i in checkingArray)
            {
                checkingList.Add(i);
            }

            Sorting.BubbleSort<int>.Sort(checkingList, new StandartComparer());
            Assert.IsTrue(Sorting.BubbleSort<int>.IsSorted(checkingList, new StandartComparer()));
        }

        [TestMethod]
        public void TestSomeClassSorting()
        {
            List<SomeSortingClass> checkingList = new List<SomeSortingClass>();
            string[] numbers = new string[] { "123", "234", "012", "500" };
            foreach (var i in numbers)
            {
                var newElement = new SomeSortingClass(1, "a", i);
                checkingList.Add(newElement);
            }
            Sorting.BubbleSort<SomeSortingClass>.Sort(checkingList, new SomeSortingClassComparerByNumber());
            Assert.IsTrue(Sorting.BubbleSort<SomeSortingClass>.IsSorted(checkingList, new SomeSortingClassComparerByNumber()));
        }
    }
}
