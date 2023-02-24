namespace ValidPerson
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName 
        {
            get => _firstName;
            private set
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentNullException("The first name cannot be empty!");
                }
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The first name cannot be empty!");
                }
                _lastName = value;
            }
        }
        public int Age
        {
            get => _age;
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age must be in the interval [0...120]!");
                }
                _age = value;
            }
        }
    }
}
