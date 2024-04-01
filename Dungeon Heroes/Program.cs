using System;

namespace Dungeon_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Hero hero = player.CreateAHero();

            Store store = new Store();
            store.Skills.InsertRange(0, player.StartSkills);

            Hub hub = new Hub(player, store, hero);
            hub.OpenGameMenu();
        }
    }
}
