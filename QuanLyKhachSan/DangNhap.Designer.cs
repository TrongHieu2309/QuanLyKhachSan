using System;

namespace QuanLyKhachSan
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.picHide = new System.Windows.Forms.PictureBox();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.picUnlock = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.linkDangKy = new System.Windows.Forms.LinkLabel();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.picLock1 = new System.Windows.Forms.PictureBox();
            this.linkDangNhap = new System.Windows.Forms.LinkLabel();
            this.picHide1 = new System.Windows.Forms.PictureBox();
            this.picShow1 = new System.Windows.Forms.PictureBox();
            this.picLock = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserDK = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(92, 300);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(227, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Enter Password ";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUsername
            // 
            this.txtUsername.AccessibleName = "";
            this.txtUsername.BackColor = System.Drawing.SystemColors.Info;
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(93, 250);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(227, 26);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Enter Username ";
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // picHide
            // 
            this.picHide.BackColor = System.Drawing.SystemColors.Info;
            this.picHide.Image = ((System.Drawing.Image)(resources.GetObject("picHide.Image")));
            this.picHide.Location = new System.Drawing.Point(287, 303);
            this.picHide.Name = "picHide";
            this.picHide.Size = new System.Drawing.Size(30, 19);
            this.picHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHide.TabIndex = 22;
            this.picHide.TabStop = false;
            this.picHide.Click += new System.EventHandler(this.picHide_Click);
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.SystemColors.Info;
            this.picShow.Image = ((System.Drawing.Image)(resources.GetObject("picShow.Image")));
            this.picShow.Location = new System.Drawing.Point(287, 303);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(30, 19);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picShow.TabIndex = 23;
            this.picShow.TabStop = false;
            this.picShow.Click += new System.EventHandler(this.picShow_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(45, 240);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // picUnlock
            // 
            this.picUnlock.BackColor = System.Drawing.Color.White;
            this.picUnlock.Image = ((System.Drawing.Image)(resources.GetObject("picUnlock.Image")));
            this.picUnlock.Location = new System.Drawing.Point(45, 291);
            this.picUnlock.Name = "picUnlock";
            this.picUnlock.Size = new System.Drawing.Size(42, 40);
            this.picUnlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picUnlock.TabIndex = 25;
            this.picUnlock.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(124, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDangNhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.BackgroundImage")));
            this.btnDangNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(55, 397);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(265, 43);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            this.btnDangNhap.MouseEnter += new System.EventHandler(this.btnDangNhap_MouseEnter);
            this.btnDangNhap.MouseLeave += new System.EventHandler(this.btnDangNhap_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(32, 93);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 24);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "X";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // linkDangKy
            // 
            this.linkDangKy.AutoSize = true;
            this.linkDangKy.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDangKy.LinkColor = System.Drawing.Color.Blue;
            this.linkDangKy.Location = new System.Drawing.Point(214, 459);
            this.linkDangKy.Name = "linkDangKy";
            this.linkDangKy.Size = new System.Drawing.Size(106, 18);
            this.linkDangKy.TabIndex = 6;
            this.linkDangKy.TabStop = true;
            this.linkDangKy.Text = "Đăng ký tài khoản";
            this.linkDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangKy_LinkClicked);
            // 
            // txtConfirm
            // 
            this.txtConfirm.BackColor = System.Drawing.SystemColors.Info;
            this.txtConfirm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.Location = new System.Drawing.Point(92, 348);
            this.txtConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(227, 26);
            this.txtConfirm.TabIndex = 3;
            this.txtConfirm.Text = "Confirm Password ";
            this.txtConfirm.TextChanged += new System.EventHandler(this.txtConfirm_TextChanged);
            this.txtConfirm.Enter += new System.EventHandler(this.txtConfirm_Enter);
            this.txtConfirm.Leave += new System.EventHandler(this.txtConfirm_Leave);
            // 
            // picLock1
            // 
            this.picLock1.BackColor = System.Drawing.Color.White;
            this.picLock1.Image = ((System.Drawing.Image)(resources.GetObject("picLock1.Image")));
            this.picLock1.Location = new System.Drawing.Point(45, 338);
            this.picLock1.Name = "picLock1";
            this.picLock1.Size = new System.Drawing.Size(42, 40);
            this.picLock1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLock1.TabIndex = 31;
            this.picLock1.TabStop = false;
            // 
            // linkDangNhap
            // 
            this.linkDangNhap.AutoSize = true;
            this.linkDangNhap.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDangNhap.LinkColor = System.Drawing.Color.Blue;
            this.linkDangNhap.Location = new System.Drawing.Point(52, 459);
            this.linkDangNhap.Name = "linkDangNhap";
            this.linkDangNhap.Size = new System.Drawing.Size(122, 18);
            this.linkDangNhap.TabIndex = 5;
            this.linkDangNhap.TabStop = true;
            this.linkDangNhap.Text = "Đăng nhập tài khoản";
            this.linkDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangNhap_LinkClicked);
            // 
            // picHide1
            // 
            this.picHide1.BackColor = System.Drawing.SystemColors.Info;
            this.picHide1.Image = ((System.Drawing.Image)(resources.GetObject("picHide1.Image")));
            this.picHide1.Location = new System.Drawing.Point(287, 352);
            this.picHide1.Name = "picHide1";
            this.picHide1.Size = new System.Drawing.Size(30, 19);
            this.picHide1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHide1.TabIndex = 33;
            this.picHide1.TabStop = false;
            this.picHide1.Click += new System.EventHandler(this.picHide1_Click);
            // 
            // picShow1
            // 
            this.picShow1.BackColor = System.Drawing.SystemColors.Info;
            this.picShow1.Image = ((System.Drawing.Image)(resources.GetObject("picShow1.Image")));
            this.picShow1.Location = new System.Drawing.Point(287, 352);
            this.picShow1.Name = "picShow1";
            this.picShow1.Size = new System.Drawing.Size(30, 19);
            this.picShow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picShow1.TabIndex = 34;
            this.picShow1.TabStop = false;
            this.picShow1.Click += new System.EventHandler(this.picShow1_Click);
            // 
            // picLock
            // 
            this.picLock.BackColor = System.Drawing.Color.White;
            this.picLock.Image = ((System.Drawing.Image)(resources.GetObject("picLock.Image")));
            this.picLock.Location = new System.Drawing.Point(45, 291);
            this.picLock.Name = "picLock";
            this.picLock.Size = new System.Drawing.Size(42, 40);
            this.picLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLock.TabIndex = 35;
            this.picLock.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(93, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tên tài khoản đã tồn tại";
            // 
            // txtUserDK
            // 
            this.txtUserDK.AccessibleName = "";
            this.txtUserDK.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserDK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserDK.Location = new System.Drawing.Point(92, 250);
            this.txtUserDK.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserDK.Name = "txtUserDK";
            this.txtUserDK.Size = new System.Drawing.Size(227, 26);
            this.txtUserDK.TabIndex = 37;
            this.txtUserDK.Text = "Enter Username ";
            this.txtUserDK.TextChanged += new System.EventHandler(this.txtUserDK_TextChanged);
            this.txtUserDK.Enter += new System.EventHandler(this.txtUserDK_Enter);
            this.txtUserDK.Leave += new System.EventHandler(this.txtUserDK_Leave);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(918, 546);
            this.Controls.Add(this.txtUserDK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picHide1);
            this.Controls.Add(this.linkDangNhap);
            this.Controls.Add(this.picLock1);
            this.Controls.Add(this.linkDangKy);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.picHide);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.picShow);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.picShow1);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.picUnlock);
            this.Controls.Add(this.picLock);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox picHide;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox picUnlock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel linkDangKy;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.PictureBox picLock1;
        private System.Windows.Forms.LinkLabel linkDangNhap;
        private System.Windows.Forms.PictureBox picHide1;
        private System.Windows.Forms.PictureBox picShow1;
        private System.Windows.Forms.PictureBox picLock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserDK;
    }
}

