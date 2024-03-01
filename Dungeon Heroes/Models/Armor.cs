using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Models
{
    internal class Armor
    {
        internal string Name { get; }
        internal double Defense { get; set; }
        internal int Price { get; }

        internal Armor(string name, double defense, int price)
        {
            Name = name;
            Defense = defense;
            Price = price;
        }

        public override string ToString() { return $"{Name} DEF[{Defense}]"; }
    }
}
