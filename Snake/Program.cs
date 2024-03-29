namespace Snake
{
    class Program
    {

        private const int Width = 32;
        private const int Height = 16;

        static void Main()
        {
            Console.SetWindowSize(Width, Height);
            Game game = new(Width, Height);

            while (game.Tick())
            {
                ConsoleGui.DrawGame(game);
                ConsoleGui.ReadDirectionAndWait(game);
            }
            ConsoleGui.DrawGameOver(game);
        }
    }
}