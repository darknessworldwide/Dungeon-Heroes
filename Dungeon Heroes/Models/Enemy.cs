using Dungeon_Heroes.Skills;
using System.Security.Policy;
using System.Xml.Linq;

namespace Dungeon_Heroes.Models
{
    internal class Enemy
    {
        internal string Type { get; }
        internal double Health { get; set; }
        internal double Damage { get; set; }

        internal Skill[] Skills { get; }

        internal Enemy(string type, double health, double damage)
        {
            Type = type;
            Health = health;
            Damage = damage;

            Skills = new Skill[]
            {
                new SteelShield("Стальной щит", 0, 0, 1.3),
                new Healing("Исцеление", 0, 0, 20),
                new Rage("Ярость", 0, 0, 1.3),
            };
        }

        public override string ToString() { return $"{Type} HP[{Health}] DMG[{Damage}]"; }
    }
}
