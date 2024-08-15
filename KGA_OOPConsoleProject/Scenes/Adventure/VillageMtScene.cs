/* 코멘트
 * 추후에 몬스터의 출몰 갯수를 조정하고 싶다.
 * 출몰 수를 조정 가능해지면 보스몬스터의 위치를 제외한 몬스터의 위치를 숨겨서
 * 어디에서 몬스터가 나올지 모르게 하는 것도 재미있을 것 같다.
 */
using KGA_OOPConsoleProject.Monsters;

namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class VillageMtScene : Scene
    {
        //public enum State { Start, Ing, End }
        public enum State { Start, Ing, Battle, AfterB, End } // 시작, 살아있는 상태, 죽은 상태
        public State nowState;
        Random ran = new Random(); // 랜덤을 사용

        BattleManager BaM = new BattleManager();
        AdventureManager AdM = new AdventureManager();
        Random random = new Random();
        Monster monster;

        // 마을 뒷 산 맵을 그리기 위해 사용
        private bool[,] map;
        private ConsoleKey inputKey; // 입력키 저장
        private AdventureManager.Point playerPos; // 플레이어의 위치
        private AdventureManager.Point bossMobPos; // 보스 몬스터의 위치
        private AdventureManager.Point mobPos;


        public VillageMtScene(GameData game, Player player) : base(game, player)
        {

        }
        // 맵은 장면에 들어오자마자 생성
        public override void Enter()
        {
            Console.CursorVisible = false; // 커서를 숨기는 기능
            map = new bool[,] // 이동가능지역 ture
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true,  true,  true, false, false,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false, false, false, false,  true, false, false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true, false, false, false, false,  true, false, false,  true,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false, false, false, false,  true,  true,  true,  true,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false, false, false, false, false, false, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true, false, false, false, false, false, false, false, false, false,  true,  true, false, false,  true, false },
                { false, false,  true, false, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true, false, false, false,  true,  true,  true,  true,  true,  true, false, false,  true,  true,  true, false },
                { false, false,  true, false, false, false,  true,  true, false, false, false, false, false, false, false, false,  true, false },
                { false, false,  true,  true, false,  true,  true,  true, false, false,  true,  true, false, false, false, false,  true, false },
                { false,  true,  true, false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false, false,  true, false },
                { false, false, false, false,  true, false, false,  true, false,  true, false, false,  true,  true, false, false,  true, false },
                { false, false, false,  true,  true,  true,  true,  true,  true,  true, false, false, false,  true, false,  true,  true, false },
                { false, false,  true,  true, false,  true,  true,  true,  true,  true, false, false, false,  true,  true, false, false, false },
                { false, false,  true, false, false,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false, false },
                { false,  true,  true, false, false, false, false, false, false, false,  true,  true,  true, false,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            }; // 지도 생성
            bossMobPos.x = 16; bossMobPos.y = 16;// 보스 위치 설정
        }
        public override void Render()
        {
            switch (nowState)
            {
                case State.Start:
                    Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
                    AdM.PrintMap(map);
                    AdM.PrintPlayer(playerPos);
                    AdM.PrintBoss(bossMobPos);
                    AdM.PrintMob(mobPos); //몬스터위치확인용
                    break;
                case State.Ing:
                    Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
                    AdM.PrintMap(map);
                    AdM.PrintPlayer(playerPos);
                    AdM.PrintBoss(bossMobPos);
                    if(AdM.mobState == AdventureManager.State.Live)
                    {
                    AdM.PrintMob(mobPos); //몬스터위치확인용_검사함수
                    }
                    break;
                case State.Battle:
                    Console.Clear();
                    break;
                case State.AfterB:
                    Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
                    AdM.PrintMap(map);
                    AdM.PrintPlayer(playerPos);
                    AdM.PrintBoss(bossMobPos);
                    break;
                case State.End:
                    Console.Clear();
                    break;
            }
        }
        public override void Input()
        {
            if (nowState == State.Ing || nowState == State.AfterB)
            {
                inputKey = Console.ReadKey(true).Key; // 미로이므로 화살표를 입력받아야 함
            }
        }
        public override void Update()
        {
            switch (nowState)
            {
                case State.Start:
                    playerPos.x = 1; playerPos.y = 1; // 플레이어 위치 설정
                    mobPos.x = 0; mobPos.y = 0;
                    mobPos = BaM.FieldMobPos(map, bossMobPos); // 몬스터위치 선정
                    nowState = State.Ing;
                    break;
                case State.Ing:
                    playerPos = AdM.Move(inputKey, map, playerPos, bossMobPos);

                    if (BaM.CheckReachMob(playerPos, bossMobPos))
                    {
                        nowState = State.End;
                        game.preScene = game.nowScene;
                        game.ChangeScene(SceneType.BossBattle);
                    }
                    // 플레이어의 위치와 보스의 위치가 같으면
                    // 상태를 보스로 변경
                    else if (BaM.CheckReachMob(playerPos, mobPos))
                    {
                        game.preScene = game.nowScene;
                        nowState = State.Battle;
                        game.ChangeScene(SceneType.Battle);
                    }
                    // 플레이어의 위치와 몬스터의 위치가 같으면
                    // 상태를 배틀로 변경
                    break;

                case State.Battle:
                    nowState = State.AfterB;
                    Console.Clear();
                    break;
                case State.AfterB:
                    playerPos = AdM.Move(inputKey, map, playerPos, bossMobPos);

                    if (BaM.CheckReachMob(playerPos, bossMobPos))
                    {
                        nowState = State.End;
                        game.ChangeScene(SceneType.BossBattle);
                    }
                    // 플레이어의 위치와 보스의 위치가 같으면
                    // 상태를 보스로 변경
                    break;
                case State.End:
                    nowState = State.Start;
                    game.ChangeScene(SceneType.AdventureSelect);
                    break;

            }
        }
        public override void Exit()
        {

        }

    }
}
