using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal
{
    public class Tiger : Feline
    {
        private const double WeightModifier = 1;
        private static List<string> _allowedFoods = new List<string>()
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, WeightModifier, _allowedFoods)
        {
        }

        public IReadOnlyCollection<string> AllowedFoods = _allowedFoods.AsReadOnly();

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
