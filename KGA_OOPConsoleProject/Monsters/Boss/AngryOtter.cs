using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KGA_OOPConsoleProject.Monsters.Boss
{
    public class AngryOtter : Monster
    {
        public AngryOtter() : base()
        {
            name = "분노한 수달(보스)";
            maxHp = 70;
            nowHp = maxHp;
            ATK = 30;
            DEF = 30;
            level = 6;
            nowState = State.Live;
        }
    }
}
