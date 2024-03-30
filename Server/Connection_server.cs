using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
     class Connection_server
    {
        private static string stringconnections = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84964\OneDrive\Documents\Năm 2 Đại Học\Học Kỳ 2\Lập trình mạng căn bản\thực hành lập trình mạng căn bản\DangKi_DangNhap\Server\Database1.mdf"";Integrated Security=True";
        public static SqlConnection getSQLConnection()
        {
            return new SqlConnection(stringconnections);
        }
    }
}
