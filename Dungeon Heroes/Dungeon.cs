﻿using System;

namespace Dungeon_Heroes
{
    internal class Dungeon
    {
        private Random random = new Random();
        private Hero hero;
        private DungeonLevel dungeonLevel;
        private Shop shop;

        internal Dungeon(Hero hero, DungeonLevel dungeonLevel, Shop shop)
        {
            this.hero = hero;
            this.dungeonLevel = dungeonLevel;
            this.shop = shop;
        }

        internal enum RoomType
        {
            EnemyRoom,
            TreasureRoom,
            RestoreRoom
        }

        internal void ExploreDungeon()
        {
            int numberOfRooms = random.Next(dungeonLevel.MinRooms, dungeonLevel.MaxRooms);
            for (int i = 0; i < numberOfRooms; i++)
            {
                RoomType roomType = (RoomType)random.Next(3);
                switch (roomType)
                {
                    case RoomType.EnemyRoom:
                        Enemy enemy = GenerateRandomEnemy();
                        FightEnemy(enemy);
                        break;
                    case RoomType.TreasureRoom:
                        Console.WriteLine("Вы нашли комнату с сокровищем!");
                        hero.Money += random.Next(50, 200);
                        break;
                    case RoomType.RestoreRoom:
                        RestoreHealthOrMana();
                        break;
                }

                Console.WriteLine("Вы желаете сбежать из подземелья в хаб? (да/нет)");
                string option = Console.ReadLine();
                if (option == "да")
                {
                    Escape();
                    break;
                }
            }
            Console.WriteLine("Вы исследовали все комнаты подземелья.");
        }

        private Enemy GenerateRandomEnemy()
        {
            string[] enemyTypes = { "Скелет", "Гоблин", "Орк", "Вампир", "Дракон" };
            string randomEnemyType = enemyTypes[random.Next(enemyTypes.Length)];
            double enemyHealth = random.Next(dungeonLevel.MinEnemyHealth, dungeonLevel.MaxEnemyHealth);
            double enemyDamage = random.Next(dungeonLevel.MinEnemyDamage, dungeonLevel.MaxEnemyDamage);
            double enemyDefense = Math.Round(random.NextDouble() * (dungeonLevel.MaxEnemyDefense - dungeonLevel.MinEnemyDefense) + dungeonLevel.MinEnemyDefense, 1);

            return new Enemy(randomEnemyType, enemyHealth, enemyDefense, enemyDamage);
        }

        private void FightEnemy(Enemy enemy)
        {
            Console.WriteLine($"Вы столкнулись с врагом {enemy}");
            double damage;
            int option = 0; // любое значение
            int idx = 0; // любое значение
            bool flag = false;
            bool flag2 = false;

            while (true)
            {
                if (hero.SkillSelection())
                {
                    option = shop.GetOption(hero.AvailableSkills.Count - 1);
                    hero.Skills[option - 1].UseSkill(hero);
                    flag2 = true;
                }

                damage = hero.Weapon.Damage;
                enemy.Health -= damage;
                Console.WriteLine($"{hero.Name} наносит {damage} DMG {enemy.Type}\n{enemy}");

                if (flag)
                {
                    enemy.Skills[idx].StopSkill(enemy);
                    flag = false;
                }

                if (enemy.Health <= 0)
                {
                    Console.WriteLine("Вы победили врага!");
                    return;
                }

                idx = random.Next(enemy.Skills.Length);
                enemy.Skills[idx].UseSkill(enemy);
                flag = true;
                Console.WriteLine($"{enemy.Type} использовал {enemy.Skills[idx].Name}");

                damage = Math.Round(enemy.Damage / hero.Armor.Defense);
                hero.Health -= damage;
                Console.WriteLine($"{enemy.Type} наносит {damage}DMG {hero.Name}. {hero.Name} HP[{hero.Health}]");

                if (flag2)
                {
                    hero.Skills[option - 1].StopSkill(hero);
                    flag2 = false;
                }

                if (hero.Health <= 0)
                {
                    Console.WriteLine("Вы проиграли!");
                    return;
                }
            }
        }

        private void RestoreHealthOrMana()
        {
            Console.WriteLine("Вы нашли комнату для восстановления здоровья или магической силы");
            Console.WriteLine("Что восстановить?\n1. Здоровье\n2. Магическую силу");

            switch (Console.ReadLine())
            {
                case "1":
                    hero.Health = Math.Min(hero.Health + random.Next(20, 50), 100);
                    Console.WriteLine($"Здоровье восстановлено. HP[{hero.Health}/100]");
                    break;
                case "2":
                    hero.Mana = Math.Min(hero.Mana + random.Next(20, 50), 100);
                    Console.WriteLine($"Мана восстановлена. MP[{hero.Mana}/100]");
                    break;
                default:
                    Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                    RestoreHealthOrMana();
                    break;
            }
        }

        private void Escape()
        {
            Console.WriteLine("Вы сбежали из подземелья");
            hero.Health = 100;
            hero.Mana = 100;
        }
    }
}
