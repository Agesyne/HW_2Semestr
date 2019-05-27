using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestArrayPrinting
{
    [TestClass]
    public class TestArrayPrinting
    {
        [TestMethod]
        public void TestSpirallyArrayPrinting()
        {
            int[,] testArray1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            string result1 = "5 4 7 8 9 6 3 2 1 ";
            int[,] testArray2 = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            string result2 = "13 12 17 18 19 14 9 8 7 6 11 16 21 22 23 24 25 20 15 10 5 4 3 2 1 ";
            int[,] testArray3 = null;
            int[,] testArray4 = { { 1, 2 }, { 3, 4 } };
            int[,] testArray5 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };

            string result = "";
            result = ArrayPrinting.Program.PrintArraySpirally(testArray1);
            Assert.IsTrue(result == result1);
            result = ArrayPrinting.Program.PrintArraySpirally(testArray2);
            Assert.IsTrue(result == result2);

            Assert.ThrowsException<ArgumentNullException>(() => ArrayPrinting.Program.PrintArraySpirally(testArray3));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayPrinting.Program.PrintArraySpirally(testArray4));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayPrinting.Program.PrintArraySpirally(testArray5));

        }
    }
}
