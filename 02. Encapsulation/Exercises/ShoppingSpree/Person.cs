using System.ComponentModel.DataAnnotations;

namespace ShoppingSpree
{
    public class Person
    {
        private string _name;
        private double _money;
        private List<Product> _bag;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            _bag = new List<Product>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                _name = value;
            }
        }

        public double Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Money can't be negative");
                }
                _money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => _bag.AsReadOnly();

        public string AddToBag(Product product)
        {
            if(Money >= product.Cost)
            {
                _bag.Add(product);
                Money -= product.Cost;
                return $"{Name} bought {product.Name}";
            }
            else
            {
                return $"{Name} cannot afford {product.Name}";
            }
        }
    }
}
