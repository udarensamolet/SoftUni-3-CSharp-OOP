using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Person : IIDentifiable, IPerson
    {
        public Person(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}
