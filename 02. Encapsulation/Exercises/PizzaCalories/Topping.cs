namespace PizzaCalories
{
    public class Topping
    {
        private string _name;
        private double _weight; 

        public Topping(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get => _name;
            private set
            {

                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                _name = value;
            }
        }

        public double Weight
        {
            get => _weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentOutOfRangeException($"{Name} weight should be in the range [1..50].");
                }
                _weight = value;
            }
        }

        public double GetCalories()
        {
            double calories = 2;
            double modifierName = 0;
            switch (Name.ToLower())
            {
                case "meat":
                    modifierName = 1.2;
                    break;
                case "veggies":
                    modifierName = 0.8;
                    break;
                case "cheese":
                    modifierName = 1.1;
                    break;
                case "sauce":
                    modifierName = 1.1;
                    break;
            }
            return calories = calories * Weight * modifierName;
        }
    }
}
