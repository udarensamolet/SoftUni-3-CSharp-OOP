using FoodShortage.Interfaces;
using FootShortage.Interfaces;

namespace FootShortage.Models
{
    public class Citizen : IIDentifiable, IPerson, IBirthatble, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
