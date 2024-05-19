using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
namespace DangKi_DangNhap
{
    public partial class UserControl2 : UserControl
    {
        public static string static_day;
        private readonly string userName;
        private readonly IFirebaseClient firebaseClient;
        public UserControl2(string user)
        {
            InitializeComponent();
            userName = user;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            if (firebaseClient == null)
            {
                MessageBox.Show("Không thể kết nối tới máy chủ Firebase");
            }
        }


        public void UserControl2_Load(object sender, EventArgs e)
        {
           // DisplayEvent(number);
        }
        public void Days(int num)
        {
            lbDays.Text = num + "";
        }

        private async void UserControl2_Click(object sender, EventArgs e)
        {
            static_day = lbDays.Text;
            // Gọi form sự kiện (EventForm)
            EventForm eventform = new EventForm(userName);
            eventform.Show();

            // Ghi sự kiện lên Firebase
           // await SaveEventToFirebase();
        }

        private async Task SaveEventToFirebase()
        {
            try
            {
                // Ghi dữ liệu sự kiện lên Firebase cho ngày cụ thể của người dùng
                FirebaseResponse response = await firebaseClient.SetAsync($"Calendar/{userName}/{static_day}", "Event Data");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Sự kiện đã được lưu trữ thành công.");
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi lưu trữ sự kiện.");
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Đã xảy ra lỗi khi lưu trữ sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void DisplayEvent(int number)
        {
            DateTime now = DateTime.Now;
          int month = now.Month;
          int year = now.Year;
          int static_month = month;
          int static_year = year;
          //int days = DateTime.DaysInMonth(year, month);
         
            try
            {
                // Truy vấn dữ liệu từ Firebase cho ngày cụ thể của người dùng
               // FirebaseResponse response = await firebaseClient.GetAsync($"Calendar/{userName}/{lbDays.Text}");

                // Kiểm tra xem dữ liệu có tồn tại không
               
              
                  string eventDate = $"{LapLich.static_month}_{number}_{LapLich.static_year}";
                    FirebaseResponse response = await firebaseClient.GetAsync($"Calendar/{userName}/{eventDate}");
                  
                if (response.Body == "null")
                    {
                    // MessageBox.Show("Không tìm thấy dữ liệu cho ngày này.");
                    // Nếu không có dữ liệu, xóa nội dung của lbEvent
                    lbEvent.Text = "";
                }
                else
                {
                    lbEvent.Text = response.Body;
                }
               
               

                // Hiển thị dữ liệu trong lbEvent
                // lbEvent.Text = response.Body;
            }
            catch (Exception ex)
            {
                // Xử lý các trường hợp lỗi
              //  MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        public void ColorBack(int ngay, int thang)
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            if(month==thang)
            {
                if (ngay == day)
                {
                    this.BackColor = Color.SteelBlue;  // Đổi màu nền của UserControl2 thành màu SteelBlue
                    lbEvent.BackColor = Color.SteelBlue;
                    lbEvent.ForeColor = Color.OldLace;
                    lbDays.ForeColor = Color.OldLace;
                }
                else
                {
                    this.BackColor = Color.OldLace; 
                    lbEvent.ForeColor = Color.Navy;
                    lbDays.ForeColor = Color.Navy;
                }
            }
            else
            {
                this.BackColor = Color.OldLace;  // Đổi màu nền của UserControl2 thành màu SteelBlue
                lbEvent.BackColor = Color.OldLace;
                lbEvent.ForeColor = Color.Navy;
                lbDays.ForeColor = Color.Navy;
            }
           
        }
        private void lbDays_Click(object sender, EventArgs e)
        {

        }

        private void lbEvent_Click(object sender, EventArgs e)
        {

        }
    }
}
