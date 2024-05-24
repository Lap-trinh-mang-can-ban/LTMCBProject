using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class DanhGia : Form
    {
        //khởi tạo firebase
        private IFirebaseClient firebaseClient;

        public DanhGia()
        {

            InitializeComponent();
            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };
            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
        }

        private void DanhGia_Load(object sender, EventArgs e)
        {

        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy giá trị từ BunifuRating và BunifuTextBox
                double ratingValue = bunifuRating1.Value;
                string feedbackText = bunifuTextBox1.Text;

                // Tạo đối tượng dữ liệu để lưu trữ
                var feedbackData = new
                {
                    Rating = ratingValue,
                    Feedback = feedbackText,
                    Timestamp = DateTime.Now
                };

                // Đẩy dữ liệu lên Firebase
                PushResponse response = await firebaseClient.PushAsync("feedbacks", feedbackData);

                // Hiển thị thông báo khi lưu thành công
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Đánh giá của bạn đã được lưu thành công!");

                    // Xóa nội dung đã nhập sau khi lưu thành công
                    bunifuRating1.Value = 3; // assuming 0 is the default value
                    bunifuTextBox1.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
