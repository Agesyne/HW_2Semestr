using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericSet;

namespace UnitTests
{
    /// <summary>
    /// Test GenericSet class
    /// </summary>
    [TestClass]
    public class TestGenericSet
    {
        /// <summary>
        /// Testing class element
        /// </summary>
        private GenericSet<int> set = null;

        /// <summary>
        /// Array of adding values
        /// </summary>
        private int[] values = null;

        /// <summary>
        /// Array of 'set" values
        /// </summary>
        private int[] differentValues = null;

        /// <summary>
        /// Test initialize
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            set = new GenericSet<int>(new InteregerComparer());
            values = new int[] { 1, 0, 4, -1, 0, 7, 1 };
            differentValues = new int[] { 1, 0, 4, -1, 7};
        }

        /// <summary>
        /// Add given values to set
        /// </summary>
        /// <param name="values">The given values</param>
        /// <param name="set">The set values to be added</param>
        private void AddValues(int[] values, GenericSet<int> set)
        {
            foreach (var i in values)
            {
                set.Add(i);
            }
        }
        
        /// <summary>
        /// Test Add method
        /// </summary>
        [TestMethod]
        public void TestAddMethod()
        {
            foreach (var i in values)
            {
                set.Add(i);
            }
            Assert.AreEqual(differentValues.Length, set.Count);
        }

        /// <summary>
        /// Test Remove method
        /// </summary>
        [TestMethod]
        public void TestRemoveMethod()
        {
            AddValues(values, set);

            foreach (var i in differentValues)
            {
                set.Remove(i);
            }

            Assert.AreEqual(0, set.Count);
        }

        /// <summary>
        /// Test Clear method
        /// </summary>
        [TestMethod]
        public void TestClearMethod()
        {
            AddValues(values, set);

            set.Clear();

            Assert.AreEqual(0, set.Count);
        }

        /// <summary>
        /// Test Contains method
        /// </summary>
        [TestMethod]
        public void TestContainsMethod()
        {
            AddValues(values, set);

            foreach (var i in differentValues)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }


        /// <summary>
        /// Test Slice method
        /// </summary>
        [TestMethod]
        public void TestSliceMethod()
        {
            AddValues(values, set);
            Array.Sort(differentValues);

            var index = 0;
            foreach (var i in differentValues)
            {
                Assert.AreEqual(i, set[index]);
                ++index;
            }
        }


        /// <summary>
        /// Test Count property
        /// </summary>
        [TestMethod]
        public void TestCountProperty()
        {
            AddValues(values, set);
            Assert.AreEqual(differentValues.Length, set.Count);

            for (var i = 0; i < differentValues.Length; ++i)
            {
                set.Remove(differentValues[i]);
                Assert.AreEqual(differentValues.Length - 1 - i, set.Count);
            }
        }

        /// <summary>
        /// Test CopyTo method
        /// </summary>
        [TestMethod]
        public void TestCopyToMethod()
        {
            AddValues(values, set);
            Array.Sort(differentValues);
            Assert.AreEqual(differentValues.Length, set.Count);

            int[] result = new int[set.Count];
            set.CopyTo(result);

            Assert.AreEqual(differentValues.Length, result.Length);
            for (var i = 0; i < differentValues.Length; ++i)
            {
                Assert.AreEqual(differentValues[i], result[i]);
            }
        }


        /// <summary>
        /// Test SetEquals method
        /// </summary>
        [TestMethod]
        public void TestSetEqualMethod()
        {
            AddValues(values, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);

            Assert.IsTrue(set.SetEquals(other));
        }

        /// <summary>
        /// Test Overlap method
        /// </summary>
        [TestMethod]
        public void TestOverlapMethod()
        {
            AddValues(values, set);

            var other = new GenericSet<int>(new InteregerComparer());
            other.Add(set[0]);

            Assert.IsTrue(set.Overlaps(other));
        }


