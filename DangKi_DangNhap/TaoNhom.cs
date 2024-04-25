using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class TaoNhom : Form
    {
        private FormNhom formNhom;
        private readonly string userName;
        private readonly IFirebaseClient firebaseClient;
        private int soLuongNhom = 0;
        private string tenNhom;
        public TaoNhom(String user)
        {
            InitializeComponent();

            userName = user;

            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);

            // Tải dữ liệu button nhóm từ Firebase khi đăng nhập
            LoadNhomData();
        }

        private async void LoadNhomData()
        {
            try
            {
                // Truy vấn dữ liệu từ Firebase
                FirebaseResponse response = await firebaseClient.GetAsync($"nhoms/{userName}");
                if (response.Body == "null")
                {

                    return;
                }

                // Parse dữ liệu trả về thành một danh sách các nhóm
                Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();

                // Duyệt qua danh sách nhóm và tạo các button nhóm tương ứng
                foreach (var pair in nhomData)
                {
                    string tenNhom = pair.Key;
                    // Tạo button nhóm và thêm vào form
                    AddNhomButton(tenNhom);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNhomButton(string tenNhom)
        {

            soLuongNhom++;
            Button btnNhomMoi = new Button();
            btnNhomMoi.Text = tenNhom;
            btnNhomMoi.Width = 100;
            btnNhomMoi.Height = 100;
            btnNhomMoi.Location = new System.Drawing.Point(60 + (soLuongNhom - 1) * 120, 100);
            btnNhomMoi.Click += BtnNhomMoi_Click;
            this.Controls.Add(btnNhomMoi);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var newForm = new TrangTaoNhom(userName,firebaseClient);
            newForm.Show();
            newForm.TenNhomCreated += (sender, tenNhom) =>
            {
                AddNhomButton(tenNhom);
            };
           

        }

        private void BtnNhomMoi_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            tenNhom = btn.Text;
            // Tạo một form mới để hiển thị danh sách thành viên của nhóm
            FormNhom newForm = new FormNhom(tenNhom,userName);
            newForm.Text = "Danh sách thành viên của nhóm" + tenNhom; // Đặt tiêu đề cho form
            newForm.Show();
            // Tải danh sách thành viên của nhóm từ Firebase và cập nhật vào ListView trong form mới
            LoadMembersOfGroup(tenNhom, newForm.listView1);
            LoadClick(tenNhom, newForm.richTextBox1);
        }


        public async Task<Dictionary<string, object>> GetGroupData(string tenNhom)
        {
            try
            {
                // Truy vấn dữ liệu từ Firebase để lấy dữ liệu của nhóm
                FirebaseResponse response = await firebaseClient.GetAsync($"group /{tenNhom}/ports");
                if (response.Body == "null")
                {
                    MessageBox.Show("Không tìm thấy dữ liệu của nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                // Parse dữ liệu trả về thành một Dictionary<string, object>
                Dictionary<string, object> groupData = response.ResultAs<Dictionary<string, object>>();

                return groupData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async void ShowGroupData(string tenNhom, Label label1)
        {
            try
            {
                // Gọi phương thức để lấy dữ liệu của nhóm từ Firebase
                Dictionary<string, object> groupData = await GetGroupData(tenNhom);

                // Kiểm tra nếu dữ liệu không null
                if (groupData != null)
                {
                    // Hiển thị dữ liệu lên label1
                    label1.Text = string.Join(Environment.NewLine, groupData.Values);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void LoadClick(string tenNhom, RichTextBox richTextBox)
        {
            try
            {
                // Gọi phương thức để lấy dữ liệu của nhóm từ Firebase
                Dictionary<string, object> groupData = await GetGroupData(tenNhom);

                // Kiểm tra nếu dữ liệu không null
                if (groupData != null)
                {
                    // Xóa nội dung cũ trong RichTextBox trước khi thêm mới
                    richTextBox.Clear();

                    // Thêm các bài đăng vào RichTextBox và định dạng chúng
                    foreach (var post in groupData.Values)
                    {
                        AddPostToRichTextBox(richTextBox, post.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddPostToRichTextBox(RichTextBox richTextBox, string post)
        {
            // Thêm bài đăng vào RichTextBox
            richTextBox.AppendText(post + Environment.NewLine);

            // Định dạng văn bản cho bài đăng mới
            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
            richTextBox.SelectionColor = Color.Black;
        }
        private async void LoadMembersOfGroup(string tenNhom, ListView listView)
        {
            try
            {
                // Truy vấn dữ liệu từ Firebase để lấy danh sách thành viên của nhóm
                FirebaseResponse response = await firebaseClient.GetAsync($"group /{tenNhom}");
                if (response.Body == "null")
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Parse dữ liệu trả về thành một Dictionary<string, object>
                Dictionary<string, object> nhomData = response.ResultAs<Dictionary<string, object>>();

                // Xóa danh sách thành viên cũ trước khi cập nhật mới
                listView.Items.Clear();

                // Thiết lập ListView để hiển thị dạng bảng
                listView.View = View.Details;
                listView.GridLines = true;

                // Thêm cột "Danh sách thành viên nhóm"
                listView.Columns.Add("Danh sách thành viên nhóm:", -2, HorizontalAlignment.Left);

                // Thêm các thành viên của nhóm vào ListView
                foreach (var member in nhomData)
                {
                    string userName = member.Key;
                    ListViewItem item = new ListViewItem(userName);
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Vui lòng nhập tên nhóm và ID nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {
                // Khi Button tham gia nhóm được nhấp, thêm người dùng vào nhóm trong Firebase
                string tenNhom = textBox1.Text;
                string nhomID = textBox2.Text;
                string us = textBox3.Text;
                // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
                if (string.IsNullOrEmpty(tenNhom) || string.IsNullOrEmpty(nhomID) || string.IsNullOrEmpty(us))
                {
                    MessageBox.Show("Vui lòng nhập tên nhóm và ID nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                // Kiểm tra xem nhóm có tồn tại không
                FirebaseResponse response = await firebaseClient.GetAsync($"nhoms/{us}/{tenNhom}/{nhomID}");

                if (response.Body == "null")
                {
                    MessageBox.Show("Nhóm không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm người dùng vào nhóm
                var data = new Dictionary<string, object>
            {
                { nhomID, true }
            };

                FirebaseResponse joinResponse = await firebaseClient.UpdateAsync($"nhoms/{userName}/{tenNhom}", data);
                MessageBox.Show("Đã tham gia nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddNhomButton(tenNhom);
                var data2 = new Dictionary<string, object>
             {
                { userName, true }
             };

                // Thực hiện thêm dữ liệu vào Firebase
                FirebaseResponse response2 = await firebaseClient.UpdateAsync($"group /{tenNhom}/", data2);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tham gia nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TaoNhom_Load(object sender, EventArgs e)
        {

        }
    }
}