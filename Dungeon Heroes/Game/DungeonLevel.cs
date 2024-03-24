using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class DungeonLevel
    {
        private Random random = new Random();
        private string difficulty;
        internal int MinRooms { get; }
        internal int MaxRooms { get; }
        internal int MinEnemyHealth { get; }
        internal int MaxEnemyHealth { get; }
        internal int MinEnemyDamage { get; }
        internal int MaxEnemyDamage { get; }
        internal double MinEnemyDefense { get; }
        internal double MaxEnemyDefense { get; }
        internal List<RoomType> Rooms { get; }
        internal double EnemyRoomChance { get; }
        internal double TreasureRoomChance { get; }
        internal double RestoreRoomChance { get; }

        internal DungeonLevel(string difficulty, int minRooms, int maxRooms, int minEnemyHealth, int maxEnemyHealth, int minEnemyDamage, int maxEnemyDamage, double minEnemyDefense, double maxEnemyDefense, double enemyRoomChance, double treasureRoomChance, double restoreRoomChance)
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
            EnemyRoomChance = enemyRoomChance;
            TreasureRoomChance = treasureRoomChance;
            RestoreRoomChance = restoreRoomChance;
            Rooms = GenerateRooms(minRooms, maxRooms);
        }

        private List<RoomType> GenerateRooms(int minRooms, int maxRooms)
        {
            List<RoomType> rooms = new List<RoomType>();
            int numberOfRooms = random.Next(minRooms, maxRooms);

            for (int i = 0; i < numberOfRooms; i++)
            {
                rooms.Add(GetRandomRoomType());
            }

            return rooms;
        }

        private RoomType GetRandomRoomType()
        {
            double randomNumber = random.NextDouble();

            double totalChance = EnemyRoomChance + TreasureRoomChance + RestoreRoomChance;
            double enemyThreshold = EnemyRoomChance / totalChance;
            double treasureThreshold = (EnemyRoomChance + TreasureRoomChance) / totalChance;

            if (randomNumber < enemyThreshold)
            {
                return RoomType.EnemyRoom;
            }
            else if (randomNumber < treasureThreshold)
            {
                return RoomType.TreasureRoom;
            }
            else
            {
                return RoomType.RestoreRoom;
            }
        }

        public override string ToString() { return difficulty; }
    }
}
