using Dungeon_Heroes.Models;
using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class DungeonLevel
    {
        private string difficulty;
        internal int MinRooms { get; }
        internal int MaxRooms { get; }
        internal int MinEnemyHealth { get; }
        internal int MaxEnemyHealth { get; }
        internal int MinEnemyDamage { get; }
        internal int MaxEnemyDamage { get; }
        internal double MinEnemyDefense { get; }
        internal double MaxEnemyDefense { get; }
        internal List<RoomType> RoomTypes { get; }
        internal double TreasureChance { get; } // не реализовано

        internal DungeonLevel(string difficulty, int minRooms, int maxRooms, int minEnemyHealth, int maxEnemyHealth, int minEnemyDamage, int maxEnemyDamage, double minEnemyDefense, double maxEnemyDefense, double treasureChance)
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
