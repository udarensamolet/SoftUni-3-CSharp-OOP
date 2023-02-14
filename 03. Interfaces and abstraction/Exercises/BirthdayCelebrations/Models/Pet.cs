using BirthdayCelebrations.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Pet : IPet, IBirthatble
    {
        public Pet(string name, string birtdate)
        {
            Name = name;
            Birthdate = birtdate;
        }
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
