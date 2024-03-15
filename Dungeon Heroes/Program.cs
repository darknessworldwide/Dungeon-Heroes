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
            Hub hub = new Hub();
            Player player = new Player(hub);
            hub.SetHero(player.hero);

            Console.WriteLine(player.hero);
            player.VisitTheHub();
        }
    }
}
