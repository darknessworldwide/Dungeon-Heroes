namespace Dungeon_Heroes
{
    internal class Skill : IItem
    {
        public string Name { get; set; }
        internal int Mana { get; }
        public int Price { get; }
        private protected string description;

        internal Skill(string name, int mana, int price)
        {
            Name = name;
            Mana = mana;
            Price = price;
        }

        internal Skill() { }

        internal virtual void UseSkill(Hero hero) { }
        internal virtual void StopSkill(Hero hero) { }

        internal virtual void UseSkill(Enemy enemy) { }
        internal virtual void StopSkill(Enemy enemy) { }

        public override string ToString() { return $"{Name} MP[{Mana}] {description}"; }
    }
}
