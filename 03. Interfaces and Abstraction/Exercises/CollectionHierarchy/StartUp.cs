using CollectionHierarchy.Collections;
using System.Text;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            AddCollection addCollection = new AddCollection();  
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            var sb1 = new StringBuilder();
            for (int i = 0; i < input.Count; i++)
            {
                sb1.Append($"{addCollection.AddToEndMethod(input[i])} ");
            }
            Console.WriteLine(sb1.ToString().TrimEnd());

            var sb2 = new StringBuilder();
            for (int i = 0; i < input.Count; i++)
            {
                sb2.Append($"{addRemoveCollection.AddToStartMethod(input[i])} ");
            }
            Console.WriteLine(sb2.ToString().TrimEnd());

            var sb3 = new StringBuilder();
            for (int i = 0; i < input.Count; i++)
            {
                sb3.Append($"{myList.AddToStartMethod(input[i])} ");
            }
            Console.WriteLine(sb3.ToString().TrimEnd());


            int n = int.Parse(Console.ReadLine());

            var sb4 = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb4.Append($"{addRemoveCollection.RemoveAtEndMethod()} ");
            }
            Console.WriteLine(sb4.ToString().TrimEnd());

            var sb5 = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb5.Append($"{myList.RemoveAtStartMethod()} ");
            }
            Console.WriteLine(sb5.ToString().TrimEnd());
        }
    }
}