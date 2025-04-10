namespace QuanLyKhachSan
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDSQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDSTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDsLoaiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDSLoaiDV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDSDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDsPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDsDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDsNhanPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDsTraPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDsKH = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.picMem = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMem)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUser,
            this.menuOption,
            this.menuPhong,
            this.menuDatPhong,
            this.menuDsKH,
            this.menuDoanhThu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1242, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuUser
            // 
            this.menuUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuUser.Enabled = false;
            this.menuUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuUser.Image = ((System.Drawing.Image)(resources.GetObject("menuUser.Image")));
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(70, 24);
            this.menuUser.Text = "User";
            // 
            // menuOption
            // 
            this.menuOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain,
            this.menuMembers,
            this.menuQuyen,
            this.menuDsLoaiPhong,
            this.menuDichVu,
            this.menuInvoice,
            this.menuLogout});
            this.menuOption.Image = ((System.Drawing.Image)(resources.GetObject("menuOption.Image")));
            this.menuOption.Name = "menuOption";
            this.menuOption.Size = new System.Drawing.Size(32, 24);
            this.menuOption.MouseEnter += new System.EventHandler(this.menuOption_MouseEnter);
            this.menuOption.MouseLeave += new System.EventHandler(this.menuOption_MouseLeave);
            // 
            // menuMain
            // 
            this.menuMain.Image = ((System.Drawing.Image)(resources.GetObject("menuMain.Image")));
            this.menuMain.Name = "menuMain";
            this.menuMain.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuMain.Size = new System.Drawing.Size(206, 26);
            this.menuMain.Text = "Trang chủ";
            this.menuMain.Click += new System.EventHandler(this.menuMain_Click);
            // 
            // menuMembers
            // 
            this.menuMembers.Image = ((System.Drawing.Image)(resources.GetObject("menuMembers.Image")));
            this.menuMembers.Name = "menuMembers";
            this.menuMembers.ShowShortcutKeys = false;
            this.menuMembers.Size = new System.Drawing.Size(206, 26);
            this.menuMembers.Text = "Danh sách nhóm";
            this.menuMembers.Click += new System.EventHandler(this.menuMembers_Click);
            this.menuMembers.MouseEnter += new System.EventHandler(this.menuMembers_MouseEnter);
            this.menuMembers.MouseLeave += new System.EventHandler(this.menuMembers_MouseLeave);
            // 
            // menuQuyen
            // 
            this.menuQuyen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDSQuyen,
            this.menuDSTaiKhoan});
            this.menuQuyen.Image = ((System.Drawing.Image)(resources.GetObject("menuQuyen.Image")));
            this.menuQuyen.Name = "menuQuyen";
            this.menuQuyen.Size = new System.Drawing.Size(206, 26);
            this.menuQuyen.Text = "Quyền";
            // 
            // menuDSQuyen
            // 
            this.menuDSQuyen.Name = "menuDSQuyen";
            this.menuDSQuyen.Size = new System.Drawing.Size(196, 22);
            this.menuDSQuyen.Text = "Danh sách quyền";
            this.menuDSQuyen.Click += new System.EventHandler(this.menuDSQuyen_Click_1);
            // 
            // menuDSTaiKhoan
            // 
            this.menuDSTaiKhoan.Name = "menuDSTaiKhoan";
            this.menuDSTaiKhoan.Size = new System.Drawing.Size(196, 22);
            this.menuDSTaiKhoan.Text = "Danh sách tài khoản";
            this.menuDSTaiKhoan.Click += new System.EventHandler(this.menuDSTaiKhoan_Click_1);
            // 
            // menuDsLoaiPhong
            // 
            this.menuDsLoaiPhong.Image = ((System.Drawing.Image)(resources.GetObject("menuDsLoaiPhong.Image")));
            this.menuDsLoaiPhong.Name = "menuDsLoaiPhong";
            this.menuDsLoaiPhong.Size = new System.Drawing.Size(206, 26);
            this.menuDsLoaiPhong.Text = "Danh sách loại phòng";
            this.menuDsLoaiPhong.Click += new System.EventHandler(this.menuDsLoaiPhong_Click);
            // 
            // menuDichVu
            // 
            this.menuDichVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDSLoaiDV,
            this.menuDSDichVu});
            this.menuDichVu.Image = ((System.Drawing.Image)(resources.GetObject("menuDichVu.Image")));
            this.menuDichVu.Name = "menuDichVu";
            this.menuDichVu.Size = new System.Drawing.Size(206, 26);
            this.menuDichVu.Text = "Dịch vụ";
            // 
            // menuDSLoaiDV
            // 
            this.menuDSLoaiDV.Name = "menuDSLoaiDV";
            this.menuDSLoaiDV.Size = new System.Drawing.Size(209, 22);
            this.menuDSLoaiDV.Text = "Danh sách loại dịch vụ";
            this.menuDSLoaiDV.Click += new System.EventHandler(this.menuDSLoaiDV_Click);
            // 
            // menuDSDichVu
            // 
            this.menuDSDichVu.Name = "menuDSDichVu";
            this.menuDSDichVu.Size = new System.Drawing.Size(209, 22);
            this.menuDSDichVu.Text = "Danh sách dịch vụ";
            this.menuDSDichVu.Click += new System.EventHandler(this.menuDSDichVu_Click);
            // 
            // menuInvoice
            // 
            this.menuInvoice.Image = ((System.Drawing.Image)(resources.GetObject("menuInvoice.Image")));
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(206, 26);
            this.menuInvoice.Text = "Hóa đơn";
            this.menuInvoice.Click += new System.EventHandler(this.menuInvoice_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Image = ((System.Drawing.Image)(resources.GetObject("menuLogout.Image")));
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(206, 26);
            this.menuLogout.Text = "Đăng xuất";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuPhong
            // 
            this.menuPhong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDsPhong,
            this.menuDsDatPhong,
            this.menuDsNhanPhong,
            this.menuDsTraPhong});
            this.menuPhong.Image = ((System.Drawing.Image)(resources.GetObject("menuPhong.Image")));
            this.menuPhong.Name = "menuPhong";
            this.menuPhong.Size = new System.Drawing.Size(77, 24);
            this.menuPhong.Text = "Phòng";
            // 
            // menuDsPhong
            // 
            this.menuDsPhong.Name = "menuDsPhong";
            this.menuDsPhong.Size = new System.Drawing.Size(229, 22);
            this.menuDsPhong.Text = "Danh sách phòng";
            this.menuDsPhong.Click += new System.EventHandler(this.menuDsPhong_Click_1);
            // 
            // menuDsDatPhong
            // 
            this.menuDsDatPhong.Name = "menuDsDatPhong";
            this.menuDsDatPhong.Size = new System.Drawing.Size(229, 22);
            this.menuDsDatPhong.Text = "Danh sách phòng đã đặt";
            this.menuDsDatPhong.Click += new System.EventHandler(this.menuDsDatPhong_Click_1);
            // 
            // menuDsNhanPhong
            // 
            this.menuDsNhanPhong.Name = "menuDsNhanPhong";
            this.menuDsNhanPhong.Size = new System.Drawing.Size(229, 22);
            this.menuDsNhanPhong.Text = "Danh sách phòng đã nhận";
            this.menuDsNhanPhong.Click += new System.EventHandler(this.menuDsNhanPhong_Click_1);
            // 
            // menuDsTraPhong
            // 
            this.menuDsTraPhong.Name = "menuDsTraPhong";
            this.menuDsTraPhong.Size = new System.Drawing.Size(229, 22);
            this.menuDsTraPhong.Text = "Danh sách phòng đã trả";
            this.menuDsTraPhong.Click += new System.EventHandler(this.menuDsTraPhong_Click_1);
            // 
            // menuDatPhong
            // 
            this.menuDatPhong.Image = ((System.Drawing.Image)(resources.GetObject("menuDatPhong.Image")));
            this.menuDatPhong.Name = "menuDatPhong";
            this.menuDatPhong.Size = new System.Drawing.Size(101, 24);
            this.menuDatPhong.Text = "Đặt phòng";
            this.menuDatPhong.Click += new System.EventHandler(this.menuDatPhong_Click_1);
            // 
            // menuDsKH
            // 
            this.menuDsKH.Image = ((System.Drawing.Image)(resources.GetObject("menuDsKH.Image")));
            this.menuDsKH.Name = "menuDsKH";
            this.menuDsKH.Size = new System.Drawing.Size(174, 24);
            this.menuDsKH.Text = "Danh sách khách hàng";
            this.menuDsKH.Click += new System.EventHandler(this.menuDsKH_Click);
            // 
            // menuDoanhThu
            // 
            this.menuDoanhThu.Image = ((System.Drawing.Image)(resources.GetObject("menuDoanhThu.Image")));
            this.menuDoanhThu.Name = "menuDoanhThu";
            this.menuDoanhThu.Size = new System.Drawing.Size(101, 24);
            this.menuDoanhThu.Text = "Doanh thu";
            this.menuDoanhThu.Click += new System.EventHandler(this.menuDoanhThu_Click);
            // 
            // picMem
            // 
            this.picMem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMem.BackgroundImage")));
            this.picMem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMem.Location = new System.Drawing.Point(0, 0);
            this.picMem.Name = "picMem";
            this.picMem.Size = new System.Drawing.Size(1242, 700);
            this.picMem.TabIndex = 3;
            this.picMem.TabStop = false;
            this.picMem.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1242, 700);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picMem);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuOption;
        private System.Windows.Forms.ToolStripMenuItem menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuMembers;
        private System.Windows.Forms.ToolStripMenuItem menuDsLoaiPhong;
        private System.Windows.Forms.ToolStripMenuItem menuQuyen;
        private System.Windows.Forms.ToolStripMenuItem menuDSQuyen;
        private System.Windows.Forms.ToolStripMenuItem menuDSTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuUser;
        private System.Windows.Forms.ToolStripMenuItem menuDichVu;
        private System.Windows.Forms.ToolStripMenuItem menuDSLoaiDV;
        private System.Windows.Forms.ToolStripMenuItem menuDSDichVu;
        private System.Windows.Forms.ToolStripMenuItem menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem menuPhong;
        private System.Windows.Forms.ToolStripMenuItem menuDsPhong;
        private System.Windows.Forms.ToolStripMenuItem menuDsDatPhong;
        private System.Windows.Forms.ToolStripMenuItem menuDsNhanPhong;
        private System.Windows.Forms.ToolStripMenuItem menuDsTraPhong;
        private System.Windows.Forms.ToolStripMenuItem menuDatPhong;
        private System.Windows.Forms.ToolStripMenuItem menuDsKH;
        private System.Windows.Forms.ToolStripMenuItem menuDoanhThu;
        private System.Windows.Forms.PictureBox picMem;
    }
}