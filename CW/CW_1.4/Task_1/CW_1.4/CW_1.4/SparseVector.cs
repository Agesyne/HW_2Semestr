using System;
using System.Collections.Generic;

namespace SparseVector
{
    /// <summary>
    /// Sparse Vector Class
    /// </summary>
    public class SparseVector
    {
        /// <summary>
        /// The values of vector
        /// </summary>
        private List<SparseVectorElement> vector = new List<SparseVectorElement>();

        public int GetAmoutOfValues()
        {
            return vector.Count;
        }

        /// <summary>
        /// Get n'th value in vector
        /// </summary>
        /// <param name="index">Index of value</param>
        /// <returns></returns>
        public int GetValue(int index)
        {
            return vector[index].Value;
        }

        /// <summary>
        /// Get n'th value's zeros in vector
        /// </summary>
        /// <param name="index">Index of value</param>
        /// <returns></returns>
        public int GetZerosValue(int index)
        {
            return vector[index].NextZeros;
        }

        /// <summary>
        /// Number of dimentions
        /// </summary>
        public int Dimention { get; protected set; } = 0;

        /// <summary>
        /// Enum to choose operation
        /// </summary>
        private enum Operation { Sum, Sub, Mul };
        
        /// <summary>
        /// The internal class - element of SparseVector
        /// </summary>
        private class SparseVectorElement
        {
            public int Value { get; set; }
            public int NextZeros { get; set; }

            public SparseVectorElement(int value, int nextZeros)
            {
                Value = value;
                NextZeros = nextZeros;
            }

            public SparseVectorElement()
            {

            }
        }

        /// <summary>
        /// The simple constructor
        /// </summary>
        /// <param name="values">Array form of vector</param>
        public SparseVector(params int[] values)
        {
            foreach (var i in values)
            {
                var newElement = new SparseVectorElement(i, 0);
                vector.Add(newElement);
                Dimention += 1;
            }
        }

        /// <summary>
        /// Add element to vector
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="NextZeros">The number of Zeros after the value</param>
        public void Add(int value, int NextZeros)
        {
            var newElement = new SparseVectorElement(value, NextZeros);
            vector.Add(newElement);
            Dimention += 1 + NextZeros;
        }


        /// <summary>
        /// Make given operations between two integer
        /// </summary>
        /// <param name="a">First int</param>
        /// <param name="b">Second int</param>
        /// <param name="operation">The operation</param>
        /// <returns></returns>
        private static int MakeOperation(int a, int b, Operation operation)
        {
            if (operation == Operation.Sum)
            {
                return a + b;
            }
            else if (operation == Operation.Sub)
            {
                return a - b;
            }
            else
            {
                return a * b;
            }
        }

        /// <summary>
        /// The method to walk through 2 vectors and make given operations between them
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <param name="operation">The operation</param>
        /// <returns></returns>
        private static SparseVector MakeMathAction(SparseVector a, SparseVector b, Operation operation)
        {
            var newSparseVector = new SparseVector();
            int totalValue = 0;
            int aDimentionValue = 0;
            int aVectorPointer = 0;
            int bDimentionValue = 0;
            int bVectorPointer = 0;
            int currentDimention = 0;
            while (aVectorPointer < a.vector.Count && bVectorPointer < b.vector.Count)
            {
                int value = 0;
                int nextZeros = 0;
                var newElement = new SparseVectorElement();

                if (currentDimention == aDimentionValue && currentDimention == bDimentionValue)
                {

                    value = MakeOperation(a.vector[aVectorPointer].Value, b.vector[bVectorPointer].Value, operation);
                    nextZeros = Math.Min(a.vector[aVectorPointer].NextZeros, b.vector[bVectorPointer].NextZeros);
                    aDimentionValue += a.vector[aVectorPointer].NextZeros + 1;
                    bDimentionValue += b.vector[bVectorPointer].NextZeros + 1;
                    ++aVectorPointer;
                    ++bVectorPointer;
                }
                else
                {
                    if (currentDimention == aDimentionValue)
                    {
                        value = MakeOperation(a.vector[aVectorPointer].Value, 0, operation);
                        nextZeros = Math.Min(a.vector[aVectorPointer].NextZeros, bDimentionValue - currentDimention - 1);
                        aDimentionValue += a.vector[aVectorPointer].NextZeros + 1;
                        ++aVectorPointer;
                    }
                    else
                    {
                        value = MakeOperation(0, b.vector[aVectorPointer].Value, operation);
                        nextZeros = Math.Min(b.vector[bVectorPointer].NextZeros, aDimentionValue - currentDimention - 1);
                        bDimentionValue += b.vector[bVectorPointer].NextZeros + 1;
                        ++bVectorPointer;
                    }
                }

                if (operation != Operation.Mul)
                {
                    newSparseVector.Add(value, nextZeros);
                }
                else
                {
                    totalValue += value;
                }

                currentDimention += nextZeros + 1;
            }

            if (operation != Operation.Mul)
            {
                if (aVectorPointer == a.vector.Count)
                {
                    for (var i = bVectorPointer; i < b.vector.Count; ++i)
                    {
                        if (operation == Operation.Sub)
                        {
                            var newElement = new SparseVectorElement(-b.vector[i].Value, b.vector[i].NextZeros);
                            newSparseVector.vector.Add(newElement);
                        }
                        else
                        {
                            newSparseVector.vector.Add(b.vector[i]);
                        }
                    }
                }
                else
                {
                    for (var i = aVectorPointer; i < a.vector.Count; ++i)
                    {
                        newSparseVector.vector.Add(a.vector[i]);
                    }
                }

            }


            if (operation == Operation.Mul)
            {
                newSparseVector.Add(totalValue, 0);
                newSparseVector.Dimention = 1;
            }
            else
            {
                newSparseVector.Dimention = Math.Max(a.Dimention, b.Dimention);
            }
            return newSparseVector;
        }


        /// <summary>
        /// Sum 2 vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns></returns>
        public static SparseVector SumVectors(SparseVector a, SparseVector b)
        {
            var newSparseVector = MakeMathAction(a, b, Operation.Sum);
            return newSparseVector;
        }

        /// <summary>
        /// Subtract 2 vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns></returns>
        public static SparseVector SubtractVectors(SparseVector a, SparseVector b)
        {
            var newSparseVector = MakeMathAction(a, b, Operation.Sub);
            return newSparseVector;
        }

        /// <summary>
        /// Multiply 2 vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns></returns>
        public static int ScalarMultiplyVectors(SparseVector a, SparseVector b)
        {
            var newSparseVector = MakeMathAction(a, b, Operation.Mul);
            return newSparseVector.vector[0].Value;
        }

        /// <summary>
        /// Check if vector is zero
        /// </summary>
        /// <param name="a">The checking vector</param>
        /// <returns></returns>
        public static bool IsZeroVector(SparseVector a)
        {
            foreach (var i in a.vector)
            {
                if (i.Value != 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Clone given vector
        /// </summary>
        /// <param name="a">The cloning vector</param>
        /// <returns></returns>
        public SparseVector Clone(SparseVector a)
        {
            var newSparseVector = new SparseVector();
            foreach (var i in a.vector)
            {
                newSparseVector.vector.Add(i);
            }
            newSparseVector.Dimention = a.Dimention;

            return newSparseVector;
        }
    }
}
