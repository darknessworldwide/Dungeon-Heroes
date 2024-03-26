using System;
using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class Shop
    {
        internal List<Armor> Armors { get; set; }
        internal List<Weapon> Weapons { get; set; }
        internal List<Skill> Skills { get; set; }
        internal DungeonLevel[] DungeonLevels { get; }

        internal Shop()
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
                new SteelShield("Стальной щит", 30, 1, 1.5),
                new Healing("Исцеление", 20, 1, 30),
                new Rage("Ярость", 30, 1, 1.5),
            };

            DungeonLevels = new DungeonLevel[]
            {
                new DungeonLevel("Легкий", 5, 8, 50, 100, 10, 20, 0.5, 1, 0.5, 0.3, 0.2),
                new DungeonLevel("Средний", 8, 12, 100, 150, 20, 30, 1, 1.5, 0.6, 0.2, 0.2),
                new DungeonLevel("Сложный", 12, 16, 150, 200, 30, 40, 1.5, 2, 0.7, 0.1, 0.1),
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
            for (int i = 0; i < DungeonLevels.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {DungeonLevels[i]}");
            }
            Console.WriteLine($"{DungeonLevels.Length + 1}. Назад");
        }
    }
}
