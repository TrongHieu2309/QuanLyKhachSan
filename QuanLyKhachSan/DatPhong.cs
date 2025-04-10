using QuanLyKhachSan.Temp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class DatPhong : Form
    {
        private Color originalColor;
        private int _gia1ngay = 0;
        private int _tongtienCoDV = 0;
        private int _tongtienKoDV = 0;

        KetNoiCSDL KetNoi = new KetNoiCSDL();

        public DatPhong()
        {
            InitializeComponent();
        }

        private void Refesh()
        {
            txtUser.Text = string.Empty;
            txtMaPhong.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtLoaiPhong.Text = string.Empty;
            txtSoPhong.Text = string.Empty;
            dateNgayDen.Value = DateTime.Now;
            dateNgayDi.Value = DateTime.Now;
            txtSdt.Text = string.Empty;
            txtTim.Text = string.Empty;

            btnAccept.Enabled = false;
            btnCancle.Enabled = false;
            btnTim.Enabled = false;
        }

        private void LoadData()
        {
            //string TinhTrang = "Đã đặt";
            string qr = "SELECT * FROM DatPhong"; // WHERE TinhTrang = N'" + TinhTrang + "'";
            dataGVDatPhong.DataSource = KetNoi.Execute(qr);
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0) dataGVDatPhong.Enabled = true;
            else dataGVDatPhong.Enabled = false;
        }

        private void BtnDatPhong()
        {
            btnDatPhong.Enabled = !string.IsNullOrWhiteSpace(txtUser.Text) && 
                !string.IsNullOrWhiteSpace(txtSoLuong.Text) && !string.IsNullOrWhiteSpace(txtMaPhong.Text);            
        }

        bool Date()
        {
            DateTime NgayDen = dateNgayDen.Value.Date;
            DateTime NgayDi = dateNgayDi.Value.Date;
            int SoNgay = (NgayDi - NgayDen).Days;
            if (SoNgay < 0) return false;
            return true;
        }

        private void NhanPhong_Load(object sender, EventArgs e)
        {
            LoadData();

            btnCancle.Enabled = false;
            btnAccept.Enabled = false;
            btnTim.Enabled = false;
            btnDatPhong.Enabled = false;

            txtMaKH.Text = SharedData.MaKH.ToString();
            txtTenKH.Text = SharedData.TenKH;
            txtSdt.Text = SharedData.Sdt;
            txtMaPhong.Text = SharedData.MaPhong.ToString();
            txtLoaiPhong.Text = SharedData.LoaiPhong;
            txtSoPhong.Text = SharedData.SoPhong;
            picRefesh.BackColor = originalColor;
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (Date() == false) MessageBox.Show("Chọn ngày đến và ngày đi");
                else
                {
                    if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên đăng nhập\nSố lượng khách hàng", "Thông báo");
                    }
                    else
                    {
                        string TenKH = txtTenKH.Text;
                        string SoLuong = txtSoLuong.Text;
                        string LoaiPhong = txtLoaiPhong.Text;
                        string SoPhong = txtSoPhong.Text;
                        DateTime NgayDen = dateNgayDen.Value;
                        DateTime NgayDi = dateNgayDi.Value;
                        string sdt = txtSdt.Text;
                        string TinhTrang = "Đã đặt";
                        string MaKH = txtMaKH.Text;
                        string MaPhong = txtMaPhong.Text;
                        string qrDV = "SELECT TenLoaiDV, GiaLoaiDV FROM DichVu WHERE MaKH = " + MaKH;
                        DataTable dtDV = KetNoi.Execute(qrDV);
                        if (dtDV.Rows.Count > 0)
                        {
                            int GiaDV = Convert.ToInt32(dtDV.Rows[0]["GiaLoaiDV"]);
                            string TenDV = dtDV.Rows[0]["TenLoaiDV"].ToString();

                            // Tính toán TongTien có dịch vụ
                            DateTime ngayDen = dateNgayDen.Value.Date;
                            DateTime ngayDi = dateNgayDi.Value.Date;
                            int SoNgay = (ngayDi - ngayDen).Days;

                            string qr = "SELECT Gia1Ngay FROM Phong WHERE MaPhong = '" + MaPhong + "'";
                            DataTable dt = KetNoi.Execute(qr);
                            if (dt.Rows.Count > 0)
                            {
                                _gia1ngay = Convert.ToInt32(dt.Rows[0][0]);
                            }

                            _tongtienCoDV = (SoNgay * _gia1ngay) + GiaDV;

                            DialogResult result1 = MessageBox.Show(" Đặt phòng thành công\nTổng tiền của quý khách bao gồm dịch vụ " +
                                "" + TenDV + " là: " + _tongtienCoDV.ToString() + "\n" +
                                "Quý khách có muốn cọc trước không?", "Cọc trước",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                SharedData.NgayDen = dateNgayDen.Value.Date;
                                SharedData.NgayDi = dateNgayDi.Value.Date;
                                SharedData.TongTien = _tongtienCoDV;                                

                                string User = txtUser.Text;
                                string qrTK = "SELECT MaTK FROM TaiKhoan WHERE Username = '" + User + "'";
                                DataTable dtTK = KetNoi.Execute(qrTK);
                                int MaTK = Convert.ToInt32(dtTK.Rows[0][0]);

                                // Định dạng ngày tháng
                                string NgayDenStr = NgayDen.ToString("MM/dd/yyyy");
                                string NgayDiStr = NgayDi.ToString("MM/dd/yyyy");

                                string qr1 = "INSERT INTO DatPhong VALUES ('" + MaTK + "', '" + MaPhong + "'," +
                                    " '" + MaKH + "', N'" + TenKH + "', N'" + LoaiPhong + "', N'" + SoPhong + "'," +
                                    " '" + SoLuong + "', '" + NgayDenStr + "', '" + NgayDiStr + "', '" + sdt + "', N'" + TinhTrang + "')";
                                dataGVDatPhong.DataSource = KetNoi.Execute(qr1);
                                string qr2 = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' WHERE MaPhong = " + MaPhong;
                                KetNoi.ExecuteNonQuery(qr2);
                                
                                ThanhToan frmThanhToan = new ThanhToan();
                                this.Hide();
                                this.Close();
                                frmThanhToan.grbNhapTT.Visible = true;
                                frmThanhToan.grbTinhDT.Visible = false;
                                frmThanhToan.ShowDialog();
                            }
                            else
                            {
                                string TinhTrangThanhToan = "Chưa thanh toán";
                                string User = txtUser.Text;
                                string qrTK = "SELECT MaTK FROM TaiKhoan WHERE Username = '" + User + "'";
                                DataTable dtTK = KetNoi.Execute(qrTK);
                                int MaTK = Convert.ToInt32(dtTK.Rows[0][0]);

                                // Định dạng ngày tháng
                                string NgayDenStr = NgayDen.ToString("MM/dd/yyyy");
                                string NgayDiStr = NgayDi.ToString("MM/dd/yyyy");

                                string qr1 = "INSERT INTO DatPhong VALUES ('" + MaTK + "', '" + MaPhong + "'," +
                                    " '" + MaKH + "', N'" + TenKH + "', N'" + LoaiPhong + "', N'" + SoPhong + "'," +
                                    " '" + SoLuong + "', '" + NgayDenStr + "', '" + NgayDiStr + "', '" + sdt + "', N'" + TinhTrang + "')";
                                DataTable dt1 = KetNoi.Execute(qr1);

                                string qr2 = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' WHERE MaPhong = " + MaPhong;
                                KetNoi.ExecuteNonQuery(qr2);

                                string qrThanhToan = "INSERT INTO ThanhToan VALUES ('" + MaKH + "', N'" + TenKH + "', '" + sdt + "', " +
                                        "'" + NgayDenStr + "', '" + NgayDiStr + "', '" + _tongtienCoDV + "', '', '" + _tongtienCoDV + "', N'" + TinhTrangThanhToan + "')";
                                KetNoi.ExecuteNonQuery(qrThanhToan);
                            }
                        }
                        else
                        {
                            // Tính toán TongTien không có dịch vụ
                            DateTime ngayDen = dateNgayDen.Value.Date;
                            DateTime ngayDi = dateNgayDi.Value.Date;
                            int SoNgay = (ngayDi - ngayDen).Days;

                            string qr = "SELECT Gia1Ngay FROM Phong WHERE MaPhong = '" + MaPhong + "'";
                            DataTable dt = KetNoi.Execute(qr);
                            if (dt.Rows.Count > 0)
                            {
                                _gia1ngay = Convert.ToInt32(dt.Rows[0][0]);
                            }

                            _tongtienKoDV = SoNgay * _gia1ngay;

                            DialogResult result1 = MessageBox.Show("Đặt phòng thành công\nTổng tiền của quý khách là: " + _tongtienKoDV + "\n" +
                                "Quý khách có muốn cọc trước không?", "Cọc trước",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                SharedData.NgayDen = dateNgayDen.Value;
                                SharedData.NgayDi = dateNgayDi.Value;
                                SharedData.TongTien = _tongtienKoDV;

                                string User = txtUser.Text;
                                string qrTK = "SELECT MaTK FROM TaiKhoan WHERE Username = '" + User + "'";
                                DataTable dtTK = KetNoi.Execute(qrTK);
                                int MaTK = Convert.ToInt32(dtTK.Rows[0][0]);

                                // Định dạng ngày tháng
                                string NgayDenStr = NgayDen.ToString("MM/dd/yyyy");
                                string NgayDiStr = NgayDi.ToString("MM/dd/yyyy");

                                string qr1 = "INSERT INTO DatPhong VALUES ('" + MaTK + "', '" + MaPhong + "'," +
                                    " '" + MaKH + "', N'" + TenKH + "', N'" + LoaiPhong + "', N'" + SoPhong + "'," +
                                    " '" + SoLuong + "', '" + NgayDenStr + "', '" + NgayDiStr + "', '" + sdt + "', N'" + TinhTrang + "')";
                                dataGVDatPhong.DataSource = KetNoi.Execute(qr1);
                                string qr2 = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' WHERE MaPhong = " + MaPhong;
                                KetNoi.ExecuteNonQuery(qr2);
                                
                                ThanhToan frmThanhToan = new ThanhToan();
                                this.Hide();
                                this.Close();
                                frmThanhToan.grbNhapTT.Visible = true;
                                frmThanhToan.grbTinhDT.Visible = false;
                                frmThanhToan.ShowDialog();
                            }
                            else
                            {
                                string User = txtUser.Text;
                                string qrTK = "SELECT MaTK FROM TaiKhoan WHERE Username = '" + User + "'";
                                DataTable dtTK = KetNoi.Execute(qrTK);
                                int MaTK = Convert.ToInt32(dtTK.Rows[0][0]);

                                // Định dạng ngày tháng
                                string NgayDenStr = NgayDen.ToString("MM/dd/yyyy");
                                string NgayDiStr = NgayDi.ToString("MM/dd/yyyy");

                                string qr1 = "INSERT INTO DatPhong VALUES ('" + MaTK + "', '" + MaPhong + "'," +
                                    " '" + MaKH + "', N'" + TenKH + "', N'" + LoaiPhong + "', N'" + SoPhong + "'," +
                                    " '" + SoLuong + "', '" + NgayDenStr + "', '" + NgayDiStr + "', '" + sdt + "', N'" + TinhTrang + "')";
                                dataGVDatPhong.DataSource = KetNoi.Execute(qr1);

                                string qrThanhToan = "INSERT INTO ThanhToan VALUES ('" + MaKH + "', N'" + TenKH + "', '" + sdt + "', " +
                                        "'" + NgayDenStr + "', '" + NgayDiStr + "', '" + _tongtienKoDV + "', '', '" + _tongtienKoDV + "', N'" + "Chưa thanh toán" + "')";
                                KetNoi.ExecuteNonQuery(qrThanhToan);                                

                                string qr2 = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' WHERE MaPhong = " + MaPhong;
                                KetNoi.ExecuteNonQuery(qr2);                                
                            }
                        }
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                int MaPhong = int.Parse(txtMaPhong.Text);
                int MaDP = int.Parse(txtMaDP.Text);
                string TinhTrang = "Đã nhận";
                string qrCheck = "SELECT * FROM DatPhong WHERE MaDatPhong = '" + MaDP + "'";
                DataTable dtCheck = KetNoi.Execute(qrCheck);
                string TinhTrang1 = Convert.ToString(dtCheck.Rows[0]["TinhTrang"]);
                if (TinhTrang1 == "Đã nhận")
                {
                    MessageBox.Show("Phòng đã được nhận rồi!", "Thông báo");
                }
                else
                {
                    string qr = "UPDATE DatPhong SET TinhTrang = N'" + TinhTrang + "' " +
                        "WHERE MaDatPhong = " + MaDP;
                    string qrP = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' " +
                        "WHERE MaPhong = " + MaPhong;
                    KetNoi.ExecuteNonQuery(qrP);
                    DataTable dt = KetNoi.Execute(qr);
                    MessageBox.Show("Nhận phòng thành công", "Thông báo");
                    LoadData();
                    Refesh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGVDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAccept.Enabled = true;
            btnCancle.Enabled = true;
            btnDatPhong.Enabled = false;

            int index = dataGVDatPhong.CurrentRow.Index;
            
            // Lấy giá trị MaTK từ bảng DatPhong
            int MaTK = int.Parse(dataGVDatPhong.Rows[index].Cells[1].Value.ToString());

            // Truy vấn Username từ bảng TaiKhoan dựa trên MaTK
            string qr = "SELECT Username FROM TaiKhoan WHERE MaTK = " + MaTK;
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0)
            {
                txtUser.Text = dt.Rows[0]["Username"].ToString();
            }

            txtMaDP.Text = dataGVDatPhong.Rows[index].Cells[0].Value.ToString();
            txtMaPhong.Text = dataGVDatPhong.Rows[index].Cells[2].Value.ToString();
            txtMaKH.Text = dataGVDatPhong.Rows[index].Cells[3].Value.ToString();
            txtTenKH.Text = dataGVDatPhong.Rows[index].Cells[4].Value.ToString();
            txtLoaiPhong.Text = dataGVDatPhong.Rows[index].Cells[5].Value.ToString();
            txtSoPhong.Text = dataGVDatPhong.Rows[index].Cells[6].Value.ToString();
            txtSoLuong.Text = dataGVDatPhong.Rows[index].Cells[7].Value.ToString();
            dateNgayDen.Text = dataGVDatPhong.Rows[index].Cells[8].Value.ToString();
            dateNgayDi.Text = dataGVDatPhong.Rows[index].Cells[9].Value.ToString();
            txtSdt.Text = dataGVDatPhong.Rows[index].Cells[10].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sdt = txtTim.Text;

            string qr = "SELECT * FROM DatPhong WHERE Sdt = " + sdt;
            DataTable dt = KetNoi.Execute(qr);
            if (dt.Rows.Count > 0) dataGVDatPhong.DataSource = KetNoi.Execute(qr);
            else MessageBox.Show("Không tìm thấy", "Thông báo");
        }

        private void picRefesh_Click(object sender, EventArgs e)
        {
            Refesh();
            LoadData();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            try
            {
                int MaPhong = int.Parse(txtMaPhong.Text);
                int MaDatPhong = int.Parse(txtMaDP.Text);
                string TinhTrang = "Trống";
                string qr = "DELETE FROM DatPhong WHERE MaDatPhong = '" + MaDatPhong + "'";
                string qrP = "UPDATE Phong SET TinhTrang = N'" + TinhTrang + "' " +
                    "WHERE MaPhong = '" + MaPhong + "'";

                DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy?", "Hủy", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    KetNoi.ExecuteNonQuery(qrP);
                    dataGVDatPhong.DataSource = KetNoi.Execute(qr);
                    MessageBox.Show("Hủy phòng thành công", "Thông báo");
                    LoadData();
                    Refesh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            btnTim.Enabled = !string.IsNullOrWhiteSpace(txtTim.Text);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            BtnDatPhong();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            BtnDatPhong();
        }

        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {
            BtnDatPhong();
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
