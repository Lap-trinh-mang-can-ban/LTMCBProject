using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DangKi_DangNhap
{
    public partial class ThamGiaNhom : Form
    {
        IFirebaseClient firebaseClient;
        private readonly string userName;
        public ThamGiaNhom(string user)
        {
            InitializeComponent();
            userName = user;
            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };
            firebaseClient = new FireSharp.FirebaseClient(config);
        }


        private void ThamGiaNhom_Load(object sender, EventArgs e)
        {

        }

      
        private async  void bunifuButton25_Click(object sender, EventArgs e)
        {
            try
            {
                string tenUser = textBox1.Text;

                // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
                if (string.IsNullOrEmpty(tenUser))
                {
                    MessageBox.Show("Vui lòng nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Truy vấn Firebase để lấy danh sách các nhóm mà userName đã tham gia
                FirebaseResponse response = await firebaseClient.GetAsync($"nhoms/{tenUser}");

                if (response.Body == "null")
                {
                    MessageBox.Show("Không tìm thấy dữ liệu");
                    return;
                }

                comboBox1.Items.Clear();

                // Parse dữ liệu trả về thành một danh sách các nhóm
                Dictionary<string, object> nhomData = response.ResultAs
            <Dictionary<string, object>>();

                // Duyệt qua danh sách nhóm và thêm vào comboBox1
                foreach (var pair in nhomData)
                {

                    string tenNhom = pair.Key;
                    string giaTri = Convert.ToString(pair.Value); // Chuyển đổi giá trị thành chuỗi

                    if (!giaTri.Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        comboBox1.Items.Add(tenNhom);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bunifuButton24_Click(object sender, EventArgs e)
        {

            try
            {
                string tenUser = textBox1.Text;
                string tenTeam = comboBox1.Text;
                string IDnhom = textBox2.Text;

                // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
                if (string.IsNullOrEmpty(tenTeam) || string.IsNullOrEmpty(tenUser) || string.IsNullOrEmpty(IDnhom))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện cập nhật dữ liệu trong Firebase để thêm người dùng vào nhóm
                var data = new Dictionary<string, object>
        {
            { tenTeam, true }
        };
                var data1 = new Dictionary<string, object>
        {
            { userName, true }
        };
                // Thực hiện cập nhật dữ liệu vào Firebase

                FirebaseResponse response2 = await firebaseClient.GetAsync($"nhoms/{tenUser}/{tenTeam}");

                if (response2.Body == "null")
                {
                    MessageBox.Show("Tên người dùng hoặc tên nhóm không đúng.");
                    return;
                }
                string actualID = response2.ResultAs<string>();

                // So sánh ID nhập vào với ID thực tế từ Firebase
                if (IDnhom != actualID)
                {
                    MessageBox.Show("ID nhóm không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool userExists = await CheckUsernameExists(tenTeam);
                if (userExists)
                {
                    MessageBox.Show("Tên người dùng đã tồn tại, vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FirebaseResponse response = await firebaseClient.UpdateAsync($"nhoms/{userName}", data);
                FirebaseResponse response1 = await firebaseClient.UpdateAsync($"group /{tenTeam}", data1);
                MessageBox.Show("Đã thêm người dùng vào nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm người dùng vào nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> CheckUsernameExists(string name)
        {
            FirebaseResponse response = await firebaseClient.GetAsync($"group /{name}");
            return response.Body != "null";
        }
    }
}
