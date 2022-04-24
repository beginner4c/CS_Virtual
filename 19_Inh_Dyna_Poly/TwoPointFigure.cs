using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_Inh_Dyna_Poly
{
    // 이 클래스도 abstract 클래스로 만들어줘야 한다
    // 이유는 abstract 클래스를 상속받은 이 곳에서 draw 함수를 override를 하지 않고 또 상속을 내리기 때문
    // instantiation 할 수 없는 클래스이다
    abstract class TwoPointFigure : Figure
    {
        // constructor
        public TwoPointFigure(int x, int y)
        {
            _x1 = _x2 = x;
            _y1 = _y2 = y;
        }
        // data member
        protected int _x1;
        protected int _y1;
        protected int _x2;
        protected int _y2;

        public override void draw(Graphics g, Pen pen)
        {
           
        }

        // set 함수
        public override void setXY2(int x, int y) // 상위 클래스인 Figure에서 재정의한 함수
        {
            _x2 = x;
            _y2 = y;
        }
    }
}
