using System;

namespace Dungeon_Heroes
{
    internal class Rage : Skill
    {
        private double buff;
        private double defaultHeroValue; // int
        private double defaultEnemyValue; // int

        internal Rage(string name, int mana, int price, double buff) : base(name, mana, price)
        {
            this.buff = buff;
        }

        internal Rage(string name, double buff) : base(name)
        {
            this.buff = buff;
        }

        internal override void UseSkill(Hero hero)
        {
            defaultHeroValue = hero.Weapon.Damage;
            hero.Weapon.Damage *= buff;
            hero.Mana -= Mana;
            Console.WriteLine($"DMG +{(buff - 1) * 100}% -{Mana}MP");
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Weapon.Damage = defaultHeroValue;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultEnemyValue = enemy.Damage;
            enemy.Damage *= buff;
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Damage = defaultEnemyValue;
        }
    }
}
