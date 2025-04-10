using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class DangNhap : Form
    {
        KetNoiCSDL KetNoi = new KetNoiCSDL();

        private Color originalColor;

        private Point originalLocation;

        private Size originalSizeExit;

        private Font originalFont;

        private bool isRegisterMode = false;

        public DangNhap()
        {
            InitializeComponent();
        }      

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.BringToFront();
            txtUserDK.ForeColor = originalColor;
            label1.Visible = false;
            picLock.BringToFront();
            picLock1.Visible = false;
            txtConfirm.Visible = false;
            picHide1.Visible = false;
            picShow1.Visible = false;
            btnDangNhap.Location = new Point(originalLocation.X = 55, originalLocation.Y = 348);

            btnDangNhap.FlatAppearance.BorderColor = Color.Yellow;

            picHide.Visible = false;
            picShow.Visible = false;

            txtUsername.KeyDown += KeyEnter;
            txtPassword.KeyDown += KeyEnter;

            originalFont = btnDangNhap.Font;
            originalLocation = btnDangNhap.Location;

            this.BeginInvoke(new Action(() =>
            {
                this.ActiveControl = null; // Không đặt focus
            }));
        }

        private bool checkTextLogin(out string errorMessage)
        {
            errorMessage = "Vui lòng nhập thông tin";
            if (txtUsername.Text == "Enter Username ")
                return false;
            if (txtPassword.Text == "Enter Password ")
                return false;
            if (isRegisterMode && txtConfirm.Text != txtPassword.Text)
            {
                errorMessage = "Mật khẩu xác nhận không khớp";
                return false;
            }
            return true;
        }

        private bool checkTextRegister(out string errorMessage)
        {
            errorMessage = "Vui lòng nhập thông tin";
            if (txtUserDK.Text == "Enter Username ")
                return false;
            if (txtPassword.Text == "Enter Password ")
                return false;
            if (isRegisterMode && txtConfirm.Text != txtPassword.Text)
            {
                errorMessage = "Mật khẩu xác nhận không khớp";
                return false;
            }
            return true;
        }

        private void KeyEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }        

        private void picHide_Click(object sender, EventArgs e)
        {
            picHide.Visible = false;
            picShow.Visible = true;
            txtPassword.UseSystemPasswordChar = false;
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            picShow.Visible = false;
            picHide.Visible = true;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void picHide1_Click(object sender, EventArgs e)
        {
            picHide1.Visible = false;
            picShow1.Visible = true;
            txtConfirm.UseSystemPasswordChar = false;
        }

        private void picShow1_Click(object sender, EventArgs e)
        {
            picShow1.Visible = false;
            picHide1.Visible = true;
            txtConfirm.UseSystemPasswordChar = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) ||
                txtPassword.Text == "Enter Password ")
            {
                picHide.Visible = false;
                picShow.Visible = false;
            }
            else
            {
                picHide.Visible = true;
                picShow.Visible = true;
            }    
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirm.Text) ||
                txtConfirm.Text == "Confirm Password ")
            {
                picHide1.Visible = false;
                picShow1.Visible = false;
            }
            else
            {
                picHide1.Visible = true;
                picShow1.Visible = true;
            }
        }

        private void txtUserDK_Enter(object sender, EventArgs e)
        {
            if (txtUserDK.Text == "Enter Username ")
                txtUserDK.Text = string.Empty;
        }

        private void txtUserDK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserDK.Text))
                txtUserDK.Text = "Enter Username ";
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter Username ")
                txtUsername.Text = string.Empty;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                txtUsername.Text = "Enter Username ";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Password ")
            {
                txtPassword.Text = string.Empty;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Enter Password ";
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirm_Enter(object sender, EventArgs e)
        {
            if (txtConfirm.Text == "Confirm Password ")
            {
                txtConfirm.Text = string.Empty;
                txtConfirm.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                txtConfirm.Text = "Confirm Password ";
                txtConfirm.UseSystemPasswordChar = false;
            }
        }

        private void btnDangNhap_MouseEnter(object sender, EventArgs e)
        {
            btnDangNhap.FlatAppearance.BorderSize = 1;
            btnDangNhap.ForeColor = Color.Yellow;
        }

        private void btnDangNhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.ForeColor = Color.White;
        }

        private void Login(string user, string pass)
        {
            string query = "SELECT * FROM TaiKhoan WHERE Username COLLATE SQL_Latin1_General_CP1_CS_AS = @Username AND Pass COLLATE SQL_Latin1_General_CP1_CS_AS = @Pass";
            DataTable dt = KetNoi.GetLogin(query, user, pass);

            if (dt.Rows.Count > 0)
            {
                int MaQuyen = Convert.ToInt32(dt.Rows[0]["MaQuyen"]); // Lấy MaQuyen từ dữ liệu trả về
                string quyen = "";

                if (MaQuyen == 1)
                {
                    quyen = "Quản lý";
                }
                else
                {
                    quyen = "Nhân viên";
                }

                MessageBox.Show(quyen + " đăng nhập thành công", "Thông báo");
                if (quyen == "Nhân viên")
                {
                    Main frm = new Main(false, user);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    Main frm = new Main(true, user);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
            }
        }

        private void Register(string user, string pass)
        {
            try
            {
                int? MaQuyen = null;
                if (user.StartsWith("QL_")) MaQuyen = 1;
                else MaQuyen = 2;

                string TenQuyen = null;
                if (MaQuyen == 1) TenQuyen = "Quản lý";
                else TenQuyen = "Nhân viên";

                string query = "INSERT INTO TaiKhoan VALUES ('" + MaQuyen + "', '" + user + "'," +
                    "'" + pass + "', N'" + TenQuyen + "')";
                int rowsAffected = KetNoi.ExecuteNonQuery(query, new SqlParameter("@Username", user),
                    new SqlParameter("@Pass", pass));

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đăng ký thành công", "Thông báo");
                    linkDangNhap_LinkClicked(null, null);
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string user1 = txtUserDK.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (isRegisterMode)
            {
                if (!checkTextRegister(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Thông báo");
                    return;
                }
                string query = "SELECT * FROM TaiKhoan WHERE Username = '" + user1 + "'";
                DataTable dt = KetNoi.Execute(query);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Đã ký thất bại", "Thông báo");
                }
                else
                {
                    label1.Visible = false;
                    Register(user1, pass);
                } 
            }
            else
            {
                if (!checkTextLogin(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Thông báo");
                    return;
                }
                Login(user, pass);
            }
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.OrangeRed;
            btnExit.Font = new Font(btnExit.Font, FontStyle.Bold);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.Black;
            btnExit.Font = new Font(btnExit.Font, FontStyle.Regular);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUserDK.BringToFront();
            isRegisterMode = true;
            txtUserDK.Text = "Enter Username ";
            txtUsername.Text = "Enter Username ";
            txtPassword.Text = "Enter Password ";
            txtConfirm.Text = "Confirm Password ";
            txtPassword.UseSystemPasswordChar = false;
            txtConfirm.UseSystemPasswordChar = false;
            picUnlock.BringToFront();
            picLock1.Visible = true;
            txtConfirm.Visible = true;
            btnDangNhap.Location = new Point(originalLocation.X = 55, originalLocation.Y = 397);
            btnDangNhap.Text = "Đăng ký";
            
        }

        private void linkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUserDK.SendToBack();
            label1.Visible = false;
            isRegisterMode = false;
            txtUserDK.Text = "Enter Username ";
            txtUsername.Text = "Enter Username ";
            txtPassword.Text = "Enter Password ";
            txtConfirm.Text = "Confirm Password ";
            txtPassword.UseSystemPasswordChar = false;
            txtConfirm.UseSystemPasswordChar = false;
            picUnlock.SendToBack();
            picLock1.Visible = false;
            txtConfirm.Visible = false;
            picHide1.Visible = false;
            picShow1.Visible = false;
            btnDangNhap.Location = new Point(originalLocation.X = 55, originalLocation.Y = 348);
            btnDangNhap.Text = "Đăng nhập";
        }

        private void txtUserDK_TextChanged(object sender, EventArgs e)
        {
            string user = txtUserDK.Text;
            string CheckQuery = "SELECT * FROM TaiKhoan WHERE Username = '" + user + "'";
            DataTable dt = KetNoi.Execute(CheckQuery);
            if (dt.Rows.Count > 0)
            {
                label1.Visible = true;
                txtUserDK.ForeColor = Color.Red;
            }
            else
            {
                label1.Visible = false;
                txtUserDK.ForeColor = originalColor;
            }
        }
    }
}
