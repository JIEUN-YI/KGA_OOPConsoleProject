using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 코멘트
 * Adventure에 관련한 인터페이스
 * - (플레이어 / 몬스터 / 보스) 각각의 생존 상태 열거형과 위치(Point) 를 가지는 인터페이스
 * - GameData에 넣기에는 Adventure에 속한 Scene에서만 사용하고
 * - 클래스에 선언해서 사용하기에는 Adventure에 전체적으로 사용하며 하나의 클래스가 너무 많은 기능을 가지게 되어서 분할
 *  => 근데 이게 맞나...
 */
namespace KGA_OOPConsoleProject.Interface
{
    public interface IAdventure
    {
        public enum State { Live, Die }
        public struct Point { public int x, y; }

    }
}