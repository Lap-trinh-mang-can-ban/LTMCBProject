using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace DangKi_DangNhap
{
    public partial class FormNhom : Form
    {
        public event EventHandler ButtonClickEvent;
        private string tenNhom;
        private string userName;
        private readonly IFirebaseClient firebaseClient;
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
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.Title = "Chọn file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

                // Gán đường dẫn của file vào LinkLabel1
                linkLabel1.Text = fileName;
                linkLabel1.Tag = filePath; // Lưu đường dẫn của file vào Tag của LinkLabel1
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Kiểm tra xem đường dẫn của file có tồn tại không
            if (linkLabel1.Tag != null && File.Exists(linkLabel1.Tag.ToString()))
            {
                try
                {
                    // Mở file PDF bằng Adobe Acrobat Reader
                    System.Diagnostics.Process.Start("AcroRd32.exe", linkLabel1.Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi mở file PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại hoặc đường dẫn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


