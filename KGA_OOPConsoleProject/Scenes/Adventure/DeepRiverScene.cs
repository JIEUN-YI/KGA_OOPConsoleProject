using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class DeepRiverScene : Scene
    {
        public enum State { Start, Live, Dead } // 시작, 살아있는 상태, 죽은 상태
        public struct Point { public int x, y; } // 위치 표현을 하는 x, y 좌표
        public State nowState;
        Random ran = new Random(); // 랜덤을 사용
        // 마을 뒷 산 맵을 그리기 위해 사용
        private bool[,] map;
        private ConsoleKey inputKey; // 입력키 저장
        private Point playerPos; // 플레이어의 위치
        private Point BossMobPoss; // 보스 몬스터의 위치

        public DeepRiverScene(GameData game, Player player) : base(game, player)
        {

        }
        // 맵은 장면에 들어오자마자 생성
        public override void Enter()
        {
            Console.CursorVisible = false; // 커서를 숨기는 기능
            map = new bool[,] // 이동가능지역 ture
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true, false, false, false, false, false, false, false, false, false, false, false, false, false,  true, false },
                { false, false,  true, false,  true, false, false, false, false, false, false, false, false, false,  true, false,  true, false },
                { false, false,  true, false,  true, false, false, false,  true,  true,  true,  true,  true, false,  true, false,  true, false },
                { false, false,  true,  true,  true, false, false, false,  true, false, false, false,  true, false,  true, false,  true, false },
                { false,  true,  true,  true, false, false, false,  true,  true, false, false, false,  true,  true,  true, false,  true, false },
                { false,  true, false, false, false, false, false,  true, false, false, false, false, false,  true,  true, false,  true, false },
                { false,  true,  true, false, false, false, false,  true, false, false, false, false, false,  true, false, false,  true, false },
                { false, false,  true,  true, false, false, false,  true, false, false, false, false, false, false, false, false,  true, false },
                { false, false,  true,  true,  true,  true,  true,  true,  true, false, false, false, false, false, false,  true,  true, false },
                { false, false, false, false, false, false,  true, false,  true, false, false, false, false, false, false,  true,  true, false },
                { false, false, false, false, false, false,  true, false,  true, false,  true, false, false, false,  true,  true,  true, false },
                { false, false, false, false, false, false,  true, false,  true, false,  true, false, false,  true,  true,  true, false, false },
                { false, false, false, false, false, false,  true, false,  true, false,  true,  true,  true,  true,  true, false, false, false },
                { false, false, false, false, false, false,  true, false,  true, false,  true, false, false,  true, false, false, false, false },
                { false, false, false,  true,  true,  true,  true, false,  true,  true,  true, false, false,  true, false, false, false, false },
                { false, false,  true,  true,  true,  true, false, false,  true,  true,  true, false, false,  true, false, false, false, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            };
            playerPos = new Point() { x = 1, y = 1 };
            BossMobPoss = new Point() { x = 16, y = 1 };
        }
        public override void Render()
        {
            Console.SetCursorPosition(0, 0); //맵의 깜빡임을 없애기 위한 커서 위치 이동
            PrintMap();
            PrintPlayer();
            PrintBoss();
        }
        public override void Input()
        {
            inputKey = Console.ReadKey(true).Key; // 미로이므로 화살표를 입력받아야 함
        }
        public override void Update()
        {
            Move();
            CheckReachBoss();
        }
        public override void Exit()
        {

        }
        #region Update()에 사용되는 함수들
        /// <summary>
        /// 게임에서 플레이어의 이동
        /// </summary>
        public void Move()
        {
            // 입력받은 키 기반 움직임
            switch (inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
            }
        }
        /// <summary>
        /// 보스의 방에 도달했는지 확인
        /// </summary>
        public void CheckReachBoss()
        {
            if (playerPos.x == BossMobPoss.x && playerPos.y == BossMobPoss.y)
            {
                Console.Clear();//작동여부확인
                Console.WriteLine("보스");
                // 몬스터 배틀 시작
            }
        }

        public void MoveUp()
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y - 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
            }
        }
        public void MoveDown()
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y + 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
            }
        }
        public void MoveLeft()
        {
            Point next = new Point() { x = playerPos.x - 1, y = playerPos.y };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
            }
        }
        public void MoveRight()
        {
            Point next = new Point() { x = playerPos.x + 1, y = playerPos.y };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
            }
        }
        #endregion

        #region 맵에 관련된 함수들
        /// <summary>
        /// 맵을 그리는 함수
        /// 배열이므로 y축이 우선출력
        /// </summary>
        public void PrintMap()
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    //true인 이동가능지역
                    if (map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 플레이어의 위치를 표현하는 함수
        /// </summary>
        public void PrintPlayer()
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y); // 플레이어의 위치에 커서를 이동
            Console.ForegroundColor = ConsoleColor.Green; // 플레이어의 표시 색
            Console.Write("P");// 플레이어 출력
            Console.ResetColor();// 콘솔표시색을 리셋해야함
        }
        /// <summary>
        /// 보스몬스터의 위치를 표현하는 함수
        /// </summary>
        public void PrintBoss()
        {
            Console.SetCursorPosition(BossMobPoss.x, BossMobPoss.y); // 필드 보스의 위치에 커서를 이동
            Console.ForegroundColor = ConsoleColor.Red; // 필드 보스의 표시 색
            Console.Write("B");// 필드 보스 출력
            Console.ResetColor();
        }
        #endregion
    }
}
