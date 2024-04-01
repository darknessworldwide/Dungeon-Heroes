using System;
using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class DungeonLevel
    {
        private Random random = new Random();
        private string difficulty;
        internal int MinEnemyHealth { get; }
        internal int MaxEnemyHealth { get; }
        internal int MinEnemyDamage { get; }
        internal int MaxEnemyDamage { get; }
        internal double MinEnemyDefense { get; }
        internal double MaxEnemyDefense { get; }
        internal int MinCoins { get; }
        internal int MaxCoins { get; }
        private double enemyRoomChance;
        private double treasureRoomChance;
        private double recoveryRoomChance;
        internal List<RoomTypes> Rooms { get; set; }

        internal DungeonLevel(string difficulty, int minRooms, int maxRooms, int minEnemyHealth, int maxEnemyHealth, int minEnemyDamage, int maxEnemyDamage, double minEnemyDefense, double maxEnemyDefense, int minCoins, int maxCoins, double enemyRoomChance, double treasureRoomChance, double recoveryRoomChance)
        {
            this.difficulty = difficulty;
            MinEnemyHealth = minEnemyHealth;
            MaxEnemyHealth = maxEnemyHealth;
            MinEnemyDamage = minEnemyDamage;
            MaxEnemyDamage = maxEnemyDamage;
            MinEnemyDefense = minEnemyDefense;
            MaxEnemyDefense = maxEnemyDefense;
            MinCoins = minCoins;
            MaxCoins = maxCoins;
            this.enemyRoomChance = enemyRoomChance;
            this.treasureRoomChance = treasureRoomChance;
            this.recoveryRoomChance = recoveryRoomChance;
            Rooms = GenerateRooms(minRooms, maxRooms);
        }

        private List<RoomTypes> GenerateRooms(int minRooms, int maxRooms)
        {
            List<RoomTypes> rooms = new List<RoomTypes>();

            int numberOfRooms = random.Next(minRooms, maxRooms);
            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms.Add(GetRandomRoomType());
            }
            return rooms;
        }

        private RoomTypes GetRandomRoomType()
        {
            double randomNumber = random.NextDouble();

            double totalChance = enemyRoomChance + treasureRoomChance + recoveryRoomChance;
            double enemyThreshold = enemyRoomChance / totalChance;
            double treasureThreshold = (enemyRoomChance + treasureRoomChance) / totalChance;

            if (randomNumber < enemyThreshold)
            {
                return RoomTypes.EnemyRoom;
            }
            else if (randomNumber < treasureThreshold)
            {
                return RoomTypes.TreasureRoom;
            }
            else
            {
                return RoomTypes.RecoveryRoom;
            }
        }

        public override string ToString() { return difficulty; }
    }
}
