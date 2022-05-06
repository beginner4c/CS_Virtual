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
    public partial class FigureDialog : Form
    {
        XDrawer mainForm; // 메인 폼을 불러올 객체
        public FigureDialog(XDrawer form) // 생성 시에 메인 폼을 가져옴
        {
            mainForm = form; // 메인 폼 저장
            InitializeComponent();

            textX1.Text = "0"; // 초기 화면에 좌표값 0을 넣어주게
            textX2.Text = "0"; // 초기 화면에 좌표값 0을 넣어주게
            textY1.Text = "0"; // 초기 화면에 좌표값 0을 넣어주게
            textY2.Text = "0"; // 초기 화면에 좌표값 0을 넣어주게

            selectBox.Items.Add("Box"); // 콤보 박스에 아이템 추가
            selectBox.Items.Add("Line");
            selectBox.Items.Add("CIrcle");
            selectBox.Items.Add("Point");

            selectBox.SelectedIndex = 0; // 콤보박스에 첫 번째 아이템을 초기 화면에 보여주게 한다
        }

        // ok 버튼
        private void OkButton_Click(object sender, EventArgs e)
        {
            // Text에 아무 값도 안들어있는 경우 발생하는 NullPointException을 방지하기 위한 곳
            if (textX1.Text.Length == 0)
                return;
            if (textX2.Text.Length == 0)
                return;
            if (textY1.Text.Length == 0)
                return;
            if (textY2.Text.Length == 0)
                return;

            //MessageBox.Show("" +selectBox.SelectedIndex); 확인용

            int x1 = int.Parse(textX1.Text);
            int x2 = int.Parse(textX2.Text);
            int y1 = int.Parse(textY1.Text);
            int y2 = int.Parse(textY2.Text);


            // dynamic binding으로 인해 많은 if문을 줄일 수 있지만 객체를 처음 만들 땐 어쩔 수 없다
            Figure newFigure = null;
            // upcasting
            if (selectBox.SelectedIndex == XDrawer.DRAW_BOX - 1)
            {
                newFigure = new Box(mainForm.boxPopup, x1, y1, x2, y2);
            }
            else if(selectBox.SelectedIndex == XDrawer.DRAW_LINE - 1)
            {
                newFigure = new Line(mainForm.linePopup, x1, y1, x2, y2);
            }
            else if(selectBox.SelectedIndex == XDrawer.DRAW_CIRCLE - 1)
            {
                newFigure = new Circle(mainForm.circlePopup, x1, y1, x2, y2);
            }
            else if(selectBox.SelectedIndex == XDrawer.DRAW_POINT - 1)
            {
                newFigure = new Point(mainForm.pointPopup, x1, y1);
            }

            mainForm.addFigure(newFigure);
            // 한 번 그리고 나면 사라지게
            // Hide();
        }

        // cancle 버튼
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide(); // 다이얼로그 화면을 사라지게하는 함수 호출
        }

        private void SelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; // 콤보박스처럼 사용할 수 있는 객체 생성

            // MessageBox.Show(""+box.SelectedIndex); // selectedindex가 정수라 "" + 로 처리, 확인용
        }
    }
}
