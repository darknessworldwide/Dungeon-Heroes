using Dungeon_Heroes.Models;
using Dungeon_Heroes.Skills;
using System;
using System.Collections.Generic;

namespace Dungeon_Heroes.Game
{
    internal class Shop
    {
        internal List<Armor> Armors { get; set; }
        internal List<Weapon> Weapons { get; set; }
        internal List<Skill> Skills { get; set; }
        internal List<DungeonLevel> DungeonLevels { get; }

        internal Shop() // отредачить
        {
            Armors = new List<Armor>
            {
                new Armor("Простая кожаная броня", 1.1, 30),
                new Armor("Рваная кольчуга", 1.4, 60),
                new Armor("Кольчуга с кожаными вставками", 1.5, 70),
                new Armor("Легкий пластинчатый доспех", 1.6, 80),
                new Armor("Стальной корсет", 1.7, 90),
                new Armor("Усиленная кольчуга", 1.8, 100),
                new Armor("Бригантина", 1.9, 110),
                new Armor("Тяжелый пластинчатый доспех", 2.2, 140),
                new Armor("Бесшовная броня", 2.3, 150),
                new Armor("Кольчуга с пластинами", 2.4, 160),
                new Armor("Поврежденные латы", 2.6, 180),
                new Armor("Латы", 2.7, 190),
                new Armor("Доспех великого хранителя", 3.0, 250),
            };

            Weapons = new List<Weapon>
            {
                new Weapon("Старый кинжал", 25, 50),
                new Weapon("Ржавый клинок", 30, 60),
                new Weapon("Стальной меч", 35, 70),
                new Weapon("Копье", 40, 80),
                new Weapon("Железный боевой топор", 45, 90),
                new Weapon("Двуручный меч", 65, 120),
                new Weapon("Рапира", 70, 130),
                new Weapon("Клеймор", 75, 140),
                new Weapon("Палица", 80, 150),
                new Weapon("Алебарда", 90, 160),
                new Weapon("Пика", 95, 170),
                new Weapon("Экскалибур", 100, 180),
                new Weapon("Клинок тьмы", 110, 200),
                new Weapon("Палаш Погибели", 120, 210),
                new Weapon("Молот бога", 130, 250),
            };

            Skills = new List<Skill>
            {
                new SteelShield("Стальной щит", 1, 30, 1.5),
                new Healing("Исцеление", 1, 20, 30),
                new Rage("Ярость", 1, 30, 1.5),
            };

            DungeonLevels = new List<DungeonLevel>
            {
                new DungeonLevel("Лёгкий", 5, 9, 50, 101, 10, 21, 5, 10, 0.2),
                new DungeonLevel("Средний", 8, 13, 100, 151, 20, 31, 10, 15, 0.15),
                new DungeonLevel("Сложный", 12, 16, 150, 201, 30, 41, 15, 20, 0.1),
            };
        }

        internal int GetOption(int len)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > len + 1)
            {
                Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
            }
            return option;
        }

        private void ShowList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i]}");
            }
            Console.WriteLine($"{list.Count + 1}. Назад");
        }

        internal void ShowArmors()
        {
            ShowList(Armors);
        }

        internal void ShowWeapons()
        {
            ShowList(Weapons);
        }

        internal void ShowSkills()
        {
            ShowList(Skills);
        }

        internal void ShowDungeonLevels()
        {
            ShowList(DungeonLevels);
        }
    }
}
