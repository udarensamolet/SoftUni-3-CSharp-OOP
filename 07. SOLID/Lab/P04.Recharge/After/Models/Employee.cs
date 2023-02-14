using P04.Recharge.After;

namespace P04.Recharge.After.Models
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("Sleep");
        }

    }
}
