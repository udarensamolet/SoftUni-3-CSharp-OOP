using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        private const double WeightModifier = 0.40;
        private static List<string> allowedFoods = new List<string>()
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, WeightModifier, allowedFoods)
        {
        }

        public IReadOnlyCollection<string> AllowedFoods = allowedFoods.AsReadOnly();

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
