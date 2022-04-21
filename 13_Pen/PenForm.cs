using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_Pen
{
    public partial class PenForm : Form
    {
        int sX, sY;
        public PenForm()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            sX = e.X;
            sY = e.Y;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            int eX = e.X;
            int eY = e.Y;

            Graphics g = canvas.CreateGraphics(); // canvas 객체 안에서 사용하는 그래픽스 객체 생성
            Pen pen = new Pen(Color.Black);
            pen.Width = 4; // 펜의 두께를 조절

            pen.DashStyle = DashStyle.Dash; // 펜을 사용했을 때 선의 형태를 결정하는 거
            // pen.StartCap = LineCap.Flat; // 줄발점의 모양을 평평하게
            pen.StartCap = LineCap.DiamondAnchor; // 출발점 모양을 다이아몬드로
            // pen.EndCap = LineCap.ArrowAnchor; // 끝점의 모양을 화살표 모양으로
            pen.EndCap = LineCap.RoundAnchor; // 끝점의 모양을 둥근 형태로

            pen.Color = Color.Red; // 펜 색 조절

            g.DrawLine(pen, sX, sY, eX, eY);

            pen.LineJoin = LineJoin.Miter; // 펜들이 이어질 때 선들이 이어지는 점을 어떻게 처리할지 결정

            g.DrawRectangle(pen, Math.Min(sX,eX), Math.Min(sY,eY), Math.Abs(sX-eX), Math.Abs(sY-eY));

            // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
            g.Dispose(); // garbage collection을 위해서 사용
        }
    }
}
