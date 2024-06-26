﻿
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace Server
{

    class DatabaseAccess 
    {
       
        public List<TaiKhoan_Server> DocDanhSachTaiKhoan()
        {
            List<TaiKhoan_Server> danhSachTaiKhoan = new List<TaiKhoan_Server>();

            using (SqlConnection connection = Connection_server.getSQLConnection())
            {
                string query = "SELECT TaiKhoan, MatKhau FROM TaiKhoan_Server"; // Thay đổi TableName cho phù hợp

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string taiKhoan = reader.GetString(0);
                            string matKhau = reader.GetString(1);

                            TaiKhoan_Server tk = new TaiKhoan_Server(taiKhoan, matKhau);
                            danhSachTaiKhoan.Add(tk);
                        }
                    }
                }
            }

            return danhSachTaiKhoan;
        }
        public static bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            bool ketQua = false;

            using (SqlConnection connection = Connection_server.getSQLConnection())
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM TaiKhoan_Server WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                        command.Parameters.AddWithValue("@MatKhau", matKhau);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int count = Convert.ToInt32(result);
                            ketQua = (count > 0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ và hiển thị thông báo cụ thể về lỗi
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
                if (!ketQua)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ketQua;
        }
        public static void ThemTaiKhoan(string taiKhoan, string matKhau, string email)
        {
            using (SqlConnection connection = Connection_server.getSQLConnection())
            {
                try
                {
                    string query = "INSERT INTO TaiKhoan_Server (TaiKhoan, MatKhau, Email) VALUES (@TaiKhoan, @MatKhau, @Email)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                        command.Parameters.AddWithValue("@MatKhau", matKhau);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ và hiển thị thông báo cụ thể về lỗi
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

            public static string LayMatKhauQuenMatKhau(string email)
            {
                string matKhau = null;

                using (SqlConnection connection = Connection_server.getSQLConnection())
                {
                    try
                    {
                        string query = "SELECT MatKhau FROM TaiKhoan_Server WHERE Email = @Email";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Email", email);

                            connection.Open();

                            object result = command.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                matKhau = result.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy email trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ và hiển thị thông báo cụ thể về lỗi
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return matKhau;
            }
        public static bool KiemTraTonTaiTaiKhoan(string taiKhoan)
        {
            bool tonTai = false;

            using (SqlConnection connection = Connection_server.getSQLConnection())
            {
                string query = "SELECT COUNT(*) FROM TaiKhoan_Server WHERE TaiKhoan = @TaiKhoan";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        tonTai = (count > 0);
                    }
                }
            }

            return tonTai;
        }

        public static bool KiemTraTonTaiMatKhau(string matKhau)
        {
            bool tonTai = false;

            using (SqlConnection connection = Connection_server.getSQLConnection())
            {
                string query = "SELECT COUNT(*) FROM TaiKhoan_Server WHERE MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        tonTai = (count > 0);
                    }
                }
            }

            return tonTai;
        }

        public static bool KiemTraTonTaiEmail(string email)
        {
            bool tonTai = false;

            using (SqlConnection connection = Connection_server.getSQLConnection())
            {
                string query = "SELECT COUNT(*) FROM TaiKhoan_Server WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        tonTai = (count > 0);
                    }
                }
            }

            return tonTai;
        }
    }
}


    



