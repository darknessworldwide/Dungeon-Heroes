using Dungeon_Heroes.Models;
using System;

namespace Dungeon_Heroes.Skills
{
    internal class Rage : Skill
    {
        double defaultValue;

        internal Rage(string name, int price) : base(name, price) { }

        internal override void UseSkill(Hero hero)
        {
            defaultValue = hero.Weapon.Damage;

            double buff = 1.2;
            int mana = 30;
            hero.Weapon.Damage *= buff;
            hero.Mana -= mana;
            Console.WriteLine($"DMG +{(buff - 1) * 100}% -{mana}MP");
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Weapon.Damage = defaultValue;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultValue = enemy.Damage;

            double buff = 1.1;
            enemy.Damage *= buff;
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Damage = defaultValue;
        }
    }
}
