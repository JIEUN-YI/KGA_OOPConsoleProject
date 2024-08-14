using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Monsters.Boss
{
    public class StrongTiger : Monster
    {
        public StrongTiger() : base()
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
