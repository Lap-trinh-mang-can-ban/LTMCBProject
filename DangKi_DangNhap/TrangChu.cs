using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace DangKi_DangNhap
{
    public partial class TrangChu : Form
    {
        public event Func<Task> ImagePathChanged; // Change to Func<Task>

        IFirebaseClient firebaseClient;
        // Dictionary để lưu màu ban đầu của các button
        Dictionary<Bunifu.UI.WinForms.BunifuButton.BunifuButton2, Color> originalButtonColors = new Dictionary<Bunifu.UI.WinForms.BunifuButton.BunifuButton2, Color>();
        private Form currentChildForm;
        private User currentUser; // Thêm trường để lưu thông tin tài khoản

        public TrangChu(User user)
        {
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            // Gắn sự kiện MouseEnter và MouseLeave cho các button
            bunifuButton21.MouseEnter += Button_MouseEnter;
            bunifuButton21.MouseLeave += Button_MouseLeave;

            bunifuButton22.MouseEnter += Button_MouseEnter;
            bunifuButton22.MouseLeave += Button_MouseLeave;

            bunifuButton23.MouseEnter += Button_MouseEnter;
            bunifuButton23.MouseLeave += Button_MouseLeave;

            bunifuButton24.MouseEnter += Button_MouseEnter;
            bunifuButton24.MouseLeave += Button_MouseLeave;

            bunifuButton25.MouseEnter += Button_MouseEnter;
            bunifuButton25.MouseLeave += Button_MouseLeave;

            bunifuButton26.MouseEnter += Button_MouseEnter;
            bunifuButton26.MouseLeave += Button_MouseLeave;

            // Lưu màu ban đầu của các button
            originalButtonColors.Add(bunifuButton21, bunifuButton21.BackColor);
            originalButtonColors.Add(bunifuButton22, bunifuButton22.BackColor);
            originalButtonColors.Add(bunifuButton23, bunifuButton23.BackColor);
            originalButtonColors.Add(bunifuButton24, bunifuButton24.BackColor);
            originalButtonColors.Add(bunifuButton25, bunifuButton25.BackColor);
            originalButtonColors.Add(bunifuButton26, bunifuButton25.BackColor);

            currentUser = user;
            linkLabel2.Text = currentUser.Username;
            LoadAnhDaiDien();
            this.ImagePathChanged += TrangChu_ImagePathChanged;
        }

        private async Task TrangChu_ImagePathChanged()
        {
            await LoadAnhDaiDien();
        }

        private async Task LoadAnhDaiDien()
        {
            // Dispose of the current image if it exists
            if (bunifuPictureBox7.Image != null)
            {
                bunifuPictureBox7.Image.Dispose();
                bunifuPictureBox7.Image = null;
            }

            string us = currentUser.Username;
            string path = string.Empty;
            FirebaseResponse response = await firebaseClient.GetAsync($"AnhDaiDien/{us}");
            if (response.Body == "null")
            {
              //  MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Parse dữ liệu trả về thành một Dictionary<string, object>
            Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();
            foreach (var member in nhomData)
            {
                path = member.Value.ToString();
            }

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    // Load the image from the path and set it to the PictureBox
                    bunifuPictureBox7.Image = new Bitmap(path);
                    bunifuPictureBox7.SizeMode = PictureBoxSizeMode.Zoom; // Ensure the image is centered and properly resized
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

        public async void UpdateImagePath()
        {
            // Trigger the event
            if (ImagePathChanged != null)
            {
                await ImagePathChanged.Invoke();
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close(); // Đóng form con hiện tại nếu có
            }

            currentChildForm = childForm; // Cập nhật form con hiện tại
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button = (Bunifu.UI.WinForms.BunifuButton.BunifuButton2)sender;
            if (originalButtonColors.ContainsKey(button))
            {
                button.BackColor = Color.MediumTurquoise;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button = (Bunifu.UI.WinForms.BunifuButton.BunifuButton2)sender;
            // Trở lại màu của button trước khi rê chuột vào
            if (originalButtonColors.ContainsKey(button))
            {
                button.BackColor = originalButtonColors[button];
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
            else
            {
                // Người dùng chọn không đăng xuất, không làm gì cả
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ThongTinNguoiDungForm infoForm = new ThongTinNguoiDungForm(currentUser, this);
            infoForm.Show();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChuThatSu());
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongBao());
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaoNhom(currentUser.Username)); // Truyền username của người dùng hiện tại
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LapLich(currentUser.Username));
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CaiDat(currentUser.MatKhau, currentUser.TaiKhoan));
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhGia());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
