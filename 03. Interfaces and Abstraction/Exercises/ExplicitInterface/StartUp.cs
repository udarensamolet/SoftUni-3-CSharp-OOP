using ExplicitInterface.Contracts;
using ExplicitInterface.Models;

namespace ExplicitInterface
{
    public class StartUp
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "End")
                {
                    break;
                }
                string[] tokens = input
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson personName = citizen;
                IResident residentName = citizen;

                personName.GetName();
                residentName.GetName();
            }
           
        }
    }
}