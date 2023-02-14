using Raiding.Factory;
using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            List<Hero> heroes = new List<Hero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                Hero hero = HeroFactory.GetHero(heroType, heroName);

                if (hero != null)
                {
                    heroes.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPowerHeroes = 0;
            foreach(var hero in heroes) 
            {
                totalPowerHeroes += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (totalPowerHeroes >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}