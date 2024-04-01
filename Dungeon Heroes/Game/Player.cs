using System;
using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class Player
    {
        internal List<Skill> StartSkills { get; }

        internal Player()
        {
            StartSkills = new List<Skill>
            {
                new Healing("Луч Исцеления", 20, 70, 30),
                new SteelShield("Аура Защиты", 30, 80, 1.8),
                new Rage("Гнев Титана", 30, 100, 2.0),
            };
        }

        internal Hero CreateAHero()
        {
            while (true)
            {
                Console.Write("Введите имя для вашего героя: ");
                string name = Console.ReadLine();

                Console.WriteLine("\nВыберите начальное умение:");
                ShowStartSkills();

                int len = StartSkills.Count;
                int option = GetOption(len);
                if (option == 0) continue;

                Skill skill = StartSkills[option - 1];
                Hero hero = new Hero(name, skill);

                StartSkills.Remove(skill);
                Console.Clear();

                return hero;
            }
        }

        internal int GetOption(int len)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > len)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
                Console.ResetColor();
            }
            return option;
        }

        private void ShowStartSkills()
        {
            for (int i = 0; i < StartSkills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {StartSkills[i]}");
            }
            Console.WriteLine("0. Назад");
        }
    }
}
