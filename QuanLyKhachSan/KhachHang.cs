using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKhachSan.Temp;

namespace QuanLyKhachSan
{
    public partial class KhachHang : Form
    {
        KetNoiCSDL KetNoi = new KetNoiCSDL();
        private Color originalColor;

        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadcbTenDV();
            picRefesh.BackColor = originalColor;
            btnDatPhong.Enabled = false;
            btnTim.Enabled = false;
        }

        private void LoadcbTenDV()
        {
            cbDV.Items.Clear();
            string qr = "SELECT TenLoaiDV FROM LoaiDV";
            DataTable dt = KetNoi.Execute(qr);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbDV.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }

        private void LoadData()
        {
            string qr = "SELECT * FROM KhachHang";
            dataGVKhachHang.DataSource = KetNoi.Execute(qr);
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0) dataGVKhachHang.Enabled = true;
            else dataGVKhachHang.Enabled = false;
        }

        private void Refesh()
        {
            txtMaKH.Text = string.Empty;
            timeNgaySinh.Value = DateTime.Now;
            cbGioiTinh.SelectedIndex = -1;
            txtTenKH.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtTim.Text = string.Empty;
            btnDatPhong.Enabled = false;
            btnTim.Enabled = false;
        }

        private void BtnDatPhong()
        {
            btnDatPhong.Enabled = !string.IsNullOrWhiteSpace(cbGioiTinh.Text) &&
                !string.IsNullOrWhiteSpace(txtTenKH.Text) && !string.IsNullOrWhiteSpace(txtSdt.Text);
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                string TenKH = txtTenKH.Text;
                DateTime NgaySinh = timeNgaySinh.Value;
                string sdt = txtSdt.Text;
                string GioiTinh = cbGioiTinh.SelectedItem.ToString();
                string TenDV = cbDV.Text;

                string qrDV = "SELECT MaLoaiDV FROM LoaiDV WHERE TenLoaiDV = N'" + TenDV + "'";                

                string formattedNgaySinh = NgaySinh.ToString("MM/dd/yyyy");
                string qr = "INSERT INTO KhachHang OUTPUT INSERTED.MaKH " +
                            "VALUES (N'" + TenKH + "', '" + formattedNgaySinh + "', N'" + GioiTinh + "', " +
                            "'" + sdt + "')";

                string qrKT = "SELECT MaKH FROM KhachHang WHERE Sdt = '" + sdt + "'";
                DataTable dtKT = KetNoi.Execute(qrKT);
                if (dtKT.Rows.Count > 0)
                {
                    int MaKH = int.Parse(dtKT.Rows[0][0].ToString());

                    if (MaKH.ToString() == txtMaKH.Text)
                    {
                        SharedData.MaKH = MaKH;
                        SharedData.TenKH = TenKH;
                        SharedData.Sdt = sdt;

                        if (cbDV.Text == string.Empty && txtGiaDV.Text == string.Empty)
                        {
                            string qrXoaDV = "DELETE FROM DichVu WHERE MaKH = '" + MaKH + "'";
                            KetNoi.ExecuteNonQuery(qrXoaDV);
                        }
                        else
                        {
                            DataTable dtDV = KetNoi.Execute(qrDV);
                            int MaLoaiDV = Convert.ToInt32(dtDV.Rows[0]["MaLoaiDV"]);

                            string qrKTDV = "SELECT * FROM DichVu WHERE MaKH = '" + MaKH + "'";
                            DataTable dtKTDV = KetNoi.Execute(qrKTDV);
                            if (dtKTDV.Rows.Count > 0)
                            {
                                string qrUpdate = "UPDATE DichVu SET TenLoaiDV = '" + TenDV + "', " +
                                "GiaLoaiDV = '" + txtGiaDV.Text + "' WHERE MaKH = '" + MaKH + "'";
                                KetNoi.ExecuteNonQuery(qrUpdate);
                            }
                            else
                            {
                                string qrLoaiDV = "INSERT INTO DichVu VALUES ('" + MaLoaiDV + "', N'" + TenDV + "', " +
                                    "'" + txtGiaDV.Text + "', '" + MaKH + "')";
                                KetNoi.ExecuteNonQuery(qrLoaiDV);
                            }
                        }

                        MessageBox.Show("Chào mừng quý khách đã quay trở lại\nVui lòng đặt phòng", "Thông báo");

                        Phong frmPhong = new Phong();
                        frmPhong.grbNhapTT.Enabled = false;
                        frmPhong.ShowDialog();
                        this.Hide();
                        this.Close();
                    }
                    else MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo");
                }
                else
                {
                    DataTable dt = KetNoi.Execute(qr);
                    if (dt.Rows.Count > 0)
                    {
                        if (int.TryParse(dt.Rows[0]["MaKH"].ToString(), out int MaKH))
                        {
                            SharedData.MaKH = MaKH;
                            SharedData.TenKH = TenKH;
                            SharedData.Sdt = sdt;

                            if (cbDV.Text == string.Empty && txtGiaDV.Text == string.Empty)
                            {
                                MessageBox.Show("Đã thêm thông tin khách hàng\nVui lòng đặt phòng", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            else
                            {
                                DataTable dtDV = KetNoi.Execute(qrDV);
                                int MaLoaiDV = Convert.ToInt32(dtDV.Rows[0]["MaLoaiDV"]);

                                string qrLoaiDV = "INSERT INTO DichVu VALUES ('" + MaLoaiDV + "', N'" + TenDV + "', " +
                                    "'" + txtGiaDV.Text + "', '" + MaKH + "')";
                                KetNoi.ExecuteNonQuery(qrLoaiDV);

                                MessageBox.Show("Đã thêm thông tin khách hàng và dịch vụ " + TenDV +
                                    "\nVui lòng đặt phòng", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.None);
                            }

                            Phong frmPhong = new Phong();
                            frmPhong.grbNhapTT.Enabled = false;
                            frmPhong.ShowDialog();
                            this.Hide();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi chuyển đổi MaKH", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData();
                Refesh();
            }
        }

        private void dataGVKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGVKhachHang.CurrentRow.Index;
            txtMaKH.Text = dataGVKhachHang.Rows[index].Cells[0].Value.ToString();
            txtTenKH.Text = dataGVKhachHang.Rows[index].Cells[1].Value.ToString();
            timeNgaySinh.Text = dataGVKhachHang.Rows[index].Cells[2].Value.ToString();
            cbGioiTinh.Text = dataGVKhachHang.Rows[index].Cells[3].Value.ToString();
            txtSdt.Text = dataGVKhachHang.Rows[index].Cells[4].Value.ToString();
        }

        private void cbDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TenDV = cbDV.SelectedItem.ToString();
            string qr = "SELECT GiaLoaiDV FROM LoaiDV WHERE TenLoaiDV = N'" + TenDV + "'";
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0)
            {
                int GiaDV = Convert.ToInt32(dt.Rows[0]["GiaLoaiDV"]);
                txtGiaDV.Text = GiaDV.ToString();
            }
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnDatPhong();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            BtnDatPhong();
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            BtnDatPhong();
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
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

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string Sdt = txtTim.Text;
            string queryTim = "SELECT * FROM KhachHang WHERE Sdt = '" + Sdt + "'";
            dataGVKhachHang.DataSource = KetNoi.Execute(queryTim);
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            btnTim.Enabled = !string.IsNullOrWhiteSpace(txtTim.Text);
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
