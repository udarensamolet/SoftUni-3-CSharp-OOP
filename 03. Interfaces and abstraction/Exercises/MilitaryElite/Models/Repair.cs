using MilitaryElite.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked) 
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }
        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Part Name: {PartName} Hours Worked: {HoursWorked}");
            return sb.ToString().TrimEnd();
        }
    }
}
