using _QuanLyCHTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class frmDangKy: Form
    {
        private bool kt = false;
        private bool ktNV = false;
        private bool ktKH = false;
        public frmDangKy()
        {
            InitializeComponent();
            txtMK.Text = "Mật khẩu";
        }

        

        private void btnDK_Click(object sender, EventArgs e)
        {
            //Kiểm tra người dùng đã nhập đầy đủ thông tin chưa
            if (txtSDT.Text=="Số điện thoại" || txtHo.Text=="Họ" || txtMK.Text=="Mật khẩu"
                || txtMKxn.Text =="Xác nhận lại mật khẩu" || txtMK.Text=="Mật khẩu" 
                || txtDC.Text=="Địa chỉ"
                || txtTen.Text =="Tên" || (rdbNV.Checked==false && rdbKH.Checked==false))
            {
                MessageBox.Show("VUI LÒNG CUNG CẤP ĐẦY ĐỦ THÔNG TIN");
            }
            else
            {
                Connection conn = new Connection();
                conn.moKetNoi();
                //Tự động cấp mã Nhân viên / Khách hàng
                int sl=0;
                string MaSo = null;
                if (rdbNV.Checked==true)
                {
                    string ma_lonNhat = null;
                    //Lấy mã số lớn nhất phía sau mã NV/KH VD: KH02 --> '02'
                    string sql1 = "select TOP 1 MaNV from NhanVien order by convert(int, substring(MaNV,3,LEN(MaNV))) desc";
                    SqlDataReader dr1 = conn.truyVan(sql1);
                    if (dr1.Read())
                    {
                        ma_lonNhat = dr1["MaNV"].ToString();
                        ma_lonNhat = ma_lonNhat.Replace("NV", "");
                        sl = Convert.ToInt32(ma_lonNhat);
                    }
                    dr1.Close();
                }
                else
                    if (rdbKH.Checked==true)
                        {
                    string ma_lonNhat = null;
                    string sql1 = "select TOP 1 MaKH from KhachHang order by convert(int, substring(MaKH,3,LEN(MaKH))) desc";
                    SqlDataReader dr1 = conn.truyVan(sql1);
                    if (dr1.Read())
                    {
                        ma_lonNhat = dr1["MaKH"].ToString();
                        ma_lonNhat = ma_lonNhat.Replace("KH", "");
                        sl = Convert.ToInt32(ma_lonNhat);
                    }
                    dr1.Close();

                }
                    //
                string sql = null;
                string sql2 = null;
                //Mã nhân viên/khách hàng
                if (rdbKH.Checked==true)
                {
                    if (sl <10)
                    {
                        MaSo = "KH0" + (sl+1);
                    }
                    else
                    {
                        MaSo = "KH" + (sl + 1);
                    }
                    //Khách hàng có quyền là 3
                    sql = "insert into TaiKhoan values ('"+txtTDN.Text + "' , '" + txtMK.Text + "', '3')";
                    sql2 = "insert into KhachHang(MaKH,TenKH,DiaChi,SDT,TenTK) values " +
                        "('"+MaSo+"', N'" + txtHo.Text + " " + txtTen.Text + "' , N'" + txtDC.Text + "', '" + txtSDT.Text + "', '"
                        + txtTDN.Text + "')";
                }                        
                else
                    if (rdbNV.Checked==true)
                {
                    if (sl < 10)
                    {
                        MaSo = "NV0" + (sl + 1);
                    }
                    else
                    {
                        MaSo = "NV" + (sl + 1);
                    }
                    //nếu là Nhân Viên thì tài khoản cần được phê duyệt, quyền = -1 (chưa cấp quyền, NV có quyền là 2)
                    sql = "insert into TaiKhoan values ('" + txtTDN.Text + "' , '" + txtMK.Text + "', '-1')";
                    sql2 = "insert into NhanVien(MaNV,TenNV,DiaChi,SDT,TenTK) values " +
                        "('" + MaSo + "', N'" + txtHo.Text + " " + txtTen.Text + "' , N'" + txtDC.Text + "', '" + txtSDT.Text + "', '"
                        + txtTDN.Text + "')";
                }    
                    
                int kq = conn.capNhat(sql);
                int kq2 = conn.capNhat(sql2);
                if (kq > 0 && kq2 > 0)
                {
                    MessageBox.Show("Tạo tài khoản thành công !!!\nHÃY ĐĂNG NHẬP");
                    //txtHo.Text = "Họ";
                    //txtTen.Text = "Tên";
                    //txtTDN.Text = "Tên đăng nhập";
                    //txtMK.Text = "Mật khẩu";
                    //txtMKxn.Text = "Xác nhận lại mật khẩu";
                    //txtSDT.Text = "Số điện thoại";
                    //txtDC.Text = "Địa chỉ";
                    //txtMKxn.UseSystemPasswordChar = false;
                    //rdbKH.Checked = false;
                    //rdbNV.Checked = false;
                    //btnDK.Focus();
                    //foreach (Control c in Controls)
                    //    if (c is TextBox)
                    //        c.ForeColor = Color.Gray;
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("VUI LÒNG KIỂM TRA LẠI THÔNG TIN");
                }
            }    
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            lblMKxn.Visible = false;
            lblTDN.Visible = false;
            btnDK.Focus();
            rdbKH.Checked = false;
            rdbNV.Checked = false;
            
        }

        private void txtHo_Enter(object sender, EventArgs e)
        {
            if (txtHo.Text.CompareTo("Họ")==0)
            {
                txtHo.Text = "";
                txtHo.ForeColor = Color.Black;
            }    
        }

        private void txtHo_Leave(object sender, EventArgs e)
        {
            if (txtHo.Text.Length == 0)
            {
                txtHo.Text = "Họ";
                txtHo.ForeColor = Color.Gray;
            }
        }

        private void txtTen_Enter(object sender, EventArgs e)
        {
            if (txtTen.Text.CompareTo("Tên") == 0)
            {
                txtTen.Text = "";
                txtTen.ForeColor = Color.Black;
            }
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            if (txtTen.Text.Length == 0)
            {
                txtTen.Text = "Tên";
                txtTen.ForeColor = Color.Gray;
            }
        }

        private void txtTDN_Leave(object sender, EventArgs e)
        {
            if (txtTDN.Text.Length == 0)
            {
                txtTDN.Text = "Tên đăng nhập";
                txtTDN.ForeColor = Color.Gray;
            }
        }

        private void txtTDN_Enter(object sender, EventArgs e)
        {
            if (txtTDN.Text.CompareTo("Tên đăng nhập") == 0)
            {
                txtTDN.Text = "";
                txtTDN.ForeColor = Color.Black;
            }
        }

        private void txtMK_Enter(object sender, EventArgs e)
        {
            if (txtMK.Text.CompareTo("Mật khẩu") == 0)
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
            }
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (txtMK.Text.Length == 0)
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.Gray;
            }
        }

        private void txtMKxn_Leave(object sender, EventArgs e)
        {
            if (txtMKxn.Text.Length == 0)
            {
                txtMKxn.Text = "Xác nhận lại mật khẩu";
                txtMKxn.ForeColor = Color.Gray;
                txtMKxn.UseSystemPasswordChar = false;
                lblMKxn.Visible = false;

            }
            
        }

        private void txtMKxn_Enter(object sender, EventArgs e)
        {
            
            if (txtMKxn.Text.CompareTo("Xác nhận lại mật khẩu") == 0 )
            {
                txtMKxn.Text = "";
                txtMKxn.ForeColor = Color.Black;
                txtMKxn.UseSystemPasswordChar = true;
            }
        }

        private void txtDC_Enter(object sender, EventArgs e)
        {
            if (txtDC.Text.CompareTo("Địa chỉ") == 0)
            {
                txtDC.Text = "";
                txtDC.ForeColor = Color.Black;
            }
        }

        private void txtDC_Leave(object sender, EventArgs e)
        {
            if (txtDC.Text.Length == 0)
            {
                txtDC.Text = "Địa chỉ";
                txtDC.ForeColor = Color.Gray;
            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length == 0)
            {
                txtSDT.Text = "Số điện thoại";
                txtSDT.ForeColor = Color.Gray;
            }
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            if (txtSDT.Text.CompareTo("Số điện thoại") == 0)
            {
                txtSDT.Text = "";
                txtSDT.ForeColor = Color.Black;
            }
        }

        private void txtTDN_TextChanged(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.moKetNoi();
            //Kiểm tra Tên TK đã có trên hệ thống chưa, nếu đã có thì hiện thông báo và vô hiệu hóa nút đăng ký
            string sql = "select * from TaiKhoan where TenTK = '" + txtTDN.Text + "'";
            SqlDataReader dr = conn.truyVan(sql);
            if (dr.Read())
            {
                lblTDN.Visible = true;
                btnDK.Enabled = false;
            }
            else
            {
                lblTDN.Visible = false;
                btnDK.Enabled = true;
            }
                dr.Close();
            conn.dongKetNoi();
        }

        private void txtMKxn_TextChanged(object sender, EventArgs e)
        {
            //Kiểm tra xem có khớp không, nếu không thì vô hiệu hóa nút đăng ký
            if (txtMKxn.Text.CompareTo(txtMK.Text) != 0 && txtMKxn.Text.Length!=0
                && txtMKxn.Text!="Xác nhận lại mật khẩu" && txtMK.Text != "Mật khẩu") 
            {
                lblMKxn.Visible = true;
                btnDK.Enabled = false;
            }
            else
            {
                lblMKxn.Visible = false;
                btnDK.Enabled = true;
            }    
                
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
            //Kiểm tra xem có khớp không, nếu không thì vô hiệu hóa nút đăng ký
            if (txtMK.Text.CompareTo(txtMKxn.Text)!=0 && txtMKxn.Text!="Xác nhận lại mật khẩu")
            {
                lblMKxn.Visible = true;
                btnDK.Enabled = false;
            }
            else
            {
                lblMKxn.Visible = false;
                btnDK.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SDT chỉ cho phép nhập số
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

