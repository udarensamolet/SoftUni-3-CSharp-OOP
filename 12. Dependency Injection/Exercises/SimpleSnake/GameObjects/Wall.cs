namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        private int playerPoints;

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            InitializeWallBorders();
            PlayerInfo();
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.LeftX == 0 || snake.LeftX == LeftX || snake.TopY == 0 || snake.TopY == TopY - 1;
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY - 1);
            SetVerticalLine(0);
            SetVerticalLine(LeftX);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }

        public void AddPoints(Queue<Point> snakeElements)
        {
            playerPoints = snakeElements.Count - 6;
        }

        public void PlayerInfo()
        {
            Console.SetCursorPosition(LeftX + 3, 0);
            Console.Write($"Player points: {playerPoints}");
            Console.SetCursorPosition(LeftX + 3, 1);
            Console.Write($"Player level: {playerPoints / 10}");
        }
    }
}
