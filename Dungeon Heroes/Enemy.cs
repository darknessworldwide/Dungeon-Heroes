namespace Dungeon_Heroes
{
    internal class Enemy
    {
        internal string Type { get; }
        internal double Health { get; set; }
        internal double Defense { get; set; }
        internal double Damage { get; set; }
        internal Skill[] Skills { get; }

        internal Enemy(string type, double health, double defence, double damage)
        {
            Type = type;
            Health = health;
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
