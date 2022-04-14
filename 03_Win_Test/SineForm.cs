using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 그래픽스 객체의 사용법과 이전 콘솔 창의 가로 사인 그래프를 윈도에서 표현

namespace _03_Win_Test
{
    public partial class SineForm : Form
    {
        // 아래 부분은 이전 콘솔 창에서 가로 sine 그래프를 그리던 것
        static int XMAX = 60;
        static int YMAX = 20;
        static void drawSine(Graphics g)
        {
            double x = 0.0;
            double step = 2 * Math.PI / XMAX; // 2pi 값을 XMAX값으로 나눈 거
            char[,] screenBuffer = new char[YMAX + 2, XMAX + 1]; // 출력할 내용을 담을 2차원 배열

            Pen pen = new Pen(Color.Black); // 그림을 그릴 펜 객체 생성

            g.DrawLine(pen, 100, 100, 200, 200); // x y축 (100, 100) 과 (200 200) 에 선을 그음
            g.DrawEllipse(pen, 200, 100, 20, 20); // x y 좌표 200 100 자리에서 너비가 20 높이가 20인 원을 그림
            g.DrawEllipse(pen, 300, 100, 1, 1); // x y 좌표 400 200 자리에서 너비 높이가 1인 원을 그림(사실상 점)

            g.DrawLine(pen, 0, 0, 0, YMAX);
            g.DrawLine(pen, 0, YMAX / 2, XMAX, YMAX / 2);

            // sin 그래프를 그릴 * 좌표 저장
            for (int i = 0; i < XMAX + 1; i++)
            {
                double y; // 구할 sin 값
                int yPrime;

                x += step;
                y = Math.Sin(x);

                yPrime = (int)(-(YMAX / 2) * y + (YMAX / 2 + 1));

                // screenBuffer[yPrime, i] = '*';
                g.DrawEllipse(pen, i, yPrime, 1, 1); // 사인 그래프를 그릴 거
            }

        }
        public SineForm() // 생성자
        {
            InitializeComponent();
        }

        private void SineForm_Paint(object sender, PaintEventArgs e) // 윈도 화면에 그릴 이벤트
        {
            Graphics g = e.Graphics; // 윈도우 화면을 그릴 때 사용함

            drawSine(g); // 만들어놓은 함수 콜
        }

        private void SineForm_Load(object sender, EventArgs e)
        {

        }
    }
}
