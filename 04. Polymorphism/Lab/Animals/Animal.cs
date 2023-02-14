using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood= favouriteFood;
        }

        public string Name { get; private set; }
        public string FavouriteFood { get; private set; }

        public virtual string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"I am {Name} and my favourite food is {FavouriteFood}");
            return sb.ToString();
        }
    }
}
