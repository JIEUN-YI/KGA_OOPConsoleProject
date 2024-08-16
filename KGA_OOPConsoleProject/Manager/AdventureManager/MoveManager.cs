using KGA_OOPConsoleProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 코멘트
 * IAdventure에서 Point를 이용하여 맵에서의 이동을 제어하는 클래스 제작
 */
namespace KGA_OOPConsoleProject.Manager.AdventureManager
{
    public class MoveManager : IAdventure
    {
        //public struct Point { public int x, y; }

        public IAdventure.Point Move(ConsoleKey inputKey, bool[,] map, IAdventure.Point playerPos, IAdventure.Point BossMobPos)
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
        public IAdventure.Point MoveUp(bool[,] map, IAdventure.Point playerPos, IAdventure.Point BossMobPos)
        {
            IAdventure.Point next = new IAdventure.Point() { x = playerPos.x, y = playerPos.y - 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public IAdventure.Point MoveDown(bool[,] map, IAdventure.Point playerPos, IAdventure.Point BossMobPos)
        {
            IAdventure.Point next = new IAdventure.Point() { x = playerPos.x, y = playerPos.y + 1 };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public IAdventure.Point MoveLeft(bool[,] map, IAdventure.Point playerPos, IAdventure.Point BossMobPos)
        {
            IAdventure.Point next = new IAdventure.Point() { x = playerPos.x - 1, y = playerPos.y };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }
        public IAdventure.Point MoveRight(bool[,] map, IAdventure.Point playerPos, IAdventure.Point BossMobPos)
        {
            IAdventure.Point next = new IAdventure.Point() { x = playerPos.x + 1, y = playerPos.y };
            if (map[next.y, next.x]) //이동할 위치가 true 이면
            {
                playerPos = next; //플레이어의 위치 변경
                return playerPos;
            }
            return playerPos;
        }

    }
}
