using Dungeon_Heroes.Models;
using System;

namespace Dungeon_Heroes.Game
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
            int numberOfRooms = random.Next(dungeonLevel.MinRooms, dungeonLevel.MaxRooms);
            for (int i = 0; i < numberOfRooms; i++)
            {
                int roomType = random.Next(3);
                switch (roomType)
                {
                    case 0:
                        Enemy enemy = GenerateRandomEnemy();
                        FightEnemy(enemy);
                        break;
                    case 1:
                        Console.WriteLine("Вы нашли комнату с сокровищем!");
                        hero.Money += random.Next(50, 200);
                        break;
                    case 2:
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
            double enemyHealth = random.Next((int)dungeonLevel.MinEnemyHealth, (int)dungeonLevel.MaxEnemyHealth);
            double enemyDamage = random.Next((int)dungeonLevel.MinEnemyDamage, (int)dungeonLevel.MaxEnemyDamage);
            return new Enemy(randomEnemyType, enemyHealth, enemyDamage);
        }

        private void FightEnemy(Enemy enemy)
        {
            Console.WriteLine($"Вы столкнулись с врагом {enemy}");
            double damage;

            while (true)
            {
                Console.WriteLine($"Выберите умение из списка:\n{hero.GetMySkills()}");
                int option = shop.GetOption(hero.Skills.Count - 1);
                hero.Skills[option - 1].UseSkill(hero);

                damage = hero.Weapon.Damage;
                enemy.Health -= damage;
                Console.WriteLine($"{hero.Name} наносит {damage}DMG {enemy.Type}. {enemy.Type} HP[{enemy.Health}]");

                Console.WriteLine(hero);

                if (enemy.Health <= 0)
                {
                    Console.WriteLine("Вы победили врага!");
                    return;
                }

                int idx = random.Next(enemy.Skills.Length);
                enemy.Skills[idx].UseSkill(enemy);
                Console.WriteLine($"{enemy.Type} использовал {enemy.Skills[idx].Name}");

                damage = Math.Round(enemy.Damage / hero.Armor.Defense);
                hero.Health -= damage;
                Console.WriteLine($"{enemy.Type} наносит {damage}DMG {hero.Name}. {hero.Name} HP[{hero.Health}]");

                Console.WriteLine(enemy);

                hero.Skills[option - 1].StopSkill(hero);
                enemy.Skills[idx].StopSkill(enemy); // если он юзает стальной щит, то он ему он никак не поможет)

                if (hero.Health <= 0)
                {
                    Console.WriteLine("Вы проиграли!");
                    return;
                }
            }
        }

        //private void Attack(Enemy enemy)
        //{
        //    Console.WriteLine($"Выберите умение из списка:\n{hero.GetMySkills()}");

        //    int option = shop.GetOption(hero.Skills.Count);
        //    if (option == shop.Skills.Count + 1) return;

        //    hero.Skills[option - 1].UseSkill(hero);

        //    double damage = hero.Weapon.Damage;
        //    enemy.Health -= damage;
        //    Console.WriteLine($"{hero.Name} наносит {damage}DMG {enemy.Type}. {enemy.Type} HP[{enemy.Health}]");

        //    hero.Skills[option - 1].StopSkill(hero);

        //    Console.WriteLine(hero);
        //}

        //private void Attack(Hero hero, Enemy enemy)
        //{
        //    int idx = random.Next(enemy.Skills.Length);
        //    enemy.Skills[idx].UseSkill(enemy);
        //    Console.WriteLine($"{enemy.Type} использовал {enemy.Skills[idx].Name}");

        //    double damage = enemy.Damage;
        //    hero.Health -= damage;
        //    Console.WriteLine($"{enemy.Type} наносит {damage}DMG {hero.Name}. {hero.Name} HP[{hero.Health}]");

        //    enemy.Skills[idx].StopSkill(enemy);

        //    Console.WriteLine(enemy);
        //}

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
