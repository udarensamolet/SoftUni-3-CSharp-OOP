namespace ShoppingSpree
{
    public class Product
    {
        private string _name;
        private double _cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
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

        public double Cost
        {
            get => _cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Money cannot be negative");
                }
                _cost = value;
            }
        }
    }
}
