﻿namespace Animals
{
    public class Kitten : Cat
    {
        private const string Gender = "female";
        public Kitten(string name, int age, string gender)
            : base(name, age, Gender) 
        {
        }

        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
