using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net;

namespace DangKi_DangNhap
{
    public partial class Form1 : Form
    {
        private IFirebaseClient firebaseClient;
        private bool isPasswordVisible = false;

        public Form1()
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
            // Đảm bảo errorLabel không hiển thị chữ khi form được tải
            errorLabel.Text = "";

        }
        private async void bunifuButton23_Click(object sender, EventArgs e)
        {
            string tentaikhoan = textBox1.Text;
            string matKhau = textBox2.Text;
            errorLabel.Text = ""; // Xóa thông báo lỗi trước đó

            if (string.IsNullOrWhiteSpace(tentaikhoan))
            {
                //MessageBox.Show("Vui lòng nhập tên đăng nhập của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Vui lòng nhập tên đăng nhập của bạn !";
                return;
            }
            else if (string.IsNullOrWhiteSpace(matKhau))
            {
                //MessageBox.Show("Vui lòng nhập mật khẩu của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Vui lòng nhập mật khẩu của bạn !";
                return;
            }

            try
            {
                // Kiểm tra xem tài khoản có tồn tại và mật khẩu đúng không trên Firebase
                FirebaseResponse userResponse = await firebaseClient.GetAsync($"users/{tentaikhoan}");
                if (userResponse.Body == "null")
                {
                    // MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorLabel.Text = "Tên người dùng không tồn tại";
                    return;
                }

                var user = userResponse.ResultAs<User>();


                if (!BCrypt.Net.BCrypt.Verify(matKhau, user.MatKhau))
                {
                    //MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorLabel.Text = "Mật khẩu không đúng";
                    return;
                }

                string userName = user.Tentaikhoan;
                // Đăng nhập thành công
                //MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                errorLabel.Text = ""; 
                this.Hide();
                TrangChu tc = new TrangChu(user);
                tc.ShowDialog();
                this.Show();
                TaoNhom taoNhom = new TaoNhom(userName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            // Chuyển đổi giữa hiển thị và ẩn mật khẩu
            isPasswordVisible = !isPasswordVisible;
            textBox2.UseSystemPasswordChar = !isPasswordVisible;
      
        }
    }
}
