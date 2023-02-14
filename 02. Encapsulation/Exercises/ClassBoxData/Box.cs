using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => _length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative");
                }
                _length = value;
            }
        }
        public double Width
        {
            get => _width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative");
                }
                _width = value;
            }
        }

        public double Height
        {
            get => _height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative");
                }
                _height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2 * (Length * Width + Length * Height + Width * Height);
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * (Length * Height + Width * Height);
        }

        public double CalculateVolume()
        {
            return Length * Width * Height;
        }
    }
}
