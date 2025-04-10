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
    public partial class LoaiPhong : Form
    {
        private Color originalColor;
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        public LoaiPhong()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM LoaiPhong";
            dataGVLoaiPhong.DataSource = KetNoi.Execute(query);
            DataTable dt = KetNoi.Execute(query);
            if (dt.Rows.Count > 0) dataGVLoaiPhong.Enabled = true;
            else dataGVLoaiPhong.Enabled = false;
        }

        private void Refesh()
        {
            txtMaLoai.Text = string.Empty;
            txtTenLoaiPhong.Text = string.Empty;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void LoaiPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            picRefesh.BackColor = originalColor;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string TenLoai = txtTenLoaiPhong.Text;

            string qr = "INSERT INTO LoaiPhong VALUES (N'" + TenLoai + "')";
            KetNoi.ExecuteNonQuery(qr);
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
            Refesh();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLoai = int.Parse(txtMaLoai.Text);
                string TenLoai = txtTenLoaiPhong.Text;
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string qr = "UPDATE LoaiPhong SET TenLoaiPhong = N'" + TenLoai + "' WHERE MaLoai = " + MaLoai;
                    KetNoi.ExecuteNonQuery(qr);
                    LoadData();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLoai = int.Parse(txtMaLoai.Text);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string qr = "DELETE FROM LoaiPhong WHERE MaLoai = " + MaLoai;
                    KetNoi.ExecuteNonQuery(qr);
                    LoadData();
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

        private void txtTenLoaiPhong_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = !string.IsNullOrWhiteSpace(txtTenLoaiPhong.Text);
        }

        private void dataGVLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            int index = dataGVLoaiPhong.CurrentRow.Index;
            txtMaLoai.Text = dataGVLoaiPhong.Rows[index].Cells[0].Value.ToString();
            txtTenLoaiPhong.Text = dataGVLoaiPhong.Rows[index].Cells[1].Value.ToString();
        }
    }
}
