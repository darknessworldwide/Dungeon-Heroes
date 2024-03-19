using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Skills
{
    internal class Healing : Skill
    {
        Hero hero;

        internal Healing(string name, int price, Hero hero) : base(name, price, hero) { }

        internal override void UseSkill()
        {
            int value = 20;
            hero.Health += value;
            Console.WriteLine($"Восстановлено {value}HP");
        }
    }
}
