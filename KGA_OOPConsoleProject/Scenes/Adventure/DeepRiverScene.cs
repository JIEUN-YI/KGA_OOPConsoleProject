using KGA_OOPConsoleProject.Interface;
using KGA_OOPConsoleProject.Manager;
using KGA_OOPConsoleProject.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class DeepRiverScene : Scene
    {
        public enum State { Start, Ing, Battle, AfterB, End } // 시작, 살아있는 상태, 죽은 상태
        public State nowState;

        MoveManager moveM = new();
        PrintgMapManager printM = new();
        BattleManager battleM = new();

        Random random = new Random();
        Monster monster;

        //맵을 그리기 위해 사용
        private bool[,] map;
        private ConsoleKey inputKey; // 입력키 저장
        private IAdventure.Point playerPos; // 플레이어의 위치
        private IAdventure.Point bossMobPos; // 보스 몬스터의 위치
        private IAdventure.Point fieldMobPos; //필드 몬스터의 위치


        public DeepRiverScene(GameData game, Player player) : base(game, player)
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
               /* 1*/{ false,  true,  true, false, false, false, false, false, false, false, false, false, false, false, false, false,  true, false },
               /* 2*/{ false, false,  true, false,  true, false, false, false, false, false, false, false, false, false,  true, false,  true, false },
               /* 3*/{ false, false,  true, false,  true, false, false, false,  true,  true,  true,  true,  true, false,  true, false,  true, false },
               /* 4*/{ false, false,  true,  true,  true, false, false, false,  true, false, false, false,  true, false,  true, false,  true, false },
               /* 5*/{ false,  true,  true,  true, false, false, false,  true,  true, false, false, false,  true,  true,  true, false,  true, false },
               /* 6*/{ false,  true, false, false, false, false, false,  true, false, false, false, false, false,  true,  true, false,  true, false },
               /* 7*/{ false,  true,  true, false, false, false, false,  true, false, false, false, false, false,  true, false, false,  true, false },
               /* 8*/{ false, false,  true,  true, false, false, false,  true, false, false, false, false, false, false, false, false,  true, false },
               /* 9*/{ false, false,  true,  true,  true,  true,  true,  true,  true, false, false, false, false, false, false,  true,  true, false },
               /*10*/{ false, false, false, false, false, false,  true, false,  true, false, false, false, false, false, false,  true,  true, false },
               /*11*/{ false, false, false, false, false, false,  true, false,  true, false,  true, false, false, false,  true,  true,  true, false },
               /*12*/{ false, false, false, false, false, false,  true, false,  true, false,  true, false, false,  true,  true,  true, false, false },
               /*13*/{ false, false, false, false, false, false,  true, false,  true, false,  true,  true,  true,  true,  true, false, false, false },
               /*14*/{ false, false, false, false, false, false,  true, false,  true, false,  true, false, false,  true, false, false, false, false },
               /*15*/{ false, false, false,  true,  true,  true,  true, false,  true,  true,  true, false, false,  true, false, false, false, false },
               /*16*/{ false, false,  true,  true,  true,  true, false, false,  true,  true,  true, false, false,  true, false, false, false, false },
               /*17*/{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            };
            bossMobPos.x = 16; bossMobPos.y = 1;// 보스 위치 설정
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
                    if (battleM.mobState == IAdventure.State.Live)
                    {
                        printM.PrintMob(fieldMobPos); //몬스터위치확인용_검사함수
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
                    playerPos.x = 1; playerPos.y = 1; // 플레이어 위치 설정
                    fieldMobPos.x = 0; fieldMobPos.y = 0;
                    fieldMobPos = battleM.FieldMobPos(map, bossMobPos, playerPos); // 몬스터위치 선정
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
                    else if (battleM.CheckReachMob(playerPos, fieldMobPos))
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
