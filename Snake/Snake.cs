namespace Snake
{
    class Snake(Coordinates startPosition)
    {
        private const int InitialLength = 5;

        public Coordinates Head { get; private set; } = startPosition;
        public List<Coordinates> Body { get; private set; } = [];
        public Direction Direction { get; private set; } = Direction.Right;
        public int Length { get; set; } = InitialLength;

        public void Move()
        {
            Coordinates newHead = new(Head.X, Head.Y);
            UpdateHeadPosition(ref newHead);
           
            Body.Add(new Coordinates(Head.X, Head.Y));
            if (Body.Count >= Length)
            {
                Body.RemoveAt(0);
            }

            Head = newHead;
        }

        private void UpdateHeadPosition(ref Coordinates newHead)
        {
            switch (Direction)
            {
                case Direction.Left:
                    newHead.X--;
                    break;
                case Direction.Right:
                    newHead.X++;
                    break;
                case Direction.Up:
                    newHead.Y--;
                    break;
                case Direction.Down:
                    newHead.Y++;
                    break;
            }
        }

        public void SetDirection(Direction? newDirection)
        {
            if (newDirection != null && newDirection != OppositeDirection(Direction))
            {
                Direction = (Direction)newDirection;
            }
        }

        private static Direction OppositeDirection(Direction direction)
        {
            return direction switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => throw new ArgumentException("Invalid direction"),
            };
        }
    }
}
