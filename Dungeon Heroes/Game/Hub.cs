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
        internal List<Weapon> Weapons { get; set; }
        internal List<Skill> Skills { get; set; }

        internal Hub(Hero hero)
        {
            this.hero = hero;

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
                new SteelShield("SteelShield", 1, hero),
            };
        }

        internal void ShowWeapons()
        {
            for (int i = 0; i < Weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Weapons[i]}");
            }
        }

        internal void ShowSkills()
        {
            for (int i = 0; i < Skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Skills[i]}");
            }
        }

        //internal void BuySkills()
        //{
        //    Console.WriteLine("Выберите новое умение для покупки:");
        //    DisplaySkills();

        //    int option;

        //}

        internal int GetOption(int len)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > len) //option > len + 1
            {
                Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
            }
            return option; 
        }
    }
}
