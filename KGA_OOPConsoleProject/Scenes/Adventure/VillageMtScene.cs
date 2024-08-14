/* 코멘트
 * 맵의 생성까지는 완료
 * 몬스터의 생성을 완료해야 장면에서의 행동(함수)들을 정의할 수 있을 듯
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class VillageMtScene : Scene, AdventureManager
    {
        public enum State { Live, Dead, Battle, Boss, Finish } // 시작, 살아있는 상태, 죽은 상태
        //public struct Point { public int x, y; } // 위치 표현을 하는 x, y 좌표
        public State nowState;

        Random ran = new Random(); // 랜덤을 사용
        // 마을 뒷 산 맵을 그리기 위해 사용
        private bool[,] map;
        private ConsoleKey inputKey; // 입력키 저장
        private AdventureManager.Point playerPos; // 플레이어의 위치
        private AdventureManager.Point BossMobPos; // 보스 몬스터의 위치

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
            }; // 지도 그리기
            playerPos.x = 1; playerPos.y = 1; // 플레이어 위치 설정
            BossMobPos.x = 16; BossMobPos.y = 16;// 보스 위치 설정
        }
        public override void Render()
        {
            switch (nowState)
            {
                case State.Live:
                    Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
                    AdventureManager.PrintMap(map);
                    AdventureManager.PrintPlayer(playerPos);
                    AdventureManager.PrintBoss(BossMobPos);
                    break;

                case State.Battle:
                    break;
                case State.Boss:
                    //콘솔 클리어 후
                    break;
                case State.Dead:

                    break;
                case State.Finish:

                    break;
            }
        }
        public override void Input()
        {
            if (nowState == State.Live)
            {
                inputKey = Console.ReadKey(true).Key; // 미로이므로 화살표를 입력받아야 함
            }
        }
        public override void Update()
        {
            switch (nowState)
            {
                case State.Live:
                    playerPos = AdventureManager.Move(inputKey, map, playerPos, BossMobPos);
                    if (AdventureManager.CheckReachBoss(playerPos, BossMobPos))
                    {
                        nowState = State.Boss;
                    }
                    //플레이어의 위치와 보스의 위치가 같으면
                    //상태를 보스로 변경
                    break;

                case State.Battle:
                    break;
                case State.Boss:
                    //보스 배틀 장면으로 이동
                    break;
                case State.Dead:

                    break;
                case State.Finish:

                    break;
            }
        }
        public override void Exit()
        {

        }

    }
}
