﻿using FireSharp.Config;
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
        public AdminGroup(string tenNhom)
        {
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
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            string time = textBox6.Text;
            string QuizName = textBox5.Text;
            if (string.IsNullOrWhiteSpace(QuizName))
            {
                MessageBox.Show("Yêu cầu name quiz để cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var postData2 = new Dictionary<string, object>

            {
                {QuizName, time.ToString() }
        };
            FirebaseResponse response2 = await firebaseClient.UpdateAsync($"TuyenTapBaiQuiz/{nhom}", postData2);
            MessageBox.Show("Đã đăng cập nhật quiz thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void bunifuButton22_Click(object sender, EventArgs e)
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
                MessageBox.Show("Bạn cần nhập name quiz !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters (e.g., backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Chỉ nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }

}
