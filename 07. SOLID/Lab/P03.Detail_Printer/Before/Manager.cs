using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Before
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }
    }
}
