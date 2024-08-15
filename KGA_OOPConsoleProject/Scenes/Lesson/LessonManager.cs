using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
/* 코멘트
 * Lesson 장면들에 공통으로 들어가는 함수들을 인터페이스로 빼와서 LessonManager을 생성하여
 * 인터페이스로 상속받아 사용하게끔 수정함
 * 근데...
 * 함수를 정의하는 것은 어짜피 각 장면에서 하게되는데, 인터페이스로 함수를 빼서 먼저 선언하고 작성하는 것이
 * 유지보수성향상/ 확장성 향상/ 다형성/ 코드재사용성 향상에 좋다고는 하는데
 * 직관적으로 느껴지지 않는 것 같다
 * 아니면 이 경우에는 굳이 추상으로 제작할 필요가 없었던 걸까...
 *  - Interface에 대한 이해가 아직 부족한 듯...
 */
namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    // Lesson 장면들의 공통적인 함수 생성 - 인터페이스로 사용
    public interface LessonManager
    {

        /// <summary>
        /// 수업 후 스탯 증감함수
        /// </summary>
        public abstract void UpgradeStatus();
        /// <summary>
        /// 수업 중 코멘트
        /// </summary>
        public abstract void LessonComment();
        /// <summary>
        /// 수업 후 코멘트
        /// </summary>
        public abstract void SelfComment();
    }

}
