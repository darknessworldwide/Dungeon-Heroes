﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Heroes.Models
{
    internal class Enemy
    {
        internal string Type { get; }
        internal double Health { get; set; }
        internal double Damage { get; set; }

        internal Enemy(string type, double health, double damage)
        {
            Type = type;
            Health = health;
            Damage = damage;
        }
    }
}