using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 이전에는 여기서 직접 사각형을 그려 코드가 반복되면서 길었는데 Box class에 몰아넣어서 작업함

namespace _17_Box_Member_Function
{
    public partial class BoxMemberForm : Form
    {
        static int MAX = 100;
        Box currentBox; // 현재 그리는 사각형의 좌표를 저장할 객체
        Box[] boxes = new Box[MAX]; // 그려진 사각형들의 좌표를 저장할 객체
        int nBox = 0;

        bool buttonPressed = false; // 마우스가 눌렸는가를 판단
        public BoxMemberForm()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            currentBox = new Box(e.X, e.Y); // 마우스를 누를 때마다 새로운 객체 생성
            boxes[nBox] = currentBox; // 새로운 객체를 가르키는 reference 개념
            nBox++;

            buttonPressed = true;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = canvas.CreateGraphics(); // canvas 객체 안에서 사용하는 그래픽스 객체 생성
            Pen pen = new Pen(Color.Black);

            currentBox.draw(g, pen);

            // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
            g.Dispose(); // garbage collection을 위해서 사용

            buttonPressed = false;
            currentBox = null;

            canvas.Invalidate(); // 화면을 무효화 함으로써 paint 이벤트를 다시 호출하게 한다
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
                currentBox.draw(g, backPen);

                // 시작 위치가 끝 위치보다 큰 경우 제대로 그려지지 않고 width와 height가 -값이 되면 사각형이 그려지지 않는다
                // g.DrawRectangle(pen, Math.Min(currentBox.x1, newX), Math.Min(currentBox.y1, newY), Math.Abs(newX - currentBox.x1), Math.Abs(newY - currentBox.y1));
                currentBox.draw(g, pen);

                // currentBox.x2 = newX;
                // currentBox.y2 = newY;
                currentBox.setXY2(newX, newY); // box 객체의 x2,y2를 세팅하는 함수 호출

                // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
                g.Dispose(); // garbage collection을 위해서 사용
            }
        }
        // 페인트 이벤트를 이용해보니 기존에 rubber banding을 하지 않아 지워졌던 부분이 깔끔하게 그려진다
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // clip area를 자동으로 넘겨주니까 e에서 갖다 쓰면 된다
            // 이 경우 새로운 그래픽스를 만든 것이 아니니까 dispose를 하면 안된다
            Graphics g = e.Graphics; // 그래픽스 객체

            Pen pen = new Pen(Color.Black); // 펜 객체

            for (int i = 0; i < nBox; i++)
            {
                boxes[i].draw(g, pen);
            }
        }
    }
}
