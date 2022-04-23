using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Box_Member_Function
{
    class Box
    {
        public Box(int x, int y) // constructor
        {
            _x1 = _x2 = x;
            _y1 = _y2 = y;
        }
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

        public void draw(Graphics g, Pen pen)
        {
            // 시작 위치가 끝 위치보다 큰 경우 제대로 그려지지 않고 width와 height가 -값이 되면 사각형이 그려지지 않는다
            g.DrawRectangle(pen, Math.Min(this._x1, this._x2), Math.Min(this._y1, this._y2), Math.Abs(this._x2 - this._x1), Math.Abs(this._y2 - this._y1));
            // this 안써도 됨
        }

        // set 함수
        public void setXY2(int x, int y)
        {
            _x2 = x;
            _y2 = y;
        }
    }
}
