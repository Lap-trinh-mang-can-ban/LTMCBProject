using System.Text;

namespace DangKi_DangNhap
{
    public partial class ThongTinNguoiDungForm : Form
    {
        private User user; // Lưu thông tin của người dùng

        public ThongTinNguoiDungForm(User user)
        {
            InitializeComponent();
            this.user = user; // Lưu thông tin người dùng được truyền vào
            HienThiThongTinNguoiDung(); // Gọi phương thức hiển thị thông tin người dùng
        }

        // Phương thức để hiển thị thông tin người dùng
        private void HienThiThongTinNguoiDung()
        {
            // Hiển thị tên người dùng
            label2.Text = user.Username;
            // Hiển thị email người dùng
            string email1 = Encoding.UTF8.GetString(Convert.FromBase64String(user.Email));
            label4.Text = email1;
            // Các thông tin khác có thể được hiển thị tương tự
            label6.Text = user.Ngaysinh;
            label8.Text = user.Gioitinh;
        }

        private void ThongTinNguoiDungForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
