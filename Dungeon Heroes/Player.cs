using System;

namespace Dungeon_Heroes
{
    internal class Player
    {
        internal Hero CreateHero(Shop shop)
        {
            while (true)
            {
                Console.Write("Введите имя вашего героя: ");
                string name = Console.ReadLine();

                Console.WriteLine("Выберите начальное умение:");
                shop.ShowSkills();

                int option = shop.GetOption(shop.Skills.Count);
                if (option == shop.Skills.Count + 1) continue;

                Hero hero = new Hero(name, shop.Skills[option - 1]);
                shop.Skills.RemoveAt(option - 1);
                return hero;
            }
        }
    }
}
