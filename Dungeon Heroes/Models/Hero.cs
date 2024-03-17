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

        string GetMySkills()
        {
            string text = "";
            for (int i = 0; i < Skills.Count; i++)
            {
                text += $"{i + 1}. {Skills[i]}\n";
            }
            return text;
        }

        public override string ToString() { return $"{Name} HP[{Health}/100] MP[{Mana}/100] {Money}$\nДоспехи: {Armor}\nОружие: {Weapon}\nУмения:\n{GetMySkills()}"; }
    }
}
