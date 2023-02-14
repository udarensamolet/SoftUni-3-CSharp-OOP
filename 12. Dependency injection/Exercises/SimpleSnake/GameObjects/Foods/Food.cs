using System.Drawing;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Wall wall;
        private char foodSymbol;
        private Random random;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElements.Any(x => x.TopY == TopY && x.LeftX == LeftX);

            while (isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements.Any(x => x.TopY == TopY && x.LeftX == LeftX);
            }

            Draw(foodSymbol);
        }

        public bool IsFoodPoint(Point snake)
        {
            return LeftX == snake.LeftX && TopY == snake.TopY;
        }
    }
}
