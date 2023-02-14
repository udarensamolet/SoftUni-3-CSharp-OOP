using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        private const double WeightModifier = 0.35;
        private static List<string> _allowedFoods = new List<string>()
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Seeds),
            nameof(Fruit)
        };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize, WeightModifier, _allowedFoods)
        {
        }

        public IReadOnlyCollection<string> AllowedFoods = _allowedFoods.AsReadOnly();

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
