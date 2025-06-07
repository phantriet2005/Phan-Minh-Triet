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
    public partial class frmQuanLyNhanVien: Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }
        public void Loaddgv()
        {
            dgvnhanvien.Rows.Clear();
            Connection conn = new Connection();
            if (conn.moKetNoi())
            {
                string sql = "select MaNV, TenNV, TenTK from NhanVien";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    string m = dr["MaNV"].ToString();
                    string t = dr["TenNV"].ToString();
                    string tk = dr["TenTK"].ToString();

                    dgvnhanvien.Rows.Add(m, t, tk);
                }
                dr.Close();
            }
            conn.dongKetNoi();
        }
        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Tìm kiếm theo mã số, tên nhân viên")
            {
                txttimkiem.Text = "";
                txttimkiem.ForeColor = Color.Black;
            }    

        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                txttimkiem.Text = "Tìm kiếm theo mã số, tên nhân viên";
                txttimkiem.ForeColor = Color.Gray;
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (txttimkiem.Text != "Tìm kiếm theo mã số, tên nhân viên" && txttimkiem.Text != "")

            {
                dgvnhanvien.Rows.Clear();
                Connection conn = new Connection();
                conn.moKetNoi();
                string sql = "select * from NhanVien where TenNV like N'" + txttimkiem.Text + "%' or " +
                   "MaNV like '"+ txttimkiem.Text +"%' or "+ " TenTK like '" + txttimkiem.Text + "%'";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    dgvnhanvien.Rows.Clear();
                    string m = dr["MaNV"].ToString();
                    string t = dr["TenNV"].ToString();
                    string tk = dr["TenTK"].ToString();

                    dgvnhanvien.Rows.Add(m, t, tk);

                }

                while (dr.Read())
                {
                    string m = dr["MaNV"].ToString();
                    string t = dr["TenNV"].ToString();
                    string tk = dr["TenTK"].ToString();

                    dgvnhanvien.Rows.Add(m, t, tk);
                }
                dr.Close();
                conn.dongKetNoi();
            }
        }

        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            txtHoTen.Enabled = false;
            txtDC.Enabled = false;
            txtSDT.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMSNV.Enabled = false;
            txttentk.Enabled = false;
            string msnv = dgvnhanvien.CurrentRow.Cells["MaNV"].Value.ToString();
            Connection conn = new Connection();
            if (conn.moKetNoi())
            {
                string sql = "select * from NhanVien where MaNV = '" + msnv+"'";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    txtMSNV.Text = dr["MaNV"].ToString();
                    txtHoTen.Text = dr["TenNV"].ToString();
                    txtSDT.Text = dr["SDT"].ToString();
                    txtDC.Text = dr["DiaChi"].ToString();
                    txttentk.Text = dr["TenTK"].ToString();
                }
                dr.Close();
            }
            conn.dongKetNoi();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            //
            txttimkiem.Text = "Tìm kiếm theo mã số, tên nhân viên";
            txttimkiem.ForeColor = Color.Gray;
            Connection conn = new Connection();
            conn.moKetNoi();
            //Tự động cấp mã NV
            int sl = 0;
            string ma_lonNhat = null;
            string sql1 = "select TOP 1 MaNV from NhanVien order by convert(int, substring(MaNV,3,LEN(MaNV))) desc";
            SqlDataReader dr1 = conn.truyVan(sql1);
            if (dr1.Read())
            {
                ma_lonNhat = dr1["MaNV"].ToString();
                ma_lonNhat = ma_lonNhat.Replace("NV", "");
                sl = Convert.ToInt32(ma_lonNhat);
            }
            dr1.Close();
            
            string MaNV = null;
            if (sl<10)
            {
                MaNV = "NV0" + (sl + 1);
            }
            else
            {
                MaNV = "NV" + (sl + 1);
            }
            txtMSNV.Text = MaNV;
            //
            dgvnhanvien.Rows.Clear();
            //
            txtHoTen.Enabled = true;
            txtDC.Enabled = true;
            txtSDT.Enabled = true;
            txtMSNV.Enabled = false; 
            txttentk.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //
                string sql = "select MaNV, TenNV, TenTK from NhanVien";
                SqlDataReader dr = conn.truyVan(sql);
                while (dr.Read())
                {
                    string m = dr["MaNV"].ToString();
                    string t = dr["TenNV"].ToString();
                    string tk = dr["TenTK"].ToString();

                    dgvnhanvien.Rows.Add(m, t, tk);
                }
            //
                dr.Close();
            conn.dongKetNoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string tk = "select * from TaiKhoan where TenTK = '" + txttentk.Text + "'";
            conn.moKetNoi();
            SqlDataReader dr = conn.truyVan(tk);
            if (dr.Read())
            {
                MessageBox.Show("Đã tồn tại tên tài khoản " + txttentk.Text);
                //
                dr.Close();
                conn.dongKetNoi();
            }
            else
            if (txtHoTen.Text == "" || txtSDT.Text == "" || txttentk.Text == "" || txtDC.Text == "")
            {
                dr.Close();
                conn.dongKetNoi();
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN");
            }
            else
            {
                dr.Close();
                string tb = "MSNV : " + txtMSNV.Text + "\nHọ tên : " + txtHoTen.Text + "\nĐịa chỉ : " + txtDC.Text + "\nSĐT : " + txtSDT.Text + "\nTên tài khoản : " + txttentk.Text;
                DialogResult r = MessageBox.Show("Thông tin nhân viên : \n" + tb, "Xác nhận thông tin", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        //Tự động tạo tài khoản cấp MK mặc định 123
                        string sql_themTK = "insert into TaiKhoan values ('" + txttentk.Text + "', '123' ,'2')";
                        int kq_themTK = conn.capNhat(sql_themTK);

                        string sql = "insert into NhanVien values ('" + txtMSNV.Text + "', N'" + txtHoTen.Text + "', N'" + txtDC.Text + "', '" + txtSDT.Text + "', '" + txttentk.Text + "')";
                        int kq = conn.capNhat(sql);
                        if (kq > 0 && kq_themTK > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                            frmQuanLyNhanVien_Load(sender, e);
                            txtDC.Text = "";
                            txtHoTen.Text = "";
                            txtSDT.Text = "";
                            txttentk.Text = "";
                        }

                        conn.dongKetNoi();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm không thành công");
                        conn.dongKetNoi();
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Chỉnh sửa")
            {
                btnThem.Enabled = false;
                btnSua.Text = "Lưu";
                btnXoa.Enabled = true;
                txtHoTen.Enabled = true;
                txtDC.Enabled = true;
                txtSDT.Enabled = true;
            }
            else
                if (btnSua.Text == "Lưu")
            {
                string tb = "MSNV : " + txtMSNV.Text + "\nHọ tên : " + txtHoTen.Text + "\nĐịa chỉ : " + txtDC.Text + "\nSĐT : " + txtSDT.Text + "\nTên tài khoản : " + txttentk.Text;
                DialogResult r = MessageBox.Show("Thông tin khách hàng :\n " + tb, "Xác nhận thông tin", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    string msnv = dgvnhanvien.CurrentRow.Cells["MaNV"].Value.ToString();
                    Connection conn = new Connection();
                    conn.moKetNoi();
                    string sql = " update NhanVien set TenNV = N'" + txtHoTen.Text + "', DiaChi =N'" + txtDC.Text + "', SDT = '" + txtSDT.Text + "' where MaNV ='" + msnv + "'";
                    int kq = conn.capNhat(sql);
                    if (kq > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");

                    }
                    conn.dongKetNoi();
                    frmQuanLyNhanVien_Load(sender, e);
                    btnLamlai_Click(sender, e);
                    btnSua.Text = "Chỉnh sửa";
                }
            }   
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string msnv = dgvnhanvien.CurrentRow.Cells["MaNV"].Value.ToString();
            DialogResult kq = MessageBox.Show("Bạn có muốn xoá nhân viên có mã số " + msnv, "Xác nhận", MessageBoxButtons.YesNo);
            switch (kq)
            {
                case DialogResult.Yes:
                    {
                        Connection conn = new Connection();
                        conn.moKetNoi();
                        string sql1 = "delete from NhanVien where MaNV ='" + msnv+"'";
                        int kq1 = conn.capNhat(sql1);
                        //Xoá luôn tài khoản
                        string sql2 = "delete TaiKhoan where TenTK =N'" + txttentk.Text + "'";
                        int kq2 = conn.capNhat(sql2);
                        if (kq1 > 0 && kq2>0)
                        {
                            MessageBox.Show("Đã xóa thành công");
                        }
                        frmQuanLyNhanVien_Load(sender, e);
                        conn.dongKetNoi();
                        break;
                    }

                case DialogResult.No:
                    {
                        break;
                    }
                default: break;
            }
            btnLamlai_Click(sender, e);
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            txtMSNV.Clear();
            txtDC.Clear();
            txtHoTen.Clear();
            txttentk.Clear();
            txtSDT.Clear();
            
            frmQuanLyNhanVien_Load(sender, e);
            
            txtHoTen.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn cấp lại mật khẩu cho tài khoản", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string TenTK = dgvnhanvien.CurrentRow.Cells["TenTK"].Value?.ToString() ?? "";
                Connection conn = new Connection();
                conn.moKetNoi();
                string sql = "update TaiKhoan set MatKhau ='123' where TenTK ='" + TenTK + "'";
                int kq = conn.capNhat(sql);
                if (kq > 0)
                {
                    MessageBox.Show("Cấp lại mật khẩu mặc định '123' thành công");
                }
                conn.dongKetNoi();
            }    
            
            

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsControl(c))
                return;
            if (char.IsControl(c))
                return;
            if (char.IsDigit(c))
                return;
            e.Handled = true;
        }
    }
}

