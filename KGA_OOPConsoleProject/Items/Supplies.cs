using System.Numerics;

namespace KGA_OOPConsoleProject.Items
{
    public class Supplies : Item
    {
        public Supplies(string name, ItemsType itemType, int itemCost, StatusType status, int plusValue) : base(name, itemType, itemCost, status, plusValue)
        {

        }

        public static Supplies healingPotion = new Supplies("회복 포션", ItemsType.Supplies, 10, StatusType.maxHp, 10);
        public static Supplies ATKPotion = new Supplies("공격력 포션", ItemsType.Supplies, 10, StatusType.ATK, 10);
        public static Supplies DEFPotion = new Supplies("방어력 포션", ItemsType.Supplies, 10, StatusType.DEF, 10);
        public static Supplies STRPotion = new Supplies("무술능력 포션", ItemsType.Supplies, 10, StatusType.STR, 10);
        public static Supplies INTPotion = new Supplies("지력 포션", ItemsType.Supplies, 10, StatusType.INT, 10);
        public static Supplies mannerPotion = new Supplies("예법 포션", ItemsType.Supplies, 10, StatusType.manner, 10);
        public static Supplies sensiPotion = new Supplies("감수성 포션", ItemsType.Supplies, 10, StatusType.sensi, 10);

    }
}

