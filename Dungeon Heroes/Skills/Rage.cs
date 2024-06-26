﻿using System;

namespace Dungeon_Heroes
{
    internal class Rage : Skill
    {
        private double buff;
        private int defaultHeroValue;
        private int defaultEnemyValue;

        internal Rage(string name, int mana, int price, double buff) : base(name, mana, price)
        {
            this.buff = buff;
            description = $"DMG +{(buff - 1) * 100}% -{Mana}MP";
        }

        internal Rage()
        {
            Name = "Ярость";
            buff = 1.5;
        }

        internal override void UseSkill(Hero hero)
        {
            defaultHeroValue = hero.Weapon.Damage;
            hero.Weapon.Damage = (int)Math.Round(hero.Weapon.Damage * buff);
            hero.Mana -= Mana;
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Weapon.Damage = defaultHeroValue;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultEnemyValue = enemy.Damage;
            enemy.Damage = (int)Math.Round(enemy.Damage * buff);
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Damage = defaultEnemyValue;
        }
    }
}
