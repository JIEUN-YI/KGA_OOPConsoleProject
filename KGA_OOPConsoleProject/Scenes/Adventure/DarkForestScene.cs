using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class DarkForestScene : Scene
    {
        public enum State { Start, Live, Dead } // 시작, 살아있는 상태, 죽은 상태
        public struct Point { public int x, y; } // 위치 표현을 하는 x, y 좌표
        public State nowState;
        Random ran = new Random(); // 랜덤을 사용
        // 마을 뒷 산 맵을 그리기 위해 사용
        private bool[,] map;
        private ConsoleKey inputKey; // 입력키 저장
        private AdventureManager.Point playerPos; // 플레이어의 위치
        private AdventureManager.Point BossMobPos; // 보스 몬스터의 위치
        public DarkForestScene(GameData game, Player player) : base(game, player)
        {

        }
        public override void Enter()
        {
            Console.CursorVisible = false; // 커서를 숨기는 기능
            map = new bool[,] // 이동가능지역 ture
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true, false, false,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false, false, false },
                { false,  true,  true,  true, false,  true, false, false, false,  true, false, false,  true, false, false, false,  true, false },
                { false, false,  true,  true,  true,  true,  true, false, false,  true, false, false,  true, false, false,  true,  true, false },
                { false, false, false,  true,  true, false,  true,  true,  true, false, false, false,  true, false, false,  true, false, false },
                { false, false, false,  true, false, false,  true, false,  true,  true, false, false,  true,  true, false,  true,  true, false },
                { false, false, false,  true, false, false,  true, false, false,  true,  true,  true, false,  true, false, false,  true, false },
                { false, false, false,  true, false, false,  true,  true, false, false, false,  true, false,  true, false, false,  true, false },
                { false, false, false,  true, false, false, false,  true,  true, false, false, false, false,  true,  true, false,  true, false },
                { false, false,  true,  true, false, false, false, false,  true,  true, false, false, false, false,  true, false,  true, false },
                { false,  true,  true, false, false, false, false, false, false,  true, false, false,  true, false,  true, false,  true, false },
                { false,  true, false, false, false, false, false, false, false,  true, false,  true,  true, false,  true,  true,  true, false },
                { false,  true, false, false, false, false, false, false,  true,  true, false,  true,  true, false,  true,  true, false, false },
                { false,  true, false, false, false, false, false, false,  true, false, false, false,  true,  true,  true,  true, false, false },
                { false,  true, false, false, false,  true,  true,  true,  true, false, false, false, false,  true, false,  true,  true, false },
                { false,  true, false, false,  true,  true, false, false,  true,  true, false,  true, false, false, false, false,  true, false },
                { false,  true,  true, false,  true, false, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            };
            playerPos.x = 1; playerPos.y = 1; // 플레이어 위치 설정
            BossMobPos.x = 16; BossMobPos.y = 2;// 보스 위치 설정
        }
        public override void Render()
        {
            Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
            AdventureManager.PrintMap(map);
            AdventureManager.PrintPlayer(playerPos);
            AdventureManager.PrintBoss(BossMobPos);
        }
        public override void Input()
        {
            inputKey = Console.ReadKey(true).Key; // 미로이므로 화살표를 입력받아야 함
        }
        public override void Update()
        {
            playerPos = AdventureManager.Move(inputKey, map, playerPos, BossMobPos);
            AdventureManager.CheckReachBoss(playerPos, BossMobPos);
        }
        public override void Exit()
        {

        }
    }
}