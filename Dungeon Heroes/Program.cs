using Dungeon_Heroes.Game;
using Dungeon_Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Hub hub = new Hub();

            Hero hero = player.CreateHero(hub);

            Console.WriteLine(hero);

            Console.ReadLine();
        }
    }
}
