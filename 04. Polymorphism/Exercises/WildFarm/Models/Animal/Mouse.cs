using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal
{
    public class Mouse : Mammal
    {
        private const double WeightModifier = 0.10;
        private static List<string> _allowedFoods = new List<string>()
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion, WeightModifier, _allowedFoods)
        {
        }

        public IReadOnlyCollection<string> AllowedFoods = _allowedFoods.AsReadOnly();

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
