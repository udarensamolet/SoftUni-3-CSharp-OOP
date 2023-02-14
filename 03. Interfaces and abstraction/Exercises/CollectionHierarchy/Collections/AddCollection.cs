using CollectionHierarchy.Models;
using System.Collections;

namespace CollectionHierarchy.Collections
{
    public class AddCollection : Add
    {
        private List<string> list;

        public AddCollection()
        {
            list = new List<string>();
        }

        public IReadOnlyCollection<string> List => list.AsReadOnly();

        public override int AddToEndMethod(string item)
        {
            list.Add(item);
            return list.Count - 1;
        }
    }
}
