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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DangKi_DangNhap
{
    public partial class Choose : Form
    {
        private IFirebaseClient firebaseClient;
        string tenNhom;
        string user;
        string link;
        string time1;
        public Choose(string TenNhom, string userName, string link, string time)
        {
            this.tenNhom = TenNhom;
            this.user = userName;
            this.link = link;
            this.time1 = time;
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };
            // Khởi tạo Firebase client
            firebaseClient = new FireSharp.FirebaseClient(config);
        }

        private async void bunifuButton23_Click(object sender, EventArgs e)
        {
            Quiz quiz = new Quiz(tenNhom, user, link, time1);
            quiz.Show();
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            FirebaseResponse rsp = await firebaseClient.GetAsync($"nhoms/{user}/{tenNhom}");

            // Lấy giá trị của "tenNhom" từ thuộc tính "Result"
            string tenNhomValue = rsp.ResultAs<string>();

            // Kiểm tra nếu giá trị của "tenNhom" là "true"
            if (tenNhomValue != "true")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa quiz này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    FirebaseResponse res = await firebaseClient.DeleteAsync($"Quiz/{tenNhom}/{link}");
                    FirebaseResponse res1 = await firebaseClient.DeleteAsync($"TuyenTapBaiQuiz/{tenNhom}/{link}");
                
                }


            }
            else
            {

                MessageBox.Show("Chỉ người tạo quiz mới có quyền xóa !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
    }
}