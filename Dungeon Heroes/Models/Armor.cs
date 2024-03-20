using Dungeon_Heroes.ItemInterfaces;

namespace Dungeon_Heroes.Models
{
    internal class Armor : IItem
    {
        public string Name { get; }
        internal double Defense { get; set; }
        public int Price { get; }

        internal Armor(string name, double defense, int price)
        {
            Name = name;
            Defense = defense;
            Price = price;
        }

        public override string ToString() { return $"{Name} DEF[{Defense}]"; }
    }
}
