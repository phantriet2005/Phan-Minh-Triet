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
    public partial class frmMenu: Form
    {
        string TenDangNhap=null;
        int PhanQuyen=-1;
        public frmMenu()
        {
            InitializeComponent();
        }
        
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DangNhap.Text == "Đăng nhập")
            {
                frmDangNhap frm = new frmDangNhap();
                //frm.MdiParent = this;
                var kq = frm.ShowDialog();
                if (kq == DialogResult.OK)
                {
                    TenDangNhap = frm.LayTDN;
                    PhanQuyen = frm.LayPhanQuyen;
                    Connection conn = new Connection();
                    conn.moKetNoi();
                    string sql = null;
                    if (PhanQuyen == 1)
                    {
                        sql = "select * from NhanVien where TenTK = '" + TenDangNhap + "'";
                        pic_Quyen.Image = Properties.Resources.QL;
                        pic_Quyen.Visible = true;
                        lblTen.Visible = true;
                        SqlDataReader dr = conn.truyVan(sql);
                        if (dr.Read())
                             lblTen.Text = dr["TenNV"].ToString();
                        //Nếu chưa có thông tin đầy đủ trên hệ thống
                        if (lblTen.Text == "Họ và tên đăng nhập")
                            lblTen.Text = "";
                        dr.Close();
                        conn.dongKetNoi();
                        DangNhap.Text = "Đăng xuất";
                        //Hiện các chức năng theo phân quyền
                        DanhMuc.Visible = true;
                        QLHH.Visible = true;
                        QLKH.Visible = true;
                        QLNV.Visible = true;
                        CTHD.Visible = true;
                        TTHD.Visible = true;
                        ThongKe.Visible = true;

                    }
                    else
                    if (PhanQuyen == 2)
                    {
                        sql = "select * from NhanVien where TenTK = '" + TenDangNhap + "'";
                        pic_Quyen.Image = Properties.Resources.NV;
                        pic_Quyen.Visible = true;
                        lblTen.Visible = true;
                        SqlDataReader dr = conn.truyVan(sql);
                        if (dr.Read())
                            lblTen.Text = dr["TenNV"].ToString();
                        //Nếu chưa có thông tin đầy đủ trên hệ thống
                        if (lblTen.Text == "Họ và tên đăng nhập")
                            lblTen.Text = "";
                        dr.Close();
                        conn.dongKetNoi();
                        DangNhap.Text = "Đăng xuất";
                        DanhMuc.Visible = true;
                        QLHH.Visible = true; //chỉ xem
                        CTHD.Visible = true;
                        TTHD.Visible = true;
                    }
                    else
                        if (PhanQuyen == 3)
                    {
                        sql = "select * from KhachHang where TenTK = '" + TenDangNhap + "'";
                        pic_Quyen.Image = Properties.Resources.KH;
                        pic_Quyen.Visible = true;
                        lblTen.Visible = true;
                        SqlDataReader dr = conn.truyVan(sql);
                        if (dr.Read())
                            lblTen.Text = dr["TenKH"].ToString();
                        //Nếu chưa có thông tin đầy đủ trên hệ thống
                        if (lblTen.Text == "Họ và tên đăng nhập")
                            lblTen.Text = "";
                        dr.Close();
                        conn.dongKetNoi();
                        DangNhap.Text = "Đăng xuất";
                        DanhMuc.Visible = true;
                        QLHH.Visible = true; //chỉ xem được hàng hoá
                        CTHD.Visible = true;// chỉ xem được hoá đơn của mình
                    }
                    else
                    {
                        //Quyền = -1, nếu đăng ký tài khoản Nhân Viên
                        MessageBox.Show("Tài khoản đang đợi phê duyệt và cấp quyền");
                    }
                }
            }
            else
                if (DangNhap.Text=="Đăng xuất")
            {
                frmMenu_Load(sender, e);
            }    
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            pic_Quyen.Visible = false;
            lblTen.Visible = false;
            DangNhap.Text = "Đăng nhập";
            lblTen.Text = "Họ và tên đăng nhập";
            DanhMuc.Visible = false;
            QLHH.Visible = false;
            QLKH.Visible = false;
            QLNV.Visible = false;
            TTHD.Visible = false;
            CTHD.Visible = false;
            ThongKe.Visible = false;
            //Reset lại
            TenDangNhap = null;
            PhanQuyen = -1;
        }

        private void QLHH_Click(object sender, EventArgs e)
        {
            frmQuanLyHangHoa fr = new frmQuanLyHangHoa(PhanQuyen);
            fr.MdiParent = this;
            fr.Show();
        }

        private void TTHD_Click(object sender, EventArgs e)
        {
            frmThanhToanHoaDon fr = new frmThanhToanHoaDon(TenDangNhap);
            fr.MdiParent = this;
            fr.Show();
        }

        private void CTHD_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon fr = new frmChiTietHoaDon(TenDangNhap, PhanQuyen);
            fr.MdiParent = this;
            fr.Show();
        }

        private void QLNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien fr = new frmQuanLyNhanVien();
            fr.MdiParent = this;
            fr.Show();
        }

        private void QLKH_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang fr = new frmQuanLyKhachHang();
            fr.MdiParent = this;
            fr.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe fr = new frmThongKe();
            fr.MdiParent = this;
            fr.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
