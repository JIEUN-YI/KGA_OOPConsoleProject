using System.Numerics;
using System.Reflection.Metadata;
/* 코멘트
 * Monster()를 상속받는 BossMonster()/FieldMonster()를 제작하여
 * 그 안에서 보스몬스터와 필드몬스터를 생성하려고 하였으나
 * BattleScene으로 불러내는 것에 실패함
 * 몬스터를 구조체로 사용할까 하였으나 부모클래스인 Monster()에 있는 함수 사용이 필요함
 * => 각 맵 폴더 안에 각각의 몬스터를 클래스로 종류별로 구현
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

        public Monster(string name, int maxHp, int nowHp, int ATK, int DEF, int level, State nowState)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.nowHp = nowHp;
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
        public void MonsterAttack(Player player, Monster monster)
        {
            int monsterAttack = (int)(monster.ATK - player.DEF * 0.5);
            monsterAttack = Math.Clamp(monsterAttack, 0, 100);
            Console.WriteLine($" {monster.name}이(가) 반격을 시도한다!");
            Console.WriteLine($" {monsterAttack}의 데미지를 입었다.");
            Console.WriteLine(" ===================================== ");
            Thread.Sleep(2000);
            player.nowHp -= monsterAttack;
        }
        public bool MonsterLive(Player player, Monster monster)
        {
           bool result = true; //생존
           if(monster.nowHp <= 0)
            {
                monster.nowHp = 0;
                result = false; //사망
            }
            return result;

        }
    }
}
