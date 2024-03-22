using Dungeon_Heroes.Models;
using System;

namespace Dungeon_Heroes.Skills
{
    internal class Rage : Skill
    {
        private double buff;
        private double defaultValue;

        internal Rage(string name, int price, double mana, double buff) : base(name, price, mana)
        {
            this.buff = buff;
        }

        internal Rage(string name, double buff) : base(name)
        {
            this.buff = buff;
        }

        internal override void UseSkill(Hero hero)
        {
            defaultValue = hero.Weapon.Damage;

            hero.Weapon.Damage *= buff;
            hero.Mana -= Mana;
            Console.WriteLine($"DMG +{(buff - 1) * 100}% -{Mana}MP");
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Weapon.Damage = defaultValue;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultValue = enemy.Damage;

            enemy.Damage *= buff;
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Damage = defaultValue;
        }
    }
}
