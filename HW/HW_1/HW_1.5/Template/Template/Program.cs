using System;
using System.Collections.Generic;

namespace SortMatrix
{
    /// <summary>
    /// Class stores method to sort matrix by columns
    /// </summary>
    public class SortMatrix
    {
        /// <summary>
        /// Struct int pair
        /// </summary>
        private class Pair
        {
            public int First { get; set; }
            public int Second { get; set; }

            public Pair(int first, int second)
            {
                First = first;
                Second = second;
            }
        }
        
        /// <summary>
        /// Comparer for Pair class
        /// </summary>
        private class PairComparer : IComparer<Pair>
        {
            public int Compare(Pair x, Pair y)
            {
                if (x.First > y.First)
                {
                    return 1;
                }
                else if (x.First < y.First)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        

        /// <summary>
        /// Swap 2 int variables
        /// </summary>
        /// <param name="a">First var</param>
        /// <param name="b">Second var</param>
        private static void Swap<T>(ref T a, ref T b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// Swap 2 columns in matrix
        /// </summary>
        /// <param name="sortingMatrix">The sorting matrix</param>
        /// <param name="columns1Number">First swapping columns</param>
        /// <param name="column2Number">Second swapping columns</param>
        private static void InterchangeColumns(int[,] sortingMatrix, int columns1Number, int column2Number)
        {
            var columnLength = sortingMatrix.GetLength(0);
            for (var i = 0; i < columnLength; ++i)
            {
                Swap(ref sortingMatrix[i, columns1Number], ref sortingMatrix[i, column2Number]);
            }
        }

        /// <summary>
        /// Sort columns in matrix
        /// </summary>
        /// <param name="sortingMatrix">The sorting matrix</param>
        /// <param name="transmitions">The tranmitions matrix</param>
        private static void SortMatrixByColumns(int[,] sortingMatrix, Pair[] transmitions)
        {
            var currentColumnPosition = new int[sortingMatrix.GetLength(1)];
            for (var i = 0; i < currentColumnPosition.Length; ++i)
            {
                currentColumnPosition[i] = i;
            }

            for (var i = 0; i < currentColumnPosition.Length; ++i)
            {
                var columnCurrentNumber = transmitions[i].Second;
                if (i != currentColumnPosition[columnCurrentNumber])
                {
                    InterchangeColumns(sortingMatrix, i, currentColumnPosition[columnCurrentNumber]);
                    Swap(ref currentColumnPosition[Array.FindIndex(currentColumnPosition, x => x == i)], ref currentColumnPosition[columnCurrentNumber]);
                }
            }
        }

        /// <summary>
        /// Sort matrix by columns
        /// </summary>
        /// <param name="sortingMatrix">The sorting matrix</param>
        public static void SortMatrixByFirstColumnsElement(int[,] sortingMatrix)
        {
            if (sortingMatrix == null)
            {
                throw new ArgumentNullException();
            }

            var columnPositions = new Pair[sortingMatrix.GetLength(1)];
            for (var i = 0; i < columnPositions.Length; ++i)
            {
                var newPair = new Pair(sortingMatrix[0, i], i);
                columnPositions[i] = newPair;
            }
            Array.Sort(columnPositions, new PairComparer());

            SortMatrixByColumns(sortingMatrix, columnPositions);
        }

        /// <summary>
        /// Print given Matrix
        /// </summary>
        /// <param name="printingMatrix">The given matrix</param>
        public static void PrintMatrix(int[,] printingMatrix)
        {
            for (var i = 0; i < printingMatrix.GetLength(0); ++i)
            {
                for (var j = 0; j < printingMatrix.GetLength(1); ++j)
                {
                    Console.Write(printingMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
        }
    }
}
