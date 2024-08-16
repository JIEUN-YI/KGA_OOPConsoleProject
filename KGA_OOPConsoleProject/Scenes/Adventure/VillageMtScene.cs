/* 코멘트
 * 추후에 몬스터의 출몰 갯수를 조정하고 싶다.
 * - 몬스터들끼리 위치가 겹치지 않게 조정하는 함수를 BatteleManager에 CheckOverlapMobPos()로 제작
 *   => 문제는 위치가 겹치지 않게 조정하여 생성은 가능하였으나 몬스터 배틀 이후
 *      만났던 몬스터만 사라지게 하는 것에 실패
 *   => 우선은 몬스터 하나만 출력되는 것으로 진행
 * 출몰 수를 조정 가능해지면 보스몬스터의 위치를 제외한 몬스터의 위치를 숨겨서
 * 어디에서 몬스터가 나올지 모르게 하는 것도 재미있을 것 같다.
 * 
 */
using KGA_OOPConsoleProject.Interface;
using KGA_OOPConsoleProject.Manager;
using KGA_OOPConsoleProject.Monsters;

namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class VillageMtScene : Scene, IAdventure
    {
        public enum State { Start, Ing, Battle, AfterB, End } // 시작, 살아있는 상태, 죽은 상태
        public State nowState;

        MoveManager moveM = new();
        PrintgMapManager printM = new();
        BattleManager battleM = new();

        Random random = new Random();
        Monster monster;

        // 마을 뒷 산 맵을 그리기 위해 사용
        private bool[,] map;
        private ConsoleKey inputKey; // 입력키 저장
        private IAdventure.Point playerPos; // 플레이어의 위치
        private IAdventure.Point bossMobPos; // 보스 몬스터의 위치
        private IAdventure.Point fieldMobPos1; //필드 몬스터1의 위치

        /* 2개의 몬스터 출력을 하려고 제작중이던 소스코드
         * private IAdventure.Point fieldMobPos2; //필드 몬스터2의 위치
         * private IAdventure.State fieldMobState1; //필드 몬스터 1의 상태
         * private IAdventure.State fieldMobState2; //필드 몬스터 2의 상태*/

        public VillageMtScene(GameData game, Player player) : base(game, player)
        {

        }
        // 맵은 장면에 들어오자마자 생성
        public override void Enter()
        {
            Console.CursorVisible = false; // 커서를 숨기는 기능
            map = new bool[,] // 이동가능지역 ture
            {
           /*       0       1       2     3       4      5     6      7       8     9      10    11      12     13     14     15     16     17*/
           /* 0*/{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
           /* 1*/{ false,  true,  true,  true,  true,  true,  true, false, false,  true,  true,  true,  true,  true,  true, false,  true, false },
           /* 2*/{ false,  true, false, false, false, false,  true, false, false,  true,  true,  true,  true,  true,  true,  true,  true, false },
           /* 3*/{ false,  true, false, false, false, false,  true, false, false,  true,  true, false,  true,  true,  true,  true,  true, false },
           /* 4*/{ false,  true, false, false, false, false,  true,  true,  true,  true,  true, false,  true,  true,  true,  true,  true, false },
           /* 5*/{ false,  true, false, false, false, false, false, false, false, false, false, false,  true,  true,  true,  true,  true, false },
           /* 6*/{ false,  true,  true, false, false, false, false, false, false, false, false, false,  true,  true, false, false,  true, false },
           /* 7*/{ false, false,  true, false, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
           /* 8*/{ false,  true,  true, false, false, false,  true,  true,  true,  true,  true,  true, false, false,  true,  true,  true, false },
           /* 9*/{ false, false,  true, false, false, false,  true,  true, false, false, false, false, false, false, false, false,  true, false },
           /*10*/{ false, false,  true,  true, false,  true,  true,  true, false, false,  true,  true, false, false, false, false,  true, false },
           /*11*/{ false,  true,  true, false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false, false,  true, false },
           /*12*/{ false, false, false, false,  true, false, false,  true, false,  true, false, false,  true,  true, false, false,  true, false },
           /*13*/{ false, false, false,  true,  true,  true,  true,  true,  true,  true, false, false, false,  true, false,  true,  true, false },
           /*14*/{ false, false,  true,  true, false,  true,  true,  true,  true,  true, false, false, false,  true,  true, false, false, false },
           /*15*/{ false, false,  true, false, false,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false, false },
           /*16*/{ false,  true,  true, false, false, false, false, false, false, false,  true,  true,  true, false,  true,  true,  true, false },
           /*17*/{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            }; // 지도 생성
            bossMobPos.x = 16; bossMobPos.y = 16;// 보스 위치 설정
        }
        public override void Render()
        {
            switch (nowState)
            {
                case State.Start:
                    break;
                case State.Ing:
                    Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
                    printM.PrintMap(map);
                    printM.PrintPlayer(playerPos);
                    printM.PrintBoss(bossMobPos);
                    if (battleM.mobState == IAdventure.State.Live) // 몬스터의 생존 시에만 출력
                    {
                        printM.PrintMob(fieldMobPos1);
                    }

                    break;
                case State.Battle:
                    Console.Clear();
                    break;
                case State.AfterB:
                    Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
                    printM.PrintMap(map);
                    printM.PrintPlayer(playerPos);
                    printM.PrintBoss(bossMobPos);
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
                    bool result = false;
                    playerPos.x = 1; playerPos.y = 1; // 플레이어 위치 설정
                    fieldMobPos1.x = 0; fieldMobPos1.y = 0;
                    fieldMobPos1 = battleM.FieldMobPos(map, bossMobPos, playerPos); // 몬스터가 다른 것과 겹치지 않게 생성
                    /* 두 몬스터의 위치를 선정 후 위치가 겹치는지 비교
                     * 다르면 둘 다 사용 - true
                     * 같으면 fieldMobPos2의 위치를 재선정 - false
                     
                    fieldMobPos1 = battleM.FieldMobPos(map, bossMobPos, playerPos); // 1번 필드몬스터 위치 선정
                    while (result == false)
                    {
                        fieldMobPos2 = battleM.FieldMobPos(map, bossMobPos, playerPos);
                        result = battleM.CheckOverlapMobPos(map, fieldMobPos1, fieldMobPos2); // 2번 필드몬스터 위치 선정
                    }*/
                    nowState = State.Ing;
                    break;
                case State.Ing:
                    playerPos = moveM.Move(inputKey, map, playerPos, bossMobPos);

                    // 플레이어의 위치와 보스의 위치가 같으면
                    // 상태를 보스로 변경
                    if (battleM.CheckReachMob(playerPos, bossMobPos))
                    {
                        nowState = State.End;
                        game.preScene = game.nowScene;
                        game.ChangeScene(SceneType.BossBattle);
                    }
                    // 플레이어의 위치와 몬스터의 위치가 같으면
                    // 상태를 배틀로 변경
                    else if (battleM.CheckReachMob(playerPos, fieldMobPos1))
                    {
                        game.preScene = game.nowScene;
                        nowState = State.Battle;
                        game.ChangeScene(SceneType.Battle);
                    }
                    break;

                case State.Battle:
                    nowState = State.AfterB;
                    Console.Clear();
                    break;
                case State.AfterB:
                    playerPos = moveM.Move(inputKey, map, playerPos, bossMobPos);

                    // 플레이어의 위치와 보스의 위치가 같으면
                    // 상태를 보스로 변경
                    if (battleM.CheckReachMob(playerPos, bossMobPos))
                    {
                        nowState = State.End;
                        game.ChangeScene(SceneType.BossBattle);
                    }
                    break;
                case State.End:
                    nowState = State.Start;
                    game.ChangeScene(SceneType.AdventureSelect);
                    break;

            }
        }
        public override void Exit()
        {
            battleM.playerState = IAdventure.State.Live;
        }

    }
}
