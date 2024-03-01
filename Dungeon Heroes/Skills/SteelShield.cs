using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Skills
{
    internal class SteelShield : Skill
    {
        Hero hero;
        double defaultValue;

        internal SteelShield(string name, int price, Hero hero) : base(name, price, hero) { }

        internal void UseSkill()
        {
            defaultValue = hero.Armor.Defense;

            double buff = 1.2;
            hero.Armor.Defense *= buff;
            Console.WriteLine($"Защита увеличена на {(buff - 1) * 100}%");
        }

        internal void StopSkill()
        {
            hero.Armor.Defense = defaultValue;
        }
    }
}
