using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_Star
{
    public partial class StarForm : Form
    {
        static int NDOTS = 5; // 꼭지점의 개수 

        // 특정 좌표에 점을 찍는 함수
        static void drawPoint(Graphics g, int x, int y)
        {
            Pen pen = new Pen(Color.Black);

            g.DrawEllipse(pen, x, y, 1, 1); // 점 찍
        }

        static void drawStar(Graphics g, int ox, int oy, int r)
        {
            double step = 2 * Math.PI / NDOTS;
            double theta = 0.0;
            Pen pen = new Pen(Color.Black);
            Point[] pt = new Point[2 * NDOTS]; // Point 클래스는 X와 Y를 데이터 멤버로 가지고 있다


            for (int i = 0; i < NDOTS; i++)
            {
                int x, y;

                x = (int)(r * Math.Cos(theta - Math.PI / 2)) + ox; // 그릴 도형의 초기 위상을 잡기 때문에 / 2 의 경우 맨 위 꼭지점을 기준으로 한다
                y = (int)(r * Math.Sin(theta - Math.PI / 2)) + oy;

                pt[2 * i].X = x;
                pt[2 * i].Y = y;

                theta += step;
            }

            r = (int)(0.38 * r);

            for (int i = 0; i < NDOTS; i++)
            {
                int x, y;

                x = (int)(r * Math.Cos(theta - Math.PI / 2 + Math.PI / 5)) + ox; // 그릴 도형의 초기 위상을 잡기 때문에 / 2 의 경우 맨 위 꼭지점을 기준으로 한다
                y = (int)(r * Math.Sin(theta - Math.PI / 2 + Math.PI / 5)) + oy;

                pt[2 * i + 1].X = x;
                pt[2 * i + 1].Y = y;

                theta += step;
            }

            g.DrawPolygon(pen, pt);
        }   

        // 원을 그리는 함수
        static void drawFigures(Graphics g)
        {
            drawStar(g, 400, 400, 200);
            drawStar(g, 300, 200, 10);
            drawStar(g, 120, 400, 100);
            
        }
        public StarForm()
        {
            InitializeComponent();
        }

        private void StarForm_Paint(object sender, PaintEventArgs e)
        {
            drawFigures(e.Graphics);
        }
    }
}
