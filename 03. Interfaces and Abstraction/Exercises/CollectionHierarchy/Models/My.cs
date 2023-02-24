using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public abstract class My : IAddToStart, IRemoveAtStart
    {
        public abstract int AddToStartMethod(string item);

        public abstract string RemoveAtStartMethod();

    }
}
