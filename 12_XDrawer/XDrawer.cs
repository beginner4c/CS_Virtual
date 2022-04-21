using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_XDrawer
{
    public partial class XDrawer : Form
    {
        int sX, sY;
        public XDrawer()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            sX = e.X;
            sY = e.Y;

            /*
            // MessageBox.Show("here"); // 이런 Modal Dialog는 중간의 다른 이벤트들을 무시하고 실행되기 때문에 동작이 중복될 땐 소용이 없다
            // Console.Beep(1000,1000); // 주파수와 시간을 인자로 받는데 주파수는 낮을수록 소리가 작고 시간은 1000이 1초
            // MessageBox.Show(e.X + "," + e.Y + "," + e.Button + "," + e.Clicks); // 커서의 x,y좌표와 좌,우버튼, 클릭 횟수 파악
            if(e.Clicks == 1) // 이 경우 더블 클릭을 하면 Beep은 두 번 발생한다
            {
                Console.Beep(10000, 100);
            }
            else
            {
                Console.Beep(100, 100);
            }
            */
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            int eX = e.X;
            int eY = e.Y;

            Graphics g = canvas.CreateGraphics(); // canvas 객체 안에서 사용하는 그래픽스 객체 생성
            Pen pen = new Pen(Color.Black);

            // 시작 위치가 끝 위치보다 큰 경우 제대로 그려지지 않고 width와 height가 -값이 되면 사각형이 그려지지 않는다
            g.DrawRectangle(pen, Math.Min(sX, eX), Math.Min(sY, eY), Math.Abs(eX - sX), Math.Abs(eY - sY));

            // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
            g.Dispose(); // garbage collection을 위해서 사용

            // MessageBox.Show("there");
        }
    }
}
