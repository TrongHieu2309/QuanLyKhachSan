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
    public partial class Quyen : Form
    {
        private Color originalColor;
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        public Quyen()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Quyen";
            dataGVQuyen.DataSource = KetNoi.Execute(query);
            DataTable dt = KetNoi.Execute(query);
            if (dt.Rows.Count > 0) dataGVQuyen.Enabled = true;
            else dataGVQuyen.Enabled = false;
        }

        private void Refesh()
        {
            txtMaQuyen.Text = string.Empty;
            txtTenQuyen.Text = string.Empty;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void Quyen_Load(object sender, EventArgs e)
        {
            LoadData();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            picRefesh.BackColor = originalColor;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string TenQuyen = txtTenQuyen.Text;
                string query = "INSERT INTO Quyen VALUES (N'" + TenQuyen + "')";
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

        private void dataGVQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            int index = dataGVQuyen.CurrentRow.Index;
            txtMaQuyen.Text = dataGVQuyen.Rows[index].Cells[0].Value.ToString();
            txtTenQuyen.Text = dataGVQuyen.Rows[index].Cells[1].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaQuyen = int.Parse(txtMaQuyen.Text);
                string TenQuyen = txtTenQuyen.Text;
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "UPDATE Quyen SET TenQuyen = N'" + TenQuyen + "' WHERE MaQuyen = " + MaQuyen;
                    KetNoi.ExecuteNonQuery(query);
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
                int MaQuyen = int.Parse(txtMaQuyen.Text);
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM Quyen WHERE MaQuyen = " + MaQuyen;
                    KetNoi.ExecuteNonQuery(query);
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

        private void txtTenQuyen_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = !string.IsNullOrWhiteSpace(txtTenQuyen.Text);
        }
    }
}
