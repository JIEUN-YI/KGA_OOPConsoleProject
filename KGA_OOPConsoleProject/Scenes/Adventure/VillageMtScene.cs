/* 코멘트
 * 맵의 생성까지는 완료
 * 몬스터의 생성을 완료해야 장면에서의 행동(함수)들을 정의할 수 있을 듯
 */
using KGA_OOPConsoleProject.Monsters;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class VillageMtScene : Scene, AdventureManager
    {
        public enum State { Start, Battle, Boss, End  } // 시작, 살아있는 상태, 죽은 상태
        public State nowState;

        Random ran = new Random(); // 랜덤을 사용
        // 마을 뒷 산 맵을 그리기 위해 사용
        private bool[,] map;
        private ConsoleKey inputKey; // 입력키 저장
        private AdventureManager.Point playerPos; // 플레이어의 위치
        private AdventureManager.Point BossMobPos; // 보스 몬스터의 위치
        public Monster monster;
        //Monster bossMonster = new StrongTiger();

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
                case State.Start:
                    Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
                    AdventureManager.PrintMap(map);
                    AdventureManager.PrintPlayer(playerPos);
                    AdventureManager.PrintBoss(BossMobPos);
                    break;

                case State.Battle:
                    break;
                case State.Boss:
                    //콘솔 클리어 후
                    Console.Clear();
                    break;
                case State.End:
                    break;
            }
        }
        public override void Input()
        {
            if (nowState == State.Start)
            {
                inputKey = Console.ReadKey(true).Key; // 미로이므로 화살표를 입력받아야 함
            }
        }
        public override void Update()
        {
            switch (nowState)
            {
                case State.Start:
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
                    game.preScene = game.nowScene;
                    game.ChangeScene(SceneType.BossBattle);
                    nowState=State.End;
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
