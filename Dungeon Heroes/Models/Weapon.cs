using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Models
{
    internal class Weapon
    {
        internal string Name { get; }
        internal double Damage { get; }
        internal double Mana { get; }
        internal int Price { get; }

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
