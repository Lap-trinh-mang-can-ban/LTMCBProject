using Firebase.Storage;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangKi_DangNhap
{
    public partial class ThongTinNguoiDungForm : Form
    {
        private TrangChu trangChuForm;
        private User user; // Lưu thông tin của người dùng
        private readonly IFirebaseClient firebaseClient;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private const string Bucket = "databeseaccess.appspot.com";
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
            label4.Text = user.Email;
            // Các thông tin khác có thể được hiển thị tương tự
            label6.Text = user.Ngaysinh;
            label8.Text = user.Gioitinh;

            string path = $"ProfilePictures/{user.Tentaikhoan}";

            // Tạo đối tượng FirebaseStorage
            var firebaseStorage = new FirebaseStorage(Bucket);

            try
            {
                // Lấy URL tải xuống cho tệp từ Firebase Storage
                string downloadUrl = await firebaseStorage.Child(path).GetDownloadUrlAsync();

                // Tải xuống và hiển thị hình ảnh
                var image = await DownloadImageFromUrl(downloadUrl);
                if (image != null)
                {
                    bunifuPictureBox1.Image = image;
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

        private void ThongTinNguoiDungForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnLayma_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
            string uniquePath = $"ProfilePictures/{user.Tentaikhoan}";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;
                    bunifuPictureBox1.Image = new Bitmap(imagePath);

                    byte[] fileBytes = File.ReadAllBytes(imagePath);
                    var firebaseStorage = new FirebaseStorage(Bucket);

                    // Lưu trữ tệp lên Firebase Storage
                    await firebaseStorage.Child(uniquePath).PutAsync(new MemoryStream(fileBytes));

                    // Tạo đường dẫn tới tệp trên Firebase Storage
                    string firebaseStoragePath = await firebaseStorage.Child(uniquePath).GetDownloadUrlAsync();
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
