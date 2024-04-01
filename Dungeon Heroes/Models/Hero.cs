using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class Hero
    {
        internal string Name { get; set; }
        internal int Health { get; set; }
        internal int Mana { get; set; }
        internal int Money { get; set; }
        internal Armor Armor { get; set; }
        internal Weapon Weapon { get; set; }
        internal List<Skill> Skills { get; set; }
        internal List<Skill> AvailableSkills { get; set; }

        internal Hero(string name, Skill skill)
        {
            Name = name;
            Health = 100;
            Mana = 100;
            Money = 30000;
            Armor = new Armor("Накидка", 1, 0);
            Weapon = new Weapon("Дубинка", 15, 0);
            Skills = new List<Skill>() { skill };
        }

        internal bool SkillsAvailable()
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
                return true;
            }
            return false;
        }

        internal string GetMySkills(List<Skill> skills)
        {
            string text = "";
            for (int i = 0; i < skills.Count; i++)
            {
                text += $"{i + 1}. {skills[i]}\n";
            }
            return text;
        }

        public override string ToString() { return $"{Name} HP[{Health}/100] MP[{Mana}/100] {Money} монет\nДоспехи: {Armor}\nОружие: {Weapon}\nУмения:\n{GetMySkills(Skills)}"; }
    }
}
