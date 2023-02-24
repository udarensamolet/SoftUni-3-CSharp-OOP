using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : IEngineer
    {
        private List<Repair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            repairs = new List<Repair>();
            Corps = corps;
        }


        public IReadOnlyCollection<IRepair> Repairs => repairs.AsReadOnly();

        public Corps Corps { get; private set; }

        public decimal Salary { get; private set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public void AddRepair(Repair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Repairs: ");
            foreach (var repair in repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
