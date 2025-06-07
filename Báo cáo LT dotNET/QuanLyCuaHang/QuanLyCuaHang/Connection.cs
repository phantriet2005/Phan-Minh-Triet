using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _QuanLyCHTL
{
    class Connection
    {
        //public static string strConn = "Server=DESKTOP-ERJG42D\\SQLEXPRESS04;" +
        //    "Database=QLCHTL;Integrated Security=True;";
        public static string strConn = "server =DESKTOP-L27EOOE\\TRIET ; database =QLCHTL ; uid =sa ; pwd =123456";
        public SqlConnection conn { get; set; }

        public SqlCommand cmd { get; set; }

        public Connection()
        {
            conn = new SqlConnection(strConn);
            cmd = null;
        }
        //Mở kết nối
        public bool moKetNoi()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Đóng kết nối
        public bool dongKetNoi()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Đọc dữ liệu từ DataReader
        public SqlDataReader truyVan(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }
        //Cập nhật dữ liệu
        public int capNhat(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();

        }
    }
}
