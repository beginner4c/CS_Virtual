using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_Popups
{
    public abstract class Figure // 메인 폼에서 함수의 parameter로 활용하기 위해 public 선언
    {
        public Figure()
        {

        }
        public abstract void draw(Graphics g, Pen pen);

        public abstract void setXY2(int x, int y);
    }
}
