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
    public partial class NhanPhong : Form
    {
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        private Color originalColor;

        public NhanPhong()
        {
            InitializeComponent();
        }

        private void Refesh()
        {
            txtMaTK.Text = string.Empty;
            txtMaPhong.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtLoaiPhong.Text = string.Empty;
            txtSoPhong.Text = string.Empty;
            dateNgayDen.Value = DateTime.Now;
            dateNgayDi.Value = DateTime.Now;
            txtSdt.Text = string.Empty;
            btnTraPhong.Enabled = false;
        }

        private void LoadData()
        {
            string TinhTrang = "Đã nhận";
            string qr = "SELECT MaTK, MaPhong, MaKH, TenKH, SoLuong, TenLoaiPhong, TenPhong, NgayDen, NgayDi, Sdt, TinhTrang" +
                " FROM DatPhong WHERE TinhTrang = N'" + TinhTrang + "'";
            dataGVDatPhong.DataSource = KetNoi.Execute(qr);
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0) dataGVDatPhong.Enabled = true;
            else dataGVDatPhong.Enabled = false;
        }

        private void NhanPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            btnTraPhong.Enabled = false;
        }

        private void dataGVDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnTraPhong.Enabled = true;

            int index = dataGVDatPhong.CurrentRow.Index;
            txtMaTK.Text = dataGVDatPhong.Rows[index].Cells[0].Value.ToString();
            txtMaPhong.Text = dataGVDatPhong.Rows[index].Cells[1].Value.ToString();
            txtMaKH.Text = dataGVDatPhong.Rows[index].Cells[2].Value.ToString();
            txtTenKH.Text = dataGVDatPhong.Rows[index].Cells[3].Value.ToString();
            txtSoLuong.Text = dataGVDatPhong.Rows[index].Cells[4].Value.ToString();
            txtLoaiPhong.Text = dataGVDatPhong.Rows[index].Cells[5].Value.ToString();
            txtSoPhong.Text = dataGVDatPhong.Rows[index].Cells[6].Value.ToString();
            dateNgayDen.Text = dataGVDatPhong.Rows[index].Cells[7].Value.ToString();
            dateNgayDi.Text = dataGVDatPhong.Rows[index].Cells[8].Value.ToString();
            txtSdt.Text = dataGVDatPhong.Rows[index].Cells[9].Value.ToString();
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận trả phòng", "Xác nhận", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string TinhTrang = "Đã trả";
                    string MaPhong = txtMaPhong.Text;
                    string qr = "UPDATE DatPhong SET TinhTrang = N'" + TinhTrang + "' " +
                        "WHERE MaPhong = '" + MaPhong + "'";
                    string qrP = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' " +
                        "WHERE MaPhong = '" + MaPhong + "'";
                    KetNoi.ExecuteNonQuery(qr);
                    KetNoi.ExecuteNonQuery(qrP);

                    string MaTK = txtMaTK.Text;
                    string MaKH = txtMaKH.Text;
                    string TenKH = txtTenKH.Text;
                    string TenLoaiPhong = txtLoaiPhong.Text;
                    string SoPhong = txtSoPhong.Text;
                    string SoLuong = txtSoLuong.Text;
                    DateTime NgayDen = dateNgayDen.Value;
                    DateTime NgayDi = dateNgayDi.Value;
                    string Sdt = txtSdt.Text;

                    // Đảm bảo ngày tháng được định dạng chính xác cho SQL Server
                    string NgayDenStr = NgayDen.ToString("MM/dd/yyyy");
                    string NgayDiStr = NgayDi.ToString("MM/dd/yyyy");

                    string qrTraPhong = "INSERT INTO TraPhong VALUES ('" + MaTK + "', '" + MaPhong + "', '" + MaKH + "', N'" + TenKH + "', " +
                        "N'" + TenLoaiPhong + "', N'" + SoPhong + "', '" + SoLuong + "', '" + NgayDenStr + "', '" + NgayDiStr + "', '" + Sdt + "', N'" + TinhTrang + "')";
                    KetNoi.ExecuteNonQuery(qrTraPhong);

                    LoadData();
                    Refesh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
