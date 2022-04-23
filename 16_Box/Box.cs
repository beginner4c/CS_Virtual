using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 만들어낼 혹은 만든 사각형들의 좌표를 저장할 클래스

namespace _16_Box
{
    class Box
    {
        public Box(int x, int y) // constructor
        {
            x1 = x2 = x;
            y1 = y2 = y;
        }
        public int x1;
        public int y1;
        public int x2;
        public int y2;
    }
}
