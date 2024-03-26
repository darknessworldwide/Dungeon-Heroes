namespace Dungeon_Heroes
{
    internal class Enemy
    {
        internal string Type { get; }
        internal int Health { get; set; }
        internal double Defense { get; set; }
        internal int Damage { get; set; }
        internal Skill[] Skills { get; }
        internal int defaultHealth { get; }

        internal Enemy(string type, int health, double defence, int damage)
        {
            Type = type;
            Health = health;
            defaultHealth = health;
            Defense = defence;
            Damage = damage;

            Skills = new Skill[]
            {
                new SteelShield("Стальной щит", 1.3),
                new Healing("Исцеление", 20),
                new Rage("Ярость", 1.3),
            };
        }

        public override string ToString() { return $"{Type} HP[{Health}] DEF[{Defense}] DMG[{Damage}]"; }
    }
}
