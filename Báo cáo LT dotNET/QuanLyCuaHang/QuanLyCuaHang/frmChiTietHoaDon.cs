using _QuanLyCHTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class frmChiTietHoaDon: Form
    {
        int _quyen=-1;
        string _tdn=null;
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }
        public frmChiTietHoaDon(string tdn, int quyen)
        {
            InitializeComponent();
            _quyen = quyen;
            _tdn = tdn;
        }


        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            //Nếu là Quản lý hoặc Nhân viên thì hiện tất cả Hóa đơn, nếu là KH thì chỉ hiện của KH đó
            Connection conn = new Connection();
            conn.moKetNoi();
            string sql = null;
            if (_quyen==1 || _quyen==2)
            {
                sql = "select MaHD from HoaDon";
                SqlDataReader dr1 = conn.truyVan(sql);
                while (dr1.Read())
                {
                    cbbSoHD.Items.Add(dr1["MaHD"].ToString());
                }
                dr1.Close();
            }
            else
            {
                if (_quyen==3)
                {
                    //Chỉ lấy HD của KH
                    string ma=null;
                    string sql_ma = "select MaKH from KhachHang where TenTK ='" + _tdn + "'";
                    SqlDataReader dr = conn.truyVan(sql_ma);
                    if (dr.Read())
                    {
                        ma = dr["MaKH"].ToString();
                    }
                    dr.Close();
                    sql = "select MaHD from HoaDon where MaKH ='" + ma+"'";
                    SqlDataReader dr1 = conn.truyVan(sql);
                    while (dr1.Read())
                    {
                        cbbSoHD.Items.Add(dr1["MaHD"].ToString());
                    }
                    dr1.Close();
                }    
            }
            conn.dongKetNoi();
            try {
                cbbSoHD.SelectedIndex = 0;
                //gọi sự kiện
                cbbSoHD_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                if (_quyen==1 || _quyen==2)
                MessageBox.Show("Chưa có dữ liệu về CTHD\nVUI LÒNG CẬP NHẬT LẠI CSDL");
                else
                    if (_quyen==3)
                {
                    MessageBox.Show("Chưa có dữ liệu về CTHD\nBẠN CHƯA CÓ HOÁ ĐƠN TẠI CỬA HÀNG");
                }    
            }
        }

        private void cbbSoHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvHD.Rows.Clear();
            if (cbbSoHD.Text == null || cbbSoHD.Text == "System.Data.DataRowView")
                return;
            string sohd = cbbSoHD.Text;
            //MessageBox.Show(sohd);
            Connection conn = new Connection();
            conn.moKetNoi();
            string sql = "select NgayLap, MaKH, MaNV,TongTien from HoaDon where MaHD ='" + sohd + "'";
            SqlDataReader dr = conn.truyVan(sql);
            if (dr.Read())
            {
                DateTime ngay = Convert.ToDateTime(dr["NgayLap"].ToString());
                dateNgayLap.Value = ngay;
                txtKH.Text = dr["MaKH"].ToString();
                txtNV.Text = dr["MaNV"].ToString();
                txtTongTien.Text= dr["TongTien"].ToString();
            }
            dr.Close();

            string sql1 = "select h.TenHH ,c.SoLuong, c.ThanhTien , h.DonGia " +
                "from HangHoa h " +
                "join ChiTietHoaDon c " +
                "on c.MaHH = h.MaHH " +
                "where c.MaHD = '" + sohd + "'";
            SqlDataReader dr1 = conn.truyVan(sql1);
            while (dr1.Read())
            {
                string ten = dr1["TenHH"].ToString();
                string dg = dr1["DonGia"].ToString();
                string sl = dr1["SoLuong"].ToString();
                string tt = dr1["ThanhTien"].ToString();
                dgvHD.Rows.Add(ten, dg, sl, tt);
            }
            dr1.Close();
            conn.dongKetNoi();
        }

        
    }
}
