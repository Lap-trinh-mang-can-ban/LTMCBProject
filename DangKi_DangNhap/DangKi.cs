using System;
using System.Text;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace DangKi_DangNhap
{
    public partial class DangKi : Form
    {
        IFirebaseClient firebaseClient;

        public DangKi()
        {
            InitializeComponent();

            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string taiKhoan = textBox1.Text;
            string matKhau = textBox2.Text;
            string xacNhanMatKhau = textBox3.Text;
            string email = textBox4.Text;
            string encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            string username = textBox5.Text;
            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau) || string.IsNullOrWhiteSpace(xacNhanMatKhau) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username))
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
                // Kiểm tra xem tên tài khoản đã tồn tại chưa
                FirebaseResponse userExistsResponse = firebaseClient.Get($"users/{taiKhoan}");
                if (userExistsResponse.Body != "null")
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!! Vui lòng nhập tên tài khoản khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem email đã tồn tại chưa
                FirebaseResponse emailExistsResponse = await firebaseClient.GetAsync($"emails/{encodedEmail}");
                if (emailExistsResponse.Body != "null")
                {
                    MessageBox.Show("Email đã tồn tại!! Vui lòng nhập email khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FirebaseResponse usernameExistsResponse = await firebaseClient.GetAsync($"emails/{username}");
                if (usernameExistsResponse.Body != "null")
                {
                    MessageBox.Show("Username đã tồn tại!! Vui lòng nhập username khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Tạo dữ liệu người dùng mới
                var newUser = new User
                {
                    TaiKhoan = taiKhoan,
                    MatKhau = matKhau,
                    Email = encodedEmail,
                    Username = username,
                };

                // Thêm người dùng mới vào Firebase Realtime Database
                SetResponse setResponse = await firebaseClient.SetAsync($"users/{taiKhoan}", newUser);
                // Thêm email vào danh sách để kiểm tra tồn tại
                await firebaseClient.SetAsync($"emails/{encodedEmail}", true);

                MessageBox.Show("Đăng kí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class User
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
