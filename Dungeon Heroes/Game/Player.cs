using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Game
{
    internal class Player
    {
        internal Hero CreateHero(Hub hub)
        {
            Console.Write("Введите имя вашего героя: ");
            string name = Console.ReadLine();

            Console.WriteLine("Выберите начальное умение:");
            hub.ShowSkills();

            int skillOption = hub.GetOption(hub.Skills.Count);

            Hero hero = new Hero(name, 100, 100, 10000, new Armor("Накидка", 1, 50), new List<Skill> { hub.Skills[skillOption - 1] });

            hub.Skills.RemoveAt(skillOption - 1);

            return hero;
        }
    }
}
