using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace DangKi_DangNhap
{
    public partial class QuenMK : Form
    {
        private IFirebaseClient firebaseClient;

        public QuenMK()
        {
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };
            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string taikhoan = textBox2.Text.Trim();
            string encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            if (encodedEmail == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                FirebaseResponse userResponse = await firebaseClient.GetAsync($"users/{taikhoan}");

                if (userResponse.Body == "null")
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = userResponse.ResultAs<User>();
                if (user.Email != (encodedEmail))
                {
                    MessageBox.Show("Email không đúng vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string password = user.MatKhau;
                string email1 = Encoding.UTF8.GetString(Convert.FromBase64String(encodedEmail));
                // Gửi email chứa mật khẩu đến người dùng
                GuiEmailMatKhau(email1, password);

                MessageBox.Show("Mật khẩu đã được gửi đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                using (MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body))
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(fromAddress, "svlo zxtg dblm nycv"); // Mật khẩu của bạn
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuenMK_Load(object sender, EventArgs e)
        {

        }
    }
}
