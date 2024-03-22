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
        internal double TreasureChance { get; }

        internal DungeonLevel(string difficulty, int minRooms, int maxRooms, double minEnemyHealth, double maxEnemyHealth, double minEnemyDamage, double maxEnemyDamage, double treasureChance)
        {
            this.difficulty = difficulty;
            MinRooms = minRooms;
            MaxRooms = maxRooms;
            MinEnemyHealth = minEnemyHealth;
            MaxEnemyHealth = maxEnemyHealth;
            MinEnemyDamage = minEnemyDamage;
            MaxEnemyDamage = maxEnemyDamage;
            TreasureChance = treasureChance;
        }

        public override string ToString() { return difficulty; }
    }
}
