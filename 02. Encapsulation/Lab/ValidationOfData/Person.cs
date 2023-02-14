namespace PersonsInfo
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private decimal _salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException($"First name cannot contain fewer than 3 symbols!");
                }
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException($"Last name cannot contain fewer than 3 symbols!");
                }
                _lastName = value;
            }
        }
        public int Age {
            get => _age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Age cannot be zero or a negative integer!");
                }
            }
        }
        public decimal Salary
        {
            get => _salary;
            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                percentage /= 2;
            }
            Salary += (percentage / 100 * Salary);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
