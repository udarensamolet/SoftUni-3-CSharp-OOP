using System.Runtime.CompilerServices;

namespace WildFarm.Models.Animal
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize, double weightModifier, List<string> allowedFoods) 
            : base(name, weight, weightModifier, allowedFoods)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
