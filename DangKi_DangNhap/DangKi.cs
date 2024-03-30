using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace DangKi_DangNhap
{
    public partial class DangKi : Form
    {
        private TcpClient client;

        public DangKi()
        {
            InitializeComponent();

        }
       
    private void button1_Click(object sender, EventArgs e)
        {
            string taiKhoan = textBox1.Text;
            string matKhau = textBox2.Text;
            string xacNhanMatKhau = textBox3.Text;
            string email = textBox4.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau) || string.IsNullOrWhiteSpace(xacNhanMatKhau) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (client == null || !client.Connected) // Kiểm tra nếu kết nối chưa được thiết lập hoặc đã đóng
                {
                    client = new TcpClient();
                    client.Connect("127.0.0.1", 8888); // Kết nối tới máy chủ
                }
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes("DANGKI|" + taiKhoan + "|" + matKhau + "|" + email);
                stream.Write(data, 0, data.Length);

                // Đọc phản hồi từ máy chủ sau khi đăng kí
                byte[] responseData = new byte[4096];
                int bytesRead = stream.Read(responseData, 0, 4096);
                string response = Encoding.ASCII.GetString(responseData, 0, bytesRead);

                if (response == "TAIKHOAN_EXIST")
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!! Vui lòng nhập tên tài khoản khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (response == "MATKHAU_EXIST")
                {
                    MessageBox.Show("Mật khẩu khoản đã tồn tại!! Vui lòng nhập mật khẩu khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (response == "EMAIL_EXIST")
                {
                    MessageBox.Show("Email đã tồn tại!! Vui lòng nhập email khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (response == "DANGKI_SUCCESS")
                {
                    MessageBox.Show("Đăng kí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
