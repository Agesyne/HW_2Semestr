using System;

namespace ArrayPrinting
{
    public class Program
    {
        /// <summary>
        /// Associate numbers and 2D directions
        /// </summary>
        private enum Direction { L, D, R, U };

        /// <summary>
        /// Associate coordinate's name and numbers
        /// </summary>
        private enum Coordinate { Y, X };

        /// <summary>
        /// Store map of coordinate diffecences for every direction step
        /// </summary>
        private readonly static int[,] directionDifference = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };


        /// <summary>
        /// Give coordinate difference by directions and coordinate name
        /// </summary>
        /// <param name="direction">The given direction</param>
        /// <param name="coordinate">The given coordinate name</param>
        /// <returns></returns>
        private static int GetWalkDirectoinDifference(Direction direction, Coordinate coordinate)
        {
            return directionDifference[(int)direction, (int)coordinate];
        }

        /// <summary>
        /// Print straight line of array in given directoin with given length
        /// </summary>
        /// <param name="printingArray">The printing array</param>
        /// <param name="currentPositionX">The starting X position</param>
        /// <param name="currentPositionY">The starting Y position</param>
        /// <param name="lineLength">The length of the line</param>
        /// <param name="direction">The given directoin</param>
        private static void PrintArrayLine(int[,] printingArray, ref int currentPositionX, ref int currentPositionY, int lineLength, Direction direction, ref string resultString)
        {
            int xDifference = GetWalkDirectoinDifference(direction, Coordinate.X);
            int yDifference = GetWalkDirectoinDifference(direction, Coordinate.Y);
            for (int i = 0; i < lineLength; ++i)
            {
                resultString += printingArray[currentPositionY, currentPositionX] + " ";
                currentPositionX += xDifference;
                currentPositionY += yDifference;
            }
        }

        /// <summary>
        /// Print given array spirally (only if it has odd side length)
        /// </summary>
        /// <param name="printingArray">The printing array</param>
        public static string PrintArraySpirally(int[,] printingArray)
        {
            if (printingArray == null)
            {
                throw new ArgumentNullException();
            }

            int arrayLength = (int)Math.Sqrt(printingArray.Length);
            if (arrayLength % 2 == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            string resultString = "";
            int currentPositionX = arrayLength / 2;
            int currentPositionY = currentPositionX;
            int stepNumber = 0;
            int lineLength = 0;
            
            while (currentPositionX != -1 || currentPositionY != 0)
            {
                if (stepNumber % 2 == 0)
                {
                    ++lineLength;
                }
                PrintArrayLine(printingArray, ref currentPositionX, ref currentPositionY, lineLength, (Direction)stepNumber, ref resultString);
                stepNumber = (stepNumber + 1) % 4;
            };
            return resultString;
        }

        static void Main(string[] args)
        {
        }
    }
}
