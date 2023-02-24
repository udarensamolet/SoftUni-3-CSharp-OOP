using System.Reflection;
using System.Text;

namespace Stealer.Models
{
    public class Spy
    {
        public Spy()
        {
        }

        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            List<FieldInfo> fields = new List<FieldInfo>();
            var sb = new StringBuilder();

            Type type = Type.GetType(classToInvestigate);

            for (int i = 0; i < fieldsToInvestigate.Length; i++)
            {
                FieldInfo field = type.GetField(fieldsToInvestigate[i], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                fields.Add(field);
            }

            object classInstance = Activator.CreateInstance(type);
            sb.AppendLine($"Class under investigation: {classToInvestigate}");


            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} - {field.GetValue(classInstance)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
