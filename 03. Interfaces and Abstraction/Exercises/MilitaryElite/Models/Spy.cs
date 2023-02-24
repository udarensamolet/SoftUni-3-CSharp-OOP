using MilitaryElite.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : ISpy
    {
        public Spy(int codeNumber, int id, string firstName, string lastName)
        {
            CodeNumber = codeNumber;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int CodeNumber { get; private set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {LastName} Id: {Id}");
            sb.AppendLine($"Code Number: {CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
