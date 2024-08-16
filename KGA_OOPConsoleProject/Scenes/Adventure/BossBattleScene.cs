using KGA_OOPConsoleProject.Manager.AdventureManager;
using KGA_OOPConsoleProject.Monsters;
/* 코멘트
 * Render()와 Update() 함수를 좀 더 명확하게 구별하여 쓰는 방법을 연구할 필요가 있음
 * - 스위치문과 if문의 중복말고 다른 방법이 있지 않을까 고민됨
 * 
 * 보스 몬스터를 처치 후 타이틀을 획득하고 획득한 타이틀을 알려주는 알고리즘을 추가하고 싶으나 추가하지 못함
 * - game.preScene 데이터에 따라서 타이틀의 종류가 달라짐
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class BossBattleScene : Scene
    {
        public enum State { Live, Die }
        private State nowPlayerState;
        private State nowBossState;
        public string titleName;
        public TitleType getTitle;

        private string input;

        Monster monster;
        BattleManager battleM = new();

        public BossBattleScene(GameData game, Player player) : base(game, player)
        {
            //this.game = game;
            //this.player = player;
        }

        public override void Enter()
        {
            nowPlayerState = State.Live;
            nowBossState = State.Live;

            switch (game.preScene)
            {
                case VillageMtScene:
                    monster = VillageM.strongTiger;
                    titleName = " 마을 뒷 산을 정복한 자 ";
                    getTitle = TitleType.VillageMtConqueror;
                    battleM.PrintMobEnter(game.preScene, monster);
                    break;
                case DeepRiverScene:
                    monster = DeepM.angryOtter;
                    titleName = " 깊은 강가를 정복한 자 ";
                    getTitle = TitleType.DeepRiverConqueror;
                    battleM.PrintMobEnter(game.preScene, monster);
                    break;
                case DarkForestScene:
                    monster = DarkM.pollutionTiger;
                    titleName = " 어두운 숲을 정복한 자 ";
                    getTitle = TitleType.DarkForestConqueror;
                    battleM.PrintMobEnter(game.preScene, monster);
                    break;
                default:

                    break;
            }

        }
        public override void Render()
        {
            if (nowPlayerState == State.Live && nowBossState == State.Live)
            {
                Console.Clear();
                Console.WriteLine(" === 몬스터 정보 ===================== ");
                Console.WriteLine($" 이름 : {monster.name,+3}");
                Console.WriteLine($" 체력 : {monster.nowHp,+3}");
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
                Console.WriteLine($" {monster.name}은/는 \n {player.name}을/를 쓰려트렸다!");
                Console.WriteLine($" {player.name}는 지고 말았다......");
                Console.WriteLine(" ===================================== ");
                Thread.Sleep(2000);
                // 원래의 위치로 돌아감
                game.ChangeScene(game.preScene);

            }
            else if (nowBossState == State.Die) // 몬스터 사망 시
            {
                Console.Clear();
                Console.WriteLine(" ===================================== ");
                Console.WriteLine($" {player.name}은/는 {monster.name}을/를 \n 쓰려트렸다!");
                Console.WriteLine($" {player.name}은/는 {titleName}타이틀을 얻었다!");
                Console.WriteLine(" ===================================== ");
                Thread.Sleep(2000);
                // 원래의 위치로 돌아감
                // 업적 타이틀 획득
                player.GetTitle(getTitle);
                player.mCount++;
                game.ChangeScene(game.preScene);
            }
        }
        public override void Input()
        {
            input = Console.ReadLine();
        }
        public override void Update()
        {
            switch (input)
            {
                case "1":
                    player.PlayerAttack(player, monster); //플레이어 공격
                    if (monster.MonsterLive(monster) == true)//몬스터 생존여부
                    {
                        Console.WriteLine(" === 몬스터 정보 ===================== ");
                        Console.WriteLine($" 이름 : {monster.name,+3}");
                        Console.WriteLine($" 체력 : {monster.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        monster.MonsterAttack(player, monster);//몬스터 반격
                        if (player.PlayerLive(player) == false)//플레이어 생존여부
                        {
                            nowPlayerState = State.Die;
                        }
                        Console.WriteLine(" === 내 정보 ===================== ");
                        Console.WriteLine($" 이름 : {player.name,+3}");
                        Console.WriteLine($" 체력 : {player.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                    }
                    else if (monster.MonsterLive(monster) == false)
                    {
                        nowBossState = State.Die;
                    }
                    break;
                case "2":
                    int result = player.PlayerRun(player, monster);
                    if (result == 0)
                    {
                        nowPlayerState = State.Die;
                    }
                    game.ChangeScene(game.preScene);
                    break;
                case "3":
                    // 추후 인벤토리 추가 예정
                    break;
            }
        }
        public override void Exit()
        {

        }

        /*/// <summary>
        /// 전투 진행 함수
        /// </summary>
        /// <param name="input"></param>
        private void StartBossBattle(string input)
        {
            switch (input)
            {
                case "1":
                    player.PlayerAttack(player, monster); //플레이어 공격
                    if (monster.MonsterLive(monster) == true)//몬스터 생존여부
                    {
                        Console.WriteLine(" === 몬스터 정보 ===================== ");
                        Console.WriteLine($" 이름 : {monster.name,+3}");
                        Console.WriteLine($" 체력 : {monster.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                        monster.MonsterAttack(player, monster);//몬스터 반격
                        if (player.PlayerLive(player) == false)//플레이어 생존여부
                        {
                            nowPlayerState = State.Die;
                        }
                        Console.WriteLine(" === 내 정보 ===================== ");
                        Console.WriteLine($" 이름 : {player.name,+3}");
                        Console.WriteLine($" 체력 : {player.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                    }
                    else if (monster.MonsterLive(monster) == false)
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

        /// <summary>
        /// 이전 장면 별 장면 전환 함수
        /// </summary>
        /// <param name="preScene"></param>

        private void ChangeScene(Scene preScene)
        {
            switch (game.preScene)
            {
                case VillageMtScene:
                    game.ChangeScene(SceneType.VillageMt);
                    break;
                case DeepRiverScene:
                    game.ChangeScene(SceneType.DeepRiver);
                    break;
                case DarkForestScene:
                    game.ChangeScene(SceneType.DarkForest);
                    break;
                default:
                    break;


            }
        }*/

    }


}

