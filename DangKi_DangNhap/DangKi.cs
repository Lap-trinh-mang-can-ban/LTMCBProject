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
using BCrypt.Net;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.LinkLabel;
using System.Formats.Tar;

namespace DangKi_DangNhap
{
    public partial class DangKi : Form
    {
        IFirebaseClient firebaseClient;
        private string verificationCode;
        private bool isPasswordVisible = false;
        private string newUserID;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private const string Bucket = "databeseaccess.appspot.com";
        public DangKi()
        {
            InitializeComponent();

            // Khởi tạo cấu hình Firebase
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "PFejsR6CHWL2zIGqFqZ1w3Orw0ljzeHnHubtuQN8",
                BasePath = "https://databeseaccess-default-rtdb.firebaseio.com/",
            };

            // Khởi tạo FirebaseClient
            firebaseClient = new FireSharp.FirebaseClient(config);
            //Làm rỗng label báo lỗi 
            errorLabel.Text = "";
            //label9.Text = "";
            // Tạo ID mới khi form được tải
            Load += DangKi_Load;
        }


        private async void bunifuButton22_Click(object sender, EventArgs e)
        {
            string ID = newUserID; // Sử dụng ID mới tạo
            string matKhau = textBox2.Text;
            string xacNhanMatKhau = textBox3.Text;
            string email = textBox4.Text;
            string encodedEmail = EncodeEmail(email);
            string tentaikhoan = textBox5.Text;
            string ngaysinh = textBox6.Text;
            string gioitinh = comboBox1.Text;
            string maXacThuc = textBox7.Text;
            string path = textBox8.Text;
            byte[] fileBytes = File.ReadAllBytes(path);
            string uniquePath = $"ProfilePictures/{tentaikhoan}";

            //  string imagePath = textBox8.Text;
            if (string.IsNullOrWhiteSpace(ID) || string.IsNullOrWhiteSpace(matKhau) || string.IsNullOrWhiteSpace(xacNhanMatKhau) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(tentaikhoan) || string.IsNullOrWhiteSpace(ngaysinh) || string.IsNullOrWhiteSpace(gioitinh) || string.IsNullOrWhiteSpace(maXacThuc) || string.IsNullOrWhiteSpace(path))
            {
                //MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Vui lòng điền đầy đủ thông tin !";
                return;
            }

            if (matKhau != xacNhanMatKhau)
            {
                //MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLabel.Text = "Xác nhận mật khẩu chưa đúng !";
                return;
            }

            if (maXacThuc != verificationCode)
            {
                errorLabel.Text = "Mã xác thực không đúng!";
                return;
            }

            try
            {
                /* Kiểm tra xem tên tài khoản đã tồn tại chưa
                FirebaseResponse userExistsResponse = firebaseClient.Get($"users/{ID}");
                if (userExistsResponse.Body != "null")
                {
                    //MessageBox.Show("Tên tài khoản đã tồn tại!! Vui lòng nhập tên tài khoản khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorLabel.Text = "ID tài khoản đã tồn tại !";
                    return;
                }
                */
                var firebaseStorage = new FirebaseStorage(Bucket);

                // Lưu trữ tệp lên Firebase Storage
                await firebaseStorage.Child(uniquePath).PutAsync(new MemoryStream(fileBytes));

                // Tạo đường dẫn tới tệp trên Firebase Storage
                string firebaseStoragePath = await firebaseStorage.Child(uniquePath).GetDownloadUrlAsync();
                // Kiểm tra xem email đã tồn tại chưa
                FirebaseResponse emailExistsResponse = firebaseClient.Get($"emails/{encodedEmail}");
                if (emailExistsResponse.Body != "null")
                {
                    //MessageBox.Show("Email đã tồn tại!! Vui lòng nhập email khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorLabel.Text = "Email đã tồn tại !";
                    return;
                }

                // Kiểm tra xem username đã tồn tại chưa
                FirebaseResponse usernameExistsResponse = firebaseClient.Get($"Tentaikhoan/{tentaikhoan}");
                if (usernameExistsResponse.Body != "null")
                {
                    //MessageBox.Show("Username đã tồn tại!! Vui lòng nhập 1 Username khác: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorLabel.Text = "Tên người dùng đã tồn tại !";
                    return;
                }



                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhau);
             
               
                // Tạo dữ liệu người dùng mới
                var newUser = new User
                {
                    ID = ID,
                    MatKhau = hashedPassword,
                    Email = email,
                    Tentaikhoan = tentaikhoan,
                    Ngaysinh = ngaysinh,
                    Gioitinh = gioitinh,
                };

                // Thêm người dùng mới vào Firebase Realtime Database
                SetResponse setResponse = await firebaseClient.SetAsync($"users/{tentaikhoan}", newUser);
                // Thêm email vào danh sách để kiểm tra tồn tại              
                await firebaseClient.SetAsync($"emails/{encodedEmail}", true);
                // Thêm mật khẩu mới vào danh sách để kiểm tra tồn tại
                await firebaseClient.SetAsync($"Matkhau/{matKhau}", true);
                // Thêm username mới vào danh sách để kiểm tra tồn tại
                await firebaseClient.SetAsync($"Tentaikhoan/{tentaikhoan}", true);
                MessageBox.Show("Đăng kí thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
                textBox7.Text = "";
                errorLabel.Text = "";
                label9.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi gì gì đó : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //thay các kí tự đặc biệt của email khi lưu lên firebase
        private string EncodeEmail(string email)
        {
            return email.Replace(".", "-dot-")
                        .Replace("@", "-at-")
                        .Replace("#", "-hash-")
                        .Replace("$", "-dollar-")
                        .Replace("[", "-lb-")
                        .Replace("]", "-rb-");
        }
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
         
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lấy đường dẫn tập tin ảnh đã chọn
                    string imagePath = openFileDialog.FileName;

                    // Hiển thị ảnh đã chọn trên PictureBox
                    bunifuPictureBox1.Image = new Bitmap(imagePath);
                    textBox8.Text = imagePath;

                    // Upload ảnh đại diện lên Firebase Storage
                    // string avatarUrl = await UploadImageToFirebaseStorage(imagePath);

                    // Thêm đường dẫn ảnh đại diện vào dữ liệu người dùng
                    // Chưa biết làm gì với đường dẫn ảnh đại diện trong ví dụ này

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private async Task<string> UploadImageToFirebaseStorage(string imagePath)
        {
            try
            {
                // Tạo một bản sao của tệp tin ảnh
                string tempImagePath = Path.GetTempFileName();
                File.Copy(imagePath, tempImagePath, true);

                // FirebaseStorage instance
                var firebaseStorage = new FirebaseStorage("https://databeseaccess-default-rtdb.firebaseio.com/");

                // Upload image to Firebase Storage
                var imageUrl = await firebaseStorage
                    .Child("avatars")
                    .Child(Guid.NewGuid().ToString()) // Sử dụng GUID để tạo tên duy nhất cho ảnh
                    .PutAsync(File.Open(tempImagePath, FileMode.Open));

                // Xóa bản sao tệp tin
                File.Delete(tempImagePath);

                // Return the download URL of the uploaded image
                return imageUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi ở phần đăng ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Trả về null nếu có lỗi xảy ra
            }
        }

        private async void DangKi_Load(object sender, EventArgs e)
        {
            newUserID = await GenerateNewUserID();
            textBox1.Text = newUserID.ToString();
        }

        private async Task<string> GenerateNewUserID()
        {
            FirebaseResponse response = await firebaseClient.GetAsync("users");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            int userCount = 0;
            if (data != null)
            {
                foreach (var item in data)
                {
                    userCount++;
                }
            }

            return (userCount + 1).ToString("D6");
        }
        // hiển thị và ẩn mật khẩu
        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            textBox2.UseSystemPasswordChar = !isPasswordVisible;
            textBox3.UseSystemPasswordChar = !isPasswordVisible;
        }

        //Tạo OTP 
        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        //Xác  thức email
        private void GuiEmailXacThuc(string email, string code)
        {
            try
            {
                string fromAddress = "22520358@gm.uit.edu.vn";
                string toAddress = email;
                string subject = "Verification Code";
                string body = $"Mã xác thực của bạn là: {code}";

                using (MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body))
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(fromAddress, "uit1429256805c#");
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnLayma_Click(object sender, EventArgs e)
        {
            string email = textBox4.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                errorLabel.Text = "Vui lòng nhập email !";
                return;
            }

            string encodedEmail = EncodeEmail(email);

            try
            {
                // Kiểm tra xem email đã tồn tại chưa
                FirebaseResponse emailExistsResponse = await firebaseClient.GetAsync($"emails/{encodedEmail}");
                if (emailExistsResponse.Body != "null")
                {
                    errorLabel.Text = "Email đã tồn tại !";
                    return;
                }

                verificationCode = GenerateVerificationCode();
                GuiEmailXacThuc(email, verificationCode);
                label9.Text = "Mã xác thực đã được gửi đi ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi ở phần Lấy mã : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class User
    {
        public string ID { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Tentaikhoan { get; set; }
        public string Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
    }
}
