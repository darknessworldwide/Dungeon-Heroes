using Dungeon_Heroes.ItemInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Models
{
    internal class Skill : IItem
    {
        public string Name { get; }
        public int Price { get; }
        Hero hero;

        internal Skill(string name, int price, Hero hero)
        {
            Name = name;
            Price = price;
            this.hero = hero;
        }

        internal virtual void UseSkill() { }

        public override string ToString() { return $"{Name}"; }
    }
}
