using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Line_Circle
{
    class Line
    {
        public Line(int x, int y) // constructor
        {
            _x1 = _x2 = x;
            _y1 = _y2 = y;
        }
        // data member
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

        // 선을 그리는 함수
        public void draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, _x1, _y1, _x2, _y2);
        }

        // set 함수
        public void setXY2(int x, int y)
        {
            _x2 = x;
            _y2 = y;
        }
    }
}
