using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public abstract class Add : IAddToEnd
    {
        public abstract int AddToEndMethod(string item);
    }
}
