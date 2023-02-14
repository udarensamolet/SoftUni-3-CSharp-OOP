namespace Raiding.Models
{
    public class Paladin : Hero
    {
        private const int Power = 100;
        public Paladin(string name)
            : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
