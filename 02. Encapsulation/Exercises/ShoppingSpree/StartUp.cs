using System.Text;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] inputPerson = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < inputPerson.Length; i++)
            {
                string[] tokensPerson = inputPerson[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokensPerson[0];
                double money = double.Parse(tokensPerson[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }

            string[] inputProduct = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < inputPerson.Length; i++)
            {
                string[] tokensProduct = inputProduct[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokensProduct[0];
                double money = double.Parse(tokensProduct[1]);

                Product product = new Product(name, money);
                products.Add(product);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = tokens[0];
                string productName = tokens[1];

                Person targetPerson = people.FirstOrDefault(p => p.Name == personName);
                Product targetProduct = products.FirstOrDefault(p => p.Name == productName);
                Console.WriteLine(targetPerson.AddToBag(targetProduct));              
            }
            foreach (var person in people)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{person.Name} - ");
                string bag = "Nothing bought";
                if (person.Bag.Any())
                {
                    bag = string.Join(", ", person.Bag.Select(x => x.Name));
                }
                sb.Append(bag);
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
