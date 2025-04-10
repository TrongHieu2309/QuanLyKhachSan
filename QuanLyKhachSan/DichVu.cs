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
    public partial class DichVu : Form
    {
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        private Color originalColor;

        private Size originalSize;
        private Point originalLocation;
        private Image originalImage;

        public DichVu()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string qr = "SELECT * FROM DichVu";
            dataGVDV.DataSource = KetNoi.Execute(qr);
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0) dataGVDV.Enabled = true;
            else dataGVDV.Enabled = false;
        }

        private void Refesh()
        {
            txtMaDV.Text = string.Empty;
            txtMaLoaiDV.Text = string.Empty;
            cbTenDV.Text = string.Empty;
            txtGiaDV.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtSdt.Text = string.Empty;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadcbTenDV();
            picRefesh.BackColor = originalColor;

            originalSize = picRefesh.Size;
            originalLocation = picRefesh.Location;
            originalImage = picRefesh.Image;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void BtnThem()
        {
            btnThem.Enabled = !string.IsNullOrWhiteSpace(cbTenDV.Text) &&
                !string.IsNullOrWhiteSpace(txtSdt.Text);
        }

        private void LoadcbTenDV()
        {
            cbTenDV.Items.Clear();
            string qr = "SELECT TenLoaiDV, GiaLoaiDV FROM LoaiDV";
            DataTable dt = KetNoi.Execute(qr);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbTenDV.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }

        private void cbTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TenDV = cbTenDV.Text;
            string qr = "SELECT GiaLoaiDV FROM LoaiDV WHERE TenLoaiDV = N'" + TenDV + "'";
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0)
            {
                int GiaDV = Convert.ToInt32(dt.Rows[0]["GiaLoaiDV"]);
                txtGiaDV.Text = GiaDV.ToString();
                BtnThem();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string TenDV = cbTenDV.Text;
                string GiaDV = txtGiaDV.Text;
                string qrMaDV = "SELECT MaLoaiDV FROM LoaiDV WHERE TenLoaiDV = N'" + TenDV + "'";
                DataTable dtDV = KetNoi.Execute(qrMaDV);

                // Kiểm tra thông tin KH có tồn tại ko?
                string Sdt = txtSdt.Text;
                string qrSdt = "SELECT * FROM KhachHang WHERE Sdt = '" + Sdt + "'";
                DataTable dt = KetNoi.Execute(qrSdt);
                if (dt.Rows.Count > 0)
                {
                    int MaKH = Convert.ToInt32(dt.Rows[0]["MaKH"]);
                    txtMaKH.Text = MaKH.ToString();

                    if (dtDV.Rows.Count > 0)
                    {
                        int MaLoaiDV = Convert.ToInt32(dtDV.Rows[0][0]);
                        string qr = "INSERT INTO DichVu VALUES ('" + MaLoaiDV + "', N'" + TenDV + "', '" + GiaDV + "', '" + MaKH + "')";
                        dataGVDV.DataSource = KetNoi.Execute(qr);
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin khách hàng chưa tồn tại", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Thêm dịch vụ thành công", "Thông báo");
                LoadData();
                Refesh();
            }
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
            Refesh();
        }

        private void dataGVDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;

            int index = dataGVDV.CurrentRow.Index;
            txtMaDV.Text = dataGVDV.Rows[index].Cells[0].Value.ToString();            
            txtMaLoaiDV.Text = dataGVDV.Rows[index].Cells[1].Value.ToString();
            cbTenDV.Text = dataGVDV.Rows[index].Cells[2].Value.ToString();
            txtGiaDV.Text = dataGVDV.Rows[index].Cells[3].Value.ToString();
            txtMaKH.Text = dataGVDV.Rows[index].Cells[4].Value.ToString();

            string qr = "SELECT Sdt FROM KhachHang WHERE MaKH = '" + txtMaKH.Text + "'";
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0)
            {
                txtSdt.Text = dt.Rows[0]["Sdt"].ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaDV = int.Parse(txtMaDV.Text);
                string TenDV = cbTenDV.SelectedItem.ToString();
                int GiaDV = int.Parse(txtGiaDV.Text);
                string qr = "UPDATE DichVu SET TenLoaiDV = N'" + TenDV + "', GiaLoaiDV = '" + GiaDV + "' " +
                    "WHERE MaDV = " + MaDV;
                dataGVDV.DataSource = KetNoi.Execute(qr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Sửa thành công", "Thông báo");
                LoadData();
                Refesh();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int MaDV = int.Parse(txtMaDV.Text);
                string qr = "DELETE FROM DichVu WHERE MaDV = " + MaDV;
                dataGVDV.DataSource = KetNoi.Execute(qr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                LoadData();
                Refesh();
            }
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void picRefesh_MouseEnter(object sender, EventArgs e)
        {
            picRefesh.BackColor = SystemColors.WindowFrame;
        }

        private void picRefesh_MouseLeave(object sender, EventArgs e)
        {
            picRefesh.BackColor = originalColor;
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            BtnThem();
        }
    }
}
