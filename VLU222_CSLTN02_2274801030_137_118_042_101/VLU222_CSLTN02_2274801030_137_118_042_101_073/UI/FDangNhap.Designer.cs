namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    partial class FDangNhap
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
            this.txt_maGiangVien = new System.Windows.Forms.TextBox();
            this.bnt_dangNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(126, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(369, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "Truy cập cơ sở dữ liệu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chuỗi kết nối :";
            // 
            // txt_maGiangVien
            // 
            this.txt_maGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_maGiangVien.Location = new System.Drawing.Point(203, 52);
            this.txt_maGiangVien.MaxLength = 10;
            this.txt_maGiangVien.Name = "txt_maGiangVien";
            this.txt_maGiangVien.Size = new System.Drawing.Size(329, 35);
            this.txt_maGiangVien.TabIndex = 1;
            // 
            // bnt_dangNhap
            // 
            this.bnt_dangNhap.BackColor = System.Drawing.Color.MidnightBlue;
            this.bnt_dangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.bnt_dangNhap.ForeColor = System.Drawing.Color.White;
            this.bnt_dangNhap.Location = new System.Drawing.Point(242, 126);
            this.bnt_dangNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bnt_dangNhap.Name = "bnt_dangNhap";
            this.bnt_dangNhap.Size = new System.Drawing.Size(168, 44);
            this.bnt_dangNhap.TabIndex = 2;
            this.bnt_dangNhap.Text = "Đăng Nhập";
            this.bnt_dangNhap.UseVisualStyleBackColor = false;
            this.bnt_dangNhap.Click += new System.EventHandler(this.bnt_dangNhap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bnt_dangNhap);
            this.panel1.Controls.Add(this.txt_maGiangVien);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(30, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 217);
            this.panel1.TabIndex = 5;
            // 
            // FDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VLU222_CSLTN02_2274801030_137_118_042_101_073.Properties.Resources.bg_starry;
            this.ClientSize = new System.Drawing.Size(604, 299);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FDangNhap";
            this.Text = "FDangNhap";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_maGiangVien;
        private System.Windows.Forms.Button bnt_dangNhap;
        private System.Windows.Forms.Panel panel1;
    }
}