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
namespace DangKi_DangNhap
{
    public partial class KhoTaiLieu : Form
    {
        private int currentTopPosition = 0;
        private IFirebaseClient firebaseClient;
        private string tenNhom;
        private string user;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private const string Bucket = "databeseaccess.appspot.com";
        // Di chuyển khai báo của hộp thoại mở tệp ra khỏi sự kiện

        public KhoTaiLieu(string tenNhom, string userName)
        {
            this.tenNhom = tenNhom;
            this.user = userName;
            InitializeComponent();
            InitializeFirebase();
            LoadLinksFromFirebase();

        }

        private void InitializeFirebase()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
        }

        private async void bunifuButton24_Click(object sender, EventArgs e)
        {
            string link = textBox1.Text.Trim();
            string filename = Path.GetFileNameWithoutExtension(link);

            string extension = "";
            int underscoreIndex = filename.LastIndexOf('_'); // Find the last underscore index
            if (underscoreIndex != -1 && underscoreIndex < filename.Length - 1) // Check if underscore exists and it's not the last character
            {
                extension = filename.Substring(underscoreIndex + 1); // Get the substring after the underscore
                int dotIndex = extension.LastIndexOf('.'); // Find the last dot index
                if (dotIndex != -1) // Check if dot exists
                {
                    extension = extension.Substring(0, dotIndex); // Exclude the .hex part
                }
            }
            string tenfile = $"{textBox2.Text.Trim()}_{extension}";
            string tempNameFile = $"{textBox2.Text}_{extension}";
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
                    var newTL = new TaiLieu
                    {
                        UserUp = user,
                        PathFile = firebaseStoragePath, // Lưu đường dẫn tới tệp trên Firebase Storage
                        Date = Date,
                        fileName = tenfile,
                    };
                    var data = new Dictionary<string, object>
            {
                { tempNameFile, true }
            };

                    var data_notify = new Dictionary<string, object>
                    {
                        {currentTime.ToString("yyyy-MM-dd HH:mm:ss"), $"{tenNhom}" }
                    };
                    FirebaseResponse response = await firebaseClient.UpdateAsync($"TaiLieu/{tenNhom}/{tenfile}", newTL);
                    FirebaseResponse response1 = await firebaseClient.UpdateAsync($"TuyenTapTaiLieu/{tenNhom}", data);
                    FirebaseResponse response2 = await firebaseClient.SetAsync($"Notify_TL/{tenNhom}", data_notify);
                    // Xóa trường nhập và làm mới danh sách tệp
                    textBox1.Clear();
                    textBox2.Clear();
                    richTextBox1.Controls.Clear();
                    currentTopPosition = 0;
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
            FirebaseResponse response = await firebaseClient.GetAsync($"TuyenTapTaiLieu/{tenNhom}");
            if (response.Body != "null")
            {
                Dictionary<string, object> fileInfo = response.ResultAs<Dictionary<string, object>>();

                foreach (var pair in fileInfo)
                {

                    AddLinkLabelToRichTextBox(pair.Key);
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
            linkLabel.Font = new Font(linkLabel.Font.FontFamily, 12); // Đặt kích thước 12

            linkLabel.Width = 2000; // Đặt độ rộng tùy ý
            linkLabel.Height = 30; // Đặt chiều cao tùy ý
                                   // Đặt vị trí dọc cho linkLabel mới
            linkLabel.Top = currentTopPosition;

            // Thêm linkLabel vào RichTextBox
            richTextBox1.Controls.Add(linkLabel);

            // Đặt vị trí của linkLabel bằng với vị trí hiện tại của RichTextBox
            linkLabel.Location = new System.Drawing.Point(0, currentTopPosition);

            // Tăng giá trị currentTopPosition cho linkLabel tiếp theo
            currentTopPosition += linkLabel.Height + 5; // Thêm một khoảng trống
        }

        private bool closeButtonClicked = false; // Biến để xác định xem nút "x" đã được nhấn hay không
        private async void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            LinkLabel linkLabel0 = sender as LinkLabel;
            string nameF = linkLabel0.Text;
            FirebaseResponse FileResponse = await firebaseClient.GetAsync($"TaiLieu/{tenNhom}/{nameF}");
            var TepTin = FileResponse.ResultAs<TaiLieu>();

            this.Hide();
            ThongTinFile f = new ThongTinFile(linkLabel0, tenNhom, TepTin);
            f.FormClosing += ThongTinFile_FormClosing;
            f.ShowDialog();

            // Hiển thị form ThongTinFile và chờ đợi cho đến khi nó được đóng
            if (closeButtonClicked)
                return;

            this.Show();
            // Kiểm tra kết quả trả về từ form ThongTinFile


        }

        private void ThongTinFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem nguyên nhân của sự kiện FormClosing là do nút "x" được nhấn hay không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Đặt biến closeButtonClicked thành true để biết rằng nút "x" đã được nhấn
                closeButtonClicked = true;
            }
        }


        private string DecodePath(string encodedPath)
        {
            byte[] bytes = Convert.FromBase64String(encodedPath);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textBox1.Text = filePath; // Hiển thị đường dẫn tệp trong textBox1

                // Lấy tên tệp từ đường dẫn và gán vào textBox2

            }
        }

        private string EncodePath(string path)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(path);
            return Convert.ToBase64String(bytes);
        }

        private void KhoTaiLieu_Load_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            MaHoaFile maHoaFile = new MaHoaFile();
            maHoaFile.ShowDialog();
        }
    }
    public class TaiLieu
    {
        public string UserUp { get; set; }
        public string PathFile { get; set; }
        public string Date { get; set; }
        public string fileName { get; set; }
     
    }
}
