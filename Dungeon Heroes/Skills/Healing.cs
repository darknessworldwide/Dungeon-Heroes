namespace Dungeon_Heroes
{
    internal class Healing : Skill
    {
        private int healthPoints;

        internal Healing(string name, int mana, int price, int healthPoints) : base(name, mana, price)
        {
            this.healthPoints = healthPoints;
            description = $"+{healthPoints}HP -{Mana}MP";
        }

        internal Healing()
        {
            Name = "Исцеление";
            healthPoints = 30;
        }

        internal override void UseSkill(Hero hero)
        {
            hero.Health += healthPoints;
            hero.Mana -= Mana;
        }

        internal override void UseSkill(Enemy enemy)
        {
            enemy.Health += healthPoints;
        }
    }
}
