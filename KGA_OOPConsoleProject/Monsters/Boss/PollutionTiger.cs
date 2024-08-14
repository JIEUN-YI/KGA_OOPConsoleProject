using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KGA_OOPConsoleProject.Monsters.Boss
{
    public class PollutionTiger : Monster
    {
        public PollutionTiger() : base()
        {
            name = "오염된 산군(보스)";
            maxHp = 100;
            nowHp = maxHp;
            ATK = 40;
            DEF = 40;
            level = 8;
            nowState = State.Live;
        }
    }

}
