using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 점을 그릴 클래스
// Point class의 경우 System.Drawing 에 라이브러리로 정의가 되어 있어서 다른 Point를 사용하는 클래스들에게 영향을 줄 수 있다
// 이런 문제점을 해결하기 위해서 다른 클래스들에서는 System.Drawing.Point라고 명확하게 정의해서 사용할 필요가 있어진다

namespace _24_XDrawer
{
    public class Point : OnePointFigure
    {
        public Point(Popup popup, int x, int y) // constructor
           : base(popup, x, y) // 상위 클래스 constructor 호출
        {

        }

        public override void draw(Graphics g, Pen pen) // 상위 클래스인 Figure에서 재정의한 함수
        {
            // 시작 위치가 끝 위치보다 큰 경우 제대로 그려지지 않고 width와 height가 -값이 되면 사각형이 그려지지 않는다
            g.DrawRectangle(pen, _x1 - Delta, _y1 - Delta, 2*Delta, 2*Delta);
            // this 안써도 됨
        }
    }
}
