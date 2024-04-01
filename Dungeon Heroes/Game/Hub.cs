using System;
using System.Collections.Generic;

namespace Dungeon_Heroes
{
    internal class Hub
    {
        private Player player;
        private Store store;
        private Hero hero;
        private DungeonLevel[] dungeonLevels;

        internal Hub(Player player, Store store, Hero hero)
        {
            this.player = player;
            this.store = store;
            this.hero = hero;
        }

        internal void OpenGameMenu()
        {
            while (true)
            {
                Console.WriteLine($"1. Доспехи\n2. Оружие\n3. Умения\n4. Подземелья\n5. Сменить имя\n6. Персонаж\n7. Выйти из игры");
                string option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        SelectItems(store.Armors);
                        break;

                    case "2":
                        SelectItems(store.Weapons);
                        break;

                    case "3":
                        SelectItems(store.Skills);
                        break;

                    case "4":
                        ChooseDungeon();
                        break;

                    case "5":
                        ChangeHeroName();
                        break;

                    case "6":
                        Console.WriteLine(hero);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "7":
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private bool NotEnoughMoney(int cost)
        {
            if (hero.Money < cost)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не хватает монет!\n");
                Console.ResetColor();
                return true;
            }
            return false;
        }

        private bool BuyAnItem<T>(T item) where T : IItem
        {
            if (NotEnoughMoney(item.Price)) return false;
            hero.Money -= item.Price;

            if (typeof(T) == typeof(Armor))
            {
                if (item.Price < hero.Armor.Price)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Нельзя купить доспехи хуже имеющихся!\n");
                    Console.ResetColor();
                    return false;
                }
                hero.Armor = (Armor)(object)item;
                store.Armors.Remove((Armor)(object)item);
            }
            else if (typeof(T) == typeof(Weapon))
            {
                if (item.Price < hero.Weapon.Price)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Нельзя купить оружие хуже имеющегося!\n");
                    Console.ResetColor();
                    return false;
                }
                hero.Weapon = (Weapon)(object)item;
                store.Weapons.Remove((Weapon)(object)item);
            }
            else if (typeof(T) == typeof(Skill))
            {
                hero.Skills.Add((Skill)(object)item);
                store.Skills.Remove((Skill)(object)item);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Приобретено {item.Name}\n");
            Console.ResetColor();

            return true;
        }

        private void ShowList<T>(List<T> list) where T : IItem
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{i + 1}. {list[i]} ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{list[i].Price} монет");
                Console.ResetColor();
            }
            Console.WriteLine("0. Назад");
        }

        private void SelectItems<T>(List<T> list) where T : IItem
        {
            while (true)
            {
                ShowList(list);
                int option = player.GetOption(list.Count);
                if (option == 0)
                {
                    Console.Clear();
                    return;
                }
                if (!BuyAnItem(list[option - 1])) continue;
            }
        }

        private void ChooseDungeon()
        {
            dungeonLevels = new DungeonLevel[]
            {
                new DungeonLevel("Легкий", 5, 8, 50, 100, 10, 20, 0.5, 1, 40, 60, 0.5, 0.3, 0.2),
                new DungeonLevel("Средний", 8, 12, 100, 150, 20, 30, 1, 1.5, 60, 80, 0.6, 0.2, 0.2),
                new DungeonLevel("Сложный", 12, 16, 150, 200, 30, 40, 1.5, 2, 80, 100, 0.7, 0.1, 0.1),
            };

            ShowDungeonLevels();
            int option = player.GetOption(dungeonLevels.Length);
            if (option == 0)
            {
                Console.Clear();
                return;
            }
            Console.Clear();
            EnterDungeon(dungeonLevels[option - 1]);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nНажмите любую кнопку, чтобы продолжить...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        private void ShowDungeonLevels()
        {
            Console.WriteLine("Выберите уровень сложности подземелья:");
            for (int i = 0; i < dungeonLevels.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {dungeonLevels[i]}");
            }
            Console.WriteLine("0. Назад");
        }

        private void EnterDungeon(DungeonLevel dungeonLevel)
        {
            Dungeon dungeon = new Dungeon(hero, dungeonLevel);
            dungeon.ExploreDungeon();
        }

        private void ChangeHeroName()
        {
            Console.Write("Введите новое имя для вашего героя: ");
            string newName = Console.ReadLine();
            hero.Name = newName;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Имя вашего героя изменено на {newName}\n");
            Console.ResetColor();
        }
    }
}
