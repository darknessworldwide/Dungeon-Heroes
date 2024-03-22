namespace Dungeon_Heroes.Game
{
    internal class DungeonLevel
    {
        private string difficulty;
        internal int MinRooms { get; }
        internal int MaxRooms { get; }
        internal double MinEnemyHealth { get; }
        internal double MaxEnemyHealth { get; }
        internal double MinEnemyDamage { get; }
        internal double MaxEnemyDamage { get; }
        internal double MinEnemyDefense { get; }
        internal double MaxEnemyDefense { get; }
        internal double TreasureChance { get; }

        internal DungeonLevel(string difficulty, int minRooms, int maxRooms, double minEnemyHealth, double maxEnemyHealth, double minEnemyDamage, double maxEnemyDamage, double minEnemyDefense, double maxEnemyDefense, double treasureChance)
        {
            this.difficulty = difficulty;
            MinRooms = minRooms;
            MaxRooms = maxRooms;
            MinEnemyHealth = minEnemyHealth;
            MaxEnemyHealth = maxEnemyHealth;
            MinEnemyDamage = minEnemyDamage;
            MaxEnemyDamage = maxEnemyDamage;
            MinEnemyDefense = minEnemyDefense;
            MaxEnemyDefense = maxEnemyDefense;
            TreasureChance = treasureChance;
        }

        public override string ToString() { return difficulty; }
    }
}
