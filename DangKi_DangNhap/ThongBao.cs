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
using MigraDoc.DocumentObjectModel.Internals;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DangKi_DangNhap
{
    public partial class ThongBao : Form
    {
        public IFirebaseClient firebaseClient;
        private readonly string userName;
        private string[] all_nhom;
        public ThongBao(string user)
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
            loadnotify_nhom1();
            loadnotify_nhom();
        }
        private async Task loadnotify_nhom()
        {
            try
            {
                // Truy vấn dữ liệu từ Firebase
                FirebaseResponse response = await firebaseClient.GetAsync($"nhoms/{userName}");
                if (response.Body == "null")
                {
                    return;
                }

                // Parse dữ liệu trả về thành một danh sách các nhóm
                Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();

                // Duyệt qua danh sách nhóm và tạo các button nhóm tương ứng
                List<string> allNhom = new List<string>();
                foreach (var pair in nhomData)
                {
                    string nhom = pair.Key;
                    allNhom.Add(nhom);
                }

                await addNhom(allNhom.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task addNhom(string[] allNhom)
        {
            List<(string, string)> notifications = new List<(string, string)>(); // Tuple to store notifications

            foreach (string nhom in allNhom)
            {
                // Truy vấn dữ liệu từ Firebase
                FirebaseResponse response = await firebaseClient.GetAsync($"Notify_TL/{nhom}");

                if (response.Body == "null")
                {
                    continue; // Skip to next iteration
                }

                // Parse dữ liệu trả về thành một danh sách các nhóm
                Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();

                foreach (var pair in nhomData)
                {
                    string datetime = pair.Key.ToString();
                    string nhoms = pair.Value.ToString();
                    notifications.Add((datetime, nhoms)); // Add notification to list
                }

            }

            // Order notifications by timeDifference
            var sortedNotifications = notifications.OrderBy(notification => GetTimeDifference(notification.Item1));

            foreach (var notification in sortedNotifications)
            {
                AddPostToRichTextBox1(notification.Item1, notification.Item2);
            }
        }

        private TimeSpan GetTimeDifference(string datetime)
        {
            DateTime datenow = DateTime.Now;
            DateTime dateTime_before;
            DateTime.TryParseExact(datetime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_before);
            return datenow - dateTime_before;
        }

        private async void AddPostToRichTextBox1(string datetime, string nhoms)
        {
            /*TimeSpan timeDifference = GetTimeDifference(datetime);*/

            /*string result = "   " + nhoms + " mới có file mới được upload vào " +
                        timeDifference.Days.ToString() + " ngày " +
                        timeDifference.Hours.ToString() + " giờ " +
                        timeDifference.Minutes.ToString() + " phút " +
                        timeDifference.Seconds.ToString() + " giây trước";*/
            string result = datetime + " " + nhoms + " có file mới.";
            richTextBox5.AppendText(result + Environment.NewLine);


        }



        /// <summary>
        /// 
        private async Task loadnotify_nhom1()
        {
            try
            {
                // Truy vấn dữ liệu từ Firebase
                FirebaseResponse response = await firebaseClient.GetAsync($"nhoms/{userName}");
                if (response.Body == "null")
                {
                    return;
                }

                // Parse dữ liệu trả về thành một danh sách các nhóm
                Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();

                // Duyệt qua danh sách nhóm và tạo các button nhóm tương ứng
                List<string> allNhom = new List<string>();
                foreach (var pair in nhomData)
                {
                    string nhom = pair.Key;
                    allNhom.Add(nhom);
                }

                await addNhom1(allNhom.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task addNhom1(string[] allNhom)
        {
            List<(string, string)> notifications = new List<(string, string)>(); // Tuple to store notifications

            foreach (string nhom in allNhom)
            {
                // Truy vấn dữ liệu từ Firebase

                FirebaseResponse response1 = await firebaseClient.GetAsync($"group /{nhom}/message");
                if (response1.Body == "null")
                {
                    continue; // Skip to next iteration
                }

                // Parse dữ liệu trả về thành một danh sách các nhóm

                Dictionary<string, object> nhomData1 = response1.ResultAs<Dictionary<string, object>>();

                foreach (var pair in nhomData1)
                {
                    string datetime = pair.Key.ToString();
                    string nhoms = pair.Value.ToString();
                    notifications.Add((datetime, nhoms)); // Add notification to list
                }
            }

            // Order notifications by timeDifference
            var sortedNotifications = notifications.OrderBy(notification => GetTimeDifference1(notification.Item1));

            foreach (var notification in sortedNotifications)
            {
                AddPostToRichTextBox11(notification.Item1, notification.Item2);
            }
        }

        private TimeSpan GetTimeDifference1(string datetime)
        {
            DateTime datenow = DateTime.Now;
            DateTime dateTime_before;
            DateTime.TryParseExact(datetime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime_before);
            return datenow - dateTime_before;
        }

        private async void AddPostToRichTextBox11(string datetime, string nhoms)
        {
            /*TimeSpan timeDifference = GetTimeDifference(datetime);

            string result = "   " + nhoms + " mới có 1 bài đăng mới vào " +
                        timeDifference.Days.ToString() + " ngày " +
                        timeDifference.Hours.ToString() + " giờ " +
                        timeDifference.Minutes.ToString() + " phút " +
                        timeDifference.Seconds.ToString() + " giây trước";*/
            string result = datetime + " " + nhoms + " có bài đăng mới.";
            richTextBox6.AppendText(result + Environment.NewLine);


        }
        /// ///////////////////////////////////////
        /// </summary>
        private async void loadnotify_ll()
        {
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
                richTextBox2.AppendText("   " + values + Environment.NewLine);
            }
            else if (totalDays == 1)
            {
                string values = $"còn 1 ngày nữa là đến: {value}";
                richTextBox2.AppendText("   " + values + Environment.NewLine);
            }
            else if (totalDays == 2)
            {
                string values = $"còn 2 ngày nữa là đến: {value}";
                richTextBox2.AppendText("   " + values + Environment.NewLine);
            }

            else if (totalDays == 3)
            {
                string values = $"còn 3 ngày nữa là đến: {value}";
                richTextBox2.AppendText("   " + values + Environment.NewLine);
            }

            // Append the notification to the RichTextBox with a new line

        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {

        }

        private void ThongBao_Load_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
