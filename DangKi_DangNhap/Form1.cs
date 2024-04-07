using System.Net.Sockets;
using System.Text;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DangKi_DangNhap
{
    public partial class Form1 : Form
    {

        private TcpClient client;

        public Form1()
        {
            InitializeComponent();
            client = new TcpClient();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangKi dk = new DangKi();
            dk.ShowDialog();
            this.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            QuenMK qmk = new QuenMK();
            qmk.ShowDialog();
            this.Show();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string taiKhoan = textBox1.Text;
            string matKhau = textBox2.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (client == null || !client.Connected) // Kiểm tra nếu kết nối chưa được thiết lập hoặc đã đóng
                {
                    client = new TcpClient();
                    client.Connect("127.0.0.1", 8888); // Kết nối tới máy chủ
                }

                // Gửi dữ liệu tài khoản và mật khẩu tới máy chủ
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes("DANGNHAP|" + taiKhoan + "|" + matKhau);
                stream.Write(data, 0, data.Length);

                // Nhận kết quả từ máy chủ
                byte[] responseData = new byte[4096];
                int bytesRead = stream.Read(responseData, 0, 4096);
                string response = Encoding.ASCII.GetString(responseData, 0, bytesRead);

                // Hiển thị kết quả đăng nhập
                if (response == "True")
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    TrangChu tc = new TrangChu();
                    tc.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Đóng kết nối sau khi xử lý xong
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}