        /// <summary>
        /// Test IsSubsetOf method
        /// </summary>
        [TestMethod]
        public void TestIsSubsetOfMethod()
        {
            AddValues(values, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);

            Assert.IsTrue(set.IsSubsetOf(other));


            for (var i = 0; i < differentValues.Length / 2; i++)
            {
                set.Remove(differentValues[i]);
            }

            Assert.IsTrue(set.IsSubsetOf(other));
        }

        /// <summary>
        /// Test IsProperSubsetOf method
        /// </summary>
        [TestMethod]
        public void TestIsProperSubsetOfMethod()
        {
            AddValues(values, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);

            Assert.IsFalse(set.IsProperSubsetOf(other));


            for (var i = 0; i < differentValues.Length / 2; i++)
            {
                set.Remove(differentValues[i]);
            }

            Assert.IsTrue(set.IsProperSubsetOf(other));
        }

        /// <summary>
        /// Test IsSupersetOf method
        /// </summary>
        [TestMethod]
        public void TestIsSupersetOfMethod()
        {
            AddValues(values, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);

            Assert.IsTrue(set.IsSupersetOf(other));


            for (var i = 0; i < differentValues.Length / 2; i++)
            {
                other.Remove(differentValues[i]);
            }

            Assert.IsTrue(set.IsSupersetOf(other));
        }

        /// <summary>
        /// Test IsProperSupersetOf method
        /// </summary>
        [TestMethod]
        public void TestIsProperSupersetOfMethod()
        {
            AddValues(values, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);

            Assert.IsFalse(set.IsProperSupersetOf(other));


            for (var i = 0; i < differentValues.Length / 2; i++)
            {
                other.Remove(differentValues[i]);
            }

            Assert.IsTrue(set.IsProperSupersetOf(other));
        }

        /// <summary>
        /// Test UnionWith method
        /// </summary>
        [TestMethod]
        public void TestUnionWithMethod()
        {
            AddValues(values, set);
            
            var other = new GenericSet<int>(new InteregerComparer());
            int[] unionValues = new int[] { 100, 200, 300 };
            AddValues(unionValues, other);

            Assert.IsFalse(set.IsSupersetOf(other));


            set.UnionWith(other);

            foreach (var i in differentValues)
            {
                Assert.IsTrue(set.Contains(i));
            }
            foreach (var i in unionValues)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }

        /// <summary>
        /// Test IntersectWith method
        /// </summary>
        [TestMethod]
        public void TestIntersectWithMethod()
        {
            AddValues(values, set);
            int[] intersectValues = new int[] { 100, 200, 300 };
            AddValues(intersectValues, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);
            
            
            set.IntersectWith(other);

            foreach (var i in differentValues)
            {
                Assert.IsTrue(set.Contains(i));
            }
            foreach (var i in intersectValues)
            {
                Assert.IsFalse(set.Contains(i));
            }
        }

        /// <summary>
        /// Test ExceptWith method
        /// </summary>
        [TestMethod]
        public void TestExceptWithMethod()
        {
            AddValues(values, set);
            int[] intersectValues = new int[] { 100, 200, 300 };
            AddValues(intersectValues, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);


            set.ExceptWith(other);

            foreach (var i in differentValues)
            {
                Assert.IsFalse(set.Contains(i));
            }
            foreach (var i in intersectValues)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }

        /// <summary>
        /// Test SymmetricExceptWith method
        /// </summary>
        [TestMethod]
        public void TestSymmetricExceptWithMethod()
        {
            AddValues(values, set);

            var other = new GenericSet<int>(new InteregerComparer());
            AddValues(values, other);
            int[] intersectValues = new int[] { 100, 200, 300 };
            AddValues(intersectValues, set);


            set.SymmetricExceptWith(other);

            foreach (var i in differentValues)
            {
                Assert.IsFalse(set.Contains(i));
            }
            foreach (var i in intersectValues)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }
    }
}
