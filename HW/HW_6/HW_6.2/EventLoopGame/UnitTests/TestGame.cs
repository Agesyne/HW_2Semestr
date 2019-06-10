using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventLoopGame;

namespace UnitTests
{
    /// <summary>
    /// Test Game class
    /// </summary>
    [TestClass]
    public class TestGame
    {
        /// <summary>
        /// Game object
        /// </summary>
        private Game game = null;

        /// <summary>
        /// Test initialize
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            game = new Game();
            game.Map = new Game.GameMap("Map2.txt");
            game.EventObserver = new Game.GameEventHandler(game.OnUp, game.OnDown, game.OnLeft, game.OnRight, null);
        }


        /// <summary>
        /// Test GoUp event
        /// </summary>
        [TestMethod]
        public void TestGoUpEvent()
        {
            game.OnUp(game, null);
        }

        /// <summary>
        /// Test GoDown event
        /// </summary>
        [TestMethod]
        public void TestGoDownEvent()
        {
            game.OnDown(game, null);
        }

        /// <summary>
        /// Test GoLeft event
        /// </summary>
        [TestMethod]
        public void TestGoLeftEvent()
        {
            game.OnLeft(game, null);
        }

        /// <summary>
        /// Test GoRight event
        /// </summary>
        [TestMethod]
        public void TestGoRightEvent()
        {
            game.OnRight(game, null);
        }

        /// <summary>
        /// Test some predefined walking ways
        /// </summary>
        /// <param name="steps">The string of steps</param>
        /// <param name="resultX">Result X coordinate</param>
        /// <param name="resultY">Result Y coordinate</param>
        [TestMethod]
        [DataRow("DRUDRULLULRU", 1, 0)]
        [DataRow("DRDRULUDRDRLUDRULDR", 2, 2)]
        [DataRow("DRDRRRDDDDDRRDRLULULRD", 3, 6)]
        [DataRow("RRRRRRDDDDDDDLLLLLUUUUDDDDDRRRR", 6, 6)]
        [DataRow("RRDDDRRRRRUUUULLLLLDDDDDDDDDDDLLLLLLLLLLLUURRLRUD", 1, 7)]
        public void TestWalk(string steps, int resultX, int resultY)
        {
            foreach (var i in steps)
            {
                switch (i)
                {
                    case 'U':
                        game.OnUp(game, null);
                        break;

                    case 'D':
                        game.OnDown(game, null);
                        break;

                    case 'L':
                        game.OnLeft(game, null);
                        break;

                    case 'R':
                        game.OnRight(game, null);
                        break;
                }
            }

            Assert.AreEqual(resultX, game.Map.Position.X);
            Assert.AreEqual(resultY, game.Map.Position.Y);
        }

    }
}
