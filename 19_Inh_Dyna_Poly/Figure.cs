using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// abstract function이 있는 클래스는 반드시 abstract class로 만들어 주어야 한다
// abstract class는 instantiation을 할 수 없는 클래스를 의미한다

namespace _19_Inh_Dyna_Poly
{
    abstract class Figure
    {
        public Figure()
        {

        }
        public abstract void draw(Graphics g, Pen pen);

        public abstract void setXY2(int x, int y);
    }
}
