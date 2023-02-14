using System.Diagnostics.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal
{
    public class Owl : Bird
    {
        private const double WeightModifier = 0.25;
        private static List<string> _allowedFoods = new List<string>()
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, WeightModifier, _allowedFoods)
        {
        }

        public IReadOnlyCollection<string> AllowedFoods => _allowedFoods.AsReadOnly();

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
