using System.Diagnostics;
using static System.Console;

namespace Snake
{
    internal class ConsoleGui
    {

        private const int TimeToWait = 500;

        private ConsoleGui() { }

        public static void ReadDirectionAndWait(Game game)
        {
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds <= TimeToWait)
            {
                game.Snake.SetDirection(ReadMovement());
            }
        }

        public static void DrawGameOver(Game game)
        {
            int xCenter = WindowWidth / 5;
            int yCenter = WindowHeight / 2;

            SetCursorPosition(xCenter, yCenter);
            WriteLine($"Game over, Score: {game.Snake.Length - 5}");
            SetCursorPosition(xCenter, yCenter + 1);
            ReadKey();
        }

        public static void DrawGame(Game game)
        {
            Clear();
            DrawBorder();
            DrawPixel(game.Berry, ConsoleColor.Cyan);
            DrawSnake(game.Snake);
        }

        private static Direction? ReadMovement()
        {
            if (KeyAvailable)
            {
                var key = ReadKey(true).Key;

                return key switch
                {
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    _ => null,
                };
            }
            return null;
        }

        private static void DrawBorder()
        {
            ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < WindowWidth; i++)
            {
                SetCursorPosition(i, 0);
                Write("■");
                SetCursorPosition(i, WindowHeight - 1);
                Write("■");
            }

            for (int i = 0; i < WindowHeight; i++)
            {
                SetCursorPosition(0, i);
                Write("■");
                SetCursorPosition(WindowWidth - 1, i);
                Write("■");
            }
        }

        private static void DrawPixel(Coordinates coordinates, ConsoleColor color)
        {
            SetCursorPosition(coordinates.X, coordinates.Y);
            ForegroundColor = color;
            Write("■");
            SetCursorPosition(0, 0);
        }

        private static void DrawSnake(Snake snake)
        {
            foreach (var bodyPart in snake.Body)
            {
                DrawPixel(bodyPart, ConsoleColor.Green);
            }
            DrawPixel(snake.Head, ConsoleColor.Red);
        }
    }
}
