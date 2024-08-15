using KGA_OOPConsoleProject.Monsters;
/* 코멘트
 * AdventureManager 클래스를 상속받아서 동일한 변수를 사용하도록 설정
 * Point변수 때문에 상속으로 설정함
 */
namespace KGA_OOPConsoleProject.Scenes.Adventure
{
    public class BattleManager : AdventureManager
    {
        

        #region 배틀에 관련된 함수들
        /// <summary>
        /// 몬스터에게 도달했는지 확인
        /// 플레이어와 몬스터의 위치를 입력받아서 사용
        /// </summary>
        /// <param name="playerPos"></param>
        /// <param name="MobPos"></param>
        /// <returns></returns>
        public bool CheckReachMob(Point playerPos, Point MobPos)
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
        /// 보스몬스터 등장 출력함수
        /// BossBattleScene의 Enter()함수에 간단하게 사용하기 위해 제작
        /// </summary>
        /// <param name="preScene"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        public Monster BossEnter(Scene preScene)
        {
            Console.Clear();
            Monster monster = null;
            switch (preScene)
            {
                case VillageMtScene:
                    monster = VillageM.strongTiger;
                    Console.WriteLine(" ==== 마을 뒷 산 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    return monster;
                case DeepRiverScene:
                    monster = DeepM.angryOtter;
                    Console.WriteLine(" ==== 깊은 강가 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    return monster;
                case DarkForestScene:
                    monster = DarkM.pollutionTiger;
                    Console.WriteLine(" ==== 어두운 숲 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    return monster;
                default:
                    return monster;
            }
        }
        /// <summary>
        /// 필드몬스터 등장 출력함수
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
                    //return monster;
                case DeepRiverScene:
                    
                    Console.WriteLine(" ==== 깊은 강가 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    break;
                //return monster;
                case DarkForestScene:
                    
                    Console.WriteLine(" ==== 어두운 숲 ===================== ");
                    Console.WriteLine($" 전방에 {monster.name}이(가) 나타났다.");
                    Console.WriteLine(" ===================================== ");
                    Thread.Sleep(3000);
                    break;
                //return monster;
                default:
                    break;
                    //return monster;
            }
        }
        /// <summary>
        /// 필드몬스터 랜덤위치 생성
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="bossMobPos"></param>
        /// <returns></returns>
        public Point FieldMobPos(bool[,] Map, Point bossMobPos)
        {
            Random random = new Random();
            Point mobPos;
            int x = 0; int y = 0;
            mobPos.x = y; mobPos.y = x;

            while (Map[y, x] == false)
            {
                x = random.Next(1, 16);
                y = random.Next(1, 16);
                mobPos.x = x; mobPos.y = y;
            }
            if (mobPos.y != bossMobPos.y && mobPos.x != bossMobPos.x ) // 맵에서 이동가능 하고 보스몹 위치가 아닐 때
            {
                return mobPos;
            }
            return default;

        }
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
        public void BattleRender(Player player, Monster monster, State playerState, State monsterState)
        {
           
            
        }
        #endregion

    }
}
