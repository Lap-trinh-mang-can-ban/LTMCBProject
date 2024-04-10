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
    public partial class TrangChu : Form
    {
        // Dictionary để lưu màu ban đầu của các button
        Dictionary<Button, Color> originalButtonColors = new Dictionary<Button, Color>();
        private Form currentChildForm;
        private User currentUser; // Thêm trường để lưu thông tin tài khoản
        public TrangChu(User user)
        {
            InitializeComponent();
            // Gắn sự kiện MouseEnter và MouseLeave cho các button
            button1.MouseEnter += Button_MouseEnter;
            button1.MouseLeave += Button_MouseLeave;

            button2.MouseEnter += Button_MouseEnter;
            button2.MouseLeave += Button_MouseLeave;

            button3.MouseEnter += Button_MouseEnter;
            button3.MouseLeave += Button_MouseLeave;

            button4.MouseEnter += Button_MouseEnter;
            button4.MouseLeave += Button_MouseLeave;

            button5.MouseEnter += Button_MouseEnter;
            button5.MouseLeave += Button_MouseLeave;

            button6.MouseEnter += Button_MouseEnter;
            button6.MouseLeave += Button_MouseLeave;
            // Lưu màu ban đầu của các button
            originalButtonColors.Add(button1, button1.BackColor);
            originalButtonColors.Add(button2, button2.BackColor);
            originalButtonColors.Add(button3, button3.BackColor);
            originalButtonColors.Add(button4, button4.BackColor);
            originalButtonColors.Add(button5, button5.BackColor);
            originalButtonColors.Add(button6, button5.BackColor);
            currentUser = user;
            linkLabel2.Text = currentUser.Username;
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
            Button button = (Button)sender;
            button.BackColor = Color.Gray; // Chuyển màu nền của button sang màu xám
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChuThatSu());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongBao());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaoNhom());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LapLich());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhGia());
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ThongTinNguoiDungForm infoForm = new ThongTinNguoiDungForm(currentUser);
            infoForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        // Các phương thức xử lý sự kiện click cho các button khác có thể được thêm vào tương tự
    }
}
