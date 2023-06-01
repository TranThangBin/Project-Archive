namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    partial class FTruyCapCSDL
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bnt_truyCap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_tenServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_tenCSDL = new System.Windows.Forms.TextBox();
            this.rdBtn_baoMat = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idNguoiDung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_matKhau = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(184)))), ((int)(((byte)(19)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(604, 50);
            this.label2.TabIndex = 0;
            this.label2.Text = "Truy cập cơ sở dữ liệu QLDTNCKHSV";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Server:";
            // 
            // bnt_truyCap
            // 
            this.bnt_truyCap.BackColor = System.Drawing.Color.MidnightBlue;
            this.bnt_truyCap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnt_truyCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.bnt_truyCap.ForeColor = System.Drawing.Color.White;
            this.bnt_truyCap.Location = new System.Drawing.Point(0, 382);
            this.bnt_truyCap.Margin = new System.Windows.Forms.Padding(2);
            this.bnt_truyCap.Name = "bnt_truyCap";
            this.bnt_truyCap.Size = new System.Drawing.Size(604, 50);
            this.bnt_truyCap.TabIndex = 2;
            this.bnt_truyCap.Text = "Truy cập";
            this.bnt_truyCap.UseVisualStyleBackColor = false;
            this.bnt_truyCap.Click += new System.EventHandler(this.bnttruyCap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_matKhau);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_idNguoiDung);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rdBtn_baoMat);
            this.panel1.Controls.Add(this.txt_tenCSDL);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_tenServer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.panel1.Location = new System.Drawing.Point(27, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 316);
            this.panel1.TabIndex = 1;
            // 
            // txt_tenServer
            // 
            this.txt_tenServer.Location = new System.Drawing.Point(256, 25);
            this.txt_tenServer.Name = "txt_tenServer";
            this.txt_tenServer.Size = new System.Drawing.Size(258, 26);
            this.txt_tenServer.TabIndex = 0;
            this.txt_tenServer.Text = "LocalHost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(38, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên Cơ sở dữ liệu:";
            // 
            // txt_tenCSDL
            // 
            this.txt_tenCSDL.Enabled = false;
            this.txt_tenCSDL.Location = new System.Drawing.Point(256, 88);
            this.txt_tenCSDL.Name = "txt_tenCSDL";
            this.txt_tenCSDL.Size = new System.Drawing.Size(258, 26);
            this.txt_tenCSDL.TabIndex = 1;
            this.txt_tenCSDL.Text = "QLNCKH_SV";
            // 
            // rdBtn_baoMat
            // 
            this.rdBtn_baoMat.AutoSize = true;
            this.rdBtn_baoMat.Checked = true;
            this.rdBtn_baoMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.rdBtn_baoMat.ForeColor = System.Drawing.Color.Red;
            this.rdBtn_baoMat.Location = new System.Drawing.Point(184, 264);
            this.rdBtn_baoMat.Name = "rdBtn_baoMat";
            this.rdBtn_baoMat.Size = new System.Drawing.Size(181, 29);
            this.rdBtn_baoMat.TabIndex = 4;
            this.rdBtn_baoMat.TabStop = true;
            this.rdBtn_baoMat.Text = "Tích hợp bảo mật";
            this.rdBtn_baoMat.UseVisualStyleBackColor = true;
            this.rdBtn_baoMat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdBtn_baoMat_KeyPress);
            this.rdBtn_baoMat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdBtn_baoMat_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(38, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "ID người dùng(nếu có):";
            // 
            // txt_idNguoiDung
            // 
            this.txt_idNguoiDung.Location = new System.Drawing.Point(256, 153);
            this.txt_idNguoiDung.Name = "txt_idNguoiDung";
            this.txt_idNguoiDung.Size = new System.Drawing.Size(258, 26);
            this.txt_idNguoiDung.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(38, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mật khẩu(nếu có):";
            // 
            // txt_matKhau
            // 
            this.txt_matKhau.Location = new System.Drawing.Point(256, 215);
            this.txt_matKhau.Name = "txt_matKhau";
            this.txt_matKhau.PasswordChar = '*';
            this.txt_matKhau.Size = new System.Drawing.Size(258, 26);
            this.txt_matKhau.TabIndex = 3;
            // 
            // FTruyCapCSDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VLU222_CSLTN02_2274801030_137_118_042_101_073.Properties.Resources.bg_starry;
            this.ClientSize = new System.Drawing.Size(604, 432);
            this.Controls.Add(this.bnt_truyCap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FTruyCapCSDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy cập CSDL quản lý đề tài nghiên cứu khoa học sinh viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTruyCapCSDL_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnt_truyCap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_tenServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_tenCSDL;
        private System.Windows.Forms.RadioButton rdBtn_baoMat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_idNguoiDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_matKhau;
    }
}