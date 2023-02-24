using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : ICommando
    {
        private List<Mission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            missions = new List<Mission>();
            Corps = corps;
        }

        public IReadOnlyCollection<IMission> Missions => missions.AsReadOnly();

        public Corps Corps { get; private set; }

        public decimal Salary { get; private set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions: ");
            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
