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

namespace _15_Rectangle
{
    public partial class RectForm : Form
    {
        int sX, sY;
        int eX, eY;
        bool buttonPressed = false; // 마우스가 눌렸는가를 판단

        public RectForm()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            sX = eX = e.X;
            sY = eY = e.Y;

            buttonPressed = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // rubber banding을 보통 사용하지만 지금은 허접한 방법으로 잔상을 없애는 걸 구현
            // 문제점은 기존에 그려놓은 사각형을 지나가면 해당 사각형 위로 흰 선이 그려져 지워짐
            if (buttonPressed == true)
            {
                int newX = e.X;
                int newY = e.Y;

                Graphics g = canvas.CreateGraphics(); // canvas 객체 안에서 사용하는 그래픽스 객체 생성

                Pen pen = new Pen(Color.Black);
                Pen backPen = new Pen(canvas.BackColor); // canvas 객체의 배경 색을 가진 펜 생성
                
                // 이전에 그려진 잔상을 지울 사각형을 따로 그려줌
                g.DrawRectangle(backPen, Math.Min(sX, eX), Math.Min(sY, eY), Math.Abs(eX - sX), Math.Abs(eY - sY));

                // 시작 위치가 끝 위치보다 큰 경우 제대로 그려지지 않고 width와 height가 -값이 되면 사각형이 그려지지 않는다
                g.DrawRectangle(pen, Math.Min(sX, newX), Math.Min(sY, newY), Math.Abs(newX - sX), Math.Abs(newY - sY));

                // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
                g.Dispose(); // garbage collection을 위해서 사용

                eX = newX;
                eY = newY;
            }
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

            buttonPressed = false;
        }
    }
}
