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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DangKi_DangNhap
{
    public partial class DisplayEvent : Form
    {
        private readonly string Nhom;
        private readonly IFirebaseClient firebaseClient;
        public DisplayEvent(string nhom)
        {
            this.Nhom = nhom;
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
          
        }
        private async void DisplayEvent_Load(object sender, EventArgs e)
        {
            string date = $"{GroupCalender.static_month}_{UserControl3.static_day}_{GroupCalender.static_year}";
          //  MessageBox.Show(date);
            FirebaseResponse response = await firebaseClient.GetAsync($"Calendar/{Nhom}/{date}");
            if (response.Body != "null")
            {
                label3.Text = date;
                label7.Text = response.Body;
            }
            else
            {
                MessageBox.Show("Chưa có sự kiện nào được thêm vào ngày này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
