using System.Reflection;

namespace AuthorProblem.Models
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(AuthorProblem.StartUp);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
