using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            foods = new Food[3];
            foodIndex = RandomFoodNumber;
            snakeElements = new Queue<Point>();
            GetFoods();
            CreateSnake();
        }

        public int RandomFoodNumber => new Random().Next(0, foods.Length);

        private void CreateSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                snakeElements.Enqueue(new Point(leftX, 2));
            }

            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();

            snakeTail.Draw(' ');

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            wall.AddPoints(snakeElements);
            wall.PlayerInfo();
            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }
    }
}