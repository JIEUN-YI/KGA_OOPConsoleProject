using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGA_OOPConsoleProject.Scenes;
namespace KGA_OOPConsoleProject.Happeing
{
    // 각종 돌발이벤트 추상 클래스
    // 각종 돌발이벤트를 함수로 정의하고, 모험장면에서 각각 사용가능
    // 추상클래스로 선택한 이유 - 모험 장면에서 사용하는 돌발이벤트 별로 자식클래스로 사용하기 위함
    public abstract class Happening
    {
        // 돌발이벤트에서 사용하는 공통 변수
        Player player;
        GameData nowScene;
        /*
         * Player player - 플레이어의 정보를 사용하기 위함
         * GameData nowScene - 현재 장면 정보
         */

        // 추상클래스 사용 함수
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Exit();

        /* 
         * public abstract void Render(); - 각 돌발이벤트의 내용 출력
         * public abstract void Input(); - 각 돌발이벤트 선택지 선택
         * public abstract void Update(); - 각 돌발이벤트 선택지에 따른 스탯변화 저장
         * public abstract void Exit(); - 돌발이벤트 종료
         */
    }
}
