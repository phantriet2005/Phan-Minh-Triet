namespace QuanLyCuaHang
{
    partial class frmDangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangKy));
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtTDN = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtMKxn = new System.Windows.Forms.TextBox();
            this.txtDC = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblTDN = new System.Windows.Forms.Label();
            this.lblMKxn = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rdbNV = new System.Windows.Forms.RadioButton();
            this.rdbKH = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHo
            // 
            this.txtHo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHo.ForeColor = System.Drawing.Color.Gray;
            this.txtHo.Location = new System.Drawing.Point(39, 155);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(159, 30);
            this.txtHo.TabIndex = 2;
            this.txtHo.Text = "Họ";
            this.txtHo.Enter += new System.EventHandler(this.txtHo_Enter);
            this.txtHo.Leave += new System.EventHandler(this.txtHo_Leave);
            // 
            // txtMK
            // 
            this.txtMK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.ForeColor = System.Drawing.Color.Gray;
            this.txtMK.Location = new System.Drawing.Point(39, 263);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(375, 30);
            this.txtMK.TabIndex = 5;
            this.txtMK.Text = "Mật khẩu";
            this.txtMK.UseSystemPasswordChar = true;
            this.txtMK.TextChanged += new System.EventHandler(this.txtMK_TextChanged);
            this.txtMK.Enter += new System.EventHandler(this.txtMK_Enter);
            this.txtMK.Leave += new System.EventHandler(this.txtMK_Leave);
            // 
            // txtTDN
            // 
            this.txtTDN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDN.ForeColor = System.Drawing.Color.Gray;
            this.txtTDN.Location = new System.Drawing.Point(39, 208);
            this.txtTDN.Name = "txtTDN";
            this.txtTDN.Size = new System.Drawing.Size(375, 30);
            this.txtTDN.TabIndex = 4;
            this.txtTDN.Text = "Tên đăng nhập";
            this.txtTDN.TextChanged += new System.EventHandler(this.txtTDN_TextChanged);
            this.txtTDN.Enter += new System.EventHandler(this.txtTDN_Enter);
            this.txtTDN.Leave += new System.EventHandler(this.txtTDN_Leave);
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.ForeColor = System.Drawing.Color.Gray;
            this.txtSDT.Location = new System.Drawing.Point(39, 428);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(375, 30);
            this.txtSDT.TabIndex = 8;
            this.txtSDT.Text = "Số điện thoại";
            this.txtSDT.Enter += new System.EventHandler(this.txtSDT_Enter);
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            this.txtSDT.Leave += new System.EventHandler(this.txtSDT_Leave);
            // 
            // txtMKxn
            // 
            this.txtMKxn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKxn.ForeColor = System.Drawing.Color.Gray;
            this.txtMKxn.Location = new System.Drawing.Point(39, 318);
            this.txtMKxn.Name = "txtMKxn";
            this.txtMKxn.Size = new System.Drawing.Size(375, 30);
            this.txtMKxn.TabIndex = 6;
            this.txtMKxn.Text = "Xác nhận lại mật khẩu";
            this.txtMKxn.TextChanged += new System.EventHandler(this.txtMKxn_TextChanged);
            this.txtMKxn.Enter += new System.EventHandler(this.txtMKxn_Enter);
            this.txtMKxn.Leave += new System.EventHandler(this.txtMKxn_Leave);
            // 
            // txtDC
            // 
            this.txtDC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDC.ForeColor = System.Drawing.Color.Gray;
            this.txtDC.Location = new System.Drawing.Point(39, 370);
            this.txtDC.Name = "txtDC";
            this.txtDC.Size = new System.Drawing.Size(375, 30);
            this.txtDC.TabIndex = 7;
            this.txtDC.Text = "Địa chỉ";
            this.txtDC.Enter += new System.EventHandler(this.txtDC_Enter);
            this.txtDC.Leave += new System.EventHandler(this.txtDC_Leave);
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.ForeColor = System.Drawing.Color.Gray;
            this.txtTen.Location = new System.Drawing.Point(255, 155);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(159, 30);
            this.txtTen.TabIndex = 3;
            this.txtTen.Text = "Tên";
            this.txtTen.Enter += new System.EventHandler(this.txtTen_Enter);
            this.txtTen.Leave += new System.EventHandler(this.txtTen_Leave);
            // 
            // lblTDN
            // 
            this.lblTDN.AutoSize = true;
            this.lblTDN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTDN.ForeColor = System.Drawing.Color.Red;
            this.lblTDN.Location = new System.Drawing.Point(262, 241);
            this.lblTDN.Name = "lblTDN";
            this.lblTDN.Size = new System.Drawing.Size(152, 19);
            this.lblTDN.TabIndex = 8;
            this.lblTDN.Text = "Tài khoản đã tồn tại";
            // 
            // lblMKxn
            // 
            this.lblMKxn.AutoSize = true;
            this.lblMKxn.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMKxn.ForeColor = System.Drawing.Color.Red;
            this.lblMKxn.Location = new System.Drawing.Point(251, 351);
            this.lblMKxn.Name = "lblMKxn";
            this.lblMKxn.Size = new System.Drawing.Size(163, 19);
            this.lblMKxn.TabIndex = 8;
            this.lblMKxn.Text = "Mật khẩu không khớp";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyCuaHang.Properties.Resources.add;
            this.pictureBox2.Location = new System.Drawing.Point(165, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(111, 87);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // btnDK
            // 
            this.btnDK.BackColor = System.Drawing.Color.AliceBlue;
            this.btnDK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDK.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDK.Location = new System.Drawing.Point(39, 495);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(375, 47);
            this.btnDK.TabIndex = 1;
            this.btnDK.Text = "Đăng ký";
            this.btnDK.UseVisualStyleBackColor = false;
            this.btnDK.Click += new System.EventHandler(this.btnDK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(102, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // rdbNV
            // 
            this.rdbNV.AutoSize = true;
            this.rdbNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNV.ForeColor = System.Drawing.Color.Black;
            this.rdbNV.Location = new System.Drawing.Point(165, 466);
            this.rdbNV.Name = "rdbNV";
            this.rdbNV.Size = new System.Drawing.Size(97, 23);
            this.rdbNV.TabIndex = 11;
            this.rdbNV.TabStop = true;
            this.rdbNV.Text = "Nhân viên";
            this.rdbNV.UseVisualStyleBackColor = true;
            // 
            // rdbKH
            // 
            this.rdbKH.AutoSize = true;
            this.rdbKH.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKH.ForeColor = System.Drawing.Color.Black;
            this.rdbKH.Location = new System.Drawing.Point(39, 466);
            this.rdbKH.Name = "rdbKH";
            this.rdbKH.Size = new System.Drawing.Size(108, 23);
            this.rdbKH.TabIndex = 11;
            this.rdbKH.TabStop = true;
            this.rdbKH.Text = "Khách hàng";
            this.rdbKH.UseVisualStyleBackColor = true;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(459, 566);
            this.Controls.Add(this.rdbNV);
            this.Controls.Add(this.rdbKH);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblMKxn);
            this.Controls.Add(this.lblTDN);
            this.Controls.Add(this.btnDK);
            this.Controls.Add(this.txtTDN);
            this.Controls.Add(this.txtDC);
            this.Controls.Add(this.txtMKxn);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.label7);
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.Button btnDK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtTDN;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtMKxn;
        private System.Windows.Forms.TextBox txtDC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblTDN;
        private System.Windows.Forms.Label lblMKxn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton rdbNV;
        private System.Windows.Forms.RadioButton rdbKH;
    }
}

