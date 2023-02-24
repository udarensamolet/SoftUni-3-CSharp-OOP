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

        public string AnalyzeAccessModifiers(string classToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields =
                classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classNonPublicMethod.Where(n => n.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classPublicMethod.Where(n => n.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            var baseType = classType.BaseType.Name;
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(className);
            sb.AppendLine(baseType);
            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();
            foreach(var method in methodsInfo.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in methodsInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnParameter}");
            }
            return sb.ToString().Trim();

        }
    }
}
