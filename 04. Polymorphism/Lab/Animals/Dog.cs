using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood)
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.Append(base.ExplainSelf());
            sb.Append("BARK");
            return sb.ToString();   
        }
    }
}
