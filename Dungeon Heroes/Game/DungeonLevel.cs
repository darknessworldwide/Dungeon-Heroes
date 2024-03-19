using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Game
{
    internal class DungeonLevel
    {
        internal string Name { get; }
        internal int MinRooms { get; }
        internal int MaxRooms { get; }
        internal double MinEnemyHealth { get; }
        internal double MaxEnemyHealth { get; }
        internal double MinEnemyDamage { get; }
        internal double MaxEnemyDamage { get; }
        internal double TreasureChance { get; }

        internal DungeonLevel(string name, int minRooms, int maxRooms, double minEnemyHealth, double maxEnemyHealth, double minEnemyDamage, double maxEnemyDamage, double treasureChance)
        {
            Name = name;
            MinRooms = minRooms;
            MaxRooms = maxRooms;
            MinEnemyHealth = minEnemyHealth;
            MaxEnemyHealth = maxEnemyHealth;
            MinEnemyDamage = minEnemyDamage;
            MaxEnemyDamage = maxEnemyDamage;
            TreasureChance = treasureChance;
        }
    }
}
