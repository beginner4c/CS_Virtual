using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_XDrawer
{
    public abstract class Figure // 메인 폼에서 함수의 parameter로 활용하기 위해 public 선언
    {
        protected Popup _popup; // 각 그림마다 자기 팝업을 띄우기 위한 reference를 유지할 수 있게
        protected Region _region; // 이걸 상속받는 TwoPointFigure가 사용할 수 있게 visibility 설정

        public Figure(Popup popup)
        {
            _popup = popup;
        }
        public abstract void draw(Graphics g, Pen pen);

        public abstract void setXY2(int x, int y);

        public abstract void makeRegion();

        public bool ptInRegion(int x, int y) // 마우스 위치에 만들어진 region이 있는지 판별하는 함수
        {
            if (_region != null) // 마우스 위치에 만들어진 그림이 있으면
            {
                return _region.IsVisible(x, y); // 해당 좌표에 있다고 반환
            }
            else // 마우스 위치에 그림이 없으면
            {
                return false; // 없다고 반환
            }
        }

        public void popup(System.Drawing.Point pos) // 좌표를 받아서 상속받은 클래스들이 맞게 팝업을 할 수 있게
        {
            // Delegation 위임
            _popup.popup(pos);
        }
    }
}
