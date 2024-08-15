/* 코멘트
 * Point를 AdventureManager에서 선언하여 상속으로로 BattleManager에 연결
 * 전체적인 모험 장면에서 AdcenteurManager에 연결된 Point를 사용하는 것으로 정리
 * - 인터페이스로 사용을 고민
 *  => 상속으로 하는것도 딱히...좋은 선택인지는 의문
 */
using KGA_OOPConsoleProject.Monsters;

namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    //Adventure에 공통으로 들어갈 Move 함수 제작
    public class AdventureManager
    {
        public enum State { Live, Die }
        public State playerState; // 플레이어 상태
        public State bossState; // 보스 상태
        public State mobState; // 몬스터 상태
        public struct Point { public int x, y; } // 위치 표현을 하는 x, y 좌표
        public GameData game;

        #region 이동에 관련된 함수들
        /// <summary>
        /// 게임에서 플레이어의 이동
        /// inputKey를 받아서 이용하는 함수
        /// </summary>
        public Point Move(ConsoleKey inputKey, bool[,] map, Point playerPos, Point BossMobPos)
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
        public Point MoveUp(bool[,] map, Point playerPos, Point BossMobPos)
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y - 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public Point MoveDown(bool[,] map, Point playerPos, Point BossMobPos)
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y + 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public Point MoveLeft(bool[,] map, Point playerPos, Point BossMobPos)
        {
            Point next = new Point() { x = playerPos.x - 1, y = playerPos.y };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public Point MoveRight(bool[,] map, Point playerPos, Point BossMobPos)
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
        public void PrintMap(bool[,] map)
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
        public void PrintPlayer(Point playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y); // 플레이어의 위치에 커서를 이동
            Console.ForegroundColor = ConsoleColor.Green; // 플레이어의 표시 색
            Console.Write("P");// 플레이어 출력
            Console.ResetColor();// 콘솔표시색을 리셋해야함
        }
         /// <summary>
        /// 보스몬스터의 위치를 표현하는 함수
        /// </summary>
        public void PrintBoss(Point BossMobPos)
        {
            Console.SetCursorPosition(BossMobPos.x, BossMobPos.y); // 필드 보스의 위치에 커서를 이동
            Console.ForegroundColor = ConsoleColor.Red; // 필드 보스의 표시 색
            Console.Write("B");// 필드 보스 출력
            Console.ResetColor();
        }

        /// <summary>
        /// 임시함수 - 몬스터 위치 출력 검사 확인용
        /// </summary>
        /// <param name="MobPos"></param>
        public void PrintMob(Point MobPos)
        {
            // 보스몬스터와 다른 위치에서 생성된 경우에만 필드 몬스터 표시
            if (MobPos.x != 0 && MobPos.y != 0) 
            {
                Console.SetCursorPosition(MobPos.x, MobPos.y); // 필드 몬스터의 위치에 커서를 이동
                Console.ForegroundColor = ConsoleColor.Yellow; // 필드 몬스터의 표시 색
                Console.Write("M");
                Console.ResetColor();

            }
        }
        #endregion

    }
}

