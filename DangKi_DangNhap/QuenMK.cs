using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace DangKi_DangNhap
{
    public partial class QuenMK : Form
    {
        private TcpClient client;
        public QuenMK()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            if (email == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                byte[] data = Encoding.ASCII.GetBytes("QUENMK|" + email); // Thêm dấu "|" để phân biệt giữa lệnh và dữ liệu
                stream.Write(data, 0, data.Length);

                // Đọc phản hồi từ máy chủ sau khi đăng kí
                byte[] responseData = new byte[4096];
                int bytesRead = stream.Read(responseData, 0, 4096);
                string response = Encoding.ASCII.GetString(responseData, 0, bytesRead);

                if (response.StartsWith("MATKHAU|"))
                {
                    string password = response.Substring(8); // Lấy mật khẩu từ phản hồi
                    GuiEmailMatKhau(email, password); // Gửi email chứa mật khẩu đến địa chỉ email của người dùng
                    MessageBox.Show("Mật khẩu đã được gửi về email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (response == "MATKHAU_NOT_FOUND")
                {
                    MessageBox.Show("Không tìm thấy mật khẩu cho địa chỉ email này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuiEmailMatKhau(string email, string password)
        {
            try
            {
                string fromAddress = "22520358@gm.uit.edu.vn"; // Email của bạn
                string toAddress = email; // Email của người dùng
                string subject = "Password Recovery"; // Tiêu đề email
                string body = $"Mật khẩu của bạn: {password}"; // Nội dung email

                MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body);
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromAddress, "1429256805"); // Mật khẩu của bạn

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

