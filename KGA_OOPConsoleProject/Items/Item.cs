using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 코멘트
 * 몬스터의 선언/정의 방식과 동일하게 Item을 상속받아서
 * Device / Supplies / Weapon 클래스를 제작
 */
namespace KGA_OOPConsoleProject.Items
{
    public class Item
    {
        public string name;
        public ItemsType itemType;
        public int itemCost;
        public StatusType status;
        public int plusValue;

        Player player;

        public Item(string name, ItemsType itemType, int itemCost, StatusType status, int plusValue)
        {
            this.name = name;
            this.itemType = itemType;
            this.itemCost = itemCost;
            this.status = status;
            this.plusValue = plusValue;
        }

    }
}
