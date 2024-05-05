using Firebase.Storage;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class ThongTinFile : Form
    {
        public IFirebaseClient firebaseClient;
        private string tenNhom;
        private string tenfile1;
        private TaiLieu currentailieu;
        private const string Bucket = "databeseaccess.appspot.com";
        public ThongTinFile(LinkLabel tenfile, string tenNhom, TaiLieu teptin )
        {
            InitializeComponent();
            this.tenNhom = tenNhom;
            this.tenfile1 = tenfile.Text;

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            currentailieu = teptin;
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa file không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                FirebaseResponse res = firebaseClient.Delete("TaiLieu/" + tenNhom + "/" + tenfile1);
                FirebaseResponse res1 = firebaseClient.Delete("TuyenTapTaiLieu/" + tenNhom + "/" + tenfile1);
                MessageBox.Show("Đã xóa file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn tải xuống file không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "PDF files (*.pdf)|*.pdf|Word documents (*.doc;*.docx)|*.doc;*.docx|JPEG files (*.jpg)|*.jpg";
                    dialog.FileName = tenfile1; // Tên mặc định cho tệp tải xuống

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string localFilePath = dialog.FileName; // Lấy đường dẫn được chọn bởi người dùng
                        string extension = Path.GetExtension(localFilePath).ToLower();

                        // Tạo đường dẫn đến tệp trong Firebase Storage
                        string path = $"{tenNhom}/{tenfile1}";

                        // Tạo đối tượng FirebaseStorage
                        var firebaseStorage = new FirebaseStorage("databeseaccess.appspot.com");

                        try
                        {
                            // Lấy URL tải xuống cho tệp từ Firebase Storage
                            string downloadUrl = await firebaseStorage.Child(path).GetDownloadUrlAsync();

                            // Tạo đối tượng HttpClient
                            using (var httpClient = new HttpClient())
                            {
                                // Tải xuống file và lưu vào đường dẫn địa phương
                                var response = await httpClient.GetAsync(downloadUrl);
                                if (response.IsSuccessStatusCode)
                                {
                                    using (var fileStream = File.Create(localFilePath))
                                    {
                                        await response.Content.CopyToAsync(fileStream);
                                    }
                                    MessageBox.Show("Tải xuống file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Không thể tải xuống file từ Firebase Storage.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TTFile tf = new TTFile(currentailieu);
            tf.ShowDialog();
            this.Show();
        }
    }
}
