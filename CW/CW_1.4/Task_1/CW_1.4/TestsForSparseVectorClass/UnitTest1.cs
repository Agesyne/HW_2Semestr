using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForSparseVectorClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOperationSum()
        {
            bool isDone = true;
            /*
            int[] a = { 0, 0, 0, 12, 38, 0, 0, 8, 0, 4, 0};
            int[] b = { 1, 0, 3, 0, 10, 3, 0, 0, 0, 0, 6};
            int[] c = { 1, 0, 3, 12, 48, 3, 0, 8, 0, 4, 6};
            */
            var vector1 = new SparseVector.SparseVector();
            vector1.Add(0, 2);
            vector1.Add(12, 0);
            vector1.Add(38, 2);
            vector1.Add(8, 1);
            vector1.Add(4, 1);
            var vector2 = new SparseVector.SparseVector();
            vector2.Add(1, 1);
            vector2.Add(3, 1);
            vector2.Add(10, 0);
            vector2.Add(3, 4);
            vector2.Add(6, 0);
            var resultVector = SparseVector.SparseVector.SumVectors(vector1 , vector2);

            var answerVector = new SparseVector.SparseVector();
            answerVector.Add(1, 1);
            answerVector.Add(3, 0);
            answerVector.Add(12, 0);
            answerVector.Add(48, 0);
            answerVector.Add(3, 1);
            answerVector.Add(8, 1);
            answerVector.Add(4, 0);
            answerVector.Add(6, 0);
            for (var i = 0; i < resultVector.GetAmoutOfValues(); ++i)
            {
                if (resultVector.GetValue(i) != answerVector.GetValue(i) || resultVector.GetZerosValue(i) != answerVector.GetZerosValue(i))
                {
                    isDone = false;
                    break;
                }
            }
            Assert.IsTrue(isDone);
        }

        [TestMethod]
        public void TestOperationSub()
        {
            bool isDone = true;
            /*
            int[] a = { 0, 0, 0, 12, 38, 0, 0, 8, 0, 4, 0 };
            int[] b = { 1, 0, 3, 0, 10, 3, 0, 0, 0, 0, 6 };
            int[] c = { -1, 0, -3, 12, 28, -3, 0, 8, 0, 4, -6 };
            */
            var vector1 = new SparseVector.SparseVector();
            vector1.Add(0, 2);
            vector1.Add(12, 0);
            vector1.Add(38, 2);
            vector1.Add(8, 1);
            vector1.Add(4, 1);
            var vector2 = new SparseVector.SparseVector();
            vector2.Add(1, 1);
            vector2.Add(3, 1);
            vector2.Add(10, 0);
            vector2.Add(3, 4);
            vector2.Add(6, 0);
            var resultVector = SparseVector.SparseVector.SubtractVectors(vector1, vector2);

            var answerVector = new SparseVector.SparseVector();
            answerVector.Add(-1, 1);
            answerVector.Add(-3, 0);
            answerVector.Add(12, 0);
            answerVector.Add(28, 0);
            answerVector.Add(-3, 1);
            answerVector.Add(8, 1);
            answerVector.Add(4, 0);
            answerVector.Add(-6, 0);
            for (var i = 0; i < resultVector.GetAmoutOfValues(); ++i)
            {
                if (resultVector.GetValue(i) != answerVector.GetValue(i) || resultVector.GetZerosValue(i) != answerVector.GetZerosValue(i))
                {
                    isDone = false;
                    break;
                }
            }
            Assert.IsTrue(isDone);
        }

        [TestMethod]
        public void TestOperationMul()
        {
            bool isDone = true;
            /*
            int[] a = { 0, 0, 0, 12, 38, 0, 0, 8, 0, 4, 0 };
            int[] b = { 1, 0, 3, 0, 10, 3, 0, 0, 0, 0, 6 };
            */
            int answer = 380;
            var vector1 = new SparseVector.SparseVector();
            vector1.Add(0, 2);
            vector1.Add(12, 0);
            vector1.Add(38, 2);
            vector1.Add(8, 1);
            vector1.Add(4, 1);
            var vector2 = new SparseVector.SparseVector();
            vector2.Add(1, 1);
            vector2.Add(3, 1);
            vector2.Add(10, 0);
            vector2.Add(3, 4);
            vector2.Add(6, 0);
            var result = SparseVector.SparseVector.ScalarMultiplyVectors(vector1, vector2);

            isDone = answer == result;
            Assert.IsTrue(isDone);
        }

        [TestMethod]
        public void TestIsZero()
        {
            /*
            int[] a = { 0, 0, 0, 12, 38, 0, 0, 8, 0, 4, 0 };
            int[] b = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            */
            var vector1 = new SparseVector.SparseVector();
            vector1.Add(0, 2);
            vector1.Add(12, 0);
            vector1.Add(38, 2);
            vector1.Add(8, 1);
            vector1.Add(4, 1);
            var vector2 = new SparseVector.SparseVector();
            vector2.Add(0, 10);
            Assert.IsFalse(SparseVector.SparseVector.IsZeroVector(vector1));
            Assert.IsTrue(SparseVector.SparseVector.IsZeroVector(vector2));
        }
    }
}
