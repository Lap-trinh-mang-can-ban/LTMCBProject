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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FireSharp.Interfaces;
using FireSharp.Config;
using Microsoft.VisualBasic.ApplicationServices;

namespace DangKi_DangNhap
{
    public partial class MoiVaoNhom : Form
    {
        IFirebaseClient firebaseClient;
        private readonly string TenNhom;
        public MoiVaoNhom(string team)
        {
            InitializeComponent();
            TenNhom = team;
            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };
            firebaseClient = new FireSharp.FirebaseClient(config);
            //làm rông lable báo lỗi 
            errorLabel.Text = "";
        }

        private void MoiVaoNhom_Load(object sender, EventArgs e)
        {

        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            int temp = 0;
            string ten = textBox1.Text;
            FirebaseResponse response2 = await firebaseClient.GetAsync($"Username");
            if (response2.Body == "null")
            {
                MessageBox.Show("Không tìm thấy dữ liệu");
                return;
            }
            Dictionary<string, object> nhomData = response2.ResultAs
          <Dictionary<string, object>>();

            // Duyệt qua các Username trong cơ sở dữ liệu.
            foreach (var pair in nhomData)
            {

                string username = pair.Key;


                if (ten == username)
                {
                    temp++;
                }
            }
            if (string.IsNullOrEmpty(ten))
            {
                //MessageBox.Show("Vui lòng nhập tên người dùng cần mời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorLabel.Text = "Vui lòng nhập tên người dùng cần mời !";
                return;
            }
            if (temp == 0)
            {
                //MessageBox.Show("Tên người dùng không tồn tại !!");
                errorLabel.Text = "Tên người dùng không tồn tại !";
                return;
            }
          
            var data = new Dictionary<string, object>
        {
            { TenNhom, true }
        };
            var data1 = new Dictionary<string, object>
        {
            { ten, true }
        };
            FirebaseResponse response = await firebaseClient.UpdateAsync($"nhoms/{ten}", data);
            FirebaseResponse response1 = await firebaseClient.UpdateAsync($"group /{TenNhom}", data1);
            MessageBox.Show("Đã mời người dùng vào nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            errorLabel.Text = "";
        }

        
    }
}
