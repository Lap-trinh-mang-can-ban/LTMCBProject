using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public Form1()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, 8888);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();

            // Hiển thị thông báo khi server bắt đầu chạy
            label1.Text = "Server đang chạy. Kết nối...";
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                string dataReceived = Encoding.ASCII.GetString(message, 0, bytesRead);

                // Tách dữ liệu nhận được từ client thành các tham số
                string[] requestParts = dataReceived.Split('|');

                // Xác định loại yêu cầu từ client (đăng kí hoặc đăng nhập)
                string command = requestParts[0];

                switch (command)
                {
                    case "DANGKI":
                        // Xử lý yêu cầu đăng kí
                        HandleRegistration(requestParts, clientStream);
                        break;
                    case "DANGNHAP":
                        // Xử lý yêu cầu đăng nhập
                        HandleLogin(requestParts, clientStream);
                        break;
                    case "QUENMK":
                        // Xử lý yêu cầu đăng nhập
                        HandleQMK(requestParts, clientStream);
                        break;
                    default:
                        // Yêu cầu không hợp lệ
                        SendResponse(clientStream, "INVALID_REQUEST");
                        break;
                }
            }

            tcpClient.Close();
        }

        // Xử lý yêu cầu đăng nhập
        private void HandleLogin(string[] requestParts, NetworkStream clientStream)
        {
            string taiKhoan = requestParts[1];
            string matKhau = requestParts[2];

            // Kiểm tra đăng nhập trong cơ sở dữ liệu
            bool ketQuaDangNhap = DatabaseAccess.KiemTraDangNhap(taiKhoan, matKhau);

            // Gửi kết quả đăng nhập cho client
            byte[] responseData = Encoding.ASCII.GetBytes(ketQuaDangNhap.ToString());
            clientStream.Write(responseData, 0, responseData.Length);

            // Hiển thị thông tin đăng nhập nếu đăng nhập thành công
            if (ketQuaDangNhap)
            {
                // Hiển thị thông tin đăng nhập trên label
                Invoke((MethodInvoker)(() => label1.Text = $"Tài khoản: {taiKhoan} - Đăng nhập thành công"));
            }
        }

        // Xử lý yêu cầu đăng kí
        private void HandleRegistration(string[] requestParts, NetworkStream clientStream)
        {
            string taiKhoan = requestParts[1];
            string matKhau = requestParts[2];
            string email = requestParts[3];
            if (DatabaseAccess.KiemTraTonTaiTaiKhoan(taiKhoan))
            {
                SendResponse(clientStream, "TAIKHOAN_EXIST"); // Gửi phản hồi rằng tài khoản đã tồn tại
                return;
            }
            if (DatabaseAccess.KiemTraTonTaiMatKhau(matKhau))
            {
                SendResponse(clientStream, "MATKHAU_EXIST"); // Gửi phản hồi rằng tài khoản đã tồn tại
                return;
            }

            // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu chưa
            if (DatabaseAccess.KiemTraTonTaiEmail(email))
            {
                SendResponse(clientStream, "EMAIL_EXIST"); // Gửi phản hồi rằng email đã tồn tại
                return;
            }
            // Thêm tài khoản vào cơ sở dữ liệu
            DatabaseAccess.ThemTaiKhoan(taiKhoan, matKhau, email);

            // Gửi phản hồi cho client
            SendResponse(clientStream, "DANGKI_SUCCESS");

        }

        // Xử lý yêu cầu quên mật khẩu
        private void HandleQMK(string[] requestParts, NetworkStream clientStream)
        {
            string email = requestParts[1];

            // Lấy mật khẩu từ cơ sở dữ liệu
            string matKhau = DatabaseAccess.LayMatKhauQuenMatKhau(email);

            if (matKhau != null)
            {
                // Gửi mật khẩu cho client
                SendResponse(clientStream, "MATKHAU|" + matKhau);
            }
            else
            {
                // Gửi thông báo không tìm thấy mật khẩu cho client
                SendResponse(clientStream, "MATKHAU_NOT_FOUND");
            }
        }

        private void SendResponse(NetworkStream clientStream, string response)
        {
            byte[] responseData = Encoding.ASCII.GetBytes(response);
            clientStream.Write(responseData, 0, responseData.Length);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
