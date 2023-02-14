using CollectionHierarchy.Models;

namespace CollectionHierarchy.Collections
{
    public class AddRemoveCollection : AddRemove
    {
        private List<string> list;

        public AddRemoveCollection()
        {
            list = new List<string>();
        }

        public IReadOnlyCollection<string> List => list.AsReadOnly();

        public override int AddToStartMethod(string item)
        {
            list.Insert(0, item);
            return 0;
        }

        public override string RemoveAtEndMethod()
        {
            string item = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return item;
        }
    }
}
