using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 이전 사인 그래프에서 수치 만져서 주기랑 진폭, 위상까지 조절해 봄
// 이전 사인 그래프는 x를 y보다 먼저 계산해서 한 픽셀 정도 잘못 그려졌는데 그거 돌려놓음

namespace _05_Sine_Graph2
{
    public partial class Form1 : Form
    {

        // 시작과 끝 좌표
        static int XORG = 100;
        static int YORG = 100;
        static int XMAX = 600;
        static int YMAX = 400;

        static void drawSine(Graphics g)
        {
            double x = 0.0;
            double step = 2 * Math.PI / XMAX; // 2pi 값을 XMAX값으로 나눈 거

            Pen pen = new Pen(Color.Black); // 그림을 그릴 펜 객체 생성

            g.DrawLine(pen, XORG, YORG, XORG, YORG + YMAX);
            g.DrawLine(pen, XORG, YORG + YMAX / 2, XORG + XMAX, YORG + YMAX / 2);

            // sin 그래프를 그릴 * 좌표 저장
            for (int i = 0; i < XMAX + 1; i++)
            {
                double y; // 구할 sin 값
                int yPrime;

                // y = Math.Sin(x);
                // y = 0.2 * Math.Sin(x); // 사인 그래프의 진폭 0.2배
                // y = Math.Sin(2.0*x); // 사인 그래프의 주기 2배
                // y = Math.Sin(x - 1.0); // 사인 그래프의 위상차이가 1 발생 - 처음 x 축에 닿기까지 1 radian 이 걸림
                // y = 0.2 * Math.Sin(20.0 * x); // 사인 그래프의 진폭이 0.2배 낮아지고 주기가 20배인 그래프 발생
                // y = 0.2 * Math.Sin(20.0 * x) * Math.Sin(x - 0.5); // 서로 다른 사인 그래프 두 개를 곱한 건데 모양이 신기하다
                y = 0.2 * Math.Sin(20.0 * x) + Math.Sin(x - 0.5); // 다른 사인 그래프 두 개를 더한 건데 왔다리 갔다리 한다

                x += step;

                yPrime = (int)(-(YMAX / 2) * y + (YMAX / 2 + YORG));

                g.DrawEllipse(pen, i + XORG, yPrime, 1, 1); // 사인 그래프를 그릴 점들을 이어보인다
            }

            Font font = new Font("Arial", 10); // 글자를 그릴 때 사용할 폰트 지정
            SolidBrush brush = new SolidBrush(Color.Black); // 글자 그릴 때 사용할 붓

            g.DrawString("Sine Graph", font, brush, XORG + 10, YORG + YMAX);
        }
            public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            drawSine(g);
        }
    }
}
