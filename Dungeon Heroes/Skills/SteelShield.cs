using Dungeon_Heroes.Models;
using System;

namespace Dungeon_Heroes.Skills
{
    internal class SteelShield : Skill
    {
        private double buff;
        private double defaultValue;

        internal SteelShield(string name, int price, double mana, double buff) : base(name, price, mana)
        {
            this.buff = buff;
        }

        internal SteelShield(string name, double buff) : base(name)
        {
            this.buff = buff;
        }

        internal override void UseSkill(Hero hero)
        {
            defaultValue = hero.Armor.Defense;

            hero.Armor.Defense *= buff;
            hero.Mana -= Mana;
            Console.WriteLine($"DEF +{(buff - 1) * 100}% -{Mana}MP");
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Armor.Defense = defaultValue;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultValue = enemy.Health;

            enemy.Health *= buff;
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Health = defaultValue;
        }
    }
}
