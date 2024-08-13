using System.Numerics;
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
        // 몬스터가 가지는 변수
        public string name;
        private int maxHp;
        public int nowHp;
        private int ATK;
        private int DEF;
        public int level;
        SceneType sceneType;

        Player player;

        public Monster(string name, int maxHp, int ATK, int DEF, int level, SceneType sceneType)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.ATK = ATK;
            this.DEF = DEF;
            this.level = level;
            this.sceneType = sceneType;
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
        public void MosterEnter()
        {
            Console.WriteLine($" 전방에 {name}이(가) 나타났다.");
        }
        public abstract void MonsterBattle();
        /*
         * MonsterEnter() - 몬스터 등장 함수
         * MonsterBattle() - 몬스터와의 전투 함수
         */
    }
}
