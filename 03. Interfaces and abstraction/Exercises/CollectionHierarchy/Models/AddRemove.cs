using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public abstract class AddRemove : IAddToStart, IRemoveAtEnd
    {
        public abstract int AddToStartMethod(string item);

        public abstract string RemoveAtEndMethod();
        
    }
}
