namespace Dungeon_Heroes
{
    internal class SteelShield : Skill
    {
        private double buff;
        private double defaultHeroValue;
        private double defaultEnemyValue;

        internal SteelShield(string name, int mana, int price, double buff) : base(name, mana, price)
        {
            this.buff = buff;
            Description = $"DEF +{(buff - 1) * 100}% -{Mana}MP";
        }

        internal SteelShield()
        {
            Name = "Стальной щит";
            buff = 1.8;
        }

        internal override void UseSkill(Hero hero)
        {
            defaultHeroValue = hero.Armor.Defense;
            hero.Armor.Defense *= buff;
            hero.Mana -= Mana;
        }

        internal override void StopSkill(Hero hero)
        {
            hero.Armor.Defense = defaultHeroValue;
        }

        internal override void UseSkill(Enemy enemy)
        {
            defaultEnemyValue = enemy.Defense;
            enemy.Defense *= buff;
        }

        internal override void StopSkill(Enemy enemy)
        {
            enemy.Defense = defaultEnemyValue;
        }
    }
}
