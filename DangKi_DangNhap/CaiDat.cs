using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

      

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            string pass = text1.Text;
            string newpass = text2.Text;
            string mail = text3.Text;
            string newpass1 = BCrypt.Net.BCrypt.HashPassword(newpass);
            string enpass = BCrypt.Net.BCrypt.HashPassword(pass);
            if (string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(newpass))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (matkhau != enpass)
            {
                MessageBox.Show("Mật khẩu cũ không đúng xin hãy nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var Data = new Dictionary<string, object>
        {

            { "MatKhau",  newpass1}

        };
            var Data1 = new Dictionary<string, object>
        {
            { "Email",  mail}
        };
            FirebaseResponse response1 = await firebaseClient.UpdateAsync($"users/{account}", Data);
            FirebaseResponse response2 = await firebaseClient.UpdateAsync($"users/{account}", Data1);
            MessageBox.Show("Đã thay đổi mật khẩu và email thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private async void bunifuButton21_Click_1(object sender, EventArgs e)
        {
            string pass = text1.Text;
            string newpass = text2.Text;
            string mail = text3.Text;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newpass);

            if (string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(newpass))
            {
                errorLabel.Text = "Vui lòng điền đầy đủ thông tin !";
                return;
            }

            if (!BCrypt.Net.BCrypt.Verify(pass, matkhau))
            {
                //MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show("Mật khẩu cũ không đúng vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var Data = new Dictionary<string, object>
        {

            { "MatKhau",  hashedPassword}

        };
            var Data1 = new Dictionary<string, object>
        {
            { "Email",  mail}
        };
            FirebaseResponse response1 = await firebaseClient.UpdateAsync($"users/{account}", Data);
            FirebaseResponse response2 = await firebaseClient.UpdateAsync($"users/{account}", Data1);
            MessageBox.Show("Đã thay đổi mật khẩu và email thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            text1.Text = "";
            text2.Text = "";
            text3.Text = "";
            errorLabel.Text = "";

        }
    }
}
