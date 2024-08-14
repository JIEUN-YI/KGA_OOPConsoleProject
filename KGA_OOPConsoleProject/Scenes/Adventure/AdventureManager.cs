using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 코멘트
 * Adventure 장면들에 공통으로 들어가는 함수들을 인터페이스로 빼와서 AdventureManager을 생성하여
 * 인터페이스로 상속받아 사용하게끔 설정
 * Move에 관련한 함수들은 공통으로 움직이는 설정이 필요한게 맞음으로 인터페이스에서 작성하여 상속시켜 사용하기 좋을 것 같음
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    //Adventure에 공통으로 들어갈 Move 함수 제작
    public interface AdventureManager
    {
        public struct Point { public int x, y; } // 위치 표현을 하는 x, y 좌표
        #region 이동에 관련된 함수들
        /// <summary>
        /// 게임에서 플레이어의 이동
        /// inputKey를 받아서 이용하는 함수
        /// </summary>
        public static Point Move(ConsoleKey inputKey, bool[,] map, Point playerPos, Point BossMobPos)
        {
            // 입력받은 키 기반 움직임
            switch (inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    playerPos = MoveUp(map, playerPos, BossMobPos);
                    return playerPos;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    playerPos = MoveDown(map, playerPos, BossMobPos);
                    return playerPos;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    playerPos = MoveLeft(map, playerPos, BossMobPos);
                    return playerPos;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    playerPos = MoveRight(map, playerPos, BossMobPos);
                    return playerPos;
            }
            return playerPos;
        }
        /// <summary>
        /// 보스의 방에 도달했는지 확인
        /// 플레이어와 보스의 위치를 입력받아서 사용
        /// </summary>
        public static void CheckReachBoss(Point playerPos, Point BossMobPos)
        {
            if (playerPos.x == BossMobPos.x && playerPos.y == BossMobPos.y)
            {
                Console.Clear();//작동여부확인
                Console.WriteLine("보스");
                // 몬스터 배틀 시작
            }
        }

        public static Point MoveUp(bool[,] map, Point playerPos, Point BossMobPos)
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y - 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public static Point MoveDown(bool[,] map, Point playerPos, Point BossMobPos)
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y + 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public static Point MoveLeft(bool[,] map, Point playerPos, Point BossMobPos)
        {
            Point next = new Point() { x = playerPos.x - 1, y = playerPos.y };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public static Point MoveRight(bool[,] map, Point playerPos, Point BossMobPos)
        {
            Point next = new Point() { x = playerPos.x + 1, y = playerPos.y };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        #endregion

        #region 맵에 관련된 함수들
        /// <summary>
        /// 맵을 그리는 함수
        /// 배열이므로 y축이 우선출력
        /// </summary>
        public static void PrintMap(bool[,] map)
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
        public static void PrintPlayer(Point playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y); // 플레이어의 위치에 커서를 이동
            Console.ForegroundColor = ConsoleColor.Green; // 플레이어의 표시 색
            Console.Write("P");// 플레이어 출력
            Console.ResetColor();// 콘솔표시색을 리셋해야함
        }
        /// <summary>
        /// 보스몬스터의 위치를 표현하는 함수
        /// </summary>
        public static void PrintBoss(Point BossMobPos)
        {
            Console.SetCursorPosition(BossMobPos.x, BossMobPos.y); // 필드 보스의 위치에 커서를 이동
            Console.ForegroundColor = ConsoleColor.Red; // 필드 보스의 표시 색
            Console.Write("B");// 필드 보스 출력
            Console.ResetColor();
        }
        #endregion
    }
}

