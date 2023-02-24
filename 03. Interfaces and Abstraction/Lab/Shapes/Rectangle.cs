using Shapes.Interfaces;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public void Draw()
        {
            // top line
            for(int i = 0; i < Width; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();

            // middle
            for (int i = 0; i < Height - 2; i++)
            {
                Console.Write('*');
                for (int j = 0; j < Width - 2; j++)
                {
                    Console.Write(' ');
                }
                Console.Write('*');
                Console.WriteLine();
            }

            // bottom line
            for (int i = 0; i < Width; i++)
            {
                Console.Write('*');
            }
        }
    }
}
