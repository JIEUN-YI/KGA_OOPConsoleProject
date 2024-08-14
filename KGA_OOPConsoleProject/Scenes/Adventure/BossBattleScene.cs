using KGA_OOPConsoleProject.Monsters;
/* 코멘트
 * Render()와 Update() 함수를 좀 더 명확하게 구별하여 쓰는 방법을 연구할 필요가 있음
 * - 이중 스위치문을 사용하여 해결하고자 했으나 플레이어와 몬스터의 상태 2가지로 구별해야해서 적합하지 않음
 *      => 결국 Render에서 그리기만 하는 것이 아니라 상태를 업데이트도 동시에 진행함
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class BossBattleScene : Scene
    {
        public enum State { Live, Die }
        private State nowPlayerState;
        private State nowBossState;

        private string input;
        Monster monster;
        StrongTiger strongTiger = new StrongTiger();

        public BossBattleScene(GameData game, Player player) : base(game, player)
        {
            this.game = game;
            this.player = player;
        }

        public override void Enter()
        {
            switch (game.preScene)
            {
                case VillageMtScene:
                    nowPlayerState = State.Live;
                    nowBossState = State.Live;
                    Console.WriteLine(" ==== 마을 뒷 산 ===================== ");
                    Console.WriteLine($" 전방에 {strongTiger.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    break;
                case DarkForestScene:

                    break;
                case DeepRiverScene:

                    break;
                default:
                    break;
            }

        }
        public override void Render()
        {
            switch (game.preScene)
            {
                case VillageMtScene:
                    if (nowPlayerState == State.Live && nowBossState == State.Live)
                    {
                        Console.Clear();
                        Console.WriteLine(" === 몬스터 정보 ===================== ");
                        Console.WriteLine($" 이름 : {strongTiger.name,+3}");
                        Console.WriteLine($" 체력 : {strongTiger.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine(" === 내 정보 ========================= ");
                        Console.WriteLine($" 이름   : {player.name,+3}");
                        Console.WriteLine($" 체력   : {player.nowHp,+3}");
                        Console.WriteLine($" 공격력 : {player.ATK,+3}");
                        Console.WriteLine($" 방어력 : {player.DEF,+3}");
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine(" 1. 공격한다.");
                        Console.WriteLine(" 2. 도망친다.");
                        Console.WriteLine(" 3. 아이템");
                        Console.Write("선택 : ");
                    }
                    else if (nowPlayerState == State.Die) // 플레이어 사망 시
                    {
                        Console.Clear();
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {strongTiger.name}은/는 {player.name}을/를 \n 쓰려트렸다!");
                        Console.WriteLine($" {player.name}는 지고 말았다......");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        // 플레이어와 몬스터의 체력을 초기화하고 원래의 위치로 돌아감
                        nowPlayerState = State.Live; 
                        player.nowHp = player.maxHp;
                        monster.nowHp = monster.maxHp;
                        game.ChangeScene(SceneType.VillageMt);
                    }
                    else if (nowBossState == State.Die) // 몬스터 사망 시
                    {
                        Console.Clear();
                        Console.WriteLine(" ===================================== ");
                        Console.WriteLine($" {player.name}은/는 {strongTiger.name}을/를 \n 쓰려트렸다!");
                        Console.WriteLine($" {player.name}는 \" 마을 뒷 산을 정복한자\" \n 타이틀을 얻었다!");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        // 플레이어와 몬스터의 체력을 초기화하고 원래의 위치로 돌아감
                        player.nowHp = player.maxHp;
                        monster.nowHp = monster.maxHp;
                        player.playerTitle[0] = TitleType.VillageMtConqueror; // 업적 타이틀 획득
                        game.ChangeScene(SceneType.VillageMt);
                    }
                    break;
                case DarkForestScene:

                    break;
                case DeepRiverScene:

                    break;
                default:
                    break;
            }

        }
        public override void Input()
        {
            input = Console.ReadLine();
        }
        public override void Update()
        {
            switch (game.preScene)
            {
                case VillageMtScene:
                    if (nowPlayerState == State.Die)
                    {

                    }
                    monster = strongTiger;
                    StartBossBattle(input);
                    break;
                case DarkForestScene:
                    //monster = strongTiger;
                    StartBossBattle(input);
                    break;
                case DeepRiverScene:
                    //monster = strongTiger;
                    StartBossBattle(input);
                    break;
                default:
                    break;


            }
        }
        public override void Exit()
        {

        }
        public void StartBossBattle(string input)
        {
            switch (input)
            {
                case "1":
                    player.PlayerAttack(player, monster); //플레이어 공격
                    if(monster.MonsterLive(player, monster) == true)//몬스터 생존여부
                    {
                        Console.WriteLine(" === 몬스터 정보 ===================== ");
                        Console.WriteLine($" 이름 : {monster.name,+3}");
                        Console.WriteLine($" 체력 : {monster.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        monster.MonsterAttack(player, monster);//몬스터 반격
                        if (player.PlayerLive(player, monster) == false)//플레이어 생존여부
                        {
                            nowPlayerState = State.Die;
                        }
                        Console.WriteLine(" === 내 정보 ===================== ");
                        Console.WriteLine($" 이름 : {player.name,+3}");
                        Console.WriteLine($" 체력 : {player.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                    }
                    else if(monster.MonsterLive(player, monster) == false)
                    {
                        nowBossState = State.Die;
                    }

                    

                    break;
                case "2":
                    int result = player.PlayerRun(player, monster);
                    if (result == 1)
                    {
                        game.ChangeScene(SceneType.AdventureSelect);
                    }
                    break;
                case "3":
                    // 추후 인벤토리 추가 예정
                    break;
            }
        }

    }


}

