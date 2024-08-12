using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Player
    {
        // 플레이어가 필요로 하는 변수
        /* 이름 - string 타입
         * title - Title[] 열거형 타입 / 업적은 여러개를 가질 수 있음
         * money - int 타입
         * inventory - Item 타입 리스트로 제작 / 아이템은 여러개를 가질 수 있음
         * equip - Item[] 타입 / 무기(weapon)타입과 방어구(device) 타입을 하나씩 저장
         * 각종 스텟 변수들
         * MaxHp - int형 최대체력 / CurHp - int형 현재체력 / Atk - int형 공격력 / Def - int형 방어력
         * / mCount - int형 몬스터 처리 수 
         * Str - int형 무술능력 Int - int형 지력 / Manner - int형 예법 / Sensi - int형 감수성 : 수업으로 올라가는 스탯
         * + Atk은 무술능력에서 계산해서 저장하는 편이 좋을 것 같다
         */


        // 플레이어가 사용하는 함수
        /*
         * ShowStatus() - 플레이어의 현재 스탯을 보여주는 함수 / Math.Clamp를 사용하여 최소값과 최대값을 지정
         * ShowInventory() - 플레이어가 가진 인벤토리를 보여주는 함수
         * PlayerDead() - 플레이어가 전투 중 사망 시 사용하는 함수
         */
    }
}
