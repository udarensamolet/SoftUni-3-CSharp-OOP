namespace WildFarm.Models.Animal
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion, double weightModifier, List<string> allowedFoods) 
            : base(name, weight, weightModifier, allowedFoods)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion;
    }
}
