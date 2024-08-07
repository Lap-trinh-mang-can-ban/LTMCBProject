﻿using Firebase.Storage;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        private string tentaikhoan;
        private TaiLieu currentailieu;
        public ThongTinFile(LinkLabel tenfile, string tenNhom, TaiLieu teptin, string nametk)
        {
            InitializeComponent();
            this.tenNhom = tenNhom;
            this.tenfile1 = tenfile.Text;
            this.tentaikhoan = nametk;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            currentailieu = teptin;
        }

        private string DecodePath(string encodedPath)
        {
            byte[] bytes = Convert.FromBase64String(encodedPath);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

       

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn tải xuống file không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "PDF files (*.pdf)|*.pdf|Word documents (*.doc;*.docx)|*.doc;*.docx|Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    dialog.FileName = tenfile1; // Tên mặc định cho tệp tải xuống

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string localFilePath = dialog.FileName; // Lấy đường dẫn được chọn bởi người dùng

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

        private async void bunifuButton22_Click(object sender, EventArgs e)
        {
            FirebaseResponse rsp = await firebaseClient.GetAsync($"nhoms/{tentaikhoan}/{tenNhom}");

            // Lấy giá trị của "tenNhom" từ thuộc tính "Result"
            string tenNhomValue = rsp.ResultAs<string>();
            // Retrieve the file information from Firebase
            FirebaseResponse FileResponse = await firebaseClient.GetAsync($"TaiLieu/{tenNhom}/{tenfile1}");

            // Deserialize the response to get the file data
            FirebaseFileData fileData = JsonConvert.DeserializeObject<FirebaseFileData>(FileResponse.Body);

            // Get the value of UserUp
            string userUpValue = fileData.UserUp;

            // Display the value of UserUp (optional, for verification)
           if(tentaikhoan == userUpValue || tenNhomValue != "true")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa file không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Delete the file from Firebase
                    FirebaseResponse res = firebaseClient.Delete($"TaiLieu/{tenNhom}/{tenfile1}");
                    FirebaseResponse res1 = firebaseClient.Delete($"TuyenTapTaiLieu/{tenNhom}/{tenfile1}");
                    MessageBox.Show("Đã xóa file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chỉ có người đăng hoặc người quản lý nhóm mới được quyền xóa file !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            // Ask for confirmation before deleting the file
       
        }


        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            TTFile tf = new TTFile(currentailieu);
            tf.Show();
        }
        public class FirebaseFileData
        {
            public string Date { get; set; }
            public string PathFile { get; set; }
            public string UserUp { get; set; }
            public string fileName { get; set; }
        }
    }
}
