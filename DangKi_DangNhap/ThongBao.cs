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
using Microsoft.VisualBasic.ApplicationServices;
using System.Globalization;

namespace DangKi_DangNhap
{
    public partial class ThongBao : Form
    {
        public IFirebaseClient firebaseClient;
        private readonly string userName;
        public ThongBao(String user)
        {
            InitializeComponent();
            userName = user;
            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            loadnotify_ll();
            loadnotify_nhom();
        }
        private async void loadnotify_nhom()
        {

        }
            private async void loadnotify_ll() {
            try
            {
                // Truy vấn dữ liệu từ Firebase
                FirebaseResponse response = await firebaseClient.GetAsync($"Calendar/{userName}");
                if (response.Body == "null")
                {

                    return;
                }

                // Parse dữ liệu trả về thành một danh sách các nhóm
                Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();

                // Duyệt qua danh sách nhóm và tạo các button nhóm tương ứng
                foreach (var pair in nhomData)
                {
                    string date = pair.Key;
                    string value = pair.Value.ToString();
                    AddPostToRichTextBox(date, value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        private void AddPostToRichTextBox(string date, string value)
        {
            DateTime dateTime_now = DateTime.Now.Date;
            DateTime dateTime_before;
            DateTime.TryParseExact(date, "M_d_yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_before);
            dateTime_before = dateTime_before.Date;
            int totalDays = (dateTime_before - dateTime_now).Days;
            if (totalDays == 0)
            {
                string values = $"hôm nay là đến: {value}";
                richTextBox2.AppendText(values + Environment.NewLine);
            }
            else if(totalDays == 1)
            {
                string values = $"còn 1 ngày nữa là đến: {value}";
                richTextBox2.AppendText(values + Environment.NewLine);
            }
            else if (totalDays == 2) {
                string values = $"còn 2 ngày nữa là đến: {value}";
                richTextBox2.AppendText(values + Environment.NewLine);
            }

            else if (totalDays == 3)
            {
                string values = $"còn 3 ngày nữa là đến: {value}";
                richTextBox2.AppendText(values + Environment.NewLine);
            }

            // Append the notification to the RichTextBox with a new line

        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {

        }

        private void ThongBao_Load_1(object sender, EventArgs e)
        {

        }
    }
}
