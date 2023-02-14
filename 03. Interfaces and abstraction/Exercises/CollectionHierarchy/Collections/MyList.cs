using CollectionHierarchy.Models;
using System.Collections.Generic;

namespace CollectionHierarchy.Collections
{
    public class MyList : My
    {
        private List<string> list;

        public MyList()
        {
            list = new List<string>();
        }

        public IReadOnlyCollection<string> List => list.AsReadOnly();

        public int Used => list.Count;

        public override int AddToStartMethod(string item)
        {
            list.Insert(0, item);
            return 0;
        }

        public override string RemoveAtStartMethod()
        {
            string item = list[0];
            list.RemoveAt(0);
            return item;
        }
    }
}
