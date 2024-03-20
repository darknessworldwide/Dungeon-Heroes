using Dungeon_Heroes.Models;
using System;

namespace Dungeon_Heroes.Skills
{
    internal class SteelShield : Skill
    {
        double defaultValue;

        internal SteelShield(string name, int price) : base(name, price) { }

        internal override void UseSkill(Hero hero)
        {
            defaultValue = hero.Armor.Defense;

            double buff = 1.2;
            int mana = 30;
            hero.Armor.Defense *= buff;
            hero.Mana -= mana;
            Console.WriteLine($"DEF +{(buff - 1) * 100}% -{mana}MP");
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Armor.Defense = defaultValue;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultValue = enemy.Health;

            double buff = 1.1;
            enemy.Health *= buff;
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Health = defaultValue;
        }
    }
}
