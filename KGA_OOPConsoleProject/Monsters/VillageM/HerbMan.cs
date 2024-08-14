using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Monsters.VillageM
{
    public class HerbMan : Monster
    {
        public HerbMan() : base()
        {
            name = "약초꾼(마을사람)";
            maxHp = 20;
            nowHp = maxHp;
            ATK = 1;
            DEF = 1;
            level = 1;
            nowState = State.Live;
        }
    }
}