using System;
using System.Collections.Generic;

namespace Dungeon_Heroes
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
        internal List<Skill> AvailableSkills { get; set; }

        internal Hero(string name, Skill skill)
        {
            Name = name;
            Health = 100;
            Mana = 40;
            Money = 10000;
            Armor = new Armor("Накидка", 1, 50);
            Weapon = new Weapon("Зубочистка", 10, 0);
            Skills = new List<Skill>() { skill };
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

        internal bool SkillSelection()
        {
            AvailableSkills = new List<Skill>();

            foreach (Skill skill in Skills)
            {
                if (Mana >= skill.Mana)
                {
                    AvailableSkills.Add(skill);
                }
            }

            if (AvailableSkills.Count > 0)
            {
                Console.WriteLine("Выберите умение:");
                for (int i = 0; i < AvailableSkills.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {AvailableSkills[i]}");
                }
                return true;
            }
            return false;
        }

        public override string ToString() { return $"{Name} HP[{Health}/100] MP[{Mana}/100] {Money}$\nДоспехи: {Armor}\nОружие: {Weapon}\nУмения:\n{GetMySkills()}"; }
    }
}
