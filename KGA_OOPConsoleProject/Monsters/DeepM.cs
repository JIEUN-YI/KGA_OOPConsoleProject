using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 깊은 강가 맵에서 등장하는 몬스터들의 클래스
namespace KGA_OOPConsoleProject.Monsters
{
    public class DeepM : Monster
    {
        public DeepM(string name, int maxHp, int nowHp, int ATK, int DEF, int level, State nowState) : base(name, maxHp, nowHp, ATK, DEF, level, nowState)
        {

        }

        public static DeepM hugeToad = new DeepM("거대한 두꺼비", 15, 15, 2, 0, 2, State.Live);
        public static DeepM fierceHeron = new DeepM("사나운 왜가리", 30, 30, 10, 10, 3, State.Live);
        public static DeepM weirdCrane = new DeepM("어딘가 이상한 두루미", 40, 40, 20, 15, 4, State.Live);
        public static DeepM angryOtter = new DeepM("분노한 수달(보스)", 70, 70, 30, 30, 6, State.Live);
    }
}
