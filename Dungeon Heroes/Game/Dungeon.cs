using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Game
{
    internal class Dungeon
    {
        Random random = new Random();
        Hero hero;
        Player player;
        DungeonLevel dungeonLevel;

        internal Dungeon(Hero hero, Player player, DungeonLevel dungeonLevel)
        {
            this.hero = hero;
            this.player = player;
            this.dungeonLevel = dungeonLevel;
        }

        internal void EnterTheDungeon()
        {
            int numberOfRooms = random.Next(dungeonLevel.MinRooms, dungeonLevel.MaxRooms + 1);
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
            double enemyHealth = random.Next((int)dungeonLevel.MinEnemyHealth, (int)dungeonLevel.MaxEnemyHealth + 1);
            double enemyDamage = random.Next((int)dungeonLevel.MinEnemyDamage, (int)dungeonLevel.MaxEnemyDamage + 1);
            return new Enemy(randomEnemyType, enemyHealth, enemyDamage);
        }

        private void FightEnemy(Enemy enemy)
        {
            Console.WriteLine($"Вы столкнулись с врагом {enemy.Type} HP[{enemy.Health}]");

            while (true)
            {
                Console.WriteLine($"Выберите умение из списка: {hero.GetMySkills()}");
                int option = player.GetOption(hero.Skills.Count);

                hero.Skills[option - 1].UseSkill();
            }
            if (hero.Health <= 0)
            {
                Console.WriteLine("Вы проиграли!");
            }
            else
            {
                Console.WriteLine("Вы победили врага!");
            }
        }

        private void RestoreHealthOrMana()
        {
            Console.WriteLine("Вы нашли комнату для восстановления здоровья или магической силы!");
            Console.WriteLine("Что вы хотите восстановить?\n1. Здоровье\n2. Магическую силу");

            switch (Console.ReadLine())
            {
                case "1":
                    hero.Health = Math.Min(hero.Health + random.Next(20, 50), 100);
                    Console.WriteLine($"Ваше здоровье восстановлено. Здоровье: {hero.Health}");
                    break;
                case "2":
                    hero.Mana = Math.Min(hero.Mana + random.Next(20, 50), 100);
                    Console.WriteLine($"Ваша магическая сила восстановлена. Мана: {hero.Mana}");
                    break;
                default:
                    Console.WriteLine("Неправильный выбор! Пожалуйста, выберите 1 или 2.");
                    break;
            }
        }

        private void Escape()
        {
            Console.WriteLine("Вы успешно сбежали из подземелья в хаб.");
            hero.Health = 100;
            hero.Mana = 100;
        }
    }
}
