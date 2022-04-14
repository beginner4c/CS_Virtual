using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_Sine_Graph
{
    public partial class Sine_Graph : Form
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
            g.DrawLine(pen, XORG, YORG+YMAX / 2, XORG + XMAX, YORG + YMAX / 2);

            // sin 그래프를 그릴 * 좌표 저장
            for (int i = 0; i < XMAX + 1; i++)
            {
                double y; // 구할 sin 값
                int yPrime;

                x += step;
                y = Math.Sin(x);

                yPrime = (int)(-(YMAX / 2) * y + (YMAX / 2 + YORG));

                g.DrawEllipse(pen, i + XORG, yPrime, 1, 1); // 사인 그래프를 그릴 점들을 이어보인다
            }

            Font font = new Font("Arial", 10); // 글자를 그릴 때 사용할 폰트 지정
            SolidBrush brush = new SolidBrush(Color.Black); // 글자 그릴 때 사용할 붓

            g.DrawString("Sine Graph", font, brush, XORG+10, YORG + YMAX);
        }

        public Sine_Graph()
        {
            InitializeComponent();
        }

        private void Sine_Graph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            drawSine(g);
        }

        private void Sine_Graph_Load(object sender, EventArgs e)
        {

        }
    }
}
