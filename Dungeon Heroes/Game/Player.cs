using Dungeon_Heroes.Models;
using Dungeon_Heroes.ItemInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Game
{
    internal class Player
    {
        Hub hub;
        internal Hero Hero { get; set; }

        internal Player(Hub hub)
        {
            this.hub = hub;
            Hero = CreateHero();
        }

        internal Hero CreateHero()
        {
            while (true)
            {
                Console.Write("Введите имя вашего героя: ");
                string name = Console.ReadLine();

                Console.WriteLine("Выберите начальное умение:");
                hub.ShowSkills();
                int option = GetOption(hub.Skills.Count);
                if (option == hub.Skills.Count + 1) continue;

                Hero hero = new Hero(name, 100, 100, 10000, new Armor("Накидка", 1, 50), new Weapon("Зубочистка", 1, 0, 0), new List<Skill> { hub.Skills[option - 1] });
                hub.Skills.RemoveAt(option - 1);
                return hero;
            }
        }

        internal void VisitTheHub()
        {
            while (true)
            {
                Console.WriteLine($"1. Доспехи\n2. Оружие\n3. Умения\n4. Выбрать подземелье\n5. Сменить имя\n6. Выйти из игры");

                int option;
                switch (Console.ReadLine())
                {
                    case "1":
                        hub.ShowArmors();
                        option = GetOption(hub.Armors.Count);
                        if (option == hub.Armors.Count + 1) break;

                        BuyGoods(hub.Armors[option - 1]);
                        break;

                    case "2":
                        hub.ShowWeapons();
                        option = GetOption(hub.Weapons.Count);
                        if (option == hub.Weapons.Count + 1) break;

                        BuyGoods(hub.Weapons[option - 1]);
                        break;

                    case "3":
                        hub.ShowSkills();
                        option = GetOption(hub.Skills.Count);
                        if (option == hub.Skills.Count + 1) break;

                        BuyGoods(hub.Skills[option - 1]);
                        break;

                    case "4":
                        ChooseDungeon();
                        break;

                    case "5":
                        ChangeHeroName();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        break;
                }
            }
        }

        void BuyGoods<T>(T item) where T : IItem
        {
            if (NotEnoughMoney(item.Price)) return;
            Hero.Money -= item.Price;

            if (typeof(T) == typeof(Armor))
            {
                Hero.Armor = (Armor)(object)item;
                hub.Armors.Remove((Armor)(object)item);
            }
            else if (typeof(T) == typeof(Weapon))
            {
                Hero.Weapon = (Weapon)(object)item;
                hub.Weapons.Remove((Weapon)(object)item);
            }
            else if (typeof(T) == typeof(Skill))
            {
                Hero.Skills.Add((Skill)(object)item);
                hub.Skills.Remove((Skill)(object)item);
            }

            Console.WriteLine($"Приобретено {item.Name}");
        }

        bool NotEnoughMoney(int cost)
        {
            if (Hero.Money < cost)
            {
                Console.WriteLine("Не хватает монет!\n");
                return true;
            }
            return false;
        }

        internal int GetOption(int len)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > len + 1)
            {
                Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
            }
            return option;
        }

        void ChooseDungeon()
        {
            Console.WriteLine("Выберите уровень сложности подземелья:");
            hub.ShowDungeonLevels();

            int option = GetOption(hub.DungeonLevels.Count);
            if (option == hub.DungeonLevels.Count + 1) return;

            EnterDungeon(hub.DungeonLevels[option - 1]);
        }

        void EnterDungeon(DungeonLevel dungeonLevel) 
        {
            Dungeon dungeon = new Dungeon(Hero, this, dungeonLevel);
            dungeon.EnterTheDungeon();
        }

        void ChangeHeroName()
        {
            Console.Write("Введите новое имя для вашего героя: ");
            string newName = Console.ReadLine();
            Hero.Name = newName;
            Console.WriteLine($"Имя вашего героя успешно изменено на {newName}");
        }
    }
}
