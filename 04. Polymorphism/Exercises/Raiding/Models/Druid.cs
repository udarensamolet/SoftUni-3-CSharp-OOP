namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int Power = 80;
        public Druid(string name)
            : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
