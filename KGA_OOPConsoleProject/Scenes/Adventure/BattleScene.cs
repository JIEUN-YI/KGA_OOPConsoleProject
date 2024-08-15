using KGA_OOPConsoleProject.Interface;
using KGA_OOPConsoleProject.Manager;
using KGA_OOPConsoleProject.Monsters;
/* 코멘트
 * Battle씬 하나에서
 * 이전 장면별 분기 + 일반 필드 몬스터 배틀 or 보스 몬스터 배틀 기능을 구현
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class BattleScene : Scene
    {
        /*public enum State { Live, Die }
        private State nowPlayerState; // 플레이어 상태
        private State nowBossState; // 보스 상태
        private State nowMobState; // 몬스터 상태*/

        private string input; // 입력

        Monster monster;
        BattleManager battleM = new();

        public BattleScene(GameData game, Player player) : base(game, player)
        {
            this.game = game;
            this.player = player;
        }
        public override void Enter()
        {

            switch (game.preScene)
            {
                case VillageMtScene:
                    monster = battleM.VillageFieldMobCreate(); // 랜덤생성몬스터 저장
                    battleM.PrintMobEnter(game.preScene, monster);
                    break;
                case DeepRiverScene:
                    monster = battleM.DeepFieldMobCreate(); // 랜덤생성몬스터 저장
                    battleM.PrintMobEnter(game.preScene, monster);
                    break;
                case DarkForestScene:
                    monster = battleM.DarkFieldMobCreate(); // 랜덤생성몬스터 저장
                    battleM.PrintMobEnter(game.preScene, monster);
                    break;
                default:

                    break;
            }
        }
        public override void Render()
        {
            if (battleM.playerState == IAdventure.State.Live && battleM.mobState == IAdventure.State.Live)
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
            else if (battleM.playerState == IAdventure.State.Die) // 플레이어 사망 시
            {
                Console.Clear();
                Console.WriteLine(" ===================================== ");
                Console.WriteLine($" {monster.name}은/는 {player.name}을/를 \n 쓰려트렸다!");
                Console.WriteLine($" {player.name}는 지고 말았다......");
                Console.WriteLine(" ===================================== ");
                Thread.Sleep(2000);
                // 플레이어와 몬스터의 체력을 초기화하고 원래의 위치로 돌아감
                player.nowHp = player.maxHp;
                monster.nowHp = monster.maxHp;
                game.ChangeScene(game.preScene);
            }
            else if (battleM.mobState == IAdventure.State.Die) // 몬스터 사망 시
            {
                Console.Clear();
                Console.WriteLine(" ===================================== ");
                Console.WriteLine($" {player.name}은/는 {monster.name}을/를 \n 쓰려트렸다!");
                Console.WriteLine(" ===================================== ");
                Thread.Sleep(2000);
                // 플레이어와 몬스터의 체력을 초기화하고 원래의 위치로 돌아감
                player.nowHp = player.maxHp;
                monster.nowHp = monster.maxHp;
                game.ChangeScene(game.preScene);
            }
        }
        public override void Input()
        {
            if (battleM.playerState == IAdventure.State.Live && battleM.mobState == IAdventure.State.Live)
            {
                input = Console.ReadLine();
            }
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
                            battleM.playerState = IAdventure.State.Die;
                        }
                        Console.WriteLine(" === 내 정보 ========================= ");
                        Console.WriteLine($" 이름 : {player.name,+3}");
                        Console.WriteLine($" 체력 : {player.nowHp,+3}");
                        Console.WriteLine(" ===================================== ");
                        Thread.Sleep(2000);
                    }
                    else if (monster.MonsterLive(monster) == false)
                    {
                        battleM.mobState = IAdventure.State.Die;
                    }
                    break;
                case "2":
                    int result = player.PlayerRun(player, monster);
                    if (result == 0)
                    {
                        game.ChangeScene(game.preScene);
                    }
                    break;
                case "3":
                    // 추후 인벤토리 추가 예정
                    break;
            }
        }
            
        
        public override void Exit()
        {
            battleM.mobState = IAdventure.State.Live;
            battleM.bossState = IAdventure.State.Live;
        }

    }
}

