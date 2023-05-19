namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    partial class FGiangVien
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmB_gioiTinh = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lsB_danhSachGiangVien = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_troVeGV = new System.Windows.Forms.Button();
            this.btn_suaGV = new System.Windows.Forms.Button();
            this.btn_xoaGV = new System.Windows.Forms.Button();
            this.btn_themGV = new System.Windows.Forms.Button();
            this.txt_maKhoa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_trinhDo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_tenGiangVien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_hoLot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_maGiangVien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtP_ngayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtP_ngayBatDau = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lsV_giangVienGuongdanVeDT = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_truyCapDT = new System.Windows.Forms.Button();
            this.btn_xoaDT = new System.Windows.Forms.Button();
            this.btn_suaDT = new System.Windows.Forms.Button();
            this.btn_themDT = new System.Windows.Forms.Button();
            this.txt_maSinhVien = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_maGiangVienDT = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_kinhPhi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_tenDeTai = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_maDetai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmB_gioiTinh);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txt_maKhoa);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_trinhDo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_tenGiangVien);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_hoLot);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_maGiangVien);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(23, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 1069);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giảng viên";
            // 
            // cmB_gioiTinh
            // 
            this.cmB_gioiTinh.FormattingEnabled = true;
            this.cmB_gioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ ",
            "khác"});
            this.cmB_gioiTinh.Location = new System.Drawing.Point(212, 286);
            this.cmB_gioiTinh.Name = "cmB_gioiTinh";
            this.cmB_gioiTinh.Size = new System.Drawing.Size(357, 37);
            this.cmB_gioiTinh.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lsB_danhSachGiangVien);
            this.groupBox5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox5.Location = new System.Drawing.Point(15, 518);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(564, 510);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Danh sách giảng viên";
            // 
            // lsB_danhSachGiangVien
            // 
            this.lsB_danhSachGiangVien.FormattingEnabled = true;
            this.lsB_danhSachGiangVien.ItemHeight = 29;
            this.lsB_danhSachGiangVien.Location = new System.Drawing.Point(24, 33);
            this.lsB_danhSachGiangVien.Name = "lsB_danhSachGiangVien";
            this.lsB_danhSachGiangVien.Size = new System.Drawing.Size(526, 468);
            this.lsB_danhSachGiangVien.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_troVeGV);
            this.groupBox3.Controls.Add(this.btn_suaGV);
            this.groupBox3.Controls.Add(this.btn_xoaGV);
            this.groupBox3.Controls.Add(this.btn_themGV);
            this.groupBox3.Location = new System.Drawing.Point(31, 409);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(549, 85);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btn_troVeGV
            // 
            this.btn_troVeGV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_troVeGV.ForeColor = System.Drawing.Color.White;
            this.btn_troVeGV.Location = new System.Drawing.Point(417, 34);
            this.btn_troVeGV.Name = "btn_troVeGV";
            this.btn_troVeGV.Size = new System.Drawing.Size(104, 45);
            this.btn_troVeGV.TabIndex = 0;
            this.btn_troVeGV.Text = "Trở về";
            this.btn_troVeGV.UseVisualStyleBackColor = false;
            this.btn_troVeGV.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_suaGV
            // 
            this.btn_suaGV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_suaGV.ForeColor = System.Drawing.Color.White;
            this.btn_suaGV.Location = new System.Drawing.Point(281, 34);
            this.btn_suaGV.Name = "btn_suaGV";
            this.btn_suaGV.Size = new System.Drawing.Size(104, 45);
            this.btn_suaGV.TabIndex = 0;
            this.btn_suaGV.Text = "Sửa";
            this.btn_suaGV.UseVisualStyleBackColor = false;
            this.btn_suaGV.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_xoaGV
            // 
            this.btn_xoaGV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_xoaGV.ForeColor = System.Drawing.Color.White;
            this.btn_xoaGV.Location = new System.Drawing.Point(149, 34);
            this.btn_xoaGV.Name = "btn_xoaGV";
            this.btn_xoaGV.Size = new System.Drawing.Size(104, 45);
            this.btn_xoaGV.TabIndex = 0;
            this.btn_xoaGV.Text = "Xóa";
            this.btn_xoaGV.UseVisualStyleBackColor = false;
            this.btn_xoaGV.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_themGV
            // 
            this.btn_themGV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_themGV.ForeColor = System.Drawing.Color.White;
            this.btn_themGV.Location = new System.Drawing.Point(22, 34);
            this.btn_themGV.Name = "btn_themGV";
            this.btn_themGV.Size = new System.Drawing.Size(104, 45);
            this.btn_themGV.TabIndex = 0;
            this.btn_themGV.Text = "Thêm";
            this.btn_themGV.UseVisualStyleBackColor = false;
            this.btn_themGV.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_maKhoa
            // 
            this.txt_maKhoa.Location = new System.Drawing.Point(212, 339);
            this.txt_maKhoa.Name = "txt_maKhoa";
            this.txt_maKhoa.Size = new System.Drawing.Size(357, 35);
            this.txt_maKhoa.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(68, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã khoa :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(71, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Giới tính :";
            // 
            // txt_trinhDo
            // 
            this.txt_trinhDo.Location = new System.Drawing.Point(212, 223);
            this.txt_trinhDo.Name = "txt_trinhDo";
            this.txt_trinhDo.Size = new System.Drawing.Size(357, 35);
            this.txt_trinhDo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(69, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Trình độ :";
            // 
            // txt_tenGiangVien
            // 
            this.txt_tenGiangVien.Location = new System.Drawing.Point(212, 167);
            this.txt_tenGiangVien.Name = "txt_tenGiangVien";
            this.txt_tenGiangVien.Size = new System.Drawing.Size(357, 35);
            this.txt_tenGiangVien.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(0, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên giảng viên :";
            // 
            // txt_hoLot
            // 
            this.txt_hoLot.Location = new System.Drawing.Point(212, 113);
            this.txt_hoLot.Name = "txt_hoLot";
            this.txt_hoLot.Size = new System.Drawing.Size(357, 35);
            this.txt_hoLot.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(96, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ lót :";
            // 
            // txt_maGiangVien
            // 
            this.txt_maGiangVien.Location = new System.Drawing.Point(212, 65);
            this.txt_maGiangVien.Name = "txt_maGiangVien";
            this.txt_maGiangVien.Size = new System.Drawing.Size(357, 35);
            this.txt_maGiangVien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã giảng viên :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.dtP_ngayKetThuc);
            this.groupBox2.Controls.Add(this.dtP_ngayBatDau);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txt_maSinhVien);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txt_maGiangVienDT);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_kinhPhi);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_tenDeTai);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_maDetai);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(670, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 1034);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đề tài";
            // 
            // dtP_ngayKetThuc
            // 
            this.dtP_ngayKetThuc.Location = new System.Drawing.Point(234, 277);
            this.dtP_ngayKetThuc.Name = "dtP_ngayKetThuc";
            this.dtP_ngayKetThuc.Size = new System.Drawing.Size(356, 35);
            this.dtP_ngayKetThuc.TabIndex = 4;
            // 
            // dtP_ngayBatDau
            // 
            this.dtP_ngayBatDau.Location = new System.Drawing.Point(234, 224);
            this.dtP_ngayBatDau.Name = "dtP_ngayBatDau";
            this.dtP_ngayBatDau.Size = new System.Drawing.Size(356, 35);
            this.dtP_ngayBatDau.TabIndex = 4;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lsV_giangVienGuongdanVeDT);
            this.groupBox6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox6.Location = new System.Drawing.Point(19, 561);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(578, 462);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Giảng Viên Hướng dẫn về đề tài";
            // 
            // lsV_giangVienGuongdanVeDT
            // 
            this.lsV_giangVienGuongdanVeDT.HideSelection = false;
            this.lsV_giangVienGuongdanVeDT.Location = new System.Drawing.Point(21, 37);
            this.lsV_giangVienGuongdanVeDT.Name = "lsV_giangVienGuongdanVeDT";
            this.lsV_giangVienGuongdanVeDT.Size = new System.Drawing.Size(534, 415);
            this.lsV_giangVienGuongdanVeDT.TabIndex = 0;
            this.lsV_giangVienGuongdanVeDT.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_truyCapDT);
            this.groupBox4.Controls.Add(this.btn_xoaDT);
            this.groupBox4.Controls.Add(this.btn_suaDT);
            this.groupBox4.Controls.Add(this.btn_themDT);
            this.groupBox4.Location = new System.Drawing.Point(30, 459);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(561, 87);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btn_truyCapDT
            // 
            this.btn_truyCapDT.ForeColor = System.Drawing.Color.Black;
            this.btn_truyCapDT.Location = new System.Drawing.Point(430, 34);
            this.btn_truyCapDT.Name = "btn_truyCapDT";
            this.btn_truyCapDT.Size = new System.Drawing.Size(114, 39);
            this.btn_truyCapDT.TabIndex = 0;
            this.btn_truyCapDT.Text = "Truy cập";
            this.btn_truyCapDT.UseVisualStyleBackColor = true;
            // 
            // btn_xoaDT
            // 
            this.btn_xoaDT.ForeColor = System.Drawing.Color.Black;
            this.btn_xoaDT.Location = new System.Drawing.Point(300, 34);
            this.btn_xoaDT.Name = "btn_xoaDT";
            this.btn_xoaDT.Size = new System.Drawing.Size(98, 39);
            this.btn_xoaDT.TabIndex = 0;
            this.btn_xoaDT.Text = "Xóa";
            this.btn_xoaDT.UseVisualStyleBackColor = true;
            // 
            // btn_suaDT
            // 
            this.btn_suaDT.ForeColor = System.Drawing.Color.Black;
            this.btn_suaDT.Location = new System.Drawing.Point(161, 34);
            this.btn_suaDT.Name = "btn_suaDT";
            this.btn_suaDT.Size = new System.Drawing.Size(104, 39);
            this.btn_suaDT.TabIndex = 0;
            this.btn_suaDT.Text = "Sửa";
            this.btn_suaDT.UseVisualStyleBackColor = true;
            // 
            // btn_themDT
            // 
            this.btn_themDT.ForeColor = System.Drawing.Color.Black;
            this.btn_themDT.Location = new System.Drawing.Point(26, 34);
            this.btn_themDT.Name = "btn_themDT";
            this.btn_themDT.Size = new System.Drawing.Size(107, 39);
            this.btn_themDT.TabIndex = 0;
            this.btn_themDT.Text = "Thêm";
            this.btn_themDT.UseVisualStyleBackColor = true;
            // 
            // txt_maSinhVien
            // 
            this.txt_maSinhVien.Location = new System.Drawing.Point(234, 384);
            this.txt_maSinhVien.Name = "txt_maSinhVien";
            this.txt_maSinhVien.Size = new System.Drawing.Size(357, 35);
            this.txt_maSinhVien.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(35, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 29);
            this.label13.TabIndex = 0;
            this.label13.Text = "Mã sinh viên :";
            // 
            // txt_maGiangVienDT
            // 
            this.txt_maGiangVienDT.Location = new System.Drawing.Point(234, 331);
            this.txt_maGiangVienDT.Name = "txt_maGiangVienDT";
            this.txt_maGiangVienDT.Size = new System.Drawing.Size(357, 35);
            this.txt_maGiangVienDT.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(18, 337);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mã Giảng viên :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(29, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Ngày kết thúc :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(32, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 29);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngày bắt đầu :";
            // 
            // txt_kinhPhi
            // 
            this.txt_kinhPhi.Location = new System.Drawing.Point(233, 168);
            this.txt_kinhPhi.Name = "txt_kinhPhi";
            this.txt_kinhPhi.Size = new System.Drawing.Size(357, 35);
            this.txt_kinhPhi.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(84, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "Kinh phí :";
            // 
            // txt_tenDeTai
            // 
            this.txt_tenDeTai.Location = new System.Drawing.Point(234, 111);
            this.txt_tenDeTai.Name = "txt_tenDeTai";
            this.txt_tenDeTai.Size = new System.Drawing.Size(357, 35);
            this.txt_tenDeTai.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(65, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tên đề tài :";
            // 
            // txt_maDetai
            // 
            this.txt_maDetai.Location = new System.Drawing.Point(234, 60);
            this.txt_maDetai.Name = "txt_maDetai";
            this.txt_maDetai.Size = new System.Drawing.Size(357, 35);
            this.txt_maDetai.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(69, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã đề tài  :";
            // 
            // FGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 1046);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FGiangVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giảng viên hướng dẫn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmB_gioiTinh;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lsB_danhSachGiangVien;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_themGV;
        private System.Windows.Forms.TextBox txt_maKhoa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_trinhDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tenGiangVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_hoLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_maGiangVien;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lsV_giangVienGuongdanVeDT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_themDT;
        private System.Windows.Forms.TextBox txt_maSinhVien;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_maGiangVienDT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_kinhPhi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_tenDeTai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_maDetai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_troVeGV;
        private System.Windows.Forms.Button btn_suaGV;
        private System.Windows.Forms.Button btn_xoaGV;
        private System.Windows.Forms.DateTimePicker dtP_ngayKetThuc;
        private System.Windows.Forms.DateTimePicker dtP_ngayBatDau;
        private System.Windows.Forms.Button btn_truyCapDT;
        private System.Windows.Forms.Button btn_xoaDT;
        private System.Windows.Forms.Button btn_suaDT;
    }
}