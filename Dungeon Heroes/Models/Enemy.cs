using Dungeon_Heroes.Skills;

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
                new SteelShield("Стальной щит", 0),
                new Healing("Исцеление", 0),
                new Rage("Ярость", 0),
            };
        }
    }
}
