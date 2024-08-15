using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 코멘트
 * Scene을 부모클래스로 가지는 장면들이 너무 많아짐
 *  - 하나의 클래스에 연관된 클래스가 많은 갓클래스? 가 이 경우인지 생각해봄
 *  - 하지만 씬을 상속받아서 공통되는 부분이 많은 것은 사실이라 이 경우 어떤식으로 씬을 따로 쪼갤 수 있는가
 *    고민하게 됨
 *  => 아마 씬을 쪼갠다면 Scene / AdventureScene / LessonScene 으로 부모클래스를 3개로 만들고
 *     자식 클래스로 분류한다면 하나의 클래스에 쏠림 현상을 막을 수 있을 것 같다.
 *     근데, 어짜피 공통인 부분은 같은데 이렇게 나누는 게 더 효율이 좋은지는...?
 */
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
