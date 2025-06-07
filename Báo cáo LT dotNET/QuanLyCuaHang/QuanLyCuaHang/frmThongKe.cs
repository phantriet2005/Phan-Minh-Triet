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
    public partial class frmThongKe : Form
    {
        int i = 0;
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            for (int i=1;i<=12;i++)
            {
                cbbTG2.Items.Add("Tháng "+i);
                cbb_TG1.Items.Add("Tháng "+i);
            }
            for (int i = 1; i <= 4; i++)
            {
                cbbTG2.Items.Add("Quý " + i);
                cbb_TG1.Items.Add("Quý " + i);
            }

            DateTime today = DateTime.Now;
            for (int i= 2020;i<=today.Year;i++)
            {
                cbb_Nam1.Items.Add(i.ToString());
                cbbNam2.Items.Add(i.ToString());
            }   
            
            Connection conn = new Connection();
            conn.moKetNoi();
            string sql = "select MaHH, TenHH, MaHH + ' - ' + TenHH as hienthi from HangHoa ";
            SqlDataReader dr = conn.truyVan(sql);
            DataTable db = new DataTable(); 
            db.Load(dr);
            cbbHH.DataSource = db;
            cbbHH.DisplayMember = "hienthi";
            cbbHH.ValueMember = "MaHH";
            dr.Close();
            conn.dongKetNoi();
            try
            {
                cbbHH.SelectedIndex = 0;
            }
            catch(Exception ex)
            {

            }
            cbb_TG1.SelectedIndex = 0;
            cbbTG2.SelectedIndex = 0;
            cbb_Nam1.SelectedIndex = cbb_Nam1.Items.Count - 1;
            cbbNam2.SelectedIndex = cbbNam2.Items.Count - 1;
            i = 1;
        }

        private void cbb_TG1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cbb_TG1.SelectedIndex >= 0 && cbb_Nam1.SelectedIndex >= 0)
            {
                string tg = cbb_TG1.Text;
                var x = cbb_Nam1.Text;
                int nam;

                // Kiểm tra nếu x không phải là chuỗi rỗng và có thể chuyển thành số nguyên
                if (string.IsNullOrEmpty(x) || !int.TryParse(x.Trim(), out nam))
                {
                    return;
                }
                string sql = null;
                double doanhthu = 0;
                switch (tg)
                {
                    case "Tháng 1":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 1";
                            break;
                        }
                    case "Tháng 2":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 2";
                            break;
                        }
                    case "Tháng 3":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 3";
                            break;
                        }
                    case "Tháng 4":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 4";
                            break;
                        }
                    case "Tháng 5":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 5";
                            break;
                        }
                    case "Tháng 6":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 6";
                            break;
                        }
                    case "Tháng 7":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 7";
                            break;
                        }
                    case "Tháng 8":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 8";
                            break;
                        }
                    case "Tháng 9":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 9";
                            break;
                        }
                    case "Tháng 10":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 10";
                            break;
                        }
                    case "Tháng 11":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 11";
                            break;
                        }
                    case "Tháng 12":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 12";
                            break;
                        }
                    case "Quý 1":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(1, 2, 3)";
                            break;
                        }
                    case "Quý 2":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(4,5,6)";
                            break;
                        }
                    case "Quý 3":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(7,8,9)";
                            break;
                        }
                    case "Quý 4":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(10,11,12)";
                            break;
                        }
                    default: break;
                }
                Connection conn = new Connection();
                conn.moKetNoi();
                SqlDataReader dr = conn.truyVan(sql);
                while (dr.Read())
                {
                    doanhthu += Convert.ToDouble(dr["TongTien"].ToString());
                }
                dr.Close();
                conn.dongKetNoi();
                txtDoanhthu.Text = doanhthu.ToString();
                if (doanhthu==0 && i>0)
                {
                    MessageBox.Show("Chưa có dữ liệu doanh thu của " + cbb_TG1.Text + " năm " + cbb_Nam1.Text);
                }    
            }  
        }

        private void cbb_Nam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_TG1.SelectedIndex >= 0 && cbb_Nam1.SelectedIndex >= 0)
            {
                string tg = cbb_TG1.Text;
                var x = cbb_Nam1.Text;
                int nam;

                // Kiểm tra nếu x không phải là chuỗi rỗng và có thể chuyển thành số nguyên
                if (string.IsNullOrEmpty(x) || !int.TryParse(x.Trim(), out nam))
                {
                    return;
                }
                string sql = null;
                double doanhthu = 0;
                switch (tg)
                {
                    case "Tháng 1":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 1";
                            break;
                        }
                    case "Tháng 2":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 2";
                            break;
                        }
                    case "Tháng 3":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 3";
                            break;
                        }
                    case "Tháng 4":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 4";
                            break;
                        }
                    case "Tháng 5":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 5";
                            break;
                        }
                    case "Tháng 6":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 6";
                            break;
                        }
                    case "Tháng 7":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 7";
                            break;
                        }
                    case "Tháng 8":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 8";
                            break;
                        }
                    case "Tháng 9":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 9";
                            break;
                        }
                    case "Tháng 10":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 10";
                            break;
                        }
                    case "Tháng 11":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 11";
                            break;
                        }
                    case "Tháng 12":
                        {
                            sql = "select TongTien from HoaDon where YEAR(NgayLap)= " + nam + " and MONTH(NgayLap) = 12";
                            break;
                        }
                    case "Quý 1":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(1, 2, 3)";
                            break;
                        }
                    case "Quý 2":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(4,5,6)";
                            break;
                        }
                    case "Quý 3":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(7,8,9)";
                            break;
                        }
                    case "Quý 4":
                        {
                            sql = "SELECT TongTien FROM HoaDon WHERE YEAR(NgayLap) = " + nam + " AND MONTH(NgayLap) IN(10,11,12)";
                            break;
                        }
                    default: break;
                }
                Connection conn = new Connection();
                conn.moKetNoi();
                SqlDataReader dr = conn.truyVan(sql);
                while (dr.Read())
                {
                    doanhthu += Convert.ToDouble(dr["TongTien"].ToString());
                }
                dr.Close();
                conn.dongKetNoi();
                txtDoanhthu.Text = doanhthu.ToString();
                if (doanhthu == 0 && i>0)
                {
                    MessageBox.Show("Chưa có dữ liệu doanh thu của " + cbb_TG1.Text + " năm " + cbb_Nam1.Text);
                }
            }
        }

        private void cbbTG2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cbbTG2.SelectedIndex >= 0 && cbbNam2.SelectedIndex >= 0)
            {
                string tg = cbbTG2.Text;
                var x = cbbNam2.Text;
                int nam;

                // Kiểm tra nếu x không phải là chuỗi rỗng và có thể chuyển thành số nguyên
                if (string.IsNullOrEmpty(x) || !int.TryParse(x.Trim(), out nam))
                {
                    return;
                }
                string sql = null;
                double doanhthu = 0;
                switch (tg)
                {
                    case "Tháng 1":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 1  and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 2":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) =2 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 3":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 3 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 4":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 4 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 5":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 5 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 6":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 6 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 7":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 7 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 8":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 8 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 9":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 9 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 10":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 10 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 11":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 11 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 12":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 12 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 1":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in (1, 2, 3) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 2":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(4,5,6) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 3":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(7,8,9) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 4":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(10,11,12) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    default: break;
                }
                Connection conn = new Connection();
                conn.moKetNoi();
                SqlDataReader dr = conn.truyVan(sql);
                while (dr.Read())
                {
                    doanhthu += Convert.ToDouble(dr["TongTien"].ToString());
                }
                dr.Close();
                conn.dongKetNoi();
                txtDoanhthu2.Text = doanhthu.ToString();
                if (doanhthu == 0 && i > 0)
                {
                    MessageBox.Show("Chưa có dữ liệu doanh thu của " +cbbHH.Text+" trong " + cbbTG2.Text + " năm " + cbbNam2.Text);
                }
            }
        }

        private void cbbNam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTG2.SelectedIndex >= 0 && cbbNam2.SelectedIndex >= 0)
            {
                string tg = cbbTG2.Text;
                var x = cbbNam2.Text;
                int nam;

                // Kiểm tra nếu x không phải là chuỗi rỗng và có thể chuyển thành số nguyên
                if (string.IsNullOrEmpty(x) || !int.TryParse(x.Trim(), out nam))
                {
                    return;
                }
                string sql = null;
                double doanhthu = 0;
                switch (tg)
                {
                    case "Tháng 1":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 1  and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 2":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) =2 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 3":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 3 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 4":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 4 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 5":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 5 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 6":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 6 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 7":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 7 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 8":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 8 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 9":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 9 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 10":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 10 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 11":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 11 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 12":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 12 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 1":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in (1, 2, 3) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 2":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(4,5,6) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 3":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(7,8,9) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 4":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(10,11,12) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    default: break;
                }
                Connection conn = new Connection();
                conn.moKetNoi();
                SqlDataReader dr = conn.truyVan(sql);
                while (dr.Read())
                {
                    doanhthu += Convert.ToDouble(dr["TongTien"].ToString());
                }
                dr.Close();
                conn.dongKetNoi();
                txtDoanhthu2.Text = doanhthu.ToString();
                if (doanhthu == 0 && i > 0)
                {
                    MessageBox.Show("Chưa có dữ liệu doanh thu của " + cbbHH.Text + " trong " + cbbTG2.Text + " năm " + cbbNam2.Text);
                }
            }
        }

        private void cbbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTG2.SelectedIndex >= 0 && cbbNam2.SelectedIndex >= 0)
            {
                string tg = cbbTG2.Text;
                var x = cbbNam2.Text;
                int nam;

                // Kiểm tra nếu x không phải là chuỗi rỗng và có thể chuyển thành số nguyên
                if (string.IsNullOrEmpty(x) || !int.TryParse(x.Trim(), out nam))
                {
                    return;
                }
                string sql = null;
                double doanhthu = 0;
                switch (tg)
                {
                    case "Tháng 1":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 1  and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 2":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) =2 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 3":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 3 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 4":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 4 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 5":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 5 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 6":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 6 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 7":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 7 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 8":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 8 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 9":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 9 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 10":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 10 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 11":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 11 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Tháng 12":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) = 12 and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 1":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in (1, 2, 3) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 2":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(4,5,6) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 3":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(7,8,9) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    case "Quý 4":
                        {
                            sql = "select h.TongTien from HoaDon h join ChiTietHoaDon c on c.MaHD = h.MaHD where YEAR(h.NgayLap)= " + nam + " and MONTH(h.NgayLap) in(10,11,12) and c.MaHH = '" + cbbHH.SelectedValue.ToString() + "'";
                            break;
                        }
                    default: break;
                }
                Connection conn = new Connection();
                conn.moKetNoi();
                SqlDataReader dr = conn.truyVan(sql);
                while (dr.Read())
                {
                    doanhthu += Convert.ToDouble(dr["TongTien"].ToString());
                }
                dr.Close();
                conn.dongKetNoi();
                txtDoanhthu2.Text = doanhthu.ToString();
                if (doanhthu == 0 && i > 0)
                {
                    MessageBox.Show("Chưa có dữ liệu doanh thu của " + cbbHH.Text + " trong " + cbbTG2.Text + " năm " + cbbNam2.Text);
                }
            }
        }
    }
}
