﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class Weapon : Item
    {
        public Weapon(string name, ItemsType itemType, int itemCost, StatusType status, int plusValue) : base(name, itemType, itemCost, status, plusValue)
        {

        }

    }
}
