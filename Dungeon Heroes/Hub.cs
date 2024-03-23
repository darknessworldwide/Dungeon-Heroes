using System;

namespace Dungeon_Heroes
{
    internal class Hub
    {
        private Shop shop;
        private Hero hero;

        internal Hub(Shop shop, Hero hero)
        {
            this.shop = shop;
            this.hero = hero;
        }

        internal void VisitTheHub()
        {
            while (true)
            {
                Console.WriteLine($"1. Доспехи\n2. Оружие\n3. Умения\n4. Выбрать подземелье\n5. Сменить имя\n6. Персонаж\n7. Выйти из игры");
                switch (Console.ReadLine())
                {
                    case "1":
                        ChooseArmor();
                        break;

                    case "2":
                        ChooseWeapon();
                        break;

                    case "3":
                        ChooseSkill();
                        break;

                    case "4":
                        ChooseDungeon();
                        break;

                    case "5":
                        ChangeHeroName();
                        break;

                    case "6":
                        Console.WriteLine(hero);
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        break;
                }
            }
        }

        private bool NotEnoughMoney(int cost)
        {
            if (hero.Money < cost)
            {
                Console.WriteLine("Не хватает монет!\n");
                return true;
            }
            return false;
        }

        private void BuyGoods<T>(T item) where T : IItem
        {
            if (NotEnoughMoney(item.Price)) return;
            hero.Money -= item.Price;

            if (typeof(T) == typeof(Armor))
            {
                hero.Armor = (Armor)(object)item;
                shop.Armors.Remove((Armor)(object)item);
            }
            else if (typeof(T) == typeof(Weapon))
            {
                hero.Weapon = (Weapon)(object)item;
                shop.Weapons.Remove((Weapon)(object)item);
            }
            else if (typeof(T) == typeof(Skill))
            {
                hero.Skills.Add((Skill)(object)item);
                shop.Skills.Remove((Skill)(object)item);
            }

            Console.WriteLine($"Приобретено {item.Name}");
        }

        private void ChooseArmor()
        {
            shop.ShowArmors();

            int option = shop.GetOption(shop.Armors.Count);
            if (option == shop.Armors.Count + 1) return;

            BuyGoods(shop.Armors[option - 1]);
        }

        private void ChooseWeapon()
        {
            shop.ShowWeapons();

            int option = shop.GetOption(shop.Weapons.Count);
            if (option == shop.Weapons.Count + 1) return;

            BuyGoods(shop.Weapons[option - 1]);
        }

        private void ChooseSkill()
        {
            shop.ShowSkills();

            int option = shop.GetOption(shop.Skills.Count);
            if (option == shop.Skills.Count + 1) return;

            BuyGoods(shop.Skills[option - 1]);
        }

        private void ChooseDungeon()
        {
            Console.WriteLine("Выберите уровень сложности подземелья:");
            shop.ShowDungeonLevels();

            int option = shop.GetOption(shop.DungeonLevels.Length);
            if (option == shop.DungeonLevels.Length + 1) return;

            EnterDungeon(shop.DungeonLevels[option - 1]);
        }

        private void EnterDungeon(DungeonLevel dungeonLevel)
        {
            Dungeon dungeon = new Dungeon(hero, dungeonLevel, shop);
            dungeon.ExploreDungeon();
        }

        private void ChangeHeroName()
        {
            Console.Write("Введите новое имя для вашего героя: ");
            string newName = Console.ReadLine();

            hero.Name = newName;
            Console.WriteLine($"Имя вашего героя изменено на {newName}");
        }
    }
}
