using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace DangKi_DangNhap
{
    public partial class KhoQuiz : Form
    {
        private IFirebaseClient firebaseClient;
        string tenNhom;
        string user;
        public KhoQuiz(string nhom, string user)
        {
            tenNhom = nhom;
            this.user = user;
            InitializeComponent();
            InitializeFirebase();
            LoadQuizNames();
        }

        private void InitializeFirebase()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };
            // Khởi tạo Firebase client
            firebaseClient = new FireSharp.FirebaseClient(config);
        }

        private async void LoadQuizNames()
        {
            try
            {
                FirebaseResponse response = await firebaseClient.GetAsync($"TuyenTapBaiQuiz/{tenNhom}");

                // Kiểm tra xem response có dữ liệu hay không
                if (response.Body != "null")
                {
                    var quizNames = response.ResultAs<Dictionary<string, object>>();

                    int yPosition = 10; // Vị trí y cho LinkLabel đầu tiên
                    foreach (var quizName in quizNames.Keys)
                    {
                        // Tạo LinkLabel mới
                        LinkLabel linkLabel = new LinkLabel();
                        linkLabel.Text = quizName;
                        linkLabel.Location = new Point(20, yPosition);
                        linkLabel.Size = new Size(210, 30); // Set the size of the LinkLabel
                        linkLabel.BackColor = Color.OldLace; // Set the background color
                        linkLabel.AutoSize = false; // Ensure AutoSize is false for background color to display
                        linkLabel.LinkClicked += LinkLabel_LinkClicked;

                        // Thêm LinkLabel vào bunifuPanel1
                        bunifuPanel1.Controls.Add(linkLabel);

                        // Tăng yPosition để LinkLabel tiếp theo nằm dưới
                        yPosition += linkLabel.Height + 10;
                    }
                }
                else
                {
                    MessageBox.Show("Không có bài quiz nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bài quiz: {ex.Message}");
            }
        }


        private async void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string time = string.Empty; // Initialize time
            FirebaseResponse response = await firebaseClient.GetAsync($"TuyenTapBaiQuiz/{tenNhom}");
            if (response.Body != "null")
            {
                var quizNames = response.ResultAs<Dictionary<string, object>>();
                foreach (var quizName in quizNames)
                {
                    // Assuming 'time' is a property of each quiz entry and it's a string

                    time = quizName.Value.ToString();
                    break; // Exit the loop once time is found, assuming you need only one value

                }
            }

            LinkLabel linkLabel = sender as LinkLabel;
            string link = linkLabel.Text;
            if (linkLabel != null)
            {
                Choose ch = new Choose(tenNhom, user, link, time);
               // Quiz quiz = new Quiz(tenNhom, user, link, time);
                ch.Show();
                // You can add additional logic to handle user interaction with the link, such as opening the corresponding quiz
            }
        }


        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi panel được nhấp
        }


    }
}
