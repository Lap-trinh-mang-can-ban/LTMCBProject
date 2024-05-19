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
    public partial class GiaoBaiTap : Form
    {
        private int currentTopPosition = 0;
        private const string Bucket = "databeseaccess.appspot.com";
        private IFirebaseClient firebaseClient;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        string tenNhom;
        public GiaoBaiTap(string tenNhom)
        {
            InitializeComponent();
            this.tenNhom = tenNhom;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            LoadLinksFromFirebase();
            //  AddTimeLabelToPanel(); // Thêm label hiển thị thời gian lên Panel
        }


        public async Task LoadLinksFromFirebase()
        {
            FirebaseResponse response = await firebaseClient.GetAsync($"GiaoBaiTap/{tenNhom}");
            FirebaseResponse response2 = await firebaseClient.GetAsync($"GiaoBaiTap/{tenNhom}/ThoiHan");
            if (response2.Body != "null")
            {
                Dictionary<string, object> fileInfo = response2.ResultAs<Dictionary<string, object>>();

                foreach (var pair in fileInfo)
                {
                    label5.Text = pair.Key;
                }

            }
            if (response.Body != "null")
            {
                Dictionary<string, object> fileInfo = response.ResultAs<Dictionary<string, object>>();

                foreach (var pair in fileInfo)
                {
                    AddLinkLabelToPanel(pair.Value.ToString());
                }
            }
        }

        private void AddLinkLabelToPanel(string link)
        {
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Text = link;
            linkLabel.LinkClicked += LinkLabel_LinkClicked;

            // Thiết lập Font cho linkLabel
            linkLabel.Font = new Font(linkLabel.Font, FontStyle.Bold); // Đặt đậm
            linkLabel.Font = new Font(linkLabel.Font.FontFamily, 14); // Đặt kích thước 12

            linkLabel.Width = 2000; // Đặt độ rộng tùy ý
            linkLabel.Height = 30; // Đặt chiều cao tùy ý
            linkLabel.Top = currentTopPosition; // Đặt vị trí dọc cho linkLabel mới

            // Thêm linkLabel vào Panel
            panel1.Controls.Add(linkLabel);

            // Tăng giá trị currentTopPosition cho linkLabel tiếp theo

        }

        private async void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Code xử lý khi click vào LinkLabel
        }

     
        
        static DateTime ConvertStringToDate(string dateStr)
        {

            // Phân tách chuỗi thành các phần ngày, tháng, năm
            string[] parts = dateStr.Split('_');

            // Chuyển đổi các phần thành số nguyên
            int day = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int year = int.Parse(parts[2]);

            // Tạo đối tượng DateTime từ các phần đã chuyển đổi
            DateTime date = new DateTime(year, month, day);

            return date;
        }

        private void GiaoBaiTap_Load(object sender, EventArgs e)
        {

        }

        private void NopBai_Click(object sender, EventArgs e)
        {
            string dateStr = label5.Text;
            if (dateStr != "")
            {
                DateTime date = ConvertStringToDate(dateStr);

                // Lấy ngày tháng năm hiện tại
                DateTime today = DateTime.Today;

                // So sánh
                if (date <= today)
                {
                    MessageBox.Show("Đã quá thời hạn nộp bài!");
                }
            }
          
           
        }
    }
}
