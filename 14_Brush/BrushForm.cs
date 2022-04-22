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

namespace _14_Brush
{
    public partial class BrushForm : Form
    {
        int sX, sY;

        public BrushForm()
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
            Brush brush = new SolidBrush(Color.Black); // Brush 자체는 interface이기 때문에 직접 구현(instance)할 수 없다
            // brush = new LinearGradientBrush(p1, p2, Color.Black, Color.White); // 검은 색으로 시작해 하얀 색으로 끝나는 Brush 객체

            Point p1 = new Point(sX, sY);
            Point p2 = new Point(eX, eY);

            Bitmap bmp = new Bitmap("window.bmp");
            TextureBrush brush1 = new TextureBrush(bmp); // 만들어놓은 bmp 이미지로 Brush를 세팅
            brush1.WrapMode = WrapMode.Tile; // WrapMode는 TextureBrush에만 먹힌다

            Font font = new Font("궁서체",40,FontStyle.Bold);

            g.DrawString("hello world", font, brush1, 10, 20); // 글자를 그릴 때도 texturebrush 사용이 가능하다

            // Brush를 사용하기 위해선 Draw가 아닌 Fill
            g.FillRectangle(brush1, Math.Min(sX, eX), Math.Min(sY, eY), Math.Abs(eX - sX), Math.Abs(eY - sY)); // 그린 사각형에 색이 채워져있다

            // 시작 위치가 끝 위치보다 큰 경우 제대로 그려지지 않고 width와 height가 -값이 되면 사각형이 그려지지 않는다
            // g.DrawRectangle(pen, Math.Min(sX, eX), Math.Min(sY, eY), Math.Abs(eX - sX), Math.Abs(eY - sY));

            // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
            g.Dispose(); // garbage collection을 위해서 사용
            brush.Dispose();
            brush1.Dispose();
        }
    }
}
