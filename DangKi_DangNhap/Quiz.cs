using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;
using Firebase.Storage;
using System.Collections.Generic;

namespace DangKi_DangNhap
{
    public partial class Quiz : Form
    {
        private int timeLeft;
        private System.Windows.Forms.Timer countdownTimer;
        private IFirebaseClient firebaseClient;
        private int currentQuestionIndex = 0;
        string tenNhom;
        string user;
        string link;
        int time1;
        private List<AnsweredQuestion> answeredQuestions = new List<AnsweredQuestion>();
        private Question currentQuestion;

        public Quiz(string TenNhom, string userName, string link, string time)
        {
            this.tenNhom = TenNhom;
            this.user = userName;
            this.link = link;
            if (int.TryParse(time, out int timeValue))
            {
                time1 = timeValue;
            }
            int seccond = time1 * 60;
            InitializeComponent();

            // Cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };
            // Khởi tạo Firebase client
            firebaseClient = new FireSharp.FirebaseClient(config);

            // Khởi tạo Timer đếm ngược
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // Mỗi giây
            countdownTimer.Tick += TimerTick;
            timeLeft = seccond; // Thời gian đếm ngược ban đầu (300 giây = 5 phút)

            // Ensure the Quiz_Load method is attached to the Load event
            this.Load += new EventHandler(Quiz_Load);
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            // Path to the next question in Firebase
            string nextQuestionPath = $"Quiz/{tenNhom}/{link}/ID{currentQuestionIndex + 1}";
            string userAttemptsPath = $"DsDiem/{tenNhom}/{user}/{link}";

            try
            {
                // Retrieve the next question
                FirebaseResponse response = await firebaseClient.GetAsync(nextQuestionPath);
                if (response.Body != "null")
                {
                    var firebaseQuestion = response.ResultAs<Dictionary<string, object>>();
                    var question = ConvertFirebaseQuestion(firebaseQuestion);
                    DisplayQuestion(question);
                    currentQuestionIndex++;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn nộp bài ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        countdownTimer.Stop(); // Stop the timer
                        int correctAnswers = CalculateCorrectAnswers();
                        int totalQuestions = currentQuestionIndex;
                        double score = ((double)correctAnswers / totalQuestions) * 10;

                        MessageBox.Show($"Bạn đã trả lời đúng {correctAnswers}/{totalQuestions} câu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Retrieve the user's current attempts
                        FirebaseResponse userAttemptsResponse = await firebaseClient.GetAsync(userAttemptsPath);
                        var userAttemptsData = userAttemptsResponse.ResultAs<Dictionary<string, object>>() ?? new Dictionary<string, object>();

                        // Calculate the next attempt number
                        int nextAttemptNumber = userAttemptsData.Count + 1;

                        // Prepare the data to update
                        var data = new Dictionary<string, object>
                        {
                            { $"LuotLamBai{nextAttemptNumber}", score.ToString() },
                        };

                        // Update Firebase with the new attempt
                        FirebaseResponse response2 = await firebaseClient.UpdateAsync(userAttemptsPath, data);
                        DialogResult dialogResult2 = MessageBox.Show("Bạn có muốn xem thông tin bài làm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Ds_Diem diem = new Ds_Diem(tenNhom, user, link);
                            diem.Show();
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải câu hỏi: {ex.Message}");
            }
        }

        private Question ConvertFirebaseQuestion(Dictionary<string, object> firebaseQuestion)
        {
            var questionText = firebaseQuestion["Question"].ToString();
            var options = new List<string>();
            string correctAnswer = null;

            foreach (var key in firebaseQuestion.Keys)
            {
                if (key != "Question")
                {
                    options.Add(key);
                    if (firebaseQuestion[key].ToString().ToLower() == "true")
                    {
                        correctAnswer = key;  // Lưu đáp án đúng
                    }
                }
            }

            return new Question
            {
                QuestionText = questionText,
                Options = options,
                CorrectAnswer = correctAnswer
            };
        }

        private void DisplayQuestion(Question question)
        {
            // Hiển thị câu hỏi và các lựa chọn tương ứng
            currentQuestion = question;  // Lưu câu hỏi hiện tại
            label1.Text = question.QuestionText;
            List<RadioButton> radioButtons = new List<RadioButton> { radioButton1, radioButton2, radioButton3, radioButton4 };

            // Đặt tất cả các RadioButton về trạng thái chưa được chọn
            foreach (var radioButton in radioButtons)
            {
                radioButton.Checked = false;
                radioButton.Visible = false; // Ẩn các RadioButton ban đầu
            }

            // Cập nhật và hiển thị các RadioButton với các lựa chọn từ câu hỏi
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (i < question.Options.Count)
                {
                    radioButtons[i].Text = question.Options[i];
                    radioButtons[i].Visible = true;
                    radioButtons[i].CheckedChanged += radioButton_CheckedChanged;  // Thêm sự kiện
                }
            }
        }

        private int CalculateCorrectAnswers()
        {
            int correctAnswers = 0;
            foreach (var question in answeredQuestions)
            {
                if (question.SelectedAnswer == question.Question.CorrectAnswer)
                {
                    correctAnswers++;
                }
            }
            return correctAnswers;
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            // Tải câu hỏi đầu tiên khi form được tải
            bunifuButton21_Click(sender, e);
            countdownTimer.Start(); // Bắt đầu đếm ngược thời gian
            UpdateTimeLabel(); // Ensure the time label is updated at start
        }

        private async void TimerTick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; // Giảm thời gian đi 1 giây
                UpdateTimeLabel();
            }
            else
            {
                countdownTimer.Stop();
                // Handle quiz completion due to time out
                EndQuiz();
            }
        }

