namespace Dungeon_Heroes
{
    internal class Skill : IItem
    {
        public string Name { get; }
        public int Price { get; }
        internal double Mana {  get; }

        internal Skill(string name, int price, double mana)
        {
            Name = name;
            Price = price;
            Mana = mana;
        }

        internal Skill(string name)
        {
            Name = name;
        }

        internal virtual void UseSkill(Hero hero) { }
        internal virtual void StopSkill(Hero hero) { }

        internal virtual void UseSkill(Enemy enemy) { }
        internal virtual void StopSkill(Enemy enemy) { }

        public override string ToString() { return $"{Name} MP[{Mana}]"; }
    }
}
