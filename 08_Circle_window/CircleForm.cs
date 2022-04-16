using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// 도스 창에서 그린 원을 윈도우 폼에서 그린다
// 여기서 좌표의 시작 부분인 1사분면의 경우 X가 양수, Y가 음수인 면이고 2사분면이 X가 음수 Y가 음수다

namespace _08_Circle_window
{
    public partial class CircleForm : Form
    {
        // static int XMAX = 41;
        // static int YMAX = 41;
        static int XMAX = 500;
        static int YMAX = 500;
        static int XORG = XMAX / 2;
        static int YORG = YMAX / 2;
        static int NDOTS = 100; // 원을 그릴 때 사용할 점의 개수
        static int RADIUS = XMAX / 2 - 100; // 원의 반지름
        
        // 특정 좌표에 점을 찍는 함수
        static void drawPoint(Graphics g, int x, int y)
        {
            Pen pen = new Pen(Color.Black);

            g.DrawLine(pen, XORG, YORG, x, y); // 시계의 침들 구현할 때 사용 가능
          //  g.DrawEllipse(pen, x, y, 1, 1); // 점 찍
        }
        // 원을 그리는 함수
        static void drawCircle(Graphics g)
        {
            double step = 2 * Math.PI / NDOTS;
            double theta = 0.0;

            for(int i =0; i<NDOTS; i++)
            {
                int x, y;

                x = (int)(RADIUS * Math.Cos(theta - Math.PI / 2)) + XORG;
                y = (int)(RADIUS * Math.Sin(theta - Math.PI / 2)) + YORG;

                drawPoint(g, x, y);

                theta += step;

                Thread.Sleep(10); // Thread 클래스의 슬립 함수, 그림을 천천히 그릴 때 사용, 0.01초만큼 기다렸다가 시작
            }
        }

        public CircleForm()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawCircle(e.Graphics);
        }
    }
}
