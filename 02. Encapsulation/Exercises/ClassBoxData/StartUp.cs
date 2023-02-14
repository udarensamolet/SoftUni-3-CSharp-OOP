using ClassBoxData;
using System.Text;

namespace ClassBoxOfData
{
    public class StartUp
    {
        static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            var box = new Box(length, width, height);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {box.CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {box.CalculateVolume():f2}");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}