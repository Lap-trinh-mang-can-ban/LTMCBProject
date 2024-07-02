using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO;
using System.Net.Http;
using Firebase.Storage;

namespace DangKi_DangNhap
{
    public partial class TrangChu : Form
    {
        public event Func<Task> ImagePathChanged;
        IFirebaseClient firebaseClient;
        Dictionary<Bunifu.UI.WinForms.BunifuButton.BunifuButton2, Color> originalButtonColors = new Dictionary<Bunifu.UI.WinForms.BunifuButton.BunifuButton2, Color>();
        private Form currentChildForm;
        private User currentUser;
        private string temp;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private const string Bucket = "databeseaccess.appspot.com";

        public TrangChu(User user)
        {
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            firebaseClient = new FireSharp.FirebaseClient(config);

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

            originalButtonColors.Add(bunifuButton21, bunifuButton21.BackColor);
            originalButtonColors.Add(bunifuButton22, bunifuButton22.BackColor);
            originalButtonColors.Add(bunifuButton23, bunifuButton23.BackColor);
            originalButtonColors.Add(bunifuButton24, bunifuButton24.BackColor);
            originalButtonColors.Add(bunifuButton25, bunifuButton25.BackColor);
            originalButtonColors.Add(bunifuButton26, bunifuButton25.BackColor);

            currentUser = user;
            linkLabel2.Text = currentUser.Tentaikhoan;
            LoadAnhDaiDien();
            this.ImagePathChanged += TrangChu_ImagePathChanged;
        }

        private async Task TrangChu_ImagePathChanged()
        {
            await LoadAnhDaiDien();
        }

        private async Task LoadAnhDaiDien()
        {
            string path = $"ProfilePictures/{currentUser.Tentaikhoan}";

            var firebaseStorage = new FirebaseStorage(Bucket);

            try
            {
                string downloadUrl = await firebaseStorage.Child(path).GetDownloadUrlAsync();
                var image = await DownloadImageFromUrl(downloadUrl);
                if (image != null)
                {
                    bunifuPictureBox7.Image = image;
                }
                else
                {
                    MessageBox.Show("Không thể tải xuống ảnh từ Firebase Storage.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Bitmap> DownloadImageFromUrl(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        return new Bitmap(stream);
                    }
                }
                return null;
            }
        }

        public async void UpdateImagePath()
        {
            if (ImagePathChanged != null)
            {
                await ImagePathChanged.Invoke();
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
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
                this.Close();
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
            OpenChildForm(new ThongBao(currentUser.Tentaikhoan));
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaoNhom(currentUser.Tentaikhoan));
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LapLich(currentUser.Tentaikhoan, temp));
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CaiDat(currentUser.MatKhau, currentUser.Tentaikhoan));
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhGia());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
