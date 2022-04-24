using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19_Inh_Dyna_Poly
{
    public partial class RepairForm : Form
    {
        // DATA MEMBER
        static int DRAW_LINE = 2;
        static int DRAW_BOX = 3;
        static int DRAW_CIRCLE = 4;

        Figure _selectedFigure;
        List<Figure> _figures;

        bool buttonPressed = false; // 마우스가 눌렸는가를 판단
        private int _whatToDraw; // 어떤 그림을 그릴지 정하기 위한 정수

        public RepairForm() // constructor
        {
            InitializeComponent();
            _figures = new List<Figure>();
            _whatToDraw = DRAW_BOX; // 초기화 시 0으로 해주면 오류가 발생하기 때문에 생성 시 BOX를 초기값으로
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (_whatToDraw == DRAW_BOX)
            {
                // upcasting ,박스 그리기
                _selectedFigure = new Box(e.X, e.Y); // 마우스를 누를 때마다 새로운 객체 생성
            }
            else if (_whatToDraw == DRAW_LINE)
            {
                _selectedFigure = new Line(e.X, e.Y); // 객체 생성 시 x, y 좌표값을 현재 마우스 위치로 초기화
            }
            else if (_whatToDraw == DRAW_CIRCLE)
            {
                _selectedFigure = new Circle(e.X, e.Y);
            }
            buttonPressed = true;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = canvas.CreateGraphics(); // canvas 객체 안에서 사용하는 그래픽스 객체 생성
            Pen pen = new Pen(Color.Black);

            // dynamic binding
            _selectedFigure.draw(g, pen);

            // C#은 Automatic garbage collection을 채택했으나 완벽하지 않기 때문에 큰 객체를 호출하면 따로 처리해주어야 한다
            g.Dispose(); // garbage collection을 위해서 사용

            buttonPressed = false;

            // 이전엔 마우스를 누르자 말자 배열에 더해줬지만 이제는 완성시킨 후 리스트에 넣어준다
            _figures.Add(_selectedFigure);

            _selectedFigure = null;

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

                _selectedFigure.draw(g, backPen);
                // 아래에서 수행할 동작은 새로 사각형을 그리는 것이니까 x2, y2, 값을 바꾸고 했어야 함
                _selectedFigure.setXY2(newX, newY);
                // 마우스가 움직이면서 받은 새 좌표로 사각형을 그린다
                _selectedFigure.draw(g, pen);
               

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

            foreach (Figure ptr in _figures)
            {
                ptr.draw(g, pen);
               
            }
            pen.Dispose();
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
