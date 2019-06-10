using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventLoopGame;

namespace UnitTests
{
    /// <summary>
    /// Test ReadFileMap class
    /// </summary>
    [TestClass]
    public class TestReadFileMap
    {
        /// <summary>
        /// Test ReadMap method
        /// </summary>
        [TestMethod]
        public void TestReadMap()
        {
            string[] resultMap = new string[] { "###########",
                                                "#@#    #  #",
                                                "# ###  #  #",
                                                "#      #  #",
                                                "### #  #  #",
                                                "# # ####  #",
                                                "# #       #",
                                                "#   # ##  #",
                                                "###########"};

            var answerMap = ReadFileMap.ReadMap("Map1.txt");

            Assert.AreEqual(resultMap.Length, answerMap.Length);
            for (var i = 0; i < resultMap.Length; ++i)
            {
                Assert.AreEqual(resultMap[i], answerMap[i]);
            }
        }
    }
}
