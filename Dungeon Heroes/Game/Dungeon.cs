using System;

namespace Dungeon_Heroes
{
    internal class Dungeon
    {
        private Random random = new Random();
        private Hero hero;
        private DungeonLevel dungeonLevel;
        private int money = 0;
        private bool dead;

        internal Dungeon(Hero hero, DungeonLevel dungeonLevel)
        {
            this.hero = hero;
            this.dungeonLevel = dungeonLevel;
        }

        internal void ExploreDungeon()
        {
            foreach (RoomTypes roomType in dungeonLevel.Rooms)
            {
                switch (roomType)
                {
                    case RoomTypes.EnemyRoom:
                        FightEnemy();
                        if (dead)
                        {
                            Escape();
                            return;
                        }
                        break;

                    case RoomTypes.TreasureRoom:
                        CollectTreasure();
                        break;

                    case RoomTypes.RecoveryRoom:
                        RestoreHealthOrMana();
                        break;
                }
                if (CheckEscape()) return;
            }
            CollectTreasure();
            hero.Money += money;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВы исследовали все комнаты подземелья");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Вы столкнулись с врагом {enemy}");
            Console.ResetColor();

            int damage;
            int index = 0; // индекс для героя, любое значение
            int idx = 0; // индекс для врага, любое значение
            bool heroSkill = false;
            bool enemySkill = false;

            while (true)
            {
                if (hero.SkillsAvailable())
                {
                    Console.WriteLine("\nВыберите доступное умение:");
                    Console.WriteLine(hero.GetMySkills(hero.AvailableSkills));
                    index = GetIndex(hero.AvailableSkills.Count);
                    hero.AvailableSkills[index].UseSkill(hero);
                    heroSkill = true;

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{hero.Name} использовал {hero.AvailableSkills[index].Name}");
                    Console.ResetColor();
                }

                damage = (int)Math.Round(hero.Weapon.Damage / enemy.Defense);
                enemy.Health -= damage;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{hero.Name} наносит {damage}DMG {enemy.Type}");
                Console.ResetColor();
                Console.WriteLine();

                if (enemySkill)
                {
                    enemy.Skills[idx].StopSkill(enemy);
                    enemySkill = false;
                }

                if (enemy.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Вы победили врага!");
                    Console.ResetColor();

                    if (heroSkill)
                    {
                        hero.AvailableSkills[index].StopSkill(hero);
                        heroSkill = false;
                    }
                    return;
                }

                Console.WriteLine($"{enemy.Type} HP[{enemy.Health}/{enemy.DefaultHealth}]");

                idx = random.Next(enemy.Skills.Length);
                enemy.Skills[idx].UseSkill(enemy);
                enemySkill = true;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{enemy.Type} использовал {enemy.Skills[idx].Name}");
                Console.ResetColor();

                damage = (int)Math.Round(enemy.Damage / hero.Armor.Defense);
                hero.Health -= damage;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{enemy.Type} наносит {damage}DMG {hero.Name}");
                Console.ResetColor();
                Console.WriteLine();

                if (heroSkill)
                {
                    hero.AvailableSkills[index].StopSkill(hero);
                    heroSkill = false;
                }

                if (hero.Health <= 0)
                {
                    dead = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы погибли! Все найденные монеты потеряны\n");
                    Console.ResetColor();

                    if (enemySkill)
                    {
                        enemy.Skills[idx].StopSkill(enemy);
                        enemySkill = false;
                    }
                    return;
                }

                Console.WriteLine($"{hero.Name} HP[{hero.Health}/100] MP[{hero.Mana}/100]");
            }
        }

        private void CollectTreasure()
        {
            int coins = random.Next(dungeonLevel.MinCoins, dungeonLevel.MaxCoins);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Вы нашли комнату с сокровищем! Получено {coins} монет");
            Console.ResetColor();

            money += coins;
        }

        private void RestoreHealthOrMana()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Вы нашли комнату для восстановления здоровья или магической силы\n");
            Console.ResetColor();
            Console.WriteLine("Что восстановить?\n1. Здоровье\n2. Магическую силу");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        hero.Health = Math.Min(hero.Health + random.Next(20, 50), 100);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Здоровье восстановлено. HP[{hero.Health}/100]");
                        Console.ResetColor();
                        return;

                    case "2":
                        hero.Mana = Math.Min(hero.Mana + random.Next(20, 50), 100);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Мана восстановлена. MP[{hero.Mana}/100]");
                        Console.ResetColor();
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private bool CheckEscape()
        {
            Console.WriteLine("\nВы желаете сбежать из подземелья в хаб? (да/нет)");
            string input = Console.ReadLine();
            Console.Clear();
            if (input == "да")
            {
                hero.Money += money;
                Escape();
                return true;
            }
            return false;
        }

        private void Escape()
        {
            hero.Health = 100;
            hero.Mana = 100;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Вы сбежали из подземелья");
            Console.ResetColor();
        }

        private int GetIndex(int len)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > len)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
                Console.ResetColor();
            }
            return option - 1;
        }
    }
}
