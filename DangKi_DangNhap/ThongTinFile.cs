using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class ThongTinFile : Form
    {
        public IFirebaseClient firebaseClient;
        private string tenNhom;
        private string tenfile;
        private TaiLieu currentailieu;
        public ThongTinFile(LinkLabel tenfile, string tenNhom, TaiLieu teptin )
        {
            InitializeComponent();
            this.tenNhom = tenNhom;
            this.tenfile = tenfile.Text;

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/"
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            currentailieu = teptin;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa file không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                FirebaseResponse res = firebaseClient.Delete("TaiLieu/" + tenNhom + "/" + tenfile);
                FirebaseResponse res1 = firebaseClient.Delete("TuyenTapTaiLieu/" + tenNhom + "/" + tenfile);
                MessageBox.Show("Đã xóa file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (tenfile != null)
            {
                string fileName = tenfile; // Lấy tên tệp từ linkLabel
                FirebaseResponse response = await firebaseClient.GetAsync($"TaiLieu/{tenNhom}/{fileName}/PathFile");
                if (response.Body != "null")
                {
                    string encodedPath = response.ResultAs<string>(); // Lấy đường dẫn được mã hóa từ Firebase
                    string edgeDirectory = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                    string decodedPath = DecodePath(encodedPath); // Giải mã đường dẫn
                                                                  //MessageBox.Show(decodedPath);

                    Process.Start(edgeDirectory, $"\"{decodedPath}\"");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đường dẫn cho tệp này trong cơ sở dữ liệu.");
                }
            }
        }
        private string DecodePath(string encodedPath)
        {
            byte[] bytes = Convert.FromBase64String(encodedPath);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TTFile tf = new TTFile(currentailieu);
            tf.Show();
        }
    }
}
