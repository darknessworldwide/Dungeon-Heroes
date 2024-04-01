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

                Console.WriteLine();

                Console.WriteLine("Выберите начальное умение:");
                shop.ShowStartSkills();

                int len = shop.StartSkills.Length;
                int option = shop.GetOption(len);
                if (option == 0) continue;

                Skill skill = shop.StartSkills[option - 1];
                Hero hero = new Hero(name, skill);
                shop.Skills.Remove(skill);

                return hero;
            }
        }
    }
}
