using System.Numerics;
using System.Reflection.Metadata;
/* 코멘트
 * MonsterBattle() 함수 추상화가 아니라
 * PlayAttack()함수 / MonsterAttack()함수 를 따로 작성하고
 * 그걸 이용해서 MosterBattle()함수를 작성하는 것이 Scene에서 사용하기 용이할 것 같음
 * 추상화에 대해 조금 더 고민할 것
 */
namespace KGA_OOPConsoleProject.Monsters
{
    // 몬스터 종류별로 가지고 있는 클래스 제작
    public abstract class Monster
    {
        public enum State { Live, Dead }
        // 몬스터가 가지는 변수
        public string name;
        public int maxHp;
        public int nowHp;
        public int ATK;
        public int DEF;
        public int level;

        public State nowState;

        Player player;
        GameData game;

        public Monster(string name, int maxHp, int ATK, int DEF, int level, State nowState)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.nowState = nowState;
            this.ATK = ATK;
            this.DEF = DEF;
            this.level = level;
            this.nowState = nowState;
        }
        /* 
         * 이름 - string 타입
         * MaxHp - int형 최대 체력
         * CurHp - int형 현재 체력
         * Atk - int형 공격력
         * Def - int형 방어력
         * level - int형 몬스터의 레벨
         * 출몰장소 - Scenes 열거형 타입
         */
        // 몬스터가 가지는 함수
        /// <summary>
        /// 몬스터가 플레이어를 공격하는 함수
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monster"></param>
        public int MonsterAttack(Player player, Monster monster)
        {
            int monsterAttack = (int)(monster.ATK - player.DEF * 0.5);
            player.nowHp -= monsterAttack;
            return player.nowHp;
        }

    }
}
