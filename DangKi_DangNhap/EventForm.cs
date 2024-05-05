using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class EventForm : Form
    {
        private readonly IFirebaseClient firebaseClient;
        private readonly string _userName;

        public EventForm(string userName)
        {
            InitializeComponent();

            _userName = userName;

            // Cấu hình Firebase
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

        private void EventForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = $"{LapLich.static_month}_{UserControl2.static_day}_{LapLich.static_year}";
        }

        private async void bunifuButton22_Click(object sender, EventArgs e)
        {
            int eventCount = await GetCurrentEventCount();
            string eventName = textBox2.Text.Trim();
            string eventDate = textBox1.Text.Trim();
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(eventName))
            {
                MessageBox.Show("Vui lòng nhập sự kiện.");
                return;
            }

            try
            {
                var data = new Dictionary<string, object>
                {
                    { eventDate, eventName }
                };

                // Thực hiện thêm dữ liệu vào Firebase với tên của người dùng làm nút cha
                FirebaseResponse response = await firebaseClient.UpdateAsync($"Calendar/{_userName}/", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Thêm sự kiện thành công.");

                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm sự kiện.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
      
        private async Task<int> GetCurrentEventCount()
        {
            try
            {
                // Thực hiện truy vấn dữ liệu từ Firebase để lấy danh sách các sự kiện
                FirebaseResponse response = await firebaseClient.GetAsync($"Calendar/{_userName}");

                // Kiểm tra xem có dữ liệu hay không
                if (response.Body != "null")
                {
                    // Parse dữ liệu từ response thành một Dictionary<string, object>
                    Dictionary<string, object> eventData = response.ResultAs<Dictionary<string, object>>();

                    // Trả về số lượng sự kiện hiện có bằng cách đếm số lượng cặp key-value trong Dictionary
                    return eventData.Count;
                }
                else
                {
                    // Trả về 0 nếu không có sự kiện nào tồn tại
                    return 0;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show($"Đã xảy ra lỗi khi lấy số lượng sự kiện: {ex.Message}");
                return -1; // Trả về -1 để chỉ ra lỗi
            }
        }

 
        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            string eventDate = textBox1.Text.Trim();

            try
            {
                // Thực hiện xóa dữ liệu từ Firebase cho ngày cụ thể của người dùng
                FirebaseResponse response = await firebaseClient.DeleteAsync($"Calendar/{_userName}/{eventDate}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Đã xóa sự kiện.");
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa sự kiện.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
  
    


       
    }
}
