namespace PizzaCalories
{
    public class Pizza
    {
        private string _name;
        private Dough _dough;
        private List<Topping> _toppings;
        private int _toppingsNumber;
        private double _totalCalories;

        private Pizza(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }
                _name = value;
            }
        }    
        

    }
}
