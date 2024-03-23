using System;

namespace Dungeon_Heroes
{
    internal class Healing : Skill
    {
        private int healthPoints;

        internal Healing(string name, int mana, int price, int healthPoints) : base(name, mana, price)
        {
            this.healthPoints = healthPoints;
        }

        internal Healing(string name, int healthPoints) : base(name)
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
