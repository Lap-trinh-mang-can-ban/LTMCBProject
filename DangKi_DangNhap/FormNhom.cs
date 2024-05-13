﻿using System;
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
using Microsoft.VisualBasic.ApplicationServices;
namespace DangKi_DangNhap
{
    public partial class FormNhom : Form
    {
        // Cài đặt lề cho RichTextBox
        
        public string SelectedEmoticon { get; private set; }
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
        public string usern;
        public FormNhom(string tenNhom, string username)
        {
            InitializeComponent();
            this.tenNhom = tenNhom;
            usern = username;
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
            richTextBox1.Padding = new Padding(10);
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
                string post = latestItem.Value.ToString();
                // Hiển thị dữ liệu mới nhất lên RichTextBox
                richTextBox1.Invoke((MethodInvoker)delegate
                {
                    // Thêm bài đăng vào RichTextBox
                    string postWithEmoji = post.Replace(":)", "😊")
                                               .Replace("<3", "❤️")
                                               .Replace(":))", "🤣")
                                               .Replace("=)", "😊")
                                               .Replace(":(", "🙁");


                    richTextBox1.SelectionIndent = 10; // Đặt độ lề trái là 20 (đơn vị là pixel)
                    richTextBox1.SelectionRightIndent = 10; // Đặt độ lề phải là 20 (đơn vị là pixel)
                    bool isCurrentUser = post.Contains(usern);
                    if (isCurrentUser)
                    {
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                        richTextBox1.AppendText(postWithEmoji + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                    }
                    else
                    {
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        richTextBox1.AppendText(postWithEmoji + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                    }


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
           
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!");
                return;
            }
            else
            {
                string data = this.userName + ": " + textBox1.Text; // Lấy dữ liệu từ textBox1
                await PushDataToFirebase(tenNhom, data);
            }
            

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
            { key, tenNhom }
        };

            // Thực hiện đẩy dữ liệu lên Firebase
            FirebaseResponse response = await firebaseClient.UpdateAsync($"group /{tenNhom}/ports", postData);
            FirebaseResponse response1 = await firebaseClient.SetAsync($"group /{tenNhom}/message", postData1);
            // Kiểm tra xem dữ liệu đã được đẩy thành công hay không
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //MessageBox.Show("Dữ liệu đã được đẩy lên Firebase thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                FirebaseResponse res1 = firebaseClient.Delete($"group /{tenNhom}");
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

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            ShowIconSuggestionPopup();
        }
        private void ShowIconSuggestionPopup()
        {
            Form iconSuggestionForm = new Form();
            iconSuggestionForm.FormBorderStyle = FormBorderStyle.None; // Remove border
            iconSuggestionForm.StartPosition = FormStartPosition.Manual;
            iconSuggestionForm.BackColor = Color.LightGreen; // Set background color
            iconSuggestionForm.TransparencyKey = Color.LightGreen; // Make the background color transparent
            iconSuggestionForm.Location = new Point(this.Location.X + bunifuButton26.Location.X,
                                                    this.Location.Y + bunifuButton26.Location.Y + bunifuButton26.Height + 40);
            iconSuggestionForm.Width = 550; // Increase width to fit 5 icons per row
            iconSuggestionForm.Height = 300;

            List<string> iconSuggestions = new List<string> { "❤️", "😎", "👍", "😁", "😢", "😊", "😀", "👌", "😍", "😌",
                                                              "🥰", "😇", "😅", "😂", "🤩", "📚", "🎓", "🖊️", "📝", "🧠" };

            int xPos = 10;
            int yPos = 10;
            int iconsPerRow = 10;
            int iconSpacing = 5;
            int iconSize = 40; // Adjust icon size as needed

            foreach (string icon in iconSuggestions)
            {
                Button iconButton = new Button();
                iconButton.Text = icon;
                iconButton.Font = new Font("Segoe UI Emoji", 12);
                iconButton.AutoSize = true;
                iconButton.FlatStyle = FlatStyle.Flat; // Remove button border
                iconButton.FlatAppearance.BorderSize = 0; // Remove button border
                iconButton.BackColor = Color.LightGray; // Set button background color to match form's background
                iconButton.Size = new Size(iconSize, iconSize); // Set icon size
                iconButton.Location = new Point(xPos, yPos);
                iconButton.Click += (sender, e) =>
                {
                    textBox1.Text += icon;
                    iconSuggestionForm.Close();
                };
                iconSuggestionForm.Controls.Add(iconButton);

                // Move to the next row if the maximum number of icons per row is reached
                if ((iconSuggestions.IndexOf(icon) + 1) % iconsPerRow == 0)
                {
                    xPos = 10;
                    yPos += iconSize + iconSpacing;
                }
                else
                {
                    xPos += iconSize + iconSpacing;
                }
            }

            iconSuggestionForm.ShowInTaskbar = false; // Don't show in taskbar
            iconSuggestionForm.ShowIcon = false; // Hide icon
            iconSuggestionForm.TopMost = true; // Ensure it stays on top
            iconSuggestionForm.Show(); // Show the form
        }

    }
}


