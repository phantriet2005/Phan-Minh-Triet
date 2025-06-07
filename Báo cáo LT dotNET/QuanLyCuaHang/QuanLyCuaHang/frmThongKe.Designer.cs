namespace QuanLyCuaHang
{
    partial class frmThongKe
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
            this.cbb_TG1 = new System.Windows.Forms.ComboBox();
            this.txtDoanhthu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_Nam1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDoanhthu2 = new System.Windows.Forms.TextBox();
            this.cbbNam2 = new System.Windows.Forms.ComboBox();
            this.cbbHH = new System.Windows.Forms.ComboBox();
            this.cbbTG2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb_TG1
            // 
            this.cbb_TG1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TG1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TG1.FormattingEnabled = true;
            this.cbb_TG1.Location = new System.Drawing.Point(158, 30);
            this.cbb_TG1.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_TG1.Name = "cbb_TG1";
            this.cbb_TG1.Size = new System.Drawing.Size(117, 30);
            this.cbb_TG1.TabIndex = 0;
            this.cbb_TG1.SelectedIndexChanged += new System.EventHandler(this.cbb_TG1_SelectedIndexChanged);
            // 
            // txtDoanhthu
            // 
            this.txtDoanhthu.Enabled = false;
            this.txtDoanhthu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoanhthu.Location = new System.Drawing.Point(46, 65);
            this.txtDoanhthu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoanhthu.Name = "txtDoanhthu";
            this.txtDoanhthu.Size = new System.Drawing.Size(444, 30);
            this.txtDoanhthu.TabIndex = 1;
            this.txtDoanhthu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDoanhthu);
            this.groupBox1.Controls.Add(this.cbb_Nam1);
            this.groupBox1.Controls.Add(this.cbb_TG1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(46, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(555, 119);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh thu theo tháng, quý";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Năm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thời gian :";
            // 
            // cbb_Nam1
            // 
            this.cbb_Nam1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Nam1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Nam1.FormattingEnabled = true;
            this.cbb_Nam1.Location = new System.Drawing.Point(390, 30);
            this.cbb_Nam1.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_Nam1.Name = "cbb_Nam1";
            this.cbb_Nam1.Size = new System.Drawing.Size(100, 30);
            this.cbb_Nam1.TabIndex = 0;
            this.cbb_Nam1.SelectedIndexChanged += new System.EventHandler(this.cbb_Nam1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDoanhthu2);
            this.groupBox2.Controls.Add(this.cbbNam2);
            this.groupBox2.Controls.Add(this.cbbHH);
            this.groupBox2.Controls.Add(this.cbbTG2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(46, 247);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(555, 143);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doanh thu theo hàng hóa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(308, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Năm :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 22);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hàng hóa :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thời gian :";
            // 
            // txtDoanhthu2
            // 
            this.txtDoanhthu2.Enabled = false;
            this.txtDoanhthu2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoanhthu2.Location = new System.Drawing.Point(46, 100);
            this.txtDoanhthu2.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoanhthu2.Name = "txtDoanhthu2";
            this.txtDoanhthu2.Size = new System.Drawing.Size(444, 30);
            this.txtDoanhthu2.TabIndex = 1;
            this.txtDoanhthu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbbNam2
            // 
            this.cbbNam2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNam2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNam2.FormattingEnabled = true;
            this.cbbNam2.Location = new System.Drawing.Point(390, 65);
            this.cbbNam2.Margin = new System.Windows.Forms.Padding(4);
            this.cbbNam2.Name = "cbbNam2";
            this.cbbNam2.Size = new System.Drawing.Size(100, 30);
            this.cbbNam2.TabIndex = 0;
            this.cbbNam2.SelectedIndexChanged += new System.EventHandler(this.cbbNam2_SelectedIndexChanged);
            // 
            // cbbHH
            // 
            this.cbbHH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHH.FormattingEnabled = true;
            this.cbbHH.Location = new System.Drawing.Point(158, 27);
            this.cbbHH.Margin = new System.Windows.Forms.Padding(4);
            this.cbbHH.Name = "cbbHH";
            this.cbbHH.Size = new System.Drawing.Size(332, 30);
            this.cbbHH.TabIndex = 0;
            this.cbbHH.SelectedIndexChanged += new System.EventHandler(this.cbbHH_SelectedIndexChanged);
            // 
            // cbbTG2
            // 
            this.cbbTG2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTG2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTG2.FormattingEnabled = true;
            this.cbbTG2.Location = new System.Drawing.Point(158, 65);
            this.cbbTG2.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTG2.Name = "cbbTG2";
            this.cbbTG2.Size = new System.Drawing.Size(117, 30);
            this.cbbTG2.TabIndex = 0;
            this.cbbTG2.SelectedIndexChanged += new System.EventHandler(this.cbbTG2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(146, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(369, 35);
            this.label8.TabIndex = 3;
            this.label8.Text = "THỐNG KÊ DOANH THU";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(635, 442);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_TG1;
        private System.Windows.Forms.TextBox txtDoanhthu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_Nam1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDoanhthu2;
        private System.Windows.Forms.ComboBox cbbNam2;
        private System.Windows.Forms.ComboBox cbbHH;
        private System.Windows.Forms.ComboBox cbbTG2;
        private System.Windows.Forms.Label label8;
    }
}