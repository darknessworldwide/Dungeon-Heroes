using System;

namespace Dungeon_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Player player = new Player();
            Hero hero = player.CreateHero(shop);
            Console.WriteLine(hero);
            Hub hub = new Hub(shop, hero);
            hub.VisitTheHub();
        }
    }
}
