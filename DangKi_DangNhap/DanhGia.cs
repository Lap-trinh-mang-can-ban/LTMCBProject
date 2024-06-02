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

        private async void DanhGia_Load(object sender, EventArgs e)
        {
            await LoadRatings();
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {

            try
            {
                double ratingValue = bunifuRating1.Value;
                string feedbackText = bunifuTextBox1.Text;

                var feedbackData = new
                {
                    Rating = ratingValue,
                    Feedback = feedbackText,
                    Timestamp = DateTime.Now
                };

                PushResponse response = await firebaseClient.PushAsync("feedbacks", feedbackData);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Đánh giá của bạn đã được gửi thành công!");

                    bunifuRating1.Value = 3;
                    bunifuTextBox1.Text = string.Empty;

                    await LoadRatings(); // Load lại đánh giá sau khi gửi thành công
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }

        private async Task LoadRatings()
        {
            try
            {
                FirebaseResponse response = await firebaseClient.GetAsync("feedbacks");
                var feedbacks = response.ResultAs<Dictionary<string, Feedback>>();

                if (feedbacks != null)
                {
                    int totalRatings = feedbacks.Count;
                    int count5Star = feedbacks.Count(f => f.Value.Rating == 5);
                    int count4Star = feedbacks.Count(f => f.Value.Rating == 4);
                    int count3Star = feedbacks.Count(f => f.Value.Rating == 3);
                    int count2Star = feedbacks.Count(f => f.Value.Rating == 2);
                    int count1Star = feedbacks.Count(f => f.Value.Rating == 1);
                    //Tính tỉ lệ giữa các số sao 
                    int percentage5Star = (count5Star * 100) / totalRatings;
                    int percentage4Star = (count4Star * 100) / totalRatings;
                    int percentage3Star = (count3Star * 100) / totalRatings;
                    int percentage2Star = (count2Star * 100) / totalRatings;
                    int percentage1Star = (count1Star * 100) / totalRatings;

                    progressBar5Star.Value = percentage5Star;
                    progressBar4Star.Value = percentage4Star;
                    progressBar3Star.Value = percentage3Star;
                    progressBar2Star.Value = percentage2Star;
                    progressBar1Star.Value = percentage1Star;

                    //Đếm số lượt đánh giá 
                    lblSoluotDG.Text = $"Số lượt đánh giá: {totalRatings}";

                    // Tính trung bình số sao 
                    double averageRating = feedbacks.Average(f => f.Value.Rating);
                    labelAverageRating.Text = $"{averageRating:F1}";
                    bunifuRatingAverage.Value = (int)Math.Round(averageRating);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi lấy dữ liệu đánh giá: " + ex.Message);
            }
        }

        public class Feedback
        {
            public double Rating { get; set; }
            public string FeedbackText { get; set; }
            public DateTime Timestamp { get; set; }
        }

       
    }
}

