namespace QuanLyCuaHang
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.DanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.QLHH = new System.Windows.Forms.ToolStripMenuItem();
            this.QLNV = new System.Windows.Forms.ToolStripMenuItem();
            this.QLKH = new System.Windows.Forms.ToolStripMenuItem();
            this.TTHD = new System.Windows.Forms.ToolStripMenuItem();
            this.CTHD = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTen = new System.Windows.Forms.Label();
            this.quảnLýThôngTinHàngHoáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánHoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiTiếtHoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pic_Quyen = new System.Windows.Forms.PictureBox();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Quyen)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DangNhap,
            this.DanhMuc,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(853, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DangNhap
            // 
            this.DangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangNhap.ForeColor = System.Drawing.Color.Navy;
            this.DangNhap.Name = "DangNhap";
            this.DangNhap.Size = new System.Drawing.Size(107, 26);
            this.DangNhap.Text = "Đăng nhập";
            this.DangNhap.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // DanhMuc
            // 
            this.DanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QLHH,
            this.QLNV,
            this.QLKH,
            this.TTHD,
            this.CTHD,
            this.ThongKe});
            this.DanhMuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DanhMuc.ForeColor = System.Drawing.Color.Navy;
            this.DanhMuc.Name = "DanhMuc";
            this.DanhMuc.Size = new System.Drawing.Size(102, 26);
            this.DanhMuc.Text = "Danh mục";
            // 
            // QLHH
            // 
            this.QLHH.Name = "QLHH";
            this.QLHH.Size = new System.Drawing.Size(248, 26);
            this.QLHH.Text = "Quản lý hàng hoá";
            this.QLHH.Click += new System.EventHandler(this.QLHH_Click);
            // 
            // QLNV
            // 
            this.QLNV.Name = "QLNV";
            this.QLNV.Size = new System.Drawing.Size(248, 26);
            this.QLNV.Text = "Quản lý nhân viên";
            this.QLNV.Click += new System.EventHandler(this.QLNV_Click);
            // 
            // QLKH
            // 
            this.QLKH.Name = "QLKH";
            this.QLKH.Size = new System.Drawing.Size(248, 26);
            this.QLKH.Text = "Quản lý khách hàng";
            this.QLKH.Click += new System.EventHandler(this.QLKH_Click);
            // 
            // TTHD
            // 
            this.TTHD.Name = "TTHD";
            this.TTHD.Size = new System.Drawing.Size(248, 26);
            this.TTHD.Text = "Thanh toán hoá đơn";
            this.TTHD.Click += new System.EventHandler(this.TTHD_Click);
            // 
            // CTHD
            // 
            this.CTHD.Name = "CTHD";
            this.CTHD.Size = new System.Drawing.Size(248, 26);
            this.CTHD.Text = "Chi tiết hoá đơn";
            this.CTHD.Click += new System.EventHandler(this.CTHD_Click);
            // 
            // ThongKe
            // 
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.Size = new System.Drawing.Size(248, 26);
            this.ThongKe.Text = "Thống kê ";
            this.ThongKe.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // lblTen
            // 
            this.lblTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTen.AutoSize = true;
            this.lblTen.BackColor = System.Drawing.Color.Gray;
            this.lblTen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(620, 11);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(157, 19);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Họ và tên đăng nhập";
            // 
            // quảnLýThôngTinHàngHoáToolStripMenuItem
            // 
            this.quảnLýThôngTinHàngHoáToolStripMenuItem.Name = "quảnLýThôngTinHàngHoáToolStripMenuItem";
            this.quảnLýThôngTinHàngHoáToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.quảnLýThôngTinHàngHoáToolStripMenuItem.Text = "Quản lý thông tin hàng hoá";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.quảnLýToolStripMenuItem.Text = "Quản lý thông tin nhân viên, khách hàng";
            // 
            // quảnLýTàiKhoảnToolStripMenuItem
            // 
            this.quảnLýTàiKhoảnToolStripMenuItem.Name = "quảnLýTàiKhoảnToolStripMenuItem";
            this.quảnLýTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.quảnLýTàiKhoảnToolStripMenuItem.Text = "Quản lý tài khoản";
            // 
            // quảnLýHoáĐơnToolStripMenuItem
            // 
            this.quảnLýHoáĐơnToolStripMenuItem.Name = "quảnLýHoáĐơnToolStripMenuItem";
            this.quảnLýHoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.quảnLýHoáĐơnToolStripMenuItem.Text = "Quản lý hoá đơn";
            // 
            // thanhToánHoáĐơnToolStripMenuItem
            // 
            this.thanhToánHoáĐơnToolStripMenuItem.Name = "thanhToánHoáĐơnToolStripMenuItem";
            this.thanhToánHoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.thanhToánHoáĐơnToolStripMenuItem.Text = "Thanh toán hoá đơn";
            // 
            // chiTiếtHoáĐơnToolStripMenuItem
            // 
            this.chiTiếtHoáĐơnToolStripMenuItem.Name = "chiTiếtHoáĐơnToolStripMenuItem";
            this.chiTiếtHoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.chiTiếtHoáĐơnToolStripMenuItem.Text = "Chi tiết hoá đơn";
            // 
            // pic_Quyen
            // 
            this.pic_Quyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Quyen.BackColor = System.Drawing.Color.Gray;
            this.pic_Quyen.Image = global::QuanLyCuaHang.Properties.Resources.QL;
            this.pic_Quyen.Location = new System.Drawing.Point(564, 9);
            this.pic_Quyen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_Quyen.Name = "pic_Quyen";
            this.pic_Quyen.Size = new System.Drawing.Size(52, 27);
            this.pic_Quyen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Quyen.TabIndex = 3;
            this.pic_Quyen.TabStop = false;
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(61, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(853, 474);
            this.Controls.Add(this.pic_Quyen);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMenu";
            this.Text = "Hệ thống quản lý cửa hàng tiện lợi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Quyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DangNhap;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.PictureBox pic_Quyen;
        private System.Windows.Forms.ToolStripMenuItem DanhMuc;
        private System.Windows.Forms.ToolStripMenuItem quảnLýThôngTinHàngHoáToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHoáĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánHoáĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtHoáĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLHH;
        private System.Windows.Forms.ToolStripMenuItem QLNV;
        private System.Windows.Forms.ToolStripMenuItem QLKH;
        private System.Windows.Forms.ToolStripMenuItem TTHD;
        private System.Windows.Forms.ToolStripMenuItem CTHD;
        private System.Windows.Forms.ToolStripMenuItem ThongKe;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
    }
}