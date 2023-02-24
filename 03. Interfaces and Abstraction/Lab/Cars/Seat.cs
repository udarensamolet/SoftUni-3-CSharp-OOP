using System.Text;
using Cars.Interfaces;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color) 
        {
            Model = model;
            Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} {GetType().Name} {Model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString();
        }
    }
}
