namespace Snake
{
    internal class Game(int width, int height)
    {
        private readonly static Random Random = new();
        public Snake Snake { get; private set; } = new(CreateCenterPoint(width, height));
        public Coordinates Berry { get; private set; } = GenerateBerry(width, height);

        public bool Tick()
        {
            if (IsBerryCollision())
            {
                EatAndCreateNewBerry();
            }

            Snake.Move();
            return !IsCollision();
        }

        private bool IsBerryCollision()
        {
            return Berry.X == Snake.Head.X && Berry.Y == Snake.Head.Y;
        }

        private void EatAndCreateNewBerry()
        {
            Snake.Length++;
            Berry = GenerateBerry(width, height);
        }

        private static Coordinates GenerateBerry(int width, int height)
        {
            return new Coordinates(Random.Next(1, width - 2), Random.Next(1, height - 2));
        }

        private static Coordinates CreateCenterPoint(int width, int height)
        {
            return new Coordinates(width / 2, height / 2);
        }

        private bool IsCollision()
        {
            return IsWallCollision() || IsBodyCollision();
        }

        private bool IsWallCollision()
        {
            return Snake.Head.X == width - 1 || Snake.Head.X == 0 || Snake.Head.Y == height - 1 || Snake.Head.Y == 0;
        }

        private bool IsBodyCollision()
        {
            return Snake.Body.Any(coordinates => coordinates.X == Snake.Head.X && coordinates.Y == Snake.Head.Y);
        }

    }
}