        private void UpdateTimeLabel()
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            label2.Text = $"{minutes:D2}:{seconds:D2}"; // Hiển thị thời gian dưới dạng mm:ss
        }

        private async void EndQuiz()
        {
            FirebaseResponse userAttemptsResponse = await firebaseClient.GetAsync($"Quiz/{tenNhom}/{link}");
            var userAttemptsData = userAttemptsResponse.ResultAs<Dictionary<string, object>>() ?? new Dictionary<string, object>();
            int correctAnswers = CalculateCorrectAnswers();
            int totalQuestions = userAttemptsData.Count;
            double score = ((double)correctAnswers / totalQuestions) * 10;

            MessageBox.Show($"Bạn đã trả lời đúng {correctAnswers}/{totalQuestions} câu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FirebaseResponse userAttemptsResponse1 = await firebaseClient.GetAsync($"DsDiem/{tenNhom}/{user}");
            var userAttemptsData1 = userAttemptsResponse1.ResultAs<Dictionary<string, object>>() ?? new Dictionary<string, object>();
            int temp = userAttemptsResponse1.Body == "null" ? 0 : userAttemptsData1.Count;

            int nextAttemptNumber = temp + 1;

            var data = new Dictionary<string, object>
            {
                { $"LuotLamBai{nextAttemptNumber}", score.ToString() },
            };

            await firebaseClient.UpdateAsync($"DsDiem/{tenNhom}/{user}", data);
            DialogResult dialogResult2 = MessageBox.Show("Bạn có muốn xem thông tin bài làm không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult2 == DialogResult.Yes)
            {
                Ds_Diem diem = new Ds_Diem(tenNhom, user, link);
                diem.Show();
            }
            this.Close();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                var answeredQuestion = answeredQuestions.Find(q => q.Question == currentQuestion);
                if (answeredQuestion == null)
                {
                    answeredQuestions.Add(new AnsweredQuestion
                    {
                        Question = currentQuestion,
                        SelectedAnswer = radioButton.Text
                    });
                }
                else
                {
                    answeredQuestion.SelectedAnswer = radioButton.Text;
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    // Định nghĩa lớp Question để khớp với cấu trúc dữ liệu của bạn trong Firebase
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }  // Thêm thuộc tính này

        public Question()
        {
            Options = new List<string>();
        }
    }

    public class AnsweredQuestion
    {
        public Question Question { get; set; }
        public string SelectedAnswer { get; set; }
    }
}
