using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class AdminGroup : Form
    {
        private IFirebaseClient firebaseClient;
        private string nhom;
        private string username;
        public AdminGroup(string tenNhom, string user)
        {
            this.username = user;
            InitializeComponent();
            textBox6.KeyPress += new KeyPressEventHandler(textBox6_KeyPress);
            this.nhom = tenNhom;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };
            // Khởi tạo Firebase client
            firebaseClient = new FireSharp.FirebaseClient(config);
            errorLabel.Text = "";
        }




        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters (e.g., backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // MessageBox.Show("Chỉ nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorLabel.Text = "Chỉ nhập số !";
                e.Handled = true; // Ignore the key press
            }
        }



        private async Task<int> GetNextQuestionIdAsync()
        {
            string QuizName = textBox5.Text;
            string path = $"Quiz/{nhom}/{QuizName}";
            FirebaseResponse response = await firebaseClient.GetAsync(path);
            var questions = response.ResultAs<Dictionary<string, object>>();
            if (questions != null && questions.Keys.Count > 0)
            {
                List<int> ids = new List<int>();
                foreach (var key in questions.Keys)
                {
                    if (key.StartsWith("ID"))
                    {
                        if (int.TryParse(key.Substring(2), out int id))
                        {
                            ids.Add(id);
                        }
                    }
                }
                if (ids.Count > 0)
                {
                    return ids.Max() + 1;
                }
            }
            return 1;
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void bunifuButton22_Click_1(object sender, EventArgs e)
        {
            string QuizName = textBox5.Text;
            int nextId = await GetNextQuestionIdAsync();
            string Question = richTextBox1.Text;
            string ans1 = textBox1.Text;
            string ans2 = textBox2.Text;
            string ans3 = textBox3.Text;
            string ans4 = textBox4.Text;
            string bool1 = comboBox1.Text;
            string bool2 = comboBox2.Text;
            string bool3 = comboBox3.Text;
            string bool4 = comboBox4.Text;

            if (string.IsNullOrWhiteSpace(QuizName))
            {
                // MessageBox.Show("Bạn cần nhập name quiz !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Bạn cần nhập name quiz !";
                return;
            }
            if (string.IsNullOrWhiteSpace(Question))
            {
                //MessageBox.Show("Bạn cần nhập câu hỏi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Bạn cần nhập câu hỏi !";
                return;
            }
            if (string.IsNullOrWhiteSpace(ans1) || string.IsNullOrWhiteSpace(ans2) || string.IsNullOrWhiteSpace(ans3) || string.IsNullOrWhiteSpace(ans4) || string.IsNullOrWhiteSpace(bool1) || string.IsNullOrWhiteSpace(bool2) || string.IsNullOrWhiteSpace(bool3) || string.IsNullOrWhiteSpace(bool4))
            {
                //MessageBox.Show("Bạn cần nhập đầy đủ các câu trả lời !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Bạn cần nhập đầy đủ các câu trả lời !";
                return;
            }
            var postData = new Dictionary<string, object>
        {
            { "Question", Question },
            { ans1, bool1 },
            { ans2, bool2 },
            { ans3, bool3 },
            { ans4, bool4 },
        };



            FirebaseResponse response = await firebaseClient.UpdateAsync($"Quiz/{nhom}/{QuizName}/ID{nextId}", postData);


            MessageBox.Show("Đã tạo quiz thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            string time = textBox6.Text;
            string QuizName = textBox5.Text;

            if (string.IsNullOrWhiteSpace(QuizName))
            {
                //MessageBox.Show("Yêu cầu name quiz để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Yêu cầu name quiz để cập nhật !";
                return;
            }

            if (string.IsNullOrWhiteSpace(time))
            {
                //MessageBox.Show("Thiết lập thời gian làm quiz!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Thiết lập thời gian làm quiz !";
                return;
            }

            FirebaseResponse rsp = await firebaseClient.GetAsync($"Quiz/{nhom}/{QuizName}");
            var quizData = rsp.ResultAs<object>(); // Deserialize to object to check for existence

            if (quizData == null)
            {
                //MessageBox.Show("Không thể cập nhật vì quiz này chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Không thể cập nhật vì quiz này chưa tồn tại !";
                return;
            }

            var postData2 = new Dictionary<string, object>
    {
        { QuizName, time.ToString() }
    };

            FirebaseResponse response2 = await firebaseClient.UpdateAsync($"TuyenTapBaiQuiz/{nhom}", postData2);
            MessageBox.Show("Đã đăng cập nhật quiz thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bunifuButton23_Click_1(object sender, EventArgs e)
        {
            KhoQuiz q = new KhoQuiz(nhom, username);
            q.Show();
        }
    }
}