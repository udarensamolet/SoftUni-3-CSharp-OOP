using Raiding.Models;

namespace Raiding.Factory
{
    public class HeroFactory
    {
        public static Hero GetHero(string heroType, string heroName)
        {
            Hero? hero = null;

            if(heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }

            return hero;
        }
    }
}
