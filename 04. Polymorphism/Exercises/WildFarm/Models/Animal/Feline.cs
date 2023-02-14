namespace WildFarm.Models.Animal
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed, double weightModifier, List<string> allowedFoods)
            : base(name, weight, livingRegion, weightModifier, allowedFoods)
        {
            Breed = breed;
        }

        public string Breed;

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
