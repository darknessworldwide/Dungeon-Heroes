using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Models
{
    internal class Hero
    {
        internal string Name { get; set; }
        internal double Health { get; set; }
        internal double Mana { get; set; }
        internal int Money { get; set; }
        internal Armor Armor { get; set; }
        internal Weapon Weapon { get; set; }
        internal List<Skill> Skills { get; set; }

        internal Hero(string name, double health, double mana, int money, Armor armor, Weapon weapon, List<Skill> skills)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Money = money;
            Armor = armor;
            Weapon = weapon;
            Skills = skills;
        }

        internal string GetMySkills()
        {
            string text = "";
            for (int i = 0; i < Skills.Count; i++)
            {
                text += $"{i + 1}. {Skills[i]}\n";
            }
            return text;
        }

        internal void Attack(Enemy enemy)
        {
            Console.WriteLine($"Выберите ваше действие:\n1. Базовая атака\n2. Использовать умение");

            switch(Console.ReadLine())
            {
                case "1":
                    BasicAttack(enemy);
                    break;
                case "2":
                    UseSkill();
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1 или 2.");
                    break;
            }
        }

        protected void BasicAttack(Enemy enemy)
        {
            double damage = Weapon.Damage;
            enemy.Health -= damage;
            Console.WriteLine($"{Name} наносит урон {damage} врагу {enemy.Type}. Здоровье врага: {enemy.Health}");
        }

        protected void UseSkill()
        {
            Console.WriteLine($"Выберите умение из списка:\n{GetMySkills()}");

            int choice = int.Parse(Console.ReadLine());
            if (choice > 0 && choice <= Skills.Count)
            {
                Skills[choice - 1].UseSkill();
            }
            else
            {
                Console.WriteLine("Неправильный выбор.");
            }
        }

        public override string ToString() { return $"{Name} HP[{Health}/100] MP[{Mana}/100] {Money}$\nДоспехи: {Armor}\nОружие: {Weapon}\nУмения:\n{GetMySkills()}"; }
    }
}
