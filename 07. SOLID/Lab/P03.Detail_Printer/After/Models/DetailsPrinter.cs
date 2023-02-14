using System;
using System.Collections.Generic;

namespace P03.Detail_Printer.After.Models
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in employees)
            {
                employee.PrintDetails();
            }
        }
    }
}
