using KGA_OOPConsoleProject.Interface;
using KGA_OOPConsoleProject.Monsters;
using KGA_OOPConsoleProject.Items;
using System.Threading;
/* 코멘트
 * 업적을 스택으로 구현
 * - 배열과 리스트로 고민해보았으나, 변동 없이 저장만 한다는 점에서 스택이 좋을 것 같아서 스택으로 사용
 * - 엔딩이나 출력시에는 contain함수로 획득 여부를 확인하면 좋을 것 같음
 * 플레이어의 스탯 / 게임일수 / 최대 스탯은 게임 난이도에 따라서 조절 필수
 * - 임의로 10일동안 최대스탯 100으로 설정
 */
namespace KGA_OOPConsoleProject
{
    public class Player
    {
        // 플레이어가 필요로 하는 변수
        public GameData game;
        public string name;
        public Stack<TitleType> Titles =new Stack<TitleType>(3);
        public int money;
        public List<Item> inventory = new List<Item>(16); // 아이템을 저장하는 인벤토리 용량 16의 리스트
        public List<Item> equip = new List<Item>(2); // 무기/방어구 아이템을 장비하는 장비칸 리스트로 제작
        // public Item[] equip = new Item[2]; 
        public int maxHp;
        public int nowHp;
        public int ATK;
        public int DEF;
        public int mCount;
        public int STR;
        public int INT;
        public int manner;
        public int sensi;

        Random ran = new Random();
        /* 이름 - string 타입
         * title - Title[] 열거형 타입 / 업적은 여러개를 가질 수 있음
         * money - int 타입
         * inventory - Item 타입 리스트로 제작 / 아이템은 여러개를 가질 수 있음
         * equip - Item[] 타입 / 무기(weapon)타입과 방어구(device) 타입을 하나씩 저장
         * 각종 스텟 변수들
         * MaxHp - int형 최대체력 / nowHp - int형 현재체력 / Atk - int형 공격력 / Def - int형 방어력
         * / mCount - int형 몬스터 처리 수 
         * Str - int형 무술능력 Int - int형 지력 / Manner - int형 예법 / Sensi - int형 감수성 : 수업으로 올라가는 스탯
         * + Atk은 무술능력에서 계산해서 저장하는 편이 좋을 것 같다
         */


