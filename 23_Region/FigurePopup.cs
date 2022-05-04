using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23_Region
{
    public class FigurePopup : Popup
    {
        public FigurePopup(RegionForm view, String title, bool fillFlag) // constructor
            : base(view, title)
        {
            MenuItem deleteItem = new MenuItem(" 지우기 "); // 메뉴아이템 객체 생성
            _popupPtr.MenuItems.Add(deleteItem); // 메뉴 아이템 팝업에 추가

            MenuItem copyItem = new MenuItem(" 복사하기 ");
            _popupPtr.MenuItems.Add(copyItem);

            MenuItem[] colorPopup = new MenuItem[4]; // 팝업메뉴 안에 팝업 메뉴가 더 추가되는 아이템 객체
            colorPopup[0] = new MenuItem(" 검정색 "); // 색 표기
            colorPopup[1] = new MenuItem(" 빨강색 ");
            colorPopup[2] = new MenuItem(" 초록색 ");
            colorPopup[3] = new MenuItem(" 파랑색 ");
            _popupPtr.MenuItems.Add(" 색 정하기 ", colorPopup); // 팝업에 제목을 색 정하기로 해서 아이템 추가

            if (fillFlag == true)
            {
                MenuItem fillItem = new MenuItem(" 채우기 ");
                _popupPtr.MenuItems.Add(fillItem);
            }
        }
    }
}
