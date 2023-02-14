using System;
using P03.Detail_Printer.After.Contracts;

namespace P03.Detail_Printer.After.Models
{
    public class Employee : IWorker, IPrintable
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void PrintDetails()
        {
            Console.WriteLine(Name);
        }
    }
}
