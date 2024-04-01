namespace Dungeon_Heroes
{
    internal class Enemy
    {
        internal string Type { get; }
        internal int Health { get; set; }
        internal int DefaultHealth { get; }
        internal double Defense { get; set; }
        internal int Damage { get; set; }
        internal Skill[] Skills { get; }

        internal Enemy(string type, int health, double defence, int damage)
        {
            Type = type;
            Health = health;
            DefaultHealth = health;
            Defense = defence;
            Damage = damage;

            Skills = new Skill[]
            {
                new SteelShield(),
                new Healing(),
                new Rage(),
            };
        }

        public override string ToString() { return $"{Type} HP[{Health}/{DefaultHealth}] DEF[{Defense}] DMG[{Damage}]"; }
    }
}
