using BirthdayCelebrations.Models;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Robot> robots = new List<Robot>();
            List<Pet> pets = new List<Pet>();

            while (true)
            {
                string[] input = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                if (input[0] == "End")
                {
                    break;
                }

                string type = input[0];

                if (type == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];
                    Person person = new Person(name, age, id, birthdate);
                    people.Add(person);
                }
                else if (type == "Robot")
                {
                    string model = input[1];
                    string id = input[2];
                    Robot robot = new Robot(model, id);
                    robots.Add(robot);
                }
                else if (type == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];
                    Pet pet = new Pet(name, birthdate);
                    pets.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var person in people)
            {
                if (person.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(person.Birthdate);
                }
            }

            foreach (var pet in pets)
            {
                if (pet.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(pet.Birthdate);
                }
            }
        }
    }
}