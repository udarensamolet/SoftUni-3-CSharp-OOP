using System;
using System.Collections.Generic;
using P03.Detail_Printer.After.Contracts;
using P03.Detail_Printer.Before;

namespace P03.Detail_Printer.After.Models
{
    public class Manager : IWorker, IPrintable
    {
        private ICollection<string> documents;
        public Manager(string name, ICollection<string> documents)
        {
            this.documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; private set; }

        public string Name { get; private set; }

        public void PrintDetails()
        {
            Console.WriteLine(Name);
            Console.WriteLine(string.Join(Environment.NewLine, Documents));
        }
    }
}
