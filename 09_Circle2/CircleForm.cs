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

// 이전에는 점을 찍어 원을 그렸지만 이번에는 선을 통해 원을 그렸다
// 사실 원이 아니고 중심점을 기준으로 포인트를 잡아 NDOTS 만큼 선을 그리기 때문에 NDOTS가 100이라면 100각형인 것이다
// NDOTS를 낮은 수로 조절하면 정삼각형, 정사각형 등이 찍히게 된다

namespace _09_Circle2
{
    public partial class CircleForm : Form
    {
        // static int XMAX = 41;
        // static int YMAX = 41;
        static int XMAX = 500;
        static int YMAX = 500;
        static int XORG = XMAX / 2;
        static int YORG = YMAX / 2;
        static int NDOTS = 5; // 원을 그릴 때 사용할 점의 개수
        static int RADIUS = XMAX / 2 - 100; // 원의 반지름

        // 특정 좌표에 점을 찍는 함수
        static void drawPoint(Graphics g, int x, int y)
        {
            Pen pen = new Pen(Color.Black);

            g.DrawEllipse(pen, x, y, 1, 1); // 점 찍
        }
        // 원을 그리는 함수
        static void drawCircle(Graphics g)
        {
            double step = 2 * Math.PI / NDOTS;
            double theta = 0.0;
            Pen pen = new Pen(Color.Black);

            int oldX = (int)(RADIUS * Math.Cos(theta - Math.PI / 2)) + XORG;
            int oldY = (int)(RADIUS * Math.Sin(theta - Math.PI / 2)) + YORG;

            for (int i = 0; i < NDOTS + 1; i++) // NDOTS를 기준으로 한 경우 첫 좌표에서 그림이 그려지지 않기 때문에 NDOTS + 1 을 기준으로 한다
            {
                int x, y;

                x = (int)(RADIUS * Math.Cos(theta - Math.PI / 2)) + XORG; // 그릴 도형의 초기 위상을 잡기 때문에 / 2 의 경우 맨 위 꼭지점을 기준으로 한다
                y = (int)(RADIUS * Math.Sin(theta - Math.PI / 2)) + YORG;

                g.DrawLine(pen, oldX, oldY, x, y);

                oldX = x;
                oldY = y;

                theta += step;

            }
        }
            public CircleForm()
        {
            InitializeComponent();
        }

        private void CircleForm_Paint(object sender, PaintEventArgs e)
        {
            drawCircle(e.Graphics);
        }
    }
}
