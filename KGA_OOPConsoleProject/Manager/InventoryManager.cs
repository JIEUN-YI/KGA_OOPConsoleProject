using KGA_OOPConsoleProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Manager
{
    public class InventoryManager
    {
        public Item item;
        public Player player;

        public void InputInven(Item productList)
        {
            player.inventory.Add(productList);
        }
        public void OutputInven()
        {

        }
    }
}
