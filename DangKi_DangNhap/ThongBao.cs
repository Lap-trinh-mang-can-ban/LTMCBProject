using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangKi_DangNhap
{
    public partial class ThongBao : Form
    {
        public ThongBao()
        {
            InitializeComponent();
            // Thiết lập thuộc tính để thanh cuộn chỉ hiển thị khi cần thiết
            vScrollBar1.Visible = false;
            vScrollBar1.Scroll += VScrollBar1_Scroll;
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Di chuyển nội dung trong flowLayoutPanel1 tương ứng với giá trị thanh cuộn
            flowLayoutPanel1.VerticalScroll.Value = e.NewValue;
        }

        private void ThongBao_Load(object sender, EventArgs e)
        {
            // Tính toán kích thước cần thiết của thanh cuộn
            int totalHeight = flowLayoutPanel1.Controls.OfType<Control>().Sum(control => control.Height);
            vScrollBar1.Maximum = totalHeight - flowLayoutPanel1.ClientSize.Height;
            vScrollBar1.LargeChange = flowLayoutPanel1.ClientSize.Height;
            vScrollBar1.Visible = vScrollBar1.Maximum > 0;
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            // Cập nhật lại kích thước của thanh cuộn khi thêm một control mới vào flowLayoutPanel1
            int totalHeight = flowLayoutPanel1.Controls.OfType<Control>().Sum(control => control.Height);
            vScrollBar1.Maximum = totalHeight - flowLayoutPanel1.ClientSize.Height;
            vScrollBar1.LargeChange = flowLayoutPanel1.ClientSize.Height;
            vScrollBar1.Visible = vScrollBar1.Maximum > 0;
        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {

        }
    }
}
