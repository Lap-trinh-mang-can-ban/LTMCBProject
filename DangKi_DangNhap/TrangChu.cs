using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class TrangChu : Form
    {
        // Dictionary để lưu màu ban đầu của các button
        Dictionary<Bunifu.UI.WinForms.BunifuButton.BunifuButton2, Color> originalButtonColors = new Dictionary<Bunifu.UI.WinForms.BunifuButton.BunifuButton2, Color>();
        private Form currentChildForm;
        private User currentUser; // Thêm trường để lưu thông tin tài khoản
        public TrangChu(User user)
        {
            InitializeComponent();
            // Gắn sự kiện MouseEnter và MouseLeave cho các button
            bunifuButton21.MouseEnter += Button_MouseEnter;
            bunifuButton21.MouseLeave += Button_MouseLeave;

            bunifuButton22.MouseEnter += Button_MouseEnter;
            bunifuButton22.MouseLeave += Button_MouseLeave;

            bunifuButton23.MouseEnter += Button_MouseEnter;
            bunifuButton23.MouseLeave += Button_MouseLeave;

            bunifuButton24.MouseEnter += Button_MouseEnter;
            bunifuButton24.MouseLeave += Button_MouseLeave;

            bunifuButton25.MouseEnter += Button_MouseEnter;
            bunifuButton25.MouseLeave += Button_MouseLeave;

            bunifuButton26.MouseEnter += Button_MouseEnter;
            bunifuButton26.MouseLeave += Button_MouseLeave;
            // Lưu màu ban đầu của các button
            originalButtonColors.Add(bunifuButton21, bunifuButton21.BackColor);
            originalButtonColors.Add(bunifuButton22, bunifuButton22.BackColor);
            originalButtonColors.Add(bunifuButton23, bunifuButton23.BackColor);
            originalButtonColors.Add(bunifuButton24, bunifuButton24.BackColor);
            originalButtonColors.Add(bunifuButton25, bunifuButton25.BackColor);
            originalButtonColors.Add(bunifuButton26, bunifuButton25.BackColor);
            currentUser = user;
            linkLabel2.Text = currentUser.Tentaikhoan;
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Đóng form con hiện tại nếu có
            }

            currentChildForm = childForm; // Cập nhật form con hiện tại
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button = (Bunifu.UI.WinForms.BunifuButton.BunifuButton2)sender;
            if (originalButtonColors.ContainsKey(button))
            {
                button.BackColor = Color.MediumTurquoise;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button = (Bunifu.UI.WinForms.BunifuButton.BunifuButton2)sender;
            // Trở lại màu của button trước khi rê chuột vào
            if (originalButtonColors.ContainsKey(button))
            {
                button.BackColor = originalButtonColors[button];
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                this.Close(); // Đóng form hiện tại
            }
            else
            {
                // Người dùng chọn không đăng xuất, không làm gì cả
            }
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ThongTinNguoiDungForm infoForm = new ThongTinNguoiDungForm(currentUser);
            infoForm.Show();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChuThatSu());
        }
        private string user;
        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongBao(currentUser.Tentaikhoan));
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaoNhom(currentUser.Tentaikhoan)); // Truyền username của người dùng hiện tại
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LapLich(currentUser.Tentaikhoan));
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaoNhom(currentUser.Tentaikhoan)); 
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhGia());
        }
    }
}
