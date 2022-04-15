using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 다항 함수 그래프를 그릴건데 X축 시작점은 -3 끝 점은 4
// Y축 시작점은 -24, 끝 점은 18
// 해서 그래프를 그릴 XY 축이 비대칭인 게 정상이다

namespace _06_Polynomial
{
    public partial class PolyForm : Form
    {
        // X Y 축 시작과 끝 좌표
        static int XORG = 100;
        static int YORG = 100;
        static int XMAX = 1000;
        static int YMAX = 400;
        // 시작할 X값과 끝 X값
        static double XSTART = -3.0;
        static double XFINISH = 4.0;
        // Y축을 조금 더 길게 잡기 위한 YGAP
        static int YGAP = 50;
        // X의 값이 -3부터 4까지인데 중간값 0을 잡기 위해 계산된 INTERVAL, Y축을 X축의 0 값에 맞추기 위해서
        static int INTERVAL = XMAX / (int)(XFINISH - XSTART);

        static void drawPoly(Graphics g)
        {
            double step = (XFINISH - XSTART) / (double)(XMAX); // 0.07 단위로 값이 바뀔 예정
            double x = XSTART; // 그래프를 출발시킬 위치

            Pen pen = new Pen(Color.Black);

            // Y축 그리기
            g.DrawLine(pen, XORG + 3 * INTERVAL, YORG - YGAP, XORG + 3 * INTERVAL, YORG + YMAX + YGAP); // X좌표는 X시작점부터 X좌표 0값에 맞추기, Y좌표는 YGAP만큼 추가
            // X축 그리기
            g.DrawLine(pen, XORG, (YORG + YMAX + 2 * YGAP) / 2, XORG+XMAX, (YORG + YMAX + 2 * YGAP) / 2); // X좌표는 시작과 끝에, Y 좌표는 YGAP의 크기를 제외하고 계산해 양수 범위가 짧게 음수 범위가 길게

            for(int i = 0; i < XMAX; i++)
            {
                double y; // 원래 함수 값
                int yPrime; // 선형 변환을 위해 사용할 정수 값

                y = x * x * x - 2.0 * x * x - 5 * x + 6; // f(x) = (x^3)-2(x^2)+x+6 의 다항함수

                yPrime = (int)(-1.0 * 10.0 * y + (YMAX / 2 + YORG)); // 10.0은 함수의 그래프 폭을 조절하는데 적당한 거 본인이 찾으면 된다

                g.DrawEllipse(pen, i + XORG, yPrime, 1, 1);

                x += step;
            }
        }

        public PolyForm()
        {
            InitializeComponent();
        }

        private void PolyForm_Paint(object sender, PaintEventArgs e)
        {
            drawPoly(e.Graphics);
        }
    }
}
