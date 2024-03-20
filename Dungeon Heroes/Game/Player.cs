using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;

namespace Dungeon_Heroes.Game
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

                Hero hero = new Hero(name, 100, 100, 10000, new Armor("Накидка", 1, 50), new Weapon("Зубочистка", 1, 0, 0), new List<Skill> { shop.Skills[option - 1] }); // отредачить
                shop.Skills.RemoveAt(option - 1);
                return hero;
            }
        }
    }
}
