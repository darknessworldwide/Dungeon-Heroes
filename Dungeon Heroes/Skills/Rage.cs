using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Skills
{
    internal class Rage : Skill
    {
        Hero hero;
        double defaultValue;

        internal Rage(string name, int price, Hero hero) : base(name, price, hero) { }

        internal override void UseSkill()
        {
            defaultValue = hero.Weapon.Damage;

            double buff = 1.2;
            hero.Weapon.Damage *= buff;
            Console.WriteLine($"Урон увеличен на {(buff - 1) * 100}%");
        }

        internal void StopSkill()
        {
            hero.Weapon.Damage = defaultValue;
        }
    }
}
