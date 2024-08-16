using KGA_OOPConsoleProject.Items;
using System.Numerics;
/* 코멘트
 * ShopScene에서 사용할 아이템을 보여주고 구매하는 함수 모음
 * - 추후 판매도 업데이트 예정
 */
namespace KGA_OOPConsoleProject.Manager
{
    public class ShoppingManager
    {
        public Item[] productList = new Item[3]; // 임시로 3개를 판매해보기 위한 판매용 배열


        public Item item;
        public Player player = new();
        //public InventoryManager invenM;

        /// <summary>
        /// 판매 물품 배열에 저장
        /// </summary>
        public Item[] SetProduct()
        {
            productList[0] = Supplies.ATKPotion;
            productList[1] = Supplies.DEFPotion;
            productList[2] = Supplies.STRPotion;
            return productList;
        }

        /// <summary>
        /// 구매 아이템 보여주는 함수
        /// </summary>
        public void ShowItems()
        {
            for (int i = 0; i < productList.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {productList[i].name} / {productList[i].itemCost}G");
            }
        }


        /// <summary>
        /// 아이템 구매 함수
        /// </summary>
        public void Buy(string num, Item[] productList, int playerMoney)
        {
            switch (num)
            {
                case "1":
                    playerMoney -= productList[0].itemCost;
                    player.inventory.Add(productList[0]);
                    //invenM.InputInven(productList[0]);
                    break;
                case "2":
                    playerMoney -= productList[1].itemCost;
                    player.inventory.Add(productList[1]);
                    break;
                case "3":
                    playerMoney -= productList[2].itemCost;
                    player.inventory.Add(productList[2]);
                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// 아이템 판매 함수
        /// </summary>
        public void Selling()
        {

        }
    }
}
