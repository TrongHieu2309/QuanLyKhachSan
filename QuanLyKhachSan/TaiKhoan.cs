using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class TaiKhoan : Form
    {
        private Color originalColor;
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            picRefesh.BackColor = originalColor;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnTim.Enabled = false;
        }

        private void UncheckAllInGrb(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private void Refesh()
        {
            txtMaQuyen.Text = string.Empty;
            txtMaTK.Text = string.Empty;
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtTim.Text = string.Empty;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            UncheckAllInGrb(groupBox3);
        }

        private void LoadData()
        {
            string query = "SELECT * FROM TaiKhoan";
            dataGVTaiKhoan.DataSource = KetNoi.Execute(query);
            DataTable dt = KetNoi.Execute(query);
            if (dt.Rows.Count > 0) dataGVTaiKhoan.Enabled = true;
            else dataGVTaiKhoan.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUser.Text;
                string pass = txtPass.Text;

                int? MaQuyen = null;
                if (user.StartsWith("QL_")) MaQuyen = 1;
                else MaQuyen = 2;

                string TenQuyen = null;
                if (MaQuyen == 1) TenQuyen = "Quản lý";
                else TenQuyen = "Nhân viên";

                string query = "INSERT INTO TaiKhoan VALUES ('" + MaQuyen + "', N'" + user + "'," +
                    "'" + pass + "', N'" + TenQuyen + "')";
                KetNoi.ExecuteNonQuery(query);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Refesh();
            }
        }

        private void dataGVTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            int index = dataGVTaiKhoan.CurrentRow.Index;
            txtMaQuyen.Text = dataGVTaiKhoan.Rows[index].Cells[0].Value.ToString();
            txtMaTK.Text = dataGVTaiKhoan.Rows[index].Cells[1].Value.ToString();
            txtUser.Text = dataGVTaiKhoan.Rows[index].Cells[2].Value.ToString();
            txtPass.Text = dataGVTaiKhoan.Rows[index].Cells[3].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaTK = int.Parse(txtMaTK.Text);
            string query = "DELETE FROM TaiKhoan WHERE MaTK = '" + MaTK + "'";
            KetNoi.ExecuteNonQuery(query);
            LoadData();
            Refesh();
        }

        private void picRefesh_MouseEnter(object sender, EventArgs e)
        {
            picRefesh.BackColor = SystemColors.WindowFrame;
        }

        private void picRefesh_MouseLeave(object sender, EventArgs e)
        {
            picRefesh.BackColor = originalColor;
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
            Refesh();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int MaTK = int.Parse(txtMaTK.Text);
            string user = txtUser.Text;
            string pass = txtPass.Text;

            int? MaQuyen = null;
            if (user.StartsWith("QL_")) MaQuyen = 1;
            else MaQuyen = 2;

            string TenQuyen = null;
            if (MaQuyen == 1) TenQuyen = "Quản lý";
            else TenQuyen = "Nhân viên";

            string query = "UPDATE TaiKhoan SET MaQuyen = '" + MaQuyen + "', Username = N'" + user + "'," +
                "Pass = '" + pass + "', TenQuyen = N'" + TenQuyen + "' WHERE MaTK = '" + MaTK + "'";
            KetNoi.ExecuteNonQuery(query);
            LoadData();
            Refesh();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbMaTK.Checked)
                {
                    string TimKiem = txtTim.Text;
                    int MaTK = int.Parse(TimKiem);
                    string qr = "SELECT * FROM TaiKhoan WHERE MaTK = " + MaTK;
                    DataTable dt = KetNoi.Execute(qr);

                    if (dt.Rows.Count > 0) dataGVTaiKhoan.DataSource = dt;
                    else MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (rbUser.Checked)
                {
                    string TimKiem = txtTim.Text;
                    string qr = "SELECT * FROM TaiKhoan WHERE Username = N'"+TimKiem+"'";
                    DataTable dt = KetNoi.Execute(qr);

                    if (dt.Rows.Count > 0) dataGVTaiKhoan.DataSource = dt;
                    else MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Refesh();
            }
        }

        private void BtnThem()
        {
            btnThem.Enabled = !string.IsNullOrWhiteSpace(txtUser.Text) &&
                !string.IsNullOrWhiteSpace(txtPass.Text);
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            btnTim.Enabled = !string.IsNullOrWhiteSpace(txtTim.Text);
        }
    }
}
