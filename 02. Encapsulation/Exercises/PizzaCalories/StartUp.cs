namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            while (true)
            {
                string[] input = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                string type = input[0];

                if (type == "END")
                {
                    break;
                }
                else if (type == "Dough")
                {
                    string flour = input[1];
                    string bakingTechnique = input[2];
                    double grams = double.Parse(input[3]);

                    Dough dough = new Dough(flour, bakingTechnique, grams);
                    Console.WriteLine($"{dough.GetCalories():f2}");
                }
                else if (type == "Topping")
                {
                    string name = input[1];
                    double weight = double.Parse(input[2]);

                    Topping topping = new Topping(name, weight);
                    Console.WriteLine($"{topping.GetCalories():f2}");
                }
               
            }
           

            
        }
    }
}