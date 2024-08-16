using KGA_OOPConsoleProject.Interface;
using KGA_OOPConsoleProject.Items;
using System.Numerics;

namespace KGA_OOPConsoleProject.Manager.ItemManager
{
    public class SuppliesManager : IItemManager
    {
        Player player;
        /// <summary>
        /// 소모품 아이템을 사용하여 능력치의 증감이 일어나는 함수
        /// </summary>
        public void UseItem(Item item)
        {
            switch (item.status)
            {
                case StatusType.maxHp:
                    
                    break;
                case StatusType.ATK:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" {player.name}의 공격력이 {item.plusValue}만큼 올랐다");
                    Console.WriteLine(" ===================================== ");
                    player.ATK += item.plusValue;
                    break;
                case StatusType.DEF:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" {player.name}의 방어력이 {item.plusValue}만큼 올랐다");
                    Console.WriteLine(" ===================================== ");
                    player.DEF += item.plusValue;
                    break;
                case StatusType.STR:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine($" {player.name}의 무술능력이 {item.plusValue}만큼 올랐다");
                    Console.WriteLine(" ===================================== ");
                    player.STR += item.plusValue;
                    break;
                case StatusType.INT:

                    break;
                case StatusType.manner:

                    break;
                case StatusType.sensi:

                    break;
                default:
                    break;
            }

        }
    }
}
