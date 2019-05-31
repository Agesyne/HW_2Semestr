using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structures;

namespace UnitTests
{
    /// <summary>
    /// Test DataSqueezer class
    /// </summary>
    [TestClass]
    public class TestDataSqueezer
    {
        /// <summary>
        /// Check if arrays are equal
        /// </summary>
        /// <param name="a">The 1st array</param>
        /// <param name="b">The 2nd array</param>
        private bool IsSameArrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (var i = 0; i < a.Length; ++i)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Test Unbox method
        /// </summary>
        [TestMethod]
        public void TestUnboxMethod()
        {
            byte[] testAraray1 = new byte[] { };
            byte[] testAraray2 = new byte[] { 1, 0 };
            byte[] testAraray3 = new byte[] { 6, 0, 8, 1, 2, 255, 2, 128, 1, 127, 1, 0 };
            byte[] testAraray4 = new byte[] { 1, 0, 1, 1, 2, 0, 2, 1, 3, 0, 3, 1, 2, 0, 1, 1, 1, 0, 3, 1, 1, 0 };
            byte[] testAraray5 = new byte[] { 255, 0, 245, 0 };

            byte[] resultAraray1 = new byte[] { };
            byte[] resultAraray2 = new byte[] { 0 };
            byte[] resultAraray3 = new byte[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 255, 255, 128, 128, 127, 0 };
            byte[] resultAraray4 = new byte[] { 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] resultAraray5 = new byte[500];
            resultAraray5.Initialize();

            Assert.IsTrue(IsSameArrays(resultAraray1, DataSqueezer.Unbox(testAraray1)));
            Assert.IsTrue(IsSameArrays(resultAraray2, DataSqueezer.Unbox(testAraray2)));
            Assert.IsTrue(IsSameArrays(resultAraray3, DataSqueezer.Unbox(testAraray3)));
            Assert.IsTrue(IsSameArrays(resultAraray4, DataSqueezer.Unbox(testAraray4)));
            Assert.IsTrue(IsSameArrays(resultAraray5, DataSqueezer.Unbox(testAraray5)));
        }

        /// <summary>
        /// Test Box method
        /// </summary>
        [TestMethod]
        public void TestBoxMethod()
        {
            byte[] testAraray1 = new byte[] { };
            byte[] testAraray2 = new byte[] { 0 };
            byte[] testAraray3 = new byte[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 255, 255, 128, 128, 127, 0 };
            byte[] testAraray4 = new byte[] { 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            byte[] testAraray5 = new byte[500];
            testAraray5.Initialize();

            byte[] resultAraray1 = new byte[] { };
            byte[] resultAraray2 = new byte[] { 1, 0 };
            byte[] resultAraray3 = new byte[] { 6, 0, 8, 1, 2, 255, 2, 128, 1, 127, 1, 0 };
            byte[] resultAraray4 = new byte[] { 1, 0, 1, 1, 2, 0, 2, 1, 3, 0, 3, 1, 2, 0, 1, 1, 1, 0, 3, 1, 1, 0 };
            byte[] resultAraray5 = new byte[] { 255, 0, 245, 0 };

            Assert.IsTrue(IsSameArrays(resultAraray1, DataSqueezer.Box(testAraray1)));
            Assert.IsTrue(IsSameArrays(resultAraray2, DataSqueezer.Box(testAraray2)));
            Assert.IsTrue(IsSameArrays(resultAraray3, DataSqueezer.Box(testAraray3)));
            Assert.IsTrue(IsSameArrays(resultAraray4, DataSqueezer.Box(testAraray4)));
            Assert.IsTrue(IsSameArrays(resultAraray5, DataSqueezer.Box(testAraray5)));
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        [TestMethod]
        public void TestExceptions()
        {
            byte[] nullTestAraray = null;
            byte[] testAraray1 = new byte[] { 0 };

            Assert.ThrowsException<ArgumentNullException>(() => DataSqueezer.Box(nullTestAraray));
            Assert.ThrowsException<ArgumentNullException>(() => DataSqueezer.Unbox(nullTestAraray));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DataSqueezer.Unbox(testAraray1));
        }
    }
}
