namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (base.Count == 0)
            {
                return true;
            }
            return false;
        }


        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
            {
                this.Push(element);
            }
            return this;
        }
    }
}
