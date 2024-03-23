using System;

namespace Dungeon_Heroes
{
    internal class SteelShield : Skill
    {
        private double buff;
        private double defaultValueHero;
        private double defaultValueEnemy;

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
            defaultValueHero = hero.Armor.Defense;

            hero.Armor.Defense *= buff;
            hero.Mana -= Mana;
            Console.WriteLine($"DEF +{(buff - 1) * 100}% -{Mana}MP");
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Armor.Defense = defaultValueHero;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultValueEnemy = enemy.Defense;

            enemy.Defense *= buff;
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Defense = defaultValueEnemy;
        }
    }
}
