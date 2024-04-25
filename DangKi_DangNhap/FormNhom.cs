using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Database.Query;
using System.Net;
using Firebase.Storage;
using System.Diagnostics;
namespace DangKi_DangNhap
{
    public partial class FormNhom : Form
    {
        public event EventHandler<string> TenNhomCreated;
        public event EventHandler ButtonClickEvent;
        string tenNhom;
        string userName;
        private string filePath;
        string fileName;
        string pra;
        public IFirebaseClient firebaseClient;
        private const string Bucket = "databeseaccess.appspot.com";
        public FormNhom(string tenNhom, string username)
        {
            InitializeComponent();

            this.tenNhom = tenNhom;
            this.userName = username;
            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            link_load();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void link_load()
        {
            FirebaseResponse response = await firebaseClient.GetAsync($"files/{tenNhom}");

            // Kiểm tra xem yêu cầu có thành công hay không
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Trích xuất dữ liệu từ phản hồi
                var responseData = response.ResultAs<Dictionary<string, object>>();

                // Lặp qua từng cặp key-value trong responseData
                foreach (var kvp in responseData)
                {
                    // Lấy giá trị từ mỗi cặp key-value
                    string value = kvp.Value.ToString(); // Chỉ lấy giá trị, không quan tâm đến key

                    // Thêm giá trị vào linkLabel1.Text hoặc làm bất kỳ thao tác nào khác bạn muốn thực hiện
                    pra += value; // Ví dụ: thêm giá trị vào linkLabel1.Text với mỗi giá trị trên một dòng mới
                }
                linkLabel1.Text = pra;
            }
            else
            {
                // Xử lý trường hợp yêu cầu thất bại
                Console.WriteLine("Yêu cầu không thành công: " + response.StatusCode);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            string data = this.userName + ": " + textBox1.Text; // Lấy dữ liệu từ textBox1
            AddPostToRichTextBox(richTextBox1, data);
            // Gọi phương thức để đẩy dữ liệu lên Firebase
            await PushDataToFirebase(tenNhom, data);

        }
        private void AddPostToRichTextBox(RichTextBox richTextBox, string post)
        {
            // Lấy ngày và giờ hiện tại
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Tạo chuỗi văn bản với ngày và giờ đăng bài
            string postWithDateTime = $"[{dateTime}] {post}";

            // Đặt văn bản của bài đăng
            richTextBox.Text = postWithDateTime;

            // Định dạng văn bản
            richTextBox.Font = new Font("Arial", 12); // Font chữ
            richTextBox.ForeColor = Color.Black; // Màu chữ

            // Đặt viền cho RichTextBox
            richTextBox.BorderStyle = BorderStyle.FixedSingle; // Loại viền

            // Đặt màu nền cho RichTextBox
            richTextBox.BackColor = Color.GreenYellow; // Màu nền

            // Đặt màu chữ cho RichTextBox
            richTextBox.ForeColor = Color.Black; // Màu chữ

            // Đặt kích thước cho RichTextBox
            richTextBox.Width = 500; // Độ rộng
            richTextBox.Height = 200; // Độ cao

            // Tạo Panel để chứa Button thích
            Panel panel = new Panel();
            panel.Dock = DockStyle.Bottom; // Đặt Panel ở dưới cùng của RichTextBox

            // Thêm Button thích vào Panel
            Button likeButton = new Button();
            likeButton.Text = "Thích";
            likeButton.Dock = DockStyle.Right; // Đặt Button ở bên phải của Panel
            likeButton.Click += (sender, e) =>
            {
                // Xử lý sự kiện thích bài đăng
                // Ví dụ: tăng số lượt thích và cập nhật trạng thái nút thích
            };
            panel.Controls.Add(likeButton);

            // Thêm Panel vào RichTextBox
            richTextBox.Controls.Add(panel);
        }



        private async Task PushDataToFirebase(string tenNhom, string data)
        {
            try
            {
                // Lấy số lượng bài đăng hiện tại
                int currentPostsCount = await GetCurrentPostsCount(tenNhom);

                // Tạo key cho bài đăng mới
                string newPostKey = $"baidang{currentPostsCount + 1}";

                // Tạo một đối tượng chứa dữ liệu cần đẩy lên Firebase
                var postData = new Dictionary<string, object>
        {
            { newPostKey, data }
        };

                // Thực hiện đẩy dữ liệu lên Firebase
                FirebaseResponse response = await firebaseClient.UpdateAsync($"group /{tenNhom}/ports", postData);

                // Kiểm tra xem dữ liệu đã được đẩy thành công hay không
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Dữ liệu đã được đẩy lên Firebase thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi đẩy dữ liệu lên Firebase!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<int> GetCurrentPostsCount(string tenNhom)
        {
            // Truy vấn dữ liệu từ Firebase để lấy số lượng bài đăng hiện tại
            FirebaseResponse response = await firebaseClient.GetAsync($"group /{tenNhom}/ports");
            if (response.Body == "null")
            {
                return 0; // Nếu không có bài đăng nào thì trả về 0
            }
            else
            {
                // Parse dữ liệu và trả về số lượng bài đăng
                Dictionary<string, object> postData = response.ResultAs<Dictionary<string, object>>();
                return postData.Count;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            pra = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                fileName = Path.GetFileName(filePath);
                UploadFileAsync(filePath);
                // Gán đường dẫn của file vào LinkLabel1

                //linkLabel1.Tag = filePath; // Lưu đường dẫn của file vào Tag của LinkLabel1
                var data1 = new Dictionary<string, object>
                {
                    { userName , fileName }
                };

                FirebaseResponse response1 = await firebaseClient.SetAsync($"files/{tenNhom}", data1);
                if (response1.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Dữ liệu đã được đẩy lên Firebase thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi đẩy dữ liệu lên Firebase!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                link_load();
            }
        }

        private async Task UploadFileAsync(string filePath)
        {
            try
            {
                using (var stream = File.Open(filePath, FileMode.Open)) // Open the file stream
                {
                    var storage = new FirebaseStorage(Bucket);
                    var uploadTask = storage
                        .Child(tenNhom)

                        .Child(Path.GetFileName(filePath))
                        .PutAsync(stream); // bỏ qua CancellationToken

                    uploadTask.Progress.ProgressChanged += (s, e) =>
                    {
                        Console.WriteLine($"Progress: {e.Percentage}%");
                        // Update UI here if needed
                    };

                    // You can cancel the upload by calling cancellationTokenSource.Cancel()

                    var downloadUrl = await uploadTask;
                    Console.WriteLine("Download link:\n" + downloadUrl);
                    // Close the file stream after upload


                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex.Message);
            }
        }

        private async Task DownloadFileFromStorage()
        {
            try
            {
                string a = tenNhom;
                string b = linkLabel1.Text;

                var storage = new FirebaseStorage(Bucket);
                var downloadUrl = await storage
                    .Child(a).Child(b)
                    .GetDownloadUrlAsync();

                // Start a new process to download the file
                Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe", downloadUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await DownloadFileFromStorage();
        }



        private async void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn rời nhóm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    // Xóa nhoms
                    FirebaseResponse res = firebaseClient.Delete("nhoms/" + userName + "/" + tenNhom);

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Đã rời khỏi nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hiển thị form tạo nhóm
                        var form = new TaoNhom(userName);

                        // Đóng form hiện tại
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể rời khỏi nhóm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormNhom_Load(object sender, EventArgs e)
        {

        }
    }
}


