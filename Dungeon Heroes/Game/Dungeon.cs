using Dungeon_Heroes.Models;
using System;

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

        internal void ExploreDungeon()
        {
            foreach (RoomType roomType in dungeonLevel.Rooms)
            {
                switch (roomType)
                {
                    case RoomType.EnemyRoom:
                        FightEnemy();
                        break;
                    case RoomType.TreasureRoom:
                        CollectTreasure();
                        break;
                    case RoomType.RestoreRoom:
                        RestoreHealthOrMana();
                        break;
                }

                if (CheckEscape()) break;
            }
            Console.WriteLine("Вы исследовали все комнаты подземелья.");
            CollectTreasure();
        }

        private Enemy GenerateRandomEnemy()
        {
            string[] enemyTypes = { "Скелет", "Гоблин", "Орк", "Вампир", "Дракон" };
            string randomEnemyType = enemyTypes[random.Next(enemyTypes.Length)];
            int enemyHealth = random.Next(dungeonLevel.MinEnemyHealth, dungeonLevel.MaxEnemyHealth);
            int enemyDamage = random.Next(dungeonLevel.MinEnemyDamage, dungeonLevel.MaxEnemyDamage);
            double enemyDefense = Math.Round(random.NextDouble() * (dungeonLevel.MaxEnemyDefense - dungeonLevel.MinEnemyDefense) + dungeonLevel.MinEnemyDefense, 1);

            return new Enemy(randomEnemyType, enemyHealth, enemyDefense, enemyDamage);
        }

        private void FightEnemy()
        {
            Enemy enemy = GenerateRandomEnemy();
            Console.WriteLine($"Вы столкнулись с врагом {enemy}");
            int damage;
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

                damage = (int)Math.Round(hero.Weapon.Damage / enemy.Defense);
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

                damage = (int)Math.Round(enemy.Damage / hero.Armor.Defense);
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

        private void CollectTreasure()
        {
            int treasureAmount = random.Next(50, 200);
            Console.WriteLine($"Вы нашли комнату с сокровищем! Получено {treasureAmount} монет.");
            hero.Money += treasureAmount;
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

        private bool CheckEscape()
        {
            Console.WriteLine("Вы желаете сбежать из подземелья в хаб? (да/нет)");
            string option = Console.ReadLine();
            if (option == "да")
            {
                Escape();
                return true;
            }
            return false;
        }

        private void Escape()
        {
            Console.WriteLine("Вы сбежали из подземелья");
            hero.Health = 100;
            hero.Mana = 100;
        }
    }
}
