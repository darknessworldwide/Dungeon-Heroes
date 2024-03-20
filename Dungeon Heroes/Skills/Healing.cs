using Dungeon_Heroes.Models;
using System;

namespace Dungeon_Heroes.Skills
{
    internal class Healing : Skill
    {
        internal Healing(string name, int price) : base(name, price) { }

        internal override void UseSkill(Hero hero)
        {
            int healthValue = 20;
            int mana = 10;
            hero.Health += healthValue;
            hero.Mana -= mana;
            Console.WriteLine($"+{healthValue}HP -{mana}MP");
        }

        internal override void StopSkill(Hero hero) { }

        internal override void UseSkill(Enemy enemy)
        {
            int healthValue = 10;
            enemy.Health += healthValue;
        }

        internal override void StopSkill(Enemy enemy) { }
    }
}
