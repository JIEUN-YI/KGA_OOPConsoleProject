using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    // 아이템 생성 클래스
    public class Items
    {
        /*public struct Item
        {
            public string name;
            public ItemsType itemType;
            public int itemCost;
        }
        // 아이템 사용 변수
        /*public string name;
        public ItemsType type;
        public int cost;*/

        /*
         * name - string 타입 아이템 이름
         * type - Items 아이템 열거형 타입
         * cost - 아이템 구매 비용
         */

        /*// 아이템 별 사용 함수 - 상속으로 아이템의 변수를 상속받게 해서 아이템 종류를 제작 후 알맞은 함수 사용
        public abstract void UseItem();

        public abstract void EquipItem();

        public abstract void ShowItemEffect();
        /*
         * UseItem() - 인벤토리의 소모품 아이템(supplies)을 사용하는 함수
         *             보통 room에서 사용하거나 전투 중 소모품 사용
         *             아이템의 사용 효과 별로 능력치의 증감발생
         * EquipItem() - 인벤토리의 무기(weapon) 또는 방어구(device)를 착용하는 함수
         *               room에서 착용 가능 / 그 외 장소 불가
         *               무기나 방어구의 착용에 따라 능력치의 증감발생
         *               
         * ShowItemEffect() - 아이템의 효과를 보여주는 함수
         */
    }
}