namespace EventLoopGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Map2.txt";
            var newGame = new Game();
            newGame.Start(fileName);
        }
    }
}
