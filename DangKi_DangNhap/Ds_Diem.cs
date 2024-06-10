using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class Ds_Diem : Form
    {
        IFirebaseClient firebaseClient;
        string tenNhom;
        string user;
        string link;
        public Ds_Diem(string TenNhom, string userName, string link)
        {
            InitializeComponent();
            this.tenNhom = TenNhom;
            this.user = userName;
            this.link = link;
            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };
            firebaseClient = new FireSharp.FirebaseClient(config);

            // Cấu hình ListView
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listView1.BackColor = Color.OldLace;
            listView1.Location = new Point(48, 77);
            listView1.Name = "listView1";
            listView1.Size = new Size(692, 370);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.Columns.Add(link, -2, HorizontalAlignment.Left);
        }

        private async void Ds_Diem_Load(object sender, EventArgs e)
        {
            int count = 0;
            int totalScore = 0; // Tổng điểm
            try
            {

                // Fetch the data from Firebase
                FirebaseResponse response = await firebaseClient.GetAsync($"DsDiem/{tenNhom}/{user}/{link}");

                // Kiểm tra nếu response không null
                if (response == null)
                {
                    MessageBox.Show("Không thể kết nối đến Firebase", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Deserialize the data into a dictionary
                Dictionary<string, string> scores = response.ResultAs<Dictionary<string, string>>();

                // Check if scores are available
                if (scores != null && scores.Count > 0)
                {
                    int i = 1;
                    foreach (var score in scores)
                    {
                        string formattedText = $"Điểm làm bài quiz lần {i} là: {score.Value}";
                        listView1.Items.Add(new ListViewItem(formattedText));
                        i++;
                        int.TryParse(score.Value, out int scoreValue); // Lấy giá trị điểm từ dữ liệu

                        totalScore += scoreValue; // Cộng điểm
                        count++; // Tăng biến đếm số lượng quiz
                    }

                    // Tính điểm trung bình
                    double averageScore = (double)totalScore / count;

                    // Hiển thị điểm trung bình trên Label 3
                    label3.Text = $"{averageScore:F2}"; // Hiển thị điểm trung bình với 2 chữ số sau dấu phẩy
                    label5.Text = user;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi truy xuất dữ liệu: " + ex.Message);
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
