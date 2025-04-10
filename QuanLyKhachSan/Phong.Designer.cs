namespace QuanLyKhachSan
{
    partial class Phong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Phong));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGVPhong = new System.Windows.Forms.DataGridView();
            this.grbNhapTT = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.grbTienIch = new System.Windows.Forms.GroupBox();
            this.ckbHoBoi = new System.Windows.Forms.CheckBox();
            this.ckbTuLanh = new System.Windows.Forms.CheckBox();
            this.rb4Giuong = new System.Windows.Forms.RadioButton();
            this.rb3Giuong = new System.Windows.Forms.RadioButton();
            this.rb2Giuong = new System.Windows.Forms.RadioButton();
            this.rb1Giuong = new System.Windows.Forms.RadioButton();
            this.ckbBonTam = new System.Windows.Forms.CheckBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGia1Ngay = new System.Windows.Forms.TextBox();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLoaiPhong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.picRefesh = new System.Windows.Forms.PictureBox();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLoaiPhong1 = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPhong)).BeginInit();
            this.grbNhapTT.SuspendLayout();
            this.grbTienIch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefesh)).BeginInit();
            this.grbTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.dataGVPhong);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(63, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(884, 255);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phòng";
            // 
            // dataGVPhong
            // 
            this.dataGVPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGVPhong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGVPhong.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGVPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGVPhong.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGVPhong.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGVPhong.Location = new System.Drawing.Point(5, 23);
            this.dataGVPhong.Name = "dataGVPhong";
            this.dataGVPhong.ReadOnly = true;
            this.dataGVPhong.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGVPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGVPhong.Size = new System.Drawing.Size(873, 226);
            this.dataGVPhong.TabIndex = 0;
            this.dataGVPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVPhong_CellClick);
            // 
            // grbNhapTT
            // 
            this.grbNhapTT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grbNhapTT.Controls.Add(this.btnXoa);
            this.grbNhapTT.Controls.Add(this.grbTienIch);
            this.grbNhapTT.Controls.Add(this.btnSua);
            this.grbNhapTT.Controls.Add(this.btnThem);
            this.grbNhapTT.Controls.Add(this.label5);
            this.grbNhapTT.Controls.Add(this.txtGia1Ngay);
            this.grbNhapTT.Controls.Add(this.txtSoPhong);
            this.grbNhapTT.Controls.Add(this.label4);
            this.grbNhapTT.Controls.Add(this.cbLoaiPhong);
            this.grbNhapTT.Controls.Add(this.label3);
            this.grbNhapTT.Controls.Add(this.label2);
            this.grbNhapTT.Controls.Add(this.txtMaLoaiPhong);
            this.grbNhapTT.Controls.Add(this.label1);
            this.grbNhapTT.Controls.Add(this.txtMaPhong);
            this.grbNhapTT.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNhapTT.ForeColor = System.Drawing.Color.White;
            this.grbNhapTT.Location = new System.Drawing.Point(53, 324);
            this.grbNhapTT.Name = "grbNhapTT";
            this.grbNhapTT.Size = new System.Drawing.Size(671, 213);
            this.grbNhapTT.TabIndex = 7;
            this.grbNhapTT.TabStop = false;
            this.grbNhapTT.Text = "Nhập thông tin";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(532, 164);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 31);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // grbTienIch
            // 
            this.grbTienIch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grbTienIch.Controls.Add(this.ckbHoBoi);
            this.grbTienIch.Controls.Add(this.ckbTuLanh);
            this.grbTienIch.Controls.Add(this.rb4Giuong);
            this.grbTienIch.Controls.Add(this.rb3Giuong);
            this.grbTienIch.Controls.Add(this.rb2Giuong);
            this.grbTienIch.Controls.Add(this.rb1Giuong);
            this.grbTienIch.Controls.Add(this.ckbBonTam);
            this.grbTienIch.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTienIch.ForeColor = System.Drawing.Color.White;
            this.grbTienIch.Location = new System.Drawing.Point(272, 15);
            this.grbTienIch.Name = "grbTienIch";
            this.grbTienIch.Size = new System.Drawing.Size(369, 91);
            this.grbTienIch.TabIndex = 9;
            this.grbTienIch.TabStop = false;
            this.grbTienIch.Text = "Tiện ích";
            // 
            // ckbHoBoi
            // 
            this.ckbHoBoi.AutoSize = true;
            this.ckbHoBoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbHoBoi.Location = new System.Drawing.Point(191, 58);
            this.ckbHoBoi.Name = "ckbHoBoi";
            this.ckbHoBoi.Size = new System.Drawing.Size(70, 23);
            this.ckbHoBoi.TabIndex = 9;
            this.ckbHoBoi.Text = "Hồ bơi";
            this.ckbHoBoi.UseVisualStyleBackColor = true;
            // 
            // ckbTuLanh
            // 
            this.ckbTuLanh.AutoSize = true;
            this.ckbTuLanh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTuLanh.Location = new System.Drawing.Point(101, 58);
            this.ckbTuLanh.Name = "ckbTuLanh";
            this.ckbTuLanh.Size = new System.Drawing.Size(72, 23);
            this.ckbTuLanh.TabIndex = 8;
            this.ckbTuLanh.Text = "Tủ lạnh";
            this.ckbTuLanh.UseVisualStyleBackColor = true;
            // 
            // rb4Giuong
            // 
            this.rb4Giuong.AutoSize = true;
            this.rb4Giuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb4Giuong.Location = new System.Drawing.Point(279, 25);
            this.rb4Giuong.Name = "rb4Giuong";
            this.rb4Giuong.Size = new System.Drawing.Size(84, 23);
            this.rb4Giuong.TabIndex = 7;
            this.rb4Giuong.TabStop = true;
            this.rb4Giuong.Text = "4 Giường";
            this.rb4Giuong.UseVisualStyleBackColor = true;
            this.rb4Giuong.CheckedChanged += new System.EventHandler(this.rb4Giuong_CheckedChanged);
            // 
            // rb3Giuong
            // 
            this.rb3Giuong.AutoSize = true;
            this.rb3Giuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3Giuong.Location = new System.Drawing.Point(191, 25);
            this.rb3Giuong.Name = "rb3Giuong";
            this.rb3Giuong.Size = new System.Drawing.Size(84, 23);
            this.rb3Giuong.TabIndex = 6;
            this.rb3Giuong.TabStop = true;
            this.rb3Giuong.Text = "3 Giường";
            this.rb3Giuong.UseVisualStyleBackColor = true;
            this.rb3Giuong.CheckedChanged += new System.EventHandler(this.rb3Giuong_CheckedChanged);
            // 
            // rb2Giuong
            // 
            this.rb2Giuong.AutoSize = true;
            this.rb2Giuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb2Giuong.Location = new System.Drawing.Point(101, 25);
            this.rb2Giuong.Name = "rb2Giuong";
            this.rb2Giuong.Size = new System.Drawing.Size(84, 23);
            this.rb2Giuong.TabIndex = 5;
            this.rb2Giuong.TabStop = true;
            this.rb2Giuong.Text = "2 Giường";
            this.rb2Giuong.UseVisualStyleBackColor = true;
            this.rb2Giuong.CheckedChanged += new System.EventHandler(this.rb2Giuong_CheckedChanged);
            // 
            // rb1Giuong
            // 
            this.rb1Giuong.AutoSize = true;
            this.rb1Giuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1Giuong.Location = new System.Drawing.Point(14, 25);
            this.rb1Giuong.Name = "rb1Giuong";
            this.rb1Giuong.Size = new System.Drawing.Size(84, 23);
            this.rb1Giuong.TabIndex = 4;
            this.rb1Giuong.TabStop = true;
            this.rb1Giuong.Text = "1 Giường";
            this.rb1Giuong.UseVisualStyleBackColor = true;
            this.rb1Giuong.CheckedChanged += new System.EventHandler(this.rb1Giuong_CheckedChanged);
            // 
            // ckbBonTam
            // 
            this.ckbBonTam.AutoSize = true;
            this.ckbBonTam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbBonTam.Location = new System.Drawing.Point(14, 58);
            this.ckbBonTam.Name = "ckbBonTam";
            this.ckbBonTam.Size = new System.Drawing.Size(79, 23);
            this.ckbBonTam.TabIndex = 1;
            this.ckbBonTam.Text = "Bồn tắm";
            this.ckbBonTam.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(419, 164);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 31);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(306, 164);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 31);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(302, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Giá 1 ngày:";
            // 
            // txtGia1Ngay
            // 
            this.txtGia1Ngay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia1Ngay.Location = new System.Drawing.Point(385, 124);
            this.txtGia1Ngay.Name = "txtGia1Ngay";
            this.txtGia1Ngay.Size = new System.Drawing.Size(202, 26);
            this.txtGia1Ngay.TabIndex = 10;
            this.txtGia1Ngay.TextChanged += new System.EventHandler(this.txtGia1Ngay_TextChanged);
            this.txtGia1Ngay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGia1Ngay_KeyPress);
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoPhong.Location = new System.Drawing.Point(117, 169);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(122, 26);
            this.txtSoPhong.TabIndex = 7;
            this.txtSoPhong.TextChanged += new System.EventHandler(this.txtSoPhong_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số phòng:";
            // 
            // cbLoaiPhong
            // 
            this.cbLoaiPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiPhong.FormattingEnabled = true;
            this.cbLoaiPhong.Location = new System.Drawing.Point(117, 123);
            this.cbLoaiPhong.Name = "cbLoaiPhong";
            this.cbLoaiPhong.Size = new System.Drawing.Size(122, 27);
            this.cbLoaiPhong.TabIndex = 5;
            this.cbLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cbLoaiPhong_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại phòng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã loại phòng:";
            // 
            // txtMaLoaiPhong
            // 
            this.txtMaLoaiPhong.Enabled = false;
            this.txtMaLoaiPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoaiPhong.Location = new System.Drawing.Point(117, 80);
            this.txtMaLoaiPhong.Name = "txtMaLoaiPhong";
            this.txtMaLoaiPhong.Size = new System.Drawing.Size(60, 26);
            this.txtMaLoaiPhong.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã phòng:";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Enabled = false;
            this.txtMaPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhong.Location = new System.Drawing.Point(117, 32);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(60, 26);
            this.txtMaPhong.TabIndex = 0;
            // 
            // picRefesh
            // 
            this.picRefesh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picRefesh.Image = ((System.Drawing.Image)(resources.GetObject("picRefesh.Image")));
            this.picRefesh.Location = new System.Drawing.Point(196, 12);
            this.picRefesh.Name = "picRefesh";
            this.picRefesh.Size = new System.Drawing.Size(24, 24);
            this.picRefesh.TabIndex = 15;
            this.picRefesh.TabStop = false;
            this.picRefesh.Click += new System.EventHandler(this.picRefesh_Click);
            this.picRefesh.MouseEnter += new System.EventHandler(this.picRefesh_MouseEnter);
            this.picRefesh.MouseLeave += new System.EventHandler(this.picRefesh_MouseLeave);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.BackColor = System.Drawing.Color.White;
            this.btnDatPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatPhong.ForeColor = System.Drawing.Color.Black;
            this.btnDatPhong.Location = new System.Drawing.Point(127, 164);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(90, 31);
            this.btnDatPhong.TabIndex = 16;
            this.btnDatPhong.Text = "Đặt phòng";
            this.btnDatPhong.UseVisualStyleBackColor = false;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grbTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grbTimKiem.Controls.Add(this.picRefesh);
            this.grbTimKiem.Controls.Add(this.btnTim);
            this.grbTimKiem.Controls.Add(this.btnDatPhong);
            this.grbTimKiem.Controls.Add(this.label6);
            this.grbTimKiem.Controls.Add(this.cbLoaiPhong1);
            this.grbTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTimKiem.ForeColor = System.Drawing.Color.White;
            this.grbTimKiem.Location = new System.Drawing.Point(730, 324);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(223, 212);
            this.grbTimKiem.TabIndex = 8;
            this.grbTimKiem.TabStop = false;
            this.grbTimKiem.Text = "Tìm kiếm";
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.White;
            this.btnTim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.Black;
            this.btnTim.Location = new System.Drawing.Point(10, 164);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 31);
            this.btnTim.TabIndex = 18;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Loại phòng:";
            // 
            // cbLoaiPhong1
            // 
            this.cbLoaiPhong1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiPhong1.FormattingEnabled = true;
            this.cbLoaiPhong1.Location = new System.Drawing.Point(48, 80);
            this.cbLoaiPhong1.Name = "cbLoaiPhong1";
            this.cbLoaiPhong1.Size = new System.Drawing.Size(133, 27);
            this.cbLoaiPhong1.TabIndex = 17;
            // 
            // Phong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1004, 589);
            this.Controls.Add(this.grbTimKiem);
            this.Controls.Add(this.grbNhapTT);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Phong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng";
            this.Load += new System.EventHandler(this.Phong_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPhong)).EndInit();
            this.grbNhapTT.ResumeLayout(false);
            this.grbNhapTT.PerformLayout();
            this.grbTienIch.ResumeLayout(false);
            this.grbTienIch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefesh)).EndInit();
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGVPhong;
        //private System.Windows.Forms.GroupBox grbNhapTT;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLoaiPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaLoaiPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.GroupBox grbTienIch;
        private System.Windows.Forms.CheckBox ckbBonTam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGia1Ngay;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.RadioButton rb4Giuong;
        private System.Windows.Forms.RadioButton rb3Giuong;
        private System.Windows.Forms.RadioButton rb2Giuong;
        private System.Windows.Forms.RadioButton rb1Giuong;
        private System.Windows.Forms.CheckBox ckbTuLanh;
        private System.Windows.Forms.PictureBox picRefesh;
        private System.Windows.Forms.CheckBox ckbHoBoi;
        //private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLoaiPhong1;
        private System.Windows.Forms.Button btnTim;
    }
}