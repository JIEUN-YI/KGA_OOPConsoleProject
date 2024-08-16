using KGA_OOPConsoleProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 코멘트
 * 아이템의 종류별로 사용하는 함수의 정의가 다르기때문에
 * 인터페이스로 선언 후 각각의 Manager클래스에서 정의
 */
namespace KGA_OOPConsoleProject.Interface
{
    public interface IItemManager
    {
        public void UseItem(Item item);
    }
}
