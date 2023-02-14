using System.Linq;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal
{
    public abstract class Animal
    {
        private List<string> _allowedFoods;

        public Animal(string name, double weight, double weightModifier, List<string> allowedFoods)
        {
            Name = name;
            Weight = weight;
            _allowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }    
        public double Weight { get; private set; }
        public int FoodEaten { get; set; } = 0;
        private double WeightModifier { get; set; }

        public IReadOnlyCollection<string> AllowedFoods => _allowedFoods.AsReadOnly();

        public abstract string AskForFood();

        public virtual void Feed(Food food, int foodQuantity)
        {
            string foodType = food.GetType().Name;
            if (!_allowedFoods.Contains(foodType.ToString()))
            {
                Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
            }
            else 
            {
                FoodEaten += foodQuantity;
                Weight += WeightModifier * foodQuantity;
            }
        }

    }
}
