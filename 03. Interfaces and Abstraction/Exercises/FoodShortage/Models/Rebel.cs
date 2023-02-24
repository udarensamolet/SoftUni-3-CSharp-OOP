﻿using FoodShortage.Interfaces;
using FootShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Rebel : IPerson, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
