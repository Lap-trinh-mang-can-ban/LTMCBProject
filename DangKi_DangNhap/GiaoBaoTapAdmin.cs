using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.IO; // Thêm thư viện này để sử dụng class Path
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel.Tables;
using System.Diagnostics;
using static System.Windows.Forms.LinkLabel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Formats.Tar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Firebase.Storage;
using Microsoft.VisualBasic.ApplicationServices;
namespace DangKi_DangNhap
{
    public partial class GiaoBaoTapAdmin : Form
    {
        private int currentTopPosition = 0;
        private const string Bucket = "databeseaccess.appspot.com";
        private IFirebaseClient firebaseClient;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        string tenNhom;
        public GiaoBaoTapAdmin(string tenNhom)
        {
            this.tenNhom = tenNhom;
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            LoadLinksFromFirebase();
          
        }

        private void GiaoBaoTapAdmin_Load(object sender, EventArgs e)
        {

        }

        private async  void bunifuButton24_Click(object sender, EventArgs e)
        {
         
            string link = textBox1.Text.Trim();
            string tenfile = textBox2.Text.Trim();
            string deadline = textBox3.Text;
            string tempNameFile = textBox2.Text;
            DateTime currentTime = DateTime.Now;
            string Date = currentTime.ToString("yyyy-MM-dd"); // Định dạng ngày tháng năm theo yyyy-MM-dd
            if (!string.IsNullOrEmpty(link))
            {
                // Kiểm tra xem tệp có tồn tại không
                if (!File.Exists(link))
                {
                    MessageBox.Show("File không tồn tại!");
                    return;
                }
               
                // Đọc nội dung của tệp
                byte[] fileBytes = File.ReadAllBytes(link);

                // Tạo một đường dẫn duy nhất trên Firebase Storage để lưu trữ tệp
                //  string fileName = Path.GetFileName(link);
                string uniquePath = $"{tenNhom}/{tenfile}";

                // Tải lên nội dung của tệp lên Firebase Storage
                try
                {
                    // Khởi tạo Firebase Storage
                    var firebaseStorage = new FirebaseStorage(Bucket);

                    // Lưu trữ tệp lên Firebase Storage
                    await firebaseStorage.Child(uniquePath).PutAsync(new MemoryStream(fileBytes));

                    // Tạo đường dẫn tới tệp trên Firebase Storage
                    string firebaseStoragePath = await firebaseStorage.Child(uniquePath).GetDownloadUrlAsync();

                    // Lưu thông tin về tệp vào Firebase Realtime Database
               
                    var data = new Dictionary<string, object>
            {
                { "BaiTap", tenfile }
            };

                    var data1 = new Dictionary<string, object>
            {
                {  deadline, true}
            };
                    FirebaseResponse response = await firebaseClient.UpdateAsync($"GiaoBaiTap/{tenNhom}", data);
                    FirebaseResponse response1 = await firebaseClient.UpdateAsync($"GiaoBaiTap/{tenNhom}/ThoiHan", data1);
                    // FirebaseResponse response1 = await firebaseClient.UpdateAsync($"TuyenTapTaiLieu/{tenNhom}", data);

                    // Xóa trường nhập và làm mới danh sách tệp
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    richTextBox1.Controls.Clear();
                   
                    await LoadLinksFromFirebase();

                    MessageBox.Show("Tải tệp lên Firebase thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải tệp lên Firebase: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin link và tên!");
            }
        }
        public async Task LoadLinksFromFirebase()
        {
            FirebaseResponse response = await firebaseClient.GetAsync($"GiaoBaiTap/{tenNhom}");
            if (response.Body != "null")
            {
                Dictionary<string, object> fileInfo = response.ResultAs<Dictionary<string, object>>();

                foreach (var pair in fileInfo)
                {

                    AddLinkLabelToRichTextBox(pair.Value.ToString());
                }
            }
        }
        private void AddLinkLabelToRichTextBox(string link)
        {
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Text = link;
            linkLabel.LinkClicked += LinkLabel_LinkClicked;

            // Thiết lập Font cho linkLabel
            linkLabel.Font = new Font(linkLabel.Font, FontStyle.Bold); // Đặt đậm
            linkLabel.Font = new Font(linkLabel.Font.FontFamily, 14); // Đặt kích thước 12

            linkLabel.Width = 2000; // Đặt độ rộng tùy ý
            linkLabel.Height = 30; // Đặt chiều cao tùy ý
                                   // Đặt vị trí dọc cho linkLabel mới
            linkLabel.Top = currentTopPosition;

            // Thêm linkLabel vào RichTextBox
            richTextBox1.Controls.Add(linkLabel);

            // Đặt vị trí của linkLabel bằng với vị trí hiện tại của RichTextBox
            linkLabel.Location = new System.Drawing.Point(0, 0);

            // Tăng giá trị currentTopPosition cho linkLabel tiếp theo
         
        }
        private async void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }
        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textBox1.Text = filePath; // Hiển thị đường dẫn tệp trong textBox1

                // Lấy tên tệp từ đường dẫn và gán vào textBox2

            }
        }
    }
}
