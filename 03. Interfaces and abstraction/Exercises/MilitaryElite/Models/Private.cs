using MilitaryElite.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class Private : IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
