using Dungeon_Heroes.ItemInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Models
{
    internal class Weapon : IItem
    {
        public string Name { get; }
        internal double Damage { get; set; }
        internal double Mana { get; }
        public int Price { get; }

        internal Weapon(string name, double damage, double mana, int price)
        {
            Name = name;
            Damage = damage;
            Mana = mana;
            Price = price;
        }

        public override string ToString() { return $"{Name} DMG[{Damage}] MP[{Mana}]"; }
    }
}
