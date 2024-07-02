using System;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using System.Net;
using System.Security.Principal;

namespace DangKi_DangNhap
{
    public partial class QuenMK : Form
    {
        private IFirebaseClient firebaseClient;
        private string verificationCode;
        private bool isPasswordVisible = false;
        public QuenMK()
        {
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };
            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            errorLabel.Text = "";
        }

        private async void bunifuButton23_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string tentaikhoan = textBox2.Text.Trim();
            string maXacThuc = textBox3.Text;
            string matKhau = textBox4.Text;
            string xacNhanMatKhau = textBox5.Text;
            errorLabel.ForeColor = Color.Red;// chỉ là đổi màu thành đỏ thôi
            //string encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            if (email=="" || tentaikhoan=="" || maXacThuc=="" || matKhau=="" || xacNhanMatKhau=="")
            {
                //MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Vui lòng điền đầy đủ thông tin !";
                return;
            }
            if (maXacThuc != verificationCode)
            {
                errorLabel.Text = "Mã xác thực không đúng!";
                return;
            }
            if (matKhau != xacNhanMatKhau)
            {
                //MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Xác nhận mật khẩu chưa đúng !";
                return;
            }
            try
            {

                FirebaseResponse userResponse = await firebaseClient.GetAsync($"users/{tentaikhoan}");
                if (userResponse.Body == "null")
                {
                    //MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorLabel.Text = "Tài khoản không tồn tại !";
                    return;
                }

                var user = userResponse.ResultAs<User>();
                if (user.Email != (email))
                {
                    //MessageBox.Show("Email không đúng vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorLabel.Text = "Email không đúng hoặc không tồn tại email này !";
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhau);
                var Data = new Dictionary<string, object>

        {
            { "MatKhau",  hashedPassword}
        };
                FirebaseResponse response1 = await firebaseClient.UpdateAsync($"users/{tentaikhoan}", Data);
                MessageBox.Show("Mật khẩu đã được đặt lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                errorLabel.Text = "";
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
                string fromAddress = "22520358@gm.uit.edu.vn"; // Email của chur host
                string toAddress = email; // Email của người dùng
                string subject = "Password Recovery"; // Tiêu đề email
                string body = $"Mật khẩu của bạn: {password}"; // Nội dung email

                using (MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body))
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(fromAddress, "uit1429256805c#"); // Mật khẩu của bạn
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

        private string EncodeEmail(string email)
        {
            return email.Replace(".", "-dot-")
                        .Replace("@", "-at-")
                        .Replace("#", "-hash-")
                        .Replace("$", "-dollar-")
                        .Replace("[", "-lb-")
                        .Replace("]", "-rb-");
        }
        //Tạo OTP 
        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        //Xác  thức email
        private void GuiEmailXacThuc(string email, string code)
        {
            try
            {
                string fromAddress = "22520358@gm.uit.edu.vn";
                string toAddress = email;
                string subject = "Verification Code";
                string body = $"Mã xác thực của bạn là: {code}";

                using (MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body))
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(fromAddress, "uit1429256805c#");
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lấy đường dẫn tập tin ảnh đã chọn
                    string imagePath = openFileDialog.FileName;

                    // Hiển thị ảnh đã chọn trên PictureBox
                    bunifuPictureBox1.Image = new Bitmap(imagePath);

                    // Upload ảnh đại diện lên Firebase Storage
                    // string avatarUrl = await UploadImageToFirebaseStorage(imagePath);

                    // Thêm đường dẫn ảnh đại diện vào dữ liệu người dùng
                    // Chưa biết làm gì với đường dẫn ảnh đại diện trong ví dụ này

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void btnLayma_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                errorLabel.Text = "Vui lòng nhập email !";
                return;
            }

            string encodedEmail = EncodeEmail(email);

            try
            {
                /*// Kiểm tra xem email đã tồn tại chưa
                FirebaseResponse emailExistsResponse = await firebaseClient.GetAsync($"emails/{encodedEmail}");
                if (emailExistsResponse.Body != "null")
                {
                    errorLabel.Text = "Email đã tồn tại !";
                    return;
                }*/

                verificationCode = GenerateVerificationCode();
                GuiEmailXacThuc(email, verificationCode);
                {
                    errorLabel.ForeColor = Color.LimeGreen;
                    errorLabel.Text = "Mã xác thực đã được gửi đi ";
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi ở phần Lấy mã : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            // Chuyển đổi giữa hiển thị và ẩn mật khẩu
            isPasswordVisible = !isPasswordVisible;
            textBox4.UseSystemPasswordChar = !isPasswordVisible;
        }

        private void ShowPasswordButton2_Click(object sender, EventArgs e)
        {
            // Chuyển đổi giữa hiển thị và ẩn mật khẩu
            isPasswordVisible = !isPasswordVisible;
            textBox5.UseSystemPasswordChar = !isPasswordVisible;
        }
    }
}
