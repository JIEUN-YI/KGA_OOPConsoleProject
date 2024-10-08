﻿using KGA_OOPConsoleProject.Interface;
using KGA_OOPConsoleProject.Monsters;
using KGA_OOPConsoleProject.Scenes;
using KGA_OOPConsoleProject.Scenes.Adventure;
/* 코멘트
 * IAdventure를 사용하여 Battle Scene에 사용하는 함수를 모은 클래스
 */
namespace KGA_OOPConsoleProject.Manager.AdventureManager
{
    public class BattleManager : IAdventure
    {
        public IAdventure.State playerState; // 플레이어 상태
        public IAdventure.State bossState; // 보스 상태
        public IAdventure.State mobState; // 몬스터 상태

        //public struct Point { public int x, y; }
        /// <summary>
        /// 몬스터에게 도달했는지 확인
        /// 플레이어와 몬스터의 위치를 입력받아서 사용
        /// </summary>
        /// <param name="playerPos"></param>
        /// <param name="MobPos"></param>
        /// <returns></returns>
        public bool CheckReachMob(IAdventure.Point playerPos, IAdventure.Point MobPos)
        {
            bool result = false;
            if (playerPos.x == MobPos.x && playerPos.y == MobPos.y)
            {
                result = true;
                return result;
            }
            return result;
        }

        /// <summary>
        /// 몬스터 등장 문구 출력
        /// </summary>
        /// <param name="preScene"></param>
        /// <param name="monster"></param>
        public void PrintMobEnter(Scene preScene, Monster monster)
        {
            Console.Clear();
            switch (preScene)
            {
                case VillageMtScene:
                    Console.WriteLine(" ==== 마을 뒷 산 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    break;
                case DeepRiverScene:

                    Console.WriteLine(" ==== 깊은 강가 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    break;
                case DarkForestScene:

                    Console.WriteLine(" ==== 어두운 숲 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 필드몬스터 랜덤위치 생성
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="bossMobPos"></param>
        /// <returns></returns>
        public IAdventure.Point FieldMobPos(bool[,] Map, IAdventure.Point bossMobPos, IAdventure.Point playerPos)
        {
            Random random = new Random();
            IAdventure.Point mobPos;
            int x = 0; int y = 0;
            mobPos.x = y; mobPos.y = x;
            // 맵에서 이동이 가능한 동안
            while (Map[y, x] == false)
            {
                x = random.Next(1, 16);
                y = random.Next(1, 16);
                mobPos.x = x; mobPos.y = y; // 좌표를 생성하고

                if (mobPos.y != bossMobPos.y && mobPos.x != bossMobPos.x) // 보스몹 위치가 아니고
                {
                    if (mobPos.y != playerPos.y && mobPos.x != playerPos.x) // 플레이어의 위치도 아니면
                    {
                        mobPos.x = x; mobPos.y = y;
                    }
                }
            }
            return mobPos;

        }


        /// <summary>
        /// 두 몬스터의 위치를 비교하는 함수
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="fieldMobPos1"></param>
        /// <param name="fieldMobPos2"></param>
        /// <returns></returns>
        /*public bool CheckOverlapMobPos(bool[,] Map, IAdventure.Point fieldMobPos1, IAdventure.Point fieldMobPos2)
        {
            bool result = false;
            if (fieldMobPos1.y == fieldMobPos2.y && fieldMobPos1.x == fieldMobPos2.x) // 두 몬스터의 위치를 비교
            {
                return result; // 같으면 false
            }
            result = true; // 다르면 true 반환
            return result;
        }*/

        /// <summary>
        /// 마을 뒷 산 몬스터 랜덤 생성 후 리턴
        /// </summary>
        /// <returns></returns>
        public Monster VillageFieldMobCreate()
        {
            Monster monster = null;
            Random random = new Random();
            int num = random.Next(0, 4);
            switch (num)
            {
                case 0:
                    monster = VillageM.herbMan;
                    return monster;
                case 1:
                    monster = VillageM.mildDeer;
                    return monster;
                case 2:
                    monster = VillageM.poorBoar;
                    return monster;
                case 3:
                    monster = VillageM.warnWolf;
                    return monster;
                default:
                    break;
            }
            return monster;
        }

        /// <summary>
        /// 깊은 강가 몬스터 랜덤 생성 후 리턴
        /// </summary>
        /// <returns></returns>
        public Monster DeepFieldMobCreate()
        {
            Monster monster = null;
            Random random = new Random();
            int num = random.Next(0, 3);
            switch (num)
            {
                case 0:
                    monster = DeepM.hugeToad;
                    return monster;
                case 1:
                    monster = DeepM.fierceHeron;
                    return monster;
                case 2:
                    monster = DeepM.weirdCrane;
                    return monster;
                default:
                    break;
            }
            return monster;
        }

        /// <summary>
        /// 어두운 숲 몬스터 랜덤 생성 후 리턴
        /// </summary>
        /// <returns></returns>
        public Monster DarkFieldMobCreate()
        {
            Monster monster = null;
            Random random = new Random();
            int num = random.Next(0, 3);
            switch (num)
            {
                case 0:
                    monster = VillageM.warnWolf;
                    return monster;
                case 1:
                    monster = DeepM.weirdCrane;
                    return monster;
                case 2:
                    monster = DarkM.unknownMonster;
                    return monster;
                default:
                    break;
            }
            return monster;
        }
    }
}
