using Dungeon_Heroes.ItemInterfaces;

namespace Dungeon_Heroes.Models
{
    internal class Weapon : IItem
    {
        public string Name { get; }
        internal double Damage { get; set; }
        public int Price { get; }

        internal Weapon(string name, double damage, int price)
        {
            Name = name;
            Damage = damage;
            Price = price;
        }

        public override string ToString() { return $"{Name} DMG[{Damage}]"; }
    }
}
