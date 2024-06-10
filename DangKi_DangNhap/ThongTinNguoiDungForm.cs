﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
          // Lưu thông tin người dùng được truyền vào
            this.trangChuForm = trangChu; // Reference to the parent form
            this.user = user; // Lưu thông tin người dùng được truyền vào
            HienThiThongTinNguoiDung(); // Gọi phương thức hiển thị thông tin người dùng
        }

        // Phương thức để hiển thị thông tin người dùng
        private async void HienThiThongTinNguoiDung()
        {
            // Hiển thị tên người dùng
            label2.Text = user.Tentaikhoan;
            // Hiển thị email người dùng
            //string email1 = Encoding.UTF8.GetString(Convert.FromBase64String(user.Email));
            label4.Text = user.Email;
            // Các thông tin khác có thể được hiển thị tương tự
            label6.Text = user.Ngaysinh;
            label8.Text = user.Gioitinh;
            string path = string.Empty;
            FirebaseResponse response = await firebaseClient.GetAsync($"AnhDaiDien/{user.Tentaikhoan}");
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

        private void ThongTinNguoiDungForm_Load(object sender, EventArgs e)
        {

        }

        private async  void btnLayma_Click(object sender, EventArgs e)
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

                    FirebaseResponse response1 = await firebaseClient.UpdateAsync($"AnhDaiDien/{user.Tentaikhoan}", data1);
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
