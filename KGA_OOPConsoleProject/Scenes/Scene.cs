using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    // 각 장면을 설정하기 위한 추상클래스 제작
    public abstract class Scene
    {
        // 사용하는 변수
        // GameData game 으로 불러오기
        protected GameData game;
        protected Player player;

        // 장면을 생성하는 경우 무조건 GameData 변수가 필요함 - 생성자 생성
        public Scene(GameData game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        // 각 장면에서 사용하는 함수
        public abstract void Enter();
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Exit();
        /*
         * Enter() - 장면에 입장
         * Render(); - 장면을 그리고
         * Input(); - 장면에 적절한 입력
         * Update(); - 장면에서의 동작을 설정
         * Exit(); // 장면에서 나옴
         */

    }
}
