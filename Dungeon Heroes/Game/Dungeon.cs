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
        private Random random = new Random();

        internal void EnterTheDungeon(Hero hero)
        {
            int numberOfRooms = random.Next(5, 10);
            for (int i = 0; i < numberOfRooms; i++)
            {
                int roomType = random.Next(3);
                switch (roomType)
                {
                    case 0:
                        Console.WriteLine("Вы столкнулись с врагом!");
                        Enemy enemy = GenerateRandomEnemy();
                        FightEnemy(hero, enemy);
                        break;
                    case 1:
                        Console.WriteLine("Вы нашли комнату с сокровищем!");
                        hero.Money += random.Next(50, 200);
                        break;
                    case 2:
                        Console.WriteLine("Вы нашли комнату для восстановления здоровья или магической силы!");
                        RestoreHealthOrMana(hero);
                        break;
                }
            }
            Console.WriteLine("Вы исследовали все комнаты подземелья.");
        }

        private Enemy GenerateRandomEnemy()
        {
            string[] enemyTypes = { "Скелет", "Гоблин", "Орк", "Вампир", "Дракон" };
            string randomEnemyType = enemyTypes[random.Next(enemyTypes.Length)];
            double enemyHealth = random.Next(50, 200);
            return new Enemy(randomEnemyType, enemyHealth);
        }

        private void FightEnemy(Hero hero, Enemy enemy)
        {
            Console.WriteLine($"Вы столкнулись с врагом {enemy.Type} HP[{enemy.Health}]");
            while (hero.Health > 0 && enemy.Health > 0)
            {
                // Логика боя между героем и врагом
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

        private void RestoreHealthOrMana(Hero hero)
        {
            Console.WriteLine("Что вы хотите восстановить? (1 - Здоровье, 2 - Магическая сила)");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Неправильный выбор! Пожалуйста, выберите 1 или 2.");
            }

            switch (choice)
            {
                case 1:
                    hero.Health = Math.Min(hero.Health + random.Next(20, 50), 100);
                    Console.WriteLine($"Ваше здоровье восстановлено. Здоровье: {hero.Health}");
                    break;
                case 2:
                    hero.Mana = Math.Min(hero.Mana + random.Next(20, 50), 100);
                    Console.WriteLine($"Ваша магическая сила восстановлена. Мана: {hero.Mana}");
                    break;
            }
        }
    }

    internal class Enemy
    {
        internal string Type { get; }
        internal double Health { get; set; }

        internal Enemy(string type, double health)
        {
            Type = type;
            Health = health;
        }
    }
}
