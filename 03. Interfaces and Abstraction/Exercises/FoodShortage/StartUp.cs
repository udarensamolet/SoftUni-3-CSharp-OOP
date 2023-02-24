using FoodShortage.Models;
using FootShortage.Models;

namespace FootShortage
{
    public class StartUp
    {
        static void Main()
        {
            var citizens = new List<Citizen>();
            var rebels = new List<Rebel>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];
                    Citizen citizen = new (name, age, id, birthdate);    
                    citizens.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    Rebel rebel = new (name, age, group);
                    rebels.Add(rebel);
                }
            }

            int totalAmountPurchasedFood = 0;
            while(true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }


                var targetCitizen = citizens.FirstOrDefault(c => c.Name == input);
                if (targetCitizen!= null)
                {
                    targetCitizen.BuyFood();
                    totalAmountPurchasedFood += 10;
                }

                var targetRebel = rebels.FirstOrDefault(r => r.Name == input);
                if (targetRebel != null)
                {
                    targetRebel.BuyFood();
                    totalAmountPurchasedFood += 5;
                }
            }
            Console.WriteLine(totalAmountPurchasedFood);
        }
    }
}