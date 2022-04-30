using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_Popups
{
    class Line : TwoPointFigure
    {
        public Line(int x, int y) // constructor
            : base(x, y) // 상위 클래스 constructor 호출
        {
        }

        // 선을 그리는 함수
        public override void draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, _x1, _y1, _x2, _y2);
        }
    }
}
