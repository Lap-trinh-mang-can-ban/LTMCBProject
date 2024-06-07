using Bunifu.UI.WinForms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DangKi_DangNhap
{
    public partial class ThongTinNguoiDungForm : Form
    {
        private TrangChu trangChuForm;
        private User user; // Lưu thông tin của người dùng
        private readonly IFirebaseClient firebaseClient;

        public ThongTinNguoiDungForm(User user, TrangChu trangChu)
        {
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            firebaseClient = new FireSharp.FirebaseClient(config);
            this.user = user; // Lưu thông tin người dùng được truyền vào
            this.trangChuForm = trangChu; // Reference to the parent form
            HienThiThongTinNguoiDung(); // Gọi phương thức hiển thị thông tin người dùng
        }

        private async void HienThiThongTinNguoiDung()
        {
            label2.Text = user.Username;
            label4.Text = user.Email;
            label6.Text = user.Ngaysinh;
            label8.Text = user.Gioitinh;
            string path = string.Empty;
            FirebaseResponse response = await firebaseClient.GetAsync($"AnhDaiDien/{user.Username}");
            if (response.Body == "null")
            {
              //  MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();
            foreach (var member in nhomData)
            {
                path = member.Value.ToString();
            }

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    bunifuPictureBox1.Image = new Bitmap(path);
                    bunifuPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Image path is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bunifuButton22_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;
                    bunifuPictureBox1.Image = new Bitmap(imagePath);
                    var data1 = new Dictionary<string, object>
                    {
                        { "Anh", imagePath }
                    };

                    FirebaseResponse response1 = await firebaseClient.UpdateAsync($"AnhDaiDien/{user.Username}", data1);
                    trangChuForm.UpdateImagePath();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
