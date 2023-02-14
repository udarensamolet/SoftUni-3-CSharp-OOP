using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        private const double WeightModifier = 0.30;
        private static List<string> allowedFoods = new List<string>()
        {
            nameof(Vegetable),
            nameof(Meat)
        };

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed, WeightModifier, allowedFoods)
        {
        }

        public IReadOnlyCollection<string> AllowedFoods = allowedFoods.AsReadOnly();

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
