using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_Dialog
{
    public partial class FigureDialog : Form
    {
        DialogForm mainForm; // 메인 폼을 불러올 객체

        public FigureDialog(DialogForm form) // 생성 시에 메인 폼을 가져옴
        {
            mainForm = form; // 메인 폼 저장
            InitializeComponent();
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

            int x1 = int.Parse(textX1.Text);
            int x2 = int.Parse(textX2.Text);
            int y1 = int.Parse(textY1.Text);
            int y2 = int.Parse(textY2.Text);

            // upcasting
            Figure newFigure = new Box(x1, y1, x2, y2);

            mainForm.addFigure(newFigure);

            Hide();
        }

        // cancle 버튼
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide(); // 화면을 사라지게하는 함수
        }
    }
}
