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
    public partial class LoaiDV : Form
    {
        private Color originalColor;
        KetNoiCSDL KetNoi = new KetNoiCSDL();

        public LoaiDV()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM LoaiDV";
            dataGVDV.DataSource = KetNoi.Execute(query);
            DataTable dt = KetNoi.Execute(query);
            if (dt.Rows.Count > 0) dataGVDV.Enabled = true;
            else dataGVDV.Enabled = false;
        }

        private void Refesh()
        {
            txtMaLoaiDV.Text = string.Empty;
            txtTenDV.Text = string.Empty;
            txtGiaDV.Text = string.Empty;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void LoaiDV_Load(object sender, EventArgs e)
        {
            LoadData();
            picRefesh.BackColor = originalColor;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            picRefesh.BackColor = originalColor;
        }

        private void BtnThem()
        {
            btnThem.Enabled = !string.IsNullOrWhiteSpace(txtTenDV.Text) && !string.IsNullOrWhiteSpace(txtGiaDV.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string TenDV = txtTenDV.Text;
            string GiaDV = txtGiaDV.Text;

            string qr = "INSERT INTO LoaiDV VALUES (N'" + TenDV + "', '" + GiaDV + "')";
            KetNoi.ExecuteNonQuery(qr);
            LoadData();
            Refesh();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLoaiDV = int.Parse(txtMaLoaiDV.Text);
                string TenDV = txtTenDV.Text;
                string GiaDV = txtGiaDV.Text;
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string qr = "UPDATE LoaiDV SET TenLoaiDV = N'" + TenDV + "', " +
                        "GiaLoaiDV = '" + GiaDV + "' WHERE MaLoaiDV = " + MaLoaiDV;
                    KetNoi.ExecuteNonQuery(qr);
                    LoadData();
                    Refesh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLoaiDV = int.Parse(txtMaLoaiDV.Text);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string qr = "DELETE FROM LoaiPhong WHERE MaLoai = " + MaLoaiDV;
                    KetNoi.ExecuteNonQuery(qr);
                    LoadData();
                    Refesh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGVDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            int index = dataGVDV.CurrentRow.Index;
            txtMaLoaiDV.Text = dataGVDV.Rows[index].Cells[0].Value.ToString();
            txtTenDV.Text = dataGVDV.Rows[index].Cells[1].Value.ToString();
            txtGiaDV.Text = dataGVDV.Rows[index].Cells[2].Value.ToString();
        }

        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void txtGiaDV_TextChanged(object sender, EventArgs e)
        {
            BtnThem();
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
            Refesh();
            LoadData();
        }

        private void picRefesh_MouseEnter(object sender, EventArgs e)
        {
            picRefesh.BackColor = SystemColors.WindowFrame;
        }

        private void picRefesh_MouseLeave(object sender, EventArgs e)
        {
            picRefesh.BackColor = originalColor;
        }

        private void txtGiaDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
