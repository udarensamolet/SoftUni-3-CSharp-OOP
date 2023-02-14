using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height;
        public double Width;

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Height + Width);
        }

        public override string Draw()
        {
            var sb = new StringBuilder();
            // top line
            for (int i = 0; i < Width; i++)
            {
                sb.Append('*');
            }
            sb.AppendLine();

            // middle
            for (int i = 0; i < Height - 2; i++)
            {
                sb.Append('*');
                for (int j = 0; j < Width - 2; j++)
                {
                    sb.Append(' ');
                }
                sb.Append('*');
                sb.AppendLine();
            }

            // bottom line
            for (int i = 0; i < Width; i++)
            {
                sb.Append('*');
            }

            return sb.ToString().TrimEnd();
        }
    }
}
