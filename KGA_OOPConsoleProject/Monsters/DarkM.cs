using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Monsters
{
    internal class DarkM : Monster
    {
        public DarkM(string name, int maxHp, int nowHp, int ATK, int DEF, int level, State nowState) : base(name, maxHp, nowHp, ATK, DEF, level, nowState)
        {

        }

        public static DarkM unknownMonster = new DarkM("정체를 알 수 없는 괴물", 85, 85, 30, 30, 6, State.Live);
        public static DarkM pollutionTiger = new DarkM("오염된 산군(보스)", 100, 100, 40, 40, 8, State.Live);
    }
}