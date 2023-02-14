using MilitaryElite.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : ILieutenantGeneral
    {
        private List<Private> _soldiers;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            _soldiers = new List<Private>();
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal Salary { get; private set; }

        public IReadOnlyCollection<IPrivate> Soldiers => _soldiers.AsReadOnly();

        public void AddSoldiers(Private soldier)
        {
            _soldiers.Add(soldier);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Privates:");
            foreach(var privatee in Soldiers)
            {
                sb.AppendLine($"  {privatee.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
