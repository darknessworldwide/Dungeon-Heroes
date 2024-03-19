using Dungeon_Heroes.Models;
using Dungeon_Heroes.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Game
{
    internal class Hub
    {
        Hero hero;
        internal List<Armor> Armors { get; set; }
        internal List<Weapon> Weapons { get; set; }
        internal List<Skill> Skills { get; set; }
        internal List<DungeonLevel> DungeonLevels { get; }

        internal Hub()
        {
            Armors = new List<Armor> // отредачить
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
                new Weapon("Огненная сфера", 1, 1, 1),
                new Weapon("Веер пламени", 1, 1, 1),
                new Weapon("Огненный кнут", 1, 1, 1),
                new Weapon("Мощный поджог", 1, 1, 1),
                new Weapon("Разрывной огненный шар", 1, 1, 1),

                new Weapon("Громовое копьё", 1, 1, 1),
                new Weapon("Божественные столпы света", 1, 1, 1),
                new Weapon("Клинок тёмной Луны", 1, 1, 1),
                new Weapon("Громовая стрела", 1, 1, 1),
                new Weapon("Коса охоты на жизнь", 1, 1, 1),

                new Weapon("Стрела души", 1, 1, 1),
                new Weapon("Град кристаллов", 1, 1, 1),
                new Weapon("Кристаллическое копьё души", 1, 1, 1),
                new Weapon("Двуручный меч душ", 1, 1, 1),
                new Weapon("Кристаллический наводящийся сгусток души", 1, 1, 1),
            };

            Skills = new List<Skill>
            {
                new SteelShield("Стальной щит", 1, hero),
                new Healing("Исцеление", 1, hero),
                new Rage("Ярость", 1, hero),
            };

            DungeonLevels = new List<DungeonLevel>
            {
                new DungeonLevel("Лёгкий", 5, 8, 50, 100, 10, 20, 0.2),
                new DungeonLevel("Средний", 8, 12, 100, 150, 20, 30, 0.15),
                new DungeonLevel("Сложный", 12, 15, 150, 200, 30, 40, 0.1),
            };
        }

        internal void SetHero(Hero hero)
        {
            this.hero = hero;
        }

        void ShowList<T>(List<T> list)
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
            for (int i = 0; i < DungeonLevels.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {DungeonLevels[i].Name}");
            }
            Console.WriteLine($"{DungeonLevels.Count + 1}. Назад");
        }
    }
}
