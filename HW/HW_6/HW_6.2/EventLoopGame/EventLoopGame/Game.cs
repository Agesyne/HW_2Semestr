using System;

namespace EventLoopGame
{
    /// <summary>
    /// The game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Game map
        /// </summary>
        public class GameMap
        {
            /// <summary>
            /// Coordinate type
            /// </summary>
            public class Coord
            {
                /// <summary>
                /// Y value
                /// </summary>
                public int Y { get; set; }

                /// <summary>
                /// X value
                /// </summary>
                public int X { get; set; }


                /// <summary>
                /// Constructor
                /// </summary>
                public Coord(int y, int x)
                {
                    Y = y;
                    X = x;
                }
            }


            /// <summary>
            /// The map
            /// </summary>
            public char[,] Map { get; } = null;

            /// <summary>
            /// Player position
            /// </summary>
            public Coord Position { get; set; } = null;


            /// <summary>
            /// Constructor: load game map from given file
            /// </summary>
            public GameMap(string fileName)
            {
                var stringMap = ReadFileMap.ReadMap(fileName);
                Map = new char[stringMap.Length, stringMap[0].Length];

                for (var i = 0; i < stringMap.Length; ++i)
                {
                    for (var j = 0; j < stringMap[i].Length; ++j)
                    {
                        if (stringMap[i][j] == '@')
                        {
                            Position = new Coord(i, j);
                        }
                        Map[i, j] = stringMap[i][j];
                    }
                }
            }


            /// <summary>
            /// Check if coordinates are in the map
            /// </summary>
            private bool IsCorrectCoordinates(int x, int y) => !(x < 0 || y < 0 || x >= Map.GetLength(1) || y >= Map.GetLength(0));

            /// <summary>
            /// Check if player can go there
            /// </summary>
            private bool IsCorrectStep(int x, int y) => Map[y, x] == ' ';
            
            /// <summary>
            /// Make a move
            /// </summary>
            /// <param name="dX">Delta X</param>
            /// <param name="dY">Delta Y</param>
            public void MovePlayer(int dX, int dY)
            {
                if (IsCorrectCoordinates(Position.X + dX, Position.Y + dY) && IsCorrectStep(Position.X + dX, Position.Y + dY))
                {
                    Map[Position.Y + dY, Position.X + dX] = '@';
                    Map[Position.Y, Position.X] = ' ';
                    Position.X += dX;
                    Position.Y += dY;
                }
            }

        }

        /// <summary>
        /// Key typing observer
        /// </summary>
        public class GameEventHandler
        {
            public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
            public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
            public event EventHandler<EventArgs> UpHandler = (sender, args) => { };
            public event EventHandler<EventArgs> DownHandler = (sender, args) => { };
            public event EventHandler<EventArgs> DrawHandler = (sender, args) => { };

            /// <summary>
            /// Constructor: link events to handlers
            /// </summary>
            /// <param name="up">Move up</param>
            /// <param name="down">Move down</param>
            /// <param name="left">Move left</param>
            /// <param name="right">Move right</param>
            /// <param name="draw">Draw map</param>
            public GameEventHandler(EventHandler<EventArgs> up,
                                    EventHandler<EventArgs> down,
                                    EventHandler<EventArgs> left,
                                    EventHandler<EventArgs> right,
                                    EventHandler<EventArgs> draw)
            {
                UpHandler += up;
                DownHandler += down;
                LeftHandler += left;
                RightHandler += right;

                UpHandler += draw;
                DownHandler += draw;
                LeftHandler += draw;
                RightHandler += draw;
                DrawHandler += draw;
            }

            /// <summary>
            /// Begin observe key typing
            /// </summary>
            public void Run()
            {
                DrawHandler(this, EventArgs.Empty);
                while (true)
                {
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            LeftHandler(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.RightArrow:
                            RightHandler(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.UpArrow:
                            UpHandler(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.DownArrow:
                            DownHandler(this, EventArgs.Empty);
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }
            }

        }


        /// <summary>
        /// Game map
        /// </summary>
        public GameMap Map = null;

        /// <summary>
        /// Game event handler
        /// </summary>
        public GameEventHandler EventObserver = null;


        /// <summary>
        /// Start game
        /// </summary>
        /// <param name="fileName">Filename of map</param>
        public void Start(string fileName)
        {
            Map = new GameMap(fileName);
            EventObserver = new GameEventHandler(OnUp, OnDown, OnLeft, OnRight, Draw);
            EventObserver.Run();
        }


        /// <summary>
        /// Drap game map
        /// </summary>
        private void Draw(object sender, EventArgs args)
        {
            Console.SetCursorPosition(0, 0);
            var printingMap = Map.Map;

            for (var i = 0; i < printingMap.GetLength(0); ++i)
            {
                for (var j = 0; j < printingMap.GetLength(1); ++j)
                {
                    Console.Write(printingMap[i, j]);
                }
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Event go up
        /// </summary>
        public void OnUp(object sender, EventArgs args)
        {
            Map.MovePlayer(0, -1);
        }

        /// <summary>
        /// Event go down
        /// </summary>
        public void OnDown(object sender, EventArgs args)
        {
            Map.MovePlayer(0, 1);
        }

        /// <summary>
        /// Event go left
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
        {
            Map.MovePlayer(-1, 0);
        }

        /// <summary>
        /// Event go right
        /// </summary>
        public void OnRight(object sender, EventArgs args)
        {
            Map.MovePlayer(1, 0);
        }

    }
}
