using KGA_OOPConsoleProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 코멘트
 * IAdventure를 이용하여 맵을 그리고 플레이어/몬스터/보스를 출력하기위한 클래스 제작
 */
namespace KGA_OOPConsoleProject.Manager
{
    public class PrintgMapManager : IAdventure
    {
        //public struct Point { public int x, y; }
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
        public void PrintPlayer(IAdventure.Point playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y); // 플레이어의 위치에 커서를 이동
            Console.ForegroundColor = ConsoleColor.Green; // 플레이어의 표시 색
            Console.Write("P");// 플레이어 출력
            Console.ResetColor();// 콘솔표시색을 리셋해야함
        }
        /// <summary>
        /// 보스몬스터의 위치를 표현하는 함수
        /// </summary>
        public void PrintBoss(IAdventure.Point BossMobPos)
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
        public void PrintMob(IAdventure.Point MobPos)
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

    }
}
