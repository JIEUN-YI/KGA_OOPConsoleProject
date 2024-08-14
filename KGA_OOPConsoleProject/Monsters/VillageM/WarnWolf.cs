using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Monsters.VillageM
{
    public class WarnWolf : Monster
    {
        public WarnWolf() : base()
        {
            name = "경계하는 늑대";
            maxHp = 30;
            nowHp = maxHp;
            ATK = 12;
            DEF = 15;
            level = 3;
            nowState = State.Live;
        }
    }
}