        public Player() // 플레이어 생성자 - 플레이어 기본 값
        {
            money = 500;
            maxHp = 50;
            ATK = 50;
            DEF = 15;
            mCount = 0;
            STR = 0;
            INT = 0;
            manner = 0;
            sensi = 0;
        }
        // 플레이어가 사용하는 함수
        /// <summary>
        /// 스탯을 정리하여 보여주는 함수
        /// </summary>
        /// <param name="game"></param>
        public void ShowStatus(GameData game)
        {
            money = Math.Clamp(money, 0, 99999999);
            maxHp = Math.Clamp(maxHp, 0, 100); // 임시제작 능력치 100 - 최대 능력치는 게임 기간 대비로 조절 필수
            mCount = Math.Clamp(mCount, 0, 100);
            ATK = Math.Clamp(ATK, 0, 100);
            DEF = Math.Clamp(DEF, 0, 100);
            STR = Math.Clamp(STR, 0, 100);
            INT = Math.Clamp(INT, 0, 100);
            manner = Math.Clamp(manner, 0, 100);
            sensi = Math.Clamp(sensi, 0, 100);
            // 스테이터스의 범위 지정
            Console.Clear();
            Console.WriteLine(" === 상태창 ========================== ");
            Console.WriteLine($" 이름 : {name,-2}");
            Console.WriteLine($" 체력   : {maxHp,-2}");
            Console.WriteLine($" 공격력 : {ATK,-2}");
            Console.WriteLine($" 방어력 : {DEF,-2}");
            Console.WriteLine($" 무술능력 : {STR,-2}");
            Console.WriteLine($" 지력   : {INT,-2}");
            Console.WriteLine($" 예법   : {manner,-2}");
            Console.WriteLine($" 감수성 : {sensi,-2}");
            Console.WriteLine($" 사냥한 몬스터 수 : {mCount,-2}");
            Console.WriteLine($" 소지금 : {money,-2}G");
            Console.WriteLine(" ===================================== ");
            Console.WriteLine(" 획득한 업적 ");
            ShowTitle();
            Console.WriteLine(" ===================================== ");
            Console.WriteLine();
            Console.WriteLine("     돌아가려면 아무키나 누르세요      ");
            game.nowScene.Enter();
        }
        /// <summary>
        /// 인벤토리 구성 함수 - 추후 다시 구상하기
        /// </summary>
        /// <param name="Inventory"></param>
        private void ShowInventory(List<Item> Inventory)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Inventory[i].name}");
                Console.WriteLine($"{Inventory[i].itemType,+4}");
                Console.WriteLine($"{Inventory[i].itemCost,+4}");
                Console.WriteLine(" ===================================== ");
                //name - string 타입 아이템 이름 type -Items 아이템 열거형 타입
                //cost - 아이템 구매 비용*/
            }
        }
        /// <summary>
        /// 플레이어가 몬스터를 공격하는 함수
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monster"></param>
        public void PlayerAttack(Player player, Monster monster)
        {
            int playerAttack = (int)(player.ATK - monster.DEF * 0.5);
            playerAttack = Math.Clamp(playerAttack, 0, 100);
            Console.Clear();
            Console.WriteLine(" ===================================== ");
            Console.WriteLine($" {player.name}은(는) 힘껏 공격했다!");
            Console.WriteLine($" {playerAttack}의 데미지를 입혔다.");
            Console.WriteLine(" ===================================== ");
            Thread.Sleep(2000);
            monster.nowHp -= playerAttack;
        }
        /// <summary>
        /// 플레이어의 생존 여부 확인 함수
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        public bool PlayerLive(Player player)
        {
            if (player.nowHp <= 0)
            {
                player.nowHp = 0;
                return false;//사망
            }
            return true;//생존
        }
       /// <summary>
       /// 플레이어의 도망 함수
       /// </summary>
       /// <param name="player"></param>
       /// <param name="monster"></param>
       /// <returns></returns>
        public int PlayerRun(Player player, Monster monster)
        {
            int num = ran.Next(0, 2);
            int result = 0;
            switch (num)
            {            
                case 0:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" 도망에 실패했다!");
                    Console.WriteLine(" ===================================== ");
                    monster.MonsterAttack(player, monster);
                    if(PlayerLive(player) == false)
                    {

                        result = 0;// 플레이어 사망
                    }
                    else
                    {
                        result = 1;// 플레이어 생존
                    }
                    Thread.Sleep(2000);
                    return result;
                case 1:
                    Console.Clear();
                    Console.WriteLine(" ===================================== ");
                    Console.WriteLine(" \"휴~\"");
                    Console.WriteLine(" 무사히 도망에 성공했다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    result = 0;// 플레이어 도망 성공
                    break;
            }
            return result;
        }

        /// <summary>
        /// 획득한 타이틀을 스택에 저장하는 함수
        /// </summary>
        /// <param name="getTitle"></param>
        public void GetTitle(TitleType getTitle)
        {
            Titles.Push(getTitle);
        }

        /// <summary>
        /// 획득한 업적을 출력하는 함수
        /// </summary>
        public void ShowTitle()
        {
            if (Titles.Contains(TitleType.VillageMtConqueror))
            {
                Console.WriteLine("마을 뒷 산을 정복한 자");
            }
            if (Titles.Contains(TitleType.DeepRiverConqueror))
            {
                Console.WriteLine("깊은 강가를 정복한 자");
            }
            if (Titles.Contains(TitleType.DarkForestConqueror))
            {
                Console.WriteLine("어두운 숲을 정복한 자");
            }

        }


        /*
         * ShowStatus() - 플레이어의 현재 스탯을 보여주는 함수 / Math.Clamp를 사용하여 최소값과 최대값을 지정
         * ShowInventory() - 플레이어가 가진 인벤토리를 보여주는 함수
         * PlayerDead() - 플레이어가 전투 중 사망 시 사용하는 함수
         */
    }
}
