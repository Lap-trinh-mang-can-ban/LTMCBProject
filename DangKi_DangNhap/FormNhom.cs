using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Database.Query;
using Firebase.Storage;
using System.Net;
using System.Diagnostics;
using static Google.Apis.Requests.BatchRequest;
using FirebaseAdmin.Messaging;
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
        public bool isFirstLoad = true;
        public IFirebaseClient firebaseClient;
        private const string Bucket = "databeseaccess.appspot.com";
        public string key;
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

            SubscribeToFirebase();
            SubscribeToFirebase1();
        }

        private async void SubscribeToFirebase1()
        {


            string urls = "group /" + tenNhom + "/message";
            // Đăng ký sự kiện để theo dõi thay đổi trong node Firebase
            EventStreamResponse response = await firebaseClient.OnAsync(urls, (sender, args, context) =>
            {
                if (isFirstLoad)
                {
                    isFirstLoad = false;
                }
                else
                {
                    LoadLatestDataToRichTextBox();
                }
            });


        }


        private async Task LoadLatestDataToRichTextBox()
        {
            /*try
            {*/
            // Truy vấn dữ liệu từ Firebase để lấy phần tử cuối cùng
            FirebaseResponse response = await firebaseClient.GetAsync($"group /{tenNhom}/ports"); // Thay "your-node" bằng tên node bạn muốn truy vấn

            // Kiểm tra xem có dữ liệu trả về không

            if (response.Body != "null")
            {
                // Lấy dữ liệu từ Firebase
                var data = response.ResultAs<Dictionary<string, string>>();

                // Lấy phần tử cuối cùng từ dictionary
                KeyValuePair<string, string> latestItem = new KeyValuePair<string, string>();
                foreach (var item in data)
                {
                    latestItem = item;

                }

                // Hiển thị dữ liệu mới nhất lên RichTextBox
                richTextBox1.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.AppendText(latestItem.Value + Environment.NewLine);

                });
            }

            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu từ Firebase: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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



        private async void bunifuButton23_Click(object sender, EventArgs e)
        {
            string data = this.userName + ": " + textBox1.Text; // Lấy dữ liệu từ textBox1

            await PushDataToFirebase(tenNhom, data);
        }



        private async Task PushDataToFirebase(string tenNhom, string data)
        {
            /*try
            {*/

            key = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Tạo key cho bài đăng mới


            // Tạo một đối tượng chứa dữ liệu cần đẩy lên Firebase
            var postData = new Dictionary<string, object>
        {
            { key, data }
        };
            var postData1 = new Dictionary<string, object>
        {
            { key, key }
        };

            // Thực hiện đẩy dữ liệu lên Firebase
            FirebaseResponse response = await firebaseClient.UpdateAsync($"group /{tenNhom}/ports", postData);
            FirebaseResponse response1 = await firebaseClient.SetAsync($"group /{tenNhom}/message", postData1);
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
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }



        private async void bunifuButton22_Click(object sender, EventArgs e)
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
        private async Task UploadFileAsync(string filePath)
        {
            /*try
            {*/
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
            /*}
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex.Message);
            }*/
        }

        // btn_click_link open File on this page
        private async void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await DownloadFileFromStorage();
        }


        private async Task DownloadFileFromStorage()
        {
            if (linkLabel1.Text == "Upload File môn học.")
                return;
            /*try
            {*/
            string a = tenNhom;
            string b = linkLabel1.Text;

            var storage = new FirebaseStorage(Bucket);
            var downloadUrl = await storage
                .Child(a).Child(b)
                .GetDownloadUrlAsync();

            // Start a new process to download the file
            Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe", downloadUrl);
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex.Message);
             }*/
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn rời nhóm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                /* try
                 {*/

                // Xóa nhoms
                FirebaseResponse res = firebaseClient.Delete("nhoms/" + userName + "/" + tenNhom);
                FirebaseResponse res1 = firebaseClient.Delete("group /" + tenNhom + "/" + userName);
                if ((res.StatusCode == System.Net.HttpStatusCode.OK) && (res1.StatusCode == System.Net.HttpStatusCode.OK))
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
                /*}
                    catch (Exception ex)
                    {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            }
        }


        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            MoiVaoNhom invite = new MoiVaoNhom(tenNhom);
            invite.Show();
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            KhoTaiLieu tl = new KhoTaiLieu(tenNhom, userName);
            tl.Show();
        }
    }
}


