namespace KGA_OOPConsoleProject.Interface
{
    public interface IItem
    {
        public struct Item
        {
            public string name;
            public ItemsType itemType;
            public int itemCost;
        }

        public void UseItem(); // 타입별로 사용되는 방식이 다름

    }
}
