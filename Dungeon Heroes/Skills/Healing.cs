using Dungeon_Heroes.Models;
using System;

namespace Dungeon_Heroes.Skills
{
    internal class Healing : Skill
    {
        private double healthPoints;

        internal Healing(string name, int price, double mana, double healthPoints) : base(name, price, mana)
        {
            this.healthPoints = healthPoints;
        }

        internal override void UseSkill(Hero hero)
        {
            hero.Health += healthPoints;
            hero.Mana -= Mana;
            Console.WriteLine($"+{healthPoints}HP -{Mana}MP");
        }

        internal override void UseSkill(Enemy enemy)
        {
            enemy.Health += healthPoints;
        }
    }
}
