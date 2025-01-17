﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_XDrawer
{
    public class Box : TwoPointFigure
    {
        public Box(Popup popup, int x, int y) // constructor
           : base(popup, x, y) // 상위 클래스 constructor 호출
        {

        }

        public Box(Popup popup,int x1, int y1, int x2, int y2)
            : base(popup, x1, y1, x2, y2)
        {

        }

        public override void draw(Graphics g, Pen pen) // 상위 클래스인 Figure에서 재정의한 함수
        {
            // 시작 위치가 끝 위치보다 큰 경우 제대로 그려지지 않고 width와 height가 -값이 되면 사각형이 그려지지 않는다
            g.DrawRectangle(pen, Math.Min(this._x1, this._x2), Math.Min(this._y1, this._y2), Math.Abs(this._x2 - this._x1), Math.Abs(this._y2 - this._y1));
            // this 안써도 됨
        }
    }
}
