using Dungeon_Heroes.ItemInterfaces;

namespace Dungeon_Heroes.Models
{
    internal class Skill : IItem
    {
        public string Name { get; }
        public int Price { get; }

        internal Skill(string name, int price)
        {
            Name = name;
            Price = price;
        }

        internal virtual void UseSkill(Hero hero) { }
        internal virtual void StopSkill(Hero hero) { }

        internal virtual void UseSkill(Enemy enemy) { }
        internal virtual void StopSkill(Enemy enemy) { }

        public override string ToString() { return $"{Name}"; }
    }
}
