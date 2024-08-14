using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Monsters
{
    public class StrongTiger : Monster
    {
        public StrongTiger(string name, int maxHp, int ATK, int DEF, int level, State nowState) : base(name, maxHp, ATK, DEF, level, nowState)
        {
            name = "강인한 호랑이(보스)";
            maxHp = 45;
            nowHp = maxHp;
            ATK = 20;
            DEF = 20;
            level = 5;
            nowState = State.Live;
        }

    }

}
