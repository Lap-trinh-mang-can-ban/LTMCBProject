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
        static int i = 0;
        public IFirebaseClient firebaseClient;
        private const string Bucket = "databeseaccess.appspot.com";
        public FormNhom(string tenNhom, string username)
        {
            InitializeComponent();
            richTextBox1.Text = string.Empty;
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
            // Liên kết sự kiện Form_Load với hàm xử lý FormNhom_Load
            this.Load += FormNhom_Load;


        }

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async Task link_load()
        {
            string pra = "";


            FirebaseResponse response = await firebaseClient.GetAsync($"files/{tenNhom}");
            if (response == null || response.Body == "null")
            {

                return;
            }
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

            }
        }

        private async Task SubscribeToFirebase()
        {
            // Subscribe to changes in the "files" node of the Firebase database
            await firebaseClient.OnAsync($"files/{tenNhom}", async (sender, args, context) =>
            {
                // Reload data whenever there's a change in the database
                await link_load();
            });

            
        }
        private async Task SubscribeToFirebase1()
        {
            // Subscribe to changes in the "files" node of the Firebase database
            


            await firebaseClient.OnAsync($"group /{tenNhom}/ports", async (sender, args, context) =>
            {
                // Reload data whenever there's a change in the database
                await LoadClick(tenNhom, richTextBox1);
            });
        }


        private async void button1_Click(object sender, EventArgs e)
        {

            string data = this.userName + ": " + textBox1.Text; // Lấy dữ liệu từ textBox1
            /*AddPostToRichTextBox(richTextBox1, data);*/
            // Gọi phương thức để đẩy dữ liệu lên Firebase
            await PushDataToFirebase(tenNhom, data);

        }
        /* private void AddPostToRichTextBox(RichTextBox richTextBox, string post)
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



             // Đặt màu chữ cho RichTextBox
             richTextBox.ForeColor = Color.Black; // Màu chữ


         }*/



        private async Task PushDataToFirebase(string tenNhom, string data)
        {
            try
            {
                

                // Tạo key cho bài đăng mới
                string newPostKey = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                data = date + " " + data;
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
                    textBox1.Text = string.Empty;
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


        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                fileName = Path.GetFileName(filePath);
                await UploadFileAsync(filePath);
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
                await link_load();
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
            if (linkLabel1.Text == "Upload File môn học.")
                return;
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

        private async void FormNhom_Load(object sender, EventArgs e)
        {
            await SubscribeToFirebase1();
            await SubscribeToFirebase();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public async Task<Dictionary<string, object>> GetGroupData(string tenNhom)
        {
            try
            {
                // Truy vấn dữ liệu từ Firebase để lấy dữ liệu của nhóm
                FirebaseResponse response = await firebaseClient.GetAsync($"group /{tenNhom}/ports");
                if (response.Body == "null")
                {
                    MessageBox.Show("Không tìm thấy dữ liệu của nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                // Parse dữ liệu trả về thành một Dictionary<string, object>
                Dictionary<string, object> groupData = response.ResultAs<Dictionary<string, object>>();

                return groupData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi GetGroupData: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task LoadClick(string tenNhom, RichTextBox richTextBox)
        {
            try
            {
                // Gọi phương thức để lấy dữ liệu của nhóm từ Firebase
                Dictionary<string, object> groupData = await GetGroupData(tenNhom);

                // Kiểm tra nếu dữ liệu không null
                if (groupData != null)
                {
                    // Xóa nội dung cũ trong RichTextBox trước khi thêm mới
                    richTextBox.Clear();

                    // Thêm các bài đăng vào RichTextBox và định dạng chúng
                    foreach (var post in groupData.Values)
                    {
                        await AddPostToRichTextBox(richTextBox, post.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi LoadClick: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AddPostToRichTextBox(RichTextBox richTextBox, string post)
        {
            // Thêm bài đăng vào RichTextBox
            richTextBox.AppendText(post + Environment.NewLine);

            
        }

        private void FormNhom_FormClosing(object sender, FormClosingEventArgs e)
        {
           

            // Giải phóng tài nguyên của richTextBox1
            richTextBox1.Dispose();
        }
    }
}


