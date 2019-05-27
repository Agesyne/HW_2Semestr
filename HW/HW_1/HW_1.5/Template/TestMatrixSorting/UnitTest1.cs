using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestMatrixSorting
    {
        /// <summary>
        /// Test if the given matrixes are same
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        private static bool IsMatrixesSame(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                return false;
            }

            for (var i = 0; i < matrix1.GetLength(0); ++i)
            {
                for (var j = 0; j < matrix1.GetLength(1); ++j)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Test the sorting method
        /// </summary>
        [TestMethod]
        public void TestSortMatrixByFirstColumnsElement()
        {
            int[,] testMatrix1 = { { 2, 1, 0 }, { 9, 1, 45 } };
            int[,] testMatrix2 = { { 1, 3, 0, 4, 2 }, { 9, 1, 45, 7, 9 }, { 8, 4, 0, -4, 7 } };
            int[,] testMatrix3 = { { 4, 3, 2, 1, 0 }, { 9, 1, 45, 7, 9 }, { 8, 4, 0, -4, 7 } };
            int[,] testMatrix4 = { { 0, 1, 2, 1, 0 }, { 9, 1, 45, 7, 9 }, { 8, 4, 0, -4, 7 } };
            int[,] testMatrix5 = null;

            int[,] resultMatrix1 = { { 0, 1, 2 }, { 45, 1, 9 } };
            int[,] resultMatrix2 = { { 0, 1, 2, 3, 4 }, { 45, 9, 9, 1, 7 }, { 0, 8, 7, 4, -4 } };
            int[,] resultMatrix3 = { { 0, 1, 2, 3, 4 }, { 9, 7, 45, 1, 9 }, { 7, -4, 0, 4, 8 } };
            int[,] resultMatrix4 = { { 0, 0, 1, 1, 2 }, { 9, 9, 1, 7, 45 }, { 8, 7, 4, -4, 0 } };

            SortMatrix.SortMatrix.SortMatrixByFirstColumnsElement(testMatrix1);
            Assert.IsTrue(IsMatrixesSame(testMatrix1, resultMatrix1));
            SortMatrix.SortMatrix.SortMatrixByFirstColumnsElement(testMatrix2);
            SortMatrix.SortMatrix.PrintMatrix(testMatrix2);
            Assert.IsTrue(IsMatrixesSame(testMatrix2, resultMatrix2));
            SortMatrix.SortMatrix.SortMatrixByFirstColumnsElement(testMatrix3);
            Assert.IsTrue(IsMatrixesSame(testMatrix3, resultMatrix3));
            SortMatrix.SortMatrix.SortMatrixByFirstColumnsElement(testMatrix4);
            Assert.IsTrue(IsMatrixesSame(testMatrix4, resultMatrix4));
            Assert.ThrowsException<ArgumentNullException>(() => SortMatrix.SortMatrix.SortMatrixByFirstColumnsElement(testMatrix5));
        }
    }
}
