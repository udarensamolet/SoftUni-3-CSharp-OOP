using System;
using ValidationAttributes.Models;
using ValidationAttributes.Models.Attributes;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main()
        {
            var person1 = new Person(null, 33);
            var person2 = new Person("Udaren Samolet", -1);
            var person3 = new Person("Udaren Samolet", 33);

            bool isValidEntity1 = Validator.IsValid(person1);
            bool isValidEntity2 = Validator.IsValid(person2);
            bool isValidEntity3 = Validator.IsValid(person3);

            Console.WriteLine(isValidEntity1);
            Console.WriteLine(isValidEntity2);
            Console.WriteLine(isValidEntity3);
        }
    }
}
