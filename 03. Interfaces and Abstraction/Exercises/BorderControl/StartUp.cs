using BorderControl.Models;
using System.Runtime.CompilerServices;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            List<string> detained = new List<string>();
            List<Person> people = new List<Person>();
            List<Robot> robots = new List<Robot>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    Person person = new Person(name, age, id);
                    people.Add(person);
                }
                else if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];
                    Robot robot = new Robot(model, id);
                    robots.Add(robot);
                }
            }

            int fakeIds = int.Parse(Console.ReadLine());

            foreach (var person in people)
            {
                if (person.Id.EndsWith(fakeIds.ToString()))
                {
                    detained.Add(person.Id);
                }
            }

            foreach (var robot in robots)
            {
                if (robot.Id.EndsWith(fakeIds.ToString()))
                {
                    detained.Add(robot.Id);
                }
            }

            foreach(var id in detained)
            {
                Console.WriteLine(id);
            }
        }
    }
}