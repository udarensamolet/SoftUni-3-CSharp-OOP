namespace Composite
{
    public abstract class GiftBase
    {
        protected string _name;
        protected int _price;

        public GiftBase(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public abstract int CalculateTotalPrice();
    }
}
