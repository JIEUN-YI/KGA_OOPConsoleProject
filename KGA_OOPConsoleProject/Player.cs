using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject
{
    public class Player
    {
        // 플레이어가 필요로 하는 변수
        public GameData game;
        public string name;
        private TitleType[] titleTypes;
        private int money;
        public List<Item> inventory = new List<Item>(16);
        private Item[] equip = new Item[2];
        private int maxHp;
        private int nowMp;
        private int ATK;
        private int DEF;
        private int mCount;
        private int str;
        private int INT;
        private int manner;
        private int sensi;
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


        // 플레이어가 사용하는 함수
        public Player()
        {
            money = 500;
            maxHp = 10;
            ATK = 0;
            DEF = 0;
            mCount = 0;
            str = 0;
            INT = 0;
            manner = 0;
            sensi = 0;
        }
        private void ShowStatus()
        {
            // 스테이터스의 범위 지정
            Math.Clamp(money, 0, 99999999);
            Math.Clamp(maxHp, 0, 999);
            Math.Clamp(mCount, 0, 999);
            Math.Clamp(ATK, 0, 999);
            Math.Clamp(DEF, 0, 999);
            Math.Clamp(str, 0, 999);
            Math.Clamp(INT, 0, 999);
            Math.Clamp(manner, 0, 999);
            Math.Clamp(sensi, 0, 999);

            Console.WriteLine(" === 상태창 ========================== ");
            Console.WriteLine($" 체력   : {maxHp,+2}");
            Console.WriteLine($" 공격력 : {ATK,+2}");
            Console.WriteLine($" 방어력 : {DEF,+2}");
            Console.WriteLine($" 무술능력 : {str,+2}");
            Console.WriteLine($" 지력   : {INT,+2}");
            Console.WriteLine($" 예법   : {manner,+2}");
            Console.WriteLine($" 감수성 : {sensi,+2}");
            Console.WriteLine($" 사냥한 몬스터 수 : {mCount,+2}");
            Console.WriteLine($" 소지금 : {money,+2}G");
            Console.WriteLine(" ===================================== ");
            Console.WriteLine("     돌아가려면 아무키나 누르세요      ");
            Console.ReadKey();
            game.nowScene.Enter();
        }
        private void ShowInventory(List<Item> Inventory)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Inventory[i].name}");
                Console.WriteLine($"{Inventory[i].type,+4}");
                //Console.WriteLine($"{Inventory[i].effect,+4}");
                Console.WriteLine($"{Inventory[i].cost,+4}");
                Console.WriteLine(" ===================================== ");
                //name - string 타입 아이템 이름 type -Items 아이템 열거형 타입
                //effect -아이템 사용 효과 cost - 아이템 구매 비용*/
            }
        }
        private void PlayerDead()
        {
            Console.WriteLine(" ===================================== ");
            Console.WriteLine($" {name}이/가 체력이 0이 되었습니다. ");
            Console.WriteLine(" 집으로 돌아갑니다. ");
            Console.WriteLine(" ===================================== ");
            game.ChangeScene(SceneType.Room);
        }

        /*
         * ShowStatus() - 플레이어의 현재 스탯을 보여주는 함수 / Math.Clamp를 사용하여 최소값과 최대값을 지정
         * ShowInventory() - 플레이어가 가진 인벤토리를 보여주는 함수
         * PlayerDead() - 플레이어가 전투 중 사망 시 사용하는 함수
         */
    }
}
