using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_XDrawer
{
    public partial class XDrawer : Form
    {
        // DATA MEMBER
        public static int DRAW_BOX = 1;
        public static int DRAW_LINE = 2;
        public static int DRAW_CIRCLE = 3;
        public static int DRAW_POINT = 4;

        Color _currentColor;

        // _currentColor 객체를 건드리는 property
        public Color CurrentColor
        {
            get
            {
                return _currentColor;
            }
            set
            {
                _currentColor = value; // property 만들 때 사용하는 reserved word 예약어
            }
        }

        public Popup mainPopup = null; // 팝업 객체
        public Popup pointPopup = null;
        public Popup boxPopup = null;
        public Popup linePopup = null;
        public Popup circlePopup = null;

        Figure _selectedFigure; // 그림을 그릴 객체
        List<Figure> _figures; // 그림들을 저장할 리스트

        bool buttonPressed = false; // 마우스가 눌렸는가를 판단
        private int _whatToDraw; // 어떤 그림을 그릴지 정하기 위한 정수

        public PictureBox Canvas // PictureBox 를 돌려줄 property
        {
            get
            {
                return canvas;
            }
        }

        public XDrawer() // 생성자 constructor
        {
            InitializeComponent();
            _figures = new List<Figure>();
            _whatToDraw = DRAW_BOX; // 초기화 시 0으로 해주면 오류가 발생하기 때문에 생성 시 BOX를 초기값으로
            _currentColor = Color.Black; // 색 초기화

            mainPopup = new MainPopup(this); // canvas가 아닌 Form 전체를 넘긴다
            boxPopup = new FigurePopup(this, "Box", true); // Form과 이름, 색 채우기를 할건지 결정
            linePopup = new FigurePopup(this, "Line", false);
            circlePopup = new FigurePopup(this, "Circle", true);
            pointPopup = new FigurePopup(this, "Point", false); 
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 오른쪽을 누를 시
            if (e.Button == MouseButtons.Right)
            {
                // 그림을 잡는 걸 초기화
                _selectedFigure = null;
                foreach(Figure ptr in _figures) // 만들어진 그림들의 리스트를 순회하면서
                {
                    if(ptr.ptInRegion(e.X, e.Y)) // 지정된 위치에 그림이 있으면
                    {
                        _selectedFigure = ptr; // 해당 그림을 잡고 빠져나간다
                        break;
                    }
                }

                if(_selectedFigure != null) // 그림 잡은 게 있으면
                {   // 이와 같이 자식 클래스에 작업을 넘기는 걸 위임한다고 한다 Delegation
                    _selectedFigure.popup(e.Location); // 해당 region의 클래스에 맞는 popup 호출
                }
                else // 그림 잡은 게 없으면
                {
                    mainPopup.popup(e.Location); // 기본 메인 팝업을 열어준다
                }

                return;
            }
            // 마우스 왼쪽을 누를 시
            if (_whatToDraw == DRAW_BOX)
            {
                // upcasting ,박스 그리기
                _selectedFigure = new Box(boxPopup, e.X, e.Y); // 마우스를 누를 때마다 새로운 객체 생성
            }
            else if (_whatToDraw == DRAW_LINE)
            {
                _selectedFigure = new Line(linePopup, e.X, e.Y); // 객체 생성 시 x, y 좌표값을 현재 마우스 위치로 초기화
            }
            else if (_whatToDraw == DRAW_CIRCLE)
            {
                _selectedFigure = new Circle(circlePopup, e.X, e.Y);
            } else if(_whatToDraw == DRAW_POINT)
            {
                _selectedFigure = new Point(pointPopup, e.X, e.Y);
            }

            _selectedFigure.setColor(_currentColor); // 그림 그리는 객체 색상 지정
            buttonPressed = true; // 마우스가 눌려져있는지 확인하는 flag를 눌려져있다고 표시
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

            _selectedFigure.makeRegion(); // 그림을 완성하면서 region을 만든다 -> 나중에 popup 등에 사용하려고

            // 이전엔 마우스를 누르자 말자 배열에 더해줬지만 이제는 완성시킨 후 리스트에 넣어준다
            _figures.Add(_selectedFigure);

            _selectedFigure = null;

            canvas.Invalidate(); // 화면을 무효화 함으로써 paint 이벤트를 다시 호출하게 한다
        }

        // modal dialog에서 OK 버튼을 눌렀을 때 list에 좌표를 넣을 수 있게 해주는 함수
        public void addFigure(Figure fig) // 여기서 Figure를 사용할 수 있게 Figure class에서 public으로 설정해주어야 함
        {
            // 다이얼로그를 통해 그림을 만들 때도 region을 가지고 있어야 한다
            fig.makeRegion(); // region 잡기

            _figures.Add(fig); // 그림 리스트에 그림 추가

            canvas.Invalidate(); // 넣었으니 페인트 재호출
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // rubber banding을 보통 사용하지만 지금은 허접한 방법으로 잔상을 없애는 걸 구현
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

        // 여기 페인트를 invalidate로 호출하게 되면 각 클래스의 draw 함수가 재호출된다
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // clip area를 자동으로 넘겨주니까 e에서 갖다 쓰면 된다
            // 이 경우 새로운 그래픽스를 만든 것이 아니니까 dispose를 하면 안된다
            Graphics g = e.Graphics; // 그래픽스 객체

            Pen pen = new Pen(Color.Black); // 펜 객체

            // Paint 이벤트가 호출되었을 때 그려놨던 그림을 표시하기 위해 사용
            foreach (Figure ptr in _figures)
            {
                ptr.draw(g, pen);
            }
        }
        // 스튜디오가 만들어준 클래스라도 디자이너 말고 여기 거는 수정해도 문제가 없다
        // 메인 창 스트립 메뉴에서 클릭을 관리하는 이벤트 핸들러들
        public void BoxToolStripMenuItem_Click(object sender, EventArgs e)
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

        public void PointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _whatToDraw = DRAW_POINT;
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

        // 직접 만든 이벤트 핸들러
        public void deleteFigure(object sender, EventArgs e) // 선택된 그림을 지우는 함수
        {
            // MessageBox.Show("hello"); // 호출되는지 확인용
            if (_selectedFigure == null) // 선택된 그림이 없다면 (빈 화면에 마우스 우클릭 시에)
                return;

            // region은 Figure 클래스를 통해 만들어지게 되어있으므로 해당 Figure가 사라지면 자동으로 삭제
            _figures.Remove(_selectedFigure); // 그림들을 저장한 리스트에서 선택된 그림을 제거하는 함수 호출

            canvas.Invalidate(); // paint 재호출
        }

        // Figure class 내부의 setcolor 함수를 호출할 함수
        private void setColor(Color color)
        {
            if (_selectedFigure == null) // 만약 선택된 Figure가 없으면 리턴
                return;

            _selectedFigure.setColor(color); // 

            canvas.Invalidate(); // canvas의 paint 이벤트 재호출
        }

        // popup을 통해서 색을 정하면 그 색을 세팅하는 이벤트 핸들러들
        public void setBlackColor(object sender, EventArgs e) // 검은색 함수
        {
            setColor(Color.Black);
        }
        public void setRedColor(object sender, EventArgs e) // 빨간색 함수
        {
            setColor(Color.Red);
        }
        public void setBlueColor(object sender, EventArgs e) // 파란색 함수
        {
            setColor(Color.Blue);
        }
        public void setGreenColor(object sender, EventArgs e) // 초록색 함수
        {
            setColor(Color.Green);
        }
        // 팝업에서 채우기를 누르면 그림의 색을 채우는 이벤트 핸들러
        public void setFill(object sender, EventArgs e)
        {
            if (_selectedFigure == null) // 선택된 그림이 없는 경우
                return;

            _selectedFigure.setFill(); // Figure class의 setFill 함수 호출해서 그림을 채우지 않았다면 채우고 채웠다면 선으로만 되돌릴 수 있게 한다

            canvas.Invalidate(); // canvas paint 재호출해서 리스트의 Figure들을 draw할 수 있게
        }

        // 팝업에서 복사하기를 누르면 그림을 복사하는 이벤트 핸들러
        public void copyFigure(object sender, EventArgs e)
        {
            if (_selectedFigure == null) // 선택된 그림이 없는 경우
                return;

            Figure newFigure = _selectedFigure.clone(); // 현재 선택된 그림을 복사하는 함수를 호출해 새 Figure 만들기
            newFigure.move(10, 20); // 복사된 그림이 겹치지 않게 좌표를 조금 이동시키는 함수 호출

            addFigure(newFigure); // addFigure 함수에서 리스트 추가, region 처리, invalidate를 한 번에 처리해주니까 사용
        }
    }
}
