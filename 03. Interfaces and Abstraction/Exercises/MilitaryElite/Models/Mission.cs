using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName {get; private set; }

        public MissionState State { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Code Name: {CodeName} State: {State}");
            return sb.ToString().TrimEnd();
        }
    }
}
