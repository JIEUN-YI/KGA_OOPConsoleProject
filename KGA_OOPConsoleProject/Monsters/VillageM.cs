using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
/* 코멘트
 * 마을 뒷 산 맵에서 등장하는 몬스터들의 클래스
 * 몬스터 클래스를 상속받아서 몬스터의 종류 5가지를 생성 후
 * 배틀씬에서 불러오는 것으로 사용
 *  - 기존에는 몬스터 종류별로 클래스로 상속받아서 사용하였으나, 이 방법이 깔끔해보여서 수정
 *  - 근데 이게 더 좋은지는 잘 모르겠지만 가독성적인 측면에서 보기에는 좋은 것 같다.
 */
namespace KGA_OOPConsoleProject.Monsters
{
    public class VillageM : Monster
    {
        public VillageM(string name, int maxHp, int nowHp, int ATK, int DEF, int level, State nowState) : base(name, maxHp, nowHp, ATK, DEF, level, nowState)
        {

        }

        public static VillageM herbMan = new VillageM("약초꾼(마을사람)", 20, 20, 1, 1, 1, State.Live);
        public static VillageM mildDeer = new VillageM("순한 사슴", 10, 10, 1, 0, 1, State.Live);
        public static VillageM poorBoar = new VillageM("둔한 멧돼지", 15, 15, 5, 5, 2, State.Live);
        public static VillageM warnWolf = new VillageM("경계하는 늑대", 30, 30, 12, 15, 3, State.Live);
        public static VillageM strongTiger = new VillageM("강인한 호랑이(보스)", 45, 45, 20, 20, 5, State.Live);

    }
}
