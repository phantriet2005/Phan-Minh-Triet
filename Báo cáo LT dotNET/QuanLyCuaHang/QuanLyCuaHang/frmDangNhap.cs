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
    public partial class frmDangNhap: Form
    {
        
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public string LayTDN { get; set; }
        public int LayPhanQuyen { get; set; }

        private void txtTDN_Leave(object sender, EventArgs e)
        {
            if (txtTDN.Text == "")
            {
                txtTDN.Text = "Tên đăng nhập";
                txtTDN.ForeColor = Color.Gray;
                
            }
        }
        

        

        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (txtMK.Text.Length==0)
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.Gray;
                txtMK.UseSystemPasswordChar = false;
            }    
        }

        private void txtMK_Enter(object sender, EventArgs e)
        {
            if (txtMK.Text == "Mật khẩu")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void txtTDN_Enter(object sender, EventArgs e)
        {
            if (txtTDN.Text == "Tên đăng nhập")
            {
                txtTDN.Text = "";
                txtTDN.ForeColor = Color.Black;
            }
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (txtTDN.Text=="Tên đăng nhập" || txtMK.Text == "Mật khẩu")
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐỦ THÔNG TIN");
            }
            else
            {
                bool dn = false;
                int quyen = -1;
                Connection conn = new Connection();
                conn.moKetNoi();
                //Kiểm tra TDN và MK có đúng không
                string sql = "select * from TaiKhoan where TenTK = '" + txtTDN.Text + "' and MatKhau ='" + txtMK.Text + "'";
                SqlDataReader dr = conn.truyVan(sql);
                if (dr.Read())
                {
                    MessageBox.Show("Đăng nhập thành công");
                    quyen = Convert.ToInt32(dr["PhanQuyen"].ToString());
                    dn = true;
                }
                dr.Close();
                conn.dongKetNoi();
                if (dn==true)
                {
                    //Lấy Tên đăng nhập và Phân quyền đưa vào frm Menu
                    LayTDN =txtTDN.Text;
                    LayPhanQuyen = quyen;
                    this.DialogResult = DialogResult.OK;
                    this.Close();    
                }
                else
                {
                    MessageBox.Show("Sai thông tin vui lòng nhập lại");
                    txtTDN.Focus();
                }
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            frmDangKy dk = new frmDangKy();
            dk.Show();
            //this.Hide();
            this.Close();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            //Hiện mật khẩu
            if (txtMK.Text !="Mật khẩu")
                txtMK.UseSystemPasswordChar = false;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (txtMK.Text != "Mật khẩu")
                txtMK.UseSystemPasswordChar = true;
        }

        
    }
}
