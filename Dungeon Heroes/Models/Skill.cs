using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Models
{
    internal class Skill
    {
        internal string Name { get; }
        internal int Price { get; }
        Hero hero;

        internal Skill(string name, int price, Hero hero)
        {
            Name = name;
            Price = price;
            this.hero = hero;
        }

        public override string ToString() { return $"{Name}"; }
    }
}
