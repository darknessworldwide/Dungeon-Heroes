namespace Dungeon_Heroes
{
    internal class Weapon : IItem
    {
        public string Name { get; }
        internal int Damage { get; set; }
        public int Price { get; }

        internal Weapon(string name, int damage, int price)
        {
            Name = name;
            Damage = damage;
            Price = price;
        }

        public override string ToString() { return $"{Name} DMG[{Damage}]"; }
    }
}
