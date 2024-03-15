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
        internal Hero hero { get; set; }

        internal Player(Hub hub)
        {
            this.hub = hub;
            hero = CreateHero();
        }

        internal Hero CreateHero()
        {
            while (true)
            {
                Console.Write("Введите имя вашего героя: ");
                string name = Console.ReadLine();

                Console.WriteLine("Выберите начальное умение:");
                hub.ShowSkills();
                //Console.WriteLine($"{hub.Skills.Count + 1}. Сменить имя");
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
                Console.WriteLine($"1. Доспехи\n2. Оружие\n3. Умения\n4. Выбрать подземелье\n5. Выйти из игры");

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

                    case "4": // доделать выбор данжа
                        break;

                    case "5": return;

                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        break;
                }
            }
        }

        void BuyGoods<T>(T item) where T : IItem
        {
            if (NotEnoughMoney(item.Price)) return;
            hero.Money -= item.Price;

            if (typeof(T) == typeof(Armor))
            {
                hero.Armor = (Armor)(object)item;
                hub.Armors.Remove((Armor)(object)item);
            }
            else if (typeof(T) == typeof(Weapon))
            {
                hero.Weapon = (Weapon)(object)item;
                hub.Weapons.Remove((Weapon)(object)item);
            }
            else if (typeof(T) == typeof(Skill))
            {
                hero.Skills.Add((Skill)(object)item);
                hub.Skills.Remove((Skill)(object)item);
            }

            Console.WriteLine($"Приобретено {item.Name}");
        }

        bool NotEnoughMoney(int cost)
        {
            if (hero.Money < cost)
            {
                Console.WriteLine("Не хватает монет!\n");
                return true;
            }
            return false;
        }

        int GetOption(int len)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > len + 1)
            {
                Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
            }
            return option;
        }
    }
}
