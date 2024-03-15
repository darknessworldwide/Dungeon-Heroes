using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.ItemInterfaces
{
    internal interface IItem
    {
        string Name { get; }
        int Price { get; }
    }
}
