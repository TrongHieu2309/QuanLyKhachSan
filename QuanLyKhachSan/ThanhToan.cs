using QuanLyKhachSan.Temp;
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
    public partial class ThanhToan : Form
    {
        KetNoiCSDL ketnoi = new KetNoiCSDL();
        private Color originalColor;

        public ThanhToan()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string qr = "SELECT * FROM ThanhToan";
            dataGVThanhToan.DataSource = ketnoi.Execute(qr);
            DataTable dt = ketnoi.Execute(qr);
            if (dt.Rows.Count > 0) dataGVThanhToan.Enabled = true;
            else dataGVThanhToan.Enabled = false;
        }

        private void Refesh()
        {
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtSdt.Text = string.Empty;
            dateNgayDen.Value = DateTime.Now;
            dateNgayDi.Value = DateTime.Now;
            txtTongTien.Text = string.Empty;
            txtTraTruoc.Text = string.Empty;
            txtConLai.Text = string.Empty;
            rb30.Checked = false;
            rb40.Checked = false;
            rb50.Checked = false;
            btnDatCoc.Enabled = false;
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
            btnDatCoc.Enabled = false;
            btnTinhDT.Enabled = false;
            txtMaKH.Text = SharedData.MaKH.ToString();
            txtTenKH.Text = SharedData.TenKH;
            txtSdt.Text = SharedData.Sdt;
            txtTongTien.Text = SharedData.TongTien.ToString();
            picRefesh.BackColor = originalColor;
            picRefesh1.BackColor = originalColor;

            rb30.Checked = false;
            rb40.Checked = false;
            rb50.Checked = false;
        }

        private void btnDatCoc_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = txtMaKH.Text;
                string TenKH = txtTenKH.Text;
                string Sdt = txtSdt.Text;
                DateTime NgayDen = SharedData.NgayDen;
                DateTime NgayDi = SharedData.NgayDi;
                int TongTien = int.Parse(txtTongTien.Text);
                int TraTruoc = int.Parse(txtTraTruoc.Text);
                int ConLai = int.Parse(txtConLai.Text);
                string TinhTrang = "Đã đặt cọc";

                // Định dạng ngày tháng
                string NgayDenStr = NgayDen.ToString("MM/dd/yyyy");
                string NgayDiStr = NgayDi.ToString("MM/dd/yyyy");

                string qr = "INSERT INTO ThanhToan (MaKH, TenKH, Sdt, NgayDen, NgayDi, TongTien, TraTruoc, ConLai, TinhTrang) " +
                            "VALUES ('" + MaKH + "', N'" + TenKH + "', '" + Sdt + "', '" + NgayDenStr + "', '" + NgayDiStr + "', " +
                            "'" + TongTien + "', '" + TraTruoc + "', '" + ConLai + "', N'" + TinhTrang + "')";
                int rowsAffected = ketnoi.ExecuteNonQuery(qr);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đặt cọc thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Đặt cọc thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnTinhDT_Click(object sender, EventArgs e)
        {
            try
            {
                string TinhTrang = "Đã thanh toán";

                string qrTinhDT = "SELECT * FROM ThanhToan WHERE TinhTrang = N'" + TinhTrang + "'";
                DataTable dtTinhDT = ketnoi.Execute(qrTinhDT);
                if (dtTinhDT.Rows.Count > 0)
                {
                    int DoanhThuNam = int.Parse(txtDoanhThuNam.Text);
                    if (cbDoanhThuThang.Text == string.Empty)
                    {
                        string qrKTTT = "SELECT * FROM ThanhToan WHERE YEAR(NgayDi) = '" + DoanhThuNam + "' " +
                            "AND TinhTrang = N'" + TinhTrang + "'";
                        dataGVThanhToan.DataSource = ketnoi.Execute(qrKTTT);

                        string qrDTNam = "SELECT SUM(TongTien) FROM ThanhToan " +
                            "WHERE YEAR(NgayDi) = '" + DoanhThuNam + "' " +
                            "AND TinhTrang = N'" + TinhTrang + "'";

                        DataTable dtDoanhThuNam = ketnoi.Execute(qrKTTT);
                        if (dtDoanhThuNam.Rows.Count > 0)
                        {
                            DataTable dtDTNam = ketnoi.Execute(qrDTNam);
                            if (dtDTNam.Rows.Count > 0)
                            {
                                int TongDT = Convert.ToInt32(dtDTNam.Rows[0][0]);
                                txtTongDT.Text = TongDT.ToString();
                            }
                        }
                        else MessageBox.Show("Không tìm thấy dữ liệu cho năm đã chọn", "Thông báo");
                    }
                    else
                    {
                        int DoanhThuThang = int.Parse(cbDoanhThuThang.SelectedItem.ToString());

                        string qrKTTT = "SELECT * FROM ThanhToan WHERE MONTH(NgayDi) = '" + DoanhThuThang + "' " +
                            "AND YEAR(NgayDi) = '" + DoanhThuNam + "'";
                        dataGVThanhToan.DataSource = ketnoi.Execute(qrKTTT);

                        string qrKTTT1 = "SELECT * FROM ThanhToan WHERE YEAR(NgayDi) = '" + DoanhThuNam + "' " +
                            "AND YEAR(NgayDi) = '" + DoanhThuNam + "' AND TinhTrang != N'" + TinhTrang + "'";
                        DataTable dtKTTT1 = ketnoi.Execute(qrKTTT1);
                        if (dtKTTT1.Rows.Count > 0)
                        {
                            MessageBox.Show("Khách hàng chưa thanh toán");
                            return;
                        }

                        string qrDTThang = "SELECT SUM(TongTien) FROM ThanhToan " +
                            "WHERE MONTH(NgayDi) = '" + DoanhThuThang + "' AND YEAR(NgayDi) = '" + DoanhThuNam + "' " +
                            "AND TinhTrang = N'" + TinhTrang + "'";

                        DataTable dtDoangThuThang = ketnoi.Execute(qrKTTT);
                        if (dtDoangThuThang.Rows.Count > 0)
                        {
                            DataTable dtDTThang = ketnoi.Execute(qrDTThang);
                            if (dtDTThang.Rows.Count > 0)
                            {
                                int TongDT = Convert.ToInt32(dtDTThang.Rows[0][0]);
                                txtTongDT.Text = TongDT.ToString();
                            }
                            else MessageBox.Show("Khách hàng chưa thanh toán");
                        }
                        else MessageBox.Show("Không tìm thấy dữ liệu cho tháng, năm đã chọn", "Thông báo");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rb30_CheckedChanged(object sender, EventArgs e)
        {
            if (rb30.Checked == true)
            {
                int TongTien = SharedData.TongTien;
                int TraTruoc = (int)(TongTien * 0.30);
                int Conlai = TongTien - TraTruoc;

                txtTraTruoc.Text = TraTruoc.ToString();
                txtConLai.Text = Conlai.ToString();
                btnDatCoc.Enabled = true;
            }

        }

        private void rb40_CheckedChanged(object sender, EventArgs e)
        {
            if (rb40.Checked == true)
            {
                int TongTien = SharedData.TongTien;
                int TraTruoc = (int)(TongTien * 0.40);
                int Conlai = TongTien - TraTruoc;

                txtTraTruoc.Text = TraTruoc.ToString();
                txtConLai.Text = Conlai.ToString();
                btnDatCoc.Enabled = true;
            }

        }

        private void rb50_CheckedChanged(object sender, EventArgs e)
        {
            if (rb50.Checked == true)
            {
                int TongTien = SharedData.TongTien;
                int TraTruoc = (int)(TongTien * 0.50);
                int Conlai = TongTien - TraTruoc;

                txtTraTruoc.Text = TraTruoc.ToString();
                txtConLai.Text = Conlai.ToString();
                btnDatCoc.Enabled = true;
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
            Refesh();
            LoadData();
        }

        private void txtDoanhThuNam_TextChanged(object sender, EventArgs e)
        {
            btnTinhDT.Enabled = !string.IsNullOrWhiteSpace(txtDoanhThuNam.Text);
        }

        private void picRefesh1_MouseEnter(object sender, EventArgs e)
        {
            picRefesh1.BackColor = SystemColors.WindowFrame;
        }

        private void picRefesh1_MouseLeave(object sender, EventArgs e)
        {
            picRefesh1.BackColor = originalColor;
        }

        private void picRefesh1_Click(object sender, EventArgs e)
        {
            cbDoanhThuThang.Text = string.Empty;
            txtDoanhThuNam.Text = string.Empty;
            txtTongDT.Text = string.Empty;
            LoadData();
        }

        private void txtDoanhThuNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
