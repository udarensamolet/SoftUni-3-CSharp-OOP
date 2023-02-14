using WildFarm.Models.Animal;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] animalTokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string animalType = animalTokens[0];

                Animal animal = null;
                if (animalType == "Cat")
                {
                    string name = animalTokens[1];
                    double weight = double.Parse(animalTokens[2]);
                    string livingRegion = animalTokens[3];
                    string breed = animalTokens[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (animalType == "Tiger")
                {
                    string name = animalTokens[1];
                    double weight = double.Parse(animalTokens[2]);
                    string livingRegion = animalTokens[3];
                    string breed = animalTokens[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
                else if (animalType == "Dog")
                {
                    string name = animalTokens[1];
                    double weight = double.Parse(animalTokens[2]);
                    string livingRegion = animalTokens[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (animalType == "Mouse")
                {
                    string name = animalTokens[1];
                    double weight = double.Parse(animalTokens[2]);
                    string livingRegion = animalTokens[3];
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (animalType == "Owl")
                {
                    string name = animalTokens[1];
                    double weight = double.Parse(animalTokens[2]);
                    double wingSize = double.Parse(animalTokens[3]);
                    animal = new Owl(name, weight, wingSize);
                }
                else if (animalType == "Hen")
                {
                    string name = animalTokens[1];
                    double weight = double.Parse(animalTokens[2]);
                    double wingSize = double.Parse(animalTokens[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                animals.Add(animal);

                string[] foodTokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string foodType = foodTokens[0];
                int quantity = int.Parse(foodTokens[1]);

                Console.WriteLine(animal.AskForFood());

                Food food = null;
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }

                animal.Feed(food, quantity);
            }
            foreach(var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}