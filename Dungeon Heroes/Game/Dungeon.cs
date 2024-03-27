using System;

namespace Dungeon_Heroes
{
    internal class Dungeon
    {
        private Hero hero;
        private DungeonLevel dungeonLevel;
        private Random random = new Random();
        private bool dead;

        internal Dungeon(Hero hero, DungeonLevel dungeonLevel)
        {
            this.hero = hero;
            this.dungeonLevel = dungeonLevel;
        }

        internal void ExploreDungeon()
        {
            foreach (RoomType roomType in dungeonLevel.Rooms)
            {
                switch (roomType)
                {
                    case RoomType.EnemyRoom:
                        FightEnemy();
                        if (dead)
                        {
                            Escape();
                            return;
                        }
                        break;
                    case RoomType.TreasureRoom:
                        CollectTreasure();
                        break;
                    case RoomType.RestoreRoom:
                        RestoreHealthOrMana();
                        break;
                }

                if (CheckEscape()) return;
            }
            CollectTreasure();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Вы исследовали все комнаты подземелья");
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
            Console.WriteLine($"Вы столкнулись с врагом {enemy}");
            int damage;
            int option = 0; // любое значение
            int idx = 0; // любое значение
            bool heroSkill = false;
            bool enemySkill = false;

            while (true)
            {
                if (hero.ChooseASkill())
                {
                    option = GetNoExitOption(hero.AvailableSkills.Count);
                    hero.Skills[option - 1].UseSkill(hero);
                    heroSkill = true;
                }

                damage = (int)Math.Round(hero.Weapon.Damage / enemy.Defense);
                enemy.Health -= damage;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{hero.Name} наносит {damage}DMG {enemy.Type}");
                Console.ResetColor();

                if (enemySkill)
                {
                    enemy.Skills[idx].StopSkill(enemy);
                    enemySkill = false;
                }

                if (enemy.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nВы победили врага!");
                    Console.ResetColor();
                    return;
                }

                Console.WriteLine($"{enemy.Type} HP[{enemy.Health}/{enemy.DefaultHealth}]");

                idx = random.Next(enemy.Skills.Length);
                enemy.Skills[idx].UseSkill(enemy);
                enemySkill = true;
                Console.WriteLine($"{enemy.Type} использовал {enemy.Skills[idx].Name}");

                damage = (int)Math.Round(enemy.Damage / hero.Armor.Defense);
                hero.Health -= damage;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{enemy.Type} наносит {damage}DMG {hero.Name}");
                Console.ResetColor();

                if (heroSkill)
                {
                    hero.Skills[option - 1].StopSkill(hero);
                    heroSkill = false;
                }

                if (hero.Health <= 0)
                {
                    dead = true;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nВы проиграли!");
                    Console.ResetColor();
                    return;
                }

                Console.WriteLine($"{hero.Name} HP[{hero.Health}/100]");
            }
        }

        private void CollectTreasure()
        {
            int treasureAmount = random.Next(50, 200);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Вы нашли комнату с сокровищем! Получено {treasureAmount} монет.");
            Console.ResetColor();

            hero.Money += treasureAmount;
        }

        private void RestoreHealthOrMana()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Вы нашли комнату для восстановления здоровья или магической силы");
            Console.ResetColor();
            Console.WriteLine("Что восстановить?\n1. Здоровье\n2. Магическую силу");

            switch (Console.ReadLine())
            {
                case "1":
                    hero.Health = Math.Min(hero.Health + random.Next(20, 50), 100);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Здоровье восстановлено. HP[{hero.Health}/100]");
                    Console.ResetColor();
                    break;

                case "2":
                    hero.Mana = Math.Min(hero.Mana + random.Next(20, 50), 100);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Мана восстановлена. MP[{hero.Mana}/100]");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                    Console.ResetColor();

                    RestoreHealthOrMana();
                    break;
            }
        }

        private bool CheckEscape()
        {
            Console.WriteLine("\nВы желаете сбежать из подземелья в хаб? (да/нет)");
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
            Console.WriteLine("\nВы сбежали из подземелья");
            hero.Health = 100;
            hero.Mana = 100;
        }

        internal int GetNoExitOption(int len)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > len)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
                Console.ResetColor();
            }
            return option;
        }
    }
}
