using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace DangKi_DangNhap
{
    public partial class CaiDat : Form
    {
        private IFirebaseClient firebaseClient;
        private readonly string matkhau;
        private readonly string account;

        public CaiDat(string mk, string acc)
        {
            matkhau = mk;
            account = acc;
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };
            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            errorLabel.Text = "";
        }

        private async void bunifuButton21_Click_1(object sender, EventArgs e)
        {
            string pass = text1.Text;
            string newpass = text2.Text;
            string mail = text3.Text;
            string hashedNewPassword = !string.IsNullOrWhiteSpace(newpass) ? BCrypt.Net.BCrypt.HashPassword(newpass) : string.Empty;

            // Kiểm tra nếu không nhập gì 
            if (string.IsNullOrWhiteSpace(pass))
            {
                errorLabel.Text = "Vui lòng nhập mật khẩu cũ !";
                return;
            }

            // Kiểm tra nếu chỉ nhập mật khẩu cũ
            if ((string.IsNullOrWhiteSpace(newpass) && string.IsNullOrWhiteSpace(mail)))
            {
                errorLabel.Text = "Vui lòng nhập mật khẩu mới hoặc email mới !";
                return;
            }

            // Kiểm tra mật khẩu cũ có đúng không
            if (!BCrypt.Net.BCrypt.Verify(pass, matkhau))
            {
                errorLabel.Text = "Mật khẩu cũ không đúng !";
                return;
            }

            // Tạo các dữ liệu cần cập nhật
            var updates = new Dictionary<string, object>();

            // Kiểm tra nếu người dùng muốn thay đổi mật khẩu
            if (!string.IsNullOrWhiteSpace(newpass))
            {
                updates.Add("MatKhau", hashedNewPassword);
            }

            // Kiểm tra nếu người dùng muốn thay đổi email
            if (!string.IsNullOrWhiteSpace(mail))
            {
                updates.Add("Email", mail);
            }

            // Cập nhật dữ liệu lên Firebase
            FirebaseResponse response = await firebaseClient.UpdateAsync($"users/{account}", updates);

            // Hiển thị thông báo thành công tương ứng
            if (updates.ContainsKey("MatKhau") && updates.ContainsKey("Email"))
            {
                MessageBox.Show("Đã đổi mật khẩu và email thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (updates.ContainsKey("MatKhau"))
            {
                MessageBox.Show("Đã đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (updates.ContainsKey("Email"))
            {
                MessageBox.Show("Đã đổi email thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Xóa các trường nhập và thông báo lỗi
            text1.Text = "";
            text2.Text = "";
            text3.Text = "";
            errorLabel.Text = "";
        }
    }
}
