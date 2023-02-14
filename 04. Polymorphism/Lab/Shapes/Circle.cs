using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius;

        public override double CalculatePerimeter()
        {
            return Math.PI * 2 * Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string Draw()
        {
            var sb = new StringBuilder();
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                        sb.Append("*");
                    else
                        sb.Append(" ");
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
