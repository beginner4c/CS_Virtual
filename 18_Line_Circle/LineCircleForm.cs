using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 문제점을 인식하기 위해서 엉터리로 만들 프로그램
// inheritance, dynamic binding, polymorism 의 필요성을 인식해보려고
// 문제점 : 중복되는 코드가 너무 많다. -> 수정 시 만질 곳이 많아진다

namespace _18_Line_Circle
{
    public partial class LineCircleForm : Form
    {
        // DATA MEMBER
        static int DRAW_LINE = 2;
        static int DRAW_BOX = 3;
        static int DRAW_CIRCLE = 4;

        static int MAX = 100;
        Box currentBox; // 현재 그리는 사각형의 좌표를 저장할 객체
        Box[] boxes = new Box[MAX]; // 그려진 사각형들의 좌표를 저장할 객체
        Line currentLine;
        Line[] lines = new Line[MAX];
        Circle currentCircle;
        Circle[] circles = new Circle[MAX];

        int nBox = 0;
        int nLine = 0;
        int nCircle = 0;

        bool buttonPressed = false; // 마우스가 눌렸는가를 판단
        private int _whatToDraw = 0;

        public LineCircleForm()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (_whatToDraw == DRAW_BOX)
            {
                // 박스 그리기
                currentBox = new Box(e.X, e.Y); // 마우스를 누를 때마다 새로운 객체 생성
                boxes[nBox] = currentBox; // 새로운 객체를 가르키는 reference 개념
                nBox++;
                // 선 그리기
            }
            else if (_whatToDraw == DRAW_LINE)
            {
                currentLine = new Line(e.X, e.Y);
                lines[nLine] = currentLine;
                nLine++;
            }
            else if (_whatToDraw == DRAW_CIRCLE)
            {
                currentCircle = new Circle(e.X, e.Y);
                circles[nCircle] = currentCircle;
                nCircle++;
            }
            buttonPressed = true;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = canvas.CreateGraphics(); // canvas 객체 안에서 사용하는 그래픽스 객체 생성
            Pen pen = new Pen(Color.Black);

            if (currentBox != null)
                currentBox.draw(g, pen);
            else if (currentLine != null)
                currentLine.draw(g, pen);
            else if (currentCircle != null)
                currentCircle.draw(g, pen);

            // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
            g.Dispose(); // garbage collection을 위해서 사용

            buttonPressed = false;
            currentBox = null;
            currentLine = null;
            currentCircle = null;

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

                // 기존에 그려진 사각형을 지울 사각형을 그린다
                if (currentBox != null)
                {
                    currentBox.draw(g, backPen);
                    // 아래에서 수행할 동작은 새로 사각형을 그리는 것이니까 x2, y2, 값을 바꾸고 했어야 함
                    currentBox.setXY2(newX, newY);
                    // 마우스가 움직이면서 받은 새 좌표로 사각형을 그린다
                    currentBox.draw(g, pen);
                }else if (currentLine != null)
                {
                    currentLine.draw(g, backPen);
                    // 아래에서 수행할 동작은 새로 선을 그리는 것이니까 x2, y2, 값을 바꾸고 했어야 함
                    currentLine.setXY2(newX, newY);
                    // 마우스가 움직이면서 받은 새 좌표로 선을 그린다
                    currentLine.draw(g, pen);
                }else if (currentCircle != null)
                {
                    currentCircle.draw(g, backPen);
                    currentCircle.setXY2(newX, newY);
                    currentCircle.draw(g, pen);
                }

                // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
                g.Dispose(); // garbage collection을 위해서 사용
            }
        }

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
            for (int i = 0; i < nLine; i++)
            {
                lines[i].draw(g, pen);
            }
            for(int i = 0; i<nCircle; i++)
            {
                circles[i].draw(g, pen);
            }
        }

        private void BoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _whatToDraw = DRAW_BOX;
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _whatToDraw = DRAW_LINE;
        }

        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _whatToDraw = DRAW_CIRCLE;
        }
    }
}
