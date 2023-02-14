using System;
using System.Text;

namespace Animals
{
    public  class Animal
    {
        private int age;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender { get; set; }

        public virtual string ProduceSound() 
        {
            return $"";
        }
    }
}
