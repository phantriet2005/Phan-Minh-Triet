using _QuanLyCHTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class frmQuanLyHangHoa: Form
    {
        int _quyen = -1;
        public frmQuanLyHangHoa()
        {
            InitializeComponent();
        }

        public frmQuanLyHangHoa(int quyen)
        {
            InitializeComponent();
            _quyen = quyen;
        }

        private void frmQuanLyHangHoa_Load(object sender, EventArgs e)
        {
            //Nhân viên và Khách hàng chỉ được xem thông tin hàng hóa
            if (_quyen==2 || _quyen==3)
            {
                btnLamlai.Visible = false;
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }   
            //Xóa dữ liệu của TextBox
            txtTim.Text = "Tìm kiếm theo tên, mã hàng hoá";
            txtTim.ForeColor = Color.Gray;
            txtMH.Clear();
            txtTH.Clear();
            txtDVT.Clear();
            txtDG.Clear();
            txtXS.Clear();
            //cbb Trạng thái chưa được chọn
            cbbTT.SelectedIndex = -1;
            //Vô hiệu hóa nút Sửa và Xóa, hiện lại khi người dùng đổ dữ liệu từ DGV 
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            //Mã hàng hóa được cấp tự động
            cbbTT.Enabled = true;
            txtTH.Enabled = true;
            txtDG.Enabled = true;
            txtDVT.Enabled = true;
            txtXS.Enabled = true;
            txtMH.Enabled =false;
            //Xóa hết dữ liệu của DGV
            dgvHH.Rows.Clear();
            dgvHH.DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            //Đổ dữ liệu Loại hàng vào combobox Loại hàng
            Connection conn = new Connection();
            conn.moKetNoi();
            string sql = "select * from LoaiHang";
            SqlDataReader dr = conn.truyVan(sql);
            DataTable dt = new DataTable();
            dt.Load(dr);
            //Hiện tên loại hàng - Giá trị là mã Loại hàng
            cbbLH.DataSource =  dt;
            cbbLH.DisplayMember = "TenLH";
            cbbLH.ValueMember = "MaLH";
            //Tự động cấp mã HH
            string MaHH = "";
            if (_quyen==1)
            {
                int sl = 0;
                string ma_lonNhat = null;
                //Tìm mã HH lớn nhất
                string sql1 = "select TOP 1 MaHH from HangHoa order by convert(int, substring(MaHH,3,LEN(MaHH))) desc";
                SqlDataReader dr1 = conn.truyVan(sql1);
                if (dr1.Read())
                {
                    ma_lonNhat = dr1["MaHH"].ToString();
                    ma_lonNhat = ma_lonNhat.Replace("HH", "");
                    sl = Convert.ToInt32(ma_lonNhat);
                }
                dr1.Close();
                //Cấp mã HH
                if (sl < 10)
                {
                    MaHH = "HH0" + (sl + 1);
                }
                else
                {
                    MaHH = "HH" + (sl + 1);
                }
            }    
            //Thêm dữ liệu cho TextBox hàng hóa
            txtMH.Text = MaHH;
            try
            {
                cbbLH.SelectedIndex = 0;
                //Gọi SK SelectedIndexChanged
                comboBox1_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa có dữ liệu về loại hàng/nVUI LÒNG KIỂM TRA CSDL LOẠI HÀNG");
            }

            dr.Close();
            conn.dongKetNoi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                //Đổ dữ liệu vào dgv theo loại hàng
                string sql  = "select * from HangHoa where MaLH ='" + cbbLH.SelectedValue.ToString() + "'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Kiểm tra người dùng đã nhập đầu đủ thông tin chưa
            if (txtTH.Text == "" || txtDVT.Text == "" || txtXS.Text == "" ||
                txtDG.Text == "" || cbbTT.SelectedIndex == -1)
            {
                MessageBox.Show("VUI LÒNG CUNG CẤP ĐẦY ĐỦ THÔNG TIN HÀNG HOÁ");
            }
            else
            {
                Connection conn = new Connection();
                conn.moKetNoi();
                //Tự động cấp mã 
                int sl = 0;
                string ma_lonNhat = null;
                string sql1 = "select TOP 1 MaHH from HangHoa order by convert(int, substring(MaHH,3,LEN(MaHH))) desc";
                SqlDataReader dr1 = conn.truyVan(sql1);
                if (dr1.Read())
                {
                    ma_lonNhat = dr1["MaHH"].ToString();
                    ma_lonNhat = ma_lonNhat.Replace("HH", "");
                    sl = Convert.ToInt32(ma_lonNhat);
                }
                dr1.Close();
                string MaHH = null;
                if (sl < 10)
                {
                    MaHH = "HH0" + (sl + 1);
                }
                else
                {
                    MaHH = "HH" + (sl + 1);
                }
                //
                string sql = "select * from HangHoa where MaHH = '" + txtMH.Text + "'";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    MessageBox.Show("Mã hàng hoá đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMH.Text = MaHH;
                    txtMH.Enabled = false;
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    //
                    string tb = "Loại hàng : " + cbbLH.Text + "\nMã hàng : " +
                            txtMH.Text + "\nTên hàng : " + txtTH.Text + "\nĐơn vị tính : " +
                            txtDVT.Text + "\nĐơn giá : " + txtDG.Text + "\nXuất sứ : " + txtXS.Text
                            + "\nTrạng thái : " + cbbTT.Text;
                    DialogResult resulf = MessageBox.Show("Bạn muốn thêm hàng hoá có thông tin \n" + tb, "Thông báo", MessageBoxButtons.YesNo);
                    if (resulf == DialogResult.Yes)
                    {

                        string sql01 = "insert into HangHoa values " +
                                "('" + txtMH.Text + "' , N'" + txtTH.Text + "', " + txtDG.Text + ", N'" +
                                txtDVT.Text + "' ,N'" + txtXS.Text + "', '" + cbbLH.SelectedValue.ToString() + "', N'" + cbbTT.Text + "')";
                        try
                        {
                            int kq = conn.capNhat(sql01);
                            if (kq > 0)
                            {
                                MessageBox.Show("Thêm hàng hoá thành công");
                            }
                            frmQuanLyHangHoa_Load(sender, e);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm hàng hoá không thành công\nVUI LÒNG KIỂM TRA THÔNG TIN"
                              , "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }


                }
                conn.dongKetNoi();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                cbbTT.Enabled = false;
                txtMH.Enabled = false;
                txtTH.Enabled = false;
                txtDG.Enabled = false;
                txtDVT.Enabled = false;
                txtXS.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;


                //Nếu mã HH là null thì gán là rỗng
                string ma = dgvHH.CurrentRow.Cells["MaHH"].Value?.ToString() ?? "";
                Connection conn = new Connection();
                conn.moKetNoi();

                string sql = "select * from HangHoa where MaHH ='" + ma + "'";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    txtMH.Text = dr["MaHH"].ToString();
                    txtTH.Text = dr["TenHH"].ToString();
                    txtDG.Text = dr["DonGia"].ToString();
                    txtDVT.Text = dr["DVT"].ToString();
                    txtXS.Text = dr["XuatSu"].ToString();
                    // 0 : Còn bán ; 1: Không còn bán
                    if (dr["TrangThai"].ToString()=="Còn bán")
                    {
                        cbbTT.SelectedIndex = 0;
                    }
                    else
                        if (dr["TrangThai"].ToString()=="Không còn bán")
                    {
                        cbbTT.SelectedIndex = 1;
                    }
                    else
                    {
                        cbbTT.SelectedIndex = -1;
                    }
                }
                dr.Close();
                conn.dongKetNoi();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text =="Chỉnh sửa")
            {
                cbbTT.Enabled = true;
                txtTH.Enabled = true;
                txtDG.Enabled = true;
                txtDVT.Enabled = true;
                txtXS.Enabled = true;
                btnSua.Text = "Lưu";
                btnXoa.Enabled = false;
            }
            else
                if (btnSua.Text == "Lưu")
            {
                string tb = "Loại hàng : " + cbbLH.Text + "\nMã hàng : " +
                            txtMH.Text + "\nTên hàng : " + txtTH.Text + "\nĐơn vị tính : " +
                            txtDVT.Text + "\nĐơn giá : " + txtDG.Text + "\nXuất sứ : " + txtXS.Text
                            + "\nTrạng thái : " + cbbTT.Text;
                DialogResult resulf = MessageBox.Show("Thông tin thay đổi :\n" + tb, "Xác nhận thông tin hàng hóa", MessageBoxButtons.YesNo);
                if (resulf == DialogResult.Yes)
                {
                    Connection conn = new Connection();
                    conn.moKetNoi();
                    string sql = "update HangHoa set " +
                        "TenHH =N'" + txtTH.Text + "' ," +
                        "DonGia =" + txtDG.Text + ", " +
                        "DVT =N'" + txtDVT.Text + "', " +
                        "XuatSu =N'" + txtXS.Text + "'," +
                        "TrangThai =N'" + cbbTT.Text + "'"
                        + " where MaHH ='" + txtMH.Text + "'";
                    try
                    {
                        int kq = conn.capNhat(sql);
                        if (kq > 0)
                        {
                            MessageBox.Show("Cập nhật thành công !!!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật không thành công !!!\nVUI LÒNG KIỂM TRA DỮ LIỆU NHẬP",
                            "Cánh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    conn.dongKetNoi();
                    btnSua.Text = "Chỉnh sửa";
                    frmQuanLyHangHoa_Load(sender, e);
                }    
                    
                
            }    
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            frmQuanLyHangHoa_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xoá " + txtMH.Text + " không ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq ==DialogResult.Yes)
            {
                Connection conn = new Connection();
                conn.moKetNoi();
                string sql = "delete HangHoa where MaHH = '" + txtMH.Text + "'";
                try
                {
                    int kq2 = conn.capNhat(sql);
                    if (kq2 > 0)
                    {
                        MessageBox.Show("Xoá thành công hàng hoá có mã là "+txtMH.Text);
                    }
                    frmQuanLyHangHoa_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xoá hàng hoá có mã là " + txtMH.Text);
                }
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
            if (txtTim.Text=="")
            {
                txtTim.Text = "Tìm kiếm theo tên, mã hàng hoá";
                txtTim.ForeColor = Color.Gray;
            }    
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "Tìm kiếm theo tên, mã hàng hoá")
            {
                txtTim.Focus();
            }
            else
            {
                Connection conn = new Connection();
                conn.moKetNoi();
                string sql = "select * from HangHoa where TenHH like N'" + txtTim.Text + "%' or " +
                    "MaHH like '" + txtTim.Text + "%'";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    dgvHH.Rows.Clear();
                    string m = dr["MaHH"].ToString();
                    string t = dr["TenHH"].ToString();
                    string dg = dr["DonGia"].ToString();
                    string dvt = dr["DVT"].ToString();
                    dgvHH.Rows.Add(m, t, dg, dvt);

                }    
                    
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

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text != "Tìm kiếm theo tên, mã hàng hoá" && txtTim.Text != "")

            {
                Connection conn = new Connection();
                conn.moKetNoi();
                string sql = "select * from HangHoa where TenHH like N'" + txtTim.Text + "%' or " +
                    "MaHH like '" + txtTim.Text + "%'";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    dgvHH.Rows.Clear();
                    string m = dr["MaHH"].ToString();
                    string t = dr["TenHH"].ToString();
                    string dg = dr["DonGia"].ToString();
                    string dvt = dr["DVT"].ToString();
                    dgvHH.Rows.Add(m, t, dg, dvt);

                }

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

        private void txtDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho phép nhập số, 1 dấu . không ở vị trí bắt đầu Length=0
            char c = e.KeyChar;
            if (char.IsControl(c))
                return;
            if (char.IsControl(c))
                return;
            if (char.IsDigit(c))
                return;
            if (c=='.')
            {
                if (txtDG.Text.Contains(".") || txtDG.Text=="")
                    e.Handled = true;
                else
                    return;
            }
            e.Handled = true;
        }
    }
}
