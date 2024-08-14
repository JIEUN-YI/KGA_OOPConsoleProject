using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes.Lesson
{
    // Lesson 장면들의 공통적인 함수 생성 - 인터페이스로 사용
    public interface LessonManager
    {

        /// <summary>
        /// 수업 후 스탯 증감함수
        /// </summary>
        public void UpgradeStatus();
        /// <summary>
        /// 수업 중 코멘트
        /// </summary>
        public void LessonComment();
        /// <summary>
        /// 수업 후 코멘트
        /// </summary>
        public void SelfComment();
    }

}
