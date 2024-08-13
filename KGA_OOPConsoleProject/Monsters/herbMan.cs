using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Monsters
{
    public class herbMan : Monster
    {
        public herbMan(string name, int maxHp, int nowHp, int ATK, int DEF, int level, SceneType sceneType) :base(name,maxHp,ATK,DEF,level, sceneType)
        {
            name = "약초꾼";
            maxHp = 20;
            nowHp = maxHp;
            ATK = 1;
            DEF = 0;
            level = 1;
            sceneType = SceneType.VillageMt;
        }
        // 몬스터가 가지는 함수
        public override void MonsterBattle()
        {

        }
        /*
         * MonsterEnter() - 몬스터 등장 함수
         * MonsterBattle() - 몬스터와의 전투 함수
         */
    }
}