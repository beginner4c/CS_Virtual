using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22_Popups
{
    public partial class PopupsForm : Form
    {
        // DATA MEMBER
        static int DRAW_LINE = 2;
        static int DRAW_BOX = 3;
        static int DRAW_CIRCLE = 4;

        public Popup mainPopup = null;
        public Popup pointPopup = null;
        public Popup boxPopup = null;
        public Popup linePopup = null;
        public Popup circlePopup = null;

        Figure _selectedFigure;
        List<Figure> _figures;

        bool buttonPressed = false; // 마우스가 눌렸는가를 판단
        private int _whatToDraw; // 어떤 그림을 그릴지 정하기 위한 정수

        public PictureBox Canvas // PictureBox 를 돌려줄 property
        {
            get
            {
                return canvas;
            }
        }

        public PopupsForm()
        {
            InitializeComponent();
            _figures = new List<Figure>();
            _whatToDraw = DRAW_BOX; // 초기화 시 0으로 해주면 오류가 발생하기 때문에 생성 시 BOX를 초기값으로

            mainPopup = new MainPopup(this); // canvas가 아닌 Form 전체를 넘긴다
            pointPopup = new FigurePopup(this, "Point", false); // Form과 이름, 색 채우기를 할건지 결정
            boxPopup = new FigurePopup(this, "Box", true);
            linePopup = new FigurePopup(this, "Line", false);
            circlePopup = new FigurePopup(this, "Circle", true);

        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 오른쪽을 누를 시
            if (e.Button == MouseButtons.Right)
            {
                mainPopup.popup(e.Location);

                return;
            }

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

        // 마우스 오른쪽 버튼을 누르건 왼쪽 버튼을 누르건 이벤트 핸들러는 똑같다
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

        // modal dialog에서 OK 버튼을 눌렀을 때 list에 좌표를 넣을 수 있게 해주는 함수
        public void addFigure(Figure fig) // 여기서 Figure를 사용할 수 있게 Figure class에서 public으로 설정해주어야 함
        {
            _figures.Add(fig);

            canvas.Invalidate(); // 넣었으니 페인트 재호출
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
        }
        // 스튜디오가 만들어준 클래스라도 디자이너 말고 여기 거는 수정해도 문제가 없다
        public void BoxToolStripMenuItem_Click(object sender, EventArgs e) // 다른 클래스에서 사용할 수 있게 visibility를 수정
        {
            _whatToDraw = DRAW_BOX;
        }

        public void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _whatToDraw = DRAW_LINE;
        }

        public void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _whatToDraw = DRAW_CIRCLE;
        }

        private void ModalDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FigureDialog dlg = new FigureDialog(this);

            dlg.ShowDialog(); // 내부에서 무한루프 비스무리하게 돌아가면서 dialog 외부에서 일어나는 이벤트를 전부 무시
        }

        private void ModalessDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FigureDialog dlg = new FigureDialog(this);

            dlg.Show(); // ShowDialog와 다르게 외부 이벤트도 받아준다
        }
    }
}
