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
    public partial class frmThanhToanHoaDon: Form
    {
        string TenTK=null;
        public frmThanhToanHoaDon()
        {
            InitializeComponent();
        }
        public frmThanhToanHoaDon(string tdn)
        {
            InitializeComponent();
            TenTK = tdn;
        }
        private void frmThanhToanHoaDon_Load(object sender, EventArgs e)
        {
            //
            Connection conn = new Connection();
            conn.moKetNoi();
            string sql_ma = "select MaNV from NhanVien where TenTK ='" + TenTK + "'";
            SqlDataReader dr_ma = conn.truyVan(sql_ma);
            if (dr_ma.Read())
            {
                txtNV.Text = dr_ma["MaNV"].ToString();
            }
            dr_ma.Close();
            //
            dgvHH_ThanhToan.Rows.Clear();
            //
            txtNV.Enabled = false;
            //
            txtKH.Clear();
            txtTongTien.Text = "0";
            txtTienthoi.Text = "0";
            txtKhachDua.Text = "0";
            txtTim.Text = "Tìm kiếm theo tên, mã hàng hoá";
            txtTim.ForeColor = Color.Gray;
            txtKhachDua.Enabled = false;
            //Cập nhật ngày hiện tại
            DateTime hientai = DateTime.Today;
            dateNgayLap.Value = hientai;
            //Tự động thêm số Hoá đơn
            
            int sl = 0;
            string ma_lonNhat = null;
            string sql1 = "select TOP 1 MaHD from HoaDon order by convert(int, substring(MaHD,3,LEN(MaHD))) desc";
            SqlDataReader dr1 = conn.truyVan(sql1);
            if (dr1.Read())
            {
                ma_lonNhat = dr1["MaHD"].ToString();
                ma_lonNhat = ma_lonNhat.Replace("HD", "");
                sl = Convert.ToInt32(ma_lonNhat);
            }
            dr1.Close();
            if (sl <10)
            {
                txtSHD.Text = "HD0" + (sl + 1);
            }
            else
                txtSHD.Text = "HD" + (sl + 1);
            txtSHD.Enabled = false;
            //Đổ dl vào cbb
            string sql = "select * from LoaiHang ";
            SqlDataReader dr = conn.truyVan(sql);
            DataTable dt = new DataTable();
            dt.Load(dr);
            cbbLH.DataSource = dt;
            cbbLH.DisplayMember = "TenLH";
            cbbLH.ValueMember = "MaLH";
            try
            {
                cbbLH.SelectedIndex = 0;
                //
                cbbLH_SelectedIndexChanged(sender, e);
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa có dữ liệu về LOẠI HÀNG\nVUI LÒNG CẬP NHẬT LẠI CSDL");
            }
            
            conn.dongKetNoi();
        }

        private void cbbLH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvHH.Rows.Clear();
            if (cbbLH.SelectedValue.ToString() == null ||
                cbbLH.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            else
            if (cbbLH.SelectedIndex >= 0)
            {
                Connection conn = new Connection();
                conn.moKetNoi();
                string sql = "select * from HangHoa where TrangThai = N'Còn bán' and MaLH ='" + cbbLH.SelectedValue.ToString() + "'";
                SqlDataReader dr = conn.truyVan(sql);

                while (dr.Read())
                {
                    string m = dr["MaHH"].ToString();
                    string t = dr["TenHH"].ToString();
                    string dg = dr["DonGia"].ToString();
                    string dvt = dr["DVT"].ToString();
                    dgvHH.Rows.Add(m, t, dg, dvt);
                }
                dr.Close();
                conn.dongKetNoi();
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            if (txtTim.Text == "Tìm kiếm theo tên, mã hàng hoá")
            {
                txtTim.Text = "";
                txtTim.ForeColor = Color.Black;
            }
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                txtTim.Text = "Tìm kiếm theo tên, mã hàng hoá";
                txtTim.ForeColor = Color.Gray;
            }
        }

        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            ///// Bỏ qua nếu click ngoài vùng dòng
            //if (e.RowIndex < 0 || dgvHH.CurrentRow == null) return;
            string ma = dgvHH.CurrentRow.Cells["MaHH"].Value?.ToString() ?? "";
            string donGiaStr = dgvHH.CurrentRow.Cells["DonGia"].Value?.ToString() ?? "0";
            double donGia = Convert.ToDouble(donGiaStr);
            bool kt = false;

            for (int i = 0; i < dgvHH_ThanhToan.Rows.Count; i++)
            {
                string ma_tt = dgvHH_ThanhToan.Rows[i].Cells[0].Value?.ToString() ?? "";
                //Nếu hàng hóa đã có ở bảng Thanh toán thì không thêm mới mà cập nhật lại Số lượng và Thành tiền
                if (ma_tt == ma)
                {
                    kt = true;
                    int soLuong = Convert.ToInt32(dgvHH_ThanhToan.Rows[i].Cells[3].Value) + 1;
                    dgvHH_ThanhToan.Rows[i].Cells[3].Value = soLuong;
                    dgvHH_ThanhToan.Rows[i].Cells[4].Value = (donGia * soLuong).ToString();
                    break;
                }
            }

            if (!kt)
            {
                //Nếu chưa có ở bảng Thanh toán thì thêm mới
                string ten = dgvHH.CurrentRow.Cells["TenHH"].Value?.ToString() ?? "";
                string sl = "1";
                string tt = donGia.ToString(); // đơn giá x 1
                dgvHH_ThanhToan.Rows.Add(ma,ten, donGiaStr, sl, tt);
            }
            double Tong = 0;
            foreach (DataGridViewRow row in dgvHH_ThanhToan.Rows)
            {
                Tong = Tong + Convert.ToDouble(row.Cells["ThanhTien"].Value );
                txtTongTien.Text = Tong.ToString();
            }    

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            if (txtTongTien.Text != "0")
            {
                txtKhachDua.Enabled = true;
            }
            if (Convert.ToDouble(txtKhachDua.Text) < Convert.ToDouble(txtTongTien.Text) && txtKhachDua.Text != "0")
            {
                MessageBox.Show("Số tiền không hợp lệ");
                txtTienthoi.Text = (Convert.ToDouble(txtKhachDua.Text) - Convert.ToDouble(txtTongTien.Text)).ToString();
                txtKhachDua.Focus();
            }
        }

        private void txtKhachDua_Enter(object sender, EventArgs e)
        {
            if (txtKhachDua.Text=="0")
            {
                txtKhachDua.Text = "";
                txtKhachDua.ForeColor = Color.Black;
            }    
        }

        private void txtKhachDua_Leave(object sender, EventArgs e)
        {
            if (txtKhachDua.Text == "")
            {
                txtKhachDua.Text = "0";
                txtKhachDua.ForeColor = Color.Gray;
            }
            else
            {
                if (Convert.ToDouble(txtKhachDua.Text) < Convert.ToDouble(txtTongTien.Text))
                    {
                    MessageBox.Show("Số tiền không hợp lệ");
                    txtKhachDua.Focus();
                }
                
            }
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txtKhachDua.Text != "0" && txtKhachDua.Text != "")
            {
                
                {
                    txtTienthoi.Text = (Convert.ToDouble(txtKhachDua.Text) - Convert.ToDouble(txtTongTien.Text)).ToString();
                }    
            }    
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text != "Tìm kiếm theo tên, mã hàng hoá" && txtTim.Text !="" )
            
            {
                Connection conn = new Connection();
                conn.moKetNoi();
                string sql = "select * from HangHoa where TenHH like N'" + txtTim.Text + "%' or " +
                    "MaHH like '" + txtTim.Text + "%'";
                SqlDataReader dr = conn.truyVan(sql);
                //Đọc dòng đầu tiên - nếu không có thì bị bỏ dòng đầu tiên
                if (dr.Read())
                {
                    dgvHH.Rows.Clear();
                    string m = dr["MaHH"].ToString();
                    string t = dr["TenHH"].ToString();
                    string dg = dr["DonGia"].ToString();
                    string dvt = dr["DVT"].ToString();
                    dgvHH.Rows.Add(m, t, dg, dvt);

                }
                //Đọc tiếp
                while (dr.Read())
                {
                    string m = dr["MaHH"].ToString();
                    string t = dr["TenHH"].ToString();
                    string dg = dr["DonGia"].ToString();
                    string dvt = dr["DVT"].ToString();

                    dgvHH.Rows.Add(m, t, dg, dvt);
                }
                dr.Close();
                conn.dongKetNoi();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            bool kt = false;
            bool next = false;
            Connection conn = new Connection();
            conn.moKetNoi();
            //Kiểm tra nếu có nhập mã khách hàng, mã KH có thể NULL nếu KH chưa có tài khoản trên hệ thống
            if (txtKH.Text != "")
            {
                string kt1 = "select * from KhachHang where MaKH ='" + txtKH.Text + "'";
                SqlDataReader dr_kt = conn.truyVan(kt1);
                if (dr_kt.Read())
                {
                    kt = true;
                }
                dr_kt.Close();
            }
            else
            {
                next = true;
            }
            //Kiểm tra đã chọn HH chưa 
             if (dgvHH_ThanhToan.Rows.Count == 0)
            {
                MessageBox.Show("VUI LÒNG CHỌN HÀNG HOÁ ĐỂ THANH TOÁN");
            }
            else
            if (kt == false && next == false)
            {
                MessageBox.Show("KIỂM TRA LẠI MÃ KHÁCH HÀNG\nBỎ TRỐNG NẾU KHÁCH HÀNG KHÔNG CÓ TÀI KHOẢN");
            }
            //Kiểm tra nếu có nhập mã khách hàng
            else

            {
                DateTime ngayL = dateNgayLap.Value;  // từ DateTimePicker
                string ngay = ngayL.ToString("yyyy-MM-dd");

                //Thêm vào bảng Hoá Đơn
                string sql = null;
                if (txtKH.Text != "")
                    sql = "insert into HoaDon values " +
                    "('" + txtSHD.Text + "', '" + ngay + "', '" + txtNV.Text + "','" + txtKH.Text + "'," + txtTongTien.Text + ")";
                else
                    sql = "insert into HoaDon values " +
                    "('" + txtSHD.Text + "', '" + ngay + "' , '" + txtNV.Text + "',null, " + txtTongTien.Text + ")";
                int kq = conn.capNhat(sql);

                //Thêm vào chi tiết hoá đơn
                bool ctht = false;
                for (int i = 0; i < dgvHH_ThanhToan.Rows.Count; i++)
                {
                    string mahh = dgvHH_ThanhToan.Rows[i].Cells[0].Value?.ToString() ?? "";
                    string sl = dgvHH_ThanhToan.Rows[i].Cells[3].Value?.ToString() ?? "";
                    string tt = dgvHH_ThanhToan.Rows[i].Cells[4].Value?.ToString() ?? "";
                    string sql1 = "insert into ChiTietHoaDon values " +
                        "('" + txtSHD.Text + "','" + mahh + "'," + sl + "," + tt + ")";
                    int kq1 = conn.capNhat(sql1);
                    if (kq1 > 0)
                    {
                        ctht = true;
                    }
                    else
                        ctht = false;
                }
                if (kq > 0 && ctht)
                {
                    MessageBox.Show("Xuất thành công hoá đơn");
                }

                conn.dongKetNoi();
                frmThanhToanHoaDon_Load(sender, e);

            } 
        
        }

        private void txtKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho phép nhập số
            char c = e.KeyChar;
            if (char.IsControl(c))
                return;
            if (char.IsControl(c))
                return;
            if (char.IsDigit(c))
                return;
            if (c == '.')
            {
                if (txtKhachDua.Text.Contains(".") || txtKhachDua.Text == "")
                    e.Handled = true;
                else
                    return;
            }
            e.Handled = true;
        }
    }
}
